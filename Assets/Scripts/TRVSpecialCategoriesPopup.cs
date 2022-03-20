using UnityEngine;
public class TRVSpecialCategoriesPopup : FrameSkipper
{
    // Fields
    private UnityEngine.UI.Image categoryImage;
    private UnityEngine.UI.Image progressFillBar;
    private UnityEngine.UI.Text levelText;
    private UnityEngine.UI.Text entryCostText;
    private UnityEngine.UI.Text categoryNameText;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.UI.Text nextLevelText;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button entryButton;
    private CoinCurrencyCollectAnimationInstantiator coinAnim;
    private UnityEngine.Transform coinFlyTo;
    private UnityEngine.GameObject playbuttonLobbyGroup;
    private System.Collections.Generic.List<TRVDynamicSliderTick> sliderTicks;
    
    // Properties
    private int entryCost { get; }
    
    // Methods
    private int get_entryCost()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (int)val_1._quizEntryCost;
    }
    private void OnEnable()
    {
        this.SetupUI();
    }
    private void SetupUI()
    {
        var val_26;
        var val_27;
        System.Action<TRVDynamicSliderTick> val_29;
        var val_31;
        var val_32;
        var val_33;
        System.Func<System.Int32, System.Boolean> val_35;
        object val_36;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 1)
        {
            goto label_6;
        }
        
        this.playbuttonLobbyGroup.SetActive(value:  true);
        string val_3 = this.playbuttonLobbyGroup.entryCost.ToString();
        this.entryButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVSpecialCategoriesPopup::OnButtonClickLobby()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVSpecialCategoriesPopup::<SetupUI>b__16_0()));
        if((System.Void TRVSpecialCategoriesPopup::<SetupUI>b__16_0()) == 0)
        {
            goto label_13;
        }
        
        mem[1152921517384098744].RemoveAllListeners();
        mem[1152921517384098744].AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVSpecialCategoriesPopup::OnStoreButtonClicked()));
        gameObject.SetActive(value:  true);
        goto label_24;
        label_6:
        this.playbuttonLobbyGroup.SetActive(value:  false);
        this.entryButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVSpecialCategoriesPopup::OnButtonClickedCatSelectMenu()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVSpecialCategoriesPopup::<SetupUI>b__16_2()));
        goto label_24;
        label_13:
        mem2[0] = new System.Action(object:  this, method:  System.Void TRVSpecialCategoriesPopup::<SetupUI>b__16_1());
        label_24:
        var val_26 = TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 72;
        val_26 = val_26 + 1;
        string val_12 = System.String.Format(format:  "LEVEL {0}", arg0:  val_26.ToString());
        this.categoryImage.sprite = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 64);
        val_26 = 1152921504964939776;
        val_27 = null;
        val_27 = null;
        val_29 = TRVSpecialCategoriesPopup.<>c.<>9__16_3;
        if(val_29 == null)
        {
                System.Action<TRVDynamicSliderTick> val_17 = null;
            val_29 = val_17;
            val_17 = new System.Action<TRVDynamicSliderTick>(object:  TRVSpecialCategoriesPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVSpecialCategoriesPopup.<>c::<SetupUI>b__16_3(TRVDynamicSliderTick x));
            TRVSpecialCategoriesPopup.<>c.<>9__16_3 = val_29;
        }
        
        this.sliderTicks.ForEach(action:  val_17);
        if(1152921515450617360 < 1)
        {
            goto label_46;
        }
        
        var val_27 = 0;
        label_51:
        if(val_27 >= 1152921517382644384)
        {
            goto label_46;
        }
        
        if(1152921517382644384 <= val_27)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_26 = 0;
        if(1152921515450617360 <= val_27)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_31 = System.Void ShortcutExtensionsTextMeshPro.<>c__DisplayClass5_0::<DOFaceFade>b__1(UnityEngine.Color x);
        if(1152921515450617360 <= val_27)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_31 = "WGStoreItem_spins";
        }
        
        Init(myValue:  179398208, maxValue:  System.Linq.Enumerable.Max(source:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 40.Keys), myDisplayAmount:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 40.Item[-1082943552], lastTickOffset:  22, isComplete:  false);
        val_27 = val_27 + 1;
        if(val_27 < 44328216)
        {
            goto label_51;
        }
        
        label_46:
        val_32 = null;
        val_33 = 1152921504964726784;
        val_35 = TRVSpecialCategoriesPopup.<>c.<>9__16_4;
        if(val_35 == null)
        {
                System.Func<System.Int32, System.Boolean> val_21 = null;
            val_35 = val_21;
            val_21 = new System.Func<System.Int32, System.Boolean>(object:  TRVSpecialCategoriesPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVSpecialCategoriesPopup.<>c::<SetupUI>b__16_4(int x));
            TRVSpecialCategoriesPopup.<>c.<>9__16_4 = val_35;
        }
        
        int val_22 = System.Linq.Enumerable.FirstOrDefault<System.Int32>(source:  System.Linq.Enumerable.ToList<System.Int32>(source:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 40.Keys), predicate:  val_21);
        val_36 = val_22;
        if(val_22 == 0)
        {
                if((public static System.Int32 System.Linq.Enumerable::FirstOrDefault<System.Int32>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_36 = mem[222179988];
        }
        
        val_36 = val_36 - (TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 72);
        string val_24 = System.String.Format(format:  "Complete {0} level{1} for the next reward!", arg0:  val_36, arg1:  (val_36 > 1) ? "s" : "");
        if(null == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        float val_28 = (float)TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 32;
        val_28 = ((float)TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 72) / val_28;
        this.progressFillBar.fillAmount = val_28;
        mem[1152921517384240392] = new System.Action(object:  this, method:  System.Void TRVSpecialCategoriesPopup::UpdateTime());
    }
    private void OnButtonClickLobby()
    {
        var val_18;
        var val_19;
        System.Action val_21;
        decimal val_3 = System.Decimal.op_Implicit(value:  App.Player.entryCost);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid})) != false)
        {
                WGAudioController val_5 = MonoSingleton<WGAudioController>.Instance;
            val_5.sound.PlayGeneralSound(type:  2, oneshot:  true, pitch:  1f, vol:  1f);
            int val_6 = val_5.sound.entryCost;
            decimal val_7 = System.Decimal.op_Implicit(value:  val_6);
            bool val_8 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, source:  "Special Category", externalParams:  0, animated:  true);
            UnityEngine.Vector3 val_9 = this.coinFlyTo.position;
            int val_10 = this.coinFlyTo.entryCost;
            val_6.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, particleCount:  0, animateStatView:  false);
            this.entryButton.interactable = false;
            UUI_EventsController.DisableInputs();
            this.GetComponentInChildren<UnityEngine.ParticleSystem>().Stop(withChildren:  true, stopBehavior:  0);
            UnityEngine.Coroutine val_13 = this.StartCoroutine(routine:  this.WaitForCoinAnimation());
            return;
        }
        
        val_18 = null;
        val_18 = null;
        PurchaseProxy.currentPurchasePoint = 0;
        GameBehavior val_14 = App.getBehavior;
        val_19 = null;
        val_19 = null;
        val_21 = TRVSpecialCategoriesPopup.<>c.<>9__17_0;
        if(val_21 == null)
        {
                System.Action val_16 = null;
            val_21 = val_16;
            val_16 = new System.Action(object:  TRVSpecialCategoriesPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVSpecialCategoriesPopup.<>c::<OnButtonClickLobby>b__17_0());
            TRVSpecialCategoriesPopup.<>c.<>9__17_0 = val_21;
        }
        
        val_14.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_16);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnStoreButtonClicked()
    {
        var val_5;
        var val_6;
        System.Action val_8;
        val_5 = null;
        val_5 = null;
        PurchaseProxy.currentPurchasePoint = 0;
        GameBehavior val_1 = App.getBehavior;
        val_6 = null;
        val_6 = null;
        val_8 = TRVSpecialCategoriesPopup.<>c.<>9__18_0;
        if(val_8 == null)
        {
                System.Action val_3 = null;
            val_8 = val_3;
            val_3 = new System.Action(object:  TRVSpecialCategoriesPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVSpecialCategoriesPopup.<>c::<OnStoreButtonClicked>b__18_0());
            TRVSpecialCategoriesPopup.<>c.<>9__18_0 = val_8;
        }
        
        val_1.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_3);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnButtonClickedCatSelectMenu()
    {
        var val_3;
        TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID.__unknownFiledOffset_18 = 0;
        val_3 = null;
        val_3 = null;
        TRVMainController.noAnswerSelectedCharacter = 2;
        MonoSingleton<TRVMainController>.Instance.InitSpecialCategories();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private System.Collections.IEnumerator WaitForCoinAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVSpecialCategoriesPopup.<WaitForCoinAnimation>d__20();
    }
    private void UpdateTime()
    {
        var val_14;
        var val_15;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID.Subtract(value:  new System.DateTime() {dateData = val_1.dateData});
        val_14 = null;
        val_14 = null;
        if((System.TimeSpan.Compare(t1:  new System.TimeSpan() {_ticks = val_2._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) == 1)
        {
                val_15 = null;
            val_15 = null;
        }
        
        string val_10 = System.String.Format(format:  "Event ends : {0}d {1}h {2}m", arg0:  System.TimeSpan.Zero.Days.ToString(format:  "0"), arg1:  System.TimeSpan.Zero.Hours.ToString(format:  "00"), arg2:  System.TimeSpan.Zero.Minutes.ToString(format:  "00"));
        if(System.TimeSpan.Zero.TotalSeconds >= 0)
        {
                return;
        }
        
        GameBehavior val_12 = App.getBehavior;
        this.Close(doCatSelectOnClose:  ((val_12.<metaGameBehavior>k__BackingField) == 2) ? 1 : 0);
    }
    private void Close(bool doCatSelectOnClose = False)
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVSpecialCategoriesPopup()
    {
    
    }
    private void <SetupUI>b__16_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void <SetupUI>b__16_1()
    {
        static_value_028080F8.RemoveAllListeners();
        static_value_028080F8.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVSpecialCategoriesPopup::OnStoreButtonClicked()));
        gameObject.SetActive(value:  true);
    }
    private void <SetupUI>b__16_2()
    {
        this.Close(doCatSelectOnClose:  true);
    }

}
