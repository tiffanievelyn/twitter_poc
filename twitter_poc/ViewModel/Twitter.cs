﻿using Microsoft.Win32;
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
using TwitterPlugin.Model;
using ViewModel;


namespace twitter_poc.ViewModel
{
    public class Twitter : ObservableObject
    {
        TwitterPlugin.TwitterPlugin twitter = new TwitterPlugin.TwitterPlugin();

        private TwitterUser _user;
        private string _pin;
        private ObservableCollection<TwitterStatus> _tweets = new ObservableCollection<TwitterStatus>();
        private ObservableCollection<TwitterUser> _users = new ObservableCollection<TwitterUser>();
        private ObservableCollection<TwitterTrend> _trends = new ObservableCollection<TwitterTrend>();
        private ObservableCollection<TwitterMessage> _messages = new ObservableCollection<TwitterMessage>();
        private string _query;
        private string _tweetid;
        private string _username;
        private string _woeid;

        public TwitterUser User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChangedEvent(nameof(User));
            }
        }
        public string Pin
        {
            get { return _pin; }
            set
            {
                _pin = value;
                RaisePropertyChangedEvent(nameof(Pin));
            }
        }
        public ObservableCollection<TwitterStatus> Tweets
        {
            get { return _tweets; }
            set
            {
                _tweets = value;
                RaisePropertyChangedEvent(nameof(Tweets));
            }
        }      
        public ObservableCollection<TwitterUser> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChangedEvent(nameof(Users));
            }
        }
        public ObservableCollection<TwitterTrend> Trends
        {
            get { return _trends; }
            set
            {
                _trends = value;
                RaisePropertyChangedEvent(nameof(Trends));
            }
        }
        public ObservableCollection<TwitterMessage> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                RaisePropertyChangedEvent(nameof(Messages));
            }
        }
        public string Query
        {
            get { return _query; }
            set
            {
                _query = value;
                RaisePropertyChangedEvent(nameof(Query));
            }
        }
        public string TweetId
        {
            get { return _tweetid; }
            set
            {
                _tweetid = value;
                RaisePropertyChangedEvent(nameof(TweetId));
            }
        }
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChangedEvent(nameof(UserName));
            }
        }
        public string Woeid
        {
            get { return _woeid; }
            set
            {
                _woeid = value;
                RaisePropertyChangedEvent(nameof(Woeid));
            }
        }


        #region commands
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

        public ICommand GetFollowers
        {
            get { return new DelegateCommand(getFollowers); }
        }

        public void getFollowers()
        {
            Users.Clear();
            Users = twitter.GetFollowers();
            Console.WriteLine(Users);
        }

        public ICommand GetTimeline
        {
            get { return new DelegateCommand(getTimeline); }
        }

        public void getTimeline()
        {
            Tweets.Clear();
            Tweets = twitter.GetTweetsCollection();
        }

        public ICommand Search
        {
            get { return new DelegateCommand(search); }
        }

        public void search()
        {
            Tweets.Clear();
            Tweets = twitter.SearchQuery(Query);
        }

        public ICommand GetMention
        {
            get { return new DelegateCommand(getMention); }
        }

        public void getMention()
        {
            Tweets.Clear();
            Tweets = twitter.GetMention();
        }

        public ICommand SearchRepliesToId
        {
            get { return new DelegateCommand(searchRepliesToId); }
        }

        public void searchRepliesToId()
        {
            Tweets.Clear();
            Tweets = twitter.SearchRepliesToId(TweetId);
        }
        
        public ICommand GetRetweetsOfMe
        {
            get { return new DelegateCommand(getRetweetsOfMe); }
        }

        public void getRetweetsOfMe()
        {
            Tweets.Clear();
            Tweets = twitter.GetRetweetsOfMe();
        }

        public ICommand SearchUser
        {
            get { return new DelegateCommand(searchUser); }
        }

        public void searchUser()
        {
            Users.Clear();
            Users.Add(twitter.SearchUser(UserName));
            searchUserTimeline(twitter.SearchUser(UserName).Id);
        }
        
        public void searchUserTimeline (long userid)
        {
            Tweets.Clear();
            Tweets = twitter.SearchUserTimeline(userid);
        }

        public ICommand SearchTrendByWoeid
        {
            get { return new DelegateCommand(searchTrendByWoeid); }
        }

        public void searchTrendByWoeid()
        {
            Trends.Clear();
            Trends = twitter.getTrends(Woeid);
        }

        public ICommand GetMessages
        {
            get { return new DelegateCommand(getMessages); }
        }

        public void getMessages()
        {
            Messages.Clear();
            Messages = twitter.GetMessages();
        }

        #endregion

        public void getUserInfo()
        {
            User = twitter.UserInfo();
        }
    }
}
