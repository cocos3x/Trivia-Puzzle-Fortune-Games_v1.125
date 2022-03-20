using UnityEngine;
public class WGLeaderboardManager : MonoSingleton<WGLeaderboardManager>
{
    // Fields
    public const int TotalLeaderboardRanks = 200;
    private string currentCountry;
    private string QAHACK_RawLeaderboardData;
    private System.DateTime QAHack_LastLeaderboardDataTime;
    private LeaderboardPlayerInfo_Self playerInfo_Self;
    private System.Collections.Generic.List<LeaderboardPlayerInfo> rankedPlayerInfoList;
    private LeaderboardGeoType <GeoType>k__BackingField;
    private LeaderboardInterval <Interval>k__BackingField;
    
    // Properties
    public LeaderboardPlayerInfo_Self PlayerInfo { get; set; }
    public System.Collections.Generic.List<LeaderboardPlayerInfo> RankedPlayersInfo { get; set; }
    public string LeaderBoardCountry { get; }
    public LeaderboardGeoType GeoType { get; set; }
    public LeaderboardInterval Interval { get; set; }
    
    // Methods
    public LeaderboardPlayerInfo_Self get_PlayerInfo()
    {
        return (LeaderboardPlayerInfo_Self)this.playerInfo_Self;
    }
    private void set_PlayerInfo(LeaderboardPlayerInfo_Self value)
    {
        this.playerInfo_Self = value;
    }
    public System.Collections.Generic.List<LeaderboardPlayerInfo> get_RankedPlayersInfo()
    {
        return (System.Collections.Generic.List<LeaderboardPlayerInfo>)this.rankedPlayerInfoList;
    }
    private void set_RankedPlayersInfo(System.Collections.Generic.List<LeaderboardPlayerInfo> value)
    {
        this.rankedPlayerInfoList = value;
    }
    public string get_LeaderBoardCountry()
    {
        return (string)this.currentCountry;
    }
    public LeaderboardGeoType get_GeoType()
    {
        return (LeaderboardGeoType)this.<GeoType>k__BackingField;
    }
    private void set_GeoType(LeaderboardGeoType value)
    {
        this.<GeoType>k__BackingField = value;
    }
    public LeaderboardInterval get_Interval()
    {
        return (LeaderboardInterval)this.<Interval>k__BackingField;
    }
    private void set_Interval(LeaderboardInterval value)
    {
        this.<Interval>k__BackingField = value;
    }
    public override void InitMonoSingleton()
    {
        this.Initialize();
    }
    public void UpdateGoldenCurrency(int amount)
    {
        var val_4;
        Player val_1 = App.Player;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "value", value:  amount);
        val_4 = null;
        val_4 = null;
        App.networkManager.DoPut(path:  System.String.Format(format:  "/api/leaderboards/{0}", arg0:  val_1.id), postBody:  val_3, onCompleteFunction:  0, timeout:  20, destroy:  false, immediate:  false);
    }
    public void Refresh(LeaderboardGeoType geoType, LeaderboardInterval interval)
    {
        var val_9;
        this.<GeoType>k__BackingField = geoType;
        this.<Interval>k__BackingField = interval;
        Player val_1 = App.Player;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "type", value:  geoType.ToString().ToLower());
        val_3.Add(key:  "interval", value:  interval.ToString().ToLower());
        val_9 = null;
        val_9 = null;
        App.networkManager.DoGet(path:  System.String.Format(format:  "/api/leaderboards/{0}", arg0:  val_1.id), onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGLeaderboardManager::OnLeaderboardDataUpdated(string method, System.Collections.Generic.Dictionary<string, object> data)), destroy:  false, immediate:  false, getParams:  val_3, timeout:  20);
    }
    public void ShowLeaderboardWindow()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.IsWindowInQueue<LevelCompletePopup>();
        if(val_2 != 0)
        {
                val_2.OpenStackingMonolith<WGLeaderboardWindow>();
            return;
        }
        
        GameBehavior val_4 = App.getBehavior;
        goto mem[(1152921504946249728 + (public WGLeaderboardWindow MetaGameBehavior::ShowUGUIMonolith<WGLeaderboardWindow>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public void ResetLeaderboardGeoAndInterval()
    {
        this.<GeoType>k__BackingField = 0;
    }
    private void Initialize()
    {
        var val_4;
        this.<GeoType>k__BackingField = 0;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        val_1.Add(key:  "user_id", value:  val_2.id);
        val_4 = null;
        val_4 = null;
        App.networkManager.DoPost(path:  "/api/leaderboards", postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGLeaderboardManager::<Initialize>b__27_0(string method, System.Collections.Generic.Dictionary<string, object> data)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private void OnLeaderboardDataUpdated(string method, System.Collections.Generic.Dictionary<string, object> data)
    {
        if(data == null)
        {
                return;
        }
        
        if((data.ContainsKey(key:  "success")) == false)
        {
                return;
        }
        
        object val_2 = data.Item["success"];
        if((0 & 3) == 0)
        {
                return;
        }
        
        this.ParseData(data:  data);
        this.playerInfo_Self.name = SLC.Social.SocialManager.ProfileName;
        SLC.Social.Profile val_5 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        this.playerInfo_Self.avatar = val_5.AvatarId;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "RefreshLeaderboard");
    }
    private void ResetData()
    {
        this.playerInfo_Self = new LeaderboardPlayerInfo_Self();
        this.rankedPlayerInfoList = new System.Collections.Generic.List<LeaderboardPlayerInfo>();
    }
    private void ParseData(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_38;
        int val_16 = 0;
        int val_9 = 0;
        int val_29 = 0;
        this.ResetData();
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                this.QAHACK_RawLeaderboardData = PrettyPrint.printJSON(obj:  data, types:  false, singleLineOutput:  false);
            System.DateTime val_4 = ServerHandler.ServerTime;
            this.QAHack_LastLeaderboardDataTime = val_4;
        }
        
        if((data.ContainsKey(key:  "country")) != false)
        {
                this.currentCountry = data.Item["country"];
        }
        
        if((data.ContainsKey(key:  "total")) != false)
        {
                bool val_10 = System.Int32.TryParse(s:  data.Item["total"], result: out  val_9);
            this.playerInfo_Self.apples = 0;
        }
        
        if((data.ContainsKey(key:  "lifetime_value")) != false)
        {
                bool val_13 = System.Int32.TryParse(s:  data.Item["lifetime_value"], result: out  val_9);
            this.playerInfo_Self.lifetimeBalance = 0;
        }
        
        if((data.ContainsKey(key:  "rank")) != false)
        {
                bool val_17 = System.Int32.TryParse(s:  data.Item["rank"], result: out  val_16);
            this.playerInfo_Self.rank = 0;
        }
        
        val_38 = "rankings";
        if((data.ContainsKey(key:  "rankings")) == false)
        {
                return;
        }
        
        object val_19 = data.Item["rankings"];
        if(val_19 == null)
        {
                return;
        }
        
        var val_20 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_19) : 0;
        var val_38 = 0;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_38 = mem[((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_19 : 0 + 16 + 0) + 32];
        val_38 = ((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_19 : 0 + 16 + 0) + 32;
        if((val_38.ContainsKey(key:  "rank")) != false)
        {
                bool val_24 = System.Int32.TryParse(s:  val_38.Item["rank"], result: out  val_16);
        }
        
        if((val_38.ContainsKey(key:  "name")) != false)
        {
                object val_26 = val_38.Item["name"];
        }
        
        if((val_38.ContainsKey(key:  "value")) != false)
        {
                bool val_30 = System.Int32.TryParse(s:  val_38.Item["value"], result: out  val_29);
        }
        
        if((val_38.ContainsKey(key:  "avatar_id")) != false)
        {
                bool val_33 = System.Int32.TryParse(s:  val_38.Item["avatar_id"], result: out  val_29);
        }
        
        if((val_38.ContainsKey(key:  "is_me")) != false)
        {
                string val_35 = SLC.Social.SocialManager.ProfileName;
            SLC.Social.Profile val_37 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        }
        
        this.rankedPlayerInfoList.Add(item:  new LeaderboardPlayerInfo());
        val_38 = val_38 + 1;
    }
    public string QAHack_GetLeaderboardDataHUD()
    {
        System.DateTime val_2 = ServerHandler.ServerTime;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = this.QAHack_LastLeaderboardDataTime});
        return (string)"" + this.QAHACK_RawLeaderboardData("" + this.QAHACK_RawLeaderboardData) + System.String.Format(format:  "\nLast Update: {0}\n", arg0:  val_3)(System.String.Format(format:  "\nLast Update: {0}\n", arg0:  val_3));
    }
    public WGLeaderboardManager()
    {
        var val_3;
        this.currentCountry = "Country";
        this.QAHACK_RawLeaderboardData = "";
        val_3 = null;
        val_3 = null;
        this.QAHack_LastLeaderboardDataTime = System.DateTime.MinValue;
        this.playerInfo_Self = new LeaderboardPlayerInfo_Self();
        this.rankedPlayerInfoList = new System.Collections.Generic.List<LeaderboardPlayerInfo>();
    }
    private void <Initialize>b__27_0(string method, System.Collections.Generic.Dictionary<string, object> data)
    {
        if(data == null)
        {
                return;
        }
        
        if((data.ContainsKey(key:  "success")) == false)
        {
                return;
        }
        
        object val_2 = data.Item["success"];
        if(null == null)
        {
                return;
        }
        
        this.Refresh(geoType:  0, interval:  0);
    }

}
