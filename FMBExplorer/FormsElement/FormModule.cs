using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.FormsElement
{
    public class FormModule
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _name;
        public string Name
        {

            get
            {
                return _name;
            }

            set
            {
                _name = value;
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
                _title = value;
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
                _maximumQueryTime = value;
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
                _menuModule = value;
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
                _consoleWindowe = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConsoleWindow"));
            }
        }

        public List<Block> blocks { get; set; }
    }
}
