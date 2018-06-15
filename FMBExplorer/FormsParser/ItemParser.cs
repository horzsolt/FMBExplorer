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
                    name: el.Attribute(ns + "Name")?.Value.ToString(),
                    maximumLength: el.Attribute(ns + "MaximumLength")?.Value.ToString(),
                    yPosition: el.Attribute(ns + "YPosition")?.Value.ToString(),
                    xPosition: el.Attribute(ns + "XPosition")?.Value.ToString(),
                    itemsDisplay: el.Attribute(ns + "ItemsDisplay")?.Value.ToString(),
                    distanceBetweenRecords: el.Attribute(ns + "DistanceBetweenRecords")?.Value.ToString(),
                    width: el.Attribute(ns + "Width")?.Value.ToString(),
                    canvasName: el.Attribute(ns + "CanvasName")?.Value.ToString(),
                    height: el.Attribute(ns + "Height")?.Value.ToString(),
                    required: el.Attribute(ns + "Required")?.Value.ToString(),
                    insertAllowed: el.Attribute(ns + "InsertAllowed")?.Value.ToString(),
                    deleteAllowed: el.Attribute(ns + "DeleteAllowed")?.Value.ToString(),
                    updateAllowed: el.Attribute(ns + "UpdateAllowed")?.Value.ToString(),
                    itemType: el.Attribute(ns + "ItemType")?.Value.ToString(),
                    prompt: el.Attribute(ns + "Prompt")?.Value.ToString(),
                    tabPageName: el.Attribute(ns + "TabPageName")?.Value.ToString(),
                    promptDisplayStyle: el.Attribute(ns + "PromptDisplayStyle")?.Value.ToString(),
                    columnName: el.Attribute(ns + "ColumnName")?.Value.ToString(),
                    visualAttributeName: el.Attribute(ns + "VisualAttributeName")?.Value.ToString()
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

                item.Triggers.AddRange(triggers);
            }

            return items;
        }
    }
}
