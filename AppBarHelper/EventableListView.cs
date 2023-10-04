using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBarHelper
{
    public class EventableListView : ListView
    {
        public void Add(ListViewItem item)
        {
            Items.Add(item);
            if (ItemAdded != null)
                ItemAdded.Invoke(this, new ItemsChangedArgs(item));
        }

        public void Remove(ListViewItem item)
        {
            Items.Remove(item);
            if (ItemRemoved != null)
                ItemRemoved.Invoke(this, new ItemsChangedArgs(item));
        }

        public void Reload()
        {
            Items.Clear();
            if (ItemsCleared != null)
                ItemsCleared.Invoke(this, new EventArgs());
        }

        public event EventHandler<ItemsChangedArgs> ItemAdded;
        public event EventHandler<ItemsChangedArgs> ItemRemoved;
        public event EventHandler<EventArgs> ItemsCleared;
    }

    public class ItemsChangedArgs : EventArgs
    {
        public ItemsChangedArgs(ListViewItem item)
        {
            Item = item;
        }

        public ListViewItem Item { get; set; }
    }
}
