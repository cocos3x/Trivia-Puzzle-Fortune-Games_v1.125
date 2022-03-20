using UnityEngine;
public class WGDailyChallengeLevelComplete : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject graphic_sun;
    private UnityEngine.GameObject graphic_moon;
    private UnityEngine.GameObject lessStarsGroup;
    private UnityEngine.UI.Text description;
    private UnityEngine.GameObject starPrefab;
    private UnityEngine.RectTransform progressParent;
    private UnityEngine.RectTransform progress;
    private DailyChallengeStarGroup starGroup;
    private UnityEngine.UI.Button button_continue_less_stars;
    private UnityEngine.UI.Button button_retry_less_stars;
    private UnityEngine.UI.Text retryUnlockAmount;
    private UnityEngine.GameObject fullStarsGroup;
    private UnityEngine.UI.Text coinReward;
    private UnityEngine.UI.Text appleReward;
    private UnityEngine.UI.Button button_continue_completed;
    private UnityEngine.GameObject regularReward;
    private UnityEngine.GameObject goldenGalaReward;
    private UnityEngine.GameObject[] starsImages;
    private UnityEngine.GameObject goldenGalaOverlay;
    private UnityEngine.UI.Text regularCoinReward;
    private UnityEngine.UI.Text regularAppleReward;
    private UnityEngine.UI.Text galaCoinReward;
    private UnityEngine.UI.Text galaAppleReward;
    private UnityEngine.Transform rewardSource;
    private UnityEngine.Transform middleSource;
    private UnityEngine.Transform leftSource;
    private UnityEngine.Transform rightSource;
    private UnityEngine.UI.Button button_gala_rewards;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private GoldenCurrencyCollectAnimationInstantiator goldenCurrencyAnimControl;
    private GoldenCurrencyCollectAnimationInstantiator goldenCurrencyAnimControl_mult;
    private UnityEngine.GameObject goldenMultiplierGroup;
    private UnityEngine.UI.Text goldenMultiplierBonusApples;
    private UnityEngine.GameObject[] dcStars;
    private DailyChallengeProgressUI weeklyProgressUI;
    private DailyChallengeProgressUI monthlyProgressUI;
    private UnityEngine.ParticleSystem weekStarParticles;
    private UnityEngine.ParticleSystem monthStarParticles;
    private float starPunchDuration;
    private const string COMPLETE_TEXT_MORNING = "Collect more Suns to earn 3 Stars!";
    private const string COMPLETE_TEXT_EVENING = "Collect more Moons to earn 3 Stars!";
    private const string FREE_COINS_SOURCE = "Daily Challenge";
    private int goldenApplesReward;
    private decimal galaCoinAmount;
    private int galaAppleAmount;
    private decimal retryCost;
    private bool dcRevamp;
    
    // Methods
    private void Awake()
    {
        this.button_retry_less_stars.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyChallengeLevelComplete::OnRetryButtonClicked()));
        this.button_continue_less_stars.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyChallengeLevelComplete::GrantCompleteReward()));
        this.button_continue_completed.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyChallengeLevelComplete::GrantCompleteReward()));
        this.button_gala_rewards.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyChallengeLevelComplete::OnGalaRewardsClicked()));
        this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGDailyChallengeLevelComplete::OnCoinsAnimFinished());
        WGSubscriptionManager val_6 = MonoSingleton<WGSubscriptionManager>.Instance;
        System.Delegate val_8 = System.Delegate.Combine(a:  val_6.purchaseResult, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyChallengeLevelComplete::OnSubscriptionPurchaseAttempt(bool success)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        val_6.purchaseResult = val_8;
        return;
        label_14:
    }
    private void OnEnable()
    {
        this.UpdateUIForDay();
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.sound.PlayGeneralSound(type:  0, oneshot:  true, pitch:  1f, vol:  1f);
        this.button_continue_completed.interactable = false;
        this.button_continue_less_stars.interactable = false;
        this.button_retry_less_stars.interactable = false;
        this.button_gala_rewards.interactable = false;
    }
    private System.Collections.IEnumerator Start()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGDailyChallengeLevelComplete.<Start>d__49();
    }
    private System.Collections.IEnumerator PlayNewStarAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGDailyChallengeLevelComplete.<PlayNewStarAnimation>d__50();
    }
    private void UpdateUIForDay()
    {
        var val_38;
        var val_39;
        int val_40;
        UnityEngine.Transform val_41;
        val_38 = 1152921504893161472;
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        this.graphic_sun.SetActive(value:  ((val_1.<Status>k__BackingField.playingDayMorning) == true) ? 1 : 0);
        this.graphic_moon.SetActive(value:  ((val_1.<Status>k__BackingField.playingDayMorning) == false) ? 1 : 0);
        this.lessStarsGroup.SetActive(value:  false);
        this.fullStarsGroup.SetActive(value:  false);
        this.button_retry_less_stars.interactable = MonoSingleton<WGDailyChallengeManager>.Instance.IsPlayingValid();
        this.goldenApplesReward = MonoSingleton<WGDailyChallengeManager>.Instance.GetGoldenAppleReward();
        decimal val_10 = MonoSingleton<WGDailyChallengeManager>.Instance.GetRetryCost();
        mem2[0] = val_10.flags;
        mem[4] = val_10.hi;
        mem[1152921517775240940] = val_10.lo;
        mem[1152921517775240944] = val_10.mid;
        if(GoldenGalaHandler.dailyChallengeApple != null)
        {
                val_39 = (~GoldenGalaHandler.dailyChallengeApple) & 1;
        }
        else
        {
                val_39 = 0;
        }
        
        WGDailyChallengeManager val_11 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_40 = this.goldenApplesReward;
        if((val_39 == 0) && (41963520 <= 2))
        {
                string val_14 = Localization.Localize(key:  ((val_1.<Status>k__BackingField.playingDayMorning) == true) ? "daily_challenge_morning_description" : "daily_challenge_evening_description", defaultValue:  ((val_1.<Status>k__BackingField.playingDayMorning) == true) ? "Collect more Suns to earn 3 Stars!" : "Collect more Moons to earn 3 Stars!", useSingularKey:  false);
            string val_15 = this.retryCost.ToString();
            UnityEngine.Rect val_16 = this.progressParent.rect;
            float val_17 = val_16.m_XMin.width;
            var val_38 = 0;
            do
        {
            UnityEngine.Transform val_19 = this.progressParent.transform;
            UnityEngine.Vector3 val_20 = val_19.GetStarPosition(index:  val_38 + 1, parent:  val_19, parentLength:  val_17);
            UnityEngine.Quaternion val_21 = UnityEngine.Quaternion.identity;
            val_41 = this.starGroup.transform;
            UnityEngine.GameObject val_23 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.starPrefab, position:  new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z}, rotation:  new UnityEngine.Quaternion() {x = val_21.x, y = val_21.y, z = val_21.z, w = val_21.w}, parent:  val_41);
            val_38 = val_38 + 1;
        }
        while(val_38 < 2);
        
            this.starGroup.Setup(stars:  41963520);
            val_38 = 1152921504893161472;
            WGDailyChallengeManager val_25 = MonoSingleton<WGDailyChallengeManager>.Instance;
            float val_39 = val_25.<Status>k__BackingField.lastPlayedLevel.progress;
            val_39 = val_17 * val_39;
            UnityEngine.Vector2 val_26 = new UnityEngine.Vector2(x:  val_39, y:  -30f);
            this.progress.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_26.x, y = val_26.y};
            this.lessStarsGroup.SetActive(value:  true);
        }
        else
        {
                WGDailyChallengeManager val_27 = MonoSingleton<WGDailyChallengeManager>.Instance;
            string val_28 = val_27.<Econ>k__BackingField.ChallengeDefinition.CoinReward.ToString();
            val_41 = this.appleReward;
            string val_29 = val_40.ToString();
            this.fullStarsGroup.SetActive(value:  true);
            this.regularReward.SetActive(value:  (val_39 == 0) ? 1 : 0);
            this.goldenGalaReward.SetActive(value:  false);
            if(val_39 != 0)
        {
                this.SetupGalaRewards();
        }
        
        }
        
        if(this.dcRevamp == false)
        {
            goto label_65;
        }
        
        WGDailyChallengeManager val_31 = MonoSingleton<WGDailyChallengeManager>.Instance;
        string val_32 = val_31.<Econ>k__BackingField.ChallengeDefinition.CoinReward.ToString();
        string val_33 = val_40.ToString();
        val_40 = 0;
        label_68:
        if(val_40 >= this.dcStars.Length)
        {
            goto label_65;
        }
        
        this.dcStars[val_40].SetActive(value:  (val_40 < 41963520) ? 1 : 0);
        val_40 = val_40 + 1;
        if(this.dcStars != null)
        {
            goto label_68;
        }
        
        throw new NullReferenceException();
        label_65:
        DG.Tweening.Tween val_36 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.05f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGDailyChallengeLevelComplete::<UpdateUIForDay>b__51_0()), ignoreTimeScale:  true);
        if(GoldenMultiplierManager.IsAvaialable == false)
        {
                return;
        }
        
        this.SetupGoldenMultiplierUI();
    }
    private void SetupGalaRewards()
    {
        var val_12;
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        var val_13 = 0;
        label_10:
        if(val_13 >= this.starsImages.Length)
        {
            goto label_7;
        }
        
        this.starsImages[val_13].SetActive(value:  (val_13 < W22) ? 1 : 0);
        val_13 = val_13 + 1;
        if(this.starsImages != null)
        {
            goto label_10;
        }
        
        throw new NullReferenceException();
        label_7:
        WGDailyChallengeManager val_3 = MonoSingleton<WGDailyChallengeManager>.Instance;
        string val_4 = val_3.<Econ>k__BackingField.ChallengeDefinition.CoinReward.ToString();
        string val_5 = this.goldenApplesReward.ToString();
        if((GoldenGalaHandler.dailyChallengeApple + 64 + 24) > W22)
        {
                val_12 = 0;
        }
        else
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_6 = (static_value_02805631 == false) ? 1 : 0;
        }
        
        var val_14 = GoldenGalaHandler.dailyChallengeApple + 64 + 16;
        val_14 = val_14 + ((X22) << 4);
        this.galaCoinAmount = (GoldenGalaHandler.dailyChallengeApple + 64 + 16 + (X22) << 4) + 32;
        if((GoldenGalaHandler.dailyChallengeApple + 72 + 24) <= W22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_15 = GoldenGalaHandler.dailyChallengeApple + 72 + 16;
        val_15 = val_15 + ((X22) << 2);
        this.galaAppleAmount = (GoldenGalaHandler.dailyChallengeApple + 72 + 16 + (X22) << 2) + 32;
        string val_7 = this.galaCoinAmount.ToString();
        string val_8 = this.galaAppleAmount.ToString();
        this.goldenGalaOverlay.SetActive(value:  (~GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive) & 1);
        UnityEngine.Vector3 val_11 = this.leftSource.position;
        this.rewardSource.position = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
        this.coinsAnim.coinExpansionEnabled = false;
    }
    private void OnSubscriptionPurchaseAttempt(bool success)
    {
        this.goldenGalaOverlay.SetActive(value:  (~GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive) & 1);
    }
    private UnityEngine.Vector3 GetStarPosition(int index, UnityEngine.Transform parent, float parentLength)
    {
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        DailyChallengeDefinition val_6 = val_1.<Econ>k__BackingField.ChallengeDefinition;
        if(val_6 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (index << 3);
        float val_8 = 100f;
        float val_7 = 1.152922E+18f;
        val_7 = val_7 * parentLength;
        val_8 = val_7 / val_8;
        val_8 = val_8 + (parentLength * (-0.5f));
        UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  val_8, y:  -52f, z:  0f);
        UnityEngine.Vector3 val_5 = parent.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
        return new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnDisable()
    {
        if((MonoSingleton<WGSubscriptionManager>.Instance) == 0)
        {
                return;
        }
        
        WGSubscriptionManager val_3 = MonoSingleton<WGSubscriptionManager>.Instance;
        1152921504893161472 = val_3.purchaseResult;
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyChallengeLevelComplete::OnSubscriptionPurchaseAttempt(bool success)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_3.purchaseResult = val_5;
        return;
        label_10:
    }
    private void OnRetryButtonClicked()
    {
        int val_21;
        var val_22;
        var val_23;
        System.Action val_25;
        var val_26;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        Player val_2 = App.Player;
        val_21 = mem[this.retryCost];
        val_21 = this.retryCost.flags;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = 41963520}, d2:  new System.Decimal() {flags = val_21, hi = val_21, lo = this.retryCost.lo, mid = this.retryCost.lo})) != false)
        {
                val_22 = null;
            val_22 = null;
            PurchaseProxy.currentPurchasePoint = 26;
            val_23 = null;
            val_23 = null;
            val_25 = WGDailyChallengeLevelComplete.<>c.<>9__57_0;
            if(val_25 == null)
        {
                System.Action val_6 = null;
            val_25 = val_6;
            val_6 = new System.Action(object:  WGDailyChallengeLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGDailyChallengeLevelComplete.<>c::<OnRetryButtonClicked>b__57_0());
            WGDailyChallengeLevelComplete.<>c.<>9__57_0 = val_25;
        }
        
            MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  val_6);
            return;
        }
        
        if((MonoSingleton<DailyChallengeTutorialManager>.Instance) != 0)
        {
                MonoSingleton<DailyChallengeTutorialManager>.Instance.CheckHomeClick();
        }
        
        DailyChallengeGameLevel val_11 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
        val_11.isRetryLevel = true;
        WGDailyChallengeManager val_12 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((val_12.<Status>k__BackingField.playingPersistentLevel) != false)
        {
                WGDailyChallengeManager val_13 = MonoSingleton<WGDailyChallengeManager>.Instance;
            val_26 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() ^ (((val_13.<Status>k__BackingField.playingDayMorning) == false) ? 1 : 0);
        }
        else
        {
                val_26 = 0;
        }
        
        WGDailyChallengeManager val_16 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_16.<Status>k__BackingField.playingPersistentLevel = val_26 & 1;
        MonoSingleton<WGDailyChallengeManager>.Instance.Play();
        decimal val_21 = System.Decimal.op_UnaryNegation(d:  new System.Decimal() {flags = this.retryCost.flags, hi = this.retryCost.flags, lo = this.retryCost.lo, mid = this.retryCost.lo});
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_21.flags, hi = val_21.hi, lo = val_21.lo, mid = val_21.mid}, source:  (val_26 != 1) ? "Daily Challenge Retry" : "Daily Challenge Missed Days Retry", subSource:  0, externalParams:  0, doTrack:  true);
    }
    private void OnGalaRewardsClicked()
    {
        var val_9 = null;
        if(GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive != false)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        else
        {
                GameBehavior val_3 = App.getBehavior;
            WGSubscriptionManager._subEntryPoint = 67;
        }
    
    }
    private void ShowDailyChallengePopup()
    {
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_1.PlayingMorning = false;
        val_1.PlayingEvening = false;
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeV2Popup>(showNext:  true);
    }
    private void GrantCompleteReward()
    {
        GridCoinCollectAnimationInstantiator val_16;
        object val_17;
        var val_18;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_19;
        var val_20;
        decimal val_21;
        var val_22;
        var val_23;
        val_16 = this;
        if(this.coinsAnim == 0)
        {
                return;
        }
        
        this.button_continue_less_stars.interactable = false;
        this.button_retry_less_stars.interactable = false;
        this.button_continue_completed.interactable = false;
        WGDailyChallengeManager val_2 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((val_2.<Econ>k__BackingField.ChallengeDefinition) != null)
        {
                WGDailyChallengeManager val_3 = MonoSingleton<WGDailyChallengeManager>.Instance;
            decimal val_4 = val_3.<Econ>k__BackingField.ChallengeDefinition.GetReward;
            val_17 = val_4.flags;
            val_18 = val_4.lo;
        }
        else
        {
                val_18 = 0;
            val_17 = 0;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = null;
        val_19 = val_5;
        val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_20 = 1152921504617017344;
        val_5.Add(key:  "Base Reward", value:  val_17);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_6.Add(key:  "Base Reward", value:  this.goldenApplesReward);
        if((GoldenGalaHandler.dailyChallengeApple != null) && (GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive != false))
        {
                decimal val_8 = System.Decimal.op_Addition(d1:  new System.Decimal(), d2:  new System.Decimal() {flags = this.galaCoinAmount, hi = this.galaCoinAmount, lo = 41963520});
            val_17 = val_8.flags;
            val_18 = val_8.lo;
            val_5.Add(key:  "Golden Gala Bonus", value:  this.galaCoinAmount);
            int val_16 = this.goldenApplesReward;
            val_21 = this.galaCoinAmount;
            val_16 = this.galaAppleAmount + val_16;
            this.goldenApplesReward = val_16;
            val_20 = 1152921504617017344;
            val_6.Add(key:  "Golden Gala Bonus", value:  this.galaAppleAmount);
        }
        else
        {
                val_22 = 0;
            val_21 = 0;
        }
        
        val_6.Add(key:  "Daily Challenge", value:  true);
        val_23 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal(), d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                App.Player.AddCredits(amount:  new System.Decimal(), source:  "Daily Challenge", subSource:  0, externalParams:  val_5, doTrack:  true);
            GoldenApplesManager val_11 = MonoSingleton<GoldenApplesManager>.Instance;
            val_16 = this.coinsAnim;
            Player val_12 = App.Player;
            val_19 = val_12._credits;
            decimal val_13 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_19, hi = val_19, lo = 285570416, mid = 268435459}, d2:  new System.Decimal());
            val_17 = val_13.lo;
            Player val_14 = App.Player;
            decimal val_15 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_14._credits, hi = val_14._credits, lo = val_13.lo, mid = val_13.mid}, d2:  new System.Decimal());
            val_16.Play(fromValue:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_17, mid = val_13.mid}, toValue:  new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            return;
        }
        
        this.OnGoldenCurrencyAnimFinished();
    }
    private void OnRewardCollected()
    {
        this.weeklyProgressUI.InitializeWeeklyProgress(starsToAnimate:  0);
        this.monthlyProgressUI.InitializeMonthlyProgress(starsToAnimate:  0);
    }
    private void OnCoinsAnimFinished()
    {
        int val_9;
        mem2[0] = new System.Action(object:  this, method:  System.Void WGDailyChallengeLevelComplete::OnGoldenCurrencyAnimFinished());
        if((GoldenGalaHandler.dailyChallengeApple != null) && (GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive != false))
        {
                mem2[0] = new System.Action(object:  this, method:  System.Void WGDailyChallengeLevelComplete::PlayGalaCoinsAnim());
            val_9 = this.galaAppleAmount;
        }
        else
        {
                val_9 = 0;
        }
        
        Player val_4 = App.Player;
        Player val_5 = App.Player;
        decimal val_7 = System.Decimal.op_Implicit(value:  val_5._stars - val_9);
        this.goldenCurrencyAnimControl.Play(fromValue:  val_4._stars - this.goldenApplesReward, toValue:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        this.Invoke(methodName:  "OnGoldenCurrencyAnimFinished", time:  2f);
    }
    private void OnGoldenCurrencyAnimFinished()
    {
        this.ShowDailyChallengePopup();
        MonoSingleton<WordGameEventsController>.Instance.OnDailyChallengeRewardGranted();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void PlayGalaCoinsAnim()
    {
        UnityEngine.Vector3 val_1 = this.rightSource.position;
        this.rewardSource.position = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
        this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGDailyChallengeLevelComplete::PlayGalaGoldenCurrencyAnim());
        Player val_3 = App.Player;
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = this.galaCoinAmount, hi = this.galaCoinAmount, lo = 286150384, mid = 268435459});
        Player val_5 = App.Player;
        this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void PlayGalaGoldenCurrencyAnim()
    {
        mem2[0] = new System.Action(object:  this, method:  System.Void WGDailyChallengeLevelComplete::OnGoldenCurrencyAnimFinished());
        Player val_2 = App.Player;
        Player val_3 = App.Player;
        decimal val_4 = System.Decimal.op_Implicit(value:  val_3._stars);
        this.goldenCurrencyAnimControl.Play(fromValue:  val_2._stars - this.galaAppleAmount, toValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void SetupGoldenMultiplierUI()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  41963520, b:  new System.Action(object:  this, method:  System.Void WGDailyChallengeLevelComplete::<SetupGoldenMultiplierUI>b__66_0()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        mem2[0] = val_2;
        GoldenMultiplierManager val_3 = MonoSingleton<GoldenMultiplierManager>.Instance;
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.PlayGoldenCurrencyGet(amount:  val_3.currentLevelCompleteBonus));
        return;
        label_3:
    }
    private System.Collections.IEnumerator PlayGoldenCurrencyGet(int amount)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .amount = amount;
        return (System.Collections.IEnumerator)new WGDailyChallengeLevelComplete.<PlayGoldenCurrencyGet>d__67();
    }
    public WGDailyChallengeLevelComplete()
    {
        this.starPunchDuration = 0.3f;
        GameBehavior val_1 = App.getBehavior;
        this.dcRevamp = (val_1.<metaGameBehavior>k__BackingField) & 1;
    }
    private void <UpdateUIForDay>b__51_0()
    {
        UnityEngine.RectTransform val_6;
        UnityEngine.Transform val_2 = this.appleReward.rectTransform.parent;
        if(val_2 != null)
        {
                val_2 = (null == null) ? (val_2) : 0;
        }
        else
        {
                val_6 = 0;
        }
        
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot:  val_6);
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot:  (null == null) ? this.coinReward.rectTransform.parent : 0);
    }
    private void <SetupGoldenMultiplierUI>b__66_0()
    {
        if(this.goldenMultiplierGroup != null)
        {
                this.goldenMultiplierGroup.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }

}
