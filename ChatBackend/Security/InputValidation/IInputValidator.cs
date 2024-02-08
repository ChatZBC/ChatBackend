namespace ChatBackend.Security.InputValidation
{
    public interface IInputValidator
    {
        bool Validate(string input);
    }
}
