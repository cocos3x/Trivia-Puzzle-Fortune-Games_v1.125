using UnityEngine;
[Serializable]
public class ProductConfig
{
    // Fields
    public string appName;
    public string packageName;
    public string gameCode;
    public string freeOrHd;
    public System.Collections.Generic.List<string> icons;
    public System.Collections.Generic.List<string> splashScreens;
    public System.Collections.Generic.List<string> allowedOrientations;
    public string marketUrl;
    public string applovinSdkKey;
    public string helpshiftApiKey;
    public string helpshiftDomainName;
    public string helpshiftAppId;
    public string adjustAppToken;
    public string singularAppToken;
    public string bannerAdUnitId;
    public string rewardedVideAdUnitId;
    public string interstitialAdUnitId;
    public string safeDKAppId;
    public string safeDKAppKey;
    public string adMobAppID;
    
    // Methods
    public ProductConfig()
    {
        this.appName = "";
        this.packageName = "";
        this.gameCode = "";
        this.freeOrHd = "free|hd";
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "Assets/Game/Art/UI/Icon/bslots/196a.png");
        val_1.Add(item:  "Assets/Game/Art/UI/Icon/bslots/144a.png");
        val_1.Add(item:  "Assets/Game/Art/UI/Icon/bslots/96a.png");
        val_1.Add(item:  "Assets/Game/Art/UI/Icon/bslots/72a.png");
        val_1.Add(item:  "Assets/Game/Art/UI/Icon/bslots/48a.png");
        val_1.Add(item:  "Assets/Game/Art/UI/Icon/bslots/36a.png");
        this.icons = val_1;
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        val_2.Add(item:  "Assets/Game/Art/UI/Icon/bslots/splash-android.png");
        this.splashScreens = val_2;
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>();
        val_3.Add(item:  "LANDSCAPE_RIGHT");
        val_3.Add(item:  "LANDSCAPE_LEFT");
        this.allowedOrientations = val_3;
        this.marketUrl = "Marke URL of this app";
        this.applovinSdkKey = "";
        this.helpshiftApiKey = "";
        this.helpshiftAppId = "";
        this.adjustAppToken = "";
        this.helpshiftDomainName = "Domain Name for Helpshift";
        this.rewardedVideAdUnitId = "";
        this.interstitialAdUnitId = "";
        this.safeDKAppId = "";
        this.safeDKAppKey = "";
        this.adMobAppID = "";
        this.singularAppToken = "37e39f320951fdc5297544ebf2825322";
        this.bannerAdUnitId = "";
    }

}
