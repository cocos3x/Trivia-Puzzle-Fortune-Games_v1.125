using UnityEngine;
public class LeaderboardMembersListView : UIListViewController
{
    // Fields
    private UnityEngine.GameObject _leaderboardUIMemberGridItemPrefab;
    public bool allMembersLoaded;
    
    // Properties
    private UnityEngine.GameObject leaderboardUIMemberGridItemPrefab { get; }
    
    // Methods
    private UnityEngine.GameObject get_leaderboardUIMemberGridItemPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._leaderboardUIMemberGridItemPrefab == 0)
        {
                this._leaderboardUIMemberGridItemPrefab = PrefabLoader.LoadPrefab(featureName:  "Leaderboard", prefabName:  "member_leaderboard_grid_item");
            return val_3;
        }
        
        val_3 = this._leaderboardUIMemberGridItemPrefab;
        return val_3;
    }
    protected override UnityEngine.GameObject GetMemberItemPrefab()
    {
        return this.leaderboardUIMemberGridItemPrefab;
    }
    public void RefreshMembers()
    {
        WGLeaderboardManager val_1 = MonoSingleton<WGLeaderboardManager>.Instance;
        mem[1152921517584952376] = val_1.rankedPlayerInfoList;
        this.UpdateMembersGrid();
    }
    public void SetOnFinishedUISetup()
    {
        mem[1152921517585081816] = new System.Action<System.Boolean>(object:  this, method:  System.Void LeaderboardMembersListView::FinishedUIUpdate(bool state));
        mem[1152921517585081824] = new System.Action<System.Boolean>(object:  this, method:  System.Void LeaderboardMembersListView::FinishedUIUpdate(bool state));
    }
    protected override void SetupGridItem(int i)
    {
        var val_4;
        System.Collections.Generic.List<LeaderboardPlayerInfo> val_5;
        LeaderboardPlayerInfo val_6;
        val_4 = i;
        bool val_4 = true;
        if(val_4 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + (val_4 << 3);
        LeaderboardMemberGridItem val_1 = (true + (i) << 3) + 32.GetComponent<LeaderboardMemberGridItem>();
        val_5 = 1152921504893161472;
        WGLeaderboardManager val_2 = MonoSingleton<WGLeaderboardManager>.Instance;
        if(val_2.rankedPlayerInfoList <= val_4)
        {
            goto label_8;
        }
        
        WGLeaderboardManager val_3 = MonoSingleton<WGLeaderboardManager>.Instance;
        val_5 = val_3.rankedPlayerInfoList;
        val_4 = (long)val_4;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_6 = mem[(MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32];
        val_6 = (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32;
        if(val_1 != null)
        {
            goto label_14;
        }
        
        label_8:
        val_6 = 0;
        label_14:
        val_1.UpdateUIFromMember(info:  val_6);
    }
    private void FinishedUIUpdate(bool state)
    {
        this.allMembersLoaded = true;
    }
    public LeaderboardMembersListView()
    {
    
    }

}
