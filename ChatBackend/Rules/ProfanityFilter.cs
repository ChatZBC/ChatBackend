using System.Text;

namespace ChatBackend.Rules
{
    public class ProfanityFilter
    {
        public bool ContainsProfanity(string message)
        {
            var profaneWords = new List<string> { "bad", "nasty", "horrible", "William" };
            string[] words = message.Split(' ');

            foreach (string word in words)
            {
                if (profaneWords.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }

        public bool DoesNotContainsProfanity(string message)
        {
            var profaneWords = new List<string> { "bad", "nasty", "horrible", "William" };
            string[] words = message.Split(' ');
            int profanityCount = 0;

            foreach (string word in words)
            {
                if (profaneWords.Contains(word))
                {
                    profanityCount++;
                }
            }
            return profanityCount == 0;
        }

        public string FilterProfanity(string message)
        {
            var profaneWords = new List<string> { "bad", "nasty", "horrible", "William" };
            string[] words = message.Split(' ');
            var modifiedMessageBuilder = new StringBuilder();

            foreach (string word in words)
            {
                if (profaneWords.Contains(word))
                {
                    modifiedMessageBuilder.Append(new string('*', word.Length));
                }
                else
                {
                    modifiedMessageBuilder.Append(word);
                }
                modifiedMessageBuilder.Append(" ");
            }

            string modifiedMessage = modifiedMessageBuilder.ToString().Trim();
            return modifiedMessage;
        }

    }
}
