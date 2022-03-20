using UnityEngine;

namespace SLC.Minigames.WordChain
{
    public class WordChainManager : MonoSingleton<SLC.Minigames.WordChain.WordChainManager>
    {
        // Fields
        private SLC.Minigames.WordChain.WordChainUIController wordChainUIController;
        public SLC.Minigames.WordChain.WordChainLevel currentLevel;
        public int answerProgress;
        public System.Collections.Generic.List<int> hintOrder;
        private bool isPaused;
        private readonly string[] vocabulary;
        private System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLevel> allLevels;
        private RandomSet randomSet;
        
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
            System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLevel> val_23;
            var val_24;
            System.Action val_25;
            object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordChain/word_data").text);
            List.Enumerator<T> val_5 = GetEnumerator();
            label_26:
            if(val_7.MoveNext() == false)
            {
                goto label_7;
            }
            
            SLC.Minigames.WordChain.WordChainLevel val_9 = null;
            val_24 = 0;
            val_9 = new SLC.Minigames.WordChain.WordChainLevel();
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = null;
            if((val_6 + 24) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_23 = mem[val_6 + 16 + 32];
            val_23 = val_6 + 16 + 32;
            if(val_23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = mem[val_6 + 16 + 32 + 352 + 8];
            val_24 = val_6 + 16 + 32 + 352 + 8;
            if(val_23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 0;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            .word1 = val_23.ToUpper();
            val_24 = null;
            if((val_6 + 24) <= 2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_23 = mem[val_6 + 16 + 48];
            val_23 = val_6 + 16 + 48;
            if(val_23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = mem[val_6 + 16 + 48 + 352 + 8];
            val_24 = val_6 + 16 + 48 + 352 + 8;
            if(val_23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            .word2 = val_23.ToUpper();
            val_24 = null;
            if((val_6 + 24) <= 1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_23 = mem[val_6 + 16 + 40];
            val_23 = val_6 + 16 + 40;
            if(val_23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = mem[val_6 + 16 + 40 + 352 + 8];
            val_24 = val_6 + 16 + 40 + 352 + 8;
            if(val_23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 0;
            .answer = val_23.ToUpper();
            val_23 = this.allLevels;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23.Add(item:  val_9);
            goto label_26;
            label_7:
            val_7.Dispose();
            label_67:
            this.randomSet.addIntRange(lowest:  0, highest:  this.allLevels - 1);
            val_25 = 1152921504893161472;
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance)) != false)
            {
                    SLC.Minigames.MinigameManager val_16 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                System.Delegate val_18 = System.Delegate.Combine(a:  val_16.OnRestartMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordChain.WordChainManager::OnRestartFromCheckpoint()));
                if(val_18 != null)
            {
                    val_24 = null;
                if(null != val_24)
            {
                goto label_65;
            }
            
            }
            
                val_16.OnRestartMinigame = val_18;
                SLC.Minigames.MinigameManager val_19 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_25 = val_19.OnContinueMinigame;
                System.Delegate val_21 = System.Delegate.Combine(a:  val_25, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordChain.WordChainManager::HandleContinue()));
                if(val_21 != null)
            {
                    val_24 = null;
                if(null != val_24)
            {
                goto label_65;
            }
            
            }
            
                val_19.OnContinueMinigame = val_21;
                UnityEngine.Debug.LogError(message:  "subscribing to things");
            }
            
            SLC.Minigames.WordChain.WordChainLevel val_22 = this.GetNewLevel();
            this.currentLevel = val_22;
            this.InitializeLevel(level:  val_22);
            return;
            label_65:
            if(val_24 != 1)
            {
                goto label_66;
            }
            
            val_7.Dispose();
            if( == 0)
            {
                goto label_67;
            }
            
            throw null;
            label_66:
        }
        private void InitializeLevel(SLC.Minigames.WordChain.WordChainLevel level)
        {
            var val_4;
            this.isPaused = false;
            this.answerProgress = 0;
            this.hintOrder.Clear();
            this.hintOrder.AddRange(collection:  System.Linq.Enumerable.Range(start:  0, count:  level.answer.m_stringLength));
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
            this.wordChainUIController.InitializeLevel(level:  level);
        }
        private SLC.Minigames.WordChain.WordChainLevel GetNewLevel()
        {
            if(this.randomSet.remainingCount() == 0)
            {
                    System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLevel> val_4 = this.allLevels;
                this.randomSet.addIntRange(lowest:  0, highest:  val_4 - 1);
            }
            
            int val_3 = this.randomSet.roll(unweighted:  false);
            if(val_4 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_4 = val_4 + (val_3 << 3);
            return 0;
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
            this.InitializeLevel(level:  this.GetNewLevel());
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
        public void QuitGame()
        {
            App.Quit();
        }
        public System.Collections.Generic.List<string> GetRandomizedLetters(SLC.Minigames.WordChain.WordChainLevel level)
        {
            System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
            var val_6 = 0;
            label_5:
            if(val_6 >= level.answer.m_stringLength)
            {
                goto label_3;
            }
            
            val_1.Add(item:  level.answer.Chars[0].ToString());
            val_6 = val_6 + 1;
            if(level.answer != null)
            {
                goto label_5;
            }
            
            label_3:
            int val_4 = level.keyboardLetterNum - level.answer.m_stringLength;
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
            var val_7;
            object val_8;
            var val_9;
            DG.Tweening.TweenCallback val_10;
            var val_11;
            val_8 = this;
            if(answer.m_stringLength != this.currentLevel.answer.m_stringLength)
            {
                    return;
            }
            
            this.isPaused = true;
            if((answer.Equals(value:  this.currentLevel.answer)) != false)
            {
                    this.wordChainUIController.UpdateSuccessLevelUI();
                val_9 = 1;
                val_10 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.WordChain.WordChainManager::<CheckAnswerCorrect>b__21_0());
            }
            else
            {
                    this.wordChainUIController.UpdateFailedLevelUI();
                val_7 = 1152921504797261824;
                DG.Tweening.Tween val_4 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.WordChain.WordChainManager::<CheckAnswerCorrect>b__21_1()), ignoreTimeScale:  true);
                val_11 = null;
                val_11 = null;
                val_8 = WordChainManager.<>c.<>9__21_2;
                if(val_8 == null)
            {
                    DG.Tweening.TweenCallback val_5 = null;
                val_8 = val_5;
                val_5 = new DG.Tweening.TweenCallback(object:  WordChainManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WordChainManager.<>c::<CheckAnswerCorrect>b__21_2());
                WordChainManager.<>c.<>9__21_2 = val_8;
            }
            
                val_9 = 1;
                val_10 = val_8;
            }
            
            DG.Tweening.Tween val_6 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.5f, callback:  val_5, ignoreTimeScale:  true);
        }
        public WordChainManager()
        {
            int val_6;
            this.currentLevel = new SLC.Minigames.WordChain.WordChainLevel();
            this.hintOrder = new System.Collections.Generic.List<System.Int32>();
            string[] val_3 = new string[26];
            val_6 = val_3.Length;
            val_3[0] = "A";
            val_6 = val_6;
            val_3[1] = "B";
            val_6 = val_6;
            val_3[2] = "C";
            val_6 = val_6;
            val_3[3] = "D";
            val_6 = val_6;
            val_3[4] = "E";
            val_6 = val_6;
            val_3[5] = "F";
            val_6 = val_6;
            val_3[6] = "G";
            val_6 = val_6;
            val_3[7] = "H";
            val_6 = val_6;
            val_3[8] = "I";
            val_6 = val_6;
            val_3[9] = "J";
            val_6 = val_6;
            val_3[10] = "K";
            val_6 = val_6;
            val_3[11] = "L";
            val_6 = val_6;
            val_3[12] = "M";
            val_6 = val_6;
            val_3[13] = "N";
            val_6 = val_6;
            val_3[14] = "O";
            val_6 = val_6;
            val_3[15] = "P";
            val_6 = val_6;
            val_3[16] = "Q";
            val_6 = val_6;
            val_3[17] = "R";
            val_6 = val_6;
            val_3[18] = "S";
            val_6 = val_6;
            val_3[19] = "T";
            val_6 = val_6;
            val_3[20] = "U";
            val_6 = val_6;
            val_3[21] = "V";
            val_6 = val_6;
            val_3[22] = "W";
            val_6 = val_6;
            val_3[23] = "X";
            val_6 = val_6;
            val_3[24] = "Y";
            val_6 = val_6;
            val_3[25] = "Z";
            this.vocabulary = val_3;
            this.allLevels = new System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLevel>();
            this.randomSet = new RandomSet();
        }
        private void <CheckAnswerCorrect>b__21_0()
        {
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance)) == false)
            {
                    return;
            }
            
            bool val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete();
            this.InitializeLevel(level:  this.GetNewLevel());
        }
        private void <CheckAnswerCorrect>b__21_1()
        {
            var val_1 = 0;
            do
            {
                val_1 = val_1 + 1;
                if(val_1 >= this.currentLevel.answer.m_stringLength)
            {
                    return;
            }
            
                this.wordChainUIController.ShowHint();
            }
            while(this.currentLevel != null);
            
            throw new NullReferenceException();
        }
    
    }

}
