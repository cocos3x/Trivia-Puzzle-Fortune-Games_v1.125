using UnityEngine;
private sealed class LeaguesDataController.<>c__DisplayClass51_0
{
    // Fields
    public SLC.Social.Profile toRemove;
    public SLC.Social.Leagues.LeaguesDataController <>4__this;
    public int guild_id;
    
    // Methods
    public LeaguesDataController.<>c__DisplayClass51_0()
    {
    
    }
    internal void <RemoveGuildMember>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)
    {
        SLC.Social.Profile val_1 = this.<>4__this.MyProfile;
        if(this.toRemove.ServerId != val_1.ServerId)
        {
                return;
        }
        
        bool val_2 = this.<>4__this.knownGuilds.Remove(key:  this.guild_id);
        this.<>4__this.UpdateEligibleGuildsToJoin();
        MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance.OnGuildStatusChanged(state:  1, source:  "self_leave_guild", leftGuildId:  this.guild_id, forDisplayOnly:  false);
    }

}
