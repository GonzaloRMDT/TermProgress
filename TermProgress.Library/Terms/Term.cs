using System;

namespace TermProgress.Domain.Terms
{
    /// <summary>
    /// Represents a term.
    /// </summary>
    public class Term : ITerm
    {
        private DateTime? currentDate;
        private DateTime? endDate;
        private DateTime? startDate;

        public DateTime CurrentDate
        {
            get => currentDate ?? DateTime.Now.Date;
            init => currentDate = value;  // for testing purposes only
        }

        public int GetDaysElapsed()
        {
            TimeSpan elapsedTime = CurrentDate - GetStartDate();

            return elapsedTime.Days;
        }

        /// <inheritdoc/>
        public DateTime GetEndDate()
        {
            if (endDate is null)
            {
                throw new InvalidOperationException("End date is not set.");
            }

            return endDate.Value;
        }

        public double GetProgressRatio()
        {
            var elapsedDays = (double)GetDaysElapsed();
            var totalDays = (double)GetDaysTotal();

            return elapsedDays / totalDays;
        }

        public int GetDaysRemaining()
        {
            TimeSpan remainingTime = GetEndDate().AddDays(1) - CurrentDate;

            return remainingTime.Days;
        }

        public DateTime GetStartDate()
        {
            if (startDate is null)
            {
                throw new InvalidOperationException("Start date is not set.");
            }

            return startDate.Value;
        }

        public int GetDaysTotal()
        {
            TimeSpan totalTime = GetEndDate().AddDays(1) - GetStartDate();

            return totalTime.Days;
        }

        public void SetEndDate(DateTime value)
        {
            if (startDate is not null && value < GetStartDate())  // only try to get start date when set
            {
                throw new ArgumentException("Value cannot be less than start date.");
            }

            endDate = value;
        }

        public void SetStartDate(DateTime value)
        {
            if (endDate is not null && value > GetEndDate())  // only try to get end date when set
            {
                throw new ArgumentException("Value cannot be greater than end date.");
            }

            startDate = value;
        }
    }
}
