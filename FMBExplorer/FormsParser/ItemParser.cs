using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FMBExplorer.FormsElement;

namespace FMBExplorer.FormsParser
{
    public static class ItemParser
    {
        public static IEnumerable<Item> GetItems(XNamespace ns, XElement block)
        {
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

            return items;
        }
    }
}
