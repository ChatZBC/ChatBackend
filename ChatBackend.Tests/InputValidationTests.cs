using ChatBackend.Security.InputValidation;
using Xunit;

namespace ChatBackend.Tests
{
    public class InputValidationTests
    {
        [Fact]
        public void Validate_ExceptionWhenCompositeEmpty()
        {
            InputValidationComposite comp = new InputValidationComposite();
            Assert.Throws<InvalidOperationException>(() => comp.Validate(""));
        }

        [Fact]
        public void Validate_AllValidatorsPass()
        {
            InputValidationComposite comp = new InputValidationComposite();
            comp.AddInputValidator(new XSSValidator());
            Assert.True(comp.Validate("This is a normal message"));
        }

        [Fact]
        public void Validate_AllValidatorsFail()
        {
            InputValidationComposite comp = new InputValidationComposite();
            comp.AddInputValidator(new XSSValidator());
            Assert.False(comp.Validate("<script>alert('XSS');</script>"));
        }

        [Theory]
        [InlineData("<", false)]
        [InlineData(">", false)]
        [InlineData("This is a seemingly innocuous message.<script>alert('but it is not');</script>", false)]
        [InlineData("This message has done nothing wrong", true)]
        public void Validate_XSSValidatorDeniesHtmlTags(string input, bool expected)
        {
            XSSValidator xss = new XSSValidator();

            bool actual = xss.Validate(input);

            Assert.Equal(actual, expected);
        }
    }
}