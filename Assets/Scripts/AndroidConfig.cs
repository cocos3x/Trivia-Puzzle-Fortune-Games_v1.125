using UnityEngine;
[Serializable]
public class AndroidConfig : ProductConfig
{
    // Fields
    public const string GCM_SENDER_ID = "769681372589";
    public string fcmSenderId;
    public string loadingDialogTitle;
    public string loadingDialogMessage;
    public string loadingDialogCurrency;
    public string supportUrl;
    public string supportText;
    public string androidPlatform;
    public string leaderboardId;
    public string googlePlayKey;
    public string cloudzillaKey;
    public string displayName;
    public string[] pushNotificationsIcons;
    
    // Methods
    public AndroidConfig()
    {
        int val_2;
        this.fcmSenderId = "408088123253";
        this.loadingDialogTitle = "TODO-SET-THIS";
        this.loadingDialogMessage = "";
        this.loadingDialogCurrency = "coins";
        this.supportUrl = "https://support.12gigs.com";
        this.supportText = "Support text stuff";
        this.androidPlatform = "google|kindle";
        this.leaderboardId = "CgkIm-eQjsIaEAIQBg";
        this.googlePlayKey = "Google purchases key";
        this.cloudzillaKey = "Cloudzilla purchases key";
        this.displayName = "";
        string[] val_1 = new string[2];
        val_2 = val_1.Length;
        val_1[0] = "Assets/Game/UI/WordAddict/Icons/24a.png";
        val_2 = val_1.Length;
        val_1[1] = "Assets/Game/UI/WordAddict/Icons/32a.png";
        this.pushNotificationsIcons = val_1;
    }

}
