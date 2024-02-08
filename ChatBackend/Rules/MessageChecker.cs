using System.Linq;

namespace ChatBackend.Rules
{
    public class MessageChecker
    {

        public bool CheckMessage(string message)
        {
            message = message.ToLower();

            if (SecurityChecks(message) == true && 
                ProfanityCheck(message) == true &&
                CommandCheck(message)   == true){
                return true;
            }
            return false;

        }



        private bool SecurityChecks(string message) {

            if (message.Contains("issues"))
            {
                return false;
            }
            return true;
        }

        public bool ProfanityCheck(string message)
        {

            if (message.Contains("profanity"))
            {
                return false;
            }
            return true;
        }
    
        private bool CommandCheck(string message)
        {
            if (message.Contains("/kick william"))
            {
                // fire action
                return false;
            }

            return true;
        }

    }
}
