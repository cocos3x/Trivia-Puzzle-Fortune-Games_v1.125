using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordSolutionData
    {
        // Fields
        public string word;
        public System.Collections.Generic.List<int> slotSequence;
        
        // Methods
        public WordSolutionData(string _word, System.Collections.Generic.List<int> sequence)
        {
            val_1 = new System.Object();
            this.word = _word;
            this.slotSequence = val_1;
        }
        public override string ToString()
        {
            string val_6;
            System.Collections.Generic.List<System.Int32> val_7;
            int val_8;
            var val_6 = 0;
            val_6 = "";
            label_6:
            if(val_6 >= "")
            {
                goto label_2;
            }
            
            if(val_6 >= 44273376)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_7 = this.slotSequence;
            val_6 = val_6 + public CreatorPropertyContext List.Enumerator<CreatorPropertyContext>::get_Current().ToString()(public CreatorPropertyContext List.Enumerator<CreatorPropertyContext>::get_Current().ToString());
            if(val_6 < (1152921515789385199 << ))
            {
                    val_7 = this.slotSequence;
                val_6 = val_6 + ", ";
            }
            
            val_6 = val_6 + 1;
            if(val_7 != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_2:
            string[] val_4 = new string[5];
            val_8 = val_4.Length;
            val_4[0] = "{ Word: ";
            if(this.word != null)
            {
                    val_8 = val_4.Length;
            }
            
            val_4[1] = this.word;
            val_8 = val_4.Length;
            val_4[2] = ", SlotSequence: [";
            if(val_6 != null)
            {
                    val_8 = val_4.Length;
            }
            
            val_4[3] = val_6;
            val_8 = val_4.Length;
            val_4[4] = "] }";
            return (string)+val_4;
        }
    
    }

}
