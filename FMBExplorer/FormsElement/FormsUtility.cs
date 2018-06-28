using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FMBExplorer.FormsElement
{
    public static class FormsUtility
    {

        public static Position CalculateLabelPosition(Item item)
        {
            Label dummyLabel = new Label() { Content = item.Prompt };
            dummyLabel.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            int labelLength = System.Convert.ToInt32(dummyLabel.DesiredSize.Width);

            Position pos = new Position();

            if (item.LabelPosition == Item.ItemLabelPosition.Start)
            {
                pos.Left = item.WpfXPosition - labelLength;
                pos.Top = item.WpfYPosition;
            }

            if (item.LabelPosition == Item.ItemLabelPosition.Top)
            {
                pos.Left = item.WpfXPosition;
                pos.Top = item.WpfYPosition - item.WpfHeight;
            }

            return pos;
        }

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
