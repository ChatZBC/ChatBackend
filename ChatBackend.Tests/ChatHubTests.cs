using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ChatBackend.Hubs;
using Microsoft.Extensions.Logging;
using Moq;

namespace ChatBackend.Tests
{

    public class ChatHubTests
    {
        [Fact]
        public void ShouldLogMessage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ChatHub>>();
            ChatHub chatHub = new ChatHub(loggerMock.Object);
            string user = "test";
            string message = "test message";

            // Act
            chatHub.LogMessage(user, message);

            // Assert
            // Verify that the logger was called with a log level of Information (or whichever level we expect)
            // and that the message contains the expected text.
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information, // or the log level we are using
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains($"Message received from {user}: {message}")),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once); // Verify that the log method was called exactly once
        }
    }
}
