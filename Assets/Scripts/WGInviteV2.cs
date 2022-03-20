using UnityEngine;
public class WGInviteV2 : WGInvite
{
    // Fields
    protected UnityEngine.UI.Button m_whatsAppBtn;
    protected UnityEngine.UI.Button m_enterFriendCode;
    protected UnityEngine.UI.Text m_textRewardChest;
    protected UnityEngine.UI.Slider m_invitesProggression;
    private UnityEngine.GameObject m_enterCodeSection;
    private UnityEngine.UI.InputField m_enterCodeInput;
    private UnityEngine.UI.Button m_enterCodeButton;
    private UnityEngine.Vector3 m_inputOffset;
    private UnityEngine.GameObject m_MessageSection;
    private UnityEngine.UI.Text m_MessageTitleText;
    private UnityEngine.UI.Text m_ErrorTitleText;
    private UnityEngine.UI.Text m_MessageSectionText;
    private UnityEngine.UI.Button m_MessageSectionButton;
    private UnityEngine.GameObject m_MessageCloseButton;
    private UnityEngine.GameObject chestGO;
    private UnityEngine.GameObject closedChest;
    private UnityEngine.GameObject openedChest;
    private CurrencyCollectAnimationInstantiator chestCoinAnim;
    private System.Collections.Generic.List<UnityEngine.UI.RawImage> chestImages;
    private System.Collections.Generic.List<UnityEngine.Texture> bronzeChestTextures;
    private System.Collections.Generic.List<UnityEngine.Texture> silverChestTextures;
    private System.Collections.Generic.List<UnityEngine.Texture> goldChestTextures;
    private System.Collections.Generic.List<UnityEngine.GameObject> progressChestGO;
    private System.Collections.Generic.List<UnityEngine.UI.Text> progressChestText;
    private string InviteCode;
    private UnityEngine.Vector3 enterCodePosition;
    private const float CHEST_SCALE_0 = 0.25;
    private const float CHEST_SCALE_DURATION = 1;
    private const float CHEST_SCALE_DELAY = 2;
    
    // Methods
    private void Awake()
    {
        GameEcon val_1 = App.getGameEcon;
        string val_2 = val_1.FInviterCoinsReward.ToString();
        GameEcon val_4 = App.getGameEcon;
        string val_5 = System.String.Format(format:  Localization.Localize(key:  "inviter_v2_invitewin_fineprint", defaultValue:  "Friend must complete {0} levels for your reward", useSingularKey:  false), arg0:  val_4.FInviterLevelComplete);
        AppConfigs val_7 = App.Configuration;
        GameEcon val_8 = App.getGameEcon;
        string val_9 = System.String.Format(format:  Localization.Localize(key:  "inviter_v2_sent_text", defaultValue:  "Receive your reward when your friend downloads {0} from your link or enters your friend code and plays {1} levels!", useSingularKey:  false), arg0:  val_7.appConfig.gameName, arg1:  val_8.FInviterLevelComplete);
        UnityEngine.Vector3 val_11 = this.m_enterCodeSection.transform.localPosition;
        this.enterCodePosition = val_11;
        mem[1152921517884248988] = val_11.y;
        mem[1152921517884248992] = val_11.z;
        this.m_enterFriendCode.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGInviteV2::OnEnterInviteCodeClick()));
        this.m_whatsAppBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGInviteV2::OnWhatsAppClick()));
        this.m_enterCodeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGInviteV2::OnEnterCodeButtonClicked()));
        FrameSkipper val_15 = this.m_enterCodeSection.AddComponent<FrameSkipper>();
        System.Delegate val_17 = System.Delegate.Combine(a:  val_15.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGInviteV2::UpdateInputPos()));
        if(val_17 != null)
        {
                if(null != null)
        {
            goto label_22;
        }
        
        }
        
        val_15.updateLogic = val_17;
        this.m_enterCodeInput.m_OnEndEdit.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  public System.Void WGInviteV2::OnCodeInputEndEdit(string value)));
        this.m_enterCodeInput.m_OnValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  public System.Void WGInviteV2::OnCodeValueInputChanged(string value)));
        return;
        label_22:
    }
    public override void SetStatus(WGInvite.WGInviteStatus status)
    {
        this.SetActive(value:  false);
        this.SetActive(value:  false);
        this.SetActive(value:  false);
        this.m_enterCodeSection.SetActive(value:  false);
        this.m_MessageSection.SetActive(value:  false);
        if(status <= 4)
        {
                var val_1 = 32496520 + (status) << 2;
            val_1 = val_1 + 32496520;
        }
        else
        {
                mem[1152921517884520392] = status;
        }
    
    }
    public override void OnMoreButtonClicked()
    {
        MonoSingleton<WGInviteManager>.Instance.CopyToClipboard();
    }
    public void OnEnterInviteCodeClick()
    {
        goto typeof(WGInviteV2).__il2cppRuntimeField_170;
    }
    public void ShowInvite()
    {
        goto typeof(WGInviteV2).__il2cppRuntimeField_170;
    }
    public void OnCodeValueInputChanged(string value)
    {
        if((System.String.IsNullOrEmpty(value:  value)) != false)
        {
                return;
        }
        
        this.m_enterCodeInput.text = value.ToUpper();
    }
    public void OnCodeInputEndEdit(string value)
    {
        this.m_enterCodeButton.interactable = false;
        if((System.String.IsNullOrEmpty(value:  value)) == true)
        {
                return;
        }
        
        this.m_enterCodeButton.interactable = true;
        this.InviteCode = value.ToUpper();
    }
    private void UpdateInputPos()
    {
        UnityEngine.Vector3 val_4;
        float val_5;
        float val_6;
        if(this.m_enterCodeSection.activeSelf == false)
        {
                return;
        }
        
        val_4 = this.enterCodePosition;
        if(this.m_enterCodeInput.m_AllowInput != false)
        {
                UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_4, y = V9.16B, z = V10.16B}, b:  new UnityEngine.Vector3() {x = this.m_inputOffset, y = V11.16B, z = V12.16B});
            val_4 = val_3.x;
            val_5 = val_3.y;
            val_6 = val_3.z;
        }
        
        this.m_enterCodeSection.transform.localPosition = new UnityEngine.Vector3() {x = val_4, y = val_5, z = val_6};
    }
    public void OnEnterCodeButtonClicked()
    {
        if((System.String.IsNullOrEmpty(value:  this.InviteCode)) != false)
        {
                return;
        }
        
        this.m_enterCodeButton.interactable = false;
        if(WGInviteManager.isInvited != false)
        {
                this.OnEnterCodeResponse(response:  "exist");
            return;
        }
        
        MonoSingleton<WGInviteManager>.Instance.SentInviteCode(inviteCode:  this.InviteCode.ToUpper(), codeResponse:  new System.Action<System.String>(object:  this, method:  public System.Void WGInviteV2::OnEnterCodeResponse(string response)));
    }
    public void OnEnterCodeResponse(string response)
    {
        UnityEngine.UI.Text val_22;
        string val_23;
        string val_24;
        this.m_enterCodeButton.interactable = true;
        if((response.Contains(value:  "success")) != false)
        {
                this.m_ErrorTitleText.gameObject.SetActive(value:  false);
            this.m_MessageTitleText.transform.parent.gameObject.SetActive(value:  true);
            this.m_MessageCloseButton.SetActive(value:  true);
            string val_6 = Localization.Localize(key:  "congrats_upper", defaultValue:  "CONGRATULATIONS!", useSingularKey:  false);
            GameEcon val_8 = App.getGameEcon;
            string val_9 = System.String.Format(format:  Localization.Localize(key:  "inviter_v2_valid_text", defaultValue:  "Your friend will be credited for your install after you complete {0} levels!", useSingularKey:  false), arg0:  val_8.FInviterLevelComplete);
            UnityEngine.UI.Text val_10 = this.m_MessageSectionButton.GetComponentInChildren<UnityEngine.UI.Text>();
            string val_11 = Localization.Localize(key:  "continue_upper", defaultValue:  "", useSingularKey:  false);
            return;
        }
        
        this.m_ErrorTitleText.gameObject.SetActive(value:  true);
        this.m_MessageTitleText.transform.parent.gameObject.SetActive(value:  false);
        this.m_MessageCloseButton.SetActive(value:  false);
        if((response.Contains(value:  "exist")) != false)
        {
                string val_17 = Localization.Localize(key:  "inviter_v2_already_entered", defaultValue:  "ALREADY ENTERED", useSingularKey:  false);
            val_22 = this.m_MessageSectionText;
            val_23 = "inviter_v2_duplicate_code_text";
            val_24 = "A valid friend code has already been entered. Only one friend code can be entered.";
        }
        else
        {
                string val_18 = Localization.Localize(key:  "inviter_v2_invalid_title", defaultValue:  "INVALID CODE", useSingularKey:  false);
            val_22 = this.m_MessageSectionText;
            val_23 = "inviter_v2_invalid_text";
            val_24 = "Seems like the friend code you entered is invalid. Please check and try again.";
        }
        
        string val_19 = Localization.Localize(key:  val_23, defaultValue:  val_24, useSingularKey:  false);
        UnityEngine.UI.Text val_20 = this.m_MessageSectionButton.GetComponentInChildren<UnityEngine.UI.Text>();
        string val_21 = Localization.Localize(key:  "ok_upper", defaultValue:  "", useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    protected override void OpenAndInitInviteSection()
    {
        this.OpenAndInitInviteSection();
        this.chestGO.SetActive(value:  false);
        UnityEngine.GameObject val_1 = this.m_whatsAppBtn.gameObject;
        val_1.SetActive(value:  WGInviteManager.<IsWhatsAppInstalled>k__BackingField);
        val_1.gameObject.SetActive(value:  ((WGInviteManager.<IsWhatsAppInstalled>k__BackingField) == false) ? 1 : 0);
        GameEcon val_6 = App.getGameEcon;
        float val_28 = (float)val_6.FInviter_GO_I;
        val_28 = ((float)MonoSingleton<WGInviteManager>.Instance.InvitesCollected) / val_28;
        int val_8 = MonoSingleton<WGInviteManager>.Instance.NextTargetTierInvites();
        string val_14 = System.String.Format(format:  Localization.Localize(key:  "inviter_v2_invitewin_progress", defaultValue:  "Invite {0} more people to open the next Reward Chest", useSingularKey:  false), arg0:  UnityEngine.Mathf.Max(a:  0, b:  val_8 - (MonoSingleton<WGInviteManager>.Instance.InvitesCollected)));
        TierReward val_16 = MonoSingleton<WGInviteManager>.Instance.NextTier();
        if(null <= val_16)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.UI.Text val_17 = 1152921504814993408 + (val_16 << 3);
        string val_20 = System.String.Format(format:  "{0}/{1}", arg0:  MonoSingleton<WGInviteManager>.Instance.InvitesCollected, arg1:  val_8);
        var val_29 = mem[(1152921504814993408 + (val_16) << 3) + 32];
        var val_30 = 0;
        label_33:
        if(val_30 >= val_29)
        {
            goto label_26;
        }
        
        if(val_29 <= val_30)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_29 = val_29 + 0;
        (mem[(1152921504814993408 + (val_16) << 3) + 32] + 0) + 32.SetActive(value:  (val_30 >= val_16) ? 1 : 0);
        if(val_29 <= val_30)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_29 = val_29 + 0;
        ((mem[(1152921504814993408 + (val_16) << 3) + 32] + 0) + 0) + 32.gameObject.SetActive(value:  (val_16 == val_30) ? 1 : 0);
        val_30 = val_30 + 1;
        if(this.progressChestGO != null)
        {
            goto label_33;
        }
        
        label_26:
        if((MonoSingleton<WGInviteManager>.Instance.TierRewardAvailable()) == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_27 = this.StartCoroutine(routine:  this.ShowCollectTierReward());
    }
    protected void OpenAndInitEnterSection()
    {
        this.InviteCode = System.String.alignConst;
        this.m_enterCodeInput.text = System.String.alignConst;
        this.m_enterCodeSection.SetActive(value:  true);
    }
    protected void OnWhatsAppClick()
    {
        MonoSingleton<WGInviteManager>.Instance.SendWhatsApp();
        this.Invoke(methodName:  "SetToSentStatus", time:  1f);
    }
    private System.Collections.IEnumerator ShowCollectTierReward()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGInviteV2.<ShowCollectTierReward>d__42();
    }
    public WGInviteV2()
    {
    
    }

}
