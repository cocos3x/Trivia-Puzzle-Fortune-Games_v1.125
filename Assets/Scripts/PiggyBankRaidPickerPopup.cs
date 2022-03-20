using UnityEngine;
public class PiggyBankRaidPickerPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject introGroup;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.GameObject raidGroup;
    private UnityEngine.UI.Image profileImage;
    private UnityEngine.UI.Text profileNameText;
    private UnityEngine.UI.Text profileCoinAmountText;
    private UnityEngine.UI.Text youStoleAmountText;
    private UnityEngine.UI.Button[] raidButtons;
    private UnityEngine.UI.Image[] raidPiggyImages;
    private UnityEngine.GameObject[] raidAmountGroups;
    private UnityEngine.UI.Text[] raidAmountTexts;
    private UnityEngine.ParticleSystem[] raidParticles;
    private UnityEngine.ParticleSystem coinBurstParticle;
    private UnityEngine.UI.Text pickAmountText;
    private UnityEngine.GameObject addToPiggyGroup;
    private UnityEngine.UI.Text addToPiggyAmountText;
    private UnityEngine.UI.Button addToPiggyButton;
    private SLC.Social.AvatarConfig avatarConfig;
    private decimal stoleAmount;
    private System.Action onCloseCallback;
    private int pickAmount;
    private UnityEngine.CanvasGroup introCanvasGroup;
    private UnityEngine.CanvasGroup raidCanvasGroup;
    private System.Collections.Generic.List<System.Decimal> pickerCoinOptions;
    
    // Methods
    public void Initialize(PiggyBankRaidPlayerProfile opponent, System.Action onClose)
    {
        UnityEngine.UI.Text val_8;
        var val_9;
        val_8 = opponent;
        this.profileImage.sprite = this.avatarConfig.GetAvatarSpriteByID(id:  opponent.avatarId, portraitID:  0);
        GameEcon val_2 = App.getGameEcon;
        string val_3 = opponent.coins.ToString(format:  val_2.numberFormatInt);
        val_9 = null;
        val_9 = null;
        this.pickerCoinOptions = PiggyBankRaidEventHandler.<Instance>k__BackingField.GeneratePickerOptionsFromCoins(coins:  new System.Decimal() {flags = opponent.coins, hi = opponent.coins, lo = typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E8>>0&0xFFFFFFFF, mid = typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E8>>32&0x0});
        var val_8 = 0;
        do
        {
            val_8 = this.raidAmountTexts[val_8];
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            GameEcon val_5 = App.getGameEcon;
            string val_6 = PiggyBankRaidEventHandler.isEventPopupQueued.__il2cppRuntimeField_20.ToString(format:  val_5.numberFormatInt);
            val_8 = val_8 + 1;
        }
        while(this.pickerCoinOptions != null);
        
        throw new NullReferenceException();
    }
    private void Start()
    {
        UnityEngine.UI.Button val_15 = this.raidButtons[0];
        this.raidButtons[0].m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PiggyBankRaidPickerPopup::OnRaidButton1Clicked()));
        UnityEngine.UI.Button val_16 = this.raidButtons[1];
        this.raidButtons[1].m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PiggyBankRaidPickerPopup::OnRaidButton2Clicked()));
        UnityEngine.UI.Button val_17 = this.raidButtons[2];
        this.raidButtons[2].m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PiggyBankRaidPickerPopup::OnRaidButton3Clicked()));
        UnityEngine.UI.Button val_18 = this.raidButtons[3];
        this.raidButtons[3].m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PiggyBankRaidPickerPopup::OnRaidButton4Clicked()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PiggyBankRaidPickerPopup::OnContinueClicked()));
        this.addToPiggyButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PiggyBankRaidPickerPopup::OnAddToPiggyClicked()));
        this.introCanvasGroup = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.introGroup);
        this.raidCanvasGroup = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.raidGroup);
        this.introGroup.SetActive(value:  true);
        this.raidGroup.SetActive(value:  false);
        this.UpdateText();
        this.TweenInIntroGroup();
        if((MonoSingleton<AdsUIController>.Instance) == 0)
        {
                return;
        }
        
        UnityEngine.Transform val_11 = this.raidGroup.transform;
        if(null == null)
        {
                UnityEngine.Vector2 val_14 = val_11.offsetMin;
            val_14.y = (MonoSingleton<AdsUIController>.Instance.GetBannerAdHeight()) + val_14.y;
            val_11.offsetMin = new UnityEngine.Vector2() {x = val_14.x, y = val_14.y};
            return;
        }
    
    }
    private void OnDisable()
    {
        if(this.onCloseCallback == null)
        {
                return;
        }
        
        this.onCloseCallback.Invoke();
    }
    private void TweenInIntroGroup()
    {
        this.introCanvasGroup.alpha = 0f;
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.introCanvasGroup, endValue:  1f, duration:  0.5f);
    }
    private void TweenInRaidGroup()
    {
        DG.Tweening.Tweener val_3 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.introCanvasGroup, endValue:  0f, duration:  0.3f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void PiggyBankRaidPickerPopup::<TweenInRaidGroup>b__28_0()));
        this.raidGroup.SetActive(value:  true);
        this.raidCanvasGroup.alpha = 0f;
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.raidCanvasGroup, endValue:  1f, duration:  0.5f), delay:  0.3f);
    }
    private void PickRaidOptions(int optionIndex)
    {
        int val_1 = this.pickAmount;
        val_1 = val_1 - 1;
        if()
        {
                return;
        }
        
        this.pickAmount = val_1;
        this.ShowRaidOptionResult(optionIndex:  optionIndex);
        this.UpdateText();
        if(this.pickAmount > 0)
        {
                return;
        }
        
        this.OnRaidFinished();
    }
    private void UpdateText()
    {
        GameEcon val_2 = App.getGameEcon;
        string val_4 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "pick_upper", defaultValue:  "PICK", useSingularKey:  false), arg1:  this.pickAmount.ToString(format:  val_2.numberFormatInt));
        GameEcon val_6 = App.getGameEcon;
        string val_8 = System.String.Format(format:  Localization.Localize(key:  "piggy_raid_banner", defaultValue:  "You stole: {0}", useSingularKey:  false), arg0:  this.stoleAmount.ToString(format:  val_6.numberFormatInt));
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnRaidFinished()
    {
        var val_6 = 0;
        label_5:
        if(val_6 >= this.raidButtons.Length)
        {
            goto label_2;
        }
        
        this.raidButtons[val_6].interactable = false;
        val_6 = val_6 + 1;
        if(this.raidButtons != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_2:
        this.addToPiggyGroup.SetActive(value:  true);
        GameEcon val_2 = App.getGameEcon;
        string val_4 = System.String.Format(format:  Localization.Localize(key:  "piggy_raid_steal", defaultValue:  "You stole {0} coins from {1}", useSingularKey:  false), arg0:  this.stoleAmount.ToString(format:  val_2.numberFormatInt), arg1:  this.profileNameText);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void ShowRaidOptionResult(int optionIndex)
    {
        var val_8;
        this.raidButtons[(long)optionIndex].interactable = false;
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.raidPiggyImages[(long)optionIndex].transform, endValue:  0f, duration:  0.2f);
        var val_11 = 1152921510472987776;
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.raidAmountGroups[(long)optionIndex].transform, endValue:  1f, duration:  0.3f), delay:  0.2f);
        if(val_11 <= optionIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_11 = val_11 + (((long)(int)(optionIndex)) << 4);
        val_8 = null;
        val_8 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = (1152921510472987776 + ((long)(int)(optionIndex)) << 4) + 32, hi = (1152921510472987776 + ((long)(int)(optionIndex)) << 4) + 32, lo = (1152921510472987776 + ((long)(int)(optionIndex)) << 4) + 32 + 8, mid = (1152921510472987776 + ((long)(int)(optionIndex)) << 4) + 32 + 8}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        decimal val_7 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.stoleAmount, hi = this.stoleAmount, lo = (1152921510472987776 + ((long)(int)(optionIndex)) << 4) + 32 + 8, mid = (1152921510472987776 + ((long)(int)(optionIndex)) << 4) + 32 + 8}, d2:  new System.Decimal() {flags = (System.Decimal.__il2cppRuntimeField_static_fields + ((long)(int)(optionIndex)) << 4) + 32, hi = (System.Decimal.__il2cppRuntimeField_static_fields + ((long)(int)(optionIndex)) << 4) + 32, lo = (System.Decimal.__il2cppRuntimeField_static_fields + ((long)(int)(optionIndex)) << 4) + 32 + 8, mid = (System.Decimal.__il2cppRuntimeField_static_fields + ((long)(int)(optionIndex)) << 4) + 32 + 8});
        this.stoleAmount = val_7;
        mem[1152921516588222832] = val_7.lo;
        mem[1152921516588222836] = val_7.mid;
        this.raidParticles[(long)optionIndex].Play();
        this.coinBurstParticle.Play();
    }
    private void OnRaidButton1Clicked()
    {
        this.PickRaidOptions(optionIndex:  0);
    }
    private void OnRaidButton2Clicked()
    {
        this.PickRaidOptions(optionIndex:  1);
    }
    private void OnRaidButton3Clicked()
    {
        this.PickRaidOptions(optionIndex:  2);
    }
    private void OnRaidButton4Clicked()
    {
        this.PickRaidOptions(optionIndex:  3);
    }
    private void OnContinueClicked()
    {
        this.TweenInRaidGroup();
    }
    private void OnAddToPiggyClicked()
    {
        var val_16;
        var val_17;
        var val_18;
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        val_16 = null;
        val_16 = null;
        PiggyBankRaidEventHandler.<Instance>k__BackingField.SendRaidResultToServer(amountStolen:  new System.Decimal() {flags = this.stoleAmount, hi = this.stoleAmount});
        val_17 = 0;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_18 = null;
            val_18 = null;
            if((PiggyBankRaidEventHandler.<Instance>k__BackingField.<QA_NextPiggyCreditFillExactlyMax>k__BackingField) != false)
        {
                decimal val_4 = Item[PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankLevel];
            decimal val_5 = PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankCoins;
            decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
            this.stoleAmount = val_6;
            mem[1152921516589129632] = val_6.lo;
            mem[1152921516589129636] = val_6.mid;
            PiggyBankRaidEventHandler.<Instance>k__BackingField.<QA_NextPiggyCreditFillExactlyMax>k__BackingField = false;
            val_17 = 0;
            UnityEngine.Debug.LogWarning(message:  "[PiggyRaid] Doing a one-time modification of stolen amount to "("[PiggyRaid] Doing a one-time modification of stolen amount to ") + this.stoleAmount);
        }
        
        }
        
        val_20 = null;
        val_20 = null;
        decimal val_8 = PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankCoins;
        val_21 = null;
        val_21 = null;
        decimal val_9 = PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankCoins;
        decimal val_10 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, d2:  new System.Decimal() {flags = this.stoleAmount, hi = this.stoleAmount, lo = val_4.lo, mid = val_4.mid});
        PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankCoins = new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid};
        val_22 = null;
        val_22 = null;
        PiggyBankRaidEventHandler.<Instance>k__BackingField.UpdateProgressToServer();
        val_23 = null;
        val_23 = null;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_11 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_11.Add(key:  "Amount", value:  this.stoleAmount);
        val_11.Add(key:  "Current Piggy Bank", value:  val_10);
        if((System.String.IsNullOrEmpty(value:  PiggyBankRaidPlayerProfile.__il2cppRuntimeField_name)) != true)
        {
                val_11.Add(key:  "Raided Opponent ID", value:  PiggyBankRaidPlayerProfile.__il2cppRuntimeField_name);
        }
        
        val_24 = null;
        val_24 = null;
        App.trackerManager.track(eventName:  "Raid Complete", data:  val_11);
        val_25 = null;
        val_25 = null;
        PiggyBankRaidEventHandler.<Instance>k__BackingField.currPurchasePoint = 103;
        GameBehavior val_13 = App.getBehavior;
        val_13.<metaGameBehavior>k__BackingField.PlayAddCoinAnimation(addedAmount:  new System.Decimal() {flags = this.stoleAmount, hi = this.stoleAmount, lo = mem[(1152921504946249728 + (public PiggyBankRaidPopup MetaGameBehavior::ShowUGUIMonolith<PiggyBankRaidPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312], mid = mem[(1152921504946249728 + (public PiggyBankRaidPopup MetaGameBehavior::ShowUGUIMonolith<PiggyBankRaidPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312]});
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public PiggyBankRaidPickerPopup()
    {
        this.pickAmount = 3;
    }
    private void <TweenInRaidGroup>b__28_0()
    {
        if(this.introGroup != null)
        {
                this.introGroup.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }

}
