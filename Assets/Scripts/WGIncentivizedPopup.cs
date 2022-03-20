using UnityEngine;
public class WGIncentivizedPopup : WGFreeHintPopup
{
    // Fields
    private UnityEngine.GameObject videoOverlayImage;
    private UnityEngine.GameObject videoNotAvailableText;
    private FrameSkipper skipper;
    private UnityEngine.GameObject watchVideoPopup;
    private UnityEngine.GameObject allIncenvtivesPopup;
    private UGUINetworkedButton FreeHintVideoButton;
    
    // Methods
    protected override void SetUp()
    {
        this.watchVideoPopup.gameObject.SetActive(value:  true);
        this.allIncenvtivesPopup.gameObject.SetActive(value:  false);
        mem[1152921517869748888] = this.FreeHintVideoButton;
        this.SetUp();
        this.skipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_4._framesToSkip = 15;
        this.skipper.updateLogic = new System.Action(object:  this, method:  System.Void WGIncentivizedPopup::CheckUI());
    }
    private void CheckUI()
    {
        this.ToggleVideoUI(state:  MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable());
    }
    private void ToggleVideoUI(bool state)
    {
        bool val_1 = state ^ 1;
        state = val_1;
        this.videoOverlayImage.SetActive(value:  state);
        this.videoOverlayImage.gameObject.SetActive(value:  state);
        this.videoNotAvailableText.gameObject.SetActive(value:  val_1);
    }
    public override void OnDisable()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<AdsUIController>.Instance)) != false)
        {
                MonoSingleton<AdsUIController>.Instance.SawFreeHint();
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        this.OnDisable();
    }
    public WGIncentivizedPopup()
    {
    
    }

}
