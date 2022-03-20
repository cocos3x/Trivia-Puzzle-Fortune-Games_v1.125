using UnityEngine;
public class GameConfig : ScriptableObject
{
    // Fields
    public string vip_email;
    public string termsOfServiceURL;
    public string privacyPolicyUrl;
    public string facebookRecommenderUrl;
    public string recommenderUrl;
    public string adjustInviteUrl;
    public string twitterInviteURL;
    public string facebookViralText;
    public string twitterViralText;
    public string pinterestViralText;
    public string smsViralText;
    public string emailSubjectViralText;
    public string emailBodyViralText;
    public string appIndexDescription;
    public bool socialEnabled;
    public bool themesEnabled;
    public Themes[] allowedThemes;
    
    // Methods
    public GameConfig()
    {
        this.vip_email = "VIP Support Email";
        this.termsOfServiceURL = "https://www.superluckycasino.com/terms_of_service";
        this.privacyPolicyUrl = "https://www.superluckycasino.com/privacy_policy";
        this.facebookRecommenderUrl = "Redirect Url for Recommend (facebook)";
        this.recommenderUrl = "Redirect Url for Recommend";
        this.adjustInviteUrl = "https://app.adjust.com";
        this.twitterInviteURL = "defualtURL";
        this.facebookViralText = "facebookViralText";
        this.twitterViralText = "twitterViralText";
        this.pinterestViralText = "pinterestViralText";
        this.smsViralText = "smsViralText";
        this.emailSubjectViralText = "emailSubjectViralText";
        this.emailBodyViralText = "emailBodyViralText";
        this.appIndexDescription = "";
        Themes[] val_1 = new Themes[1];
        val_1[0] = 1;
        this.allowedThemes = val_1;
    }

}
