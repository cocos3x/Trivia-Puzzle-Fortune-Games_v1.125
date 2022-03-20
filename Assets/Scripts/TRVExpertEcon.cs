using UnityEngine;
public class TRVExpertEcon : ScriptableObject
{
    // Fields
    private System.Collections.Generic.List<string> defaultUnlockedExperts;
    public int expertSpeedUpCost;
    private System.Collections.Generic.Dictionary<int, int> DailyBonusCardProbabilities;
    private System.Collections.Generic.Dictionary<int, int> ChapterRewardCardProbabilities;
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.Dictionary<TRVExpertOutcomes, int>> expertProbibilites;
    private System.Collections.Generic.List<ExpertCardEcon> expertLevelUpEcon;
    public System.Collections.Generic.List<TRVCategoryExpertEcon> econs;
    
    // Properties
    public System.Collections.Generic.List<string> getDefaultUnlocked { get; }
    public int getExpertCooldown { get; }
    public System.Collections.Generic.Dictionary<TRVExpertRarites, int> getCardRarityProbabilities { get; }
    public System.Collections.Generic.Dictionary<int, int> getDBProbabilities { get; }
    public System.Collections.Generic.Dictionary<int, int> getCRProbabilities { get; }
    public System.Collections.Generic.List<ExpertCardEcon> cardEcon { get; }
    
    // Methods
    public System.Collections.Generic.List<string> get_getDefaultUnlocked()
    {
        return (System.Collections.Generic.List<System.String>)this.defaultUnlockedExperts;
    }
    public int get_getExpertCooldown()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (int)val_1.expertCooldownHours;
    }
    public System.Collections.Generic.Dictionary<TRVExpertRarites, int> get_getCardRarityProbabilities()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (System.Collections.Generic.Dictionary<TRVExpertRarites, System.Int32>)val_1.expertOdds;
    }
    public System.Collections.Generic.Dictionary<int, int> get_getDBProbabilities()
    {
        return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)this.DailyBonusCardProbabilities;
    }
    public System.Collections.Generic.Dictionary<int, int> get_getCRProbabilities()
    {
        return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)this.ChapterRewardCardProbabilities;
    }
    public System.Collections.Generic.Dictionary<TRVExpertOutcomes, int> getOutcomesByLevel(int level)
    {
        int val_4;
        var val_5;
        val_4 = level;
        if((this.expertProbibilites.ContainsKey(key:  val_4)) != false)
        {
                System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32> val_2 = this.expertProbibilites.Item[val_4];
            return (System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>)val_5;
        }
        
        val_4 = "no expert outcome econ found for a proficiency level " + val_4;
        UnityEngine.Debug.LogError(message:  val_4);
        val_5 = 0;
        return (System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>)val_5;
    }
    public System.Collections.Generic.List<ExpertCardEcon> get_cardEcon()
    {
        return (System.Collections.Generic.List<ExpertCardEcon>)this.expertLevelUpEcon;
    }
    public ExpertCardEcon.ExpertLevelReq getReqFromExpert(TRVExpert exp, TRVExpertProgressData prog)
    {
        IntPtr val_5;
        TRVExpertEcon.<>c__DisplayClass19_0 val_1 = new TRVExpertEcon.<>c__DisplayClass19_0();
        .exp = exp;
        .prog = prog;
        ExpertCardEcon val_3 = System.Linq.Enumerable.FirstOrDefault<ExpertCardEcon>(source:  this.expertLevelUpEcon, predicate:  new System.Func<ExpertCardEcon, System.Boolean>(object:  val_1, method:  System.Boolean TRVExpertEcon.<>c__DisplayClass19_0::<getReqFromExpert>b__0(ExpertCardEcon x)));
        if(((TRVExpertEcon.<>c__DisplayClass19_0)[1152921517149785600].prog) != null)
        {
                val_5 = 1152921517149717312;
        }
        else
        {
                val_5 = 1152921517149718336;
        }
        
        System.Func<ExpertLevelReq, System.Boolean> val_4 = new System.Func<ExpertLevelReq, System.Boolean>(object:  val_1, method:  val_5);
        return System.Linq.Enumerable.FirstOrDefault<ExpertLevelReq>(source:  val_3.myReqs, predicate:  null);
    }
    public TRVExpertEcon()
    {
        this.defaultUnlockedExperts = new System.Collections.Generic.List<System.String>();
        this.expertSpeedUpCost = 15;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_2 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        val_2.Add(key:  1, value:  100);
        val_2.Add(key:  2, value:  80);
        val_2.Add(key:  3, value:  20);
        this.DailyBonusCardProbabilities = val_2;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_3 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        val_3.Add(key:  1, value:  100);
        val_3.Add(key:  2, value:  100);
        val_3.Add(key:  3, value:  50);
        val_3.Add(key:  4, value:  20);
        this.ChapterRewardCardProbabilities = val_3;
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>> val_4 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>>();
        System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32> val_5 = new System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>();
        val_5.Add(key:  0, value:  30);
        val_5.Add(key:  1, value:  50);
        val_5.Add(key:  2, value:  20);
        val_4.Add(key:  1, value:  val_5);
        System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32> val_6 = new System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>();
        val_6.Add(key:  0, value:  20);
        val_6.Add(key:  1, value:  40);
        val_6.Add(key:  2, value:  40);
        val_4.Add(key:  2, value:  val_6);
        System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32> val_7 = new System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>();
        val_7.Add(key:  0, value:  10);
        val_7.Add(key:  1, value:  30);
        val_7.Add(key:  2, value:  60);
        val_4.Add(key:  3, value:  val_7);
        System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32> val_8 = new System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>();
        val_8.Add(key:  1, value:  20);
        val_8.Add(key:  2, value:  80);
        val_4.Add(key:  4, value:  val_8);
        System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32> val_9 = new System.Collections.Generic.Dictionary<TRVExpertOutcomes, System.Int32>();
        val_9.Add(key:  2, value:  100);
        val_4.Add(key:  5, value:  val_9);
        this.expertProbibilites = val_4;
        this.expertLevelUpEcon = new System.Collections.Generic.List<ExpertCardEcon>();
    }

}
