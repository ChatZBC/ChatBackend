using ChatBackend;
using ChatBackend.Rules;
using Xunit;

namespace ChatBackend.Tests
{
    public  class MessageCheckerTests
    {

        [Theory]
        [InlineData("Profanity")]
        [InlineData("Confanity")]
        [InlineData("Issues")]
        [InlineData("/kick William")]
        [InlineData("Something entirely new!")]
        public void ShouldCheckMessage(string message)
        {
            // Arrange
            bool actual = false;
            bool expected = false;
            MessageChecker messageChecker = new MessageChecker();
            // Act
            switch (message)
            {

                // Does message contain profanity?
                case "Profanity":
                    {
                        actual = messageChecker.CheckMessage("Profanity");
                        expected = false;
                        break;
                    }
                // Does message contain confanity?
                case "Confanity":
                    {
                        actual = messageChecker.CheckMessage("Confanity");
                        expected = true;
                        break;
                    }
                // Does message contain security issues?
                case "Issues":
                    {
                        actual = messageChecker.CheckMessage("Issues");
                        expected = false;
                        break;
                    }
                // Does message contain chat commands?
                case "/kick William":
                    {
                        actual = messageChecker.CheckMessage("/kick William");
                        expected = false;
                        break;
                    }
                    
                default:
                    break;
            }
            bool result = (actual == expected);



        // Assert
        Assert.True(result);
        }
    }
}
