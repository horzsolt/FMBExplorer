using System.IO;
using System.Reflection;
using System.Text;
using FMBExplorer.FormsElement;
using RazorEngine;
using RazorEngine.Templating;

namespace FMBExplorer.CodeGen
{
    public static class GenerateDataGridColumns
    {
        static Assembly assembly = Assembly.GetExecutingAssembly();

        public static string Generate(Block block)
        {
            StringBuilder result = new StringBuilder("");

            block.Items.ForEach(item =>
            {
                if (!string.IsNullOrEmpty(item.ItemType))
                {
                    switch (item.ItemType)
                    {
                        case "Text Item":
                            {
                                result.Append(GenTextColumn(item)).AppendLine();
                                break;
                            }
                        default:
                            {
                                result.Append(GenTextColumn(item)).AppendLine();
                                break;
                            }
                    }
                } else if (!string.IsNullOrEmpty(item.DataType))
                {
                    switch (item.DataType)
                    {
                        case "Date":
                            {
                                result.Append(GenDateColumn(item)).AppendLine();
                                break;
                            }
                        case "Char":
                            {
                                result.Append(GenTextColumn(item)).AppendLine();
                                break;
                            }
                        default:
                            {
                                result.Append(GenTextColumn(item)).AppendLine();
                                break;
                            }
                    }
                } else if ((string.IsNullOrEmpty(item.ItemType) && (string.IsNullOrEmpty(item.DataType)))) {
                    result.Append(GenTextColumn(item));
                } else
                {
                    throw new InvalidDataException(string.Format("Unknown Item found. {0} ", item.ToString()));
                }
            });

            return result.ToString();
        }

        private static string GenTextColumn(Item item)
        {
            string template = "<DataGridTextColumn x: Name = \"@Model.Name\" Binding = \"{Binding @Model.FieldName}\" Header = \"@Model.Prompt\" Width = \"SizeToHeader\" />";
            string result = Engine.Razor.RunCompile(template, "columnTemplate", null, new { Name = item.Name, FieldName = item.ColumnName, Prompt = item.Prompt });

            return result;
        }

        private static string GenDateColumn(Item item)
        {
            string result = "";

            var resourceName = "FMBExplorer.Templates.DateColumn.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "dateColumnKey", null, new { Name = item.Name, Prompt = item.Prompt, FieldName = item.ColumnName });
            }

            return result;
        }
    }
}
