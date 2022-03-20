using UnityEngine;

namespace SLC.Social.Leagues
{
    public class ClubLevelContribution_WindowGems : ClubLevelContribution_Window
    {
        // Fields
        private GemsCollectAnimationInstantiator gemGainedAnim;
        
        // Methods
        protected override void Start()
        {
            GemsCollectAnimationInstantiator val_10;
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  2.ToString());
            1384122505.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.ClubLevelContribution_Window::ContributeButton_OnInitialClick()));
            System.Delegate val_5 = System.Delegate.Combine(a:  X23 + 448, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.ClubLevelContribution_Window::ContributeButton_OnConnectionClick(bool result)));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_9;
            }
            
            }
            
            mem2[0] = val_5;
            val_10 = this.gemGainedAnim;
            System.Action val_6 = new System.Action(object:  this, method:  System.Void SLC.Social.Leagues.ClubLevelContribution_Window::ConcludeAnimation());
            mem2[0] = val_6;
            bool val_7 = UnityEngine.Object.op_Inequality(x:  val_6, y:  0);
            if(val_7 == false)
            {
                    return;
            }
            
            val_7.RemoveAllListeners();
            val_10.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.ClubLevelContribution_WindowGems::<Start>b__1_0()));
            val_6.gameObject.SetActive(value:  true);
            return;
            label_9:
        }
        protected override void SetProgressRemainingText(bool onEnable)
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
            this.SetSliderValue(val:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_18.flags, hi = val_18.hi, lo = val_18.lo, mid = val_18.mid}), instant:  onEnable);
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
            
            string val_26 = System.String.Format(format:  Localization.Localize(key:  "num_gems_remaining", defaultValue:  "{0} Gems Remaining", useSingularKey:  false), arg0:  val_28);
        }
        protected override bool CheckAllowedAndShowError()
        {
            var val_19;
            long val_20;
            var val_21;
            var val_22;
            val_19 = null;
            val_19 = null;
            System.DateTime val_1 = DateTimeCheat.UtcNow;
            System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = X21});
            val_20 = val_2._ticks;
            System.TimeSpan val_3 = System.TimeSpan.op_Subtraction(t1:  new System.TimeSpan() {_ticks = SLC.Social.Leagues.LeaguesEconomy.AllowedDonationInterval}, t2:  new System.TimeSpan() {_ticks = val_20});
            bool val_4 = System.TimeSpan.op_GreaterThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_3._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero});
            if(val_4 == false)
            {
                goto label_9;
            }
            
            label_42:
            val_4.SetActive(value:  true);
            return false;
            label_9:
            Player val_5 = App.Player;
            decimal val_6 = System.Decimal.op_Implicit(value:  val_5._gems);
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = (System.TimeSpan.__il2cppRuntimeField_static_fields + (System.TimeSpan.__il2cppRuntimeField_cctor_finished) << 4) + 32, hi = (System.TimeSpan.__il2cppRuntimeField_static_fields + (System.TimeSpan.__il2cppRuntimeField_cctor_finished) << 4) + 32, lo = (System.TimeSpan.__il2cppRuntimeField_static_fields + (System.TimeSpan.__il2cppRuntimeField_cctor_finished) << 4) + 32 + 8, mid = (System.TimeSpan.__il2cppRuntimeField_static_fields + (System.TimeSpan.__il2cppRuntimeField_cctor_finished) << 4) + 32 + 8}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid})) != false)
            {
                    val_21 = null;
                val_21 = null;
                PurchaseProxy.currentPurchasePoint = 124;
                GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
                val_22 = null;
                val_22 = null;
                val_20 = ClubLevelContribution_WindowGems.<>c.<>9__3_0;
                if(val_20 == null)
            {
                    System.Action val_11 = null;
                val_20 = val_11;
                val_11 = new System.Action(object:  ClubLevelContribution_WindowGems.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ClubLevelContribution_WindowGems.<>c::<CheckAllowedAndShowError>b__3_0());
                ClubLevelContribution_WindowGems.<>c.<>9__3_0 = val_20;
            }
            
                MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  val_11);
                SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
                return false;
            }
            
            SLC.Social.Leagues.GuildLevel val_18 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.NextLevel;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.Level != val_18)
            {
                    return false;
            }
            
            if(val_18 != null)
            {
                goto label_42;
            }
            
            throw new NullReferenceException();
        }
        protected override System.Collections.IEnumerator DeferredUpdate(bool success)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .success = success;
            return (System.Collections.IEnumerator)new ClubLevelContribution_WindowGems.<DeferredUpdate>d__4();
        }
        public ClubLevelContribution_WindowGems()
        {
        
        }
        private void <Start>b__1_0()
        {
            var val_5;
            var val_6;
            System.Action val_8;
            val_5 = null;
            val_5 = null;
            PurchaseProxy.currentPurchasePoint = 124;
            val_6 = null;
            val_6 = null;
            val_8 = ClubLevelContribution_WindowGems.<>c.<>9__1_1;
            if(val_8 == null)
            {
                    System.Action val_3 = null;
                val_8 = val_3;
                val_3 = new System.Action(object:  ClubLevelContribution_WindowGems.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ClubLevelContribution_WindowGems.<>c::<Start>b__1_1());
                ClubLevelContribution_WindowGems.<>c.<>9__1_1 = val_8;
            }
            
            MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  val_3);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
    
    }

}
