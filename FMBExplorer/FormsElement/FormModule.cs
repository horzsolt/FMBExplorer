using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.FormsElement
{
    public class FormModule : BaseFormsElement
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public FormModule(string Name, string Title, string MaximumQueryTime, string MenuModule, String ConsoleWindow, List<Block> Blocks)
        {
            this.Name = Name;
            this.MaximumQueryTime = MaximumQueryTime;
            this.MenuModule = MenuModule;
            this.ConsoleWindow = ConsoleWindow;
            this.Blocks = Blocks;
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

        private string _title;
        public string Title
        {

            get
            {
                return _title;
            }

            set
            {
                _title = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }

        private string _maximumQueryTime;
        public string MaximumQueryTime
        {

            get
            {
                return _maximumQueryTime;
            }

            set
            {
                _maximumQueryTime = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("MaximumQueryTime"));
            }
        }

        private string _menuModule;
        public string MenuModule
        {

            get
            {
                return _menuModule;
            }

            set
            {
                _menuModule = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("MenuModule"));
            }
        }

        private string _consoleWindowe;
        public string ConsoleWindow
        {

            get
            {
                return _consoleWindowe;
            }

            set
            {
                _consoleWindowe = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("ConsoleWindow"));
            }
        }

        public List<Block> Blocks { get; set; }
    }
}
