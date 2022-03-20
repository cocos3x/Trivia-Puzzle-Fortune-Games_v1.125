using UnityEngine;
public class WGSubscriptionButton : MonoBehaviour
{
    // Fields
    private WGSubscriptionButton.SubButtonLocation location;
    private SubscriptionHandler.SubScriptionType subPackage;
    public UGUINetworkedButton targetButton;
    private UnityEngine.GameObject targetParentObject;
    private UnityEngine.GameObject noSubGroup;
    private UnityEngine.UI.Text costText;
    private UnityEngine.GameObject hasSubGroup;
    private UnityEngine.GameObject purchaseSubscriptionWindow;
    private System.Action<bool> OnConnectionClick;
    private bool awaitingPing;
    
    // Methods
    private void Start()
    {
        UnityEngine.UI.Text val_1 = this.hasSubGroup.GetComponent<UnityEngine.UI.Text>();
        string val_2 = Localization.Localize(key:  "active_upper", defaultValue:  "Active", useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnEnable()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if(this.location == 2)
        {
                WGSubscriptionManager._subEntryPoint = (this.subPackage == 0) ? 35 : 59;
        }
        
            this.UpdateUI();
            this.targetButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void WGSubscriptionButton::onClickButton(bool result));
            return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void UpdateUI()
    {
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        UnityEngine.GameObject val_32;
        var val_34;
        var val_35;
        val_28 = this;
        val_29 = 1152921504884269056;
        val_30 = null;
        val_30 = null;
        if(App.game == 17)
        {
            goto label_6;
        }
        
        val_31 = null;
        val_31 = null;
        if(App.game != 19)
        {
            goto label_12;
        }
        
        label_6:
        if(this.hasSubGroup != 0)
        {
                this.hasSubGroup.SetActive(value:  MonoSingleton<WGSubscriptionManager>.Instance.hasAnySubscription());
        }
        
        if(this.noSubGroup == 0)
        {
            goto label_37;
        }
        
        val_32 = this.noSubGroup;
        bool val_7 = MonoSingleton<WGSubscriptionManager>.Instance.hasAnySubscription();
        if(val_32 != null)
        {
            goto label_26;
        }
        
        label_12:
        if(this.hasSubGroup != 0)
        {
                SubscriptionHandler.SubScriptionType val_28 = this.subPackage;
            val_28 = MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  val_28);
            this.hasSubGroup.SetActive(value:  val_28);
        }
        
        if(this.noSubGroup == 0)
        {
            goto label_37;
        }
        
        val_32 = this.noSubGroup;
        SubscriptionHandler.SubScriptionType val_29 = this.subPackage;
        label_26:
        val_29 = (~(MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  val_29))) & 1;
        val_32.SetActive(value:  val_29);
        label_37:
        if(this.costText == 0)
        {
                return;
        }
        
        val_34 = null;
        val_34 = null;
        if(App.game == 17)
        {
            goto label_50;
        }
        
        val_35 = null;
        val_35 = null;
        if(App.game != 19)
        {
            goto label_56;
        }
        
        label_50:
        label_58:
        string val_16 = Localization.Localize(key:  "subscribe_now_upper", defaultValue:  "SUBSCRIBE NOW", useSingularKey:  false);
        label_62:
        val_28 = ???;
        val_29 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_56:
        if(WGSubscriptionManager.WillGetFreeTrial == true)
        {
            goto label_58;
        }
        
        string val_27 = System.String.Format(format:  "{0} / {1}", arg0:  MonoSingleton<WGSubscriptionManager>.Instance.GetPromoCostForPackage(subPack:  this.subPackage), arg1:  Localization.Localize(key:  "week_upper", defaultValue:  "WEEK", useSingularKey:  false));
        if(this.costText != null)
        {
            goto label_62;
        }
        
        throw new NullReferenceException();
    }
    public void onClickButton(bool result)
    {
        object val_15;
        UnityEngine.Object val_16;
        System.Delegate val_17;
        var val_18;
        IntPtr val_20;
        string val_21;
        int val_22;
        var val_23;
        val_15 = this;
        if(result == false)
        {
            goto label_1;
        }
        
        if(this.location == 2)
        {
            goto label_10;
        }
        
        if(this.location == 1)
        {
            goto label_3;
        }
        
        if(this.location != 0)
        {
            goto label_4;
        }
        
        val_16 = this.targetParentObject;
        val_17 = 0;
        if(val_16 == 0)
        {
            goto label_35;
        }
        
        val_16 = this.targetParentObject;
        val_16.SetActive(value:  false);
        label_4:
        val_17 = 0;
        goto label_35;
        label_1:
        if(this.location == 2)
        {
            goto label_10;
        }
        
        if(this.location != 1)
        {
            goto label_11;
        }
        
        SLC.Social.Leagues.LeaguesManager.NOTIFY_API.Notify(note:  9);
        return;
        label_10:
        WGSubscriptionManager._subEntryPoint = (this.subPackage == 0) ? 34 : 58;
        val_18 = 1152921504614301696;
        val_20 = 1152921516451027968;
        goto label_16;
        label_11:
        GameBehavior val_4 = App.getBehavior;
        val_15 = val_4.<metaGameBehavior>k__BackingField;
        val_21 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_22 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_22 = val_9.Length;
        val_9[1] = "NULL";
        val_23 = null;
        val_23 = null;
        val_15.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  val_21, shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        return;
        label_3:
        WGSubscriptionManager._subEntryPoint = 31;
        val_18 = 1152921504614301696;
        System.Action val_11 = null;
        val_20 = 1152921516451061792;
        label_16:
        val_11 = new System.Action(object:  this, method:  val_20);
        System.Delegate val_12 = System.Delegate.Combine(a:  0, b:  val_11);
        val_17 = val_12;
        if(val_12 != null)
        {
                if(null != val_18)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        label_35:
        GameBehavior val_13 = App.getBehavior;
        val_21 = val_13.<metaGameBehavior>k__BackingField;
        mem2[0] = val_17;
        mem2[0] = this.subPackage;
    }
    private void OnStoreClosed()
    {
        this.UpdateUI();
        if((MonoSingleton<GameStoreUI>.Instance) != 0)
        {
                MonoSingleton<GameStoreUI>.Instance.RefreshPackItemDisplays();
        }
        
        WGSubscriptionManager._subEntryPoint = (this.subPackage == 0) ? 35 : 59;
    }
    public void ClickButton()
    {
        if(this.targetButton != null)
        {
                this.targetButton.OnOtherButtonClick();
            return;
        }
        
        throw new NullReferenceException();
    }
    public WGSubscriptionButton()
    {
    
    }

}
