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
        static Assembly assembly = Assembly.GetExecutingAssembly();

        public static string Generate(Block block)
        {

            var columns = new GenerateDataGridColumns().Generate(block);
            string result = "";
            
            var resourceName = "FMBExplorer.Templates.DataGrid.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "templateKey", null, new { Name = block.Name, Columns = columns });
            }

            return result;
        }
    }
}
