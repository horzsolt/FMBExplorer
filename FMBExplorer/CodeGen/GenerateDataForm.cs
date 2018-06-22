
using FMBExplorer.FormsElement;
using System.IO;
using System.Reflection;
using System.Text;

using RazorEngine;
using RazorEngine.Templating;

namespace FMBExplorer.CodeGen
{
    public class GenerateDataForm
    {
        static Assembly assembly = Assembly.GetExecutingAssembly();

        public static string Generate(Block block)
        {

            StringBuilder rowDefs = new StringBuilder();
            block.Items.ForEach(item =>
            {
                rowDefs.Append("<RowDefinition Height=\"Auto\"/>");
            });

            var columns = new GenerateDataFormFields().Generate(block);
            string result = "";

            var resourceName = "FMBExplorer.Templates.DataForm.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "dataFormTemplateKey", null, new { RowDefs = rowDefs, DataFormFields = columns });
            }

            return result;
        }
    }
}
