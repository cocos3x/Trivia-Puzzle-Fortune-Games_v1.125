using UnityEngine;
public class WGHelpMenuPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button howToPlayButton;
    private UGUINetworkedButton privacyButton;
    private UnityEngine.UI.Text versionText;
    private UnityEngine.UI.Text supportIDText;
    
    // Properties
    private string url_privacy { get; }
    
    // Methods
    private string get_url_privacy()
    {
        AppConfigs val_1 = App.Configuration;
        return (string)val_1.gameConfig.privacyPolicyUrl;
    }
    private void Awake()
    {
        if(this.howToPlayButton != 0)
        {
                this.howToPlayButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGHelpMenuPopup::OnClickHowToPlay()));
        }
        
        this.privacyButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGHelpMenuPopup::OnClick_Privacy(bool connected));
    }
    private void OnEnable()
    {
        string val_1 = DeviceIdPlugin.GetClientVersion();
        Player val_2 = App.Player;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnClick_Privacy(bool connected)
    {
        int val_16;
        var val_17;
        this.privacyButton.interactable = false;
        if(connected != false)
        {
                twelvegigs.plugins.SharePlugin.OpenURL(url:  this.privacyButton.url_privacy);
            this.privacyButton.interactable = true;
            return;
        }
        
        WGWindow val_3 = this.GetComponent<WGWindow>();
        .prevActionOnClose = new System.Action(object:  X22, method:  public System.Void System.Action::Invoke());
        WGWindowManager val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false);
        bool[] val_9 = new bool[2];
        val_9[0] = true;
        string[] val_10 = new string[2];
        val_16 = val_10.Length;
        val_10[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_16 = val_10.Length;
        val_10[1] = "NULL";
        val_17 = null;
        val_17 = null;
        val_6.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_9, buttonTexts:  val_10, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        WGWindow val_12 = val_6.GetComponent<WGWindow>();
        mem2[0] = new System.Action(object:  new WGHelpMenuPopup.<>c__DisplayClass8_0(), method:  System.Void WGHelpMenuPopup.<>c__DisplayClass8_0::<OnClick_Privacy>b__0());
        WGWindow val_14 = this.GetComponent<WGWindow>();
        mem2[0] = 0;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickHowToPlay()
    {
        SLCWindow val_2 = this.GetComponent<SLCWindow>();
        .prevOnClose = new System.Action(object:  val_2.Action_OnClose, method:  public System.Void System.Action::Invoke());
        WGWindow val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGHowToPlayPopup>(showNext:  false).GetComponent<WGWindow>();
        mem2[0] = new System.Action(object:  new WGHelpMenuPopup.<>c__DisplayClass9_0(), method:  System.Void WGHelpMenuPopup.<>c__DisplayClass9_0::<OnClickHowToPlay>b__0());
        WGWindow val_8 = this.GetComponent<WGWindow>();
        mem2[0] = 0;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGHelpMenuPopup()
    {
    
    }

}
