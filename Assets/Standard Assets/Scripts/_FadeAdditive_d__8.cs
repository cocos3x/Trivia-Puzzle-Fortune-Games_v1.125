using UnityEngine;
private sealed class SkeletonGhostRenderer.<FadeAdditive>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Spine.Unity.Modules.SkeletonGhostRenderer <>4__this;
    private UnityEngine.Color32 <black>5__2;
    private int <t>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SkeletonGhostRenderer.<FadeAdditive>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_7;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<black>5__2 = this.<>4__this.black;
        this.<t>5__3 = 0;
        goto label_4;
        label_1:
        int val_8 = this.<t>5__3;
        this.<>1__state = 0;
        val_8 = val_8 + 1;
        this.<t>5__3 = val_8;
        if(val_8 > 499)
        {
                if((this.<>4__this) != null)
        {
            goto label_6;
        }
        
        }
        
        label_4:
        var val_10 = 1;
        var val_11 = 8;
        label_14:
        if((val_11 - 8) >= ((this.<>4__this.colors.Length) << ))
        {
            goto label_10;
        }
        
        UnityEngine.Color32 val_9 = this.<>4__this.colors[0];
        mem[1152921513290110459] = (ulong)(val_9 >> 24) & 255;
        float val_3 = UnityEngine.Time.deltaTime;
        val_3 = val_3 * (this.<>4__this.fadeSpeed);
        UnityEngine.Color32 val_4 = UnityEngine.Color32.Lerp(a:  new UnityEngine.Color32() {r = val_9, g = val_9, b = val_9, a = val_9}, b:  new UnityEngine.Color32() {r = this.<black>5__2, g = this.<black>5__2, b = this.<black>5__2, a = this.<black>5__2}, t:  val_3);
        this.<>4__this.colors[0] = val_4;
        val_10 = (((val_9 & 16777215) != 0) ? 1 : 0) & val_10;
        val_11 = val_11 + 1;
        if((this.<>4__this.colors) != null)
        {
            goto label_14;
        }
        
        label_10:
        this.<>4__this.meshFilter.sharedMesh.colors32 = this.<>4__this.colors;
        if((val_10 & 1) == 0)
        {
            goto label_18;
        }
        
        label_6:
        UnityEngine.Object.Destroy(obj:  this.<>4__this.meshFilter.sharedMesh);
        this.<>4__this.gameObject.SetActive(value:  false);
        label_2:
        val_7 = 0;
        return (bool)val_7;
        label_18:
        val_7 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_7;
        return (bool)val_7;
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
