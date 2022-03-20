using UnityEngine;
public class FPHQotdPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Button closeButton;
    
    // Methods
    private void Awake()
    {
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHQotdPopup::OnClick_Play()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHQotdPopup::OnClick_Close()));
    }
    private void OnClick_Play()
    {
        MonoSingleton<FPHPhraseOfTheDayController>.Instance.Play();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public FPHQotdPopup()
    {
    
    }

}
