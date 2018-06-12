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
                       name: el.Attribute(ns + "Name")?.Value.ToString(),
                       insertAllowed: el.Attribute(ns + "InsertAllowed")?.Value.ToString(),
                       deleteAllowed: el.Attribute(ns + "DeleteAllowed")?.Value.ToString(),
                       updateAllowed: el.Attribute(ns + "UpdateAllowed")?.Value.ToString(),
                       queryDataSourceName: el.Attribute(ns + "QueryDataSourceName")?.Value.ToString(),
                       recordDisplayCount: el.Attribute(ns + "RecordsDisplayCount")?.Value.ToString(),
                       scrollbarTabPageName: el.Attribute(ns + "ScrollbarTabPageName")?.Value.ToString(),
                       nextNavigationBlockName: el.Attribute(ns + "NextNavigationBlockName")?.Value.ToString(),
                       queryAllRecords: el.Attribute(ns + "QueryAllRecords")?.Value.ToString(),
                       keyMode: el.Attribute(ns + "KeyMode")?.Value.ToString(),
                       scrollbarCanvasName: el.Attribute(ns + "ScrollbarCanvasName")?.Value.ToString(),
                       orderByClause: el.Attribute(ns + "OrderByClause")?.Value.ToString(),
                       previousNavigationBlockName: el.Attribute(ns + "PreviousNavigationBlockName")?.Value.ToString(),
                       lockMode: el.Attribute(ns + "LockMode")?.Value.ToString()
                       );
        }

        public static Block GetBlockByName(XNamespace ns, XElement fmx, string Name)
        {
            return (from el in fmx.Descendants(ns + "Block")
                    where el.Attribute("Name").Value == Name
                    select new Block(
                        name: el.Attribute(ns + "Name")?.Value.ToString(),
                        insertAllowed: el.Attribute(ns + "InsertAllowed")?.Value.ToString(),
                        deleteAllowed: el.Attribute(ns + "DeleteAllowed")?.Value.ToString(),
                        updateAllowed: el.Attribute(ns + "UpdateAllowed")?.Value.ToString(),
                        queryDataSourceName: el.Attribute(ns + "QueryDataSourceName")?.Value.ToString(),
                        recordDisplayCount: el.Attribute(ns + "RecordsDisplayCount")?.Value.ToString(),
                        scrollbarTabPageName: el.Attribute(ns + "ScrollbarTabPageName")?.Value.ToString(),
                        nextNavigationBlockName: el.Attribute(ns + "NextNavigationBlockName")?.Value.ToString(),
                        queryAllRecords: el.Attribute(ns + "QueryAllRecords")?.Value.ToString(),
                        keyMode: el.Attribute(ns + "KeyMode")?.Value.ToString(),
                        scrollbarCanvasName: el.Attribute(ns + "ScrollbarCanvasName")?.Value.ToString(),
                        orderByClause: el.Attribute(ns + "OrderByClause")?.Value.ToString(),
                        previousNavigationBlockName: el.Attribute(ns + "PreviousNavigationBlockName")?.Value.ToString(),
                        lockMode: el.Attribute(ns + "LockMode")?.Value.ToString()
                        )).First();
        }
    }
}
