using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.PropertyGrid
{
    public class CodeGenProperties
    {

        public CodeGenProperties()
        {
            this.Guid = System.Guid.NewGuid();
        }

        [Category("Code Generation")]
        [DisplayName("Collection View Source Name")]
        public string CollectionViewSourceName { get; set; }

        [Category("Code Generation")]
        [DisplayName("Binding Source")]
        public string BindingSource { get; set; }
        public enum DataEntry { Simple, Form, Grid }

        [Category("Code Generation")]
        [DisplayName("Data Entry Type")]
        public DataEntry DataEntryStyle { get; set; }

        // Other cases of hidden read-only property and formatted property
        [DisplayName("GUID"), ReadOnly(true), Browsable(true)]
        public string GuidStr
        {
            get { return Guid.ToString(); }
        }

        [Browsable(false)]  // this property will not be displayed
        public System.Guid Guid
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return string.Format("{0}", Guid);
        }
    }
}
