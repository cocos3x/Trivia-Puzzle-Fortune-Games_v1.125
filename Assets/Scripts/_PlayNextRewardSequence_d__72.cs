using UnityEngine;
private sealed class AttackMadnessEventHandler.<PlayNextRewardSequence>d__72 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public AttackMadnessEventHandler <>4__this;
    public WGEventButtonV2 eventButton;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public AttackMadnessEventHandler.<PlayNextRewardSequence>d__72(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_5;
        object val_6;
        int val_7;
        val_5 = 0;
        if((this.<>1__state) != 2)
        {
                if((this.<>1__state) != 1)
        {
                if((this.<>1__state) != 0)
        {
                return (bool)val_5;
        }
        
            this.<>1__state = 0;
            GameBehavior val_1 = App.getBehavior;
            mem2[0] = this.<>4__this;
            val_6 = val_1.<metaGameBehavior>k__BackingField.PlayNextRewardSequence(eventButton:  this.eventButton);
            val_7 = 1;
        }
        else
        {
                this.<>1__state = 0;
            UnityEngine.WaitForSeconds val_4 = null;
            val_6 = val_4;
            val_4 = new UnityEngine.WaitForSeconds(seconds:  0.5f);
            val_7 = 2;
        }
        
            val_5 = 1;
            this.<>2__current = val_6;
        }
        else
        {
                val_7 = 0;
        }
        
        this.<>1__state = val_7;
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
