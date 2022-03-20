using UnityEngine;
private sealed class ApplovinMaxPlugin.<InitializeInterstitials>d__68 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public ApplovinMaxPlugin <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ApplovinMaxPlugin.<InitializeInterstitials>d__68(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_10;
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
        val_10 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  2f);
        this.<>1__state = val_10;
        return (bool)val_10;
        label_2:
        this.<>1__state = 0;
        MaxSdkCallbacks.add_OnInterstitialLoadedEvent(value:  new System.Action<System.String>(object:  this.<>4__this, method:  System.Void ApplovinMaxPlugin::OnInterstitialLoaded(string adUnit)));
        MaxSdkCallbacks.add_OnInterstitialLoadFailedEvent(value:  new System.Action<System.String, System.Int32>(object:  this.<>4__this, method:  System.Void ApplovinMaxPlugin::OnInterstitialFailed(string adUnit, int errorCode)));
        MaxSdkCallbacks.add_OnInterstitialAdFailedToDisplayEvent(value:  new System.Action<System.String, System.Int32>(object:  this.<>4__this, method:  System.Void ApplovinMaxPlugin::OnInterstitialFailedToDisplay(string adUnit, int errorCode)));
        MaxSdkCallbacks.add_OnInterstitialHiddenEvent(value:  new System.Action<System.String>(object:  this.<>4__this, method:  System.Void ApplovinMaxPlugin::OnInterstitialHidden(string adUnit)));
        MaxSdkCallbacks.add_OnInterstitialClickedEvent(value:  new System.Action<System.String>(object:  this.<>4__this, method:  System.Void ApplovinMaxPlugin::OnInterstitialClicked(string adUnitClicked)));
        MaxSdkCallbacks.add_OnInterstitialDisplayedEvent(value:  new System.Action<System.String>(object:  this.<>4__this, method:  System.Void ApplovinMaxPlugin::OnInterstitialDisplayedEvent(string adUnit)));
        MaxSdkCallbacks.Interstitial.add_OnAdRevenuePaidEvent(value:  new System.Action<System.String, AdInfo>(object:  this.<>4__this, method:  System.Void ApplovinMaxPlugin::OnInterstitialAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)));
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  15f);
        this.<>1__state = 2;
        val_10 = 1;
        return (bool)val_10;
        label_1:
        this.<>1__state = 0;
        31431.LoadInterstitial();
        label_3:
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
