using UnityEngine;
public class TRVPowerupFtuxWindow : MonoBehaviour
{
    // Methods
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVPowerupFtuxWindow()
    {
    
    }

}
