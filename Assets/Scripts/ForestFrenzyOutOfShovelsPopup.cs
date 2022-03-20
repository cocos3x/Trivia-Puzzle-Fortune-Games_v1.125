using UnityEngine;
public class ForestFrenzyOutOfShovelsPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Text playButtonText;
    
    // Methods
    private void Start()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestFrenzyOutOfShovelsPopup::OnCloseButtonClicked()));
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestFrenzyOutOfShovelsPopup::OnPlayButtonClicked()));
        string val_5 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        string val_9 = System.String.Format(format:  Localization.Localize(key:  "forest_frenzy_info_pg1", defaultValue:  "Play levels to collect {0}. Each {1} earns one SHOVEL.", useSingularKey:  false), arg0:  Localization.Localize(key:  "#currency", defaultValue:  "", useSingularKey:  false), arg1:  Localization.Localize(key:  "#currency_s", defaultValue:  "", useSingularKey:  false));
    }
    private void OnCloseButtonClicked()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnPlayButtonClicked()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        MonoSingleton<ForestFrenzyManager>.Instance.OnPlayLevelButtonClicked();
    }
    public ForestFrenzyOutOfShovelsPopup()
    {
    
    }

}
