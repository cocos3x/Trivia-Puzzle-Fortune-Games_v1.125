using UnityEngine;

namespace SLC.Minigames.Bubbles
{
    public class WordBubblesCategory
    {
        // Fields
        private string <Category>k__BackingField;
        private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> <LetterWordsDic>k__BackingField;
        
        // Properties
        public string Category { get; set; }
        public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> LetterWordsDic { get; set; }
        
        // Methods
        public string get_Category()
        {
            return (string)this.<Category>k__BackingField;
        }
        private void set_Category(string value)
        {
            this.<Category>k__BackingField = value;
        }
        public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> get_LetterWordsDic()
        {
            return (System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>)this.<LetterWordsDic>k__BackingField;
        }
        private void set_LetterWordsDic(System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> value)
        {
            this.<LetterWordsDic>k__BackingField = value;
        }
        public WordBubblesCategory(string catName, System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> letterWordsDic)
        {
            val_1 = new System.Object();
            this.<Category>k__BackingField = catName;
            this.<LetterWordsDic>k__BackingField = val_1;
        }
        public override string ToString()
        {
            string val_3;
            var val_5;
            string val_13;
            var val_14;
            string val_15;
            string val_1 = "catName:"("catName:") + this.<Category>k__BackingField(this.<Category>k__BackingField);
            Dictionary.Enumerator<TKey, TValue> val_2 = this.<LetterWordsDic>k__BackingField.GetEnumerator();
            label_9:
            if(val_5.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_13 = ", ";
            val_15 = val_1 + val_13 + val_3.ToString() + ": "(": ");
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_9 = val_3.GetEnumerator();
            label_5:
            if(val_5.MoveNext() == false)
            {
                goto label_4;
            }
            
            string val_11 = val_15 + " ," + val_3;
            goto label_5;
            label_4:
            var val_12 = 0 + 1;
            val_15 = 0;
            mem2[0] = 135;
            val_5.Dispose();
            if(val_15 != 0)
            {
                goto label_6;
            }
            
            if((val_12 == 1) || ((1152921519836585360 + ((0 + 1)) << 2) != 135))
            {
                goto label_9;
            }
            
            var val_15 = 0;
            val_15 = val_15 ^ (val_12 >> 31);
            var val_13 = val_12 + val_15;
            goto label_9;
            label_2:
            var val_14 = 0 + 1;
            mem2[0] = 160;
            val_5.Dispose();
            return val_1;
            label_6:
            val_14 = val_15;
            val_13 = 0;
            throw val_14;
        }
    
    }

}
