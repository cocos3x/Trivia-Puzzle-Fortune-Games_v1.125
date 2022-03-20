using UnityEngine;
public class LeaderboardTierGridView : UIListViewController
{
    // Fields
    private UnityEngine.GameObject _leaderboardTierGridItemPrefab;
    
    // Properties
    private UnityEngine.GameObject leaderboardTierGridItemPrefab { get; }
    
    // Methods
    private UnityEngine.GameObject get_leaderboardTierGridItemPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._leaderboardTierGridItemPrefab == 0)
        {
                this._leaderboardTierGridItemPrefab = PrefabLoader.LoadPrefab(featureName:  "Events", prefabName:  "tier_leaderboard_grid_item");
            return val_3;
        }
        
        val_3 = this._leaderboardTierGridItemPrefab;
        return val_3;
    }
    protected override UnityEngine.GameObject GetMemberItemPrefab()
    {
        return this.leaderboardTierGridItemPrefab;
    }
    private void OnEnable()
    {
        this.DisplayPrizeTiers();
    }
    private void DisplayPrizeTiers()
    {
        null = null;
        mem[1152921517589000408] = System.Collections.Generic.List<T>.__il2cppRuntimeField_namespaze;
        this.UpdateMembersGrid();
    }
    protected override void SetupGridItem(int i)
    {
        var val_2;
        bool val_2 = true;
        if(val_2 <= i)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + (i << 3);
        val_2 = null;
        val_2 = null;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        (true + (i) << 3) + 32.GetComponent<LeaderboardTierGridItem>().UpdateTier(tier:  (System.Collections.Generic.List<T>.__il2cppRuntimeField_name + ((long)(int)(i)) << 3) + 32);
    }
    public LeaderboardTierGridView()
    {
    
    }

}
