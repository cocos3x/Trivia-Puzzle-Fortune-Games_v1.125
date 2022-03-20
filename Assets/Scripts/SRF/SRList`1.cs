using UnityEngine;

namespace SRF
{
    [Serializable]
    public class SRList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ISerializationCallbackReceiver
    {
        // Fields
        private T[] _buffer;
        private int _count;
        private System.Collections.Generic.EqualityComparer<T> _equalityComparer;
        private System.Collections.ObjectModel.ReadOnlyCollection<T> _readOnlyWrapper;
        
        // Properties
        public T[] Buffer { get; set; }
        private System.Collections.Generic.EqualityComparer<T> EqualityComparer { get; }
        public int Count { get; set; }
        public bool IsReadOnly { get; }
        public T Item { get; set; }
        
        // Methods
        public SRList<T>()
        {
            if(this != null)
            {
                    return;
            }
            
            throw new NullReferenceException();
        }
        public SRList<T>(int capacity)
        {
            if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) == 0)
            {
                
            }
        
        }
        public SRList<T>(System.Collections.Generic.IEnumerable<T> source)
        {
            goto __RuntimeMethodHiddenParam + 24 + 192 + 16;
        }
        public T[] get_Buffer()
        {
            return (T[])this;
        }
        private void set_Buffer(T[] value)
        {
            mem[1152921519441762384] = value;
        }
        private System.Collections.Generic.EqualityComparer<T> get_EqualityComparer()
        {
            var val_1;
            if(this != null)
            {
                    return (System.Collections.Generic.EqualityComparer<T>)val_1;
            }
            
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 24];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 24;
            mem[1152921519441911264] = val_1;
            return (System.Collections.Generic.EqualityComparer<T>)val_1;
        }
        public int get_Count()
        {
            return (int)this;
        }
        private void set_Count(int value)
        {
            mem[1152921519442135256] = value;
        }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            mem2[0] = this;
            return (System.Collections.Generic.IEnumerator<T>)__RuntimeMethodHiddenParam + 24 + 192 + 40;
        }
        private System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if(this != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public void Add(T item)
        {
            if(this != null)
            {
                    if(this != (__RuntimeMethodHiddenParam + 24 + 192 + 64))
            {
                goto label_3;
            }
            
            }
            
            label_3:
            mem[1152921517868417888] = item;
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
        public bool Contains(T item)
        {
            var val_1;
            if(this == null)
            {
                    return (bool)val_1;
            }
            
            if(this < 1)
            {
                goto label_2;
            }
            
            var val_1 = 0;
            label_7:
            if((this & 1) != 0)
            {
                goto label_6;
            }
            
            val_1 = val_1 + 1;
            if(val_1 < (this << ))
            {
                goto label_7;
            }
            
            label_2:
            val_1 = 0;
            return (bool)val_1;
            label_6:
            val_1 = 1;
            return (bool)val_1;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.CopyTo(array:  array, index:  arrayIndex);
        }
        public bool Remove(T item)
        {
            var val_1;
            if(this == null)
            {
                    return (bool)val_1;
            }
            
            if((this & 2147483648) == 0)
            {
                    val_1 = 1;
                return (bool)val_1;
            }
            
            val_1 = 0;
            return (bool)val_1;
        }
        public bool get_IsReadOnly()
        {
            return false;
        }
        public int IndexOf(T item)
        {
            var val_1;
            if((this != null) && (this >= 1))
            {
                    val_1 = 0;
                do
            {
                if((this & 1) != 0)
            {
                    return (int)val_1;
            }
            
                val_1 = val_1 + 1;
            }
            while(val_1 < (this << ));
            
            }
            
            val_1 = 0;
            return (int)val_1;
        }
        public void Insert(int index, T item)
        {
            var val_2;
            var val_3;
            if(this == null)
            {
                goto label_1;
            }
            
            val_2 = this;
            if(val_2 != (__RuntimeMethodHiddenParam + 24 + 192 + 64))
            {
                goto label_3;
            }
            
            label_1:
            label_3:
            if(this > index)
            {
                    val_2 = this;
                if(this > index)
            {
                    long val_3 = 1951604672;
                do
            {
                var val_1 = val_3 - 1;
                val_3 = val_3 - 1;
                mem[1152921527249772256] = 1152921527249772224;
                val_2 = this;
            }
            while(val_3 > (long)index);
            
            }
            
                SRF.SRList<T> val_2 = val_2 + (index << 2);
                mem2[0] = item;
                val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 88];
                val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 88;
            }
            else
            {
                    val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 136];
                val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 136;
            }
        
        }
        public void RemoveAt(int index)
        {
            int val_5 = index;
            if(this == null)
            {
                    return;
            }
            
            if(this <= val_5)
            {
                    return;
            }
            
            SRF.SRList<T> val_1 = this + (val_5 << 3);
            mem2[0] = 0;
            if(this <= val_5)
            {
                    return;
            }
            
            var val_5 = (long)val_5;
            do
            {
                val_5 = this;
                var val_2 = val_5 + 1;
                SRF.SRList<T> val_4 = val_5 + (((long)(int)(index)) << 3);
                val_5 = val_5 + 1;
                mem2[0] = this + (((long)(int)(index)) << 3);
            }
            while(val_5 < (this << ));
        
        }
        public T get_Item(int index)
        {
            if(this == null)
            {
                    throw new System.IndexOutOfRangeException();
            }
            
            SRF.SRList<T> val_1 = this + (index << 3);
            return (SRDebugger.Profiler.ProfilerCameraListener)this;
        }
        public void set_Item(int index, T value)
        {
            if(this == null)
            {
                    throw new System.IndexOutOfRangeException();
            }
            
            SRF.SRList<T> val_1 = this + (index << 2);
            mem2[0] = value;
        }
        public void OnBeforeSerialize()
        {
            object[] val_1 = new object[1];
            val_1[0] = 1152921505054202560;
            UnityEngine.Debug.Log(message:  SRF.SRFStringExtensions.Fmt(formatString:  "[OnBeforeSerialize] Count: {0}", args:  val_1));
        }
        public void OnAfterDeserialize()
        {
            object[] val_1 = new object[1];
            val_1[0] = 1152921505054202560;
            UnityEngine.Debug.Log(message:  SRF.SRFStringExtensions.Fmt(formatString:  "[OnAfterDeserialize] Count: {0}", args:  val_1));
        }
        public void AddRange(System.Collections.Generic.IEnumerable<T> range)
        {
            var val_5;
            var val_6;
            var val_9;
            val_5 = __RuntimeMethodHiddenParam;
            val_6 = range;
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_6 = 0;
            val_6 = val_6 + 1;
            val_6 = val_6;
            label_19:
            var val_7 = 0;
            val_7 = val_7 + 1;
            val_9 = public System.Boolean System.Collections.IEnumerator::MoveNext();
            if(val_6.MoveNext() == false)
            {
                goto label_12;
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_9 = __RuntimeMethodHiddenParam + 24 + 192 + 160;
            if(this == null)
            {
                    throw new NullReferenceException();
            }
            
            goto label_19;
            label_12:
            val_5 = 0;
            if(val_6 != null)
            {
                    var val_9 = 0;
                val_9 = val_9 + 1;
                val_6.Dispose();
            }
            
            if(val_5 != 0)
            {
                    throw val_5;
            }
        
        }
        public void Clear(bool clean)
        {
            if(clean == false)
            {
                    return;
            }
            
            this = ???;
            goto __RuntimeMethodHiddenParam + 24 + 192 + 144;
        }
        public void Clean()
        {
            if(this == null)
            {
                    return;
            }
            
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 72;
            long val_2 = 1952576848;
            do
            {
                if(val_2 >= ((__RuntimeMethodHiddenParam + 24 + 192 + 72 + 24) << ))
            {
                    return;
            }
            
                val_1 = val_1 + 7810307392;
                mem2[0] = 0;
                val_2 = val_2 + 1;
            }
            while(val_1 != 0);
            
            throw new NullReferenceException();
        }
        public System.Collections.ObjectModel.ReadOnlyCollection<T> AsReadOnly()
        {
            var val_1;
            if(X21 != 0)
            {
                    return (System.Collections.ObjectModel.ReadOnlyCollection<T>)val_1;
            }
            
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 176;
            mem[1152921519444437752] = val_1;
            return (System.Collections.ObjectModel.ReadOnlyCollection<T>)val_1;
        }
        private void Expand()
        {
            System.Array val_3;
            var val_4;
            if(this != null)
            {
                    val_3 = __RuntimeMethodHiddenParam + 24 + 192;
                val_4 = UnityEngine.Mathf.Max(a:  UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished << 1, b:  32);
            }
            else
            {
                    val_4 = 32;
                val_3 = __RuntimeMethodHiddenParam + 24 + 192;
            }
            
            if((this != null) && (this >= 1))
            {
                    this.CopyTo(array:  val_3, index:  0);
            }
        
        }
        public void Trim()
        {
            var val_7;
            var val_8;
            var val_9;
            var val_10;
            var val_11;
            val_7 = this;
            if(this >= 1)
            {
                    val_8 = val_7;
                if(val_8 >= (__RuntimeMethodHiddenParam + 24 + 192 + 64))
            {
                    return;
            }
            
                val_9 = __RuntimeMethodHiddenParam + 24 + 192;
                val_10 = mem[__RuntimeMethodHiddenParam + 24 + 192];
                val_10 = __RuntimeMethodHiddenParam + 24 + 192;
                if(val_7 >= 1)
            {
                    var val_9 = 8;
                do
            {
                mem2[0] = val_9 - 8;
                val_9 = val_9 + 1;
                val_10 = mem[__RuntimeMethodHiddenParam + 24 + 192];
                val_10 = __RuntimeMethodHiddenParam + 24 + 192;
            }
            while((val_9 - 7) < (val_7 << ));
            
            }
            
                val_11 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8];
                val_11 = __RuntimeMethodHiddenParam + 24 + 192 + 8;
            }
            else
            {
                    val_9 = mem[__RuntimeMethodHiddenParam + 24 + 192];
                val_9 = __RuntimeMethodHiddenParam + 24 + 192;
                val_11 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8];
                val_11 = __RuntimeMethodHiddenParam + 24 + 192 + 8;
            }
            
            val_7 = ???;
            val_8 = ???;
            goto __RuntimeMethodHiddenParam + 24 + 192 + 8;
        }
        public void Sort(System.Comparison<T> comparer)
        {
            var val_1;
            var val_5 = 1;
            label_17:
            val_1 = 0;
            if(val_5 >= this)
            {
                goto label_1;
            }
            
            var val_1 = val_5 - 1;
            SRF.SRList<T> val_2 = this + (((long)(int)((1 - 1))) << 3);
            if(comparer >= 1)
            {
                    mem[1152921519444794776] = this + (((long)(int)((1 - 1))) << 3);
                SRF.SRList<T> val_4 = this + (((long)(int)((1 - 1))) << 3);
                mem2[0] = val_1;
                val_1 = 1;
            }
            
            val_5 = val_5 + 1;
            goto label_17;
            label_1:
            if((val_1 & 1) != 0)
            {
                goto label_17;
            }
        
        }
    
    }

}
