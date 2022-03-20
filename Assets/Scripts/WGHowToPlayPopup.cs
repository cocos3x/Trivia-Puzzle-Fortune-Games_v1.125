using UnityEngine;
public class WGHowToPlayPopup : MonoBehaviour
{
    // Fields
    private UGUIPageDisplay pageDisplay;
    
    // Methods
    public void OpenToPageIndex(int index)
    {
        if(this.pageDisplay == 0)
        {
                return;
        }
        
        this.pageDisplay.SetToPage(index:  index, force:  false);
    }
    public void CloseWindow()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGHowToPlayPopup()
    {
    
    }

}
