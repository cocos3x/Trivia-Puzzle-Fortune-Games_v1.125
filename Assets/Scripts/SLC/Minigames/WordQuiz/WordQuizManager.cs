using UnityEngine;

namespace SLC.Minigames.WordQuiz
{
    public class WordQuizManager : MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>
    {
        // Fields
        private SLC.Minigames.WordQuiz.WordQuizUIController wordQuizUIController;
        public SLC.Minigames.WordQuiz.WordQuizLevel currentLevel;
        public int answerProgress;
        public System.Collections.Generic.List<int> hintOrder;
        private bool isPaused;
        private readonly string[] vocabulary;
        private System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLevel> allLevels;
        private RandomSet randomSet;
        private System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLevel> removedLevels;
        private System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLevel> trackedLevels;
        private bool hasAdded;
        private int _continuesUsed;
        
        // Properties
        public decimal hintCost { get; }
        public bool IsPaused { get; }
        
        // Methods
        public decimal get_hintCost()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            return new System.Decimal() {flags = val_1.hintCost, hi = val_1.hintCost};
        }
        public bool get_IsPaused()
        {
            return (bool)this.isPaused;
        }
        private void Start()
        {
            var val_6;
            var val_7;
            SLC.Minigames.WordQuiz.WordQuizManager val_37;
            string val_38;
            string val_39;
            string val_40;
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_41;
            val_37 = this;
            mem[1152921519784784424] = 0;
            object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordQuiz/word_data").text);
            List.Enumerator<T> val_5 = GetEnumerator();
            label_39:
            if(val_7.MoveNext() == false)
            {
                goto label_7;
            }
            
            SLC.Minigames.WordQuiz.WordQuizLevel val_9 = null;
            val_39 = 0;
            val_9 = new SLC.Minigames.WordQuiz.WordQuizLevel();
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = null;
            if((val_6 + 24) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_38 = mem[val_6 + 16 + 32];
            val_38 = val_6 + 16 + 32;
            if(val_38 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = mem[val_6 + 16 + 32 + 352 + 8];
            val_39 = val_6 + 16 + 32 + 352 + 8;
            if(val_38 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = 0;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            .word = val_38.ToUpper();
            val_39 = null;
            var val_37 = val_6 + 296;
            if((val_6 + 24) < 4)
            {
                goto label_17;
            }
            
            val_40 = (SLC.Minigames.WordQuiz.WordQuizLevel)[1152921519784828608].definition;
            var val_39 = 2;
            val_37 = val_37 & 255;
            if(val_39 >= (val_6 + 24))
            {
                goto label_20;
            }
            
            if((val_6 + 24) <= val_39)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_38 = val_6 + 16;
            val_38 = val_38 + 16;
            if(((val_6 + 16 + 16) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
            mem2[0] = mem[(SLC.Minigames.WordQuiz.WordQuizLevel)[1152921519784828608].definition] + (val_39 == 2) ? "" : ","((val_39 == 2) ? "" : ",") + (val_6 + 16 + 16) + 32((val_6 + 16 + 16) + 32);
            val_39 = null;
            val_39 = val_39 + 1;
            throw new NullReferenceException();
            label_17:
            if((val_6 + 24) <= 2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_38 = mem[val_6 + 16 + 48];
            val_38 = val_6 + 16 + 48;
            if(val_38 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = mem[val_6 + 16 + 48 + 352 + 8];
            val_39 = val_6 + 16 + 48 + 352 + 8;
            val_40 = val_9;
            .definition = val_38;
            if(val_38 != 0)
            {
                goto label_28;
            }
            
            throw new NullReferenceException();
            label_20:
            if(mem[(SLC.Minigames.WordQuiz.WordQuizLevel)[1152921519784828608].definition] == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "\"";
            val_37 = this;
            string val_14 = mem[(SLC.Minigames.WordQuiz.WordQuizLevel)[1152921519784828608].definition].Replace(oldValue:  val_39, newValue:  "");
            mem2[0] = val_14;
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_28:
            val_39 = "\t";
            if((val_14.Contains(value:  val_39)) != false)
            {
                    val_38 = mem[(SLC.Minigames.WordQuiz.WordQuizLevel)[1152921519784828608].definition];
                if(val_38 == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_39 = "\t";
                string val_16 = val_38.Replace(oldValue:  val_39, newValue:  System.String.alignConst);
            }
            
            val_38 = mem[(SLC.Minigames.WordQuiz.WordQuizLevel)[1152921519784828608].definition];
            if(val_38 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "\n";
            if((val_38.Contains(value:  val_39)) != false)
            {
                    val_38 = mem[(SLC.Minigames.WordQuiz.WordQuizLevel)[1152921519784828608].definition];
                if(val_38 == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_39 = "\n";
                string val_18 = val_38.Replace(oldValue:  val_39, newValue:  System.String.alignConst);
            }
            
            val_38 = mem[(SLC.Minigames.WordQuiz.WordQuizLevel)[1152921519784828608].definition];
            if(val_38 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = 0;
            mem2[0] = val_38.Trim();
            val_38 = mem[1152921519784784392];
            if(val_38 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_38.Add(item:  val_9);
            goto label_39;
            label_7:
            val_7.Dispose();
            label_98:
            mem[1152921519784784400].addIntRange(lowest:  0, highest:  (mem[1152921519784784392] + 24) - 1);
            mem[1152921519784784416].AddRange(collection:  mem[1152921519784784392]);
            val_41 = 1152921504893161472;
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance)) != false)
            {
                    SLC.Minigames.MinigameManager val_23 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                System.Delegate val_25 = System.Delegate.Combine(a:  val_23.OnRestartMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordQuiz.WordQuizManager::OnRestartFromCheckpoint()));
                if(val_25 != null)
            {
                    val_39 = null;
                if(null != val_39)
            {
                goto label_96;
            }
            
            }
            
                val_23.OnRestartMinigame = val_25;
                SLC.Minigames.MinigameManager val_26 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                System.Delegate val_28 = System.Delegate.Combine(a:  val_26.OnContinueMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordQuiz.WordQuizManager::HandleContinue()));
                if(val_28 != null)
            {
                    val_39 = null;
                if(null != val_39)
            {
                goto label_96;
            }
            
            }
            
                val_26.OnContinueMinigame = val_28;
                SLC.Minigames.MinigameManager val_29 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                System.Delegate val_31 = System.Delegate.Combine(a:  val_29.TogglePopupWindow, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.WordQuiz.WordQuizManager::TogglePopupWindow(bool showing)));
                if(val_31 != null)
            {
                    val_39 = null;
                if(null != val_39)
            {
                goto label_96;
            }
            
            }
            
                val_29.TogglePopupWindow = val_31;
                SLC.Minigames.MinigameManager val_32 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_41 = val_32.OnInjectTracking;
                System.Delegate val_34 = System.Delegate.Combine(a:  val_41, b:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Minigames.WordQuiz.WordQuizManager::Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)));
                if(val_34 != null)
            {
                    val_39 = null;
                if(null != val_39)
            {
                goto label_96;
            }
            
            }
            
                val_32.OnInjectTracking = val_34;
            }
            
            SLC.Minigames.WordQuiz.WordQuizLevel val_35 = this.GetNewLevel();
            mem[1152921519784784352] = val_35;
            this.InitializeLevel(level:  val_35);
            MonoSingleton<MinigameAudioController>.Instance.StartMusic(clipIndex:  0);
            return;
            label_96:
            if(val_39 != 1)
            {
                goto label_97;
            }
            
            val_7.Dispose();
            if( == 0)
            {
                goto label_98;
            }
            
            throw null;
            label_97:
        }
        private void Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)
        {
            obj.Add(key:  "Total Continues Used", value:  this._continuesUsed);
        }
        private void TogglePopupWindow(bool showing)
        {
            if(this.wordQuizUIController != null)
            {
                    this.wordQuizUIController.HideUIForPopup(showingPopup:  showing);
                return;
            }
            
            throw new NullReferenceException();
        }
        private void InitializeLevel(SLC.Minigames.WordQuiz.WordQuizLevel level)
        {
            var val_4;
            this.isPaused = false;
            this.answerProgress = 0;
            this.hintOrder.Clear();
            this.hintOrder.AddRange(collection:  System.Linq.Enumerable.Range(start:  0, count:  level.word.m_stringLength));
            PluginExtension.Shuffle<System.Int32>(list:  this.hintOrder, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            SLC.Minigames.MinigameManager val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_2.currentPlayerLevel < 26)
            {
                    val_4 = 8;
            }
            else
            {
                    if(val_2.currentPlayerLevel < 76)
            {
                    val_4 = 10;
            }
            else
            {
                    if(val_2.currentPlayerLevel < 126)
            {
                    val_4 = 12;
            }
            else
            {
                    if(val_2.currentPlayerLevel < 201)
            {
                    val_4 = 14;
            }
            else
            {
                    if(val_2.currentPlayerLevel < 301)
            {
                    val_4 = 16;
            }
            
            }
            
            }
            
            }
            
            }
            
            level.keyboardLetterNum = (val_2.currentPlayerLevel < 401) ? 18 : 21;
            this.currentLevel = level;
            this.hasAdded = true;
            this.wordQuizUIController.InitializeLevel(level:  level);
        }
        private SLC.Minigames.WordQuiz.WordQuizLevel GetNewLevel()
        {
            if(this.randomSet.remainingCount() == 0)
            {
                    this.randomSet.reset();
                this.removedLevels.Clear();
                this.trackedLevels.Clear();
                this.trackedLevels.AddRange(collection:  this.allLevels);
            }
            
            bool val_3 = this.hasAdded;
            if(val_3 != false)
            {
                    this.TrackRemovedLevel(lvl:  this.currentLevel);
            }
            
            int val_2 = this.randomSet.roll(unweighted:  false);
            if(val_3 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_3 = val_3 + (val_2 << 3);
            return (SLC.Minigames.WordQuiz.WordQuizLevel)(this.hasAdded + (val_2) << 3) + 32;
        }
        private void TrackRemovedLevel(SLC.Minigames.WordQuiz.WordQuizLevel lvl)
        {
            if((this.trackedLevels.Contains(item:  lvl)) != false)
            {
                    bool val_2 = this.trackedLevels.Remove(item:  lvl);
            }
            
            this.removedLevels.Add(item:  lvl);
        }
        private int GetKeyboardLetterNumByLevel(int levelIndex)
        {
            if(levelIndex < 26)
            {
                    return 8;
            }
            
            if(levelIndex < 76)
            {
                    return 10;
            }
            
            if(levelIndex < 126)
            {
                    return 12;
            }
            
            if(levelIndex < 201)
            {
                    return 14;
            }
            
            if(levelIndex >= 301)
            {
                    return (int)(levelIndex < 401) ? 18 : 21;
            }
            
            return 16;
        }
        private void HandleContinue()
        {
            this.InitializeLevel(level:  this.GetNewLevel());
        }
        private void OnRestartFromCheckpoint()
        {
            this._continuesUsed = 0;
            this.InitializeLevel(level:  this.GetNewLevel());
        }
        public void QuitGame()
        {
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance)) == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowGameOver();
        }
        public bool ShouldShowFTUX()
        {
            var val_5;
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance)) != false)
            {
                    SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                var val_4 = (val_3.currentPlayerLevel == 0) ? 1 : 0;
                return (bool)val_5;
            }
            
            val_5 = 0;
            return (bool)val_5;
        }
        public System.Collections.Generic.List<string> GetRandomizedLetters(SLC.Minigames.WordQuiz.WordQuizLevel level)
        {
            System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
            var val_6 = 0;
            label_5:
            if(val_6 >= level.word.m_stringLength)
            {
                goto label_3;
            }
            
            val_1.Add(item:  level.word.Chars[0].ToString());
            val_6 = val_6 + 1;
            if(level.word != null)
            {
                goto label_5;
            }
            
            label_3:
            int val_4 = level.keyboardLetterNum - level.word.m_stringLength;
            if(val_4 < 1)
            {
                    return val_1;
            }
            
            var val_8 = 0;
            do
            {
                val_1.Add(item:  this.vocabulary[UnityEngine.Random.Range(min:  0, max:  this.vocabulary.Length)]);
                val_8 = val_8 + 1;
            }
            while(val_8 < val_4);
            
            return val_1;
        }
        public void CheckAnswerCorrect(string answer)
        {
            DG.Tweening.TweenCallback val_9;
            if(answer.m_stringLength != this.currentLevel.word.m_stringLength)
            {
                    return;
            }
            
            this.isPaused = true;
            if((answer.Equals(value:  this.currentLevel.word)) != false)
            {
                    MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Win", clipIndex:  0, volumeScale:  1f);
                this.wordQuizUIController.UpdateSuccessLevelUI();
                DG.Tweening.TweenCallback val_3 = null;
                val_9 = val_3;
                val_3 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.WordQuiz.WordQuizManager::<CheckAnswerCorrect>b__28_0());
            }
            else
            {
                    MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Lose", clipIndex:  0, volumeScale:  1f);
                this.wordQuizUIController.checkMarkWrong.SetActive(value:  true);
                DG.Tweening.Tween val_6 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.WordQuiz.WordQuizManager::<CheckAnswerCorrect>b__28_1()), ignoreTimeScale:  true);
                DG.Tweening.TweenCallback val_7 = null;
                val_9 = val_7;
                val_7 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.WordQuiz.WordQuizManager::<CheckAnswerCorrect>b__28_2());
            }
            
            DG.Tweening.Tween val_8 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.5f, callback:  val_7, ignoreTimeScale:  true);
        }
        private void Update()
        {
            if((UnityEngine.Input.GetKeyUp(key:  32)) == false)
            {
                    return;
            }
            
            string val_2 = this.ReturnWordPool();
        }
        public string ReturnWordPool()
        {
            var val_4;
            var val_5;
            var val_18;
            string val_2 = "CURRENT LEVEL POOL" + System.Environment.NewLine;
            List.Enumerator<T> val_3 = this.trackedLevels.GetEnumerator();
            label_4:
            val_18 = public System.Boolean List.Enumerator<SLC.Minigames.WordQuiz.WordQuizLevel>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_9 = val_2 + System.String.Format(format:  "Word: <color=#F2240D>{0}</color>", arg0:  val_4 + 16)(System.String.Format(format:  "Word: <color=#F2240D>{0}</color>", arg0:  val_4 + 16)) + System.Environment.NewLine;
            goto label_4;
            label_2:
            val_5.Dispose();
            string val_11 = val_2 + "WORD GRAVEYARD" + System.Environment.NewLine;
            List.Enumerator<T> val_12 = this.removedLevels.GetEnumerator();
            label_8:
            val_18 = public System.Boolean List.Enumerator<SLC.Minigames.WordQuiz.WordQuizLevel>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_6;
            }
            
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_16 = val_11 + System.String.Format(format:  "Used Word: <color=#F2240D>{0}</color>", arg0:  val_4 + 16)(System.String.Format(format:  "Used Word: <color=#F2240D>{0}</color>", arg0:  val_4 + 16)) + System.Environment.NewLine;
            goto label_8;
            label_6:
            val_5.Dispose();
            return val_11;
        }
        public string ReturnCurrentAnswer()
        {
            if(this.currentLevel != null)
            {
                    return (string)this.currentLevel.word;
            }
            
            throw new NullReferenceException();
        }
        public WordQuizManager()
        {
            int val_8;
            this.currentLevel = new SLC.Minigames.WordQuiz.WordQuizLevel();
            this.hintOrder = new System.Collections.Generic.List<System.Int32>();
            string[] val_3 = new string[26];
            val_8 = val_3.Length;
            val_3[0] = "A";
            val_8 = val_8;
            val_3[1] = "B";
            val_8 = val_8;
            val_3[2] = "C";
            val_8 = val_8;
            val_3[3] = "D";
            val_8 = val_8;
            val_3[4] = "E";
            val_8 = val_8;
            val_3[5] = "F";
            val_8 = val_8;
            val_3[6] = "G";
            val_8 = val_8;
            val_3[7] = "H";
            val_8 = val_8;
            val_3[8] = "I";
            val_8 = val_8;
            val_3[9] = "J";
            val_8 = val_8;
            val_3[10] = "K";
            val_8 = val_8;
            val_3[11] = "L";
            val_8 = val_8;
            val_3[12] = "M";
            val_8 = val_8;
            val_3[13] = "N";
            val_8 = val_8;
            val_3[14] = "O";
            val_8 = val_8;
            val_3[15] = "P";
            val_8 = val_8;
            val_3[16] = "Q";
            val_8 = val_8;
            val_3[17] = "R";
            val_8 = val_8;
            val_3[18] = "S";
            val_8 = val_8;
            val_3[19] = "T";
            val_8 = val_8;
            val_3[20] = "U";
            val_8 = val_8;
            val_3[21] = "V";
            val_8 = val_8;
            val_3[22] = "W";
            val_8 = val_8;
            val_3[23] = "X";
            val_8 = val_8;
            val_3[24] = "Y";
            val_8 = val_8;
            val_3[25] = "Z";
            this.vocabulary = val_3;
            this.allLevels = new System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLevel>();
            this.randomSet = new RandomSet();
            this.removedLevels = new System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLevel>();
            this.trackedLevels = new System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLevel>();
        }
        private void <CheckAnswerCorrect>b__28_0()
        {
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance)) == false)
            {
                    return;
            }
            
            bool val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete();
            this.InitializeLevel(level:  this.GetNewLevel());
        }
        private void <CheckAnswerCorrect>b__28_1()
        {
            this.wordQuizUIController.checkMarkWrong.SetActive(value:  false);
            var val_1 = 0;
            do
            {
                val_1 = val_1 + 1;
                if(val_1 >= this.currentLevel.word.m_stringLength)
            {
                    return;
            }
            
                this.wordQuizUIController.ShowHint();
            }
            while(this.currentLevel != null);
            
            throw new NullReferenceException();
        }
        private void <CheckAnswerCorrect>b__28_2()
        {
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance)) == false)
            {
                    return;
            }
            
            int val_5 = this._continuesUsed;
            val_5 = val_5 + 1;
            this._continuesUsed = val_5;
            bool val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
        }
    
    }

}
