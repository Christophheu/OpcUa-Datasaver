using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUA_Client
{
    /// <summary>
    /// Class represent a ObservableDictionary as a extension of the Dictionary
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class ObservableDictionary<Tkey, TValue> : Dictionary<Tkey, TValue>, INotifyCollectionChanged
    {

        #region attrubutes

        #endregion

        #region properties

        #endregion

        #region methods

        /// <summary>
        /// Add new member to the dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public new void Add(Tkey key, TValue value)
        {
            base.Add(key, value);
            String DescString = "NodeID: " + key.ToString() + "    Wert: " + this[key].ToString();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, DescString));
        }

        /// <summary>
        /// Clear the Dictionary 
        /// </summary>
        public new void Clear()
        {
            base.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)); 
        }

        public new TValue this[Tkey key]
        {
            get
            {
                return base[key]; 
            }
            set
            {
                //find number of index
                int keyIndex = 0; 

                //go throu all keys in the dictionary
                foreach(Tkey keyIterator in this.Keys)
                {
                    if(keyIterator.ToString() == key.ToString())
                    {
                        break;
                    }
                    keyIndex++; 
                }

                String OldDescString = "NodeID: " + key.ToString() + "    Wert: " + base[key].ToString();
                String NewDescString = "NodeID: " + key.ToString() + "    Wert: " + value.ToString();
                base[key] = value;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, NewDescString, OldDescString,keyIndex));
                
            }
        }
        #endregion

        #region iNotifyCollectionChanged Members
        public event NotifyCollectionChangedEventHandler CollectionChanged; 
        #endregion
    }
}
