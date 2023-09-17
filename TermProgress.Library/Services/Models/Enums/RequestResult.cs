namespace TermProgress.Library.Services.Models.Enums
{
    /// <summary>
    /// Enumerates the request results.
    /// </summary>
    public enum RequestResult
    {
        /// <summary>
        /// The initial request result.
        /// </summary>
        /// <remarks>
        /// Only used when no tasks associated with the request have been performed.
        /// </remarks>
        None,

        /// <summary>
        /// The request produced an error.
        /// </summary>
        /// <remarks>
        /// Some tasks associated with the request have been performed, but it could not be completed
        /// at this time due to an error. The request will not be scheduled for later retry
        /// and no further action will be taken.
        /// </remarks>
        Error,

        /// <summary>
        /// The request has been scheduled.
        /// </summary>
        /// <remarks>
        /// Some tasks associated with the request may have been performed, but it could not be
        /// completed at this time. The request has been scheduled for later retry,
        /// but no future completion is guaranteed.
        /// </remarks>
        Scheduled,

        /// <summary>
        /// The request has been completed successfully.
        /// </summary>
        /// <remarks>
        /// All tasks associated with the request have been completed successfully.
        /// </remarks>
        Success
    }
}
