using UnityEngine;
private sealed class LeaguesDataController.<>c__DisplayClass72_0
{
    // Fields
    public System.Action<bool, string> OnMessagerResponse;
    public string message;
    public SLC.Social.Leagues.LeaguesDataController <>4__this;
    
    // Methods
    public LeaguesDataController.<>c__DisplayClass72_0()
    {
    
    }
    internal void <SendChatMessage>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)
    {
        var val_3;
        if(this.OnMessagerResponse != null)
        {
                this.OnMessagerResponse.Invoke(arg1:  true, arg2:  this.message);
        }
        
        object val_2 = responseObject.Item["chat"];
        val_3 = 0;
        this.<>4__this.MyGuild.MergeChat(toParse:  null);
        SLC.Social.Leagues.LeaguesTracker.AddToChatMessageCount();
    }
    internal void <SendChatMessage>b__1(string apiCall)
    {
        if(this.OnMessagerResponse == null)
        {
                return;
        }
        
        this.OnMessagerResponse.Invoke(arg1:  false, arg2:  this.message);
    }

}
