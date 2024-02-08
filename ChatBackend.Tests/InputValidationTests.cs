using ChatBackend.Security.InputValidation;
using Xunit;

namespace Chatbackend.Tests
{
    public class InputValidationTests
    {
        [Fact]
        public void Validate_ExceptionWhenCompositeEmpty()
        {
            InputValidationComposite comp = new InputValidationComposite();
            Assert.Throws<InvalidOperationException>(() => comp.Validate(""));
        }


    }
}