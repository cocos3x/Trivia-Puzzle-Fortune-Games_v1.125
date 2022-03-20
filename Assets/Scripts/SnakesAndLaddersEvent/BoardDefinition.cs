using UnityEngine;

namespace SnakesAndLaddersEvent
{
    public class BoardDefinition
    {
        // Fields
        public const int COLS_PER_ROW = 6;
        public int MaxSpaceCount;
        public System.Collections.Generic.List<SnakesAndLaddersEvent.BoardSpace> BoardSpaces;
        
        // Methods
        public BoardDefinition(int maxBoardSpaces, System.Collections.Generic.List<int> rewardSpaceIndices, System.Collections.Generic.List<SnakesAndLaddersEvent.NumberSpaceConnectionDefinition> numberSpaceConnections)
        {
            var val_6;
            var val_7;
            int val_8;
            bool val_9;
            val_1 = new System.Object();
            System.Collections.Generic.List<SnakesAndLaddersEvent.BoardSpace> val_2 = new System.Collections.Generic.List<SnakesAndLaddersEvent.BoardSpace>();
            if(maxBoardSpaces < 1)
            {
                goto label_1;
            }
            
            val_6 = 0;
            var val_6 = 0;
            int val_7 = 1;
            label_16:
            if(val_6 >= 1152921519612633584)
            {
                goto label_6;
            }
            
            if(1152921519612633584 <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_7 = public static System.Boolean System.Linq.Enumerable::All<TRVCategoryButton>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_8 = mem[public static System.Boolean System.Linq.Enumerable::All<TRVCategoryButton>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate).__il2cppRuntimeField_20 + 20];
            val_8 = public static System.Boolean System.Linq.Enumerable::All<TRVCategoryButton>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate).__il2cppRuntimeField_20 + 20;
            val_6 = val_6 + 1;
            if(val_1 != null)
            {
                goto label_9;
            }
            
            label_6:
            val_8 = 0;
            label_9:
            if(val_6 < 1152921519612633584)
            {
                    if(1152921519612633584 <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_3 = (val_7 == (public static System.Boolean System.Linq.Enumerable::All<TRVCategoryButton>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate))) ? 1 : 0;
                var val_4 = (val_7 == (public static System.Boolean System.Linq.Enumerable::All<TRVCategoryButton>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate))) ? (val_6 + 1) : (val_6);
            }
            else
            {
                    val_9 = false;
            }
            
            .Number = val_7;
            .NumberConnected = val_8;
            .IsRewardSpace = val_9;
            val_2.Add(item:  new SnakesAndLaddersEvent.BoardSpace());
            val_7 = val_7 + 1;
            if(val_7 <= maxBoardSpaces)
            {
                goto label_16;
            }
            
            label_1:
            mem[1152921519612663752] = val_2;
            mem[1152921519612663744] = maxBoardSpaces;
        }
        public int GetRows()
        {
            int val_3 = this.MaxSpaceCount;
            val_3 = val_3 * 715827883;
            val_3 = val_3 >> 32;
            return (int)val_3 + (val_3 >> 63);
        }
        public bool Equals(SnakesAndLaddersEvent.BoardDefinition anotherBoard)
        {
            if(anotherBoard != null)
            {
                    return (bool)(this.MaxSpaceCount == anotherBoard.MaxSpaceCount) ? 1 : 0;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
