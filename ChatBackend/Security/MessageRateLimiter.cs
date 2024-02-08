namespace ChatBackend.Security
{
    public class MessageRateLimiter
    {
        public bool IsRateAllowed(DateTime lastMessageSent)
        {
            if (DateTime.Now - lastMessageSent < TimeSpan.FromSeconds(1))
            {
                return false;
            }
            return true;
        }
    }
}
