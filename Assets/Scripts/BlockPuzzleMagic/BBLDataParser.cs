using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLDataParser : MonoSingletonSelfGenerating<BlockPuzzleMagic.BBLDataParser>
    {
        // Fields
        private int totalPredefinedLevels;
        private System.Collections.Generic.Dictionary<int, BlockPuzzleMagic.ChapterRef> chaptersReference;
        private BlockPuzzleMagic.ChapterRef tutorialChapter;
        private bool isInitialized;
        private const string PP_HasSynched = "PP_123j86_Sync";
        
        // Properties
        public int TotalPredefinedLevels { get; }
        public int TotalPredefinedChapters { get; }
        public BlockPuzzleMagic.ChapterRef TutorialChapter { get; }
        
        // Methods
        public int get_TotalPredefinedLevels()
        {
            return (int)this.totalPredefinedLevels;
        }
        public int get_TotalPredefinedChapters()
        {
            return this.chaptersReference.Count;
        }
        public BlockPuzzleMagic.ChapterRef get_TutorialChapter()
        {
            return (BlockPuzzleMagic.ChapterRef)this.tutorialChapter;
        }
        private void Start()
        {
            this.Initialize();
        }
        public void Initialize()
        {
            if(this.isInitialized == true)
            {
                    return;
            }
            
            this.LoadFromResources();
            this.LoadDataIntoMemory();
            UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
            this.isInitialized = true;
        }
        private void LoadData()
        {
            this.LoadFromResources();
            this.LoadDataIntoMemory();
        }
        private void LoadFromResources()
        {
            var val_21;
            var val_22;
            var val_23;
            string val_1 = DeviceIdPlugin.GetClientVersion();
            if((UnityEngine.PlayerPrefs.HasKey(key:  "PP_123j86_Sync")) != false)
            {
                    if((System.String.op_Inequality(a:  UnityEngine.PlayerPrefs.GetString(key:  "PP_123j86_Sync", defaultValue:  System.String.alignConst), b:  val_1)) == false)
            {
                    return;
            }
            
            }
            
            val_21 = null;
            val_21 = null;
            val_22 = 1152921504894226432;
            string val_6 = "/WordGame/Games/"("/WordGame/Games/") + App.game.ToString() + "/Levels/"("/Levels/");
            string val_7 = UnityEngine.Application.dataPath;
            val_23 = null;
            val_23 = null;
            string[] val_12 = new string[0];
            if(val_12.Length >= 1)
            {
                    var val_21 = 0;
                do
            {
                System.IO.File.WriteAllText(path:  UnityEngine.Application.persistentDataPath + "/"("/") + name + ".txt"(name + ".txt"), contents:  text);
                val_21 = val_21 + 1;
            }
            while(val_21 < val_12.Length);
            
            }
            
            UnityEngine.PlayerPrefs.SetString(key:  "PP_123j86_Sync", value:  val_1);
            bool val_20 = PrefsSerializationManager.SavePlayerPrefs();
        }
        private void LoadDataIntoMemory()
        {
            int val_8;
            int val_8 = val_2.Length;
            if(val_8 < 1)
            {
                goto label_2;
            }
            
            val_8 = 0;
            var val_9 = 0;
            val_8 = val_8 & 4294967295;
            label_14:
            BlockPuzzleMagic.ChapterRef val_4 = BlockPuzzleMagic.ChapterRef.Parse(_jsonString:  System.IO.File.ReadAllText(path:  null));
            if(val_4.chapterId <= 0)
            {
                goto label_5;
            }
            
            if((this.chaptersReference.ContainsKey(key:  val_4.chapterId)) == false)
            {
                goto label_8;
            }
            
            this.chaptersReference.set_Item(key:  val_4.chapterId, value:  val_4);
            goto label_9;
            label_5:
            this.tutorialChapter = val_4;
            goto label_10;
            label_8:
            this.chaptersReference.Add(key:  val_4.chapterId, value:  val_4);
            label_9:
            BlockPuzzleMagic.LevelRef val_6 = val_4.LastLevel;
            val_8 = UnityEngine.Mathf.Max(a:  0, b:  val_6.levelId);
            label_10:
            val_9 = val_9 + 1;
            if(val_9 < (val_2.Length << ))
            {
                goto label_14;
            }
            
            goto label_15;
            label_2:
            val_8 = 0;
            label_15:
            this.totalPredefinedLevels = val_8;
        }
        public BlockPuzzleMagic.ChapterRef GetPredefinedChapterDataFromLevel(int levelId)
        {
            var val_5;
            var val_6;
            int val_13;
            object val_14;
            BlockPuzzleMagic.ChapterRef val_15;
            object val_16;
            System.Predicate<BlockPuzzleMagic.LevelRef> val_18;
            val_13 = levelId;
            BBLDataParser.<>c__DisplayClass16_0 val_1 = null;
            val_14 = val_1;
            val_1 = new BBLDataParser.<>c__DisplayClass16_0();
            .levelId = val_13;
            if((BlockPuzzleMagic.BBLFtuxData.IsEligibleForCuratedFtuxLevels(playerLevel:  val_13)) != false)
            {
                    val_15 = this.tutorialChapter;
                return (BlockPuzzleMagic.ChapterRef)val_15;
            }
            
            Dictionary.Enumerator<TKey, TValue> val_3 = this.chaptersReference.GetEnumerator();
            label_15:
            val_16 = public System.Boolean Dictionary.Enumerator<System.Int32, BlockPuzzleMagic.ChapterRef>::MoveNext();
            if(val_6.MoveNext() == false)
            {
                goto label_7;
            }
            
            val_15 = val_5;
            if(val_15 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_16 = 0;
            if(val_15.FirstLevel == null)
            {
                    throw new NullReferenceException();
            }
            
            if(((BBLDataParser.<>c__DisplayClass16_0)[1152921520106145792].levelId) < val_8.levelId)
            {
                goto label_15;
            }
            
            val_16 = 0;
            if(val_15.LastLevel == null)
            {
                    throw new NullReferenceException();
            }
            
            if(((BBLDataParser.<>c__DisplayClass16_0)[1152921520106145792].levelId) > val_9.levelId)
            {
                goto label_15;
            }
            
            val_18 = (BBLDataParser.<>c__DisplayClass16_0)[1152921520106145792].<>9__0;
            val_13 = mem[val_5 + 24];
            val_13 = val_5 + 24;
            if(val_18 == null)
            {
                    System.Predicate<BlockPuzzleMagic.LevelRef> val_10 = null;
                val_18 = val_10;
                val_16 = val_14;
                val_10 = new System.Predicate<BlockPuzzleMagic.LevelRef>(object:  val_1, method:  System.Boolean BBLDataParser.<>c__DisplayClass16_0::<GetPredefinedChapterDataFromLevel>b__0(BlockPuzzleMagic.LevelRef obj));
                .<>9__0 = val_18;
            }
            
            if(val_13 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_13.Find(match:  val_10)) == null)
            {
                goto label_15;
            }
            
            goto label_16;
            label_7:
            val_15 = 0;
            label_16:
            val_6.Dispose();
            return (BlockPuzzleMagic.ChapterRef)val_15;
        }
        public BlockPuzzleMagic.ChapterRef GetPredefinedChapterFromChapterId(int chapterId)
        {
            var val_3;
            if((this.chaptersReference.ContainsKey(key:  chapterId)) != false)
            {
                    BlockPuzzleMagic.ChapterRef val_2 = this.chaptersReference.Item[chapterId];
                return (BlockPuzzleMagic.ChapterRef)val_3;
            }
            
            val_3 = 0;
            return (BlockPuzzleMagic.ChapterRef)val_3;
        }
        public BBLDataParser()
        {
            this.totalPredefinedLevels = 20;
            this.chaptersReference = new System.Collections.Generic.Dictionary<System.Int32, BlockPuzzleMagic.ChapterRef>();
        }
    
    }

}
