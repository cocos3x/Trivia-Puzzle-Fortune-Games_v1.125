using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizDisplayWord : MonoBehaviour
    {
        // Fields
        private UnityEngine.CanvasGroup containerCanvasGroup;
        private UnityEngine.UI.LayoutElement containerLayoutElement;
        private SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter letterTilePrefab;
        private UnityEngine.UI.GridLayoutGroup lettersGridLayoutGroup;
        private float preferredCellSize;
        private UnityEngine.RectTransform currentInputIndicator;
        private DG.Tweening.DOTweenAnimation[] currentInputIndicatorTween;
        private SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter[] letterTiles;
        private SLC.Minigames.ImageQuiz.ImageQuizLetterButton[] sourceLetterButton;
        private string[] currentInput;
        private string[] givenLetters;
        private int numberOfLetters;
        private int caretPosition;
        private const float BACK_TRACK_DELAY = 0.033;
        public System.Action OnInputProcessed;
        private bool <AllowInput>k__BackingField;
        private bool <AllowErase>k__BackingField;
        
        // Properties
        public int CaretPosition { get; }
        public bool AllowInput { get; set; }
        public bool AllowErase { get; set; }
        public int FilledLettersCount { get; }
        
        // Methods
        public int get_CaretPosition()
        {
            return (int)this.caretPosition;
        }
        public bool get_AllowInput()
        {
            return (bool)this.<AllowInput>k__BackingField;
        }
        public void set_AllowInput(bool value)
        {
            this.<AllowInput>k__BackingField = value;
        }
        public bool get_AllowErase()
        {
            return (bool)this.<AllowErase>k__BackingField;
        }
        public void set_AllowErase(bool value)
        {
            this.<AllowErase>k__BackingField = value;
        }
        public int get_FilledLettersCount()
        {
            var val_2;
            var val_4 = 0;
            val_2 = 0;
            do
            {
                if(val_4 >= (this.currentInput.Length << ))
            {
                    return (int)val_2;
            }
            
                var val_3 = ~(System.String.IsNullOrEmpty(value:  this.currentInput[val_4]));
                val_3 = val_3 & 1;
                val_2 = val_2 + val_3;
                val_4 = val_4 + 1;
            }
            while(this.currentInput != null);
            
            throw new NullReferenceException();
        }
        private void Awake()
        {
            this.currentInputIndicatorTween = this.currentInputIndicator.GetComponentsInChildren<DG.Tweening.DOTweenAnimation>();
        }
        public void Initialize(int _numberOfLetters)
        {
            UnityEngine.RectTransform val_19;
            var val_20;
            var val_23;
            val_19 = this.currentInputIndicator;
            UnityEngine.Transform val_1 = this.transform;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19.SetParent(p:  val_1.parent);
            val_19 = this.currentInputIndicator;
            UnityEngine.Quaternion val_3 = UnityEngine.Quaternion.identity;
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19.rotation = new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w};
            if(this.lettersGridLayoutGroup == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_4 = this.lettersGridLayoutGroup.transform;
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19 = val_4.GetEnumerator();
            val_20 = 1152921504765632512;
            label_23:
            var val_21 = 0;
            val_21 = val_21 + 1;
            if(val_19.MoveNext() == false)
            {
                goto label_13;
            }
            
            var val_22 = 0;
            val_22 = val_22 + 1;
            object val_9 = val_19.Current;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_9.gameObject);
            goto label_23;
            label_13:
            if(X0 == false)
            {
                goto label_24;
            }
            
            var val_25 = X0;
            val_19 = X0;
            if((X0 + 294) == 0)
            {
                goto label_28;
            }
            
            var val_23 = X0 + 176;
            var val_24 = 0;
            val_23 = val_23 + 8;
            label_27:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_26;
            }
            
            val_24 = val_24 + 1;
            val_23 = val_23 + 16;
            if(val_24 < (X0 + 294))
            {
                goto label_27;
            }
            
            goto label_28;
            label_26:
            val_25 = val_25 + (((X0 + 176 + 8)) << 4);
            val_23 = val_25 + 304;
            label_28:
            val_19.Dispose();
            label_24:
            if(0 != 0)
            {
                    throw ???;
            }
            
            this.numberOfLetters = _numberOfLetters;
            this.givenLetters = new string[0];
            this.letterTiles = new SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter[0];
            this.sourceLetterButton = new SLC.Minigames.ImageQuiz.ImageQuizLetterButton[0];
            if(this.letterTiles == null)
            {
                    throw new NullReferenceException();
            }
            
            val_20 = 1152921504765632512;
            var val_27 = 4;
            label_41:
            int val_14 = val_27 - 4;
            if(val_14 >= this.letterTiles.Length)
            {
                goto label_31;
            }
            
            if(this.lettersGridLayoutGroup == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19 = UnityEngine.Object.Instantiate<SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter>(original:  this.letterTilePrefab, parent:  this.lettersGridLayoutGroup.transform);
            this.letterTiles[0] = val_19;
            if(this.letterTiles == null)
            {
                    throw new NullReferenceException();
            }
            
            SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter val_26 = this.letterTiles[0];
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_26.Initialize(indexInWord:  val_14);
            val_27 = val_27 + 1;
            if(this.letterTiles != null)
            {
                goto label_41;
            }
            
            throw new NullReferenceException();
            label_31:
            this.currentInput = new string[0];
            this.<AllowInput>k__BackingField = true;
            this.<AllowErase>k__BackingField = true;
            this.caretPosition = 0;
            UnityEngine.Coroutine val_19 = this.StartCoroutine(routine:  this.RepositionMoveIndicator());
            DG.Tweening.Tweener val_20 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.containerCanvasGroup, endValue:  1f, duration:  0.3f);
        }
        private System.Collections.IEnumerator RepositionMoveIndicator()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ImageQuizDisplayWord.<RepositionMoveIndicator>d__29();
        }
        protected void OnRectTransformDimensionsChange()
        {
            UnityEngine.Vector2 val_1 = this.DetermineCellSize();
            this.lettersGridLayoutGroup.cellSize = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        }
        public void ShowAnswer()
        {
            SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter[] val_6;
            var val_7;
            SLC.Minigames.ImageQuiz.ImageQuizLevelInfo val_2 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.GetCurrentQuizLevel();
            if((System.String.IsNullOrEmpty(value:  val_2.word)) == true)
            {
                    return;
            }
            
            val_6 = this.letterTiles;
            val_7 = 0;
            do
            {
                if(val_7 >= (this.letterTiles.Length << ))
            {
                    return;
            }
            
                if(val_7 < val_2.word.m_stringLength)
            {
                    val_6[val_7].SetLetter(letterString:  val_2.word.Chars[0].ToString());
                float val_8 = 0f;
                val_8 = val_8 * 0.05f;
                this.letterTiles[val_7].PlayAnimation(anim:  3, animationDelay:  val_8);
                val_6 = this.letterTiles;
            }
            
                val_7 = val_7 + 1;
            }
            while(val_6 != null);
            
            throw new NullReferenceException();
        }
        public void AddInput(string inputLetter, SLC.Minigames.ImageQuiz.ImageQuizLetterButton originatingButton)
        {
            if((this.<AllowInput>k__BackingField) == false)
            {
                    return;
            }
            
            twelvegigs.Autopilot.AutopilotManager val_1 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            if(1152921517483448192 != 1)
            {
                    return;
            }
            
            if((this.caretPosition & 2147483648) != 0)
            {
                    return;
            }
            
            if(this.caretPosition >= this.letterTiles.Length)
            {
                    return;
            }
            
            this.currentInput[this.caretPosition] = inputLetter;
            this.sourceLetterButton[this.caretPosition] = originatingButton;
            this.letterTiles[this.caretPosition].SetLetter(letterString:  inputLetter);
            this.letterTiles[this.caretPosition].PlayAnimation(anim:  0, animationDelay:  0f);
            this.IncrementInputCursor();
            if(this.OnInputProcessed != null)
            {
                    this.OnInputProcessed.Invoke();
            }
            
            this.RefreshUI();
        }
        private System.Collections.IEnumerator RefreshUIAfterAnimation()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ImageQuizDisplayWord.<RefreshUIAfterAnimation>d__33();
        }
        private bool IsTilesAnimating()
        {
            var val_1;
            if(this.letterTiles.Length < 1)
            {
                goto label_1;
            }
            
            var val_2 = 0;
            label_5:
            SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter val_1 = this.letterTiles[val_2];
            if((this.letterTiles[0x0][0].<IsAnimating>k__BackingField) == true)
            {
                goto label_4;
            }
            
            val_2 = val_2 + 1;
            if(val_2 < this.letterTiles.Length)
            {
                goto label_5;
            }
            
            label_1:
            val_1 = 0;
            return (bool)val_1;
            label_4:
            val_1 = 1;
            return (bool)val_1;
        }
        private void RefreshUI()
        {
            this.MoveIndicator(inputPos:  this.caretPosition);
            if(this.FilledLettersCount != this.numberOfLetters)
            {
                    return;
            }
            
            this.SubmitCurrentWord();
        }
        public string GetCurrentInput()
        {
            int val_2;
            var val_3 = 0;
            val_2 = System.String.alignConst;
            do
            {
                if(val_3 >= (this.currentInput.Length << ))
            {
                    return (string)val_2 + this.currentInput[val_3];
            }
            
                val_3 = val_3 + 1;
            }
            while(this.currentInput != null);
            
            throw new NullReferenceException();
        }
        public bool IsInputOnGivenLetter(string letter)
        {
            if((this.caretPosition & 2147483648) != 0)
            {
                    return false;
            }
            
            if(this.caretPosition >= this.letterTiles.Length)
            {
                    return false;
            }
            
            return System.String.op_Equality(a:  this.givenLetters[this.caretPosition], b:  letter);
        }
        private void SubmitCurrentWord()
        {
            if((this.<AllowInput>k__BackingField) == false)
            {
                    return;
            }
            
            this.<AllowInput>k__BackingField = false;
            this.currentInputIndicator.gameObject.SetActive(value:  false);
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.SubmittingWord());
        }
        private System.Collections.IEnumerator SubmittingWord()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ImageQuizDisplayWord.<SubmittingWord>d__39();
        }
        private void IncrementInputCursor()
        {
            int val_4 = this.caretPosition;
            val_4 = val_4 + 1;
            int val_1 = (val_4 < this.letterTiles.Length) ? (val_4) : 0;
            label_3:
            if((this.IsLetterOccupied(letterIndex:  val_1, includeGivens:  true)) == false)
            {
                goto label_1;
            }
            
            var val_3 = val_1 + 1;
            val_1 = (val_3 < this.letterTiles.Length) ? (val_3) : 0;
            if(val_1 != this.caretPosition)
            {
                goto label_3;
            }
            
            label_1:
            this.caretPosition = val_1;
        }
        private void MoveIndicator(int inputPos)
        {
            if((inputPos & 2147483648) == 0)
            {
                    if(this.letterTiles.Length >= inputPos)
            {
                goto label_3;
            }
            
            }
            
            this.currentInputIndicator.gameObject.SetActive(value:  false);
            return;
            label_3:
            var val_11 = 0;
            label_10:
            if(val_11 >= this.currentInputIndicatorTween.Length)
            {
                goto label_7;
            }
            
            DG.Tweening.DOTweenAnimation val_10 = this.currentInputIndicatorTween[val_11];
            val_11 = val_11 + 1;
            if(this.currentInputIndicatorTween != null)
            {
                goto label_10;
            }
            
            throw new NullReferenceException();
            label_7:
            this.currentInputIndicator.gameObject.SetActive(value:  true);
            this.currentInputIndicator.SetParent(p:  this.letterTiles[inputPos].transform);
            UnityEngine.Quaternion val_4 = UnityEngine.Quaternion.identity;
            this.currentInputIndicator.rotation = new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w};
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.zero;
            this.currentInputIndicator.anchoredPosition = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
            UnityEngine.Vector2 val_6 = UnityEngine.Vector2.zero;
            this.currentInputIndicator.anchorMin = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
            UnityEngine.Vector2 val_7 = UnityEngine.Vector2.one;
            this.currentInputIndicator.anchorMax = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
            UnityEngine.Vector2 val_8 = UnityEngine.Vector2.zero;
            this.currentInputIndicator.offsetMin = new UnityEngine.Vector2() {x = val_8.x, y = val_8.y};
            UnityEngine.Vector2 val_9 = UnityEngine.Vector2.zero;
            this.currentInputIndicator.offsetMax = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        }
        private UnityEngine.Vector2 DetermineCellSize()
        {
            float val_11;
            if((this.letterTiles == null) || (this.letterTiles.Length == 0))
            {
                goto label_2;
            }
            
            if(null != null)
            {
                goto label_6;
            }
            
            UnityEngine.Rect val_3 = this.containerLayoutElement.gameObject.transform.rect;
            int val_5 = val_3.m_XMin.left;
            UnityEngine.Vector2 val_12 = this.lettersGridLayoutGroup.m_Spacing;
            float val_11 = (float)val_5;
            val_11 = val_3.m_XMin.width - val_11;
            val_11 = val_11 - (float)val_5.right;
            val_12 = val_12 * ((float)this.letterTiles.Length - 1);
            val_12 = val_11 - val_12;
            val_11 = this.preferredCellSize;
            float val_9 = UnityEngine.Mathf.Min(a:  val_11, b:  val_12 / (float)this.letterTiles.Length);
            goto label_15;
            label_2:
            val_11 = this.preferredCellSize;
            label_15:
            UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  val_11, y:  val_11);
            return new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
            label_6:
        }
        private void SetLetterTileSize(UnityEngine.Vector2 letterTileSize)
        {
            if(this.lettersGridLayoutGroup != null)
            {
                    this.lettersGridLayoutGroup.cellSize = new UnityEngine.Vector2() {x = letterTileSize.x, y = letterTileSize.y};
                return;
            }
            
            throw new NullReferenceException();
        }
        public void EraseLetter(int letterIndex)
        {
            int val_12;
            int val_13 = letterIndex;
            if((this.<AllowErase>k__BackingField) == false)
            {
                    return;
            }
            
            twelvegigs.Autopilot.AutopilotManager val_1 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            if(1152921517483448192 != 1)
            {
                    return;
            }
            
            string val_2 = this.GetCurrentInput();
            int val_12 = val_2.m_stringLength;
            val_12 = val_12 - 1;
            var val_15 = 0;
            var val_3 = X10 + 32;
            int val_4 = val_12 - val_13;
            label_30:
            if(((long)val_13 + val_15) >= (this.currentInput.Length << ))
            {
                goto label_8;
            }
            
            val_13 = val_13 + val_15;
            if((System.String.IsNullOrEmpty(value:  null)) != true)
            {
                    if((System.String.IsNullOrEmpty(value:  null)) != false)
            {
                    float val_14 = (float)val_4;
                val_14 = val_14 * 0.033f;
                val_14 = val_14 / (float)val_12;
                1152921508265041280.PlayAnimation(anim:  2, animationDelay:  val_14);
                1152921508265045376.ToggleButtonVisibility(isVisible:  true);
                val_12 = System.String.alignConst;
                mem2[0] = val_12;
                mem2[0] = val_12;
            }
            
            }
            
            if(0 == 0)
            {
                    if((this.IsLetterOccupied(letterIndex:  val_13, includeGivens:  true)) != true)
            {
                    System.Nullable<System.Int32> val_9 = new System.Nullable<System.Int32>(value:  val_13);
            }
            
            }
            
            val_15 = val_15 + 1;
            val_4 = val_4 - 1;
            if(this.currentInput != null)
            {
                goto label_30;
            }
            
            throw new NullReferenceException();
            label_8:
            this.caretPosition = val_9.HasValue;
            UnityEngine.Coroutine val_11 = this.StartCoroutine(routine:  this.RefreshUIAfterAnimation());
        }
        public void GiveLetterHint()
        {
            RandomSet val_1 = new RandomSet();
            var val_5 = 0;
            label_6:
            if(val_5 >= (this.givenLetters.Length << ))
            {
                goto label_2;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.givenLetters[val_5])) != false)
            {
                    val_1.add(item:  0, weight:  1f);
            }
            
            val_5 = val_5 + 1;
            if(this.givenLetters != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_2:
            this.GiveLetterHint(letterIndex:  val_1.roll(unweighted:  false));
        }
        public void GiveLetterHint(int letterIndex)
        {
            string val_9 = 1152921504893161472;
            SLC.Minigames.ImageQuiz.ImageQuizLevelInfo val_2 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.GetCurrentQuizLevel();
            if((this.<AllowInput>k__BackingField) == false)
            {
                    return;
            }
            
            val_9 = val_2.word;
            twelvegigs.Autopilot.AutopilotManager val_3 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            if((letterIndex & 2147483648) != 0)
            {
                    return;
            }
            
            if(null != 1)
            {
                    return;
            }
            
            if(val_2.word.m_stringLength <= letterIndex)
            {
                    return;
            }
            
            this.EraseLetter(letterIndex:  0);
            string val_5 = val_9.Chars[letterIndex].ToString();
            this.currentInput[(long)letterIndex] = val_5;
            this.givenLetters[(long)letterIndex] = val_5;
            this.letterTiles[(long)letterIndex].SetLetter(letterString:  val_5);
            this.letterTiles[(long)letterIndex].PlayAnimation(anim:  1, animationDelay:  0f);
            SLC.Minigames.ImageQuiz.ImageQuizUIController val_6 = MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizUIController>.Instance;
            this.sourceLetterButton[(long)letterIndex] = val_6.letterButtonGrid.GetButton(letter:  val_5, getOnlyUnusedButtons:  true);
            val_9 = this.sourceLetterButton[(long)letterIndex];
            if(val_9 != 0)
            {
                    this.sourceLetterButton[(long)letterIndex].ToggleButtonVisibility(isVisible:  false);
            }
            
            if(this.caretPosition == letterIndex)
            {
                    this.IncrementInputCursor();
            }
            
            this.RefreshUI();
        }
        public bool IsLetterGiven(int letterIndex)
        {
            bool val_1 = System.String.IsNullOrEmpty(value:  this.givenLetters[letterIndex]);
            val_1 = (~val_1) & 1;
            return (bool)val_1;
        }
        public bool IsLetterOccupied(int letterIndex, bool includeGivens = True)
        {
            var val_2;
            bool val_1 = System.String.IsNullOrEmpty(value:  this.currentInput[letterIndex]);
            if(includeGivens == false)
            {
                goto label_2;
            }
            
            if(val_1 == false)
            {
                goto label_3;
            }
            
            return this.IsLetterGiven(letterIndex:  letterIndex);
            label_2:
            val_2 = val_1 ^ 1;
            return (bool)val_2 & 1;
            label_3:
            val_2 = 1;
            return (bool)val_2 & 1;
        }
        public void FadeVisible(bool state)
        {
            if(state != false)
            {
                    DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.containerCanvasGroup, endValue:  1f, duration:  0.3f);
                return;
            }
            
            DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.containerCanvasGroup, endValue:  0f, duration:  0.3f);
        }
        public void SetVisible(bool state)
        {
            if(this.containerCanvasGroup != null)
            {
                    if(state != false)
            {
                    this.containerCanvasGroup.alpha = 1f;
                return;
            }
            
                this.containerCanvasGroup.alpha = 0f;
                return;
            }
            
            throw new NullReferenceException();
        }
        public ImageQuizDisplayWord()
        {
            this.preferredCellSize = 160f;
        }
    
    }

}
