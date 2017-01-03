using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Raven.Client;
using System;

namespace NancySignalrRaven
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        private readonly IDocumentStore _documentStore;
        public ChatHub(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
        public void Send(string message)
        {
            Clients.All.addMessage(message);
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(new ChatLogDocument { Created = DateTime.UtcNow, Message = message });
                session.SaveChanges();
            }
        }
    }
}
