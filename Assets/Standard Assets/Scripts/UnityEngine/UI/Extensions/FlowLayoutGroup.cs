using UnityEngine;

namespace UnityEngine.UI.Extensions
{
    public class FlowLayoutGroup : LayoutGroup
    {
        // Fields
        public float SpacingX;
        public float SpacingY;
        public bool ExpandHorizontalSpacing;
        public bool ChildForceExpandWidth;
        public bool ChildForceExpandHeight;
        private float _layoutHeight;
        private readonly System.Collections.Generic.IList<UnityEngine.RectTransform> _rowList;
        
        // Properties
        protected bool IsCenterAlign { get; }
        protected bool IsRightAlign { get; }
        protected bool IsMiddleAlign { get; }
        protected bool IsLowerAlign { get; }
        
        // Methods
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
        public float SetLayout(float width, int axis, bool layoutInput)
        {
            float val_38;
            System.Collections.Generic.IList<UnityEngine.RectTransform> val_40;
            float val_41;
            float val_42;
            float val_43;
            int val_44;
            float val_45;
            float val_46;
            float val_49;
            float val_50;
            UnityEngine.Rect val_2 = this.rectTransform.rect;
            val_38 = val_2.m_XMin.height;
            UnityEngine.Rect val_5 = this.rectTransform.rect;
            val_40 = true.right;
            var val_9 = W9 - 6;
            if(val_9 < 3)
            {
                    int val_10 = true.bottom;
            }
            
            var val_43 = X27 + 24;
            float val_36 = (float)val_5.m_XMin.left;
            val_36 = val_5.m_XMin.width - val_36;
            float val_12 = val_36 - (float)val_40;
            float val_37 = 0.5f;
            val_41 = (float)true.top;
            val_37 = val_38 * val_37;
            if(val_43 < 1)
            {
                goto label_9;
            }
            
            var val_42 = 0;
            val_42 = 0f;
            val_43 = 0f;
            do
            {
                var val_15 = ((val_9 - 7) == 2) ? (val_43 + val_42) : (val_42);
                if(val_43 <= val_15)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_38 = X27 + 16;
                val_38 = val_38 + (val_15 << 3);
                val_44 = 0;
                float val_17 = UnityEngine.UI.LayoutUtility.GetPreferredSize(rect:  (X27 + 16 + (val_13 == 0x2 ? (X27 + 24 + 0) : 0) << 3) + 32, axis:  1);
                float val_18 = UnityEngine.Mathf.Min(a:  UnityEngine.UI.LayoutUtility.GetPreferredSize(rect:  (X27 + 16 + (val_13 == 0x2 ? (X27 + 24 + 0) : 0) << 3) + 32, axis:  0), b:  val_12);
                val_45 = val_18;
                val_18 = val_43 + val_18;
                if(val_18 > val_12)
            {
                    if(layoutInput != true)
            {
                    val_46 = (val_38 - val_41) - val_42;
                val_43 = val_43 - this.SpacingX;
                val_44 = axis;
                this.LayoutRow(contents:  0, rowWidth:  val_43, rowHeight:  val_42, maxWidth:  val_12, xOffset:  (float)0.left, yOffset:  null, axis:  val_44);
            }
            
                var val_40 = 0;
                val_40 = val_40 + 1;
                val_44 = 3;
                this._rowList.Clear();
                val_42 = 0f;
                val_43 = 0f;
                val_41 = (val_42 + val_41) + this.SpacingY;
            }
            
                val_40 = this._rowList;
                var val_41 = 0;
                val_41 = val_41 + 1;
                val_44 = 2;
                val_40.Add(item:  val_5.m_XMin);
                var val_25 = (val_17 > val_42) ? (val_17) : (val_42);
                val_50 = val_45 + val_43;
                if(val_42 < ((X27 + 24) - 1))
            {
                    val_50 = val_50 + this.SpacingX;
            }
            
                val_42 = val_42 + 1;
            }
            while(val_42 < (X27 + 24));
            
            if(layoutInput == false)
            {
                goto label_32;
            }
            
            goto label_34;
            label_9:
            val_50 = 0f;
            val_49 = 0f;
            if(layoutInput == true)
            {
                goto label_34;
            }
            
            label_32:
            if((val_43 - 6) <= 2)
            {
                    val_38 = (val_38 - val_41) - val_49;
            }
            else
            {
                    val_43 = val_43 - 3;
                val_38 = val_41;
                if(val_43 <= 2)
            {
                    float val_44 = this._layoutHeight;
                val_44 = val_44 * (-0.5f);
                val_44 = val_37 + val_44;
                val_38 = val_41 + val_44;
            }
            
            }
            
            float val_46 = this.SpacingX;
            var val_45 = 0;
            val_45 = val_45 + 1;
            int val_30 = this._rowList.Count;
            val_45 = 0f;
            if(val_30 >= 2)
            {
                    val_45 = this.SpacingX;
            }
            
            val_46 = val_50 - val_46;
            this.LayoutRow(contents:  0, rowWidth:  val_46, rowHeight:  val_49, maxWidth:  val_12 - val_45, xOffset:  (float)val_30.left, yOffset:  val_38, axis:  axis);
            label_34:
            var val_47 = 0;
            val_47 = val_47 + 1;
            this._rowList.Clear();
            val_49 = val_49 + val_41;
            if(1152921505682639482 < 3)
            {
                    int val_34 = this._rowList.top;
            }
            
            val_49 = val_49 + (float)this._rowList.bottom;
            if(axis != 1)
            {
                    return val_49;
            }
            
            if(layoutInput == false)
            {
                    return val_49;
            }
            
            this.SetLayoutInputForAxis(totalMin:  val_49, totalPreferred:  val_49, totalFlexible:  -1f, axis:  1);
            return val_49;
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
            float val_24;
            var val_25;
            float val_27;
            int val_29;
            float val_32;
            var val_33;
            UnityEngine.RectTransform val_34;
            var val_36;
            var val_37;
            var val_38;
            var val_39;
            val_24 = xOffset;
            float val_33 = rowWidth;
            bool val_29 = this.ChildForceExpandWidth;
            if(val_29 == false)
            {
                goto label_1;
            }
            
            var val_28 = 0;
            val_28 = val_28 + 1;
            val_25 = 0;
            goto label_6;
            label_1:
            if(val_29 > true)
            {
                goto label_9;
            }
            
            val_29 = 1 << val_29;
            if(val_29 != true)
            {
                goto label_8;
            }
            
            if((val_29 & true) != 0)
            {
                goto label_9;
            }
            
            val_27 = maxWidth - val_33;
            goto label_10;
            label_6:
            rowWidth = maxWidth - val_33;
            label_43:
            label_69:
            var val_36 = 0;
            do
            {
                var val_30 = 0;
                val_30 = val_30 + 1;
                val_25 = 0;
                if(val_36 >= this._rowList.Count)
            {
                    return;
            }
            
                val_29 = val_36;
                if(1152921505682639146 <= 2)
            {
                    var val_31 = 0;
                val_31 = val_31 + 1;
                val_25 = 0;
                val_29 = this._rowList.Count + val_36;
            }
            
                var val_32 = 0;
                val_32 = val_32 + 1;
                val_25 = 0;
                T val_9 = this._rowList.Item[val_29];
                val_33 = (rowWidth / (float)this._rowList.Count) + (UnityEngine.UI.LayoutUtility.GetPreferredSize(rect:  val_9, axis:  0));
                float val_13 = UnityEngine.Mathf.Min(a:  val_33, b:  maxWidth);
                val_32 = (rowHeight - ((this.ChildForceExpandHeight == false) ? UnityEngine.UI.LayoutUtility.GetPreferredSize(rect:  val_9, axis:  1) : rowHeight)) * 0.5f;
                 =  + yOffset;
                val_24 = (this.ExpandHorizontalSpacing == false) ? (val_24) : (0f + val_24);
                if(axis != 0)
            {
                    val_33 = 1;
                val_34 = val_9;
            }
            else
            {
                    val_34 = val_9;
                val_33 = 0;
            }
            
                this.SetChildAlongAxis(rect:  val_34, axis:  0, pos:  val_24, size:  val_13);
                var val_34 = 0;
                val_34 = val_34 + 1;
                if(val_36 < (this._rowList.Count - 1))
            {
                    float val_35 = this.SpacingX;
                val_35 = val_13 + val_35;
                val_24 = val_24 + val_35;
            }
            
                val_36 = val_36 + 1;
            }
            while(this._rowList != null);
            
            return;
            label_8:
            rowWidth = maxWidth - val_33;
            val_27 = rowWidth * 0.5f;
            label_10:
            val_24 = val_27 + val_24;
            label_9:
            if(this.ExpandHorizontalSpacing == false)
            {
                goto label_43;
            }
            
            var val_39 = mem[this._rowList];
            if((mem[this._rowList] + 294) == 0)
            {
                goto label_48;
            }
            
            var val_37 = mem[this._rowList] + 176;
            var val_38 = 0;
            val_37 = val_37 + 8;
            label_47:
            if(((mem[this._rowList] + 176 + 8) + -8) == null)
            {
                goto label_46;
            }
            
            val_38 = val_38 + 1;
            val_37 = val_37 + 16;
            if(val_38 < (mem[this._rowList] + 294))
            {
                goto label_47;
            }
            
            goto label_48;
            label_46:
            val_39 = val_39 + (((mem[this._rowList] + 176 + 8)) << 4);
            val_36 = val_39 + 304;
            label_48:
            var val_42 = mem[this._rowList];
            val_33 = maxWidth - val_33;
            if((mem[this._rowList] + 294) == 0)
            {
                goto label_53;
            }
            
            var val_40 = mem[this._rowList] + 176;
            var val_41 = 0;
            val_40 = val_40 + 8;
            label_52:
            if(((mem[this._rowList] + 176 + 8) + -8) == null)
            {
                goto label_51;
            }
            
            val_41 = val_41 + 1;
            val_40 = val_40 + 16;
            if(val_41 < (mem[this._rowList] + 294))
            {
                goto label_52;
            }
            
            goto label_53;
            label_51:
            val_42 = val_42 + (((mem[this._rowList] + 176 + 8)) << 4);
            val_37 = val_42 + 304;
            label_53:
            float val_22 = val_33 / ((float)mem[this._rowList].Count - 1);
            if((mem[this._rowList].Count < 2) || ((public System.Int32 System.Collections.Generic.ICollection<T>::get_Count()) > 8))
            {
                goto label_69;
            }
            
            if(0 != 146)
            {
                goto label_56;
            }
            
            if((0 & 292) != 0)
            {
                goto label_69;
            }
            
            var val_47 = mem[this._rowList];
            if((mem[this._rowList] + 294) == 0)
            {
                goto label_62;
            }
            
            var val_43 = mem[this._rowList] + 176;
            var val_44 = 0;
            val_43 = val_43 + 8;
            label_61:
            if(((mem[this._rowList] + 176 + 8) + -8) == null)
            {
                goto label_60;
            }
            
            val_44 = val_44 + 1;
            val_43 = val_43 + 16;
            if(val_44 < (mem[this._rowList] + 294))
            {
                goto label_61;
            }
            
            goto label_62;
            label_56:
            var val_49 = mem[this._rowList];
            if((mem[this._rowList] + 294) == 0)
            {
                goto label_67;
            }
            
            var val_45 = mem[this._rowList] + 176;
            var val_46 = 0;
            val_45 = val_45 + 8;
            label_66:
            if(((mem[this._rowList] + 176 + 8) + -8) == null)
            {
                goto label_65;
            }
            
            val_46 = val_46 + 1;
            val_45 = val_45 + 16;
            if(val_46 < (mem[this._rowList] + 294))
            {
                goto label_66;
            }
            
            goto label_67;
            label_60:
            val_47 = val_47 + (((mem[this._rowList] + 176 + 8)) << 4);
            val_38 = val_47 + 304;
            label_62:
            float val_48 = (float)mem[this._rowList].Count - 1;
            val_48 = val_22 * val_48;
            val_24 = val_24 - val_48;
            goto label_69;
            label_65:
            val_49 = val_49 + (((mem[this._rowList] + 176 + 8)) << 4);
            val_39 = val_49 + 304;
            label_67:
            float val_50 = -0.5f;
            val_50 = val_22 * val_50;
            val_50 = val_50 * ((float)mem[this._rowList].Count - 1);
            val_24 = val_24 + val_50;
            goto label_69;
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
