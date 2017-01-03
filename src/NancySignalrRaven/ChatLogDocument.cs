using System;
using System.Text.Encodings.Web;

namespace NancySignalrRaven
{
    internal class ChatLogDocument
    {
        public DateTime Created { get; set; }

        public string Message { get; set; }
        public string Id { get; set; }
        public string UrlId => Id.Split('/')[1];
    }
}