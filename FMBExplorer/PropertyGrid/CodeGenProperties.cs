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

        [Category("C# Code Generation")]
        [DisplayName("Partial Class Namespace")]
        public string CodebehindNamespace { get; set; }

        [Category("C# Code Generation")]
        [DisplayName("Window Name")]
        public string WindowName { get; set; }

        [Category("C# Code Generation")]
        [DisplayName("Entity Name")]
        public string EntityName { get; set; }

        [Category("XAML Generation")]
        [DisplayName("Collection View Source Name")]
        public string CollectionViewSourceName { get; set; }

        [Category("XAML Generation")]
        [DisplayName("Binding Source")]
        public string BindingSource { get; set; }

        [Category("XAML Generation")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Category("View Model")]
        [DisplayName("View Model Name")]
        public string ViewModelName { get; set; }

        [Category("View Model")]
        [DisplayName("Enabled Property")]
        public string EnabledPropertyName { get; set; }

        public enum DataEntry { Simple, Form, Grid }

        [Category("XAML Generation")]
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
