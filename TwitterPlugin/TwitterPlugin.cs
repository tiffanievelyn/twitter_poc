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

            info.Add("name", user.Name);
            info.Add("username", user.ScreenName);
            info.Add("followers", user.FollowersCount.ToString());
            info.Add("likes", user.FavouritesCount.ToString());
            info.Add("numTweets", user.StatusesCount.ToString());

            return info;
        }

        public ObservableCollection<StatusTweet> toObservable(IEnumerable<ITweet> tweets)
        {
            StatusCollection collections = new StatusCollection();
            foreach (var twt in tweets)
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
        
        public ObservableCollection<StatusTweet> getTweetsCollection()
        {
            var user = User.GetAuthenticatedUser();
            return toObservable(Timeline.GetUserTimeline(user.Id));
        }

        public ObservableCollection<StatusTweet> searchQuery(string query)
        {
            return toObservable(Search.SearchTweets(query));
        }

        public ObservableCollection<StatusTweet> getMention()
        {
            return toObservable(Timeline.GetMentionsTimeline());
        }

        public ObservableCollection<StatusTweet> searchRepliesToId(String tweetId)
        {
            return toObservable(Search.SearchRepliesTo(Tweet.GetTweet(Convert.ToInt64(tweetId)), false));
        }
    }
    
}
