using ChatBackend.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChatBackend.Tests
{
    public class RateLimitTests
    {
        [Fact]
        public void IsRateAllowed_TrueWhenMessagesAreMoreThanOneSecondApart()
        {
            // Arrange
            DateTime lastMessageSent = DateTime.Now.AddSeconds(-2);
            MessageRateLimiter limiter = new MessageRateLimiter();

            // Act
            bool result = limiter.IsRateAllowed(lastMessageSent);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsRateAllowed_FalseWhenMessagesAreLessThanOneSecondApart()
        {
            // Arrange
            DateTime lastMessageSent = DateTime.Now.AddSeconds(-0.5);
            MessageRateLimiter limiter = new MessageRateLimiter();

            // Act
            bool result = limiter.IsRateAllowed(lastMessageSent);

            // Assert
            Assert.False(result);
        }
    }
}
