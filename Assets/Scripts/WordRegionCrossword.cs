using UnityEngine;
public class WordRegionCrossword : WordRegion
{
    // Fields
    private const float CELL_SIZE = 80;
    private UnityEngine.UI.GridLayoutGroup grid;
    public int width;
    public int height;
    public UnityEngine.GameObject emptyCellPrefab;
    
    // Methods
    protected override void Awake()
    {
        this.Awake();
        this.grid = this.GetComponent<UnityEngine.UI.GridLayoutGroup>();
    }
    protected override void ApplyHintToLine(LineWord line, Cell cell)
    {
        UnityEngine.Object val_2;
        var val_3;
        UnityEngine.Object val_7;
        line.CheckShown();
        List.Enumerator<T> val_1 = line.GetEnumerator();
        label_11:
        if(val_3.MoveNext() == false)
        {
            goto label_3;
        }
        
        val_7 = val_2;
        if(val_7 == line)
        {
            goto label_11;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_7 = mem[val_2 + 40];
        val_7 = val_2 + 40;
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_7.Contains(item:  cell)) == false)
        {
            goto label_11;
        }
        
        val_2.CheckShown();
        if((val_2 + 56) == 0)
        {
            goto label_11;
        }
        
        this.ApplyHintToLine(line:  val_2, cell:  cell);
        goto label_11;
        label_3:
        val_3.Dispose();
        this.ApplyHintToLine(line:  line, cell:  cell);
    }
    public override void Load(GameLevel gameLevel, System.Action loadCompleteCallback)
    {
        mem[1152921515479244808] = gameLevel;
        System.Delegate val_1 = System.Delegate.Combine(a:  38328, b:  loadCompleteCallback);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        mem[1152921515479244904] = val_1;
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.LoadCoroutine());
        return;
        label_2:
    }
    private System.Collections.IEnumerator LoadCoroutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordRegionCrossword.<LoadCoroutine>d__8();
    }
    private void NotifyLevelLoaded(GameLevel level)
    {
        if(38329 == 0)
        {
                return;
        }
        
        38329.Invoke(obj:  level);
    }
    private System.Collections.IEnumerator LevelLoadCompleteActionCoroutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordRegionCrossword.<LevelLoadCompleteActionCoroutine>d__10();
    }
    private System.Collections.IEnumerator ScaleToFitLate()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordRegionCrossword.<ScaleToFitLate>d__11();
    }
    private void OnRectTransformDimensionsChange()
    {
        goto typeof(WordRegionCrossword).__il2cppRuntimeField_170;
    }
    protected override void ScaleToFit()
    {
        float val_13;
        var val_14;
        UnityEngine.Rect val_1 = rect;
        val_13 = val_1.m_XMin.height;
        val_14 = null;
        val_14 = null;
        if((S9 ?? val_13) <= UnityEngine.Mathf.Epsilon)
        {
                return;
        }
        
        mem[1152921515479974064] = val_13;
        UnityEngine.Rect val_4 = rect;
        val_13 = val_4.m_XMin.width;
        UnityEngine.Rect val_6 = rect;
        float val_15 = 80f;
        float val_13 = (float)this.width;
        float val_14 = (float)this.height;
        val_13 = val_13 * val_15;
        val_14 = val_14 * val_15;
        val_15 = val_13 / val_13;
        mem[1152921515479974296] = UnityEngine.Mathf.Min(a:  val_15, b:  val_6.m_XMin.height / val_14);
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.one;
        UnityEngine.Vector3 val_12 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, d:  val_6.m_Height);
        if(null == null)
        {
                this.transform.localScale = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
            return;
        }
    
    }
    public WordRegionCrossword()
    {
        this.width = 1;
        this.height = 0;
    }

}
