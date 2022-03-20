using UnityEngine;
public class SeasonPassEventPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject mainWindow;
    private UnityEngine.GameObject infoWindow;
    private UnityEngine.UI.Text titleText;
    private UnityEngine.UI.Button showPassButton;
    private UnityEngine.GameObject activePassGO;
    private UnityEngine.UI.Button infoButton;
    private UnityEngine.UI.Text lvlProgressionText;
    private UnityEngine.UI.Slider lvlProgressionBar;
    private UnityEngine.UI.Text currentTierText;
    private UnityEngine.UI.Image currentTierImg;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button levelButton;
    private UnityEngine.UI.LoopVerticalScrollRect loopScrollRect;
    private UnityEngine.RectTransform maskTransform;
    private UnityEngine.RectTransform tiersScrollContainer;
    public UnityEngine.GameObject tierHeader;
    public UnityEngine.GameObject tierLockDivider;
    private SeasonPassTierUI tierRewardPrefab;
    private UnityEngine.Sprite freeTierIcon;
    public System.Collections.Generic.List<UnityEngine.Sprite> tierIconTextures;
    private UnityEngine.GameObject passWindow;
    private UGUINetworkedButton purchasePassButton;
    private UnityEngine.UI.Text passTimerText;
    private UnityEngine.UI.Text timerText;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private CurrencyCollectAnimationInstantiator gemAnimControl;
    private CurrencyCollectAnimationInstantiator goldCurrencyAnimControl;
    private WADPetFoodAnimationInstantiator foodAnimControl;
    private PetCardAnimationInstantiator petCardControl;
    private UnityEngine.Transform currencyAnimParent;
    private SeasonPassEventHandler eventHandler;
    private bool onLevelCompleted;
    private System.Collections.Generic.List<System.Tuple<SeasonPassEcon.Item, System.Decimal>> claimedAwards;
    
    // Methods
    public void Start()
    {
        this.eventHandler = SeasonPassEventHandler.<Instance>k__BackingField;
        System.Collections.Generic.List<Tier> val_9 = this.eventHandler.<econ>k__BackingField.tiers;
        val_9 = val_9 + 1;
        mem2[0] = val_9;
        this.loopScrollRect.RefillCells(offset:  0);
        FrameSkipper val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_2.updateLogic = new System.Action(object:  this, method:  System.Void SeasonPassEventPopup::UpdateTimerText());
        this.levelButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void SeasonPassEventPopup::OnClickLevelButton()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void SeasonPassEventPopup::Close()));
        this.purchasePassButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void SeasonPassEventPopup::OnConnectPurchaseClick(bool connected));
        System.Delegate val_8 = System.Delegate.Combine(a:  this.eventHandler.OnPurchaseAttempt, b:  new System.Action<System.Boolean>(object:  this, method:  public System.Void SeasonPassEventPopup::OnPurchasePlusPass(bool success)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        this.eventHandler.OnPurchaseAttempt = val_8;
        this.RefreshUI();
        return;
        label_16:
    }
    private void OnDestroy()
    {
        System.Delegate val_2 = System.Delegate.Remove(source:  this.eventHandler.OnPurchaseAttempt, value:  new System.Action<System.Boolean>(object:  this, method:  public System.Void SeasonPassEventPopup::OnPurchasePlusPass(bool success)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.eventHandler.OnPurchaseAttempt = val_2;
        return;
        label_3:
    }
    public void UICompleteLevel()
    {
        this.onLevelCompleted = true;
    }
    public void RefreshUI()
    {
        this.mainWindow.SetActive(value:  true);
        this.infoWindow.SetActive(value:  false);
        this.passWindow.SetActive(value:  false);
        GameBehavior val_1 = App.getBehavior;
        this.continueButton.gameObject.SetActive(value:  ((val_1.<metaGameBehavior>k__BackingField) == 2) ? 1 : 0);
        this.levelButton.gameObject.SetActive(value:  ((val_1.<metaGameBehavior>k__BackingField) != 2) ? 1 : 0);
        string val_6 = this.eventHandler.uniqueSeasonName;
        UnityEngine.UI.Text val_7 = this.levelButton.GetComponentInChildren<UnityEngine.UI.Text>();
        string val_10 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "level_upper", defaultValue:  "", useSingularKey:  false), arg1:  App.Player);
        int val_11 = this.eventHandler.CurrentTierProgression();
        int val_12 = this.eventHandler.NextTierTarget();
        int val_14 = UnityEngine.Mathf.Min(a:  (this.eventHandler.<progression>k__BackingField.currentTier) + 1, b:  30);
        float val_37 = (float)val_11;
        val_37 = val_37 / (float)val_12;
        string val_16 = System.String.Format(format:  "{0}/{1}", arg0:  System.Math.Min(val1:  val_11, val2:  val_12), arg1:  val_12);
        string val_17 = val_14.ToString();
        SeasonPassEventHandler val_38 = this.eventHandler;
        int val_18 = this.eventHandler.<progression>k__BackingField.CurrentChestTier;
        if(val_38 <= val_18)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_38 = val_38 + (val_18 << 3);
        this.currentTierImg.sprite = (this.eventHandler + (val_18) << 3).OnPurchaseAttempt;
        this.timerText.transform.parent.parent.gameObject.SetActive(value:  (this.onLevelCompleted == false) ? 1 : 0);
        this.showPassButton.gameObject.SetActive(value:  ((this.eventHandler.<progression>k__BackingField.hasPass) == false) ? 1 : 0);
        this.activePassGO.SetActive(value:  this.eventHandler.<progression>k__BackingField.hasPass);
        string val_27 = this.purchasePassButton.GetComponentInChildren<UnityEngine.UI.Text>().GetPlusPackagePrice();
        this.coinsAnimControl.gameObject.SetActive(value:  false);
        this.gemAnimControl.gameObject.SetActive(value:  false);
        this.goldCurrencyAnimControl.gameObject.SetActive(value:  false);
        this.foodAnimControl.gameObject.SetActive(value:  false);
        this.petCardControl.gameObject.SetActive(value:  false);
        UnityEngine.Coroutine val_36 = this.StartCoroutine(routine:  this.ScrollToTier(tierIndex:  System.Math.Max(val1:  0, val2:  val_14 - 1)));
    }
    public void OnRewardClaim(int index, bool isPassReward)
    {
        this.claimedAwards = this.eventHandler.ClaimAward(tierIndex:  index, isPass:  isPassReward);
        this.AnimateClaimedAward();
    }
    public void OnClickLevelButton()
    {
        this.Close();
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_410;
    }
    public void OnConnectPurchaseClick(bool connected)
    {
        var val_5;
        System.Func<System.Boolean> val_7;
        if(connected != false)
        {
                this.purchasePassButton.interactable = false;
            this.eventHandler.PurchasePlusPassPackage();
            return;
        }
        
        System.Func<System.Boolean>[] val_3 = new System.Func<System.Boolean>[1];
        val_5 = null;
        val_5 = null;
        val_7 = SeasonPassEventPopup.<>c.<>9__39_0;
        if(val_7 == null)
        {
                System.Func<System.Boolean> val_4 = null;
            val_7 = val_4;
            val_4 = new System.Func<System.Boolean>(object:  SeasonPassEventPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean SeasonPassEventPopup.<>c::<OnConnectPurchaseClick>b__39_0());
            SeasonPassEventPopup.<>c.<>9__39_0 = val_7;
        }
        
        val_3[0] = val_7;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupInternetRequired(buttonCallbacks:  val_3);
        this.Close();
    }
    public void OnPurchasePlusPass(bool success)
    {
        var val_5;
        System.Func<System.Boolean> val_7;
        if(success != false)
        {
                this.RefreshUI();
            this.loopScrollRect.RefreshCells();
            return;
        }
        
        System.Func<System.Boolean>[] val_3 = new System.Func<System.Boolean>[1];
        val_5 = null;
        val_5 = null;
        val_7 = SeasonPassEventPopup.<>c.<>9__40_0;
        if(val_7 == null)
        {
                System.Func<System.Boolean> val_4 = null;
            val_7 = val_4;
            val_4 = new System.Func<System.Boolean>(object:  SeasonPassEventPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean SeasonPassEventPopup.<>c::<OnPurchasePlusPass>b__40_0());
            SeasonPassEventPopup.<>c.<>9__40_0 = val_7;
        }
        
        val_3[0] = val_7;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupPurchaseFail(buttonCallbacks:  val_3);
        this.Close();
    }
    public void Close()
    {
        this.CancelInvoke();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void AnimateClaimedAward()
    {
        mem2[0] = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        this.coinsAnimControl.gameObject.SetActive(value:  false);
        this.gemAnimControl.gameObject.SetActive(value:  false);
        this.goldCurrencyAnimControl.gameObject.SetActive(value:  false);
        this.foodAnimControl.gameObject.SetActive(value:  false);
        this.petCardControl.gameObject.SetActive(value:  false);
        if(this.foodAnimControl == null)
        {
                return;
        }
        
        this.claimedAwards.RemoveAt(index:  0);
        if((X24 + 16) > 4)
        {
                return;
        }
        
        var val_40 = 32561632 + (X24 + 16) << 2;
        val_40 = val_40 + 32561632;
        goto (32561632 + (X24 + 16) << 2 + 32561632);
    }
    private void AnimatePetCards(System.Collections.Generic.List<System.Tuple<WADPets.WADPet, int>> petCards, System.Action actionOnComplete)
    {
        var val_3;
        var val_4;
        var val_9;
        int val_10;
        this.petCardControl.gameObject.SetActive(value:  true);
        this.petCardControl.OnCompleteCallback = actionOnComplete;
        List.Enumerator<T> val_2 = petCards.GetEnumerator();
        label_12:
        val_9 = public System.Boolean List.Enumerator<System.Tuple<WADPets.WADPet, System.Int32>>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_3 + 16) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_10 = (val_3 + 16 + 32) - (val_3 + 24);
        val_9 = 0;
        decimal val_6 = System.Decimal.op_Implicit(value:  val_10);
        if((val_3 + 16) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_10 = mem[val_3 + 16 + 32];
        val_10 = val_3 + 16 + 32;
        val_9 = 0;
        decimal val_7 = System.Decimal.op_Implicit(value:  val_10);
        if(this.petCardControl == null)
        {
                throw new NullReferenceException();
        }
        
        this.petCardControl.AddCard(pet:  val_3 + 16, startBalance:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, endBalance:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
        goto label_12;
        label_5:
        val_4.Dispose();
        this.petCardControl.Play();
    }
    private void AnimateCoins(decimal fromAmount, decimal toAmount, System.Action actionOnComplete)
    {
        this.coinsAnimControl.gameObject.SetActive(value:  true);
        this.coinsAnimControl.OnCompleteCallback = actionOnComplete;
        this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = fromAmount.flags, hi = fromAmount.hi, lo = fromAmount.lo, mid = fromAmount.mid}, toValue:  new System.Decimal() {flags = toAmount.flags, hi = toAmount.hi, lo = toAmount.lo, mid = toAmount.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void AnimateReward(CurrencyCollectAnimationInstantiator animControl, int fromAmount, int toAmount, System.Action actionOnComplete, float delay = 0)
    {
        UnityEngine.GameObject val_1 = animControl.gameObject;
        val_1.SetActive(value:  true);
        animControl.OnCompleteCallback = actionOnComplete;
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  val_1.StartAnimating(animControl:  animControl, fromAmount:  fromAmount, toAmount:  toAmount, delay:  delay));
    }
    private System.Collections.IEnumerator StartAnimating(CurrencyCollectAnimationInstantiator animControl, int fromAmount, int toAmount, float delay)
    {
        .<>1__state = 0;
        .animControl = animControl;
        .fromAmount = fromAmount;
        .toAmount = toAmount;
        .delay = delay;
        return (System.Collections.IEnumerator)new SeasonPassEventPopup.<StartAnimating>d__46();
    }
    private void UpdateTimerText()
    {
        UnityEngine.UI.Text val_14;
        ulong val_15;
        val_14 = this;
        System.DateTime val_1 = this.eventHandler.GetTimeEnd();
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        val_15 = val_2.dateData;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_15});
        if(val_3._ticks.TotalSeconds < 0)
        {
                return;
        }
        
        object[] val_5 = new object[4];
        val_5[0] = val_3._ticks.Days;
        val_5[1] = val_3._ticks.Hours;
        val_5[2] = val_3._ticks.Minutes;
        val_15 = val_3._ticks.Seconds;
        val_5[3] = val_15;
        if(this.passWindow.activeSelf == false)
        {
                return;
        }
        
        val_14 = this.passTimerText;
        string val_13 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "season_pass_ends", defaultValue:  "SEASON ENDS IN", useSingularKey:  false), arg1:  System.String.Format(format:  "{0}:{1:00}:{2:00}:{3:00}", args:  val_5));
    }
    private System.Collections.IEnumerator ScrollToTier(int tierIndex)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .tierIndex = tierIndex;
        return (System.Collections.IEnumerator)new SeasonPassEventPopup.<ScrollToTier>d__48();
    }
    public SeasonPassEventPopup()
    {
    
    }

}
