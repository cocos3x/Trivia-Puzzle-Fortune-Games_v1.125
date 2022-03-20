using UnityEngine;
private sealed class WGEventHandler.<DoLevelCompleteEventWrapUpAnimation>d__94 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButtonV2 eventButton;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGEventHandler.<DoLevelCompleteEventWrapUpAnimation>d__94(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_7;
        WGEventButtonV2 val_8;
        int val_9;
        val_7 = 0;
        if((this.<>1__state) != 1)
        {
                if((this.<>1__state) != 0)
        {
                return (bool)val_7;
        }
        
            this.<>1__state = 0;
            WGEventHandler.<>c__DisplayClass94_0 val_1 = new WGEventHandler.<>c__DisplayClass94_0();
            val_8 = this.eventButton;
            .eventButton = val_8;
            if(val_8 != 0)
        {
                if(((WGEventHandler.<>c__DisplayClass94_0)[1152921516373284208].eventButton.canvasGroup.alpha) < 0)
        {
                DG.Tweening.Core.DOGetter<System.Single> val_4 = null;
            val_8 = val_4;
            val_4 = new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single WGEventHandler.<>c__DisplayClass94_0::<DoLevelCompleteEventWrapUpAnimation>b__0());
            DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions> val_6 = DG.Tweening.DOTween.To(getter:  val_4, setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void WGEventHandler.<>c__DisplayClass94_0::<DoLevelCompleteEventWrapUpAnimation>b__1(float n)), endValue:  1f, duration:  1f);
        }
        
        }
        
            val_9 = 1;
            val_7 = 1;
            this.<>2__current = 0;
        }
        else
        {
                val_9 = 0;
        }
        
        this.<>1__state = val_9;
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
