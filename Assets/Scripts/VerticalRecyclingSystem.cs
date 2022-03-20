using UnityEngine;
public class VerticalRecyclingSystem : RecyclingSystem
{
    // Fields
    private readonly IRecyclableScrollRectDataSource _dataSource;
    private readonly int _coloumns;
    private System.Collections.Generic.List<UnityEngine.RectTransform> _cellPool;
    private System.Collections.Generic.List<ICell> _cachedCells;
    private UnityEngine.Bounds _recyclableViewBounds;
    private readonly UnityEngine.Vector3[] _corners;
    private bool _recycling;
    private int startPos;
    private int currentItemCount;
    private int topMostCellIndex;
    private int bottomMostCellIndex;
    private int _topMostCellColoumn;
    private int _bottomMostCellColoumn;
    private UnityEngine.Vector2 zeroVector;
    
    // Methods
    public VerticalRecyclingSystem(UnityEngine.RectTransform prototypeCell, UnityEngine.RectTransform viewport, UnityEngine.RectTransform content, IRecyclableScrollRectDataSource dataSource, bool isGrid, int coloumns)
    {
        this._corners = new UnityEngine.Vector3[4];
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.zero;
        this.zeroVector = val_2;
        mem[1152921517115273488] = val_2.y;
        mem[1152921517115273368] = isGrid;
        mem[1152921517115273352] = content;
        mem[1152921517115273360] = prototypeCell;
        mem[1152921517115273344] = viewport;
        this._dataSource = dataSource;
        mem[1152921517115273432] = 0;
        mem[1152921517115273440] = 0;
        this._coloumns = (isGrid != true) ? coloumns : (0 + 1);
        this._recyclableViewBounds = 0;
    }
    public override System.Collections.IEnumerator InitCoroutine(System.Action onInitialized, int m_startPos, bool centered = False)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .onInitialized = onInitialized;
        .m_startPos = m_startPos;
        .centered = centered;
        return (System.Collections.IEnumerator)new VerticalRecyclingSystem.<InitCoroutine>d__15();
    }
    private void SetRecyclingBounds()
    {
        this.GetWorldCorners(fourCornersArray:  this._corners);
        UnityEngine.Vector3 val_4 = this._corners[2];
        UnityEngine.Vector3 val_6 = this._corners[0];
        val_4 = val_4 - val_6;
        float val_1 = S3 * val_4;
        val_4 = val_6 - val_1;
        UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  this._corners[0], y:  val_4);
        this._recyclableViewBounds.min = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        UnityEngine.Vector3 val_8 = this._corners[2];
        UnityEngine.Vector3 val_3;
        val_8 = val_1 + val_8;
        val_3 = new UnityEngine.Vector3(x:  this._corners[2], y:  val_8);
        this._recyclableViewBounds.max = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    private void CreateCellPool()
    {
        ICell val_46;
        var val_47;
        System.Action<UnityEngine.RectTransform> val_49;
        float val_50;
        float val_51;
        float val_54;
        var val_58;
        float val_59;
        float val_60;
        IRecyclableScrollRectDataSource val_64;
        if(this._cellPool != null)
        {
                val_46 = 1152921504949497856;
            val_47 = null;
            val_47 = null;
            val_49 = VerticalRecyclingSystem.<>c.<>9__17_0;
            if(val_49 == null)
        {
                System.Action<UnityEngine.RectTransform> val_1 = null;
            val_49 = val_1;
            val_1 = new System.Action<UnityEngine.RectTransform>(object:  VerticalRecyclingSystem.<>c.__il2cppRuntimeField_static_fields, method:  System.Void VerticalRecyclingSystem.<>c::<CreateCellPool>b__17_0(UnityEngine.RectTransform item));
            VerticalRecyclingSystem.<>c.<>9__17_0 = val_49;
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
        
        UnityEngine.GameObject val_4 = val_3.gameObject;
        val_4.SetActive(value:  true);
        if((public System.Void System.Collections.Generic.List<UnityEngine.RectTransform>::.ctor()) != 0)
        {
                val_4.SetTopLeftAnchor(rectTransform:  1);
        }
        else
        {
                val_4.SetTopAnchor(rectTransform:  1);
        }
        
        UnityEngine.Rect val_5 = val_4.rect;
        float val_6 = val_5.m_XMin.width;
        val_6 = val_6 / (float)this._coloumns;
        mem[1152921517115962808] = val_6;
        UnityEngine.Vector2 val_7 = val_5.m_XMin.sizeDelta;
        UnityEngine.Vector2 val_8 = val_5.m_XMin.sizeDelta;
        val_8.x = val_7.y / val_8.x;
        val_51 = val_8.y * val_8.x;
        mem[1152921517115962812] = val_51;
        UnityEngine.Rect val_9 = val_5.m_XMin.rect;
        float val_10 = val_9.m_XMin.height;
        val_54 = val_10;
        var val_52 = 0;
        val_52 = val_52 + 1;
        int val_13 = System.Math.Min(val1:  -375733632, val2:  this._dataSource.GetItemCount());
        var val_53 = 0;
        val_53 = val_53 + 1;
        if((this.currentItemCount + val_13) > this._dataSource.GetItemCount())
        {
                var val_54 = 0;
            val_54 = val_54 + 1;
            this.currentItemCount = this._dataSource.GetItemCount() - val_13;
        }
        
        if(val_13 <= 0)
        {
                if((S9 * val_54) <= 0f)
        {
            goto label_43;
        }
        
        }
        
        val_58 = 0;
        val_59 = 0f;
        val_60 = 0f;
        label_62:
        var val_55 = 0;
        val_55 = val_55 + 1;
        int val_22 = this._dataSource.GetItemCount();
        if(val_58 >= val_22)
        {
            goto label_43;
        }
        
        UnityEngine.RectTransform val_25 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_22.gameObject).GetComponent<UnityEngine.RectTransform>();
        val_25.name = "Cell";
        UnityEngine.Vector2 val_26 = new UnityEngine.Vector2(x:  val_10, y:  val_9.m_YMin);
        val_25.sizeDelta = new UnityEngine.Vector2() {x = val_26.x, y = val_26.y};
        this._cellPool.Add(item:  val_25);
        val_25.SetParent(parent:  val_25, worldPositionStays:  false);
        float val_56 = (float)this._bottomMostCellColoumn;
        val_56 = val_26.y * val_56;
        UnityEngine.Vector2 val_27 = new UnityEngine.Vector2(x:  val_56, y:  val_60);
        val_51 = val_27.x;
        val_50 = val_27.y;
        val_25.anchoredPosition = new UnityEngine.Vector2() {x = val_51, y = val_50};
        int val_57 = this._bottomMostCellColoumn;
        val_57 = val_57 + 1;
        this._bottomMostCellColoumn = val_57;
        if(val_57 >= this._coloumns)
        {
                this._bottomMostCellColoumn = 0;
            val_54 =  - ;
            UnityEngine.Rect val_32 = val_25.rect;
            val_59 = val_59 + val_32.m_XMin.height;
        }
        
        this._cachedCells.Add(item:  val_25.GetComponent<ICell>());
        if(this._cachedCells == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<ICell> val_35 = this._cachedCells - 1;
        val_46 = mem[(UnityEngine.Object.__il2cppRuntimeField_cctor_finished + ((this._cachedCells - 1)) << 3) + 32];
        val_46 = (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + ((this._cachedCells - 1)) << 3) + 32;
        var val_58 = 0;
        val_58 = val_58 + 1;
        this._dataSource.SetCell(cell:  val_46, index:  this.currentItemCount);
        int val_59 = this.currentItemCount;
        val_58 = val_58 + 1;
        val_59 = val_59 + 1;
        this.currentItemCount = val_59;
        if((val_58 < val_13) || (val_59 < 0))
        {
            goto label_62;
        }
        
        label_43:
        if(val_59 != 0)
        {
                int val_60 = this._bottomMostCellColoumn;
            val_60 = val_60 + this._coloumns;
            val_60 = val_60 - 1;
            val_60 = val_60 - ((val_60 / this._coloumns) * this._coloumns);
            this._bottomMostCellColoumn = val_60;
        }
        
        UnityEngine.SceneManagement.Scene val_39 = this._dataSource.gameObject.scene;
        bool val_40 = val_39.m_Handle.IsValid();
        if(val_40 != false)
        {
                val_40.gameObject.SetActive(value:  false);
        }
        
        val_64 = this._dataSource;
        var val_61 = 0;
        val_61 = val_61 + 1;
        if((this.startPos + val_13) <= val_64.GetItemCount())
        {
                return;
        }
        
        var val_62 = 0;
        val_62 = val_62 + 1;
        int val_47 = this.startPos + val_13;
        val_47 = val_47 - this._dataSource.GetItemCount();
        UnityEngine.Vector2 val_48 = this._dataSource.anchoredPosition;
        val_54 = val_48.x;
        UnityEngine.Vector2 val_50 = new UnityEngine.Vector2(x:  0f, y:  val_48.x * (float)val_47);
        UnityEngine.Vector2 val_51 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_54, y = val_48.y}, b:  new UnityEngine.Vector2() {x = val_50.x, y = val_50.y});
        this._dataSource.anchoredPosition = new UnityEngine.Vector2() {x = val_51.x, y = val_51.y};
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
        if(direction.y > 0f)
        {
                if(val_7 <= this.bottomMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_7 = val_7 + ((this.bottomMostCellIndex) << 3);
            UnityEngine.Vector3 val_2 = this._recyclableViewBounds.min;
            if((UIExtension.MaxY(rectTransform:  0)) > val_2.y)
        {
                UnityEngine.Vector2 val_3 = this.RecycleTopToBottom();
            return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
        }
        
        }
        
        if(direction.y >= 0)
        {
                return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
        }
        
        if(val_7 <= this.topMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + ((this.topMostCellIndex) << 3);
        UnityEngine.Vector3 val_5 = this._recyclableViewBounds.max;
        if((UIExtension.MinY(rectTransform:  0)) >= 0)
        {
                return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
        }
        
        UnityEngine.Vector2 val_6 = this.RecycleBottomToTop();
        return new UnityEngine.Vector2() {x = this.zeroVector, y = direction.y};
    }
    private UnityEngine.Vector2 RecycleTopToBottom()
    {
        float val_33;
        var val_34;
        int val_38;
        System.Collections.Generic.List<UnityEngine.RectTransform> val_39;
        int val_40;
        bool val_33 = true;
        .<>4__this = this;
        this._recycling = val_33;
        .n = 0;
        if(val_33 != 0)
        {
                if(val_33 <= this.bottomMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_33 = val_33 + ((this.bottomMostCellIndex) << 3);
            UnityEngine.Vector2 val_2 = (true + (this.bottomMostCellIndex) << 3) + 32.anchoredPosition;
            val_33 = val_2.y;
        }
        else
        {
                val_33 = 0f;
        }
        
        val_34 = 0;
        label_50:
        if(val_33 <= this.topMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_33 = val_33 + ((this.topMostCellIndex) << 3);
        UnityEngine.Vector3 val_4 = this._recyclableViewBounds.max;
        if((UIExtension.MinY(rectTransform:  (true + (this.topMostCellIndex) << 3) + 32)) <= val_4.y)
        {
            goto label_15;
        }
        
        var val_34 = 0;
        val_34 = val_34 + 1;
        var val_37 = public System.Int32 IRecyclableScrollRectDataSource::GetItemCount();
        if(this.currentItemCount >= this._dataSource.GetItemCount())
        {
            goto label_15;
        }
        
        if((public System.Int32 IRecyclableScrollRectDataSource::GetItemCount()) == 0)
        {
            goto label_16;
        }
        
        val_38 = this._bottomMostCellColoumn + 1;
        this._bottomMostCellColoumn = val_38;
        if(val_38 >= this._coloumns)
        {
                int val_35 = (VerticalRecyclingSystem.<>c__DisplayClass19_0)[1152921517116412432].n;
            val_35 = val_35 + 1;
            .n = val_35;
            this._bottomMostCellColoumn = 0;
            if(val_35 <= this.bottomMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_35 = val_35 + ((this.bottomMostCellIndex) << 3);
            UnityEngine.Vector2 val_7 = (((VerticalRecyclingSystem.<>c__DisplayClass19_0)[1152921517116412432].n + 1) + (this.bottomMostCellIndex) << 3) + 32.anchoredPosition;
            val_38 = this._bottomMostCellColoumn;
            val_34 = val_34 + 1;
            val_33 = val_7.y - val_7.x;
        }
        
        if(this._coloumns <= this.topMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_38 = val_38 + ((this.topMostCellIndex) << 3);
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  val_7.x * (float)val_38, y:  val_33);
        (this._bottomMostCellColoumn + (this.topMostCellIndex) << 3) + 32.anchoredPosition = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        int val_36 = this._topMostCellColoumn;
        val_36 = val_36 + 1;
        this._topMostCellColoumn = val_36;
        if(val_36 < this._coloumns)
        {
            goto label_25;
        }
        
        this._topMostCellColoumn = 0;
        val_34 = val_34 - 1;
        goto label_25;
        label_16:
        if(val_37 <= this.bottomMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37 = val_37 + ((this.bottomMostCellIndex) << 3);
        UnityEngine.Vector2 val_10 = (IRecyclableScrollRectDataSource.GetItemCount + (this.bottomMostCellIndex) << 3) + 32.anchoredPosition;
        float val_38 = val_10.y;
        if(val_37 <= this.bottomMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37 = val_37 + ((this.bottomMostCellIndex) << 3);
        UnityEngine.Vector2 val_11 = ((IRecyclableScrollRectDataSource.GetItemCount + (this.bottomMostCellIndex) << 3) + (this.bottomMostCellIndex) << 3) + 32.sizeDelta;
        val_39 = this._cellPool;
        val_40 = this.topMostCellIndex;
        if(val_37 > val_40)
        {
            
        }
        else
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_40 = this.topMostCellIndex;
            val_39 = this._cellPool;
        }
        
        val_37 = val_37 + (((long)(int)(this.topMostCellIndex)) << 3);
        val_37 = val_37 + 32;
        if(this._cellPool <= val_40)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37 = val_37 + (val_40 << 3);
        val_38 = val_38 - val_11.y;
        UnityEngine.Vector2 val_12 = (((((IRecyclableScrollRectDataSource.GetItemCount + (this.bottomMostCellIndex) << 3) + (this.bottomMostCellIndex) << 3) + ((long)(int)(this.topMostCellIndex)) << 3) + 32) + (this.topMostCellIndex) <<  + 32.anchoredPosition;
        UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  val_12.x, y:  val_38);
        val_37.anchoredPosition = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
        label_25:
        if(val_37 <= this.topMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<UnityEngine.RectTransform> val_14 = this._cellPool + ((this.topMostCellIndex) << 3);
        var val_39 = 0;
        val_39 = val_39 + 1;
        this._dataSource.SetCell(cell:  this.topMostCellIndex, index:  this.currentItemCount);
        int val_40 = this.topMostCellIndex;
        this.bottomMostCellIndex = val_40;
        int val_41 = this.currentItemCount;
        val_40 = val_40 + 1;
        val_41 = val_41 + 1;
        this.currentItemCount = val_41;
        this.topMostCellIndex = (this.topMostCellIndex + 1) - (((this.topMostCellIndex + 1) / (Klass->__il2cppRuntimeField_interfaceOffsets[].offset + 1)) * (Klass->__il2cppRuntimeField_interfaceOffsets[].offset + 1));
        if(this._cellPool != null)
        {
            goto label_50;
        }
        
        int val_42 = (VerticalRecyclingSystem.<>c__DisplayClass19_0)[1152921517116412432].n;
        val_42 = val_42 + 1;
        .n = val_42;
        if(this._cellPool != null)
        {
            goto label_50;
        }
        
        label_15:
        if(val_33 != 0)
        {
                UnityEngine.Vector2 val_17 = this._recyclableViewBounds.sizeDelta;
            UnityEngine.Vector2 val_18 = UnityEngine.Vector2.up;
            UnityEngine.Vector2 val_19 = UnityEngine.Vector2.op_Multiply(d:  0f, a:  new UnityEngine.Vector2() {x = val_18.x, y = val_18.y});
            UnityEngine.Vector2 val_20 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_19.x, y = val_19.y}, d:  val_18.y);
            UnityEngine.Vector2 val_21 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_17.x, y = val_17.y}, b:  new UnityEngine.Vector2() {x = val_20.x, y = val_20.y});
            this._recyclableViewBounds.sizeDelta = new UnityEngine.Vector2() {x = val_21.x, y = val_21.y};
            if(val_34 >= 1)
        {
                int val_43 = (VerticalRecyclingSystem.<>c__DisplayClass19_0)[1152921517116412432].n;
            val_43 = val_43 - val_34;
            .n = val_43;
        }
        
        }
        
        this._cellPool.ForEach(action:  new System.Action<UnityEngine.RectTransform>(object:  new VerticalRecyclingSystem.<>c__DisplayClass19_0(), method:  System.Void VerticalRecyclingSystem.<>c__DisplayClass19_0::<RecycleTopToBottom>b__0(UnityEngine.RectTransform cell)));
        UnityEngine.Vector2 val_23 = this._cellPool.anchoredPosition;
        UnityEngine.Vector2 val_24 = UnityEngine.Vector2.up;
        UnityEngine.Vector2 val_25 = UnityEngine.Vector2.op_Multiply(d:  (float)(VerticalRecyclingSystem.<>c__DisplayClass19_0)[1152921517116412432].n, a:  new UnityEngine.Vector2() {x = val_24.x, y = val_24.y});
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector2 val_26 = (UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished + (this.topMostCellIndex) << 3) + 32.sizeDelta;
        UnityEngine.Vector2 val_27 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_25.x, y = val_25.y}, d:  val_26.y);
        UnityEngine.Vector2 val_28 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_23.x, y = val_23.y}, b:  new UnityEngine.Vector2() {x = val_27.x, y = val_27.y});
        this._cellPool.anchoredPosition = new UnityEngine.Vector2() {x = val_28.x, y = val_28.y};
        this._recycling = false;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector2 val_30 = ((UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished + (this.topMostCellIndex) << 3) + (this.topMostCellIndex) << 3) + 32.sizeDelta;
        val_30.y = val_30.y * ((float)(VerticalRecyclingSystem.<>c__DisplayClass19_0)[1152921517116412432].n);
        UnityEngine.Vector2 val_31 = new UnityEngine.Vector2(x:  0f, y:  val_30.y);
        UnityEngine.Vector2 val_32 = UnityEngine.Vector2.op_UnaryNegation(a:  new UnityEngine.Vector2() {x = val_31.x, y = val_31.y});
        return new UnityEngine.Vector2() {x = val_32.x, y = val_32.y};
    }
    private UnityEngine.Vector2 RecycleBottomToTop()
    {
        System.Collections.Generic.List<UnityEngine.RectTransform> val_34;
        int val_35;
        var val_36;
        System.Collections.Generic.List<UnityEngine.RectTransform> val_37;
        float val_38;
        System.Collections.Generic.List<UnityEngine.RectTransform> val_39;
        int val_40;
        float val_42;
        float val_43;
        int val_44;
        bool val_31 = true;
        .<>4__this = this;
        this._recycling = val_31;
        .n = 0;
        if(val_31 != 0)
        {
                if(val_31 <= this.topMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_31 = val_31 + ((this.topMostCellIndex) << 3);
            UnityEngine.Vector2 val_2 = (true + (this.topMostCellIndex) << 3) + 32.anchoredPosition;
        }
        
        val_34 = this._cellPool;
        val_35 = this.bottomMostCellIndex;
        val_36 = 0;
        goto label_8;
        label_44:
        val_37 = this._cellPool;
        if(this.currentItemCount <= val_31)
        {
            goto label_10;
        }
        
        if(this.currentItemCount == 0)
        {
            goto label_11;
        }
        
        int val_32 = this._topMostCellColoumn;
        val_32 = val_32 - 1;
        this._topMostCellColoumn = val_32;
        if(this.currentItemCount < 0)
        {
            goto label_12;
        }
        
        val_38 = S0 * (float)val_32;
        goto label_13;
        label_11:
        if(val_31 <= this.topMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_31 = val_31 + ((this.topMostCellIndex) << 3);
        UnityEngine.Vector2 val_3 = (true + (this.topMostCellIndex) << 3) + 32.anchoredPosition;
        float val_37 = val_3.y;
        if(val_31 <= this.topMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_31 = val_31 + ((this.topMostCellIndex) << 3);
        UnityEngine.Vector2 val_4 = ((true + (this.topMostCellIndex) << 3) + (this.topMostCellIndex) << 3) + 32.sizeDelta;
        val_39 = this._cellPool;
        val_40 = this.bottomMostCellIndex;
        if(val_31 <= val_40)
        {
            goto label_20;
        }
        
        goto label_21;
        label_12:
        int val_33 = (VerticalRecyclingSystem.<>c__DisplayClass20_0)[1152921517116668864].n;
        val_33 = val_33 + 1;
        .n = val_33;
        int val_34 = this._coloumns;
        val_34 = val_34 - 1;
        this._topMostCellColoumn = val_34;
        if(val_34 <= this.topMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_34 = val_34 + ((this.topMostCellIndex) << 3);
        UnityEngine.Vector2 val_5 = ((this._coloumns - 1) + (this.topMostCellIndex) << 3) + 32.anchoredPosition;
        val_37 = this._cellPool;
        val_36 = 1;
        val_38 = S3 * (float)this._topMostCellColoumn;
        label_13:
        if(val_34 <= this.bottomMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Vector2 val_7;
        val_34 = val_34 + ((this.bottomMostCellIndex) << 3);
        val_7 = new UnityEngine.Vector2(x:  val_38, y:  val_5.y + val_5.x);
        val_42 = val_7.x;
        val_43 = val_7.y;
        (((this._coloumns - 1) + (this.topMostCellIndex) << 3) + (this.bottomMostCellIndex) << 3) + 32.anchoredPosition = new UnityEngine.Vector2() {x = val_42, y = val_43};
        int val_35 = this._bottomMostCellColoumn;
        val_35 = val_35 - 1;
        this._bottomMostCellColoumn = val_35;
        if(val_34 >= 0)
        {
            goto label_29;
        }
        
        int val_36 = this._coloumns;
        val_36 = val_36 - 1;
        val_36 = val_36 - 1;
        this._bottomMostCellColoumn = val_36;
        goto label_29;
        label_20:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_40 = this.bottomMostCellIndex;
        val_39 = this._cellPool;
        label_21:
        val_31 = val_31 + (((long)(int)(this.bottomMostCellIndex)) << 3);
        val_31 = val_31 + 32;
        if(this._cellPool <= val_40)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_31 = val_31 + (val_40 << 3);
        val_37 = val_37 + val_4.y;
        UnityEngine.Vector2 val_8 = (((((true + (this.topMostCellIndex) << 3) + (this.topMostCellIndex) << 3) + ((long)(int)(this.bottomMostCellIndex)) << 3) + 32) + (this.bottomMostCellIndex) << 3) + 32.anchoredPosition;
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  val_8.x, y:  val_37);
        val_42 = val_9.x;
        val_43 = val_9.y;
        val_31.anchoredPosition = new UnityEngine.Vector2() {x = val_42, y = val_43};
        int val_38 = (VerticalRecyclingSystem.<>c__DisplayClass20_0)[1152921517116668864].n;
        val_38 = val_38 + 1;
        .n = val_38;
        label_29:
        val_44 = this.currentItemCount - 1;
        this.currentItemCount = val_44;
        if(this._cellPool <= this.bottomMostCellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_44 = this.currentItemCount;
        }
        
        var val_10 = X11 + ((this.bottomMostCellIndex) << 3);
        var val_39 = 0;
        val_39 = val_39 + 1;
        this._dataSource.SetCell(cell:  (X11 + (this.bottomMostCellIndex) << 3) + 32, index:  val_44 - W12);
        int val_40 = this.bottomMostCellIndex;
        val_34 = this._cellPool;
        this.topMostCellIndex = val_40;
        val_40 = val_40 + 1152921504949071872;
        val_40 = val_40 - 1;
        val_35 = val_40 - ((val_40 / 1152921504949071872) * 1152921504949071872);
        this.bottomMostCellIndex = val_35;
        label_8:
        if(val_40 <= val_35)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_40 = val_40 + (val_35 << 3);
        UnityEngine.Vector3 val_15 = this._recyclableViewBounds.min;
        if((UIExtension.MaxY(rectTransform:  (((this.bottomMostCellIndex + 1152921504949071872) - 1) + (((this.bottomMostCellIndex + 1152921504949071872) - 1) - ((((this.bottomMostCellIndex + 1152921504949071872) - 1) / 1152921504949071872) * 11 + 32)) < 0)
        {
            goto label_44;
        }
        
        label_10:
        if(val_40 != 0)
        {
                UnityEngine.Vector2 val_16 = this._recyclableViewBounds.sizeDelta;
            UnityEngine.Vector2 val_17 = UnityEngine.Vector2.up;
            UnityEngine.Vector2 val_18 = UnityEngine.Vector2.op_Multiply(d:  0f, a:  new UnityEngine.Vector2() {x = val_17.x, y = val_17.y});
            UnityEngine.Vector2 val_19 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_18.x, y = val_18.y}, d:  val_17.y);
            val_42 = val_16.x;
            val_43 = val_16.y;
            UnityEngine.Vector2 val_20 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_42, y = val_43}, b:  new UnityEngine.Vector2() {x = val_19.x, y = val_19.y});
            this._recyclableViewBounds.sizeDelta = new UnityEngine.Vector2() {x = val_20.x, y = val_20.y};
            if(val_36 >= 1)
        {
                int val_41 = (VerticalRecyclingSystem.<>c__DisplayClass20_0)[1152921517116668864].n;
            val_41 = val_41 - val_36;
            .n = val_41;
        }
        
        }
        
        this._cellPool.ForEach(action:  new System.Action<UnityEngine.RectTransform>(object:  new VerticalRecyclingSystem.<>c__DisplayClass20_0(), method:  System.Void VerticalRecyclingSystem.<>c__DisplayClass20_0::<RecycleBottomToTop>b__0(UnityEngine.RectTransform cell)));
        UnityEngine.Vector2 val_22 = this._cellPool.anchoredPosition;
        UnityEngine.Vector2 val_23 = UnityEngine.Vector2.up;
        UnityEngine.Vector2 val_24 = UnityEngine.Vector2.op_Multiply(d:  (float)(VerticalRecyclingSystem.<>c__DisplayClass20_0)[1152921517116668864].n, a:  new UnityEngine.Vector2() {x = val_23.x, y = val_23.y});
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector2 val_25 = (UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished + (this.topMostCellIndex) << 3) + 32.sizeDelta;
        UnityEngine.Vector2 val_26 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_24.x, y = val_24.y}, d:  val_25.y);
        UnityEngine.Vector2 val_27 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_22.x, y = val_22.y}, b:  new UnityEngine.Vector2() {x = val_26.x, y = val_26.y});
        this._cellPool.anchoredPosition = new UnityEngine.Vector2() {x = val_27.x, y = val_27.y};
        this._recycling = false;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector2 val_29 = ((UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished + (this.topMostCellIndex) << 3) + (this.topMostCellIndex) << 3) + 32.sizeDelta;
        val_29.y = val_29.y * ((float)(VerticalRecyclingSystem.<>c__DisplayClass20_0)[1152921517116668864].n);
        UnityEngine.Vector2 val_30 = new UnityEngine.Vector2(x:  0f, y:  val_29.y);
        return new UnityEngine.Vector2() {x = val_30.x, y = val_30.y};
    }
    public override DG.Tweening.Tween ScrollByAmountCell(float amountCell, float duration)
    {
        float val_4 = amountCell;
        VerticalRecyclingSystem.<>c__DisplayClass21_0 val_1 = new VerticalRecyclingSystem.<>c__DisplayClass21_0();
        .<>4__this = this;
        .currentLength = 0f;
        val_4 = amountCell * val_4;
        return DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single VerticalRecyclingSystem.<>c__DisplayClass21_0::<ScrollByAmountCell>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void VerticalRecyclingSystem.<>c__DisplayClass21_0::<ScrollByAmountCell>b__1(float x)), endValue:  val_4, duration:  duration);
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
    private void SetTopAnchor(UnityEngine.RectTransform rectTransform)
    {
        UnityEngine.Rect val_1 = rectTransform.rect;
        UnityEngine.Rect val_3 = rectTransform.rect;
        UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  0.5f, y:  1f);
        rectTransform.anchorMin = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  0.5f, y:  1f);
        rectTransform.anchorMax = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  0.5f, y:  1f);
        rectTransform.pivot = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
        UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  val_1.m_XMin.width, y:  val_3.m_XMin.height);
        rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_8.x, y = val_8.y};
    }
    private void SetTopLeftAnchor(UnityEngine.RectTransform rectTransform)
    {
        UnityEngine.Rect val_1 = rectTransform.rect;
        UnityEngine.Rect val_3 = rectTransform.rect;
        UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  0f, y:  1f);
        rectTransform.anchorMin = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  0f, y:  1f);
        rectTransform.anchorMax = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  0f, y:  1f);
        rectTransform.pivot = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
        UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  val_1.m_XMin.width, y:  val_3.m_XMin.height);
        rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_8.x, y = val_8.y};
    }
    public void OnDrawGizmos()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.green;
        UnityEngine.Gizmos.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        UnityEngine.Vector3 val_2 = this._recyclableViewBounds.min;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  2000f, y:  0f);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, b:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        UnityEngine.Vector3 val_5 = this._recyclableViewBounds.min;
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  2000f, y:  0f);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, b:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
        UnityEngine.Gizmos.DrawLine(from:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, to:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        UnityEngine.Color val_8 = UnityEngine.Color.red;
        UnityEngine.Gizmos.color = new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a};
        UnityEngine.Vector3 val_9 = this._recyclableViewBounds.max;
        UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  2000f, y:  0f);
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, b:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
        UnityEngine.Vector3 val_12 = this._recyclableViewBounds.max;
        UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  2000f, y:  0f);
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, b:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
        UnityEngine.Gizmos.DrawLine(from:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, to:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
    }

}
