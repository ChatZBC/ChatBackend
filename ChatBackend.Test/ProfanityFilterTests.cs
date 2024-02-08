using ChatBackend.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChatBackend.Test
{
    public class ProfanityFilterTests
    {
        [Fact]
        public void FilterProfanity_InputContainsProfanity_ShouldFilterProfanity()
        {
            // Arrange
            ProfanityFilter filter = new ProfanityFilter();
            string inputText = "This is a badword1 and badword2 example.";

            // Act
            string filteredText = filter.FilterProfanity(inputText);

            // Assert
            Assert.Equal("This is a ****** and ****** example.", filteredText);

        }

        [Fact]
        public void FilterProfanity_InputDoesNotContainProfanity_ShouldNotChangeText()
        {
            // Arrange
            ProfanityFilter filter = new ProfanityFilter();
            string inputText = "This is a clean example.";

            // Act
            string filteredText = filter.FilterProfanity(inputText);

            // Assert
            Assert.Equal(inputText, filteredText);
        }

        [Fact]
        public void FilterProfanity_InputIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            ProfanityFilter filter = new ProfanityFilter();
            string inputText = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => filter.FilterProfanity(inputText));
        }
    }
}
