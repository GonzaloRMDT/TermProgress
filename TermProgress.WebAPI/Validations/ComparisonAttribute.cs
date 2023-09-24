using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using TermProgress.WebAPI.Validations.Enums;

namespace TermProgress.WebAPI.Validations
{
    /// <summary>
    /// Represents the comparison validation attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ComparisonAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparisonAttribute"/> class.
        /// </summary>
        /// <param name="relation">The relation between comparison values.</param>
        /// <param name="referencePropertyName">The property name of the comparison reference value.</param>
        public ComparisonAttribute(Relation relation, string referencePropertyName)
        {
            Relation = relation;
            ReferencePropertyName = referencePropertyName;
            ErrorMessage ??= "The {0} property value has failed comparison of type {1} against {2} property value.";
        }

        /// <summary>
        /// Gets the relation between comparison values.
        /// </summary>
        public Relation Relation { get; }

        /// <summary>
        /// Gets the property name of the comparison reference value.
        /// </summary>
        public string ReferencePropertyName { get; }

        public override string FormatErrorMessage(string validatablePropertyName)
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                ErrorMessageString,
                validatablePropertyName,
                Enum.GetName(Relation),
                ReferencePropertyName);
        }

        /// <inheritdoc/>
        /// <exception cref="ValidationException">Thrown when the reference property is not found.</exception>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            PropertyInfo referenceProperty = validationContext.ObjectInstance
                .GetType()
                .GetProperty(ReferencePropertyName)
                ?? throw new ValidationException($"Reference property '{ReferencePropertyName}' could not be found.");

            IComparable? validatableValue = value as IComparable;
            IComparable? referenceValue = referenceProperty.GetValue(validationContext.ObjectInstance) as IComparable;

            if (validatableValue is null || referenceValue is null)
                return null;

            var isValid = validatableValue.CompareTo(referenceValue) switch
            {
                < 0 => Relation
                    is Relation.LessThan
                    or Relation.LessThanOrEqual
                    or Relation.NotEquals,
                0 => Relation
                    is Relation.Equals
                    or Relation.LessThanOrEqual
                    or Relation.GreaterThanOrEqual,
                > 0 => Relation
                    is Relation.GreaterThan
                    or Relation.GreaterThanOrEqual
                    or Relation.NotEquals
            };

            return isValid ?
                ValidationResult.Success :
                new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}