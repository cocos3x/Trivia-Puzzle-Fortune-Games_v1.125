using UnityEngine;
public class RewardedVideoAdScene : BaseScene
{
    // Fields
    private AudienceNetwork.RewardedVideoAd rewardedVideoAd;
    private bool isLoaded;
    private bool didClose;
    public UnityEngine.UI.Text statusLabel;
    
    // Methods
    private void Awake()
    {
        AudienceNetwork.AudienceNetworkAds.Initialize();
        SettingsScene.InitializeSettings();
    }
    public void LoadRewardedVideo()
    {
        var val_13;
        AudienceNetwork.FBRewardedVideoAdBridgeCallback val_15;
        var val_16;
        AudienceNetwork.FBRewardedVideoAdBridgeCallback val_18;
        var val_19;
        AudienceNetwork.FBRewardedVideoAdBridgeCallback val_21;
        var val_22;
        AudienceNetwork.FBRewardedVideoAdBridgeCallback val_24;
        this.rewardedVideoAd = new AudienceNetwork.RewardedVideoAd(placementId:  "YOUR_PLACEMENT_ID");
        .<UserId>k__BackingField = "USER_ID";
        .<Currency>k__BackingField = "REWARD_ID";
        AudienceNetwork.RewardedVideoAd val_3 = new AudienceNetwork.RewardedVideoAd(placementId:  "YOUR_PLACEMENT_ID", rewardData:  new AudienceNetwork.RewardData());
        this.rewardedVideoAd.Register(gameObject:  this.gameObject);
        this.rewardedVideoAd.RewardedVideoAdDidLoad = new AudienceNetwork.FBRewardedVideoAdBridgeCallback(object:  this, method:  System.Void RewardedVideoAdScene::<LoadRewardedVideo>b__5_0());
        this.rewardedVideoAd.RewardedVideoAdDidFailWithError = new AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback(object:  this, method:  System.Void RewardedVideoAdScene::<LoadRewardedVideo>b__5_1(string error));
        val_13 = null;
        val_13 = null;
        val_15 = RewardedVideoAdScene.<>c.<>9__5_2;
        if(val_15 == null)
        {
                AudienceNetwork.FBRewardedVideoAdBridgeCallback val_7 = null;
            val_15 = val_7;
            val_7 = new AudienceNetwork.FBRewardedVideoAdBridgeCallback(object:  RewardedVideoAdScene.<>c.__il2cppRuntimeField_static_fields, method:  System.Void RewardedVideoAdScene.<>c::<LoadRewardedVideo>b__5_2());
            RewardedVideoAdScene.<>c.<>9__5_2 = val_15;
        }
        
        this.rewardedVideoAd.RewardedVideoAdWillLogImpression = val_7;
        val_16 = null;
        val_16 = null;
        val_18 = RewardedVideoAdScene.<>c.<>9__5_3;
        if(val_18 == null)
        {
                AudienceNetwork.FBRewardedVideoAdBridgeCallback val_8 = null;
            val_18 = val_8;
            val_8 = new AudienceNetwork.FBRewardedVideoAdBridgeCallback(object:  RewardedVideoAdScene.<>c.__il2cppRuntimeField_static_fields, method:  System.Void RewardedVideoAdScene.<>c::<LoadRewardedVideo>b__5_3());
            RewardedVideoAdScene.<>c.<>9__5_3 = val_18;
        }
        
        this.rewardedVideoAd.RewardedVideoAdDidClick = val_8;
        val_19 = null;
        val_19 = null;
        val_21 = RewardedVideoAdScene.<>c.<>9__5_4;
        if(val_21 == null)
        {
                AudienceNetwork.FBRewardedVideoAdBridgeCallback val_9 = null;
            val_21 = val_9;
            val_9 = new AudienceNetwork.FBRewardedVideoAdBridgeCallback(object:  RewardedVideoAdScene.<>c.__il2cppRuntimeField_static_fields, method:  System.Void RewardedVideoAdScene.<>c::<LoadRewardedVideo>b__5_4());
            RewardedVideoAdScene.<>c.<>9__5_4 = val_21;
        }
        
        this.rewardedVideoAd.RewardedVideoAdDidSucceed = val_9;
        val_22 = null;
        val_22 = null;
        val_24 = RewardedVideoAdScene.<>c.<>9__5_5;
        if(val_24 == null)
        {
                AudienceNetwork.FBRewardedVideoAdBridgeCallback val_10 = null;
            val_24 = val_10;
            val_10 = new AudienceNetwork.FBRewardedVideoAdBridgeCallback(object:  RewardedVideoAdScene.<>c.__il2cppRuntimeField_static_fields, method:  System.Void RewardedVideoAdScene.<>c::<LoadRewardedVideo>b__5_5());
            RewardedVideoAdScene.<>c.<>9__5_5 = val_24;
        }
        
        this.rewardedVideoAd.RewardedVideoAdDidFail = val_10;
        this.rewardedVideoAd.RewardedVideoAdDidClose = new AudienceNetwork.FBRewardedVideoAdBridgeCallback(object:  this, method:  System.Void RewardedVideoAdScene::<LoadRewardedVideo>b__5_6());
        this.rewardedVideoAd.RewardedVideoAdActivityDestroyed = new AudienceNetwork.FBRewardedVideoAdBridgeCallback(object:  this, method:  System.Void RewardedVideoAdScene::<LoadRewardedVideo>b__5_7());
        this.rewardedVideoAd.LoadAd();
    }
    public void ShowRewardedVideo()
    {
        var val_3;
        if(this.isLoaded != false)
        {
                bool val_1 = this.rewardedVideoAd.Show();
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
        if(this.rewardedVideoAd != null)
        {
                this.rewardedVideoAd.Dispose();
        }
        
        UnityEngine.Debug.Log(message:  "RewardedVideoAdTest was destroyed!");
    }
    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "InterstitialAdScene");
    }
    public RewardedVideoAdScene()
    {
    
    }
    private void <LoadRewardedVideo>b__5_0()
    {
        UnityEngine.Debug.Log(message:  "RewardedVideo ad loaded.");
        this.isLoaded = true;
        this.didClose = false;
        string val_3 = "Ad loaded and is " + (this.rewardedVideoAd.IsValid() != true) ? "valid" : "invalid"((this.rewardedVideoAd.IsValid() != true) ? "valid" : "invalid") + ". Click show to present!"(". Click show to present!");
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void <LoadRewardedVideo>b__5_1(string error)
    {
        UnityEngine.Debug.Log(message:  "RewardedVideo ad failed to load with error: "("RewardedVideo ad failed to load with error: ") + error);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void <LoadRewardedVideo>b__5_6()
    {
        UnityEngine.Debug.Log(message:  "Rewarded video ad did close.");
        this.didClose = true;
        if(this.rewardedVideoAd == null)
        {
                return;
        }
        
        this.rewardedVideoAd.Dispose();
    }
    private void <LoadRewardedVideo>b__5_7()
    {
        if(this.didClose != false)
        {
                return;
        }
        
        UnityEngine.Debug.Log(message:  "Rewarded video activity destroyed without being closed first.");
        UnityEngine.Debug.Log(message:  "Game should resume. User should not get a reward.");
    }

}
