using UnityEngine;
public class WGGameSceneFlyoutProxy : MonoBehaviour
{
    // Fields
    private System.Action onShowCallback;
    
    // Methods
    public void setCallback(System.Action theCallback)
    {
        this.onShowCallback = theCallback;
    }
    private void OnEnable()
    {
        if(this.onShowCallback == null)
        {
                return;
        }
        
        this.onShowCallback.Invoke();
    }
    public void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    public WGGameSceneFlyoutProxy()
    {
    
    }

}
