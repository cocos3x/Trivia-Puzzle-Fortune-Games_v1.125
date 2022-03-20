using UnityEngine;
private sealed class WFOMysteryChestDisplay.<DoOpenChestAnimationSequence>d__86 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordForest.WFOMysteryChestDisplay <>4__this;
    private WordForest.WFOMysteryChestDisplay.<>c__DisplayClass86_0 <>8__1;
    private WordForest.WFOMysteryChestDisplay.<>c__DisplayClass86_1 <>8__2;
    private bool <canRaid>5__2;
    private bool <canAttack>5__3;
    private int <i>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WFOMysteryChestDisplay.<DoOpenChestAnimationSequence>d__86(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        bool val_58;
        if((this.<>1__state) <= 8)
        {
                var val_57 = 32561420 + (this.<>1__state) << 2;
            val_57 = val_57 + 32561420;
        }
        else
        {
                val_58 = 0;
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
