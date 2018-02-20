using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

using Tweetinvi;
using Tweetinvi.Models;
using TwitterPlugin.Model;

namespace TwitterPlugin
{
    public class TwitterPlugin
    {
        Helper helper = new Helper();

        static ConsumerCredentials appCred = new ConsumerCredentials(UserConfig.ConsumerKey, UserConfig.ConsumerSecret);
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

        public TwitterUser UserInfo()
        {
            return helper.GetTwitterUser(User.GetAuthenticatedUser());
        }
        
        public ObservableCollection<TwitterStatus> GetTweetsCollection()
        {
            var user = User.GetAuthenticatedUser();
            return helper.CollectStatus(Timeline.GetUserTimeline(user.Id));
        }

        public ObservableCollection<TwitterStatus> SearchQuery(string query)
        {
            return helper.CollectStatus(Search.SearchTweets(query));
        }

        public ObservableCollection<TwitterStatus> GetMention()
        {
            return helper.CollectStatus(Timeline.GetMentionsTimeline());
        }

        public ObservableCollection<TwitterStatus> SearchRepliesToId(String tweetId)
        {
            return helper.CollectStatus(Search.SearchRepliesTo(Tweet.GetTweet(Convert.ToInt64(tweetId)), false));
        }

        public ObservableCollection<TwitterStatus> GetRetweetsOfMe()
        {
            return helper.CollectStatus(Timeline.GetRetweetsOfMeTimeline());
        }

        public ObservableCollection<TwitterUser> GetFollowers()
        {
            var user = User.GetAuthenticatedUser();
            return(helper.CollectUser(user.GetFollowers()));
            
        }
    }
    
}
