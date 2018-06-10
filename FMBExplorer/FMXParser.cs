using FMBExplorer.FormsElement;
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

            IEnumerable<Block> blocks =
                from el in fmx.Descendants(ns + "Block")
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

            foreach (Block blockItem in blocks)
            {
                XElement block = (from el in fmx.Descendants(ns + "Block")
                                  where blockItem.Name == el.Attribute("Name").Value
                                  select el).First();

                IEnumerable<Item> items =
                    from el in block.Descendants(ns + "Item")
                    select new Item(
                        name: el.Attribute(ns + "Name")?.ToString(),
                        maximumLength: el.Attribute(ns + "MaximumLength")?.ToString(),
                        yPosition: el.Attribute(ns + "YPosition")?.ToString(),
                        xPosition: el.Attribute(ns + "XPosition")?.ToString(),
                        itemsDisplay: el.Attribute(ns + "ItemsDisplay")?.ToString(),
                        distanceBetweenRecords: el.Attribute(ns + "DistanceBetweenRecords")?.ToString(),
                        width: el.Attribute(ns + "Width")?.ToString(),
                        canvasName: el.Attribute(ns + "CanvasName")?.ToString(),
                        height: el.Attribute(ns + "Height")?.ToString(),
                        required: el.Attribute(ns + "Required")?.ToString(),
                        insertAllowed: el.Attribute(ns + "InsertAllowed")?.ToString(),
                        deleteAllowed: el.Attribute(ns + "DeleteAllowed")?.ToString(),
                        updateAllowed: el.Attribute(ns + "UpdateAllowed")?.ToString(),
                        itemType: el.Attribute(ns + "ItemType")?.ToString(),
                        prompt: el.Attribute(ns + "Prompt")?.ToString(),
                        tabPageName: el.Attribute(ns + "TabPageName")?.ToString(),
                        promptDisplayStyle: el.Attribute(ns + "PromptDisplayStyle")?.ToString(),
                        columnName: el.Attribute(ns + "ColumnName")?.ToString(),
                        visualAttributeName: el.Attribute(ns + "VisualAttributeName")?.ToString()
                        );

                IEnumerable<Trigger> triggersOfTheBlock = from el in block.Descendants(ns + "Trigger")
                                                          select new Trigger(
                        name: el.Attribute(ns + "Name")?.ToString(),
                        triggerText: el.Attribute(ns + "TriggerText")?.ToString()
                        );

                foreach (Item item in items)
                {
                    XElement givenItem = (from el in block.Descendants(ns + "Item")
                                          where item.Name == el.Attribute("Name").Value
                                          select el).First();

                    IEnumerable<Trigger> triggers =
                        from el in givenItem.Descendants(ns + "Trigger")
                        select new Trigger(
                            name: el.Attribute(ns + "Name")?.ToString(),
                            triggerText: el.Attribute(ns + "TriggerText")?.ToString()
                            );

                    item.triggers.AddRange(triggers);
                }

                blockItem.items.AddRange(items);
            }

            //blocks.
        }
    }
}
