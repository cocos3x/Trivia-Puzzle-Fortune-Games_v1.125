using UnityEngine;
public class TRVOutOfQuestionsPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button okButton;
    
    // Methods
    private void Awake()
    {
        this.okButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVOutOfQuestionsPopup::OnClick_OK()));
    }
    private void OnClick_OK()
    {
        GameBehavior val_1 = App.getBehavior;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVOutOfQuestionsPopup()
    {
    
    }

}
