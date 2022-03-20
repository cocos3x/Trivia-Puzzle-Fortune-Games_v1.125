using UnityEngine;
private sealed class WGDailyChallengeLevelComplete.<Start>d__49 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGDailyChallengeLevelComplete <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGDailyChallengeLevelComplete.<Start>d__49(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WGDailyChallengeLevelComplete val_3;
        int val_4;
        val_3 = this.<>4__this;
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
            goto label_3;
        }
        
        this.<>1__state = 0;
        if((this.<>4__this.dcRevamp) == false)
        {
            goto label_5;
        }
        
        this.<>2__current = val_3.PlayNewStarAnimation();
        val_4 = 1;
        this.<>1__state = val_4;
        return (bool)val_4;
        label_2:
        this.<>1__state = 0;
        label_5:
        UnityEngine.WaitForSeconds val_2 = null;
        val_3 = val_2;
        val_2 = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>2__current = val_3;
        this.<>1__state = 2;
        val_4 = 1;
        return (bool)val_4;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.button_continue_completed.interactable = true;
        this.<>4__this.button_continue_less_stars.interactable = true;
        this.<>4__this.button_retry_less_stars.interactable = true;
        this.<>4__this.button_gala_rewards.interactable = true;
        label_3:
        val_4 = 0;
        return (bool)val_4;
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
