using FMBExplorer.FormsElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FMBExplorer.FormsParser
{
    public static class BlockParser
    {
        public static IEnumerable<Block> GetBlocks(XNamespace ns, XElement fmx)
        {
            return from el in fmx.Descendants(ns + "Block")
                   select new Block(
                       name: el.Attribute(ns + "Name")?.ToString(),
                       insertAllowed: el.Attribute(ns + "InsertAllowed")?.ToString(),
                       deleteAllowed: el.Attribute(ns + "DeleteAllowed")?.ToString(),
                       updateAllowed: el.Attribute(ns + "UpdateAllowed")?.ToString(),
                       queryDataSourceName: el.Attribute(ns + "QueryDataSourceName")?.ToString(),
                       recordDisplayCount: el.Attribute(ns + "RecordDisplayCount")?.ToString(),
                       scrollbarTabPageName: el.Attribute(ns + "ScrollbarTabPageName")?.ToString(),
                       nextNavigationBlockName: el.Attribute(ns + "NextNavigationBlockName")?.ToString(),
                       queryAllRecords: el.Attribute(ns + "QueryAllRecords")?.ToString(),
                       keyMode: el.Attribute(ns + "KeyMode")?.ToString(),
                       scrollbarCanvasName: el.Attribute(ns + "ScrollbarCanvasName")?.ToString(),
                       orderByClause: el.Attribute(ns + "OrderByClause")?.ToString(),
                       previousNavigationBlockName: el.Attribute(ns + "PreviousNavigationBlockName")?.ToString(),
                       lockMode: el.Attribute(ns + "LockMode")?.ToString()
                       );
        }
    }
}
