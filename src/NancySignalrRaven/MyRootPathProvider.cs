using Nancy;
using System.IO;

namespace NancySignalrRaven
{
    public class MyRootPathProvider : IRootPathProvider
    {
        public string GetRootPath() => Directory.GetCurrentDirectory();
        
    }
}
