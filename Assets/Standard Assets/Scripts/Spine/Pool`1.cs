using UnityEngine;

namespace Spine
{
    public class Pool<T>
    {
        // Fields
        public readonly int max;
        private readonly System.Collections.Generic.Stack<T> freeObjects;
        private int <Peak>k__BackingField;
        
        // Properties
        public int Count { get; }
        public int Peak { get; set; }
        
        // Methods
        public int get_Count()
        {
            if(this != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public int get_Peak()
        {
            return (int)this;
        }
        private void set_Peak(int value)
        {
            mem[1152921510544467040] = value;
        }
        public Pool<T>(int initialCapacity = 16, int max = 2147483647)
        {
            mem[1152921510544579032] = __RuntimeMethodHiddenParam + 24 + 192 + 8;
            mem[1152921510544579024] = max;
        }
        public T Obtain()
        {
            if(this != null)
            {
                    __RuntimeMethodHiddenParam = ???;
            }
        
        }
        public void Free(T obj)
        {
            if(obj == null)
            {
                    throw new System.ArgumentNullException(paramName:  "obj", message:  "obj cannot be null");
            }
            
            if(21578 < (__RuntimeMethodHiddenParam + 24 + 192))
            {
                    int val_1 = System.Math.Max(val1:  1642998144, val2:  __RuntimeMethodHiddenParam + 24 + 192 + 56);
            }
        
        }
        public void Clear()
        {
            if(this != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        protected void Reset(T obj)
        {
            var val_2;
            var val_3;
            val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 88;
            if(X0 == false)
            {
                    return;
            }
            
            var val_3 = X0;
            if((X0 + 294) == 0)
            {
                goto label_3;
            }
            
            var val_1 = X0 + 176;
            var val_2 = 0;
            val_1 = val_1 + 8;
            label_5:
            if(((X0 + 176 + 8) + -8) == (__RuntimeMethodHiddenParam + 24 + 192 + 88))
            {
                goto label_4;
            }
            
            val_2 = val_2 + 1;
            val_1 = val_1 + 16;
            if(val_2 < (X0 + 294))
            {
                goto label_5;
            }
            
            label_3:
            val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 88;
            goto (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(X0, typeof(__RuntimeMethodHiddenParam + 24 + 192 + 88), slot: 0);
            label_4:
            val_3 = val_3 + (((X0 + 176 + 8)) << 4);
            val_3 = val_3 + 304;
            goto (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(X0, typeof(__RuntimeMethodHiddenParam + 24 + 192 + 88), slot: 0);
        }
    
    }

}
