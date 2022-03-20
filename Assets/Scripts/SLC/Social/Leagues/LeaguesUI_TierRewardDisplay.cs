using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_TierRewardDisplay : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text rankText;
        private UnityEngine.UI.Text rewardText;
        private SLC.Social.Leagues.LeaguesUIGuildTierDisplay leagueText;
        private UnityEngine.GameObject[] upArrows;
        private UnityEngine.GameObject[] downArrows;
        
        // Methods
        public void UpdateFromLeagueTier(int rank, int tier)
        {
            UnityEngine.UI.Text val_20;
            UnityEngine.UI.Text val_21;
            int val_22;
            int val_23;
            val_20 = this;
            SLC.Social.Leagues.SeasonReward val_1 = SLC.Social.Leagues.LeaguesEconomy.GetSeasonRewardForTier(tier:  tier);
            val_21 = this.rankText;
            bool val_2 = UnityEngine.Object.op_Implicit(exists:  val_21);
            this.rankText.ShowArrows(arrows:  this.upArrows, active:  false);
            this.rankText.ShowArrows(arrows:  this.downArrows, active:  false);
            if((rank - 1) <= 6)
            {
                    var val_20 = 32561508 + ((rank - 1)) << 2;
                val_20 = val_20 + 32561508;
            }
            else
            {
                    val_23 = 0;
                val_22 = 0;
                if((UnityEngine.Object.op_Implicit(exists:  this.rewardText)) == false)
            {
                    return;
            }
            
                val_20 = this.rewardText;
                decimal val_18 = new System.Decimal(value:  232);
                string val_19 = MetricSystem.Abbreviate(number:  new System.Decimal() {hi = val_14.hi, mid = val_14.mid}, maxSigFigs:  3, round:  true, useColor:  true, maxValueWithoutAbbr:  new System.Decimal() {flags = val_18.flags, hi = val_18.flags, lo = val_18.lo, mid = val_18.lo}, useRichText:  true, withSpaces:  false);
            }
        
        }
        public void ShowArrows(UnityEngine.GameObject[] arrows, bool active)
        {
            if(arrows == null)
            {
                    return;
            }
            
            if(arrows.Length < 1)
            {
                    return;
            }
            
            var val_2 = 0;
            do
            {
                1152921507173703552.SetActive(value:  active);
                val_2 = val_2 + 1;
            }
            while(val_2 < arrows.Length);
        
        }
        public LeaguesUI_TierRewardDisplay()
        {
        
        }
    
    }

}
