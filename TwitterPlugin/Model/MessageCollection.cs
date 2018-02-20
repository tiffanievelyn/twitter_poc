using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterPlugin.Model
{
    public class MessageCollection : ObservableCollection<TwitterMessage>
    {
        public MessageCollection() : base() { }
    }
}
