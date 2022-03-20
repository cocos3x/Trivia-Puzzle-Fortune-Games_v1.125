using UnityEngine;
public class WGSpinKingSlotPopup : MonoSingleton<WGSpinKingSlotPopup>
{
    // Fields
    private UnityEngine.GameObject window;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private CurrencyCollectAnimationInstantiator gemAnimControl;
    private CurrencyCollectAnimationInstantiator goldCurrencyAnimControl;
    private WADPetFoodAnimationInstantiator foodAnimControl;
    private WADPetCardAnimationInstantiator petsCardAnimControl;
    private UnityEngine.Sprite big_coin_sprite;
    private UnityEngine.Sprite small_coin_sprite;
    private UnityEngine.Sprite apple_sprite;
    private UnityEngine.Sprite card_sprite;
    private UnityEngine.Sprite food_sprite;
    private UnityEngine.Sprite gem_sprite;
    private UnityEngine.UI.Text text_progress;
    private UnityEngine.UI.Image progressBar;
    private MultiGraphicButton spinBtn;
    private UnityEngine.UI.Button closeBtn;
    private UnityEngine.GameObject spin_result_go;
    private UnityEngine.UI.Text spin_result_text;
    private UnityEngine.UI.Image spin_result_icon;
    public SpinKingReelsController ReelController;
    public UnityEngine.GameObject popupInfoBtn;
    private UnityEngine.GameObject footerTimer;
    private UnityEngine.UI.Text time_left_text;
    private UnityEngine.GameObject no_spin_popup;
    private UnityEngine.GameObject no_spin_close_btn;
    private MultiGraphicButton no_spin_level_btn;
    private UnityEngine.UI.Text no_spin_level_txt;
    private MultiGraphicButton no_spin_continue_btn;
    private UnityEngine.GameObject ftux_go;
    private MultiGraphicButton ftux_spinBtn;
    private UnityEngine.UI.Text ftux_message_text;
    private SpinKingOutCome spinResult;
    private WADPets.WADPet petCard;
    private System.Collections.Generic.Dictionary<SpinKingSlotMachine.SpinKingSymbol, UnityEngine.Sprite> symbolSprites;
    private System.Collections.Generic.Dictionary<SpinKingSlotMachine.SpinType, System.Action<System.Collections.Generic.Dictionary<string, object>>> spinningStopActions;
    
    // Methods
    public override void InitMonoSingleton()
    {
        if(this.coinsAnimControl != 0)
        {
                if(this.coinsAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.gemAnimControl != 0)
        {
                if(this.gemAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.goldCurrencyAnimControl != 0)
        {
                if(this.goldCurrencyAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.foodAnimControl != 0)
        {
                if(this.foodAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.petsCardAnimControl != 0)
        {
                if(this.petsCardAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        this.symbolSprites.Add(key:  1, value:  this.big_coin_sprite);
        this.symbolSprites.Add(key:  2, value:  this.small_coin_sprite);
        this.symbolSprites.Add(key:  3, value:  this.apple_sprite);
        this.symbolSprites.Add(key:  4, value:  this.card_sprite);
        this.symbolSprites.Add(key:  5, value:  this.food_sprite);
        this.symbolSprites.Add(key:  6, value:  this.gem_sprite);
        this.spinningStopActions.Add(key:  1, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::BigCoinSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  2, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::BigCoinSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  3, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::BigCoinSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  4, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::SmallCoinSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  5, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::SmallCoinSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  6, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::SmallCoinSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  7, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::ApplesSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  8, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::CardsSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  9, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::FoodSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  10, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::GemsSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        this.spinningStopActions.Add(key:  0, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSpinKingSlotPopup::<InitMonoSingleton>b__35_0(System.Collections.Generic.Dictionary<string, object> additionalParams)));
        string val_24 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        this.no_spin_level_txt.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSpinKingSlotPopup::Spin()));
        this.no_spin_level_txt.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSpinKingSlotPopup::<InitMonoSingleton>b__35_1()));
        this.closeBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSpinKingSlotPopup::Close()));
        this.closeBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSpinKingSlotPopup::<InitMonoSingleton>b__35_2()));
        this.closeBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSpinKingSlotPopup::Close()));
        this.ReelController.OnSpinReelStop = new System.Action<System.Int32>(object:  this, method:  System.Void WGSpinKingSlotPopup::OnSpinReelStop(int reel));
        this.UpdateProgress(animate:  false);
        UnityEngine.Vector3 val_32 = UnityEngine.Vector3.zero;
        this.spin_result_go.transform.localScale = new UnityEngine.Vector3() {x = val_32.x, y = val_32.y, z = val_32.z};
    }
    private void Start()
    {
        this.Invoke(methodName:  "GetNewPet", time:  0.1f);
    }
    private void Update()
    {
        this.UpdateSlotEndTime();
    }
    public void SetPlayFromLevelComplete(bool level_complete)
    {
        UnityEngine.UI.Text val_12;
        bool val_13;
        val_12 = this;
        bool val_1 = level_complete ^ 1;
        val_13 = val_1;
        this.popupInfoBtn.SetActive(value:  val_13);
        this.footerTimer.SetActive(value:  val_13);
        this.no_spin_level_btn.gameObject.SetActive(value:  val_1);
        this.no_spin_continue_btn.gameObject.SetActive(value:  level_complete);
        this.no_spin_close_btn.SetActive(value:  val_1);
        this.ftux_go.SetActive(value:  false);
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.isBankedSpinsMax == false)
        {
                return;
        }
        
        if(level_complete == false)
        {
                return;
        }
        
        val_13 = "spinKing_popup_frux";
        if((UnityEngine.PlayerPrefs.GetInt(key:  "spinKing_popup_frux", defaultValue:  0)) != 0)
        {
                return;
        }
        
        this.ftux_go.SetActive(value:  true);
        val_12 = this.ftux_message_text;
        string val_10 = System.String.Format(format:  Localization.Localize(key:  "spin_king_ftux", defaultValue:  "YOU\'VE COLLECTED {0} SPINS! PRESS THE SPIN BUTTON TO WIN PRIZES!", useSingularKey:  false), arg0:  SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 48 + 20);
        UnityEngine.PlayerPrefs.SetInt(key:  "spinKing_popup_frux", value:  1);
    }
    public UnityEngine.Sprite GetSymbolSprite(SpinKingSlotMachine.SpinKingSymbol symbol)
    {
        return this.symbolSprites.Item[symbol];
    }
    private void Spin()
    {
        if((SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 56) <= 0)
        {
                if((SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 40) == 0)
        {
            goto label_4;
        }
        
        }
        
        SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.Spin();
        this.spinBtn.interactable = false;
        this.spinResult = SpinKingSlotMachine.CreateSpinOutCome();
        this.ReelController.StartSpin();
        this.UpdateProgress(animate:  true);
        return;
        label_4:
        this.window.SetActive(value:  false);
        this.no_spin_popup.SetActive(value:  true);
    }
    private void OnSpinReelStop(int reel)
    {
        SpinKingOutCome val_4;
        if(reel != 2)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "Spin Balance", value:  SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 56);
        val_4 = this.spinResult;
        if(this.spinResult.SType != 0)
        {
                WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
            val_2.sound.PlayGameSpecificSound(id:  "SpinKingWin", clipIndex:  0);
            val_4 = this.spinResult;
        }
        
        this.spinningStopActions.Item[this.spinResult.SType].Invoke(obj:  val_1);
    }
    private void BigCoinSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        decimal val_2 = System.Decimal.op_Implicit(value:  this.spinResult.Reward);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "Spin King", subSource:  0, externalParams:  additionalParams, doTrack:  true);
        this.ShowReward(icon:  this.big_coin_sprite, amount:  this.spinResult.Reward, onComplete:  new System.Action(object:  this, method:  System.Void WGSpinKingSlotPopup::<BigCoinSpinResultAction>b__42_0()));
    }
    private void SmallCoinSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        decimal val_2 = System.Decimal.op_Implicit(value:  this.spinResult.Reward);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "Spin King", subSource:  0, externalParams:  additionalParams, doTrack:  true);
        this.ShowReward(icon:  this.small_coin_sprite, amount:  this.spinResult.Reward, onComplete:  new System.Action(object:  this, method:  System.Void WGSpinKingSlotPopup::<SmallCoinSpinResultAction>b__43_0()));
    }
    private void ApplesSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        GoldenApplesManager val_1 = MonoSingleton<GoldenApplesManager>.Instance;
        this.ShowReward(icon:  this.apple_sprite, amount:  this.spinResult.Reward, onComplete:  new System.Action(object:  this, method:  System.Void WGSpinKingSlotPopup::<ApplesSpinResultAction>b__44_0()));
    }
    private void CardsSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        this.GetNewPet();
        MonoSingleton<WADPetsManager>.Instance.RewardPetCards(amount:  this.spinResult.Reward, pet:  this.petCard, source:  "Spin King", subsource:  0, additionalParam:  additionalParams);
        this.ShowReward(icon:  this.card_sprite, amount:  this.spinResult.Reward, onComplete:  new System.Action(object:  this, method:  System.Void WGSpinKingSlotPopup::<CardsSpinResultAction>b__45_0()));
    }
    private void FoodSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        App.Player.AddPetsFood(amount:  this.spinResult.Reward, source:  "Spin King", subSource:  0, FoodSpentParams:  0, additionalParam:  additionalParams);
        this.ShowReward(icon:  this.food_sprite, amount:  this.spinResult.Reward, onComplete:  new System.Action(object:  this, method:  System.Void WGSpinKingSlotPopup::<FoodSpinResultAction>b__46_0()));
    }
    private void GemsSpinResultAction(System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        App.Player.AddGems(amount:  this.spinResult.Reward, source:  "Spin King", subsource:  0);
        App.Player.TrackNonCoinReward(source:  "Spin King", subSource:  0, rewardType:  "Gems", rewardAmount:  this.spinResult.Reward.ToString(), additionalParams:  additionalParams);
        this.ShowReward(icon:  this.gem_sprite, amount:  this.spinResult.Reward, onComplete:  new System.Action(object:  this, method:  System.Void WGSpinKingSlotPopup::<GemsSpinResultAction>b__47_0()));
    }
    private void UpdateSlotEndTime()
    {
        int val_13;
        int val_14;
        int val_15;
        int val_16;
        System.TimeSpan val_1 = SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.GetRemainingTime();
        string[] val_2 = new string[9];
        val_13 = val_2.Length;
        val_2[0] = Localization.Localize(key:  "spin_king_ends", defaultValue:  "SPIN KING ENDS:", useSingularKey:  false);
        val_13 = val_2.Length;
        val_2[1] = " ";
        val_14 = val_2.Length;
        val_2[2] = val_1._ticks.Days.ToString(format:  "00");
        val_14 = val_2.Length;
        val_2[3] = ":";
        val_15 = val_2.Length;
        val_2[4] = val_1._ticks.Hours.ToString(format:  "00");
        val_15 = val_2.Length;
        val_2[5] = ":";
        val_16 = val_2.Length;
        val_2[6] = val_1._ticks.Minutes.ToString(format:  "00");
        val_16 = val_2.Length;
        val_2[7] = ":";
        val_2[8] = val_1._ticks.Seconds.ToString(format:  "00");
        string val_12 = +val_2;
    }
    private void GetNewPet()
    {
        this.petCard = MonoSingleton<WADPetsManager>.Instance.GetRandomPet();
        decimal val_4 = System.Decimal.op_Implicit(value:  this.petCard.Cards);
        X21.Setup(pet:  this.petCard, progressStartBalance:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, upgradeRequirement:  WADPetsManager.GetUpgradeRequirement(levelIndex:  val_2.LevelIndex));
    }
    private void UpdateProgress(bool animate)
    {
        WGSpinKingSlotPopup val_9;
        UnityEngine.UI.Text val_10;
        val_9 = this;
        val_10 = this.text_progress;
        string val_1 = System.String.Format(format:  "{0}/{1}", arg0:  SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 56, arg1:  SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 48 + 20);
        float val_2 = ((float)SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 56) / ((float)SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 48 + 20);
        if(animate != false)
        {
                WGSpinKingSlotPopup.<>c__DisplayClass50_0 val_3 = new WGSpinKingSlotPopup.<>c__DisplayClass50_0();
            .<>4__this = val_9;
            .progress = this.progressBar.m_FillAmount;
            val_9 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_3, method:  System.Void WGSpinKingSlotPopup.<>c__DisplayClass50_0::<UpdateProgress>b__0(float x)), startValue:  this.progressBar.m_FillAmount, endValue:  val_2, duration:  0.3f), ease:  1);
            DG.Tweening.TweenCallback val_7 = 1152921504797261824;
            val_10 = val_7;
            val_7 = new DG.Tweening.TweenCallback(object:  val_3, method:  System.Void WGSpinKingSlotPopup.<>c__DisplayClass50_0::<UpdateProgress>b__1());
            DG.Tweening.Tweener val_8 = DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  val_9, action:  val_10);
            return;
        }
        
        this.progressBar.fillAmount = val_2;
    }
    private void ShowReward(UnityEngine.Sprite icon, int amount, System.Action onComplete)
    {
        WGSpinKingSlotPopup.<>c__DisplayClass51_0 val_1 = new WGSpinKingSlotPopup.<>c__DisplayClass51_0();
        .onComplete = onComplete;
        .<>4__this = this;
        this.spin_result_icon.sprite = icon;
        string val_2 = amount.ToString();
        DG.Tweening.Sequence val_3 = DG.Tweening.DOTween.Sequence();
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
        DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_3, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.spin_result_go.transform, endValue:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, duration:  0.2f), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WGSpinKingSlotPopup.<>c__DisplayClass51_0::<ShowReward>b__0())));
        DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_3, interval:  1f);
        DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_3, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WGSpinKingSlotPopup.<>c__DisplayClass51_0::<ShowReward>b__1()));
        DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_3, interval:  0.5f);
        UnityEngine.Vector3 val_15 = UnityEngine.Vector3.zero;
        DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_3, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.spin_result_go.transform, endValue:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z}, duration:  0.3f));
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_3, interval:  0.5f);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        goto typeof(System.String).__il2cppRuntimeField_540;
    }
    public WGSpinKingSlotPopup()
    {
        this.symbolSprites = new System.Collections.Generic.Dictionary<SpinKingSymbol, UnityEngine.Sprite>();
        this.spinningStopActions = new System.Collections.Generic.Dictionary<SpinType, System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>>();
    }
    private void <InitMonoSingleton>b__35_0(System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        if(this.spinBtn != null)
        {
                this.spinBtn.interactable = true;
            return;
        }
        
        throw new NullReferenceException();
    }
    private void <InitMonoSingleton>b__35_1()
    {
        this.Spin();
        this.ftux_go.SetActive(value:  false);
    }
    private void <InitMonoSingleton>b__35_2()
    {
        GameBehavior val_1 = App.getBehavior;
        UnityEngine.SceneManagement.Scene val_2 = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        string val_3 = val_2.m_Handle.name;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        }
        
            GameBehavior val_7 = App.getBehavior;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void <BigCoinSpinResultAction>b__42_0()
    {
        if(this.coinsAnimControl == 0)
        {
                return;
        }
        
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Implicit(value:  this.spinResult.Reward);
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = -754531248, mid = 268435458}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        Player val_5 = App.Player;
        this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void <SmallCoinSpinResultAction>b__43_0()
    {
        if(this.coinsAnimControl == 0)
        {
                return;
        }
        
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Implicit(value:  this.spinResult.Reward);
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = -754378288, mid = 268435458}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        Player val_5 = App.Player;
        this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void <ApplesSpinResultAction>b__44_0()
    {
        if(this.goldCurrencyAnimControl == 0)
        {
                return;
        }
        
        Player val_2 = App.Player;
        Player val_3 = App.Player;
        decimal val_4 = System.Decimal.op_Implicit(value:  val_3._stars);
        this.goldCurrencyAnimControl.Play(fromValue:  val_2._stars - this.spinResult.Reward, toValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void <CardsSpinResultAction>b__45_0()
    {
        var val_6;
        .<>4__this = this;
        .upgradeRequirement = WADPetsManager.GetUpgradeRequirement(levelIndex:  this.petCard.LevelIndex);
        float val_6 = (float)this.petCard.Cards;
        val_6 = val_6 / (float)val_2.Cards;
        .endProgressValue = UnityEngine.Mathf.Min(a:  val_6, b:  1f);
        val_6 = null;
        val_6 = null;
        this.petsCardAnimControl.Play(fromValue:  0, toValue:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        DG.Tweening.Tween val_5 = DG.Tweening.DOVirtual.DelayedCall(delay:  1f, callback:  new DG.Tweening.TweenCallback(object:  new WGSpinKingSlotPopup.<>c__DisplayClass45_0(), method:  System.Void WGSpinKingSlotPopup.<>c__DisplayClass45_0::<CardsSpinResultAction>b__1()), ignoreTimeScale:  true);
    }
    private void <FoodSpinResultAction>b__46_0()
    {
        if(this.foodAnimControl == 0)
        {
                return;
        }
        
        Player val_2 = App.Player;
        Player val_3 = App.Player;
        decimal val_4 = System.Decimal.op_Implicit(value:  val_3._food);
        this.foodAnimControl.Play(fromValue:  val_2._food - this.spinResult.Reward, toValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void <GemsSpinResultAction>b__47_0()
    {
        if(this.gemAnimControl == 0)
        {
                return;
        }
        
        Player val_2 = App.Player;
        Player val_3 = App.Player;
        decimal val_4 = System.Decimal.op_Implicit(value:  val_3._gems);
        this.gemAnimControl.Play(fromValue:  val_2._gems - this.spinResult.Reward, toValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }

}
