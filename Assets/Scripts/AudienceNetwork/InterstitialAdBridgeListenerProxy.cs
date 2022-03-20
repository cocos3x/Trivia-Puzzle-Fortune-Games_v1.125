using UnityEngine;

namespace AudienceNetwork
{
    internal class InterstitialAdBridgeListenerProxy : AndroidJavaProxy
    {
        // Fields
        private AudienceNetwork.InterstitialAd interstitialAd;
        private readonly UnityEngine.AndroidJavaObject bridgedInterstitialAd;
        
        // Methods
        public InterstitialAdBridgeListenerProxy(AudienceNetwork.InterstitialAd interstitialAd, UnityEngine.AndroidJavaObject bridgedInterstitialAd)
        {
            this.interstitialAd = interstitialAd;
            this.bridgedInterstitialAd = bridgedInterstitialAd;
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
            if(this.interstitialAd.interstitialAdDidFailWithError == null)
            {
                    return;
            }
            
            this.interstitialAd.ExecuteOnMainThread(action:  new System.Action(object:  new InterstitialAdBridgeListenerProxy.<>c__DisplayClass3_0(), method:  System.Void InterstitialAdBridgeListenerProxy.<>c__DisplayClass3_0::<onError>b__0()));
        }
        private void onAdLoaded(UnityEngine.AndroidJavaObject ad)
        {
            if(this.interstitialAd != null)
            {
                    this.interstitialAd.LoadAdFromData();
                return;
            }
            
            throw new NullReferenceException();
        }
        private void onAdClicked(UnityEngine.AndroidJavaObject ad)
        {
            if(this.interstitialAd.interstitialAdDidClick == null)
            {
                    return;
            }
            
            this.interstitialAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.InterstitialAdBridgeListenerProxy::<onAdClicked>b__5_0()));
        }
        private void onInterstitialDisplayed(UnityEngine.AndroidJavaObject ad)
        {
        
        }
        private void onInterstitialDismissed(UnityEngine.AndroidJavaObject ad)
        {
            if(this.interstitialAd.interstitialAdDidClose == null)
            {
                    return;
            }
            
            this.interstitialAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.InterstitialAdBridgeListenerProxy::<onInterstitialDismissed>b__7_0()));
        }
        private void onLoggingImpression(UnityEngine.AndroidJavaObject ad)
        {
            if(this.interstitialAd.interstitialAdWillLogImpression == null)
            {
                    return;
            }
            
            this.interstitialAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.InterstitialAdBridgeListenerProxy::<onLoggingImpression>b__8_0()));
        }
        private void onInterstitialActivityDestroyed()
        {
            if(this.interstitialAd.interstitialAdActivityDestroyed == null)
            {
                    return;
            }
            
            this.interstitialAd.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.InterstitialAdBridgeListenerProxy::<onInterstitialActivityDestroyed>b__9_0()));
        }
        private void <onAdClicked>b__5_0()
        {
            this.interstitialAd.interstitialAdDidClick.Invoke();
        }
        private void <onInterstitialDismissed>b__7_0()
        {
            this.interstitialAd.interstitialAdDidClose.Invoke();
        }
        private void <onLoggingImpression>b__8_0()
        {
            this.interstitialAd.interstitialAdWillLogImpression.Invoke();
        }
        private void <onInterstitialActivityDestroyed>b__9_0()
        {
            this.interstitialAd.interstitialAdActivityDestroyed.Invoke();
        }
    
    }

}
