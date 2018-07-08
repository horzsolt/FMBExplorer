using System.IO;
using System.Reflection;
using FMBExplorer.FormsElement;
using FMBExplorer.PropertyGrid;
using RazorEngine;
using RazorEngine.Templating;

namespace FMBExplorer.CodeGen
{
    public class GenerateViewModel
    {
        static Assembly assembly = Assembly.GetExecutingAssembly();

        public static string Generate(Block block, CodeGenProperties codeGenProperties)
        {
            string result = "";

            var resourceName = "FMBExplorer.Templates.ViewModelClass.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "VMtemplateKey", null, new
                {
                    ViewModelName = codeGenProperties.ViewModelName,
                    EnabledPropertyName = codeGenProperties.EnabledPropertyName
                });
            }

            return result;
        }
    }
}
