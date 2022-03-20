using UnityEngine;
private sealed class AttackMadnessEventHandler.<RewardSequence>d__74 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButtonV2_AttackMadness attackMadnessButton;
    public WGLevelClearPopup popup;
    public AttackMadnessEventHandler <>4__this;
    private AttackMadnessEventHandler.<>c__DisplayClass74_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public AttackMadnessEventHandler.<RewardSequence>d__74(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_31 = 0;
        if((this.<>1__state) > 3)
        {
                return (bool);
        }
        
        var val_31 = 32556972 + (this.<>1__state) << 2;
        val_31 = val_31 + 32556972;
        goto (32556972 + (this.<>1__state) << 2 + 32556972);
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
