using UnityEngine;

namespace PrizeBalloon
{
    public class Econ
    {
        // Fields
        public bool FeatureEnabled;
        public int UnlockLevel;
        public int DailyLimit;
        public int TriggerCoinBalance;
        public int LapsedPayerDays;
        public int MinLevelsToCompletePerSession;
        public int BalloonOnScreenInSec;
        public int CooldownInSeconds;
        public static System.Collections.Generic.Dictionary<PrizeBalloon.PayerType, System.Collections.Generic.List<PrizeBalloon.CoinRewardChance>> CoinRewardsData;
        
        // Methods
        public Econ()
        {
            this.MinLevelsToCompletePerSession = 3;
            this.BalloonOnScreenInSec = 10;
            this.UnlockLevel = ;
            this.DailyLimit = ;
            this.TriggerCoinBalance = 21474836600;
            this.LapsedPayerDays = 5;
            this.CooldownInSeconds = 300;
        }
        private static Econ()
        {
            System.Collections.Generic.Dictionary<PrizeBalloon.PayerType, System.Collections.Generic.List<PrizeBalloon.CoinRewardChance>> val_1 = new System.Collections.Generic.Dictionary<PrizeBalloon.PayerType, System.Collections.Generic.List<PrizeBalloon.CoinRewardChance>>();
            System.Collections.Generic.List<PrizeBalloon.CoinRewardChance> val_2 = new System.Collections.Generic.List<PrizeBalloon.CoinRewardChance>();
            .Amount = 10;
            .Weight = 1;
            val_2.Add(item:  new PrizeBalloon.CoinRewardChance());
            .Amount = 15;
            .Weight = 2;
            val_2.Add(item:  new PrizeBalloon.CoinRewardChance());
            val_1.Add(key:  1, value:  val_2);
            System.Collections.Generic.List<PrizeBalloon.CoinRewardChance> val_5 = new System.Collections.Generic.List<PrizeBalloon.CoinRewardChance>();
            .Amount = 5;
            .Weight = 2;
            val_5.Add(item:  new PrizeBalloon.CoinRewardChance());
            .Amount = 10;
            .Weight = 1;
            val_5.Add(item:  new PrizeBalloon.CoinRewardChance());
            val_1.Add(key:  2, value:  val_5);
            PrizeBalloon.Econ.CoinRewardsData = val_1;
        }
    
    }

}
