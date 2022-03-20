using UnityEngine;

namespace LitJson
{
    internal class OrderedDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
    {
        // Fields
        private System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, LitJson.JsonData>> list_enumerator;
        
        // Properties
        public object Current { get; }
        public System.Collections.DictionaryEntry Entry { get; }
        public object Key { get; }
        public object Value { get; }
        
        // Methods
        public object get_Current()
        {
            System.Collections.DictionaryEntry val_1 = this.Entry;
            return (object)val_1;
        }
        public System.Collections.DictionaryEntry get_Entry()
        {
            var val_4 = 0;
            val_4 = val_4 + 1;
            System.Collections.DictionaryEntry val_3 = new System.Collections.DictionaryEntry(key:  this.list_enumerator.Current, value:  public T System.Collections.Generic.IEnumerator<T>::get_Current());
            return new System.Collections.DictionaryEntry() {Key = val_3.Key, Value = val_3.Value};
        }
        public object get_Key()
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            return this.list_enumerator.Current;
        }
        public object get_Value()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            T val_2 = this.list_enumerator.Current;
            return (object)public T System.Collections.Generic.IEnumerator<T>::get_Current();
        }
        public OrderedDictionaryEnumerator(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, LitJson.JsonData>> enumerator)
        {
            this.list_enumerator = enumerator;
        }
        public bool MoveNext()
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            return this.list_enumerator.MoveNext();
        }
        public void Reset()
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            this.list_enumerator.Reset();
        }
    
    }

}
