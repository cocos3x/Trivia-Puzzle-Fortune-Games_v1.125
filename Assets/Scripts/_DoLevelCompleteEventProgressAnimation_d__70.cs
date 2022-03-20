using UnityEngine;
private sealed class RaidMadnessEventHandler.<DoLevelCompleteEventProgressAnimation>d__70 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public RaidMadnessEventHandler <>4__this;
    public WGEventButtonV2 eventProgressUI;
    public WGEventButtonV2 eventButton;
    private RaidMadnessEventHandler.<>c__DisplayClass70_1 <>8__1;
    public WGLevelClearPopup popup;
    private RaidMadnessEventHandler.<>c__DisplayClass70_2 <>8__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public RaidMadnessEventHandler.<DoLevelCompleteEventProgressAnimation>d__70(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_55;
        if((this.<>1__state) <= 7)
        {
                var val_54 = 32556640 + (this.<>1__state) << 2;
            val_54 = val_54 + 32556640;
        }
        else
        {
                val_55 = 0;
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
