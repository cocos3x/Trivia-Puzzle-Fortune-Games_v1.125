using UnityEngine;
private sealed class LeaguesUI_MyClubDetails.<SetupClubRacerItems>d__30 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Social.Leagues.LeaguesUI_MyClubDetails <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LeaguesUI_MyClubDetails.<SetupClubRacerItems>d__30(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        SLC.Social.Leagues.LeaguesUI_MyClubDetails val_26;
        var val_27;
        var val_28;
        var val_29;
        var val_30;
        val_26 = this;
        if((this.<>1__state) != 0)
        {
                return false;
        }
        
        this.<>1__state = 0;
        val_26 = this.<>4__this;
        if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
        {
                return false;
        }
        
        do
        {
            System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_4 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInMyTier;
            System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_6 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInMyTier;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            int val_11 = 0 + 1;
            ((SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 0) + 0) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIClubRacerItem>().SetupUI(avatarId:  (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 0) + 32 + 24, yours:  (((SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 0) + 32 + 64) == SLC.Social.Leagues.LeaguesManager.DAO.MyGuildServerId) ? 1 : 0, rank:  val_11, displayTier:  0);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            decimal val_15 = (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 0) + 32.LeaguePointsFinal;
            UnityEngine.Vector2 val_16 = val_26.GetPosInTrack(points:  new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid});
            (null == null) ? (((SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 0) + 0) + 0) + 32.transform : 0.anchoredPosition = new UnityEngine.Vector2() {x = val_16.x, y = val_16.y};
            val_27 = val_11;
        }
        while( < 15);
        
        val_28 = 0;
        label_52:
        if(val_28 >= (this.<>4__this.clubRacerList))
        {
                return false;
        }
        
        System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_19 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInMyTier;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if(val_28 >= )
        {
            goto label_40;
        }
        
        UnityEngine.Transform val_20 = (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 0) + 32.transform;
        UnityEngine.Vector3 val_21 = val_20.localPosition;
        if((val_20.RacersOverlapping(xPosA:  val_21.x, xPosB:  -1f)) == false)
        {
            goto label_42;
        }
        
        val_29 = 0;
        goto label_43;
        label_40:
        val_30 = 0;
        goto label_44;
        label_42:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector3 val_25 = ((SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 0) + 0) + 32.transform.localPosition;
        val_29 = 1;
        label_43:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_30 = val_29;
        label_44:
        (((SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + 0) + 0) + 0) + 32.SetActive(value:  true);
        val_28 = val_28 + 1;
        if((this.<>4__this.clubRacerList) != null)
        {
            goto label_52;
        }
        
        throw new NullReferenceException();
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
