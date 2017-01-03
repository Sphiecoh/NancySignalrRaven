using Nancy;
using Nancy.Configuration;
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
        public override void Configure(INancyEnvironment environment)
        {
            base.Configure(environment);
            environment.Tracing(true, true);
            environment.Views(false, true);
            
        }
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(_documentStore);
        }
       
    }
}
