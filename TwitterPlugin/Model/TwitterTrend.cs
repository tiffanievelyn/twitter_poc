using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterPlugin.Model
{
    public class TwitterTrend
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string Query { get; set; }
        public string PromotedContent { get; set; }
        public int? TweetVolume { get; set; }
    }
}
