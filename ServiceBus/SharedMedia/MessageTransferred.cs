using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMedia
{
    public class MessageTransferred: IEvent
    {
        public string name { get; set; }
        public string msg { get; set; }
    }
}
