using UnityEngine;
public class LightningLevelsUIController : MonoSingleton<LightningLevelsUIController>
{
    // Fields
    protected UnityEngine.GameObject lightningEventButtonPrefab;
    protected UnityEngine.Transform eventButton;
    protected UnityEngine.GameObject lightningEffectsPrefab;
    private UnityEngine.Transform lightningEffectsParent;
    private UnityEngine.Transform mainLayout;
    private UnityEngine.UI.Button storeButton;
    private UnityEngine.UI.Button menuButton;
    private UnityEngine.UI.Button petsButton;
    protected FrameSkipper frameSkipper;
    protected WGLightningProgressPopup lightningStrikeFlyout;
    protected bool closedPreviousFlyout;
    protected LightningEvents thisEvent;
    protected System.Collections.Generic.List<UnityEngine.GameObject> lightningEffects;
    protected bool isTimerPaused;
    protected bool isAppPaused;
    private WGEventButtonProgressLightningLevels eventProgressUI;
    private LightningCountdownButton <lightningEventButton>k__BackingField;
    
    // Properties
    public bool IsTimerPaused { get; }
    public WGEventButtonProgressLightningLevels EventProgressUI { get; }
    public LightningCountdownButton lightningEventButton { get; set; }
    private bool useRevisedUX { get; }
    
    // Methods
    public bool get_IsTimerPaused()
    {
        return (bool)this.isTimerPaused;
    }
    public WGEventButtonProgressLightningLevels get_EventProgressUI()
    {
        WGEventButtonProgressLightningLevels val_4;
        if(this.eventProgressUI == 0)
        {
                MainController val_2 = MainController.instance;
            this.eventProgressUI = val_2.eventButtonPanel.GetEventButton(eventId:  "LightningLevels");
            return val_4;
        }
        
        val_4 = this.eventProgressUI;
        return val_4;
    }
    public LightningCountdownButton get_lightningEventButton()
    {
        return (LightningCountdownButton)this.<lightningEventButton>k__BackingField;
    }
    public void set_lightningEventButton(LightningCountdownButton value)
    {
        this.<lightningEventButton>k__BackingField = value;
    }
    private bool get_useRevisedUX()
    {
        null = null;
        return (bool)(App.game == 18) ? 1 : 0;
    }
    public override void InitMonoSingleton()
    {
        UnityEngine.Events.UnityAction val_10;
        if((LightningLevelsEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        this.thisEvent = 1;
        this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this.transform);
        if((UnityEngine.Object.op_Implicit(exists:  this.storeButton)) != false)
        {
                UnityEngine.Events.UnityAction val_4 = null;
            val_10 = val_4;
            val_4 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LightningLevelsUIController::HideLightningEffects());
            this.storeButton.m_OnClick.AddListener(call:  val_4);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.menuButton)) != false)
        {
                UnityEngine.Events.UnityAction val_6 = null;
            val_10 = val_6;
            val_6 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LightningLevelsUIController::HideLightningEffects());
            this.menuButton.m_OnClick.AddListener(call:  val_6);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.petsButton)) != false)
        {
                UnityEngine.Events.UnityAction val_8 = null;
            val_10 = val_8;
            val_8 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LightningLevelsUIController::HideLightningEffects());
            this.petsButton.m_OnClick.AddListener(call:  val_8);
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnInAppPurchaseStarted");
    }
    protected void OnApplicationQuit()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if(((LightningLevelsEventHandler.<Instance>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        if(((LightningLevelsEventHandler.<Instance>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if(this.isAppPaused == false)
        {
            goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_840;
        }
    
    }
    protected void OnApplicationFocus(bool focus)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if(((LightningLevelsEventHandler.<Instance>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField.InExpireInterval()) != false)
        {
                this.ResetAll();
            return;
        }
        
        if(((LightningLevelsEventHandler.<Instance>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        bool val_4 = ~focus;
        val_4 = val_4 & 1;
        this.isAppPaused = val_4;
    }
    protected void OnApplicationPause(bool pause)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if(((LightningLevelsEventHandler.<Instance>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField.InExpireInterval()) != false)
        {
                this.ResetAll();
            return;
        }
        
        if(((LightningLevelsEventHandler.<Instance>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        this.isAppPaused = pause;
        if(pause == false)
        {
                return;
        }
        
        if(this.isTimerPaused == true)
        {
                return;
        }
        
        this.isTimerPaused = true;
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_840;
    }
    public virtual void ShowLightningEffects(bool isFTUX = False)
    {
        UnityEngine.Object val_10;
        var val_11;
        val_10 = this.<lightningEventButton>k__BackingField;
        bool val_1 = UnityEngine.Object.op_Equality(x:  val_10, y:  0);
        if(val_1 != false)
        {
                if(val_1.useRevisedUX != true)
        {
                LightningCountdownButton val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.lightningEventButtonPrefab, parent:  this.eventButton.parent).GetComponent<LightningCountdownButton>();
            this.<lightningEventButton>k__BackingField = val_5;
        }
        
        }
        
        if(val_5.useRevisedUX == false)
        {
            goto label_9;
        }
        
        val_11 = 0;
        this.EventProgressUI.alpha = 1f;
        this.UpdateTimertext();
        if(isFTUX == true)
        {
            goto label_16;
        }
        
        goto label_16;
        label_9:
        val_11 = 0;
        MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.eventButton).alpha = 0f;
        if(isFTUX != false)
        {
                this.UpdateTimertext();
        }
        else
        {
                this.ShowLightningStrikeFlyout();
        }
        
        label_16:
        this.frameSkipper.updateLogic = new System.Action(object:  this, method:  typeof(LightningLevelsUIController).__il2cppRuntimeField_1D8);
        this.UpdateWordRegionLightningEffects();
    }
    public virtual void DestroyLightningEffects()
    {
        UnityEngine.Object val_11;
        if((UnityEngine.Object.op_Implicit(exists:  this.frameSkipper)) != false)
        {
                this.frameSkipper.updateLogic = 0;
        }
        
        val_11 = this.<lightningEventButton>k__BackingField;
        if((UnityEngine.Object.op_Implicit(exists:  val_11)) != false)
        {
                val_11 = this.<lightningEventButton>k__BackingField.gameObject;
            UnityEngine.Object.Destroy(obj:  val_11);
        }
        
        if(val_11.useRevisedUX != true)
        {
                UnityEngine.CanvasGroup val_5 = this.eventButton.GetComponent<UnityEngine.CanvasGroup>();
            if(val_5 != 0)
        {
                val_5.alpha = 1f;
        }
        
        }
        
        if(this.lightningEffects == null)
        {
            goto label_24;
        }
        
        List.Enumerator<T> val_7 = this.lightningEffects.GetEnumerator();
        label_21:
        if(0.MoveNext() == false)
        {
            goto label_18;
        }
        
        UnityEngine.Object.Destroy(obj:  0);
        goto label_21;
        label_18:
        0.Dispose();
        if(this.lightningStrikeFlyout != 0)
        {
                if(this.closedPreviousFlyout != true)
        {
                this.lightningStrikeFlyout.ClosePopup();
            this.lightningStrikeFlyout = 0;
        }
        
            this.closedPreviousFlyout = false;
        }
        
        label_24:
        this.lightningEffects = new System.Collections.Generic.List<UnityEngine.GameObject>();
    }
    protected void ShowLightningStrikeFlyout()
    {
        if((this.lightningStrikeFlyout != 0) && (this.closedPreviousFlyout != true))
        {
                this.lightningStrikeFlyout.ClosePopup();
            this.closedPreviousFlyout = true;
        }
        
        GameBehavior val_2 = App.getBehavior;
        this.lightningStrikeFlyout = val_2.<metaGameBehavior>k__BackingField;
        val_2.<metaGameBehavior>k__BackingField.Setup(e:  this.thisEvent);
        goto typeof(LightningLevelsUIController).__il2cppRuntimeField_1C0;
    }
    protected virtual void ShowFTUX()
    {
        if(this.useRevisedUX != false)
        {
                MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLightningLevelsFTUXFlyoutV2>(showNext:  false).ShowFTUX(eventButton:  this.EventProgressUI.transform, onClose:  0);
            return;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLightningLevelsFTUXFlyout>(showNext:  false).ShowFTUX(eventButton:  this.<lightningEventButton>k__BackingField.transform, mainLayout:  this.mainLayout, onClose:  new System.Action(object:  this, method:  System.Void LightningLevelsUIController::ShowLightningStrikeFlyout()));
    }
    protected virtual void PlayLightningSFX()
    {
        null = null;
        MonoSingleton<T>.searchedFailed + 24.PlayGameSpecificSound(id:  "LightningSoundEffect", randomIndex:  false, vol:  1f);
    }
    protected virtual void UpdateTimer()
    {
        var val_26;
        var val_27;
        var val_28;
        LightningLevelsEventHandler val_29;
        var val_30;
        val_26 = this;
        val_28 = 1152921504924897280;
        val_29 = LightningLevelsEventHandler.<Instance>k__BackingField;
        if(val_29 == null)
        {
            goto label_2;
        }
        
        if(val_29.InExpireInterval() == false)
        {
            goto label_3;
        }
        
        this.ResetAll();
        return;
        label_2:
        val_29 = val_26;
        val_26 = ???;
        val_28 = ???;
        val_27 = ???;
        goto typeof(LightningLevelsUIController).__il2cppRuntimeField_1A0;
        label_3:
        if(this.useRevisedUX != true)
        {
                MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  val_26 + 32).alpha = 0f;
        }
        
        if((val_27 + 2135) == 0)
        {
                mem2[0] = 1;
        }
        
        if(17249.HasValidQueuedWindows() == true)
        {
            goto label_24;
        }
        
        val_29 = MonoSingleton<GameStoreUI>.Instance;
        if(val_29 != 0)
        {
            goto label_24;
        }
        
        val_29 = MonoSingleton<WADPetsWindowManager>.Instance;
        if(val_29 != 0)
        {
            goto label_24;
        }
        
        val_29 = MonoSingleton<CategoryPacksScreenMain>.Instance;
        if((val_29 != 0) || ((val_26 + 121) != 0))
        {
            goto label_24;
        }
        
        val_29 = MonoSingleton<WordForest.WFOMysteryChestDisplay>.Instance;
        if(val_29 == 0)
        {
            goto label_29;
        }
        
        label_24:
        if((val_26 + 120) == 0)
        {
                mem2[0] = 1;
            if((val_27 + 2135) == 0)
        {
                mem2[0] = 1;
        }
        
            val_29 = mem[val_28 + 184];
            val_29 = val_28 + 184;
        }
        
        if(val_29.useRevisedUX != false)
        {
                WGWindowManager val_14 = MonoSingleton<WGWindowManager>.Instance;
            val_30 = 1152921516506385280;
        }
        else
        {
                val_30 = 1152921516506390400;
        }
        
        val_26.ShowOrHideLightningEffects(show:  MonoSingleton<WGWindowManager>.Instance.GetWindow<WGLightningLevelsFTUXFlyout>().isActiveAndEnabled);
        return;
        label_29:
        if((val_26 + 120) != 0)
        {
                mem2[0] = 0;
            if((val_27 + 2135) == 0)
        {
                mem2[0] = 1;
        }
        
            val_26.ShowOrHideLightningEffects(show:  true);
        }
        
        val_26.UpdateWordRegionLightningEffects();
        val_26.UpdateTimertext();
    }
    protected void UpdateTimertext()
    {
        var val_7;
        if((LightningLevelsEventHandler.<Instance>k__BackingField.useRevisedUX) != true)
        {
                val_7 = null;
            val_7 = null;
            this.<lightningEventButton>k__BackingField.SetupCountdownText(text:  System.String.Format(format:  "{0:0}:{1:00}", arg0:  LightningLevelsEventHandler.<Instance>k__BackingField.Minutes, arg1:  LightningLevelsEventHandler.<Instance>k__BackingField.Seconds), size:  (App.game == 18) ? 0 : 50);
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField.TotalSeconds) > 0f)
        {
                return;
        }
        
        this.ResetAll();
    }
    private void ResetAll()
    {
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_2B0;
    }
    private void OnInAppPurchaseStarted()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if(((LightningLevelsEventHandler.<Instance>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField.InExpireInterval()) != false)
        {
                this.ResetAll();
            return;
        }
        
        this.isTimerPaused = true;
        this.isAppPaused = true;
    }
    private void ShowOrHideLightningEffects(bool show)
    {
        this.lightningEffectsParent.gameObject.SetActive(value:  show);
    }
    private void HideLightningEffects()
    {
        this.ShowOrHideLightningEffects(show:  false);
    }
    private void UpdateWordRegionLightningEffects()
    {
        UnityEngine.GameObject val_12;
        float val_13;
        float val_14;
        UnityEngine.Vector3[] val_1 = new UnityEngine.Vector3[4];
        UnityEngine.GameObject.FindGameObjectWithTag(tag:  "Area-WordRegion").GetComponent<UnityEngine.RectTransform>().GetWorldCorners(fourCornersArray:  val_1);
        int val_17 = val_1.Length;
        UnityEngine.Vector3 val_15 = val_1[0];
        val_15 = val_15 + val_1[2];
        val_17 = val_17 & 4294967295;
        var val_18 = 0;
        float val_4 = val_15 * 0.5f;
        do
        {
            float val_5 = null - val_4;
            val_5 = val_5 * 10f;
            float val_6 = null * 37f;
            val_5 = val_5 / 11f;
            val_6 = val_6 / 40f;
            val_5 = val_4 + val_5;
            UnityEngine.Vector3 val_7 = new UnityEngine.Vector3(x:  val_6, y:  val_5, z:  1.187865E-20f);
            val_18 = val_18 + 1;
            mem2[0] = val_7.x;
            mem2[0] = val_7.z;
        }
        while(val_18 < 3);
        
        float val_19 = 0f;
        label_26:
        val_19 = val_19 + 1;
        var val_9 = (val_19 == 3) ? 0 : (val_19);
        label_25:
        if(this.lightningEffectsParent.childCount > 19)
        {
                var val_11 = 0 + 0;
            if(val_9 <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_9 = val_9 + (val_11 << 3);
            val_12 = mem[(0 == 0x3 ? 0 : (0 + 1) + ((0 + 0)) << 3) + 32];
            val_12 = (0 == 0x3 ? 0 : (0 + 1) + ((0 + 0)) << 3) + 32;
        }
        else
        {
                val_12 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.lightningEffectsPrefab, parent:  this.lightningEffectsParent);
            this.lightningEffects.Add(item:  val_12);
        }
        
        if((val_19 & 4294967294) != 2)
        {
            goto label_17;
        }
        
        val_13 = (long)val_9;
        val_14 = val_19;
        if(val_19 < val_1.Length)
        {
            goto label_19;
        }
        
        label_17:
        val_13 = val_19;
        val_14 = val_19;
        label_19:
        val_14 = val_1[32] + (val_14 * 12);
        val_13 = val_1[32] + (val_13 * 12);
        val_12.GetComponent<LightningEffects>().Setup(start:  new UnityEngine.Vector3() {x = val_13, y = (val_13 * 12) + val_1[0x20] + 4, z = (val_13 * 12) + val_1[0x20] + 8}, end:  new UnityEngine.Vector3() {x = val_14, y = ((0 + 1) * 12) + val_1[0x20] + 4, z = ((0 + 1) * 12) + val_1[0x20] + 8});
        if(0 < 4)
        {
            goto label_25;
        }
        
        var val_20 = 0;
        val_20 = val_20 + (0 + 1);
        if(val_19 <= 2)
        {
            goto label_26;
        }
    
    }
    public LightningLevelsUIController()
    {
        this.lightningEffects = new System.Collections.Generic.List<UnityEngine.GameObject>();
    }

}
