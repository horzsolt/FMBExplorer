using FMBExplorer.FormsElement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _currentFolder;
        public string CurrentFolder
        {

            get
            {
                return _currentFolder;
            }

            set
            {
                _currentFolder = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentFolder"));
            }
        }

        private Dictionary<string, FormModule> _fmxList;
        public Dictionary<string, FormModule> FmxList
        {

            get
            {
                return _fmxList;
            }

            set
            {
                _fmxList = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FmxList"));
            }
        }
    }
}
