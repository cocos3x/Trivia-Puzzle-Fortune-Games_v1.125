using UnityEngine;
public class WGPushNotificationPrompt : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button yesButton;
    private UnityEngine.UI.Button noThanksButton;
    
    // Methods
    private void Awake()
    {
        this.yesButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGPushNotificationPrompt::OnClickYes()));
        this.noThanksButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGPushNotificationPrompt::OnClickNoThanks()));
        MonoSingleton<WGNotificationPromptManager>.Instance.SetPromptSeen();
    }
    private void OnClickYes()
    {
        MonoSingleton<WGNotificationPromptManager>.Instance.SetNotifVisibility(enabled:  true);
        this.gameObject.SetActive(value:  false);
    }
    private void OnClickNoThanks()
    {
        WGNotificationPromptManager val_1 = MonoSingleton<WGNotificationPromptManager>.Instance;
        this.gameObject.SetActive(value:  false);
    }
    public WGPushNotificationPrompt()
    {
    
    }

}
