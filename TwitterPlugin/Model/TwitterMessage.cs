using System;

namespace TwitterPlugin.Model
{
    public class TwitterMessage
    {
        public long Id { get; set; }
        public long SenderId { get; set; }
        public string SenderScreenname { get; set; }
        public long RecipientId { get; set; }
        public string RecipientScreenname { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
