using UnityEngine;

namespace SLC.Social.Leagues
{
    public class SeasonResult_Window : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text seasonNumber;
        private SLC.Social.Leagues.LeaguesUIGuildTierDisplay tierText;
        private UnityEngine.UI.Text rewardAmount;
        private UnityEngine.UI.Button collectButton;
        private SLC.Social.Leagues.LeaguesUIGuildListView listView;
        private GridCoinCollectAnimationInstantiator coinsAnimControl;
        private GemsCollectAnimationInstantiator gemAnimControl;
        private bool isShowing;
        private decimal reward;
        
        // Methods
        private void Awake()
        {
            System.Delegate val_8;
            this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.SeasonResult_Window::OnCollectClicked()));
            this.listView.OnGuildListFinishedUIUpdate = new System.Action<UnityEngine.UI.ScrollRect>(object:  this, method:  System.Void SLC.Social.Leagues.SeasonResult_Window::OnListViewUpdate(UnityEngine.UI.ScrollRect scrollRect));
            System.Action val_3 = null;
            val_8 = val_3;
            val_3 = new System.Action(object:  this, method:  System.Void SLC.Social.Leagues.SeasonResult_Window::OnCoinsAnimFinished());
            System.Delegate val_4 = System.Delegate.Combine(a:  this.coinsAnimControl.OnCompleteCallback, b:  val_3);
            if(val_4 != null)
            {
                    if(null != null)
            {
                goto label_12;
            }
            
            }
            
            this.coinsAnimControl.OnCompleteCallback = val_4;
            if(this.gemAnimControl == 0)
            {
                    return;
            }
            
            System.Action val_6 = null;
            val_8 = val_6;
            val_6 = new System.Action(object:  this, method:  System.Void SLC.Social.Leagues.SeasonResult_Window::OnCoinsAnimFinished());
            System.Delegate val_7 = System.Delegate.Combine(a:  this.gemAnimControl, b:  val_6);
            if(val_7 != null)
            {
                    if(null != null)
            {
                goto label_12;
            }
            
            }
            
            mem2[0] = val_7;
            return;
            label_12:
        }
        private void OnListViewUpdate(UnityEngine.UI.ScrollRect scrollRect)
        {
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            if(val_1.LastSeasonGuildRanking < 2)
            {
                    if(scrollRect != null)
            {
                goto label_6;
            }
            
            }
            
            SLC.Social.Leagues.LeaguesDataController val_2 = SLC.Social.Leagues.LeaguesManager.DAO;
            SLC.Social.Leagues.LeaguesDataController val_3 = SLC.Social.Leagues.LeaguesManager.DAO;
            System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_5 = val_3.LastSeasonGuildRanking;
            float val_6 = (float)val_2.LastSeasonRank - 1;
            val_5 = val_5 - 1;
            val_6 = val_6 / (float)val_5;
            val_6 = 1f - val_6;
            label_6:
            scrollRect.verticalNormalizedPosition = val_6;
        }
        public void Show()
        {
            var val_17;
            int val_18;
            if(this.isShowing != false)
            {
                    return;
            }
            
            this.isShowing = true;
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            this.reward = val_1.SeasonRewardAmount;
            GameEcon val_2 = App.getGameEcon;
            string val_3 = this.reward.ToString(format:  val_2.numberFormatInt);
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_10;
            }
            
            SLC.Social.Leagues.LeaguesDataController val_6 = SLC.Social.Leagues.LeaguesManager.DAO;
            if((val_6.LastSeasonRank & 2147483648) != 0)
            {
                goto label_14;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO != null)
            {
                goto label_17;
            }
            
            label_10:
            SLC.Social.Leagues.LeaguesDataController val_8 = SLC.Social.Leagues.LeaguesManager.DAO;
            mem2[0] = 0;
            val_8.SeasonRewardAmount = 0m;
            UnityEngine.GameObject val_9 = this.gameObject;
            val_17 = 0;
            goto label_23;
            label_14:
            SLC.Social.Leagues.Guild val_11 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            label_17:
            SLC.Social.Leagues.LeaguesDataController val_12 = SLC.Social.Leagues.LeaguesManager.DAO;
            if((val_12.LastSeasonTier & 2147483648) == 0)
            {
                    SLC.Social.Leagues.LeaguesDataController val_13 = SLC.Social.Leagues.LeaguesManager.DAO;
                val_18 = val_13.LastSeasonTier;
            }
            else
            {
                    SLC.Social.Leagues.Guild val_15 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                val_18 = val_15.tier;
            }
            
            this.tierText.UpdateTierUI(guildTier:  val_18);
            this.collectButton.interactable = true;
            val_17 = 1;
            label_23:
            this.gameObject.SetActive(value:  true);
        }
        private void OnCollectClicked()
        {
            string val_32;
            decimal val_33;
            var val_34;
            var val_36;
            var val_37;
            int val_38;
            var val_39;
            this.collectButton.interactable = false;
            SLC.Social.Leagues.LeaguesTracker.TrackSeasonRollover();
            GameBehavior val_1 = App.getBehavior;
            if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
            {
                    val_32 = "Leagues Season Reward";
                App.Player.AddCredits(amount:  new System.Decimal() {flags = this.reward, hi = this.reward}, source:  val_32, subSource:  0, externalParams:  0, doTrack:  true);
            }
            else
            {
                    App.Player.AddGems(amount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = X23, mid = X23}), source:  "Leagues Season Reward", subsource:  0);
                Player val_5 = App.Player;
                val_32 = "Gems";
                val_5.TrackNonCoinReward(source:  "Leagues Season Reward", subSource:  0, rewardType:  val_32, rewardAmount:  this.reward.ToString(), additionalParams:  0);
            }
            
            SLC.Social.Leagues.LeaguesDataController val_7 = SLC.Social.Leagues.LeaguesManager.DAO;
            mem2[0] = 0;
            val_7.SeasonRewardAmount = 0m;
            val_34 = null;
            val_34 = null;
            if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_5, mid = val_5}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
            {
                    val_36 = null;
                val_36 = null;
                if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_5, mid = val_5}, d2:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0})) != false)
            {
                    GameBehavior val_10 = App.getBehavior;
                if(((val_10.<metaGameBehavior>k__BackingField) & 1) != 0)
            {
                    Player val_11 = App.Player;
                val_33 = val_11._credits;
                decimal val_12 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_33, hi = val_33, lo = "Leagues Season Reward"}, d2:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_5, mid = val_5});
                Player val_13 = App.Player;
                if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, d2:  new System.Decimal() {flags = val_13._credits, hi = val_13._credits, lo = val_5, mid = val_5})) != false)
            {
                    Player val_15 = App.Player;
                decimal val_16 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_15._credits, hi = val_15._credits, lo = "Leagues Season Reward"}, d2:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = -2047418496, mid = 268435459});
                Player val_17 = App.Player;
                this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_16.lo, mid = val_16.mid}, toValue:  new System.Decimal() {flags = val_17._credits, hi = val_17._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
                return;
            }
            
            }
            
            }
            
            }
            
            val_37 = null;
            val_37 = null;
            if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_5, mid = val_5}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
            {
                    val_39 = null;
                val_39 = null;
                if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_5, mid = val_5}, d2:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0})) != false)
            {
                    Player val_20 = App.Player;
                decimal val_21 = System.Decimal.op_Implicit(value:  val_20._gems);
                decimal val_22 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_21.flags, hi = val_21.hi, lo = val_21.lo, mid = val_21.mid}, d2:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
                val_38 = val_22.lo;
                Player val_23 = App.Player;
                decimal val_24 = System.Decimal.op_Implicit(value:  val_23._gems);
                if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = val_22.flags, hi = val_22.hi, lo = val_38, mid = val_22.mid}, d2:  new System.Decimal() {flags = val_24.flags, hi = val_24.hi, lo = val_24.lo, mid = val_24.mid})) != false)
            {
                    Player val_26 = App.Player;
                decimal val_27 = System.Decimal.op_Implicit(value:  val_26._gems);
                decimal val_28 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_27.flags, hi = val_27.hi, lo = val_27.lo, mid = val_27.mid}, d2:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_24.lo, mid = val_24.mid});
                Player val_30 = App.Player;
                decimal val_31 = System.Decimal.op_Implicit(value:  val_30._gems);
                this.gemAnimControl.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_28.flags, hi = val_28.hi, lo = val_28.lo, mid = val_28.mid}), toValue:  new System.Decimal() {flags = val_31.flags, hi = val_31.hi, lo = val_31.lo, mid = val_31.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
                return;
            }
            
            }
            
            }
            
            this.OnCoinsAnimFinished();
        }
        private void OnCoinsAnimFinished()
        {
            SLC.Social.Leagues.LeaguesWindowManager val_2 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.SeasonBegin_Window>(showNext:  true);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public SeasonResult_Window()
        {
        
        }
    
    }

}
