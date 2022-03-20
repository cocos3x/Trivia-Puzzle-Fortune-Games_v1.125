using UnityEngine;

namespace SLC.Minigames.WordJumble
{
    public class WordJumbleDataParser : MonoSingleton<SLC.Minigames.WordJumble.WordJumbleDataParser>
    {
        // Fields
        private UnityEngine.TextAsset wordData;
        private System.Collections.Generic.Dictionary<string, object> availableData;
        private System.Collections.Generic.List<string> usedKeys;
        private System.Collections.Generic.List<string> availableKeys;
        private int maxWithoutRepeat;
        private UnityEngine.TextAsset perLevelDataFile;
        private System.Collections.Generic.Dictionary<string, object> levelData;
        
        // Methods
        public override void InitMonoSingleton()
        {
            var val_8;
            object val_2 = MiniJSON.Json.Deserialize(json:  this.wordData.text);
            if(val_2 != null)
            {
                    this.availableData = val_2;
                this.availableKeys = System.Linq.Enumerable.ToList<System.String>(source:  val_2.Keys);
                object val_6 = MiniJSON.Json.Deserialize(json:  this.perLevelDataFile.text);
                val_8 = 0;
                this.levelData = ;
                return;
            }
            
            this.availableData = 0;
            throw new NullReferenceException();
        }
        public SLC.Minigames.WordJumble.WordJumbleLevel getLevel(int currentLevel)
        {
            var val_9;
            bool val_9 = true;
            int val_1 = UnityEngine.Random.Range(min:  0, max:  currentLevel);
            if(val_9 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_9 = val_9 + (val_1 << 3);
            object val_2 = this.availableData.Item[(true + (val_1) << 3) + 32];
            val_9 = 0;
            this.usedKeys.Add(item:  (true + (val_1) << 3) + 32);
            bool val_4 = this.availableKeys.Remove(item:  (true + (val_1) << 3) + 32);
            if(null > this.maxWithoutRepeat)
            {
                    if(null == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                bool val_5 = this.usedKeys.Remove(item:  System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_byval_arg);
                this.availableKeys.Add(item:  System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_byval_arg);
            }
            
            SLC.Minigames.WordJumble.WordJumbleLevel val_8 = new SLC.Minigames.WordJumble.WordJumbleLevel(name:  (true + (val_1) << 3) + 32, data:  null, levelSpecData:  this.levelData.Item[currentLevel.ToString()]);
            return new SLC.Minigames.WordJumble.WordJumbleLevel() {<category>k__BackingField = val_8.<category>k__BackingField, <levelWords>k__BackingField = val_8.<levelWords>k__BackingField};
        }
        public WordJumbleDataParser()
        {
            this.usedKeys = new System.Collections.Generic.List<System.String>();
            this.availableKeys = new System.Collections.Generic.List<System.String>();
            this.maxWithoutRepeat = 50;
        }
    
    }

}
