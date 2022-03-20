using UnityEngine;

namespace SRF
{
    public class Hierarchy
    {
        // Fields
        private static readonly char[] Seperator;
        private static readonly System.Collections.Generic.Dictionary<string, UnityEngine.Transform> Cache;
        
        // Properties
        public UnityEngine.Transform Item { get; }
        
        // Methods
        public UnityEngine.Transform get_Item(string key)
        {
            return SRF.Hierarchy.Get(key:  key);
        }
        public static UnityEngine.Transform Get(string key)
        {
            var val_12;
            var val_13;
            UnityEngine.Transform val_14;
            val_12 = null;
            val_12 = null;
            if((SRF.Hierarchy.Cache.TryGetValue(key:  key, value: out  0)) != true)
            {
                    UnityEngine.GameObject val_3 = UnityEngine.GameObject.Find(name:  key);
                if((UnityEngine.Object.op_Implicit(exists:  val_3)) != false)
            {
                    val_13 = null;
                val_13 = null;
                SRF.Hierarchy.Cache.Add(key:  key, value:  val_3.transform);
            }
            else
            {
                    System.String[] val_6 = key.Split(separator:  SRF.Hierarchy.Seperator, options:  1);
                UnityEngine.Transform val_9 = new UnityEngine.GameObject(name:  System.Linq.Enumerable.Last<System.String>(source:  val_6)).transform;
                SRF.Hierarchy.Cache.Add(key:  key, value:  val_9);
                val_14 = val_9;
                if()
            {
                    return val_14;
            }
            
                val_14.parent = System.String.Join(separator:  "/", value:  val_6, startIndex:  0, count:  val_6.Length - 1);
            }
            
            }
            
            val_14 = val_9;
            return val_14;
        }
        public Hierarchy()
        {
        
        }
        private static Hierarchy()
        {
            char[] val_1 = new char[1];
            val_1[0] = '/';
            SRF.Hierarchy.Seperator = val_1;
            SRF.Hierarchy.Cache = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Transform>();
        }
    
    }

}
