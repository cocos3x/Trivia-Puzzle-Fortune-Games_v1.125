using UnityEngine;
public class UnlockableUIWordIQ : WGUnlockableUIElement
{
    // Fields
    private UnityEngine.UI.Text wordIQText;
    private UnityEngine.UI.Button infoButton;
    
    // Properties
    protected override bool FeatureHidden { get; }
    protected override int UnlockLevel { get; }
    
    // Methods
    protected override void Start()
    {
        this.Start();
        this.infoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void UnlockableUIWordIQ::InfoButtonClicked()));
    }
    protected override bool get_FeatureHidden()
    {
        GameEcon val_2 = App.getGameEcon;
        return (bool)(App.Player < val_2.iqButtonDisplayLevel) ? 1 : 0;
    }
    protected override int get_UnlockLevel()
    {
        return 0;
    }
    protected override void SetNewState(WGUnlockableUIElement.UiLockedState newState)
    {
        string val_4 = System.String.Format(format:  "WORD IQ : {0}", arg0:  WordIQManagerUI.FormatPoints(iqPoints:  MonoSingleton<WordIQManager>.Instance.PlayerIQ));
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    protected override void OnClickUnlocked()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WordIQFoundWordsMenu>(showNext:  false);
    }
    private void InfoButtonClicked()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WordIQInfoPopup>(showNext:  false);
    }
    public UnlockableUIWordIQ()
    {
    
    }

}
