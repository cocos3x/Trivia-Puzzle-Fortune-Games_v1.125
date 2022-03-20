using UnityEngine;

namespace SLC.Minigames.Just2Emojis
{
    public class J2ELevel
    {
        // Fields
        private int levelIndex;
        private System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Emoji> emojis;
        private System.Collections.Generic.List<char> lettersSet;
        private string answer;
        
        // Properties
        public System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Emoji> Emojis { get; }
        public System.Collections.Generic.List<char> LettersSet { get; }
        public string Answer { get; }
        public string StrippedAnswer { get; }
        
        // Methods
        public System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Emoji> get_Emojis()
        {
            return (System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Emoji>)this.emojis;
        }
        public System.Collections.Generic.List<char> get_LettersSet()
        {
            return (System.Collections.Generic.List<System.Char>)this.lettersSet;
        }
        public string get_Answer()
        {
            return (string)this.answer;
        }
        public string get_StrippedAnswer()
        {
            return this.answer.Replace(oldValue:  " ", newValue:  "");
        }
        public J2ELevel(int index, System.Collections.Generic.List<object> emojiSet, string answer)
        {
            string val_5;
            var val_6;
            string val_12;
            val_1 = new System.Object();
            this.levelIndex = index;
            string val_2 = answer.ToUpper();
            this.emojis = new System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Emoji>();
            List.Enumerator<T> val_4 = val_1.GetEnumerator();
            label_6:
            if(val_6.MoveNext() == false)
            {
                goto label_3;
            }
            
            val_12 = val_5;
            if(val_12 == 0)
            {
                    throw new NullReferenceException();
            }
            
            .myName = val_12;
            if(this.emojis == null)
            {
                    throw new NullReferenceException();
            }
            
            this.emojis.Add(item:  new SLC.Minigames.Just2Emojis.Emoji());
            goto label_6;
            label_3:
            val_6.Dispose();
            this.lettersSet = new System.Collections.Generic.List<System.Char>();
            int val_11 = val_10.Length;
            if(val_11 >= 1)
            {
                    var val_12 = 0;
                val_11 = val_11 & 4294967295;
                do
            {
                if(null != 32)
            {
                    this.lettersSet.Add(item:  '뷰');
            }
            
                val_12 = val_12 + 1;
            }
            while(val_12 < (val_10.Length << ));
            
            }
            
            PluginExtension.Shuffle<System.Char>(list:  this.lettersSet, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            this.answer = val_2;
        }
        public static int GetNumberOfLettersForIndex(int index)
        {
            if(index < 26)
            {
                    return 8;
            }
            
            if(index < 76)
            {
                    return 10;
            }
            
            if(index < 126)
            {
                    return 12;
            }
            
            if(index < 201)
            {
                    return 14;
            }
            
            if(index >= 301)
            {
                    return (int)(index < 401) ? 18 : 21;
            }
            
            return 16;
        }
        public static int GetNumberOfTilesForLetters(int number)
        {
            if(number < 9)
            {
                    return 8;
            }
            
            if(number < 11)
            {
                    return 10;
            }
            
            if(number < 13)
            {
                    return 12;
            }
            
            if(number < 15)
            {
                    return 14;
            }
            
            if(number >= 17)
            {
                    return (int)(number < 19) ? 18 : 21;
            }
            
            return 16;
        }
        public override string ToString()
        {
            int val_5;
            object[] val_1 = new object[4];
            val_5 = val_1.Length;
            val_1[0] = this.levelIndex;
            if(this.answer != null)
            {
                    val_5 = val_1.Length;
            }
            
            val_1[1] = this.answer;
            val_1[2] = MiniJSON.Json.Serialize(obj:  this.lettersSet);
            val_1[3] = MiniJSON.Json.Serialize(obj:  this.emojis);
            return (string)System.String.Format(format:  "Level index: {0}, Answer: {1}, Letterblocks: {2}, Emojis: {3}", args:  val_1);
        }
    
    }

}
