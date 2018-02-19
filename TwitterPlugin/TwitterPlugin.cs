using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tweetinvi;
using Tweetinvi.Models;

namespace TwitterPlugin
{
    public class TwitterPlugin
    {
        private static string ConsumerKey = "dCfWgNmcMiUsMmmZkc0uhkZbq";
        private static string ConsumerSecret = "xETVYjlj8SEuluKRp85BDN9Twn0xDeMLfwrzzlufrzkUjiwz3R";
        private static string AccessToken = "862690063624192000-y52pg7YZAbFyfQT0X9hFUI0qLKzVo50";
        private static string AccessTokenSecret = "Bk9Q4TZEVWfuCCb8zlbxQQmCeDkDxVeCU1CAUAbPjSjDM";

        static ConsumerCredentials appCred = new ConsumerCredentials(ConsumerKey, ConsumerSecret);
        IAuthenticationContext authenticationContext = AuthFlow.InitAuthentication(appCred);

        public TwitterPlugin(){}
        
        /*
        public void QuickLogin()
        {
            Auth.SetUserCredentials(ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret);
            Console.WriteLine(User.GetAuthenticatedUser());
            //AuthenticatedUser user = (AuthenticatedUser)Tweetinvi.User.GetAuthenticatedUser();
        }
        */

        public void Login()
        {
            Process.Start(authenticationContext.AuthorizationURL);
        }

        public void VerifyUser(string PinCode)
        {
            var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(PinCode, authenticationContext);
            Auth.SetCredentials(userCredentials);
            Console.WriteLine(User.GetAuthenticatedUser());
        }

        public Dictionary<string, string> userInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            var user = User.GetAuthenticatedUser();
            
            Console.WriteLine(user);
            info.Add("name", user.Name);
            info.Add("username", user.ScreenName);
            info.Add("followers", user.FollowersCount.ToString());
            info.Add("likes", user.FavouritesCount.ToString());
            info.Add("numTweets", user.StatusesCount.ToString());

            return info;
        }
        
        public ObservableCollection<StatusTweet> getTweetsCollection()
        {
            var user = User.GetAuthenticatedUser();

            StatusCollection collections = new StatusCollection();
            var twts = Timeline.GetUserTimeline(user.Id);
            foreach (var twt in twts)
            {
                StatusTweet s = new StatusTweet
                {
                    username = twt.CreatedBy.Name,
                    id = twt.Id,
                    text = twt.Text,
                    likes = twt.FavoriteCount,
                    retweets = twt.RetweetCount
                };
                collections.Add(s);
            }

            return collections;
        }

        public ObservableCollection<StatusTweet> searchQuery(string query)
        {
            StatusCollection collections = new StatusCollection();
            var twts = Search.SearchTweets(query);

            foreach (var twt in twts)
            {
                StatusTweet s = new StatusTweet
                {
                    username = twt.CreatedBy.Name,
                    id = twt.Id,
                    text = twt.Text,
                    likes = twt.FavoriteCount,
                    retweets = twt.RetweetCount
                };
                collections.Add(s);
            }

            return collections;
        }

        public ObservableCollection<StatusTweet> getMention()
        {
            StatusCollection collections = new StatusCollection();
            var twts = Timeline.GetMentionsTimeline();

            foreach (var twt in twts)
            {
                StatusTweet s = new StatusTweet
                {
                    username = twt.CreatedBy.Name,
                    id = twt.Id,
                    text = twt.Text,
                    likes = twt.FavoriteCount,
                    retweets = twt.RetweetCount
                };
                collections.Add(s);
            }

            return collections;
        }

        public ObservableCollection<StatusTweet>searchRepliesToId(String tweetId)
        {
            StatusCollection collections = new StatusCollection();
            
            var twts = Search.SearchRepliesTo(Tweet.GetTweet(Convert.ToInt64(tweetId)), false);

            foreach (var twt in twts)
            {
                StatusTweet s = new StatusTweet
                {
                    username = twt.CreatedBy.Name,
                    id = twt.Id,
                    text = twt.Text,
                    likes = twt.FavoriteCount,
                    retweets = twt.RetweetCount
                };
                collections.Add(s);
            }

            return collections;
        }
    }
    
}
