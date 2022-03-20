using UnityEngine;

namespace SLC.Minigames.Just2Emojis
{
    public class Just2EmojisManager : MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>
    {
        // Fields
        private System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel> levels;
        private System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel> trackedLevels;
        private System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel> removedLevels;
        private bool hasAdded;
        private bool init;
        private SLC.Minigames.Just2Emojis.J2ELevel currentLevel;
        private string currentAnswer;
        private char[] currentAnswerCharacters;
        public int ftuxIndex;
        private int _continuesUsed;
        
        // Methods
        public override void InitMonoSingleton()
        {
            this.Initialize();
        }
        private void Initialize()
        {
            if(this.init == true)
            {
                    return;
            }
            
            this.ftuxIndex = 0;
            this.LoadData();
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_1.OnRestartMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisManager::ResetLevel());
            SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_3.OnContinueMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisManager::ContinueLevels());
            SLC.Minigames.MinigameManager val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnCheckpointRankUpContinue, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisManager::ContinueToggleUI()));
            if(val_7 != null)
            {
                    if(null != null)
            {
                goto label_14;
            }
            
            }
            
            val_5.OnCheckpointRankUpContinue = val_7;
            SLC.Minigames.MinigameManager val_8 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_10 = System.Delegate.Combine(a:  val_8.TogglePopupWindow, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisManager::TogglePopupWindow(bool showUI)));
            if(val_10 != null)
            {
                    if(null != null)
            {
                goto label_14;
            }
            
            }
            
            val_8.TogglePopupWindow = val_10;
            SLC.Minigames.MinigameManager val_11 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_13 = System.Delegate.Combine(a:  val_11.OnInjectTracking, b:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisManager::Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)));
            if(val_13 != null)
            {
                    if(null != null)
            {
                goto label_14;
            }
            
            }
            
            val_11.OnInjectTracking = val_13;
            this.trackedLevels.Clear();
            this.removedLevels.Clear();
            this.init = true;
            return;
            label_14:
        }
        private void Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)
        {
            obj.Add(key:  "Total Continues Used", value:  this._continuesUsed);
        }
        private void Start()
        {
            this._continuesUsed = 0;
            this.LoadLevel();
            this.hasAdded = true;
        }
        private void TogglePopupWindow(bool showUI)
        {
            SLC.Minigames.Just2Emojis.Just2EmojisUIController val_1 = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance;
            showUI = (~showUI) & 1;
            val_1.canvas.enabled = showUI;
        }
        private void LoadData()
        {
            var val_6;
            var val_7;
            string val_13;
            System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel> val_14;
            var val_15;
            this.levels = new System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel>();
            List.Enumerator<T> val_5 = MiniJSON.Json.Deserialize(json:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/Just2Emojis/emojis_levels").text).GetEnumerator();
            goto label_5;
            label_15:
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            object val_8 = val_6.Item["emojis"];
            val_13 = "answer";
            object val_9 = val_6.Item[val_13];
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_15 = 0;
            val_13 = 0;
            new SLC.Minigames.Just2Emojis.J2ELevel() = new SLC.Minigames.Just2Emojis.J2ELevel(index:  0, emojiSet:  null, answer:  val_9);
            val_14 = this.levels;
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_13 = new SLC.Minigames.Just2Emojis.J2ELevel();
            val_14.Add(item:  new SLC.Minigames.Just2Emojis.J2ELevel());
            val_14 = this.trackedLevels;
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14.Add(item:  new SLC.Minigames.Just2Emojis.J2ELevel());
            label_5:
            if(val_7.MoveNext() == true)
            {
                goto label_15;
            }
            
            val_7.Dispose();
        }
        private void ContinueLevels()
        {
            this.LoadLevel();
        }
        private void ResetLevel()
        {
            this._continuesUsed = 0;
            this.LoadLevel();
        }
        private void LoadLevel()
        {
            System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel> val_10;
            var val_11;
            System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel> val_10 = this.levels;
            int val_1 = UnityEngine.Random.Range(min:  0, max:  0);
            val_10 = this.levels;
            if(val_10 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_10 = val_10 + (val_1 << 3);
            this.currentLevel = val_10;
            if(val_2.ftux == false)
            {
                goto label_7;
            }
            
            label_14:
            if(this.currentLevel.lettersSet < 10)
            {
                goto label_30;
            }
            
            System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel> val_11 = this.levels;
            int val_3 = UnityEngine.Random.Range(min:  0, max:  0);
            if(val_11 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_11 = val_11 + (val_3 << 3);
            this.currentLevel = val_11;
            if(val_11 != null)
            {
                goto label_14;
            }
            
            label_7:
            val_10 = 0;
            label_33:
            int val_4 = MonoSingleton<Just2EmojisFTUXManager>.Instance.GetPlayerCurrentLevel();
            if(val_4 < 26)
            {
                    val_11 = 8;
            }
            else
            {
                    if(val_4 < 76)
            {
                    val_11 = 10;
            }
            else
            {
                    if(val_4 < 126)
            {
                    val_11 = 12;
            }
            else
            {
                    if(val_4 < 201)
            {
                    val_11 = 14;
            }
            else
            {
                    if(val_4 < 301)
            {
                    val_11 = 16;
            }
            
            }
            
            }
            
            }
            
            }
            
            if(W24 <= ((val_4 < 401) ? 18 : 21))
            {
                goto label_30;
            }
            
            System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel> val_12 = this.levels;
            val_10 = val_10 + 1;
            if(val_10 >= W1)
            {
                goto label_30;
            }
            
            int val_6 = UnityEngine.Random.Range(min:  0, max:  0);
            if(val_12 <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_12 = val_12 + (val_6 << 3);
            this.currentLevel = val_12;
            if(val_12 != null)
            {
                goto label_33;
            }
            
            label_30:
            string val_13 = "";
            this.currentAnswer = val_13;
            if(this.hasAdded != false)
            {
                    val_10 = this.levels;
                if(val_13 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_13 = val_13 + (val_1 << 3);
                this.TrackRemovedLevel(lvl:  ("" + (val_1) << 3) + 32);
            }
            
            this.levels.RemoveAt(index:  val_1);
            string val_7 = this.currentLevel.StrippedAnswer;
            char[] val_8 = new char[0];
            this.currentAnswerCharacters = val_8;
            var val_14 = 0;
            label_44:
            if(val_14 >= (val_8.Length << ))
            {
                goto label_42;
            }
            
            val_8[0] = '-';
            val_14 = val_14 + 1;
            if(this.currentAnswerCharacters != null)
            {
                goto label_44;
            }
            
            throw new NullReferenceException();
            label_42:
            MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.StartLevel(currentLevel:  this.currentLevel);
            if(this.levels > 9)
            {
                    return;
            }
            
            this.LoadData();
        }
        private void TrackRemovedLevel(SLC.Minigames.Just2Emojis.J2ELevel lvl)
        {
            if((this.trackedLevels.Contains(item:  lvl)) != false)
            {
                    bool val_2 = this.trackedLevels.Remove(item:  lvl);
            }
            
            this.removedLevels.Add(item:  lvl);
        }
        public void LetterClick(SLC.Minigames.Just2Emojis.Just2EmojisItem item)
        {
            System.Char[] val_8;
            var val_9;
            SLC.Minigames.Just2Emojis.Just2EmojisUIController val_1 = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance;
            if(val_1.shouldDisable != false)
            {
                    return;
            }
            
            Just2EmojisFTUXManager val_2 = MonoSingleton<Just2EmojisFTUXManager>.Instance;
            if(val_2.ftux != false)
            {
                    if((System.String.op_Inequality(a:  item.letter, b:  this.GetAnswerNextLetter())) == true)
            {
                    return;
            }
            
            }
            
            val_8 = this.currentAnswerCharacters;
            if(this.currentAnswerCharacters.Length < 1)
            {
                goto label_12;
            }
            
            val_9 = 0;
            label_15:
            if(val_8[0] == ('-'))
            {
                goto label_14;
            }
            
            val_9 = val_9 + 1;
            if(val_9 < this.currentAnswerCharacters.Length)
            {
                goto label_15;
            }
            
            label_12:
            val_9 = 0;
            goto label_16;
            label_14:
            mem2[0] = System.Char.Parse(s:  item.letter);
            val_8 = this.currentAnswerCharacters;
            label_16:
            string val_6 = 0.CreateString(val:  val_8);
            MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.OnLetterBlockClicked(letter:  item.letter, index:  0, item:  item);
            this.CheckForAnswer();
        }
        public void ClearCurrentAnswerChar(int index)
        {
            this.currentAnswerCharacters[index << 1] = '-';
            string val_1 = 0.CreateString(val:  this.currentAnswerCharacters);
        }
        public void AnswerClick(SLC.Minigames.Just2Emojis.Just2EmojisAnswer answer, System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Just2EmojisAnswer> answerBlocks)
        {
            if((this.currentAnswerCharacters[(answer.index) << 1]) == ('-'))
            {
                    return;
            }
            
            SLC.Minigames.Just2Emojis.Just2EmojisUIController val_1 = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance;
            bool val_7 = val_1.shouldDisable;
            if(val_7 != false)
            {
                    return;
            }
            
            if(val_7 >= true)
            {
                    var val_8 = 0;
                do
            {
                if(val_7 <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_7 = val_7 + 0;
                if((((val_1.shouldDisable + 0) + 32 + 56) == 0) && (val_8 >= answer.index))
            {
                    this.currentAnswerCharacters[0] = '-';
            }
            
                val_8 = val_8 + 1;
            }
            while(val_8 < this.currentAnswerCharacters[0]);
            
            }
            
            this.currentAnswer = 0.CreateString(val:  this.currentAnswerCharacters);
            SLC.Minigames.Just2Emojis.Just2EmojisUIController val_3 = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance;
            UnityEngine.Coroutine val_5 = val_3.StartCoroutine(routine:  val_3.DelayedReturn(index:  answer.index));
        }
        public void Hint()
        {
            System.Char[] val_7;
            var val_8;
            val_7 = this.currentAnswerCharacters;
            val_8 = 0;
            label_6:
            if(val_8 > 99)
            {
                goto label_5;
            }
            
            if((val_7[((long)(int)(val_1)) << 1]) == ('-'))
            {
                goto label_5;
            }
            
            int val_2 = UnityEngine.Random.Range(min:  0, max:  this.currentAnswerCharacters.Length);
            val_7 = this.currentAnswerCharacters;
            val_8 = val_8 + 1;
            if(val_7 != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_5:
            if(val_8 == 100)
            {
                    this.CheckForAnswer();
                val_7 = this.currentAnswerCharacters;
            }
            
            val_7[((long)(int)(val_1)) << 1] = this.currentLevel.StrippedAnswer.Chars[(long)UnityEngine.Random.Range(min:  0, max:  this.currentAnswerCharacters.Length)];
            MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.Hinted(index:  (long)UnityEngine.Random.Range(min:  0, max:  this.currentAnswerCharacters.Length));
            if((System.Linq.Enumerable.Contains<System.Char>(source:  this.currentAnswerCharacters, value:  '-')) != false)
            {
                    return;
            }
            
            this.CheckForAnswer();
        }
        public string GetAnswerNextLetter()
        {
            var val_5;
            string val_1 = this.currentLevel.StrippedAnswer;
            if(this.ftuxIndex < val_1.m_stringLength)
            {
                    string val_4 = this.currentLevel.StrippedAnswer.Chars[this.ftuxIndex].ToString();
                return (string)val_5;
            }
            
            val_5 = 0;
            return (string)val_5;
        }
        private void CheckForAnswer()
        {
            string val_2 = 0.CreateString(val:  this.currentAnswerCharacters);
            if((System.String.op_Equality(a:  val_2, b:  this.currentLevel.StrippedAnswer)) != false)
            {
                    UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.AnswerFeedback(correct:  true));
                this = 1152921504893161472;
                Just2EmojisFTUXManager val_6 = MonoSingleton<Just2EmojisFTUXManager>.Instance;
                if(val_6.ftux == false)
            {
                    return;
            }
            
                MonoSingleton<Just2EmojisFTUXManager>.Instance.EndFTUX();
                return;
            }
            
            if((System.Linq.Enumerable.Contains<System.Char>(source:  val_2, value:  '-')) != false)
            {
                    return;
            }
            
            UnityEngine.Coroutine val_10 = this.StartCoroutine(routine:  this.AnswerFeedback(correct:  false));
        }
        private System.Collections.IEnumerator AnswerFeedback(bool correct)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .correct = correct;
            return (System.Collections.IEnumerator)new Just2EmojisManager.<AnswerFeedback>d__26();
        }
        public int GetPlayerCurrentLevel()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            return (int)val_1.currentPlayerLevel;
        }
        private void ContinueToggleUI()
        {
            SLC.Minigames.Just2Emojis.Just2EmojisUIController val_1 = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance;
            val_1.canvas.enabled = true;
            MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.SetLettersInteractable(on:  true);
        }
        public string CurrentLevelInfo()
        {
            if(this.currentLevel != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public string ReturnWordPool()
        {
            var val_4;
            var val_5;
            var val_19;
            string val_2 = "CURRENT J2E LEVEL POOL" + System.Environment.NewLine;
            List.Enumerator<T> val_3 = this.levels.GetEnumerator();
            label_4:
            val_19 = public System.Boolean List.Enumerator<SLC.Minigames.Just2Emojis.J2ELevel>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_9 = val_2 + System.String.Format(format:  "Level: {0}", arg0:  val_4 + 40)(System.String.Format(format:  "Level: {0}", arg0:  val_4 + 40)) + System.Environment.NewLine;
            goto label_4;
            label_2:
            val_5.Dispose();
            string val_12 = val_2 + System.Environment.NewLine + "J2E LEVEL GRAVEYARD" + System.Environment.NewLine;
            List.Enumerator<T> val_13 = this.removedLevels.GetEnumerator();
            label_8:
            val_19 = public System.Boolean List.Enumerator<SLC.Minigames.Just2Emojis.J2ELevel>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_6;
            }
            
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_17 = val_12 + System.String.Format(format:  "Used level: {0}", arg0:  val_4 + 40)(System.String.Format(format:  "Used level: {0}", arg0:  val_4 + 40)) + System.Environment.NewLine;
            goto label_8;
            label_6:
            val_5.Dispose();
            return val_12;
        }
        public Just2EmojisManager()
        {
            this.trackedLevels = new System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel>();
            this.removedLevels = new System.Collections.Generic.List<SLC.Minigames.Just2Emojis.J2ELevel>();
        }
    
    }

}
