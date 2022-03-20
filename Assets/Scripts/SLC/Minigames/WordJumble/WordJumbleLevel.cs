using UnityEngine;

namespace SLC.Minigames.WordJumble
{
    public struct WordJumbleLevel
    {
        // Fields
        private string <category>k__BackingField;
        private System.Collections.Generic.List<string> <levelWords>k__BackingField;
        
        // Properties
        public string category { get; set; }
        public System.Collections.Generic.List<string> levelWords { get; set; }
        
        // Methods
        public string get_category()
        {
            return (string)new SLC.Minigames.WordJumble.WordJumbleLevel();
        }
        private void set_category(string value)
        {
            this = value;
        }
        public System.Collections.Generic.List<string> get_levelWords()
        {
            return (System.Collections.Generic.List<System.String>)this.<levelWords>k__BackingField;
        }
        private void set_levelWords(System.Collections.Generic.List<string> value)
        {
            this.<levelWords>k__BackingField = value;
        }
        public WordJumbleLevel(string name, System.Collections.Generic.Dictionary<string, object> data, object levelSpecData)
        {
            var val_17;
            var val_18;
            string val_19;
            this = name;
            this.<levelWords>k__BackingField = new System.Collections.Generic.List<System.String>();
            System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>();
            val_17 = 1152921510214912464;
            val_18 = 1152921517236766080;
            do
            {
                if((data.ContainsKey(key:  3.ToString())) != false)
            {
                    val_19 = 3.ToString();
                char[] val_8 = new char[1];
                val_8[0] = '-';
                val_2.Add(key:  val_19, value:  System.Linq.Enumerable.ToList<System.String>(source:  data.Item[3.ToString()].Split(separator:  val_8)));
            }
            
                var val_17 = 3;
                val_17 = val_17 + 1;
            }
            while(val_17 < 8);
            
            char[] val_12 = new char[1];
            val_12[0] = '-';
            System.Collections.Generic.List<TSource> val_14 = System.Linq.Enumerable.ToList<System.String>(source:  levelSpecData.Item["WordLength"].Split(separator:  val_12));
            if(1152921510375394352 < 1)
            {
                    return;
            }
            
            val_17 = 1152921509851232320;
            do
            {
                if(0 >= 1152921510375394352)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_18 = 44451696;
                System.Collections.Generic.List<System.String> val_15 = val_2.Item[null];
                val_19 = this.<levelWords>k__BackingField;
                int val_16 = UnityEngine.Random.Range(min:  0, max:  78753792);
                if(val_18 <= val_16)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_18 = val_18 + (val_16 << 3);
                val_19.Add(item:  (44451696 + (val_16) << 3) + 32);
                val_18 = 0 + 1;
            }
            while(val_18 < val_18);
        
        }
    
    }

}
