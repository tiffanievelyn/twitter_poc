using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterPlugin.Model;

namespace TwitterPlugin
{
    public class StatusCollection : ObservableCollection<TwitterStatus>
    {
        public StatusCollection() : base() { }
    }
}
