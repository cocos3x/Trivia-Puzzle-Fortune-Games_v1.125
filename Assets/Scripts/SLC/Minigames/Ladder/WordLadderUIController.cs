using UnityEngine;

namespace SLC.Minigames.Ladder
{
    public class WordLadderUIController : MonoSingleton<SLC.Minigames.Ladder.WordLadderUIController>
    {
        // Fields
        private UnityEngine.GameObject container;
        private UnityEngine.GameObject chosenWord;
        private UnityEngine.Transform chosenWordRoot;
        private UnityEngine.UI.Text levelTitle;
        private UnityEngine.GameObject keyboardLetter;
        private UnityEngine.Transform[] keyboardContainers;
        private UnityEngine.Transform Arrow;
        private UnityEngine.UI.Text[] foundWords;
        private UnityEngine.GameObject checkMark;
        private UnityEngine.GameObject crossMark;
        private SLC.Minigames.Ladder.FlyKeyBoardLetter FlyKeyBoardLetter;
        private UnityEngine.Sprite chosenLetterSprite;
        private UnityEngine.Sprite unChosenLetterSprite;
        private System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderKeyboardLetter> keyboardLetters;
        private System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderLetter> chosenLetters;
        private SLC.Minigames.Ladder.WordLadderLetter chosenLetter;
        private SLC.Minigames.Ladder.WordLadderKeyboardLetter itemClicked;
        private bool initialized;
        
        // Methods
        public override void InitMonoSingleton()
        {
            this.InitMonoSingleton();
            this.Initialize();
        }
        private void Initialize()
        {
            if(this.initialized == true)
            {
                    return;
            }
            
            this.keyboardLetters = new System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderKeyboardLetter>();
            this.chosenLetters = new System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderLetter>();
            var val_14 = 64;
            do
            {
                var val_3 = val_14 - 64;
                val_3 = val_3 >> 33;
                SLC.Minigames.Ladder.WordLadderKeyboardLetter val_6 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.keyboardLetter, parent:  this.keyboardContainers[val_3]).GetComponent<SLC.Minigames.Ladder.WordLadderKeyboardLetter>();
                mem2[0] = 0;
                mem2[0] = val_14 + 1.ToString();
                val_6.gameObject.SetActive(value:  false);
                this.keyboardLetters.Add(item:  val_6);
                val_14 = val_14 + 1;
            }
            while(val_14 < 90);
            
            var val_15 = 0;
            do
            {
                SLC.Minigames.Ladder.WordLadderLetter val_10 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.chosenWord, parent:  this.chosenWordRoot).GetComponent<SLC.Minigames.Ladder.WordLadderLetter>();
                val_10.index = val_15 + 1;
                val_10.letter = "A";
                val_10.gameObject.SetActive(value:  false);
                this.chosenLetters.Add(item:  val_10);
                val_15 = val_15 + 1;
            }
            while(val_15 < 4);
            
            this.initialized = true;
        }
        public void StartLevel(SLC.Minigames.Ladder.WordLadderLevel currentLevel)
        {
            if(this.initialized != true)
            {
                    this.Initialize();
            }
            
            this.SetupChosenLetters(currentLevel:  currentLevel);
            this.Arrow.gameObject.SetActive(value:  false);
            this.RestChosenLetters();
            this.checkMark.SetActive(value:  false);
            this.crossMark.SetActive(value:  false);
            this.RestFoundWord();
            this.HideKeyboard();
            string val_2 = System.String.Format(format:  "<color=yellow> <size=50>Change</size></color> <size=70>{0}</size> <color=yellow><size=70>to</size></color> <size=90>{1}</size>", arg0:  currentLevel.startingWord, arg1:  currentLevel.requiredWord);
            this.container.SetActive(value:  true);
        }
        private void RestFoundWord()
        {
            var val_2 = 0;
            do
            {
                if(val_2 >= this.foundWords.Length)
            {
                    return;
            }
            
                UnityEngine.UI.Text val_1 = this.foundWords[val_2];
                val_2 = val_2 + 1;
            }
            while(this.foundWords != null);
            
            throw new NullReferenceException();
        }
        public void RestChosenLetters()
        {
            List.Enumerator<T> val_1 = this.chosenLetters.GetEnumerator();
            label_4:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            0.SetSpriteAndText(s:  this.unChosenLetterSprite, textSize:  100);
            goto label_4;
            label_2:
            0.Dispose();
        }
        public void LetterChosen(int clickedIndex)
        {
            UnityEngine.Sprite val_9;
            var val_10;
            System.Collections.Generic.List<SLC.Minigames.Ladder.WordLadderKeyboardLetter> val_11;
            var val_12;
            bool val_10 = true;
            var val_11 = 0;
            label_8:
            val_10 = val_10 & 4294967295;
            if(val_11 >= val_10)
            {
                goto label_2;
            }
            
            if(val_11 >= val_10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_10 = val_10 + 0;
            if(clickedIndex == val_11)
            {
                    val_9 = this.chosenLetterSprite;
                val_10 = 90;
            }
            else
            {
                    val_9 = this.unChosenLetterSprite;
                val_10 = 100;
            }
            
            ((true & 4294967295) + 0) + 32.SetSpriteAndText(s:  val_9, textSize:  100);
            val_11 = val_11 + 1;
            if(this.chosenLetters != null)
            {
                goto label_8;
            }
            
            label_2:
            if(val_10 <= clickedIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_10 = val_10 + (clickedIndex << 3);
            this.chosenLetter = ((true & 4294967295) + (clickedIndex) << 3) + 32;
            UnityEngine.Vector3 val_2 = ((true & 4294967295) + (clickedIndex) << 3) + 32.transform.position;
            UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.MoveArrow(x:  val_2.x));
            val_11 = this.keyboardLetters;
            var val_12 = 4;
            do
            {
                var val_7 = val_12 - 4;
                if(val_7 >= 1152921519805541968)
            {
                    return;
            }
            
                if(1152921519805541968 <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((public static System.Void System.Array::Sort<Spine.Unity.SubmeshInstruction>(T[] array, int index, int length, System.Collections.Generic.IComparer<T> comparer)) <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((MonoSingleton<SLC.Minigames.Ladder.WordLadderController>.Instance.GenerateLettersForTappedLetter(index:  clickedIndex).Contains(item:  public static System.Void System.Array::Sort<Spine.Unity.SubmeshInstruction>(T[] array, int index, int length, System.Collections.Generic.IComparer<T> comparer).__il2cppRuntimeField_30)) != false)
            {
                    val_12 = 1;
            }
            else
            {
                    val_12 = 0;
            }
            
                public static System.Void System.Array::Sort<Spine.Unity.SubmeshInstruction>(T[] array, int index, int length, System.Collections.Generic.IComparer<T> comparer).__il2cppRuntimeField_20.gameObject.SetActive(value:  false);
                val_11 = this.keyboardLetters;
                val_12 = val_12 + 1;
            }
            while(val_11 != null);
            
            throw new NullReferenceException();
        }
        private System.Collections.IEnumerator MoveArrow(float x)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .x = x;
            return (System.Collections.IEnumerator)new WordLadderUIController.<MoveArrow>d__24();
        }
        public void SubmitLetter(SLC.Minigames.Ladder.WordLadderKeyboardLetter item)
        {
            this.itemClicked = item;
            this.Arrow.gameObject.SetActive(value:  false);
            MonoSingleton<SLC.Minigames.Ladder.WordLadderController>.Instance.SubmitWord(chosenWord:  this.CalculateWord(toCalculate:  this.itemClicked));
        }
        private System.Collections.IEnumerator FlydLadderKeyboardLetter(SLC.Minigames.Ladder.WordLadderKeyboardLetter itemClicked)
        {
            .<>1__state = 0;
            return (System.Collections.IEnumerator)new WordLadderUIController.<FlydLadderKeyboardLetter>d__26();
        }
        private string CalculateWord(SLC.Minigames.Ladder.WordLadderKeyboardLetter toCalculate)
        {
            string val_6;
            var val_7 = 4;
            label_19:
            var val_2 = val_7 - 4;
            if(val_2 >= 1152921504630968320)
            {
                goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
            }
            
            if(1152921504630968320 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(gameObject.activeSelf != false)
            {
                    if(1152921504630968320 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((System.Boolean System.Array::InternalArray__ICollection_Contains<TMPro.TMP_WordInfo>(TMPro.TMP_WordInfo item)) == this.chosenLetter)
            {
                
            }
            else
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_6 = mem[UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32 + 48];
                val_6 = UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32 + 48;
            }
            
                System.Text.StringBuilder val_6 = new System.Text.StringBuilder().Append(value:  val_6);
            }
            
            val_7 = val_7 + 1;
            if(this.chosenLetters != null)
            {
                goto label_19;
            }
            
            goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
        }
        public void ToggleUI(bool state)
        {
            if(this.container != null)
            {
                    this.container.SetActive(value:  state);
                return;
            }
            
            throw new NullReferenceException();
        }
        public void ValidWord(SLC.Minigames.Ladder.WordLadderLevel currentLevel)
        {
            .<>4__this = this;
            .currentLevel = currentLevel;
            this.UpdateFoundWords(currentLevel:  currentLevel);
            this.HideKeyboard();
            UnityEngine.Vector3 val_3 = this.chosenLetter.transform.position;
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            UnityEngine.Vector3 val_6 = this.itemClicked.transform.position;
            UnityEngine.Vector2 val_7 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
            this.FlyKeyBoardLetter.setUp(letter:  currentLevel, posStart:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y}, posStop:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y}, callback:  new System.Action(object:  new WordLadderUIController.<>c__DisplayClass29_0(), method:  System.Void WordLadderUIController.<>c__DisplayClass29_0::<ValidWord>b__0()));
            this.chosenLetter = 0;
            this.itemClicked = 0;
        }
        public void LevelComplete(bool victory)
        {
            this.HideKeyboard();
            victory = victory;
            this.checkMark.SetActive(value:  victory);
            this.crossMark.SetActive(value:  (~victory) & 1);
        }
        public void WordAlreadyUsed(string usedWord)
        {
        
        }
        private void UpdateFoundWords(SLC.Minigames.Ladder.WordLadderLevel currentLevel)
        {
            System.Collections.Generic.Queue<System.String> val_5 = currentLevel.ladder;
            if(this.foundWords.Length < 0)
            {
                    return;
            }
            
            if(W9 < 1)
            {
                    return;
            }
            
            val_5 = this.foundWords.Length - 2;
            do
            {
                string val_2 = new System.Collections.Generic.Queue<System.String>(collection:  val_5 = currentLevel.ladder).Dequeue();
                UnityEngine.UI.Text val_4 = this.foundWords[val_5 + 1];
                if((val_5 & 2147483648) != 0)
            {
                    return;
            }
            
                val_5 = val_5 - 1;
            }
            while(null >= 1);
        
        }
        private void HideKeyboard()
        {
            var val_5 = 4;
            do
            {
                var val_1 = val_5 - 4;
                if(val_1 >= true)
            {
                    return;
            }
            
                if(true <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(0.gameObject.activeSelf != false)
            {
                    if(true <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                0.gameObject.SetActive(value:  false);
            }
            
                val_5 = val_5 + 1;
            }
            while(this.keyboardLetters != null);
            
            throw new NullReferenceException();
        }
        private void SetupChosenLetters(SLC.Minigames.Ladder.WordLadderLevel currentLevel)
        {
            string val_5;
            var val_7 = 4;
            do
            {
                int val_6 = currentLevel.startingWord.m_stringLength;
                int val_1 = val_7 - 4;
                val_6 = val_6 - 1;
                val_5 = (long)val_6;
                if(val_1 >= X9)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(val_1 > val_5)
            {
                    (currentLevel.startingWord.m_stringLength - 1) + 32.gameObject.SetActive(value:  false);
            }
            else
            {
                    val_5 = currentLevel.chosenWord.Chars[val_1].ToString();
                mem2[0] = val_1;
                mem2[0] = val_5;
                if(val_1 >= ((currentLevel.startingWord.m_stringLength - 1) + 32 + 24))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                (currentLevel.startingWord.m_stringLength - 1) + 32 + 24 + 32.gameObject.SetActive(value:  true);
                if(val_1 >= ((currentLevel.startingWord.m_stringLength - 1) + 32 + 24))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                (currentLevel.startingWord.m_stringLength - 1) + 32 + 24 + 32.SetSpriteAndText(s:  this.unChosenLetterSprite, textSize:  100);
            }
            
                val_7 = val_7 + 1;
            }
            while(val_1 < 4);
        
        }
        public WordLadderUIController()
        {
        
        }
    
    }

}
