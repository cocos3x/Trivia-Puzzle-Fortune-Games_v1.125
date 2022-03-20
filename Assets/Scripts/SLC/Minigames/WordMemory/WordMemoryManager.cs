using UnityEngine;

namespace SLC.Minigames.WordMemory
{
    public class WordMemoryManager : MonoSingleton<SLC.Minigames.WordMemory.WordMemoryManager>
    {
        // Fields
        private const string MINIGAME_NAME = "WordQUiz";
        private SLC.Minigames.WordMemory.WordMemoryUIController uiController;
        private SLC.Minigames.WordMemory.WordMemoryParser wordMemoryParser;
        private string usedCategoriesKey;
        private System.Collections.Generic.List<string> usedCategories;
        private bool <inMinigameFramework>k__BackingField;
        private int _playerLevel;
        private int maxLives;
        private int lives;
        private int pairs;
        private string[] levelWords;
        private System.Collections.Generic.List<string> categories;
        private int card1;
        private int card2;
        private int cardsRemaining;
        private bool canPlay;
        private bool <Locked>k__BackingField;
        
        // Properties
        public bool inMinigameFramework { get; set; }
        public bool Locked { get; set; }
        
        // Methods
        public bool get_inMinigameFramework()
        {
            return (bool)this.<inMinigameFramework>k__BackingField;
        }
        private void set_inMinigameFramework(bool value)
        {
            this.<inMinigameFramework>k__BackingField = value;
        }
        public bool get_Locked()
        {
            return (bool)this.<Locked>k__BackingField;
        }
        public void set_Locked(bool value)
        {
            this.<Locked>k__BackingField = value;
        }
        public bool CanPlay()
        {
            if((this.<Locked>k__BackingField) == false)
            {
                    return (bool)(this.canPlay == true) ? 1 : 0;
            }
            
            return false;
        }
        public override void InitMonoSingleton()
        {
            System.Collections.Generic.List<System.String> val_6;
            this.wordMemoryParser = new SLC.Minigames.WordMemory.WordMemoryParser();
            if((UnityEngine.PlayerPrefs.HasKey(key:  this.usedCategoriesKey)) != false)
            {
                    val_6 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  UnityEngine.PlayerPrefs.GetString(key:  this.usedCategoriesKey));
            }
            else
            {
                    System.Collections.Generic.List<System.String> val_5 = null;
                val_6 = val_5;
                val_5 = new System.Collections.Generic.List<System.String>();
            }
            
            this.usedCategories = val_6;
        }
        private void Start()
        {
            System.Action val_13;
            object val_14;
            val_13 = 1152921504893161472;
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                goto label_5;
            }
            
            val_14 = "WordMemory: No Minigame Manager";
            goto label_8;
            label_5:
            if((this.<inMinigameFramework>k__BackingField) == false)
            {
                goto label_27;
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameId.Equals(value:  "WordQUiz")) == false)
            {
                goto label_14;
            }
            
            if((this.<inMinigameFramework>k__BackingField) == false)
            {
                goto label_27;
            }
            
            SLC.Minigames.MinigameManager val_6 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            this._playerLevel = val_6.currentPlayerLevel;
            SLC.Minigames.MinigameManager val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnRestartMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordMemory.WordMemoryManager::OnRestartFromCheckpoint()));
            if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_24;
            }
            
            }
            
            val_7.OnRestartMinigame = val_9;
            SLC.Minigames.MinigameManager val_10 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_13 = val_10.OnContinueMinigame;
            System.Delegate val_12 = System.Delegate.Combine(a:  val_13, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordMemory.WordMemoryManager::HandleContinue()));
            if(val_12 != null)
            {
                    if(null != null)
            {
                goto label_24;
            }
            
            }
            
            val_10.OnContinueMinigame = val_12;
            UnityEngine.Debug.LogError(message:  "subscribing to things");
            goto label_27;
            label_14:
            val_14 = "WordMemory: Minigame Mismatch";
            label_8:
            UnityEngine.Debug.LogError(message:  val_14, context:  this);
            this.<inMinigameFramework>k__BackingField = false;
            label_27:
            this.StartGame();
            return;
            label_24:
        }
        private void StartGame()
        {
            int val_3;
            if((this.<inMinigameFramework>k__BackingField) != false)
            {
                    SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_3 = val_1.currentPlayerLevel;
                this._playerLevel = val_3;
            }
            else
            {
                    val_3 = this._playerLevel;
            }
            
            this.GenerateLevelData(level:  val_3);
            this.card1 = -1;
            this.card2 = -1;
            this.cardsRemaining = this.pairs << 1;
            this.<Locked>k__BackingField = true;
            this.uiController.LoadLevel(maxLives:  val_3, lives:  this.maxLives, pairs:  this.pairs, words:  this.levelWords);
            this.canPlay = true;
        }
        private void GenerateLevelData(int level)
        {
            var val_13;
            int val_14;
            var val_15;
            System.String[] val_16;
            System.String[] val_17;
            System.Collections.Generic.List<System.String> val_18;
            SLC.Minigames.WordMemory.WordMemoryLevel val_1 = this.wordMemoryParser.GetWordMemoryLevelData(level:  level);
            this.maxLives = val_1.lives;
            this.lives = val_1.lives;
            this.pairs = val_1.pairs;
            System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>(collection:  this.wordMemoryParser.wordDataSource.Keys);
            this.categories = val_3;
            System.Collections.Generic.List<TSource> val_5 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Except<System.String>(first:  val_3, second:  this.usedCategories));
            int val_6 = UnityEngine.Random.Range(min:  0, max:  1473580080);
            if(1152921510375394352 <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            SLC.Minigames.WordMemory.WordMemoryParser val_15 = this.wordMemoryParser;
            val_15 = val_15 + (val_6 << 3);
            System.String[] val_7 = this.wordMemoryParser.wordDataSource.Item[X27];
            string[] val_8 = new string[0];
            this.Shuffle<System.String>(data:  val_7);
            if(this.pairs > val_7.Length)
            {
                    UnityEngine.Debug.LogError(message:  "not enough words to make " + this.pairs + " pairs.");
                return;
            }
            
            if(val_8.Length >= 1)
            {
                    var val_16 = 0;
                val_14 = val_8.Length & 4294967295;
                do
            {
                if(null != null)
            {
                    val_14 = val_8.Length;
            }
            
                mem2[0] = null;
                val_16 = val_16 + 1;
            }
            while(val_16 < (val_14 << ));
            
            }
            
            int val_10 = this.pairs << 1;
            string[] val_11 = new string[0];
            this.levelWords = val_11;
            int val_17 = val_8.Length;
            val_17 = val_11;
            if(val_17 >= 1)
            {
                    val_17 = val_17 & 4294967295;
                var val_18 = 0;
                do
            {
                var val_12 = val_18 + 1;
                val_17[0] = null;
                val_16 = this.levelWords;
                val_18 = val_18 + 2;
                val_16[(0 + 4294967296) >> 29] = null;
                val_17 = this.levelWords;
                val_15 = 0 + 1;
                val_13 = 0 + 8589934592;
            }
            while(val_15 < (val_8.Length << ));
            
            }
            
            this.Shuffle<System.String>(data:  val_17);
            this.usedCategories.Add(item:  ???);
            val_18 = this.usedCategories;
            label_35:
            if(1152921509851232320 <= 50)
            {
                goto label_34;
            }
            
            val_18.RemoveAt(index:  0);
            val_18 = this.usedCategories;
            if(val_18 != null)
            {
                goto label_35;
            }
            
            throw new NullReferenceException();
            label_34:
            UnityEngine.PlayerPrefs.SetString(key:  this.usedCategoriesKey, value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_18));
        }
        public void Shuffle<T>(T[] data)
        {
            if(data.Length < 1)
            {
                    return;
            }
            
            var val_5 = 0;
            do
            {
                int val_3 = data.Length;
                val_3 = val_3 & 4294967295;
                mem2[0] = data[UnityEngine.Random.Range(min:  0, max:  data.Length & 4294967295)];
                data[UnityEngine.Random.Range(min:  0, max:  data.Length & 4294967295)] = null;
                val_5 = val_5 + 1;
            }
            while(val_5 < (data.Length << ));
        
        }
        private void OnRestartFromCheckpoint()
        {
        
        }
        private void HandleContinue()
        {
        
        }
        public void HandleFailed()
        {
            if((this.<inMinigameFramework>k__BackingField) != false)
            {
                    bool val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
                return;
            }
            
            this.StartGame();
        }
        private void Update()
        {
        
        }
        public void FaceUpCard(int index)
        {
            if((this.card1 & 2147483648) != 0)
            {
                goto label_1;
            }
            
            this.card2 = index;
            this.<Locked>k__BackingField = true;
            if((System.String.op_Equality(a:  null, b:  null)) == false)
            {
                goto label_5;
            }
            
            UnityEngine.Coroutine val_3 = this.uiController.StartCoroutine(routine:  this.uiController.DelayHidePair(card1:  this.card1, card2:  this.card2));
            int val_7 = this.cardsRemaining;
            val_7 = val_7 - 2;
            this.cardsRemaining = val_7;
            if(val_7 > 0)
            {
                goto label_15;
            }
            
            UnityEngine.Debug.Log(message:  "You win!");
            this.canPlay = false;
            goto label_15;
            label_1:
            this.card1 = index;
            return;
            label_5:
            int val_4 = this.lives - 1;
            this.lives = val_4;
            this.uiController.SetLives(lives:  val_4, maxLives:  this.maxLives);
            if(this.lives > 0)
            {
                    UnityEngine.Coroutine val_6 = this.uiController.StartCoroutine(routine:  this.uiController.DelayFaceDownPair(card1:  this.card1, card2:  this.card2));
            }
            else
            {
                    this.HandleFailed();
            }
            
            label_15:
            this.card1 = -1;
            this.card2 = -1;
        }
        public WordMemoryManager()
        {
            this.card1 = -1;
            this.card2 = -1;
            this.usedCategoriesKey = "word_memory_category_key";
        }
    
    }

}
