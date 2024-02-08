using ChatBackend.Rules;
using Microsoft.AspNetCore.SignalR;
using System;

namespace ChatBackend.Hubs
{


    public class ChatHub : Hub
    {
        // Create a private readonly ILogger service
        private readonly ILogger<ChatHub> _logger;

        // Instantiate our rule engine
        private MessageChecker _messageChecker = new MessageChecker();

        // Inject the ILogger service into the ChatHub
        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("connected");
            SendMessage("ChatZBC", "Welcome to the ChatHub!");
            return base.OnConnectedAsync();
        }

        public void LogMessage(string user, string message)
        {
            _logger.LogInformation($"Message received from {user}: {message}");
        }

        // Log the message to the console.
        // Then send message to all clients, if it passes the rules in the rules engine.
        public async Task SendMessage(string user, string message)
        {
            LogMessage(user, message);
            
            if (_messageChecker.CheckMessage(message) == true) 
            {
                await Clients.All.SendAsync("MessageReceived", user, message);
            }
        }
    }
}
