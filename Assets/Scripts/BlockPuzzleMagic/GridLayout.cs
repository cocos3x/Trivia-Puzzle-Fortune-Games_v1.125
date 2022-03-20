using UnityEngine;

namespace BlockPuzzleMagic
{
    [Serializable]
    public class GridLayout
    {
        // Fields
        public static readonly BlockPuzzleMagic.GridLayout ZenGridLayout;
        public int columnCount;
        public int[] gridData;
        
        // Properties
        public static int MaxColumnCount { get; }
        public static int MaxRowCount { get; }
        public int rowCount { get; }
        
        // Methods
        public static int get_MaxColumnCount()
        {
            var val_4;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) != 0)
            {
                    BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                if((val_3.currentLevel != null) && (val_3.currentLevel.gameMode == 1))
            {
                    val_4 = 10;
                return 9;
            }
            
            }
            
            val_4 = 9;
            return 9;
        }
        public static int get_MaxRowCount()
        {
            var val_4;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) != 0)
            {
                    BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                if((val_3.currentLevel != null) && (val_3.currentLevel.gameMode == 1))
            {
                    val_4 = 10;
                return 9;
            }
            
            }
            
            val_4 = 9;
            return 9;
        }
        public int get_rowCount()
        {
            float val_1 = (float)this.gridData.Length;
            val_1 = val_1 / (float)this.columnCount;
            return UnityEngine.Mathf.CeilToInt(f:  val_1);
        }
        public GridLayout(int ColumnCount, int[] GridData)
        {
            this.columnCount = ColumnCount;
            int[] val_1 = new int[0];
            this.gridData = val_1;
            GridData.CopyTo(array:  val_1, index:  0);
        }
        public GridLayout(BlockPuzzleMagic.GridLayout target)
        {
            this.columnCount = target.columnCount;
            int[] val_1 = new int[0];
            this.gridData = val_1;
            target.gridData.CopyTo(array:  val_1, index:  0);
        }
        public override string ToString()
        {
            var val_5;
            int val_6;
            val_5 = 0;
            val_6 = System.String.alignConst;
            do
            {
                if(val_5 >= (this.gridData.Length << ))
            {
                    return (string)val_6;
            }
            
                int val_6 = this.columnCount;
                val_5 = val_5 + 1;
                val_6 = val_5 - ((val_5 / val_6) * val_6);
                val_6 = val_6 + this.gridData[val_5](val_6 + this.gridData[val_5]) + (val_6 == 0) ? "\n" : ", "((val_6 == 0) ? "\n" : ", ");
            }
            while(this.gridData != null);
            
            throw new NullReferenceException();
        }
        public bool GridContainsNodeType(BlockPuzzleMagic.GridLayout.NodeType _nodeType)
        {
            return (bool)((this.GetNodeTypeGridCount(_nodeType:  _nodeType)) > 0) ? 1 : 0;
        }
        public int GetNodeTypeGridCount(BlockPuzzleMagic.GridLayout.NodeType _nodeType)
        {
            var val_3 = 0;
            var val_3 = 0;
            do
            {
                if(val_3 >= this.gridData.Length)
            {
                    return (int)val_3;
            }
            
                val_3 = val_3 + (this.IsFlagSetOnGridDataNode(_gridDataIndex:  0, _nodeType:  _nodeType));
                val_3 = val_3 + 1;
            }
            while(this.gridData != null);
            
            throw new NullReferenceException();
        }
        public bool IsFlagSetOnGridDataNode(int _gridDataIndex, BlockPuzzleMagic.GridLayout.NodeType _nodeType)
        {
            var val_2;
            if(this.gridData.Length > _gridDataIndex)
            {
                    if(_nodeType == 0)
            {
                    return (bool)(this.gridData[_gridDataIndex] == 0) ? 1 : 0;
            }
            
                return (bool)(this.gridData[_gridDataIndex] == 0) ? 1 : 0;
            }
            
            val_2 = 0;
            return (bool)(this.gridData[_gridDataIndex] == 0) ? 1 : 0;
        }
        public void SetFlagToGridDataNode(int _gridDataIndex, BlockPuzzleMagic.GridLayout.NodeType _nodeType)
        {
            if(this.gridData.Length <= _gridDataIndex)
            {
                    return;
            }
            
            int val_1 = this.gridData[_gridDataIndex];
            val_1 = val_1 | _nodeType;
            this.gridData[_gridDataIndex] = val_1;
        }
        public void RemoveFlagFromGridDataNode(int _gridDataIndex, BlockPuzzleMagic.GridLayout.NodeType _nodeType)
        {
            if(this.gridData.Length <= _gridDataIndex)
            {
                    return;
            }
            
            int val_1 = this.gridData[_gridDataIndex];
            val_1 = val_1 & (~_nodeType);
            this.gridData[_gridDataIndex] = val_1;
        }
        public static UnityEngine.Vector2 GetColumnRowIndexFromGridIndex(int gridIndex)
        {
            var val_8;
            var val_9;
            var val_10;
            val_8 = null;
            int val_1 = BlockPuzzleMagic.GridLayout.MaxColumnCount;
            val_9 = gridIndex - ((gridIndex / val_1) * val_1);
            float val_7 = (float)gridIndex;
            val_7 = val_7 / (float)BlockPuzzleMagic.GridLayout.MaxColumnCount;
            if((val_9 & 2147483648) != 0)
            {
                    val_10 = null;
                val_9 = BlockPuzzleMagic.GridLayout.MaxColumnCount + val_9;
            }
            
            UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  (float)val_9, y:  (float)UnityEngine.Mathf.FloorToInt(f:  val_7));
            return new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        }
        public static int GetGridIndexFromColumnRowIndex(UnityEngine.Vector2 gridColRow)
        {
            var val_2 = null;
            float val_2 = (float)BlockPuzzleMagic.GridLayout.MaxColumnCount;
            val_2 = gridColRow.y * val_2;
            val_2 = gridColRow.x + val_2;
            return UnityEngine.Mathf.FloorToInt(f:  val_2);
        }
        public static int GetCellIdTowardsDirection(int cellId, BlockPuzzleMagic.GridLayout.Direction dir)
        {
            float val_5;
            float val_6;
            var val_9;
            var val_10;
            UnityEngine.Vector2 val_1 = BlockPuzzleMagic.GridLayout.GetColumnRowIndexFromGridIndex(gridIndex:  cellId);
            val_5 = val_1.x;
            val_6 = val_1.y;
            if((dir - 1) <= 3)
            {
                    var val_5 = 32563384 + ((dir - 1)) << 2;
                val_5 = val_5 + 32563384;
            }
            else
            {
                    if( < 0f)
            {
                    return 0;
            }
            
                val_9 = null;
                int val_3 = BlockPuzzleMagic.GridLayout.MaxRowCount;
                if( < 0f)
            {
                    return 0;
            }
            
                if( >= 0)
            {
                    return 0;
            }
            
                val_10 = null;
                int val_4 = BlockPuzzleMagic.GridLayout.MaxColumnCount;
                if( >= 0)
            {
                    return 0;
            }
            
                return BlockPuzzleMagic.GridLayout.GetGridIndexFromColumnRowIndex(gridColRow:  new UnityEngine.Vector2() {});
            }
        
        }
        private static GridLayout()
        {
            BlockPuzzleMagic.GridLayout.ZenGridLayout = new BlockPuzzleMagic.GridLayout(ColumnCount:  10, GridData:  new int[100] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1});
        }
    
    }

}
