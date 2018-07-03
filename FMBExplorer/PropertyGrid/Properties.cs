using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.PropertyGrid
{
    public class Properties
    {
        public enum GridStyle { Simple, Form }

        // The following are auto-implemented properties (C# 3.0 and up)
        [Category("CodeGen")]
        [DisplayName("GridStyle")]
        public GridStyle PersonGender { get; set; }

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

        public Properties()
        {
            this.Guid = System.Guid.NewGuid();
        }

        public override string ToString()
        {
            return string.Format("{0}", Guid);
        }
    }
}
