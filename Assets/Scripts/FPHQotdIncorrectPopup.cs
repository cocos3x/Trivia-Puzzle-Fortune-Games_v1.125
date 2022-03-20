using UnityEngine;
public class FPHQotdIncorrectPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button okButton;
    
    // Methods
    private void Awake()
    {
        this.okButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHQotdIncorrectPopup::OnClick_OK()));
    }
    private void OnClick_OK()
    {
        MonoSingleton<FPHPhraseOfTheDayController>.Instance.Complete();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public FPHQotdIncorrectPopup()
    {
    
    }

}
