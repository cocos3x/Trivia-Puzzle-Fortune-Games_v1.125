using UnityEngine;

namespace SLC.Minigames.WordMemory
{
    public class WordMemoryLevel
    {
        // Fields
        public int level;
        public int lives;
        public int pairs;
        
        // Methods
        public WordMemoryLevel(System.Collections.Generic.Dictionary<string, object> dict)
        {
            this.level = System.Int32.Parse(s:  dict.Item["Level"]);
            this.lives = System.Int32.Parse(s:  dict.Item["Lives"]);
            this.pairs = System.Int32.Parse(s:  dict.Item["Pairs"]);
        }
    
    }

}
