using UnityEngine;

namespace SLC.Minigames.Ladder
{
    public class WordLadderController : MonoSingleton<SLC.Minigames.Ladder.WordLadderController>
    {
        // Fields
        public const int MIN_LETTER_UNICODE = 65;
        public const int MAX_LETTER_UNICODE = 91;
        public const int MAX_WORD_LENGTH = 5;
        public const int MAX_FOUND_WORDS = 5;
        private System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderLevel> levels;
        private bool initialized;
        private System.Collections.Generic.Dictionary<int, System.Collections.Generic.HashSet<string>> validWords;
        private SLC.Minigames.Ladder.WordLadderLevel currentLevel;
        public bool IsGameOver;
        
        // Methods
        private void Initialize()
        {
            if(this.initialized != false)
            {
                    return;
            }
            
            this.LoadLevelDefinitions();
            this.LoadWordsLists();
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_1.OnRestartMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.Ladder.WordLadderController::StartLevel());
            SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_3.OnContinueMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.Ladder.WordLadderController::StartLevel());
            this.StartLevel();
            this.initialized = true;
            UnityEngine.Debug.LogError(message:  "Controller has been initialized");
        }
        private void StartLevel()
        {
            System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderLevel> val_3 = this.levels;
            int val_1 = UnityEngine.Random.Range(min:  0, max:  0);
            if(val_3 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_3 = val_3 + (val_1 << 3);
            this.currentLevel = val_3;
            mem2[0] = ???;
            this.levels.RemoveAt(index:  val_1);
            if(this.levels <= 0)
            {
                    this.LoadLevelDefinitions();
            }
            
            this.IsGameOver = false;
            MonoSingleton<SLC.Minigames.Ladder.WordLadderUIController>.Instance.StartLevel(currentLevel:  this.currentLevel);
        }
        private void LoadLevelDefinitions()
        {
            System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderLevel> val_9;
            System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderLevel> val_3 = null;
            val_9 = val_3;
            val_3 = new System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderLevel>();
            this.levels = val_9;
            char[] val_4 = new char[1];
            val_4[0] = '
            ';
            if(val_5.Length < 2)
            {
                    return;
            }
            
            var val_12 = 1;
            do
            {
                char[] val_6 = new char[1];
                val_6[0] = ',';
                System.String[] val_7 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordLadder/word_ladder_levels").text.Split(separator:  val_4)[val_12].Split(separator:  val_6);
                SLC.Minigames.Ladder.WordLadderLevel val_8 = null;
                val_9 = val_8;
                val_8 = new SLC.Minigames.Ladder.WordLadderLevel(starting:  val_7[0], required:  val_7[1]);
                this.levels.Add(item:  val_8);
                val_12 = val_12 + 1;
            }
            while(val_12 < val_5.Length);
        
        }
        public void SubmitWord(string chosenWord)
        {
            SLC.Minigames.Ladder.WordLadderLevel val_5;
            bool val_1 = this.currentLevel.ladder.Contains(item:  chosenWord);
            if(val_1 != false)
            {
                    val_1.ShowWordAlreadyUsed(chosenWord:  chosenWord);
                return;
            }
            
            if((System.String.op_Equality(a:  this.currentLevel.requiredWord, b:  chosenWord)) != false)
            {
                    this.LevelComplete();
                return;
            }
            
            this.currentLevel.ladder.Enqueue(item:  this.currentLevel.chosenWord);
            val_5 = this.currentLevel;
            if(W9 >= 6)
            {
                    string val_3 = this.currentLevel.ladder.Dequeue();
                val_5 = this.currentLevel;
            }
            
            this.currentLevel.chosenWord = chosenWord;
            MonoSingleton<SLC.Minigames.Ladder.WordLadderUIController>.Instance.ValidWord(currentLevel:  this.currentLevel);
        }
        private void LevelComplete()
        {
            MonoSingleton<SLC.Minigames.Ladder.WordLadderUIController>.Instance.LevelComplete(victory:  true);
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.LevelCompleteDelay(delay:  1.5f, wincondition:  true));
        }
        private void GameOver()
        {
            this.IsGameOver = true;
            MonoSingleton<SLC.Minigames.Ladder.WordLadderUIController>.Instance.LevelComplete(victory:  false);
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.LevelCompleteDelay(delay:  1.5f, wincondition:  false));
        }
        private System.Collections.IEnumerator LevelCompleteDelay(float delay, bool wincondition)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .delay = delay;
            .wincondition = wincondition;
            return (System.Collections.IEnumerator)new WordLadderController.<LevelCompleteDelay>d__15();
        }
        private void ShowWordAlreadyUsed(string chosenWord)
        {
            SLC.Minigames.Ladder.WordLadderUIController val_1 = MonoSingleton<SLC.Minigames.Ladder.WordLadderUIController>.Instance;
        }
        public System.Collections.Generic.List<string> GenerateLettersForTappedLetter(int index)
        {
            System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
            var val_10 = 64;
            do
            {
                System.Char[] val_2 = this.currentLevel.chosenWord.ToCharArray();
                var val_3 = val_10 + 1;
                if((val_2[((long)(int)(index)) << 1]) != val_3)
            {
                    mem2[0] = val_3;
                string val_4 = 0.CreateString(val:  val_2);
                if((this.validWords.Item[val_2.Length].Contains(item:  val_4)) != false)
            {
                    if((this.currentLevel.ladder.Contains(item:  val_4)) != true)
            {
                    val_1.Add(item:  val_3.ToString());
            }
            
            }
            
            }
            
                val_10 = val_10 + 1;
            }
            while(val_10 < 90);
            
            if((public System.Void System.Collections.Generic.List<System.String>::Add(System.String item)) != 0)
            {
                    return val_1;
            }
            
            this.GameOver();
            return val_1;
        }
        private void LoadWordsLists()
        {
            var val_18;
            var val_19;
            System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.HashSet<System.String>> val_70;
            string val_71;
            var val_72;
            var val_73;
            var val_74;
            var val_75;
            var val_76;
            var val_77;
            System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.HashSet<System.String>> val_1 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.HashSet<System.String>>();
            System.Collections.Generic.HashSet<System.String> val_2 = null;
            val_71 = public System.Void System.Collections.Generic.HashSet<System.String>::.ctor();
            val_2 = new System.Collections.Generic.HashSet<System.String>();
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(key:  3, value:  val_2);
            val_1.Add(key:  4, value:  new System.Collections.Generic.HashSet<System.String>());
            val_1.Add(key:  5, value:  new System.Collections.Generic.HashSet<System.String>());
            this.validWords = val_1;
            val_71 = public static UnityEngine.TextAsset UnityEngine.Resources::Load<UnityEngine.TextAsset>(string path);
            UnityEngine.TextAsset val_5 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordLadder/common_words/3");
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = public static UnityEngine.TextAsset UnityEngine.Resources::Load<UnityEngine.TextAsset>(string path);
            UnityEngine.TextAsset val_8 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordLadder/common_words/4");
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            object val_10 = MiniJSON.Json.Deserialize(json:  val_8.text);
            val_72 = 0;
            val_71 = public static UnityEngine.TextAsset UnityEngine.Resources::Load<UnityEngine.TextAsset>(string path);
            UnityEngine.TextAsset val_12 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordLadder/common_words/5");
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 0;
            object val_14 = MiniJSON.Json.Deserialize(json:  val_12.text);
            val_73 = 0;
            if((MiniJSON.Json.Deserialize(json:  val_5.text)) == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_17 = GetEnumerator();
            label_22:
            val_71 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_19.MoveNext() == false)
            {
                goto label_17;
            }
            
            val_70 = this.validWords;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 3;
            System.Collections.Generic.HashSet<System.String> val_21 = val_70.Item[3];
            if(val_18 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = mem[val_18 + 352 + 8];
            val_71 = val_18 + 352 + 8;
            val_70 = val_18;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = val_70.ToUpper();
            if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_23 = val_21.Add(item:  val_71);
            goto label_22;
            label_17:
            val_71 = public System.Void List.Enumerator<System.Object>::Dispose();
            val_19.Dispose();
            List.Enumerator<T> val_24 = GetEnumerator();
            label_29:
            val_71 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_19.MoveNext() == false)
            {
                goto label_24;
            }
            
            val_70 = this.validWords;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 4;
            System.Collections.Generic.HashSet<System.String> val_26 = val_70.Item[4];
            if(val_18 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = mem[val_18 + 352 + 8];
            val_71 = val_18 + 352 + 8;
            val_70 = val_18;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = val_70.ToUpper();
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_28 = val_26.Add(item:  val_71);
            goto label_29;
            label_24:
            val_71 = public System.Void List.Enumerator<System.Object>::Dispose();
            val_19.Dispose();
            List.Enumerator<T> val_29 = GetEnumerator();
            label_36:
            val_71 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_19.MoveNext() == false)
            {
                goto label_31;
            }
            
            val_70 = this.validWords;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 5;
            System.Collections.Generic.HashSet<System.String> val_31 = val_70.Item[5];
            if(val_18 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = mem[val_18 + 352 + 8];
            val_71 = val_18 + 352 + 8;
            val_70 = val_18;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = val_70.ToUpper();
            if(val_31 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_33 = val_31.Add(item:  val_71);
            goto label_36;
            label_31:
            val_19.Dispose();
            if(0 != 1)
            {
                    var val_34 = (340 == 340) ? 1 : 0;
                val_34 = ((0 >= 0) ? 1 : 0) & val_34;
                val_74 = 0 - val_34;
            }
            else
            {
                    val_74 = 0;
            }
            
            val_71 = public static UnityEngine.TextAsset UnityEngine.Resources::Load<UnityEngine.TextAsset>(string path);
            UnityEngine.TextAsset val_36 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordLadder/uncommon_words/3");
            if(val_36 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = public static UnityEngine.TextAsset UnityEngine.Resources::Load<UnityEngine.TextAsset>(string path);
            UnityEngine.TextAsset val_39 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordLadder/uncommon_words/4");
            if(val_39 == null)
            {
                    throw new NullReferenceException();
            }
            
            object val_41 = MiniJSON.Json.Deserialize(json:  val_39.text);
            val_75 = 0;
            val_71 = public static UnityEngine.TextAsset UnityEngine.Resources::Load<UnityEngine.TextAsset>(string path);
            UnityEngine.TextAsset val_43 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordLadder/uncommon_words/5");
            if(val_43 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 0;
            object val_45 = MiniJSON.Json.Deserialize(json:  val_43.text);
            val_76 = 0;
            if((MiniJSON.Json.Deserialize(json:  val_36.text)) == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_48 = GetEnumerator();
            label_59:
            val_71 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_19.MoveNext() == false)
            {
                goto label_54;
            }
            
            val_70 = this.validWords;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 3;
            System.Collections.Generic.HashSet<System.String> val_50 = val_70.Item[3];
            if(val_18 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = mem[val_18 + 352 + 8];
            val_71 = val_18 + 352 + 8;
            val_70 = val_18;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = val_70.ToUpper();
            if(val_50 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_52 = val_50.Add(item:  val_71);
            goto label_59;
            label_54:
            val_71 = public System.Void List.Enumerator<System.Object>::Dispose();
            val_19.Dispose();
            if(1 != 1)
            {
                    var val_53 = (489 == 489) ? 1 : 0;
                val_53 = ((1 >= 0) ? 1 : 0) & val_53;
                val_77 = 1 - val_53;
            }
            else
            {
                    val_77 = 0;
            }
            
            List.Enumerator<T> val_55 = GetEnumerator();
            label_68:
            val_71 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_19.MoveNext() == false)
            {
                goto label_63;
            }
            
            val_70 = this.validWords;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 4;
            System.Collections.Generic.HashSet<System.String> val_57 = val_70.Item[4];
            if(val_18 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = mem[val_18 + 352 + 8];
            val_71 = val_18 + 352 + 8;
            val_70 = val_18;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = val_70.ToUpper();
            if(val_57 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_59 = val_57.Add(item:  val_71);
            goto label_68;
            label_63:
            val_77 = val_77 + 1;
            val_71 = public System.Void List.Enumerator<System.Object>::Dispose();
            mem2[0] = 562;
            val_19.Dispose();
            if(val_77 == 1)
            {
                    throw new NullReferenceException();
            }
            
            var val_60 = ((1152921519804305136 + ((val_77 + 1)) << 2) == 562) ? 1 : 0;
            val_60 = ((val_77 >= 0) ? 1 : 0) & val_60;
            val_60 = val_77 - val_60;
            val_60 = val_60 + 1;
            List.Enumerator<T> val_62 = GetEnumerator();
            label_76:
            val_71 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_19.MoveNext() == false)
            {
                goto label_71;
            }
            
            val_70 = this.validWords;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 5;
            if(val_18 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = mem[val_18 + 352 + 8];
            val_71 = val_18 + 352 + 8;
            val_70 = val_18;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            bool val_66 = val_70.Item[5].Add(item:  val_70.ToUpper());
            goto label_76;
            label_71:
            mem2[0] = 635;
            val_19.Dispose();
        }
        public override void InitMonoSingleton()
        {
            this.InitMonoSingleton();
            this.Initialize();
        }
        public WordLadderController()
        {
        
        }
    
    }

}
