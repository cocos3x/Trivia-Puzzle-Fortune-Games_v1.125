using UnityEngine;
public class WGRewardedVideoUI : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject group_start;
    private UnityEngine.UI.Text desc_text;
    private UGUINetworkedButton Button_FreeHint;
    private UnityEngine.GameObject group_sorry;
    private UGUINetworkedButton Button_WatchAnother;
    private UnityEngine.UI.Button Button_Close_Sorry;
    private UnityEngine.GameObject group_success;
    private UnityEngine.UI.Button Button_CollectHint;
    private bool hideTextWhileCollecting;
    private UnityEngine.UI.Text message_thankYou;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private UnityEngine.UI.Text coin_amount;
    private WGMessagePopup localPopup;
    private decimal reward;
    private HeyZapAdTag initTag;
    private string freeCoinEventName;
    public System.Action completeCallback;
    
    // Methods
    private void DoCompleteCallback()
    {
        this.SetUp();
        if(this.completeCallback == null)
        {
                return;
        }
        
        this.completeCallback.Invoke();
    }
    private void Awake()
    {
        this.Button_FreeHint.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void WGRewardedVideoUI::OnFreeHintClick(bool result));
        this.Button_WatchAnother.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void WGRewardedVideoUI::OnFreeHintClick(bool result));
        this.Button_Close_Sorry.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGRewardedVideoUI::CloseSorry()));
        this.Button_CollectHint.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGRewardedVideoUI::OnCollectClicked()));
    }
    private void OnEnable()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        this.SetUp();
    }
    public void InitWithTag(HeyZapAdTag tag, string eventName)
    {
        this.initTag = tag;
        this.freeCoinEventName = eventName;
    }
    private void SetUp()
    {
        decimal val_18;
        var val_19;
        this.localPopup.transform.parent.gameObject.SetActive(value:  false);
        this.Button_FreeHint.interactable = true;
        this.group_start.SetActive(value:  true);
        this.group_success.SetActive(value:  false);
        this.group_sorry.SetActive(value:  false);
        this.message_thankYou.canvasRenderer.SetAlpha(alpha:  1f);
        Player val_5 = App.Player;
        if(val_5.num_purchase < 1)
        {
            goto label_14;
        }
        
        if(val_5.num_purchase != 1)
        {
            goto label_15;
        }
        
        val_18 = val_6.oneTimePurchaserVidReward;
        val_19 = App.getGameEcon + 324;
        goto label_23;
        label_14:
        val_18 = val_7.nonPurchaserVidReward;
        val_19 = App.getGameEcon + 308;
        goto label_23;
        label_15:
        val_18 = val_8.repeatPurchaserVidReward;
        val_19 = App.getGameEcon + 340;
        label_23:
        this.reward = val_8.repeatPurchaserVidReward.flags;
        mem[1152921517953066200] = null;
        GameEcon val_10 = App.getGameEcon;
        string val_12 = System.String.Format(format:  Localization.Localize(key:  "wgrewardvideo_button", defaultValue:  "+{0}", useSingularKey:  false), arg0:  this.reward.ToString(format:  val_10.numberFormatInt));
        GameEcon val_13 = App.getGameEcon;
        string val_14 = this.reward.ToString(format:  val_13.numberFormatInt);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void OnFreeHintClick(bool result)
    {
        string val_26;
        object val_27;
        WGMessagePopup val_28;
        string val_29;
        System.Boolean[] val_30;
        System.String[] val_31;
        int val_32;
        System.Func<System.Boolean>[] val_33;
        IntPtr val_36;
        int val_37;
        var val_38;
        val_27 = this;
        if(result != false)
        {
                this.Button_FreeHint.interactable = false;
            if((MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  this.initTag, adCapExempt:  false)) == true)
        {
                return;
        }
        
            this.Button_FreeHint.interactable = true;
            this.localPopup.transform.parent.gameObject.SetActive(value:  true);
            this.localPopup.transform.gameObject.SetActive(value:  true);
            val_28 = this.localPopup;
            val_26 = Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false);
            val_29 = Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false);
            val_30 = new bool[2];
            val_30[0] = true;
            val_31 = new string[2];
            val_32 = val_11.Length;
            val_31[0] = Localization.Localize(key:  "try_again_later_upper", defaultValue:  "TRY AGAIN LATER", useSingularKey:  false);
            val_32 = val_11.Length;
            val_31[1] = "NULL";
            val_33 = new System.Func<System.Boolean>[2];
            val_36 = 1152921517953330240;
        }
        else
        {
                this.localPopup.transform.parent.gameObject.SetActive(value:  true);
            this.localPopup.transform.gameObject.SetActive(value:  true);
            val_28 = this.localPopup;
            val_26 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
            val_29 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
            bool[] val_21 = new bool[2];
            val_30 = val_21;
            val_30[0] = true;
            string[] val_22 = new string[2];
            val_31 = val_22;
            val_37 = val_22.Length;
            val_31[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_37 = val_22.Length;
            val_31[1] = "NULL";
            System.Func<System.Boolean>[] val_24 = new System.Func<System.Boolean>[2];
            val_33 = val_24;
            System.Func<System.Boolean> val_25 = null;
            val_36 = 1152921517953392752;
        }
        
        val_25 = new System.Func<System.Boolean>(object:  this, method:  val_36);
        val_33[0] = val_25;
        val_27 = 1152921504617017344;
        val_38 = null;
        val_38 = null;
        val_28.SetupMessage(titleTxt:  val_26, messageTxt:  val_29, shownButtons:  val_21, buttonTexts:  val_22, showClose:  false, buttonCallbacks:  val_24, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public void OnVideoResponse(Notification notif)
    {
        bool val_2 = System.Boolean.Parse(value:  notif.data.ToString());
        this.group_start.SetActive(value:  false);
        bool val_3 = val_2;
        this.group_success.SetActive(value:  val_3);
        this.Button_CollectHint.interactable = val_3;
        this.group_sorry.SetActive(value:  (~val_2) & 1);
    }
    public void OnCollectClicked()
    {
        this.Button_CollectHint.interactable = false;
        if(this.coinsAnim != 0)
        {
                this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGRewardedVideoUI::DoCompleteCallback());
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = 462127504, mid = 268435459}, source:  this.freeCoinEventName, externalParams:  0, animated:  false);
            Player val_3 = App.Player;
            decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = this.coinsAnim, mid = this.coinsAnim});
            Player val_5 = App.Player;
            this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            if(this.hideTextWhileCollecting == false)
        {
                return;
        }
        
            this.message_thankYou.CrossFadeAlpha(alpha:  0f, duration:  1f, ignoreTimeScale:  true);
            return;
        }
        
        this.DoCompleteCallback();
    }
    private void CloseSorry()
    {
        this.group_start.SetActive(value:  true);
        this.Button_FreeHint.interactable = true;
        this.group_success.SetActive(value:  false);
        this.group_sorry.SetActive(value:  false);
        this.localPopup.transform.parent.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
    }
    public WGRewardedVideoUI()
    {
        this.freeCoinEventName = "Default:WGRewardedVideoUI";
    }
    private bool <OnFreeHintClick>b__22_0()
    {
        this.CloseSorry();
        return true;
    }
    private bool <OnFreeHintClick>b__22_1()
    {
        this.CloseSorry();
        return true;
    }

}
