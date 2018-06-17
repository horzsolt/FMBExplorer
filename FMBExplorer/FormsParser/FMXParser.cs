using FMBExplorer.FormsElement;
using FMBExplorer.FormsParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

            //XNamespace ns = "http://xmlns.oracle.com/Forms/";
            XNamespace ns = String.Empty;

            string text = File.ReadAllText(fileName, Encoding.GetEncoding("UTF-8"));
            XElement fmx = XElement.Parse(text);

            List<Block> blocks = BlockParser.GetBlocks(ns, fmx).ToList<Block>();

            blocks.ForEach(blockItem => {
                XElement block = (from el in fmx.Descendants(ns + "Block")
                                  where el.Attribute("Name").Value == blockItem.Name
                                  select el).First();

                blockItem.Items.AddRange(ItemParser.GetItems(ns, block));
            });

            FormModule formModule = new FormModule("Name", "Title", "Max", "MenuModule", "Console", blocks);

            return formModule;
        }


    }
}
