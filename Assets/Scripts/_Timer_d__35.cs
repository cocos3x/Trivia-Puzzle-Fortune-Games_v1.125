using UnityEngine;
private sealed class EmojiMatchUIController.<Timer>d__35 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.EmojiMatch.EmojiMatchUIController <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public EmojiMatchUIController.<Timer>d__35(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_7;
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
        if((this.<>4__this.timerDurationToWait) >= 0)
        {
            goto label_5;
        }
        
        SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
        if(val_1.currentPlayerLevel <= 0)
        {
            goto label_9;
        }
        
        label_5:
        this.<>4__this.FTUXHand.gameObject.SetActive(value:  false);
        if((this.<>4__this.firstSession) == false)
        {
            goto label_12;
        }
        
        val_7 = 0;
        this.<>4__this.firstSession = false;
        return (bool)val_7;
        label_2:
        val_7 = 0;
        this.<>1__state = 0;
        return (bool)val_7;
        label_1:
        this.<>1__state = 0;
        float val_3 = UnityEngine.Time.deltaTime;
        val_3 = val_3 * (this.<>4__this.timerSpeed);
        val_3 = (this.<>4__this.timerDurationToWait) - val_3;
        this.<>4__this.timerDurationToWait = val_3;
        val_3 = val_3 / (this.<>4__this.timerFullDuration);
        this.<>4__this.timerSlider.normalizedValue = val_3;
        label_12:
        if((this.<>4__this.timerDurationToWait) > 0f)
        {
            goto label_17;
        }
        
        this.<>4__this.timerSlider.normalizedValue = 0f;
        this.<>4__this.blockInput = true;
        this.<>4__this.OnFailure();
        label_3:
        val_7 = 0;
        return (bool)val_7;
        label_17:
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = 2;
        val_7 = 1;
        return (bool)val_7;
        label_9:
        val_7 = 1;
        this.<>4__this.FTUXHand.gameObject.SetActive(value:  true);
        this.<>2__current = this.<>4__this.MoveFTUXHand();
        this.<>1__state = val_7;
        return (bool)val_7;
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
