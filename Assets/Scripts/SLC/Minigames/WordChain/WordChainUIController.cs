using UnityEngine;

namespace SLC.Minigames.WordChain
{
    public class WordChainUIController : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject letterTilePrefab;
        private UnityEngine.UI.Text levelText;
        private SLC.Minigames.MinigamesCheckpointSlider minigamesCheckpointSlider;
        private UnityEngine.UI.Text word1;
        private UnityEngine.UI.Text word2;
        private UnityEngine.GameObject checkMarkCorrect;
        private UnityEngine.GameObject checkMarkWrong;
        private UnityEngine.GameObject answerGroup;
        private UnityEngine.GameObject tutorialText;
        private UnityEngine.UI.GridLayoutGroup keyboardArea;
        private UnityEngine.GameObject FTUXHand;
        private UnityEngine.Vector3 FTUXHandOffset;
        private UnityEngine.UI.Button hintBtn;
        private System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLetterTile> answerTiles;
        private System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLetterTile> keyboardTiles;
        
        // Properties
        private string CurrentAnswer { get; }
        
        // Methods
        private string get_CurrentAnswer()
        {
            string val_4;
            List.Enumerator<T> val_1 = this.answerTiles.GetEnumerator();
            label_5:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_4 = 9733424;
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_3 = "" + val_4;
            goto label_5;
            label_2:
            0.Dispose();
            return "";
        }
        public void InitializeLevel(SLC.Minigames.WordChain.WordChainLevel level)
        {
            int val_14;
            SLC.Minigames.WordChain.WordChainLevel val_29;
            System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLetterTile> val_30;
            SLC.Minigames.WordChain.WordChainLevel val_31;
            val_29 = level;
            this.ClearUI();
            val_30 = this.answerTiles;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = public System.Void System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLetterTile>::Clear();
            val_30.Clear();
            val_30 = this.keyboardTiles;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = public System.Void System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLetterTile>::Clear();
            val_30.Clear();
            SLC.Minigames.WordChain.WordChainManager val_1 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = val_29;
            System.Collections.Generic.List<System.String> val_2 = val_1.GetRandomizedLetters(level:  val_31);
            if(val_29 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(level.answer == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            PluginExtension.Shuffle<System.String>(list:  val_2, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            val_30 = this.keyboardArea;
            int val_4 = level.keyboardLetterNum - 8;
            if(val_4 < 9)
            {
                    if(((341 >> val_4) & 1) != 0)
            {
                goto label_10;
            }
            
            }
            
            var val_6 = (level.keyboardLetterNum != 18) ? (6 + 1) : 6;
            goto label_11;
            label_10:
            val_31 = mem[32560704 + ((level.keyboardLetterNum - 8)) << 2];
            val_31 = 32560704 + ((level.keyboardLetterNum - 8)) << 2;
            label_11:
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_30.constraintCount = val_31;
            if(32560704 >= 1)
            {
                    val_29 = 1152921519831421936;
                int val_27 = 0;
                do
            {
                WordChainUIController.<>c__DisplayClass17_0 val_7 = null;
                val_31 = 0;
                val_7 = new WordChainUIController.<>c__DisplayClass17_0();
                if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
                .<>4__this = this;
                val_30 = this.keyboardArea;
                if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_31 = val_30.transform;
                UnityEngine.GameObject val_9 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.letterTilePrefab, parent:  val_31);
                if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_31 = public SLC.Minigames.WordChain.WordChainLetterTile UnityEngine.GameObject::GetComponent<SLC.Minigames.WordChain.WordChainLetterTile>();
                SLC.Minigames.WordChain.WordChainLetterTile val_10 = val_9.GetComponent<SLC.Minigames.WordChain.WordChainLetterTile>();
                .tile = val_10;
                if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_27 >= 1152921513413301296)
            {
                    val_30 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(val_10.letter == null)
            {
                    throw new NullReferenceException();
            }
            
                val_30 = val_10.letter;
                val_31 = "_____";
                if(((WordChainUIController.<>c__DisplayClass17_0)[1152921519831673520].tile) == null)
            {
                    throw new NullReferenceException();
            }
            
                if(((WordChainUIController.<>c__DisplayClass17_0)[1152921519831673520].tile.btn) == null)
            {
                    throw new NullReferenceException();
            }
            
                UnityEngine.Events.UnityAction val_11 = null;
                val_31 = val_7;
                val_11 = new UnityEngine.Events.UnityAction(object:  val_7, method:  System.Void WordChainUIController.<>c__DisplayClass17_0::<InitializeLevel>b__0());
                if(((WordChainUIController.<>c__DisplayClass17_0)[1152921519831673520].tile.btn.m_OnClick) == null)
            {
                    throw new NullReferenceException();
            }
            
                val_30 = (WordChainUIController.<>c__DisplayClass17_0)[1152921519831673520].tile.btn.m_OnClick;
                val_31 = val_11;
                val_30.AddListener(call:  val_11);
                if(((WordChainUIController.<>c__DisplayClass17_0)[1152921519831673520].tile) == null)
            {
                    throw new NullReferenceException();
            }
            
                (WordChainUIController.<>c__DisplayClass17_0)[1152921519831673520].tile.keyboardIndex = val_27;
                val_30 = this.keyboardTiles;
                if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_31 = (WordChainUIController.<>c__DisplayClass17_0)[1152921519831673520].tile;
                val_30.Add(item:  val_31);
                val_27 = val_27 + 1;
            }
            while(val_27 < ((WordChainUIController.<>c__DisplayClass17_0)[1152921519831673520].tile));
            
            }
            
            val_30 = this.word1;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = mem[level + 16];
            val_31 = level + 16;
            val_30 = this.word2;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = mem[level + 24];
            val_31 = level + 24;
            val_30 = val_2.GetRange(index:  0, count:  level.answer.m_stringLength);
            if(val_30 == 0)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_12 = val_30.GetEnumerator();
            label_43:
            if(val_14.MoveNext() == false)
            {
                goto label_31;
            }
            
            WordChainUIController.<>c__DisplayClass17_1 val_16 = null;
            val_31 = 0;
            val_16 = new WordChainUIController.<>c__DisplayClass17_1();
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            .<>4__this = this;
            val_30 = this.answerGroup;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = val_30.transform;
            UnityEngine.GameObject val_18 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.letterTilePrefab, parent:  val_31);
            if(val_18 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = public SLC.Minigames.WordChain.WordChainLetterTile UnityEngine.GameObject::GetComponent<SLC.Minigames.WordChain.WordChainLetterTile>();
            SLC.Minigames.WordChain.WordChainLetterTile val_19 = val_18.GetComponent<SLC.Minigames.WordChain.WordChainLetterTile>();
            .tile = val_19;
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_19.btn == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Events.UnityAction val_20 = null;
            val_31 = val_16;
            val_20 = new UnityEngine.Events.UnityAction(object:  val_16, method:  System.Void WordChainUIController.<>c__DisplayClass17_1::<InitializeLevel>b__1());
            if(val_19.btn.m_OnClick == null)
            {
                    throw new NullReferenceException();
            }
            
            val_30 = val_19.btn.m_OnClick;
            val_31 = val_20;
            val_30.AddListener(call:  val_20);
            if(((WordChainUIController.<>c__DisplayClass17_1)[1152921519831739056].tile) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_30 = (WordChainUIController.<>c__DisplayClass17_1)[1152921519831739056].tile.btn;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_30.interactable = false;
            this.answerTiles.Add(item:  (WordChainUIController.<>c__DisplayClass17_1)[1152921519831739056].tile);
            goto label_43;
            label_31:
            val_31 = public System.Void List.Enumerator<System.String>::Dispose();
            val_14.Dispose();
            SLC.Minigames.WordChain.WordChainManager val_21 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_22 = val_21.ShouldShowFTUX();
            if(this.tutorialText == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = val_22;
            this.tutorialText.SetActive(value:  val_31);
            val_30 = this.hintBtn;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = 0;
            UnityEngine.GameObject val_23 = val_30.gameObject;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_22 != false)
            {
                    val_31 = 0;
                val_23.SetActive(value:  false);
                SLC.Minigames.WordChain.WordChainFTUX val_24 = MonoSingleton<SLC.Minigames.WordChain.WordChainFTUX>.Instance;
                if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_24.ShowFTUX();
            }
            else
            {
                    val_31 = 1;
                val_23.SetActive(value:  true);
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_28 = val_25.currentPlayerLevel;
            val_28 = val_28 + 1;
            val_14 = val_28;
            val_31 = val_14;
            if(this.levelText == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = "Level " + val_14;
            val_30 = this.minigamesCheckpointSlider;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_30.UpdateUI();
        }
        public void OnTileSelected(SLC.Minigames.WordChain.WordChainLetterTile tile)
        {
            SLC.Minigames.WordChain.WordChainManager val_2 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            SLC.Minigames.WordChain.WordChainManager val_3 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            int val_17 = val_3.answerProgress;
            val_17 = val_17 + 1;
            val_3.answerProgress = val_17;
            SLC.Minigames.WordChain.WordChainManager val_4 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            int val_18 = val_4.answerProgress;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_18 = val_18 + ((val_18 - 1) << 3);
            if((UnityEngine.Object.op_Implicit(exists:  (val_4.answerProgress + ((val_4.answerProgress - 1)) << 3) + 32)) != false)
            {
                    (val_4.answerProgress + ((val_4.answerProgress - 1)) << 3) + 32 + 32.interactable = true;
                mem2[0] = tile.keyboardIndex;
                SLC.Minigames.WordChain.WordChainManager val_7 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
                int val_19 = val_7.answerProgress;
                val_19 = val_19 - 1;
                mem2[0] = val_19;
                tile.canvasGroup.alpha = 0f;
                tile.btn.interactable = false;
                tile.submitted = true;
            }
            
            MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance.CheckAnswerCorrect(answer:  this.CurrentAnswer);
            if((MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance.ShouldShowFTUX()) != false)
            {
                    string val_12 = this.CurrentAnswer;
                SLC.Minigames.WordChain.WordChainManager val_13 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
                if(val_12.m_stringLength < val_13.currentLevel.answer.m_stringLength)
            {
                    MonoSingleton<SLC.Minigames.WordChain.WordChainFTUX>.Instance.ShowFTUX();
                return;
            }
            
            }
            
            MonoSingleton<SLC.Minigames.WordChain.WordChainFTUX>.Instance.StopAllCoroutines();
            this.HideFTUXHand();
        }
        public void OnTileDeselected(SLC.Minigames.WordChain.WordChainLetterTile tile)
        {
            int val_9;
            var val_10;
            bool val_9 = true;
            val_9 = tile.answerIndex;
            goto label_2;
            label_17:
            if(val_9 <= val_9)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_9 = val_9 + (val_9 << 3);
            val_10 = mem[(true + (tile.answerIndex) << 3) + 32];
            val_10 = (true + (tile.answerIndex) << 3) + 32;
            if(((true + (tile.answerIndex) << 3) + 32 + 56) == 0)
            {
                    var val_10 = (true + (tile.answerIndex) << 3) + 32 + 24;
                (true + (tile.answerIndex) << 3) + 32 + 32.interactable = false;
                if(val_10 <= ((true + (tile.answerIndex) << 3) + 32 + 48))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_10 = val_10 + (((true + (tile.answerIndex) << 3) + 32 + 48) << 3);
                val_10 = mem[((true + (tile.answerIndex) << 3) + 32 + 24 + ((true + (tile.answerIndex) << 3) + 32 + 48) << 3) + 32];
                val_10 = ((true + (tile.answerIndex) << 3) + 32 + 24 + ((true + (tile.answerIndex) << 3) + 32 + 48) << 3) + 32;
                ((true + (tile.answerIndex) << 3) + 32 + 24 + ((true + (tile.answerIndex) << 3) + 32 + 48) << 3) + 32 + 40.alpha = 1f;
                ((true + (tile.answerIndex) << 3) + 32 + 24 + ((true + (tile.answerIndex) << 3) + 32 + 48) << 3) + 32 + 32.interactable = true;
                mem2[0] = 0;
            }
            
            val_9 = val_9 + 1;
            label_2:
            SLC.Minigames.WordChain.WordChainManager val_1 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            if(val_9 < val_1.answerProgress)
            {
                goto label_17;
            }
            
            SLC.Minigames.WordChain.WordChainManager val_2 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            val_2.answerProgress = tile.answerIndex;
            if((MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance.ShouldShowFTUX()) != false)
            {
                    string val_5 = this.CurrentAnswer;
                SLC.Minigames.WordChain.WordChainManager val_6 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
                if(val_5.m_stringLength < val_6.currentLevel.answer.m_stringLength)
            {
                    MonoSingleton<SLC.Minigames.WordChain.WordChainFTUX>.Instance.ShowFTUX();
                return;
            }
            
            }
            
            MonoSingleton<SLC.Minigames.WordChain.WordChainFTUX>.Instance.StopAllCoroutines();
            this.HideFTUXHand();
        }
        public void ShowFTUXHand(SLC.Minigames.WordChain.WordChainLetterTile tile)
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
        public void DisableOtherLetterTiles(SLC.Minigames.WordChain.WordChainLetterTile currentFTUXLetterTile)
        {
            System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLetterTile> val_2;
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
                SLC.Minigames.WordChain.WordChainLetterTile val_3 = currentFTUXLetterTile;
                val_3 = UnityEngine.Object.op_Equality(x:  (true + 0) + 32, y:  val_3);
                (true + 0) + 32 + 32.interactable = val_3;
                val_2 = this.keyboardTiles;
                val_3 = val_3 + 1;
            }
            while(val_2 != null);
            
            throw new NullReferenceException();
        }
        public SLC.Minigames.WordChain.WordChainLetterTile GetNextLetterInFTUX(int index)
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
            SLC.Minigames.WordChain.WordChainManager val_1 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            if((System.String.op_Equality(a:  val_1.currentLevel.answer.Chars[index].ToString(), b:  (true + 0) + 32 + 24)) != false)
            {
                    if(((true + 0) + 32 + 57) == 0)
            {
                    return (SLC.Minigames.WordChain.WordChainLetterTile)val_6;
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
            return (SLC.Minigames.WordChain.WordChainLetterTile)val_6;
        }
        public void UpdateFailedLevelUI()
        {
            if(this.checkMarkWrong != null)
            {
                    this.checkMarkWrong.SetActive(value:  true);
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
            if(null == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.OnTileDeselected(tile:  "/");
            SLC.Minigames.WordChain.WordChainManager val_2 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            .currentHintAnswerTile = (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 32) << 3) + 32;
            mem2[0] = 1;
            SLC.Minigames.WordChain.WordChainManager val_3 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            string val_5 = val_3.currentLevel.answer.Chars[MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 32].ToString();
            SLC.Minigames.WordChain.WordChainManager val_6 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            val_6.hintOrder.RemoveAt(index:  0);
            SLC.Minigames.WordChain.WordChainLetterTile val_8 = this.keyboardTiles.Find(match:  new System.Predicate<SLC.Minigames.WordChain.WordChainLetterTile>(object:  new WordChainUIController.<>c__DisplayClass26_0(), method:  System.Boolean WordChainUIController.<>c__DisplayClass26_0::<ShowHint>b__0(SLC.Minigames.WordChain.WordChainLetterTile x)));
            val_8.canvasGroup.alpha = 0f;
            val_8.btn.interactable = false;
            val_8.submitted = true;
        }
        private void OnEnable()
        {
            this.hintBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.WordChain.WordChainUIController::OnClickHintBtn()));
        }
        private void OnClickHintBtn()
        {
            var val_17;
            SLC.Minigames.WordChain.WordChainManager val_1 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance;
            if(val_1.isPaused != false)
            {
                    return;
            }
            
            decimal val_2 = CurrencyController.GetBalance();
            decimal val_4 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance.hintCost;
            if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})) != false)
            {
                    Player val_6 = App.Player;
                int val_17 = val_6.properties.MGHintsCount;
                val_17 = val_17 + 1;
                val_6.properties.MGHintsCount = val_17;
                decimal val_8 = MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance.hintCost;
                bool val_12 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, source:  System.String.Format(format:  "MG {0} HINT", arg0:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameName), externalParams:  0, animated:  false);
                this.ShowHint();
                MonoSingleton<SLC.Minigames.WordChain.WordChainManager>.Instance.CheckAnswerCorrect(answer:  this.CurrentAnswer);
                return;
            }
            
            val_17 = null;
            val_17 = null;
            PurchaseProxy.currentPurchasePoint = 28;
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
                    return (int)32560704 + ((keyboardLetterNumber - 8)) << 2;
            }
            
            return (int)(keyboardLetterNumber != 18) ? (6 + 1) : 6;
        }
        public WordChainUIController()
        {
            this.answerTiles = new System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLetterTile>();
            this.keyboardTiles = new System.Collections.Generic.List<SLC.Minigames.WordChain.WordChainLetterTile>();
        }
    
    }

}
