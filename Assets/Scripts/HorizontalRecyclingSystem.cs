using UnityEngine;
public class HorizontalRecyclingSystem : RecyclingSystem
{
    // Fields
    private readonly IRecyclableScrollRectDataSource _dataSource;
    private readonly int _rows;
    private System.Collections.Generic.List<UnityEngine.RectTransform> _cellPool;
    private System.Collections.Generic.List<ICell> _cachedCells;
    private UnityEngine.Bounds _recyclableViewBounds;
    private readonly UnityEngine.Vector3[] _corners;
    private bool _recycling;
    private int currentItemCount;
    private int leftMostCellIndex;
    private int rightMostCellIndex;
    private int _leftMostCellRow;
    private int _RightMostCellRow;
    private UnityEngine.Vector2 zeroVector;
    
    // Methods
    public HorizontalRecyclingSystem(UnityEngine.RectTransform prototypeCell, UnityEngine.RectTransform viewport, UnityEngine.RectTransform content, IRecyclableScrollRectDataSource dataSource, bool isGrid, int rows)
    {
        this._corners = new UnityEngine.Vector3[4];
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.zero;
        this.zeroVector = val_2;
        mem[1152921517108507772] = val_2.y;
        mem[1152921517108507656] = isGrid;
        mem[1152921517108507640] = content;
        mem[1152921517108507648] = prototypeCell;
        mem[1152921517108507632] = viewport;
        this._dataSource = dataSource;
        mem[1152921517108507720] = 0;
        mem[1152921517108507728] = 0;
        this._rows = (isGrid != true) ? rows : (0 + 1);
        this._recyclableViewBounds = 0;
    }
    public override System.Collections.IEnumerator InitCoroutine(System.Action onInitialized, int startPos, bool centered = False)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .onInitialized = onInitialized;
        .startPos = startPos;
        .centered = centered;
        return (System.Collections.IEnumerator)new HorizontalRecyclingSystem.<InitCoroutine>d__14();
    }
    private void SetRecyclingBounds()
    {
        this.GetWorldCorners(fourCornersArray:  this._corners);
        UnityEngine.Vector3 val_5 = this._corners[2];
        UnityEngine.Vector3 val_6 = this._corners[0];
        val_5 = val_5 - val_6;
        float val_1 = S0 * val_5;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_6 - val_1, y:  this._corners[0]);
        this._recyclableViewBounds.min = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        UnityEngine.Vector3 val_8 = this._corners[2];
        UnityEngine.Vector3 val_4;
        val_8 = val_1 + val_8;
        val_4 = new UnityEngine.Vector3(x:  val_8, y:  this._corners[2]);
        this._recyclableViewBounds.max = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
    }
    private void CreateCellPool()
    {
        ICell val_38;
        var val_39;
        System.Action<UnityEngine.RectTransform> val_41;
        float val_42;
        IRecyclableScrollRectDataSource val_44;
        HorizontalRecyclingSystem val_47;
        float val_48;
        float val_49;
        float val_51;
        if(this._cellPool != null)
        {
                val_38 = 1152921504948805632;
            val_39 = null;
            val_39 = null;
            val_41 = HorizontalRecyclingSystem.<>c.<>9__16_0;
            if(val_41 == null)
        {
                System.Action<UnityEngine.RectTransform> val_1 = null;
            val_41 = val_1;
            val_1 = new System.Action<UnityEngine.RectTransform>(object:  HorizontalRecyclingSystem.<>c.__il2cppRuntimeField_static_fields, method:  System.Void HorizontalRecyclingSystem.<>c::<CreateCellPool>b__16_0(UnityEngine.RectTransform item));
            HorizontalRecyclingSystem.<>c.<>9__16_0 = val_41;
        }
        
            this._cellPool.ForEach(action:  val_1);
            this._cellPool.Clear();
            this._cachedCells.Clear();
        }
        else
        {
                this._cachedCells = new System.Collections.Generic.List<ICell>();
            System.Collections.Generic.List<UnityEngine.RectTransform> val_3 = new System.Collections.Generic.List<UnityEngine.RectTransform>();
            this._cellPool = val_3;
        }
        
        val_3.gameObject.SetActive(value:  true);
        this.SetLeftAnchor(rectTransform:  1);
        UnityEngine.Rect val_5 = this.rect;
        float val_6 = val_5.m_XMin.height;
        val_6 = val_6 / (float)this._rows;
        mem[1152921517109196124] = val_6;
        UnityEngine.Vector2 val_7 = val_5.m_XMin.sizeDelta;
        UnityEngine.Vector2 val_8 = val_5.m_XMin.sizeDelta;
        val_8.y = val_7.x / val_8.y;
        val_8.x = val_8.x * val_8.y;
        mem[1152921517109196120] = val_8.x;
        UnityEngine.Rect val_9 = val_5.m_XMin.rect;
        float val_10 = val_9.m_XMin.width;
        val_42 = val_10;
        var val_42 = 0;
        val_42 = val_42 + 1;
        int val_13 = System.Math.Min(val1:  -382500320, val2:  this._dataSource.GetItemCount());
        val_44 = this._dataSource;
        var val_43 = 0;
        val_43 = val_43 + 1;
        if((this.currentItemCount + val_13) > val_44.GetItemCount())
        {
                val_44 = this._dataSource;
            var val_44 = 0;
            val_44 = val_44 + 1;
            this.currentItemCount = val_44.GetItemCount() - val_13;
        }
        
        if((val_13 > 0) || ((S9 * val_42) > 0f))
        {
            goto label_35;
        }
        
        val_47 = 1152921517109196104;
        goto label_36;
        label_35:
        var val_49 = 0;
        val_48 = 0f;
        val_49 = 0f;
        label_61:
        val_44 = this._dataSource;
        var val_45 = 0;
        val_45 = val_45 + 1;
        int val_22 = val_44.GetItemCount();
        if(val_49 >= val_22)
        {
            goto label_42;
        }
        
        UnityEngine.RectTransform val_25 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_22.gameObject).GetComponent<UnityEngine.RectTransform>();
        val_25.name = "Cell";
        UnityEngine.Vector2 val_26 = new UnityEngine.Vector2(x:  val_10, y:  val_9.m_YMin);
        val_25.sizeDelta = new UnityEngine.Vector2() {x = val_26.x, y = val_26.y};
        this._cellPool.Add(item:  val_25);
        val_25.SetParent(parent:  val_25, worldPositionStays:  false);
        float val_46 = (float)-this._RightMostCellRow;
        val_46 = val_26.x * val_46;
        UnityEngine.Vector2 val_27 = new UnityEngine.Vector2(x:  val_49, y:  val_46);
        val_51 = val_27.y;
        val_25.anchoredPosition = new UnityEngine.Vector2() {x = val_27.x, y = val_51};
        int val_47 = this._RightMostCellRow;
        val_47 = val_47 + 1;
        this._RightMostCellRow = val_47;
        if(val_47 >= this._rows)
        {
                this._RightMostCellRow = 0;
            val_42 =  + ;
            UnityEngine.Rect val_32 = val_25.rect;
            val_48 = val_48 + val_32.m_XMin.width;
        }
        
        this._cachedCells.Add(item:  val_25.GetComponent<ICell>());
        val_44 = this._dataSource;
        if(this._cachedCells == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<ICell> val_35 = this._cachedCells - 1;
        val_38 = mem[(UnityEngine.Object.__il2cppRuntimeField_cctor_finished + ((this._cachedCells - 1)) << 3) + 32];
        val_38 = (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + ((this._cachedCells - 1)) << 3) + 32;
        var val_48 = 0;
        val_48 = val_48 + 1;
        val_44.SetCell(cell:  val_38, index:  this.currentItemCount);
        int val_50 = this.currentItemCount;
        val_49 = val_49 + 1;
        val_50 = val_50 + 1;
        this.currentItemCount = val_50;
        if((val_49 < val_13) || (val_48 < 0))
        {
            goto label_61;
        }
        
        label_42:
        val_47 = 1152921517109196104;
        label_36:
        if(!=0)
        {
                int val_51 = this._RightMostCellRow;
            val_51 = val_51 + this._rows;
            val_51 = val_51 - 1;
            val_51 = val_51 - ((val_51 / this._rows) * this._rows);
            this._RightMostCellRow = val_51;
        }
        
        UnityEngine.SceneManagement.Scene val_39 = val_44.gameObject.scene;
        bool val_40 = val_39.m_Handle.IsValid();
        if(val_40 == false)
        {
                return;
        }
        
        val_40.gameObject.SetActive(value:  false);
    }
    public override UnityEngine.Vector2 OnValueChangedListener(UnityEngine.Vector2 direction)
    {
        if(this._recycling != false)
        {
                return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
        }
        
        System.Collections.Generic.List<UnityEngine.RectTransform> val_7 = this._cellPool;
        if((val_7 == null) || (val_7 == null))
        {
                return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
        }
        
        this.SetRecyclingBounds();
        if(direction.x < 0)
        {
                if(val_7 <= this.rightMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_7 = val_7 + ((this.rightMostCellIndex) << 3);
            UnityEngine.Vector3 val_2 = this._recyclableViewBounds.max;
            if((UIExtension.MinX(rectTransform:  0)) < 0)
        {
                UnityEngine.Vector2 val_3 = this.RecycleLeftToRight();
            return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
        }
        
        }
        
        if(direction.x <= 0f)
        {
                return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
        }
        
        if(val_7 <= this.leftMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + ((this.leftMostCellIndex) << 3);
        UnityEngine.Vector3 val_5 = this._recyclableViewBounds.min;
        if((UIExtension.MaxX(rectTransform:  0)) <= val_5.x)
        {
                return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
        }
        
        UnityEngine.Vector2 val_6 = this.RecycleRightToleft();
        return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
    }
    private UnityEngine.Vector2 RecycleLeftToRight()
    {
        float val_34;
        var val_35;
        int val_39;
        System.Collections.Generic.List<UnityEngine.RectTransform> val_40;
        int val_41;
        bool val_34 = true;
        .<>4__this = this;
        this._recycling = val_34;
        .n = 0;
        if(val_34 != 0)
        {
                if(val_34 <= this.rightMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_34 = val_34 + ((this.rightMostCellIndex) << 3);
            UnityEngine.Vector2 val_2 = (true + (this.rightMostCellIndex) << 3) + 32.anchoredPosition;
            val_34 = val_2.x;
        }
        else
        {
                val_34 = 0f;
        }
        
        val_35 = 0;
        label_50:
        if(val_34 <= this.leftMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_34 = val_34 + ((this.leftMostCellIndex) << 3);
        UnityEngine.Vector3 val_4 = this._recyclableViewBounds.min;
        if((UIExtension.MaxX(rectTransform:  (true + (this.leftMostCellIndex) << 3) + 32)) >= 0)
        {
            goto label_15;
        }
        
        var val_35 = 0;
        val_35 = val_35 + 1;
        var val_39 = public System.Int32 IRecyclableScrollRectDataSource::GetItemCount();
        if(this.currentItemCount >= this._dataSource.GetItemCount())
        {
            goto label_15;
        }
        
        if((public System.Int32 IRecyclableScrollRectDataSource::GetItemCount()) == 0)
        {
            goto label_16;
        }
        
        val_39 = this._RightMostCellRow + 1;
        this._RightMostCellRow = val_39;
        if(val_39 >= this._rows)
        {
                int val_36 = (HorizontalRecyclingSystem.<>c__DisplayClass18_0)[1152921517109637520].n;
            val_36 = val_36 + 1;
            .n = val_36;
            this._RightMostCellRow = 0;
            if(val_36 <= this.rightMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_36 = val_36 + ((this.rightMostCellIndex) << 3);
            UnityEngine.Vector2 val_7 = (((HorizontalRecyclingSystem.<>c__DisplayClass18_0)[1152921517109637520].n + 1) + (this.rightMostCellIndex) << 3) + 32.anchoredPosition;
            val_39 = this._RightMostCellRow;
            val_35 = val_35 + 1;
            val_34 = val_7.x + val_7.y;
        }
        
        var val_37 = -val_39;
        if(this._rows <= this.leftMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37 = val_37 + ((this.leftMostCellIndex) << 3);
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  val_34, y:  val_7.x * (float)val_37);
        (this._RightMostCellRow + (this.leftMostCellIndex) << 3) + 32.anchoredPosition = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        int val_38 = this._leftMostCellRow;
        val_38 = val_38 + 1;
        this._leftMostCellRow = val_38;
        if(val_38 < this._rows)
        {
            goto label_25;
        }
        
        this._leftMostCellRow = 0;
        val_35 = val_35 - 1;
        goto label_25;
        label_16:
        if(val_39 <= this.rightMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_39 = val_39 + ((this.rightMostCellIndex) << 3);
        UnityEngine.Vector2 val_10 = (IRecyclableScrollRectDataSource.GetItemCount + (this.rightMostCellIndex) << 3) + 32.anchoredPosition;
        float val_40 = val_10.x;
        if(val_39 <= this.rightMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_39 = val_39 + ((this.rightMostCellIndex) << 3);
        UnityEngine.Vector2 val_11 = ((IRecyclableScrollRectDataSource.GetItemCount + (this.rightMostCellIndex) << 3) + (this.rightMostCellIndex) << 3) + 32.sizeDelta;
        val_40 = this._cellPool;
        val_41 = this.leftMostCellIndex;
        if(val_39 > val_41)
        {
            
        }
        else
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_41 = this.leftMostCellIndex;
            val_40 = this._cellPool;
        }
        
        val_39 = val_39 + (((long)(int)(this.leftMostCellIndex)) << 3);
        val_39 = val_39 + 32;
        if(this._cellPool <= val_41)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_39 = val_39 + (val_41 << 3);
        val_40 = val_40 + val_11.x;
        UnityEngine.Vector2 val_12 = (((((IRecyclableScrollRectDataSource.GetItemCount + (this.rightMostCellIndex) << 3) + (this.rightMostCellIndex) << 3) + ((long)(int)(this.leftMostCellIndex)) << 3) + 32) + (this.leftMostCellIndex) <<  + 32.anchoredPosition;
        UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  val_40, y:  val_12.y);
        val_39.anchoredPosition = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
        label_25:
        if(val_39 <= this.leftMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<UnityEngine.RectTransform> val_14 = this._cellPool + ((this.leftMostCellIndex) << 3);
        var val_41 = 0;
        val_41 = val_41 + 1;
        this._dataSource.SetCell(cell:  this.leftMostCellIndex, index:  this.currentItemCount);
        int val_42 = this.leftMostCellIndex;
        this.rightMostCellIndex = val_42;
        int val_43 = this.currentItemCount;
        val_42 = val_42 + 1;
        val_43 = val_43 + 1;
        this.currentItemCount = val_43;
        this.leftMostCellIndex = (this.leftMostCellIndex + 1) - (((this.leftMostCellIndex + 1) / (Klass->__il2cppRuntimeField_interfaceOffsets[].offset + 1)) * (Klass->__il2cppRuntimeField_interfaceOffsets[].offset + 1));
        if(this._cellPool != null)
        {
            goto label_50;
        }
        
        int val_44 = (HorizontalRecyclingSystem.<>c__DisplayClass18_0)[1152921517109637520].n;
        val_44 = val_44 + 1;
        .n = val_44;
        if(this._cellPool != null)
        {
            goto label_50;
        }
        
        label_15:
        if(val_34 != 0)
        {
                UnityEngine.Vector2 val_17 = this._recyclableViewBounds.sizeDelta;
            UnityEngine.Vector2 val_18 = UnityEngine.Vector2.right;
            UnityEngine.Vector2 val_19 = UnityEngine.Vector2.op_Multiply(d:  0f, a:  new UnityEngine.Vector2() {x = val_18.x, y = val_18.y});
            UnityEngine.Vector2 val_20 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_19.x, y = val_19.y}, d:  val_18.y);
            UnityEngine.Vector2 val_21 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_17.x, y = val_17.y}, b:  new UnityEngine.Vector2() {x = val_20.x, y = val_20.y});
            this._recyclableViewBounds.sizeDelta = new UnityEngine.Vector2() {x = val_21.x, y = val_21.y};
            if(val_35 >= 1)
        {
                int val_45 = (HorizontalRecyclingSystem.<>c__DisplayClass18_0)[1152921517109637520].n;
            val_45 = val_45 - val_35;
            .n = val_45;
        }
        
        }
        
        this._cellPool.ForEach(action:  new System.Action<UnityEngine.RectTransform>(object:  new HorizontalRecyclingSystem.<>c__DisplayClass18_0(), method:  System.Void HorizontalRecyclingSystem.<>c__DisplayClass18_0::<RecycleLeftToRight>b__0(UnityEngine.RectTransform cell)));
        UnityEngine.Vector2 val_23 = this._cellPool.anchoredPosition;
        UnityEngine.Vector2 val_24 = UnityEngine.Vector2.right;
        UnityEngine.Vector2 val_25 = UnityEngine.Vector2.op_Multiply(d:  (float)(HorizontalRecyclingSystem.<>c__DisplayClass18_0)[1152921517109637520].n, a:  new UnityEngine.Vector2() {x = val_24.x, y = val_24.y});
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector2 val_26 = (UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished + (this.leftMostCellIndex) << 3) + 32.sizeDelta;
        UnityEngine.Vector2 val_27 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_25.x, y = val_25.y}, d:  val_26.x);
        UnityEngine.Vector2 val_28 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_23.x, y = val_23.y}, b:  new UnityEngine.Vector2() {x = val_27.x, y = val_27.y});
        this._cellPool.anchoredPosition = new UnityEngine.Vector2() {x = val_28.x, y = val_28.y};
        this._recycling = false;
        UnityEngine.Vector2 val_29 = UnityEngine.Vector2.right;
        UnityEngine.Vector2 val_30 = UnityEngine.Vector2.op_Multiply(d:  (float)(HorizontalRecyclingSystem.<>c__DisplayClass18_0)[1152921517109637520].n, a:  new UnityEngine.Vector2() {x = val_29.x, y = val_29.y});
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector2 val_32 = ((UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished + (this.leftMostCellIndex) << 3) + (this.leftMostCellIndex) << 3) + 32.sizeDelta;
        UnityEngine.Vector2 val_33 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_30.x, y = val_30.y}, d:  val_32.x);
        return new UnityEngine.Vector2() {x = val_33.x, y = val_33.y};
    }
    private UnityEngine.Vector2 RecycleRightToleft()
    {
        System.Collections.Generic.List<UnityEngine.RectTransform> val_36;
        int val_37;
        var val_38;
        System.Collections.Generic.List<UnityEngine.RectTransform> val_39;
        float val_40;
        System.Collections.Generic.List<UnityEngine.RectTransform> val_41;
        int val_42;
        float val_44;
        float val_45;
        int val_46;
        bool val_33 = true;
        .<>4__this = this;
        this._recycling = val_33;
        .n = 0;
        if(val_33 != 0)
        {
                if(val_33 <= this.leftMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_33 = val_33 + ((this.leftMostCellIndex) << 3);
            UnityEngine.Vector2 val_2 = (true + (this.leftMostCellIndex) << 3) + 32.anchoredPosition;
        }
        
        val_36 = this._cellPool;
        val_37 = this.rightMostCellIndex;
        val_38 = 0;
        goto label_8;
        label_44:
        val_39 = this._cellPool;
        if(this.currentItemCount <= val_33)
        {
            goto label_10;
        }
        
        if(this.currentItemCount == 0)
        {
            goto label_11;
        }
        
        int val_34 = this._leftMostCellRow;
        this._leftMostCellRow = val_34 - 1;
        if(this.currentItemCount < 0)
        {
            goto label_12;
        }
        
        val_34 = 1 - val_34;
        val_40 = S0 * (float)val_34;
        goto label_13;
        label_11:
        if(val_33 <= this.leftMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_33 = val_33 + ((this.leftMostCellIndex) << 3);
        UnityEngine.Vector2 val_4 = (true + (this.leftMostCellIndex) << 3) + 32.anchoredPosition;
        float val_40 = val_4.x;
        if(val_33 <= this.leftMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_33 = val_33 + ((this.leftMostCellIndex) << 3);
        UnityEngine.Vector2 val_5 = ((true + (this.leftMostCellIndex) << 3) + (this.leftMostCellIndex) << 3) + 32.sizeDelta;
        val_41 = this._cellPool;
        val_42 = this.rightMostCellIndex;
        if(val_33 <= val_42)
        {
            goto label_20;
        }
        
        goto label_21;
        label_12:
        int val_35 = (HorizontalRecyclingSystem.<>c__DisplayClass19_0)[1152921517109893952].n;
        val_35 = val_35 + 1;
        .n = val_35;
        int val_36 = this._rows;
        val_36 = val_36 - 1;
        this._leftMostCellRow = val_36;
        if(val_36 <= this.leftMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_36 = val_36 + ((this.leftMostCellIndex) << 3);
        UnityEngine.Vector2 val_6 = ((this._rows - 1) + (this.leftMostCellIndex) << 3) + 32.anchoredPosition;
        val_39 = this._cellPool;
        val_38 = 1;
        var val_37 = -this._leftMostCellRow;
        val_40 = S2 * (float)val_37;
        label_13:
        if(val_37 <= this.rightMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37 = val_37 + ((this.rightMostCellIndex) << 3);
        UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  val_6.x - val_6.y, y:  val_40);
        val_44 = val_8.x;
        val_45 = val_8.y;
        (this._leftMostCellRow + (this.rightMostCellIndex) << 3) + 32.anchoredPosition = new UnityEngine.Vector2() {x = val_44, y = val_45};
        int val_38 = this._RightMostCellRow;
        val_38 = val_38 - 1;
        this._RightMostCellRow = val_38;
        if(val_37 >= 0)
        {
            goto label_29;
        }
        
        int val_39 = this._rows;
        val_38 = val_38 - 1;
        val_39 = val_39 - 1;
        this._RightMostCellRow = val_39;
        goto label_29;
        label_20:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_42 = this.rightMostCellIndex;
        val_41 = this._cellPool;
        label_21:
        val_33 = val_33 + (((long)(int)(this.rightMostCellIndex)) << 3);
        val_33 = val_33 + 32;
        if(this._cellPool <= val_42)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_33 = val_33 + (val_42 << 3);
        val_40 = val_40 - val_5.x;
        UnityEngine.Vector2 val_9 = (((((true + (this.leftMostCellIndex) << 3) + (this.leftMostCellIndex) << 3) + ((long)(int)(this.rightMostCellIndex)) << 3) + 32) + (this.rightMostCellIndex) << 3) + 32.anchoredPosition;
        UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  val_40, y:  val_9.y);
        val_44 = val_10.x;
        val_45 = val_10.y;
        val_33.anchoredPosition = new UnityEngine.Vector2() {x = val_44, y = val_45};
        int val_41 = (HorizontalRecyclingSystem.<>c__DisplayClass19_0)[1152921517109893952].n;
        val_41 = val_41 + 1;
        .n = val_41;
        label_29:
        val_46 = this.currentItemCount - 1;
        this.currentItemCount = val_46;
        if(this._cellPool <= this.rightMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_46 = this.currentItemCount;
        }
        
        var val_11 = X11 + ((this.rightMostCellIndex) << 3);
        var val_42 = 0;
        val_42 = val_42 + 1;
        this._dataSource.SetCell(cell:  (X11 + (this.rightMostCellIndex) << 3) + 32, index:  val_46 - W12);
        int val_43 = this.rightMostCellIndex;
        val_36 = this._cellPool;
        this.leftMostCellIndex = val_43;
        val_43 = val_43 + 1152921504949071872;
        val_43 = val_43 - 1;
        val_37 = val_43 - ((val_43 / 1152921504949071872) * 1152921504949071872);
        this.rightMostCellIndex = val_37;
        label_8:
        if(val_43 <= val_37)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_43 = val_43 + (val_37 << 3);
        UnityEngine.Vector3 val_16 = this._recyclableViewBounds.max;
        if((UIExtension.MinX(rectTransform:  (((this.rightMostCellIndex + 1152921504949071872) - 1) + (((this.rightMostCellIndex + 1152921504949071872) - 1) - ((((this.rightMostCellIndex + 1152921504949071872) - 1) / 1152921504949071872) * 11529 + 32)) > val_16.x)
        {
            goto label_44;
        }
        
        label_10:
        if(val_43 != 0)
        {
                UnityEngine.Vector2 val_17 = this._recyclableViewBounds.sizeDelta;
            UnityEngine.Vector2 val_18 = UnityEngine.Vector2.right;
            UnityEngine.Vector2 val_19 = UnityEngine.Vector2.op_Multiply(d:  0f, a:  new UnityEngine.Vector2() {x = val_18.x, y = val_18.y});
            UnityEngine.Vector2 val_20 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_19.x, y = val_19.y}, d:  val_18.y);
            val_44 = val_17.x;
            val_45 = val_17.y;
            UnityEngine.Vector2 val_21 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_44, y = val_45}, b:  new UnityEngine.Vector2() {x = val_20.x, y = val_20.y});
            this._recyclableViewBounds.sizeDelta = new UnityEngine.Vector2() {x = val_21.x, y = val_21.y};
            if(val_38 >= 1)
        {
                int val_44 = (HorizontalRecyclingSystem.<>c__DisplayClass19_0)[1152921517109893952].n;
            val_44 = val_44 - val_38;
            .n = val_44;
        }
        
        }
        
        this._cellPool.ForEach(action:  new System.Action<UnityEngine.RectTransform>(object:  new HorizontalRecyclingSystem.<>c__DisplayClass19_0(), method:  System.Void HorizontalRecyclingSystem.<>c__DisplayClass19_0::<RecycleRightToleft>b__0(UnityEngine.RectTransform cell)));
        UnityEngine.Vector2 val_23 = this._cellPool.anchoredPosition;
        UnityEngine.Vector2 val_24 = UnityEngine.Vector2.right;
        UnityEngine.Vector2 val_25 = UnityEngine.Vector2.op_Multiply(d:  (float)(HorizontalRecyclingSystem.<>c__DisplayClass19_0)[1152921517109893952].n, a:  new UnityEngine.Vector2() {x = val_24.x, y = val_24.y});
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector2 val_26 = (UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished + (this.leftMostCellIndex) << 3) + 32.sizeDelta;
        UnityEngine.Vector2 val_27 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_25.x, y = val_25.y}, d:  val_26.x);
        UnityEngine.Vector2 val_28 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_23.x, y = val_23.y}, b:  new UnityEngine.Vector2() {x = val_27.x, y = val_27.y});
        this._cellPool.anchoredPosition = new UnityEngine.Vector2() {x = val_28.x, y = val_28.y};
        this._recycling = false;
        UnityEngine.Vector2 val_29 = UnityEngine.Vector2.right;
        var val_45 = -((HorizontalRecyclingSystem.<>c__DisplayClass19_0)[1152921517109893952].n);
        UnityEngine.Vector2 val_30 = UnityEngine.Vector2.op_Multiply(d:  (float)val_45, a:  new UnityEngine.Vector2() {x = val_29.x, y = val_29.y});
        if(val_45 <= this.leftMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_45 = val_45 + ((this.leftMostCellIndex) << 3);
        UnityEngine.Vector2 val_31 = ((HorizontalRecyclingSystem.<>c__DisplayClass19_0)[1152921517109893952].n + (this.leftMostCellIndex) << 3) + 32.sizeDelta;
        UnityEngine.Vector2 val_32 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_30.x, y = val_30.y}, d:  val_31.x);
        return new UnityEngine.Vector2() {x = val_32.x, y = val_32.y};
    }
    public override DG.Tweening.Tween ScrollByAmountCell(float amountCell, float duration)
    {
        float val_4 = amountCell;
        HorizontalRecyclingSystem.<>c__DisplayClass20_0 val_1 = new HorizontalRecyclingSystem.<>c__DisplayClass20_0();
        .<>4__this = this;
        .currentLength = 0f;
        val_4 = amountCell * val_4;
        return DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single HorizontalRecyclingSystem.<>c__DisplayClass20_0::<ScrollByAmountCell>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void HorizontalRecyclingSystem.<>c__DisplayClass20_0::<ScrollByAmountCell>b__1(float x)), endValue:  val_4, duration:  duration);
    }
    public override ICell FindCellByIndex(int Id)
    {
        System.Collections.Generic.List<ICell> val_2;
        System.Collections.Generic.List<ICell> val_3;
        var val_4;
        var val_5;
        val_2 = Id;
        bool val_2 = true;
        val_3 = this._cachedCells;
        var val_6 = 0;
        label_10:
        if(val_6 >= val_2)
        {
            goto label_2;
        }
        
        if(val_2 <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + 0;
        val_3 = mem[(true + 0) + 32];
        val_3 = (true + 0) + 32;
        var val_5 = val_3;
        if(((true + 0) + 32 + 294) == 0)
        {
            goto label_8;
        }
        
        var val_3 = (true + 0) + 32 + 176;
        var val_4 = 0;
        val_3 = val_3 + 8;
        label_7:
        if((((true + 0) + 32 + 176 + 8) + -8) == null)
        {
            goto label_6;
        }
        
        val_4 = val_4 + 1;
        val_3 = val_3 + 16;
        if(val_4 < ((true + 0) + 32 + 294))
        {
            goto label_7;
        }
        
        goto label_8;
        label_6:
        val_5 = val_5 + ((((true + 0) + 32 + 176 + 8)) << 4);
        val_4 = val_5 + 304;
        label_8:
        if(val_3.GetId() == val_2)
        {
            goto label_9;
        }
        
        val_6 = val_6 + 1;
        if(this._cachedCells != null)
        {
            goto label_10;
        }
        
        label_2:
        val_5 = 0;
        return (ICell)public System.Int32 ICell::GetId().__il2cppRuntimeField_20;
        label_9:
        val_2 = this._cachedCells;
        if((public System.Int32 ICell::GetId()) > val_6)
        {
                return (ICell)public System.Int32 ICell::GetId().__il2cppRuntimeField_20;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        return (ICell)public System.Int32 ICell::GetId().__il2cppRuntimeField_20;
    }
    private void SetLeftAnchor(UnityEngine.RectTransform rectTransform)
    {
        UnityEngine.Rect val_1 = rectTransform.rect;
        UnityEngine.Rect val_3 = rectTransform.rect;
        if(W8 != 0)
        {
            
        }
        
        UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  0f, y:  0.5f);
        rectTransform.anchorMin = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        rectTransform.anchorMax = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        rectTransform.pivot = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  val_1.m_XMin.width, y:  val_3.m_XMin.height);
        rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
    }
    public void OnDrawGizmos()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.green;
        UnityEngine.Gizmos.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        UnityEngine.Vector3 val_2 = this._recyclableViewBounds.min;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  0f, y:  2000f);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, b:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        UnityEngine.Vector3 val_5 = this._recyclableViewBounds.min;
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  0f, y:  2000f);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, b:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
        UnityEngine.Gizmos.DrawLine(from:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, to:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        UnityEngine.Color val_8 = UnityEngine.Color.red;
        UnityEngine.Gizmos.color = new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a};
        UnityEngine.Vector3 val_9 = this._recyclableViewBounds.max;
        UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  0f, y:  2000f);
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, b:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
        UnityEngine.Vector3 val_12 = this._recyclableViewBounds.max;
        UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  0f, y:  2000f);
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, b:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
        UnityEngine.Gizmos.DrawLine(from:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, to:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
    }

}
