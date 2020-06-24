namespace TermProgress.Library.Terms
{
    public interface ITermProgressBarBlockFactory
    {
        /// <summary>
        /// Creates progress bar block according to given data.
        /// </summary>
        /// <param name="comparisonDays">Comparison days.</param>
        /// <param name="elapsedDays">Term elapsed days.</param>
        /// <returns>Progress bar block.</returns>
        TermProgressBarBlock CreateProgressBarBlock(double comparisonDays, double elapsedDays);
    }
}