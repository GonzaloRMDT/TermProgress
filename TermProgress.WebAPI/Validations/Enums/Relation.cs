namespace TermProgress.WebAPI.Validations.Enums
{
    /// <summary>
    /// Enumerates the possible relations between values.
    /// </summary>
    public enum Relation
    {
        /// <summary>
        /// Initial value.
        /// </summary>
        /// <remarks>
        /// Not intended for use in comparisons.
        /// </remarks>
        None,

        /// <summary>
        /// The values are equal.
        /// </summary>
        Equals,

        /// <summary>
        /// The validatable value is greater than the reference value.
        /// </summary>
        GreaterThan,

        /// <summary>
        /// The validatable value is greater than or equal to the reference value.
        /// </summary>
        GreaterThanOrEqual,

        /// <summary>
        /// The validatable value is less than the reference value.
        /// </summary>
        LessThan,

        /// <summary>
        /// The validatable value is less than or equal to the reference value.
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// The values are not equal.
        /// </summary>
        NotEquals
    }
}
