using UnityEngine;
private sealed class ApplovinMaxPlugin.<InitializeBanners>d__39 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public ApplovinMaxPlugin <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ApplovinMaxPlugin.<InitializeBanners>d__39(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_7;
        int val_8;
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
        val_7 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  10f);
        val_8 = 1;
        this.<>2__current = val_7;
        this.<>1__state = val_8;
        return (bool)val_8;
        label_1:
        this.<>1__state = 0;
        val_7 = this.<>4__this;
        MaxSdkCallbacks.add_OnBannerAdClickedEvent(value:  new System.Action<System.String>(object:  val_7, method:  System.Void ApplovinMaxPlugin::MaxSdkCallbacks_OnBannerAdClickedEvent(string obj)));
        MaxSdkCallbacks.add_OnBannerAdCollapsedEvent(value:  new System.Action<System.String>(object:  val_7, method:  System.Void ApplovinMaxPlugin::MaxSdkCallbacks_OnBannerAdCollapsedEvent(string obj)));
        MaxSdkCallbacks.add_OnBannerAdExpandedEvent(value:  new System.Action<System.String>(object:  val_7, method:  System.Void ApplovinMaxPlugin::MaxSdkCallbacks_OnBannerAdExpandedEvent(string obj)));
        MaxSdkCallbacks.add_OnBannerAdLoadedEvent(value:  new System.Action<System.String>(object:  val_7, method:  System.Void ApplovinMaxPlugin::MaxSdkCallbacks_OnBannerAdLoadedEvent(string obj)));
        MaxSdkCallbacks.add_OnBannerAdLoadFailedEvent(value:  new System.Action<System.String, System.Int32>(object:  val_7, method:  System.Void ApplovinMaxPlugin::MaxSdkCallbacks_OnBannerAdLoadFailedEvent(string arg1, int arg2)));
        label_2:
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
