using UnityEngine;

namespace SLC.Minigames.WordJumble
{
    public class WordJumbleWordArea : MonoBehaviour
    {
        // Fields
        private UnityEngine.RectTransform answerArea;
        private UnityEngine.RectTransform inputArea;
        private bool <IsCompleted>k__BackingField;
        private System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleAnswerLetter> answerLetters;
        private System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleLetterTile> inputLetters;
        private string <correctAnswer>k__BackingField;
        private System.Action <onLetterSubmitted>k__BackingField;
        private System.Action <onWordComplete>k__BackingField;
        
        // Properties
        public bool IsCompleted { get; set; }
        public System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleLetterTile> getInputLetters { get; }
        public string correctAnswer { get; set; }
        public System.Action onLetterSubmitted { get; set; }
        public System.Action onWordComplete { get; set; }
        
        // Methods
        public bool get_IsCompleted()
        {
            return (bool)this.<IsCompleted>k__BackingField;
        }
        private void set_IsCompleted(bool value)
        {
            this.<IsCompleted>k__BackingField = value;
        }
        public System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleLetterTile> get_getInputLetters()
        {
            return (System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleLetterTile>)this.inputLetters;
        }
        public string get_correctAnswer()
        {
            return (string)this.<correctAnswer>k__BackingField;
        }
        private void set_correctAnswer(string value)
        {
            this.<correctAnswer>k__BackingField = value;
        }
        public System.Action get_onLetterSubmitted()
        {
            return (System.Action)this.<onLetterSubmitted>k__BackingField;
        }
        public void set_onLetterSubmitted(System.Action value)
        {
            this.<onLetterSubmitted>k__BackingField = value;
        }
        public System.Action get_onWordComplete()
        {
            return (System.Action)this.<onWordComplete>k__BackingField;
        }
        public void set_onWordComplete(System.Action value)
        {
            this.<onWordComplete>k__BackingField = value;
        }
        public void Init(string word, SLC.Minigames.WordJumble.WordJumbleAnswerLetter _answerLetter, SLC.Minigames.WordJumble.WordJumbleLetterTile _letterTile)
        {
            var val_8;
            SLC.Minigames.WordJumble.WordJumbleAnswerLetter val_9 = _answerLetter;
            this.<correctAnswer>k__BackingField = word;
            if(word.m_stringLength >= 1)
            {
                    do
            {
                SLC.Minigames.WordJumble.WordJumbleAnswerLetter val_2 = UnityEngine.Object.Instantiate<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>(original:  val_9 = _answerLetter, parent:  this.answerArea);
                val_2.Init(_wordAreaParent:  this);
                this.answerLetters.Add(item:  val_2);
                SLC.Minigames.WordJumble.WordJumbleLetterTile val_3 = UnityEngine.Object.Instantiate<SLC.Minigames.WordJumble.WordJumbleLetterTile>(original:  _letterTile, parent:  this.inputArea);
                val_3.Init(_wordAreaParent:  this, _letter:  word.Chars[0]);
                this.inputLetters.Add(item:  val_3);
                val_8 = 0 + 1;
            }
            while(val_8 < word.m_stringLength);
            
            }
            
            var val_8 = 0;
            do
            {
                if(val_8 >= this.inputArea.childCount)
            {
                    return;
            }
            
                val_9 = this.inputArea.GetChild(index:  0);
                val_9.SetSiblingIndex(index:  UnityEngine.Random.Range(min:  0, max:  this.inputArea.childCount));
                val_8 = val_8 + 1;
            }
            while(this.inputArea != null);
            
            throw new NullReferenceException();
        }
        public void LetterTileClicked(SLC.Minigames.WordJumble.WordJumbleLetterTile letterTile)
        {
            var val_5;
            System.Func<SLC.Minigames.WordJumble.WordJumbleAnswerLetter, System.Boolean> val_7;
            val_5 = null;
            val_5 = null;
            val_7 = WordJumbleWordArea.<>c.<>9__23_0;
            if(val_7 == null)
            {
                    System.Func<SLC.Minigames.WordJumble.WordJumbleAnswerLetter, System.Boolean> val_1 = null;
                val_7 = val_1;
                val_1 = new System.Func<SLC.Minigames.WordJumble.WordJumbleAnswerLetter, System.Boolean>(object:  WordJumbleWordArea.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordJumbleWordArea.<>c::<LetterTileClicked>b__23_0(SLC.Minigames.WordJumble.WordJumbleAnswerLetter x));
                WordJumbleWordArea.<>c.<>9__23_0 = val_7;
            }
            
            System.Linq.Enumerable.FirstOrDefault<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>(source:  System.Linq.Enumerable.Where<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>(source:  this.answerLetters, predicate:  val_1)).SetLetter(_letterTile:  letterTile, confirm:  false);
            if((this.<onLetterSubmitted>k__BackingField) != null)
            {
                    this.<onLetterSubmitted>k__BackingField.Invoke();
            }
            
            if(this.checkCanSubmit() == false)
            {
                    return;
            }
            
            this.SubmitWord();
        }
        public void AnswerLetterClicked(SLC.Minigames.WordJumble.WordJumbleAnswerLetter answerLetter)
        {
            this.ResetLetters(startIndex:  this.answerLetters.IndexOf(item:  answerLetter));
        }
        private void ResetLetters(int startIndex = 0)
        {
            var val_1;
            var val_2;
            val_1 = startIndex;
            val_2 = 33;
            do
            {
                if(val_1 >= true)
            {
                    return;
            }
            
                if(true <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                0.ResetLetter();
                val_1 = val_1 + 1;
                val_2 = val_2 + 8;
            }
            while(this.answerLetters != null);
            
            throw new NullReferenceException();
        }
        private bool checkCanSubmit()
        {
            var val_5;
            System.Func<SLC.Minigames.WordJumble.WordJumbleAnswerLetter, System.Boolean> val_7;
            val_5 = null;
            val_5 = null;
            val_7 = WordJumbleWordArea.<>c.<>9__26_0;
            if(val_7 != null)
            {
                    return (bool)((System.Linq.Enumerable.Count<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>(source:  System.Linq.Enumerable.Where<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>(source:  this.answerLetters, predicate:  System.Func<SLC.Minigames.WordJumble.WordJumbleAnswerLetter, System.Boolean> val_1 = null))) == 0) ? 1 : 0;
            }
            
            val_7 = val_1;
            val_1 = new System.Func<SLC.Minigames.WordJumble.WordJumbleAnswerLetter, System.Boolean>(object:  WordJumbleWordArea.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordJumbleWordArea.<>c::<checkCanSubmit>b__26_0(SLC.Minigames.WordJumble.WordJumbleAnswerLetter x));
            WordJumbleWordArea.<>c.<>9__26_0 = val_7;
            return (bool)((System.Linq.Enumerable.Count<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>(source:  System.Linq.Enumerable.Where<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>(source:  this.answerLetters, predicate:  val_1))) == 0) ? 1 : 0;
        }
        private void SubmitWord()
        {
            var val_3;
            var val_4;
            object val_8;
            System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
            List.Enumerator<T> val_2 = this.answerLetters.GetEnumerator();
            label_6:
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_3 + 40) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Text.StringBuilder val_6 = val_1.Append(value:  val_3 + 40 + 32);
            goto label_6;
            label_2:
            val_4.Dispose();
            if((System.String.op_Equality(a:  this.<correctAnswer>k__BackingField, b:  val_1)) != false)
            {
                    this.<IsCompleted>k__BackingField = true;
                if((this.<onWordComplete>k__BackingField) != null)
            {
                    this.<onWordComplete>k__BackingField.Invoke();
            }
            
                val_8 = "Correct Answer";
            }
            else
            {
                    val_8 = "Wrong Answer";
            }
            
            UnityEngine.Debug.LogError(message:  val_8);
        }
        public void Hint()
        {
            var val_12;
            System.Func<SLC.Minigames.WordJumble.WordJumbleAnswerLetter, System.Boolean> val_14;
            this.ResetLetters(startIndex:  0);
            val_12 = null;
            val_12 = null;
            val_14 = WordJumbleWordArea.<>c.<>9__28_0;
            if(val_14 == null)
            {
                    System.Func<SLC.Minigames.WordJumble.WordJumbleAnswerLetter, System.Boolean> val_2 = null;
                val_14 = val_2;
                val_2 = new System.Func<SLC.Minigames.WordJumble.WordJumbleAnswerLetter, System.Boolean>(object:  WordJumbleWordArea.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordJumbleWordArea.<>c::<Hint>b__28_0(SLC.Minigames.WordJumble.WordJumbleAnswerLetter x));
                WordJumbleWordArea.<>c.<>9__28_0 = val_14;
            }
            
            System.Collections.Generic.List<TSource> val_4 = System.Linq.Enumerable.ToList<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>(source:  System.Linq.Enumerable.Where<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>(source:  this.answerLetters, predicate:  val_2));
            var val_12 = null;
            UnityEngine.Debug.LogError(message:  "viable " + 1152921519779525792);
            int val_6 = UnityEngine.Random.Range(min:  0, max:  0);
            if(val_12 <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_12 = val_12 + (val_6 << 3);
            .answerChar = this.<correctAnswer>k__BackingField.Chars[this.answerLetters.IndexOf(item:  (null + (val_6) << 3) + 32)];
            SLC.Minigames.WordJumble.WordJumbleLetterTile val_10 = System.Linq.Enumerable.FirstOrDefault<SLC.Minigames.WordJumble.WordJumbleLetterTile>(source:  this.inputLetters, predicate:  new System.Func<SLC.Minigames.WordJumble.WordJumbleLetterTile, System.Boolean>(object:  new WordJumbleWordArea.<>c__DisplayClass28_0(), method:  System.Boolean WordJumbleWordArea.<>c__DisplayClass28_0::<Hint>b__1(SLC.Minigames.WordJumble.WordJumbleLetterTile x)));
            (null + (val_6) << 3) + 32.SetLetter(_letterTile:  val_10, confirm:  true);
            val_10.HideLetter();
            if(this.checkCanSubmit() == false)
            {
                    return;
            }
            
            this.SubmitWord();
        }
        public WordJumbleWordArea()
        {
            this.answerLetters = new System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleAnswerLetter>();
            this.inputLetters = new System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleLetterTile>();
        }
    
    }

}
