using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizMinigameManager : MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizMinigameManager>
    {
        // Fields
        private const string MINIGAME_NAME = "ImageQuiz";
        private int <currentPlayerLevel>k__BackingField;
        private SLC.Minigames.ImageQuiz.GameState <MinigameState>k__BackingField;
        public System.Action OnMinigameBegin;
        public System.Action OnMinigameEnd;
        public System.Action OnLevelComplete;
        private int _continuesUsed;
        
        // Properties
        public int currentPlayerLevel { get; set; }
        public SLC.Minigames.ImageQuiz.GameState MinigameState { get; set; }
        
        // Methods
        public int get_currentPlayerLevel()
        {
            return (int)this.<currentPlayerLevel>k__BackingField;
        }
        private void set_currentPlayerLevel(int value)
        {
            this.<currentPlayerLevel>k__BackingField = value;
        }
        public SLC.Minigames.ImageQuiz.GameState get_MinigameState()
        {
            return (SLC.Minigames.ImageQuiz.GameState)this.<MinigameState>k__BackingField;
        }
        private void set_MinigameState(SLC.Minigames.ImageQuiz.GameState value)
        {
            this.<MinigameState>k__BackingField = value;
        }
        private void Start()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnRestartMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizMinigameManager::StartNewGame()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_8;
            }
            
            }
            
            val_1.OnRestartMinigame = val_3;
            SLC.Minigames.MinigameManager val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnInjectTracking, b:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizMinigameManager::Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_8;
            }
            
            }
            
            val_4.OnInjectTracking = val_6;
            this.StartNewGame();
            return;
            label_8:
        }
        private void Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)
        {
            obj.Add(key:  "Total Continues Used", value:  this._continuesUsed);
        }
        private void OnDestroy()
        {
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
            {
                    return;
            }
            
            SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            1152921504893161472 = val_3.OnRestartMinigame;
            System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizMinigameManager::StartNewGame()));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            val_3.OnRestartMinigame = val_5;
            return;
            label_10:
        }
        private void StartNewGame()
        {
            this.InitializeNewGameAttributes();
            if(val_1.loadingCoroutine != null)
            {
                    MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance.StopCoroutine(routine:  val_1.loadingCoroutine);
                val_1.loadingCoroutine = 0;
            }
            
            val_1.<DataLoaderState>k__BackingField = 0;
            MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance.LoadQuizLevels();
        }
        private void InitializeNewGameAttributes()
        {
            this._continuesUsed = 0;
            this.<MinigameState>k__BackingField = 0;
            MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance.ClearAllQuizLevels();
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
            {
                    return;
            }
            
            if((System.String.Compare(strA:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameId, strB:  "ImageQuiz")) != 0)
            {
                    return;
            }
            
            SLC.Minigames.MinigameManager val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            this.<currentPlayerLevel>k__BackingField = val_7.currentPlayerData.checkpointLevel;
        }
        public bool HasLevelData()
        {
            SLC.Minigames.ImageQuiz.ImageQuizDataManager val_1 = MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance;
            return (bool)(val_1.stageQuizLevels > 0) ? 1 : 0;
        }
        public bool IsFTUX()
        {
            return (bool)((this.<currentPlayerLevel>k__BackingField) < 1) ? 1 : 0;
        }
        public void BeginGame()
        {
            this.<MinigameState>k__BackingField = 1;
            if(this.OnMinigameBegin != null)
            {
                    this.OnMinigameBegin.Invoke();
                return;
            }
            
            throw new NullReferenceException();
        }
        public SLC.Minigames.ImageQuiz.ImageQuizLevelInfo GetCurrentQuizLevel()
        {
            SLC.Minigames.ImageQuiz.ImageQuizDataManager val_1 = MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance;
            return val_1.stageQuizLevels.Peek();
        }
        public UnityEngine.Texture2D GetCurrentQuizImage()
        {
            SLC.Minigames.ImageQuiz.ImageQuizLevelInfo val_1 = this.GetCurrentQuizLevel();
            return (UnityEngine.Texture2D)val_1.imageTexture;
        }
        public void SubmitWord(string word)
        {
            SLC.Minigames.ImageQuiz.ImageQuizLevelInfo val_1 = this.GetCurrentQuizLevel();
            if((System.String.op_Equality(a:  word, b:  val_1.word)) == false)
            {
                goto label_2;
            }
            
            int val_4 = this.<currentPlayerLevel>k__BackingField;
            val_4 = val_4 + 1;
            this.<currentPlayerLevel>k__BackingField = val_4;
            MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance.ConsumeCurrentLevel();
            if(this.OnLevelComplete != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_2:
            int val_5 = this._continuesUsed;
            this.<MinigameState>k__BackingField = 2;
            val_5 = val_5 + 1;
            this._continuesUsed = val_5;
            label_6:
            this.OnMinigameEnd.Invoke();
        }
        public ImageQuizMinigameManager()
        {
        
        }
    
    }

}
