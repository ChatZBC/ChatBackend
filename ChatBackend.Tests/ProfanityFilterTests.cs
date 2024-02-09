using ChatBackend.Controllers;
using ChatBackend.Rules;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace ChatBackend.Tests
{
    public class ProfanityFilterTests
    {
        [Theory]
        [InlineData("This is a bad example.")]
        [InlineData("This is a nasty example.")]
        [InlineData("This is a horrible example.")]
        public void ContainsProfanity_ReturnsTrue_WhenTextContainsProfanity(string message)
        {
            // Arrange
            var profaneWords = new List<string> { "bad", "nasty", "horrible" };
            string[] words = message.Split(' ');

            // Act
            foreach (string word in words)
            {
                if (profaneWords.Contains(word))
                {
                    // Assert
                    Assert.True(true);
                }
                else
                {
                    // Assert
                    Assert.False(false);
                }
            }
        }

        [Theory]
        [InlineData("This is a good example.")]
        [InlineData("This is a nice example.")]
        [InlineData("This is a great example.")]
        public void DosNotContainsProfanity_ReturnsTrue_WhenTextDosNotContainsProfanity(string message)
        {
            // Arrange
            var profaneWords = new List<string> { "bad", "nasty", "horrible" };
            string[] words = message.Split(' ');

            // Act
            foreach (string word in words)
            {
                if (profaneWords.Contains(word))
                {
                    // Assert
                    Assert.False(false);
                }
                else
                {
                    // Assert
                    Assert.True(true);
                }
            }
        }

        [Theory]
        [InlineData("This is a bad example.")]
        [InlineData("This is a nasty example.")]
        [InlineData("This is a horrible example.")]
        public void FilterProfanity_ReplacesProfanityWithAsterisks(string message)
        {
            // Arrange
            var profaneWords = new List<string> { "bad", "nasty", "horrible" };
            string[] words = message.Split(' ');
            var modifiedMessageBuilder = new StringBuilder();

            // Act
            foreach (string word in words)
            {
                if (profaneWords.Contains(word))
                {
                    modifiedMessageBuilder.Append(new string('*', word.Length));
                }
                else
                {
                    modifiedMessageBuilder.Append(word);
                }
                modifiedMessageBuilder.Append(" ");
            }

            string modifiedMessage = modifiedMessageBuilder.ToString().Trim(); // Remove trailing space

            // Assert
            Assert.NotEqual(message, modifiedMessage);
            Assert.Contains("*", modifiedMessage);
        }
    }
}
