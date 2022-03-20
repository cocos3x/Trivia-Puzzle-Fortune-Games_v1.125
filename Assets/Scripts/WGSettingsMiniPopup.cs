using UnityEngine;
public class WGSettingsMiniPopup : MonoBehaviour
{
    // Fields
    private UGUINetworkedButton Button_FbConnect;
    private UGUINetworkedButton Button_FbShare;
    private UGUINetworkedButton Button_AppleConnect;
    private UnityEngine.GameObject FbConnectRewardGroup;
    private UnityEngine.UI.Text FbConnectRewardAmount;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private UnityEngine.UI.VerticalLayoutGroup buttons_v;
    private float verticalSpacing;
    private UnityEngine.UI.Button languageButton;
    private UGUINetworkedButton restoreTransactionsButton;
    protected UnityEngine.Transform transform_button_toggles_parent;
    private bool isFbCherry;
    private bool pnEnabled;
    private const float DEFAULT_BUTTON_SPACING = 0;
    
    // Methods
    private void Awake()
    {
        object val_32;
        var val_33;
        var val_34;
        var val_35;
        var val_36;
        System.Delegate val_37;
        val_32 = this;
        System.Action<System.Boolean> val_1 = null;
        val_33 = 1152921513393570912;
        val_1 = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSettingsMiniPopup::OnClick_FbConnect(bool result));
        this.Button_FbConnect.OnConnectionClick = val_1;
        this.Button_FbShare.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSettingsMiniPopup::OnClick_FbShare(bool result));
        if((UnityEngine.Object.op_Implicit(exists:  this.Button_AppleConnect)) != false)
        {
                this.Button_AppleConnect.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSettingsMiniPopup::OnClick_AppleConnect(bool result));
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFacebookPluginUpdate");
        val_34 = 1152921504884269056;
        GameBehavior val_6 = App.getBehavior;
        if((((val_6.<metaGameBehavior>k__BackingField) & 1) != 0) && (this.languageButton != 0))
        {
                this.languageButton.gameObject.SetActive(value:  true);
            this.languageButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSettingsMiniPopup::OnClick_Languages()));
        }
        else
        {
                if(this.languageButton != 0)
        {
                this.languageButton.gameObject.SetActive(value:  false);
        }
        
        }
        
        val_35 = 1152921504890499072;
        val_36 = null;
        val_36 = null;
        System.Delegate val_13 = System.Delegate.Combine(a:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, b:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WGSettingsMiniPopup::OnProcessPurchase(ref PurchaseModel purchase)));
        if(val_13 != null)
        {
                if(null != null)
        {
            goto label_33;
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_13;
        System.Action<PurchaseModel> val_14 = null;
        val_37 = val_14;
        val_14 = new System.Action<PurchaseModel>(object:  this, method:  System.Void WGSettingsMiniPopup::OnPurchaseCompleted(PurchaseModel obj));
        System.Delegate val_15 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  val_14);
        if(val_15 != null)
        {
                if(null != null)
        {
            goto label_33;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_15;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnRestoreTransactionsSuccess");
        if((UnityEngine.Object.op_Implicit(exists:  this.restoreTransactionsButton)) != false)
        {
                val_37 = this.restoreTransactionsButton;
            this.restoreTransactionsButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSettingsMiniPopup::OnClick_RetoreTransaction(bool result));
        }
        
        GameBehavior val_19 = App.getBehavior;
        if(((val_19.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        val_32 = ???;
        val_37 = ???;
        val_33 = ???;
        val_34 = ???;
        val_35 = ???;
        goto typeof(WGSettingsMiniPopup).__il2cppRuntimeField_170;
        label_33:
    }
    protected virtual void LoadToggleButtons()
    {
        UnityEngine.Transform val_10;
        UnityEngine.GameObject val_1 = PrefabLoader.LoadPrefab(featureName:  "Settings", prefabName:  "button_toggle_sound");
        if(val_1 != 0)
        {
                val_10 = this.transform_button_toggles_parent;
            UnityEngine.GameObject val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_1, parent:  val_10);
        }
        
        UnityEngine.GameObject val_4 = PrefabLoader.LoadPrefab(featureName:  "Settings", prefabName:  "button_toggle_music");
        if(val_4 != 0)
        {
                val_10 = this.transform_button_toggles_parent;
            UnityEngine.GameObject val_6 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_4, parent:  val_10);
        }
        
        UnityEngine.GameObject val_7 = PrefabLoader.LoadPrefab(featureName:  "Settings", prefabName:  "button_toggle_notifications");
        if(val_7 == 0)
        {
                return;
        }
        
        UnityEngine.GameObject val_9 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_7, parent:  this.transform_button_toggles_parent);
    }
    private void OnProcessPurchase(ref PurchaseModel purchase)
    {
    
    }
    private void OnPurchaseCompleted(PurchaseModel obj)
    {
        if((obj.id.Contains(value:  "remove")) == false)
        {
                return;
        }
        
        App.Player.RemovedAds = true;
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        this.OnRestoreTransactionsSuccess();
    }
    private void OnEnable()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.restoreTransactionsButton)) != false)
        {
                this.restoreTransactionsButton.gameObject.SetActive(value:  false);
        }
        
        this.SetFacebookButtons();
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.UpdateLayout());
        this.pnEnabled = twelvegigs.plugins.LocalNotificationsPlugin.IsNotificationEnabled();
        this.AdjustButtonsSpacing();
    }
    private void AdjustButtonsSpacing()
    {
        if(this.buttons_v == 0)
        {
                return;
        }
        
        this.buttons_v.GetComponent<UnityEngine.UI.VerticalLayoutGroup>().spacing = this.verticalSpacing;
    }
    public void SetFacebookButtons()
    {
        var val_25;
        var val_26;
        var val_27;
        this.Button_FbConnect.gameObject.SetActive(value:  false);
        this.Button_FbShare.gameObject.SetActive(value:  false);
        if((UnityEngine.Object.op_Implicit(exists:  this.Button_AppleConnect)) != false)
        {
                this.Button_AppleConnect.gameObject.SetActive(value:  false);
        }
        
        Player val_5 = App.Player;
        this.isFbCherry = System.String.IsNullOrEmpty(value:  val_5.properties.online_fb_id);
        GameBehavior val_8 = App.getBehavior;
        if(((val_8.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_25 = FacebookPlugin.TaskAvailable(taskToCheck:  1);
        }
        else
        {
                val_25 = 0;
        }
        
        GameBehavior val_10 = App.getBehavior;
        if(((val_10.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_26 = FacebookPlugin.IsLoggedIn;
        }
        else
        {
                val_26 = 0;
        }
        
        this.Button_FbConnect.gameObject.SetActive(value:  false);
        if(val_25 == 0)
        {
            goto label_30;
        }
        
        var val_13 = (this.isFbCherry == true) ? 1 : 0;
        if(this.FbConnectRewardGroup != null)
        {
            goto label_31;
        }
        
        label_30:
        val_27 = 0;
        label_31:
        this.FbConnectRewardGroup.SetActive(value:  false);
        GameEcon val_14 = App.getGameEcon;
        GameEcon val_15 = App.getGameEcon;
        string val_16 = val_14.fbConnectBonus.ToString(format:  val_15.numberFormatInt);
        this.Button_FbShare.gameObject.SetActive(value:  val_26 & 1);
        if(this.Button_FbConnect.gameObject.activeSelf == true)
        {
                return;
        }
        
        if(this.Button_FbShare.gameObject.activeSelf != false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_24 = this.StartCoroutine(routine:  this.UpdateLayout());
    }
    private void OnFacebookPluginUpdate(Notification notification)
    {
        var val_7;
        int val_8;
        if((this.isFbCherry != false) && (FacebookPlugin.IsLoggedIn != false))
        {
                this.isFbCherry = false;
            val_7 = 1152921504884269056;
            GameEcon val_2 = App.getGameEcon;
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_2.fbConnectBonus, hi = val_2.fbConnectBonus, lo = X21, mid = X21}, source:  "FB Connect Bonus", externalParams:  0, animated:  false);
            if(this.coinsAnim != 0)
        {
                Player val_4 = App.Player;
            decimal val_5 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits, lo = 1152921504884269056}, d2:  new System.Decimal() {flags = val_2.fbConnectBonus, hi = val_2.fbConnectBonus, lo = X21, mid = X21});
            val_8 = val_5.lo;
            Player val_6 = App.Player;
            this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_8, mid = val_5.mid}, toValue:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        }
        
        }
        
        this.SetFacebookButtons();
    }
    private System.Collections.IEnumerator UpdateLayout()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGSettingsMiniPopup.<UpdateLayout>d__22();
    }
    private void OnClick_FbConnect(bool result)
    {
        var val_15;
        string val_16;
        string val_17;
        int val_18;
        var val_19;
        var val_20;
        System.Func<System.Boolean> val_22;
        var val_23;
        var val_24;
        var val_25;
        System.Action val_27;
        if(result != false)
        {
                this.FbConnectRewardGroup.SetActive(value:  this.isFbCherry);
            if((FacebookPlugin.TaskAvailable(taskToCheck:  1)) == false)
        {
                return;
        }
        
            TrackingComponent.CurrentIntent = 4;
            FacebookPlugin.PerformTask(task:  1);
            return;
        }
        
        val_15 = 1152921516207318736;
        WGWindow val_2 = this.GetComponent<WGWindow>();
        mem2[0] = 0;
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true);
        val_16 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
        val_17 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
        bool[] val_7 = new bool[2];
        val_7[0] = true;
        string[] val_8 = new string[2];
        val_18 = val_8.Length;
        val_8[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_18 = val_8.Length;
        val_8[1] = "NULL";
        System.Func<System.Boolean>[] val_10 = new System.Func<System.Boolean>[2];
        val_19 = 1152921504994971648;
        val_20 = null;
        val_20 = null;
        val_22 = WGSettingsMiniPopup.<>c.<>9__23_0;
        if(val_22 == null)
        {
                val_23 = val_15;
            System.Func<System.Boolean> val_11 = null;
            val_22 = val_11;
            val_11 = new System.Func<System.Boolean>(object:  WGSettingsMiniPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGSettingsMiniPopup.<>c::<OnClick_FbConnect>b__23_0());
            val_15 = ;
            val_16 = val_16;
            val_17 = val_17;
            val_19 = 1152921504994971648;
            WGSettingsMiniPopup.<>c.<>9__23_0 = val_22;
        }
        
        val_10[0] = val_22;
        val_24 = null;
        val_24 = null;
        val_4.SetupMessage(titleTxt:  val_16, messageTxt:  val_17, shownButtons:  val_7, buttonTexts:  val_8, showClose:  false, buttonCallbacks:  val_10, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        WGWindow val_12 = val_4.GetComponent<WGWindow>();
        val_25 = null;
        val_27 = WGSettingsMiniPopup.<>c.<>9__23_1;
        if(val_27 == null)
        {
                System.Action val_13 = null;
            val_27 = val_13;
            val_13 = new System.Action(object:  WGSettingsMiniPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGSettingsMiniPopup.<>c::<OnClick_FbConnect>b__23_1());
            WGSettingsMiniPopup.<>c.<>9__23_1 = val_27;
        }
        
        mem2[0] = val_27;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_FbShare(bool result)
    {
        var val_15;
        string val_16;
        string val_17;
        int val_18;
        var val_19;
        var val_20;
        System.Func<System.Boolean> val_22;
        var val_23;
        var val_24;
        var val_25;
        System.Action val_27;
        if(result != false)
        {
                MonoSingletonSelfGenerating<WGScreenshotter>.Instance.ShareDefault();
            return;
        }
        
        val_15 = 1152921516207318736;
        WGWindow val_2 = this.GetComponent<WGWindow>();
        mem2[0] = 0;
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true);
        val_16 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
        val_17 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
        bool[] val_7 = new bool[2];
        val_7[0] = true;
        string[] val_8 = new string[2];
        val_18 = val_8.Length;
        val_8[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_18 = val_8.Length;
        val_8[1] = "NULL";
        System.Func<System.Boolean>[] val_10 = new System.Func<System.Boolean>[2];
        val_19 = 1152921504994971648;
        val_20 = null;
        val_20 = null;
        val_22 = WGSettingsMiniPopup.<>c.<>9__24_0;
        if(val_22 == null)
        {
                val_23 = val_15;
            System.Func<System.Boolean> val_11 = null;
            val_22 = val_11;
            val_11 = new System.Func<System.Boolean>(object:  WGSettingsMiniPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGSettingsMiniPopup.<>c::<OnClick_FbShare>b__24_0());
            val_15 = ;
            val_16 = val_16;
            val_17 = val_17;
            val_19 = 1152921504994971648;
            WGSettingsMiniPopup.<>c.<>9__24_0 = val_22;
        }
        
        val_10[0] = val_22;
        val_24 = null;
        val_24 = null;
        val_4.SetupMessage(titleTxt:  val_16, messageTxt:  val_17, shownButtons:  val_7, buttonTexts:  val_8, showClose:  false, buttonCallbacks:  val_10, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        WGWindow val_12 = val_4.GetComponent<WGWindow>();
        val_25 = null;
        val_27 = WGSettingsMiniPopup.<>c.<>9__24_1;
        if(val_27 == null)
        {
                System.Action val_13 = null;
            val_27 = val_13;
            val_13 = new System.Action(object:  WGSettingsMiniPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGSettingsMiniPopup.<>c::<OnClick_FbShare>b__24_1());
            WGSettingsMiniPopup.<>c.<>9__24_1 = val_27;
        }
        
        mem2[0] = val_27;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_AppleConnect(bool result)
    {
        if(result == false)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<SignInWithApplePlugin>.Instance.LogIn();
    }
    private void OnClick_Languages()
    {
        SLCWindow val_2 = this.GetComponent<SLCWindow>();
        .prevOnClose = new System.Action(object:  val_2.Action_OnClose, method:  public System.Void System.Action::Invoke());
        WGWindow val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLanguageSelectPopup>(showNext:  false).GetComponent<WGWindow>();
        mem2[0] = new System.Action(object:  new WGSettingsMiniPopup.<>c__DisplayClass26_0(), method:  System.Void WGSettingsMiniPopup.<>c__DisplayClass26_0::<OnClick_Languages>b__0());
        WGWindow val_8 = this.GetComponent<WGWindow>();
        mem2[0] = 0;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_RetoreTransaction(bool result)
    {
        var val_1;
        UnityEngine.Debug.LogError(message:  "OnClick: RestoreTransactions");
        val_1 = null;
        val_1 = null;
        App.inAppPurchasesManager.RestorePreviousPurchases();
    }
    private void OnRestoreTransactionsSuccess()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                App.Player.RemovedAds = true;
        }
        
        App.Player.RestoredTransactions = true;
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
        this.restoreTransactionsButton.gameObject.SetActive(value:  false);
        this.AdjustButtonsSpacing();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnDisable()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, value:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WGSettingsMiniPopup::OnProcessPurchase(ref PurchaseModel purchase)));
        if(val_2 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_2;
        System.Delegate val_4 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseCompleted, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGSettingsMiniPopup::OnPurchaseCompleted(PurchaseModel obj)));
        if(val_4 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_4;
        if((((this.pnEnabled == true) ? 1 : 0) ^ twelvegigs.plugins.LocalNotificationsPlugin.IsNotificationEnabled()) == false)
        {
                return;
        }
        
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGSettingsMiniPopup()
    {
        this.verticalSpacing = 20f;
    }

}
