namespace ChatBackend.Security.InputValidation
{
    public class XSSValidator : IInputValidator
    {
        public bool Validate(string input)
        {
            if (input.Contains('>') || input.Contains('<'))
            {
                return false;
            }
            return true;
        }
    }
}
