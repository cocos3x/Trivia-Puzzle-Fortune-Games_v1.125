using UnityEngine;
public class HotNSpicyEcon
{
    // Fields
    public HotNSpicyRewardData rewardData;
    public int unlockPlayerLevel;
    public int pointsGainPerAttack;
    public int pointsGainPerAttackBlocked;
    public int pointsGainPerRaid;
    public int pointsGainPerRaidPerfect;
    public int pointsGainPerHit3Symbols;
    public float avgPointPerSpinTier1;
    public float avgPointPerSpinTier2;
    public float avgPointPerSpinTier3;
    
    // Methods
    public HotNSpicyEcon(System.Collections.Generic.Dictionary<string, object> eventDataDict)
    {
        var val_56;
        this.unlockPlayerLevel = ;
        this.pointsGainPerAttack = ;
        this.pointsGainPerAttackBlocked = 17179869186;
        this.pointsGainPerRaid = 4;
        this.pointsGainPerRaidPerfect = 5;
        this.pointsGainPerHit3Symbols = 12;
        this.avgPointPerSpinTier1 = 5.1695f;
        this.avgPointPerSpinTier2 = 2.37344f;
        this.avgPointPerSpinTier3 = 0.3975f;
        this.rewardData = HotNSpicyEconDataHelper.ParseCSV();
        if(eventDataDict == null)
        {
                return;
        }
        
        val_56 = "economy";
        if((eventDataDict.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        if(eventDataDict.Item["economy"] == null)
        {
                return;
        }
        
        object val_4 = eventDataDict.Item["economy"];
        if(((val_4.ContainsKey(key:  "pc")) != false) && (val_4.Item["pc"] != null))
        {
                object val_7 = val_4.Item["pc"];
            if(((val_7.ContainsKey(key:  "atk")) != false) && (val_7.Item["atk"] != null))
        {
                if((System.Int32.TryParse(s:  val_7.Item["atk"], result: out  0)) != false)
        {
                this.pointsGainPerAttack = 0;
        }
        
        }
        
            if(((val_7.ContainsKey(key:  "atk_blckd")) != false) && (val_7.Item["atk_blckd"] != null))
        {
                if((System.Int32.TryParse(s:  val_7.Item["atk_blckd"], result: out  0)) != false)
        {
                this.pointsGainPerAttackBlocked = 0;
        }
        
        }
        
            if(((val_7.ContainsKey(key:  "raid")) != false) && (val_7.Item["raid"] != null))
        {
                if((System.Int32.TryParse(s:  val_7.Item["raid"], result: out  0)) != false)
        {
                this.pointsGainPerRaid = 0;
        }
        
        }
        
            if(((val_7.ContainsKey(key:  "pfct_raid")) != false) && (val_7.Item["pfct_raid"] != null))
        {
                if((System.Int32.TryParse(s:  val_7.Item["pfct_raid"], result: out  0)) != false)
        {
                this.pointsGainPerRaidPerfect = 0;
        }
        
        }
        
            if(((val_7.ContainsKey(key:  "hit_3")) != false) && (val_7.Item["hit_3"] != null))
        {
                if((System.Int32.TryParse(s:  val_7.Item["hit_3"], result: out  0)) != false)
        {
                this.pointsGainPerHit3Symbols = 0;
        }
        
        }
        
        }
        
        if(((val_4.ContainsKey(key:  "unlock_lvl")) != false) && (val_4.Item["unlock_lvl"] != null))
        {
                if((System.Int32.TryParse(s:  val_4.Item["unlock_lvl"], result: out  0)) != false)
        {
                this.unlockPlayerLevel = 0;
        }
        
        }
        
        val_56 = "avg_pps";
        if((val_4.ContainsKey(key:  "avg_pps")) == false)
        {
                return;
        }
        
        if(val_4.Item["avg_pps"] == null)
        {
                return;
        }
        
        object val_40 = val_4.Item["avg_pps"];
        if(((val_40.ContainsKey(key:  "t1")) != false) && (val_40.Item["t1"] != null))
        {
                if((System.Single.TryParse(s:  val_40.Item["t1"], result: out  float val_44 = -221.363f)) != false)
        {
                this.avgPointPerSpinTier1 = 0f;
        }
        
        }
        
        if(((val_40.ContainsKey(key:  "t2")) != false) && (val_40.Item["t2"] != null))
        {
                if((System.Single.TryParse(s:  val_40.Item["t2"], result: out  float val_49 = -221.3629f)) != false)
        {
                this.avgPointPerSpinTier2 = 0f;
        }
        
        }
        
        val_56 = "t3";
        if((val_40.ContainsKey(key:  "t3")) == false)
        {
                return;
        }
        
        if(val_40.Item["t3"] == null)
        {
                return;
        }
        
        if((System.Single.TryParse(s:  val_40.Item["t3"], result: out  float val_54 = -221.3629f)) == false)
        {
                return;
        }
        
        this.avgPointPerSpinTier3 = 0f;
    }
    public float GetAveragePointPerSpinThreshold(int playerTier)
    {
        if(playerTier == 3)
        {
                return (float)this.avgPointPerSpinTier3;
        }
        
        if(playerTier == 2)
        {
                return (float)this.avgPointPerSpinTier2;
        }
        
        if(playerTier != 1)
        {
                return -1f;
        }
        
        return (float)this.avgPointPerSpinTier1;
    }
    private System.Collections.Generic.List<RESEventRewardData> GetRewardsList(int playerTier)
    {
        System.Collections.Generic.List<RESEventRewardData> val_2;
        if()
        {
                if(this.rewardData.rewardListTier.Length >= playerTier)
        {
            goto label_3;
        }
        
        }
        
        val_2 = 0;
        return val_2;
        label_3:
        val_2 = this.rewardData.rewardListTier[playerTier - 1];
        return val_2;
    }
    private System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>> GetCoinsList(int playerTier)
    {
        System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>> val_2;
        if()
        {
                if(this.rewardData.coinValuesTiers.Length >= playerTier)
        {
            goto label_3;
        }
        
        }
        
        val_2 = 0;
        return val_2;
        label_3:
        val_2 = this.rewardData.coinValuesTiers[playerTier - 1];
        return val_2;
    }
    public int GetTotalCollectableRewards(int playerTier)
    {
        var val_3;
        if((this.GetRewardsList(playerTier:  playerTier)) != null)
        {
                System.Collections.Generic.List<RESEventRewardData> val_2 = this.GetRewardsList(playerTier:  playerTier);
            return (int)val_3;
        }
        
        val_3 = 0;
        return (int)val_3;
    }
    public decimal GetGrandPrizeSpinAmount(int playerTier)
    {
        var val_3;
        var val_4;
        var val_5;
        bool val_3 = true;
        System.Collections.Generic.List<RESEventRewardData> val_1 = this.GetRewardsList(playerTier:  playerTier);
        if(val_3 >= 1)
        {
                val_3 = 0;
            val_4 = 0;
            var val_4 = 0;
            if(val_3 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3 = val_3 + 0;
            val_5 = mem[(true + 0) + 32];
            val_5 = (true + 0) + 32;
            if(((true + 0) + 32 + 16) == 2)
        {
                if(((true + 0) + 32 + 16) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_5 = val_5 + 0;
            val_5 = mem[((true + 0) + 32 + 0) + 32];
            val_5 = ((true + 0) + 32 + 0) + 32;
        }
        
            decimal val_2 = System.Decimal.op_Addition(d1:  new System.Decimal(), d2:  new System.Decimal() {flags = ((true + 0) + 32 + 0) + 32 + 24, hi = ((true + 0) + 32 + 0) + 32 + 24, lo = ((true + 0) + 32 + 0) + 32 + 24 + 8, mid = ((true + 0) + 32 + 0) + 32 + 24 + 8});
            val_4 = val_2.flags;
            val_3 = val_2.lo;
        }
        
            val_4 = val_4 + 1;
            return new System.Decimal();
        }
        
        val_4 = 0;
        val_3 = 0;
        return new System.Decimal();
    }
    public RESEventRewardData GetFinalPrize(int playerTier)
    {
        bool val_2 = true;
        System.Collections.Generic.List<RESEventRewardData> val_1 = this.GetRewardsList(playerTier:  playerTier);
        if(val_2 == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + 0;
        return (RESEventRewardData)(true + 0) + 32;
    }
    public RESEventRewardData GetEventReward(int playerTier, int rewardProgressLevel)
    {
        var val_3;
        var val_4;
        System.Collections.Generic.List<RESEventRewardData> val_1 = this.GetRewardsList(playerTier:  playerTier);
        System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>> val_2 = this.GetCoinsList(playerTier:  playerTier);
        val_3 = 0;
        if(val_1 == null)
        {
                return (RESEventRewardData)val_3;
        }
        
        if(val_2 == null)
        {
                return (RESEventRewardData)val_3;
        }
        
        val_4 = null;
        val_4 = null;
        GameNames val_3 = App.game;
        if(val_3 == 20)
        {
                return RestaurantRivals.CommonEventEconDataHelper.GetDynamicEventReward(tierList:  val_1, coinList:  val_2, rewardProgressLevel:  rewardProgressLevel);
        }
        
        if(val_3 <= rewardProgressLevel)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + (rewardProgressLevel << 3);
        val_3 = mem[(App.game + (rewardProgressLevel) << 3) + 32];
        val_3 = (App.game + (rewardProgressLevel) << 3) + 32;
        return (RESEventRewardData)val_3;
    }

}
