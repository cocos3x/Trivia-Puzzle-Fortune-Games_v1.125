using UnityEngine;

namespace SLC.Minigames.TwistyArrow
{
    public class TwistyGameManager : MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>
    {
        // Fields
        private const int ExpectedWordCount = 5;
        private UnityEngine.TextAsset word_level_list;
        public bool inMinigameFramework;
        public System.Action<bool> OnPlayingStateChanged;
        private const string MINIGAME_NAME = "TwistyArrow";
        private const string usedLevelsKey = "twisty_arrow_used_levels";
        private bool _IsPlaying;
        private string[] levels;
        private int currentLevel;
        private const int MaxHearts = 3;
        private int _Hearts;
        private System.Collections.Generic.List<int> usedLevels;
        private int _livesUsed;
        private int consecutiveFailures;
        
        // Properties
        public int Hearts { get; }
        public bool IsPlaying { get; set; }
        public float LevelRotation { get; }
        public float AdjustedRotation { get; }
        public string[] Levels { get; }
        public string[] LevelWords { get; }
        public string LevelWordsString { get; }
        public System.Collections.Generic.List<int> UsedLevels { get; }
        public string UsedLevelsString { get; }
        public bool IsCurrentLevelUsed { get; }
        
        // Methods
        public int get_Hearts()
        {
            return (int)this._Hearts;
        }
        public bool get_IsPlaying()
        {
            return (bool)this._IsPlaying;
        }
        public void set_IsPlaying(bool value)
        {
            var val_1 = (this._IsPlaying == true) ? 1 : 0;
            val_1 = val_1 ^ value;
            if((val_1 != false) && (this.OnPlayingStateChanged != null))
            {
                    value = value;
                this.OnPlayingStateChanged.Invoke(obj:  value);
            }
            
            this._IsPlaying = value;
        }
        public float get_LevelRotation()
        {
            float val_2;
            if(this.inMinigameFramework != false)
            {
                    SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_2 = (float)val_1.currentPlayerLevel;
            }
            else
            {
                    val_2 = 0f;
            }
            
            float val_2 = 0.996651f;
            val_2 = val_2 * 8f;
            return (float)val_2;
        }
        public float get_AdjustedRotation()
        {
            SLC.Minigames.TwistyArrow.TwistyArrowLogic val_2 = MonoSingleton<SLC.Minigames.TwistyArrow.TwistyArrowLogic>.Instance;
            float val_3 = val_2.Wheel.speedMultiplier;
            val_3 = this.LevelRotation / val_3;
            return (float)val_3;
        }
        public string[] get_Levels()
        {
            if(this.levels != null)
            {
                    if(this.levels.Length != 0)
            {
                    return val_3;
            }
            
            }
            
            char[] val_2 = new char[2];
            val_2[0] = '';
            val_2[0] = '
            ';
            System.String[] val_3 = this.word_level_list.text.Split(separator:  val_2, options:  1);
            this.levels = val_3;
            return val_3;
        }
        public string[] get_LevelWords()
        {
            if(this.Levels == null)
            {
                    return 0;
            }
            
            System.String[] val_2 = this.Levels;
            if(val_2.Length == 0)
            {
                    return 0;
            }
            
            if(this.currentLevel == 1)
            {
                    return 0;
            }
            
            char[] val_4 = new char[1];
            val_4[0] = ',';
            return this.Levels[this.currentLevel].Split(separator:  val_4);
        }
        public string get_LevelWordsString()
        {
            System.String[] val_1 = this.LevelWords;
            if(val_1.Length <= 4)
            {
                    return "";
            }
            
            System.Text.StringBuilder val_2 = new System.Text.StringBuilder();
            System.Text.StringBuilder val_4 = val_2.AppendFormat(format:  "<color=#cd0202><b>{0}</b></color>", arg0:  this.LevelWords[0]);
            System.Text.StringBuilder val_5 = val_2.Append(value:  ", ");
            System.String[] val_6 = this.LevelWords;
            do
            {
                if((5 - 4) >= val_6.Length)
            {
                goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
            }
            
                System.Text.StringBuilder val_9 = val_2.AppendFormat(format:  "<color=#D5CF01><b>{0}</b></color>", arg0:  this.LevelWords[1]);
                System.Text.StringBuilder val_10 = val_2.Append(value:  ", ");
                var val_12 = 5 + 1;
            }
            while(this.LevelWords != null);
            
            throw new NullReferenceException();
        }
        public System.Collections.Generic.List<int> get_UsedLevels()
        {
            System.Collections.Generic.List<System.Int32> val_5 = this.usedLevels;
            if(val_5 != null)
            {
                    return val_5;
            }
            
            if((UnityEngine.PlayerPrefs.HasKey(key:  "twisty_arrow_used_levels")) != false)
            {
                    System.Collections.Generic.List<System.Int32> val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.Int32>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "twisty_arrow_used_levels"));
                val_5 = val_3;
                this.usedLevels = val_3;
                return val_5;
            }
            
            System.Collections.Generic.List<System.Int32> val_4 = null;
            val_5 = val_4;
            val_4 = new System.Collections.Generic.List<System.Int32>();
            this.usedLevels = val_5;
            return val_5;
        }
        public string get_UsedLevelsString()
        {
            System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
            System.Collections.Generic.List<System.Int32> val_2 = this.UsedLevels;
            var val_7 = 0;
            label_6:
            if(val_7 >= 1152921504630968320)
            {
                goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
            }
            
            System.Collections.Generic.List<System.Int32> val_3 = this.UsedLevels;
            if(val_7 >= 1152921504630968320)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            System.Text.StringBuilder val_4 = val_1.Append(value:  -1540172432);
            System.Text.StringBuilder val_5 = val_1.Append(value:  ",");
            val_7 = val_7 + 1;
            if(this.UsedLevels != null)
            {
                goto label_6;
            }
            
            goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
        }
        public bool get_IsCurrentLevelUsed()
        {
            return (bool)((System.Linq.Enumerable.Count<System.Int32>(source:  System.Linq.Enumerable.Where<System.Int32>(source:  this.UsedLevels, predicate:  new System.Func<System.Int32, System.Boolean>(object:  this, method:  System.Boolean SLC.Minigames.TwistyArrow.TwistyGameManager::<get_IsCurrentLevelUsed>b__24_0(int x))))) > 1) ? 1 : 0;
        }
        private void Start()
        {
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_21;
            var val_22;
            object val_23;
            this.inMinigameFramework = true;
            val_21 = 1152921504893161472;
            val_22 = 1152921515825925232;
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                goto label_5;
            }
            
            val_23 = "TwistyArrow: No Minigame Manager";
            goto label_8;
            label_5:
            if(this.inMinigameFramework == false)
            {
                goto label_30;
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameId.Equals(value:  "TwistyArrow")) == false)
            {
                goto label_14;
            }
            
            if(this.inMinigameFramework == false)
            {
                goto label_30;
            }
            
            SLC.Minigames.MinigameManager val_6 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_8 = System.Delegate.Combine(a:  val_6.OnContinueMinigame, b:  new System.Action(object:  this, method:  public System.Void SLC.Minigames.TwistyArrow.TwistyGameManager::StartNewLevelFreshLives()));
            if(val_8 != null)
            {
                    if(null != null)
            {
                goto label_29;
            }
            
            }
            
            val_6.OnContinueMinigame = val_8;
            SLC.Minigames.MinigameManager val_9 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_11 = System.Delegate.Combine(a:  val_9.OnRestartMinigame, b:  new System.Action(object:  this, method:  public System.Void SLC.Minigames.TwistyArrow.TwistyGameManager::RestartNewLevelFreshLives()));
            if(val_11 != null)
            {
                    if(null != null)
            {
                goto label_29;
            }
            
            }
            
            val_9.OnRestartMinigame = val_11;
            SLC.Minigames.MinigameManager val_12 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_14 = System.Delegate.Combine(a:  val_12.OnCheckpointRankUpContinue, b:  new System.Action(object:  this, method:  public System.Void SLC.Minigames.TwistyArrow.TwistyGameManager::StartNewLevel()));
            if(val_14 != null)
            {
                    if(null != null)
            {
                goto label_29;
            }
            
            }
            
            val_12.OnCheckpointRankUpContinue = val_14;
            SLC.Minigames.MinigameManager val_15 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_21 = val_15.OnInjectTracking;
            val_22 = 1152921504614248448;
            System.Delegate val_17 = System.Delegate.Combine(a:  val_21, b:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Minigames.TwistyArrow.TwistyGameManager::Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)));
            if(val_17 != null)
            {
                    if(null != null)
            {
                goto label_29;
            }
            
            }
            
            val_15.OnInjectTracking = val_17;
            goto label_30;
            label_14:
            UnityEngine.Debug.LogError(message:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameId(MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameId) + " and TwistyArrow");
            val_23 = "TwistyArrow: Minigame Mismatch";
            label_8:
            UnityEngine.Debug.LogError(message:  val_23, context:  this);
            this.inMinigameFramework = false;
            label_30:
            this._Hearts = 3;
            this.StartNewLevel();
            return;
            label_29:
        }
        private void Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)
        {
            obj.Add(key:  "Total Lives Used", value:  this._livesUsed);
        }
        public void StartNewLevel()
        {
            System.Boolean[] val_30;
            System.String[] val_31;
            int val_32;
            var val_33;
            System.Func<System.Boolean> val_35;
            string val_36;
            int val_37;
            int val_38;
            val_30 = this;
            if(this.consecutiveFailures >= 4)
            {
                goto label_1;
            }
            
            int val_1 = this.GetRandomLevel();
            this.currentLevel = val_1;
            if((val_1 == 1) || (this.LevelWords == null))
            {
                goto label_5;
            }
            
            System.String[] val_3 = this.LevelWords;
            if(val_3.Length != 5)
            {
                goto label_5;
            }
            
            this.consecutiveFailures = 0;
            MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
            val_31 = this.LevelWords;
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyArrowLogic>.Instance.Setup(words:  val_31, secondsPerRotation:  this.LevelRotation);
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyUIController>.Instance.UpdateUIHearts(currentHearts:  this._Hearts);
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyUIController>.Instance.SetActiveInfoText(active:  true);
            this.IsPlaying = true;
            return;
            label_1:
            SLC.Minigames.MinigamesUIController val_10 = MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance;
            bool[] val_11 = new bool[2];
            val_30 = val_11;
            val_30[0] = true;
            string[] val_12 = new string[2];
            val_31 = val_12;
            val_32 = val_12.Length;
            val_31[0] = "HOME";
            val_32 = val_12.Length;
            val_31[1] = "NULL";
            System.Func<System.Boolean>[] val_13 = new System.Func<System.Boolean>[2];
            val_33 = null;
            val_33 = null;
            val_35 = TwistyGameManager.<>c.<>9__37_0;
            val_36 = "Failed to load new level.";
            if(val_35 == null)
            {
                    System.Func<System.Boolean> val_14 = null;
                val_35 = val_14;
                val_14 = new System.Func<System.Boolean>(object:  TwistyGameManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TwistyGameManager.<>c::<StartNewLevel>b__37_0());
                TwistyGameManager.<>c.<>9__37_0 = val_35;
            }
            
            val_13[0] = val_35;
            X0.ShowMessage(titleTxt:  "ERROR", messageTxt:  val_36, shownButtons:  val_11, buttonTexts:  val_12, showClose:  false, buttonCallbacks:  val_13);
            return;
            label_5:
            val_31 = "";
            System.String[] val_15 = this.Levels;
            val_36 = 1152921505060011504;
            val_35 = 1152921505059157200;
            label_66:
            if(0 >= val_15.Length)
            {
                goto label_40;
            }
            
            char[] val_17 = new char[1];
            val_17[0] = ',';
            System.String[] val_18 = this.Levels[0].Split(separator:  val_17);
            if(val_18.Length != 5)
            {
                    string[] val_19 = new string[5];
                val_19[0] = val_31;
                val_37 = val_19.Length;
                val_19[1] = 0.ToString();
                val_37 = val_19.Length;
                val_19[2] = " : ";
                val_38 = val_19.Length;
                val_19[3] = this.Levels[0];
                val_38 = val_19.Length;
                val_19[4] = "\n";
                string val_22 = +val_19;
            }
            
            var val_23 = 0 + 1;
            if(this.Levels != null)
            {
                goto label_66;
            }
            
            label_40:
            string val_26 = this.currentLevel.ToString();
            if(this.LevelWords != null)
            {
                    System.String[] val_27 = this.LevelWords;
                string val_29 = System.String.Format(format:  "TwistyGameManager.StartNewLevel() error: currentLevel:{0}, LevelWords.Length:{1}, BrokenLevels:\n{2}", arg0:  val_26, arg1:  val_27.Length.ToString(), arg2:  val_31);
            }
            
            UnityEngine.Debug.LogError(message:  System.String.Format(format:  "TwistyGameManager.StartNewLevel() error: currentLevel:{0}, LevelWords:null, BrokenLevels:\n{1}", arg0:  val_26, arg1:  val_31));
            int val_33 = this.consecutiveFailures;
            this.levels = 0;
            val_33 = val_33 + 1;
            this.consecutiveFailures = val_33;
        }
        public void RestartNewLevelFreshLives()
        {
            this._livesUsed = 0;
            this._Hearts = 3;
            this.StartNewLevel();
        }
        public void StartNewLevelFreshLives()
        {
            this._Hearts = 3;
            this.StartNewLevel();
        }
        public void InvokedNewLevel()
        {
            this.StartNewLevel();
        }
        public void HandleLevelComplete()
        {
            if(this.inMinigameFramework != false)
            {
                    if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete()) != false)
            {
                    MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
            }
            else
            {
                    this.Invoke(methodName:  "InvokedNewLevel", time:  0.5f);
            }
            
            }
            
            this.IsPlaying = false;
        }
        public void HandleFailure()
        {
            this.IsPlaying = false;
            int val_4 = this._livesUsed;
            int val_5 = this._Hearts;
            val_4 = val_4 + 1;
            val_5 = val_5 - 1;
            this._livesUsed = val_4;
            this._Hearts = val_5;
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyUIController>.Instance.UpdateUIHearts(currentHearts:  this._Hearts);
            if(this._Hearts > 0)
            {
                    this.Invoke(methodName:  "InvokedNewLevel", time:  0.5f);
                return;
            }
            
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.DelayShowLevelFailed());
        }
        public void HandleSoftFailure()
        {
            int val_4 = this._livesUsed;
            int val_5 = this._Hearts;
            val_4 = val_4 + 1;
            val_5 = val_5 - 1;
            this._livesUsed = val_4;
            this._Hearts = val_5;
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyUIController>.Instance.UpdateUIHearts(currentHearts:  this._Hearts);
            if(this._Hearts > 0)
            {
                    return;
            }
            
            this.IsPlaying = false;
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.DelayShowLevelFailed());
        }
        public string CurrentLevelInfo()
        {
            var val_18;
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance)) != false)
            {
                    System.Text.StringBuilder val_3 = new System.Text.StringBuilder();
                System.Text.StringBuilder val_5 = val_3.AppendFormat(format:  "Current word set is #{0}: \n<color=#D5CF01><b>{1}</b></color>\n\n", arg0:  this.currentLevel, arg1:  this.LevelWordsString);
                System.Text.StringBuilder val_9 = val_3.AppendFormat(format:  "Is word set used in last 100 levels: \n<color=#D5CF01><b>{0}</b></color>\n\n", arg0:  this.IsCurrentLevelUsed.ToString());
                System.Text.StringBuilder val_12 = val_3.AppendFormat(format:  "Rotation speed: \n<color=#D5CF01><b>{0}</b></color> seconds per rotation \n\n", arg0:  this.LevelRotation.ToString(format:  "0.000"));
                System.Text.StringBuilder val_15 = val_3.AppendFormat(format:  "Adjusted rotation speed: \n<color=#D5CF01><b>{0}</b></color> seconds per rotation \n\n", arg0:  this.AdjustedRotation.ToString(format:  "0.000"));
                System.Text.StringBuilder val_17 = val_3.AppendFormat(format:  "Used word sets: \n<color=#D5CF01><b>{0}</b></color>\n\n", arg0:  this.UsedLevelsString);
                val_18 = val_3;
                return (string)val_18;
            }
            
            val_18 = "Word Arrows not running.";
            return (string)val_18;
        }
        private System.Collections.IEnumerator DelayShowLevelFailed()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new TwistyGameManager.<DelayShowLevelFailed>d__45();
        }
        private int GetRandomLevel()
        {
            System.Collections.Generic.List<System.Int32> val_10;
            System.String[] val_1 = this.Levels;
            var val_10 = 1152921516081016528;
            System.Collections.Generic.List<TSource> val_7 = System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Except<System.Int32>(first:  System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Range(start:  1, count:  val_1.Length - 1)), second:  this.UsedLevels));
            int val_8 = UnityEngine.Random.Range(min:  0, max:  -2041131504);
            if(val_10 <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_10 = val_10 + (val_8 << 2);
            this.usedLevels.Add(item:  (1152921516081016528 + (val_8) << 2) + 32);
            val_10 = this.usedLevels;
            label_7:
            if(val_10 <= 100)
            {
                goto label_6;
            }
            
            val_10.RemoveAt(index:  0);
            val_10 = this.usedLevels;
            if(val_10 != null)
            {
                goto label_7;
            }
            
            throw new NullReferenceException();
            label_6:
            UnityEngine.PlayerPrefs.SetString(key:  "twisty_arrow_used_levels", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_10));
            return (int)(1152921516081016528 + (val_8) << 2) + 32;
        }
        public TwistyGameManager()
        {
            this.currentLevel = 0;
        }
        private bool <get_IsCurrentLevelUsed>b__24_0(int x)
        {
            return (bool)x.Equals(obj:  this.currentLevel);
        }
    
    }

}
