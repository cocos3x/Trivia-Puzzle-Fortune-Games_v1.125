using UnityEngine;

namespace SLC.Minigames.Bubbles
{
    public class WordBubblesLevel
    {
        // Fields
        private System.Collections.Generic.HashSet<string> <RequiredWords>k__BackingField;
        private System.Collections.Generic.List<string> <Elements>k__BackingField;
        private string <Category>k__BackingField;
        private SLC.Minigames.Bubbles.WordBubblesLevelData <LevelData>k__BackingField;
        
        // Properties
        public System.Collections.Generic.HashSet<string> RequiredWords { get; set; }
        public System.Collections.Generic.List<string> Elements { get; set; }
        public string Category { get; set; }
        public SLC.Minigames.Bubbles.WordBubblesLevelData LevelData { get; set; }
        
        // Methods
        public System.Collections.Generic.HashSet<string> get_RequiredWords()
        {
            return (System.Collections.Generic.HashSet<System.String>)this.<RequiredWords>k__BackingField;
        }
        private void set_RequiredWords(System.Collections.Generic.HashSet<string> value)
        {
            this.<RequiredWords>k__BackingField = value;
        }
        public System.Collections.Generic.List<string> get_Elements()
        {
            return (System.Collections.Generic.List<System.String>)this.<Elements>k__BackingField;
        }
        private void set_Elements(System.Collections.Generic.List<string> value)
        {
            this.<Elements>k__BackingField = value;
        }
        public string get_Category()
        {
            return (string)this.<Category>k__BackingField;
        }
        private void set_Category(string value)
        {
            this.<Category>k__BackingField = value;
        }
        public SLC.Minigames.Bubbles.WordBubblesLevelData get_LevelData()
        {
            return (SLC.Minigames.Bubbles.WordBubblesLevelData)this.<LevelData>k__BackingField;
        }
        private void set_LevelData(SLC.Minigames.Bubbles.WordBubblesLevelData value)
        {
            this.<LevelData>k__BackingField = value;
        }
        public bool IsQulify(string word)
        {
            var val_3;
            if((this.<RequiredWords>k__BackingField.Contains(item:  word)) != false)
            {
                    bool val_2 = this.<RequiredWords>k__BackingField.Remove(item:  word);
                val_3 = 1;
                return (bool)val_3;
            }
            
            val_3 = 0;
            return (bool)val_3;
        }
        public bool IsComplete()
        {
            return (bool)((this.<RequiredWords>k__BackingField) == 0) ? 1 : 0;
        }
        public WordBubblesLevel(SLC.Minigames.Bubbles.WordBubblesLevelData levelData, string[] words)
        {
            SLC.Minigames.Bubbles.WordBubblesLevelData val_6;
            string val_7;
            val_6 = levelData;
            this.<RequiredWords>k__BackingField = new System.Collections.Generic.HashSet<System.String>();
            this.<Elements>k__BackingField = new System.Collections.Generic.List<System.String>();
            this.<LevelData>k__BackingField = val_6;
            int val_6 = words.Length;
            if(val_6 < 1)
            {
                goto label_2;
            }
            
            var val_7 = 0;
            val_6 = val_6 & 4294967295;
            label_12:
            bool val_3 = this.<RequiredWords>k__BackingField.Add(item:  1152921505059157200);
            if((System.String.op_Equality(a:  1152921505059157200, b:  "GREEN")) == false)
            {
                goto label_5;
            }
            
            this.<Elements>k__BackingField.Add(item:  "GR");
            val_7 = "EEN";
            goto label_8;
            label_5:
            if((System.String.op_Equality(a:  1152921505059157200, b:  "BLUE")) == false)
            {
                goto label_9;
            }
            
            this.<Elements>k__BackingField.Add(item:  "BL");
            val_7 = "UE";
            label_8:
            this.<Elements>k__BackingField.Add(item:  val_7);
            label_9:
            val_7 = val_7 + 1;
            if(val_7 < (words.Length << ))
            {
                goto label_12;
            }
            
            label_2:
            this.<Category>k__BackingField = "color";
        }
        public WordBubblesLevel(SLC.Minigames.Bubbles.WordBubblesLevelData levelData, SLC.Minigames.Bubbles.WordBubblesCategory category)
        {
            SLC.Minigames.Bubbles.WordBubblesLevelData val_31;
            var val_32;
            var val_33;
            var val_34;
            val_31 = levelData;
            val_1 = new System.Object();
            this.<RequiredWords>k__BackingField = new System.Collections.Generic.HashSet<System.String>();
            System.Collections.Generic.List<System.String> val_3 = null;
            var val_31 = 1152921509851217984;
            val_3 = new System.Collections.Generic.List<System.String>();
            this.<Elements>k__BackingField = val_3;
            this.<LevelData>k__BackingField = val_31;
            if((levelData.<FragmentsCount>k__BackingField) < 1)
            {
                goto label_2;
            }
            
            val_32 = 1152921519842361936;
            val_33 = 1152921515719925760;
            goto label_36;
            label_22:
            val_32 = 1152921516018472640;
            goto label_13;
            label_36:
            if((levelData.<FragmentsCount>k__BackingField) != 1)
            {
                goto label_5;
            }
            
            do
            {
                System.Collections.Generic.List<System.String> val_4 = category.<LetterWordsDic>k__BackingField.Item[3];
                int val_5 = UnityEngine.Random.Range(min:  0, max:  3);
                if(val_31 <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_31 = val_31 + (val_5 << 3);
                val_31 = mem[(1152921509851217984 + (val_5) << 3) + 32];
                val_31 = (1152921509851217984 + (val_5) << 3) + 32;
            }
            while((this.<RequiredWords>k__BackingField.Contains(item:  val_31)) == true);
            
            this.<Elements>k__BackingField.Insert(index:  UnityEngine.Random.Range(min:  0, max:  val_31), item:  val_31);
            val_34 = 0;
            goto label_13;
            label_5:
            if((levelData.<FragmentsCount>k__BackingField) <= 1)
            {
                goto label_14;
            }
            
            do
            {
                int val_9 = UnityEngine.Random.Range(min:  3, max:  9);
                System.Collections.Generic.List<System.String> val_10 = category.<LetterWordsDic>k__BackingField.Item[val_9];
                int val_11 = UnityEngine.Random.Range(min:  0, max:  val_9);
                if(val_31 <= val_11)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_31 = val_31 + (val_11 << 3);
                val_31 = mem[(1152921509851217984 + (val_11) << 3) + 32];
                val_31 = (1152921509851217984 + (val_11) << 3) + 32;
            }
            while((this.<RequiredWords>k__BackingField.Contains(item:  val_31)) == true);
            
            if(((1152921509851217984 + (val_11) << 3) + 32 + 16) < 1)
            {
                goto label_22;
            }
            
            var val_33 = 0;
            do
            {
                var val_32 = (1152921509851217984 + (val_11) << 3) + 32 + 16;
                val_32 = val_32 - val_33;
                int val_14 = (val_32 > 2) ? UnityEngine.Random.Range(min:  2, max:  4) : (val_32);
                this.<Elements>k__BackingField.Insert(index:  UnityEngine.Random.Range(min:  0, max:  4), item:  val_31.Substring(startIndex:  0, length:  val_14));
                var val_34 = (1152921509851217984 + (val_11) << 3) + 32 + 16;
                val_33 = val_14 + val_33;
                val_34 = (levelData.<FragmentsCount>k__BackingField) - 1;
                val_34 = val_34 - val_33;
            }
            while(val_34 >= 1);
            
            val_32 = val_32;
            goto label_25;
            label_14:
            do
            {
                int val_17 = UnityEngine.Random.Range(min:  4, max:  6);
                System.Collections.Generic.List<System.String> val_18 = category.<LetterWordsDic>k__BackingField.Item[val_17];
                int val_19 = UnityEngine.Random.Range(min:  0, max:  val_17);
                if(val_31 <= val_19)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_31 = val_31 + (val_19 << 3);
                val_31 = mem[(1152921509851217984 + (val_19) << 3) + 32];
                val_31 = (1152921509851217984 + (val_19) << 3) + 32;
            }
            while((this.<RequiredWords>k__BackingField.Contains(item:  val_31)) == true);
            
            int val_21 = UnityEngine.Random.Range(min:  0, max:  val_31);
            this.<Elements>k__BackingField.Insert(index:  val_21, item:  val_31.Substring(startIndex:  0, length:  ((((1152921509851217984 + (val_19) << 3) + 32 + 16) < 0) ? (((1152921509851217984 + (val_19) << 3) + 32 + 16) + 1) : ((1152921509851217984 + (val_19) << 3) + 32 + 16)) >> 1));
            var val_26 = (((1152921509851217984 + (val_19) << 3) + 32 + 16) < 0) ? (((1152921509851217984 + (val_19) << 3) + 32 + 16) + 1) : ((1152921509851217984 + (val_19) << 3) + 32 + 16);
            this.<Elements>k__BackingField.Insert(index:  UnityEngine.Random.Range(min:  0, max:  val_21), item:  val_31.Substring(startIndex:  val_26 >> 1, length:  ((1152921509851217984 + (val_19) << 3) + 32 + 16) - (val_26 >> 1)));
            val_34 = (levelData.<FragmentsCount>k__BackingField) - 2;
            label_25:
            val_33 = 1152921515719925760;
            label_13:
            bool val_30 = this.<RequiredWords>k__BackingField.Add(item:  val_31);
            if(val_34 > 0)
            {
                goto label_36;
            }
            
            label_2:
            this.<Category>k__BackingField = category.<Category>k__BackingField;
        }
    
    }

}
