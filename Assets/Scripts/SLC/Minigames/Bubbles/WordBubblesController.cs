using UnityEngine;

namespace SLC.Minigames.Bubbles
{
    public class WordBubblesController : MonoSingleton<SLC.Minigames.Bubbles.WordBubblesController>
    {
        // Fields
        private System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesCategory> categoryWords;
        private System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesLevelData> levelDatas;
        private System.Collections.Generic.Queue<SLC.Minigames.Bubbles.WordBubblesCategory> playedLevel;
        private int <CurrentLevelIndex>k__BackingField;
        private SLC.Minigames.Bubbles.WordBubblesLevel <CurrentLevel>k__BackingField;
        private bool initialized;
        private bool <toturalLevel>k__BackingField;
        public bool IsGameOver;
        public bool IsLevelFinish;
        private float <totalTime>k__BackingField;
        private float timer;
        private int remainLives;
        private int <FirstLevelCurrentIndex>k__BackingField;
        
        // Properties
        public int CurrentLevelIndex { get; set; }
        public SLC.Minigames.Bubbles.WordBubblesLevel CurrentLevel { get; set; }
        public bool toturalLevel { get; set; }
        private float totalTime { get; set; }
        public int FirstLevelCurrentIndex { get; set; }
        
        // Methods
        public int get_CurrentLevelIndex()
        {
            return (int)this.<CurrentLevelIndex>k__BackingField;
        }
        private void set_CurrentLevelIndex(int value)
        {
            this.<CurrentLevelIndex>k__BackingField = value;
        }
        public SLC.Minigames.Bubbles.WordBubblesLevel get_CurrentLevel()
        {
            return (SLC.Minigames.Bubbles.WordBubblesLevel)this.<CurrentLevel>k__BackingField;
        }
        private void set_CurrentLevel(SLC.Minigames.Bubbles.WordBubblesLevel value)
        {
            this.<CurrentLevel>k__BackingField = value;
        }
        public bool get_toturalLevel()
        {
            return (bool)this.<toturalLevel>k__BackingField;
        }
        private void set_toturalLevel(bool value)
        {
            this.<toturalLevel>k__BackingField = value;
        }
        private float get_totalTime()
        {
            return (float)this.<totalTime>k__BackingField;
        }
        private void set_totalTime(float value)
        {
            this.<totalTime>k__BackingField = value;
        }
        public int get_FirstLevelCurrentIndex()
        {
            return (int)this.<FirstLevelCurrentIndex>k__BackingField;
        }
        private void set_FirstLevelCurrentIndex(int value)
        {
            this.<FirstLevelCurrentIndex>k__BackingField = value;
        }
        private void Update()
        {
            if(this.IsGameOver == true)
            {
                    return;
            }
            
            if(this.IsLevelFinish == true)
            {
                    return;
            }
            
            float val_1 = UnityEngine.Time.deltaTime;
            val_1 = this.timer - val_1;
            this.timer = val_1;
            SLC.Minigames.Bubbles.WordBubblesUIController val_2 = MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance;
            float val_3 = this.<totalTime>k__BackingField;
            val_3 = this.timer / val_3;
            val_3 = 1f - val_3;
            if(this.timer > 0f)
            {
                    return;
            }
            
            this.GameOver();
        }
        private void Initialize()
        {
            if(this.initialized != false)
            {
                    return;
            }
            
            this.LoadCategoryData();
            this.LoadLevelData();
            this.<toturalLevel>k__BackingField = true;
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_1.OnRestartMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.Bubbles.WordBubblesController::StartLevel());
            SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_3.OnContinueMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.Bubbles.WordBubblesController::StartLevel());
            this.StartLevel();
            this.initialized = true;
            UnityEngine.Debug.LogError(message:  "Controller has been initialized");
        }
        private void StartLevel()
        {
            int val_11;
            var val_12;
            bool val_11 = this.<toturalLevel>k__BackingField;
            if(val_11 == false)
            {
                goto label_1;
            }
            
            if(val_11 <= (this.<CurrentLevelIndex>k__BackingField))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_11 = val_11 + ((this.<CurrentLevelIndex>k__BackingField) << 3);
            string[] val_1 = new string[2];
            val_11 = val_1.Length;
            val_1[0] = "GREEN";
            val_11 = val_1.Length;
            val_1[1] = "BLUE";
            this.<CurrentLevel>k__BackingField = new SLC.Minigames.Bubbles.WordBubblesLevel(levelData:  (this.<toturalLevel>k__BackingField + (this.<CurrentLevelIndex>k__BackingField) << 3) + 32, words:  val_1);
            this.<FirstLevelCurrentIndex>k__BackingField = 0;
            goto label_11;
            label_1:
            if(val_11 >= true)
            {
                    SLC.Minigames.Bubbles.WordBubblesCategory val_3 = this.playedLevel.Dequeue();
            }
            
            System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesCategory> val_12 = this.categoryWords;
            val_12 = UnityEngine.Random.Range(min:  0, max:  -1948579024);
            label_20:
            if(val_12 <= val_12)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_12 = val_12 + (((long)(int)(val_4)) << 3);
            if((this.playedLevel.Contains(item:  public SLC.Minigames.Bubbles.WordBubblesCategory System.Collections.Generic.Queue<SLC.Minigames.Bubbles.WordBubblesCategory>::Dequeue())) == false)
            {
                goto label_18;
            }
            
            System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesCategory> val_13 = this.categoryWords;
            val_12 = UnityEngine.Random.Range(min:  0, max:  -1948579024);
            if(this.categoryWords != null)
            {
                goto label_20;
            }
            
            throw new NullReferenceException();
            label_18:
            if(val_13 <= (this.<CurrentLevelIndex>k__BackingField))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_13 = val_13 + ((this.<CurrentLevelIndex>k__BackingField) << 3);
            if(W9 <= val_12)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_13 = val_13 + (((long)(int)(val_4)) << 3);
            this.<CurrentLevel>k__BackingField = new SLC.Minigames.Bubbles.WordBubblesLevel(levelData:  this.<CurrentLevelIndex>k__BackingField, category:  this.levelDatas);
            if(val_13 <= val_12)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_13 = val_13 + (((long)(int)(val_4)) << 3);
            this.playedLevel.Enqueue(item:  this.<CurrentLevelIndex>k__BackingField);
            label_11:
            this.IsGameOver = false;
            this.IsLevelFinish = false;
            if(val_13 <= (this.<CurrentLevelIndex>k__BackingField))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_13 = val_13 + ((this.<CurrentLevelIndex>k__BackingField) << 3);
            this.<totalTime>k__BackingField = val_13;
            this.timer = val_13;
            this.<CurrentLevelIndex>k__BackingField = (this.<CurrentLevelIndex>k__BackingField) + 1;
            MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance.StartLevel(currentLevel:  this.<CurrentLevel>k__BackingField);
            if((this.<toturalLevel>k__BackingField) == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance.PointTo(bubbleIndex:  this.<FirstLevelCurrentIndex>k__BackingField);
        }
        private void LoadCategoryData()
        {
            System.Collections.Generic.List<T> val_18;
            System.String[] val_19;
            System.String[] val_20;
            var val_21;
            System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesCategory> val_3 = null;
            val_18 = val_3;
            val_3 = new System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesCategory>();
            mem[1152921519838602104] = val_18;
            char[] val_4 = new char[1];
            val_4[0] = '
            ';
            val_19 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordBubbles/WordGameCategoriesCategories").text.Split(separator:  val_4);
            if(val_5.Length < 2)
            {
                    return;
            }
            
            do
            {
                System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_6 = null;
                val_18 = val_6;
                val_6 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>();
                char[] val_7 = new char[1];
                val_7[0] = ',';
                val_20 = val_19[1].Split(separator:  val_7);
                if(val_8.Length >= 2)
            {
                    var val_24 = 1;
                do
            {
                char[] val_10 = new char[1];
                val_10[0] = '-';
                int val_13 = val_24 + 2;
                val_6.set_Item(key:  val_13, value:  new System.Collections.Generic.List<System.String>());
                if(val_11.Length >= 1)
            {
                    var val_23 = 0;
                do
            {
                val_21 = mem[public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302];
                val_21 = public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302;
                val_21 = mem[public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302];
                val_21 = public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302;
                val_6.Item[val_13].Add(item:  val_20[val_24].Split(separator:  val_10)[val_23].ToUpper().Replace(oldChar:  '', newChar:  ' ').TrimEnd(trimChars:  public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 184));
                val_23 = val_23 + 1;
            }
            while(val_23 < val_11.Length);
            
            }
            
                val_20 = val_20;
                val_24 = val_24 + 1;
            }
            while(val_24 < (val_8 + 24));
            
            }
            
                .<Category>k__BackingField = val_20[0].ToUpper();
                .<LetterWordsDic>k__BackingField = val_18;
                val_3.Add(item:  new SLC.Minigames.Bubbles.WordBubblesCategory());
                val_19 = val_19;
            }
            while(2 < (val_5 + 24));
        
        }
        public void LoadLevelData()
        {
            System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesLevelData> val_13;
            float val_14;
            System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesLevelData> val_3 = null;
            val_13 = val_3;
            val_3 = new System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesLevelData>();
            this.levelDatas = val_13;
            char[] val_4 = new char[1];
            val_4[0] = '
            ';
            if(val_5.Length < 2)
            {
                    return;
            }
            
            var val_18 = 1;
            do
            {
                char[] val_6 = new char[1];
                val_6[0] = ',';
                System.String[] val_7 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordBubbles/WordBubblesLevelData").text.Split(separator:  val_4)[val_18].Split(separator:  val_6);
                val_13 = System.Int32.Parse(s:  val_7[0]);
                val_14 = 3.402823E+38f;
                if((val_7[1].Contains(value:  "&")) != true)
            {
                    val_14 = System.Single.Parse(s:  val_7[1]);
            }
            
                .<LevelIndex>k__BackingField = val_13;
                .<TimeLength>k__BackingField = val_14;
                .<FragmentsCount>k__BackingField = System.Int32.Parse(s:  val_7[2]);
                this.levelDatas.Add(item:  new SLC.Minigames.Bubbles.WordBubblesLevelData());
                val_18 = val_18 + 1;
            }
            while(val_18 < val_5.Length);
        
        }
        public void CheckTotural()
        {
            if((this.<toturalLevel>k__BackingField) == false)
            {
                    return;
            }
            
            int val_2 = this.<FirstLevelCurrentIndex>k__BackingField;
            val_2 = val_2 + 1;
            this.<FirstLevelCurrentIndex>k__BackingField = val_2;
            MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance.PointTo(bubbleIndex:  this.<FirstLevelCurrentIndex>k__BackingField);
        }
        public bool SubmitWords(string word)
        {
            if((this.<CurrentLevel>k__BackingField.IsComplete()) == false)
            {
                    return (bool)this.<CurrentLevel>k__BackingField.IsQulify(word:  word);
            }
            
            this.LevelComplete();
            return (bool)this.<CurrentLevel>k__BackingField.IsQulify(word:  word);
        }
        private void LevelComplete()
        {
            if((this.<toturalLevel>k__BackingField) != false)
            {
                    this.<toturalLevel>k__BackingField = false;
            }
            
            this.IsLevelFinish = true;
            MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance.LevelComplete(victory:  true);
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.LevelCompleteDelay(delay:  1.5f, wincondition:  true));
        }
        private void GameOver()
        {
            this.IsGameOver = true;
            MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance.LevelComplete(victory:  false);
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.LevelCompleteDelay(delay:  1.5f, wincondition:  false));
        }
        private System.Collections.IEnumerator LevelCompleteDelay(float delay, bool wincondition)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .delay = delay;
            .wincondition = wincondition;
            return (System.Collections.IEnumerator)new WordBubblesController.<LevelCompleteDelay>d__37();
        }
        public override void InitMonoSingleton()
        {
            this.InitMonoSingleton();
            this.Initialize();
        }
        public WordBubblesController()
        {
            this.playedLevel = new System.Collections.Generic.Queue<SLC.Minigames.Bubbles.WordBubblesCategory>();
            this.remainLives = 2;
        }
    
    }

}
