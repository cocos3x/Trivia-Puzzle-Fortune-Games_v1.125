using UnityEngine;
private sealed class LeaguesDataController.<>c__DisplayClass66_0
{
    // Fields
    public SLC.Social.Leagues.LeaguesDataController <>4__this;
    public System.Action callBack;
    
    // Methods
    public LeaguesDataController.<>c__DisplayClass66_0()
    {
    
    }
    internal void <RequestGuildsByTier>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)
    {
        var val_2;
        this.<>4__this.rankedGuildsInTier.Clear();
        object val_1 = responseObject.Item["guilds"];
        val_2 = 0;
        this.<>4__this.rankedGuildsInTier.Update(guilds:  null, fromModel:  0);
        if(this.callBack == null)
        {
                return;
        }
        
        this.callBack.Invoke();
    }

}
