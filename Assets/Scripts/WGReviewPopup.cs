using UnityEngine;
public class WGReviewPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text titleBannerText;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.GameObject reviewSection;
    private UnityEngine.UI.Toggle[] stars;
    private UnityEngine.UI.Button submitButton;
    private UnityEngine.GameObject shareSection;
    private UnityEngine.UI.Button shareButton;
    private UnityEngine.GameObject[] yourStars;
    private UnityEngine.UI.Text shareRewardText;
    private TMPro.TextMeshProUGUI rateRewardText_rate;
    private UnityEngine.GameObject feedbackTypeSection;
    private UnityEngine.GameObject feedbackSuggestionOnlyParent;
    private UnityEngine.UI.Button feedbackGiveButton;
    private UnityEngine.UI.Button feedbackDeclineButton;
    private UnityEngine.UI.Button feedbackLessAdsButton;
    private UnityEngine.UI.Button feedbackMoreCoinsButton;
    private UnityEngine.UI.Button feedbackOtherSuggestions;
    private UnityEngine.UI.Text feedbackText;
    private UnityEngine.GameObject feedbackLessAdsSection;
    private UnityEngine.GameObject feedbackBonusCoinsSection;
    private UnityEngine.GameObject feedbackGiveSuggestionSection;
    private UnityEngine.GameObject noAdsGift;
    private UnityEngine.UI.Button noAdsButton;
    private UnityEngine.UI.Text noAdsText;
    private UnityEngine.GameObject freeTrialGift;
    private UnityEngine.UI.Button freeTrialButton;
    private UnityEngine.UI.Text freeTrialDurationText;
    private UnityEngine.GameObject thanksSection;
    protected UnityEngine.UI.Button collectButton;
    private UnityEngine.UI.Text thanksRewardText;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private UnityEngine.UI.Text thanksRatingText;
    private TMPro.TextMeshProUGUI rateRewardText_thanks;
    private UnityEngine.GameObject f_thanksSection;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Text thanksFeedbackText;
    private UnityEngine.GameObject thanksFeedbackCloseButton;
    private UnityEngine.GameObject thanksFreeGiftSection;
    private UnityEngine.GameObject thanksGiftText;
    private bool didReview;
    protected decimal rateReward;
    private int currentStarRating;
    
    // Properties
    public int CurrentStarRating { get; set; }
    
    // Methods
    public int get_CurrentStarRating()
    {
        return (int)this.currentStarRating + 1;
    }
    public void set_CurrentStarRating(int value)
    {
        this.currentStarRating = value;
        var val_5 = 0;
        label_5:
        if(val_5 >= this.stars.Length)
        {
            goto label_2;
        }
        
        this.stars[val_5].isOn = (val_5 <= this.currentStarRating) ? 1 : 0;
        val_5 = val_5 + 1;
        if(this.stars != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_2:
        if(this.submitButton == 0)
        {
                return;
        }
        
        int val_6 = this.currentStarRating;
        val_6 = val_6 >> 31;
        this.submitButton.interactable = val_6 ^ 1;
    }
    private void Start()
    {
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        this.didReview = false;
        GameEcon val_1 = App.getGameEcon;
        mem2[0] = val_1.ratingReward.flags;
        WGReviewManager val_2 = MonoSingleton<WGReviewManager>.Instance;
        val_2.selectedRating = 0;
        val_22 = null;
        val_22 = null;
        if(App.game != 16)
        {
                val_23 = null;
            val_23 = null;
            if(App.game != 17)
        {
                val_24 = null;
            val_24 = null;
            if(App.game != 99)
        {
                val_25 = null;
            val_25 = null;
            if(App.game != 20)
        {
                val_26 = null;
            val_26 = null;
            if(App.game != 21)
        {
            goto label_83;
        }
        
        }
        
        }
        
        }
        
        }
        
        UnityEngine.Events.UnityAction val_3 = null;
        label_83:
        val_3 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::OnClick_Submit_v1());
        this.submitButton.m_OnClick.AddListener(call:  val_3);
        if(this.shareButton != 0)
        {
                this.shareButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::OnClick_Share()));
        }
        
        if(this.feedbackGiveButton != 0)
        {
                this.feedbackGiveButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::OnClick_Feedback()));
        }
        
        if(this.feedbackDeclineButton != 0)
        {
                this.feedbackDeclineButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::OnClick_Decline()));
        }
        
        if(this.collectButton != 0)
        {
                this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGReviewPopup).__il2cppRuntimeField_178));
        }
        
        if(this.continueButton != 0)
        {
                this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::OnClick_Continue()));
        }
        
        if(this.feedbackLessAdsButton != 0)
        {
                this.feedbackLessAdsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::OnClickTooManyAds()));
        }
        
        if(this.feedbackMoreCoinsButton != 0)
        {
                this.feedbackMoreCoinsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::OnClickNotEnoughCoins()));
        }
        
        if(this.feedbackOtherSuggestions != 0)
        {
                this.feedbackOtherSuggestions.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::OnClickOtherSuggestion()));
        }
        
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::OnClick_Decline()));
        MonoSingleton<WGReviewManager>.Instance.LoadAppReview();
    }
    private void OnEnable()
    {
        this.closeButton.gameObject.SetActive(value:  true);
        this.reviewSection.SetActive(value:  true);
        string val_5 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  Localization.Localize(key:  "having_fun_q_upper", defaultValue:  "HAVING FUN?", useSingularKey:  false));
        this.shareSection.SetActive(value:  false);
        if(this.feedbackTypeSection != 0)
        {
                this.feedbackTypeSection.SetActive(value:  false);
        }
        
        this.feedbackSuggestionOnlyParent.SetActive(value:  false);
        this.thanksSection.SetActive(value:  false);
        this.f_thanksSection.SetActive(value:  false);
        this.SetupReview();
        if(this.submitButton == 0)
        {
                return;
        }
        
        this.submitButton.interactable = false;
    }
    private void OnDisable()
    {
        this.StopAllCoroutines();
    }
    private void SetupReview()
    {
        string val_4 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  Localization.Localize(key:  "having_fun_q_upper", defaultValue:  "HAVING FUN?", useSingularKey:  false));
        this.CurrentStarRating = 0;
    }
    private void SetupShare()
    {
        TMPro.TextMeshProUGUI val_11;
        string val_12;
        var val_13;
        var val_14;
        val_11 = this;
        val_12 = App.getGameEcon.titleFormat;
        string val_4 = System.String.Format(format:  val_12, arg0:  Localization.Localize(key:  "thank_you_e_upper", defaultValue:  "THANK YOU!", useSingularKey:  false));
        var val_12 = 0;
        label_9:
        if(val_12 >= this.yourStars.Length)
        {
            goto label_6;
        }
        
        this.yourStars[val_12].SetActive(value:  (val_12 <= this.currentStarRating) ? 1 : 0);
        val_12 = val_12 + 1;
        if(this.yourStars != null)
        {
            goto label_9;
        }
        
        throw new NullReferenceException();
        label_6:
        val_13 = null;
        val_13 = null;
        if(App.game == 15)
        {
                val_12 = mem[this.rateReward];
            val_12 = this.rateReward.flags;
            decimal val_6 = new System.Decimal(value:  100);
            decimal val_7 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_12, hi = val_12, lo = 387112960, mid = 268435456}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo});
            val_11 = this.rateRewardText_rate;
            val_14 = null;
            val_14 = null;
            string val_8 = val_7.flags.ToString(format:  GameEcon.numberFormatDecimal);
            return;
        }
        
        GameEcon val_9 = App.getGameEcon;
        string val_10 = this.rateReward.ToString(format:  val_9.numberFormatInt);
    }
    private void SetupFeedback_v1()
    {
        string val_4 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  Localization.Localize(key:  "thank_you_e_upper", defaultValue:  "THANK YOU!", useSingularKey:  false));
        this.feedbackSuggestionOnlyParent.SetActive(value:  true);
    }
    private void SetupFeedback()
    {
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        val_21 = this;
        val_22 = 1152921504884269056;
        string val_4 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  Localization.Localize(key:  "thank_you_e_upper", defaultValue:  "THANK YOU!", useSingularKey:  false));
        this.feedbackLessAdsSection.SetActive(value:  false);
        this.feedbackBonusCoinsSection.SetActive(value:  false);
        this.feedbackGiveSuggestionSection.SetActive(value:  false);
        GameBehavior val_5 = App.getBehavior;
        val_23 = val_5.<metaGameBehavior>k__BackingField;
        val_24 = WGSubscriptionManager.WillGetFreeTrial;
        Player val_7 = App.Player;
        var val_8 = (val_7.num_purchase == 0) ? 1 : 0;
        val_8 = val_23 & val_8;
        val_8 = val_24 & val_8;
        if(val_8 != true)
        {
            goto label_11;
        }
        
        this.feedbackTypeSection.SetActive(value:  true);
        this.feedbackBonusCoinsSection.SetActive(value:  true);
        label_32:
        this.feedbackMoreCoinsButton.gameObject.SetActive(value:  true);
        if(this.feedbackLessAdsSection != null)
        {
            goto label_16;
        }
        
        label_11:
        Player val_10 = App.Player;
        var val_11 = (val_10.num_purchase > 0) ? 1 : 0;
        val_11 = val_23 & val_11;
        val_11 = val_24 & val_11;
        if(val_11 != true)
        {
            goto label_21;
        }
        
        this.feedbackTypeSection.SetActive(value:  true);
        this.feedbackBonusCoinsSection.SetActive(value:  true);
        label_16:
        this.feedbackMoreCoinsButton.gameObject.SetActive(value:  true);
        this.feedbackGiveSuggestionSection.SetActive(value:  true);
        val_23 = ???;
        val_21 = ???;
        val_22 = ???;
        val_24 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_21:
        Player val_13 = App.Player;
        var val_14 = (val_13.num_purchase != 0) ? 1 : 0;
        val_14 = val_14 | (~val_23);
        if((val_14 & 1) == 0)
        {
                if((val_21 + 104) != 0)
        {
            goto label_32;
        }
        
        }
        
        val_21 + 112.SetActive(value:  true);
    }
    private void SetupThanks(bool fromRating)
    {
        var val_27;
        string val_29;
        var val_30;
        var val_31;
        this.closeButton.gameObject.SetActive(value:  false);
        bool val_2 = UnityEngine.Object.op_Inequality(x:  this.coinsAnim, y:  0);
        if(val_2 != false)
        {
                val_2.SetActive(value:  true);
        }
        
        string val_6 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  Localization.Localize(key:  "thank_you_e_upper", defaultValue:  "THANK YOU!", useSingularKey:  false));
        GameBehavior val_7 = App.getBehavior;
        if(((val_7.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_27 = 0;
            string val_8 = Localization.Localize(key:  "rfeedback_thanks_popup", defaultValue:  "Your feedback helps us make #game-name the best word game!", useSingularKey:  false);
        }
        else
        {
                val_27 = 0;
            AppConfigs val_10 = App.Configuration;
            string val_11 = System.String.Format(format:  Localization.Localize(key:  "wgreviewpopup_feedback_rating", defaultValue:  "Your feedback helps make {0} the best game possible!", useSingularKey:  false), arg0:  val_10.appConfig.gameName);
        }
        
        bool val_12 = UnityEngine.Object.op_Implicit(exists:  this.thanksRatingText);
        bool val_13 = UnityEngine.Object.op_Implicit(exists:  this.thanksFeedbackText);
        val_30 = null;
        val_30 = null;
        if(App.game != 15)
        {
            goto label_33;
        }
        
        if(fromRating == false)
        {
            goto label_34;
        }
        
        decimal val_14 = new System.Decimal(value:  100);
        decimal val_15 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = this.rateReward.flags, hi = this.rateReward.flags, lo = 387112960, mid = 268435456}, d2:  new System.Decimal() {flags = val_14.flags, hi = val_14.flags, lo = val_14.lo, mid = val_14.lo});
        val_31 = null;
        val_31 = null;
        this.rateRewardText_thanks.text = val_15.flags.ToString(format:  GameEcon.numberFormatDecimal);
        val_29 = Localization.Localize(key:  "wgreviewpopup_feedback_rating", defaultValue:  "Your feedback helps make {0} the best game possible!", useSingularKey:  false);
        AppConfigs val_18 = App.Configuration;
        string val_19 = System.String.Format(format:  val_29, arg0:  val_18.appConfig.gameName);
        System.Collections.IEnumerator val_20 = this.WaitShowThanks_SCS();
        goto label_52;
        label_33:
        if(fromRating == false)
        {
            goto label_46;
        }
        
        GameEcon val_21 = App.getGameEcon;
        string val_22 = this.rateReward.ToString(format:  val_21.numberFormatInt);
        System.Collections.IEnumerator val_23 = this.WaitShowThanks();
        goto label_52;
        label_34:
        System.Collections.IEnumerator val_24 = this.WaitShowThanksF_SCS();
        goto label_52;
        label_46:
        label_52:
        UnityEngine.Coroutine val_26 = this.StartCoroutine(routine:  this.WaitShowThanksF());
    }
    private System.Collections.IEnumerator WaitShowThanks()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGReviewPopup.<WaitShowThanks>d__53();
    }
    private System.Collections.IEnumerator WaitShowThanksF()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGReviewPopup.<WaitShowThanksF>d__54();
    }
    private System.Collections.IEnumerator WaitShowThanks_SCS()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGReviewPopup.<WaitShowThanks_SCS>d__55();
    }
    private System.Collections.IEnumerator WaitShowThanksF_SCS()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGReviewPopup.<WaitShowThanksF_SCS>d__56();
    }
    private void OnClick_Submit_v1()
    {
        this.reviewSection.SetActive(value:  false);
        int val_3 = this.currentStarRating;
        val_3 = val_3 + 1;
        if(val_3 >= 5)
        {
                this.shareSection.SetActive(value:  true);
            this.SetupShare();
        }
        else
        {
                if(val_3 >= 3)
        {
                this.SetupThanks(fromRating:  false);
        }
        else
        {
                this.SetupFeedback_v1();
        }
        
        }
        
        this.didReview = true;
        MonoSingleton<WGReviewManager>.Instance.HandleReviewSelected(rating:  this.currentStarRating + 1, forceTracking:  true);
    }
    private void OnClick_Submit()
    {
        this.reviewSection.SetActive(value:  false);
        if(this.currentStarRating == 4)
        {
                this.shareSection.SetActive(value:  true);
            this.SetupShare();
        }
        else
        {
                this.SetupFeedback();
        }
        
        this.didReview = true;
        MonoSingleton<WGReviewManager>.Instance.HandleReviewSelected(rating:  this.currentStarRating + 1, forceTracking:  false);
    }
    private void OnClick_Share()
    {
        this.shareSection.SetActive(value:  false);
        this.SetupThanks(fromRating:  true);
        TrackingComponent.CurrentIntent = 6;
        MonoSingleton<WGReviewManager>.Instance.ShowInAppReview();
    }
    private void OnClick_Feedback()
    {
        if(this.feedbackTypeSection != 0)
        {
                this.feedbackTypeSection.SetActive(value:  false);
        }
        
        this.feedbackSuggestionOnlyParent.SetActive(value:  false);
        if(this.thanksFeedbackCloseButton != 0)
        {
                this.thanksFeedbackCloseButton.SetActive(value:  true);
        }
        
        this.SetupThanks(fromRating:  false);
        Player val_3 = App.Player;
        if(val_3.isTroll != false)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<HelpshiftPlugin>.Instance.ShowSupport(prefillText:  "");
    }
    private void OnClickTooManyAds()
    {
        this.feedbackTypeSection.SetActive(value:  false);
        this.noAdsGift.SetActive(value:  true);
        this.noAdsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::Close()));
        MonoSingleton<WGReviewManager>.Instance.GrantNoAdTime();
        WGReviewManager val_3 = MonoSingleton<WGReviewManager>.Instance;
        string val_4 = System.String.Format(format:  "We’d like to give you {0} days with no ads on us!", arg0:  val_3._freeNoAdsDuration);
        MonoSingleton<WGReviewManager>.Instance.DoAmpTracking(optionSelected:  "Too Many Ads");
    }
    private void OnClickNotEnoughCoins()
    {
        this.feedbackTypeSection.SetActive(value:  false);
        this.freeTrialGift.SetActive(value:  true);
        this.freeTrialButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGReviewPopup::Close()));
        WGReviewManager val_2 = MonoSingleton<WGReviewManager>.Instance;
        string val_3 = System.String.Format(format:  "We’d like to give you {0} days with the Golden Ticket. Enjoy the extra coins!", arg0:  val_2._freeTrialDuration);
        MonoSingleton<WGReviewManager>.Instance.TryGrantFreeTrial();
        MonoSingleton<WGReviewManager>.Instance.DoAmpTracking(optionSelected:  "Not enough Coins");
    }
    private void OnClickOtherSuggestion()
    {
        this.feedbackTypeSection.SetActive(value:  false);
        this.feedbackSuggestionOnlyParent.SetActive(value:  false);
        this.feedbackLessAdsButton.gameObject.SetActive(value:  false);
        this.feedbackMoreCoinsButton.gameObject.SetActive(value:  false);
        MonoSingleton<WGReviewManager>.Instance.DoAmpTracking(optionSelected:  "Other");
        this.OnClick_Feedback();
    }
    private void OnClick_Decline()
    {
        this.Close();
    }
    protected virtual void OnClick_Collect()
    {
        this.collectButton.interactable = false;
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = this.rateReward.flags, hi = this.rateReward.flags, lo = this.rateReward.lo, mid = this.rateReward.lo}, source:  "Rate Bonus", externalParams:  0, animated:  false);
        if(this.coinsAnim != 0)
        {
                this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGReviewPopup::OnCoinsAnimFinished());
            Player val_3 = App.Player;
            decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = this.rateReward.flags, hi = this.rateReward.flags, lo = this.rateReward.lo, mid = this.rateReward.lo});
            this.rateReward = val_4.flags;
            Player val_5 = App.Player;
            this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = this.rateReward, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        }
        
        if(this.coinsAnim != 0)
        {
                return;
        }
        
        this.Close();
    }
    private void OnClick_Continue()
    {
        this.Close();
    }
    private void OnCoinsAnimFinished()
    {
        this.Close();
    }
    protected void Close()
    {
        var val_3;
        if(this.didReview == false)
        {
            goto label_1;
        }
        
        val_3 = null;
        val_3 = null;
        if(App.game != 16)
        {
            goto label_7;
        }
        
        label_1:
        MonoSingleton<WGReviewManager>.Instance.HandleReviewSelected(rating:  0, forceTracking:  false);
        label_7:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGReviewPopup()
    {
        this.currentStarRating = 4;
    }

}
