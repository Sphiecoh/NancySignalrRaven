using Nancy;
using Nancy.TinyIoc;
using Raven.Client;

namespace NancySignalrRaven
{
    public class MyBootStrapper : DefaultNancyBootstrapper
    {
        private readonly IDocumentStore _documentStore;
        public MyBootStrapper(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(_documentStore);
        }
       
    }
}
