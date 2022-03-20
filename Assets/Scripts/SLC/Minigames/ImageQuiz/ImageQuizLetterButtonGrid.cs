using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizLetterButtonGrid : MonoBehaviour
    {
        // Fields
        private SLC.Minigames.ImageQuiz.ImageQuizLetterButton letterButtonPrefab;
        private UnityEngine.UI.GridLayoutGroup gridLayoutGroup;
        private UnityEngine.CanvasGroup buttonsCanvasGroup;
        private SLC.Minigames.ImageQuiz.ImageQuizLetterButton[] letterButtons;
        private int gridRowCount;
        private int gridColumnCount;
        private UnityEngine.Vector2 IdealCellSize;
        
        // Properties
        public SLC.Minigames.ImageQuiz.ImageQuizLetterButton[] LetterButtons { get; }
        
        // Methods
        public SLC.Minigames.ImageQuiz.ImageQuizLetterButton[] get_LetterButtons()
        {
            return (SLC.Minigames.ImageQuiz.ImageQuizLetterButton[])this.letterButtons;
        }
        public void Initialize(string letters)
        {
            string val_10;
            SLC.Minigames.ImageQuiz.ImageQuizLetterButton val_13;
            var val_14;
            if(this.gridLayoutGroup == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_1 = this.gridLayoutGroup.transform;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_10 = val_1.GetEnumerator();
            label_18:
            var val_11 = 0;
            val_11 = val_11 + 1;
            if(val_10.MoveNext() == false)
            {
                goto label_8;
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            object val_6 = val_10.Current;
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_6.gameObject);
            goto label_18;
            label_8:
            val_13 = 1152921504619679744;
            if(X0 == false)
            {
                goto label_19;
            }
            
            var val_15 = X0;
            val_10 = X0;
            if((X0 + 294) == 0)
            {
                goto label_23;
            }
            
            var val_13 = X0 + 176;
            var val_14 = 0;
            val_13 = val_13 + 8;
            label_22:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_21;
            }
            
            val_14 = val_14 + 1;
            val_13 = val_13 + 16;
            if(val_14 < (X0 + 294))
            {
                goto label_22;
            }
            
            goto label_23;
            label_21:
            val_15 = val_15 + (((X0 + 176 + 8)) << 4);
            val_14 = val_15 + 304;
            label_23:
            val_10.Dispose();
            label_19:
            if(0 != 0)
            {
                    throw X22;
            }
            
            if(letters == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Vector2 val_8 = val_10.GetInputGridSize(totalButtons:  letters.m_stringLength);
            val_8.y = (val_8.y == Infinityf) ? (-(double)val_8.y) : ((double)val_8.y);
            val_8.x = (val_8.x == Infinityf) ? (-(double)val_8.x) : ((double)val_8.x);
            this.InitializeObjects(_gridRowCount:  (int)val_8.y, _gridColCount:  (int)val_8.x);
            System.Collections.Generic.List<TSource> val_9 = System.Linq.Enumerable.ToList<System.Char>(source:  letters);
            PluginExtension.Shuffle<System.Char>(list:  val_9, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            if(this.letterButtons == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_17 = 0;
            do
            {
                if(val_17 >= this.letterButtons.Length)
            {
                    return;
            }
            
                if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_13 = this.letterButtons[val_17];
                if(this.letterButtons.Length <= val_17)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_10 = this.letterButtons[val_17][0].ToString();
                if(this.letterButtons[0x0][0].letterLabel == null)
            {
                    throw new NullReferenceException();
            }
            
                this.letterButtons[0x0][0]._letter = val_10;
                val_17 = val_17 + 1;
            }
            while(this.letterButtons != null);
            
            throw new NullReferenceException();
        }
        private void InitializeObjects(int _gridRowCount, int _gridColCount)
        {
            int val_22 = _gridRowCount;
            this.gridRowCount = val_22;
            this.gridColumnCount = _gridColCount;
            _gridRowCount = _gridColCount * val_22;
            this.letterButtons = new SLC.Minigames.ImageQuiz.ImageQuizLetterButton[0];
            this.gridLayoutGroup.constraint = 1;
            this.gridLayoutGroup.constraintCount = this.gridColumnCount;
            int val_24 = this.gridRowCount;
            val_24 = this.gridColumnCount * val_24;
            if(val_24 < 1)
            {
                goto label_3;
            }
            
            var val_29 = 4;
            label_42:
            object val_2 = val_29 - 4;
            System.Type[] val_4 = new System.Type[1];
            val_4[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            UnityEngine.GameObject val_6 = new UnityEngine.GameObject(name:  "Slot_" + val_2, components:  val_4);
            val_6.transform.SetParent(p:  this.gridLayoutGroup.transform);
            UnityEngine.Vector3 val_10 = UnityEngine.Vector3.one;
            val_6.transform.localScale = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
            UnityEngine.Vector3 val_12 = UnityEngine.Vector3.zero;
            val_6.transform.localPosition = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
            this.letterButtons[0] = UnityEngine.Object.Instantiate<SLC.Minigames.ImageQuiz.ImageQuizLetterButton>(original:  this.letterButtonPrefab, parent:  val_6.transform);
            this.letterButtons[0].name = this.letterButtonPrefab.name + "_" + val_2;
            val_22 = this.letterButtons[0].transform;
            val_22.SetParent(p:  val_6.transform);
            UnityEngine.Vector3 val_20 = UnityEngine.Vector3.one;
            this.letterButtons[0].transform.localScale = new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z};
            UnityEngine.Vector2 val_22 = UnityEngine.Vector2.zero;
            if(null != null)
            {
                goto label_41;
            }
            
            this.letterButtons[0].transform.anchoredPosition = new UnityEngine.Vector2() {x = val_22.x, y = val_22.y};
            int val_30 = this.gridRowCount;
            val_29 = val_29 + 1;
            val_30 = this.gridColumnCount * val_30;
            if((val_29 - 4) < val_30)
            {
                goto label_42;
            }
            
            label_3:
            this.OnRectTransformDimensionsChange();
            return;
            label_41:
        }
        protected void OnRectTransformDimensionsChange()
        {
            UnityEngine.Vector2 val_1 = this.DetermineCellSize();
            this.gridLayoutGroup.cellSize = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        }
        private UnityEngine.Vector2 DetermineCellSize()
        {
            UnityEngine.Vector2 val_13;
            float val_14;
            val_13 = this.IdealCellSize;
            UnityEngine.Transform val_1 = this.gridLayoutGroup.transform;
            if(null == null)
            {
                    UnityEngine.Rect val_2 = val_1.rect;
                float val_16 = val_2.m_XMin.width;
                int val_4 = val_2.m_XMin.left;
                UnityEngine.Rect val_6 = val_1.rect;
                float val_18 = val_6.m_XMin.height;
                int val_8 = val_6.m_XMin.top;
                float val_13 = (float)val_4;
                val_13 = val_16 - val_13;
                val_13 = val_13 - (float)val_4.right;
                float val_14 = (float)this.gridColumnCount - 1;
                val_14 = this.gridLayoutGroup.m_Spacing * val_14;
                float val_15 = (float)val_8;
                val_13 = val_13 - val_14;
                val_15 = val_18 - val_15;
                val_15 = val_15 - (float)val_8.bottom;
                val_16 = val_13 / (float)this.gridColumnCount;
                float val_17 = (float)this.gridRowCount - 1;
                val_17 = val_14 * val_17;
                val_17 = val_15 - val_17;
                val_18 = val_17 / (float)this.gridRowCount;
                if(val_16 >= 0)
            {
                    if(val_18 >= 0)
            {
                    return new UnityEngine.Vector2() {x = val_13, y = val_14};
            }
            
            }
            
                float val_12 = UnityEngine.Mathf.Min(a:  val_16, b:  val_18);
                val_13 = val_12;
                val_14 = val_12;
                return new UnityEngine.Vector2() {x = val_13, y = val_14};
            }
        
        }
        private UnityEngine.Vector2 GetInputGridSize(int totalButtons)
        {
            float val_3;
            if((totalButtons - 8) <= 13)
            {
                    var val_3 = 32559976 + ((totalButtons - 8)) << 2;
                val_3 = val_3 + 32559976;
            }
            else
            {
                    val_3 = 3f;
                UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  7f, y:  null);
                return new UnityEngine.Vector2() {x = val_2.x, y = val_2.y};
            }
        
        }
        public void SetVisible(bool state, bool isAnimated = False)
        {
            this.buttonsCanvasGroup.interactable = state;
            float val_2 = (state != true) ? 1f : 0f;
            if(isAnimated != false)
            {
                    DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.buttonsCanvasGroup, endValue:  val_2, duration:  0.3f);
                return;
            }
            
            this.buttonsCanvasGroup.alpha = val_2;
        }
        public SLC.Minigames.ImageQuiz.ImageQuizLetterButton GetButton(string letter, bool getOnlyUnusedButtons)
        {
            var val_4;
            SLC.Minigames.ImageQuiz.ImageQuizLetterButton val_5;
            val_4 = 4;
            label_12:
            if((val_4 - 4) >= this.letterButtons.Length)
            {
                goto label_1;
            }
            
            SLC.Minigames.ImageQuiz.ImageQuizLetterButton val_6 = this.letterButtons[0];
            if((System.String.op_Equality(a:  this.letterButtons[0]._letter.ToLowerInvariant(), b:  letter.ToLowerInvariant())) == false)
            {
                goto label_6;
            }
            
            if(getOnlyUnusedButtons == false)
            {
                goto label_7;
            }
            
            SLC.Minigames.ImageQuiz.ImageQuizLetterButton val_7 = this.letterButtons[0];
            if((this.letterButtons[0].<IsUsed>k__BackingField) == false)
            {
                goto label_11;
            }
            
            label_6:
            val_4 = val_4 + 1;
            if(this.letterButtons != null)
            {
                goto label_12;
            }
            
            throw new NullReferenceException();
            label_1:
            val_5 = 0;
            return val_5;
            label_7:
            label_11:
            var val_5 = val_4 - 4;
            val_5 = this.letterButtons[0];
            return val_5;
        }
        public ImageQuizLetterButtonGrid()
        {
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  175f, y:  175f);
            this.IdealCellSize = val_1.x;
        }
    
    }

}
