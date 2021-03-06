﻿using System;
using System.IO;
using System.Reflection;
using System.Text;
using FMBExplorer.FormsElement;
using FMBExplorer.PropertyGrid;

namespace FMBExplorer.CodeGen
{
    public abstract class AbstractFieldGenerator
    {
        protected Assembly assembly = Assembly.GetExecutingAssembly();

        public string Generate(FormsElement.Block block, CodeGenProperties codeGenProperties)
        {
            StringBuilder result = new StringBuilder("");
            int counter = 0;

            block.Items.ForEach(item =>
            {
                if ((!String.IsNullOrEmpty(item.ColumnName)) && ((item.Visible == true) || (!String.IsNullOrEmpty(item.Canvas))))
                {
                    counter++;

                    if (!string.IsNullOrEmpty(item.ItemType))
                    {
                        switch (item.ItemType)
                        {
                            case "Text Item":
                                {
                                    result.Append(GenTextColumn(item, counter, codeGenProperties)).AppendLine();
                                    break;
                                }
                            default:
                                {
                                    result.Append(GenTextColumn(item, counter, codeGenProperties)).AppendLine();
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
                                    result.Append(GenDateColumn(item, counter, codeGenProperties)).AppendLine();
                                    break;
                                }
                            case "Char":
                                {
                                    result.Append(GenTextColumn(item, counter, codeGenProperties)).AppendLine();
                                    break;
                                }
                            default:
                                {
                                    result.Append(GenTextColumn(item, counter, codeGenProperties)).AppendLine();
                                    break;
                                }
                        }
                    }
                    else if ((string.IsNullOrEmpty(item.ItemType) && (string.IsNullOrEmpty(item.DataType))))
                    {
                        result.Append(GenTextColumn(item, counter, codeGenProperties));
                    }
                    else
                    {
                        throw new InvalidDataException(string.Format("Unknown Item found. {0} ", item.ToString()));
                    }
                }
            });

            return result.ToString();
        }

        protected abstract string GenTextColumn(Item item, int counter, CodeGenProperties codeGenProperties);
        protected abstract string GenDateColumn(Item item, int counter, CodeGenProperties codeGenProperties);
    }
}
