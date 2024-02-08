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
        /// <summary>
        /// Sends a welcome message to the client when they connect to the hub.
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("connected");
            SendMessage("ChatZBC", "Welcome to the ChatHub!");
            return base.OnConnectedAsync();
        }


        /// <summary>
        /// Logs the message to the console.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        public void LogMessage(string user, string message)
        {
            _logger.LogInformation($"Message received from {user}: {message}");
        }

        /// <summary>
        /// Log the message to the console.
        /// Then send message to all clients, if it passes the rules in the rules engine.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
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
