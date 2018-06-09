using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer
{
    public class FMB
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

        private string _updateAllowed;
        public string UpdateAllowed
        {

            get
            {
                return _updateAllowed;
            }

            set
            {
                _updateAllowed = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UpdateAllowed"));
            }
        }

        private string _queryDataSourceName;
        public string QueryDataSourceName
        {

            get
            {
                return _queryDataSourceName;
            }

            set
            {
                _queryDataSourceName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QueryDataSourceName"));
            }
        }

        private string _recordsDisplayCount;
        public string RecordsDisplayCount
        {

            get
            {
                return _recordsDisplayCount;
            }

            set
            {
                _recordsDisplayCount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RecordsDisplayCount"));
            }
        }
    }
}
