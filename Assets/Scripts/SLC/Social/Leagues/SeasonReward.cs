using UnityEngine;

namespace SLC.Social.Leagues
{
    public class SeasonReward : EncodableModel
    {
        // Fields
        public string cat1;
        public string cat2;
        public string cat3;
        public string cat4;
        
        // Properties
        public decimal GetCategory1Reward { get; }
        public decimal GetCategory2Reward { get; }
        public decimal GetCategory3Reward { get; }
        public decimal GetCategory4Reward { get; }
        
        // Methods
        public decimal get_GetCategory1Reward()
        {
            return System.Decimal.Parse(s:  this.cat1, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        public decimal get_GetCategory2Reward()
        {
            return System.Decimal.Parse(s:  this.cat2, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        public decimal get_GetCategory3Reward()
        {
            return System.Decimal.Parse(s:  this.cat3, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        public decimal get_GetCategory4Reward()
        {
            return System.Decimal.Parse(s:  this.cat4, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        public decimal GetRewardFromRank(int rank)
        {
            if(rank <= 1)
            {
                    return this.GetCategory1Reward;
            }
            
            if(rank <= 4)
            {
                    return this.GetCategory2Reward;
            }
            
            if(rank > 10)
            {
                    return this.GetCategory4Reward;
            }
            
            return this.GetCategory3Reward;
        }
        public SeasonReward()
        {
        
        }
    
    }

}
