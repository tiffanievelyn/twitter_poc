using System.Collections.ObjectModel;

namespace TwitterPlugin.Model
{
    public class MessageCollection : ObservableCollection<TwitterMessage>
    {
        public MessageCollection() : base() { }
    }
}
