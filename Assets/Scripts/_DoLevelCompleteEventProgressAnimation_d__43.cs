using UnityEngine;
private sealed class LightningLevelsEventHandler.<DoLevelCompleteEventProgressAnimation>d__43 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButtonV2 eventProgressUI;
    public LightningLevelsEventHandler <>4__this;
    public WGEventButtonV2 eventButton;
    private LightningLevelsEventHandler.<>c__DisplayClass43_1 <>8__1;
    private LightningLevelsEventHandler.<>c__DisplayClass43_2 <>8__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LightningLevelsEventHandler.<DoLevelCompleteEventProgressAnimation>d__43(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        LightningLevelsEventHandler val_53;
        int val_54;
        if((this.<>1__state) <= 5)
        {
                var val_53 = 32560936 + (this.<>1__state) << 2;
            val_53 = this.<>4__this;
            val_53 = val_53 + 32560936;
        }
        else
        {
                val_54 = 0;
            return (bool);
        }
    
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
