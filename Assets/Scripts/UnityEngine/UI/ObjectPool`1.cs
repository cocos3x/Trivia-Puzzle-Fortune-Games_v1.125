using UnityEngine;

namespace UnityEngine.UI
{
    internal class ObjectPool<T>
    {
        // Fields
        private readonly System.Collections.Generic.Stack<T> m_Stack;
        private readonly UnityEngine.Events.UnityAction<T> m_ActionOnGet;
        private readonly UnityEngine.Events.UnityAction<T> m_ActionOnRelease;
        private int <countAll>k__BackingField;
        
        // Properties
        public int countAll { get; set; }
        public int countActive { get; }
        public int countInactive { get; }
        
        // Methods
        public int get_countAll()
        {
            return (int)this;
        }
        private void set_countAll(int value)
        {
            mem[1152921520079971704] = value;
        }
        public int get_countActive()
        {
            return (int)0;
        }
        public int get_countInactive()
        {
            if(this != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public ObjectPool<T>(UnityEngine.Events.UnityAction<T> actionOnGet, UnityEngine.Events.UnityAction<T> actionOnRelease)
        {
            mem[1152921520080315872] = __RuntimeMethodHiddenParam + 24 + 192 + 24;
            mem[1152921520080315880] = actionOnGet;
            mem[1152921520080315888] = actionOnRelease;
        }
        public T Get()
        {
            var val_1;
            if(this != null)
            {
                    val_1 = this;
            }
            else
            {
                    val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 40;
            }
            
            if(this == null)
            {
                    return (object)val_1;
            }
            
            return (object)val_1;
        }
        public void Release(T element)
        {
            if((20240 >= 1) && (20240 == element))
            {
                    UnityEngine.Debug.LogError(message:  "Internal error. Trying to destroy object that is already released to pool.");
            }
        
        }
    
    }

}
