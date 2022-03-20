using UnityEngine;
private sealed class WGDailyChallengeCalendarDisplay.<ShowTooltipCoroutine>d__13 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGDailyChallengeCalendarDisplay <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGDailyChallengeCalendarDisplay.<ShowTooltipCoroutine>d__13(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_9;
        int val_10;
        var val_11;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForSeconds val_1 = null;
        val_9 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  3f);
        val_10 = 1;
        this.<>2__current = val_9;
        this.<>1__state = val_10;
        return (bool)val_10;
        label_1:
        val_9 = this.<>4__this;
        this.<>1__state = 0;
        if(val_9.ShowTooltip() != 0)
        {
            goto label_7;
        }
        
        label_2:
        val_10 = 0;
        return (bool)val_10;
        label_7:
        val_11 = null;
        val_11 = null;
        WGDailyChallengeV2Popup.onMainScreenBtnClicked = new System.Action(object:  val_9, method:  System.Void WGDailyChallengeCalendarDisplay::OnCloseTooltip());
        NotificationCenter.DefaultCenter.PostNotification(aSender:  val_9, aName:  "EnableScreenButton");
        this.<>4__this.tooltipButton.gameObject.SetActive(value:  true);
        val_10 = 0;
        this.<>4__this.closeTooltipCoroutine = val_9.StartCoroutine(routine:  val_9.CloseTooltipCoroutine());
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
