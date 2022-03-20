using UnityEngine;

namespace UnityEngine.UI.Extensions
{
    public class TableLayoutGroup : LayoutGroup
    {
        // Fields
        protected UnityEngine.UI.Extensions.TableLayoutGroup.Corner startCorner;
        protected float[] columnWidths;
        protected float minimumRowHeight;
        protected bool flexibleRowHeight;
        protected float columnSpacing;
        protected float rowSpacing;
        private float[] preferredRowHeights;
        
        // Properties
        public UnityEngine.UI.Extensions.TableLayoutGroup.Corner StartCorner { get; set; }
        public float[] ColumnWidths { get; set; }
        public float MinimumRowHeight { get; set; }
        public bool FlexibleRowHeight { get; set; }
        public float ColumnSpacing { get; set; }
        public float RowSpacing { get; set; }
        
        // Methods
        public UnityEngine.UI.Extensions.TableLayoutGroup.Corner get_StartCorner()
        {
            return (Corner)this.startCorner;
        }
        public void set_StartCorner(UnityEngine.UI.Extensions.TableLayoutGroup.Corner value)
        {
            this.SetProperty<Corner>(currentValue: ref  this.startCorner, newValue:  value);
        }
        public float[] get_ColumnWidths()
        {
            return (System.Single[])this.columnWidths;
        }
        public void set_ColumnWidths(float[] value)
        {
            this.SetProperty<System.Single[]>(currentValue: ref  this.columnWidths, newValue:  value);
        }
        public float get_MinimumRowHeight()
        {
            return (float)this.minimumRowHeight;
        }
        public void set_MinimumRowHeight(float value)
        {
            this.SetProperty<System.Single>(currentValue: ref  this.minimumRowHeight, newValue:  value);
        }
        public bool get_FlexibleRowHeight()
        {
            return (bool)this.flexibleRowHeight;
        }
        public void set_FlexibleRowHeight(bool value)
        {
            this.SetProperty<System.Boolean>(currentValue: ref  this.flexibleRowHeight, newValue:  value);
        }
        public float get_ColumnSpacing()
        {
            return (float)this.columnSpacing;
        }
        public void set_ColumnSpacing(float value)
        {
            this.SetProperty<System.Single>(currentValue: ref  this.columnSpacing, newValue:  value);
        }
        public float get_RowSpacing()
        {
            return (float)this.rowSpacing;
        }
        public void set_RowSpacing(float value)
        {
            this.SetProperty<System.Single>(currentValue: ref  this.rowSpacing, newValue:  value);
        }
        public override void CalculateLayoutInputHorizontal()
        {
            float val_4;
            float val_5;
            this.CalculateLayoutInputHorizontal();
            val_4 = (float)this.horizontal;
            int val_2 = UnityEngine.Mathf.Min(a:  38021, b:  this.columnWidths.Length);
            if(val_2 > 0)
            {
                    var val_4 = 0;
                do
            {
                val_5 = this.columnSpacing;
                val_4 = val_4 + 1;
                val_4 = (val_4 + null) + val_5;
            }
            while(val_4 < (long)val_2);
            
            }
            else
            {
                    val_5 = this.columnSpacing;
            }
            
            val_5 = val_4 - val_5;
            this.SetLayoutInputForAxis(totalMin:  val_5, totalPreferred:  val_5, totalFlexible:  0f, axis:  0);
        }
        public override void CalculateLayoutInputVertical()
        {
            float val_12;
            float val_13;
            float val_14;
            float val_15;
            float val_16;
            var val_17;
            val_12 = ((float)X9 + 24) / (float)this.columnWidths.Length;
            int val_1 = UnityEngine.Mathf.CeilToInt(f:  val_12);
            this.preferredRowHeights = new float[0];
            val_13 = (float)vertical;
            val_14 = (float)vertical;
            if(val_1 >= 2)
            {
                    val_12 = this.rowSpacing * ((float)val_1 - 1);
                val_13 = val_12 + val_13;
                val_14 = val_12 + val_14;
            }
            
            if(this.flexibleRowHeight == false)
            {
                goto label_8;
            }
            
            if(val_1 < 1)
            {
                goto label_23;
            }
            
            var val_15 = 0;
            var val_14 = 0;
            label_22:
            val_15 = this.minimumRowHeight;
            if(this.columnWidths.Length < 1)
            {
                goto label_10;
            }
            
            var val_13 = 0;
            val_16 = val_15;
            label_18:
            val_17 = val_15 + val_13;
            if(val_17 == (X28 + 24))
            {
                goto label_19;
            }
            
            if((X28 + 24) <= val_17)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_11 = X28 + 16;
            val_11 = val_11 + (val_17 << 3);
            val_16 = UnityEngine.Mathf.Max(a:  UnityEngine.UI.LayoutUtility.GetPreferredHeight(rect:  (X28 + 16 + ((0 + 0)) << 3) + 32), b:  val_16);
            val_17 = (long)val_17;
            if((X28 + 24) <= val_17)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_12 = X28 + 16;
            val_12 = val_12 + (((long)(int)((0 + 0))) << 3);
            val_13 = val_13 + 1;
            val_15 = UnityEngine.Mathf.Max(a:  UnityEngine.UI.LayoutUtility.GetMinHeight(rect:  (X28 + 16 + ((long)(int)((0 + 0))) << 3) + 32), b:  val_15);
            if(val_13 < (long)this.columnWidths.Length)
            {
                goto label_18;
            }
            
            goto label_19;
            label_10:
            val_16 = val_15;
            label_19:
            val_14 = val_14 + 1;
            val_13 = val_13 + val_15;
            val_14 = val_14 + val_16;
            val_15 = val_15 + this.columnWidths.Length;
            this.preferredRowHeights[val_14] = val_16;
            if(val_14 < (long)val_1)
            {
                goto label_22;
            }
            
            goto label_23;
            label_8:
            if(val_1 >= 1)
            {
                    var val_16 = 0;
                do
            {
                val_16 = val_16 + 1;
                this.preferredRowHeights[val_16] = this.minimumRowHeight;
            }
            while(val_16 < (long)val_1);
            
            }
            
            float val_17 = this.minimumRowHeight;
            val_17 = val_17 * (float)val_1;
            val_14 = val_13 + val_17;
            val_13 = val_14;
            label_23:
            this.SetLayoutInputForAxis(totalMin:  val_13, totalPreferred:  UnityEngine.Mathf.Max(a:  val_13, b:  val_14), totalFlexible:  1f, axis:  1);
        }
        public override void SetLayoutHorizontal()
        {
            System.Single[] val_11;
            int val_12;
            float val_13;
            float val_14;
            float val_15;
            float val_16;
            var val_17;
            val_11 = this.columnWidths;
            if(this.columnWidths.Length == 0)
            {
                    float[] val_1 = new float[1];
                val_11 = val_1;
                this.columnWidths = val_1;
            }
            
            val_12 = val_1.Length;
            int val_3 = UnityEngine.Mathf.Min(a:  307773440, b:  null);
            if(val_3 > 0)
            {
                    var val_10 = 0;
                val_13 = this.columnSpacing;
                float val_11 = 0f;
                do
            {
                val_14 = mem[this.columnSpacing];
                val_14 = val_13;
                val_10 = val_10 + 1;
                val_11 = val_11 + null;
                val_15 = val_11 + val_14;
            }
            while(val_10 < (long)val_3);
            
            }
            else
            {
                    val_13 = this;
                val_14 = this.columnSpacing;
                val_15 = 0f;
            }
            
            val_16 = val_15 - val_14;
            Corner val_5 = this.startCorner - (((this.startCorner < 0) ? (this.startCorner + 1) : this.startCorner) & 4294967294);
            float val_6 = this.GetStartOffset(axis:  0, requiredSpaceWithoutPadding:  val_16);
            val_14 = val_6 + val_16;
            val_17 = 0;
            do
            {
                var val_13 = X25 + 24;
                if(val_17 >= val_13)
            {
                    return;
            }
            
                int val_9 = val_17 - ((val_17 / val_1.Length) * val_1.Length);
                val_16 = (val_9 == 0) ? ((val_5 == 1) ? (val_14) : (val_6)) : ((val_5 == 1) ? (val_14) : (val_6));
                if(val_5 == 1)
            {
                    val_16 = val_16 - this.columnWidths[val_9];
            }
            
                val_13 = val_13 & 4294967295;
                if(val_17 >= val_13)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_15 = X25 + 16;
                val_15 = val_15 + 0;
                this.SetChildAlongAxis(rect:  (X25 + 16 + 0) + 32, axis:  0, pos:  val_16, size:  this.columnWidths[(long)val_9]);
                if(val_5 == 1)
            {
                    float val_16 = this.columnSpacing;
                val_16 = val_16 - val_16;
            }
            else
            {
                    float val_17 = this.columnWidths[(long)val_9];
                val_17 = val_17 + this.columnSpacing;
                val_17 = val_16 + val_17;
            }
            
                val_17 = val_17 + 1;
            }
            while((long)val_9 != 0);
            
            throw new NullReferenceException();
        }
        public override void SetLayoutVertical()
        {
            int val_4;
            Corner val_5;
            float val_6;
            float val_7;
            val_4 = this.preferredRowHeights.Length;
            val_5 = this.startCorner;
            if(val_4 < 1)
            {
                goto label_3;
            }
            
            var val_5 = 0;
            do
            {
                val_5 = val_5 + 1;
                val_6 = 0f + null;
            }
            while(val_5 < (long)val_4);
            
            if(val_5 <= (long)val_4)
            {
                goto label_6;
            }
            
            float val_6 = this.rowSpacing;
            val_6 = val_6 * ((float)val_4 - 1);
            val_6 = val_6 + val_6;
            goto label_6;
            label_3:
            val_6 = 0f;
            label_6:
            float val_2 = this.GetStartOffset(axis:  1, requiredSpaceWithoutPadding:  val_6);
            if(val_4 < 1)
            {
                goto label_7;
            }
            
            val_5 = val_5 & 4294967294;
            var val_13 = 0;
            var val_12 = 0;
            val_6 = (val_5 == 2) ? (val_6 + val_2) : (val_2);
            val_4 = (long)val_4;
            label_22:
            if(val_5 == 2)
            {
                    val_7 = val_6 - this.preferredRowHeights[val_12];
            }
            
            if(this.columnWidths.Length < 1)
            {
                goto label_13;
            }
            
            var val_10 = 0;
            label_17:
            var val_4 = val_13 + val_10;
            if(val_4 == (X27 + 24))
            {
                goto label_13;
            }
            
            if((X27 + 24) <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_9 = X27 + 16;
            val_9 = val_9 + (val_4 << 3);
            this.SetChildAlongAxis(rect:  (X27 + 16 + ((0 + 0)) << 3) + 32, axis:  1, pos:  val_7, size:  this.preferredRowHeights[val_12]);
            val_10 = val_10 + 1;
            if(val_10 < (long)this.columnWidths.Length)
            {
                goto label_17;
            }
            
            label_13:
            if(val_5 == 2)
            {
                    val_7 = val_7 - this.rowSpacing;
            }
            else
            {
                    float val_11 = this.preferredRowHeights[val_12];
                val_11 = val_11 + this.rowSpacing;
                val_7 = val_7 + val_11;
            }
            
            val_12 = val_12 + 1;
            val_13 = val_13 + this.columnWidths.Length;
            if(val_12 < val_4)
            {
                goto label_22;
            }
            
            label_7:
            this.preferredRowHeights = 0;
        }
        public TableLayoutGroup()
        {
            float[] val_1 = new float[1];
            val_1[0] = 96f;
            this.columnWidths = val_1;
            this.minimumRowHeight = 32f;
            this.flexibleRowHeight = true;
        }
    
    }

}
