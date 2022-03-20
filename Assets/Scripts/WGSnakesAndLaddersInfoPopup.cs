using UnityEngine;
public class WGSnakesAndLaddersInfoPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button closeButton;
    
    // Methods
    private void Awake()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSnakesAndLaddersInfoPopup::Close()));
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGSnakesAndLaddersInfoPopup()
    {
    
    }

}
