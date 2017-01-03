using Nancy;
using Raven.Client;
using System.Dynamic;
using System.Linq;

namespace NancySignalrRaven
{
    public class ChatModule : NancyModule
    {
        public ChatModule(IDocumentStore documentStore)
        {
            Get("/",  ctx => View["Index"]);
            Get("/chat", ctx => View["chat"]);
            Get("/logs",ctx =>
            {
                dynamic model = new ExpandoObject();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    model.Logs = session
                        .Query<ChatLogDocument>()
                        .OrderBy(d => d.Created)
                        .ToArray();
                }
                return View["ChatLog", model];
            });
        }
    }
}
