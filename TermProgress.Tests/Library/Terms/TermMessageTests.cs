using Microsoft.Extensions.Options;
using System;
using TermProgress.Library.Options;
using TermProgress.Library.Terms;
using Xunit;

namespace TermProgress.Tests.Library.Terms
{
    /// <summary>
    /// Represents the <c>TermMessage</c> tests.
    /// </summary>
    public class TermMessageTests
    {
        [Fact]
        public void Bar_at_midnight_after_inauguration_is_empty()
        {
            // Act
            IOptions<TermOptions> termOptions = GetTermOptions();
            Term term = new Term(termOptions);
            term.CurrentDate = new DateTime(2019, 12, 11);
            TermMessage termMessage = new TermMessage(term);

            // Arrange
            var result = termMessage.GetBar();

            // Assert
            Assert.Equal("░░░░░░░░░░░░░░░", result);
        }

        [Fact]
        public void Bar_at_midnight_before_inauguration_is_full()
        {
            // Act
            IOptions<TermOptions> termOptions = GetTermOptions();
            Term term = new Term(termOptions);
            term.CurrentDate = new DateTime(2023, 12, 10);
            TermMessage termMessage = new TermMessage(term);

            // Arrange
            var result = termMessage.GetBar();

            // Assert
            Assert.Equal("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓", result);
        }

        private IOptions<TermOptions> GetTermOptions()
        {
            return Options.Create(new TermOptions()
            {
                StartingDateTime = new DateTime(2019, 12, 10, 10, 0, 0),
                EndingDateTime = new DateTime(2023, 12, 10, 0, 0, 0)
            });
        }
    }
}
