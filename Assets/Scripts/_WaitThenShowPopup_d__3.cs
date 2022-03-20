using UnityEngine;
private sealed class FreeHintTrialHandler.<WaitThenShowPopup>d__3 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGHintButton hButton;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public FreeHintTrialHandler.<WaitThenShowPopup>d__3(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WGHintButton val_12;
        int val_13;
        string val_14;
        var val_15;
        val_12 = this;
        if((this.<>1__state) >= 2)
        {
            goto label_20;
        }
        
        this.<>1__state = 0;
        if((MonoSingleton<WGWindowManager>.Instance.GetActiveAndQueuedWindowCount()) > 0)
        {
                val_13 = 1;
            this.<>2__current = 0;
            this.<>1__state = val_13;
            return (bool)val_13;
        }
        
        GameEcon val_4 = App.getGameEcon;
        if(App.Player != val_4.freeHintInitialTooltip)
        {
            goto label_11;
        }
        
        val_12 = this.hButton;
        val_14 = Localization.Localize(key:  "free_hints_until_level_x", defaultValue:  "Hints are free until Level {0}", useSingularKey:  false);
        GameEcon val_6 = App.getGameEcon;
        val_15 = 1152921504619999232;
        goto label_15;
        label_11:
        GameEcon val_8 = App.getGameEcon;
        if(App.Player != val_8.freeHintEndingTooltip)
        {
            goto label_20;
        }
        
        val_12 = this.hButton;
        val_14 = Localization.Localize(key:  "free_hints_trial_ends_at_level_x", defaultValue:  "Free Hints Trial ends at Level {0}", useSingularKey:  false);
        GameEcon val_10 = App.getGameEcon;
        val_15 = 1152921504619999232;
        label_15:
        val_12.SetPopup(message:  System.String.Format(format:  val_14, arg0:  val_10.freeHintFinalLevel), interactablePopup:  false);
        label_20:
        val_13 = 0;
        return (bool)val_13;
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
