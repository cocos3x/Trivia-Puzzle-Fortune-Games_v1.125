using UnityEngine;

namespace BlockPuzzleMagic
{
    public class PlayerGridLayout : GridLayout
    {
        // Fields
        public BlockPuzzleMagic.BlockData[] gridBlockData;
        
        // Methods
        public PlayerGridLayout(int ColumnCount, int[] GridData)
        {
            BlockPuzzleMagic.BlockData[] val_1 = new BlockPuzzleMagic.BlockData[0];
            this.gridBlockData = val_1;
            var val_3 = 0;
            do
            {
                if(val_3 >= val_1.Length)
            {
                    return;
            }
            
                BlockPuzzleMagic.BlockData val_2 = null;
                ColumnCount = val_2;
                val_2 = new BlockPuzzleMagic.BlockData();
                val_1[val_3] = ColumnCount;
                val_3 = val_3 + 1;
            }
            while(this.gridBlockData != null);
            
            throw new NullReferenceException();
        }
        public PlayerGridLayout(BlockPuzzleMagic.GridLayout target)
        {
            BlockPuzzleMagic.BlockData val_4;
            BlockPuzzleMagic.GridLayout val_1 = target;
            val_1 = new BlockPuzzleMagic.GridLayout(target:  val_1);
            BlockPuzzleMagic.BlockData[] val_2 = new BlockPuzzleMagic.BlockData[0];
            this.gridBlockData = val_2;
            var val_4 = 0;
            do
            {
                if(val_4 >= val_2.Length)
            {
                    return;
            }
            
                BlockPuzzleMagic.BlockData val_3 = null;
                val_4 = val_3;
                val_3 = new BlockPuzzleMagic.BlockData();
                val_2[val_4] = val_4;
                val_4 = val_4 + 1;
            }
            while(this.gridBlockData != null);
            
            throw new NullReferenceException();
        }
    
    }

}
