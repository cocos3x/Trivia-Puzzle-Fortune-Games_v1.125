using UnityEngine;
public class WGEmailCollectPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject submitGroup;
    private UnityEngine.UI.InputField input;
    private UnityEngine.UI.Button submitButton;
    private UnityEngine.UI.Text rewardSubmitLabel;
    private UnityEngine.GameObject collectGroup;
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.UI.Text rewardCollectLabel;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private string userEmail;
    
    // Methods
    private void Awake()
    {
        this.input.m_OnEndEdit.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void WGEmailCollectPopup::OnValueChanged_Input(string value)));
        this.submitButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGEmailCollectPopup::OnClick_SubmitButton()));
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGEmailCollectPopup::OnClick_CollectButton()));
    }
    private void OnEnable()
    {
        this.userEmail = "";
        this.submitGroup.SetActive(value:  true);
        this.submitButton.interactable = false;
        this.collectGroup.SetActive(value:  false);
        this.collectButton.interactable = true;
        GameEcon val_2 = App.getGameEcon;
        GameEcon val_3 = App.getGameEcon;
        string val_5 = System.String.Format(format:  Localization.Localize(key:  "wgemailcollectpopup_default", defaultValue:  "Get special bonuses and updates via email!\nGet {0} coins instantly!", useSingularKey:  false), arg0:  val_2.emailCollectReward.ToString(format:  val_3.numberFormatInt));
        GameEcon val_6 = App.getGameEcon;
        GameEcon val_7 = App.getGameEcon;
        string val_8 = val_6.emailCollectReward.ToString(format:  val_7.numberFormatInt);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnValueChanged_Input(string value)
    {
        this.submitButton.interactable = false;
        if(value.m_stringLength == 0)
        {
                return;
        }
        
        if((this.submitButton.isValidEmail(email:  value)) == false)
        {
                return;
        }
        
        this.submitButton.interactable = true;
        this.userEmail = value;
    }
    private void OnClick_SubmitButton()
    {
        var val_6;
        if((System.String.IsNullOrEmpty(value:  this.userEmail)) != false)
        {
                return;
        }
        
        Player val_2 = App.Player;
        val_2.email = this.userEmail;
        App.Player.SaveState();
        val_6 = null;
        val_6 = null;
        if(App.networkManager.Reachable() != false)
        {
                DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
        }
        
        this.submitGroup.SetActive(value:  false);
        this.collectGroup.SetActive(value:  true);
    }
    private void OnClick_CollectButton()
    {
        var val_16;
        this.collectButton.interactable = false;
        GameEcon val_2 = App.getGameEcon + 468;
        val_16 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_16 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_16 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_16 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_1.emailCollectReward.flags, hi = val_1.emailCollectReward.flags, lo = 366026752, mid = 268435456}, source:  System.String.Format(format:  "Email Collection", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), externalParams:  0, animated:  false);
        if(this.coinsAnim != 0)
        {
                Player val_5 = App.Player;
            GameEcon val_7 = App.getGameEcon + 468;
            decimal val_8 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30, mid = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30}, d2:  new System.Decimal() {flags = val_6.emailCollectReward.flags, hi = val_6.emailCollectReward.flags, lo = 366026752, mid = 268435456});
            this.coinsAnim.Set(instantValue:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid});
            this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGEmailCollectPopup::OnCoinsAnimFinished());
            Player val_10 = App.Player;
            GameEcon val_12 = App.getGameEcon + 468;
            decimal val_13 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits, lo = this.coinsAnim, mid = this.coinsAnim}, d2:  new System.Decimal() {flags = val_11.emailCollectReward.flags, hi = val_11.emailCollectReward.flags, lo = 366026752, mid = 268435456});
            Player val_14 = App.Player;
            this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid}, toValue:  new System.Decimal() {flags = val_14._credits, hi = val_14._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private bool isValidEmail(string email)
    {
        return new System.Text.RegularExpressions.Regex(pattern:  "\\A(?:[a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", options:  1).IsMatch(input:  email);
    }
    private void OnCoinsAnimFinished()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnDisable()
    {
        MonoSingleton<WGEmailCollectManager>.Instance.HandleResponded();
    }
    public WGEmailCollectPopup()
    {
        this.userEmail = "";
    }

}
