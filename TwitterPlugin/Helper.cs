using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                StatusCount = user.StatusesCount
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
                    StatusCount = user.StatusesCount
                };
                collections.Add(t);
            }
            return collections; 
        }
        
        public ObservableCollection<Model.TwitterStatus> CollectStatus(IEnumerable<ITweet> tweets)
        {
            Console.WriteLine(tweets);
            StatusCollection collections = new StatusCollection();
            foreach (var twt in tweets)
            {
                Model.TwitterStatus s = new Model.TwitterStatus
                {
                    Username = twt.CreatedBy.Name,
                    Id = twt.Id,
                    Text = twt.Text,
                    Likes = twt.FavoriteCount,
                    Retweets = twt.RetweetCount
                };
                collections.Add(s);
            }
            return collections;
        }

    }
}
