using NServiceBus;
using System;

namespace SharedMedia
{
    public class Message: ICommand
    {
        public string name { get; set; }
        public string msg { get; set; }
    }
}
