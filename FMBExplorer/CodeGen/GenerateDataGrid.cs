using FMBExplorer.FormsElement;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.CodeGen
{
    public static class GenerateDataGrid
    {
        public static string Generate(Block block)
        {
            string result = "";
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "FMBExplorer.Templates.DataGrid.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                var templateService = new TemplateService();
                result = templateService.Parse(template, new { Name = block.Name, Columns = "" }, null, null);
            }

            return result;
        }
    }
}
