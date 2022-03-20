using UnityEngine;
private sealed class AttackMadnessEventHandler.<DoLevelCompleteEventProgressAnimation>d__69 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public AttackMadnessEventHandler <>4__this;
    public WGEventButtonV2 eventButton;
    public WGEventButtonV2 eventProgressUI;
    public WGLevelClearPopup popup;
    private int <currentPoints>5__2;
    private WGEventButtonV2_AttackMadness <attackMadnessButton>5__3;
    private bool <collectedReward>5__4;
    private int <pointsToReward>5__5;
    private int <lastPointsRequired>5__6;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public AttackMadnessEventHandler.<DoLevelCompleteEventProgressAnimation>d__69(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        bool val_45;
        if((this.<>1__state) <= 8)
        {
                var val_41 = 32556936 + (this.<>1__state) << 2;
            val_41 = val_41 + 32556936;
        }
        else
        {
                val_45 = 0;
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
