using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterPlugin
{
    public class StatusCollection : ObservableCollection<StatusTweet>
    {
        public StatusCollection() : base() { }
    }

    public class StatusTweet
    {
        public string username { get; set; }
        public long id { get; set; }
        public string text { get; set; }
        public int likes { get; set; }
        public int retweets { get; set; }
        
    }
}
