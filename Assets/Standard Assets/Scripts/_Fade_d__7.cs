using UnityEngine;
private sealed class SkeletonGhostRenderer.<Fade>d__7 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Spine.Unity.Modules.SkeletonGhostRenderer <>4__this;
    private int <t>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SkeletonGhostRenderer.<Fade>d__7(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.Color32[] val_8;
        var val_9;
        int val_10;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<t>5__2 = 0;
        goto label_4;
        label_1:
        int val_8 = this.<t>5__2;
        this.<>1__state = 0;
        val_8 = val_8 + 1;
        this.<t>5__2 = val_8;
        if(val_8 > 499)
        {
                if((this.<>4__this) != null)
        {
            goto label_5;
        }
        
        }
        
        label_4:
        val_8 = this.<>4__this.colors;
        var val_10 = 0;
        val_9 = 1;
        label_12:
        if(val_10 >= ((this.<>4__this.colors.Length) << ))
        {
            goto label_9;
        }
        
        UnityEngine.Color32 val_9 = val_8[val_10];
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = val_1 * (this.<>4__this.fadeSpeed);
        UnityEngine.Color32 val_2 = UnityEngine.Color32.Lerp(a:  new UnityEngine.Color32() {r = val_9, g = val_9, b = val_9, a = val_9}, b:  new UnityEngine.Color32() {r = this.<>4__this.black, g = this.<>4__this.black, b = this.<>4__this.black, a = this.<>4__this.black}, t:  val_1);
        val_8[val_10] = val_2;
        val_8 = this.<>4__this.colors;
        val_9 = val_9 & (((val_9 >> 24) == 0) ? 1 : 0);
        val_10 = val_10 + 1;
        if(val_8 != null)
        {
            goto label_12;
        }
        
        throw new NullReferenceException();
        label_9:
        this.<>4__this.meshFilter.sharedMesh.colors32 = this.<>4__this.colors;
        if((val_9 & 1) == 0)
        {
            goto label_15;
        }
        
        label_5:
        UnityEngine.Object.Destroy(obj:  this.<>4__this.meshFilter.sharedMesh);
        this.<>4__this.gameObject.SetActive(value:  false);
        label_2:
        val_10 = 0;
        return (bool)val_10;
        label_15:
        val_10 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_10;
        return (bool)val_10;
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
