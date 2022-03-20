using UnityEngine;

namespace CrosswordCreator.Crossword
{
    public class CrosswordDisplay : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject text_prefab;
        private UnityEngine.UI.GridLayoutGroup this_grid;
        private UnityEngine.UI.Text percent_whitespace;
        private UnityEngine.UI.Text unused_words;
        
        // Methods
        public void Setup(CrosswordCreator.Crossword.Crossword _board, float pct_space, System.Collections.Generic.List<string> unusedWords)
        {
            string val_5;
            var val_6;
            var val_22;
            string val_23;
            UnityEngine.UI.Text val_24;
            var val_25;
            int val_26;
            var val_27;
            val_22 = unusedWords;
            val_23 = " empty";
            if(this.percent_whitespace == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23 = pct_space.ToString(format:  "#.#%")(pct_space.ToString(format:  "#.#%")) + val_23;
            val_24 = this.percent_whitespace;
            if(val_22 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = this.unused_words;
            if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_3 = (null > 0) ? "dropped words:" : "no dropped words";
            List.Enumerator<T> val_4 = val_22.GetEnumerator();
            val_25 = 1152921513250978752;
            label_6:
            if(val_6.MoveNext() == false)
            {
                goto label_4;
            }
            
            string val_8 = this.unused_words + " " + val_5;
            goto label_6;
            label_4:
            val_23 = public System.Void List.Enumerator<System.String>::Dispose();
            val_6.Dispose();
            val_24 = this.this_grid;
            if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23 = 1;
            val_24.constraint = val_23;
            if(_board == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = this.this_grid;
            if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24.constraintCount = _board.yWindow;
            val_26 = _board.yWindow;
            if(val_26 < 1)
            {
                    return;
            }
            
            val_25 = 1152921504765632512;
            val_27 = 0;
            do
            {
                if(_board.xWindow >= 1)
            {
                    val_23 = 0;
                do
            {
                char val_9 = _board.Item[0, 0];
                val_24 = this.this_grid;
                if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_22 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.text_prefab, parent:  val_24.transform);
                val_23 = ",";
                if(val_22 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_22.name = 0.ToString() + val_23 + 0.ToString();
                val_23 = 0;
                UnityEngine.Transform val_15 = val_22.transform;
                if(val_15 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_23 = 0;
                string val_17 = val_9.ToString();
                if((val_15.GetComponentInChildren<UnityEngine.UI.Text>()) == null)
            {
                    throw new NullReferenceException();
            }
            
                val_23 = 0;
                UnityEngine.Transform val_18 = val_22.transform;
                if(val_18 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_23 = public UnityEngine.UI.Image UnityEngine.Component::GetComponentInChildren<UnityEngine.UI.Image>();
                UnityEngine.UI.Image val_19 = val_18.GetComponentInChildren<UnityEngine.UI.Image>();
                if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_19.CrossFadeAlpha(alpha:  (val_9 == ' ') ? 0.5f : 1f, duration:  0f, ignoreTimeScale:  true);
                val_27 = 0;
            }
            while(1 < _board.xWindow);
            
                val_26 = _board.yWindow;
            }
            
                val_27 = val_27 + 1;
            }
            while(val_27 < val_26);
        
        }
        public CrosswordDisplay()
        {
        
        }
    
    }

}
