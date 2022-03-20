using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GridLayoutDefinitions : ScriptableObject
    {
        // Fields
        public const int MAX_GRID_COLUMN_COUNT_CHALLENGE = 9;
        public const int MAX_GRID_ROW_COUNT_CHALLENGE = 9;
        public const int MAX_GRID_COLUMN_COUNT_ZEN = 10;
        public const int MAX_GRID_ROW_COUNT_ZEN = 10;
        public const int ON = 1;
        public const int XX = 0;
        public BlockPuzzleMagic.GridLayoutCollection[] layoutDefinitions;
        
        // Properties
        public BlockPuzzleMagic.GridLayout[] NormalLayouts { get; }
        public BlockPuzzleMagic.GridLayout[] StoneLayouts { get; }
        
        // Methods
        public BlockPuzzleMagic.GridLayout[] get_NormalLayouts()
        {
            return this.GetGridLayoutsByType(layoutType:  1);
        }
        public BlockPuzzleMagic.GridLayout[] get_StoneLayouts()
        {
            return this.GetGridLayoutsByType(layoutType:  3);
        }
        public BlockPuzzleMagic.GridLayout[] GetGridLayoutsByType(BlockPuzzleMagic.GridLayoutType layoutType)
        {
            BlockPuzzleMagic.GridLayout[] val_1;
            if(this.layoutDefinitions.Length < 1)
            {
                goto label_1;
            }
            
            var val_2 = 0;
            label_5:
            BlockPuzzleMagic.GridLayoutCollection val_1 = this.layoutDefinitions[val_2];
            if(this.layoutDefinitions[0x0][0].collectionType == layoutType)
            {
                goto label_4;
            }
            
            val_2 = val_2 + 1;
            if(val_2 < this.layoutDefinitions.Length)
            {
                goto label_5;
            }
            
            label_1:
            val_1 = 0;
            return val_1;
            label_4:
            val_1 = this.layoutDefinitions[0x0][0].layouts;
            return val_1;
        }
        public BlockPuzzleMagic.GridLayout[] GetGridLayoutsByType(BlockPuzzleMagic.GridLayout.NodeType nodeType)
        {
            nodeType = (nodeType != 1) ? ((nodeType == 4) ? 3 : 0) : (0 + 1);
            return this.GetGridLayoutsByType(layoutType:  nodeType);
        }
        public GridLayoutDefinitions()
        {
        
        }
    
    }

}
