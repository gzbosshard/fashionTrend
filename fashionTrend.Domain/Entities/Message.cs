using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public string? Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; }
    }
}
