using UnityEngine;
public class SLCWindowSetting : MonoBehaviour
{
    // Fields
    public WGWindowBackgroundHandler.WGWindowBackgroundType backgroundType;
    public bool backButtonCanClose;
    public bool ShiftDownForBanner;
    
    // Methods
    public SLCWindowSetting()
    {
        this.backgroundType = 1;
        this.backButtonCanClose = 1;
    }

}
