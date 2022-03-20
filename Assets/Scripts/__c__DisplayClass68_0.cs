using UnityEngine;
private sealed class LeaguesDataController.<>c__DisplayClass68_0
{
    // Fields
    public SLC.Social.Leagues.Guild oldGuild;
    public SLC.Social.Leagues.LeaguesDataController <>4__this;
    
    // Methods
    public LeaguesDataController.<>c__DisplayClass68_0()
    {
    
    }
    internal void <JoinGuild>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)
    {
        var val_3;
        if(this.oldGuild != null)
        {
                bool val_1 = this.<>4__this.knownGuilds.Remove(key:  this.oldGuild.ServerId);
        }
        
        object val_2 = responseObject.Item["guild"];
        val_3 = 0;
        this.<>4__this.DecodeAndAddOrMergeGuild(responseObject:  null);
    }

}
