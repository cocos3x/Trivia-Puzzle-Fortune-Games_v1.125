using UnityEngine;
private sealed class LeaguesDataController.<DelayedGetGuildAndMembers>d__59 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Social.Leagues.LeaguesDataController <>4__this;
    public System.Collections.Generic.Dictionary<string, object> responseObject;
    private int <guildId>5__2;
    private SLC.Social.Leagues.Guild <guild>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LeaguesDataController.<DelayedGetGuildAndMembers>d__59(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_19;
        int val_24;
        val_19 = this;
        if((this.<>1__state) <= 3)
        {
                var val_19 = 32556392 + (this.<>1__state) << 2;
            val_19 = val_19 + 32556392;
        }
        else
        {
                val_24 = 0;
            return (bool);
        }
    
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
