using UnityEngine;

namespace SLC.Minigames.EmojiMatch
{
    public class EmojiMatchController : MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>
    {
        // Fields
        private UnityEngine.TextAsset pairData;
        public const string SHARED_EMOJI_LOOKUP = "SharedEmoji";
        public const string NUM_PAIRS = "Pairs";
        public const string PHRASE_KEY_PREFIX = "Phrase";
        public const string EMOJI_KEY_PREFIX = "Emoji";
        private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> levelData;
        private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> usedData;
        private int lives;
        
        // Properties
        public int CurrentLives { get; }
        public float getLevelDuration { get; }
        
        // Methods
        public int get_CurrentLives()
        {
            return (int)this.lives;
        }
        public override void InitMonoSingleton()
        {
            System.Action val_13;
            this.ParseData();
            MonoSingleton<EmojiManagerMinigames>.Instance.BuildEmojiLookup();
            val_13 = 1152921504893161472;
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
            {
                    return;
            }
            
            SLC.Minigames.MinigameManager val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnRestartMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.EmojiMatch.EmojiMatchController::OnRestartMinigame()));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_19;
            }
            
            }
            
            val_4.OnRestartMinigame = val_6;
            SLC.Minigames.MinigameManager val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnContinueMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.EmojiMatch.EmojiMatchController::OnRestartMinigame()));
            if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_19;
            }
            
            }
            
            val_7.OnContinueMinigame = val_9;
            SLC.Minigames.MinigameManager val_10 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_13 = val_10.OnCheckpointRankUpContinue;
            System.Delegate val_12 = System.Delegate.Combine(a:  val_13, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.EmojiMatch.EmojiMatchController::OnRestartMinigame()));
            if(val_12 != null)
            {
                    if(null != null)
            {
                goto label_19;
            }
            
            }
            
            val_10.OnCheckpointRankUpContinue = val_12;
            return;
            label_19:
        }
        private void Update()
        {
        
        }
        private void ParseData()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5;
            var val_6;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_8;
            System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_9;
            this.levelData = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
            List.Enumerator<T> val_4 = MiniJSON.Json.Deserialize(json:  this.pairData.text).GetEnumerator();
            label_10:
            if(val_6.MoveNext() == false)
            {
                goto label_5;
            }
            
            val_8 = val_5;
            val_9 = this.levelData;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9.Add(item:  val_8);
            goto label_10;
            label_5:
            val_6.Dispose();
        }
        public System.Collections.Generic.Dictionary<string, object> getLevel()
        {
            System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_5;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_6;
            int val_1 = UnityEngine.Random.Range(min:  0, max:  0);
            val_5 = this.levelData;
            if(this.levelData > val_1)
            {
                    val_6 = this.levelData + (val_1 << 3);
            }
            else
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_5 = this.levelData;
                val_6 = X9 + (val_1 << 3);
            }
            
            val_6 = val_6 + 32;
            bool val_2 = val_5.Remove(item:  val_6);
            this.usedData.Add(item:  val_6);
            if(val_6 < 100)
            {
                    return val_6;
            }
            
            val_5 = mem[((X9 + (val_1) << 3) + 32) + 32];
            val_5 = ((X9 + (val_1) << 3) + 32) + 32;
            bool val_3 = this.usedData.Remove(item:  val_5);
            this.levelData.Add(item:  val_5);
            return val_6;
        }
        public float get_getLevelDuration()
        {
            int val_9;
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
            {
                    val_9 = UnityEngine.Random.Range(min:  0, max:  144);
            }
            else
            {
                    SLC.Minigames.MinigameManager val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_9 = val_4.currentPlayerLevel;
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                    SLC.Minigames.MinigameManager val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                if(val_7.currentPlayerLevel < 1)
            {
                    return (float)val_9;
            }
            
            }
            
            float val_8 = (float)val_9 + (-2f);
            float val_9 = 0.9981618f;
            val_9 = val_9 * 5f;
            return (float)val_9;
        }
        private void OnRestartMinigame()
        {
            this.lives = 3;
            MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>.Instance.UnpauseForRestart();
            MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>.Instance.GetAndDisplayLevel();
        }
        public bool ShouldReset()
        {
            UnityEngine.Object val_5;
            var val_6;
            val_5 = this;
            int val_5 = this.lives;
            val_5 = val_5 - 1;
            this.lives = val_5;
            if(val_5 > 0)
            {
                    val_6 = 1;
                return (bool)val_6;
            }
            
            val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if((UnityEngine.Object.op_Implicit(exists:  val_5)) != false)
            {
                    bool val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
            }
            
            val_6 = 0;
            return (bool)val_6;
        }
        public void PauseHack()
        {
            SLC.Minigames.EmojiMatch.EmojiMatchUIController val_1 = MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>.Instance;
            val_1.timerSpeed = 0.1f;
        }
        public void StopTimerHack()
        {
            SLC.Minigames.EmojiMatch.EmojiMatchUIController val_1 = MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>.Instance;
            val_1.timerSpeed = 0f;
        }
        public void ResumeTimerHack()
        {
            SLC.Minigames.EmojiMatch.EmojiMatchUIController val_1 = MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>.Instance;
            val_1.timerSpeed = 1f;
        }
        public EmojiMatchController()
        {
            this.usedData = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
            this.lives = 3;
        }
    
    }

}
