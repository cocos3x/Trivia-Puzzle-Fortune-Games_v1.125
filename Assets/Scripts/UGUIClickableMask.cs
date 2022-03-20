using UnityEngine;
public class UGUIClickableMask : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button;
    public System.Action OnClickAction;
    
    // Methods
    private void Awake()
    {
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void UGUIClickableMask::OnButtonClick()));
    }
    private void OnButtonClick()
    {
        if(this.OnClickAction == null)
        {
                return;
        }
        
        this.OnClickAction.Invoke();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public UGUIClickableMask()
    {
    
    }

}
