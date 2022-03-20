using UnityEngine;
private sealed class WGLeaderboardWindow.<RefreshLeaderboardOnLoaded>d__20 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGLeaderboardWindow <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGLeaderboardWindow.<RefreshLeaderboardOnLoaded>d__20(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_13;
        var val_14;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        val_13 = 0;
        if((this.<>1__state) != 0)
        {
                return (bool)val_13;
        }
        
        this.<>1__state = 0;
        WGLeaderboardManager val_1 = MonoSingleton<WGLeaderboardManager>.Instance;
        System.DateTime val_3 = DateTimeCheat.Now;
        string val_5 = new System.Globalization.DateTimeFormatInfo().GetMonthName(month:  val_3.dateData.Month);
        if(val_5.Interval == 0)
        {
            goto label_11;
        }
        
        val_14 = "Total:";
        if((this.<>4__this.monthText) != null)
        {
            goto label_12;
        }
        
        label_1:
        this.<>1__state = 0;
        this.<>4__this.spin.SetActive(value:  false);
        this.<>4__this.playerInfoSpin.SetActive(value:  false);
        this.<>4__this.RefreshPlayerInfo();
        val_13 = 0;
        return (bool)val_13;
        label_11:
        val_14 = Localization.Localize(key:  val_5.ToLower(), defaultValue:  "", useSingularKey:  false);
        label_12:
        WGLeaderboardManager val_9 = MonoSingleton<WGLeaderboardManager>.Instance;
        string val_11 = val_9.playerInfo_Self.apples.ToString();
        this.<>4__this.allTimeTab.interactable = false;
        this.<>4__this.monthTab.interactable = false;
        this.<>4__this.listMembers.allMembersLoaded = false;
        this.<>4__this.RefreshRankList();
        this.<>2__current = this.<>4__this.WaitForAllMembersToSetup();
        val_13 = 1;
        this.<>1__state = val_13;
        return (bool)val_13;
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
