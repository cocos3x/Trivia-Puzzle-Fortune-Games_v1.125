using UnityEngine;

namespace BlockPuzzleMagic
{
    public class LevelManager : MonoSingletonSelfGenerating<BlockPuzzleMagic.LevelManager>
    {
        // Fields
        public const int DEFAULT_NORMAL_GRIDLAYOUT_ID = 1;
        private const int MAX_SHAPE_PIECE_WIDTH = 5;
        private const int MAX_SHAPE_PIECE_HEIGHT = 5;
        private const string PREFKEY_CHAPTER_DATA = "bbl_chapterdata";
        private const string PREFKEY_UNUSED_NORMAL_LAYOUTS = "bbl_avail_normlayid";
        private const string PREFKEY_UNUSED_STONE_LAYOUTS = "bbl_avail_stonlayid";
        private BlockPuzzleMagic.ChapterRef currentChapter;
        private System.Collections.Generic.List<int> unusedNormalGridLayoutIds;
        private System.Collections.Generic.List<int> unusedStoneGridLayoutIds;
        
        // Properties
        public static int PredefinedInitialLevelStart { get; }
        public static int PredefinedInitialLevelEnd { get; }
        public static int PredefinedStoneIntroLevelStart { get; }
        public static int PredefinedStoneIntroLevelEnd { get; }
        public static int PredefinedMetalIntroLevelStart { get; }
        public static int PredefinedMetalIntroLevelEnd { get; }
        public BlockPuzzleMagic.ChapterRef CurrentChapter { get; }
        
        // Methods
        public static int get_PredefinedInitialLevelStart()
        {
            return 1;
        }
        public static int get_PredefinedInitialLevelEnd()
        {
            return 18;
        }
        public static int get_PredefinedStoneIntroLevelStart()
        {
            null = null;
            string val_1 = BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS;
            val_1 = val_1 * BlockPuzzleMagic.BestBlocksGameEcon.proceduralCrateOnlyChapters;
            return (int)null;
        }
        public static int get_PredefinedStoneIntroLevelEnd()
        {
            var val_3 = null;
            string val_3 = BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS;
            val_3 = BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelStart + val_3;
            return (int)val_3 - 1;
        }
        public static int get_PredefinedMetalIntroLevelStart()
        {
            string val_2 = BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS;
            val_2 = BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd + (val_2 * BlockPuzzleMagic.BestBlocksGameEcon.proceduralCrateStoneOnlyChapters);
            return (int)null;
        }
        public static int get_PredefinedMetalIntroLevelEnd()
        {
            var val_3 = null;
            string val_3 = BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS;
            val_3 = BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelStart + val_3;
            return (int)val_3 - 1;
        }
        public BlockPuzzleMagic.ChapterRef get_CurrentChapter()
        {
            return (BlockPuzzleMagic.ChapterRef)this.currentChapter;
        }
        public static int GetChapterIdFromPlayerLevel(int playerLevel)
        {
            int val_22;
            int val_23;
            var val_24;
            string val_25;
            var val_26;
            var val_28;
            val_22 = playerLevel;
            if((MonoSingletonSelfGenerating<BlockPuzzleMagic.LevelManager>.Instance.IsPlayerWithinPredefinedLevels(playerLevel:  val_22)) != false)
            {
                    BlockPuzzleMagic.ChapterRef val_4 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  val_22);
                val_23 = val_4.chapterId;
                return (int)val_23;
            }
            
            if( && (BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelStart > val_22))
            {
                    BlockPuzzleMagic.ChapterRef val_8 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  18);
                val_22 = val_8.chapterId;
                val_24 = null;
                val_24 = null;
                val_25 = BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS;
                val_26 = val_22 + (UnityEngine.Mathf.FloorToInt(f:  (float)(val_22 - 19) / val_25));
            }
            else
            {
                    if((BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd < val_22) && (BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelStart > val_22))
            {
                    BlockPuzzleMagic.ChapterRef val_15 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd);
                val_25 = val_15.chapterId;
                int val_16 = BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd;
            }
            else
            {
                    BlockPuzzleMagic.ChapterRef val_19 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelEnd);
                val_25 = val_19.chapterId;
            }
            
                val_28 = null;
                val_28 = null;
                var val_22 = ~BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelEnd;
                val_22 = val_22 + val_22;
                val_22 = val_22 / BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS;
                val_26 = val_25 + (UnityEngine.Mathf.FloorToInt(f:  (float)val_22));
            }
            
            val_23 = val_26 + 1;
            return (int)val_23;
        }
        public static int GetLevelIdFromChapterId(int chapterNum)
        {
            int val_20;
            int val_21;
            int val_22;
            var val_23;
            var val_24;
            var val_25;
            var val_27;
            var val_28;
            BlockPuzzleMagic.ChapterRef val_2 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterFromChapterId(chapterId:  chapterNum);
            if(val_2 != null)
            {
                    BlockPuzzleMagic.LevelRef val_3 = val_2.FirstLevel;
                val_20 = val_3.levelId;
                return (int)val_28;
            }
            
            BlockPuzzleMagic.ChapterRef val_5 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  18);
            val_21 = val_5.chapterId;
            BlockPuzzleMagic.ChapterRef val_8 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelStart);
            BlockPuzzleMagic.ChapterRef val_11 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd);
            val_22 = val_11.chapterId;
            BlockPuzzleMagic.ChapterRef val_14 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelStart);
            BlockPuzzleMagic.ChapterRef val_17 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelEnd);
            if((val_21 < chapterNum) && (val_8.chapterId > chapterNum))
            {
                    val_23 = null;
                val_23 = null;
                var val_20 = ~val_21;
                val_20 = val_20 + chapterNum;
                string val_21 = BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS;
                val_21 = val_21 * val_20;
                return (int)val_28;
            }
            
            if((val_22 < chapterNum) && (val_14.chapterId > chapterNum))
            {
                    val_21 = 1152921505044172800;
                val_24 = BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd;
                val_25 = null;
                val_25 = null;
                val_27 = val_22;
                val_27 = ~val_22;
            }
            else
            {
                    val_21 = 1152921505044172800;
                val_24 = BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelEnd;
                val_28 = null;
                val_28 = null;
                val_27 = val_17.chapterId;
                val_27 = ~val_17.chapterId;
            }
            
            val_27 = val_27 + chapterNum;
            return (int)val_28;
        }
        private void Awake()
        {
            this.Initialize();
        }
        private void Initialize()
        {
            MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.Initialize();
            this.LoadChapterData();
            UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
        }
        private void LoadChapterData()
        {
            GameBehavior val_1 = App.getBehavior;
            if((val_1.<metaGameBehavior>k__BackingField.IsPlayerWithinPredefinedLevels(playerLevel:  val_1.<metaGameBehavior>k__BackingField)) != false)
            {
                    GameBehavior val_4 = App.getBehavior;
                BlockPuzzleMagic.ChapterRef val_5 = MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.GetPredefinedChapterDataFromLevel(levelId:  val_4.<metaGameBehavior>k__BackingField);
            }
            else
            {
                    string val_6 = UnityEngine.PlayerPrefs.GetString(key:  "bbl_chapterdata", defaultValue:  System.String.alignConst);
                if((System.String.IsNullOrEmpty(value:  val_6)) != false)
            {
                    BlockPuzzleMagic.ChapterRef val_8 = this.GenerateDynamicChapter();
                this.currentChapter = val_8;
                UnityEngine.PlayerPrefs.SetString(key:  "bbl_chapterdata", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_8));
                return;
            }
            
            }
            
            this.currentChapter = BlockPuzzleMagic.ChapterRef.Parse(_jsonString:  val_6);
        }
        public bool IsPlayerWithinPredefinedLevels(int playerLevel)
        {
            var val_6;
            if((playerLevel - 1) < 18)
            {
                    label_5:
                val_6 = 1;
                return (bool)val_6;
            }
            
            if(BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelStart <= playerLevel)
            {
                    if(BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd >= playerLevel)
            {
                goto label_5;
            }
            
            }
            
            if(BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelStart <= playerLevel)
            {
                    if(BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelEnd >= playerLevel)
            {
                goto label_5;
            }
            
            }
            
            val_6 = 0;
            return (bool)val_6;
        }
        public BlockPuzzleMagic.Level GetGameLevel(BlockPuzzleMagic.GameMode gameMode)
        {
            if(gameMode == 2)
            {
                    return this.GetGameLevelForChallengeMode();
            }
            
            UnityEngine.Debug.LogError(message:  "Unsupported game mode \'" + gameMode.ToString() + "\' retrieval attempt.");
            return 0;
        }
        private BlockPuzzleMagic.Level GetGameLevelForChallengeMode()
        {
            var val_10;
            var val_11;
            System.Predicate<BlockPuzzleMagic.LevelRef> val_13;
            var val_15;
            GameBehavior val_1 = App.getBehavior;
            if(this.currentChapter.chapterId != (BlockPuzzleMagic.LevelManager.GetChapterIdFromPlayerLevel(playerLevel:  val_1.<metaGameBehavior>k__BackingField)))
            {
                    UnityEngine.PlayerPrefs.DeleteKey(key:  "bbl_chapterdata");
                this.LoadChapterData();
            }
            
            val_10 = null;
            if(BestBlocksPlayer.Instance.IsFTUXGameLevels() == false)
            {
                goto label_9;
            }
            
            val_11 = null;
            val_13 = LevelManager.<>c.<>9__30_0;
            if(val_13 != null)
            {
                goto label_19;
            }
            
            System.Predicate<BlockPuzzleMagic.LevelRef> val_5 = null;
            val_13 = val_5;
            val_5 = new System.Predicate<BlockPuzzleMagic.LevelRef>(object:  LevelManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LevelManager.<>c::<GetGameLevelForChallengeMode>b__30_0(BlockPuzzleMagic.LevelRef obj));
            LevelManager.<>c.<>9__30_0 = val_13;
            if(this.currentChapter.levels != null)
            {
                goto label_15;
            }
            
            label_9:
            val_15 = null;
            val_13 = LevelManager.<>c.<>9__30_1;
            if(val_13 == null)
            {
                    System.Predicate<BlockPuzzleMagic.LevelRef> val_6 = null;
                val_13 = val_6;
                val_6 = new System.Predicate<BlockPuzzleMagic.LevelRef>(object:  LevelManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LevelManager.<>c::<GetGameLevelForChallengeMode>b__30_1(BlockPuzzleMagic.LevelRef obj));
                LevelManager.<>c.<>9__30_1 = val_13;
            }
            
            label_19:
            label_15:
            BlockPuzzleMagic.Level val_8 = BlockPuzzleMagic.LevelManager.CreateLevel(levelRef:  this.currentChapter.levels.Find(match:  val_6));
            GameBehavior val_9 = App.getBehavior;
            BlockPuzzleMagic.BBLFtuxData.CheckAddHardcodedFtuxStuffToLevel(playerLevel:  val_9.<metaGameBehavior>k__BackingField, gameLevel:  val_8);
            return val_8;
        }
        public static BlockPuzzleMagic.Level CreateLevel(BlockPuzzleMagic.LevelRef levelRef)
        {
            BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            BlockPuzzleMagic.Level val_2 = new BlockPuzzleMagic.Level();
            .gameMode = 2;
            .levelId = levelRef.levelId;
            int val_9 = levelRef.layoutId;
            val_9 = val_9 - 1;
            .gridLayout = new BlockPuzzleMagic.PlayerGridLayout(target:  val_1.gridLayoutDefinitions.GetGridLayoutsByType(layoutType:  1)[val_9]);
            if(levelRef.HasStone != false)
            {
                    int val_11 = levelRef.stoneLayoutId;
                val_11 = val_11 - 1;
                BlockPuzzleMagic.LevelManager.MergeSpecialLayoutToLevelLayout(baseLayout:  (BlockPuzzleMagic.Level)[1152921520190256272].gridLayout, specialLayout:  val_1.gridLayoutDefinitions.GetGridLayoutsByType(layoutType:  3)[val_11], specialLayoutFlag:  4);
            }
            
            BlockPuzzleMagic.LevelManager.AddGoalsToLevel(currentLevel:  val_2, levelRef:  levelRef);
            return val_2;
        }
        private int GetRandomNormalGridLayoutId()
        {
            System.Collections.Generic.List<System.Int32> val_14;
            System.Collections.Generic.List<System.Int32> val_15;
            var val_16;
            BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            val_14 = this.unusedNormalGridLayoutIds;
            if(val_14 != null)
            {
                    if(W9 > 0)
            {
                goto label_6;
            }
            
            }
            
            string val_2 = UnityEngine.PlayerPrefs.GetString(key:  "bbl_avail_normlayid", defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_2)) == false)
            {
                goto label_5;
            }
            
            val_14 = this.unusedNormalGridLayoutIds;
            if(val_14 != null)
            {
                goto label_6;
            }
            
            goto label_10;
            label_5:
            System.Collections.Generic.List<System.Int32> val_4 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.Int32>>(value:  val_2);
            val_14 = val_4;
            this.unusedNormalGridLayoutIds = val_4;
            if(val_14 == null)
            {
                goto label_10;
            }
            
            label_6:
            if(val_14 > 0)
            {
                goto label_15;
            }
            
            label_10:
            this.unusedNormalGridLayoutIds = new System.Collections.Generic.List<System.Int32>();
            var val_13 = 2;
            label_17:
            BlockPuzzleMagic.GridLayout[] val_7 = val_1.gridLayoutDefinitions.GetGridLayoutsByType(layoutType:  1);
            if(val_13 > val_7.Length)
            {
                goto label_15;
            }
            
            this.unusedNormalGridLayoutIds.Add(item:  2);
            val_13 = val_13 + 1;
            if(val_1.gridLayoutDefinitions != null)
            {
                goto label_17;
            }
            
            label_15:
            RandomSet val_9 = new RandomSet();
            val_9.addIntRange(lowest:  0, highest:  this.unusedNormalGridLayoutIds - 1);
            int val_11 = val_9.roll(unweighted:  false);
            val_15 = this.unusedNormalGridLayoutIds;
            if(this.unusedNormalGridLayoutIds > val_11)
            {
                    val_16 = this.unusedNormalGridLayoutIds + (val_11 << 2);
            }
            else
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_15 = this.unusedNormalGridLayoutIds;
                val_16 = X9 + (val_11 << 2);
            }
            
            val_16 = val_16 + 32;
            val_15.RemoveAt(index:  val_11);
            UnityEngine.PlayerPrefs.SetString(key:  "bbl_avail_normlayid", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.unusedNormalGridLayoutIds));
            return (int)val_16;
        }
        private int GetRandomStoneGridLayoutIndex()
        {
            System.Collections.Generic.List<System.Int32> val_12;
            System.Collections.Generic.List<System.Int32> val_13;
            var val_14;
            BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            val_12 = this.unusedStoneGridLayoutIds;
            if(val_12 != null)
            {
                    if(W9 > 0)
            {
                goto label_6;
            }
            
            }
            
            string val_2 = UnityEngine.PlayerPrefs.GetString(key:  "bbl_avail_stonlayid", defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_2)) == false)
            {
                goto label_5;
            }
            
            val_12 = this.unusedStoneGridLayoutIds;
            if(val_12 != null)
            {
                goto label_6;
            }
            
            goto label_10;
            label_5:
            System.Collections.Generic.List<System.Int32> val_4 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.Int32>>(value:  val_2);
            val_12 = val_4;
            this.unusedStoneGridLayoutIds = val_4;
            if(val_12 == null)
            {
                goto label_10;
            }
            
            label_6:
            if(W9 > 0)
            {
                goto label_15;
            }
            
            label_10:
            this.unusedStoneGridLayoutIds = new System.Collections.Generic.List<System.Int32>();
            var val_11 = 1;
            label_17:
            BlockPuzzleMagic.GridLayout[] val_7 = val_1.gridLayoutDefinitions.GetGridLayoutsByType(layoutType:  3);
            val_12 = this.unusedStoneGridLayoutIds;
            if(val_11 > val_7.Length)
            {
                goto label_15;
            }
            
            val_12.Add(item:  1);
            val_11 = val_11 + 1;
            if(val_1.gridLayoutDefinitions != null)
            {
                goto label_17;
            }
            
            label_15:
            int val_9 = UnityEngine.Random.Range(min:  0, max:  -2069959584);
            val_13 = this.unusedStoneGridLayoutIds;
            if(val_12 > val_9)
            {
                    val_14 = val_12 + (val_9 << 2);
            }
            else
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_13 = this.unusedStoneGridLayoutIds;
                val_14 = X9 + (val_9 << 2);
            }
            
            val_14 = val_14 + 32;
            val_13.RemoveAt(index:  val_9);
            UnityEngine.PlayerPrefs.SetString(key:  "bbl_avail_stonlayid", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.unusedStoneGridLayoutIds));
            return (int)val_14;
        }
        private BlockPuzzleMagic.ChapterRef GenerateDynamicChapter()
        {
            var val_25;
            var val_26;
            System.Collections.Generic.List<BlockPuzzleMagic.LevelRef> val_27;
            var val_28;
            var val_30;
            var val_31;
            var val_32;
            var val_33;
            BlockPuzzleMagic.CellImpedimentType val_34;
            val_25 = 0;
            MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>.Instance.Initialize();
            BlockPuzzleMagic.BestBlocksGameEcon val_2 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            Player val_3 = App.Player;
            if(val_3 != null)
            {
                    val_25 = null;
            }
            
            val_26 = null;
            val_26 = null;
            int val_4 = BlockPuzzleMagic.LevelManager.GetChapterIdFromPlayerLevel(playerLevel:  val_3);
            .chapterId = val_4;
            System.Collections.Generic.List<BlockPuzzleMagic.LevelRef> val_7 = new System.Collections.Generic.List<BlockPuzzleMagic.LevelRef>();
            .levels = val_7;
            if(BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS < 1)
            {
                goto label_21;
            }
            
            var val_26 = 0;
            label_22:
            val_7.Add(item:  new BlockPuzzleMagic.LevelRef());
            if(1152921520183612832 <= val_26)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_26 = val_26 + 1;
            public WGWindowManager SLCWindowManager<WGWindowManager>::ShowUGUIMonolith<WADPetsFtuxPopup>(bool showNext).__il2cppRuntimeField_10 = (BlockPuzzleMagic.LevelManager.GetLevelIdFromChapterId(chapterNum:  val_4)) + val_26;
            if(val_26 >= BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS)
            {
                goto label_21;
            }
            
            BlockPuzzleMagic.LevelRef val_10 = new BlockPuzzleMagic.LevelRef();
            if((BlockPuzzleMagic.ChapterRef)[1152921520191176176].levels != null)
            {
                goto label_22;
            }
            
            label_21:
            mem2[0] = 0;
            RandomSet val_11 = null;
            val_27 = val_11;
            val_11 = new RandomSet();
            val_11.addIntRange(lowest:  0, highest:  (BlockPuzzleMagic.ChapterRef)[1152921520191176176].levels - 1);
            int val_27 = val_2.normalGridsPerChapter;
            if(val_27 >= 1)
            {
                    var val_28 = 0;
                do
            {
                int val_13 = val_11.roll(unweighted:  false);
                if(val_27 <= val_13)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_27 = val_27 + (val_13 << 3);
                mem2[0] = 1;
                int val_29 = val_2.normalGridsPerChapter;
                val_28 = val_28 + 1;
            }
            while(val_28 < val_29);
            
            }
            
            val_28 = 0;
            int val_14 = val_11.count();
            if(val_14 >= 1)
            {
                    var val_30 = 0;
                do
            {
                val_28 = 0;
                int val_15 = val_11.roll(unweighted:  false);
                if(val_29 <= val_15)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_29 = val_29 + (val_15 << 3);
                val_30 = val_30 + 1;
                mem2[0] = this.GetRandomNormalGridLayoutId();
            }
            while(val_30 < val_14);
            
            }
            
            if((val_3 >= 19) && (val_3 < BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelStart))
            {
                    val_30 = 0;
                val_31 = 1;
            }
            else
            {
                    if((val_3 > BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd) && (val_3 < BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelStart))
            {
                    RandomSet val_20 = null;
                val_30 = val_20;
                val_20 = new RandomSet();
                .replacement = true;
                val_20.add(item:  1, weight:  50f);
                val_32 = 2;
            }
            else
            {
                    RandomSet val_21 = null;
                val_30 = val_21;
                val_21 = new RandomSet();
                .replacement = true;
                val_21.add(item:  1, weight:  40f);
                val_21.add(item:  2, weight:  40f);
                val_32 = 3;
            }
            
                val_21.add(item:  3, weight:  20f);
                val_31 = 0;
            }
            
            val_33 = 4;
            do
            {
                var val_22 = val_33 - 4;
                if(val_22 >= (BlockPuzzleMagic.ChapterRef)[1152921520191176176].levels)
            {
                    return (BlockPuzzleMagic.ChapterRef)new BlockPuzzleMagic.ChapterRef();
            }
            
                val_34 = val_31;
                if(val_31 == 0)
            {
                    val_34 = val_21.roll(unweighted:  false);
            }
            
                .goalType = 5;
                .impedimentType = val_34;
                .targetValue = 0;
                if(5 <= val_22)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                mem[702432774455320] = new System.Collections.Generic.List<BlockPuzzleMagic.GoalRef>();
                val_27 = (BlockPuzzleMagic.ChapterRef)[1152921520191176176].levels;
                if(1152921504687730688 <= val_22)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                public static SLC.Minigames.WordChain.WordChainManager MonoSingleton<SLC.Minigames.WordChain.WordChainManager>::get_Instance().__il2cppRuntimeField_18.Add(item:  new BlockPuzzleMagic.GoalRef());
                if((public static SLC.Minigames.WordChain.WordChainManager MonoSingleton<SLC.Minigames.WordChain.WordChainManager>::get_Instance()) <= val_22)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                this.SetSpecialLayoutIdToLevelRef(baseLevel:  public static SLC.Minigames.WordChain.WordChainManager MonoSingleton<SLC.Minigames.WordChain.WordChainManager>::get_Instance().__il2cppRuntimeField_20, specialLayoutFlag:  4);
                val_33 = val_33 + 1;
            }
            while((BlockPuzzleMagic.ChapterRef)[1152921520191176176].levels != null);
            
            throw new NullReferenceException();
        }
        private void SetSpecialLayoutIdToLevelRef(BlockPuzzleMagic.LevelRef baseLevel, BlockPuzzleMagic.GridLayout.NodeType specialLayoutFlag)
        {
            NodeType val_5 = specialLayoutFlag;
            BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            if(val_5 != 4)
            {
                    return;
            }
            
            val_5 = this.GetRandomStoneGridLayoutIndex();
            var val_5 = 0;
            label_6:
            if((BlockPuzzleMagic.LevelManager.CheckEntireRowColumnCompatible(baseLayoutId:  baseLevel.layoutId, specialLayoutId:  val_5, specialLayoutFlag:  4)) == true)
            {
                goto label_5;
            }
            
            val_5 = val_5 + 1;
            val_5 = this.GetRandomStoneGridLayoutIndex();
            if(val_5 <= 5000)
            {
                goto label_6;
            }
            
            return;
            label_5:
            if(val_5 < 1)
            {
                    return;
            }
            
            baseLevel.stoneLayoutId = val_5;
        }
        public static bool CheckEntireRowColumnCompatible(int baseLayoutId, int specialLayoutId, BlockPuzzleMagic.GridLayout.NodeType specialLayoutFlag)
        {
            var val_40;
            BlockPuzzleMagic.GridLayout val_41;
            var val_42;
            var val_43;
            var val_44;
            int val_45;
            var val_46;
            var val_47;
            var val_48;
            var val_49;
            var val_51;
            var val_52;
            var val_53;
            var val_54;
            val_40 = specialLayoutFlag;
            val_41 = specialLayoutId;
            if(val_40 == 1)
            {
                    val_42 = 1;
                return (bool)val_42 & 1;
            }
            
            BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            BlockPuzzleMagic.GridLayout[] val_4 = val_1.gridLayoutDefinitions.GetGridLayoutsByType(layoutType:  (val_40 == 4) ? 3 : 0);
            if(val_4 == null)
            {
                goto label_45;
            }
            
            val_40 = val_4;
            val_41 = val_1.gridLayoutDefinitions.GetGridLayoutsByType(layoutType:  1)[baseLayoutId - 1];
            BlockPuzzleMagic.GridLayout val_39 = val_40[val_41 - 1];
            if(val_41.rowCount < 1)
            {
                goto label_13;
            }
            
            val_43 = 0;
            val_44 = 0;
            label_28:
            val_45 = val_6[(baseLayoutId - 1)][0].columnCount;
            if(val_45 < 1)
            {
                goto label_14;
            }
            
            val_46 = 0;
            val_47 = 0;
            val_48 = 0;
            var val_41 = 0;
            label_24:
            int val_10 = val_41 + (0 * val_45);
            bool val_11 = val_41.IsFlagSetOnGridDataNode(_gridDataIndex:  val_10, _nodeType:  0);
            int val_40 = val_4[(specialLayoutId - 1)][0].gridData[val_10];
            val_49 = 0 + val_11;
            if(val_11 == false)
            {
                goto label_18;
            }
            
            var val_13 = (val_40 == 1) ? 1 : 0;
            val_13 = val_13 & val_11 ^ 1;
            val_44 = val_44 + val_13;
            goto label_20;
            label_18:
            bool val_15 = val_11 ^ 1;
            var val_16 = (val_40 == 1) ? 1 : 0;
            val_15 = val_16 & val_15;
            var val_18 = (val_40 != 1) ? (val_46 + 1) : (val_46);
            val_16 = val_11 | val_16;
            val_44 = val_44 + val_15;
            if(val_16 == true)
            {
                goto label_20;
            }
            
            val_45 = val_6[(baseLayoutId - 1)][0].columnCount;
            val_51 = val_45 - 1;
            if(val_41 < val_51)
            {
                goto label_21;
            }
            
            label_20:
            val_45 = val_6[(baseLayoutId - 1)][0].columnCount;
            val_47 = UnityEngine.Mathf.Max(a:  (val_40 != 1) ? (val_48 + 1) : (val_48), b:  0);
            val_40 = 0;
            val_51 = val_45 - 1;
            label_21:
            var val_20 = (val_41 >= val_51) ? 1 : 0;
            val_41 = val_41 + 1;
            val_20 = ((val_47 > 4) ? 1 : 0) & val_20;
            val_43 = val_43 | val_20;
            if(val_41 < val_45)
            {
                goto label_24;
            }
            
            goto label_25;
            label_14:
            val_46 = 0;
            val_49 = 0;
            label_25:
            if(val_46 <= 0)
            {
                    if(val_49 < val_45)
            {
                goto label_45;
            }
            
            }
            
            var val_42 = 0;
            val_42 = val_42 + 1;
            if(val_42 < val_41.rowCount)
            {
                goto label_28;
            }
            
            goto label_29;
            label_13:
            val_44 = 0;
            val_43 = 0;
            label_29:
            val_42 = 0;
            if(((val_43 & 1) == 0) || (val_44 < 1))
            {
                    return (bool)val_42 & 1;
            }
            
            if((val_6[(baseLayoutId - 1)][0].columnCount) < 1)
            {
                goto label_45;
            }
            
            val_42 = 0;
            var val_44 = 0;
            label_46:
            if(val_41.rowCount < 1)
            {
                goto label_33;
            }
            
            val_52 = 0;
            val_53 = 0;
            val_54 = 0;
            label_42:
            int val_24 = val_44 + ((val_6[(baseLayoutId - 1)][0].columnCount) * 0);
            bool val_25 = val_41.IsFlagSetOnGridDataNode(_gridDataIndex:  val_24, _nodeType:  0);
            val_46 = 0 + val_25;
            if(val_25 != true)
            {
                    int val_43 = val_4[(specialLayoutId - 1)][0].gridData[val_24];
                if(val_43 != 1)
            {
                    if(0 < (val_41.rowCount - 1))
            {
                goto label_39;
            }
            
            }
            
            }
            
            val_53 = UnityEngine.Mathf.Max(a:  (val_43 != 1) ? (val_54 + 1) : (val_54), b:  0);
            val_40 = 0;
            label_39:
            var val_34 = (0 >= (val_41.rowCount - 1)) ? 1 : 0;
            val_34 = ((val_53 > 4) ? 1 : 0) & val_34;
            val_42 = val_42 | val_34;
            val_43 = 0 + 1;
            if(val_43 < val_41.rowCount)
            {
                goto label_42;
            }
            
            if(((val_43 != 1) ? (val_52 + 1) : (val_52)) > 0)
            {
                goto label_43;
            }
            
            goto label_44;
            label_33:
            val_46 = 0;
            label_44:
            if(val_46 < val_41.rowCount)
            {
                goto label_45;
            }
            
            label_43:
            val_44 = val_44 + 1;
            if(val_44 < (val_6[(baseLayoutId - 1)][0].columnCount))
            {
                goto label_46;
            }
            
            return (bool)val_42 & 1;
            label_45:
            val_42 = 0;
            return (bool)val_42 & 1;
        }
        private static void MergeSpecialLayoutToLevelLayout(BlockPuzzleMagic.GridLayout baseLayout, BlockPuzzleMagic.GridLayout specialLayout, BlockPuzzleMagic.GridLayout.NodeType specialLayoutFlag)
        {
            var val_3 = 0;
            do
            {
                if(val_3 >= specialLayout.gridData.Length)
            {
                    return;
            }
            
                if((val_3 < baseLayout.gridData.Length) && (((baseLayout.IsFlagSetOnGridDataNode(_gridDataIndex:  0, _nodeType:  0)) != true) && (specialLayoutFlag == 4)))
            {
                    if(specialLayout.gridData[val_3] == 1)
            {
                    baseLayout.SetFlagToGridDataNode(_gridDataIndex:  0, _nodeType:  4);
            }
            
            }
            
                val_3 = val_3 + 1;
            }
            while(specialLayout.gridData != null);
            
            throw new NullReferenceException();
        }
        private static void AddGoalsToLevel(BlockPuzzleMagic.Level currentLevel, BlockPuzzleMagic.LevelRef levelRef)
        {
            System.Collections.Generic.List<BlockPuzzleMagic.GoalRef> val_10;
            var val_11;
            System.Predicate<BlockPuzzleMagic.GoalRef> val_13;
            var val_14;
            var val_15;
            var val_16;
            BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            Player val_2 = App.Player;
            if(levelRef.HasStone != false)
            {
                    val_10 = levelRef.goals;
                val_11 = null;
                val_11 = null;
                val_13 = LevelManager.<>c.<>9__38_0;
                if(val_13 == null)
            {
                    System.Predicate<BlockPuzzleMagic.GoalRef> val_4 = null;
                val_13 = val_4;
                val_4 = new System.Predicate<BlockPuzzleMagic.GoalRef>(object:  LevelManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LevelManager.<>c::<AddGoalsToLevel>b__38_0(BlockPuzzleMagic.GoalRef g));
                LevelManager.<>c.<>9__38_0 = val_13;
            }
            
                if((val_10.Find(match:  val_4)) == null)
            {
                    val_10 = levelRef.goals;
                .targetValue = 0;
                .goalType = 2.47032822920623E-323;
                val_10.Add(item:  new BlockPuzzleMagic.GoalRef());
            }
            
            }
            
            currentLevel.goals = new System.Collections.Generic.List<BlockPuzzleMagic.Goal>();
            if(levelRef.goals == null)
            {
                    return;
            }
            
            if(1152921520192382256 < 1)
            {
                    return;
            }
            
            if(1152921520192382256 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_15 = public System.Boolean System.Collections.Generic.Dictionary<System.Object, UnityEngine.Color>::Remove(System.Object key);
            if(1152921520192382256 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_15 = public System.Boolean System.Collections.Generic.Dictionary<System.Object, UnityEngine.Color>::Remove(System.Object key);
            }
            
            public System.Boolean System.Collections.Generic.Dictionary<System.Object, UnityEngine.Color>::Remove(System.Object key).__il2cppRuntimeField_18 = currentLevel.gridLayout.GetNodeTypeGridCount(_nodeType:  4);
            if(1152921520192382256 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_16 = public System.Boolean System.Collections.Generic.Dictionary<System.Object, UnityEngine.Color>::Remove(System.Object key);
            if(1152921520192359728 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            BlockPuzzleMagic.Goal val_9 = null;
            val_10 = val_9;
            val_9 = new BlockPuzzleMagic.Goal();
            .goalType = public System.Boolean System.Collections.Generic.Dictionary<System.Object, UnityEngine.Color>::Remove(System.Object key).__il2cppRuntimeField_10;
            .targetValue = public System.Boolean System.Collections.Generic.Dictionary<System.Object, UnityEngine.Color>::Remove(System.Object key).__il2cppRuntimeField_18;
            .currentValue = 0;
            .goalColorValue = 0;
            .impedimentType = public System.Boolean System.Collections.Generic.Dictionary<System.Object, UnityEngine.Color>::Remove(System.Object key).__il2cppRuntimeField_20 + 20;
            currentLevel.goals.Add(item:  val_9);
            val_14 = 4 + 1;
            var val_10 = val_14 - 4;
        }
        public LevelManager()
        {
        
        }
    
    }

}
