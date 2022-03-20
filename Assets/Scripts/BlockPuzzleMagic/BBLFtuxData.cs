using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLFtuxData
    {
        // Fields
        public const int TUTORIAL_CHAPTER_ID = 0;
        public const int INITIAL_PLAYER_LEVEL_FTUX = 1;
        public static int PlayerFtuxLevel;
        public static readonly BlockPuzzleMagic.ChapterRef FtuxChapter;
        
        // Properties
        public static int MaxFtuxLevel { get; }
        private static BlockPuzzleMagic.ShapeInfoData blankShapePiece { get; }
        private static System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> usableBlockShapes1 { get; }
        private static System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> usableBlockShapes2 { get; }
        private static BlockPuzzleMagic.BlockData referenceBlockData1 { get; }
        private static BlockPuzzleMagic.BlockData referenceBlockData2 { get; }
        private static BlockPuzzleMagic.BlockData referenceBlockDataInteractableEmpty { get; }
        private static BlockPuzzleMagic.BlockData referenceBlockDataNonInteractable { get; }
        private static System.Collections.Generic.Dictionary<int, BlockPuzzleMagic.BlockData> referenceGridData1 { get; }
        private static System.Collections.Generic.Dictionary<int, BlockPuzzleMagic.BlockData> referenceGridData2 { get; }
        
        // Methods
        public static int get_MaxFtuxLevel()
        {
            BlockPuzzleMagic.BBLDataParser val_1 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance;
            BlockPuzzleMagic.LevelRef val_2 = val_1.tutorialChapter.LastLevel;
            return (int)val_2.levelId;
        }
        public static void CheckAddHardcodedFtuxStuffToLevel(int playerLevel, BlockPuzzleMagic.Level gameLevel)
        {
            BlockPuzzleMagic.BlockData val_16;
            var val_17;
            System.Collections.Generic.List<BlockPuzzleMagic.Goal> val_20;
            BlockPuzzleMagic.Goal val_21;
            var val_22;
            var val_23;
            BlockPuzzleMagic.BlockColorType val_24;
            BlockPuzzleMagic.CellImpedimentType val_25;
            if(((BlockPuzzleMagic.BBLFtuxData.IsEligibleForCuratedFtuxLevels(playerLevel:  playerLevel)) == false) || (gameLevel.levelId != 1))
            {
                goto label_5;
            }
            
            gameLevel.usableShapeIds = BlockPuzzleMagic.BBLFtuxData.usableBlockShapes1;
            val_17 = 1152921520181113376;
            var val_16 = 0;
            label_24:
            if(val_16 >= gameLevel.gridLayout.gridBlockData.Length)
            {
                goto label_10;
            }
            
            if((BlockPuzzleMagic.BBLFtuxData.referenceGridData1.ContainsKey(key:  0)) != false)
            {
                    BlockPuzzleMagic.BlockData val_6 = BlockPuzzleMagic.BBLFtuxData.referenceGridData1.Item[0];
            }
            
            gameLevel.gridLayout.gridBlockData[val_16] = BlockPuzzleMagic.BBLFtuxData.referenceBlockDataNonInteractable;
            val_16 = val_16 + 1;
            if(gameLevel.gridLayout != null)
            {
                goto label_24;
            }
            
            label_5:
            if((BlockPuzzleMagic.BBLFtuxData.IsEligibleForCuratedFtuxLevels(playerLevel:  playerLevel)) == false)
            {
                    return;
            }
            
            if(gameLevel.levelId != 2)
            {
                    return;
            }
            
            gameLevel.usableShapeIds = BlockPuzzleMagic.BBLFtuxData.usableBlockShapes2;
            val_17 = 1152921520181113376;
            var val_17 = 0;
            label_49:
            if(val_17 >= gameLevel.gridLayout.gridBlockData.Length)
            {
                goto label_35;
            }
            
            if((BlockPuzzleMagic.BBLFtuxData.referenceGridData2.ContainsKey(key:  0)) != false)
            {
                    BlockPuzzleMagic.BlockData val_13 = BlockPuzzleMagic.BBLFtuxData.referenceGridData2.Item[0];
            }
            
            val_16 = BlockPuzzleMagic.BBLFtuxData.referenceBlockDataNonInteractable;
            gameLevel.gridLayout.gridBlockData[val_17] = val_16;
            val_17 = val_17 + 1;
            if(gameLevel.gridLayout != null)
            {
                goto label_49;
            }
            
            throw new NullReferenceException();
            label_10:
            val_20 = gameLevel.goals;
            val_21 = new BlockPuzzleMagic.Goal();
            val_22 = 2;
            val_23 = 9999;
            val_24 = 0;
            val_25 = 0;
            goto label_50;
            label_35:
            gameLevel.gridLayout.SetFlagToGridDataNode(_gridDataIndex:  30, _nodeType:  4);
            gameLevel.gridLayout.SetFlagToGridDataNode(_gridDataIndex:  31, _nodeType:  4);
            gameLevel.gridLayout.SetFlagToGridDataNode(_gridDataIndex:  39, _nodeType:  4);
            gameLevel.gridLayout.SetFlagToGridDataNode(_gridDataIndex:  40, _nodeType:  4);
            val_20 = gameLevel.goals;
            BlockPuzzleMagic.Goal val_15 = null;
            val_21 = val_15;
            val_22 = 5;
            val_23 = 9999;
            val_25 = 1;
            val_24 = 0;
            label_50:
            val_15 = new BlockPuzzleMagic.Goal(_goalType:  5, _goalAmt:  15, _colorType:  val_24, _cellImpedimentType:  val_25);
            val_20.Add(item:  val_15);
        }
        public static bool IsFreeTutorialPowerupAvailable(BlockPuzzleMagic.PowerUpType powerupType)
        {
            return false;
        }
        public static bool IsEligibleForCuratedFtuxLevels(int playerLevel)
        {
            var val_3;
            if(playerLevel <= 1)
            {
                    BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
                var val_2 = ((val_1.tutorialCompleted & 4) != 0) ? 1 : 0;
                return (bool)val_3;
            }
            
            val_3 = 0;
            return (bool)val_3;
        }
        private static BlockPuzzleMagic.ShapeInfoData get_blankShapePiece()
        {
            .shapeId = 4294967295;
            .shapeColor = 0;
            return (BlockPuzzleMagic.ShapeInfoData)new BlockPuzzleMagic.ShapeInfoData();
        }
        private static System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> get_usableBlockShapes1()
        {
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> val_1 = new System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData>();
            val_1.Add(item:  BlockPuzzleMagic.BBLFtuxData.blankShapePiece);
            .shapeId = 9;
            .shapeColor = 2;
            val_1.Add(item:  new BlockPuzzleMagic.ShapeInfoData());
            .shapeId = 9;
            .shapeColor = 2;
            val_1.Add(item:  new BlockPuzzleMagic.ShapeInfoData());
            return val_1;
        }
        private static System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> get_usableBlockShapes2()
        {
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> val_1 = new System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData>();
            val_1.Add(item:  BlockPuzzleMagic.BBLFtuxData.blankShapePiece);
            .shapeId = 9;
            .shapeColor = 2;
            val_1.Add(item:  new BlockPuzzleMagic.ShapeInfoData());
            val_1.Add(item:  BlockPuzzleMagic.BBLFtuxData.blankShapePiece);
            return val_1;
        }
        private static BlockPuzzleMagic.BlockData get_referenceBlockData1()
        {
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> val_2 = BlockPuzzleMagic.BBLFtuxData.usableBlockShapes1;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            .fillColorType = BlockPuzzleMagic.BBLFtuxData.__il2cppRuntimeField_cctor_finished + 40 + 20;
            .breaksRequired = 0;
            return (BlockPuzzleMagic.BlockData)new BlockPuzzleMagic.BlockData();
        }
        private static BlockPuzzleMagic.BlockData get_referenceBlockData2()
        {
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> val_2 = BlockPuzzleMagic.BBLFtuxData.usableBlockShapes2;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            .fillColorType = BlockPuzzleMagic.BBLFtuxData.__il2cppRuntimeField_cctor_finished + 40 + 20;
            .breaksRequired = 0;
            return (BlockPuzzleMagic.BlockData)new BlockPuzzleMagic.BlockData();
        }
        private static BlockPuzzleMagic.BlockData get_referenceBlockDataInteractableEmpty()
        {
            .fillColorType = 0;
            return (BlockPuzzleMagic.BlockData)new BlockPuzzleMagic.BlockData();
        }
        private static BlockPuzzleMagic.BlockData get_referenceBlockDataNonInteractable()
        {
            .fillColorType = -4294967296;
            return (BlockPuzzleMagic.BlockData)new BlockPuzzleMagic.BlockData();
        }
        private static System.Collections.Generic.Dictionary<int, BlockPuzzleMagic.BlockData> get_referenceGridData1()
        {
            System.Collections.Generic.Dictionary<System.Int32, BlockPuzzleMagic.BlockData> val_1 = new System.Collections.Generic.Dictionary<System.Int32, BlockPuzzleMagic.BlockData>();
            val_1.Add(key:  3, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  4, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  12, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  13, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  18, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  19, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  20, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  25, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  26, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  27, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  28, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  29, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  30, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  31, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  32, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockDataInteractableEmpty);
            val_1.Add(key:  33, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockDataInteractableEmpty);
            val_1.Add(key:  34, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  35, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  38, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  39, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  40, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  41, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockDataInteractableEmpty);
            val_1.Add(key:  42, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockDataInteractableEmpty);
            val_1.Add(key:  43, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  44, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  48, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  49, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  52, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  57, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  58, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  65, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  66, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  67, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  68, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  74, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  75, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  76, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            val_1.Add(key:  77, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData1);
            return val_1;
        }
        private static System.Collections.Generic.Dictionary<int, BlockPuzzleMagic.BlockData> get_referenceGridData2()
        {
            System.Collections.Generic.Dictionary<System.Int32, BlockPuzzleMagic.BlockData> val_1 = new System.Collections.Generic.Dictionary<System.Int32, BlockPuzzleMagic.BlockData>();
            val_1.Add(key:  1, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  2, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  3, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  4, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  9, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  10, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  16, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  18, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  25, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  26, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  27, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  28, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  29, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  30, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  31, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  32, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockDataInteractableEmpty);
            val_1.Add(key:  33, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockDataInteractableEmpty);
            val_1.Add(key:  34, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  35, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  36, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  37, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  38, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  39, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  40, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  41, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockDataInteractableEmpty);
            val_1.Add(key:  42, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockDataInteractableEmpty);
            val_1.Add(key:  43, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  44, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  46, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            val_1.Add(key:  53, value:  BlockPuzzleMagic.BBLFtuxData.referenceBlockData2);
            return val_1;
        }
        public BBLFtuxData()
        {
        
        }
        private static BBLFtuxData()
        {
            BlockPuzzleMagic.BBLFtuxData.PlayerFtuxLevel = 1;
            .chapterId = 0;
            System.Collections.Generic.List<BlockPuzzleMagic.LevelRef> val_2 = new System.Collections.Generic.List<BlockPuzzleMagic.LevelRef>();
            .levelId = 1;
            .layoutId = 1;
            val_2.Add(item:  new BlockPuzzleMagic.LevelRef());
            .levelId = 2;
            .layoutId = 1;
            val_2.Add(item:  new BlockPuzzleMagic.LevelRef());
            .levels = val_2;
            BlockPuzzleMagic.BBLFtuxData.FtuxChapter = new BlockPuzzleMagic.ChapterRef();
        }
    
    }

}
