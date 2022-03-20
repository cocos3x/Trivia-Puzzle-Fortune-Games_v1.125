using UnityEngine;
public class WGUpdatePromptPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button update_button;
    private UnityEngine.UI.Button close_button;
    private string current_url;
    
    // Methods
    private void Awake()
    {
        this.update_button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGUpdatePromptPopup::OnClick_update()));
        this.close_button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGUpdatePromptPopup::OnClick_close()));
    }
    public void Setup(string url, bool mustUpdate)
    {
        this.close_button.gameObject.SetActive(value:  (~mustUpdate) & 1);
        this.current_url = url;
    }
    private void OnEnable()
    {
    
    }
    private void OnClick_update()
    {
        twelvegigs.plugins.SharePlugin.OpenURL(url:  this.current_url);
    }
    private void OnClick_close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGUpdatePromptPopup()
    {
        this.current_url = "";
    }

}
