using UnityEngine;
public class UnlockableUILeaderboard : WGUnlockableUIElement
{
    // Fields
    private UGUINetworkedButton netWorkedButton;
    
    // Properties
    protected override int UnlockLevel { get; }
    
    // Methods
    protected override int get_UnlockLevel()
    {
        return 1;
    }
    private void Awake()
    {
        this.netWorkedButton = this.GetComponent<UGUINetworkedButton>();
        val_1.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void UnlockableUILeaderboard::OnConnectionClicked(bool connected));
    }
    private void OnConnectionClicked(bool connected)
    {
        if(connected != false)
        {
                MonoSingleton<WGLeaderboardManager>.Instance.ShowLeaderboardWindow();
            return;
        }
        
        this.ShowConnectionRequired();
    }
    private void ShowConnectionRequired()
    {
        int val_10;
        var val_11;
        System.Func<System.Boolean> val_13;
        var val_14;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_10 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_10 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_11 = null;
        val_11 = null;
        val_13 = UnlockableUILeaderboard.<>c.<>9__5_0;
        if(val_13 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_13 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  UnlockableUILeaderboard.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean UnlockableUILeaderboard.<>c::<ShowConnectionRequired>b__5_0());
            UnlockableUILeaderboard.<>c.<>9__5_0 = val_13;
        }
        
        val_8[0] = val_13;
        val_14 = null;
        val_14 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public UnlockableUILeaderboard()
    {
    
    }

}
