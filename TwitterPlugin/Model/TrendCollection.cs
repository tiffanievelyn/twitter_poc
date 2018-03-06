using System.Collections.ObjectModel;

namespace TwitterPlugin.Model
{
    public class TrendCollection : ObservableCollection<TwitterTrend>
    {
        public TrendCollection() : base() { }
    }
}
