using System.Collections.ObjectModel;
using TwitterPlugin.Model;

namespace TwitterPlugin
{
    public class StatusCollection : ObservableCollection<TwitterStatus>
    {
        public StatusCollection() : base() { }
    }
}
