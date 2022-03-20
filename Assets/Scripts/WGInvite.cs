using UnityEngine;
public class WGInvite : MonoBehaviour
{
    // Fields
    protected WGInvite.WGInviteStatus m_status;
    protected UnityEngine.GameObject m_inviteSection;
    protected UnityEngine.UI.Button m_emailBtn;
    protected UnityEngine.UI.Button m_textBtn;
    protected UnityEngine.UI.Button m_moreBtn;
    protected UnityEngine.UI.Text m_eachRewordTxt;
    protected UnityEngine.UI.Text m_text_info;
    private decimal m_eachReward;
    protected UnityEngine.GameObject m_sentSection;
    protected UnityEngine.UI.Button m_sentOKBtn;
    protected UnityEngine.UI.Text m_sentTextInfoTxt;
    protected UnityEngine.GameObject m_collectSection;
    protected UnityEngine.UI.Button m_collectBtn;
    protected UnityEngine.UI.Text m_collectCoinAmoutTxt;
    protected GridCoinCollectAnimationInstantiator coinsAnim;
    
    // Properties
    public WGInvite.WGInviteStatus Status { get; set; }
    
    // Methods
    public WGInvite.WGInviteStatus get_Status()
    {
        return (WGInviteStatus)this.m_status;
    }
    public void set_Status(WGInvite.WGInviteStatus value)
    {
        goto typeof(WGInvite).__il2cppRuntimeField_170;
    }
    private void Awake()
    {
        GameEcon val_1 = App.getGameEcon;
        decimal val_2 = System.Decimal.op_Implicit(value:  val_1.FInviterCoinsReward);
        this.m_eachReward = val_2;
        mem[1152921517870721800] = val_2.lo;
        mem[1152921517870721804] = val_2.mid;
        string val_3 = this.m_eachReward.ToString();
        AppConfigs val_5 = App.Configuration;
        string val_6 = System.String.Format(format:  Localization.Localize(key:  "invite_info", defaultValue:  "", useSingularKey:  false), arg0:  val_5.appConfig.gameName);
        AppConfigs val_8 = App.Configuration;
        GameEcon val_9 = App.getGameEcon;
        string val_10 = System.String.Format(format:  Localization.Localize(key:  "invite_sent_info", defaultValue:  "Receive your reward when your friend downloads {0} from your link and plays {1} levels!", useSingularKey:  false), arg0:  val_8.appConfig.gameName, arg1:  val_9.FInviterLevelComplete);
    }
    private void Start()
    {
        this.m_emailBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGInvite).__il2cppRuntimeField_188));
        this.m_textBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGInvite).__il2cppRuntimeField_198));
        this.m_moreBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGInvite).__il2cppRuntimeField_1A8));
        this.m_sentOKBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGInvite::OnSentOKButtonClicked()));
        this.m_collectBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGInvite::OnCollectButtonClicked()));
    }
    public virtual void SetStatus(WGInvite.WGInviteStatus status)
    {
        this.m_inviteSection.SetActive(value:  false);
        this.m_sentSection.SetActive(value:  false);
        this.m_collectSection.SetActive(value:  false);
        if(status <= 4)
        {
                var val_1 = 32497460 + (status) << 2;
            val_1 = val_1 + 32497460;
        }
        else
        {
                this.m_status = status;
        }
    
    }
    public virtual void OnEmailButtonClicked()
    {
        MonoSingleton<WGInviteManager>.Instance.SendEmail();
        this.Invoke(methodName:  "SetToSentStatus", time:  1f);
    }
    public virtual void OnTextButtonClicked()
    {
        MonoSingleton<WGInviteManager>.Instance.SendText();
        this.Invoke(methodName:  "SetToSentStatus", time:  1f);
    }
    public virtual void OnMoreButtonClicked()
    {
        MonoSingleton<WGInviteManager>.Instance.ShareMore();
        this.Invoke(methodName:  "SetToSentStatus", time:  1f);
    }
    private void SetToSentStatus()
    {
        WGInviteManager.InviteSent = true;
    }
    protected virtual void OpenAndInitInviteSection()
    {
        if(this.m_inviteSection != null)
        {
                this.m_inviteSection.SetActive(value:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    protected virtual void OpenAndInitSentInviteSection()
    {
        if(this.m_sentSection != null)
        {
                this.m_sentSection.SetActive(value:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    protected virtual void OpenAndInitCollectSection()
    {
        this.m_collectSection.SetActive(value:  true);
        if(this.coinsAnim != 0)
        {
                mem2[0] = 0;
        }
        
        this.m_collectBtn.interactable = true;
        string val_4 = MonoSingleton<WGInviteManager>.Instance.RewardCoinsCount.ToString();
    }
    public void OnSentOKButtonClicked()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnCollectButtonClicked()
    {
        this.m_collectBtn.interactable = false;
        MonoSingleton<WGInviteManager>.Instance.RewardInviteSuccessfull();
        if(this.coinsAnim == 0)
        {
                return;
        }
        
        this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGInvite::OnCoinsAnimFinished());
        Player val_6 = App.Player;
        decimal val_7 = System.Decimal.op_Implicit(value:  MonoSingleton<WGInviteManager>.Instance.RewardCoinsCount);
        decimal val_8 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits, lo = 380629152, mid = 268435459}, d2:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
        Player val_9 = App.Player;
        this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, toValue:  new System.Decimal() {flags = val_9._credits, hi = val_9._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void OnCoinsAnimFinished()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnDisable()
    {
        UnityEngine.Object val_12;
        this.StopAllCoroutines();
        val_12 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_12 == 0)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyBonusManager>.Instance.CheckAvailable()) == false)
        {
                return;
        }
        
        val_12 = 1152921504884269056;
        GameBehavior val_5 = App.getBehavior;
        if(((val_5.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        GameBehavior val_6 = App.getBehavior;
        val_12 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_9F0;
    }
    private void OnDestroy()
    {
        this.m_emailBtn.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGInvite).__il2cppRuntimeField_188));
        this.m_textBtn.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGInvite).__il2cppRuntimeField_198));
        this.m_moreBtn.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGInvite).__il2cppRuntimeField_1A8));
        this.m_sentOKBtn.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGInvite::OnSentOKButtonClicked()));
        this.m_collectBtn.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGInvite::OnCollectButtonClicked()));
    }
    public WGInvite()
    {
        decimal val_1 = new System.Decimal(value:  44);
        this.m_eachReward = val_1.flags;
    }

}
