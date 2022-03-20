using UnityEngine;
private sealed class IslandParadiseEventHandler.<DoLevelCompleteEventProgressAnimation>d__79 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButtonV2 eventButton;
    public IslandParadiseEventHandler <>4__this;
    public WGEventButtonV2 eventProgressUI;
    public WGLevelClearPopup popup;
    private WGEventButtonV2_IslandParadise <islandParadiseButton>5__2;
    private int <currentPoints>5__3;
    private int <pointsToReward>5__4;
    private int <lastPointsRequired>5__5;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public IslandParadiseEventHandler.<DoLevelCompleteEventProgressAnimation>d__79(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_30;
        if((this.<>1__state) <= 6)
        {
                var val_26 = 32554800 + (this.<>1__state) << 2;
            val_26 = val_26 + 32554800;
        }
        else
        {
                val_30 = 0;
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
