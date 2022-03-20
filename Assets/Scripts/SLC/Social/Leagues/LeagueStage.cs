using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeagueStage : EncodableModel
    {
        // Fields
        public string coinsRequirement;
        public string coinsReward;
        public int pointsReward;
        
        // Properties
        public decimal GetCoinReq { get; set; }
        public decimal GetCoinReward { get; set; }
        
        // Methods
        public decimal get_GetCoinReq()
        {
            return System.Decimal.Parse(s:  this.coinsRequirement, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        public void set_GetCoinReq(decimal value)
        {
            this.coinsRequirement = value.flags.ToString();
        }
        public decimal get_GetCoinReward()
        {
            return System.Decimal.Parse(s:  this.coinsReward, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        public void set_GetCoinReward(decimal value)
        {
            this.coinsReward = value.flags.ToString();
        }
        public LeagueStage()
        {
        
        }
    
    }

}
