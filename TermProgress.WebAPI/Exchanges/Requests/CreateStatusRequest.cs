using System;
using System.ComponentModel.DataAnnotations;
using TermProgress.WebAPI.Validations;
using TermProgress.WebAPI.Validations.Enums;

namespace TermProgress.WebAPI.Exchanges.Requests
{
    /// <summary>
    /// Represents a status creation request.
    /// </summary>
    public record class CreateStatusRequest
    {
        /// <summary>
        /// Gets or initializes the start date.
        /// </summary>
        [Required]
        [Comparison(Relation.LessThan, "EndDate")]
        public DateTime? StartDate { get; init; }

        /// <summary>
        /// Gets or initializes the end date.
        /// </summary>
        [Required]
        [Comparison(Relation.GreaterThan, "StartDate")]
        public DateTime? EndDate { get; init; }
    }
}
