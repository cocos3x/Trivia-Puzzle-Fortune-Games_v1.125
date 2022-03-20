using UnityEngine;

namespace SLC.Minigames.Whack
{
    public class WhackDataParser
    {
        // Fields
        private static bool initialized;
        private static System.Collections.Generic.List<SLC.Minigames.Whack.WhackLevel> levels;
        
        // Methods
        public static void Initialize()
        {
            object val_8;
            var val_9;
            var val_16;
            var val_17;
            var val_18;
            object val_19;
            var val_20;
            SLC.Minigames.Whack.WhackLevel val_21;
            var val_22;
            var val_23;
            val_17 = null;
            val_17 = null;
            if(SLC.Minigames.Whack.WhackDataParser.initialized == true)
            {
                    return;
            }
            
            UnityEngine.Object val_1 = UnityEngine.Resources.Load(path:  "minigames/whack/levels");
            object val_4 = MiniJSON.Json.Deserialize(json:  text);
            val_16 = 0;
            System.Collections.Generic.List<SLC.Minigames.Whack.WhackLevel> val_6 = new System.Collections.Generic.List<SLC.Minigames.Whack.WhackLevel>();
            val_18 = null;
            val_18 = null;
            SLC.Minigames.Whack.WhackDataParser.levels = val_6;
            List.Enumerator<T> val_7 = GetEnumerator();
            label_26:
            if(val_9.MoveNext() == false)
            {
                goto label_15;
            }
            
            if(val_8 != 0)
            {
                    val_19 = null;
            }
            
            val_20 = null;
            val_20 = null;
            val_21 = ;
            val_19 = val_8;
            if(val_8 == 0)
            {
                    throw new NullReferenceException();
            }
            
            object val_12 = val_8.Item["words"];
            val_22 = 0;
            val_21 = new SLC.Minigames.Whack.WhackLevel();
            val_19 = val_21.IndexOf(item:  val_19);
            val_21 = new SLC.Minigames.Whack.WhackLevel(index:  val_19, words:  null);
            if(SLC.Minigames.Whack.WhackDataParser.levels == null)
            {
                    throw new NullReferenceException();
            }
            
            val_6.Add(item:  new SLC.Minigames.Whack.WhackLevel());
            goto label_26;
            label_15:
            val_9.Dispose();
            val_23 = null;
            val_23 = null;
            SLC.Minigames.Whack.WhackDataParser.initialized = true;
        }
        public static SLC.Minigames.Whack.WhackLevel GetWhackLevel()
        {
            var val_2 = null;
            if((SLC.Minigames.Whack.WhackDataParser.levels + 24) == 0)
            {
                    SLC.Minigames.Whack.WhackDataParser.initialized = false;
                SLC.Minigames.Whack.WhackDataParser.Initialize();
                val_2 = null;
            }
            
            val_2 = null;
            int val_1 = UnityEngine.Random.Range(min:  0, max:  SLC.Minigames.Whack.WhackDataParser.levels + 24);
            if((SLC.Minigames.Whack.WhackDataParser.levels + 24) <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_2 = SLC.Minigames.Whack.WhackDataParser.levels + 16;
            val_2 = val_2 + (val_1 << 3);
            SLC.Minigames.Whack.WhackDataParser.levels.RemoveAt(index:  val_1);
            return (SLC.Minigames.Whack.WhackLevel)(SLC.Minigames.Whack.WhackDataParser.levels + 16 + (val_1) << 3) + 32;
        }
        public WhackDataParser()
        {
        
        }
        private static WhackDataParser()
        {
        
        }
    
    }

}
