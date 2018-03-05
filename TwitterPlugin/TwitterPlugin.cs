using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using TwitterPlugin.Model;

namespace TwitterPlugin
{
    public class TwitterPlugin
    {
        Helper helper = new Helper();

        static ConsumerCredentials appCred = new ConsumerCredentials(UserConfig.ConsumerKey, UserConfig.ConsumerSecret);
        
        IAuthenticationContext authenticationContext;

        ITwitterCredentials userCreds = new TwitterCredentials();

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
            authenticationContext = AuthFlow.InitAuthentication(appCred);
            Process.Start(authenticationContext.AuthorizationURL);
        }

        public void LoginWeb()
        {
            string redirectURL = "http://localhost:4200/twitter";

            authenticationContext = AuthFlow.InitAuthentication(appCred, redirectURL);
            Process.Start(authenticationContext.AuthorizationURL);

        }

        public void VerifyUser(string loginPin)
        {
            userCreds = AuthFlow.CreateCredentialsFromVerifierCode(loginPin, authenticationContext);
            Auth.SetCredentials(userCreds);
            TweetinviConfig.CurrentThreadSettings.TweetMode = TweetMode.Extended;
            TweetinviConfig.ApplicationSettings.TweetMode = TweetMode.Extended;
        }

        public void VerifyUserWeb(string verifierCode, string authorizationid)
        {
            userCreds = AuthFlow.CreateCredentialsFromVerifierCode(verifierCode, authorizationid);
            Auth.SetCredentials(userCreds);
            TweetinviConfig.CurrentThreadSettings.TweetMode = TweetMode.Extended;
            TweetinviConfig.ApplicationSettings.TweetMode = TweetMode.Extended;            
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

        public ObservableCollection<TwitterStatus> SearchQuery(string query, double latitude, double longitude, string searchtype, int radius)
        {
            var s = SearchResultType.Popular;

            if (searchtype == "R")
            {
                s = SearchResultType.Recent;
            }
            else if (searchtype == "M")
            {
                s = SearchResultType.Mixed;
            }

            IEnumerable<ITweet> tweets = Search.SearchTweets(new SearchTweetsParameters(query)
            {
                GeoCode = new GeoCode(latitude, longitude, radius, DistanceMeasure.Kilometers),
                SearchType = s
            });
            
            ObservableCollection<TwitterStatus> col =  helper.CollectStatus(tweets);
            
            return col;
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

        public TwitterUser SearchUser(string username)
        {   
            return helper.GetTwitterUser2(User.GetUserFromScreenName(username));
        }

        public ObservableCollection<TwitterStatus> SearchUserTimeline(long userid)
        {
            var user = User.GetUserFromId(userid);
            return helper.CollectStatus(Timeline.GetUserTimeline(user.Id));
        }

        public void getTre()
        {
            var locations = Trends.GetAvailableTrendLocations();
            foreach (var location in locations)
            {
                Console.WriteLine(location.Name + ", " + location.Country);
            }
        }

        public ObservableCollection<TwitterTrend> getTrends(string woeid)
        {
            return helper.CollectTrend(Trends.GetTrendsAt(Convert.ToInt64(woeid)));
        }

        public ObservableCollection<TwitterMessage> GetMessages()
        {
            return helper.CollectMessage(Message.GetLatestMessagesReceived());
        }

    }
    
}
