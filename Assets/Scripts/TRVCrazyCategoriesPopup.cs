using UnityEngine;
public class TRVCrazyCategoriesPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text descriptionText;
    private UnityEngine.UI.Text continueButtonText;
    
    // Methods
    private void OnEnable()
    {
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVCrazyCategoriesPopup::Close()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVCrazyCategoriesPopup::Close()));
        string val_4 = System.String.Format(format:  Localization.Localize(key:  "crazy_categories_description", defaultValue:  "Complete Crazy Category levels to earn {0}x more Stars", useSingularKey:  false), arg0:  TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 40);
        string val_5 = Localization.Localize(key:  "okay_upper", defaultValue:  "OKAY", useSingularKey:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnDisable()
    {
        if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
                return;
        }
        
        goto typeof(System.String).__il2cppRuntimeField_540;
    }
    public TRVCrazyCategoriesPopup()
    {
    
    }

}
