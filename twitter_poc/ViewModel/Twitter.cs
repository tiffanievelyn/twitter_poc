using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tweetinvi.Logic;
using TwitterPlugin;
using ViewModel;


namespace twitter_poc.ViewModel
{
    public class Twitter : ObservableObject
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChangedEvent(nameof(Username));
            }

        }

        private string _pin;

        public string Pin
        {
            get { return _pin; }
            set
            {
                _pin = value;
                RaisePropertyChangedEvent(nameof(Pin));
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChangedEvent(nameof(Name));
            }
        }

        private string _followerscount;

        public string FollowersCount
        {
            get { return _followerscount; }
            set
            {
                _followerscount = value;
                RaisePropertyChangedEvent(nameof(FollowersCount));
            }
        }

        private string _likescount;

        public string LikesCount
        {
            get { return _likescount; }
            set
            {
                _likescount = value;
                RaisePropertyChangedEvent(nameof(LikesCount));
            }
        }

        private string _tweetscount;

        public string TweetsCount
        {
            get { return _tweetscount; }
            set
            {
                _tweetscount = value;
                RaisePropertyChangedEvent(nameof(TweetsCount));
            }
        }

        private ObservableCollection<StatusTweet> _tweets = new ObservableCollection<StatusTweet>();

        public ObservableCollection<StatusTweet> Tweets
        {
            get { return _tweets; }
            set
            {
                _tweets = value;
                RaisePropertyChangedEvent(nameof(Tweets));
            }
        }

        private string _query;

        public string Query
        {
            get { return _query; }
            set
            {
                _query = value;
                RaisePropertyChangedEvent(nameof(Query));
            }
        }

        private string _tweetid;

        public string TweetId
        {
            get { return _tweetid; }
            set
            {
                _tweetid = value;
                RaisePropertyChangedEvent(nameof(TweetId));
            }
        }

        TwitterPlugin.TwitterPlugin twitter = new TwitterPlugin.TwitterPlugin();

        #region Login
        /*
        public ICommand QuickLogin
        {
            get { return new DelegateCommand(quicklogin); }
        }

        public void quicklogin()
        {
            authen.QuickLogin();
            getUserInfo();
        }
        */

        public ICommand Login
        {
            get { return new DelegateCommand(login); }
        }
        
        public void login()
        {
            twitter.Login();
        }

        public ICommand Verify
        {
            get { return new DelegateCommand(verify); }
        }

        public void verify()
        {
            twitter.VerifyUser(Pin);
            getUserInfo();
        }

        public ICommand GetTimeline
        {
            get { return new DelegateCommand(getTimeline); }
        }

        public void getTimeline()
        {
            Tweets.Clear();
            Tweets = twitter.getTweetsCollection();
        }

        public ICommand Search
        {
            get { return new DelegateCommand(search); }
        }

        public void search()
        {
            Tweets.Clear();
            Tweets = twitter.searchQuery(Query);
        }

        public ICommand GetMention
        {
            get { return new DelegateCommand(getMention); }
        }

        public void getMention()
        {
            Tweets.Clear();
            Tweets = twitter.getMention();
        }

        public ICommand SearchRepliesToId
        {
            get { return new DelegateCommand(searchRepliesToId); }
        }

        public void searchRepliesToId()
        {
            Tweets.Clear();
            Tweets = twitter.searchRepliesToId(TweetId);
        }

        #endregion

        public void getUserInfo()
        {
            Dictionary<string, string> info = twitter.userInfo();
            Name = info["name"];
            Username = info["username"];
            FollowersCount = "Followers : " + info["followers"];
            LikesCount = "Likes : " + info["likes"];
            TweetsCount = "Tweets : " + info["numTweets"];
        }
    }
}
