using UnityEngine;
public class WGPetsScreenProxy : MonoBehaviour
{
    // Methods
    public void ShowPetsMainScreen()
    {
        WADPetsScreenUI.ShowMainScreen();
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGPetsScreenProxy()
    {
    
    }

}
