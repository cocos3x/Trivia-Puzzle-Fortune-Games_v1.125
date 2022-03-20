using UnityEngine;

namespace Spine
{
    [Serializable]
    public class ExposedList<T> : IEnumerable<T>, IEnumerable
    {
        // Fields
        public T[] Items;
        public int Count;
        private const int DefaultCapacity = 4;
        private static readonly T[] EmptyArray;
        private int version;
        
        // Properties
        public int Capacity { get; set; }
        
        // Methods
        public ExposedList<T>()
        {
            var val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            mem[1152921510578700144] = __RuntimeMethodHiddenParam + 24 + 192 + 184;
        }
        public ExposedList<T>(System.Collections.Generic.IEnumerable<T> collection)
        {
            var val_2;
            var val_3;
            var val_4;
            var val_5;
            var val_6;
            val_2 = collection;
            val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 16;
            if(X0 == false)
            {
                goto label_2;
            }
            
            var val_3 = X0;
            if((X0 + 294) == 0)
            {
                goto label_4;
            }
            
            var val_1 = X0 + 176;
            var val_2 = 0;
            val_1 = val_1 + 8;
            label_6:
            if(((X0 + 176 + 8) + -8) == (__RuntimeMethodHiddenParam + 24 + 192 + 16))
            {
                goto label_5;
            }
            
            val_2 = val_2 + 1;
            val_1 = val_1 + 16;
            if(val_2 < (X0 + 294))
            {
                goto label_6;
            }
            
            label_4:
            val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 16;
            goto label_7;
            label_2:
            val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_5 & 1) == 0)
            {
                    val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            mem[1152921510578820336] = __RuntimeMethodHiddenParam + 24 + 192 + 184;
            val_6 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 24];
            val_6 = __RuntimeMethodHiddenParam + 24 + 192 + 24;
            goto __RuntimeMethodHiddenParam + 24 + 192 + 40;
            label_5:
            val_3 = val_3 + (((X0 + 176 + 8)) << 4);
            val_4 = val_3 + 304;
            label_7:
            val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 32];
            val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 32;
            mem[1152921510578820336] = val_2;
            val_6 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 40];
            val_6 = __RuntimeMethodHiddenParam + 24 + 192 + 40;
            goto __RuntimeMethodHiddenParam + 24 + 192 + 40;
        }
        public ExposedList<T>(int capacity)
        {
            if((capacity & 2147483648) != 0)
            {
                    throw new System.ArgumentOutOfRangeException(paramName:  "capacity");
            }
            
            mem[1152921510578949840] = __RuntimeMethodHiddenParam + 24 + 192 + 32;
        }
        internal ExposedList<T>(T[] data, int size)
        {
            mem[1152921510579106896] = data;
            mem[1152921510579106904] = size;
        }
        public void Add(T item)
        {
            if(W9 != (X8 + 24))
            {
                goto label_1;
            }
            
            var val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 48;
            mem[1152921510579259864] = W9 + 1;
            if(val_3 != 0)
            {
                goto label_2;
            }
            
            throw new NullReferenceException();
            label_1:
            mem[1152921510579259864] = W9 + 1;
            label_2:
            val_3 = val_3 + ((W9) << 3);
            mem2[0] = item;
            val_3 = val_3 + 1;
            mem[1152921510579259868] = val_3;
        }
        public void GrowIfNeeded(int newCount)
        {
            var val_9;
            int val_10;
            val_9 = __RuntimeMethodHiddenParam;
            val_10 = W9 + newCount;
            if(val_10 <= 38021)
            {
                    return;
            }
            
            int val_2 = System.Math.Max(val1:  System.Math.Max(val1:  -939843968, val2:  4), val2:  val_10);
            val_9 = ???;
            val_10 = ???;
            goto __RuntimeMethodHiddenParam + 24 + 192 + 64;
        }
        public Spine.ExposedList<T> Resize(int newSize)
        {
            mem[1152921510579487960] = newSize;
            return (Spine.ExposedList<T>)this;
        }
        public void EnsureCapacity(int min)
        {
            if(X8 != 0)
            {
                    if((X8 + 24) >= min)
            {
                    return;
            }
            
                var val_2 = ((X8 + 24) == 0) ? 4 : ((X8 + 24) << 1);
                var val_3 = (val_2 < min) ? min : (val_2);
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        private void CheckRange(int idx, int count)
        {
            string val_5;
            var val_6;
            if((idx & 2147483648) != 0)
            {
                goto label_1;
            }
            
            if((count & 2147483648) != 0)
            {
                goto label_2;
            }
            
            if((count + idx) > true)
            {
                goto label_3;
            }
            
            return;
            label_1:
            val_5 = "index";
            goto label_4;
            label_2:
            System.ArgumentOutOfRangeException val_2 = null;
            val_5 = "count";
            label_4:
            val_6 = val_2;
            val_2 = new System.ArgumentOutOfRangeException(paramName:  val_5);
            throw val_6 = val_3;
            label_3:
            System.ArgumentException val_3 = null;
            val_3 = new System.ArgumentException(message:  "index and count exceed length of list");
            throw val_6;
        }
        private void AddCollection(System.Collections.Generic.ICollection<T> collection)
        {
            var val_3 = __RuntimeMethodHiddenParam;
            var val_3 = 0;
            val_3 = val_3 + 1;
            if(collection == null)
            {
                    return;
            }
            
            var val_4 = 0;
            val_4 = val_4 + 1;
            System.Collections.Generic.ICollection<T> val_5 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(collection, typeof(__RuntimeMethodHiddenParam + 24 + 192 + 16), slot: 5);
            val_5 = val_5 + collection;
            mem[1152921510579853800] = val_5;
        }
        private void AddEnumerable(System.Collections.Generic.IEnumerable<T> enumerable)
        {
            var val_8;
            var val_9;
            var val_12;
            val_8 = __RuntimeMethodHiddenParam;
            val_9 = enumerable;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_9 = val_9;
            label_19:
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_12 = public System.Boolean System.Collections.IEnumerator::MoveNext();
            if(val_9.MoveNext() == false)
            {
                goto label_12;
            }
            
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_12 = __RuntimeMethodHiddenParam + 24 + 192 + 88;
            if(this == null)
            {
                    throw new NullReferenceException();
            }
            
            goto label_19;
            label_12:
            val_8 = 0;
            if(val_9 != null)
            {
                    var val_12 = 0;
                val_12 = val_12 + 1;
                val_9.Dispose();
            }
            
            if(val_8 != 0)
            {
                    throw val_8;
            }
        
        }
        public void AddRange(System.Collections.Generic.IEnumerable<T> collection)
        {
            var val_1;
            if(X0 != false)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 40];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 40;
            }
            else
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 24];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 24;
            }
            
            var val_1 = val_1;
            val_1 = val_1 + 1;
            mem[1152921510580094252] = val_1;
        }
        public int BinarySearch(T item)
        {
            return (int)X8;
        }
        public int BinarySearch(T item, System.Collections.Generic.IComparer<T> comparer)
        {
            return (int)X8;
        }
        public int BinarySearch(int index, int count, T item, System.Collections.Generic.IComparer<T> comparer)
        {
            return (int)this;
        }
        public void Clear(bool clearArray = True)
        {
            if(clearArray != false)
            {
                    System.Array.Clear(array:  this, index:  0, length:  __RuntimeMethodHiddenParam);
            }
            
            mem[1152921510580636552] = 0;
            mem[1152921510580636556] = W8 + 1;
        }
        public bool Contains(T item)
        {
            return (bool)((__RuntimeMethodHiddenParam + 24 + 192) != 1) ? 1 : 0;
        }
        public Spine.ExposedList<TOutput> ConvertAll<TOutput>(System.Converter<T, TOutput> converter)
        {
            var val_2;
            if(converter == null)
            {
                    throw new System.ArgumentNullException(paramName:  "converter");
            }
            
            if((__RuntimeMethodHiddenParam + 48 + 8) >= 1)
            {
                    do
            {
                var val_1 = 4 - 4;
                mem2[0] = converter;
                val_2 = 4 + 1;
            }
            while((4 - 3) < (__RuntimeMethodHiddenParam + 48 + 16 + 24));
            
            }
            
            mem2[0] = __RuntimeMethodHiddenParam + 48 + 16 + 24;
            return (Spine.ExposedList<TOutput>)__RuntimeMethodHiddenParam + 48;
        }
        public void CopyTo(T[] array)
        {
            System.Array.Copy(sourceArray:  X8, sourceIndex:  0, destinationArray:  array, destinationIndex:  0, length:  0);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            System.Array.Copy(sourceArray:  X8, sourceIndex:  0, destinationArray:  array, destinationIndex:  arrayIndex, length:  0);
        }
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            System.Array.Copy(sourceArray:  this, sourceIndex:  index, destinationArray:  array, destinationIndex:  arrayIndex, length:  count);
        }
        public bool Exists(System.Predicate<T> match)
        {
            var val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_2 & 1) == 0)
            {
                    val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            if((val_2 & 512) == 0)
            {
                    return (bool)(this != 1) ? 1 : 0;
            }
            
            return (bool)(this != 1) ? 1 : 0;
        }
        public T Find(System.Predicate<T> match)
        {
            var val_1;
            Spine.Unity.SubmeshInstruction val_0;
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            if(this != 1)
            {
                    val_0.material = null;
                val_0.rawTriangleCount = ;
                val_0.skeleton = null;
                return val_0;
            }
            
            val_0.material = 0;
            val_0.rawTriangleCount = 0;
            val_0.rawVertexCount = 0;
            val_0.rawFirstVertexIndex = 0;
            val_0.hasClipping = false;
            mem[1152921510581728029] = 0;
            val_0.skeleton = 0;
            return val_0;
        }
        private static void CheckMatch(System.Predicate<T> match)
        {
            if(match == null)
            {
                    throw new System.ArgumentNullException(paramName:  "match");
            }
        
        }
        public Spine.ExposedList<T> FindAll(System.Predicate<T> match)
        {
            var val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            if(((val_1 & 512) != 0) && ((__RuntimeMethodHiddenParam + 24 + 192 + 224) == 0))
            {
                
            }
        
        }
        private Spine.ExposedList<T> FindAllList(System.Predicate<T> match)
        {
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 168;
            if(val_1 < 1)
            {
                    return (Spine.ExposedList<T>)__RuntimeMethodHiddenParam + 24 + 192 + 160;
            }
            
            var val_3 = 0;
            var val_4 = 32;
            do
            {
                val_1 = val_1 + val_4;
                var val_2 = __RuntimeMethodHiddenParam + 24 + 192;
                if((match & 1) != 0)
            {
                    val_2 = val_2 + val_4;
            }
            
                val_3 = val_3 + 1;
                val_4 = val_4 + 48;
            }
            while(val_3 < (__RuntimeMethodHiddenParam + 24 + 192));
            
            return (Spine.ExposedList<T>)__RuntimeMethodHiddenParam + 24 + 192 + 160;
        }
        public int FindIndex(System.Predicate<T> match)
        {
            var val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            if(((val_1 & 512) != 0) && ((__RuntimeMethodHiddenParam + 24 + 192 + 224) == 0))
            {
                
            }
        
        }
        public int FindIndex(int startIndex, System.Predicate<T> match)
        {
            var val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_2 & 1) == 0)
            {
                    val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            int val_1 = (__RuntimeMethodHiddenParam + 24 + 192) - startIndex;
            goto __RuntimeMethodHiddenParam + 24 + 192 + 144;
        }
        public int FindIndex(int startIndex, int count, System.Predicate<T> match)
        {
            var val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            if(((val_1 & 512) != 0) && ((__RuntimeMethodHiddenParam + 24 + 192 + 224) == 0))
            {
                
            }
        
        }
        private int GetIndex(int startIndex, int count, System.Predicate<T> match)
        {
            var val_3;
            int val_1 = count + startIndex;
            if(val_1 > startIndex)
            {
                    var val_2 = 48;
                val_3 = (long)startIndex;
                var val_3 = 80;
                do
            {
                val_2 = val_2 + val_3;
                if((match & 1) != 0)
            {
                    return (int)val_3;
            }
            
                val_3 = val_3 + 1;
                val_3 = val_3 + 48;
            }
            while(val_3 < (long)val_1);
            
            }
            
            val_3 = 0;
            return (int)val_3;
        }
        public T FindLast(System.Predicate<T> match)
        {
            var val_1;
            Spine.Unity.SubmeshInstruction val_0;
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            if(this != 1)
            {
                    val_0.material = null;
                val_0.rawTriangleCount = ;
                val_0.skeleton = null;
                return val_0;
            }
            
            val_0.material = 0;
            val_0.rawTriangleCount = 0;
            val_0.rawVertexCount = 0;
            val_0.rawFirstVertexIndex = 0;
            val_0.hasClipping = false;
            mem[1152921510582723245] = 0;
            val_0.skeleton = 0;
            return val_0;
        }
        public int FindLastIndex(System.Predicate<T> match)
        {
            var val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_1 & 1) == 0)
            {
                    val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            if(((val_1 & 512) != 0) && ((__RuntimeMethodHiddenParam + 24 + 192 + 224) == 0))
            {
                
            }
        
        }
        public int FindLastIndex(int startIndex, System.Predicate<T> match)
        {
            var val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_2 & 1) == 0)
            {
                    val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            int val_1 = startIndex + 1;
            goto __RuntimeMethodHiddenParam + 24 + 192 + 192;
        }
        public int FindLastIndex(int startIndex, int count, System.Predicate<T> match)
        {
            var val_2;
            int val_2 = startIndex;
            val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_2 & 1) == 0)
            {
                    val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            val_2 = (val_2 - count) + 1;
            goto __RuntimeMethodHiddenParam + 24 + 192 + 192;
        }
        private int GetLastIndex(int startIndex, int count, System.Predicate<T> match)
        {
            var val_4;
            int val_3 = count;
            label_4:
            if(val_3 == 0)
            {
                goto label_0;
            }
            
            val_4 = (count + startIndex) - 1;
            int val_2 = X8 + (val_4 * 48);
            val_3 = val_3 - 1;
            if((match & 1) == 0)
            {
                goto label_4;
            }
            
            return (int)val_4;
            label_0:
            val_4 = 0;
            return (int)val_4;
        }
        public void ForEach(System.Action<T> action)
        {
            bool val_2 = true;
            if(action == null)
            {
                    throw new System.ArgumentNullException(paramName:  "action");
            }
            
            if(val_2 < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            var val_4 = 32;
            do
            {
                val_2 = val_2 + val_4;
                val_3 = val_3 + 1;
                val_4 = val_4 + 48;
            }
            while(val_3 < (__RuntimeMethodHiddenParam + 24 + 192));
        
        }
        public Spine.ExposedList.Enumerator<T> GetEnumerator()
        {
            mem2[0] = 0;
            mem2[0] = val_1.current;
            return (ExposedList.Enumerator<T>)new ExposedList.Enumerator<System.Object>(l:  this);
        }
        public Spine.ExposedList<T> GetRange(int index, int count)
        {
            System.Array.Copy(sourceArray:  __RuntimeMethodHiddenParam + 24 + 192 + 32 + 302, sourceIndex:  index, destinationArray:  __RuntimeMethodHiddenParam + 24 + 192 + 32, destinationIndex:  0, length:  count);
            if(((__RuntimeMethodHiddenParam + 24 + 192 + 160 + 302) & 1) != 0)
            {
                    return (Spine.ExposedList<T>)__RuntimeMethodHiddenParam + 24 + 192 + 160;
            }
            
            return (Spine.ExposedList<T>)__RuntimeMethodHiddenParam + 24 + 192 + 160;
        }
        public int IndexOf(T item)
        {
            goto __RuntimeMethodHiddenParam + 24 + 192 + 128;
        }
        public int IndexOf(T item, int index)
        {
            int val_1 = W9 - index;
            return (int)this;
        }
        public int IndexOf(T item, int index, int count)
        {
            string val_4;
            if((index & 2147483648) != 0)
            {
                goto label_1;
            }
            
            if((count & 2147483648) != 0)
            {
                goto label_2;
            }
            
            if((count + index) > true)
            {
                goto label_3;
            }
            
            return 11378;
            label_1:
            val_4 = "index";
            goto label_5;
            label_2:
            val_4 = "count";
            goto label_5;
            label_3:
            System.ArgumentOutOfRangeException val_2 = null;
            val_4 = "index and count exceed length of list";
            label_5:
            val_2 = new System.ArgumentOutOfRangeException(paramName:  val_4);
            throw val_2;
        }
        private void Shift(int start, int delta)
        {
            start = start - (delta & (delta >> 31));
            if()
            {
                    System.Array.Copy(sourceArray:  this, sourceIndex:  start, destinationArray:  this, destinationIndex:  start + delta, length:  W8 - start);
            }
            
            int val_4 = W8 + delta;
            mem[1152921510584076872] = val_4;
            if((delta & 2147483648) == 0)
            {
                    return;
            }
            
            System.Array.Clear(array:  this, index:  val_4, length:  -delta);
        }
        private void CheckIndex(int index)
        {
            if(((index & 2147483648) != 0) || (true < index))
            {
                    throw new System.ArgumentOutOfRangeException(paramName:  "index");
            }
        
        }
        public void Insert(int index, T item)
        {
            int val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 232;
            val_1 = val_1 + (index * 48);
            mem2[0] = item.material;
            mem2[0] = item.rawTriangleCount;
            mem2[0] = item.skeleton;
            val_1 = val_1 + 1;
            mem[1152921510584322396] = val_1;
        }
        private void CheckCollection(System.Collections.Generic.IEnumerable<T> collection)
        {
            if(collection == null)
            {
                    throw new System.ArgumentNullException(paramName:  "collection");
            }
        
        }
        public void InsertRange(int index, System.Collections.Generic.IEnumerable<T> collection)
        {
            var val_1;
            if(this == collection)
            {
                goto label_1;
            }
            
            if(X0 == false)
            {
                goto label_3;
            }
            
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 248];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 248;
            goto label_4;
            label_1:
            System.Array.Copy(sourceArray:  __RuntimeMethodHiddenParam + 24 + 192 + 32, sourceIndex:  0, destinationArray:  __RuntimeMethodHiddenParam + 24 + 192 + 32 + 24, destinationIndex:  index, length:  __RuntimeMethodHiddenParam + 24 + 192 + 32 + 24);
            goto label_7;
            label_3:
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 256];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 256;
            label_4:
            var val_1 = val_1;
            label_7:
            val_1 = val_1 + 1;
            mem[1152921510584584396] = val_1;
        }
        private void InsertCollection(int index, System.Collections.Generic.ICollection<T> collection)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            var val_4 = 0;
            val_4 = val_4 + 1;
            goto (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(collection, typeof(__RuntimeMethodHiddenParam + 24 + 192 + 16), slot: 5);
        }
        private void InsertEnumeration(int index, System.Collections.Generic.IEnumerable<T> enumerable)
        {
            var val_9;
            var val_10;
            var val_11;
            var val_12;
            val_9 = __RuntimeMethodHiddenParam;
            val_10 = enumerable;
            val_11 = index;
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_12 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 80];
            val_12 = __RuntimeMethodHiddenParam + 24 + 192 + 80;
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_10 = val_10;
            goto label_8;
            label_19:
            val_12 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 88];
            val_12 = __RuntimeMethodHiddenParam + 24 + 192 + 88;
            var val_10 = 0;
            val_10 = val_10 + 1;
            if(this == null)
            {
                    throw new NullReferenceException();
            }
            
            val_11 = val_11 + 1;
            label_8:
            var val_11 = 0;
            val_11 = val_11 + 1;
            if(val_10.MoveNext() == true)
            {
                goto label_19;
            }
            
            val_9 = 0;
            if(val_10 != null)
            {
                    var val_12 = 0;
                val_12 = val_12 + 1;
                val_10.Dispose();
            }
            
            if(val_9 != 0)
            {
                    throw val_9;
            }
        
        }
        public int LastIndexOf(T item)
        {
            var val_1 = W3 - 1;
            return (int)X8;
        }
        public int LastIndexOf(T item, int index)
        {
            int val_1 = index + 1;
            return (int)this;
        }
        public int LastIndexOf(T item, int index, int count)
        {
            object val_3;
            string val_5;
            string val_6;
            if((index & 2147483648) != 0)
            {
                goto label_1;
            }
            
            if((count & 2147483648) != 0)
            {
                goto label_2;
            }
            
            if((index + 1) < 0)
            {
                goto label_3;
            }
            
            return 11395;
            label_1:
            val_3 = index;
            val_5 = "index";
            val_6 = "index is negative";
            goto label_5;
            label_2:
            val_3 = count;
            val_5 = "count";
            val_6 = "count is negative";
            goto label_5;
            label_3:
            val_3 = count;
            System.ArgumentOutOfRangeException val_2 = null;
            val_5 = "count";
            val_6 = "count is too large";
            label_5:
            val_2 = new System.ArgumentOutOfRangeException(paramName:  val_5, actualValue:  count, message:  val_6);
            throw val_2;
        }
        public bool Remove(T item)
        {
            return (bool)(this != 1) ? 1 : 0;
        }
        public int RemoveAll(System.Predicate<T> match)
        {
            var val_5;
            int val_7;
            var val_8;
            int val_9;
            val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_5 & 1) == 0)
            {
                    val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            var val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 136;
            if(val_4 < 1)
            {
                goto label_5;
            }
            
            val_7 = 0;
            val_8 = 32;
            label_10:
            val_4 = val_4 + val_8;
            var val_6 = __RuntimeMethodHiddenParam + 24 + 192;
            var val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 176;
            if((match & 1) != 0)
            {
                goto label_9;
            }
            
            val_7 = val_7 + 1;
            val_8 = val_8 + 48;
            if(val_7 < val_6)
            {
                goto label_10;
            }
            
            goto label_12;
            label_5:
            val_7 = 0;
            goto label_12;
            label_9:
            label_12:
            if(val_7 == val_6)
            {
                    val_9 = 0;
                return val_9;
            }
            
            val_8 = val_7 + 1;
            val_5 = val_5 + 1;
            mem[1152921510585546012] = val_5;
            if(val_8 < val_6)
            {
                    var val_1 = val_6 + 32;
                do
            {
                val_6 = val_6 + val_1;
                var val_7 = __RuntimeMethodHiddenParam + 24 + 192;
                if((match & 1) == 0)
            {
                    val_7 = val_7 + (val_7 * 48);
                val_7 = val_7 + 1;
                mem2[0] = (__RuntimeMethodHiddenParam + 24 + 192 + (__RuntimeMethodHiddenParam + 24 + 192 + 32)) + 16;
                mem2[0] = (__RuntimeMethodHiddenParam + 24 + 192 + (__RuntimeMethodHiddenParam + 24 + 192 + 32)) + 16 + 16;
                mem2[0] = val_7 + val_1;
            }
            
                val_8 = val_8 + 1;
                val_1 = val_1 + 48;
            }
            while(val_8 < val_7);
            
            }
            
            val_9 = val_8 - val_7;
            if(val_9 >= 1)
            {
                    System.Array.Clear(array:  match, index:  val_7, length:  val_9);
            }
            
            mem[1152921510585546008] = val_7;
            return val_9;
        }
        public void RemoveAt(int index)
        {
            if(((index & 2147483648) != 0) || (true <= index))
            {
                    throw new System.ArgumentOutOfRangeException(paramName:  "index");
            }
            
            var val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 232;
            System.Array.Clear(array:  this, index:  index, length:  1);
            val_2 = val_2 + 1;
            mem[1152921510585667228] = val_2;
        }
        public void RemoveRange(int index, int count)
        {
            if(count < 1)
            {
                    return;
            }
            
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 232;
            System.Array.Clear(array:  this, index:  index, length:  count);
            val_1 = val_1 + 1;
            mem[1152921510585783324] = val_1;
        }
        public void Reverse()
        {
            System.Array.Reverse(array:  this, index:  0, length:  0);
            mem[1152921510585895324] = W8 + 1;
        }
        public void Reverse(int index, int count)
        {
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 120;
            System.Array.Reverse(array:  this, index:  index, length:  count);
            val_1 = val_1 + 1;
            mem[1152921510586007324] = val_1;
        }
        public void Sort()
        {
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 312;
            val_1 = val_1 + 1;
            mem[1152921510586119324] = val_1;
        }
        public void Sort(System.Collections.Generic.IComparer<T> comparer)
        {
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 312;
            val_1 = val_1 + 1;
            mem[1152921510586235420] = val_1;
        }
        public void Sort(System.Comparison<T> comparison)
        {
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 320;
            val_1 = val_1 + 1;
            mem[1152921510586355612] = val_1;
        }
        public void Sort(int index, int count, System.Collections.Generic.IComparer<T> comparer)
        {
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 312;
            val_1 = val_1 + 1;
            mem[1152921510586475804] = val_1;
        }
        public T[] ToArray()
        {
            System.Array.Copy(sourceArray:  __RuntimeMethodHiddenParam + 24 + 192 + 32 + 302, destinationArray:  __RuntimeMethodHiddenParam + 24 + 192 + 32, length:  0);
            return (T[])__RuntimeMethodHiddenParam + 24 + 192 + 32;
        }
        public void TrimExcess()
        {
            if(this != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public bool TrueForAll(System.Predicate<T> match)
        {
            var val_2;
            var val_3;
            val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_2 & 1) == 0)
            {
                    val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
                val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            }
            
            var val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 136;
            if(val_1 < 1)
            {
                goto label_5;
            }
            
            var val_2 = 0;
            var val_3 = 32;
            label_10:
            val_1 = val_1 + val_3;
            if((match & 1) == 0)
            {
                goto label_9;
            }
            
            val_2 = val_2 + 1;
            val_3 = val_3 + 48;
            if(val_2 < (__RuntimeMethodHiddenParam + 24 + 192))
            {
                goto label_10;
            }
            
            label_5:
            val_3 = 1;
            return (bool)val_3;
            label_9:
            val_3 = 0;
            return (bool)val_3;
        }
        public int get_Capacity()
        {
            if(X8 != 0)
            {
                    return (int)X8 + 24;
            }
            
            throw new NullReferenceException();
        }
        public void set_Capacity(int value)
        {
            if(true > value)
            {
                    throw new System.ArgumentOutOfRangeException();
            }
            
            goto __RuntimeMethodHiddenParam + 24 + 192 + 72;
        }
        private System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return (System.Collections.Generic.IEnumerator<T>);
        }
        private System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (System.Collections.IEnumerator);
        }
        private static ExposedList<T>()
        {
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 32;
        }
    
    }

}
