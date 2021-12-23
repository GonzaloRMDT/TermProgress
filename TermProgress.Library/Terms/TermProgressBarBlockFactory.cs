namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term progress bar block factory.
    /// </summary>
    /// <inheritdoc />
    public class TermProgressBarBlockFactory : ITermProgressBarBlockFactory
    {
        private const char COMPLETED_BLOCK = '▓';
        private const char UNCOMPLETED_BLOCK = '░';

        public TermProgressBarBlock CreateProgressBarBlock(double progressBarBlockDays, double elapsedDays)
        {
            return progressBarBlockDays <= elapsedDays ? CreateCompletedProgressBarBlock() : CreateUncompletedProgressBarBlock();
        }

        private TermProgressBarBlock CreateCompletedProgressBarBlock()
        {
            return new TermProgressBarBlock
            {
                Type = TermProgressBarBlockType.Completed,
                Symbol = COMPLETED_BLOCK
            };
        }

        private TermProgressBarBlock CreateUncompletedProgressBarBlock()
        {
            return new TermProgressBarBlock
            {
                Type = TermProgressBarBlockType.Uncompleted,
                Symbol = UNCOMPLETED_BLOCK
            };
        }
    }
}