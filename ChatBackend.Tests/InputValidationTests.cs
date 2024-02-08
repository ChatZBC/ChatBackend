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
    }
}