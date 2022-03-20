using UnityEngine;
private sealed class LeaguesUI_MyClubDetails.<UpdateRaceTrack>d__28 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Social.Leagues.LeaguesUI_MyClubDetails <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LeaguesUI_MyClubDetails.<UpdateRaceTrack>d__28(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_3;
        var val_5;
        var val_6;
        val_3 = 0;
        if((this.<>1__state) >= 2)
        {
            goto label_1;
        }
        
        this.<>1__state = val_3;
        if((this.<>4__this.clubRacerList) == null)
        {
            goto label_4;
        }
        
        System.Collections.IEnumerator val_1 = this.<>4__this.SetupClubRacerItems();
        val_3 = 2;
        goto label_5;
        label_1:
        val_5 = 0;
        val_6 = 0;
        if((this.<>1__state) == 2)
        {
            goto label_6;
        }
        
        return (bool)val_6;
        label_4:
        val_3 = 1;
        label_5:
        val_5 = 1;
        this.<>2__current = this.<>4__this.CreateClubRacerItems();
        label_6:
        val_6 = val_5;
        this.<>1__state = val_3;
        return (bool)val_6;
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
