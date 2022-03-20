using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordBalloonGridSurface
    {
        // Fields
        public int rowIndex;
        public SLC.Minigames.WordBalloon.WordBalloonGridSurface.OrientationType orientation;
        public System.Collections.Generic.List<int> columnIndexes;
        private int <Height>k__BackingField;
        
        // Properties
        public int FirstColumnIndex { get; }
        public int LastColumnIndex { get; }
        public int Width { get; }
        public int Height { get; set; }
        
        // Methods
        public int get_FirstColumnIndex()
        {
            if(true != 0)
            {
                    return 0;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            return 0;
        }
        public int get_LastColumnIndex()
        {
            bool val_1 = true;
            if(val_1 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + 0;
            return (int)(true + 0) + 32;
        }
        public int get_Width()
        {
            return 37710;
        }
        public int get_Height()
        {
            return (int)this.<Height>k__BackingField;
        }
        public void set_Height(int value)
        {
            this.<Height>k__BackingField = value;
        }
        public WordBalloonGridSurface(SLC.Minigames.WordBalloon.WordBalloonGridSurface.OrientationType _orientationType, int row)
        {
            this.rowIndex = row;
            this.orientation = _orientationType;
            this.columnIndexes = new System.Collections.Generic.List<System.Int32>();
        }
        public int GetColumnIdBySurfaceIndex(int index)
        {
            bool val_1 = true;
            if(val_1 <= index)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + (index << 2);
            return (int)(true + (index) << 2) + 32;
        }
        public override string ToString()
        {
            int val_6;
            int val_7;
            int val_8;
            int val_9;
            int val_10;
            object[] val_1 = new object[11];
            val_1[0] = "{ Row: ";
            val_6 = val_1.Length;
            val_1[1] = this.rowIndex;
            val_6 = val_1.Length;
            val_1[2] = ", StartColumn: ";
            val_7 = val_1.Length;
            val_1[3] = this.FirstColumnIndex;
            val_7 = val_1.Length;
            val_1[4] = ", EndColumn: ";
            val_8 = val_1.Length;
            val_1[5] = this.LastColumnIndex;
            val_8 = val_1.Length;
            val_1[6] = ", Width: ";
            val_9 = val_1.Length;
            val_1[7] = this.Width;
            val_9 = val_1.Length;
            val_1[8] = ", Height: ";
            val_10 = val_1.Length;
            val_1[9] = this.<Height>k__BackingField;
            val_10 = val_1.Length;
            val_1[10] = " }";
            return (string)+val_1;
        }
    
    }

}
