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
        public static FormModule ProcessFormsXML(string fileName)
        {

            //XNamespace ns = "http://xmlns.oracle.com/Forms";
            XNamespace ns = String.Empty;
            Debug.WriteLine("Debug Debug WOrld");

            XElement fmx = XElement.Load(fileName);

            List<Block> blocks = BlockParser.GetBlocks(ns, fmx).ToList<Block>();

            blocks.ForEach(blockItem => {
                XElement block = (from el in fmx.Descendants(ns + "Block")
                                  where el.Attribute("Name").Value == blockItem.Name
                                  select el).First();

                IEnumerable<Item> items = ItemParser.GetItems(ns, block);
                blockItem.items.AddRange(items);
            });

            FormModule formModule = new FormModule("Name", "Title", "Max", "MenuModule", "Console", blocks);

            return formModule;
        }


    }
}
