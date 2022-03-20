using UnityEngine;
public class WGUserConsentPopup : MonoBehaviour
{
    // Fields
    public const string GDPRConsented = "GDPRConsented";
    private UnityEngine.UI.Button Button_Continue;
    private UnityEngine.UI.Button Button_TermsOfService;
    private UnityEngine.UI.Button Button_PrivacyPolicy;
    
    // Properties
    private string url_tos { get; }
    private string url_privacy { get; }
    
    // Methods
    private string get_url_tos()
    {
        AppConfigs val_1 = App.Configuration;
        return (string)val_1.gameConfig.termsOfServiceURL;
    }
    private string get_url_privacy()
    {
        AppConfigs val_1 = App.Configuration;
        return (string)val_1.gameConfig.privacyPolicyUrl;
    }
    private void Awake()
    {
        this.Button_Continue.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGUserConsentPopup::OnClick_Continue()));
        this.Button_TermsOfService.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGUserConsentPopup::OnClick_TermsOfService()));
        this.Button_PrivacyPolicy.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGUserConsentPopup::OnClick_PrivacyPolicy()));
    }
    private void OnClick_Continue()
    {
        Player val_1 = App.Player;
        val_1.properties.gdprConsent = true;
        Player val_2 = App.Player;
        val_2.properties.Save(writePrefs:  true);
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  true, reset:  false);
        this.gameObject.SetActive(value:  false);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "GDPRConsented");
    }
    private void OnClick_TermsOfService()
    {
        twelvegigs.plugins.SharePlugin.OpenURL(url:  this.url_tos);
    }
    private void OnClick_PrivacyPolicy()
    {
        twelvegigs.plugins.SharePlugin.OpenURL(url:  this.url_privacy);
    }
    public WGUserConsentPopup()
    {
    
    }

}
