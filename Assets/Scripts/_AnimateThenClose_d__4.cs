using UnityEngine;
private sealed class WGBonusRewardsLevelUpPopup.<AnimateThenClose>d__4 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGBonusRewardsLevelUpPopup <>4__this;
    public int newLevel;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGBonusRewardsLevelUpPopup.<AnimateThenClose>d__4(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_8;
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
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        val_8 = 1;
        this.<>1__state = val_8;
        return (bool)val_8;
        label_2:
        this.<>1__state = 0;
        string val_2 = this.newLevel.ToString();
        val_8 = 1;
        UnityEngine.ParticleSystem val_5 = MonoSingleton<WGSFXController>.Instance.PlaySFX(reqType:  1, parent:  this.<>4__this.bonusLevelText.rectTransform, playImmediate:  true);
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  2f);
        this.<>1__state = 2;
        return (bool)val_8;
        label_1:
        this.<>1__state = 0;
        SLCWindow.CloseWindow(window:  this.<>4__this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        label_3:
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
