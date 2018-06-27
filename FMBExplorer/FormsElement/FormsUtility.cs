using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.FormsElement
{
    public static class FormsUtility
    {
        public static bool IsForm(Block block)
        {
            return block.RecordsDisplayCount == 1;
        }

        public static bool IsGrid(Block block)
        {
            return block.RecordsDisplayCount > 1;
        }
    }
}
