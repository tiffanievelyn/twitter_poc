﻿using System;

namespace TwitterPlugin.Model
{
    public class TwitterUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public Boolean IsProtected { get; set; }
        public int FollowersCount { get; set; }
        public int FriendsCount { get; set; }
        public int FavouritesCount {get; set;}
        public Boolean IsGeoEnabled { get; set; }
        public int StatusCount { get; set; }
        public string Location { get; set; }
    }
}
