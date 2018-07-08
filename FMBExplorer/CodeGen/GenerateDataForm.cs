
using FMBExplorer.FormsElement;
using System.IO;
using System.Reflection;
using System.Text;

using RazorEngine;
using RazorEngine.Templating;
using System.Web;
using FMBExplorer.PropertyGrid;

namespace FMBExplorer.CodeGen
{
    public class GenerateDataForm
    {
        static Assembly assembly = Assembly.GetExecutingAssembly();

        public static string Generate(Block block, CodeGenProperties codeGenProperties)
        {

            StringBuilder rowDefs = new StringBuilder();
            block.Items.ForEach(item =>
            {
                rowDefs.Append("<RowDefinition Height=\"Auto\"/>");
            });

            var columns = new GenerateDataFormFields().Generate(block, codeGenProperties);
            string result = "";

            var resourceName = "FMBExplorer.Templates.DataForm.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                result = HttpUtility.HtmlDecode(Engine.Razor.RunCompile(template, "dataFormTemplateKey", null, new {
                    ViewModelName = codeGenProperties.ViewModelName,
                    WindowName = codeGenProperties.WindowName,
                    RowDefs = rowDefs, DataFormFields = columns,
                    CollectionViewSourceName = codeGenProperties.CollectionViewSourceName,
                    BindingSource =codeGenProperties.BindingSource }));
            }

            return result;
        }
    }
}
