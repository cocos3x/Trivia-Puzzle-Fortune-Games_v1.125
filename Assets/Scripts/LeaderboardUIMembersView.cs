using UnityEngine;
public class LeaderboardUIMembersView : UIListViewController
{
    // Fields
    private UnityEngine.GameObject _leaderboardUIMemberGridItemPrefab;
    
    // Properties
    private UnityEngine.GameObject leaderboardUIMemberGridItemPrefab { get; }
    
    // Methods
    private UnityEngine.GameObject get_leaderboardUIMemberGridItemPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._leaderboardUIMemberGridItemPrefab == 0)
        {
                this._leaderboardUIMemberGridItemPrefab = PrefabLoader.LoadPrefab(featureName:  "Events", prefabName:  "member_leaderboard_grid_item");
            return val_3;
        }
        
        val_3 = this._leaderboardUIMemberGridItemPrefab;
        return val_3;
    }
    protected override UnityEngine.GameObject GetMemberItemPrefab()
    {
        return this.leaderboardUIMemberGridItemPrefab;
    }
    private void OnEnable()
    {
        this.DisplayMembers();
    }
    private void DisplayMembers()
    {
        null = null;
        mem[1152921517590003928] = System.Collections.Generic.List<T>.__il2cppRuntimeField_namespaze;
        this.UpdateMembersGrid();
    }
    protected override void SetupGridItem(int i)
    {
        var val_3;
        var val_4;
        var val_5;
        var val_6;
        System.Collections.Generic.List<LeaderboardPlayerInfo> val_7;
        var val_8;
        var val_9;
        var val_11;
        val_3 = i;
        val_4 = null;
        val_4 = null;
        GameNames val_3 = App.game;
        if(val_3 == 17)
        {
                val_5 = null;
            val_5 = null;
            val_6 = null;
            val_6 = null;
            val_7 = LeaderboardEventHandler.instance.playerInfo;
            val_8 = null;
            val_8 = null;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_3 = (System.Collections.Generic.List<T>.__il2cppRuntimeField_namespaze + (i) << 3) + 32.GetComponent<LeaderboardUIMemberGridItem>();
            val_9 = null;
            val_9 = null;
        }
        else
        {
                if(val_3 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3 = val_3 + (val_3 << 3);
            LeaderboardUIMemberGridItem val_2 = (App.game + (i) << 3) + 32.GetComponent<LeaderboardUIMemberGridItem>();
            val_11 = null;
            val_11 = null;
            val_7 = mem[LeaderboardEventHandler.instance + 40];
            val_7 = LeaderboardEventHandler.instance.rankedPlayerInfo;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
    
    }
    public LeaderboardUIMembersView()
    {
    
    }

}
