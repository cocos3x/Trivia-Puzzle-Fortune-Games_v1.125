using UnityEngine;

namespace SLC.Minigames.Snake
{
    public class SnakeGameManager : MonoSingleton<SLC.Minigames.Snake.SnakeGameManager>
    {
        // Fields
        private const string MINIGAME_NAME = "Snake";
        private SLC.Minigames.Snake.SnakeUIController uiController;
        private int _snakePlayerLevel;
        private int _snakeObjectivesCount;
        private int _snakeObjectivesReq;
        private bool inMinigameFramework;
        private bool isPaused;
        
        // Properties
        public bool IsPaused { get; }
        
        // Methods
        public bool get_IsPaused()
        {
            return (bool)this.isPaused;
        }
        private void Start()
        {
            System.Action val_13;
            object val_14;
            this.inMinigameFramework = true;
            val_13 = 1152921504893161472;
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                goto label_5;
            }
            
            val_14 = "Snake: No Minigame Manager";
            goto label_8;
            label_5:
            if(this.inMinigameFramework == false)
            {
                goto label_25;
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameId.Equals(value:  "Snake")) == false)
            {
                goto label_14;
            }
            
            if(this.inMinigameFramework == false)
            {
                goto label_25;
            }
            
            SLC.Minigames.MinigameManager val_6 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            this._snakePlayerLevel = val_6.currentPlayerLevel;
            SLC.Minigames.MinigameManager val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnContinueMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.Snake.SnakeGameManager::OnRestartFromCheckpoint()));
            if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_24;
            }
            
            }
            
            val_7.OnContinueMinigame = val_9;
            SLC.Minigames.MinigameManager val_10 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_13 = val_10.OnRestartMinigame;
            System.Delegate val_12 = System.Delegate.Combine(a:  val_13, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.Snake.SnakeGameManager::OnRestartFromCheckpoint()));
            if(val_12 != null)
            {
                    if(null != null)
            {
                goto label_24;
            }
            
            }
            
            val_10.OnRestartMinigame = val_12;
            goto label_25;
            label_14:
            val_14 = "Snake: Minigame Mismatch";
            label_8:
            UnityEngine.Debug.LogError(message:  val_14, context:  this);
            this.inMinigameFramework = false;
            label_25:
            this.SetupCurrentLevel(level:  this._snakePlayerLevel);
            this.uiController.UpdateUI(paused:  this.isPaused, currLevel:  this._snakePlayerLevel, currObjs:  this._snakeObjectivesCount, reqObjs:  this._snakeObjectivesReq);
            return;
            label_24:
        }
        private void OnRestartFromCheckpoint()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            this._snakePlayerLevel = val_1.currentPlayerLevel;
            this.SetupCurrentLevel(level:  val_1.currentPlayerLevel);
            this.uiController.UpdateUI(paused:  this.isPaused, currLevel:  this._snakePlayerLevel, currObjs:  this._snakeObjectivesCount, reqObjs:  this._snakeObjectivesReq);
        }
        private void SetupCurrentLevel(int level)
        {
            this.isPaused = true;
            level = level + 3;
            this._snakeObjectivesCount = 0;
            this._snakeObjectivesReq = UnityEngine.Mathf.Min(a:  20, b:  level);
        }
        private void Update()
        {
        
        }
        public void HACK_InstantWin()
        {
            this._snakeObjectivesCount = this._snakeObjectivesReq;
            this.HandleCollectedObjective();
        }
        public void HandleCollectedObjective()
        {
            int val_5;
            int val_4 = this._snakeObjectivesCount;
            val_4 = val_4 + 1;
            this._snakeObjectivesCount = val_4;
            if(val_4 >= this._snakeObjectivesReq)
            {
                    if(this.inMinigameFramework != false)
            {
                    bool val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete();
                SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_5 = val_3.currentPlayerLevel;
            }
            else
            {
                    val_5 = this._snakePlayerLevel + 1;
            }
            
                this._snakePlayerLevel = val_5;
                this.SetupCurrentLevel(level:  val_5);
            }
            
            this.uiController.UpdateUI(paused:  this.isPaused, currLevel:  this._snakePlayerLevel, currObjs:  this._snakeObjectivesCount, reqObjs:  this._snakeObjectivesReq);
        }
        public void HandleFailed()
        {
            this.isPaused = true;
            if(this.inMinigameFramework != false)
            {
                    bool val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
            }
            else
            {
                    int val_3 = this._snakePlayerLevel - 1;
                this._snakePlayerLevel = val_3;
                this.SetupCurrentLevel(level:  val_3);
            }
            
            this.uiController.UpdateUI(paused:  this.isPaused, currLevel:  this._snakePlayerLevel, currObjs:  this._snakeObjectivesCount, reqObjs:  this._snakeObjectivesReq);
        }
        public void OnPauseInput()
        {
            this.isPaused = this.isPaused ^ 1;
            if(this.uiController != null)
            {
                    this.uiController.UpdateUI(paused:  (this.isPaused == false) ? 1 : 0, currLevel:  this._snakePlayerLevel, currObjs:  this._snakeObjectivesCount, reqObjs:  this._snakeObjectivesReq);
                return;
            }
            
            throw new NullReferenceException();
        }
        public SnakeGameManager()
        {
            this._snakeObjectivesReq = 3;
            this.isPaused = true;
        }
    
    }

}
