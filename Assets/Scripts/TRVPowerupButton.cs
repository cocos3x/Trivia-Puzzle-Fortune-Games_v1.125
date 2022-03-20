using UnityEngine;
public abstract class TRVPowerupButton : MyButton
{
    // Fields
    private UnityEngine.UI.Text costText;
    private UnityEngine.UI.Image currencyIcon;
    private UnityEngine.GameObject glow;
    public const string LastHintUsedCPrefKey = "lastPowerupUsedLevel";
    private TRVPowerup <powerup>k__BackingField;
    protected UnityEngine.GameObject notEnoughCoinsTooltip;
    protected UnityEngine.GameObject ftuxTooltip;
    protected bool isShowingFTUX;
    private bool startedGlow;
    public System.Action supplmentalOneTimeOnClickAction;
    
    // Properties
    public virtual TRVPowerup powerup { get; set; }
    protected virtual string pref_ftux_shown_key { get; }
    public int lastLevelAnyPowerupUsed { get; set; }
    
    // Methods
    public virtual TRVPowerup get_powerup()
    {
        return (TRVPowerup)this.<powerup>k__BackingField;
    }
    private void set_powerup(TRVPowerup value)
    {
        this.<powerup>k__BackingField = value;
    }
    protected virtual string get_pref_ftux_shown_key()
    {
        return "";
    }
    public int get_lastLevelAnyPowerupUsed()
    {
        return CPlayerPrefs.GetInt(key:  "lastPowerupUsedLevel", defaultValue:  0);
    }
    public void set_lastLevelAnyPowerupUsed(int value)
    {
        CPlayerPrefs.SetInt(key:  "lastPowerupUsedLevel", val:  value);
    }
    protected void CheckFTUX()
    {
        Player val_1 = App.Player;
        if((UnityEngine.PlayerPrefs.GetInt(key:  this, defaultValue:  0)) == 1)
        {
                return;
        }
        
        if((MonoSingleton<TRVMainController>.Instance.eventEntryType) == true)
        {
                return;
        }
        
        WGWindowManager val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVPowerupFtuxWindow>(showNext:  false);
        this.isShowingFTUX = true;
        MonoSingleton<TRVGameplayUI>.Instance.StopTimer();
        if(this.ftuxTooltip != 0)
        {
                return;
        }
        
        DynamicToolTip val_10 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        this.ftuxTooltip = val_10.gameObject;
        val_10.ShowToolTip(objToToolTip:  this.gameObject, text:  this, topToolTip:  true, displayDuration:  10000f, width:  800f, height:  300f, tooltipOffsetX:  0f, tooltipOffsetY:  -50f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
        UnityEngine.Color val_14 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.45f);
        System.Nullable<UnityEngine.Color> val_15 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_14.r, g = val_14.g, b = val_14.b, a = val_14.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        System.Collections.Generic.List<UnityEngine.Transform> val_18 = new System.Collections.Generic.List<UnityEngine.Transform>();
        val_18.Add(item:  this.gameObject.transform);
        val_18.Add(item:  this.ftuxTooltip.gameObject.transform);
        this = MonoSingleton<GameMaskOverlay>.Instance;
        this.ShowOverlay(contentToOverlay:  val_18.ToArray());
    }
    protected void HideFTUXAndRefresh()
    {
        if(this.ftuxTooltip != 0)
        {
                UnityEngine.Object.Destroy(obj:  this.ftuxTooltip);
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  new System.Action(object:  this, method:  System.Void TRVPowerupButton::<HideFTUXAndRefresh>b__19_0()));
    }
    protected virtual void OnPowerupSuccess()
    {
    
    }
    protected virtual void OnPowerupFailed()
    {
        var val_7;
        MonoSingleton<TRVGameplayUI>.Instance.StopTimer();
        MonoSingleton<TRVGameplayUI>.Instance.SetGameplayAlpha(visible:  false);
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        val_7 = null;
        val_7 = null;
        PurchaseProxy.currentPurchasePoint = 86;
        GameBehavior val_4 = App.getBehavior;
        val_4.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  new System.Action(object:  this, method:  System.Void TRVPowerupButton::CheckOOC()));
    }
    protected virtual string GetFtuxText()
    {
        return "";
    }
    protected virtual bool IsPowerupAvailable()
    {
        return true;
    }
    protected virtual bool IsEligibleToShowInQOTD()
    {
        return true;
    }
    protected virtual void SetupButtonUI()
    {
        var val_9;
        this.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
        if((this & 1) == 0)
        {
            goto label_3;
        }
        
        if(this.IsFreeCost() == false)
        {
            goto label_5;
        }
        
        string val_4 = Localization.Localize(key:  "free_upper", defaultValue:  "FREE", useSingularKey:  false);
        UnityEngine.GameObject val_5 = this.currencyIcon.gameObject;
        val_9 = 0;
        goto label_9;
        label_3:
        this.DisableButton();
        goto label_10;
        label_5:
        string val_6 = this.ToString();
        val_9 = 1;
        label_9:
        this.currencyIcon.gameObject.SetActive(value:  true);
        label_10:
        this.gameObject.SetActive(value:  true);
    }
    public virtual void PlayReminderAnim(int remainingTime)
    {
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        UnityEngine.UI.Button val_3 = this.GetComponent<UnityEngine.UI.Button>();
        if((public UnityEngine.UI.Button UnityEngine.Component::GetComponent<UnityEngine.UI.Button>()) == 0)
        {
                return;
        }
        
        mem[1152921517331628256] = (float)remainingTime;
        if(this.startedGlow != false)
        {
                return;
        }
        
        this.startedGlow = true;
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.StartGlow());
    }
    public void UpdateButton()
    {
        if(this.IsEligibleToShow() == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.StartFadingIn());
    }
    public void FadeOut()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.StartFadingOut());
    }
    public override void OnButtonClick()
    {
        int val_11;
        UnityEngine.Object val_12;
        this.OnButtonClick();
        Player val_1 = App.Player;
        if(this.IsFreeCost() == false)
        {
            goto label_8;
        }
        
        this.DisableButton();
        if(this.isShowingFTUX == false)
        {
            goto label_9;
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  this, value:  1);
        this.HideFTUXAndRefresh();
        goto label_10;
        label_9:
        if(this.IsFreeCost() == true)
        {
            goto label_16;
        }
        
        Player val_4 = App.Player;
        val_11 = val_4;
        val_4.lastLevelAnyPowerupUsed = val_11;
        goto label_16;
        label_8:
        val_12 = 0;
        if(this.notEnoughCoinsTooltip == val_12)
        {
                DynamicToolTip val_7 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
            this.notEnoughCoinsTooltip = val_7.gameObject;
            val_12 = this.gameObject;
            val_7.ShowToolTip(objToToolTip:  val_12, text:  "NOT ENOUGH GEMS!", topToolTip:  true, displayDuration:  3.5f, width:  0f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
        }
        
        label_16:
        label_10:
        if(this.supplmentalOneTimeOnClickAction != null)
        {
                this.supplmentalOneTimeOnClickAction.Invoke();
        }
        
        this.supplmentalOneTimeOnClickAction = 0;
    }
    private System.Collections.IEnumerator StartFadingIn()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVPowerupButton.<StartFadingIn>d__30();
    }
    private System.Collections.IEnumerator StartFadingOut()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVPowerupButton.<StartFadingOut>d__31();
    }
    private System.Collections.IEnumerator StartGlow()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVPowerupButton.<StartGlow>d__32();
    }
    public void DisableButton()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
    }
    private void CheckOOC()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.CheckOOCAfterDelay());
    }
    private System.Collections.IEnumerator CheckOOCAfterDelay()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVPowerupButton.<CheckOOCAfterDelay>d__35();
    }
    private void ContinueGame()
    {
        MonoSingleton<TRVGameplayUI>.Instance.SetGameplayAlpha(visible:  true);
        MonoSingleton<TRVGameplayUI>.Instance.ContinueTimer(duration:  null);
    }
    private bool IsEligibleToShow()
    {
        var val_3 = 0;
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) == false)
        {
                return this.IsUnlocked();
        }
        
        if((this & 1) == 0)
        {
                return false;
        }
        
        return this.IsUnlocked();
    }
    protected TRVPowerupButton()
    {
    
    }
    private void <HideFTUXAndRefresh>b__19_0()
    {
        MonoSingleton<TRVMainController>.Instance.StartQuiz();
        SLCWindow.CloseWindow(window:  MonoSingleton<WGWindowManager>.Instance.GetWindow<TRVPowerupFtuxWindow>().gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void <CheckOOCAfterDelay>b__35_0()
    {
        this.ContinueGame();
    }

}
