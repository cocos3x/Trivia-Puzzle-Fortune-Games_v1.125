using UnityEngine;

namespace SLC.Minigames.Just2Emojis
{
    public class Just2EmojisUIController : MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>
    {
        // Fields
        private UnityEngine.Canvas canvas;
        private UnityEngine.Canvas pauseCanvas;
        private EmojiDisplay emojiDisplay_1;
        private EmojiDisplay emojiDisplay_2;
        private UnityEngine.UI.Image markRight;
        private UnityEngine.UI.Image markWrong;
        private UnityEngine.Transform answersTransform;
        private UnityEngine.GameObject answerLetterBlock;
        private UnityEngine.GameObject answerDisplayLine;
        private UnityEngine.Sprite answerEmptySprite;
        private UnityEngine.Sprite answerFilledSprite;
        private UnityEngine.GameObject blankSpace;
        private UnityEngine.UI.HorizontalLayoutGroup answerLayout1;
        private UnityEngine.UI.HorizontalLayoutGroup answerLayout2;
        private UnityEngine.GameObject letterlayout_8;
        private UnityEngine.GameObject letterLayout_10;
        private UnityEngine.GameObject letterlayout_12;
        private UnityEngine.GameObject letterlayout_14;
        private UnityEngine.GameObject letterlayout_16;
        private UnityEngine.GameObject letterlayout_18;
        private UnityEngine.GameObject letterlayout_21;
        private UnityEngine.UI.Button hintButton;
        private UnityEngine.UI.Text hintButton_hintCostText;
        private UnityEngine.UI.Button quitButton;
        private UnityEngine.UI.Button resumeButton;
        private System.Collections.Generic.Dictionary<string, UnityEngine.Sprite> spriteLookup;
        private System.Collections.Generic.Dictionary<string, object> emojiLookup;
        private System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Just2EmojisItem> progressBlocks;
        private System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Just2EmojisAnswer> answerBlocks;
        private System.Collections.Generic.Dictionary<int, UnityEngine.GameObject> layoutDictionary;
        private SLC.Minigames.Just2Emojis.Just2EmojisItem[] letters;
        private bool init;
        private string answer;
        private float answerLetterFontSize;
        private float answerLayout1StartWidth;
        private float answerLayout2StartWidth;
        private SLC.Minigames.Just2Emojis.J2ELevel currentLevel;
        private bool shouldDisable;
        
        // Properties
        private decimal hintCost { get; }
        public bool ShouldDisable { get; }
        
        // Methods
        private decimal get_hintCost()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            return new System.Decimal() {flags = val_1.hintCost, hi = val_1.hintCost};
        }
        public bool get_ShouldDisable()
        {
            return (bool)this.shouldDisable;
        }
        public override void InitMonoSingleton()
        {
            System.Action val_8;
            this.hintButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisUIController::OnClick_Hint()));
            this.quitButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisUIController::OnClick_Quit()));
            this.resumeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisUIController::OnClick_Resume()));
            val_8 = 1152921504893161472;
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
            {
                    return;
            }
            
            SLC.Minigames.MinigameManager val_6 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Action val_7 = null;
            val_8 = val_7;
            val_7 = new System.Action(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisUIController::OnClick_Pause());
            val_6.OnPauseClicked = val_8;
        }
        public void Initialize()
        {
            if(this.init == true)
            {
                    return;
            }
            
            MonoSingleton<EmojiManagerMinigames>.Instance.BuildEmojiLookup();
            MonoSingleton<MinigameAudioController>.Instance.StartMusic(clipIndex:  0);
            System.Collections.Generic.Dictionary<System.Int32, UnityEngine.GameObject> val_3 = new System.Collections.Generic.Dictionary<System.Int32, UnityEngine.GameObject>();
            this.layoutDictionary = val_3;
            val_3.Add(key:  8, value:  this.letterlayout_8);
            this.layoutDictionary.Add(key:  10, value:  this.letterLayout_10);
            this.layoutDictionary.Add(key:  12, value:  this.letterlayout_12);
            this.layoutDictionary.Add(key:  14, value:  this.letterlayout_14);
            this.layoutDictionary.Add(key:  16, value:  this.letterlayout_16);
            this.layoutDictionary.Add(key:  18, value:  this.letterlayout_18);
            this.layoutDictionary.Add(key:  21, value:  this.letterlayout_21);
            UnityEngine.Rect val_5 = this.answerLayout1.GetComponent<UnityEngine.RectTransform>().rect;
            this.answerLayout1StartWidth = val_5.m_XMin.width;
            UnityEngine.Rect val_8 = this.answerLayout2.GetComponent<UnityEngine.RectTransform>().rect;
            this.answerLayout2StartWidth = val_8.m_XMin.width;
            this.init = true;
        }
        public void StartLevel(SLC.Minigames.Just2Emojis.J2ELevel currentLevel)
        {
            var val_16;
            var val_17;
            UnityEngine.Canvas val_35;
            var val_36;
            var val_37;
            SLC.Minigames.Just2Emojis.Just2EmojisItem val_38;
            bool val_39;
            if(this.init != true)
            {
                    this.Initialize();
            }
            
            val_35 = this.pauseCanvas;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_35.enabled = false;
            SLC.Minigames.MinigamesCheckpointSlider val_1 = MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.UpdateUI();
            this.currentLevel = currentLevel;
            decimal val_2 = val_1.hintCost;
            if(App.getGameEcon == null)
            {
                    throw new NullReferenceException();
            }
            
            string val_4 = val_2.flags.ToString(format:  val_3.numberFormatInt);
            if(this.hintButton_hintCostText == null)
            {
                    throw new NullReferenceException();
            }
            
            val_35 = this.markWrong;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_35.enabled = false;
            val_35 = this.markRight;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_35.enabled = false;
            this.progressBlocks = new System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Just2EmojisItem>();
            val_35 = this.answerLayout1;
            this.answerBlocks = new System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Just2EmojisAnswer>();
            this.shouldDisable = false;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  val_35.transform);
            val_35 = this.answerLayout2;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  val_35.transform);
            val_35 = this.answerLayout1;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.RectTransform val_9 = val_35.GetComponent<UnityEngine.RectTransform>();
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9.SetSizeWithCurrentAnchors(axis:  0, size:  this.answerLayout1StartWidth);
            val_35 = this.answerLayout2;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.RectTransform val_10 = val_35.GetComponent<UnityEngine.RectTransform>();
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_10.SetSizeWithCurrentAnchors(axis:  0, size:  this.answerLayout2StartWidth);
            if(currentLevel == null)
            {
                    throw new NullReferenceException();
            }
            
            this.answerLetterFontSize = 0f;
            this.answer = currentLevel.answer;
            if(currentLevel.lettersSet == null)
            {
                    throw new NullReferenceException();
            }
            
            if(W23 >= 9)
            {
                goto label_20;
            }
            
            val_36 = 8;
            if(currentLevel.answer != null)
            {
                goto label_33;
            }
            
            throw new NullReferenceException();
            label_20:
            if(W23 >= 11)
            {
                goto label_23;
            }
            
            val_36 = 10;
            if(currentLevel.answer != null)
            {
                goto label_33;
            }
            
            throw new NullReferenceException();
            label_23:
            if(W23 >= 13)
            {
                goto label_26;
            }
            
            val_36 = 12;
            if(currentLevel.answer != null)
            {
                goto label_33;
            }
            
            throw new NullReferenceException();
            label_26:
            if(W23 >= 15)
            {
                goto label_29;
            }
            
            val_36 = 14;
            if(currentLevel.answer != null)
            {
                goto label_33;
            }
            
            throw new NullReferenceException();
            label_29:
            if(W23 >= 17)
            {
                goto label_32;
            }
            
            val_36 = 16;
            if(currentLevel.answer != null)
            {
                goto label_33;
            }
            
            throw new NullReferenceException();
            label_32:
            int val_11 = (W23 < 19) ? 18 : 21;
            if(currentLevel.answer == null)
            {
                    throw new NullReferenceException();
            }
            
            label_33:
            char[] val_12 = new char[1];
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_12[0] = 32;
            System.String[] val_13 = currentLevel.answer.Split(separator:  val_12);
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_13.Length != 1)
            {
                goto label_39;
            }
            
            label_42:
            this.SingleLineAnswerDisplay(a:  this.answer);
            goto label_41;
            label_39:
            if(val_13.Length < 2)
            {
                goto label_41;
            }
            
            if(currentLevel.answer.m_stringLength <= 10)
            {
                goto label_42;
            }
            
            this.DoubleLineAnswerDisplay(a:  val_12, words:  val_13);
            label_41:
            val_35 = this.layoutDictionary;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_14 = val_35.GetEnumerator();
            label_49:
            val_37 = public System.Boolean Dictionary.Enumerator<System.Int32, UnityEngine.GameObject>::MoveNext();
            if(val_16.MoveNext() == false)
            {
                goto label_44;
            }
            
            val_35 = val_17;
            if(val_11 != val_17)
            {
                goto label_45;
            }
            
            if(val_35 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_35.SetActive(value:  true);
            goto label_49;
            label_45:
            val_35.SetActive(value:  false);
            goto label_49;
            label_44:
            val_16.Dispose();
            val_35 = this.layoutDictionary;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.GameObject val_19 = val_35.Item[val_11];
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_20 = val_19.transform;
            if(val_20 == null)
            {
                    throw new NullReferenceException();
            }
            
            this.letters = val_20.GetComponentsInChildren<SLC.Minigames.Just2Emojis.Just2EmojisItem>();
            RandomSet val_22 = new RandomSet();
            if(this.letters == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_35 = 0;
            label_56:
            if(val_35 >= this.letters.Length)
            {
                goto label_54;
            }
            
            if(val_22 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_35 = val_22;
            val_22.add(item:  0, weight:  1f);
            val_35 = val_35 + 1;
            if(this.letters != null)
            {
                goto label_56;
            }
            
            throw new NullReferenceException();
            label_54:
            if(this.letters.Length >= 1)
            {
                    do
            {
                val_35 = this.letters[0];
                if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_35.Show();
                if(0 < W23)
            {
                    if(val_22 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_35 = val_22;
                if(this.letters == null)
            {
                    throw new NullReferenceException();
            }
            
                int val_36 = this.letters.Length;
                if(currentLevel.lettersSet == null)
            {
                    throw new NullReferenceException();
            }
            
                val_38 = this.letters[val_22.roll(unweighted:  false)];
                if(val_36 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_36 = val_36 + 0;
            }
            else
            {
                    if(val_22 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_35 = val_22;
                if(this.letters == null)
            {
                    throw new NullReferenceException();
            }
            
                val_38 = this.letters[val_22.roll(unweighted:  false)];
            }
            
                string val_26 = SLC.Minigames.Just2Emojis.Just2EmojisUIController.GetLetter().ToString();
                if(val_38 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_35 = val_38;
                val_35.SetUp(letter:  val_26);
                if(this.letters == null)
            {
                    throw new NullReferenceException();
            }
            
            }
            while((0 + 1) < this.letters.Length);
            
            }
            
            if(currentLevel.emojis == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.letters == null)
            {
                    val_35 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            SLC.Minigames.Just2Emojis.Just2EmojisItem val_37 = this.letters[0];
            if(val_37 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.emojiDisplay_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_35 = this.emojiDisplay_1;
            val_35.DisplayEmoji(emojiID:  val_26, addOutline:  false);
            if(val_37 <= 1)
            {
                    val_35 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(this.letters[0].myImage == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.emojiDisplay_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            this.emojiDisplay_2.DisplayEmoji(emojiID:  val_26, addOutline:  false);
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            if((MonoSingleton<Just2EmojisFTUXManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_29.checkedFTUX != true)
            {
                    if(val_28.currentPlayerLevel != 0)
            {
                    if((MonoSingleton<Just2EmojisFTUXManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
                val_39 = 0;
            }
            else
            {
                    if((MonoSingleton<Just2EmojisFTUXManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
                val_39 = true;
            }
            
                val_31.ftux = val_39;
            }
            
            if((MonoSingleton<Just2EmojisFTUXManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_32.ftux != false)
            {
                    Just2EmojisFTUXManager val_33 = MonoSingleton<Just2EmojisFTUXManager>.Instance;
                if(val_33 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_33.StartFTUX();
                return;
            }
            
            this.SetLettersInteractable(on:  true);
            Just2EmojisFTUXManager val_34 = MonoSingleton<Just2EmojisFTUXManager>.Instance;
            if(val_34 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_34.enabled = false;
        }
        private void SingleLineAnswerDisplay(string a)
        {
            var val_10;
            UnityEngine.Transform val_11;
            this.answerLayout2.gameObject.SetActive(value:  false);
            if(a.m_stringLength < 1)
            {
                    return;
            }
            
            var val_10 = 0;
            do
            {
                if((a.Chars[0] & 65535) == ' ')
            {
                    val_11 = this.answerLayout1.transform;
                UnityEngine.GameObject val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.blankSpace, parent:  val_11);
            }
            else
            {
                    UnityEngine.GameObject val_7 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.answerLetterBlock, parent:  this.answerLayout1.transform);
                SLC.Minigames.Just2Emojis.Just2EmojisAnswer val_8 = val_7.GetComponent<SLC.Minigames.Just2Emojis.Just2EmojisAnswer>();
                this.EmptyAnswerBlock(blockImage:  val_8.myImage, letter:  val_8.myText);
                val_11 = this.answerBlocks;
                val_11.Add(item:  val_7.GetComponent<SLC.Minigames.Just2Emojis.Just2EmojisAnswer>());
                if(null <= val_10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                UnityEngine.Object.__il2cppRuntimeField_byval_arg.__unknownFiledOffset_20 = val_10;
                val_10 = val_10 + 1;
            }
            
                val_10 = 0 + 1;
            }
            while(val_10 < a.m_stringLength);
        
        }
        private void SetUpAnswerDisplay(string a, int number)
        {
            var val_17;
            var val_18;
            var val_19;
            UnityEngine.Transform val_20;
            val_17 = number;
            if(val_17 != 1)
            {
                    if(val_17 != 2)
            {
                    return;
            }
            
                if(a.m_stringLength < 1)
            {
                    return;
            }
            
                val_18 = 1152921504765632512;
                val_19 = 1152921519922211440;
                var val_17 = 0;
                do
            {
                if((a.Chars[0] & 65535) == ' ')
            {
                    val_20 = this.answerLayout2.transform;
                UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.blankSpace, parent:  val_20);
            }
            else
            {
                    UnityEngine.GameObject val_6 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.answerLetterBlock, parent:  this.answerLayout2.transform);
                SLC.Minigames.Just2Emojis.Just2EmojisAnswer val_7 = val_6.GetComponent<SLC.Minigames.Just2Emojis.Just2EmojisAnswer>();
                this.EmptyAnswerBlock(blockImage:  val_7.myImage, letter:  val_7.myText);
                val_20 = this.answerBlocks;
                val_20.Add(item:  val_6.GetComponent<SLC.Minigames.Just2Emojis.Just2EmojisAnswer>());
                if(null <= val_17)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                UnityEngine.Object.__il2cppRuntimeField_byval_arg.__unknownFiledOffset_20 = val_17;
                val_17 = val_17 + 1;
            }
            
                val_17 = 0 + 1;
            }
            while(val_17 < a.m_stringLength);
            
                return;
            }
            
            if(a.m_stringLength < 1)
            {
                    return;
            }
            
            val_18 = 1152921504765632512;
            val_19 = 1152921519922211440;
            var val_18 = 0;
            do
            {
                if((a.Chars[0] & 65535) == ' ')
            {
                    val_20 = this.answerLayout1.transform;
                UnityEngine.GameObject val_12 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.blankSpace, parent:  val_20);
            }
            else
            {
                    UnityEngine.GameObject val_14 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.answerLetterBlock, parent:  this.answerLayout1.transform);
                SLC.Minigames.Just2Emojis.Just2EmojisAnswer val_15 = val_14.GetComponent<SLC.Minigames.Just2Emojis.Just2EmojisAnswer>();
                this.EmptyAnswerBlock(blockImage:  val_15.myImage, letter:  val_15.myText);
                val_20 = this.answerBlocks;
                val_20.Add(item:  val_14.GetComponent<SLC.Minigames.Just2Emojis.Just2EmojisAnswer>());
                if(null <= val_18)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                UnityEngine.Object.__il2cppRuntimeField_byval_arg.__unknownFiledOffset_20 = val_18;
                val_18 = val_18 + 1;
            }
            
                val_17 = 0 + 1;
            }
            while(val_17 < a.m_stringLength);
        
        }
        private void DoubleLineAnswerDisplay(string a, string[] words)
        {
            string val_5;
            string val_6;
            string val_7;
            string val_8;
            string val_9;
            int val_10;
            var val_11;
            int val_12;
            val_5 = "";
            this.answerLayout2.gameObject.SetActive(value:  true);
            if(words.Length == 4)
            {
                goto label_4;
            }
            
            if(words.Length == 3)
            {
                goto label_5;
            }
            
            val_6 = val_5;
            if(words.Length != 2)
            {
                goto label_6;
            }
            
            val_6 = words[0];
            val_5 = words[1];
            goto label_16;
            label_5:
            val_6 = words[0];
            string val_5 = words[1];
            int val_6 = words[0].m_stringLength;
            val_6 = words[1].m_stringLength + val_6;
            if(val_6 >= 11)
            {
                goto label_14;
            }
            
            val_5 = words[2];
            val_6 = val_6 + " " + val_5;
            goto label_16;
            label_4:
            val_6 = words[0] + " " + words[1];
            val_7 = words[2];
            val_8 = words[3];
            val_9 = " ";
            goto label_21;
            label_14:
            val_8 = words[2];
            val_7 = val_5;
            val_9 = " ";
            label_21:
            val_5 = val_7 + val_9 + val_8;
            label_16:
            this.SetUpAnswerDisplay(a:  val_6, number:  1);
            this.SetUpAnswerDisplay(a:  val_5, number:  2);
            label_6:
            val_10 = val_4.m_stringLength;
            if(words[0].m_stringLength > val_10)
            {
                    val_11 = 2;
                val_12 = words[0].m_stringLength;
            }
            else
            {
                    if(words[0].m_stringLength >= val_10)
            {
                    return;
            }
            
                val_11 = 1;
                val_12 = val_10;
                val_10 = words[0].m_stringLength;
            }
            
            this.ResizeAnswerBlocks(number:  1, otherLettersCount:  val_12, currAnswerCount:  val_10);
        }
        private void ResizeAnswerBlocks(int number, int otherLettersCount, int currAnswerCount)
        {
            var val_10;
            if(number == 2)
            {
                goto label_1;
            }
            
            if(number != 1)
            {
                    return;
            }
            
            val_10 = 1152921509992919280;
            UnityEngine.Rect val_2 = this.answerLayout2.GetComponent<UnityEngine.RectTransform>().rect;
            float val_3 = val_2.m_XMin.width;
            if(this.answerLayout1 != null)
            {
                goto label_5;
            }
            
            label_1:
            val_10 = 1152921509992919280;
            UnityEngine.Rect val_5 = this.answerLayout1.GetComponent<UnityEngine.RectTransform>().rect;
            label_5:
            int val_8 = otherLettersCount * 10;
            val_8 = val_8 - 10;
            float val_10 = (float)val_8;
            float val_11 = (float)otherLettersCount;
            int val_9 = currAnswerCount * 10;
            val_10 = val_5.m_XMin.width - val_10;
            val_9 = val_9 - 10;
            val_11 = val_10 / val_11;
            val_11 = val_11 * (float)currAnswerCount;
            val_11 = val_11 + (float)val_9;
            this.answerLayout2.GetComponent<UnityEngine.RectTransform>().SetSizeWithCurrentAnchors(axis:  0, size:  val_11);
        }
        public void OnLetterBlockClicked(string letter, int index, SLC.Minigames.Just2Emojis.Just2EmojisItem item)
        {
            int val_12 = index;
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            Just2EmojisFTUXManager val_2 = MonoSingleton<Just2EmojisFTUXManager>.Instance;
            if(val_2.ftux != false)
            {
                    if((MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance.GetAnswerNextLetter()) != null)
            {
                    if((System.String.op_Equality(a:  letter, b:  MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance.GetAnswerNextLetter())) != false)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + (index) << 3) + 32.Fill(letter:  letter);
                val_12 = (long)val_12;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                ((MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + (index) << 3) + ((long)(int)(index)) << 3) + 32 + 48.sprite = this.answerFilledSprite;
                item.Hide();
                this.progressBlocks.Add(item:  item);
                SLC.Minigames.Just2Emojis.Just2EmojisManager val_9 = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance;
                int val_12 = val_9.ftuxIndex;
                val_12 = val_12 + 1;
                val_9.ftuxIndex = val_12;
                this.FTUXHighlight();
            }
            
            }
            
                MonoSingleton<Just2EmojisFTUXManager>.Instance.ResetFTUXTimer();
                return;
            }
            
            Just2EmojisFTUXManager val_11 = MonoSingleton<Just2EmojisFTUXManager>.Instance;
            bool val_13 = val_11.ftux;
            if(val_13 != false)
            {
                    return;
            }
            
            if(val_13 <= val_12)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_13 = val_13 + (val_12 << 3);
            (val_11.ftux + (index) << 3) + 32.Fill(letter:  letter);
            if(val_13 <= val_12)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_13 = val_13 + (((long)(int)(index)) << 3);
            ((val_11.ftux + (index) << 3) + ((long)(int)(index)) << 3) + 32 + 48.sprite = this.answerFilledSprite;
            item.Hide();
            this.progressBlocks.Add(item:  item);
        }
        public void OnAnswerBlockClicked(int index)
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.DelayedReturn(index:  index));
        }
        private System.Collections.IEnumerator DelayedReturn(int index)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .index = index;
            return (System.Collections.IEnumerator)new Just2EmojisUIController.<DelayedReturn>d__51();
        }
        public void AnswerClicked(SLC.Minigames.Just2Emojis.Just2EmojisAnswer answer)
        {
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance.AnswerClick(answer:  answer, answerBlocks:  this.answerBlocks);
        }
        public void MarkCorrectAnswer()
        {
            this.markRight.enabled = true;
            this.SetLettersInteractable(on:  false);
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Win", clipIndex:  0, volumeScale:  1f);
        }
        public void MarkWrongAnswer()
        {
            this.markWrong.enabled = true;
            this.SetLettersInteractable(on:  false);
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Lose", clipIndex:  0, volumeScale:  1f);
        }
        public void SetLettersInteractable(bool on)
        {
            SLC.Minigames.Just2Emojis.Just2EmojisItem val_11;
            UnityEngine.UI.Button val_12 = this.hintButton;
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            on = on;
            val_12.interactable = on;
            if(this.letters == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.letters.Length >= 1)
            {
                    var val_11 = 0;
                do
            {
                val_11 = this.letters[val_11];
                if(val_11 == null)
            {
                    throw new NullReferenceException();
            }
            
                if((val_11.GetComponent<UnityEngine.UI.Button>()) != 0)
            {
                    UnityEngine.UI.Button val_3 = val_11.GetComponent<UnityEngine.UI.Button>();
                if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_3.interactable = on;
            }
            
                val_11 = val_11 + 1;
            }
            while(val_11 < this.letters.Length);
            
            }
            
            val_12 = this.answerBlocks;
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_5 = val_12.GetEnumerator();
            label_18:
            if(0.MoveNext() == false)
            {
                goto label_12;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((0.GetComponent<UnityEngine.UI.Button>()) == 0)
            {
                goto label_18;
            }
            
            0.GetComponent<UnityEngine.UI.Button>().interactable = on;
            goto label_18;
            label_12:
            0.Dispose();
        }
        public void SetAnswersInteractable(bool on)
        {
            var val_5;
            var val_6;
            List.Enumerator<T> val_1 = this.answerBlocks.GetEnumerator();
            label_5:
            val_5 = public System.Boolean List.Enumerator<SLC.Minigames.Just2Emojis.Just2EmojisAnswer>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_6 = 0;
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_5 = public UnityEngine.UI.Button UnityEngine.Component::GetComponent<UnityEngine.UI.Button>();
            UnityEngine.UI.Button val_4 = val_6.GetComponent<UnityEngine.UI.Button>();
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_4.interactable = on;
            goto label_5;
            label_2:
            0.Dispose();
        }
        public void EmptyAnswerBlock(UnityEngine.UI.Image blockImage, TMPro.TMP_Text letter)
        {
            blockImage.sprite = this.answerEmptySprite;
            goto typeof(TMPro.TMP_Text).__il2cppRuntimeField_550;
        }
        public void Hinted(int index)
        {
            System.Collections.Generic.List<SLC.Minigames.Just2Emojis.Just2EmojisAnswer> val_9;
            bool val_9 = true;
            if(val_9 <= index)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_9 = val_9 + (index << 3);
            string val_3 = this.currentLevel.StrippedAnswer.Chars[index].ToString();
            var val_10 = (true + (index) << 3) + 32 + 40;
            if(val_10 <= index)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_10 = val_10 + (((long)(int)(index)) << 3);
            var val_11 = ((true + (index) << 3) + 32 + 40 + ((long)(int)(index)) << 3) + 32;
            ((true + (index) << 3) + 32 + 40 + ((long)(int)(index)) << 3) + 32 + 40.enableAutoSizing = false;
            if(val_11 <= index)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_11 = val_11 + (((long)(int)(index)) << 3);
            var val_12 = (((true + (index) << 3) + 32 + 40 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32;
            (((true + (index) << 3) + 32 + 40 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + 40.fontSize = this.FindBestAnswerFontSize();
            if(val_12 <= index)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_12 = val_12 + (((long)(int)(index)) << 3);
            var val_13 = ((((true + (index) << 3) + 32 + 40 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32;
            mem2[0] = 1;
            if(val_13 <= index)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_13 = val_13 + (((long)(int)(index)) << 3);
            UnityEngine.Color val_5 = UnityEngine.Color.black;
            var val_14 = (((((true + (index) << 3) + 32 + 40 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + 40;
            if(val_14 <= index)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_14 = val_14 + (((long)(int)(index)) << 3);
            var val_15 = ((((((true + (index) << 3) + 32 + 40 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + 40 + ((long)(int)(index)) + 32;
            ((((((true + (index) << 3) + 32 + 40 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + 40 + ((long)(int)(index)) + 32 + 48.enabled = false;
            val_9 = this.answerBlocks;
            if(val_15 <= index)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_15 = val_15 + (((long)(int)(index)) << 3);
            if(this.letters.Length < 1)
            {
                goto label_37;
            }
            
            var val_16 = 0;
            do
            {
                val_9 = this.letters[val_16];
                if(this.letters[0x0][0].isHinted != true)
            {
                    if((System.String.op_Equality(a:  this.letters[0x0][0].letter, b:  (((((((true + (index) << 3) + 32 + 40 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + ((long)(int)(index)) << 3) + 32 + 40 + ((long)(int)(index) + 32 + 40)) == true)
            {
                goto label_35;
            }
            
            }
            
                val_16 = val_16 + 1;
            }
            while(val_16 < this.letters.Length);
            
            goto label_37;
            label_35:
            val_9.Hide();
            this.letters[0x0][0].isHinted = true;
            label_37:
            UnityEngine.Coroutine val_8 = this.StartCoroutine(routine:  this.DelayedReturn(index:  0));
        }
        public void DisplayAnswer()
        {
            this.markWrong.enabled = false;
            var val_6 = 0;
            do
            {
                string val_1 = this.currentLevel.StrippedAnswer;
                int val_5 = val_1.m_stringLength;
                if(val_6 >= val_5)
            {
                    return;
            }
            
                if(val_5 <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_5 = val_5 + 0;
                string val_4 = this.currentLevel.StrippedAnswer.Chars[0].ToString();
                val_6 = val_6 + 1;
            }
            while(this.currentLevel != null);
            
            throw new NullReferenceException();
        }
        public static char GetLetter()
        {
            return Chars[UnityEngine.Random.Range(min:  0, max:  ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".__il2cppRuntimeField_10 - 1)>>0&0xFFFFFFFF)];
        }
        public void ToggleUI(bool show)
        {
            if(this.canvas != null)
            {
                    this.canvas.enabled = show;
                return;
            }
            
            throw new NullReferenceException();
        }
        public float FindBestAnswerFontSize()
        {
            float val_2;
            var val_3;
            if(true == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = this.answerLetterFontSize;
            if(val_2 == 0f)
            {
                    if(0 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_3 = mem[mem[-2305843009213693920] + 40];
                val_3 = mem[-2305843009213693920] + 40;
                val_3.enabled = true;
                val_3.enableAutoSizing = true;
                val_2 = (mem[-2305843009213693920] + 40 + 460) * 0.85f;
                this.answerLetterFontSize = val_2;
                val_3.enableAutoSizing = false;
            }
            else
            {
                    val_3 = mem[-2305843009213693912];
            }
            
            val_3.fontSize = val_2;
            return val_2;
        }
        private void OnClick_Pause()
        {
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            this.pauseCanvas.enabled = true;
        }
        private void OnClick_Quit()
        {
            this.pauseCanvas.enabled = false;
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance)) == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowGameOver();
        }
        private void OnClick_Resume()
        {
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            this.pauseCanvas.enabled = false;
        }
        private void OnClick_Hint()
        {
            var val_15;
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            SLC.Minigames.MinigameManager val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            decimal val_4 = App.Player.hintCost;
            if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = X20, mid = X20}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})) != false)
            {
                    MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance.Hint();
                int val_15 = val_7.properties.MGHintsCount;
                val_15 = val_15 + 1;
                val_7.properties.MGHintsCount = val_15;
                decimal val_8 = App.Player.hintCost;
                bool val_12 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, source:  System.String.Format(format:  "MG {0} HINT", arg0:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameName), externalParams:  0, animated:  false);
                return;
            }
            
            val_15 = null;
            val_15 = null;
            PurchaseProxy.currentPurchasePoint = 25;
            MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  0);
        }
        public void StartFTUX()
        {
            this.FTUXHighlight();
        }
        public void FTUXHighlight()
        {
            var val_5;
            MonoSingleton<Just2EmojisFTUXManager>.Instance.HideHand();
            string val_3 = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance.GetAnswerNextLetter();
            if(val_3 == null)
            {
                    return;
            }
            
            val_5 = 4;
            label_22:
            if((val_5 - 4) >= this.letters.Length)
            {
                    return;
            }
            
            SLC.Minigames.Just2Emojis.Just2EmojisItem val_6 = this.letters[0];
            if((System.String.op_Equality(a:  this.letters[0].letter, b:  val_3)) == false)
            {
                goto label_12;
            }
            
            if(this.letters[0].isHidden == true)
            {
                goto label_16;
            }
            
            if((0 & 1) != 0)
            {
                goto label_18;
            }
            
            this.letters[0].FTUXHighlight();
            goto label_18;
            label_12:
            label_16:
            this.letters[0].Unhighlight();
            label_18:
            val_5 = val_5 + 1;
            if(this.letters != null)
            {
                goto label_22;
            }
            
            throw new NullReferenceException();
        }
        public void FTUXUnhighlight()
        {
            var val_2 = this;
            int val_2 = this.letters.Length;
            if(val_2 < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            val_2 = val_2 & 4294967295;
            do
            {
                if(1152921508258966016 != 0)
            {
                    1152921508258966016.Unhighlight();
            }
            
                val_3 = val_3 + 1;
            }
            while(val_3 < (this.letters.Length << ));
        
        }
        public UnityEngine.Transform FTUXNewLetterPosition()
        {
            string val_4;
            string val_2 = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance.GetAnswerNextLetter();
            if(val_2 == null)
            {
                    return 0;
            }
            
            if(this.letters.Length < 1)
            {
                    return 0;
            }
            
            val_4 = val_2;
            var val_5 = 0;
            do
            {
                if((System.String.op_Equality(a:  this.letters[0x0][0].letter, b:  val_4)) != false)
            {
                    if(this.letters[0x0][0].isHidden == false)
            {
                    return this.letters[val_5].transform;
            }
            
            }
            
                val_5 = val_5 + 1;
            }
            while(val_5 < this.letters.Length);
            
            return 0;
        }
        public Just2EmojisUIController()
        {
        
        }
    
    }

}
