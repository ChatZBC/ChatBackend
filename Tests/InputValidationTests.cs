using ChatBackend.Security.InputValidation;

namespace Tests
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