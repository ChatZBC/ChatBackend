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
        ChatHub chatHub = new(new Mock<ILogger<ChatHub>>().Object, new ConnectedUserTransient());
        //[Fact]
        //public void ShouldLogMessage()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<ChatHub>>();
        //    string user = "test";
        //    string message = "test message";

        //    // Act
        //    chatHub.LogMessage(user, message);

        //    // Assert
        //    // Verify that the logger was called with a log level of Information (or whichever level we expect)
        //    // and that the message contains the expected text.
        //    loggerMock.Verify(
        //        x => x.Log(
        //            LogLevel.Information, // or the log level we are using
        //            It.IsAny<EventId>(),
        //            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains($"Message received from {user}: {message}")),
        //            It.IsAny<Exception>(),
        //            It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
        //        Times.Once); // Verify that the log method was called exactly once
        //}

        [Fact]
        public void RequestUserList()
        {
            var user = chatHub.RequestUserList("User");
            Console.WriteLine(user);
        }

        [Fact]
        public void UpdateUserLists()
        {
            chatHub.UpdateUserList("user");
        }

        //[Theory]
        //[InlineData("test","message")] // cannot be tested since client are alway null
        //public async void SendMessage(string user, string message)
        //{
        //    await chatHub.SendMessage(user, message);
        //}

        [Fact]
        public void SendError()
        {
            chatHub.SendError("error");
        }
    }
}
