using UnityEngine;

namespace SLC.Social.Leagues
{
    public class ClubLevelContribution_Window : FrameSkipper
    {
        // Fields
        private UnityEngine.UI.Text clubNameText;
        private UnityEngine.UI.Text clubLevelText;
        private UnityEngine.UI.Slider clubLevelSlider;
        protected UnityEngine.UI.Text progressRemainingText;
        private UnityEngine.UI.Text[] choiceButtonsText;
        private UnityEngine.UI.Text contributeButtonLabel;
        private UnityEngine.GameObject contributeButtonAmountGroup;
        private UnityEngine.UI.Text contributeButtonAmount;
        private UnityEngine.GameObject contributeButtonTimeGroup;
        private UnityEngine.UI.Text contributeButtonTime;
        protected UGUINetworkedButton contributeButton;
        private UnityEngine.GameObject contributeButtonOverlay;
        private UnityEngine.GameObject contributeLowCreditsError;
        protected UnityEngine.GameObject contributeCooldownError;
        protected UnityEngine.GameObject contributeMaxLevelError;
        protected UnityEngine.GameObject contributeAnimParent;
        private UnityEngine.UI.Button[] selectionButtons;
        private CoinCurrencyCollectAnimationInstantiator coinsGainedAnim;
        private UnityEngine.CanvasGroup choicesCanvasGroup;
        protected int selectedIndex;
        private bool _isAnimating;
        protected bool _isAwaitingResponse;
        protected bool _isAwaitingPing;
        protected System.Decimal[] contributionValues;
        protected System.DateTime lastDonationTime;
        private decimal ContributionAmountFractional;
        protected decimal ContributionAmountCredits;
        private int ContributionIndex;
        
        // Properties
        public int SelectedIndex { get; set; }
        private bool isAnimating { get; set; }
        
        // Methods
        public int get_SelectedIndex()
        {
            return (int)this.selectedIndex;
        }
        public void set_SelectedIndex(int value)
        {
            this.selectedIndex = value;
            GameEcon val_1 = App.getGameEcon;
            string val_2 = this.contributionValues[value][32].ToString(format:  val_1.numberFormatInt);
            this.contributeLowCreditsError.SetActive(value:  false);
        }
        private bool get_isAnimating()
        {
            return (bool)this._isAnimating;
        }
        private void set_isAnimating(bool value)
        {
            this._isAnimating = value;
        }
        protected virtual void Start()
        {
            CoinCurrencyCollectAnimationInstantiator val_9;
            NotificationCenter val_1 = NotificationCenter.DefaultCenter;
            val_1.AddObserver(observer:  this, name:  2.ToString());
            val_1.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.ClubLevelContribution_Window::ContributeButton_OnInitialClick()));
            System.Delegate val_5 = System.Delegate.Combine(a:  this.contributeButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.ClubLevelContribution_Window::ContributeButton_OnConnectionClick(bool result)));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_9;
            }
            
            }
            
            this.contributeButton.OnConnectionClick = val_5;
            val_9 = this.coinsGainedAnim;
            System.Action val_6 = new System.Action(object:  this, method:  System.Void SLC.Social.Leagues.ClubLevelContribution_Window::ConcludeAnimation());
            mem2[0] = val_6;
            bool val_7 = UnityEngine.Object.op_Inequality(x:  val_6, y:  0);
            if(val_7 == false)
            {
                    return;
            }
            
            val_7.RemoveAllListeners();
            UnityEngine.Events.UnityAction val_8 = null;
            val_9 = val_8;
            val_8 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.ClubLevelContribution_Window::<Start>b__32_0());
            val_6.AddListener(call:  val_8);
            return;
            label_9:
        }
        protected void ContributeButton_OnInitialClick()
        {
            this._isAwaitingPing = true;
            this.SetContributeButtonState(state:  3);
        }
        protected void ContributeButton_OnConnectionClick(bool result)
        {
            if(result != false)
            {
                    this._isAwaitingPing = false;
                this.OnContributeButtonClick();
                return;
            }
            
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance.ShowConnectionRequired();
        }
        private void OnMyGuildUpdate()
        {
            if(this._isAwaitingResponse != false)
            {
                    return;
            }
            
            this.RefreshUI(onEnable:  false);
        }
        private void OnEnable()
        {
            this.RefreshUI(onEnable:  true);
        }
        protected virtual void SetSliderValue(float val, bool instant = False)
        {
            float val_15;
            SLC.Social.Leagues.ClubLevelContribution_Window val_16;
            val_15 = val;
            val_16 = this;
            if(instant != true)
            {
                    if(val <= val_15)
            {
                goto label_3;
            }
            
            }
            
            val_16 = ???;
            val_15 = ???;
            goto typeof(UnityEngine.UI.Slider).__il2cppRuntimeField_420;
            label_3:
            ClubLevelContribution_Window.<>c__DisplayClass37_0 val_1 = new ClubLevelContribution_Window.<>c__DisplayClass37_0();
            .<>4__this = val_16;
            .progress = val_15;
            DG.Tweening.Tweener val_14 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void ClubLevelContribution_Window.<>c__DisplayClass37_0::<SetSliderValue>b__0(float x)), startValue:  val_15, endValue:  val_15, duration:  0.3f), ease:  1), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void ClubLevelContribution_Window.<>c__DisplayClass37_0::<SetSliderValue>b__1())), autoKillOnCompletion:  true);
        }
        protected void RefreshUI(bool onEnable = False)
        {
            int val_22;
            System.Decimal[] val_23;
            val_22 = 0;
            System.DateTime val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile.GetContributedAt;
            val_23 = this.contributionValues;
            this.lastDonationTime = val_3;
            if(val_23 == null)
            {
                    val_22 = this.selectionButtons.Length;
                decimal[] val_4 = new decimal[0];
                val_23 = val_4;
                this.contributionValues = val_4;
            }
            
            var val_27 = 0;
            label_19:
            if(0 >= val_4.Length)
            {
                goto label_8;
            }
            
            decimal val_5 = SLC.Social.Leagues.LeaguesEconomy.GetSupportOption(index:  0);
            val_23[val_27] = val_5;
            val_23[val_27] = val_5.lo;
            var val_7 = (0 + 1) - 1;
            UnityEngine.UI.Text val_24 = this.choiceButtonsText[0];
            decimal val_8 = new System.Decimal(value:  232);
            string val_9 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = this.contributionValues[val_27], hi = this.contributionValues[val_27], lo = this.contributionValues[val_27], mid = this.contributionValues[val_27]}, maxSigFigs:  3, round:  true, useColor:  true, maxValueWithoutAbbr:  new System.Decimal() {flags = val_8.flags, hi = val_8.flags, lo = val_8.lo, mid = val_8.lo}, useRichText:  true, withSpaces:  false);
            val_27 = val_27 + 16;
            if(this.contributionValues != null)
            {
                goto label_19;
            }
            
            label_8:
            SLC.Social.Leagues.Guild val_11 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            SLC.Social.Leagues.Guild val_13 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            string val_14 = val_13.guildLevel.ToString();
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.Level != SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.NextLevel)
            {
                    bool val_21 = onEnable;
            }
            else
            {
                    bool val_22 = onEnable;
                string val_23 = Localization.Localize(key:  "max_club_level", defaultValue:  "Maximum Club Level!", useSingularKey:  false);
                this.SetContributeButtonState(state:  0);
            }
            
            this.contributeLowCreditsError.SetActive(value:  false);
            this.contributeCooldownError.SetActive(value:  false);
            this.contributeMaxLevelError.SetActive(value:  false);
        }
        protected virtual void SetProgressRemainingText(bool onEnable)
        {
            int val_27;
            object val_28;
            decimal val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.Level.CoinSupportRequired;
            decimal val_8 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.NextLevel.CoinSupportRequired;
            val_27 = val_8.flags;
            decimal val_11 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.GetLeagueContributedCoins;
            SLC.Social.Leagues.Guild val_13 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            decimal val_16 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.ProgressThisLevel(currentLevel:  val_15.guildLevel);
            decimal val_17 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, d2:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_16.lo, mid = val_16.mid});
            decimal val_18 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid}, d2:  new System.Decimal() {flags = val_27, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid});
            float val_19 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_18.flags, hi = val_18.hi, lo = val_18.lo, mid = val_18.mid});
            bool val_20 = onEnable;
            if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid}, d2:  new System.Decimal() {flags = val_27, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid})) != false)
            {
                    decimal val_23 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_27, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, d2:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid});
                val_27 = val_23.flags;
                decimal val_24 = new System.Decimal(value:  232);
                val_28 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_27, hi = val_23.hi, lo = val_23.lo, mid = val_23.mid}, maxSigFigs:  3, round:  true, useColor:  true, maxValueWithoutAbbr:  new System.Decimal() {flags = val_24.flags, hi = val_24.flags, lo = val_24.lo, mid = val_24.lo}, useRichText:  true, withSpaces:  false);
            }
            else
            {
                    val_28 = "0";
            }
            
            string val_26 = System.String.Format(format:  Localization.Localize(key:  "num_coins_remaining", defaultValue:  "{0} Coins Remaining", useSingularKey:  false), arg0:  val_28);
        }
        protected override void UpdateLogic()
        {
            var val_19;
            if(this._isAwaitingResponse != false)
            {
                    return;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.Level == SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.NextLevel)
            {
                    return;
            }
            
            val_19 = null;
            val_19 = null;
            System.DateTime val_7 = DateTimeCheat.UtcNow;
            System.TimeSpan val_8 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_7.dateData}, d2:  new System.DateTime() {dateData = this.lastDonationTime});
            System.TimeSpan val_9 = System.TimeSpan.op_Subtraction(t1:  new System.TimeSpan() {_ticks = SLC.Social.Leagues.LeaguesEconomy.AllowedDonationInterval}, t2:  new System.TimeSpan() {_ticks = val_8._ticks});
            if((System.TimeSpan.op_GreaterThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_9._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
            {
                    this.SetContributeButtonState(state:  2);
                string val_18 = System.String.Format(format:  "{0}:{1}:{2}", arg0:  System.Math.Truncate(d:  val_9._ticks.TotalHours).ToString(format:  "00"), arg1:  val_9._ticks.Minutes.ToString(format:  "00"), arg2:  val_9._ticks.Seconds.ToString(format:  "00"));
                return;
            }
            
            this.SetContributeButtonState(state:  1);
        }
        protected virtual bool CheckAllowedAndShowError()
        {
            var val_17;
            long val_18;
            var val_19;
            var val_20;
            val_17 = null;
            val_17 = null;
            System.DateTime val_1 = DateTimeCheat.UtcNow;
            System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = this.lastDonationTime});
            val_18 = val_2._ticks;
            System.TimeSpan val_3 = System.TimeSpan.op_Subtraction(t1:  new System.TimeSpan() {_ticks = SLC.Social.Leagues.LeaguesEconomy.AllowedDonationInterval}, t2:  new System.TimeSpan() {_ticks = val_18});
            if((System.TimeSpan.op_GreaterThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_3._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) == false)
            {
                goto label_9;
            }
            
            label_42:
            this.contributeCooldownError.SetActive(value:  true);
            return false;
            label_9:
            Player val_5 = App.Player;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = this.contributionValues[this.selectedIndex], hi = this.contributionValues[this.selectedIndex], lo = this.contributionValues[this.selectedIndex], mid = this.contributionValues[this.selectedIndex]}, d2:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = 1152921504622821376})) != false)
            {
                    val_19 = null;
                val_19 = null;
                PurchaseProxy.currentPurchasePoint = 20;
                val_20 = null;
                val_20 = null;
                val_18 = ClubLevelContribution_Window.<>c.<>9__41_0;
                if(val_18 == null)
            {
                    System.Action val_9 = null;
                val_18 = val_9;
                val_9 = new System.Action(object:  ClubLevelContribution_Window.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ClubLevelContribution_Window.<>c::<CheckAllowedAndShowError>b__41_0());
                ClubLevelContribution_Window.<>c.<>9__41_0 = val_18;
            }
            
                MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  val_9);
                SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
                return false;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.Level != SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.NextLevel)
            {
                    return false;
            }
            
            if(this.contributeMaxLevelError != null)
            {
                goto label_42;
            }
            
            throw new NullReferenceException();
        }
        public void OnContributeButtonClick()
        {
            if(this._isAnimating == true)
            {
                    return;
            }
            
            if(this._isAwaitingResponse == true)
            {
                    return;
            }
            
            decimal val_3 = this.contributionValues[(long)this.selectedIndex];
            decimal val_4 = this.contributionValues[(long)this.selectedIndex];
            this.ContributionIndex = this.selectedIndex;
            this.ContributionAmountFractional = val_3;
            mem[1152921519725620504] = val_4;
            this.ContributionAmountCredits = val_3;
            mem[1152921519725620520] = val_4;
            this.contributeLowCreditsError.SetActive(value:  false);
            this.contributeCooldownError.SetActive(value:  false);
            this.contributeMaxLevelError.SetActive(value:  false);
            if((this & 1) == 0)
            {
                    return;
            }
            
            SLC.Social.Leagues.LeaguesManager.DAO.ContributeCoins(coinsToContribute:  new System.Decimal() {flags = this.ContributionAmountFractional, hi = this.ContributionAmountFractional, lo = X21, mid = X21}, resultAction:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.ClubLevelContribution_Window::SuccessfulContribution(bool success)));
            this._isAnimating = true;
            this._isAwaitingResponse = true;
        }
        private void SuccessfulContribution(bool success)
        {
            if(this == 0)
            {
                    return;
            }
            
            if(this.gameObject == 0)
            {
                    return;
            }
            
            if(this.gameObject.activeSelf == false)
            {
                    return;
            }
            
            bool val_6 = success;
            UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this);
        }
        protected virtual System.Collections.IEnumerator DeferredUpdate(bool success)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .success = success;
            return (System.Collections.IEnumerator)new ClubLevelContribution_Window.<DeferredUpdate>d__47();
        }
        protected void ConcludeAnimation()
        {
            this._isAnimating = false;
        }
        private void OnDisable()
        {
            this.CancelInvoke();
            this._isAnimating = false;
            this._isAwaitingResponse = false;
        }
        private void SetContributeButtonState(SLC.Social.Leagues.ClubLevelContribution_Window.ContributeState state)
        {
            if(this._isAwaitingResponse != true)
            {
                    if(this._isAwaitingPing == false)
            {
                goto label_2;
            }
            
            }
            
            string val_1 = Localization.Localize(key:  "contribute_upper", defaultValue:  "CONTRIBUTE", useSingularKey:  false);
            this.contributeCooldownError.SetActive(value:  false);
            this.contributeButton.interactable = false;
            this.contributeButtonOverlay.SetActive(value:  true);
            this.contributeButtonTimeGroup.SetActive(value:  false);
            GameEcon val_2 = App.getGameEcon;
            string val_3 = this.contributionValues[this.selectedIndex][32].ToString(format:  val_2.numberFormatInt);
            this.contributeButtonAmountGroup.SetActive(value:  true);
            return;
            label_2:
            if(state > 3)
            {
                    return;
            }
            
            var val_9 = 32556348 + (state) << 2;
            val_9 = val_9 + 32556348;
            goto (32556348 + (state) << 2 + 32556348);
        }
        public ClubLevelContribution_Window()
        {
            var val_1;
            this.selectedIndex = 1;
            val_1 = null;
            val_1 = null;
            this.ContributionIndex = 0;
            this.lastDonationTime = System.DateTime.MinValue;
        }
        private void <Start>b__32_0()
        {
            var val_5;
            var val_6;
            System.Action val_8;
            val_5 = null;
            val_5 = null;
            PurchaseProxy.currentPurchasePoint = 20;
            val_6 = null;
            val_6 = null;
            val_8 = ClubLevelContribution_Window.<>c.<>9__32_1;
            if(val_8 == null)
            {
                    System.Action val_3 = null;
                val_8 = val_3;
                val_3 = new System.Action(object:  ClubLevelContribution_Window.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ClubLevelContribution_Window.<>c::<Start>b__32_1());
                ClubLevelContribution_Window.<>c.<>9__32_1 = val_8;
            }
            
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  val_3);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
    
    }

}
