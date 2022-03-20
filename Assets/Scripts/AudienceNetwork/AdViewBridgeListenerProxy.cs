using UnityEngine;

namespace AudienceNetwork
{
    internal class AdViewBridgeListenerProxy : AndroidJavaProxy
    {
        // Fields
        private AudienceNetwork.AdView adView;
        private readonly UnityEngine.AndroidJavaObject bridgedAdView;
        
        // Methods
        public AdViewBridgeListenerProxy(AudienceNetwork.AdView adView, UnityEngine.AndroidJavaObject bridgedAdView)
        {
            this.adView = adView;
            this.bridgedAdView = bridgedAdView;
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
            if(this.adView.adViewDidFailWithError == null)
            {
                    return;
            }
            
            this.adView.ExecuteOnMainThread(action:  new System.Action(object:  new AdViewBridgeListenerProxy.<>c__DisplayClass3_0(), method:  System.Void AdViewBridgeListenerProxy.<>c__DisplayClass3_0::<onError>b__0()));
        }
        private void onAdLoaded(UnityEngine.AndroidJavaObject ad)
        {
            if(this.adView != null)
            {
                    this.adView.LoadAdFromData();
                return;
            }
            
            throw new NullReferenceException();
        }
        private void onAdClicked(UnityEngine.AndroidJavaObject ad)
        {
            if(this.adView.adViewDidClick == null)
            {
                    return;
            }
            
            this.adView.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.AdViewBridgeListenerProxy::<onAdClicked>b__5_0()));
        }
        private void onLoggingImpression(UnityEngine.AndroidJavaObject ad)
        {
            if(this.adView.adViewWillLogImpression == null)
            {
                    return;
            }
            
            this.adView.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.AdViewBridgeListenerProxy::<onLoggingImpression>b__6_0()));
        }
        private void <onAdClicked>b__5_0()
        {
            this.adView.adViewDidClick.Invoke();
        }
        private void <onLoggingImpression>b__6_0()
        {
            this.adView.adViewWillLogImpression.Invoke();
        }
    
    }

}
