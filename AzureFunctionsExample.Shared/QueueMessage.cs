using System;

namespace AzureFunctionsExample.Shared
{
    public class QueueMessage
    {
        public int Person { get; set; }
        public int Order { get; set; }
        public int Status { get; set; }
    }

    public enum OrderStatus
    {
        Concept = 0,
        Processing = 1,
        Processed = 2
    }
}
