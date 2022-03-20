using UnityEngine;

namespace UnityEngine.UI
{
    public abstract class LoopScrollRect : UIBehaviour, IInitializePotentialDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IScrollHandler, ICanvasElement, ILayoutElement, ILayoutGroup, ILayoutController
    {
        // Fields
        public UnityEngine.UI.LoopScrollPrefabSource prefabSource;
        public int totalCount;
        public UnityEngine.UI.LoopScrollDataSource dataSource;
        protected float threshold;
        public bool reverseDirection;
        public float rubberScale;
        protected int itemTypeStart;
        protected int itemTypeEnd;
        protected int directionSign;
        private float m_ContentSpacing;
        protected UnityEngine.UI.GridLayoutGroup m_GridLayout;
        private int m_ContentConstraintCount;
        private UnityEngine.RectTransform m_Content;
        private bool m_Horizontal;
        private bool m_Vertical;
        private UnityEngine.UI.LoopScrollRect.MovementType m_MovementType;
        private float m_Elasticity;
        private bool m_Inertia;
        private float m_DecelerationRate;
        private float m_ScrollSensitivity;
        private UnityEngine.RectTransform m_Viewport;
        private UnityEngine.UI.Scrollbar m_HorizontalScrollbar;
        private UnityEngine.UI.Scrollbar m_VerticalScrollbar;
        private UnityEngine.UI.LoopScrollRect.ScrollbarVisibility m_HorizontalScrollbarVisibility;
        private UnityEngine.UI.LoopScrollRect.ScrollbarVisibility m_VerticalScrollbarVisibility;
        private float m_HorizontalScrollbarSpacing;
        private float m_VerticalScrollbarSpacing;
        private UnityEngine.UI.LoopScrollRect.ScrollRectEvent m_OnValueChanged;
        private UnityEngine.Vector2 m_PointerStartLocalCursor;
        private UnityEngine.Vector2 m_ContentStartPosition;
        private UnityEngine.RectTransform m_ViewRect;
        private UnityEngine.Bounds m_ContentBounds;
        private UnityEngine.Bounds m_ViewBounds;
        private UnityEngine.Vector2 m_Velocity;
        private bool m_Dragging;
        private UnityEngine.Vector2 m_PrevPosition;
        private UnityEngine.Bounds m_PrevContentBounds;
        private UnityEngine.Bounds m_PrevViewBounds;
        private bool m_HasRebuiltLayout;
        private bool m_HSliderExpand;
        private bool m_VSliderExpand;
        private float m_HSliderHeight;
        private float m_VSliderWidth;
        private UnityEngine.RectTransform m_Rect;
        private UnityEngine.RectTransform m_HorizontalScrollbarRect;
        private UnityEngine.RectTransform m_VerticalScrollbarRect;
        private UnityEngine.DrivenRectTransformTracker m_Tracker;
        private float <flexibleWidth>k__BackingField;
        private readonly UnityEngine.Vector3[] m_Corners;
        
        // Properties
        set; }
        protected float contentSpacing { get; }
        protected int contentConstraintCount { get; }
        private int StartLine { get; }
        private int CurrentLines { get; }
        private int TotalLines { get; }
        public UnityEngine.RectTransform content { get; set; }
        public bool horizontal { get; set; }
        public bool vertical { get; set; }
        public UnityEngine.UI.LoopScrollRect.MovementType movementType { get; set; }
        public float elasticity { get; set; }
        public bool inertia { get; set; }
        public float decelerationRate { get; set; }
        public float scrollSensitivity { get; set; }
        public UnityEngine.RectTransform viewport { get; set; }
        public UnityEngine.UI.Scrollbar horizontalScrollbar { get; set; }
        public UnityEngine.UI.Scrollbar verticalScrollbar { get; set; }
        public UnityEngine.UI.LoopScrollRect.ScrollbarVisibility horizontalScrollbarVisibility { get; set; }
        public UnityEngine.UI.LoopScrollRect.ScrollbarVisibility verticalScrollbarVisibility { get; set; }
        public float horizontalScrollbarSpacing { get; set; }
        public float verticalScrollbarSpacing { get; set; }
        public UnityEngine.UI.LoopScrollRect.ScrollRectEvent onValueChanged { get; set; }
        protected UnityEngine.RectTransform viewRect { get; }
        public UnityEngine.Vector2 velocity { get; set; }
        private UnityEngine.RectTransform rectTransform { get; }
        public UnityEngine.Vector2 normalizedPosition { get; set; }
        public float horizontalNormalizedPosition { get; set; }
        public float verticalNormalizedPosition { get; set; }
        private bool hScrollingNeeded { get; }
        private bool vScrollingNeeded { get; }
        public virtual float minWidth { get; }
        public virtual float preferredWidth { get; }
        public virtual float flexibleWidth { get; set; }
        public virtual float minHeight { get; }
        public virtual float preferredHeight { get; }
        public virtual float flexibleHeight { get; }
        public virtual int layoutPriority { get; }
        
        // Methods
        public void set_objectsToFill(object[] value)
        {
            var val_2;
            if(value != null)
            {
                    this.dataSource = new UnityEngine.UI.LoopScrollArraySource<System.Object>(objectsToFill:  value);
                return;
            }
            
            val_2 = null;
            val_2 = null;
            this.dataSource = UnityEngine.UI.LoopScrollSendIndexSource.Instance;
        }
        protected abstract float GetSize(UnityEngine.RectTransform item); // 0
        protected abstract float GetDimension(UnityEngine.Vector2 vector); // 0
        protected abstract UnityEngine.Vector2 GetVector(float value); // 0
        protected float get_contentSpacing()
        {
            if(this.m_ContentSpacing >= 0f)
            {
                    return (float)this.m_ContentSpacing;
            }
            
            this.m_ContentSpacing = 0f;
            if(this.m_Content == 0)
            {
                    return (float)this.m_ContentSpacing;
            }
            
            if((this.m_Content.GetComponent<UnityEngine.UI.HorizontalOrVerticalLayoutGroup>()) != 0)
            {
                    this.m_ContentSpacing = val_2.m_Spacing;
            }
            
            UnityEngine.UI.GridLayoutGroup val_4 = this.m_Content.GetComponent<UnityEngine.UI.GridLayoutGroup>();
            this.m_GridLayout = val_4;
            if(val_4 == 0)
            {
                    return (float)this.m_ContentSpacing;
            }
            
            this.m_ContentSpacing = System.Math.Abs(this.m_GridLayout.m_Spacing);
            return (float)this.m_ContentSpacing;
        }
        protected int get_contentConstraintCount()
        {
            int val_4 = this.m_ContentConstraintCount;
            if(val_4 > 0)
            {
                    return val_4;
            }
            
            this.m_ContentConstraintCount = 1;
            if((this.m_Content != 0) && ((this.m_Content.GetComponent<UnityEngine.UI.GridLayoutGroup>()) != 0))
            {
                    if(val_2.m_Constraint == 0)
            {
                    UnityEngine.Debug.LogWarning(message:  "[LoopScrollRect] Flexible not supported yet");
            }
            
                this.m_ContentConstraintCount = val_2.m_ConstraintCount;
            }
            
            val_4 = this.m_ContentConstraintCount;
            return val_4;
        }
        private int get_StartLine()
        {
            float val_2 = (float)this.itemTypeStart;
            val_2 = val_2 / (float)this.contentConstraintCount;
            return UnityEngine.Mathf.CeilToInt(f:  val_2);
        }
        private int get_CurrentLines()
        {
            float val_3 = (float)this.itemTypeEnd - this.itemTypeStart;
            val_3 = val_3 / (float)this.contentConstraintCount;
            return UnityEngine.Mathf.CeilToInt(f:  val_3);
        }
        private int get_TotalLines()
        {
            float val_2 = (float)this.totalCount;
            val_2 = val_2 / (float)this.contentConstraintCount;
            return UnityEngine.Mathf.CeilToInt(f:  val_2);
        }
        protected virtual bool UpdateItems(UnityEngine.Bounds viewBounds, UnityEngine.Bounds contentBounds)
        {
            return false;
        }
        public UnityEngine.RectTransform get_content()
        {
            return (UnityEngine.RectTransform)this.m_Content;
        }
        public void set_content(UnityEngine.RectTransform value)
        {
            this.m_Content = value;
        }
        public bool get_horizontal()
        {
            return (bool)this.m_Horizontal;
        }
        public void set_horizontal(bool value)
        {
            this.m_Horizontal = value;
        }
        public bool get_vertical()
        {
            return (bool)this.m_Vertical;
        }
        public void set_vertical(bool value)
        {
            this.m_Vertical = value;
        }
        public UnityEngine.UI.LoopScrollRect.MovementType get_movementType()
        {
            return (MovementType)this.m_MovementType;
        }
        public void set_movementType(UnityEngine.UI.LoopScrollRect.MovementType value)
        {
            this.m_MovementType = value;
        }
        public float get_elasticity()
        {
            return (float)this.m_Elasticity;
        }
        public void set_elasticity(float value)
        {
            this.m_Elasticity = value;
        }
        public bool get_inertia()
        {
            return (bool)this.m_Inertia;
        }
        public void set_inertia(bool value)
        {
            this.m_Inertia = value;
        }
        public float get_decelerationRate()
        {
            return (float)this.m_DecelerationRate;
        }
        public void set_decelerationRate(float value)
        {
            this.m_DecelerationRate = value;
        }
        public float get_scrollSensitivity()
        {
            return (float)this.m_ScrollSensitivity;
        }
        public void set_scrollSensitivity(float value)
        {
            this.m_ScrollSensitivity = value;
        }
        public UnityEngine.RectTransform get_viewport()
        {
            return (UnityEngine.RectTransform)this.m_Viewport;
        }
        public void set_viewport(UnityEngine.RectTransform value)
        {
            this.m_Viewport = value;
            this.SetDirtyCaching();
        }
        public UnityEngine.UI.Scrollbar get_horizontalScrollbar()
        {
            return (UnityEngine.UI.Scrollbar)this.m_HorizontalScrollbar;
        }
        public void set_horizontalScrollbar(UnityEngine.UI.Scrollbar value)
        {
            UnityEngine.UI.Scrollbar val_5 = this.m_HorizontalScrollbar;
            if((UnityEngine.Object.op_Implicit(exists:  val_5 = this.m_HorizontalScrollbar)) != false)
            {
                    val_5 = this.m_HorizontalScrollbar.m_OnValueChanged;
                val_5.RemoveListener(call:  new UnityEngine.Events.UnityAction<System.Single>(object:  this, method:  System.Void UnityEngine.UI.LoopScrollRect::SetHorizontalNormalizedPosition(float value)));
            }
            
            this.m_HorizontalScrollbar = value;
            if((UnityEngine.Object.op_Implicit(exists:  value)) != false)
            {
                    UnityEngine.Events.UnityAction<System.Single> val_4 = null;
                val_5 = val_4;
                val_4 = new UnityEngine.Events.UnityAction<System.Single>(object:  this, method:  System.Void UnityEngine.UI.LoopScrollRect::SetHorizontalNormalizedPosition(float value));
                this.m_HorizontalScrollbar.m_OnValueChanged.AddListener(call:  val_4);
            }
            
            this.SetDirtyCaching();
        }
        public UnityEngine.UI.Scrollbar get_verticalScrollbar()
        {
            return (UnityEngine.UI.Scrollbar)this.m_VerticalScrollbar;
        }
        public void set_verticalScrollbar(UnityEngine.UI.Scrollbar value)
        {
            UnityEngine.UI.Scrollbar val_5 = this.m_VerticalScrollbar;
            if((UnityEngine.Object.op_Implicit(exists:  val_5 = this.m_VerticalScrollbar)) != false)
            {
                    val_5 = this.m_VerticalScrollbar.m_OnValueChanged;
                val_5.RemoveListener(call:  new UnityEngine.Events.UnityAction<System.Single>(object:  this, method:  System.Void UnityEngine.UI.LoopScrollRect::SetVerticalNormalizedPosition(float value)));
            }
            
            this.m_VerticalScrollbar = value;
            if((UnityEngine.Object.op_Implicit(exists:  value)) != false)
            {
                    UnityEngine.Events.UnityAction<System.Single> val_4 = null;
                val_5 = val_4;
                val_4 = new UnityEngine.Events.UnityAction<System.Single>(object:  this, method:  System.Void UnityEngine.UI.LoopScrollRect::SetVerticalNormalizedPosition(float value));
                this.m_VerticalScrollbar.m_OnValueChanged.AddListener(call:  val_4);
            }
            
            this.SetDirtyCaching();
        }
        public UnityEngine.UI.LoopScrollRect.ScrollbarVisibility get_horizontalScrollbarVisibility()
        {
            return (ScrollbarVisibility)this.m_HorizontalScrollbarVisibility;
        }
        public void set_horizontalScrollbarVisibility(UnityEngine.UI.LoopScrollRect.ScrollbarVisibility value)
        {
            this.m_HorizontalScrollbarVisibility = value;
            this.SetDirtyCaching();
        }
        public UnityEngine.UI.LoopScrollRect.ScrollbarVisibility get_verticalScrollbarVisibility()
        {
            return (ScrollbarVisibility)this.m_VerticalScrollbarVisibility;
        }
        public void set_verticalScrollbarVisibility(UnityEngine.UI.LoopScrollRect.ScrollbarVisibility value)
        {
            this.m_VerticalScrollbarVisibility = value;
            this.SetDirtyCaching();
        }
        public float get_horizontalScrollbarSpacing()
        {
            return (float)this.m_HorizontalScrollbarSpacing;
        }
        public void set_horizontalScrollbarSpacing(float value)
        {
            this.m_HorizontalScrollbarSpacing = value;
            this.SetDirty();
        }
        public float get_verticalScrollbarSpacing()
        {
            return (float)this.m_VerticalScrollbarSpacing;
        }
        public void set_verticalScrollbarSpacing(float value)
        {
            this.m_VerticalScrollbarSpacing = value;
            this.SetDirty();
        }
        public UnityEngine.UI.LoopScrollRect.ScrollRectEvent get_onValueChanged()
        {
            return (ScrollRectEvent)this.m_OnValueChanged;
        }
        public void set_onValueChanged(UnityEngine.UI.LoopScrollRect.ScrollRectEvent value)
        {
            this.m_OnValueChanged = value;
        }
        protected UnityEngine.RectTransform get_viewRect()
        {
            UnityEngine.RectTransform val_4;
            UnityEngine.RectTransform val_5;
            if(this.m_ViewRect == 0)
            {
                    val_4 = this.m_Viewport;
                this.m_ViewRect = val_4;
            }
            else
            {
                    val_4 = this.m_ViewRect;
            }
            
            if(val_4 == 0)
            {
                    UnityEngine.Transform val_3 = this.transform;
                if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_9;
            }
            
            }
            
                this.m_ViewRect = val_3;
                return val_5;
            }
            
            val_5 = this.m_ViewRect;
            return val_5;
            label_9:
        }
        public UnityEngine.Vector2 get_velocity()
        {
            return new UnityEngine.Vector2() {x = this.m_Velocity};
        }
        public void set_velocity(UnityEngine.Vector2 value)
        {
            this.m_Velocity = value;
            mem[1152921520067831308] = value.y;
        }
        private UnityEngine.RectTransform get_rectTransform()
        {
            UnityEngine.RectTransform val_3;
            if(this.m_Rect == 0)
            {
                    this.m_Rect = this.GetComponent<UnityEngine.RectTransform>();
                return val_3;
            }
            
            val_3 = this.m_Rect;
            return val_3;
        }
        protected LoopScrollRect()
        {
            null = null;
            this.rubberScale = 1f;
            this.m_Horizontal = true;
            this.m_Vertical = true;
            this.m_MovementType = 1;
            this.m_Inertia = true;
            this.m_ContentSpacing = -1f;
            this.m_DecelerationRate = 0.135f;
            this.m_ScrollSensitivity = 1f;
            this.dataSource = UnityEngine.UI.LoopScrollSendIndexSource.Instance;
            this.m_OnValueChanged = new LoopScrollRect.ScrollRectEvent();
            UnityEngine.Vector2 val_2 = UnityEngine.Vector2.zero;
            this.m_PointerStartLocalCursor = val_2;
            mem[1152921520068088036] = val_2.y;
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
            this.m_ContentStartPosition = val_3;
            mem[1152921520068088044] = val_3.y;
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.zero;
            this.m_PrevPosition = val_4;
            mem[1152921520068088120] = val_4.y;
            this.m_Corners = new UnityEngine.Vector3[4];
            this.<flexibleWidth>k__BackingField = -1f;
        }
        public void ClearCells()
        {
            if(UnityEngine.Application.isPlaying == false)
            {
                    return;
            }
            
            this.itemTypeStart = 0;
            this.itemTypeEnd = 0;
            this.totalCount = 0;
            this.objectsToFill = 0;
            int val_3 = this.m_Content.childCount - 1;
            if(<0)
            {
                    return;
            }
            
            do
            {
                UnityEngine.Transform val_4 = this.m_Content.GetChild(index:  val_3);
                val_3 = val_3 - 1;
            }
            while(>=0);
        
        }
        public void ScrollToCell(int index, float speed)
        {
            System.Object[] val_5;
            string val_6;
            if((this.totalCount & 2147483648) == 0)
            {
                    if(((index & 2147483648) != 0) || (this.totalCount <= index))
            {
                goto label_3;
            }
            
            }
            
            if(speed > 0f)
            {
                    this.StopAllCoroutines();
                UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.ScrollToCellCoroutine(index:  index, speed:  speed));
                return;
            }
            
            val_5 = new object[1];
            val_5[0] = speed;
            val_6 = "invalid speed {0}";
            goto label_11;
            label_3:
            object[] val_4 = new object[1];
            val_5 = val_4;
            val_5[0] = index;
            val_6 = "invalid index {0}";
            label_11:
            UnityEngine.Debug.LogWarningFormat(format:  val_6, args:  val_4);
        }
        private System.Collections.IEnumerator ScrollToCellCoroutine(int index, float speed)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .index = index;
            .speed = speed;
            return (System.Collections.IEnumerator)new LoopScrollRect.<ScrollToCellCoroutine>d__124();
        }
        public void RefreshCells()
        {
            var val_6;
            if(UnityEngine.Application.isPlaying == false)
            {
                    return;
            }
            
            if(this.isActiveAndEnabled == false)
            {
                    return;
            }
            
            this.itemTypeEnd = this.itemTypeStart;
            val_6 = 0;
            do
            {
                if(val_6 >= this.m_Content.childCount)
            {
                    return;
            }
            
                if(this.itemTypeEnd < this.totalCount)
            {
                    UnityEngine.Transform val_4 = this.m_Content.GetChild(index:  0);
                int val_6 = this.itemTypeEnd;
                val_6 = val_6 + 1;
                this.itemTypeEnd = val_6;
            }
            else
            {
                    UnityEngine.Transform val_5 = this.m_Content.GetChild(index:  0);
                val_6 = val_6 - 1;
            }
            
                val_6 = val_6 + 1;
            }
            while(this.m_Content != null);
            
            throw new NullReferenceException();
        }
        public void RefillCellsFromEnd(int offset = 0)
        {
            int val_16;
            float val_17;
            float val_18;
            float val_19;
            val_16 = offset;
            if(UnityEngine.Application.isPlaying == false)
            {
                    return;
            }
            
            if(this.prefabSource == null)
            {
                    return;
            }
            
            if(this.reverseDirection != true)
            {
                    val_16 = this.totalCount - val_16;
            }
            
            this.itemTypeStart = val_16;
            this.itemTypeEnd = val_16;
            if((this.totalCount & 2147483648) == 0)
            {
                    int val_2 = this.contentConstraintCount;
                int val_3 = val_16 / val_2;
                val_3 = val_16 - (val_3 * val_2);
                if(val_3 != 0)
            {
                    UnityEngine.Debug.LogWarning(message:  "Grid will become strange since we can\'t fill items in the last line");
            }
            
            }
            
            int val_5 = this.m_Content.childCount - 1;
            if(>=0)
            {
                    do
            {
                UnityEngine.Transform val_6 = this.m_Content.GetChild(index:  val_5);
                val_5 = val_5 - 1;
            }
            while(>=0);
            
            }
            
            UnityEngine.Rect val_8 = this.viewRect.rect;
            UnityEngine.Vector2 val_9 = val_8.m_XMin.size;
            float val_10 = (this.directionSign == 1) ? val_9.y : val_9.x;
            val_17 = 0f;
            if(val_10 <= 0f)
            {
                goto label_17;
            }
            
            val_17 = 0f;
            label_18:
            if(this.reverseDirection != false)
            {
                    float val_11 = this.NewItemAtEnd();
            }
            else
            {
                    float val_12 = this.NewItemAtStart();
            }
            
            if(val_12 <= 0f)
            {
                goto label_17;
            }
            
            val_17 = val_17 + val_12;
            if(val_10 > val_17)
            {
                goto label_18;
            }
            
            label_17:
            UnityEngine.Vector2 val_13 = this.m_Content.anchoredPosition;
            val_18 = val_13.x;
            val_19 = val_13.y;
            float val_15 = UnityEngine.Mathf.Max(a:  0f, b:  val_17 - val_10);
            val_15 = (this.reverseDirection == false) ? (val_15) : (-val_15);
            if(this.directionSign == 1)
            {
                goto label_22;
            }
            
            if(this.directionSign != 1)
            {
                goto label_24;
            }
            
            val_18 = -val_15;
            goto label_24;
            label_22:
            val_19 = val_15;
            label_24:
            this.m_Content.anchoredPosition = new UnityEngine.Vector2() {x = val_18, y = val_19};
        }
        public void RefillCells(int offset = 0)
        {
            int val_14 = offset;
            if(UnityEngine.Application.isPlaying == false)
            {
                    return;
            }
            
            if(this.prefabSource == null)
            {
                    return;
            }
            
            if(this.reverseDirection != false)
            {
                    val_14 = this.totalCount - val_14;
            }
            
            this.itemTypeStart = val_14;
            this.itemTypeEnd = val_14;
            if((this.totalCount & 2147483648) == 0)
            {
                    int val_2 = this.contentConstraintCount;
                int val_3 = val_14 / val_2;
                val_3 = val_14 - (val_3 * val_2);
                if(val_3 != 0)
            {
                    UnityEngine.Debug.LogWarning(message:  "Grid will become strange since we can\'t fill items in the first line");
            }
            
            }
            
            int val_5 = this.m_Content.childCount - 1;
            if(>=0)
            {
                    do
            {
                UnityEngine.Transform val_6 = this.m_Content.GetChild(index:  val_5);
                val_5 = val_5 - 1;
            }
            while(>=0);
            
            }
            
            UnityEngine.Rect val_8 = this.viewRect.rect;
            UnityEngine.Vector2 val_9 = val_8.m_XMin.size;
            float val_10 = (this.directionSign == 1) ? val_9.y : val_9.x;
            if(val_10 <= 0f)
            {
                goto label_17;
            }
            
            float val_14 = 0f;
            label_18:
            if(this.reverseDirection != false)
            {
                    float val_11 = this.NewItemAtStart();
            }
            else
            {
                    float val_12 = this.NewItemAtEnd();
            }
            
            if(val_12 <= 0f)
            {
                goto label_17;
            }
            
            val_14 = val_14 + val_12;
            if(val_10 > val_14)
            {
                goto label_18;
            }
            
            label_17:
            UnityEngine.Vector2 val_13 = this.m_Content.anchoredPosition;
            if(this.directionSign == 1)
            {
                goto label_20;
            }
            
            if(this.directionSign != 1)
            {
                goto label_22;
            }
            
            goto label_22;
            label_20:
            label_22:
            this.m_Content.anchoredPosition = new UnityEngine.Vector2() {x = val_13.x, y = 0f};
        }
        protected float NewItemAtStart()
        {
            float val_13;
            if((this.totalCount & 2147483648) != 0)
            {
                goto label_1;
            }
            
            int val_1 = this.contentConstraintCount;
            if(this.itemTypeStart < 0)
            {
                goto label_2;
            }
            
            label_1:
            if(this.contentConstraintCount >= 1)
            {
                    var val_13 = 0;
                do
            {
                int val_3 = this.itemTypeStart - 1;
                this.itemTypeStart = val_3;
                this.InstantiateNextItem(itemIdx:  val_3).SetAsFirstSibling();
                val_13 = UnityEngine.Mathf.Max(a:  V0.16B, b:  0f);
                val_13 = val_13 + 1;
            }
            while(val_13 < this.contentConstraintCount);
            
            }
            else
            {
                    val_13 = 0f;
            }
            
            float val_7 = val_13 * 1.5f;
            this.threshold = UnityEngine.Mathf.Max(a:  this.threshold, b:  val_7);
            if(this.reverseDirection == true)
            {
                    return (float)val_13;
            }
            
            UnityEngine.Vector2 val_9 = this.m_Content.anchoredPosition;
            UnityEngine.Vector2 val_10 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y}, b:  new UnityEngine.Vector2() {x = val_13, y = val_7});
            this.m_Content.anchoredPosition = new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
            UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = this.m_PrevPosition, y = val_10.y}, b:  new UnityEngine.Vector2() {x = val_13, y = val_7});
            this.m_PrevPosition = val_11;
            mem[1152921520069175960] = val_11.y;
            UnityEngine.Vector2 val_12 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = this.m_ContentStartPosition, y = val_7}, b:  new UnityEngine.Vector2() {x = val_13, y = val_7});
            this.m_ContentStartPosition = val_12;
            mem[1152921520069175884] = val_12.y;
            return (float)val_13;
            label_2:
            val_13 = 0f;
            return (float)val_13;
        }
        protected float DeleteItemAtStart()
        {
            float val_15;
            float val_16;
            var val_17;
            var val_18;
            if(this.m_Dragging == true)
            {
                goto label_1;
            }
            
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            val_15 = V8.16B;
            if((UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = this.m_Velocity, y = val_15}, rhs:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y})) == false)
            {
                goto label_5;
            }
            
            label_1:
            int val_14 = this.totalCount;
            if((val_14 & 2147483648) == 0)
            {
                    val_14 = val_14 - 1;
                val_16 = 0f;
                if(this.itemTypeEnd >= val_14)
            {
                    return val_16;
            }
            
            }
            
            label_5:
            if(this.m_Content.childCount == 0)
            {
                goto label_8;
            }
            
            if(this.contentConstraintCount < 1)
            {
                goto label_9;
            }
            
            val_17 = 0;
            label_18:
            UnityEngine.Transform val_5 = this.m_Content.GetChild(index:  0);
            if(val_5 != null)
            {
                    var val_6 = (null == null) ? (val_5) : 0;
            }
            else
            {
                    val_18 = 0;
            }
            
            val_15 = 0f;
            val_16 = UnityEngine.Mathf.Max(a:  this.m_Velocity, b:  val_15);
            int val_15 = this.itemTypeStart;
            val_15 = val_15 + 1;
            this.itemTypeStart = val_15;
            if(this.m_Content.childCount == 0)
            {
                goto label_19;
            }
            
            val_17 = val_17 + 1;
            if(val_17 < this.contentConstraintCount)
            {
                goto label_18;
            }
            
            goto label_19;
            label_8:
            val_16 = 0f;
            return val_16;
            label_9:
            val_16 = 0f;
            label_19:
            if(this.reverseDirection == true)
            {
                    return val_16;
            }
            
            UnityEngine.Vector2 val_10 = this.m_Content.anchoredPosition;
            UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_10.x, y = val_10.y}, b:  new UnityEngine.Vector2() {x = val_16, y = val_15});
            this.m_Content.anchoredPosition = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
            UnityEngine.Vector2 val_12 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = this.m_PrevPosition, y = val_11.y}, b:  new UnityEngine.Vector2() {x = val_16, y = val_15});
            this.m_PrevPosition = val_12;
            mem[1152921520069320728] = val_12.y;
            UnityEngine.Vector2 val_13 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = this.m_ContentStartPosition, y = val_15}, b:  new UnityEngine.Vector2() {x = val_16, y = val_15});
            this.m_ContentStartPosition = val_13;
            mem[1152921520069320652] = val_13.y;
            return val_16;
        }
        protected float NewItemAtEnd()
        {
            float val_13;
            var val_14;
            if((this.totalCount & 2147483648) == 0)
            {
                    val_13 = 0f;
                if(this.itemTypeEnd >= this.totalCount)
            {
                    return val_13;
            }
            
            }
            
            UnityEngine.RectTransform val_13 = this.m_Content;
            var val_14 = this.contentConstraintCount;
            val_14 = val_13.childCount;
            int val_3 = this.contentConstraintCount;
            val_13 = val_14 / val_3;
            val_13 = (-val_14) + (val_13 * val_3);
            val_14 = val_14 + val_13;
            if(val_14 < 1)
            {
                goto label_4;
            }
            
            val_14 = 1;
            label_8:
            UnityEngine.RectTransform val_4 = this.InstantiateNextItem(itemIdx:  this.itemTypeEnd);
            val_13 = UnityEngine.Mathf.Max(a:  V0.16B, b:  0f);
            int val_6 = this.itemTypeEnd + 1;
            this.itemTypeEnd = val_6;
            if(val_6 >= this.totalCount)
            {
                goto label_9;
            }
            
            val_14 = val_14 + 1;
            if(val_14 < val_14)
            {
                goto label_8;
            }
            
            goto label_9;
            label_4:
            val_13 = 0f;
            label_9:
            float val_7 = val_13 * 1.5f;
            this.threshold = UnityEngine.Mathf.Max(a:  this.threshold, b:  val_7);
            if(this.reverseDirection == false)
            {
                    return val_13;
            }
            
            UnityEngine.Vector2 val_9 = this.m_Content.anchoredPosition;
            UnityEngine.Vector2 val_10 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y}, b:  new UnityEngine.Vector2() {x = val_13, y = val_7});
            this.m_Content.anchoredPosition = new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
            UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = this.m_PrevPosition, y = val_10.y}, b:  new UnityEngine.Vector2() {x = val_13, y = val_7});
            this.m_PrevPosition = val_11;
            mem[1152921520069469592] = val_11.y;
            UnityEngine.Vector2 val_12 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = this.m_ContentStartPosition, y = val_7}, b:  new UnityEngine.Vector2() {x = val_13, y = val_7});
            this.m_ContentStartPosition = val_12;
            mem[1152921520069469516] = val_12.y;
            return val_13;
        }
        protected float DeleteItemAtEnd()
        {
            float val_19;
            float val_20;
            var val_21;
            var val_22;
            if(this.m_Dragging == true)
            {
                goto label_1;
            }
            
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            val_19 = V8.16B;
            if((UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = this.m_Velocity, y = val_19}, rhs:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y})) == false)
            {
                goto label_5;
            }
            
            label_1:
            if((this.totalCount & 2147483648) == 0)
            {
                    val_20 = 0f;
                if(this.itemTypeStart < this.contentConstraintCount)
            {
                    return val_20;
            }
            
            }
            
            label_5:
            if(this.m_Content.childCount == 0)
            {
                goto label_8;
            }
            
            if(this.contentConstraintCount < 1)
            {
                goto label_9;
            }
            
            val_21 = 0;
            label_19:
            UnityEngine.RectTransform val_18 = this.m_Content;
            UnityEngine.Transform val_8 = val_18.GetChild(index:  val_18.childCount - 1);
            if(val_8 != null)
            {
                    val_18 = (null == null) ? (val_8) : 0;
            }
            else
            {
                    val_22 = 0;
            }
            
            val_19 = 0f;
            val_20 = UnityEngine.Mathf.Max(a:  this.m_Velocity, b:  val_19);
            int val_19 = this.itemTypeEnd;
            int val_10 = val_19 - 1;
            this.itemTypeEnd = val_10;
            int val_11 = this.contentConstraintCount;
            val_19 = val_10 / val_11;
            val_19 = val_10 - (val_19 * val_11);
            if((val_19 == 0) || (this.m_Content.childCount == 0))
            {
                goto label_20;
            }
            
            val_21 = val_21 + 1;
            if(val_21 < this.contentConstraintCount)
            {
                goto label_19;
            }
            
            goto label_20;
            label_8:
            val_20 = 0f;
            return val_20;
            label_9:
            val_20 = 0f;
            label_20:
            if(this.reverseDirection == false)
            {
                    return val_20;
            }
            
            UnityEngine.Vector2 val_14 = this.m_Content.anchoredPosition;
            UnityEngine.Vector2 val_15 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_14.x, y = val_14.y}, b:  new UnityEngine.Vector2() {x = val_20, y = val_19});
            this.m_Content.anchoredPosition = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
            UnityEngine.Vector2 val_16 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = this.m_PrevPosition, y = val_15.y}, b:  new UnityEngine.Vector2() {x = val_20, y = val_19});
            this.m_PrevPosition = val_16;
            mem[1152921520069618456] = val_16.y;
            UnityEngine.Vector2 val_17 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = this.m_ContentStartPosition, y = val_19}, b:  new UnityEngine.Vector2() {x = val_20, y = val_19});
            this.m_ContentStartPosition = val_17;
            mem[1152921520069618380] = val_17.y;
            return val_20;
        }
        private UnityEngine.RectTransform InstantiateNextItem(int itemIdx)
        {
            UnityEngine.Transform val_1 = this.prefabSource.transform;
            val_1.transform.SetParent(parent:  this.m_Content, worldPositionStays:  false);
            val_1.gameObject.SetActive(value:  true);
            return (UnityEngine.RectTransform)val_1;
        }
        public virtual void Rebuild(UnityEngine.UI.CanvasUpdate executing)
        {
            if(executing != 2)
            {
                    if(executing != 0)
            {
                    return;
            }
            
                this.UpdateCachedData();
                return;
            }
            
            this.UpdateBounds(updateItems:  false);
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            this.UpdateScrollbars(offset:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y});
            this.UpdatePrevData();
            this.m_HasRebuiltLayout = true;
        }
        public virtual void LayoutComplete()
        {
        
        }
        public virtual void GraphicUpdateComplete()
        {
        
        }
        private void UpdateCachedData()
        {
            UnityEngine.RectTransform val_30;
            UnityEngine.RectTransform val_31;
            var val_32;
            var val_33;
            bool val_34;
            bool val_35;
            UnityEngine.Transform val_1 = this.transform;
            val_30 = 0;
            if(this.m_HorizontalScrollbar != 0)
            {
                    UnityEngine.Transform val_3 = this.m_HorizontalScrollbar.transform;
                if(val_3 != null)
            {
                    var val_4 = (null == null) ? (val_3) : 0;
            }
            else
            {
                    val_30 = 0;
            }
            
            }
            
            this.m_HorizontalScrollbarRect = val_30;
            val_31 = 0;
            if(this.m_VerticalScrollbar != 0)
            {
                    UnityEngine.Transform val_6 = this.m_VerticalScrollbar.transform;
                if(val_6 != null)
            {
                    var val_7 = (null == null) ? (val_6) : 0;
            }
            else
            {
                    val_31 = 0;
            }
            
            }
            
            this.m_VerticalScrollbarRect = val_31;
            if((UnityEngine.Object.op_Implicit(exists:  this.m_HorizontalScrollbarRect)) != false)
            {
                    val_32 = UnityEngine.Object.op_Equality(x:  this.m_HorizontalScrollbarRect.parent, y:  val_1);
            }
            else
            {
                    val_32 = 1;
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.m_VerticalScrollbarRect)) != false)
            {
                    val_33 = UnityEngine.Object.op_Equality(x:  this.m_VerticalScrollbarRect.parent, y:  val_1);
            }
            else
            {
                    val_33 = 1;
            }
            
            if(((val_32 & (UnityEngine.Object.op_Equality(x:  this.viewRect.parent, y:  val_1))) & val_33) != 0)
            {
                goto label_28;
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.m_HorizontalScrollbarRect)) == false)
            {
                goto label_31;
            }
            
            var val_19 = (this.m_HorizontalScrollbarVisibility == 2) ? 1 : 0;
            goto label_32;
            label_28:
            val_35 = 0;
            this.m_HSliderExpand = false;
            goto label_37;
            label_31:
            val_34 = false;
            label_32:
            this.m_HSliderExpand = val_34;
            if((UnityEngine.Object.op_Implicit(exists:  this.m_VerticalScrollbarRect)) != false)
            {
                    var val_21 = (this.m_VerticalScrollbarVisibility == 2) ? 1 : 0;
            }
            else
            {
                    val_35 = false;
            }
            
            label_37:
            this.m_VSliderExpand = val_35;
            if(this.m_HorizontalScrollbarRect != 0)
            {
                    UnityEngine.Rect val_23 = this.m_HorizontalScrollbarRect.rect;
            }
            
            this.m_HSliderHeight = val_23.m_XMin.height;
            if(this.m_VerticalScrollbarRect != 0)
            {
                    UnityEngine.Rect val_26 = this.m_VerticalScrollbarRect.rect;
            }
            
            this.m_VSliderWidth = val_26.m_XMin.width;
        }
        protected override void OnEnable()
        {
            UnityEngine.Events.UnityAction<T0> val_5;
            this.OnEnable();
            if((UnityEngine.Object.op_Implicit(exists:  this.m_HorizontalScrollbar)) != false)
            {
                    UnityEngine.Events.UnityAction<System.Single> val_2 = null;
                val_5 = val_2;
                val_2 = new UnityEngine.Events.UnityAction<System.Single>(object:  this, method:  System.Void UnityEngine.UI.LoopScrollRect::SetHorizontalNormalizedPosition(float value));
                this.m_HorizontalScrollbar.m_OnValueChanged.AddListener(call:  val_2);
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.m_VerticalScrollbar)) != false)
            {
                    UnityEngine.Events.UnityAction<System.Single> val_4 = null;
                val_5 = val_4;
                val_4 = new UnityEngine.Events.UnityAction<System.Single>(object:  this, method:  System.Void UnityEngine.UI.LoopScrollRect::SetVerticalNormalizedPosition(float value));
                this.m_VerticalScrollbar.m_OnValueChanged.AddListener(call:  val_4);
            }
            
            UnityEngine.UI.CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(element:  this);
        }
        protected override void OnDisable()
        {
            UnityEngine.Events.UnityAction<T0> val_7;
            UnityEngine.UI.CanvasUpdateRegistry.UnRegisterCanvasElementForRebuild(element:  this);
            if((UnityEngine.Object.op_Implicit(exists:  this.m_HorizontalScrollbar)) != false)
            {
                    UnityEngine.Events.UnityAction<System.Single> val_2 = null;
                val_7 = val_2;
                val_2 = new UnityEngine.Events.UnityAction<System.Single>(object:  this, method:  System.Void UnityEngine.UI.LoopScrollRect::SetHorizontalNormalizedPosition(float value));
                this.m_HorizontalScrollbar.m_OnValueChanged.RemoveListener(call:  val_2);
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.m_VerticalScrollbar)) != false)
            {
                    UnityEngine.Events.UnityAction<System.Single> val_4 = null;
                val_7 = val_4;
                val_4 = new UnityEngine.Events.UnityAction<System.Single>(object:  this, method:  System.Void UnityEngine.UI.LoopScrollRect::SetVerticalNormalizedPosition(float value));
                this.m_VerticalScrollbar.m_OnValueChanged.RemoveListener(call:  val_4);
            }
            
            this.m_HasRebuiltLayout = false;
            this.m_Tracker.Clear();
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.zero;
            this.m_Velocity = val_5;
            mem[1152921520070775180] = val_5.y;
            UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(rect:  this.rectTransform);
            this.OnDisable();
        }
        public override bool IsActive()
        {
            if(this.IsActive() == false)
            {
                    return false;
            }
            
            return UnityEngine.Object.op_Inequality(x:  this.m_Content, y:  0);
        }
        private void EnsureLayoutHasRebuilt()
        {
            if(this.m_HasRebuiltLayout == true)
            {
                    return;
            }
            
            if(UnityEngine.UI.CanvasUpdateRegistry.IsRebuildingLayout() != false)
            {
                    return;
            }
            
            UnityEngine.Canvas.ForceUpdateCanvases();
        }
        public virtual void StopMovement()
        {
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            this.m_Velocity = val_1;
            mem[1152921520071156236] = val_1.y;
        }
        public virtual void OnScroll(UnityEngine.EventSystems.PointerEventData data)
        {
            float val_8;
            UnityEngine.Vector2 val_9;
            float val_10;
            float val_11;
            float val_12;
            float val_13;
            float val_14;
            float val_15;
            float val_16;
            float val_17;
            if((this & 1) == 0)
            {
                    return;
            }
            
            this.EnsureLayoutHasRebuilt();
            this.UpdateBounds(updateItems:  false);
            val_9 = data.<scrollDelta>k__BackingField;
            val_10 = -S0;
            if(this.m_Vertical == false)
            {
                goto label_3;
            }
            
            if(this.m_Horizontal == true)
            {
                goto label_4;
            }
            
            val_11 = System.Math.Abs(val_10);
            val_8 = 0f;
            if(System.Math.Abs(val_9) <= val_11)
            {
                goto label_7;
            }
            
            goto label_8;
            label_3:
            val_8 = val_9;
            label_7:
            val_12 = val_10;
            label_8:
            val_10 = val_12;
            val_13 = val_8;
            val_14 = val_10;
            if(this.m_Horizontal == false)
            {
                goto label_14;
            }
            
            label_4:
            if(this.m_Vertical != false)
            {
                    val_14 = val_10;
            }
            else
            {
                    val_8 = System.Math.Abs(val_10);
                val_11 = System.Math.Abs(val_13);
                val_14 = 0f;
                if(val_8 > val_11)
            {
                    val_13 = val_10;
            }
            
            }
            
            label_14:
            UnityEngine.Vector2 val_1 = this.m_Content.anchoredPosition;
            val_15 = val_1.x;
            UnityEngine.Vector2 val_2 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_13, y = val_14}, d:  this.m_ScrollSensitivity);
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_15, y = val_1.y}, b:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y});
            val_16 = val_3.x;
            val_17 = val_3.y;
            if(this.m_MovementType == 2)
            {
                    UnityEngine.Vector2 val_4 = this.m_Content.anchoredPosition;
                val_15 = val_4.x;
                UnityEngine.Vector2 val_5 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_16, y = val_17}, b:  new UnityEngine.Vector2() {x = val_15, y = val_4.y});
                UnityEngine.Vector2 val_6 = this.CalculateOffset(delta:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y});
                UnityEngine.Vector2 val_7 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_16, y = val_17}, b:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y});
                val_16 = val_7.x;
                val_17 = val_7.y;
            }
            
            this.UpdateBounds(updateItems:  false);
        }
        public virtual void OnInitializePotentialDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if((eventData.<button>k__BackingField) != 0)
            {
                    return;
            }
            
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            this.m_Velocity = val_1;
            mem[1152921520071421196] = val_1.y;
        }
        public virtual void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            var val_6;
            if((eventData.<button>k__BackingField) != 0)
            {
                    return;
            }
            
            if((this & 1) == 0)
            {
                    return;
            }
            
            this.UpdateBounds(updateItems:  false);
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            val_6 = this;
            this.m_PointerStartLocalCursor = val_1;
            mem[1152921520071561796] = val_1.y;
            bool val_4 = UnityEngine.RectTransformUtility.ScreenPointToLocalPointInRectangle(rect:  this.viewRect, screenPoint:  new UnityEngine.Vector2() {x = eventData.<position>k__BackingField, y = V9.16B}, cam:  eventData.pressEventCamera, localPoint: out  new UnityEngine.Vector2() {x = this.m_PointerStartLocalCursor, y = mem[1152921520071561796]});
            UnityEngine.Vector2 val_5 = this.m_Content.anchoredPosition;
            this.m_ContentStartPosition = val_5;
            mem[1152921520071561804] = val_5.y;
            this.m_Dragging = true;
        }
        public virtual void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(eventData != null)
            {
                    if((eventData.<button>k__BackingField) != 0)
            {
                    return;
            }
            
                this.m_Dragging = false;
                return;
            }
            
            throw new NullReferenceException();
        }
        public virtual void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            UnityEngine.Vector2 val_14;
            float val_15;
            if((eventData.<button>k__BackingField) != 0)
            {
                    return;
            }
            
            if((this & 1) == 0)
            {
                    return;
            }
            
            val_14 = eventData.<position>k__BackingField;
            if((UnityEngine.RectTransformUtility.ScreenPointToLocalPointInRectangle(rect:  this.viewRect, screenPoint:  new UnityEngine.Vector2() {x = val_14, y = V9.16B}, cam:  eventData.pressEventCamera, localPoint: out  new UnityEngine.Vector2() {x = 0f, y = 0f})) == false)
            {
                    return;
            }
            
            this.UpdateBounds(updateItems:  false);
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = 0f, y = 0f}, b:  new UnityEngine.Vector2() {x = this.m_PointerStartLocalCursor, y = val_14});
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = this.m_ContentStartPosition, y = val_14}, b:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y});
            UnityEngine.Vector2 val_6 = this.m_Content.anchoredPosition;
            UnityEngine.Vector2 val_7 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y}, b:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y});
            UnityEngine.Vector2 val_8 = this.CalculateOffset(delta:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y});
            UnityEngine.Vector2 val_9 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y}, b:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y});
            val_14 = val_9.x;
            val_15 = val_9.y;
            if(this.m_MovementType != 1)
            {
                    return;
            }
            
            if(val_8.x != 0f)
            {
                    UnityEngine.Vector3 val_10 = this.m_ViewBounds.size;
                float val_11 = UnityEngine.UI.LoopScrollRect.RubberDelta(overStretching:  val_8.x, viewSize:  val_10.x);
                val_11 = val_11 * this.rubberScale;
                val_14 = val_14 - val_11;
            }
            
            if(val_8.y == 0f)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_12 = this.m_ViewBounds.size;
            float val_13 = UnityEngine.UI.LoopScrollRect.RubberDelta(overStretching:  val_8.y, viewSize:  val_12.y);
            val_13 = val_13 * this.rubberScale;
            val_15 = val_15 - val_13;
        }
        protected virtual void SetContentAnchoredPosition(UnityEngine.Vector2 position)
        {
            float val_5;
            float val_6;
            val_5 = position.y;
            val_6 = position.x;
            if(this.m_Horizontal != true)
            {
                    UnityEngine.Vector2 val_1 = this.m_Content.anchoredPosition;
                val_6 = val_1.x;
            }
            
            if(this.m_Vertical != true)
            {
                    UnityEngine.Vector2 val_2 = this.m_Content.anchoredPosition;
                val_5 = val_2.y;
            }
            
            UnityEngine.Vector2 val_3 = this.m_Content.anchoredPosition;
            if((UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = val_6, y = val_5}, rhs:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y})) == false)
            {
                    return;
            }
            
            this.m_Content.anchoredPosition = new UnityEngine.Vector2() {x = val_6, y = val_5};
            this.UpdateBounds(updateItems:  true);
        }
        protected virtual void LateUpdate()
        {
            var val_43;
            float val_44;
            float val_47;
            float val_48;
            UnityEngine.Vector2 val_49;
            float val_50;
            float val_51;
            float val_53;
            float val_54;
            float val_55;
            float val_56;
            float val_57;
            float val_58;
            val_43 = this;
            if((UnityEngine.Object.op_Implicit(exists:  this.m_Content)) == false)
            {
                    return;
            }
            
            this.EnsureLayoutHasRebuilt();
            this.UpdateScrollbarVisibility();
            this.UpdateBounds(updateItems:  false);
            val_44 = UnityEngine.Time.unscaledDeltaTime;
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
            UnityEngine.Vector2 val_4 = this.CalculateOffset(delta:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
            if(this.m_Dragging == true)
            {
                goto label_6;
            }
            
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.zero;
            val_47 = val_4.x;
            val_48 = val_4.y;
            if((UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = val_47, y = val_48}, rhs:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y})) == true)
            {
                goto label_9;
            }
            
            val_49 = this.m_Velocity;
            UnityEngine.Vector2 val_7 = UnityEngine.Vector2.zero;
            val_50 = val_49;
            val_51 = val_4.x;
            if((UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = val_50, y = val_51}, rhs:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y})) == false)
            {
                goto label_29;
            }
            
            label_9:
            UnityEngine.Vector2 val_9 = this.m_Content.anchoredPosition;
            label_26:
            if(this.m_MovementType == 1)
            {
                    if(val_4.x.Item[0] != 0f)
            {
                goto label_15;
            }
            
            }
            
            if(this.m_Inertia == false)
            {
                goto label_16;
            }
            
            float val_42 = this.m_DecelerationRate;
            val_48 = val_44;
            val_42 = this.m_Velocity.Item[0] * val_42;
            this.m_Velocity.set_Item(index:  0, value:  val_42);
            val_53 = System.Math.Abs(this.m_Velocity.Item[0]);
            if(val_53 < 0)
            {
                    val_53 = 0f;
                this.m_Velocity.set_Item(index:  0, value:  val_53);
            }
            
            float val_14 = this.m_Velocity.Item[0];
            val_14 = val_44 * val_14;
            val_54 = val_9.x.Item[0] + val_14;
            goto label_20;
            label_16:
            val_54 = 0f;
            goto label_21;
            label_15:
            UnityEngine.Vector2 val_16 = this.m_Content.anchoredPosition;
            UnityEngine.Vector2 val_18 = this.m_Content.anchoredPosition;
            val_55 = this.m_Elasticity;
            val_48 = val_18.x.Item[0] + val_4.x.Item[0];
            val_9.x.set_Item(index:  0, value:  UnityEngine.Mathf.SmoothDamp(current:  val_16.x.Item[0], target:  val_48, currentVelocity: ref  float val_21 = -2.129188E-23f, smoothTime:  val_55, maxSpeed:  Infinityf, deltaTime:  val_44));
            val_54 = this.m_Velocity.Item[0];
            label_21:
            label_20:
            this.m_Velocity.set_Item(index:  0, value:  val_54);
            if(0 == 0)
            {
                goto label_26;
            }
            
            val_49 = this.m_Velocity;
            UnityEngine.Vector2 val_23 = UnityEngine.Vector2.zero;
            val_56 = val_49;
            val_57 = Infinityf;
            if((UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = val_56, y = Infinityf}, rhs:  new UnityEngine.Vector2() {x = val_23.x, y = val_23.y})) != false)
            {
                    val_49 = val_9.x;
                val_58 = val_9.y;
                if(this.m_MovementType == 2)
            {
                    UnityEngine.Vector2 val_25 = this.m_Content.anchoredPosition;
                val_55 = val_25.y;
                UnityEngine.Vector2 val_26 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_49, y = val_58}, b:  new UnityEngine.Vector2() {x = val_25.x, y = val_55});
                UnityEngine.Vector2 val_27 = this.CalculateOffset(delta:  new UnityEngine.Vector2() {x = val_26.x, y = val_26.y});
                UnityEngine.Vector2 val_28 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y}, b:  new UnityEngine.Vector2() {x = val_27.x, y = val_27.y});
                val_49 = val_28.x;
                val_58 = val_28.y;
            }
            
                val_56 = val_49;
                val_57 = val_58;
            }
            
            label_29:
            if(this.m_Dragging == false)
            {
                goto label_35;
            }
            
            label_6:
            if(this.m_Inertia != false)
            {
                    UnityEngine.Vector2 val_29 = this.m_Content.anchoredPosition;
                UnityEngine.Vector2 val_30 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_29.x, y = val_29.y}, b:  new UnityEngine.Vector2() {x = this.m_PrevPosition, y = val_49});
                UnityEngine.Vector2 val_31 = UnityEngine.Vector2.op_Division(a:  new UnityEngine.Vector2() {x = val_30.x, y = val_30.y}, d:  val_44);
                UnityEngine.Vector3 val_32 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_31.x, y = val_31.y});
                val_49 = val_32.y;
                UnityEngine.Vector3 val_33 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = this.m_Velocity, y = val_32.y});
                val_55 = val_33.x;
                val_56 = val_55;
                val_57 = val_33.y;
                UnityEngine.Vector3 val_35 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = val_56, y = val_57, z = val_33.z}, b:  new UnityEngine.Vector3() {x = val_32.x, y = val_49, z = val_32.z}, t:  val_44 * 10f);
                UnityEngine.Vector2 val_36 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_35.x, y = val_35.y, z = val_35.z});
                this.m_Velocity = val_36;
                mem[1152921520072170636] = val_36.y;
            }
            
            label_35:
            if((UnityEngine.Bounds.op_Inequality(lhs:  new UnityEngine.Bounds() {m_Center = new UnityEngine.Vector3() {x = this.m_ViewBounds, y = this.m_ViewBounds, z = this.m_ViewBounds}, m_Extents = new UnityEngine.Vector3() {x = this.m_ViewBounds, y = UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished, z = UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished}}, rhs:  new UnityEngine.Bounds() {m_Center = new UnityEngine.Vector3() {x = this.m_PrevViewBounds.m_Center, y = this.m_PrevViewBounds.m_Center, z = this.m_PrevViewBounds.m_Center}, m_Extents = new UnityEngine.Vector3() {x = this.m_PrevViewBounds.m_Center, y = 2.386545E-23f, z = 2.524355E-29f}})) != true)
            {
                    if((UnityEngine.Bounds.op_Inequality(lhs:  new UnityEngine.Bounds() {m_Center = new UnityEngine.Vector3() {x = this.m_ContentBounds, y = this.m_ContentBounds, z = this.m_ContentBounds}, m_Extents = new UnityEngine.Vector3() {x = this.m_ContentBounds, y = 2.386545E-23f, z = 2.524355E-29f}}, rhs:  new UnityEngine.Bounds() {m_Center = new UnityEngine.Vector3() {x = this.m_PrevContentBounds.m_Center, y = this.m_PrevContentBounds.m_Center, z = this.m_PrevContentBounds.m_Center}, m_Extents = new UnityEngine.Vector3() {x = this.m_PrevContentBounds.m_Center, y = 2.386545E-23f, z = 2.524355E-29f}})) != true)
            {
                    UnityEngine.Vector2 val_39 = this.m_Content.anchoredPosition;
                val_49 = this.m_PrevPosition;
                val_44 = val_39.x;
                val_57 = val_39.y;
                if((UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = val_44, y = val_57}, rhs:  new UnityEngine.Vector2() {x = val_49, y = val_32.x})) == false)
            {
                    return;
            }
            
            }
            
            }
            
            this.UpdateScrollbars(offset:  new UnityEngine.Vector2() {x = val_27.x, y = val_27.y});
            UnityEngine.Vector2 val_41 = this.normalizedPosition;
            this.m_OnValueChanged.Invoke(arg0:  new UnityEngine.Vector2() {x = val_41.x, y = val_41.y});
            this.UpdatePrevData();
        }
        private void UpdatePrevData()
        {
            if(this.m_Content == 0)
            {
                    UnityEngine.Vector2 val_2 = UnityEngine.Vector2.zero;
            }
            else
            {
                    UnityEngine.Vector2 val_3 = this.m_Content.anchoredPosition;
            }
            
            this.m_PrevPosition = val_3;
            mem[1152921520072331800] = val_3.y;
            mem[1152921520072331844] = UnityEngine.Object.__il2cppRuntimeField_cctor_finished;
            mem2[0] = this.m_ViewBounds;
            mem[1152921520072331820] = this.m_PrevViewBounds;
            mem2[0] = this.m_ContentBounds;
        }
        private void UpdateScrollbars(UnityEngine.Vector2 offset)
        {
            float val_19;
            UnityEngine.Bounds val_20;
            float val_22;
            UnityEngine.Bounds val_23;
            val_19 = offset.y;
            if((UnityEngine.Object.op_Implicit(exists:  this.m_HorizontalScrollbar)) != false)
            {
                    val_20 = this.m_ContentBounds;
                UnityEngine.Vector3 val_2 = val_20.size;
                if((val_2.x > 0f) && (this.totalCount >= 1))
            {
                    UnityEngine.Vector3 val_3 = this.m_ViewBounds.size;
                val_22 = val_3.x;
                UnityEngine.Vector3 val_4 = val_20.size;
                val_20 = this.CurrentLines;
                float val_7 = val_22 - System.Math.Abs(offset.x);
                val_7 = val_7 / val_4.x;
                val_7 = val_7 * (float)val_20;
                val_7 = val_7 / (float)this.TotalLines;
                float val_8 = UnityEngine.Mathf.Clamp01(value:  val_7);
            }
            
                this.m_HorizontalScrollbar.size = 1f;
                this.m_HorizontalScrollbar.value = this.horizontalNormalizedPosition;
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.m_VerticalScrollbar)) == false)
            {
                    return;
            }
            
            val_23 = this.m_ContentBounds;
            UnityEngine.Vector3 val_11 = val_23.size;
            if((val_11.y > 0f) && (this.totalCount >= 1))
            {
                    UnityEngine.Vector3 val_12 = this.m_ViewBounds.size;
                val_22 = System.Math.Abs(val_19);
                UnityEngine.Vector3 val_13 = val_23.size;
                val_19 = val_13.y;
                val_23 = this.CurrentLines;
                float val_16 = val_12.y - val_22;
                val_16 = val_16 / val_19;
                val_16 = val_16 * (float)val_23;
                val_16 = val_16 / (float)this.TotalLines;
                float val_17 = UnityEngine.Mathf.Clamp01(value:  val_16);
            }
            
            this.m_VerticalScrollbar.size = 1f;
            this.m_VerticalScrollbar.value = this.verticalNormalizedPosition;
        }
        public UnityEngine.Vector2 get_normalizedPosition()
        {
            UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  this.horizontalNormalizedPosition, y:  this.verticalNormalizedPosition);
            return new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
        }
        public void set_normalizedPosition(UnityEngine.Vector2 value)
        {
            this.SetNormalizedPosition(value:  value.x, axis:  0);
            this.SetNormalizedPosition(value:  value.y, axis:  1);
        }
        public float get_horizontalNormalizedPosition()
        {
            this.UpdateBounds(updateItems:  false);
            if(this.totalCount < 1)
            {
                    return (float)(val_9.x > val_3) ? 1f : 0f;
            }
            
            if(this.itemTypeEnd <= this.itemTypeStart)
            {
                    return (float)(val_9.x > val_3) ? 1f : 0f;
            }
            
            UnityEngine.Vector3 val_1 = this.m_ContentBounds.size;
            float val_3 = val_1.x / (float)this.CurrentLines;
            float val_5 = val_3 * (float)this.TotalLines;
            UnityEngine.Vector3 val_6 = this.m_ContentBounds.min;
            float val_13 = (float)this.StartLine;
            this = this.m_ViewBounds;
            val_13 = val_3 * val_13;
            val_3 = val_6.x - val_13;
            UnityEngine.Vector3 val_8 = this.size;
            UnityEngine.Vector3 val_9 = this.min;
            if(val_5 <= val_8.x)
            {
                    return (float)(val_9.x > val_3) ? 1f : 0f;
            }
            
            UnityEngine.Vector3 val_10 = this.size;
            val_10.x = val_5 - val_10.x;
            val_10.x = (val_9.x - val_3) / val_10.x;
            return (float)(val_9.x > val_3) ? 1f : 0f;
        }
        public void set_horizontalNormalizedPosition(float value)
        {
            this.SetNormalizedPosition(value:  value, axis:  0);
        }
        public float get_verticalNormalizedPosition()
        {
            this.UpdateBounds(updateItems:  false);
            if(this.totalCount < 1)
            {
                    return (float)(val_3 > val_9.y) ? 1f : 0f;
            }
            
            if(this.itemTypeEnd <= this.itemTypeStart)
            {
                    return (float)(val_3 > val_9.y) ? 1f : 0f;
            }
            
            UnityEngine.Vector3 val_1 = this.m_ContentBounds.size;
            float val_3 = val_1.y / (float)this.CurrentLines;
            float val_5 = val_3 * (float)this.TotalLines;
            UnityEngine.Vector3 val_6 = this.m_ContentBounds.max;
            float val_13 = (float)this.StartLine;
            this = this.m_ViewBounds;
            val_13 = val_3 * val_13;
            val_3 = val_6.y + val_13;
            UnityEngine.Vector3 val_8 = this.size;
            UnityEngine.Vector3 val_9 = this.max;
            if(val_5 <= val_8.y)
            {
                    return (float)(val_3 > val_9.y) ? 1f : 0f;
            }
            
            UnityEngine.Vector3 val_10 = this.size;
            float val_11 = val_3 - val_9.y;
            val_10.y = val_5 - val_10.y;
            val_11 = val_11 / val_10.y;
            return (float)(val_3 > val_9.y) ? 1f : 0f;
        }
        public void set_verticalNormalizedPosition(float value)
        {
            this.SetNormalizedPosition(value:  value, axis:  1);
        }
        private void SetHorizontalNormalizedPosition(float value)
        {
            this.SetNormalizedPosition(value:  value, axis:  0);
        }
        private void SetVerticalNormalizedPosition(float value)
        {
            this.SetNormalizedPosition(value:  value, axis:  1);
        }
        private void SetNormalizedPosition(float value, int axis)
        {
            float val_24;
            float val_27;
            float val_28;
            float val_29;
            val_24 = value;
            if(this.totalCount < 1)
            {
                    return;
            }
            
            if(this.itemTypeEnd <= this.itemTypeStart)
            {
                    return;
            }
            
            this.EnsureLayoutHasRebuilt();
            this.UpdateBounds(updateItems:  false);
            UnityEngine.Vector3 val_1 = this.m_Content.localPosition;
            val_27 = val_1.x.Item[axis];
            if(axis == 1)
            {
                goto label_4;
            }
            
            if(axis != 0)
            {
                goto label_6;
            }
            
            UnityEngine.Vector3 val_3 = this.m_ContentBounds.size;
            float val_5 = val_3.x / (float)this.CurrentLines;
            UnityEngine.Vector3 val_8 = this.m_ContentBounds.min;
            float val_24 = (float)this.StartLine;
            val_24 = val_5 * val_24;
            val_5 = val_8.x - val_24;
            UnityEngine.Vector3 val_10 = this.m_ViewBounds.min;
            val_28 = val_10.x;
            UnityEngine.Vector3 val_11 = this.m_ViewBounds.size;
            float val_12 = val_11.x.Item[0];
            val_12 = (val_5 * (float)this.TotalLines) - val_12;
            val_12 = val_12 * val_24;
            val_12 = val_28 - val_12;
            val_29 = val_12 - val_5;
            val_27 = val_27 + val_29;
            goto label_6;
            label_4:
            UnityEngine.Vector3 val_13 = this.m_ContentBounds.size;
            float val_15 = val_13.y / (float)this.CurrentLines;
            UnityEngine.Vector3 val_18 = this.m_ContentBounds.max;
            float val_25 = (float)this.StartLine;
            val_25 = val_15 * val_25;
            val_15 = val_18.y + val_25;
            UnityEngine.Vector3 val_20 = this.m_ViewBounds.size;
            val_28 = val_20.y;
            UnityEngine.Vector3 val_21 = this.m_ViewBounds.max;
            float val_22 = (val_15 * (float)this.TotalLines) - val_28;
            val_22 = val_22 * val_24;
            val_22 = val_15 - val_22;
            val_29 = val_22 - val_21.y;
            val_27 = val_27 - val_29;
            label_6:
            val_24 = val_1.x.Item[axis];
            val_21.y = val_24 ?? val_27;
            if(val_21.y <= 0.01f)
            {
                    return;
            }
            
            val_1.x.set_Item(index:  axis, value:  val_27);
            this.m_Content.localPosition = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
            this.m_Velocity.set_Item(index:  axis, value:  0f);
            this.UpdateBounds(updateItems:  true);
        }
        private static float RubberDelta(float overStretching, float viewSize)
        {
            float val_1 = UnityEngine.Mathf.Sign(f:  overStretching);
            float val_3 = 0.55f;
            val_3 = System.Math.Abs(overStretching) * val_3;
            val_3 = val_3 / viewSize;
            val_3 = val_3 + 1f;
            val_3 = 1f / val_3;
            val_3 = 1f - val_3;
            val_3 = val_3 * viewSize;
            val_1 = val_3 * val_1;
            return (float)val_1;
        }
        protected override void OnRectTransformDimensionsChange()
        {
            this.SetDirty();
        }
        private bool get_hScrollingNeeded()
        {
            var val_5;
            if(UnityEngine.Application.isPlaying != false)
            {
                    UnityEngine.Vector3 val_2 = this.m_ContentBounds.size;
                UnityEngine.Vector3 val_3 = this.m_ViewBounds.size;
                val_3.x = val_3.x + 0.01f;
                var val_4 = (val_2.x > val_3.x) ? 1 : 0;
                return (bool)val_5;
            }
            
            val_5 = 1;
            return (bool)val_5;
        }
        private bool get_vScrollingNeeded()
        {
            var val_5;
            if(UnityEngine.Application.isPlaying != false)
            {
                    UnityEngine.Vector3 val_2 = this.m_ContentBounds.size;
                UnityEngine.Vector3 val_3 = this.m_ViewBounds.size;
                float val_5 = 0.01f;
                val_5 = val_3.y + val_5;
                var val_4 = (val_2.y > val_5) ? 1 : 0;
                return (bool)val_5;
            }
            
            val_5 = 1;
            return (bool)val_5;
        }
        public virtual void CalculateLayoutInputHorizontal()
        {
        
        }
        public virtual void CalculateLayoutInputVertical()
        {
        
        }
        public virtual float get_minWidth()
        {
            return -1f;
        }
        public virtual float get_preferredWidth()
        {
            return -1f;
        }
        public virtual float get_flexibleWidth()
        {
            return (float)this.<flexibleWidth>k__BackingField;
        }
        private void set_flexibleWidth(float value)
        {
            this.<flexibleWidth>k__BackingField = value;
        }
        public virtual float get_minHeight()
        {
            return -1f;
        }
        public virtual float get_preferredHeight()
        {
            return -1f;
        }
        public virtual float get_flexibleHeight()
        {
            return -1f;
        }
        public virtual int get_layoutPriority()
        {
            return 0;
        }
        public virtual void SetLayoutHorizontal()
        {
            var val_20;
            UnityEngine.Bounds val_21;
            var val_38;
            UnityEngine.Bounds val_39;
            var val_55;
            UnityEngine.Bounds val_56;
            float val_68;
            float val_69;
            float val_70;
            float val_71;
            bool val_72;
            this.m_Tracker.Clear();
            if(this.m_HSliderExpand != true)
            {
                    if(this.m_VSliderExpand == false)
            {
                goto label_2;
            }
            
            }
            
            this.m_Tracker.Add(driver:  this, rectTransform:  this.viewRect, drivenProperties:  6);
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
            this.viewRect.anchorMin = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.one;
            this.viewRect.anchorMax = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
            UnityEngine.Vector2 val_7 = UnityEngine.Vector2.zero;
            this.viewRect.sizeDelta = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
            UnityEngine.Vector2 val_9 = UnityEngine.Vector2.zero;
            this.viewRect.anchoredPosition = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
            UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot:  this.m_Content);
            UnityEngine.Rect val_11 = this.viewRect.rect;
            UnityEngine.Vector2 val_12 = val_11.m_XMin.center;
            UnityEngine.Vector3 val_13 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y});
            val_68 = val_13.x;
            UnityEngine.Rect val_15 = this.viewRect.rect;
            UnityEngine.Vector2 val_16 = val_15.m_XMin.size;
            UnityEngine.Vector3 val_17 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_16.x, y = val_16.y});
            val_69 = val_17.x;
            val_70 = val_68;
            val_71 = val_13.y;
            UnityEngine.Bounds val_18 = new UnityEngine.Bounds(center:  new UnityEngine.Vector3() {x = val_70, y = val_71, z = val_13.z}, size:  new UnityEngine.Vector3() {x = val_69, y = val_17.y, z = val_17.z});
            mem[1152921520075320096] = val_18.m_Extents.y;
            this.m_ViewBounds = val_18.m_Center.x;
            UnityEngine.Bounds val_19 = this.GetBounds();
            val_72 = this.m_VSliderExpand;
            mem[1152921520075320072] = val_20;
            this.m_ContentBounds = val_21;
            if((this.m_VSliderExpand == false) || (this.vScrollingNeeded == false))
            {
                goto label_23;
            }
            
            UnityEngine.Vector2 val_25 = this.viewRect.sizeDelta;
            UnityEngine.Vector2 val_27 = new UnityEngine.Vector2(x:  -(this.m_VSliderWidth + this.m_VerticalScrollbarSpacing), y:  val_25.y);
            this.viewRect.sizeDelta = new UnityEngine.Vector2() {x = val_27.x, y = val_27.y};
            UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot:  this.m_Content);
            UnityEngine.Rect val_29 = this.viewRect.rect;
            UnityEngine.Vector2 val_30 = val_29.m_XMin.center;
            UnityEngine.Vector3 val_31 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_30.x, y = val_30.y});
            val_68 = val_31.x;
            UnityEngine.Rect val_33 = this.viewRect.rect;
            UnityEngine.Vector2 val_34 = val_33.m_XMin.size;
            UnityEngine.Vector3 val_35 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_34.x, y = val_34.y});
            val_69 = val_35.x;
            val_70 = val_68;
            val_71 = val_31.y;
            UnityEngine.Bounds val_36 = new UnityEngine.Bounds(center:  new UnityEngine.Vector3() {x = val_70, y = val_71, z = val_31.z}, size:  new UnityEngine.Vector3() {x = val_69, y = val_35.y, z = val_35.z});
            mem[1152921520075320096] = val_36.m_Extents.y;
            this.m_ViewBounds = val_36.m_Center.x;
            UnityEngine.Bounds val_37 = this.GetBounds();
            mem[1152921520075320072] = val_38;
            this.m_ContentBounds = val_39;
            goto label_23;
            label_2:
            val_72 = this.m_VSliderExpand;
            label_23:
            if(this.m_HSliderExpand != false)
            {
                    if(this.hScrollingNeeded != false)
            {
                    UnityEngine.Vector2 val_43 = this.viewRect.sizeDelta;
                float val_67 = this.m_HSliderHeight;
                val_67 = val_67 + this.m_HorizontalScrollbarSpacing;
                UnityEngine.Vector2 val_44 = new UnityEngine.Vector2(x:  val_43.x, y:  -val_67);
                this.viewRect.sizeDelta = new UnityEngine.Vector2() {x = val_44.x, y = val_44.y};
                UnityEngine.Rect val_46 = this.viewRect.rect;
                UnityEngine.Vector2 val_47 = val_46.m_XMin.center;
                UnityEngine.Vector3 val_48 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_47.x, y = val_47.y});
                val_68 = val_48.x;
                UnityEngine.Rect val_50 = this.viewRect.rect;
                UnityEngine.Vector2 val_51 = val_50.m_XMin.size;
                UnityEngine.Vector3 val_52 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_51.x, y = val_51.y});
                val_70 = val_68;
                val_71 = val_48.y;
                UnityEngine.Bounds val_53 = new UnityEngine.Bounds(center:  new UnityEngine.Vector3() {x = val_70, y = val_71, z = val_48.z}, size:  new UnityEngine.Vector3() {x = val_52.x, y = val_52.y, z = val_52.z});
                mem[1152921520075320096] = val_53.m_Extents.y;
                this.m_ViewBounds = val_53.m_Center.x;
                UnityEngine.Bounds val_54 = this.GetBounds();
                mem[1152921520075320072] = val_55;
                this.m_ContentBounds = val_56;
            }
            
            }
            
            if(val_72 == false)
            {
                    return;
            }
            
            if(this.vScrollingNeeded == false)
            {
                    return;
            }
            
            UnityEngine.Vector2 val_59 = this.viewRect.sizeDelta;
            if(val_59.x != 0f)
            {
                    return;
            }
            
            UnityEngine.Vector2 val_61 = this.viewRect.sizeDelta;
            if(val_61.y >= 0)
            {
                    return;
            }
            
            val_68 = this.m_VSliderWidth;
            UnityEngine.Vector2 val_64 = this.viewRect.sizeDelta;
            UnityEngine.Vector2 val_66 = new UnityEngine.Vector2(x:  -(val_68 + this.m_VerticalScrollbarSpacing), y:  val_64.y);
            this.viewRect.sizeDelta = new UnityEngine.Vector2() {x = val_66.x, y = val_66.y};
        }
        public virtual void SetLayoutVertical()
        {
            var val_11;
            UnityEngine.Bounds val_12;
            this.UpdateScrollbarLayout();
            UnityEngine.Rect val_2 = this.viewRect.rect;
            UnityEngine.Vector2 val_3 = val_2.m_XMin.center;
            UnityEngine.Vector3 val_4 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
            UnityEngine.Rect val_6 = this.viewRect.rect;
            UnityEngine.Vector2 val_7 = val_6.m_XMin.size;
            UnityEngine.Vector3 val_8 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y});
            UnityEngine.Bounds val_9 = new UnityEngine.Bounds(center:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, size:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
            mem[1152921520075542560] = val_9.m_Extents.y;
            this.m_ViewBounds = val_9.m_Center.x;
            UnityEngine.Bounds val_10 = this.GetBounds();
            mem[1152921520075542536] = val_11;
            this.m_ContentBounds = val_12;
        }
        private void UpdateScrollbarVisibility()
        {
            if(((UnityEngine.Object.op_Implicit(exists:  this.m_VerticalScrollbar)) != false) && (this.m_VerticalScrollbarVisibility != 0))
            {
                    if(this.m_VerticalScrollbar.gameObject.activeSelf ^ this.vScrollingNeeded != false)
            {
                    this.m_VerticalScrollbar.gameObject.SetActive(value:  this.vScrollingNeeded);
            }
            
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.m_HorizontalScrollbar)) == false)
            {
                    return;
            }
            
            if(this.m_HorizontalScrollbarVisibility == 0)
            {
                    return;
            }
            
            if(this.m_HorizontalScrollbar.gameObject.activeSelf ^ this.hScrollingNeeded == false)
            {
                    return;
            }
            
            this.m_HorizontalScrollbar.gameObject.SetActive(value:  this.hScrollingNeeded);
        }
        private void UpdateScrollbarLayout()
        {
            float val_25;
            if((this.m_VSliderExpand != false) && ((UnityEngine.Object.op_Implicit(exists:  this.m_HorizontalScrollbar)) != false))
            {
                    this.m_Tracker.Add(driver:  this, rectTransform:  this.m_HorizontalScrollbarRect, drivenProperties:  2);
                UnityEngine.Vector2 val_2 = this.m_HorizontalScrollbarRect.anchorMin;
                UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  0f, y:  val_2.y);
                this.m_HorizontalScrollbarRect.anchorMin = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
                UnityEngine.Vector2 val_4 = this.m_HorizontalScrollbarRect.anchorMax;
                UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  1f, y:  val_4.y);
                this.m_HorizontalScrollbarRect.anchorMax = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
                UnityEngine.Vector2 val_6 = this.m_HorizontalScrollbarRect.anchoredPosition;
                UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  0f, y:  val_6.y);
                this.m_HorizontalScrollbarRect.anchoredPosition = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
                if(this.vScrollingNeeded != false)
            {
                    UnityEngine.Vector2 val_9 = this.m_HorizontalScrollbarRect.sizeDelta;
                float val_10 = this.m_VerticalScrollbarSpacing + this.m_VSliderWidth;
            }
            else
            {
                    UnityEngine.Vector2 val_11 = this.m_HorizontalScrollbarRect.sizeDelta;
            }
            
                UnityEngine.Vector2 val_12 = new UnityEngine.Vector2(x:  0f, y:  val_11.y);
                this.m_HorizontalScrollbarRect.sizeDelta = new UnityEngine.Vector2() {x = val_12.x, y = val_12.y};
            }
            
            if(this.m_HSliderExpand == false)
            {
                    return;
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.m_VerticalScrollbar)) == false)
            {
                    return;
            }
            
            this.m_Tracker.Add(driver:  this, rectTransform:  this.m_VerticalScrollbarRect, drivenProperties:  4);
            UnityEngine.Vector2 val_14 = this.m_VerticalScrollbarRect.anchorMin;
            UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  val_14.x, y:  0f);
            this.m_VerticalScrollbarRect.anchorMin = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
            UnityEngine.Vector2 val_16 = this.m_VerticalScrollbarRect.anchorMax;
            UnityEngine.Vector2 val_17 = new UnityEngine.Vector2(x:  val_16.x, y:  1f);
            this.m_VerticalScrollbarRect.anchorMax = new UnityEngine.Vector2() {x = val_17.x, y = val_17.y};
            UnityEngine.Vector2 val_18 = this.m_VerticalScrollbarRect.anchoredPosition;
            UnityEngine.Vector2 val_19 = new UnityEngine.Vector2(x:  val_18.x, y:  0f);
            this.m_VerticalScrollbarRect.anchoredPosition = new UnityEngine.Vector2() {x = val_19.x, y = val_19.y};
            UnityEngine.Vector2 val_21 = this.m_VerticalScrollbarRect.sizeDelta;
            if(this.hScrollingNeeded != false)
            {
                    float val_23 = this.m_HSliderHeight;
                val_23 = val_23 + this.m_HorizontalScrollbarSpacing;
                val_25 = -val_23;
            }
            else
            {
                    val_25 = 0f;
            }
            
            UnityEngine.Vector2 val_22 = new UnityEngine.Vector2(x:  val_21.x, y:  val_25);
            this.m_VerticalScrollbarRect.sizeDelta = new UnityEngine.Vector2() {x = val_22.x, y = val_22.y};
        }
        private void UpdateBounds(bool updateItems = False)
        {
            var val_11;
            UnityEngine.Bounds val_12;
            var val_16;
            var val_17;
            float val_26;
            float val_27;
            UnityEngine.Bounds val_29;
            UnityEngine.Bounds val_30;
            float val_31;
            float val_32;
            float val_33;
            float val_34;
            UnityEngine.Rect val_2 = this.viewRect.rect;
            UnityEngine.Vector2 val_3 = val_2.m_XMin.center;
            UnityEngine.Vector3 val_4 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
            val_26 = val_4.x;
            val_27 = val_4.z;
            UnityEngine.Rect val_6 = this.viewRect.rect;
            UnityEngine.Vector2 val_7 = val_6.m_XMin.size;
            UnityEngine.Vector3 val_8 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y});
            UnityEngine.Bounds val_9 = new UnityEngine.Bounds(center:  new UnityEngine.Vector3() {x = val_26, y = val_4.y, z = val_27}, size:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
            mem[1152921520076116032] = val_9.m_Extents.y;
            this.m_ViewBounds = val_9.m_Center.x;
            UnityEngine.Bounds val_10 = this.GetBounds();
            mem[1152921520076116008] = val_11;
            this.m_ContentBounds = val_12;
            if(this.m_Content == 0)
            {
                    return;
            }
            
            val_29 = this.m_ViewBounds;
            val_30 = this.m_ContentBounds;
            if(((UnityEngine.Application.isPlaying != false) && (updateItems != false)) && ((this & 1) != 0))
            {
                    UnityEngine.Canvas.ForceUpdateCanvases();
                UnityEngine.Bounds val_15 = this.GetBounds();
                mem2[0] = val_16;
                mem2[0] = val_17;
            }
            
            UnityEngine.Vector3 val_18 = val_30.size;
            val_31 = val_18.x;
            val_32 = val_18.y;
            val_26 = val_18.z;
            UnityEngine.Vector3 val_19 = val_30.center;
            val_27 = val_19.x;
            val_33 = val_19.y;
            UnityEngine.Vector3 val_20 = val_29.size;
            val_34 = val_20.y;
            UnityEngine.Vector3 val_21 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_20.x, y = val_34, z = val_20.z}, b:  new UnityEngine.Vector3() {x = val_31, y = val_32, z = val_26});
            if(val_21.x > 0f)
            {
                    UnityEngine.Vector2 val_22 = this.m_Content.pivot;
                val_34 = -0.5f;
                val_22.x = val_22.x + val_34;
                val_22.x = val_21.x * val_22.x;
                val_27 = val_27 - val_22.x;
                UnityEngine.Vector3 val_23 = val_29.size;
                val_31 = val_23.x;
            }
            
            if(val_21.y > 0f)
            {
                    UnityEngine.Vector2 val_24 = this.m_Content.pivot;
                float val_26 = -0.5f;
                val_26 = val_24.y + val_26;
                val_26 = val_21.y * val_26;
                val_33 = val_33 - val_26;
                UnityEngine.Vector3 val_25 = val_29.size;
                val_32 = val_25.y;
            }
            
            val_30.size = new UnityEngine.Vector3() {x = val_31, y = val_32, z = val_26};
            val_30.center = new UnityEngine.Vector3() {x = val_27, y = val_33, z = val_19.z};
        }
        private UnityEngine.Bounds GetBounds()
        {
            var val_9;
            float val_16;
            UnityEngine.RectTransform val_17;
            UnityEngine.Bounds val_0;
            val_17 = this.m_Content;
            if(val_17 == 0)
            {
                    val_0.m_Center.x = 0f;
                val_0.m_Center.y = 0f;
                val_0.m_Center.z = 0f;
                val_0.m_Extents.x = 0f;
                val_0.m_Extents.y = 0f;
                val_0.m_Extents.z = 0f;
                return val_0;
            }
            
            UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  3.402823E+38f, y:  3.402823E+38f, z:  3.402823E+38f);
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  -3.402823E+38f, y:  -3.402823E+38f, z:  -3.402823E+38f);
            UnityEngine.Matrix4x4 val_5 = this.viewRect.worldToLocalMatrix;
            this.m_Content.GetWorldCorners(fourCornersArray:  this.m_Corners);
            var val_19 = 0;
            do
            {
                var val_10 = val_19 + 1;
                UnityEngine.Vector3 val_11 = val_9.MultiplyPoint3x4(point:  new UnityEngine.Vector3() {x = this.m_Corners[0], y = this.m_Corners[0], z = this.m_Corners[0]});
                UnityEngine.Vector3 val_12 = UnityEngine.Vector3.Min(lhs:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, rhs:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
                UnityEngine.Vector3 val_13 = UnityEngine.Vector3.Max(lhs:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, rhs:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
                val_19 = val_19 + 1;
                val_17 = 0 + 12;
            }
            while(val_19 < 3);
            
            UnityEngine.Vector3 val_14 = UnityEngine.Vector3.zero;
            UnityEngine.Bounds val_15 = new UnityEngine.Bounds(center:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, size:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
            val_15.m_Center.x.Encapsulate(point:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
            val_16 = val_15.m_Extents.y;
            val_0.m_Extents.y = val_16;
            val_0.m_Center.x = val_15.m_Center.x;
            return val_0;
        }
        private UnityEngine.Bounds GetBounds4Item(int index)
        {
            var val_9;
            int val_19;
            int val_20;
            UnityEngine.Bounds val_0;
            val_19 = index;
            if(this.m_Content == 0)
            {
                goto label_7;
            }
            
            UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  3.402823E+38f, y:  3.402823E+38f, z:  3.402823E+38f);
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  -3.402823E+38f, y:  -3.402823E+38f, z:  -3.402823E+38f);
            UnityEngine.Matrix4x4 val_5 = this.viewRect.worldToLocalMatrix;
            val_20 = this.itemTypeStart;
            val_19 = val_19 - val_20;
            if((<0) || (val_19 >= this.m_Content.childCount))
            {
                goto label_7;
            }
            
            UnityEngine.Transform val_11 = this.m_Content.GetChild(index:  val_19);
            if(val_11 != null)
            {
                    val_19 = (null == null) ? (val_11) : 0;
            }
            else
            {
                    val_19 = 0;
            }
            
            if(val_19 != 0)
            {
                goto label_13;
            }
            
            label_7:
            val_0.m_Center.x = 0f;
            val_0.m_Center.y = 0f;
            val_0.m_Center.z = 0f;
            val_0.m_Extents.x = 0f;
            val_0.m_Extents.y = 0f;
            val_0.m_Extents.z = 0f;
            return val_0;
            label_13:
            val_19.GetWorldCorners(fourCornersArray:  this.m_Corners);
            var val_23 = 0;
            var val_22 = 0;
            do
            {
                var val_13 = val_22 + 1;
                UnityEngine.Vector3 val_14 = val_9.MultiplyPoint3x4(point:  new UnityEngine.Vector3() {x = this.m_Corners[val_23], y = this.m_Corners[val_23], z = this.m_Corners[val_23]});
                UnityEngine.Vector3 val_15 = UnityEngine.Vector3.Min(lhs:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, rhs:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
                UnityEngine.Vector3 val_16 = UnityEngine.Vector3.Max(lhs:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, rhs:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
                val_22 = val_22 + 1;
                val_23 = val_23 + 12;
            }
            while(val_22 < 3);
            
            UnityEngine.Vector3 val_17 = UnityEngine.Vector3.zero;
            UnityEngine.Bounds val_18 = new UnityEngine.Bounds(center:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z}, size:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z});
            val_18.m_Center.x.Encapsulate(point:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
            val_0.m_Extents.y = val_18.m_Extents.y;
            val_0.m_Center.x = val_18.m_Center.x;
            return val_0;
        }
        private UnityEngine.Vector2 CalculateOffset(UnityEngine.Vector2 delta)
        {
            float val_19;
            UnityEngine.Bounds val_20;
            float val_23;
            float val_24;
            float val_25;
            val_19 = delta.y;
            float val_15 = delta.x;
            val_20 = this;
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            val_23 = val_1.x;
            val_24 = val_1.y;
            if(this.m_MovementType == 0)
            {
                    return new UnityEngine.Vector2() {x = val_23, y = val_24};
            }
            
            UnityEngine.Vector3 val_2 = this.m_ContentBounds.min;
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            val_25 = val_3.x;
            UnityEngine.Vector3 val_4 = this.m_ContentBounds.max;
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
            if(this.m_Horizontal != false)
            {
                    val_25 = val_15 + val_25;
                UnityEngine.Vector3 val_6 = this.m_ViewBounds.min;
                if(val_25 > val_6.x)
            {
                    UnityEngine.Vector3 val_7 = this.m_ViewBounds.min;
                val_23 = val_7.x - val_25;
            }
            else
            {
                    val_15 = val_15 + val_5.x;
                UnityEngine.Vector3 val_8 = this.m_ViewBounds.max;
                if(val_15 < 0)
            {
                    UnityEngine.Vector3 val_9 = this.m_ViewBounds.max;
                val_23 = val_9.x - val_15;
            }
            
            }
            
            }
            
            if(this.m_Vertical == false)
            {
                    return new UnityEngine.Vector2() {x = val_23, y = val_24};
            }
            
            val_20 = this.m_ViewBounds;
            float val_10 = val_19 + val_5.y;
            UnityEngine.Vector3 val_11 = val_20.max;
            if(val_10 < 0)
            {
                    UnityEngine.Vector3 val_12 = val_20.max;
                val_24 = val_12.y - val_10;
                return new UnityEngine.Vector2() {x = val_23, y = val_24};
            }
            
            val_19 = val_19 + val_3.y;
            UnityEngine.Vector3 val_13 = val_20.min;
            if(val_19 <= val_13.y)
            {
                    return new UnityEngine.Vector2() {x = val_23, y = val_24};
            }
            
            UnityEngine.Vector3 val_14 = val_20.min;
            val_24 = val_14.y - val_19;
            return new UnityEngine.Vector2() {x = val_23, y = val_24};
        }
        protected void SetDirty()
        {
            if((this & 1) == 0)
            {
                    return;
            }
            
            UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(rect:  this.rectTransform);
        }
        protected void SetDirtyCaching()
        {
            if((this & 1) == 0)
            {
                    return;
            }
            
            UnityEngine.UI.CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(element:  this);
            UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(rect:  this.rectTransform);
        }
        private UnityEngine.Transform UnityEngine.UI.ICanvasElement.get_transform()
        {
            return this.transform;
        }
    
    }

}
