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

            var resourceName = "FMBExplorer.Templates.TextFormField.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "columnTemplate", null, new { Name = item.Name, Row = counter, TextBox_Name = "txb_" + item.ColumnName, FieldName = item.ColumnName, Width = item.Width });
            }

            return result;
        }

        protected override string GenDateColumn(Item item, int counter)
        {
            string result = "";

            var resourceName = "FMBExplorer.Templates.DateFormField.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "dateColumnKey", null, new { Name = item.Name, Row = counter, TextBox_Name = "txb_" + item.ColumnName, FieldName = item.ColumnName, Width = item.Width });
            }

            return result;
        }
    }
}
