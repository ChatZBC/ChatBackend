using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChatBackend.Tests
{
    [TestClass]
    public class ProfanityFilterTests
    {
        [Fact]
        public void ContainsProfanity_ReturnsTrue_WhenTextContainsProfanity()
        {
            // Arrange
            var profaneWords = new List<string> { "bad", "nasty", "horrible" };
            var filter = new ProfanityFilter(profaneWords);

            // Act
            bool containsProfanity = filter.ContainsProfanity("This is a bad example.");

            // Assert
            Assert.True(containsProfanity);
        }

        [Fact]
        public void ContainsProfanity_ReturnsFalse_WhenTextDoesNotContainProfanity()
        {
            // Arrange
            var profaneWords = new List<string> { "bad", "nasty", "horrible" };
            var filter = new ProfanityFilter(profaneWords);

            // Act
            bool containsProfanity = filter.ContainsProfanity("This is a good example.");

            // Assert
            Assert.False(containsProfanity);
        }

        [Fact]
        public void FilterProfanity_ReplacesProfanityWithAsterisks()
        {
            // Arrange
            var profaneWords = new List<string> { "bad", "nasty", "horrible" };
            var filter = new ProfanityFilter(profaneWords);

            // Act
            string filteredText = filter.FilterProfanity("This is a bad example.");

            // Assert
            Assert.Equal("This is a *** example.", filteredText);
        }
    }
}
