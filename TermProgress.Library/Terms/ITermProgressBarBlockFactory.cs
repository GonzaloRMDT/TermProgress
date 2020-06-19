namespace TermProgress.Library.Terms
{
    public interface ITermProgressBarBlockFactory
    {
        /// <summary>
        /// Creates progress bar block according to given data.
        /// </summary>
        /// <param name="comparisonProgress">Comparison progress value.</param>
        /// <param name="termProgress">Term progress value.</param>
        /// <returns>Progress bar block.</returns>
        TermProgressBarBlock CreateProgressBarBlock(double comparisonProgress, double termProgress);
    }
}