using UnityEngine;
public class InterstitialAdScene : BaseScene
{
    // Fields
    private AudienceNetwork.InterstitialAd interstitialAd;
    private bool isLoaded;
    private bool didClose;
    public UnityEngine.UI.Text statusLabel;
    
    // Methods
    private void Awake()
    {
        AudienceNetwork.AudienceNetworkAds.Initialize();
        SettingsScene.InitializeSettings();
    }
    public void LoadInterstitial()
    {
        var val_9;
        AudienceNetwork.FBInterstitialAdBridgeCallback val_11;
        var val_12;
        AudienceNetwork.FBInterstitialAdBridgeCallback val_14;
        AudienceNetwork.InterstitialAd val_1 = new AudienceNetwork.InterstitialAd(placementId:  "YOUR_PLACEMENT_ID");
        this.interstitialAd = val_1;
        val_1.Register(gameObject:  this.gameObject);
        this.interstitialAd.InterstitialAdDidLoad = new AudienceNetwork.FBInterstitialAdBridgeCallback(object:  this, method:  System.Void InterstitialAdScene::<LoadInterstitial>b__5_0());
        this.interstitialAd.InterstitialAdDidFailWithError = new AudienceNetwork.FBInterstitialAdBridgeErrorCallback(object:  this, method:  System.Void InterstitialAdScene::<LoadInterstitial>b__5_1(string error));
        val_9 = null;
        val_9 = null;
        val_11 = InterstitialAdScene.<>c.<>9__5_2;
        if(val_11 == null)
        {
                AudienceNetwork.FBInterstitialAdBridgeCallback val_5 = null;
            val_11 = val_5;
            val_5 = new AudienceNetwork.FBInterstitialAdBridgeCallback(object:  InterstitialAdScene.<>c.__il2cppRuntimeField_static_fields, method:  System.Void InterstitialAdScene.<>c::<LoadInterstitial>b__5_2());
            InterstitialAdScene.<>c.<>9__5_2 = val_11;
        }
        
        this.interstitialAd.InterstitialAdWillLogImpression = val_5;
        val_12 = null;
        val_12 = null;
        val_14 = InterstitialAdScene.<>c.<>9__5_3;
        if(val_14 == null)
        {
                AudienceNetwork.FBInterstitialAdBridgeCallback val_6 = null;
            val_14 = val_6;
            val_6 = new AudienceNetwork.FBInterstitialAdBridgeCallback(object:  InterstitialAdScene.<>c.__il2cppRuntimeField_static_fields, method:  System.Void InterstitialAdScene.<>c::<LoadInterstitial>b__5_3());
            InterstitialAdScene.<>c.<>9__5_3 = val_14;
        }
        
        this.interstitialAd.InterstitialAdDidClick = val_6;
        this.interstitialAd.InterstitialAdDidClose = new AudienceNetwork.FBInterstitialAdBridgeCallback(object:  this, method:  System.Void InterstitialAdScene::<LoadInterstitial>b__5_4());
        this.interstitialAd.interstitialAdActivityDestroyed = new AudienceNetwork.FBInterstitialAdBridgeCallback(object:  this, method:  System.Void InterstitialAdScene::<LoadInterstitial>b__5_5());
        this.interstitialAd.LoadAd();
    }
    public void ShowInterstitial()
    {
        var val_3;
        if(this.isLoaded != false)
        {
                bool val_1 = this.interstitialAd.Show();
            this.isLoaded = false;
            val_3 = "";
        }
        else
        {
                val_3 = "Ad not loaded. Click load to request an ad.";
        }
    
    }
    private void OnDestroy()
    {
        if(this.interstitialAd != null)
        {
                this.interstitialAd.Dispose();
        }
        
        UnityEngine.Debug.Log(message:  "InterstitialAdTest was destroyed!");
    }
    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "AdViewScene");
    }
    public InterstitialAdScene()
    {
    
    }
    private void <LoadInterstitial>b__5_0()
    {
        UnityEngine.Debug.Log(message:  "Interstitial ad loaded.");
        this.isLoaded = true;
        this.didClose = false;
        string val_3 = "Ad loaded and is " + (this.interstitialAd.IsValid() != true) ? "valid" : "invalid"((this.interstitialAd.IsValid() != true) ? "valid" : "invalid") + 1152921504784588800;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void <LoadInterstitial>b__5_1(string error)
    {
        UnityEngine.Debug.Log(message:  "Interstitial ad failed to load with error: "("Interstitial ad failed to load with error: ") + error);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void <LoadInterstitial>b__5_4()
    {
        UnityEngine.Debug.Log(message:  "Interstitial ad did close.");
        this.didClose = true;
        if(this.interstitialAd == null)
        {
                return;
        }
        
        this.interstitialAd.Dispose();
    }
    private void <LoadInterstitial>b__5_5()
    {
        if(this.didClose != false)
        {
                return;
        }
        
        UnityEngine.Debug.Log(message:  "Interstitial activity destroyed without being closed first.");
        UnityEngine.Debug.Log(message:  "Game should resume.");
    }

}
