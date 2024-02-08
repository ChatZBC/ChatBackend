using System.Reflection.Metadata.Ecma335;

namespace ChatBackend.Security.InputValidation
{
    public class InputValidationComposite : IInputValidator
    {
        public bool Validate(string input)
        {
            if (InputValidators.Count == 0)
            {
                throw new NotImplementedException("Unexpected usage of InputValidationComposite: No input validators added.");
            }

            foreach (IInputValidator inputValidator in InputValidators)
            {
                if (!inputValidator.Validate(input))
                {
                    return false;
                }
            }

            return true;
        }

        public void AddInputValidator(IInputValidator inputValidator)
        {
            InputValidators.Add(inputValidator);
        }

        public InputValidationComposite()
        {
            InputValidators = new List<IInputValidator>();
        }

        public InputValidationComposite(List<IInputValidator> inputValidators)
        {
            InputValidators = inputValidators;
        }

        private List<IInputValidator> InputValidators;
    }
}
