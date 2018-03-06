using System.Collections.ObjectModel;

namespace TwitterPlugin.Model
{
    public class UserCollection : ObservableCollection<TwitterUser>
    {
        public UserCollection() : base() { }
    }
}
