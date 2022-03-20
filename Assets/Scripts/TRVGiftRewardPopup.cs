using UnityEngine;
public class TRVGiftRewardPopup : WGGiftRewardPopup
{
    // Fields
    private UGUINetworkedButton doubleCoinButton;
    private UGUINetworkedButton extraExpertButton;
    private UnityEngine.UI.Button noThanksButton;
    private UnityEngine.UI.Text noThanksButtonText;
    private bool bonusCoinVideo;
    private decimal coinRewardAmount;
    private bool dailyBonus;
    private GiftRewardSource currentRewardSource;
    
    // Methods
    public override void Setup(System.Collections.Generic.List<GiftReward> rewards, GiftRewardSource rewardSource)
    {
        this.currentRewardSource = rewardSource;
        this.dailyBonus = (rewardSource < 2) ? 1 : 0;
        this.SetupUI(rewardCount:  rewards);
        this.noThanksButton.gameObject.SetActive(value:  false);
        this.extraExpertButton.gameObject.SetActive(value:  false);
        this.doubleCoinButton.gameObject.SetActive(value:  false);
    }
    protected override void SetupRewards(System.Collections.Generic.List<GiftReward> rewards, GiftRewardSource rewardSource, bool postCollectLogic = False)
    {
        GiftReward val_4;
        var val_5;
        int val_13;
        System.Collections.Generic.List<GiftRewardUIParams> val_14;
        .rewards = rewards;
        .<>4__this = this;
        .rewardsUIParams = new System.Collections.Generic.List<GiftRewardUIParams>();
        List.Enumerator<T> val_3 = (TRVGiftRewardPopup.<>c__DisplayClass9_0)[1152921517168454672].rewards.GetEnumerator();
        label_17:
        if(val_5.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(val_4 != 0)
        {
                val_13 = null;
        }
        
        GiftRewardUIParams val_7 = null;
        val_13 = 0;
        val_7 = new GiftRewardUIParams();
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        .Reward = val_4;
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_4 + 16) == 0)
        {
                mem[1152921517168414580] = val_4 + 40;
            if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            .StartBalance = val_8._credits;
            if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            val_13 = X24;
            decimal val_10 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_9._credits, hi = val_9._credits, lo = val_13, mid = val_13}, d2:  new System.Decimal() {flags = val_4 + 40, hi = val_4 + 40, lo = val_4 + 40 + 8, mid = val_4 + 40 + 8});
            .EndBalance = val_10;
            mem[1152921517168467008] = val_10.lo;
            mem[1152921517168467012] = val_10.mid;
        }
        
        val_14 = (TRVGiftRewardPopup.<>c__DisplayClass9_0)[1152921517168454672].rewardsUIParams;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14.Add(item:  val_7);
        goto label_17;
        label_3:
        val_5.Dispose();
        label_34:
        System.Delegate val_12 = System.Delegate.Combine(a:  mem[1152921517168414536], b:  new System.Action(object:  new TRVGiftRewardPopup.<>c__DisplayClass9_0(), method:  System.Void TRVGiftRewardPopup.<>c__DisplayClass9_0::<SetupRewards>b__0()));
        if(val_12 != null)
        {
                val_13 = null;
            if(null != val_13)
        {
            goto label_32;
        }
        
        }
        
        mem[1152921517168414536] = val_12;
        return;
        label_32:
        if(val_13 != 1)
        {
            goto label_33;
        }
        
        val_5.Dispose();
        if( == 0)
        {
            goto label_34;
        }
        
        throw null;
        label_33:
    }
    private void SetGiftRevealedState()
    {
        var val_19;
        var val_20;
        var val_21;
        System.Action<System.Boolean> val_22;
        this.noThanksButton.gameObject.SetActive(value:  true);
        this.extraExpertButton.gameObject.SetActive(value:  (this.currentRewardSource != 12) ? 1 : 0);
        UnityEngine.GameObject val_4 = this.doubleCoinButton.gameObject;
        val_19 = null;
        val_19 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = this.coinRewardAmount, hi = this.coinRewardAmount, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_8;
        }
        
        var val_6 = (this.currentRewardSource != 12) ? 1 : 0;
        if(val_4 != null)
        {
            goto label_9;
        }
        
        label_8:
        val_20 = 0;
        label_9:
        val_4.SetActive(value:  false);
        if(this.extraExpertButton.gameObject.activeSelf != true)
        {
                if(this.doubleCoinButton.gameObject.activeSelf == false)
        {
            goto label_17;
        }
        
        }
        
        val_21 = "NO THANKS";
        if(this.noThanksButtonText == null)
        {
                label_17:
            val_21 = "CONTINUE";
        }
        
        this.noThanksButtonText.interactable = false;
        this.extraExpertButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void TRVGiftRewardPopup::ExtraExpertClicked(bool connected));
        this.doubleCoinButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void TRVGiftRewardPopup::DoubleCoinClicked(bool connected));
        this.noThanksButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVGiftRewardPopup::<SetGiftRevealedState>b__10_0()));
        val_22 = 1152921515825666416;
        if((MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable()) == true)
        {
                return;
        }
        
        this.extraExpertButton.WaitingStatus(waiting:  true);
        this.doubleCoinButton.WaitingStatus(waiting:  true);
        ApplovinMaxPlugin val_16 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        val_22 = val_16.RewardVideoLoaded;
        System.Delegate val_18 = System.Delegate.Combine(a:  val_22, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVGiftRewardPopup::OnRewardedVideoLoaded(bool success)));
        if(val_18 != null)
        {
                if(null != null)
        {
            goto label_36;
        }
        
        }
        
        val_16.RewardVideoLoaded = val_18;
        return;
        label_36:
    }
    private void OnRewardedVideoLoaded(bool success)
    {
        bool val_6 = success ^ 1;
        this.extraExpertButton.WaitingStatus(waiting:  val_6 = success ^ 1);
        this.doubleCoinButton.WaitingStatus(waiting:  val_6);
        if(success == false)
        {
                return;
        }
        
        ApplovinMaxPlugin val_2 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        val_6 = val_2.RewardVideoLoaded;
        System.Delegate val_4 = System.Delegate.Remove(source:  val_6, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVGiftRewardPopup::OnRewardedVideoLoaded(bool success)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_2.RewardVideoLoaded = val_4;
        return;
        label_8:
    }
    private void ShowVideoAd(bool isBonusCoinVideo)
    {
        this.bonusCoinVideo = isBonusCoinVideo;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        if((MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  (this.dailyBonus == false) ? 31 : 0, adCapExempt:  true)) != false)
        {
                return;
        }
        
        this.extraExpertButton.WaitingStatus(waiting:  true);
        this.doubleCoinButton.WaitingStatus(waiting:  true);
        ApplovinMaxPlugin val_6 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        System.Delegate val_8 = System.Delegate.Combine(a:  val_6.RewardVideoLoaded, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVGiftRewardPopup::OnRewardedVideoLoaded(bool success)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        val_6.RewardVideoLoaded = val_8;
        bool val_10 = MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable();
        return;
        label_14:
    }
    private void ExtraExpertClicked(bool connected)
    {
        int val_12;
        var val_13;
        if((MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable()) != false)
        {
                this.ShowVideoAd(isBonusCoinVideo:  false);
            return;
        }
        
        System.Func<System.Boolean>[] val_3 = new System.Func<System.Boolean>[1];
        val_3[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean TRVGiftRewardPopup::<ExtraExpertClicked>b__13_0());
        GameBehavior val_5 = App.getBehavior;
        bool[] val_9 = new bool[2];
        val_9[0] = true;
        string[] val_10 = new string[2];
        val_12 = val_10.Length;
        val_10[0] = Localization.Localize(key:  "try_again_upper", defaultValue:  "TRY AGAIN", useSingularKey:  false);
        val_12 = val_10.Length;
        val_10[1] = "NULL";
        val_13 = null;
        val_13 = null;
        val_5.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "no_video_upper", defaultValue:  "NO VIDEO AVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "video_unavailable_explanation", defaultValue:  "No Rewarded Video Available.", useSingularKey:  false), shownButtons:  val_9, buttonTexts:  val_10, showClose:  true, buttonCallbacks:  val_3, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void DoubleCoinClicked(bool connected)
    {
        int val_12;
        var val_13;
        if((MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable()) != false)
        {
                this.ShowVideoAd(isBonusCoinVideo:  true);
            return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        System.Func<System.Boolean>[] val_5 = new System.Func<System.Boolean>[1];
        val_5[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean TRVGiftRewardPopup::<DoubleCoinClicked>b__14_0());
        bool[] val_9 = new bool[2];
        val_9[0] = true;
        string[] val_10 = new string[2];
        val_12 = val_10.Length;
        val_10[0] = Localization.Localize(key:  "try_again_upper", defaultValue:  "TRY AGAIN", useSingularKey:  false);
        val_12 = val_10.Length;
        val_10[1] = "NULL";
        val_13 = null;
        val_13 = null;
        val_3.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "no_video_upper", defaultValue:  "NO VIDEO AVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "video_unavailable_explanation", defaultValue:  "No Rewarded Video Available.", useSingularKey:  false), shownButtons:  val_9, buttonTexts:  val_10, showClose:  true, buttonCallbacks:  val_5, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void OnVideoResponse(Notification notif)
    {
        int val_22;
        UnityEngine.Component val_23;
        var val_24;
        val_23 = this;
        if((System.Boolean.Parse(value:  notif.data.ToString())) == false)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
        this.extraExpertButton.gameObject.SetActive(value:  false);
        this.doubleCoinButton.gameObject.SetActive(value:  false);
        this.noThanksButton.gameObject.SetActive(value:  false);
        GiftRewardUIParams val_7 = new GiftRewardUIParams();
        .Reward = new TRVDailyBonusRewardContainer();
        bool val_16 = false;
        if(this.bonusCoinVideo != false)
        {
                mem[1152921517169831064] = this.coinRewardAmount;
            (GiftRewardUIParams)[1152921517169826928].Reward.Type = 0;
            Player val_10 = App.Player;
            .StartBalance = val_10._credits;
            App.Player.AddCredits(amount:  new System.Decimal() {flags = (GiftRewardUIParams)[1152921517169826928].Reward.Amount, hi = (GiftRewardUIParams)[1152921517169826928].Reward.Amount}, source:  (this.currentRewardSource == 3) ? "Chapter Rewards Rewarded Video" : "Daily Bonus Rewarded Video", subSource:  0, externalParams:  0, doTrack:  true);
            .EndBalance = val_13._credits;
            val_22 = val_13._bonusRewardPoints;
            val_22.Add(item:  App.Player.AddCoinReward(param:  val_7));
            val_22.OnClick_RevealReward(onAllRewardsRevealed:  0);
            val_24 = 0;
        }
        else
        {
                System.Collections.Generic.List<TRVExpert> val_17 = MonoSingleton<TRVExpertsController>.Instance.DetermineExpertCards(source:  (this.currentRewardSource == 3) ? 13 : (0 + 1), expertNowReadyToUpgrade: out  val_16, cardsToPull:  1);
            if((public static TRVExpertsController MonoSingleton<TRVExpertsController>::get_Instance()) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            (GiftRewardUIParams)[1152921517169826928].Reward.Type = 3;
            mem2[0] = System.Boolean System.Array::InternalArray__ICollection_Contains<System.Collections.Generic.KeyValuePair<System.Object, System.Single>>(System.Collections.Generic.KeyValuePair<System.Object, System.Single> item);
            val_17.Add(item:  (GiftRewardUIParams)[1152921517169826928].Reward.AddExpertReward(param:  val_7));
            val_17.OnClick_RevealReward(onAllRewardsRevealed:  0);
        }
        
        UnityEngine.Coroutine val_21 = this.StartCoroutine(routine:  this.WaitThenClose(expertLeveledUp:  (val_16 != 0) ? 1 : 0));
    }
    private System.Collections.IEnumerator WaitThenClose(bool expertLeveledUp)
    {
        .<>4__this = this;
        .expertLeveledUp = expertLeveledUp;
        return (System.Collections.IEnumerator)new TRVGiftRewardPopup.<WaitThenClose>d__16(<>1__state:  0);
    }
    private void Close(bool expertLeveledUp)
    {
        if(expertLeveledUp != false)
        {
                GameBehavior val_1 = App.getBehavior;
        }
        
        if(this.dailyBonus != false)
        {
                MonoSingleton<WGDailyBonusManager>.Instance.ShowPostPopups();
            MonoSingleton<WGDailyBonusManager>.Instance.ResetReadyToCollectState();
            MonoSingleton<WGDailyBonusManager>.Instance.RemoveVideoObserver();
        }
        
        ApplovinMaxPlugin val_6 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        System.Delegate val_8 = System.Delegate.Remove(source:  val_6.RewardVideoLoaded, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVGiftRewardPopup::OnRewardedVideoLoaded(bool success)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        val_6.RewardVideoLoaded = val_8;
        this.Close();
        return;
        label_16:
    }
    public TRVGiftRewardPopup()
    {
    
    }
    private void <SetGiftRevealedState>b__10_0()
    {
        this.Close(expertLeveledUp:  false);
    }
    private bool <ExtraExpertClicked>b__13_0()
    {
        this.ExtraExpertClicked(connected:  false);
        return true;
    }
    private bool <DoubleCoinClicked>b__14_0()
    {
        this.DoubleCoinClicked(connected:  false);
        return true;
    }

}
