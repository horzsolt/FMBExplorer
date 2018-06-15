using FMBExplorer.FormsElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.FormsTree
{
    public static class TreeBuilder
    {
        public static TreeItem Build(FormModule fm)
        {
            TreeItem root = new TreeItem() { Title = fm.Title };

            fm.Blocks.ForEach(blox =>
            {
                TreeItem blockItem = new TreeItem() { Title = blox.Name, Type = "block" };
                blox.items.ForEach(item =>
                {
                    TreeItem subItem = new TreeItem() { Title = item.Name, Type = "item" };
                    blockItem.Items.Add(subItem);
                });

                root.Items.Add(blockItem);
            });

            return root;
        }
    }
}
