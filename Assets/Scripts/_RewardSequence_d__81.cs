using UnityEngine;
private sealed class IslandParadiseEventHandler.<RewardSequence>d__81 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public IslandParadiseEventHandler <>4__this;
    public WGEventButtonV2_IslandParadise islandParadiseButton;
    public WGLevelClearPopup popup;
    private IslandParadiseEventHandler.<>c__DisplayClass81_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public IslandParadiseEventHandler.<RewardSequence>d__81(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_34 = 0;
        if((this.<>1__state) > 3)
        {
                return (bool);
        }
        
        var val_34 = 32554828 + (this.<>1__state) << 2;
        val_34 = val_34 + 32554828;
        goto (32554828 + (this.<>1__state) << 2 + 32554828);
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
