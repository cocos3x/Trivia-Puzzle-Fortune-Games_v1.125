using UnityEngine;
public class WGLeaguesBenefitsWindow : MonoBehaviour
{
    // Fields
    private UGUINetworkedButton joinClubButton;
    private UnityEngine.UI.Button showInfoButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text benifitText;
    
    // Methods
    private void Awake()
    {
        object val_14;
        UnityEngine.Events.UnityAction val_15;
        val_14 = this;
        System.Delegate val_2 = System.Delegate.Combine(a:  this.joinClubButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGLeaguesBenefitsWindow::OnConnectionClick(bool connected)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.joinClubButton.OnConnectionClick = val_2;
        this.showInfoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaguesBenefitsWindow::onClick_ShowInfo()));
        UnityEngine.Events.UnityAction val_4 = null;
        val_15 = val_4;
        val_4 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaguesBenefitsWindow::<Awake>b__4_0());
        this.closeButton.m_OnClick.AddListener(call:  val_4);
        if(this.benifitText == 0)
        {
                return;
        }
        
        GameBehavior val_6 = App.getBehavior;
        val_14 = ???;
        val_15 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_3:
    }
    private void onClick_ShowInfo()
    {
        var val_7;
        System.Action val_9;
        GameBehavior val_1 = App.getBehavior;
        SLCWindow val_3 = val_1.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_7 = null;
        val_7 = null;
        val_9 = WGLeaguesBenefitsWindow.<>c.<>9__5_0;
        if(val_9 == null)
        {
                System.Action val_4 = null;
            val_9 = val_4;
            val_4 = new System.Action(object:  WGLeaguesBenefitsWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGLeaguesBenefitsWindow.<>c::<onClick_ShowInfo>b__5_0());
            WGLeaguesBenefitsWindow.<>c.<>9__5_0 = val_9;
        }
        
        System.Delegate val_5 = System.Delegate.Combine(a:  val_3.Action_OnClose, b:  val_4);
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        val_3.Action_OnClose = val_5;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_13:
    }
    private void OnConnectionClick(bool connected)
    {
        var val_16;
        string val_17;
        int val_18;
        var val_19;
        var val_20;
        if(connected == false)
        {
            goto label_1;
        }
        
        if(SceneDictator.IsInGameScene() == false)
        {
            goto label_4;
        }
        
        var val_4 = ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) ? (14 + 1) : 14;
        goto label_8;
        label_1:
        GameBehavior val_5 = App.getBehavior;
        val_17 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
        bool[] val_9 = new bool[2];
        val_9[0] = true;
        string[] val_10 = new string[2];
        val_18 = val_10.Length;
        val_10[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_18 = val_10.Length;
        val_10[1] = "NULL";
        val_19 = null;
        val_19 = null;
        val_5.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  val_17, messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_9, buttonTexts:  val_10, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        goto label_35;
        label_4:
        val_16 = 13;
        label_8:
        val_17 = 1152921504887996416;
        val_20 = null;
        val_20 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 13;
        GameBehavior val_12 = App.getBehavior;
        if((val_12.<metaGameBehavior>k__BackingField) != 4)
        {
                GameBehavior val_13 = App.getBehavior;
        }
        
        label_35:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGLeaguesBenefitsWindow()
    {
    
    }
    private void <Awake>b__4_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
