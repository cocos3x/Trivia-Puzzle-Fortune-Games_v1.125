using UnityEngine;
public class RecyclableScrollRect : ScrollRect
{
    // Fields
    public IRecyclableScrollRectDataSource DataSource;
    public bool IsGrid;
    public UnityEngine.RectTransform PrototypeCell;
    public bool SelfInitialize;
    public RecyclableScrollRect.DirectionType Direction;
    public RecyclableScrollRect.CellPositionType CellType;
    private int _segments;
    private RecyclingSystem _recyclableScrollRect;
    private UnityEngine.Vector2 _prevAnchoredPos;
    
    // Properties
    public int Segments { get; set; }
    
    // Methods
    public void set_Segments(int value)
    {
        this._segments = System.Math.Max(val1:  value, val2:  2);
    }
    public int get_Segments()
    {
        return (int)this._segments;
    }
    protected override void Start()
    {
        mem[1152921517112699152] = 256;
        if(UnityEngine.Application.isPlaying == false)
        {
                return;
        }
        
        if(this.SelfInitialize == false)
        {
                return;
        }
        
        this.Initialize();
    }
    private void Initialize()
    {
        int val_11;
        IRecyclableScrollRectDataSource val_12;
        RecyclingSystem val_13;
        if(this.Direction == 0)
        {
            goto label_1;
        }
        
        if(this.Direction != 1)
        {
            goto label_2;
        }
        
        val_11 = this._segments;
        HorizontalRecyclingSystem val_1 = null;
        val_12 = this.DataSource;
        val_13 = val_1;
        val_1 = new HorizontalRecyclingSystem(prototypeCell:  this.PrototypeCell, viewport:  X21, content:  X22, dataSource:  val_12, isGrid:  this.IsGrid, rows:  val_11);
        goto label_3;
        label_1:
        val_11 = this._segments;
        VerticalRecyclingSystem val_2 = null;
        val_12 = this.DataSource;
        val_13 = val_2;
        val_2 = new VerticalRecyclingSystem(prototypeCell:  this.PrototypeCell, viewport:  X21, content:  X22, dataSource:  val_12, isGrid:  this.IsGrid, coloumns:  val_11);
        label_3:
        this._recyclableScrollRect = val_13;
        label_2:
        mem[1152921517112872609] = (this.Direction == 0) ? 1 : 0;
        mem[1152921517112872608] = (this.Direction == 1) ? 1 : 0;
        UnityEngine.Vector2 val_5 = val_2.anchoredPosition;
        this._prevAnchoredPos = val_5;
        mem[1152921517112872924] = val_5.y;
        this.PrototypeCell.RemoveListener(call:  new UnityEngine.Events.UnityAction<UnityEngine.Vector2>(object:  this, method:  public System.Void RecyclableScrollRect::OnValueChangedListener(UnityEngine.Vector2 normalizedPos)));
        System.Action val_7 = new System.Action(object:  this, method:  System.Void RecyclableScrollRect::<Initialize>b__15_0());
        var val_12 = 0;
        val_12 = val_12 + 1;
        int val_9 = this.DataSource.GetStartPos();
        var val_10 = (this.CellType == 1) ? 1 : 0;
        UnityEngine.Coroutine val_11 = this.StartCoroutine(routine:  this._recyclableScrollRect);
    }
    public void Initialize(IRecyclableScrollRectDataSource dataSource)
    {
        this.DataSource = dataSource;
        this.Initialize();
    }
    public void OnValueChangedListener(UnityEngine.Vector2 normalizedPos)
    {
        UnityEngine.Vector2 val_1 = 22874.anchoredPosition;
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y}, b:  new UnityEngine.Vector2() {x = this._prevAnchoredPos, y = V9.16B});
        UnityEngine.Vector2 val_3 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_1.x, y = V9.16B}, b:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y});
        mem[1152921517113166336] = val_3.x;
        mem[1152921517113166340] = val_3.y;
        UnityEngine.Vector2 val_4 = 0.anchoredPosition;
        this._prevAnchoredPos = val_4;
        mem[1152921517113166572] = val_4.y;
    }
    public DG.Tweening.Sequence ScrollByAmountCell(float amountCell, float duration, DG.Tweening.Ease ease = 7)
    {
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tween>(t:  this._recyclableScrollRect, ease:  ease));
        return val_1;
    }
    public ICell FindCellByIndex(int Id)
    {
        if(this._recyclableScrollRect != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public RecyclableScrollRect()
    {
        this.SelfInitialize = true;
    }
    private void <Initialize>b__15_0()
    {
        AddListener(call:  new UnityEngine.Events.UnityAction<UnityEngine.Vector2>(object:  this, method:  public System.Void RecyclableScrollRect::OnValueChangedListener(UnityEngine.Vector2 normalizedPos)));
    }

}
