using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.FormsTree
{
    public class TreeItem
    {
        public TreeItem()
        {
            this.Items = new ObservableCollection<TreeItem>();
        }

        public string Title { get; set; }
        public string Type { get; set; }

        public ObservableCollection<TreeItem> Items { get; set; }
    }
}
