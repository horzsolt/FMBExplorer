using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Razor.Parser.SyntaxTree;
using RazorEngine;
using RazorEngine.Templating;
using FMBExplorer.FormsElement;

namespace FMBExplorer.CodeGen
{
    public abstract class AbstractFieldGenerator
    {
        protected Assembly assembly = Assembly.GetExecutingAssembly();

        public string Generate(FormsElement.Block block)
        {
            StringBuilder result = new StringBuilder("");
            int counter = 0;

            block.Items.ForEach(item =>
            {
                if (!String.IsNullOrEmpty(item.Name))
                {
                    counter++;

                    if (!string.IsNullOrEmpty(item.ItemType))
                    {
                        switch (item.ItemType)
                        {
                            case "Text Item":
                                {
                                    result.Append(GenTextColumn(item, counter)).AppendLine();
                                    break;
                                }
                            default:
                                {
                                    result.Append(GenTextColumn(item, counter)).AppendLine();
                                    break;
                                }
                        }
                    }
                    else if (!string.IsNullOrEmpty(item.DataType))
                    {
                        switch (item.DataType)
                        {
                            case "Date":
                                {
                                    result.Append(GenDateColumn(item, counter)).AppendLine();
                                    break;
                                }
                            case "Char":
                                {
                                    result.Append(GenTextColumn(item, counter)).AppendLine();
                                    break;
                                }
                            default:
                                {
                                    result.Append(GenTextColumn(item, counter)).AppendLine();
                                    break;
                                }
                        }
                    }
                    else if ((string.IsNullOrEmpty(item.ItemType) && (string.IsNullOrEmpty(item.DataType))))
                    {
                        result.Append(GenTextColumn(item, counter));
                    }
                    else
                    {
                        throw new InvalidDataException(string.Format("Unknown Item found. {0} ", item.ToString()));
                    }
                }
            });

            return result.ToString();
        }

        protected abstract string GenTextColumn(Item item, int counter);
        protected abstract string GenDateColumn(Item item, int counter);
    }
}
