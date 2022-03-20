using UnityEngine;
private sealed class WGLeaguesLoadingPopup.<DelayLoadLeagues>d__11 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGLeaguesLoadingPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGLeaguesLoadingPopup.<DelayLoadLeagues>d__11(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        bool val_14;
        var val_15;
        object val_16;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 1)
        {
                val_14 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_14;
        }
        
            this.<>1__state = 0;
            val_15 = null;
            val_15 = null;
            val_14 = true;
            WGLeaguesLoadingPopup.loadingLeagues = val_14;
            UnityEngine.WaitForSeconds val_3 = null;
            val_16 = val_3;
            val_3 = new UnityEngine.WaitForSeconds(seconds:  (UnityEngine.Application.isEditor != true) ? 0.5f : 3f);
            this.<>2__current = val_16;
            this.<>1__state = val_14;
            return (bool)val_14;
        }
        
        this.<>1__state = 0;
        val_16 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
        if((val_16 == 0) || ((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance.WaitFullDataUpdate()) == false))
        {
            goto label_15;
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this.<>4__this, name:  0.ToString());
        val_16 = 9;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this.<>4__this, name:  9.ToString());
        MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance.RequestInitialData();
        val_14 = 0;
        return (bool)val_14;
        label_1:
        val_14 = 0;
        this.<>1__state = 0;
        return (bool)val_14;
        label_15:
        this.<>2__current = this.<>4__this.OnDataUpdate();
        this.<>1__state = 2;
        val_14 = 1;
        return (bool)val_14;
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
