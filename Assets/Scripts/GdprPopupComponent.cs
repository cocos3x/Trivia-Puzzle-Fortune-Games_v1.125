using UnityEngine;
public class GdprPopupComponent : AppComponent
{
    // Properties
    public override bool RunInMainThread { get; }
    
    // Methods
    public override bool get_RunInMainThread()
    {
        return true;
    }
    public GdprPopupComponent(string gameName, string gameObjectName)
    {
        mem[1152921515588762880] = "GdprPopupComponent";
    }
    public override void initializeOnMainThread()
    {
    
    }
    public override void onInitialServerUpdate()
    {
        this.ShowGdprPopup();
    }
    public override void onServerUpdate()
    {
        this.ShowGdprPopup();
    }
    private void ShowGdprPopup()
    {
        Player val_1 = App.Player;
        if(val_1.properties.ShouldShowGdprConsent() == false)
        {
                return;
        }
        
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGUserConsentPopup>(showNext:  false);
    }

}
