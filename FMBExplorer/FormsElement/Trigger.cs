using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.FormsElement
{
    public class Trigger : BaseFormsElement
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Trigger(string name, string triggerText)
        {
            this.Name = name;
            this.TriggerText = triggerText;
        }

        private string _name;
        public string Name
        {

            get
            {
                return _name;
            }

            set
            {
                _name = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        private string _triggerText;
        public string TriggerText
        {

            get
            {
                return _triggerText;
            }

            set
            {
                _triggerText = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("TriggerText"));
            }
        }
    }
}
