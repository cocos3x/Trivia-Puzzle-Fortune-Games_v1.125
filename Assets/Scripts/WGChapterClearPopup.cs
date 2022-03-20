using UnityEngine;
public class WGChapterClearPopup : MonoBehaviour
{
    // Fields
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private UnityEngine.Transform coinsAnimParent;
    private GridCoinCollectAnimationInstantiator coinsAnimControl2;
    private UnityEngine.Transform coinsAnimParent2;
    private UnityEngine.UI.Button[] collectButtons;
    private UnityEngine.ParticleSystem chapClearSystem;
    private LevelCompletePopup levelCompletePopup;
    private UnityEngine.CanvasGroup collectButtonCanvasGroup;
    private UnityEngine.CanvasGroup normalRewardCanvasGroup;
    private UnityEngine.UI.Text coinRewardAmount;
    private UnityEngine.GameObject vipRewardGroup;
    private UnityEngine.UI.Text regularCoinRewardAmount;
    private UnityEngine.UI.Text vipCoinRewardAmount;
    private UnityEngine.Transform normalRewardCoin;
    private UnityEngine.Transform regularRewardCoin;
    private UnityEngine.Transform vipRewardCoin;
    private UnityEngine.UI.Image vipMask;
    private UnityEngine.GameObject galaRewardGroup;
    private UnityEngine.UI.Text galaRegularCoinAmount;
    private UnityEngine.UI.Text galaBonusCoinAmount;
    private UnityEngine.Transform galaRegularCoin;
    private UnityEngine.Transform galaBonusCoin;
    private UnityEngine.GameObject galaRewardOverlay;
    private UnityEngine.UI.Button galaRewardsButton;
    private UnityEngine.GameObject[] appearingOrder;
    private shake vipImgAnim;
    private UnityEngine.GameObject[] galaAppearingOrder;
    private shake galaImgAnim;
    private decimal total_reward;
    private int order;
    private bool animDone;
    private VIPPartyEventInfo vipEventInfo;
    private bool rewardsAvailable;
    
    // Properties
    private bool VIPPartyCanShow { get; }
    private bool GoldenGalaCanShow { get; }
    
    // Methods
    private bool get_VIPPartyCanShow()
    {
        var val_3;
        if(VIPPartyEventHandler.instance != null)
        {
                val_3 = VIPPartyEventHandler.instance.IsEventExpired() ^ 1;
            return (bool)val_3 & 1;
        }
        
        val_3 = 0;
        return (bool)val_3 & 1;
    }
    private bool get_GoldenGalaCanShow()
    {
        var val_2;
        if(GoldenGalaHandler.dailyChallengeApple != null)
        {
                val_2 = GoldenGalaHandler.dailyChallengeApple ^ 1;
            return (bool)val_2 & 1;
        }
        
        val_2 = 0;
        return (bool)val_2 & 1;
    }
    public void OnEnable()
    {
        System.Action<System.Boolean> val_6;
        var val_7 = 0;
        label_5:
        if(val_7 >= this.collectButtons.Length)
        {
            goto label_2;
        }
        
        this.collectButtons[val_7].interactable = true;
        val_7 = val_7 + 1;
        if(this.collectButtons != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_2:
        val_6 = 1152921504893161472;
        if((MonoSingleton<WGSubscriptionManager>.Instance) == 0)
        {
                return;
        }
        
        WGSubscriptionManager val_3 = MonoSingleton<WGSubscriptionManager>.Instance;
        val_6 = val_3.purchaseResult;
        System.Delegate val_5 = System.Delegate.Combine(a:  val_6, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGChapterClearPopup::OnSubscriptionPurchaseAttempt(bool success)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_15;
        }
        
        }
        
        val_3.purchaseResult = val_5;
        return;
        label_15:
    }
    public void OnDisable()
    {
        if((MonoSingleton<WGSubscriptionManager>.Instance) == 0)
        {
                return;
        }
        
        WGSubscriptionManager val_3 = MonoSingleton<WGSubscriptionManager>.Instance;
        1152921504893161472 = val_3.purchaseResult;
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGChapterClearPopup::OnSubscriptionPurchaseAttempt(bool success)));
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
    public void Setup(bool shouldBeShowing, bool showRewards)
    {
        var val_16;
        this.collectButtonCanvasGroup.gameObject.SetActive(value:  false);
        this.collectButtonCanvasGroup.alpha = 0f;
        this.normalRewardCanvasGroup.gameObject.SetActive(value:  false);
        this.normalRewardCanvasGroup.alpha = 0f;
        this.vipRewardGroup.SetActive(value:  false);
        this.galaRewardGroup.SetActive(value:  false);
        this.vipImgAnim.enabled = false;
        this.galaImgAnim.enabled = false;
        this.coinsAnimParent.gameObject.SetActive(value:  false);
        this.coinsAnimParent2.gameObject.SetActive(value:  false);
        this.coinsAnimControl.gameObject.SetActive(value:  false);
        UnityEngine.GameObject val_6 = this.coinsAnimControl2.gameObject;
        val_6.SetActive(value:  false);
        if(val_6.VIPPartyCanShow != false)
        {
                val_16 = this;
            this.PrepareAppearingAnimation();
        }
        
        if(this.GoldenGalaCanShow != false)
        {
                this.PrepareGalaAppearingAnimation();
        }
        
        this.gameObject.SetActive(value:  shouldBeShowing);
        this.rewardsAvailable = shouldBeShowing & showRewards;
        var val_17 = 0;
        label_27:
        if(val_17 >= this.collectButtons.Length)
        {
            goto label_23;
        }
        
        this.collectButtons[val_17].gameObject.SetActive(value:  this.rewardsAvailable);
        val_17 = val_17 + 1;
        if(this.collectButtons != null)
        {
            goto label_27;
        }
        
        throw new NullReferenceException();
        label_23:
        if(this.rewardsAvailable == false)
        {
                return;
        }
        
        this.SetupRewards();
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(selected:  this.collectButtons[0].gameObject);
    }
    public void PlayStartAnims()
    {
        UnityEngine.Object val_13;
        if(this.gameObject.activeSelf != false)
        {
                WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
            val_3.sound.PlayGeneralSound(type:  1, oneshot:  true, pitch:  1f, vol:  1f);
        }
        
        if(this.rewardsAvailable == false)
        {
                return;
        }
        
        val_13 = this.chapClearSystem;
        if((UnityEngine.Object.op_Implicit(exists:  val_13)) != false)
        {
                val_13 = this.chapClearSystem;
            val_13.Play();
        }
        
        bool val_5 = val_13.VIPPartyCanShow;
        if(val_5 != false)
        {
                UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.ExecuteAppearingAnimationSequence_VIP());
            return;
        }
        
        if(val_5.GoldenGalaCanShow != false)
        {
                this.PlayGoldenGalaSequence();
            return;
        }
        
        DG.Tweening.Tweener val_10 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.normalRewardCanvasGroup, endValue:  1f, duration:  0.5f), delay:  1f);
        DG.Tweening.Tweener val_12 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.collectButtonCanvasGroup, endValue:  1f, duration:  0.5f), delay:  1f);
    }
    public void OnCollectClicked()
    {
        UnityEngine.UI.Button val_21;
        decimal val_24;
        var val_25;
        var val_26;
        this.coinsAnimControl.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGChapterClearPopup::OnRegularCoinsAnimFinished());
        if(this.collectButtons.Length >= 1)
        {
                var val_22 = 0;
            do
        {
            if(this.collectButtons[val_22] == null)
        {
                return;
        }
        
            val_22 = val_22 + 1;
        }
        while(val_22 < this.collectButtons.Length);
        
        }
        
        if(this.collectButtons.Length >= 1)
        {
                var val_23 = 0;
            do
        {
            val_21 = this.collectButtons[val_23];
            val_21.interactable = false;
            val_23 = val_23 + 1;
        }
        while(val_23 < this.collectButtons.Length);
        
        }
        
        bool val_2 = val_21.VIPPartyCanShow;
        if(val_2 == false)
        {
            goto label_13;
        }
        
        UnityEngine.Vector3 val_3 = this.regularRewardCoin.position;
        this.coinsAnimParent.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        this.coinsAnimParent.gameObject.SetActive(value:  true);
        this.coinsAnimControl.gameObject.SetActive(value:  true);
        this.coinsAnimControl.coinExpansionEnabled = false;
        if(this.vipEventInfo.isVIP == false)
        {
            goto label_34;
        }
        
        val_24 = this.vipEventInfo.reward;
        val_25 = this.vipEventInfo + 32;
        goto label_37;
        label_13:
        if(val_2.GoldenGalaCanShow == false)
        {
            goto label_24;
        }
        
        UnityEngine.Vector3 val_7 = this.galaRegularCoin.position;
        this.coinsAnimParent.position = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        this.coinsAnimParent.gameObject.SetActive(value:  true);
        this.coinsAnimControl.gameObject.SetActive(value:  true);
        this.coinsAnimControl.coinExpansionEnabled = false;
        if(GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive == false)
        {
            goto label_34;
        }
        
        goto label_37;
        label_34:
        val_26 = null;
        val_26 = null;
        val_24 = 1152921504617021448;
        val_25 = 1152921504617021456;
        label_37:
        Player val_11 = App.Player;
        decimal val_12 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_11._credits, hi = val_11._credits, lo = X24, mid = X24}, d2:  new System.Decimal() {flags = this.total_reward, hi = this.total_reward, lo = 257766768, mid = 268435459});
        Player val_13 = App.Player;
        decimal val_14 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_13._credits, hi = val_13._credits, lo = val_12.lo, mid = val_12.mid}, d2:  new System.Decimal() {flags = val_24, hi = val_24, lo = mem[1152921504617021456], mid = mem[1152921504617021456]});
        this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, toValue:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        return;
        label_24:
        MonoSingleton<WGFlyoutManager>.Instance.SetDarkenedBackgroundAlpha(alpha:  0f);
        GameBehavior val_16 = App.getBehavior;
        SLCWindow val_18 = val_16.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_18.Action_OnClose = new System.Action(object:  this, method:  System.Void WGChapterClearPopup::Close());
        val_16.<metaGameBehavior>k__BackingField.Setup(rewardSource:  3);
        MethodExtensionForMonoBehaviourTransform.SetActiveChildren(t:  this.levelCompletePopup.transform, state:  false);
    }
    private void OnRegularCoinsAnimFinished()
    {
        GridCoinCollectAnimationInstantiator val_20;
        decimal val_23;
        GridCoinCollectAnimationInstantiator val_24;
        int val_25;
        decimal val_26;
        float val_28;
        int val_29;
        bool val_30;
        val_20 = this.coinsAnimControl;
        System.Delegate val_2 = System.Delegate.Remove(source:  this.coinsAnimControl.OnCompleteCallback, value:  new System.Action(object:  this, method:  System.Void WGChapterClearPopup::OnRegularCoinsAnimFinished()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.coinsAnimControl.OnCompleteCallback = val_2;
        bool val_3 = val_2.VIPPartyCanShow;
        if((val_3 == false) || (this.vipEventInfo.isVIP == false))
        {
            goto label_6;
        }
        
        UnityEngine.Vector3 val_4 = this.vipRewardCoin.position;
        this.coinsAnimParent2.position = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        this.coinsAnimParent2.gameObject.SetActive(value:  true);
        this.coinsAnimControl2.gameObject.SetActive(value:  true);
        this.coinsAnimControl2.coinExpansionEnabled = false;
        this.coinsAnimControl2.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGChapterClearPopup::OnExtraCoinsAnimFinished());
        Player val_8 = App.Player;
        val_23 = val_8._credits;
        decimal val_9 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_23, hi = val_23, lo = 1152921504614301696}, d2:  new System.Decimal() {flags = this.vipEventInfo.reward, hi = this.vipEventInfo.reward, lo = 258195184, mid = 268435459});
        val_24 = val_9.flags;
        val_25 = val_9.lo;
        Player val_10 = App.Player;
        val_26 = val_10._credits;
        val_28 = -1f;
        val_29 = val_24;
        goto label_23;
        label_6:
        if(val_3.GoldenGalaCanShow == false)
        {
            goto label_27;
        }
        
        val_30 = static_value_02805631;
        val_30 = true;
        if(mem[7493989779944660552].IsSubscriptionActive == false)
        {
            goto label_27;
        }
        
        UnityEngine.Vector3 val_13 = this.galaBonusCoin.position;
        this.coinsAnimParent2.position = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
        this.coinsAnimParent2.gameObject.SetActive(value:  true);
        this.coinsAnimControl2.gameObject.SetActive(value:  true);
        this.coinsAnimControl2.coinExpansionEnabled = false;
        this.coinsAnimControl2.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGChapterClearPopup::OnExtraCoinsAnimFinished());
        val_24 = this.coinsAnimControl2;
        Player val_17 = App.Player;
        val_23 = mem[GoldenGalaHandler.dailyChallengeApple + 32];
        val_23 = GoldenGalaHandler.dailyChallengeApple + 32;
        decimal val_18 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_17._credits, hi = val_17._credits, lo = 258333680, mid = 268435459}, d2:  new System.Decimal() {flags = val_23, hi = val_23, lo = GoldenGalaHandler.dailyChallengeApple + 32 + 8, mid = GoldenGalaHandler.dailyChallengeApple + 32 + 8});
        val_25 = val_18.lo;
        Player val_19 = App.Player;
        val_26 = val_19._credits;
        val_28 = -1f;
        val_29 = val_18.flags;
        label_23:
        val_24.Play(fromValue:  new System.Decimal() {flags = val_29, hi = val_18.hi, lo = val_25, mid = val_18.mid}, toValue:  new System.Decimal() {flags = val_26, hi = val_26}, textTickTime:  val_28, delayBeforeComplete:  val_28);
        return;
        label_27:
        this.Close();
        return;
        label_3:
    }
    private void OnExtraCoinsAnimFinished()
    {
        System.Delegate val_2 = System.Delegate.Remove(source:  this.coinsAnimControl2.OnCompleteCallback, value:  new System.Action(object:  this, method:  System.Void WGChapterClearPopup::OnExtraCoinsAnimFinished()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.coinsAnimControl2.OnCompleteCallback = val_2;
        this.Close();
        return;
        label_3:
    }
    private void Close()
    {
        this.StopAllCoroutines();
        goto typeof(LevelCompletePopup).__il2cppRuntimeField_190;
    }
    private void OnVipButtonClicked()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.Init(levelComplete:  true, onCloseAction:  new System.Action(object:  this, method:  System.Void WGChapterClearPopup::SetupRewards()));
    }
    private void OnGalaButtonClicked()
    {
        var val_9 = null;
        if(GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive != false)
        {
                GameBehavior val_2 = App.getBehavior;
        }
        else
        {
                GameBehavior val_3 = App.getBehavior;
            WGSubscriptionManager._subEntryPoint = 65;
        }
    
    }
    private void SetupRewards()
    {
        this.normalRewardCanvasGroup.gameObject.SetActive(value:  false);
        this.vipRewardGroup.SetActive(value:  false);
        this.galaRewardGroup.SetActive(value:  false);
    }
    private void PrepareAppearingAnimation()
    {
        int val_2 = this.appearingOrder.Length;
        if(val_2 < 1)
        {
                return;
        }
        
        var val_3 = 0;
        val_2 = val_2 & 4294967295;
        do
        {
            MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  null).alpha = 0f;
            val_3 = val_3 + 1;
        }
        while(val_3 < (this.appearingOrder.Length << ));
    
    }
    private System.Collections.IEnumerator ExecuteAppearingAnimationSequence_VIP()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGChapterClearPopup.<ExecuteAppearingAnimationSequence_VIP>d__49();
    }
    private System.Collections.IEnumerator ExecuteAppearingAnimation(UnityEngine.CanvasGroup cg)
    {
        .<>1__state = 0;
        .cg = cg;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGChapterClearPopup.<ExecuteAppearingAnimation>d__50();
    }
    private void PrepareGalaAppearingAnimation()
    {
        var val_3 = 0;
        do
        {
            if(val_3 >= (this.galaAppearingOrder.Length << ))
        {
                return;
        }
        
            MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.galaAppearingOrder[val_3]).alpha = 0f;
            val_3 = val_3 + 1;
        }
        while(this.galaAppearingOrder != null);
        
        throw new NullReferenceException();
    }
    private void PlayGoldenGalaSequence()
    {
        var val_8 = 0;
        do
        {
            if(val_8 >= this.galaAppearingOrder.Length)
        {
                return;
        }
        
            float val_9 = 0f;
            val_9 = val_9 * 0.5f;
            DG.Tweening.Tweener val_3 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.galaAppearingOrder[0]), endValue:  1f, duration:  0.5f), delay:  val_9);
            if((this.galaAppearingOrder[0].name.Contains(value:  "GoldenGala")) != false)
        {
                val_8 = val_8 + 1;
            float val_11 = (float)val_8;
            val_11 = val_11 * 0.5f;
            DG.Tweening.Tween val_7 = DG.Tweening.DOVirtual.DelayedCall(delay:  val_11, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGChapterClearPopup::<PlayGoldenGalaSequence>b__52_0()), ignoreTimeScale:  true);
        }
        else
        {
                val_8 = val_8 + 1;
        }
        
        }
        while(this.galaAppearingOrder != null);
        
        throw new NullReferenceException();
    }
    private void OnSubscriptionPurchaseAttempt(bool success)
    {
        this.galaRewardOverlay.SetActive(value:  (~GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive) & 1);
        this.SetupRewards();
    }
    public WGChapterClearPopup()
    {
        this.vipEventInfo = new VIPPartyEventInfo();
    }
    private void <PlayGoldenGalaSequence>b__52_0()
    {
        if(this.galaImgAnim != null)
        {
                this.galaImgAnim.enabled = true;
            return;
        }
        
        throw new NullReferenceException();
    }

}
