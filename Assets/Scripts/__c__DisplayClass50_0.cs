using UnityEngine;
private sealed class LeaguesDataController.<>c__DisplayClass50_0
{
    // Fields
    public SLC.Social.Leagues.LeaguesDataController <>4__this;
    public System.Action<bool> resultAction;
    
    // Methods
    public LeaguesDataController.<>c__DisplayClass50_0()
    {
    
    }
    internal void <UpdateMyGuildInfo>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)
    {
        var val_2;
        object val_1 = responseObject.Item["guild"];
        val_2 = 0;
        this.<>4__this.DecodeAndAddOrMergeGuild(responseObject:  null);
        this.resultAction.Invoke(obj:  true);
    }

}
