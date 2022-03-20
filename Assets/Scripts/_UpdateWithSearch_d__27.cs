using UnityEngine;
private sealed class LeaguesUIGuildListView.<UpdateWithSearch>d__27 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public string term;
    public SLC.Social.Leagues.LeaguesUIGuildListView <>4__this;
    private SLC.Social.Leagues.Guild[] <matching>5__2;
    private int <i>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LeaguesUIGuildListView.<UpdateWithSearch>d__27(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_8;
        int val_9;
        int val_10;
        var val_11;
        var val_12;
        var val_13;
        int val_14;
        val_8 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_26;
        }
        
        this.<>1__state = 0;
        if(((System.String.IsNullOrEmpty(value:  this.term)) == true) || (this.term.m_stringLength <= 1))
        {
            goto label_5;
        }
        
        val_9 = 0;
        this.<matching>5__2 = SLC.Social.Leagues.LeaguesManager.DAO.GetKnownGuildsByName(queryString:  this.term).ToArray();
        this.<i>5__3 = 0;
        if((this.<>4__this) != null)
        {
            goto label_10;
        }
        
        label_1:
        this.<>1__state = 0;
        val_9 = (this.<i>5__3) + 1;
        this.<i>5__3 = val_9;
        label_10:
        if(val_9 >= (X22 + 24))
        {
            goto label_26;
        }
        
        if((X22 + 24) <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_7 = X22 + 16;
        val_7 = val_7 + (val_9 << 3);
        if(val_9 >= (this.<matching>5__2.Length))
        {
            goto label_18;
        }
        
        SLC.Social.Leagues.Guild val_8 = this.<matching>5__2[this.<i>5__3];
        val_10 = this.<matching>5__2[this.<i>5__3][0].ServerId;
        val_11 = 1;
        val_12 = 0;
        val_13 = 0;
        goto label_23;
        label_5:
        val_9 = 1152921519700621424;
        val_8 = 0;
        label_30:
        if(val_8 >= (X22 + 24))
        {
            goto label_26;
        }
        
        if((X22 + 24) <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_9 = X22 + 16;
        val_9 = val_9 + 0;
        (X22 + 16 + 0) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>().UpdateUIFromGuild(guildId:  0, rankingView:  false, showMemberCount:  false, finalSeasonRank:  0);
        val_8 = val_8 + 1;
        if(X22 != 0)
        {
            goto label_30;
        }
        
        throw new NullReferenceException();
        label_26:
        val_14 = 0;
        return (bool)val_14;
        label_18:
        val_10 = 0;
        val_12 = 0;
        val_13 = 0;
        val_11 = 0;
        label_23:
        (X22 + 16 + ((this.<i>5__3 + 1)) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>().UpdateUIFromGuild(guildId:  0, rankingView:  false, showMemberCount:  false, finalSeasonRank:  0);
        val_14 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_14;
        return (bool)val_14;
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
