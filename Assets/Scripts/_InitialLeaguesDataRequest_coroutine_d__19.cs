using UnityEngine;
private sealed class LeaguesManager.<InitialLeaguesDataRequest_coroutine>d__19 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public System.Collections.Generic.Dictionary<string, object> response;
    public SLC.Social.Leagues.LeaguesManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LeaguesManager.<InitialLeaguesDataRequest_coroutine>d__19(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        string val_31;
        var val_32;
        var val_69;
        SLC.Social.Leagues.LeaguesManager val_70;
        object val_72;
        string val_73;
        var val_75;
        var val_80;
        var val_81;
        var val_82;
        var val_83;
        int val_84;
        int val_8 = 0;
        val_69 = 0;
        if((this.<>1__state) > 4)
        {
                return (bool)val_69;
        }
        
        var val_68 = 32561484;
        val_70 = this.<>4__this;
        val_68 = (32561484 + (this.<>1__state) << 2) + val_68;
        goto (32561484 + (this.<>1__state) << 2 + 32561484);
        label_77:
        val_73 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_32.MoveNext() == false)
        {
            goto label_72;
        }
        
        val_80 = null;
        val_81 = null;
        if(val_31 == 0)
        {
                throw new NullReferenceException();
        }
        
        SLC.Social.Leagues.LeaguesManager.clubCountByTier.Add(item:  System.Int32.Parse(s:  val_31));
        goto label_77;
        label_72:
        val_73 = public System.Void List.Enumerator<System.Object>::Dispose();
        val_32.Dispose();
        val_72 = this.response;
        if(val_72 == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "refresh_intervals";
        if((val_72.ContainsKey(key:  val_73)) != false)
        {
                val_72 = this.response;
            if(val_72 == null)
        {
                throw new NullReferenceException();
        }
        
            val_73 = "refresh_intervals";
            val_75 = 1152921510214912464;
            object val_36 = val_72.Item[val_73];
            if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_36.ContainsKey(key:  "normal")) != false)
        {
                val_73 = "normal";
            object val_38 = val_36.Item[val_73];
            if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
            val_82 = null;
            val_82 = null;
            SLC.Social.Leagues.LeaguesManager.RefreshRequestInterval = (float)System.Math.Max(val1:  30, val2:  System.Int32.Parse(s:  val_38));
        }
        
            val_70 = "slow";
            if((val_36.ContainsKey(key:  "slow")) != false)
        {
                val_73 = "slow";
            object val_42 = val_36.Item[val_73];
            if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
            val_70 = 1152921505022660608;
            val_83 = null;
            val_83 = null;
            SLC.Social.Leagues.LeaguesManager.SlowRefreshRequestInterval = (float)System.Math.Max(val1:  50, val2:  System.Int32.Parse(s:  val_42));
        }
        
        }
        
        val_84 = 4;
        val_69 = 1;
        this.<>2__current = 0;
        this.<>1__state = ;
        return (bool)val_69;
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
