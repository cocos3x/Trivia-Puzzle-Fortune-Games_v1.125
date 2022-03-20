using UnityEngine;
private sealed class DailyChallengeTutorialGameplayHelper.<wait_ShowFTUX>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public DailyChallengeTutorialGameplayHelper.<wait_ShowFTUX>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.Object val_9;
        int val_10;
        val_9 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_13;
        }
        
        this.<>1__state = 0;
        val_10 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_10;
        return (bool)val_10;
        label_1:
        this.<>1__state = 0;
        val_9 = WordRegion.instance;
        if(val_9 != 0)
        {
                System.Collections.Generic.List<System.String> val_5 = WordRegion.instance.GetCompletedWords();
        }
        
        MonoSingleton<WGWindowManager>.Instance.CloseCurrentWindow();
        GameBehavior val_7 = App.getBehavior;
        val_9 = val_7.<metaGameBehavior>k__BackingField;
        label_13:
        val_10 = 0;
        return (bool)val_10;
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
