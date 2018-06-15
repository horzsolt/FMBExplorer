using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.FormsElement
{
    public class Block : BaseFormsElement
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public override string ToString()
        {
            return String.Format("{0} - {1} - Triggers: {2} Items: {3}", this.Name, this.QueryDataSourceName, this.Triggers.Count(), this.Items.Count());
        }

        public Block(string name, 
            string insertAllowed, 
            string deleteAllowed, 
            string updateAllowed, 
            string queryDataSourceName,
            string recordDisplayCount,
            string scrollbarTabPageName,
            string nextNavigationBlockName,
            string queryAllRecords,
            string keyMode,
            string scrollbarCanvasName,
            string orderByClause,
            string previousNavigationBlockName,
            string lockMode)
        {
            this.Name = name;
            this.InsertAllowed = insertAllowed;
            this.DeleteAllowed = deleteAllowed;
            this.UpdateAllowed = updateAllowed;
            this.QueryDataSourceName = queryDataSourceName;
            this.RecordsDisplayCount = recordDisplayCount;
            this.ScrollbarTabPageName = scrollbarTabPageName;
            this.NextNavigationBlockName = nextNavigationBlockName;
            this.QueryAllRecords = queryAllRecords;
            this.KeyMode = keyMode;
            this.ScrollbarCanvasName = scrollbarCanvasName;
            this.OrderByClause = orderByClause;
            this.PreviousNavigationBlockName = previousNavigationBlockName;
            this.LockMode = lockMode;

            Items = new List<Item>();
            Triggers = new List<Trigger>();
        }

        public List<Trigger> Triggers { get; set; }

        public List<Item> Items { get; set; }

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

        /// <summary>
        /// Új rekordot lehet-e rögzíteni (ezt is dinamikusan lehet állítani – és úgy is csinálom) ha true-ban van akkor a 
        /// felhasználó csinálhat egy üres rekordot , majd kitöltheti és elmentheti, ha false akkor nem tud üres rekordot 
        /// csinálni 
        /// </summary>
        private string _insertAllowed;
        public string InsertAllowed
        {

            get
            {
                return _insertAllowed;
            }

            set
            {
                _insertAllowed = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("InsertAllowed"));
            }
        }

        private string _deleteAllowed;
        public string DeleteAllowed
        {

            get
            {
                return _deleteAllowed;
            }

            set
            {
                _deleteAllowed = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("DeleteAllowed"));
            }
        }

        /// <summary>
        /// Módosíthatók-e az adatok. Ezt dinamikusan állítgatom programból. Ha True, akkor a felhasználó bele tud írni 
        /// azokba a item-ekbe, amiknek az InsertAllower/UpdateAllower property-je True (vagyis a Forms tudja, hogy éppen 
        /// egy new record-ról van szó vagy egy update-ről)
        /// </summary>
        private string _updateAllowed;
        public string UpdateAllowed
        {

            get
            {
                return _updateAllowed;
            }

            set
            {
                _updateAllowed = CleanXMLString(value);
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
                _queryDataSourceName = CleanXMLString(value);
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
                _recordsDisplayCount = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("RecordsDisplayCount"));
            }
        }

        /// <summary>
        /// A blokknak a scrollbarja, egy adott canvas-on jelen esetben egy tabcanvason jelenik meg és annak a „KAPOTT” fülén
        /// </summary>
        private string _scrollbarTabPageName;
        public string ScrollbarTabPageName
        {

            get
            {
                return _scrollbarTabPageName;
            }

            set
            {
                _scrollbarTabPageName = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("ScrollbarTabPageName"));
            }
        }

        /// <summary>
        /// ez azt mondja meg, hogy ha a standard Ctrl-PgDn gombot megnyomja a felhasználó akkor melyik lesz az a blokk 
        /// ami fókuszba kerül
        /// </summary>
        private string _nextNavigationBlockName;
        public string NextNavigationBlockName
        {

            get
            {
                return _nextNavigationBlockName;
            }

            set
            {
                _nextNavigationBlockName = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("NextNavigationBlockName"));
            }
        }

        /// <summary>
        /// ez azt állítja be, hogy page vagy full select -el kezelje az adatforrást, ha True -ban áll akkor a szűrőfeltételnek 
        /// megfelelő összes rekord lejön a db-ből, egyéb esetben meg csak annyi amekkora a blokk rekord count-ja
        /// </summary>
        private string _queryAllRecords;
        public string QueryAllRecords
        {

            get
            {
                return _queryAllRecords;
            }

            set
            {
                _queryAllRecords = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("QueryAllRecords"));
            }
        }

        /// <summary>
        /// ez a primary key = true itemekre vonatkozik és azt szabályozza, hogy amikor kimegy a db fele az update, 
        /// akkor lehet-e olyan eset, hogy valamelyik kulcs megváltozhat, ha False, akkor az update-ba bele sem kerülnek 
        /// a primary key mezői
        /// </summary>
        private string _keyMode;
        public string KeyMode
        {

            get
            {
                return _keyMode;
            }

            set
            {
                _keyMode = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("KeyMode"));
            }
        }

        private string _scrollbarCanvasName;
        public string ScrollbarCanvasName
        {

            get
            {
                return _scrollbarCanvasName;
            }

            set
            {
                _scrollbarCanvasName = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("ScrollbarCanvasName"));
            }
        }

        private string _orderByClause;
        public string OrderByClause
        {

            get
            {
                return _orderByClause;
            }

            set
            {
                _orderByClause = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("OrderByClause"));
            }
        }

        /// <summary>
        /// ez azt mondja meg, hogy ha a standard Ctrl-PgUp gombot megnyomja a felhasználó akkor melyik lesz az a blokk 
        /// ami fókuszba kerül
        /// </summary>
        private string _previousNavigationBlockName;
        public string PreviousNavigationBlockName
        {

            get
            {
                return _previousNavigationBlockName;
            }

            set
            {
                _previousNavigationBlockName = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("PreviousNavigationBlockName"));
            }
        }

        /// <summary>
        /// Ez azt szabályozza, hogy ha a felhasználó módosít akármit a rekordban, akkor azonnal próbálja-e locklolni a db-ben 
        /// a rekordot, vagy sem (a Delayed-el csak akkor lockol, amikor commit-ot nyomnak)
        /// </summary>
        private string _lockMode;
        public string LockMode
        {

            get
            {
                return _lockMode;
            }

            set
            {
                _lockMode = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("LockMode"));
            }
        }
    }
}
