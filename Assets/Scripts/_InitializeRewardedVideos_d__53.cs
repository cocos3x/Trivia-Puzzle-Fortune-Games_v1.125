using UnityEngine;
private sealed class ApplovinMaxPlugin.<InitializeRewardedVideos>d__53 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public ApplovinMaxPlugin <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ApplovinMaxPlugin.<InitializeRewardedVideos>d__53(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_10;
        int val_11;
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
        val_10 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  5f);
        val_11 = 1;
        this.<>2__current = val_10;
        this.<>1__state = val_11;
        return (bool)val_11;
        label_1:
        this.<>1__state = 0;
        val_10 = this.<>4__this;
        MaxSdkCallbacks.add_OnRewardedAdLoadedEvent(value:  new System.Action<System.String>(object:  val_10, method:  System.Void ApplovinMaxPlugin::OnVideoLoaded(string adUnitId)));
        MaxSdkCallbacks.add_OnRewardedAdHiddenEvent(value:  new System.Action<System.String>(object:  val_10, method:  System.Void ApplovinMaxPlugin::OnVideoHidden(string adUnitId)));
        MaxSdkCallbacks.add_OnRewardedAdLoadFailedEvent(value:  new System.Action<System.String, System.Int32>(object:  val_10, method:  System.Void ApplovinMaxPlugin::OnVideoLoadFailed(string adUnitId, int errorCode)));
        MaxSdkCallbacks.add_OnRewardedAdFailedToDisplayEvent(value:  new System.Action<System.String, System.Int32>(object:  val_10, method:  System.Void ApplovinMaxPlugin::OnVideoFailedToShow(string adUnitId, int errorCode)));
        MaxSdkCallbacks.add_OnRewardedAdClickedEvent(value:  new System.Action<System.String>(object:  val_10, method:  System.Void ApplovinMaxPlugin::OnVideoClicked(string adUnitId)));
        MaxSdkCallbacks.add_OnRewardedAdReceivedRewardEvent(value:  new System.Action<System.String, Reward>(object:  val_10, method:  System.Void ApplovinMaxPlugin::OnVideoRewardReceived(string adUnitId, MaxSdkBase.Reward reward)));
        MaxSdkCallbacks.add_OnRewardedAdDisplayedEvent(value:  new System.Action<System.String>(object:  val_10, method:  System.Void ApplovinMaxPlugin::MaxSdkCallbacks_OnRewardedAdDisplayedEvent(string obj)));
        System.Action<System.String, AdInfo> val_9 = new System.Action<System.String, AdInfo>(object:  val_10, method:  System.Void ApplovinMaxPlugin::OnVideoRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adinfo));
        MaxSdkCallbacks.Rewarded.add_OnAdRevenuePaidEvent(value:  val_9);
        val_9.LoadRewardedVideo();
        label_2:
        val_11 = 0;
        return (bool)val_11;
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
