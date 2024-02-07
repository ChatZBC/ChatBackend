namespace ChatBackend.Hubs
{
    // Hubs/ChatHub.cs
    using Microsoft.AspNetCore.SignalR;

    public class ChatHub : Hub
    {
        // Create a private readonly ILogger service
        private readonly ILogger<ChatHub> _logger;

        // Inject the ILogger service into the ChatHub
        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("connected");
            return base.OnConnectedAsync();
        }

        // Send message to all clients. Log the message to the console.
        public async Task SendMessage(string user, string message)
        {
            _logger.LogInformation("Message received from {User}: {Message}", user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
