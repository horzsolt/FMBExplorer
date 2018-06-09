using System;
using System.Collections.Generic;
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
            XElement fmx = XElement.Load(fileName);

            IEnumerable<XElement> blocks = from block in fmx.Elements("Block")
                    select block;

            blocks.
        }
    }
}
