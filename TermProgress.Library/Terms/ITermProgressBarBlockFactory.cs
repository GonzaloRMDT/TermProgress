namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Defines the common structure for term progress bar block factories.
    /// </summary>
    public interface ITermProgressBarBlockFactory
    {
        /// <summary>
        /// Creates progress bar block according to given data.
        /// </summary>
        /// <param name="comparisonDays">Comparison days.</param>
        /// <param name="elapsedDays">Term elapsed days.</param>
        /// <returns>A <see cref="TermProgressBarBlock"/> instance.</returns>
        TermProgressBarBlock CreateProgressBarBlock(double comparisonDays, double elapsedDays);
    }
}