using UnityEngine;

namespace WordForest
{
    public class Map
    {
        // Fields
        public System.Collections.Generic.List<System.Collections.Generic.List<WordForest.MapItem>> area;
        
        // Properties
        public bool ContainsDamagedTrees { get; }
        
        // Methods
        public Map(System.Collections.Generic.List<WordForest.MapItem> initialAreaItems)
        {
            System.Collections.Generic.List<System.Collections.Generic.List<WordForest.MapItem>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.List<WordForest.MapItem>>();
            this.area = val_1;
            val_1.Add(item:  initialAreaItems);
        }
        public System.Collections.Generic.List<WordForest.MapItem> GetForestData()
        {
            var val_1;
            if(W9 >= 1)
            {
                    return (System.Collections.Generic.List<WordForest.MapItem>)val_1;
            }
            
            val_1 = 0;
            return (System.Collections.Generic.List<WordForest.MapItem>)val_1;
        }
        public bool get_ContainsDamagedTrees()
        {
            var val_5;
            var val_6;
            var val_7;
            System.Predicate<WordForest.MapItem> val_9;
            val_5 = this;
            System.Collections.Generic.List<WordForest.MapItem> val_1 = this.GetForestData();
            if(val_1 == null)
            {
                    return (bool)val_6;
            }
            
            val_5 = val_1;
            val_7 = null;
            val_7 = null;
            val_9 = Map.<>c.<>9__4_0;
            if(val_9 == null)
            {
                    System.Predicate<WordForest.MapItem> val_2 = null;
                val_9 = val_2;
                val_2 = new System.Predicate<WordForest.MapItem>(object:  Map.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean Map.<>c::<get_ContainsDamagedTrees>b__4_0(WordForest.MapItem n));
                Map.<>c.<>9__4_0 = val_9;
            }
            
            val_6 = ((val_5.FindIndex(match:  val_2)) >> 31) ^ 1;
            return (bool)val_6;
        }
        public int CurrentForestGrowth(bool includeDamagedTrees = True)
        {
            var val_5;
            var val_6;
            bool val_5 = true;
            System.Collections.Generic.List<WordForest.MapItem> val_1 = this.GetForestData();
            if(val_5 >= 1)
            {
                    var val_7 = 0;
                val_5 = 0;
                do
            {
                if(val_5 <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_5 = val_5 + 0;
                var val_6 = (true + 0) + 32;
                if((System.String.op_Inequality(a:  (true + 0) + 32 + 16, b:  "tree")) != true)
            {
                    if(val_6 <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_6 = val_6 + 0;
                val_6 = mem[((true + 0) + 32 + 0) + 32];
                val_6 = ((true + 0) + 32 + 0) + 32;
                if((((true + 0) + 32 + 0) + 32 + 28) != 0)
            {
                    if((((true + 0) + 32 + 0) + 32 + 28) <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_6 = val_6 + 0;
                val_6 = mem[(((true + 0) + 32 + 0) + 32 + 0) + 32];
                val_6 = (((true + 0) + 32 + 0) + 32 + 0) + 32;
            }
            
                var val_3 = (((((true + 0) + 32 + 0) + 32 + 0) + 32 + 28) != 2) ? 1 : 0;
                val_3 = val_3 | includeDamagedTrees;
                bool val_4 = val_3;
                val_5 = val_5 + val_4;
            }
            
            }
            
                val_7 = val_7 + 1;
            }
            while(val_7 < val_4);
            
                return (int)val_5;
            }
            
            val_5 = 0;
            return (int)val_5;
        }
        public System.Collections.Generic.Dictionary<string, object> Encode()
        {
            object val_5;
            System.Collections.Generic.List<System.Object> val_1 = new System.Collections.Generic.List<System.Object>();
            if((this.GetForestData() != null) && (true >= 1))
            {
                    var val_6 = 4;
                do
            {
                if(0 >= true)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_5 = 0;
                if(val_5 != 0)
            {
                    if(0 >= true)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_5 = 0;
            }
            
                val_1.Add(item:  val_5);
            }
            
                val_6 = val_6 + 1;
            }
            while((val_6 - 3) < (mem[-2305843009213693952]));
            
            }
            
            System.Collections.Generic.List<System.Object> val_4 = new System.Collections.Generic.List<System.Object>();
            val_4.Add(item:  val_1);
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_5.Add(key:  "area", value:  val_4);
            return val_5;
        }
    
    }

}
