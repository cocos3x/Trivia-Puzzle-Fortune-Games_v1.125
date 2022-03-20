using UnityEngine;

namespace SLC.Minigames.Whack
{
    public class WhackGameManager : MonoSingleton<SLC.Minigames.Whack.WhackGameManager>
    {
        // Fields
        public const int PLAYERLIFE_TOTALNUM = 3;
        public const string PLAYERLIFEKEY = "whack_player_life";
        private int _livesUsed;
        private SLC.Minigames.Whack.WhackLevel currentLevel;
        
        // Properties
        public int PlayerLife { get; set; }
        
        // Methods
        public int get_PlayerLife()
        {
            return UnityEngine.PlayerPrefs.GetInt(key:  "whack_player_life", defaultValue:  3);
        }
        public void set_PlayerLife(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(key:  "whack_player_life", value:  value);
        }
        public override void InitMonoSingleton()
        {
            SLC.Minigames.Whack.WhackDataParser.Initialize();
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_1.OnRestartMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.Whack.WhackGameManager::RestartGame());
            SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_3.OnContinueMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.Whack.WhackGameManager::ContinueGame());
            SLC.Minigames.MinigameManager val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_5.OnCheckpointRankUpContinue = new System.Action(object:  this, method:  System.Void SLC.Minigames.Whack.WhackGameManager::ContinueGame());
            SLC.Minigames.MinigameManager val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_7.TogglePopupWindow, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.Whack.WhackGameManager::TogglePopupWindow(bool showing)));
            if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_13;
            }
            
            }
            
            val_7.TogglePopupWindow = val_9;
            SLC.Minigames.MinigameManager val_10 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_12 = System.Delegate.Combine(a:  val_10.OnInjectTracking, b:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Minigames.Whack.WhackGameManager::Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)));
            if(val_12 != null)
            {
                    if(null != null)
            {
                goto label_13;
            }
            
            }
            
            val_10.OnInjectTracking = val_12;
            return;
            label_13:
        }
        private void Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)
        {
            obj.Add(key:  "Total Lives Used", value:  this._livesUsed);
        }
        private void TogglePopupWindow(bool showing)
        {
            showing = showing;
            MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance.HideUIForPopup(showingPopup:  showing);
        }
        public int GetCurrentLevelIndex()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            return (int)val_1.currentPlayerLevel;
        }
        public void ItemClicked(SLC.Minigames.Whack.WhackItem item)
        {
            if(item.wordDefinition == null)
            {
                    return;
            }
            
            if(item.wordDefinition.incorrect != false)
            {
                    SLC.Minigames.Whack.WhackUIController val_1 = MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance;
                UnityEngine.Coroutine val_3 = val_1.StartCoroutine(routine:  val_1.displayResult(item:  item, won:  true));
                return;
            }
            
            this.LevelFailed(itemClicked:  item);
        }
        public void LevelFailed(SLC.Minigames.Whack.WhackItem itemClicked)
        {
            int val_9 = this._livesUsed;
            val_9 = val_9 + 1;
            this._livesUsed = val_9;
            int val_1 = this.PlayerLife;
            val_1.PlayerLife = val_1 - 1;
            if(itemClicked != 0)
            {
                    SLC.Minigames.Whack.WhackUIController val_4 = MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance;
                UnityEngine.Coroutine val_6 = val_4.StartCoroutine(routine:  val_4.displayResult(item:  itemClicked, won:  false));
            }
            
            DG.Tweening.Tween val_8 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.Whack.WhackGameManager::<LevelFailed>b__12_0()), ignoreTimeScale:  true);
        }
        private void Start()
        {
            this.ResetLevel(firstLevel:  true);
            MonoSingleton<MinigameAudioController>.Instance.StartMusic(clipIndex:  0);
        }
        private void RestartGame()
        {
            this.ResetLevel(firstLevel:  true);
        }
        private void ContinueGame()
        {
            this.ResetLevel(firstLevel:  false);
        }
        private void ResetLevel(bool firstLevel)
        {
            if(firstLevel != false)
            {
                    this._livesUsed = 0;
            }
            
            this.currentLevel = SLC.Minigames.Whack.WhackDataParser.GetWhackLevel();
            PluginExtension.Shuffle<SLC.Minigames.Whack.WhackWord>(list:  val_1.whackWords, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance.Initialize(level:  this.currentLevel);
        }
        private void OnCheckPointReached()
        {
            MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
        }
        public void CheckCheckpoint()
        {
            DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.Whack.WhackGameManager::<CheckCheckpoint>b__18_0()), ignoreTimeScale:  true);
        }
        public WhackGameManager()
        {
        
        }
        private void <LevelFailed>b__12_0()
        {
            if(this.PlayerLife != 0)
            {
                    this.ResetLevel(firstLevel:  false);
                return;
            }
            
            bool val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
        }
        private void <CheckCheckpoint>b__18_0()
        {
            bool val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete();
            if(val_2 != false)
            {
                    val_2.OnCheckPointReached();
                return;
            }
            
            this.ResetLevel(firstLevel:  false);
        }
    
    }

}
