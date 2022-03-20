using UnityEngine;
public class WUTWordStreak : WordStreak
{
    // Fields
    private UnityEngine.UI.Text labelStreakCounter;
    private UnityEngine.UI.Button buttonStreakSaver;
    private UnityEngine.UI.Text labelStreakSaverCounter;
    private UnityEngine.UI.Text labelStreakSaverCoinCost;
    private UnityEngine.Transform upsellStreakBadge;
    private UnityEngine.Transform upsellStreakBadgeTargetOnButton;
    private UnityEngine.Transform gameplayStreakBadge;
    private UnityEngine.ParticleSystem particles;
    private DG.Tweening.Tweener streakMoverTween;
    private UnityEngine.Vector3 upsellBadgeInitialPos;
    private int brokenStreak;
    
    // Properties
    private bool StreakSaverEnabled { get; }
    private int MinOffer { get; }
    private decimal CostMultiplier { get; }
    
    // Methods
    private bool get_StreakSaverEnabled()
    {
        GameEcon val_1 = App.getGameEcon;
        return (bool)val_1.ss_enabled;
    }
    private int get_MinOffer()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.ss_min_offer;
    }
    private decimal get_CostMultiplier()
    {
        GameEcon val_1 = App.getGameEcon;
        return System.Decimal.op_Implicit(value:  val_1.ss_cost_multiplier);
    }
    protected override void OnLevelLoaded(GameLevel level)
    {
        this.OnLevelLoaded(level:  level);
        this.buttonStreakSaver.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WUTWordStreak::OnStreakSaverButtonClicked()));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFadeInBegin");
        WordRegion.instance.addOnHintedUsedAction(callback:  new System.Action<System.String, System.Int32, System.Boolean, System.Boolean>(object:  this, method:  System.Void WUTWordStreak::OnHintUsed(string word, int hintIndex, bool isFree, bool isPickerHint)));
        UnityEngine.Vector3 val_5 = this.upsellStreakBadge.position;
        this.upsellBadgeInitialPos = val_5;
        mem[1152921518047831772] = val_5.y;
        mem[1152921518047831776] = val_5.z;
        this.UpdateStreakCounterLabel();
    }
    private void OnFadeInBegin()
    {
        this.OnPlayerInput();
    }
    private void OnHintUsed(string word, int hintIndex, bool isFree, bool isPickerHint)
    {
        this.OnPlayerInput();
    }
    private void OnPlayerInput()
    {
        this.CancelStreakSaverAnimation();
        if(this.buttonStreakSaver.gameObject.activeSelf == false)
        {
                return;
        }
        
        this.buttonStreakSaver.gameObject.SetActive(value:  false);
        this.upsellStreakBadge.gameObject.SetActive(value:  false);
    }
    public override void ResetStreak()
    {
        this.ResetStreak();
    }
    protected override void OnValidWordSubmitted(string word, bool extra)
    {
        var val_25;
        MetaGameBehavior val_26;
        int val_27;
        if(extra != false)
        {
                GameBehavior val_1 = App.getBehavior;
            if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        }
        
        this.brokenStreak = 0;
        mem[1152921518048564712] = null;
        DG.Tweening.Tween val_3 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WUTWordStreak::UpdateStreakCounterLabel()), ignoreTimeScale:  true);
        GameBehavior val_4 = App.getBehavior;
        if(mem[1152921518048564712] < (val_4.<metaGameBehavior>k__BackingField))
        {
                this.StopBorderEffects();
            return;
        }
        
        this.PlayBorderEffects(restoreEffects:  false);
        GameBehavior val_5 = App.getBehavior;
        val_26 = mem[1152921518048564712];
        if(((val_5.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                int val_6 = (val_26 < 12) ? 1152921504946249727 : 10;
        }
        
        mem[1152921504946249763] = (typeof(MetaGameBehavior).__il2cppRuntimeField_23 + val_26 < 0xC ? 1152921504946249727 : 10);
        val_27 = mem[X26 + 52];
        val_27 = X26 + 52;
        mem2[0] = UnityEngine.Mathf.Max(a:  val_27, b:  339402752);
        Player val_9 = App.Player;
        val_9.properties.SetLifetimeLargestStreak = 339402752;
        if(GoldenMultiplierManager.IsAvaialable != false)
        {
                MonoSingleton<GoldenMultiplierManager>.Instance.CurrentLevelWordStreaked(currentStreak:  1152921515677533728.__il2cppRuntimeField_24>>0&0xFFFFFFFF);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnWordStreakUpdated");
        }
        else
        {
                mem[1152921518048564728] = (WGSubscriptionManager.GetAdditionalPoints(basePoints:  val_6)) + val_27;
            GoldenApplesManager val_15 = MonoSingleton<GoldenApplesManager>.Instance;
            string val_17 = "streak_" + mem[1152921518048564712].ToString();
            val_27 = 1152921516201560176;
            if((MonoSingleton<DifficultySettingManagerGameplay>.Instance) != 0)
        {
                MonoSingleton<DifficultySettingManagerGameplay>.Instance.AwardExtraApples(earnedAmount:  val_6);
        }
        
        }
        
        val_25 = 1152921504893161472;
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<GoldenApplesFeedbackWord>.Instance)) == false)
        {
                return;
        }
        
        MonoSingleton<GoldenApplesFeedbackWord>.Instance.OnWordStreakUpdated(extra:  extra);
    }
    protected override void OnInvalidWordSubmitted()
    {
        this.brokenStreak = ;
        this.StopBorderEffects();
        this.UpdateStreakCounterLabel();
    }
    private void UpdateStreakCounterLabel()
    {
        UnityEngine.Transform val_32;
        var val_33;
        val_32 = this;
        string val_3 = System.String.Format(format:  "{0}X", arg0:  ???);
        this.gameplayStreakBadge.gameObject.SetActive(value:  (W24 > 0) ? 1 : 0);
        string val_6 = System.String.Format(format:  "{0}X", arg0:  this.brokenStreak);
        decimal val_7 = System.Decimal.op_Implicit(value:  this.brokenStreak);
        decimal val_8 = val_7.flags.CostMultiplier;
        decimal val_9 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, d2:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid});
        string val_10 = val_9.flags.ToString();
        this.buttonStreakSaver.interactable = true;
        UnityEngine.GameObject val_11 = this.buttonStreakSaver.gameObject;
        bool val_12 = val_11.StreakSaverEnabled;
        if(val_12 != false)
        {
                if(this.brokenStreak >= val_12.MinOffer)
        {
            goto label_13;
        }
        
        }
        
        val_33 = 0;
        if(val_11 == null)
        {
                label_13:
        }
        
        val_11.SetActive(value:  (this.brokenStreak > W24) ? 1 : 0);
        this.upsellStreakBadge.position = new UnityEngine.Vector3() {x = this.upsellBadgeInitialPos};
        this.upsellStreakBadge.gameObject.SetActive(value:  this.buttonStreakSaver.gameObject.activeSelf);
        if(this.buttonStreakSaver.gameObject.activeSelf == true)
        {
                return;
        }
        
        if(this.buttonStreakSaver.gameObject.activeSelf == false)
        {
                return;
        }
        
        mem[1152921518049013997] = 1;
        UnityEngine.Vector3 val_21 = this.gameplayStreakBadge.position;
        this.upsellStreakBadge.position = new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z};
        if(this.upsellStreakBadgeTargetOnButton != 0)
        {
                UnityEngine.Vector3 val_23 = this.upsellStreakBadgeTargetOnButton.position;
        }
        
        DG.Tweening.Tweener val_25 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.upsellStreakBadge, endValue:  new UnityEngine.Vector3() {x = this.upsellBadgeInitialPos, y = val_21.y, z = val_21.z}, duration:  0.55f, snapping:  false), ease:  7);
        UnityEngine.Vector3 val_27 = UnityEngine.Vector3.zero;
        this.buttonStreakSaver.transform.localScale = new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z};
        val_32 = this.buttonStreakSaver.transform;
        UnityEngine.Vector3 val_29 = new UnityEngine.Vector3(x:  1.4f, y:  1.4f, z:  1f);
        DG.Tweening.Tweener val_31 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_32, endValue:  new UnityEngine.Vector3() {x = val_29.x, y = val_29.y, z = val_29.z}, duration:  0.55f), ease:  31);
    }
    private void OnStreakSaverButtonClicked()
    {
        var val_12;
        Player val_1 = App.Player;
        decimal val_2 = System.Decimal.op_Implicit(value:  this.brokenStreak);
        decimal val_3 = val_2.flags.CostMultiplier;
        decimal val_4 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = 41963520}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})) != false)
        {
                val_12 = null;
            val_12 = null;
            PurchaseProxy.currentPurchasePoint = 121;
            GameBehavior val_6 = App.getBehavior;
            val_6.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  0);
            return;
        }
        
        decimal val_8 = System.Decimal.op_Implicit(value:  this.brokenStreak);
        decimal val_9 = val_8.flags.CostMultiplier;
        decimal val_10 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, d2:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
        bool val_11 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, source:  "Streak Saver", externalParams:  0, animated:  false);
        mem[1152921518049285740] = 1;
        mem[1152921518049285736] = this.brokenStreak;
        this.brokenStreak = 0;
        this.buttonStreakSaver.interactable = false;
        this.AnimateStreakSaved();
    }
    private void AnimateStreakSaved()
    {
        UnityEngine.Vector3 val_1 = this.gameplayStreakBadge.position;
        this.streakMoverTween = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.upsellStreakBadge, endValue:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, duration:  0.5f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WUTWordStreak::OnAnimComplete())), delay:  0.1f), autoKillOnCompletion:  true);
    }
    private void OnAnimComplete()
    {
        DG.Tweening.TweenExtensions.Kill(t:  this.streakMoverTween, complete:  false);
        this.upsellStreakBadge.gameObject.SetActive(value:  true);
        this.particles.Play();
        this.UpdateStreakCounterLabel();
        this.PlayBorderEffects(restoreEffects:  false);
    }
    private void CancelStreakSaverAnimation()
    {
        DG.Tweening.TweenExtensions.Kill(t:  this.streakMoverTween, complete:  false);
        this.upsellStreakBadge.position = new UnityEngine.Vector3() {x = this.upsellBadgeInitialPos};
        this.upsellStreakBadge.gameObject.SetActive(value:  false);
        this.UpdateStreakCounterLabel();
        this.PlayBorderEffects(restoreEffects:  false);
    }
    public WUTWordStreak()
    {
    
    }

}
