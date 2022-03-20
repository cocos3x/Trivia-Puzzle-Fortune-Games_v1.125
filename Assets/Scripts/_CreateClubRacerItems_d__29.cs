using UnityEngine;
private sealed class LeaguesUI_MyClubDetails.<CreateClubRacerItems>d__29 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Social.Leagues.LeaguesUI_MyClubDetails <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LeaguesUI_MyClubDetails.<CreateClubRacerItems>d__29(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        if((this.<>1__state) != 0)
        {
                return false;
        }
        
        this.<>1__state = 0;
        var val_5 = 0;
        do
        {
            UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.<>4__this.clubRacer);
            this = val_1;
            val_1.transform.SetParent(parent:  this.<>4__this.raceTrack, worldPositionStays:  false);
            this.layer = this.<>4__this.raceTrack.gameObject.layer;
            this.<>4__this.clubRacerList.Add(item:  this);
            val_5 = val_5 + 1;
        }
        while(val_5 < 14);
        
        return false;
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
