using UnityEngine;
public class TRVExpertReadyPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button closeButton;
    
    // Methods
    private void OnEnable()
    {
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertReadyPopup::Continue()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertReadyPopup::Close()));
    }
    private void Continue()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.gameObject.GetComponent<WGFlyoutWindow>())) != false)
        {
                GameBehavior val_4 = App.getBehavior;
        }
        else
        {
                GameBehavior val_6 = App.getBehavior;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVExpertReadyPopup()
    {
    
    }

}
