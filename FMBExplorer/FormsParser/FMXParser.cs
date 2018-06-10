using FMBExplorer.FormsElement;
using FMBExplorer.FormsParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FMBExplorer
{
    public static class FMXParser
    {
        public static async Task ProcessFormsXML(string fileName)
        {

            //XNamespace ns = "http://xmlns.oracle.com/Forms";
            XNamespace ns = String.Empty;
            Debug.WriteLine("Debug Debug WOrld");

            XElement fmx = XElement.Load(fileName);

            //IEnumerable<Block> blocks = BlockParser.GetBlocks(ns, fmx);

            BlockParser.GetBlocks(ns, fmx).ToList<Block>().ForEach(blockItem => {
                XElement block = (from el in fmx.Descendants(ns + "Block")
                                  where blockItem.Name == el.Attribute("Name").Value
                                  select el).First();

                IEnumerable<Item> items = ItemParser.GetItems(ns, block);
                blockItem.items.AddRange(items);
            });

            /*foreach (Block blockItem in blocks)
            {
                XElement block = (from el in fmx.Descendants(ns + "Block")
                                  where blockItem.Name == el.Attribute("Name").Value
                                  select el).First();

                IEnumerable<Item> items = ItemParser.GetItems(ns, block);

                blockItem.items.AddRange(items);
            }
            */
            //blocks.
        }




    }
}
