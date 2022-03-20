using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordBalloonDataManager
    {
        // Fields
        private const string PREFKEY_USED_CATEGORY = "wordballoon_used_cat";
        private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.List<string>>> wordDictionary;
        private static System.Collections.Generic.List<string> previouslyUsedCategories;
        
        // Methods
        private static void Load()
        {
            string val_8;
            var val_9;
            var val_17;
            var val_18;
            string val_19;
            string val_20;
            var val_21;
            var val_22;
            object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordBalloons/word_categories").text);
            System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Collections.Generic.List<System.String>>> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Collections.Generic.List<System.String>>>();
            val_17 = null;
            val_17 = null;
            SLC.Minigames.WordBalloon.WordBalloonDataManager.wordDictionary = val_4;
            Dictionary.Enumerator<TKey, TValue> val_6 = GetEnumerator();
            label_29:
            if(val_9.MoveNext() == false)
            {
                goto label_9;
            }
            
            val_18 = 0;
            System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_12 = null;
            val_20 = public System.Void System.Collections.Generic.List<System.Collections.Generic.List<System.String>>::.ctor();
            val_12 = new System.Collections.Generic.List<System.Collections.Generic.List<System.String>>();
            var val_18 = 0;
            System.Collections.Generic.List<System.String> val_13 = null;
            val_20 = public System.Void System.Collections.Generic.List<System.String>::.ctor();
            val_13 = new System.Collections.Generic.List<System.String>();
            val_19 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_17 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_19 = mem[(((val_8 + 200 + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_8 : 0 + 16 + 0) + 32 + 16 + 0) + 32];
            val_19 = (((val_8 + 200 + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_8 : 0 + 16 + 0) + 32 + 16 + 0) + 32;
            val_20 = val_19;
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19 = val_13;
            val_13.Add(item:  val_20);
            val_17 = val_17 + 1;
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_20 = val_13;
            val_12.Add(item:  val_13);
            val_18 = val_18 + 1;
            val_21 = null;
            val_21 = null;
            val_19 = SLC.Minigames.WordBalloon.WordBalloonDataManager.wordDictionary;
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_4.Add(key:  val_8, value:  val_12);
            goto label_29;
            label_9:
            val_9.Dispose();
            val_22 = null;
            val_22 = null;
            SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories = new System.Collections.Generic.List<System.String>();
            SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories = System.Linq.Enumerable.ToList<System.String>(source:  PlayerPrefsX.GetStringArray(key:  "wordballoon_used_cat"));
        }
        public static SLC.Minigames.WordBalloon.WordBalloonWordData GetWords(int amountToGet, bool storeHistory = True)
        {
            var val_15;
            var val_16;
            var val_17;
            System.Collections.Generic.IEnumerable<TSource> val_18;
            var val_19;
            bool val_20;
            string val_21;
            System.Collections.Generic.List<System.String> val_22;
            var val_23;
            val_15 = null;
            val_15 = null;
            if(SLC.Minigames.WordBalloon.WordBalloonDataManager.wordDictionary == null)
            {
                    SLC.Minigames.WordBalloon.WordBalloonDataManager.Load();
                val_15 = null;
            }
            
            val_15 = null;
            System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Collections.Generic.List<System.String>>> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Collections.Generic.List<System.String>>>(dictionary:  SLC.Minigames.WordBalloon.WordBalloonDataManager.wordDictionary);
            val_16 = 0;
            goto label_8;
            label_17:
            if(val_16 >= (SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories + 24))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_15 = SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories + 16;
            val_15 = val_15 + 0;
            bool val_2 = val_1.Remove(key:  (SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories + 16 + 0) + 32);
            val_16 = 1;
            label_8:
            val_17 = null;
            val_17 = null;
            if(val_16 < (SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories + 24))
            {
                goto label_17;
            }
            
            val_18 = val_1.Keys;
            string val_6 = System.Linq.Enumerable.ElementAt<System.String>(source:  val_18, index:  UnityEngine.Random.Range(min:  0, max:  val_1.Count));
            System.Collections.Generic.List<System.String> val_8 = null;
            var val_16 = 1152921509851217984;
            val_8 = new System.Collections.Generic.List<System.String>();
            if(amountToGet >= 1)
            {
                    val_18 = 1152921515438576048;
                var val_18 = 0;
                do
            {
                int val_9 = UnityEngine.Random.Range(min:  0, max:  949403712);
                if(val_16 <= val_9)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_16 = val_16 + (val_9 << 3);
                int val_10 = UnityEngine.Random.Range(min:  0, max:  (1152921509851217984 + (val_9) << 3) + 32 + 24);
                if(((1152921509851217984 + (val_9) << 3) + 32 + 24) <= val_10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_17 = (1152921509851217984 + (val_9) << 3) + 32 + 16;
                val_17 = val_17 + (val_10 << 3);
                val_8.Add(item:  ((1152921509851217984 + (val_9) << 3) + 32 + 16 + (val_10) << 3) + 32);
                (1152921509851217984 + (val_9) << 3) + 32.RemoveAt(index:  val_10);
                if(((1152921509851217984 + (val_9) << 3) + 32 + 24) <= 0)
            {
                    val_1.Item[val_6].RemoveAt(index:  val_9);
            }
            
                val_18 = val_18 + 1;
            }
            while(val_18 < amountToGet);
            
            }
            
            val_19 = null;
            val_20 = storeHistory;
            val_21 = val_6;
            SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories.Add(item:  null);
            val_22 = SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories;
            if((SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories + 24) >= 51)
            {
                    val_22 = SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories;
                val_22.RemoveRange(index:  0, count:  (SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories + 24) - 50);
            }
            
            if( == false)
            {
                    return (SLC.Minigames.WordBalloon.WordBalloonWordData)new SLC.Minigames.WordBalloon.WordBalloonWordData(_category:  null, _requiredWords:  val_8);
            }
            
            val_23 = null;
            val_23 = null;
            bool val_13 = PlayerPrefsX.SetStringArray(key:  "wordballoon_used_cat", stringArray:  SLC.Minigames.WordBalloon.WordBalloonDataManager.previouslyUsedCategories.ToArray());
            return (SLC.Minigames.WordBalloon.WordBalloonWordData)new SLC.Minigames.WordBalloon.WordBalloonWordData(_category:  null, _requiredWords:  val_8);
        }
        public WordBalloonDataManager()
        {
        
        }
        private static WordBalloonDataManager()
        {
        
        }
    
    }

}
