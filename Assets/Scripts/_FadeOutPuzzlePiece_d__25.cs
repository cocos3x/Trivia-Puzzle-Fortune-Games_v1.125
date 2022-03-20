using UnityEngine;
private sealed class WGPuzzleProgressPopup.<FadeOutPuzzlePiece>d__25 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public UnityEngine.GameObject pc;
    public WGPuzzleProgressPopup <>4__this;
    private UnityEngine.Color <newPieceColor>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGPuzzleProgressPopup.<FadeOutPuzzlePiece>d__25(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_5;
        int val_6;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.Color val_2 = this.pc.GetComponent<UnityEngine.UI.Image>().color;
        val_5 = val_2.a;
        this.<newPieceColor>5__2 = val_2;
        mem[1152921517941608484] = val_2.g;
        mem[1152921517941608488] = val_2.b;
        mem[1152921517941608492] = val_2.a;
        goto label_5;
        label_1:
        this.<>1__state = 0;
        label_5:
        if(S8 > 0f)
        {
            goto label_6;
        }
        
        this.pc.SetActive(value:  false);
        label_2:
        val_6 = 0;
        return (bool)val_6;
        label_6:
        float val_3 = UnityEngine.Time.deltaTime;
        val_3 = (this.<>4__this.revealingPuzzlePieceSpeed) * val_3;
        val_3 = S8 - val_3;
        mem[1152921517941608492] = val_3;
        this.pc.GetComponent<UnityEngine.UI.Image>().color = new UnityEngine.Color() {r = this.<newPieceColor>5__2};
        val_6 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_6;
        return (bool)val_6;
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
