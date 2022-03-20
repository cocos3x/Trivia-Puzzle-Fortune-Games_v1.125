using UnityEngine;

namespace UnityEngine.UI
{
    internal static class ListPool<T>
    {
        // Fields
        private static readonly UnityEngine.UI.ObjectPool<System.Collections.Generic.List<T>> s_ListPool;
        
        // Methods
        public static System.Collections.Generic.List<T> Get()
        {
            var val_1;
            var val_2;
            var val_3;
            var val_4;
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            val_2 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 302;
            val_3 = __RuntimeMethodHiddenParam + 24;
            if((val_2 & 1) == 0)
            {
                    val_3 = mem[__RuntimeMethodHiddenParam + 24];
                val_3 = __RuntimeMethodHiddenParam + 24;
                val_2 = mem[__RuntimeMethodHiddenParam + 24 + 302];
                val_2 = __RuntimeMethodHiddenParam + 24 + 302;
            }
            
            val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 8;
            if((val_2 & 1) == 0)
            {
                    val_4 = val_4;
            }
        
        }
        public static void Release(System.Collections.Generic.List<T> toRelease)
        {
            var val_1;
            var val_2;
            var val_3;
            var val_4;
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            val_2 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 302;
            val_3 = __RuntimeMethodHiddenParam + 24;
            if((val_2 & 1) == 0)
            {
                    val_3 = mem[__RuntimeMethodHiddenParam + 24];
                val_3 = __RuntimeMethodHiddenParam + 24;
                val_2 = mem[__RuntimeMethodHiddenParam + 24 + 302];
                val_2 = __RuntimeMethodHiddenParam + 24 + 302;
            }
            
            val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 16];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 16;
            if((val_2 & 1) == 0)
            {
                    val_4 = val_4;
            }
        
        }
        private static ListPool<T>()
        {
            var val_1;
            var val_2;
            var val_3;
            var val_4;
            var val_5;
            var val_6;
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 24 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 24 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 24 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 24 + 302;
            }
            
            val_2 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 302;
            val_3 = __RuntimeMethodHiddenParam + 24;
            if((val_2 & 1) == 0)
            {
                    val_3 = mem[__RuntimeMethodHiddenParam + 24];
                val_3 = __RuntimeMethodHiddenParam + 24;
                val_2 = mem[__RuntimeMethodHiddenParam + 24 + 302];
                val_2 = __RuntimeMethodHiddenParam + 24 + 302;
            }
            
            val_4 = val_3;
            if((val_2 & 1) == 0)
            {
                    val_4 = mem[__RuntimeMethodHiddenParam + 24];
                val_4 = __RuntimeMethodHiddenParam + 24;
                val_2 = mem[__RuntimeMethodHiddenParam + 24 + 302];
                val_2 = __RuntimeMethodHiddenParam + 24 + 302;
            }
            
            val_5 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_5 = __RuntimeMethodHiddenParam + 24 + 302;
            val_6 = __RuntimeMethodHiddenParam + 24;
            if((val_5 & 1) == 0)
            {
                    val_6 = mem[__RuntimeMethodHiddenParam + 24];
                val_6 = __RuntimeMethodHiddenParam + 24;
                val_5 = mem[__RuntimeMethodHiddenParam + 24 + 302];
                val_5 = __RuntimeMethodHiddenParam + 24 + 302;
            }
            
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 56;
        }
    
    }

}
