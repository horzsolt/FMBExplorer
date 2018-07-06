using System.IO;
using System.Reflection;
using System.Text;
using FMBExplorer.FormsElement;
using FMBExplorer.PropertyGrid;
using RazorEngine;
using RazorEngine.Templating;

namespace FMBExplorer.CodeGen
{
    public class GenerateDataGridColumns : AbstractFieldGenerator
    {
        protected override string GenTextColumn(Item item, int counter, CodeGenProperties codeGenProperties)
        {
            string result = "";

            var resourceName = "FMBExplorer.Templates.TextColumn.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "columnTemplate", null, new { Name = item.Name, FieldName = item.ColumnName, Prompt = item.Prompt });
            }

            return result;
        }

        protected override string GenDateColumn(Item item, int counter, CodeGenProperties codeGenProperties)
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
