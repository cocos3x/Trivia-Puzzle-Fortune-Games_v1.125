using UnityEngine;
private sealed class PuzzleCollectionUIController.<ShowTooltip>d__66 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PuzzleCollectionUIController <>4__this;
    public UnityEngine.Transform parent;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PuzzleCollectionUIController.<ShowTooltip>d__66(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_25;
        int val_26;
        var val_27;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_25 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_26 = 1;
        this.<>2__current = val_25;
        this.<>1__state = val_26;
        return (bool)val_26;
        label_1:
        val_25 = this.<>4__this;
        this.<>1__state = 0;
        float val_26 = this.<>4__this.word.cellSize;
        if((this.<>4__this.toolTipPrefab) == 0)
        {
            goto label_8;
        }
        
        UnityEngine.GameObject val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.<>4__this.toolTipPrefab, parent:  this.parent);
        val_27 = val_25;
        this.<>4__this.toolTipBase = val_3;
        if(val_3 != null)
        {
            goto label_11;
        }
        
        label_2:
        val_26 = 0;
        return (bool)val_26;
        label_8:
        val_27 = val_25;
        label_11:
        float val_25 = 0.5f;
        val_25 = val_26 * val_25;
        val_26 = val_25 + 10f;
        UnityEngine.Vector3 val_6 = this.<>4__this.word.GetComponent<UnityEngine.RectTransform>().localPosition;
        float val_7 = val_26 + val_26;
        val_7 = val_7 + val_6.y;
        PluginExtension.SetLocalY(transform:  this.<>4__this.toolTipBase.GetComponent<UnityEngine.RectTransform>(), y:  val_7);
        UnityEngine.Rect val_9 = WordRegion.instance.getSafeAreaRect;
        UnityEngine.Vector2 val_13 = this.<>4__this + 136.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        UnityEngine.Vector2 val_14 = new UnityEngine.Vector2(x:  val_9.m_XMin.width, y:  val_13.y);
        this.<>4__this + 136.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_14.x, y = val_14.y};
        bool val_15 = UnityEngine.Object.op_Inequality(x:  this.<>4__this.toolTipPickPrefab, y:  0);
        UnityEngine.GameObject val_17 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.<>4__this.toolTipPickPrefab, parent:  this.<>4__this.letter.transform);
        UnityEngine.Vector3 val_19 = UnityEngine.Vector3.zero;
        val_17.transform.localPosition = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
        val_17.transform.parent = this.<>4__this + 136.transform;
        PluginExtension.SetLocalY(transform:  val_17.GetComponent<UnityEngine.RectTransform>(), y:  -10f);
        val_26 = 0;
        this.<>4__this.destroyTooltipUponClick = val_25.StartCoroutine(routine:  val_25.DestroyTooltipUponClick());
        return (bool)val_26;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
