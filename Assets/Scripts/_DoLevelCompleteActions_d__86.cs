using UnityEngine;
private sealed class WordRegion.<DoLevelCompleteActions>d__86 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordRegion <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordRegion.<DoLevelCompleteActions>d__86(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WordRegion val_7;
        int val_8;
        val_7 = this.<>4__this;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_18;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForSeconds val_1 = null;
        val_7 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  1.5f);
        val_8 = 1;
        this.<>2__current = val_7;
        this.<>1__state = val_8;
        return (bool)val_8;
        label_2:
        this.<>1__state = 0;
        MainController val_2 = MainController.instance;
        val_7.NotifyBeforeLevelComplete(level:  this.<>4__this.gameLevel);
        UnityEngine.WaitUntil val_4 = null;
        val_7 = val_4;
        val_4 = new UnityEngine.WaitUntil(predicate:  new System.Func<System.Boolean>(object:  val_7, method:  System.Boolean WordRegion::<DoLevelCompleteActions>b__86_0()));
        this.<>2__current = val_7;
        this.<>1__state = 2;
        val_8 = 1;
        return (bool)val_8;
        label_1:
        this.<>1__state = 0;
        31267.ClearLevelProgress();
        val_7.NotifyLevelComplete(level:  this.<>4__this.gameLevel);
        MainController val_5 = MainController.instance;
        if((UnityEngine.Object.op_Implicit(exists:  this.<>4__this.compliment)) != false)
        {
                this.<>4__this.compliment.ShowRandom();
        }
        
        label_18:
        val_8 = 0;
        return (bool)val_8;
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
