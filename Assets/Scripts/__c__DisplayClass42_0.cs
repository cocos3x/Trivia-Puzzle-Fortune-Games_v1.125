using UnityEngine;
private sealed class LeaguesDataController.<>c__DisplayClass42_0
{
    // Fields
    public int multiplierOption;
    public decimal multiplierCost;
    public System.Action<bool> resultAction;
    
    // Methods
    public LeaguesDataController.<>c__DisplayClass42_0()
    {
    
    }
    internal void <ContributeMultiplier>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)
    {
        decimal val_2 = System.Decimal.Parse(s:  responseObject.Item["points_multiplier"]);
        SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        val_4.LeaguePointsMultiplier = val_2;
        mem2[0] = val_2.lo;
        mem[4] = val_2.mid;
        decimal val_7 = System.Decimal.op_UnaryNegation(d:  new System.Decimal() {flags = this.multiplierCost, hi = this.multiplierCost, lo = -2137538000, mid = 268435459});
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, source:  System.String.Format(format:  "Leagues Multiplier Option {0}", arg0:  this.multiplierOption), subSource:  0, externalParams:  0, doTrack:  true);
        this.resultAction.Invoke(obj:  true);
        SLC.Social.Leagues.LeaguesTracker.AddDirectCreditContribution(contribution:  new System.Decimal() {flags = this.multiplierCost, hi = this.multiplierCost, lo = -2137586384, mid = 268435459}, source:  "Leagues Multiplier");
    }
    internal void <ContributeMultiplier>b__1(System.Collections.Generic.Dictionary<string, object> responseObject)
    {
        decimal val_2 = System.Decimal.Parse(s:  responseObject.Item["points_multiplier"]);
        SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        val_4.LeaguePointsMultiplier = val_2;
        mem2[0] = val_2.lo;
        mem[4] = val_2.mid;
        App.Player.AddGems(amount:  -(System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.multiplierCost, hi = this.multiplierCost, lo = -2137360464, mid = 268435459})), source:  System.String.Format(format:  "Leagues Multiplier Option {0}", arg0:  this.multiplierOption), subsource:  0);
        this.resultAction.Invoke(obj:  true);
        SLC.Social.Leagues.LeaguesTracker.AddDirectGemContribution(contribution:  new System.Decimal() {flags = this.multiplierCost, hi = this.multiplierCost, lo = -2137408848, mid = 268435459}, source:  "Leagues Multiplier");
    }

}
