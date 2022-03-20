using UnityEngine;

namespace SRDebugger
{
    public class CircularBuffer<T> : IEnumerable<T>, IEnumerable, IReadOnlyList<T>
    {
        // Fields
        private readonly T[] _buffer;
        private int _end;
        private int _count;
        private int _start;
        
        // Properties
        public int Capacity { get; }
        public bool IsFull { get; }
        public bool IsEmpty { get; }
        public int Count { get; }
        public T Item { get; set; }
        
        // Methods
        public CircularBuffer<T>(int capacity)
        {
            if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) == 0)
            {
                
            }
        
        }
        public CircularBuffer<T>(int capacity, T[] items)
        {
            string val_5;
            string val_6;
            var val_7;
            if(capacity <= 0)
            {
                goto label_2;
            }
            
            if(items == null)
            {
                goto label_3;
            }
            
            if(items.Length > capacity)
            {
                goto label_4;
            }
            
            mem[1152921519492354608] = __RuntimeMethodHiddenParam + 24 + 192;
            System.Array.Copy(sourceArray:  items, destinationArray:  __RuntimeMethodHiddenParam + 24 + 192, length:  items.Length);
            mem[1152921519492354620] = items.Length;
            mem[1152921519492354624] = 0;
            mem[1152921519492354616] = (items.Length == capacity) ? 0 : items.Length;
            return;
            label_2:
            val_5 = "Circular buffer cannot have negative or zero capacity.";
            val_6 = "capacity";
            goto label_6;
            label_3:
            System.ArgumentNullException val_2 = null;
            val_7 = val_2;
            val_2 = new System.ArgumentNullException(paramName:  "items");
            throw val_7 = val_3;
            label_4:
            System.ArgumentException val_3 = null;
            val_5 = "Too many items to fit circular buffer";
            val_6 = "items";
            label_6:
            val_3 = new System.ArgumentException(message:  val_5, paramName:  val_6);
            throw val_7;
        }
        public int get_Capacity()
        {
            if(X8 != 0)
            {
                    return (int)X8 + 24;
            }
            
            throw new NullReferenceException();
        }
        public bool get_IsFull()
        {
            return (bool)(this == this) ? 1 : 0;
        }
        public bool get_IsEmpty()
        {
            return (bool)(this == 0) ? 1 : 0;
        }
        public int get_Count()
        {
            return (int)this;
        }
        public T get_Item(int index)
        {
            if((this & 1) == 0)
            {
                    if((__RuntimeMethodHiddenParam + 24 + 192 + 32) <= index)
            {
                    throw new System.IndexOutOfRangeException(message:  System.String.Format(format:  "Cannot access index {0}. Buffer size is {1}", arg0:  index, arg1:  __RuntimeMethodHiddenParam + 24 + 192 + 32));
            }
            
                var val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 40;
                val_4 = val_4 + (-1169910016);
                return (SRDebugger.Services.ConsoleEntry)(__RuntimeMethodHiddenParam + 24 + 192 + 40 + -1169910016) + 32;
            }
            
            string val_1 = System.String.Format(format:  "Cannot access index {0}. Buffer is empty", arg0:  ???);
            throw new System.IndexOutOfRangeException(message:  System.String.Format(format:  "Cannot access index {0}. Buffer size is {1}", arg0:  index, arg1:  __RuntimeMethodHiddenParam + 24 + 192 + 32));
        }
        public void set_Item(int index, T value)
        {
            if((this & 1) == 0)
            {
                    if((value.UpdateTime + 192 + 32) <= index)
            {
                    throw new System.IndexOutOfRangeException(message:  System.String.Format(format:  "Cannot access index {0}. Buffer size is {1}", arg0:  index, arg1:  value.UpdateTime + 192 + 32));
            }
            
                var val_4 = value.UpdateTime + 192 + 40;
                val_4 = val_4 + 64045156352;
                mem2[0] = V0.16B;
                mem2[0] = V1.16B;
                mem2[0] = V2.16B;
                mem2[0] = V3.16B;
                return;
            }
            
            string val_1 = System.String.Format(format:  "Cannot access index {0}. Buffer is empty", arg0:  ???);
            throw new System.IndexOutOfRangeException(message:  System.String.Format(format:  "Cannot access index {0}. Buffer size is {1}", arg0:  index, arg1:  value.UpdateTime + 192 + 32));
        }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            mem2[0] = this;
            return (System.Collections.Generic.IEnumerator<T>)__RuntimeMethodHiddenParam + 24 + 192 + 48;
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
        public T Front()
        {
            string val_1 = "Cannot access an empty buffer.";
            val_1 = val_1 + ((__RuntimeMethodHiddenParam + 24 + 192 + 72) << 3);
            return (SRDebugger.Services.ConsoleEntry)("Cannot access an empty buffer." + (__RuntimeMethodHiddenParam + 24 + 192 + 72) << 3) + 32;
        }
        public T Back()
        {
            SRDebugger.Services.ProfilerFrame val_0;
            string val_2 = "Cannot access an empty buffer.";
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 72;
            val_1 = val_1 - 1;
            val_2 = val_2 + (((long)(int)((__RuntimeMethodHiddenParam + 24 + 192 + 72 - 1))) << 5);
            return val_0;
        }
        public void PushBack(T item)
        {
            var val_1 = X9 + ((__RuntimeMethodHiddenParam + 24 + 192 + 80) << 3);
            mem2[0] = item;
            var val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 88;
            if((this & 1) != 0)
            {
                    mem[1152921519493761920] = val_2;
                return;
            }
            
            val_2 = val_2 + 1;
            mem[1152921519493761916] = val_2;
        }
        public void PushFront(T item)
        {
            var val_2 = item.UpdateTime + 192 + 96;
            if((this & 1) != 0)
            {
                    mem[1152921519493882056] = val_2;
                var val_1 = X9 + ((item.UpdateTime + 192 + 96) << 5);
                mem2[0] = V0.16B;
                mem2[0] = V1.16B;
                mem2[0] = V2.16B;
                mem2[0] = V3.16B;
                return;
            }
            
            val_2 = val_2 + ((X9) << 5);
            mem2[0] = V0.16B;
            mem2[0] = V1.16B;
            mem2[0] = V2.16B;
            mem2[0] = V3.16B;
            val_2 = val_2 + 1;
            mem[1152921519493882060] = val_2;
        }
        public void PopBack()
        {
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 96;
            val_1 = val_1 + ((__RuntimeMethodHiddenParam + 24 + 192 + 72) << 5);
            mem2[0] = 0;
            mem2[0] = 0;
            val_1 = val_1 - 1;
            mem[1152921519493998268] = val_1;
        }
        public void PopFront()
        {
            var val_1 = (__RuntimeMethodHiddenParam + 24 + 192 + 72) + 355011072;
            mem2[0] = 0;
            var val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 88;
            val_2 = val_2 - 1;
            mem[1152921519494110268] = val_2;
        }
        public T[] ToArray()
        {
            SRDebugger.CircularBuffer<T> val_2 = this;
            mem2[0] = val_2;
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 112;
            var val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 104 + 24;
            mem2[0] = val_2;
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 120;
            if(val_2 < 1)
            {
                    return (T[])__RuntimeMethodHiddenParam + 24 + 192;
            }
            
            var val_3 = 0;
            val_2 = val_2 & 4294967295;
            do
            {
                System.Array.Copy(sourceArray:  (__RuntimeMethodHiddenParam + 24 + 192 + 104 + 40) + -8, sourceIndex:  (__RuntimeMethodHiddenParam + 24 + 192 + 104) + 40, destinationArray:  __RuntimeMethodHiddenParam + 24 + 192, destinationIndex:  0, length:  (__RuntimeMethodHiddenParam + 24 + 192 + 104 + 40) + 4);
                val_3 = val_3 + 1;
                val_2 = 0 + ((__RuntimeMethodHiddenParam + 24 + 192 + 104 + 40) + 4);
            }
            while(val_3 < ((__RuntimeMethodHiddenParam + 24 + 192 + 104 + 24) << ));
            
            return (T[])__RuntimeMethodHiddenParam + 24 + 192;
        }
        private void ThrowIfEmpty(string message = "Cannot access an empty buffer.")
        {
            if((this & 1) != 0)
            {
                    throw new System.InvalidOperationException(message:  ???);
            }
        
        }
        private void Increment(ref int index)
        {
            int val_1 = index + 1;
            index = val_1;
            if(val_1 != this)
            {
                    return;
            }
            
            index = 0;
        }
        private void Decrement(ref int index)
        {
            int val_1 = index;
            if(val_1 == 0)
            {
                    val_1 = this;
                index = this;
            }
            
            index = 1152921519494595951;
        }
        private int InternalIndex(int index)
        {
            int val_1 = index;
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 24;
            val_1 = this - val_1;
            if(val_1 <= val_1)
            {
                    var val_2 = this;
                val_1 = val_1 - val_2;
            }
            
            val_2 = val_1 + W22;
            return (int)val_2;
        }
        private System.ArraySegment<T> ArrayOne()
        {
            int val_4;
            var val_5;
            val_4 = W9 - W2;
            if()
            {
                    val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192];
                val_5 = __RuntimeMethodHiddenParam + 24 + 192;
            }
            else
            {
                    val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192];
                val_5 = __RuntimeMethodHiddenParam + 24 + 192;
                val_4 = (X8 + 24) - W2;
            }
            
            System.ArraySegment<SRDebugger.Services.ProfilerFrame> val_1 = new System.ArraySegment<SRDebugger.Services.ProfilerFrame>(array:  X8, offset:  0, count:  val_4);
            return (System.ArraySegment<T>)val_1._count;
        }
        private System.ArraySegment<T> ArrayTwo()
        {
            var val_2;
            T[] val_3;
            var val_4;
            var val_5;
            if(W9 < W3)
            {
                    val_3 = X8;
                val_4 = W3;
                val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192];
                val_5 = __RuntimeMethodHiddenParam + 24 + 192;
                val_2 = 0;
            }
            else
            {
                    System.ArraySegment<SRDebugger.Services.ProfilerFrame> val_1;
                val_3 = X8;
                val_4 = 0;
                val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192];
                val_5 = __RuntimeMethodHiddenParam + 24 + 192;
            }
            
            val_1 = new System.ArraySegment<SRDebugger.Services.ProfilerFrame>(array:  val_3, offset:  0, count:  0);
            return (System.ArraySegment<T>)val_1._count;
        }
    
    }

}
