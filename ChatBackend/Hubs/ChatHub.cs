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
        private ConnectedUserTransient _users;

        // Inject the ILogger service into the ChatHub
        public ChatHub(ILogger<ChatHub> logger, ConnectedUserTransient connectedUserTransient)
        {
            _logger = logger;
            this._users = connectedUserTransient;
        }

        /// <summary>
        /// Adds user to dictionary over users and sends all clients a message
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext().Request.Query["username"].ToString();
            Console.WriteLine("connected"+username);
            if(username != string.Empty)
            {
                _users.Users.TryAdd(Context.ConnectionId, username);
            }
            SendMessage(username, "welcome").ConfigureAwait(false);
            UpdateUserList(username).ConfigureAwait(false);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _users.Users.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
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

        /// <summary>
        /// Sends the new user to all connected users
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task UpdateUserList(string newUser)
        {
            await Clients.All.SendAsync("adduser",newUser);
        }

        /// <summary>
        /// sends userlist only to the newly connected user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<List<string>> RequestUserList(string username)
        {
            LogMessage(username, "Requested userlist");
            return this._users.Users.Values.ToList();
        }

        /// <summary>
        /// sends error to client
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public async Task SendError(string error)
        {
            await Clients.Caller.SendAsync("error", error);
        }
    }
}
