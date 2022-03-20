using UnityEngine;
public class ForestFrenzyUI : MonoSingleton<ForestFrenzyUI>
{
    // Fields
    private UnityEngine.CanvasGroup titleGroup;
    private UnityEngine.CanvasGroup growGroup;
    private UnityEngine.CanvasGroup playGroup;
    private UnityEngine.CanvasGroup congratulationsGroup;
    private UnityEngine.CanvasGroup continueGroup;
    private UnityEngine.UI.Image darkOverlay;
    private UnityEngine.UI.Image bottomBackground;
    private UnityEngine.ParticleSystem congratParticleLeft;
    private UnityEngine.ParticleSystem congratParticleRight;
    private UnityEngine.Transform forestContentParent;
    private UnityEngine.UI.Text forestNameText;
    private UnityEngine.UI.Text growthProgressText;
    private UnityEngine.UI.Slider growthProgress;
    private UnityEngine.UI.Text growthCostText;
    private UnityEngine.UI.Text playLevelText;
    private UnityEngine.UI.Button homeButton;
    private UnityEngine.UI.Button forestInfoButton;
    private UnityEngine.UI.Button growButton;
    private UnityEngine.UI.Text growButtonText;
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Button continueButton;
    private WordForest.WFOForestContent forestContent;
    private UnityEngine.GameObject FTUXTooltip_1;
    private UnityEngine.GameObject FTUXPointer;
    private UnityEngine.UI.Image growButtonGlow;
    private UnityEngine.UI.Button tooltipContinueButton;
    private UnityEngine.UI.Image continueButtonGlow;
    private UnityEngine.Transform continueButtonPointerScaler;
    private WordForest.WFOSeedParticles seedParticlesPrefab;
    private UnityEngine.UI.Text currencyAmountText;
    private UnityEngine.UI.Button button_back_home;
    private UnityEngine.CanvasGroup eventCountdownGroup;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.UI.Text tutorialText;
    private ForestFrenzyManager forestManager;
    private int _tutorialCompleted;
    
    // Properties
    private int tutorialCompleted { get; set; }
    
    // Methods
    private int get_tutorialCompleted()
    {
        int val_2 = this._tutorialCompleted;
        if(val_2 != 1)
        {
                return val_1;
        }
        
        val_2 = "ffet";
        int val_1 = UnityEngine.PlayerPrefs.GetInt(key:  val_2, defaultValue:  0);
        this._tutorialCompleted = val_1;
        return val_1;
    }
    private void set_tutorialCompleted(int value)
    {
        this._tutorialCompleted = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "ffet", value:  value);
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void OnFrameSkipperUpdate()
    {
        this.SetTimerText(timeEnd:  new System.DateTime() {dateData = ForestFrenzyEventHandler.<Instance>k__BackingField});
    }
    private void Start()
    {
        var val_29;
        var val_30;
        this.forestManager = MonoSingleton<ForestFrenzyManager>.Instance;
        this.forestInfoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestFrenzyUI::OnForestInfoButtonClicked()));
        this.growButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestFrenzyUI::OnGrowButtonClicked()));
        this.tooltipContinueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestFrenzyUI::OnTooltipContinueButtonClicked()));
        this.button_back_home.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestFrenzyUI::OnAndroidBackButtonClicked()));
        this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestFrenzyUI::OnPlayButtonClicked()));
        string val_10 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player.ToString());
        val_29 = null;
        val_29 = null;
        string val_11 = ForestFrenzyEventProgress.accumulatedCurrency.ToString();
        this.InitialiseForestLayout();
        this.InitializeUI();
        this.UpdateForestInfo(animated:  false, skipButtonStates:  false);
        if((MonoExtensions.IsBitSet(value:  this.tutorialCompleted, bit:  2)) != false)
        {
                if((MonoExtensions.IsBitSet(value:  this.tutorialCompleted, bit:  3)) == true)
        {
            goto label_28;
        }
        
        }
        
        val_30 = null;
        val_30 = null;
        if((ForestFrenzyEventProgress.forestMapData.CurrentForestGrowth(includeDamagedTrees:  true)) >= 1)
        {
                this.tutorialCompleted = MonoExtensions.SetBit(value:  this.tutorialCompleted, bit:  5);
            this.tutorialCompleted = MonoExtensions.SetBit(value:  this.tutorialCompleted, bit:  2);
            this.tutorialCompleted = MonoExtensions.SetBit(value:  this.tutorialCompleted, bit:  3);
        }
        
        label_28:
        if((MonoExtensions.IsBitSet(value:  this.tutorialCompleted, bit:  2)) != true)
        {
                this.StartFTUX_1();
        }
        
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void ForestFrenzyUI::OnAndroidBackButtonClicked()));
        FrameSkipper val_27 = this.gameObject.AddComponent<FrameSkipper>();
        val_27.updateLogic = new System.Action(object:  this, method:  System.Void ForestFrenzyUI::OnFrameSkipperUpdate());
    }
    private void OnDisable()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void ForestFrenzyUI::OnAndroidBackButtonClicked()));
    }
    private DG.Tweening.Sequence DoCompleteForestSequence()
    {
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.titleGroup, endValue:  0f, duration:  0.5f));
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.darkOverlay, endValue:  1f, duration:  0.5f));
        DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.growGroup, endValue:  0f, duration:  0.5f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void ForestFrenzyUI::<DoCompleteForestSequence>b__42_0())));
        DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.playGroup, endValue:  1f, duration:  0.5f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void ForestFrenzyUI::<DoCompleteForestSequence>b__42_1())));
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.eventCountdownGroup, endValue:  0f, duration:  0.5f));
        DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.congratulationsGroup, endValue:  1f, duration:  0.5f));
        DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void ForestFrenzyUI::<DoCompleteForestSequence>b__42_2()));
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void ForestFrenzyUI::<DoCompleteForestSequence>b__42_3()));
        DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void ForestFrenzyUI::<DoCompleteForestSequence>b__42_4()));
        return val_1;
    }
    private void StartFTUX_1()
    {
        this.FTUXTooltip_1.SetActive(value:  true);
        this.FTUXPointer.SetActive(value:  true);
        this.growButtonGlow.gameObject.SetActive(value:  true);
        string val_4 = System.String.Format(format:  Localization.Localize(key:  "forest_frenzy_ftux", defaultValue:  "Welcome to {0}!\nHit the GROW Button to a plant a tree!", useSingularKey:  false), arg0:  this.forestManager.CurrentForestName);
        this.StartGrowButtonPointerAnim();
    }
    private void EndFTUX_1()
    {
        this.FTUXTooltip_1.SetActive(value:  false);
        this.FTUXPointer.SetActive(value:  false);
        this.growButtonGlow.gameObject.SetActive(value:  false);
        this.tutorialCompleted = MonoExtensions.SetBit(value:  this.tutorialCompleted, bit:  2);
    }
    private void InitializeUI()
    {
        var val_3;
        int val_1 = this.CurrentForestGrowth;
        WordForest.WFOForestData val_2 = this.forestManager.CurrentForestData;
        if(val_1 >= val_3)
        {
                bool val_4 = this.forestManager.IsAtLastForest;
        }
        
        float val_5 = (val_1 >= val_3) ? 1f : 0f;
        float val_6 = (val_1 >= val_3) ? 0f : 1f;
        this.congratulationsGroup.alpha = val_5;
        PluginExtension.SetColorAlpha(graphic:  this.darkOverlay, a:  val_5);
        this.titleGroup.alpha = val_6;
        this.growGroup.alpha = val_6;
        this.growGroup.blocksRaycasts = (val_1 < val_3) ? 1 : 0;
        PluginExtension.SetColorAlpha(graphic:  this.bottomBackground, a:  val_6);
        this.playButton.gameObject.SetActive(value:  true);
        this.playGroup.alpha = 1f;
        this.playGroup.blocksRaycasts = true;
        this.eventCountdownGroup.gameObject.SetActive(value:  true);
    }
    private void InitialiseForestLayout()
    {
        int val_4;
        if(this.forestContent != 0)
        {
                UnityEngine.Object.Destroy(obj:  this.forestContent.gameObject);
            this.forestContent = 0;
        }
        
        WordForest.WFOForestData val_3 = this.forestManager.CurrentForestData;
        WordForest.WFOForestContent val_6 = UnityEngine.Object.Instantiate<WordForest.WFOForestContent>(original:  this.forestManager.GetForestLayout(forestId:  val_4), parent:  this.forestContentParent);
        this.forestContent = val_6;
        val_6.Initialize(forestMap:  ForestFrenzyEventProgress.forestMapData);
    }
    private void UpdateForestInfo(bool animated = False, bool skipButtonStates = False)
    {
        object val_3;
        var val_15 = null;
        int val_1 = null.CurrentForestGrowth;
        WordForest.WFOForestData val_2 = this.forestManager.CurrentForestData;
        bool val_4 = this.forestManager.CurrentForestContainsDamagedTrees;
        WordForest.WFOForestData val_6 = this.forestManager.CurrentForestData;
        this.growButton.interactable = (val_4.CurrentForestGrowth < val_3) ? 1 : 0;
        string val_8 = this.forestManager.CurrentForestName;
        string val_10 = System.String.Format(format:  "{0} {1}/{2}", arg0:  Localization.Localize(key:  "build_upper", defaultValue:  "BUILD", useSingularKey:  false), arg1:  val_1, arg2:  val_3);
        string val_12 = this.growthProgressText.CurrentGrowthCost.ToString();
        if(val_4 != false)
        {
                if(this.growButtonText != null)
        {
            goto label_14;
        }
        
        }
        
        string val_13 = Localization.Localize(key:  "grow_upper", defaultValue:  "GROW", useSingularKey:  false);
        label_14:
        if(animated != false)
        {
                float val_15 = (float)val_1;
            val_15 = val_15 / (float)val_3;
            DG.Tweening.Tweener val_14 = DG.Tweening.ShortcutExtensions46.DOValue(target:  this.growthProgress, endValue:  val_15, duration:  0.3f, snapping:  false);
            return;
        }
        
        float val_16 = (float)val_1;
        val_16 = val_16 / (float)val_3;
    }
    private void PlayPlantingAnimation(UnityEngine.Transform treeTransform)
    {
        UnityEngine.Vector3 val_3 = treeTransform.position;
        UnityEngine.Object.Instantiate<WordForest.WFOSeedParticles>(original:  this.seedParticlesPrefab, parent:  this.growButton.transform).PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, particleCount:  3);
    }
    private void OnForestInfoButtonClicked()
    {
        ForestFrenzyWindowManager val_2 = MonoSingleton<ForestFrenzyWindowManager>.Instance.ShowUGUIMonolith<ForestFrenzyInfoPopup>(showNext:  false);
    }
    private void OnGrowButtonClicked()
    {
        var val_6;
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        val_16 = null;
        val_16 = null;
        int val_1 = CurrentGrowthCost;
        if(ForestFrenzyEventProgress.accumulatedCurrency < val_1)
        {
                ForestFrenzyWindowManager val_3 = MonoSingleton<ForestFrenzyWindowManager>.Instance.ShowUGUIMonolith<ForestFrenzyOutOfShovelsPopup>(showNext:  false);
            return;
        }
        
        val_17 = val_1.CurrentForestGrowth;
        WordForest.WFOForestData val_5 = this.forestManager.CurrentForestData;
        if(val_17 < val_6)
        {
                this.forestManager.AddGrowth(damagedTreeIdToFix:  0, onServerResponse:  0);
            val_18 = null;
            val_18 = null;
            string val_7 = ForestFrenzyEventProgress.accumulatedCurrency.ToString();
            bool val_9 = MonoExtensions.IsBitSet(value:  this.tutorialCompleted, bit:  2);
            System.Collections.Generic.List<UnityEngine.Transform> val_10 = this.forestContent.AddGrowth(addGrowth:  1);
            if(null >= 1)
        {
                var val_16 = 0;
            do
        {
            if(val_16 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_19 = this;
            this.PlayPlantingAnimation(treeTransform:  UnityEngine.UI.Text.__il2cppRuntimeField_byval_arg);
            val_16 = val_16 + 1;
        }
        while(val_16 < null);
        
        }
        
            val_17 = this.CurrentForestGrowth;
            WordForest.WFOForestData val_12 = this.forestManager.CurrentForestData;
            if(val_17 >= val_6)
        {
                this.forestContent.AddAnimationSequence(nextSequence:  this.DoCompleteForestSequence());
        }
        
            this.UpdateForestInfo(animated:  true, skipButtonStates:  false);
            if((MonoExtensions.IsBitSet(value:  this.tutorialCompleted, bit:  2)) == true)
        {
                return;
        }
        
            this.EndFTUX_1();
            return;
        }
        
        this.growButton.interactable = false;
    }
    private void RewardForestComplete()
    {
        MonoSingleton<ForestFrenzyManager>.Instance.RewardForestComplete();
    }
    private void OnAndroidBackButtonClicked()
    {
        MonoSingleton<ForestFrenzyManager>.Instance.CloseForestScene(playClicked:  false);
    }
    private void StartGrowButtonPointerAnim()
    {
        int val_1 = DG.Tweening.ShortcutExtensions.DOKill(target:  this.growButtonGlow, complete:  false);
        PluginExtension.SetColorAlpha(graphic:  this.growButtonGlow, a:  0.4f);
        DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.growButtonGlow, endValue:  0.8f, duration:  0.65f), ease:  7));
        DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.growButtonGlow, endValue:  0.4f, duration:  0.65f), ease:  7));
        DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_2, loops:  0, loopType:  0);
        int val_11 = DG.Tweening.ShortcutExtensions.DOKill(target:  this.FTUXPointer.transform, complete:  false);
        DG.Tweening.Sequence val_12 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_12, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.FTUXPointer.transform, endValue:  0.8f, duration:  0.5f), ease:  5));
        DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_12, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.FTUXPointer.transform, endValue:  1f, duration:  0.5f), ease:  5));
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_12, interval:  1f);
        DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_12, loops:  0, loopType:  0);
    }
    private void OnTooltipContinueButtonClicked()
    {
        UnityEngine.Debug.LogError(message:  "OnTooltipContinueButtonClicked");
    }
    private void OnPlayButtonClicked()
    {
        MonoSingleton<ForestFrenzyManager>.Instance.OnPlayLevelButtonClicked();
    }
    private void SetTimerText(System.DateTime timeEnd)
    {
        UnityEngine.UI.Text val_15;
        object val_16;
        var val_17;
        var val_18;
        var val_19;
        val_15 = this;
        val_16 = 1152921504616751104;
        val_17 = null;
        val_17 = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = timeEnd.dateData}, d2:  new System.DateTime() {dateData = System.DateTime.MaxValue})) != false)
        {
                return;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = timeEnd.dateData.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
        val_18 = null;
        val_18 = null;
        if((System.TimeSpan.Compare(t1:  new System.TimeSpan() {_ticks = val_3._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) == 1)
        {
                val_19 = null;
            val_19 = null;
        }
        
        val_15 = this.timerText;
        object[] val_5 = new object[4];
        val_5[0] = System.TimeSpan.Zero.Days.ToString(format:  "00");
        val_5[1] = System.TimeSpan.Zero.Hours.ToString(format:  "00");
        val_5[2] = System.TimeSpan.Zero.Minutes.ToString(format:  "00");
        val_16 = System.TimeSpan.Zero.Seconds.ToString(format:  "00");
        val_5[3] = val_16;
        string val_14 = System.String.Format(format:  "{0}:{1}:{2}:{3}", args:  val_5);
    }
    public ForestFrenzyUI()
    {
        this._tutorialCompleted = 0;
    }
    private void <DoCompleteForestSequence>b__42_0()
    {
        if(this.growGroup != null)
        {
                this.growGroup.blocksRaycasts = false;
            return;
        }
        
        throw new NullReferenceException();
    }
    private void <DoCompleteForestSequence>b__42_1()
    {
        if(this.playGroup != null)
        {
                this.playGroup.blocksRaycasts = true;
            return;
        }
        
        throw new NullReferenceException();
    }
    private void <DoCompleteForestSequence>b__42_2()
    {
        if(this.congratParticleLeft != null)
        {
                this.congratParticleLeft.Play();
            return;
        }
        
        throw new NullReferenceException();
    }
    private void <DoCompleteForestSequence>b__42_3()
    {
        if(this.congratParticleRight != null)
        {
                this.congratParticleRight.Play();
            return;
        }
        
        throw new NullReferenceException();
    }
    private void <DoCompleteForestSequence>b__42_4()
    {
        this.RewardForestComplete();
    }

}
