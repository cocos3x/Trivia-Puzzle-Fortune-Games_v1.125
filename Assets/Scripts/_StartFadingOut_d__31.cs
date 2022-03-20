using UnityEngine;
private sealed class TRVPowerupButton.<StartFadingOut>d__31 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVPowerupButton <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVPowerupButton.<StartFadingOut>d__31(int <>1__state)
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
        val_5 = 0;
        if((this.<>1__state) != 1)
        {
                if((this.<>1__state) != 0)
        {
                return (bool)val_5;
        }
        
            this.<>1__state = 0;
            if((this.<>4__this.startedGlow) != false)
        {
                this.<>4__this.glow.GetComponent<UnityEngine.ParticleSystem>().Stop();
        }
        
            DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<>4__this.gameObject.GetComponent<UnityEngine.CanvasGroup>(), endValue:  0f, duration:  0.2f);
            val_6 = 1;
            val_5 = 1;
            this.<>2__current = 0;
        }
        else
        {
                val_6 = 0;
        }
        
        this.<>1__state = val_6;
        return (bool)val_5;
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
