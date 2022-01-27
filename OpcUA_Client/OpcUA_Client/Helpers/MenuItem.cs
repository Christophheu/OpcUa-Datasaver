using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;

namespace OpcUA_Client
{
    /// <summary>
    /// Data object for one entry in the treeView. Implements the INotifyPropertyChanged interface
    /// </summary>
    public class MenuItem : INotifyPropertyChanged
    {

        #region attributes
        MenuItem _parent;
        public bool? isChecked
        #endregion

        #region properies
        {
            get { return _isChecked; }
            set { this.SetIsChecked(value, true, true); }
        }
        public ReferenceDescription RefDesc { get; }
        private bool? _isChecked = false;
        public List<MenuItem> Items { get; private set; }
        public string name { get; private set; }
        #endregion

        #region Constructors
        public MenuItem(string _Title, ReferenceDescription _refDesc)
        {
            Items = new List<MenuItem>();
            name = _Title;
            RefDesc = _refDesc;

            Initialize();
        }
        #endregion

        #region methods

        /// <summary>
        /// Set the CheckState for all Childs
        /// </summary>
        /// <param name="value"></param>
        /// <param name="updateChildren"></param>
        /// <param name="updateParent"></param>
        private void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
        {
            if (value == _isChecked) return;

            _isChecked = value;

            if (updateChildren && _isChecked.HasValue) Items.ForEach(c => c.SetIsChecked(_isChecked, true, false));

            if (updateParent && _parent != null) _parent.VerifyCheckedState();

            NotifyPropertyChanged("IsChecked");
        }


        /// <summary>
        /// Verify the State of the parents
        /// </summary>
        private void VerifyCheckedState()
        {
            bool? state = null;

            for (int i = 0; i < Items.Count; ++i)
            {
                bool? current = Items[i].isChecked;
                if (i == 0)
                {
                    state = current;
                }
                else if (state != current)
                {
                    state = null;
                    break;
                }
            }

            SetIsChecked(state, false, true);
        }

        /// <summary>
        /// Init the menuItem
        /// </summary>
        private void Initialize()
        {
            foreach (MenuItem item in Items)
            {
                item._parent = this;
                item.Initialize();
            }
        }

        #endregion

        #region Events
        /// <summary>
        /// ProperityChangedEvent
        /// </summary>
        /// <param name="info"></param>
        void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


    }
}
