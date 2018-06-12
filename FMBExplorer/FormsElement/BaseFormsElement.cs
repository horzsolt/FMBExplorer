using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.FormsElement
{
    public class BaseFormsElement
    {
        protected string CleanXMLString(string input)
        {
            return input?.Replace("\"", "");
        }
    }
}
