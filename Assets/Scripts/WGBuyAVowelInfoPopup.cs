using UnityEngine;
public class WGBuyAVowelInfoPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text playButtonText;
    private UnityEngine.UI.Text timerText;
    
    // Methods
    private void Awake()
    {
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBuyAVowelInfoPopup::OnClick_PlayButton()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBuyAVowelInfoPopup::OnClick_PlayButton()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGBuyAVowelInfoPopup).__il2cppRuntimeField_178));
        string val_6 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        FrameSkipper val_8 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        System.Delegate val_10 = System.Delegate.Combine(a:  val_8.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGBuyAVowelInfoPopup::UpdateEventTimer()));
        if(val_10 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        val_8.updateLogic = val_10;
        return;
        label_13:
    }
    private void Start()
    {
        this.continueButton.gameObject.SetActive(value:  SceneDictator.IsInGameScene());
        this.playButton.gameObject.SetActive(value:  (~SceneDictator.IsInGameScene()) & 1);
    }
    private void UpdateEventTimer()
    {
        string val_1 = BuyAVowelEventHandler.<Instance>k__BackingField.GetEventRemainingTime();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_PlayButton()
    {
        if(SceneDictator.IsInGameScene() != true)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    protected virtual void OnClick_CloseButton()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGBuyAVowelInfoPopup()
    {
    
    }

}
