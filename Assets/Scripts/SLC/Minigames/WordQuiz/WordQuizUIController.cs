using UnityEngine;

namespace SLC.Minigames.WordQuiz
{
    public class WordQuizUIController : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject letterTilePrefab;
        private SLC.Minigames.MinigamesCheckpointSlider minigamesCheckpointSlider;
        private TMPro.TMP_Text description;
        private UnityEngine.GameObject checkMarkCorrect;
        private UnityEngine.GameObject checkMarkWrong;
        private UnityEngine.GameObject answerGroup;
        private UnityEngine.GameObject tutorialText;
        private UnityEngine.UI.GridLayoutGroup keyboardArea;
        private UnityEngine.GameObject FTUXHand;
        private UnityEngine.Vector3 FTUXHandOffset;
        private UnityEngine.UI.Button hintBtn;
        private TMPro.TMP_Text hintCostText;
        private UnityEngine.GameObject pauseCanvas;
        private UnityEngine.CanvasGroup mainCanvasGroup;
        private System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLetterTile> answerTiles;
        private System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLetterTile> keyboardTiles;
        
        // Properties
        private string CurrentAnswer { get; }
        
        // Methods
        private string get_CurrentAnswer()
        {
            string val_5;
            string val_6;
            System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
            List.Enumerator<T> val_2 = this.answerTiles.GetEnumerator();
            label_6:
            val_5 = public System.Boolean List.Enumerator<SLC.Minigames.WordQuiz.WordQuizLetterTile>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_6 = 9733424;
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_5 = val_6;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Text.StringBuilder val_4 = val_1.Append(value:  val_5);
            goto label_6;
            label_2:
            0.Dispose();
            return (string)val_1;
        }
        private void Start()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnPauseClicked, b:  new System.Action(object:  this, method:  public System.Void SLC.Minigames.WordQuiz.WordQuizUIController::OnClickPause()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnPauseClicked = val_3;
            return;
            label_5:
        }
        private void OnDestroy()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnPauseClicked, value:  new System.Action(object:  this, method:  public System.Void SLC.Minigames.WordQuiz.WordQuizUIController::OnClickPause()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnPauseClicked = val_3;
            return;
            label_5:
        }
        public void HideUIForPopup(bool showingPopup)
        {
            if(this.mainCanvasGroup != null)
            {
                    this.mainCanvasGroup.alpha = (showingPopup != true) ? 0f : 1f;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void InitializeLevel(SLC.Minigames.WordQuiz.WordQuizLevel level)
        {
            SLC.Minigames.WordQuiz.WordQuizLevel val_41;
            float val_42;
            UnityEngine.UI.GridLayoutGroup val_43;
            this.ClearUI();
            if(this.answerTiles == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = public System.Void System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLetterTile>::Clear();
            this.answerTiles.Clear();
            if(this.keyboardTiles == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = public System.Void System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLetterTile>::Clear();
            this.keyboardTiles.Clear();
            SLC.Minigames.WordQuiz.WordQuizManager val_1 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            decimal val_2 = val_1.hintCost;
            val_41 = 0;
            if(this.hintCostText == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = val_2.flags.ToString();
            SLC.Minigames.WordQuiz.WordQuizManager val_4 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = level;
            System.Collections.Generic.List<System.String> val_5 = val_4.GetRandomizedLetters(level:  val_41);
            if(level == null)
            {
                    throw new NullReferenceException();
            }
            
            if(level.word == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Collections.Generic.List<T> val_6 = val_5.GetRange(index:  0, count:  level.word.m_stringLength);
            PluginExtension.Shuffle<System.String>(list:  val_5, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            int val_7 = level.keyboardLetterNum - 8;
            if(val_7 < 9)
            {
                    if(((341 >> val_7) & 1) != 0)
            {
                goto label_12;
            }
            
            }
            
            var val_9 = (level.keyboardLetterNum != 18) ? (6 + 1) : 6;
            if(this.keyboardArea != null)
            {
                goto label_13;
            }
            
            throw new NullReferenceException();
            label_12:
            val_41 = mem[32556576 + ((level.keyboardLetterNum - 8)) << 2];
            val_41 = 32556576 + ((level.keyboardLetterNum - 8)) << 2;
            if(this.keyboardArea == null)
            {
                    throw new NullReferenceException();
            }
            
            label_13:
            this.keyboardArea.constraintCount = val_41;
            if(this.keyboardArea == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.keyboardArea.m_ConstraintCount < 8)
            {
                    val_42 = 133f;
            }
            else
            {
                    val_42 = 115f;
            }
            
            UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  val_42, y:  val_42);
            val_41 = 0;
            this.keyboardArea.cellSize = new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
            if(this.keyboardArea == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = 0;
            if(this.keyboardArea == null)
            {
                    throw new NullReferenceException();
            }
            
            val_43 = this.keyboardArea.transform;
            float val_38 = 4.446478E+07f;
            val_38 = val_38 / (float)this.keyboardArea.m_ConstraintCount;
            int val_12 = UnityEngine.Mathf.CeilToInt(f:  val_38);
            if(val_43 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = null;
            if(null != val_41)
            {
                goto label_93;
            }
            
            UnityEngine.Rect val_13 = val_43.rect;
            val_41 = 0;
            if(this.keyboardArea == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_13.m_XMin == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = 0;
            int val_15 = val_13.m_XMin.top;
            if(this.keyboardArea == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_15 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = 0;
            val_43 = this.keyboardArea;
            if(val_43 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_17 = val_12 - 1;
            float val_39 = (float)val_17;
            val_39 = S9 * val_39;
            float val_40 = (float)val_15;
            val_39 = val_13.m_XMin.height - val_39;
            val_40 = val_39 - val_40;
            val_40 = val_40 - (float)val_15.bottom;
            val_40 = val_40 / (float)val_12;
            if(val_13.m_Width > val_40)
            {
                    UnityEngine.Vector2 val_18 = new UnityEngine.Vector2(x:  val_40, y:  val_40);
                val_41 = 0;
                val_43.cellSize = new UnityEngine.Vector2() {x = val_18.x, y = val_18.y};
            }
            
            if(val_17 >= 1)
            {
                    int val_41 = 0;
                do
            {
                WordQuizUIController.<>c__DisplayClass21_0 val_19 = null;
                val_41 = 0;
                val_19 = new WordQuizUIController.<>c__DisplayClass21_0();
                if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
                .<>4__this = this;
                if(this.keyboardArea == null)
            {
                    throw new NullReferenceException();
            }
            
                val_43 = this.letterTilePrefab;
                val_41 = this.keyboardArea.transform;
                UnityEngine.GameObject val_21 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_43, parent:  val_41);
                if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_41 = public SLC.Minigames.WordQuiz.WordQuizLetterTile UnityEngine.GameObject::GetComponent<SLC.Minigames.WordQuiz.WordQuizLetterTile>();
                SLC.Minigames.WordQuiz.WordQuizLetterTile val_22 = val_21.GetComponent<SLC.Minigames.WordQuiz.WordQuizLetterTile>();
                .tile = val_22;
                if(val_22 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_43 = val_22.letter;
                if(val_41 >= 1152921513413301296)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(val_43 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_41 = "_____";
                if(((WordQuizUIController.<>c__DisplayClass21_0)[1152921519789054112].tile) == null)
            {
                    throw new NullReferenceException();
            }
            
                if(((WordQuizUIController.<>c__DisplayClass21_0)[1152921519789054112].tile.btn) == null)
            {
                    throw new NullReferenceException();
            }
            
                val_43 = (WordQuizUIController.<>c__DisplayClass21_0)[1152921519789054112].tile.btn.m_OnClick;
                UnityEngine.Events.UnityAction val_23 = null;
                val_41 = val_19;
                val_23 = new UnityEngine.Events.UnityAction(object:  val_19, method:  System.Void WordQuizUIController.<>c__DisplayClass21_0::<InitializeLevel>b__0());
                if(val_43 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_41 = val_23;
                val_43.AddListener(call:  val_23);
                if(((WordQuizUIController.<>c__DisplayClass21_0)[1152921519789054112].tile) == null)
            {
                    throw new NullReferenceException();
            }
            
                (WordQuizUIController.<>c__DisplayClass21_0)[1152921519789054112].tile.keyboardIndex = val_41;
                if(this.keyboardTiles == null)
            {
                    throw new NullReferenceException();
            }
            
                val_41 = (WordQuizUIController.<>c__DisplayClass21_0)[1152921519789054112].tile;
                this.keyboardTiles.Add(item:  val_41);
                val_41 = val_41 + 1;
            }
            while(val_41 < ((WordQuizUIController.<>c__DisplayClass21_0)[1152921519789054112].tile));
            
            }
            
            if(this.description == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = mem[level + 24];
            val_41 = level + 24;
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_24 = val_6.GetEnumerator();
            val_43 = 1152921519788832224;
            label_61:
            if(val_18.x.MoveNext() == false)
            {
                goto label_48;
            }
            
            WordQuizUIController.<>c__DisplayClass21_1 val_27 = null;
            val_41 = 0;
            val_27 = new WordQuizUIController.<>c__DisplayClass21_1();
            if(val_27 == null)
            {
                    throw new NullReferenceException();
            }
            
            .<>4__this = this;
            if(this.answerGroup == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = this.answerGroup.transform;
            UnityEngine.GameObject val_29 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.letterTilePrefab, parent:  val_41);
            if(val_29 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = public SLC.Minigames.WordQuiz.WordQuizLetterTile UnityEngine.GameObject::GetComponent<SLC.Minigames.WordQuiz.WordQuizLetterTile>();
            SLC.Minigames.WordQuiz.WordQuizLetterTile val_30 = val_29.GetComponent<SLC.Minigames.WordQuiz.WordQuizLetterTile>();
            .tile = val_30;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_30.btn == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Events.UnityAction val_31 = null;
            val_41 = val_27;
            val_31 = new UnityEngine.Events.UnityAction(object:  val_27, method:  System.Void WordQuizUIController.<>c__DisplayClass21_1::<InitializeLevel>b__1());
            if(val_30.btn.m_OnClick == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = val_31;
            val_30.btn.m_OnClick.AddListener(call:  val_31);
            if(((WordQuizUIController.<>c__DisplayClass21_1)[1152921519789115552].tile) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = 1;
            (WordQuizUIController.<>c__DisplayClass21_1)[1152921519789115552].tile.SetHiddenState(hidden:  true);
            if(((WordQuizUIController.<>c__DisplayClass21_1)[1152921519789115552].tile) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(((WordQuizUIController.<>c__DisplayClass21_1)[1152921519789115552].tile.btn) == null)
            {
                    throw new NullReferenceException();
            }
            
            (WordQuizUIController.<>c__DisplayClass21_1)[1152921519789115552].tile.btn.interactable = false;
            this.answerTiles.Add(item:  (WordQuizUIController.<>c__DisplayClass21_1)[1152921519789115552].tile);
            goto label_61;
            label_48:
            val_41 = public System.Void List.Enumerator<System.String>::Dispose();
            val_18.x.Dispose();
            label_95:
            SLC.Minigames.WordQuiz.WordQuizManager val_32 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(val_32 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.tutorialText == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = val_32.ShouldShowFTUX();
            this.tutorialText.SetActive(value:  val_41);
            SLC.Minigames.WordQuiz.WordQuizManager val_34 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(val_34 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_35 = val_34.ShouldShowFTUX();
            if(this.tutorialText == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = val_35;
            this.tutorialText.SetActive(value:  val_41);
            if(this.hintBtn == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = 0;
            UnityEngine.GameObject val_36 = this.hintBtn.gameObject;
            if(val_36 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_35 != false)
            {
                    val_41 = 0;
                val_36.SetActive(value:  false);
                SLC.Minigames.WordQuiz.WordQuizFTUXManager val_37 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizFTUXManager>.Instance;
                if(val_37 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_41 = 0;
                val_37.ShowFTUX();
            }
            else
            {
                    val_41 = 1;
                val_36.SetActive(value:  true);
            }
            
            if(this.minigamesCheckpointSlider == null)
            {
                    throw new NullReferenceException();
            }
            
            this.minigamesCheckpointSlider.UpdateUI();
            return;
            label_93:
            if(level != 1)
            {
                goto label_94;
            }
            
            val_18.x.Dispose();
            if(X24 == 0)
            {
                goto label_95;
            }
            
            throw X24;
            label_94:
        }
        public void OnTileSelected(SLC.Minigames.WordQuiz.WordQuizLetterTile tile)
        {
            UnityEngine.Object val_21;
            SLC.Minigames.WordQuiz.WordQuizManager val_1 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(41967616 > val_1.answerProgress)
            {
                    SLC.Minigames.WordQuiz.WordQuizManager val_2 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if(((MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + (val_2.answerProgress) << 3) + 32) == 0)
            {
                
            }
            else
            {
                    SLC.Minigames.WordQuiz.WordQuizManager val_5 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            }
            
            SLC.Minigames.WordQuiz.WordQuizManager val_6 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            int val_22 = val_6.answerProgress;
            val_22 = val_22 + 1;
            val_6.answerProgress = val_22;
            SLC.Minigames.WordQuiz.WordQuizManager val_7 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            int val_23 = val_7.answerProgress;
            val_23 = val_23 - 1;
            if(this.answerTiles > val_23)
            {
                    SLC.Minigames.WordQuiz.WordQuizManager val_8 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
                int val_24 = val_8.answerProgress;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_24 = val_24 + ((val_24 - 1) << 3);
                val_21 = mem[(val_8.answerProgress + ((val_8.answerProgress - 1)) << 3) + 32];
                val_21 = (val_8.answerProgress + ((val_8.answerProgress - 1)) << 3) + 32;
                if(val_21 != 0)
            {
                    (val_8.answerProgress + ((val_8.answerProgress - 1)) << 3) + 32 + 32.interactable = true;
                mem2[0] = tile.keyboardIndex;
                SLC.Minigames.WordQuiz.WordQuizManager val_11 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
                int val_25 = val_11.answerProgress;
                val_25 = val_25 - 1;
                mem2[0] = val_25;
                val_21.SetHiddenState(hidden:  false);
                tile.canvasGroup.alpha = 0f;
                tile.btn.interactable = false;
                tile.submitted = true;
            }
            
            }
            
            MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance.CheckAnswerCorrect(answer:  this.CurrentAnswer);
            if((MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance.ShouldShowFTUX()) == false)
            {
                goto label_60;
            }
            
            string val_16 = this.CurrentAnswer;
            SLC.Minigames.WordQuiz.WordQuizManager val_17 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(val_16.m_stringLength >= val_17.currentLevel.word.m_stringLength)
            {
                goto label_60;
            }
            
            MonoSingleton<SLC.Minigames.WordQuiz.WordQuizFTUXManager>.Instance.ShowFTUX();
            goto label_64;
            label_60:
            MonoSingleton<SLC.Minigames.WordQuiz.WordQuizFTUXManager>.Instance.Stop();
            this.HideFTUXHand();
            label_64:
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
        }
        public void OnTileDeselected(SLC.Minigames.WordQuiz.WordQuizLetterTile tile, bool fromHint = False)
        {
            int val_10;
            int val_11;
            val_10 = tile;
            bool val_10 = true;
            val_11 = tile.answerIndex;
            goto label_2;
            label_17:
            if(val_10 <= val_11)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_10 = val_10 + (val_11 << 3);
            if(((true + (tile.answerIndex) << 3) + 32 + 96) == 0)
            {
                    var val_11 = (true + (tile.answerIndex) << 3) + 32 + 24;
                (true + (tile.answerIndex) << 3) + 32 + 32.interactable = false;
                (true + (tile.answerIndex) << 3) + 32.SetHiddenState(hidden:  true);
                if(val_11 <= ((true + (tile.answerIndex) << 3) + 32 + 88))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_11 = val_11 + (((true + (tile.answerIndex) << 3) + 32 + 88) << 3);
                ((true + (tile.answerIndex) << 3) + 32 + 24 + ((true + (tile.answerIndex) << 3) + 32 + 88) << 3) + 32 + 40.alpha = 1f;
                ((true + (tile.answerIndex) << 3) + 32 + 24 + ((true + (tile.answerIndex) << 3) + 32 + 88) << 3) + 32 + 32.interactable = true;
                mem2[0] = 0;
            }
            
            val_11 = val_11 + 1;
            label_2:
            SLC.Minigames.WordQuiz.WordQuizManager val_1 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(val_11 < val_1.answerProgress)
            {
                goto label_17;
            }
            
            SLC.Minigames.WordQuiz.WordQuizManager val_2 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            val_2.answerProgress = tile.answerIndex;
            if((MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance.ShouldShowFTUX()) == false)
            {
                goto label_29;
            }
            
            string val_5 = this.CurrentAnswer;
            val_10 = val_5.m_stringLength;
            SLC.Minigames.WordQuiz.WordQuizManager val_6 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(val_10 >= val_6.currentLevel.word.m_stringLength)
            {
                goto label_29;
            }
            
            MonoSingleton<SLC.Minigames.WordQuiz.WordQuizFTUXManager>.Instance.ShowFTUX();
            if(fromHint == true)
            {
                    return;
            }
            
            label_40:
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  1, volumeScale:  1f);
            return;
            label_29:
            MonoSingleton<SLC.Minigames.WordQuiz.WordQuizFTUXManager>.Instance.Stop();
            this.HideFTUXHand();
            if(fromHint == false)
            {
                goto label_40;
            }
        
        }
        public void ShowFTUXHand(SLC.Minigames.WordQuiz.WordQuizLetterTile tile)
        {
            UnityEngine.Vector3 val_3 = tile.transform.position;
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, b:  new UnityEngine.Vector3() {x = this.FTUXHandOffset, y = V11.16B, z = V10.16B});
            this.FTUXHand.transform.position = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
            this.FTUXHand.SetActive(value:  true);
        }
        public void HideFTUXHand()
        {
            if(this.FTUXHand != null)
            {
                    this.FTUXHand.SetActive(value:  false);
                return;
            }
            
            throw new NullReferenceException();
        }
        public void DisableOtherLetterTiles(SLC.Minigames.WordQuiz.WordQuizLetterTile currentFTUXLetterTile)
        {
            System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLetterTile> val_2;
            var val_3;
            bool val_2 = true;
            val_2 = this.keyboardTiles;
            val_3 = 0;
            do
            {
                if(val_3 >= val_2)
            {
                    return;
            }
            
                if(val_2 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2 = val_2 + 0;
                SLC.Minigames.WordQuiz.WordQuizLetterTile val_3 = currentFTUXLetterTile;
                val_3 = UnityEngine.Object.op_Equality(x:  (true + 0) + 32, y:  val_3);
                (true + 0) + 32 + 32.interactable = val_3;
                val_2 = this.keyboardTiles;
                val_3 = val_3 + 1;
            }
            while(val_2 != null);
            
            throw new NullReferenceException();
        }
        public SLC.Minigames.WordQuiz.WordQuizLetterTile GetNextLetterInFTUX(int index)
        {
            var val_5;
            var val_6;
            bool val_5 = true;
            val_5 = 0;
            label_13:
            if(val_5 >= val_5)
            {
                goto label_2;
            }
            
            if(val_5 <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_5 = val_5 + 0;
            val_6 = mem[(true + 0) + 32];
            val_6 = (true + 0) + 32;
            SLC.Minigames.WordQuiz.WordQuizManager val_1 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if((System.String.op_Equality(a:  val_1.currentLevel.word.Chars[index].ToString(), b:  (true + 0) + 32 + 24)) != false)
            {
                    if(((true + 0) + 32 + 97) == 0)
            {
                    return (SLC.Minigames.WordQuiz.WordQuizLetterTile)val_6;
            }
            
            }
            
            val_5 = val_5 + 1;
            if(this.keyboardTiles != null)
            {
                goto label_13;
            }
            
            throw new NullReferenceException();
            label_2:
            val_6 = 0;
            return (SLC.Minigames.WordQuiz.WordQuizLetterTile)val_6;
        }
        public void UpdateFailedLevelUI(bool on)
        {
            if(this.checkMarkWrong != null)
            {
                    this.checkMarkWrong.SetActive(value:  on);
                return;
            }
            
            throw new NullReferenceException();
        }
        public void UpdateSuccessLevelUI()
        {
            if(this.checkMarkCorrect != null)
            {
                    this.checkMarkCorrect.SetActive(value:  true);
                return;
            }
            
            throw new NullReferenceException();
        }
        public void ShowHint()
        {
            var val_10;
            System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLetterTile> val_11;
            val_10 = this;
            val_11 = this.answerTiles;
            if(null == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.OnTileDeselected(tile:  public System.Boolean Dictionary.Enumerator<System.String, WordForest.WFOMiniEventButton>::MoveNext(), fromHint:  true);
            SLC.Minigames.WordQuiz.WordQuizManager val_2 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(val_2.hintOrder < 1)
            {
                    return;
            }
            
            SLC.Minigames.WordQuiz.WordQuizManager val_3 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_11 = mem[MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 32];
            val_11 = MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 32;
            if(val_11 == 1)
            {
                    return;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            .currentHintAnswerTile = (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 32) << 3) + 32;
            mem2[0] = 1;
            (WordQuizUIController.<>c__DisplayClass30_0)[1152921519790773792].currentHintAnswerTile.SetHiddenState(hidden:  false);
            (WordQuizUIController.<>c__DisplayClass30_0)[1152921519790773792].currentHintAnswerTile.SetHinted();
            SLC.Minigames.WordQuiz.WordQuizManager val_4 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            string val_6 = val_4.currentLevel.word.Chars[val_11].ToString();
            SLC.Minigames.WordQuiz.WordQuizManager val_7 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            val_7.hintOrder.RemoveAt(index:  0);
            System.Predicate<SLC.Minigames.WordQuiz.WordQuizLetterTile> val_8 = null;
            val_11 = val_8;
            val_8 = new System.Predicate<SLC.Minigames.WordQuiz.WordQuizLetterTile>(object:  new WordQuizUIController.<>c__DisplayClass30_0(), method:  System.Boolean WordQuizUIController.<>c__DisplayClass30_0::<ShowHint>b__0(SLC.Minigames.WordQuiz.WordQuizLetterTile x));
            val_10 = this.keyboardTiles.Find(match:  val_8);
            val_9.canvasGroup.alpha = 0f;
            val_9.btn.interactable = false;
            val_9.submitted = true;
        }
        private void OnEnable()
        {
            this.hintBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.WordQuiz.WordQuizUIController::OnClickHintBtn()));
        }
        public void OnClickPause()
        {
            this.pauseCanvas.SetActive(value:  true);
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
        }
        public void OnClickQuit()
        {
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            this.pauseCanvas.SetActive(value:  false);
            MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance.QuitGame();
        }
        private void OnClickHintBtn()
        {
            var val_18;
            SLC.Minigames.WordQuiz.WordQuizManager val_1 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance;
            if(val_1.isPaused != false)
            {
                    return;
            }
            
            decimal val_2 = CurrencyController.GetBalance();
            decimal val_4 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance.hintCost;
            if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})) != false)
            {
                    Player val_6 = App.Player;
                int val_18 = val_6.properties.MGHintsCount;
                val_18 = val_18 + 1;
                val_6.properties.MGHintsCount = val_18;
                decimal val_8 = MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance.hintCost;
                bool val_12 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, source:  System.String.Format(format:  "MG {0} HINT", arg0:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameName), externalParams:  0, animated:  false);
                this.ShowHint();
                MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance.CheckAnswerCorrect(answer:  this.CurrentAnswer);
                MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
                return;
            }
            
            val_18 = null;
            val_18 = null;
            PurchaseProxy.currentPurchasePoint = 23;
            MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  0);
        }
        private void ClearUI()
        {
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.keyboardArea.transform);
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.answerGroup.transform);
            this.tutorialText.SetActive(value:  false);
            this.checkMarkWrong.SetActive(value:  false);
            this.checkMarkCorrect.SetActive(value:  false);
        }
        private int GetKeyboardAreaCol(int keyboardLetterNumber)
        {
            int val_1 = keyboardLetterNumber - 8;
            if(val_1 >= 9)
            {
                    return (int)(keyboardLetterNumber != 18) ? (6 + 1) : 6;
            }
            
            if(((341 >> val_1) & 1) != 0)
            {
                    return (int)32556576 + ((keyboardLetterNumber - 8)) << 2;
            }
            
            return (int)(keyboardLetterNumber != 18) ? (6 + 1) : 6;
        }
        public WordQuizUIController()
        {
            this.answerTiles = new System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLetterTile>();
            this.keyboardTiles = new System.Collections.Generic.List<SLC.Minigames.WordQuiz.WordQuizLetterTile>();
        }
    
    }

}
