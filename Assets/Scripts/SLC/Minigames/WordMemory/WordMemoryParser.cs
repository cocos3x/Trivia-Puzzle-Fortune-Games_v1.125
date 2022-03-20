using UnityEngine;

namespace SLC.Minigames.WordMemory
{
    public class WordMemoryParser
    {
        // Fields
        public System.Collections.Generic.Dictionary<string, string[]> wordDataSource;
        private SLC.Minigames.WordMemory.WordMemoryLevel[] levelDataSource;
        
        // Methods
        public WordMemoryParser()
        {
            string val_8;
            var val_9;
            var val_19;
            SLC.Minigames.WordMemory.WordMemoryLevel[] val_20;
            var val_21;
            string val_22;
            var val_23;
            this.wordDataSource = new System.Collections.Generic.Dictionary<System.String, System.String[]>();
            object val_4 = MiniJSON.Json.Deserialize(json:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordMemory/word_categories").text);
            Dictionary.Enumerator<TKey, TValue> val_6 = GetEnumerator();
            val_19 = 1152921509851233392;
            val_20 = 1152921517607384688;
            label_19:
            if(val_9.MoveNext() == false)
            {
                goto label_7;
            }
            
            val_21 = 0;
            System.Collections.Generic.List<System.String> val_12 = new System.Collections.Generic.List<System.String>();
            var val_20 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_22 = mem[((val_8 + 200 + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_8 : 0 + 16 + 0) + 32];
            val_22 = ((val_8 + 200 + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_8 : 0 + 16 + 0) + 32;
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_22 = val_12;
            val_12.Add(item:  val_22);
            val_20 = val_20 + 1;
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.wordDataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            this.wordDataSource.Add(key:  val_8, value:  val_12.ToArray());
            goto label_19;
            label_7:
            val_9.Dispose();
            object val_16 = MiniJSON.Json.Deserialize(json:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordMemory/WordMemory_levels").text);
            this.levelDataSource = 31116236;
            if(40189952 < 1)
            {
                    return;
            }
            
            val_19 = 1152921505030008832;
            var val_21 = 4;
            do
            {
                if(0 >= 40189952)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_23 = 0;
                new SLC.Minigames.WordMemory.WordMemoryLevel() = new SLC.Minigames.WordMemory.WordMemoryLevel(dict:  null);
                val_20 = this.levelDataSource;
                val_20[0] = new SLC.Minigames.WordMemory.WordMemoryLevel();
                val_21 = val_21 + 1;
            }
            while((val_21 - 3) < this.levelDataSource.Length);
        
        }
        public SLC.Minigames.WordMemory.WordMemoryLevel GetWordMemoryLevelData(int level)
        {
            return (SLC.Minigames.WordMemory.WordMemoryLevel)this.levelDataSource[level];
        }
    
    }

}
