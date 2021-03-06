﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMBExplorer.FormsElement
{
    public class Item : BaseFormsElement
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private double WpfCoordinateCorrection = 1.3333;

        public enum ItemLabelPosition
        {
            Start,
            Top
        };

        public override string ToString()
        {
            return String.Format("{0} - Triggers: {1}", this.Prompt, this.Triggers.Count());
        }

        public string ToolTip
        {
            get
            {
                return ToString();
            }
        }

        public Item(string name, string maximumLength, string yPosition, string xPosition, string itemsDisplay,
            string distanceBetweenRecords, string width, string canvasName, string height, string required,
            string insertAllowed, string deleteAllowed, string updateAllowed, string itemType, string prompt,
            string tabPageName, string promptDisplayStyle, string columnName, string visualAttributeName,
            string dataType, IEnumerable<Trigger> triggers, string canvas, string visible, string promptAttachmentEdge)
        {
            this.Name = name;
            this.MaximumLength = maximumLength;
            this.YPosition = yPosition;
            this.XPosition = xPosition;
            this.ItemsDisplay = itemsDisplay;
            this.DistanceBetweenRecords = distanceBetweenRecords;
            this.Width = width;
            this.CanvasName = canvasName;
            this.Height = height;
            this.Required = required;
            this.InsertAllowed = insertAllowed;
            this.DeleteAllowed = deleteAllowed;
            this.UpdateAllowed = updateAllowed;
            this.ItemType = itemType;
            this.Prompt = prompt;
            this.TabPageName = tabPageName;
            this.PromptDisplayStyle = promptDisplayStyle;
            this.ColumnName = columnName;
            this.VisualAttributeName = visualAttributeName;
            this.DataType = dataType;
            this.Canvas = canvas;
            this.Visible = String.IsNullOrEmpty(visible) ? true : Convert.ToBoolean(CleanXMLString(visible));
            this.PromptAttachmentEdge = promptAttachmentEdge;

            if (promptAttachmentEdge == "Start")
            {
                this.LabelPosition = ItemLabelPosition.Start;
            }
            else if (promptAttachmentEdge == "Top")
            {
                this.LabelPosition = ItemLabelPosition.Top;
            }
            else
            {
                this.LabelPosition = ItemLabelPosition.Start;
            }

            Triggers = new List<Trigger>(triggers);
        }

        public List<Trigger> Triggers { get; set; }

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

        private string _maximumLength;
        public string MaximumLength
        {

            get
            {
                return _maximumLength;
            }

            set
            {
                _maximumLength = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("MaximumLength"));
            }
        }

        private string _yPosition;
        public string YPosition
        {

            get
            {
                return _yPosition;
            }

            set
            {
                _yPosition = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("YPosition"));
            }
        }

        private string _xPosition;
        public string XPosition
        {

            get
            {
                return _xPosition;
            }

            set
            {
                _xPosition = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("XPosition"));
            }
        }

        /// <summary>
        /// ha 0 akkor alapértelmezetten a datablock -ból vesz a megjelenített rekordok számát 
        /// </summary>
        private string _itemsDisplay;
        public string ItemsDisplay
        {

            get
            {
                return _itemsDisplay;
            }

            set
            {
                _itemsDisplay = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("ItemsDisplay"));
            }
        }

        private string _distanceBetweenRecords;
        public string DistanceBetweenRecords
        {

            get
            {
                return _distanceBetweenRecords;
            }

            set
            {
                _distanceBetweenRecords = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("DistanceBetweenRecords"));
            }
        }

        private string _width;
        public string Width
        {

            get
            {
                return _width;
            }

            set
            {
                _width = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Width"));
            }
        }


        /// <summary>
        /// igen lehet ilyen pl. két canvas van egy window-ban, vagy az egyik item az egyik tabra kerül a másik meg a másikra … 
        /// </summary>
        private string _canvasName;
        public string CanvasName
        {

            get
            {
                return _canvasName;
            }

            set
            {
                _canvasName = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("CanvasName"));
            }
        }

        private string _height;
        public string Height
        {

            get
            {
                return _height;
            }

            set
            {
                _height = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Height"));
            }
        }

        private string _required;
        public string Required
        {

            get
            {
                return _required;
            }

            set
            {
                _required = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Required"));
            }
        }

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

        /// <summary>
        /// Text Item, CheckBox, RadioButton, DisplayItem
        /// </summary>
        private string _itemType;
        public string ItemType
        {

            get
            {
                return _itemType;
            }

            set
            {
                _itemType = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("ItemType"));
            }
        }

        private string _dataType;
        public string DataType
        {

            get
            {
                return _dataType;
            }

            set
            {
                _dataType = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("DataType"));
            }
        }

        private string _prompt;
        public string Prompt
        {

            get
            {
                return _prompt;
            }

            set
            {
                _prompt = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Prompt"));
            }
        }

        private string _tabPageName;
        public string TabPageName
        {

            get
            {
                return _tabPageName;
            }

            set
            {
                _tabPageName = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("TabPageName"));
            }
        }

        /// <summary>
        /// ez azt jelenti, hogy ha pl. egy itemnek az van beállítva, hogy 3 sorban jelenjen meg, akkor a labelje minden sornál megjelenjen vagy csak egyszer az elsőnél
        /// </summary>
        private string _promptDisplayStyle;
        public string PromptDisplayStyle
        {

            get
            {
                return _promptDisplayStyle;
            }

            set
            {
                _promptDisplayStyle = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("PromptDisplayStyle"));
            }
        }

        private string _columnName;
        public string ColumnName
        {

            get
            {
                return _columnName;
            }

            set
            {
                _columnName = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("ColumnName"));
            }
        }

        private string _canvas;
        public string Canvas
        {

            get
            {
                return _canvas;
            }

            set
            {
                _canvas = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Canvas"));
            }
        }

        private bool _visible;
        public bool Visible
        {

            get
            {
                return _visible;
            }

            set
            {
                _visible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Canvas"));
            }
        }

        private string _visualAttributeName;
        public string VisualAttributeName
        {

            get
            {
                return _visualAttributeName;
            }

            set
            {
                _visualAttributeName = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("VisualAttributeName"));
            }
        }

        private int _wpfYPosition;
        public int WpfYPosition
        {
            get
            {
                if (Int32.TryParse(YPosition, out _wpfYPosition))
                {
                    return Convert.ToInt32(_wpfYPosition * WpfCoordinateCorrection);
                }
                else
                {
                    throw new InvalidOperationException("WpfYPosition conversion error");
                }
            }
        }

        private int _wpfXPosition;
        public int WpfXPosition
        {
            get
            {
                if (Int32.TryParse(XPosition, out _wpfXPosition))
                {
                    return Convert.ToInt32(_wpfXPosition * WpfCoordinateCorrection);
                }
                else
                {
                    throw new InvalidOperationException("WpfXPosition conversion error");
                }
            }
        }

        private int _wpfWidth;
        public int WpfWidth
        {
            get
            {
                if (Int32.TryParse(Width, out _wpfWidth))
                {
                    return Convert.ToInt32(_wpfWidth * WpfCoordinateCorrection);
                }
                else
                {
                    throw new InvalidOperationException("WpfWidth conversion error");
                }
            }
        }

        private int _wpfHeight;
        public int WpfHeight
        {
            get
            {
                if (Int32.TryParse(Height, out _wpfHeight))
                {
                    return Convert.ToInt32(_wpfHeight * WpfCoordinateCorrection);
                }
                else
                {
                    throw new InvalidOperationException("WpfHeight conversion error");
                }
            }
        }

        private string _promptAttachmentEdge;
        public string PromptAttachmentEdge
        {

            get
            {
                return _promptAttachmentEdge;
            }

            set
            {
                _promptAttachmentEdge = CleanXMLString(value);
                PropertyChanged(this, new PropertyChangedEventArgs("PromptAttachmentEdge"));
            }
        }

        public ItemLabelPosition LabelPosition { get; set; }
    }
}