using FMBExplorer.FormsElement;
using FMBExplorer.PropertyGrid;
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

        public static string Generate(Block block, CodeGenProperties codeGenProperties)
        {

            var columns = new GenerateDataGridColumns().Generate(block, codeGenProperties);
            string result = "";
            
            var resourceName = "FMBExplorer.Templates.DataGrid.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string template = reader.ReadToEnd();
                result = Engine.Razor.RunCompile(template, "templateKey", null, new { Name = block.Name, CollectionViewSourceName = codeGenProperties.CollectionViewSourceName, BindingSource = codeGenProperties.BindingSource, Columns = columns });
            }

            return result;
        }
    }
}
