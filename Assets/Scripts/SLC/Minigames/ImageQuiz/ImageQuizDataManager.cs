using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizDataManager : MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>
    {
        // Fields
        private const string IMAGE_CDN_URL = "https://cdn.12gigs.com/mg/iq/";
        private const int INITIAL_LEVELS_TO_BATCH_LOAD = 2;
        private const int MINIMUM_IMAGE_COUNT_IN_CACHE = 5;
        private const int MAX_PER_IMAGE_DOWNLOAD_RETRIES = 1;
        private const int MAX_IMAGE_FAIL_ATTEMPTS_BEFORE_ABORT = 3;
        private System.Collections.Generic.List<SLC.Minigames.ImageQuiz.QuizLevelData> rawLevelDatas;
        private System.Collections.Generic.Queue<SLC.Minigames.ImageQuiz.ImageQuizLevelInfo> stageQuizLevels;
        private SLC.Minigames.ImageQuiz.QuizUserData userImageQuiz;
        private SLC.Minigames.ImageQuiz.DataLoaderState <DataLoaderState>k__BackingField;
        private bool isInitialized;
        private System.Collections.Generic.List<int> levelsLoadedButUnconsumed;
        private System.Collections.IEnumerator loadingCoroutine;
        public System.Action OnDataBegin;
        public System.Action<bool> OnDataLoaded;
        
        // Properties
        private static string LocalImageStoragePath { get; }
        public System.Collections.Generic.Queue<SLC.Minigames.ImageQuiz.ImageQuizLevelInfo> QuizLevels { get; }
        public SLC.Minigames.ImageQuiz.DataLoaderState DataLoaderState { get; set; }
        
        // Methods
        private static string get_LocalImageStoragePath()
        {
            return UnityEngine.Application.temporaryCachePath + "/imgquiz"("/imgquiz");
        }
        public System.Collections.Generic.Queue<SLC.Minigames.ImageQuiz.ImageQuizLevelInfo> get_QuizLevels()
        {
            return (System.Collections.Generic.Queue<SLC.Minigames.ImageQuiz.ImageQuizLevelInfo>)this.stageQuizLevels;
        }
        public SLC.Minigames.ImageQuiz.DataLoaderState get_DataLoaderState()
        {
            return (SLC.Minigames.ImageQuiz.DataLoaderState)this.<DataLoaderState>k__BackingField;
        }
        private void set_DataLoaderState(SLC.Minigames.ImageQuiz.DataLoaderState value)
        {
            this.<DataLoaderState>k__BackingField = value;
        }
        public void Init()
        {
            if(this.isInitialized == true)
            {
                    return;
            }
            
            new SLC.Minigames.ImageQuiz.ImageQuizDataParser().Init();
            this.LoadUserData();
            this.isInitialized = true;
        }
        public void SaveUserData()
        {
            bool val_2 = PlayerPrefsX.SetIntArray(key:  "IMAGEQUIZ:usedLevels", intArray:  this.userImageQuiz.usedLevels.ToArray());
            bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        }
        private void LoadUserData()
        {
            this.userImageQuiz.usedLevels.AddRange(collection:  PlayerPrefsX.GetIntArray(key:  "IMAGEQUIZ:usedLevels"));
        }
        public void StopLoading()
        {
            if(this.loadingCoroutine != null)
            {
                    this.StopCoroutine(routine:  this.loadingCoroutine);
                this.loadingCoroutine = 0;
            }
            
            this.<DataLoaderState>k__BackingField = 0;
        }
        public void LoadQuizLevels()
        {
            var val_5;
            if((this.<DataLoaderState>k__BackingField) == 1)
            {
                    return;
            }
            
            this.Init();
            this.<DataLoaderState>k__BackingField = 1;
            twelvegigs.Autopilot.AutopilotManager val_1 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            if((public static SLC.Minigames.ImageQuiz.ImageQuizMinigameManager MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizMinigameManager>::get_Instance()) != 0)
            {
                    val_5 = UnityEngine.Mathf.Max(a:  1, b:  5 - 41971712);
            }
            else
            {
                    val_5 = 2;
            }
            
            this.OnDataBegin.Invoke();
            System.Collections.IEnumerator val_4 = this.LoadQuizLevelsCoroutine(levelCount:  2);
            this.loadingCoroutine = val_4;
            UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  val_4);
        }
        private System.Collections.IEnumerator LoadQuizLevelsCoroutine(int levelCount)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .levelCount = levelCount;
            return (System.Collections.IEnumerator)new ImageQuizDataManager.<LoadQuizLevelsCoroutine>d__26();
        }
        public void AddLevel(SLC.Minigames.ImageQuiz.QuizLevelData level)
        {
            this.rawLevelDatas.Add(item:  level);
        }
        private SLC.Minigames.ImageQuiz.QuizUserData GetUserQuizData()
        {
            return (SLC.Minigames.ImageQuiz.QuizUserData)this.userImageQuiz;
        }
        private int FindLevelIndexOfWord(string word)
        {
            .word = word;
            return this.rawLevelDatas.FindIndex(match:  new System.Predicate<SLC.Minigames.ImageQuiz.QuizLevelData>(object:  new ImageQuizDataManager.<>c__DisplayClass29_0(), method:  System.Boolean ImageQuizDataManager.<>c__DisplayClass29_0::<FindLevelIndexOfWord>b__0(SLC.Minigames.ImageQuiz.QuizLevelData data)));
        }
        private SLC.Minigames.ImageQuiz.ImageQuizLevelInfo GenerateLevelInfo(string word, UnityEngine.Texture2D img)
        {
            int val_5;
            twelvegigs.Autopilot.AutopilotManager val_1 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            if((val_1.<AllowPurchases>k__BackingField) < true)
            {
                goto label_4;
            }
            
            if((val_1.<AllowPurchases>k__BackingField) < true)
            {
                goto label_5;
            }
            
            if((val_1.<AllowPurchases>k__BackingField) < true)
            {
                goto label_6;
            }
            
            if((val_1.<AllowPurchases>k__BackingField) < true)
            {
                goto label_7;
            }
            
            if((val_1.<AllowPurchases>k__BackingField) < true)
            {
                goto label_8;
            }
            
            var val_2 = ((val_1.<AllowPurchases>k__BackingField) > true) ? 21 : 18;
            goto label_13;
            label_4:
            val_5 = 8;
            goto label_13;
            label_5:
            val_5 = 10;
            goto label_13;
            label_6:
            val_5 = 12;
            goto label_13;
            label_7:
            val_5 = 14;
            goto label_13;
            label_8:
            val_5 = 16;
            label_13:
            .word = word.ToUpper();
            .imageTexture = img;
            .numberOfLetterButtons = val_5;
            return (SLC.Minigames.ImageQuiz.ImageQuizLevelInfo)new SLC.Minigames.ImageQuiz.ImageQuizLevelInfo();
        }
        public void ConsumeCurrentLevel()
        {
            SLC.Minigames.ImageQuiz.ImageQuizLevelInfo val_1 = this.stageQuizLevels.Dequeue();
            string[] val_2 = new string[1];
            val_2[0] = val_1.word;
            this.MarkWordsAsConsumed(words:  val_2, saveData:  true);
            this.LoadQuizLevels();
        }
        public void ClearAllQuizLevels()
        {
            this.stageQuizLevels.Clear();
        }
        private void MarkWordsAsConsumed(string[] words, bool saveData = True)
        {
            int val_4 = words.Length;
            if(val_4 >= 1)
            {
                    var val_5 = 0;
                val_4 = val_4 & 4294967295;
                do
            {
                int val_1 = this.FindLevelIndexOfWord(word:  null);
                this.userImageQuiz.usedLevels.Add(item:  val_1);
                if((this.levelsLoadedButUnconsumed.Contains(item:  val_1)) != false)
            {
                    bool val_3 = this.levelsLoadedButUnconsumed.Remove(item:  val_1);
            }
            
                val_5 = val_5 + 1;
            }
            while(val_5 < (words.Length << ));
            
            }
            
            if(saveData == false)
            {
                    return;
            }
            
            this.SaveUserData();
        }
        private void ResetLevelsPool(bool saveData = True)
        {
            this.userImageQuiz.usedLevels.Clear();
            if(saveData == false)
            {
                    return;
            }
            
            this.SaveUserData();
        }
        private SLC.Minigames.ImageQuiz.QuizLevelData[] GetUniqueLevelDatas(int amountOfLevels, System.Collections.Generic.List<int> filters)
        {
            var val_6;
            System.Collections.Generic.List<System.Int32> val_7;
            var val_8;
            System.Collections.Generic.List<System.Int32> val_6 = this.userImageQuiz.usedLevels;
            if(filters != null)
            {
                
            }
            else
            {
                    val_6 = 0;
            }
            
            val_6 = val_6 + val_6;
            if(val_6 >= this.rawLevelDatas)
            {
                    this.ResetLevelsPool(saveData:  true);
            }
            
            System.Collections.Generic.List<SLC.Minigames.ImageQuiz.QuizLevelData> val_1 = new System.Collections.Generic.List<SLC.Minigames.ImageQuiz.QuizLevelData>();
            System.Collections.Generic.List<System.Int32> val_2 = null;
            val_7 = val_2;
            val_2 = new System.Collections.Generic.List<System.Int32>();
            if(1152921510062986752 >= 1)
            {
                    do
            {
                if(0 >= 1152921510062986752)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2.Add(item:  -1552013584);
                val_8 = 0 + 1;
            }
            while(val_8 < 44419592);
            
            }
            
            if((filters != null) && (44419592 >= 1))
            {
                    val_8 = 1152921510479955696;
                var val_7 = 0;
                do
            {
                if(val_7 >= 44419592)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2.Add(item:  -1552013584);
                val_7 = val_7 + 1;
            }
            while(val_7 < 44419592);
            
            }
            
            System.Collections.Generic.List<System.Int32> val_4 = val_2.GetUniqueRandomValues(first:  0, last:  this.rawLevelDatas - 1, excludedFilter:  val_2, amount:  amountOfLevels);
            if(this.rawLevelDatas < 1)
            {
                    return val_1.ToArray();
            }
            
            val_7 = 1152921519930859968;
            var val_8 = 0;
            if(val_8 >= this.rawLevelDatas)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_1.Add(item:  mem[(1152921504687730688 + (System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg) << 3) + 32]);
            val_8 = val_8 + 1;
            return val_1.ToArray();
        }
        private System.Collections.Generic.List<int> GetUniqueRandomValues(int first, int last, System.Collections.Generic.List<int> excludedFilter, int amount)
        {
            RandomSet val_1 = new RandomSet();
            val_1.addIntRange(lowest:  first, highest:  last);
            if(1152921504858656768 >= 1)
            {
                    var val_4 = 0;
                do
            {
                if(val_4 >= 1152921504858656768)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1.use(item:  406867968);
                val_4 = val_4 + 1;
            }
            while(val_4 < 44364200);
            
            }
            
            System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
            if(amount < 1)
            {
                    return val_2;
            }
            
            var val_5 = 0;
            do
            {
                val_2.Add(item:  val_1.roll(unweighted:  false));
                val_5 = val_5 + 1;
            }
            while(val_5 < amount);
            
            return val_2;
        }
        public ImageQuizDataManager()
        {
            this.rawLevelDatas = new System.Collections.Generic.List<SLC.Minigames.ImageQuiz.QuizLevelData>();
            this.stageQuizLevels = new System.Collections.Generic.Queue<SLC.Minigames.ImageQuiz.ImageQuizLevelInfo>();
            this.userImageQuiz = new SLC.Minigames.ImageQuiz.QuizUserData();
            this.levelsLoadedButUnconsumed = new System.Collections.Generic.List<System.Int32>();
        }
    
    }

}
