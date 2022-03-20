using UnityEngine;
private sealed class Alphabet2Manager.<ShowTooltip>d__166 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public LineWord word;
    public Alphabet2Manager <>4__this;
    public UnityEngine.Transform letterTransform;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Alphabet2Manager.<ShowTooltip>d__166(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_19;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_19 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_19;
        return (bool)val_19;
        label_1:
        this.<>1__state = 0;
        float val_20 = this.word.cellSize;
        UnityEngine.GameObject val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  31738.AlphabetTileTooltipPrefab, parent:  WordRegion.instance.SafeTransform);
        float val_19 = 0.5f;
        val_19 = val_20 * val_19;
        val_20 = val_19 + 10f;
        UnityEngine.Vector3 val_8 = this.word.GetComponent<UnityEngine.RectTransform>().localPosition;
        float val_9 = val_20 + val_20;
        val_9 = val_9 + val_8.y;
        PluginExtension.SetLocalY(transform:  val_5.GetComponent<UnityEngine.RectTransform>(), y:  val_9);
        UnityEngine.Rect val_11 = WordRegion.instance.getSafeAreaRect;
        UnityEngine.Vector2 val_15 = val_5.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        UnityEngine.Vector2 val_16 = new UnityEngine.Vector2(x:  val_11.m_XMin.width, y:  val_15.y);
        val_5.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_16.x, y = val_16.y};
        val_5.GetComponent<AlphabetFtuxTooltip>().Setup(toolTipBase:  val_5.transform, letter:  this.letterTransform);
        label_2:
        val_19 = 0;
        return (bool)val_19;
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
