using UnityEngine;
public class WGFreeAdsControlPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text title;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Text continueText;
    private UnityEngine.UI.Button continueButton;
    
    // Methods
    private void OnEnable()
    {
        string val_11;
        if(this.title != 0)
        {
                string val_2 = Localization.Localize(key:  "thank_you_e_upper", defaultValue:  "THANK YOU!", useSingularKey:  false);
        }
        
        if(this.description != 0)
        {
                val_11 = Localization.Localize(key:  "free_ads_control_success_description", defaultValue:  "Thank you for watching!\n\nAds are removed for the next {0} levels", useSingularKey:  false);
            GameEcon val_5 = App.getGameEcon;
            string val_6 = System.String.Format(format:  val_11, arg0:  val_5.postLevelAdsControl_duration);
        }
        
        if(this.continueText != 0)
        {
                string val_8 = Localization.Localize(key:  "continue_upper", defaultValue:  "CONTINUE", useSingularKey:  false);
        }
        
        if(this.continueButton == 0)
        {
                return;
        }
        
        UnityEngine.Events.UnityAction val_10 = null;
        val_11 = val_10;
        val_10 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFreeAdsControlPopup::OnContinueButtonClicked());
        this.continueButton.m_OnClick.AddListener(call:  val_10);
    }
    private void OnContinueButtonClicked()
    {
        this.gameObject.SetActive(value:  false);
    }
    public WGFreeAdsControlPopup()
    {
    
    }

}
