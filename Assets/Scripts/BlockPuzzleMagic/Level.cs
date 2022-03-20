using UnityEngine;

namespace BlockPuzzleMagic
{
    public class Level
    {
        // Fields
        public BlockPuzzleMagic.GameMode gameMode;
        public int levelId;
        public System.Collections.Generic.List<BlockPuzzleMagic.Goal> goals;
        public BlockPuzzleMagic.PlayerGridLayout gridLayout;
        public System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> usableShapeIds;
        public System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> usablePowerupIds;
        public int movesMade;
        
        // Methods
        public Level()
        {
            this.gameMode = 2;
        }
        public void SetUsableShapeData(int containerId, int shapeId, BlockPuzzleMagic.BlockColorType shapeColor)
        {
            int val_5;
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> val_6;
            val_5 = shapeId;
            val_6 = this.usableShapeIds;
            if(val_6 == null)
            {
                    System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> val_1 = null;
                var val_5 = 1152921520181908512;
                val_6 = val_1;
                val_1 = new System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData>();
                val_1.Add(item:  new BlockPuzzleMagic.ShapeInfoData());
                val_1.Add(item:  new BlockPuzzleMagic.ShapeInfoData());
                val_1.Add(item:  new BlockPuzzleMagic.ShapeInfoData());
                this.usableShapeIds = val_6;
            }
            
            if(val_5 <= containerId)
            {
                    return;
            }
            
            if(val_5 <= containerId)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_5 = val_5 + (containerId << 3);
            var val_6 = (1152921520181908512 + (containerId) << 3) + 32;
            mem2[0] = val_5;
            val_5 = this.usableShapeIds;
            if(val_6 <= containerId)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_6 = val_6 + (((long)(int)(containerId)) << 3);
            mem2[0] = shapeColor;
        }
        public void SetUsablePowerupData(int containerId, int shapeId, bool isFreeUsage, BlockPuzzleMagic.BlockColorType shapeColor)
        {
            BlockPuzzleMagic.BlockColorType val_6;
            int val_7;
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> val_8;
            val_6 = shapeColor;
            val_7 = shapeId;
            val_8 = this.usablePowerupIds;
            if(val_8 == null)
            {
                    System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> val_1 = null;
                var val_6 = 1152921520181908512;
                val_8 = val_1;
                val_1 = new System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData>();
                val_1.Add(item:  new BlockPuzzleMagic.ShapeInfoData());
                val_1.Add(item:  new BlockPuzzleMagic.ShapeInfoData());
                val_1.Add(item:  new BlockPuzzleMagic.ShapeInfoData());
                this.usablePowerupIds = val_8;
            }
            
            if(val_6 <= containerId)
            {
                    return;
            }
            
            if(val_6 <= containerId)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_6 = val_6 + (containerId << 3);
            var val_7 = (1152921520181908512 + (containerId) << 3) + 32;
            mem2[0] = val_7;
            val_7 = (long)containerId;
            if(val_7 <= containerId)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_7 = val_7 + (((long)(int)(containerId)) << 3);
            var val_8 = ((1152921520181908512 + (containerId) << 3) + 32 + ((long)(int)(containerId)) << 3) + 32;
            mem2[0] = val_6;
            val_6 = this.usablePowerupIds;
            if(val_8 <= containerId)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_8 = val_8 + (((long)(int)(containerId)) << 3);
            mem2[0] = isFreeUsage;
        }
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this);
        }
        public static BlockPuzzleMagic.Level Parse(string _jsonString)
        {
            return (BlockPuzzleMagic.Level)Newtonsoft.Json.JsonConvert.DeserializeObject<BlockPuzzleMagic.Level>(value:  _jsonString);
        }
    
    }

}
