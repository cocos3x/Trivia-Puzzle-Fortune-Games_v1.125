using UnityEngine;
public class WGVipPartyEventInfoPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text timer;
    private UnityEngine.GameObject nonVipGroup;
    private UnityEngine.GameObject vipGroup;
    private UnityEngine.UI.Button getVipButton;
    private UnityEngine.UI.Button closeButton;
    private FrameSkipper frameSkipper;
    private bool fromLevelComplete;
    private System.Action onStoreCloseAction;
    
    // Methods
    private void Awake()
    {
        this.nonVipGroup.SetActive(value:  false);
        this.vipGroup.SetActive(value:  false);
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGVipPartyEventInfoPopup::Close()));
        this.getVipButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGVipPartyEventInfoPopup::OpenStore()));
        this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGVipPartyEventInfoPopup::UpdateTimer()));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
        val_4.updateLogic = val_6;
        return;
        label_9:
    }
    private void OnEnable()
    {
        this.nonVipGroup.SetActive(value:  (typeof(VIPPartyEventInfo).__il2cppRuntimeField_28 == 0) ? 1 : 0);
        this.vipGroup.SetActive(value:  (typeof(VIPPartyEventInfo).__il2cppRuntimeField_28 != 0) ? 1 : 0);
    }
    public void Init(bool levelComplete = False, System.Action onCloseAction)
    {
        this.onStoreCloseAction = onCloseAction;
        this.fromLevelComplete = levelComplete;
    }
    private void UpdateTimer()
    {
        string val_1 = VIPPartyEventHandler.instance.GetEventRemainingTime();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OpenStore()
    {
        if(this.fromLevelComplete != false)
        {
                GameBehavior val_1 = App.getBehavior;
            val_1.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  this.onStoreCloseAction);
        }
        else
        {
                bool val_4 = MonoSingletonSelfGenerating<WGStoreController>.Instance.OpenStore(forceShowNext:  true);
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGVipPartyEventInfoPopup()
    {
    
    }

}
