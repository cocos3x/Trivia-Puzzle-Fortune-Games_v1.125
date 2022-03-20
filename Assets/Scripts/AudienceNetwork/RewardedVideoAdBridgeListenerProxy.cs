using UnityEngine;

namespace AudienceNetwork
{
    internal class RewardedVideoAdBridgeListenerProxy : AndroidJavaProxy
    {
        // Fields
        private AudienceNetwork.RewardedVideoAd rewardedVideoAd;
        private readonly UnityEngine.AndroidJavaObject bridgedRewardedVideoAd;
        
        // Methods
        public RewardedVideoAdBridgeListenerProxy(AudienceNetwork.RewardedVideoAd rewardedVideoAd, UnityEngine.AndroidJavaObject bridgedRewardedVideoAd)
        {
            this.rewardedVideoAd = rewardedVideoAd;
            this.bridgedRewardedVideoAd = bridgedRewardedVideoAd;
        }
        private void onError(UnityEngine.AndroidJavaObject ad, UnityEngine.AndroidJavaObject error)
        {
            var val_4;
            .<>4__this = this;
            val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            .errorMessage = error.Call<System.String>(methodName:  "getErrorMessage", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            if(this.rewardedVideoAd.rewardedVideoAdDidFailWithError == null)
            {
                    return;
            }
            
            this.rewardedVideoAd.ExecuteOnMainThread(action:  new System.Action(object:  new RewardedVideoAdBridgeListenerProxy.<>c__DisplayClass3_0(), method:  System.Void RewardedVideoAdBridgeListenerProxy.<>c__DisplayClass3_0::<onError>b__0()));
        }
        private void onAdLoaded(UnityEngine.AndroidJavaObject ad)
        {
            if(this.rewardedVideoAd != null)
            {
                    this.rewardedVideoAd.LoadAdFromData();
                return;
            }
            
            throw new NullReferenceException();
        }
        private void onAdClicked(UnityEngine.AndroidJavaObject ad)
        {
            if(this.rewardedVideoAd.rewardedVideoAdDidClick == null)
            {
                    return;
            }
            
            this.rewardedVideoAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.RewardedVideoAdBridgeListenerProxy::<onAdClicked>b__5_0()));
        }
        private void onRewardedVideoDisplayed(UnityEngine.AndroidJavaObject ad)
        {
            System.Action val_1 = 23527;
            if(this.rewardedVideoAd.rewardedVideoAdWillLogImpression == null)
            {
                    return;
            }
            
            val_1 = new System.Action(object:  this, method:  System.Void AudienceNetwork.RewardedVideoAdBridgeListenerProxy::<onRewardedVideoDisplayed>b__6_0());
            this.rewardedVideoAd.ExecuteOnMainThread(action:  val_1);
        }
        private void onRewardedVideoClosed()
        {
            if(this.rewardedVideoAd.rewardedVideoAdDidClose == null)
            {
                    return;
            }
            
            this.rewardedVideoAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.RewardedVideoAdBridgeListenerProxy::<onRewardedVideoClosed>b__7_0()));
        }
        private void onRewardedVideoCompleted()
        {
            if(this.rewardedVideoAd.rewardedVideoAdComplete == null)
            {
                    return;
            }
            
            this.rewardedVideoAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.RewardedVideoAdBridgeListenerProxy::<onRewardedVideoCompleted>b__8_0()));
        }
        private void onRewardServerSuccess()
        {
            if(this.rewardedVideoAd.rewardedVideoAdDidSucceed == null)
            {
                    return;
            }
            
            this.rewardedVideoAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.RewardedVideoAdBridgeListenerProxy::<onRewardServerSuccess>b__9_0()));
        }
        private void onRewardServerFailed()
        {
            if(this.rewardedVideoAd.rewardedVideoAdDidFail == null)
            {
                    return;
            }
            
            this.rewardedVideoAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.RewardedVideoAdBridgeListenerProxy::<onRewardServerFailed>b__10_0()));
        }
        private void onLoggingImpression(UnityEngine.AndroidJavaObject ad)
        {
            if(this.rewardedVideoAd.rewardedVideoAdWillLogImpression == null)
            {
                    return;
            }
            
            this.rewardedVideoAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.RewardedVideoAdBridgeListenerProxy::<onLoggingImpression>b__11_0()));
        }
        private void onRewardedVideoActivityDestroyed()
        {
            if(this.rewardedVideoAd.rewardedVideoAdActivityDestroyed == null)
            {
                    return;
            }
            
            this.rewardedVideoAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.RewardedVideoAdBridgeListenerProxy::<onRewardedVideoActivityDestroyed>b__12_0()));
        }
        private void <onAdClicked>b__5_0()
        {
            this.rewardedVideoAd.rewardedVideoAdDidClick.Invoke();
        }
        private void <onRewardedVideoDisplayed>b__6_0()
        {
            this.rewardedVideoAd.rewardedVideoAdWillLogImpression.Invoke();
        }
        private void <onRewardedVideoClosed>b__7_0()
        {
            this.rewardedVideoAd.rewardedVideoAdDidClose.Invoke();
        }
        private void <onRewardedVideoCompleted>b__8_0()
        {
            this.rewardedVideoAd.rewardedVideoAdComplete.Invoke();
        }
        private void <onRewardServerSuccess>b__9_0()
        {
            this.rewardedVideoAd.rewardedVideoAdDidSucceed.Invoke();
        }
        private void <onRewardServerFailed>b__10_0()
        {
            this.rewardedVideoAd.rewardedVideoAdDidFail.Invoke();
        }
        private void <onLoggingImpression>b__11_0()
        {
            this.rewardedVideoAd.rewardedVideoAdWillLogImpression.Invoke();
        }
        private void <onRewardedVideoActivityDestroyed>b__12_0()
        {
            this.rewardedVideoAd.rewardedVideoAdActivityDestroyed.Invoke();
        }
    
    }

}
