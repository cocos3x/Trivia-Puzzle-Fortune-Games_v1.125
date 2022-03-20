using UnityEngine;
public class DailyChallengeTutorialLobbyHelper : MonoSingleton<DailyChallengeTutorialLobbyHelper>
{
    // Fields
    private UnlockableUIDailyChallenge dailyChallengeButton;
    private UGUINetworkedButton netWorkedButton;
    private DynamicToolTip TT;
    
    // Methods
    private void OnEnable()
    {
        GameBehavior val_1 = App.getBehavior;
        GameBehavior val_2 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) == 1) && (((val_2.<metaGameBehavior>k__BackingField) & 1) == 0))
        {
                UnlockableUIDailyChallenge val_3 = UnityEngine.Object.FindObjectOfType<UnlockableUIDailyChallenge>();
            this.dailyChallengeButton = val_3;
            this.netWorkedButton = val_3.GetComponent<UGUINetworkedButton>();
            val_4.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void DailyChallengeTutorialLobbyHelper::OnConnectionClicked(bool connected));
            UnityEngine.Color val_7 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.45f);
            System.Nullable<UnityEngine.Color> val_8 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = val_7.a});
            MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
            MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
            MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
            System.Collections.Generic.List<UnityEngine.Transform> val_11 = new System.Collections.Generic.List<UnityEngine.Transform>();
            val_11.Add(item:  this.dailyChallengeButton.transform);
            UnityEngine.Coroutine val_14 = this.StartCoroutine(routine:  this.WaitAndShowOverlay(overlayContents:  val_11));
            return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void QAHACK_CANCEL()
    {
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        if(this.TT != 0)
        {
                this.TT.Dismiss();
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        this.netWorkedButton.OnConnectionClick = 0;
    }
    private System.Collections.IEnumerator WaitAndShowOverlay(System.Collections.Generic.List<UnityEngine.Transform> overlayContents)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .overlayContents = overlayContents;
        return (System.Collections.IEnumerator)new DailyChallengeTutorialLobbyHelper.<WaitAndShowOverlay>d__5();
    }
    private void OnConnectionClicked(bool connected)
    {
        if(connected == false)
        {
            goto label_1;
        }
        
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((val_1.<IsDataReady>k__BackingField) == false)
        {
            goto label_5;
        }
        
        this.LaunchDailyChallenge();
        return;
        label_1:
        this.ShowConnectionRequired();
        return;
        label_5:
        this.netWorkedButton.WaitingStatus(waiting:  true);
        MonoSingleton<WGDailyChallengeManager>.Instance.RequestServerUpdate(callback:  new System.Action<System.Boolean>(object:  this, method:  System.Void DailyChallengeTutorialLobbyHelper::OnComplete(bool success)));
    }
    private void ShowConnectionRequired()
    {
        int val_12;
        var val_13;
        System.Func<System.Boolean> val_15;
        var val_16;
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        bool[] val_7 = new bool[2];
        val_7[0] = true;
        string[] val_8 = new string[2];
        val_12 = val_8.Length;
        val_8[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_8.Length;
        val_8[1] = "NULL";
        System.Func<System.Boolean>[] val_10 = new System.Func<System.Boolean>[2];
        val_13 = null;
        val_13 = null;
        val_15 = DailyChallengeTutorialLobbyHelper.<>c.<>9__7_0;
        if(val_15 == null)
        {
                System.Func<System.Boolean> val_11 = null;
            val_15 = val_11;
            val_11 = new System.Func<System.Boolean>(object:  DailyChallengeTutorialLobbyHelper.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean DailyChallengeTutorialLobbyHelper.<>c::<ShowConnectionRequired>b__7_0());
            DailyChallengeTutorialLobbyHelper.<>c.<>9__7_0 = val_15;
        }
        
        val_10[0] = val_15;
        val_16 = null;
        val_16 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_7, buttonTexts:  val_8, showClose:  false, buttonCallbacks:  val_10, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void OnDestroy()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.netWorkedButton)) == false)
        {
                return;
        }
        
        this.netWorkedButton.OnConnectionClick = 0;
    }
    private void OnComplete(bool success)
    {
        this.LaunchDailyChallenge();
    }
    private void LaunchDailyChallenge()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        if((MonoSingleton<GameMaskOverlay>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        MonoSingleton<DailyChallengeTutorialManager>.Instance.HandleLobbyTutorialClicked();
    }
    public DailyChallengeTutorialLobbyHelper()
    {
    
    }

}
