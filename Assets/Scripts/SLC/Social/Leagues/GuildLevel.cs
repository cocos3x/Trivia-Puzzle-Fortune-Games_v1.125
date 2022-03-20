using UnityEngine;

namespace SLC.Social.Leagues
{
    public class GuildLevel
    {
        // Fields
        public int MaximumMembers;
        public int RequiredCoinSupport;
        
        // Properties
        public decimal CoinSupportRequired { get; }
        
        // Methods
        public GuildLevel(int maxMembers, int requiredSupport)
        {
            this.MaximumMembers = maxMembers;
            this.RequiredCoinSupport = requiredSupport;
        }
        public decimal get_CoinSupportRequired()
        {
            return System.Decimal.op_Implicit(value:  this.RequiredCoinSupport);
        }
    
    }

}
