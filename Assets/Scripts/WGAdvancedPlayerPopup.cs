using UnityEngine;
public class WGAdvancedPlayerPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button CloseBtn;
    private UnityEngine.UI.Button SkipBtn;
    private UnityEngine.UI.Button DeclineBtn;
    
    // Methods
    private void Start()
    {
        this.CloseBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGAdvancedPlayerPopup::Close()));
        this.DeclineBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGAdvancedPlayerPopup::Close()));
        this.SkipBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGAdvancedPlayerPopup::SkipLevels()));
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void SkipLevels()
    {
        this.SkipBtn.enabled = false;
        Player val_1 = App.Player;
        val_1.properties.AdvancedSkipLevel = MonoSingleton<WGFTUXManager>.Instance.AdvancedPlayerLevelSkip;
        Player val_4 = App.Player;
        val_4.properties.Save(writePrefs:  true);
        MonoSingleton<WGFTUXManager>.Instance.SkipToLevel(level:  MonoSingleton<WGFTUXManager>.Instance.AdvancedPlayerLevelSkip);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGAdvancedPlayerPopup()
    {
    
    }

}
