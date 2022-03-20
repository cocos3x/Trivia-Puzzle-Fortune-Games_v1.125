using UnityEngine;

namespace SRF.UI.Layout
{
    public class VirtualVerticalLayoutGroup : LayoutGroup, IPointerClickHandler, IEventSystemHandler
    {
        // Fields
        private readonly SRF.SRList<object> _itemList;
        private readonly SRF.SRList<int> _visibleItemList;
        private bool _isDirty;
        private SRF.SRList<SRF.UI.Layout.VirtualVerticalLayoutGroup.Row> _rowCache;
        private UnityEngine.UI.ScrollRect _scrollRect;
        private int _selectedIndex;
        private object _selectedItem;
        private SRF.UI.Layout.VirtualVerticalLayoutGroup.SelectedItemChangedEvent _selectedItemChanged;
        private int _visibleItemCount;
        private SRF.SRList<SRF.UI.Layout.VirtualVerticalLayoutGroup.Row> _visibleRows;
        public SRF.UI.StyleSheet AltRowStyleSheet;
        public bool EnableSelection;
        public UnityEngine.RectTransform ItemPrefab;
        public int RowPadding;
        public SRF.UI.StyleSheet RowStyleSheet;
        public SRF.UI.StyleSheet SelectedRowStyleSheet;
        public float Spacing;
        public bool StickToBottom;
        private float _itemHeight;
        
        // Properties
        public SRF.UI.Layout.VirtualVerticalLayoutGroup.SelectedItemChangedEvent SelectedItemChanged { get; set; }
        public object SelectedItem { get; set; }
        public override float minHeight { get; }
        private UnityEngine.UI.ScrollRect ScrollRect { get; }
        private bool AlignBottom { get; }
        private bool AlignTop { get; }
        private float ItemHeight { get; }
        
        // Methods
        public SRF.UI.Layout.VirtualVerticalLayoutGroup.SelectedItemChangedEvent get_SelectedItemChanged()
        {
            return (SelectedItemChangedEvent)this._selectedItemChanged;
        }
        public void set_SelectedItemChanged(SRF.UI.Layout.VirtualVerticalLayoutGroup.SelectedItemChangedEvent value)
        {
            this._selectedItemChanged = value;
        }
        public object get_SelectedItem()
        {
            return (object)this._selectedItem;
        }
        public void set_SelectedItem(object value)
        {
            if(this._selectedItem == value)
            {
                    return;
            }
            
            if(this.EnableSelection == false)
            {
                    return;
            }
            
            if(value == null)
            {
                goto label_3;
            }
            
            int val_1 = this._itemList.IndexOf(item:  value);
            if((val_1 & 2147483648) != 0)
            {
                    throw new System.InvalidOperationException(message:  "Cannot select item not present in layout");
            }
            
            if(this._selectedItem == null)
            {
                goto label_11;
            }
            
            label_10:
            this.InvalidateItem(itemIndex:  this._selectedIndex);
            label_11:
            this._selectedItem = value;
            this._selectedIndex = val_1;
            if(value != null)
            {
                    this.InvalidateItem(itemIndex:  val_1);
            }
            
            this.SetDirty();
            if(this.IsActive() != false)
            {
                    this._isDirty = true;
            }
            
            if(this._selectedItemChanged == null)
            {
                    return;
            }
            
            this._selectedItemChanged.Invoke(arg0:  this._selectedItem);
            return;
            label_3:
            if(this._selectedItem != null)
            {
                goto label_10;
            }
            
            goto label_11;
        }
        public override float get_minHeight()
        {
            float val_5 = this.Spacing;
            float val_4 = (float)W21;
            val_4 = this.ItemHeight * val_4;
            val_4 = val_4 + (float)this.top;
            val_4 = val_4 + (float)this._itemList.bottom;
            val_5 = val_5 * (float)S3;
            val_5 = val_4 + val_5;
            return (float)val_5;
        }
        public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
            object val_9;
            if(this.EnableSelection == false)
            {
                    return;
            }
            
            if((eventData.<pointerPressRaycast>k__BackingField) == 0)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_3 = eventData.<pointerPressRaycast>k__BackingField.transform.position;
            UnityEngine.Vector3 val_5 = this.rectTransform.InverseTransformPoint(position:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            float val_6 = this.ItemHeight;
            val_6 = System.Math.Abs(val_5.y) / val_6;
            int val_7 = UnityEngine.Mathf.FloorToInt(f:  val_6);
            if((val_7 & 2147483648) == 0)
            {
                    val_9 = this._itemList.Item[val_7];
            }
            else
            {
                    val_9 = 0;
            }
            
            this.SelectedItem = val_9;
        }
        protected override void Awake()
        {
            this.Awake();
            UnityEngine.UI.ScrollRect val_1 = this.ScrollRect;
            val_1.m_OnValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<UnityEngine.Vector2>(object:  this, method:  System.Void SRF.UI.Layout.VirtualVerticalLayoutGroup::OnScrollRectValueChanged(UnityEngine.Vector2 d)));
            if((this.ItemPrefab.GetComponent(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != 0)
            {
                    return;
            }
            
            UnityEngine.Debug.LogWarning(message:  "[VirtualVerticalLayoutGroup] ItemPrefab does not have a component inheriting from IVirtualView, so no data binding can occur");
        }
        private void OnScrollRectValueChanged(UnityEngine.Vector2 d)
        {
            if(d.y >= 0)
            {
                    if(d.y <= 1f)
            {
                goto label_2;
            }
            
            }
            
            this._scrollRect.verticalNormalizedPosition = UnityEngine.Mathf.Clamp01(value:  d.y);
            label_2:
            this.SetDirty();
            if(this.IsActive() == false)
            {
                    return;
            }
            
            this._isDirty = true;
        }
        protected override void Start()
        {
            this.Start();
            this.ScrollUpdate();
        }
        protected override void OnEnable()
        {
            this.OnEnable();
            this.SetDirty();
            if(this.IsActive() == false)
            {
                    return;
            }
            
            this._isDirty = true;
        }
        protected void Update()
        {
            if((true > 8) || ((0 & 455) != 0))
            {
                goto label_2;
            }
            
            label_9:
            if(this._selectedItem != null)
            {
                    if((this._itemList.Contains(item:  this._selectedItem)) != true)
            {
                    this.SelectedItem = 0;
            }
            
            }
            
            if(this._isDirty == false)
            {
                    return;
            }
            
            this._isDirty = false;
            this.ScrollUpdate();
            return;
            label_2:
            UnityEngine.Debug.LogWarning(message:  "[VirtualVerticalLayoutGroup] Only Lower or Upper alignment is supported.", context:  this);
            this.childAlignment = 0;
            goto label_9;
        }
        protected void InvalidateItem(int itemIndex)
        {
            var val_5;
            if((this._visibleItemList.Contains(item:  itemIndex)) == false)
            {
                    return;
            }
            
            bool val_2 = this._visibleItemList.Remove(item:  itemIndex);
            val_5 = 0;
            label_8:
            if(val_5 >= 1152921519476322272)
            {
                    return;
            }
            
            Row val_3 = this._visibleRows.Item[0];
            if(val_3.Index == itemIndex)
            {
                goto label_7;
            }
            
            val_5 = val_5 + 1;
            if(this._visibleRows != null)
            {
                goto label_8;
            }
            
            return;
            label_7:
            this.RecycleRow(row:  this._visibleRows.Item[0]);
            this._visibleRows.RemoveAt(index:  0);
        }
        protected void RefreshIndexCache()
        {
            var val_4 = 0;
            do
            {
                if(val_4 >= true)
            {
                    return;
            }
            
                Row val_1 = this._visibleRows.Item[0];
                Row val_2 = this._visibleRows.Item[0];
                val_1.Index = this._itemList.IndexOf(item:  val_2.Data);
                val_4 = val_4 + 1;
            }
            while(this._visibleRows != null);
            
            throw new NullReferenceException();
        }
        protected void ScrollUpdate()
        {
            var val_23;
            var val_24;
            SRF.SRList<Row> val_25;
            if(UnityEngine.Application.isPlaying == false)
            {
                    return;
            }
            
            UnityEngine.Vector2 val_3 = this.rectTransform.anchoredPosition;
            if(null != null)
            {
                goto label_5;
            }
            
            UnityEngine.Rect val_6 = this.ScrollRect.transform.rect;
            float val_8 = this.ItemHeight;
            val_8 = val_8 + this.Spacing;
            val_8 = val_3.y / val_8;
            float val_10 = this.ItemHeight;
            val_10 = val_10 + this.Spacing;
            val_10 = (val_3.y + val_6.m_XMin.height) / val_10;
            int val_14 = UnityEngine.Mathf.Max(a:  0, b:  (UnityEngine.Mathf.FloorToInt(f:  val_8)) - this.RowPadding);
            int val_24 = val_14;
            int val_16 = UnityEngine.Mathf.Min(a:  val_14, b:  this.RowPadding + (UnityEngine.Mathf.CeilToInt(f:  val_10)));
            val_23 = 1152921519476327392;
            val_24 = 0;
            var val_23 = 0;
            label_16:
            if(val_23 >= W9)
            {
                goto label_10;
            }
            
            Row val_17 = this._visibleRows.Item[0];
            if(val_17.Index >= val_24)
            {
                    if(val_17.Index <= val_16)
            {
                goto label_13;
            }
            
            }
            
            bool val_18 = this._visibleItemList.Remove(item:  val_17.Index);
            bool val_19 = this._visibleRows.Remove(item:  val_17);
            this.RecycleRow(row:  val_17);
            label_13:
            val_23 = val_23 + 1;
            if(this._visibleRows != null)
            {
                goto label_16;
            }
            
            label_10:
            if(val_24 >= val_16)
            {
                goto label_20;
            }
            
            val_23 = 1152921519476702944;
            label_25:
            if(val_24 >= this._itemList)
            {
                goto label_20;
            }
            
            if((this._visibleItemList.Contains(item:  val_24)) != true)
            {
                    this._visibleRows.Add(item:  this.GetRow(forIndex:  val_24));
                this._visibleItemList.Add(item:  val_24);
                val_24 = 1;
            }
            
            val_24 = val_24 + 1;
            if(val_24 < val_16)
            {
                goto label_25;
            }
            
            label_20:
            if((val_24 & 1) != 0)
            {
                goto label_26;
            }
            
            val_25 = this._visibleRows;
            if(this._visibleItemCount == W10)
            {
                goto label_28;
            }
            
            label_26:
            UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(rect:  this.rectTransform);
            val_25 = this._visibleRows;
            label_28:
            this._visibleItemCount = val_25;
            return;
            label_5:
        }
        public override void CalculateLayoutInputVertical()
        {
            this.SetLayoutInputForAxis(totalMin:  V0.16B, totalPreferred:  V0.16B, totalFlexible:  -1f, axis:  1);
        }
        public override void SetLayoutHorizontal()
        {
            UnityEngine.RectTransform val_10;
            UnityEngine.Rect val_2 = this.rectTransform.rect;
            float val_11 = val_2.m_XMin.width;
            val_10 = val_2.m_XMin.left;
            float val_10 = (float)val_10;
            val_10 = val_11 - val_10;
            var val_12 = 0;
            val_11 = val_10 - (float)true.right;
            label_8:
            if(val_12 >= W9)
            {
                goto label_5;
            }
            
            Row val_6 = this._visibleRows.Item[0];
            this.SetChildAlongAxis(rect:  val_6.Rect, axis:  0, pos:  (float)this._visibleRows.left, size:  val_11);
            val_12 = val_12 + 1;
            if(this._visibleRows != null)
            {
                goto label_8;
            }
            
            label_5:
            var val_14 = 0;
            do
            {
                if(val_14 >= this._visibleRows)
            {
                    return;
            }
            
                Row val_8 = this._rowCache.Item[0];
                val_10 = val_8.Rect;
                float val_13 = (float)this._visibleRows.left;
                val_13 = (-val_11) - val_13;
                this.SetChildAlongAxis(rect:  val_10, axis:  0, pos:  val_13, size:  val_11);
                val_14 = val_14 + 1;
            }
            while(this._rowCache != null);
            
            throw new NullReferenceException();
        }
        public override void SetLayoutVertical()
        {
            if(UnityEngine.Application.isPlaying == false)
            {
                    return;
            }
            
            var val_8 = 0;
            do
            {
                if(val_8 >= true)
            {
                    return;
            }
            
                Row val_2 = this._visibleRows.Item[0];
                float val_7 = (float)val_2.Index;
                val_7 = this.ItemHeight * val_7;
                val_7 = val_7 + (float)this.top;
                val_7 = val_7 + (this.Spacing * (float)val_2.Index);
                this.SetChildAlongAxis(rect:  val_2.Rect, axis:  1, pos:  val_7, size:  this.ItemHeight);
                val_8 = val_8 + 1;
            }
            while(this._visibleRows != null);
            
            throw new NullReferenceException();
        }
        private void SetDirty()
        {
            this.SetDirty();
            if(this.IsActive() == false)
            {
                    return;
            }
            
            this._isDirty = true;
        }
        public void AddItem(object item)
        {
            this._itemList.Add(item:  item);
            this.SetDirty();
            if(this.IsActive() != false)
            {
                    this._isDirty = true;
            }
            
            if(this.StickToBottom == false)
            {
                    return;
            }
            
            if((UnityEngine.Mathf.Approximately(a:  this.ScrollRect.verticalNormalizedPosition, b:  0f)) == false)
            {
                    return;
            }
            
            this = this.ScrollRect;
            UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  0f, y:  0f);
            this.normalizedPosition = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        }
        public void RemoveItem(object item)
        {
            if(this._selectedItem == item)
            {
                    this.SelectedItem = 0;
            }
            
            this.InvalidateItem(itemIndex:  this._itemList.IndexOf(item:  item));
            bool val_2 = this._itemList.Remove(item:  item);
            this.RefreshIndexCache();
            this.SetDirty();
            if(this.IsActive() == false)
            {
                    return;
            }
            
            this._isDirty = true;
        }
        public void ClearItems()
        {
            var val_3 = 0;
            if(>=0)
            {
                    label_5:
                Row val_1 = this._visibleRows.Item[0];
                this.InvalidateItem(itemIndex:  val_1.Index);
                val_3 = val_3 - 1;
                if(>=0)
            {
                    if(this._visibleRows != null)
            {
                goto label_5;
            }
            
            }
            
            }
            
            this._itemList.Clear();
            this.SetDirty();
            if(this.IsActive() == false)
            {
                    return;
            }
            
            this._isDirty = true;
        }
        private UnityEngine.UI.ScrollRect get_ScrollRect()
        {
            UnityEngine.UI.ScrollRect val_3;
            if(this._scrollRect == 0)
            {
                    this._scrollRect = this.GetComponentInParent<UnityEngine.UI.ScrollRect>();
                return val_3;
            }
            
            val_3 = this._scrollRect;
            return val_3;
        }
        private bool get_AlignBottom()
        {
            if(W8 != 8)
            {
                    return (bool)((W8 | 1) == 7) ? 1 : 0;
            }
            
            return true;
        }
        private bool get_AlignTop()
        {
            if(W8 == 0)
            {
                    return true;
            }
            
            return (bool)((W8 - 1) < 2) ? 1 : 0;
        }
        private float get_ItemHeight()
        {
            var val_7;
            if(this._itemHeight > 0f)
            {
                    return (float)this._itemHeight;
            }
            
            UnityEngine.Component val_2 = this.ItemPrefab.GetComponent(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
            if(X0 == false)
            {
                goto label_5;
            }
            
            var val_10 = X0;
            if((X0 + 294) == 0)
            {
                goto label_9;
            }
            
            var val_7 = X0 + 176;
            var val_8 = 0;
            val_7 = val_7 + 8;
            label_8:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_7;
            }
            
            val_8 = val_8 + 1;
            val_7 = val_7 + 16;
            if(val_8 < (X0 + 294))
            {
                goto label_8;
            }
            
            goto label_9;
            label_5:
            UnityEngine.Rect val_3 = this.ItemPrefab.rect;
            float val_4 = val_3.m_XMin.height;
            goto label_11;
            label_7:
            var val_9 = val_7;
            val_9 = val_9 + 6;
            val_10 = val_10 + val_9;
            val_7 = val_10 + 304;
            label_9:
            float val_5 = X0.preferredHeight;
            label_11:
            this._itemHeight = val_5;
            if((SRF.SRFFloatExtensions.ApproxZero(f:  val_5)) == false)
            {
                    return (float)this._itemHeight;
            }
            
            UnityEngine.Debug.LogWarning(message:  "[VirtualVerticalLayoutGroup] ItemPrefab must have a preferred size greater than 0");
            this._itemHeight = 10f;
            return (float)this._itemHeight;
        }
        private SRF.UI.Layout.VirtualVerticalLayoutGroup.Row GetRow(int forIndex)
        {
            Row val_10;
            if(this._rowCache == null)
            {
                goto label_2;
            }
            
            var val_2 = (forIndex < 0) ? (forIndex + 1) : forIndex;
            val_2 = val_2 & 4294967294;
            val_10 = 0;
            var val_10 = 0;
            label_8:
            if(val_10 >= val_2)
            {
                goto label_5;
            }
            
            Row val_4 = this._rowCache.Item[0];
            if(val_4.Data == this._itemList.Item[forIndex])
            {
                goto label_7;
            }
            
            int val_11 = val_4.Index;
            val_10 = val_10 + 1;
            var val_5 = (val_11 < 0) ? (val_11 + 1) : (val_11);
            val_5 = val_5 & 4294967294;
            val_11 = val_11 - val_5;
            var val_6 = (val_11 == (forIndex - val_2)) ? (val_4) : (val_10);
            if(this._rowCache != null)
            {
                goto label_8;
            }
            
            label_2:
            Row val_7 = this.CreateRow();
            goto label_10;
            label_5:
            if(val_10 == 0)
            {
                goto label_11;
            }
            
            bool val_8 = this._rowCache.Remove(item:  val_10);
            goto label_12;
            label_7:
            this._rowCache.RemoveAt(index:  0);
            this.PopulateRow(index:  forIndex, row:  val_4);
            val_10 = val_4;
            return val_10;
            label_11:
            label_10:
            val_10 = SRF.SRFIListExtensions.PopLast<Row>(list:  this._rowCache);
            label_12:
            this.PopulateRow(index:  forIndex, row:  val_10);
            return val_10;
        }
        private void RecycleRow(SRF.UI.Layout.VirtualVerticalLayoutGroup.Row row)
        {
            this._rowCache.Add(item:  row);
        }
        private void PopulateRow(int index, SRF.UI.Layout.VirtualVerticalLayoutGroup.Row row)
        {
            var val_9;
            row.Index = index;
            row.Data = this._itemList.Item[index];
            val_9 = public System.Object SRF.SRList<System.Object>::get_Item(int index);
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_9 = 0;
            row.View.SetDataContext(data:  this._itemList.Item[index]);
            if(this.RowStyleSheet == 0)
            {
                    if(this.AltRowStyleSheet == 0)
            {
                    if(this.SelectedRowStyleSheet == 0)
            {
                    return;
            }
            
            }
            
            }
            
            if(this.SelectedRowStyleSheet != 0)
            {
                    if(this._selectedItem == row.Data)
            {
                goto label_21;
            }
            
            }
            
            label_23:
            row.Root.StyleSheet = ((index & 1) != 0) ? (this.RowStyleSheet) : this.AltRowStyleSheet;
            return;
            label_21:
            if(row.Root != null)
            {
                goto label_23;
            }
            
            throw new NullReferenceException();
        }
        private SRF.UI.Layout.VirtualVerticalLayoutGroup.Row CreateRow()
        {
            UnityEngine.RectTransform val_2 = SRInstantiate.Instantiate<UnityEngine.RectTransform>(prefab:  this.ItemPrefab);
            .Rect = val_2;
            UnityEngine.Component val_4 = val_2.GetComponent(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
            .View = null;
            if(this.RowStyleSheet == 0)
            {
                    if(this.AltRowStyleSheet == 0)
            {
                    if(this.SelectedRowStyleSheet == 0)
            {
                goto label_13;
            }
            
            }
            
            }
            
            .Root = SRF.SRFGameObjectExtensions.GetComponentOrAdd<SRF.UI.StyleRoot>(obj:  val_2.gameObject);
            val_9.StyleSheet = this.RowStyleSheet;
            label_13:
            val_2.SetParent(parent:  this.rectTransform, worldPositionStays:  false);
            return (Row)new VirtualVerticalLayoutGroup.Row();
        }
        public VirtualVerticalLayoutGroup()
        {
            this._itemList = new SRF.SRList<System.Object>();
            this._visibleItemList = new SRF.SRList<System.Int32>();
            this._rowCache = new SRF.SRList<Row>();
            this._visibleRows = new SRF.SRList<Row>();
            this.EnableSelection = true;
            this.RowPadding = 2;
            this.StickToBottom = true;
            this._itemHeight = -1f;
        }
    
    }

}
