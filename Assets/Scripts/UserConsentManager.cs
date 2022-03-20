using UnityEngine;
public class UserConsentManager : MonoBehaviour
{
    // Fields
    public const string UnlockSceneLoading = "UnlockSceneLoading";
    private UnityEngine.GameObject userConsentPopup;
    
    // Methods
    private void Start()
    {
        Player val_1 = App.Player;
        if(val_1.properties.ShouldShowGdprConsent() != false)
        {
                NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "GDPRConsented");
            this.userConsentPopup.SetActive(value:  true);
            return;
        }
        
        this.GDPRConsented();
    }
    private void GDPRConsented()
    {
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "UnlockSceneLoading");
    }
    public UserConsentManager()
    {
    
    }

}
