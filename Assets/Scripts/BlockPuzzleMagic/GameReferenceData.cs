using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GameReferenceData : ScriptableObject
    {
        // Fields
        private BlockPuzzleMagic.ShapeBlockList shapeBlockList;
        private BlockPuzzleMagic.ShapeInfo powerupBombShapeInfoPrefab;
        private BlockPuzzleMagic.ShapeInfo powerupFillShapeInfoPrefab;
        private BlockPuzzleMagic.ShapeInfo powerupTrashShapeInfoPrefab;
        private UnityEngine.GameObject emptyGridCellTemplate;
        private UnityEngine.GameObject emptyBlockTemplate;
        private System.Collections.Generic.List<BlockPuzzleMagic.BlockColor> blockColors;
        
        // Properties
        public static BlockPuzzleMagic.GameReferenceData Instance { get; }
        public BlockPuzzleMagic.ShapeBlockList ShapeBlockList { get; }
        public BlockPuzzleMagic.ShapeInfo PowerupBombShapeInfoPrefab { get; }
        public BlockPuzzleMagic.ShapeInfo PowerupFillShapeInfoPrefab { get; }
        public BlockPuzzleMagic.ShapeInfo PowerupTrashShapeInfoPrefab { get; }
        public UnityEngine.GameObject EmptyGridCellTemplate { get; }
        public UnityEngine.GameObject EmptyBlockTemplate { get; }
        
        // Methods
        public static BlockPuzzleMagic.GameReferenceData get_Instance()
        {
            AppConfigs val_1 = App.Configuration;
            return (BlockPuzzleMagic.GameReferenceData)val_1.econConfig;
        }
        public BlockPuzzleMagic.ShapeBlockList get_ShapeBlockList()
        {
            return (BlockPuzzleMagic.ShapeBlockList)this.shapeBlockList;
        }
        public BlockPuzzleMagic.ShapeInfo get_PowerupBombShapeInfoPrefab()
        {
            return (BlockPuzzleMagic.ShapeInfo)this.powerupBombShapeInfoPrefab;
        }
        public BlockPuzzleMagic.ShapeInfo get_PowerupFillShapeInfoPrefab()
        {
            return (BlockPuzzleMagic.ShapeInfo)this.powerupFillShapeInfoPrefab;
        }
        public BlockPuzzleMagic.ShapeInfo get_PowerupTrashShapeInfoPrefab()
        {
            return (BlockPuzzleMagic.ShapeInfo)this.powerupTrashShapeInfoPrefab;
        }
        public BlockPuzzleMagic.ShapeInfo GetShapePrefabForPowerup(BlockPuzzleMagic.PowerUpType powerupType)
        {
            BlockPuzzleMagic.ShapeInfo val_1;
            if(powerupType == 0)
            {
                goto label_0;
            }
            
            if(powerupType == 2)
            {
                goto label_1;
            }
            
            if(powerupType != 1)
            {
                    return 0;
            }
            
            val_1 = this.powerupBombShapeInfoPrefab;
            return (BlockPuzzleMagic.ShapeInfo)mem[this.powerupFillShapeInfoPrefab];
            label_0:
            val_1 = this.powerupTrashShapeInfoPrefab;
            return (BlockPuzzleMagic.ShapeInfo)mem[this.powerupFillShapeInfoPrefab];
            label_1:
            val_1 = this.powerupFillShapeInfoPrefab;
            return (BlockPuzzleMagic.ShapeInfo)mem[this.powerupFillShapeInfoPrefab];
        }
        public UnityEngine.GameObject get_EmptyGridCellTemplate()
        {
            return (UnityEngine.GameObject)this.emptyGridCellTemplate;
        }
        public UnityEngine.GameObject get_EmptyBlockTemplate()
        {
            return (UnityEngine.GameObject)this.emptyBlockTemplate;
        }
        public BlockPuzzleMagic.BlockColor GetBlockColor(BlockPuzzleMagic.BlockColorType colorType)
        {
            var val_8;
            float val_9;
            float val_10;
            var val_11;
            .colorType = colorType;
            if(colorType == 1)
            {
                goto label_2;
            }
            
            if(colorType != 0)
            {
                goto label_3;
            }
            
            UnityEngine.Color val_2 = UnityEngine.Color.white;
            val_8 = val_2.r;
            val_9 = val_2.b;
            val_10 = val_2.a;
            BlockPuzzleMagic.BlockColor val_3 = null;
            val_11 = val_3;
            val_3 = new BlockPuzzleMagic.BlockColor();
            .blockColor = 0;
            .colorValue = val_2;
            mem[1152921520165712024] = val_2.g;
            goto label_4;
            label_2:
            UnityEngine.Color val_4 = UnityEngine.Color.white;
            val_8 = val_4.r;
            val_9 = val_4.b;
            val_10 = val_4.a;
            BlockPuzzleMagic.BlockColor val_5 = null;
            val_11 = val_5;
            val_5 = new BlockPuzzleMagic.BlockColor();
            .colorValue = val_4;
            mem[1152921520165716120] = val_4.g;
            .blockColor = 1;
            label_4:
            mem[1152921520165716124] = val_9;
            mem[1152921520165716128] = val_10;
            return (BlockPuzzleMagic.BlockColor)val_11;
            label_3:
            val_11 = this.blockColors.Find(match:  new System.Predicate<BlockPuzzleMagic.BlockColor>(object:  new GameReferenceData.<>c__DisplayClass22_0(), method:  System.Boolean GameReferenceData.<>c__DisplayClass22_0::<GetBlockColor>b__0(BlockPuzzleMagic.BlockColor obj)));
            return (BlockPuzzleMagic.BlockColor)val_11;
        }
        public GameReferenceData()
        {
            this.blockColors = new System.Collections.Generic.List<BlockPuzzleMagic.BlockColor>();
        }
    
    }

}
