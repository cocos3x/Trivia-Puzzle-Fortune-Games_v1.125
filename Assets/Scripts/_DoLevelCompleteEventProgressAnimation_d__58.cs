using UnityEngine;
private sealed class WildWeekendHandler.<DoLevelCompleteEventProgressAnimation>d__58 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButtonV2 eventButton;
    public WildWeekendHandler <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WildWeekendHandler.<DoLevelCompleteEventProgressAnimation>d__58(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_19 = 0;
        if((this.<>1__state) > 3)
        {
                return (bool);
        }
        
        var val_19 = 32497872;
        val_19 = (32497872 + (this.<>1__state) << 2) + val_19;
        goto (32497872 + (this.<>1__state) << 2 + 32497872);
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
