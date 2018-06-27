using System.IO;
using System.Windows;
using System.Windows.Controls;
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

            Label dummyLabel = new Label() { Content = item.Prompt };
            dummyLabel.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            int labelWidth = System.Convert.ToInt32(dummyLabel.DesiredSize.Width);

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "textFieldTemplateKey", null, new { Name = item.Name, Row = counter, TextBox_Name = "txb_" + item.ColumnName, FieldName = item.ColumnName, Width = item.WpfWidth, Height = item.WpfHeight, Prompt = item.Prompt, Left = item.WpfXPosition, LabelLeft = item.WpfXPosition - labelWidth, Bottom = item.WpfYPosition });
            }

            return result;
        }

        protected override string GenDateColumn(Item item, int counter)
        {
            string result = "";

            Label dummyLabel = new Label() { Content = item.Prompt };
            dummyLabel.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            int labelWidth = System.Convert.ToInt32(dummyLabel.DesiredSize.Width);

            var resourceName = "FMBExplorer.Templates.DateFormField.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "dateFieldTemplateKey", null, new { Name = item.Name, Row = counter, TextBox_Name = "txb_" + item.ColumnName, FieldName = item.ColumnName, Width = item.WpfWidth, Height = item.WpfHeight, Prompt = item.Prompt, Left = item.WpfXPosition, LabelLeft = item.WpfXPosition - labelWidth, Bottom = item.WpfYPosition });
            }

            return result;
        }
    }
}
