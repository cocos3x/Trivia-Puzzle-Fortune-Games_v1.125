using UnityEngine;
[Serializable]
public class IosConfig : ProductConfig
{
    // Fields
    public string KEYCHAIN_ACCESS_GROUP;
    public string adjustUniversalLinkUrl;
    public string supportUrl;
    public bool firebaseAnalyticsEnabled;
    
    // Methods
    public IosConfig()
    {
        this.KEYCHAIN_ACCESS_GROUP = "(PROG) X21398N7BWE";
        this.adjustUniversalLinkUrl = "TODO-SET-THIS";
        this.supportUrl = "https://support.12gigs.com";
    }

}
