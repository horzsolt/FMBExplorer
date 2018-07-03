using FMBExplorer.Common;
using FMBExplorer.FormsElement;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FMBExplorer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public FMBExplorer.PropertyGrid.Properties CodeGenProperties { get; set; }

        private bool? _isFormsCodeGen;
        public bool? IsGridCodeGen
        {
            get
            {
                return _isFormsCodeGen;
            }

            set
            {
                _isFormsCodeGen = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsFormsCodeGen"));
            }
        }

        private string _generatedCode;
        public string GeneratedCode
        {

            get
            {
                return _generatedCode;
            }

            set
            {
                _generatedCode = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GeneratedCode"));
            }
        }

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

        private ObservableDictionary<string, FormModule> _fmxList;
        public ObservableDictionary<string, FormModule> FmxList
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

        private FormModule _formModule;
        public FormModule FormModule
        {
            get
            {
                return _formModule;
            }

            set
            {
                _formModule = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FormModule"));
            }
        }

        public KeyValuePair<string, FormModule> SelectedFormModule { get; set; }
    }
}
