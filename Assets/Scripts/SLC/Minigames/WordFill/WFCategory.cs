using UnityEngine;

namespace SLC.Minigames.WordFill
{
    public class WFCategory
    {
        // Fields
        public string name;
        public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> words;
        
        // Methods
        public WFCategory(System.Collections.Generic.List<object> data)
        {
            System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_5;
            if(true == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.name = 0;
            System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_1 = null;
            val_5 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>();
            this.words = val_5;
            if(1152921516027727200 < 2)
            {
                    return;
            }
            
            do
            {
                if(1152921516027727200 <= 1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                char[] val_2 = new char[1];
                val_2[0] = '-';
                System.Collections.Generic.List<System.String> val_4 = null;
                val_5 = val_4;
                val_4 = new System.Collections.Generic.List<System.String>(collection:  Split(separator:  val_2));
                this.words.Add(key:  1 + 2, value:  val_4);
                var val_7 = 5 + 1;
            }
            while((1 + 1) < null);
        
        }
    
    }

}
