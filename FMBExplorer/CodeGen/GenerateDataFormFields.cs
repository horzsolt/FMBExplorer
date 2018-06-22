using System;
using System.Collections.Generic;
using System.IO;
using FMBExplorer.FormsElement;

using RazorEngine;
using RazorEngine.Templating;

namespace FMBExplorer.CodeGen
{
    public class GenerateDataFormFields : AbstractFieldGenerator
    {
        protected override string GenTextColumn(Item item, int counter)
        {
            string result = "";

            var resourceName = "FMBExplorer.Templates.DataFormField.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "columnTemplate", null, new { Name = item.Name, FieldName = item.ColumnName, Prompt = item.Prompt });
            }

            return result;
        }

        protected override string GenDateColumn(Item item, int counter)
        {
            string result = "";

            var resourceName = "FMBExplorer.Templates.DateColumn.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "dateColumnKey", null, new { Name = item.Name, Prompt = item.Prompt, FieldName = item.ColumnName });
            }

            return result;
        }
    }
}
