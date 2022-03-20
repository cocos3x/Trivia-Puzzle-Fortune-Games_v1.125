using UnityEngine;

namespace SRF.UI.Layout
{
    public class FlowLayoutGroup : LayoutGroup
    {
        // Fields
        private readonly System.Collections.Generic.IList<UnityEngine.RectTransform> _rowList;
        private float _layoutHeight;
        public bool ChildForceExpandHeight;
        public bool ChildForceExpandWidth;
        public float Spacing;
        
        // Properties
        protected bool IsCenterAlign { get; }
        protected bool IsRightAlign { get; }
        protected bool IsMiddleAlign { get; }
        protected bool IsLowerAlign { get; }
        
        // Methods
        protected bool get_IsCenterAlign()
        {
            if(W8 != 7)
            {
                    return (bool)((W8 == 4) ? 1 : 0) | ((W8 == 1) ? 1 : 0);
            }
            
            return true;
        }
        protected bool get_IsRightAlign()
        {
            if(W8 != 8)
            {
                    return (bool)((W8 == 5) ? 1 : 0) | ((W8 == 2) ? 1 : 0);
            }
            
            return true;
        }
        protected bool get_IsMiddleAlign()
        {
            if(W8 != 3)
            {
                    return (bool)((W8 | 1) == 5) ? 1 : 0;
            }
            
            return true;
        }
        protected bool get_IsLowerAlign()
        {
            if(W8 != 6)
            {
                    return (bool)((W8 - 7) < 2) ? 1 : 0;
            }
            
            return true;
        }
        public override void CalculateLayoutInputHorizontal()
        {
            this.CalculateLayoutInputHorizontal();
            float val_4 = (float)this.left;
            val_4 = this.GetGreatestMinimumChildWidth() + val_4;
            val_4 = val_4 + (float)X8.right;
            this.SetLayoutInputForAxis(totalMin:  val_4, totalPreferred:  -1f, totalFlexible:  -1f, axis:  0);
        }
        public override void SetLayoutHorizontal()
        {
            UnityEngine.Rect val_2 = this.rectTransform.rect;
            float val_4 = this.SetLayout(width:  val_2.m_XMin.width, axis:  0, layoutInput:  false);
        }
        public override void SetLayoutVertical()
        {
            UnityEngine.Rect val_2 = this.rectTransform.rect;
            float val_4 = this.SetLayout(width:  val_2.m_XMin.width, axis:  1, layoutInput:  false);
        }
        public override void CalculateLayoutInputVertical()
        {
            UnityEngine.Rect val_2 = this.rectTransform.rect;
            this._layoutHeight = this.SetLayout(width:  val_2.m_XMin.width, axis:  1, layoutInput:  true);
        }
        public float SetLayout(float width, int axis, bool layoutInput)
        {
            float val_35;
            float val_36;
            int val_37;
            float val_39;
            float val_42;
            UnityEngine.Rect val_2 = this.rectTransform.rect;
            float val_3 = val_2.m_XMin.height;
            UnityEngine.Rect val_5 = this.rectTransform.rect;
            var val_9 = W9 - 6;
            if(val_9 < 3)
            {
                    int val_10 = true.bottom;
            }
            else
            {
                    int val_11 = true.top;
            }
            
            float val_33 = (float)val_5.m_XMin.left;
            float val_34 = 0.5f;
            val_33 = val_5.m_XMin.width - val_33;
            val_34 = val_3 * val_34;
            var val_42 = 0;
            float val_40 = (float)val_11;
            val_35 = 0f;
            float val_12 = val_33 - (float)true.right;
            val_36 = 0f;
            label_35:
            var val_43 = X27 + 24;
            if(val_42 >= val_43)
            {
                goto label_9;
            }
            
            var val_15 = ((val_9 - 7) == 2) ? (val_43 + val_42) : (val_42);
            if(val_43 <= val_15)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_35 = X27 + 16;
            val_35 = val_35 + (val_15 << 3);
            val_37 = 0;
            float val_17 = UnityEngine.UI.LayoutUtility.GetPreferredSize(rect:  (X27 + 16 + (val_13 == 0x2 ? (X27 + 24 + 0) : 0) << 3) + 32, axis:  1);
            float val_18 = UnityEngine.Mathf.Min(a:  UnityEngine.UI.LayoutUtility.GetPreferredSize(rect:  (X27 + 16 + (val_13 == 0x2 ? (X27 + 24 + 0) : 0) << 3) + 32, axis:  0), b:  val_12);
            var val_36 = 0;
            val_36 = val_36 + 1;
            val_37 = 0;
            int val_20 = this._rowList.Count;
            if(val_20 >= 1)
            {
                    float val_37 = this.Spacing;
                val_35 = val_35 + val_37;
            }
            
            val_37 = val_18 + val_35;
            if(val_37 > val_12)
            {
                    if(layoutInput != true)
            {
                    if(1152921505682639146 <= 2)
            {
                    val_39 = (val_3 - val_40) - val_36;
            }
            else
            {
                    val_39 = val_40;
                if(1152921505682639149 <= 2)
            {
                    float val_38 = this._layoutHeight;
                val_38 = val_38 * (-0.5f);
                val_38 = val_34 + val_38;
                val_39 = val_40 + val_38;
            }
            
            }
            
                val_35 = val_35 - this.Spacing;
                val_37 = axis;
                this.LayoutRow(contents:  0, rowWidth:  val_35, rowHeight:  val_36, maxWidth:  val_12, xOffset:  (float)val_20.left, yOffset:  val_39, axis:  val_37);
            }
            
                var val_39 = 0;
                val_39 = val_39 + 1;
                val_37 = 3;
                this._rowList.Clear();
                val_36 = 0f;
                val_35 = 0f;
                val_40 = (val_36 + val_40) + this.Spacing;
            }
            
            var val_41 = 0;
            val_41 = val_41 + 1;
            val_37 = 2;
            val_35 = val_18 + val_35;
            this._rowList.Add(item:  val_5.m_XMin);
            var val_26 = (val_17 > val_36) ? (val_17) : (val_36);
            val_42 = val_42 + 1;
            if(X27 != 0)
            {
                goto label_35;
            }
            
            label_9:
            if(layoutInput != true)
            {
                    if((val_43 - 6) <= 2)
            {
                    val_42 = (val_3 - val_40) - val_36;
            }
            else
            {
                    val_43 = val_43 - 3;
                val_42 = val_40;
                if(val_43 <= 2)
            {
                    float val_44 = this._layoutHeight;
                val_44 = val_44 * (-0.5f);
                val_44 = val_34 + val_44;
                val_42 = val_40 + val_44;
            }
            
            }
            
                this.LayoutRow(contents:  0, rowWidth:  val_35, rowHeight:  val_36, maxWidth:  val_12, xOffset:  (float)val_11.left, yOffset:  val_42, axis:  axis);
            }
            
            var val_45 = 0;
            val_45 = val_45 + 1;
            this._rowList.Clear();
            val_36 = val_36 + val_40;
            if(1152921505682639482 < 3)
            {
                    int val_31 = this._rowList.top;
            }
            
            val_36 = val_36 + (float)this._rowList.bottom;
            if(axis != 1)
            {
                    return val_36;
            }
            
            if(layoutInput == false)
            {
                    return val_36;
            }
            
            this.SetLayoutInputForAxis(totalMin:  val_36, totalPreferred:  val_36, totalFlexible:  -1f, axis:  1);
            return val_36;
        }
        private float CalculateRowVerticalOffset(float groupHeight, float yOffset, float currentRowHeight)
        {
            var val_3;
            if((W8 - 6) <= 2)
            {
                    groupHeight = groupHeight - yOffset;
                val_3 = groupHeight - currentRowHeight;
                return (float)val_3;
            }
            
            if((W8 - 3) > 2)
            {
                    return (float)val_3;
            }
            
            float val_3 = this._layoutHeight;
            groupHeight = groupHeight * 0.5f;
            val_3 = val_3 * 0.5f;
            groupHeight = groupHeight - val_3;
            val_3 = groupHeight + yOffset;
            return (float)val_3;
        }
        protected void LayoutRow(System.Collections.Generic.IList<UnityEngine.RectTransform> contents, float rowWidth, float rowHeight, float maxWidth, float xOffset, float yOffset, int axis)
        {
            float val_18;
            float val_19;
            var val_20;
            var val_22;
            float val_24;
            float val_25;
            System.Collections.Generic.IList<UnityEngine.RectTransform> val_26;
            var val_27;
            var val_28;
            int val_30;
            float val_33;
            var val_34;
            UnityEngine.RectTransform val_35;
            val_18 = xOffset;
            val_19 = rowWidth;
            bool val_25 = this.ChildForceExpandWidth;
            if(val_25 == false)
            {
                goto label_1;
            }
            
            var val_23 = 0;
            var val_24 = 0;
            label_13:
            var val_21 = 0;
            val_21 = val_21 + 1;
            val_20 = 0;
            if(val_24 >= this._rowList.Count)
            {
                goto label_7;
            }
            
            var val_22 = 0;
            val_22 = val_22 + 1;
            val_22 = 0;
            val_23 = val_23 + (((UnityEngine.UI.LayoutUtility.GetFlexibleWidth(rect:  this._rowList.Item[0])) > 0f) ? 1 : 0);
            val_24 = val_24 + 1;
            if(this._rowList != null)
            {
                goto label_13;
            }
            
            label_7:
            if(val_23 < 1)
            {
                goto label_15;
            }
            
            val_24 = maxWidth - val_19;
            val_25 = val_24 / 0f;
            goto label_21;
            label_1:
            val_25 = 0f;
            if(val_25 > true)
            {
                goto label_21;
            }
            
            val_25 = 1 << val_25;
            if(val_25 != true)
            {
                goto label_18;
            }
            
            if((val_25 & true) != 0)
            {
                goto label_21;
            }
            
            val_24 = maxWidth - val_19;
            goto label_20;
            label_15:
            val_25 = 0f;
            goto label_21;
            label_18:
            rowWidth = maxWidth - val_19;
            val_24 = rowWidth * 0.5f;
            label_20:
            val_18 = val_24 + val_18;
            label_21:
            val_26 = this._rowList;
            val_27 = 0;
            do
            {
                var val_26 = 0;
                val_26 = val_26 + 1;
                val_28 = 0;
                if(val_27 >= val_26.Count)
            {
                    return;
            }
            
                val_30 = val_27;
                if(1152921505682639146 <= 2)
            {
                    var val_27 = 0;
                val_27 = val_27 + 1;
                val_28 = 0;
                val_30 = this._rowList.Count + val_27;
            }
            
                var val_28 = 0;
                val_28 = val_28 + 1;
                val_28 = 0;
                T val_12 = this._rowList.Item[val_30];
                float val_29 = UnityEngine.UI.LayoutUtility.GetPreferredSize(rect:  val_12, axis:  0);
                val_29 = ((UnityEngine.UI.LayoutUtility.GetFlexibleWidth(rect:  val_12)) > 0f) ? (val_25 + val_29) : (val_29);
                val_19 = UnityEngine.Mathf.Min(a:  val_29, b:  maxWidth);
                val_33 = (rowHeight - ((this.ChildForceExpandHeight == false) ? UnityEngine.UI.LayoutUtility.GetPreferredSize(rect:  val_12, axis:  1) : rowHeight)) * 0.5f;
                 =  + yOffset;
                if(axis != 0)
            {
                    val_34 = 1;
                val_35 = val_12;
            }
            else
            {
                    val_35 = val_12;
                val_34 = 0;
            }
            
                this.SetChildAlongAxis(rect:  val_35, axis:  0, pos:  val_18, size:  val_19);
                float val_30 = this.Spacing;
                val_26 = this._rowList;
                val_27 = val_27 + 1;
                val_30 = val_19 + val_30;
                val_18 = val_18 + val_30;
            }
            while(val_26 != null);
            
            throw new NullReferenceException();
        }
        public float GetGreatestMinimumChildWidth()
        {
            float val_3;
            var val_5 = 0;
            val_3 = 0f;
            do
            {
                var val_3 = X22 + 24;
                if(val_5 >= val_3)
            {
                    return (float)val_3;
            }
            
                val_3 = val_3 & 4294967295;
                if(val_5 >= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_4 = X22 + 16;
                val_4 = val_4 + 0;
                val_3 = UnityEngine.Mathf.Max(a:  UnityEngine.UI.LayoutUtility.GetMinWidth(rect:  (X22 + 16 + 0) + 32), b:  val_3);
                val_5 = val_5 + 1;
            }
            while(X22 != 0);
            
            throw new NullReferenceException();
        }
        public FlowLayoutGroup()
        {
            this._rowList = new System.Collections.Generic.List<UnityEngine.RectTransform>();
        }
    
    }

}
