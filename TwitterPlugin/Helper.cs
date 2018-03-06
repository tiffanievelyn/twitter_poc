using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Tweetinvi;
using Tweetinvi.Models;
using TwitterPlugin.Model;

namespace TwitterPlugin
{
    public class Helper
    {
        public Model.TwitterUser GetTwitterUser(IAuthenticatedUser user)
        {
            Model.TwitterUser tUser = new Model.TwitterUser
            {
                Id = user.Id,
                Name = user.Name,
                ScreenName = user.ScreenName,
                IsProtected = user.Protected,
                FollowersCount = user.FollowersCount,
                FriendsCount = user.FriendsCount,
                FavouritesCount = user.FavouritesCount,
                IsGeoEnabled = user.GeoEnabled,
                StatusCount = user.StatusesCount,
                Location = user.Location.ToString()
            };
            return tUser;
        }

        public Model.TwitterUser GetTwitterUser2(IUser user)
        {
            Model.TwitterUser tUser = new Model.TwitterUser
            {
                Id = user.Id,
                Name = user.Name,
                ScreenName = user.ScreenName,
                IsProtected = user.Protected,
                FollowersCount = user.FollowersCount,
                FriendsCount = user.FriendsCount,
                FavouritesCount = user.FavouritesCount,
                IsGeoEnabled = user.GeoEnabled,
                StatusCount = user.StatusesCount,
                Location = user.Location.ToString()
            };
            return tUser;
        }

        public ObservableCollection<Model.TwitterUser> CollectUser(IEnumerable<IUser> users)
        {
            UserCollection collections = new UserCollection();
            foreach (var user in users)
            {
                TwitterUser t = new TwitterUser
                {
                    Id = user.Id,
                    Name = user.Name,
                    ScreenName = user.ScreenName,
                    IsProtected = user.Protected,
                    FollowersCount = user.FollowersCount,
                    FriendsCount = user.FriendsCount,
                    FavouritesCount = user.FavouritesCount,
                    IsGeoEnabled = user.GeoEnabled,
                    StatusCount = user.StatusesCount,
                    Location = user.Location.ToString()
                };
                collections.Add(t);
            }
            return collections;
        }

        public ObservableCollection<Model.TwitterStatus> CollectStatus(IEnumerable<ITweet> tweets)
        {
            StatusCollection collections = new StatusCollection();
            foreach (var twt in tweets)
            {
                if (!twt.IsRetweet)
                {
                    Model.TwitterStatus s = new Model.TwitterStatus
                    {
                        Username = twt.CreatedBy.ScreenName,
                        Id = twt.Id,
                        Text = twt.FullText,
                        Likes = twt.FavoriteCount,
                        Retweets = twt.RetweetCount
                    };
                    collections.Add(s);
                }
                
            }
            return collections;
        }

        public ObservableCollection<TwitterTrend> CollectTrend(IPlaceTrends trends)
        {
            TrendCollection collection = new TrendCollection();
            foreach (var tr in trends.Trends.ToList())
            {
                TwitterTrend t = new TwitterTrend
                {
                    Name = tr.Name,
                    URL = tr.URL,
                    Query = tr.Query,
                    PromotedContent = tr.PromotedContent,
                    TweetVolume = tr.TweetVolume,
                };
                collection.Add(t);
            }
            return collection;
        }

        public ObservableCollection<TwitterMessage> CollectMessage(IEnumerable<IMessage> messages)
        {
            MessageCollection collection = new MessageCollection();
            foreach (var message in messages)
            {
                TwitterMessage m = new TwitterMessage
                {
                    Id = message.Id,
                    SenderId = message.SenderId,
                    SenderScreenname = message.SenderScreenName,
                    RecipientId = message.RecipientId,
                    RecipientScreenname = message.RecipientScreenName,
                    Text = message.Text,
                    CreatedAt = message.CreatedAt
                };
                collection.Add(m);
            }
            return collection;
        }


    }
}
