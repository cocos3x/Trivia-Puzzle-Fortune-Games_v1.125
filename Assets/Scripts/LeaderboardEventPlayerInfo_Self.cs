using UnityEngine;
public class LeaderboardEventPlayerInfo_Self : LeaderboardPlayerInfo
{
    // Fields
    private const string pref_player_rank = "ldbd_rk";
    private const string pref_collected_golden_apples = "ldbd_apple_ct";
    private const string pref_rewarded_player = "lbd_rw_plyr";
    public bool notifyRankup;
    public int rankIndex;
    public int reward;
    
    // Properties
    public override int rank { get; set; }
    public override int apples { get; set; }
    public override string name { get; }
    public bool rewarded { get; set; }
    
    // Methods
    public override int get_rank()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ldbd_rk", defaultValue:  0);
    }
    public override void set_rank(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ldbd_rk", value:  value);
    }
    public override int get_apples()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ldbd_apple_ct", defaultValue:  0);
    }
    public override void set_apples(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ldbd_apple_ct", value:  value);
    }
    public override string get_name()
    {
        return SLC.Social.SocialManager.ProfileName;
    }
    public bool get_rewarded()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "lbd_rw_plyr", defaultValue:  0)) == 1) ? 1 : 0;
    }
    public void set_rewarded(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "lbd_rw_plyr", value:  value);
    }
    public void UpdateRank(int rank)
    {
        if(this > rank)
        {
                this.notifyRankup = true;
        }
    
    }
    public void ClearData()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "ldbd_apple_ct")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "ldbd_apple_ct");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "ldbd_rk")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "ldbd_rk");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lbd_rw_plyr")) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "lbd_rw_plyr");
    }
    private void DeletePlayerPref(string key)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  key);
    }
    public LeaderboardEventPlayerInfo_Self()
    {
        this.rankIndex = 1;
        val_1 = new System.Object();
    }

}
