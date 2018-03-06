
namespace TwitterPlugin.Model
{
    public class TwitterStatus
    {
        public string Username { get; set; }
        public long Id { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public int Retweets { get; set; }
    }
}
