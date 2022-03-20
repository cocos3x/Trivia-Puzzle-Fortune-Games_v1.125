using UnityEngine;
public class GameOfTheDay : MonoSingleton<GameOfTheDay>
{
    // Fields
    private static string current_promo_key;
    private static string INSTALLED;
    private static string NON_INSTALLED;
    private System.Collections.Generic.Dictionary<string, object> currentPromoData;
    private string <promoPackageName>k__BackingField;
    private string <promoName>k__BackingField;
    private string <promoIconImageUrl>k__BackingField;
    private decimal <installedReward>k__BackingField;
    public static string currentStatus;
    private bool _isAvailable;
    
    // Properties
    public string promoPackageName { get; set; }
    public string promoName { get; set; }
    public string promoIconImageUrl { get; set; }
    public decimal installedReward { get; set; }
    private bool canShow { get; }
    public bool isAvailable { get; }
    public bool isAvailableAndMustShow { get; }
    
    // Methods
    public string get_promoPackageName()
    {
        return (string)this.<promoPackageName>k__BackingField;
    }
    protected void set_promoPackageName(string value)
    {
        this.<promoPackageName>k__BackingField = value;
    }
    public string get_promoName()
    {
        return (string)this.<promoName>k__BackingField;
    }
    protected void set_promoName(string value)
    {
        this.<promoName>k__BackingField = value;
    }
    public string get_promoIconImageUrl()
    {
        return (string)this.<promoIconImageUrl>k__BackingField;
    }
    protected void set_promoIconImageUrl(string value)
    {
        this.<promoIconImageUrl>k__BackingField = value;
    }
    public decimal get_installedReward()
    {
        return new System.Decimal() {flags = this.<installedReward>k__BackingField, hi = this.<installedReward>k__BackingField};
    }
    protected void set_installedReward(decimal value)
    {
        this.<installedReward>k__BackingField = value;
        mem[1152921517563137088] = value.lo;
        mem[1152921517563137092] = value.mid;
    }
    private bool get_canShow()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        Player val_2 = App.Player;
        System.DateTime val_3 = val_2.properties.GOTDLastShownTime.AddHours(value:  24);
        return (bool)((val_1.dateData.CompareTo(value:  new System.DateTime() {dateData = val_3.dateData})) > 0) ? 1 : 0;
    }
    public bool get_isAvailable()
    {
        return (bool)this._isAvailable;
    }
    public bool get_isAvailableAndMustShow()
    {
        var val_2;
        var val_3;
        bool val_4;
        if(this.canShow != false)
        {
                val_2 = null;
            val_2 = null;
            if(twelvegigs.plugins.InstalledAppsPlugin.fetched != false)
        {
                val_3 = null;
            val_3 = null;
            this.CheckAvailableAndPrepare(networkPromos:  twelvegigs.plugins.InstalledAppsPlugin.<NetworkPromos>k__BackingField);
            val_4 = this._isAvailable;
            return (bool)val_4;
        }
        
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    public override void InitMonoSingleton()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void GameOfTheDay::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    private void OnDestroy()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void GameOfTheDay::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    private void OnSceneLoaded(SceneType sceneType)
    {
    
    }
    public void JustShown()
    {
        Player val_1 = App.Player;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        val_1.properties.GOTDLastShownTime = val_2;
        Player val_3 = App.Player;
        val_3.properties.Save(writePrefs:  true);
    }
    public void CheckAvailableAndPrepare(System.Collections.Generic.List<object> networkPromos)
    {
        var val_22;
        PlayerProperties val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        this._isAvailable = false;
        GameBehavior val_1 = App.getBehavior;
        val_22 = 1152921504887623680;
        val_23 = val_1.<metaGameBehavior>k__BackingField;
        val_24 = null;
        val_24 = null;
        if(val_23 < AdsManager.ADS_WATCHED_COOLDOWN_PREF)
        {
                return;
        }
        
        val_23 = 1152921505039912960;
        val_25 = null;
        val_25 = null;
        if((twelvegigs.plugins.InstalledAppsPlugin.<NetworkPromos>k__BackingField) == null)
        {
                return;
        }
        
        val_26 = null;
        val_26 = null;
        if((twelvegigs.plugins.InstalledAppsPlugin.<NetworkPromos>k__BackingField + 24) == 0)
        {
                return;
        }
        
        val_22 = 1152921504975536128;
        val_27 = null;
        val_27 = null;
        if((System.String.op_Equality(a:  GameOfTheDay.currentStatus, b:  "new_user")) == true)
        {
                return;
        }
        
        val_28 = null;
        val_28 = null;
        if((System.String.op_Equality(a:  GameOfTheDay.currentStatus, b:  "feature_disabled")) == true)
        {
                return;
        }
        
        this.CheckPromoAndFlag();
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        Player val_5 = App.Player;
        if(((val_4.dateData.CompareTo(value:  new System.DateTime() {dateData = val_5.properties.GOTDDontShowUntil})) & 2147483648) != 0)
        {
                return;
        }
        
        Player val_7 = App.Player;
        val_23 = val_7.properties;
        val_7.properties.GOTDDontShowUntil = System.DateTime.MinValue;
        object val_8 = this.TryPickAPromo(networkPromos:  networkPromos);
        if(val_8 == null)
        {
            goto label_40;
        }
        
        this.currentPromoData = val_8;
        val_8.PersistCurrentPromo(networkPromoData:  val_8);
        twelvegigs.storage.JsonDictionary val_9 = new twelvegigs.storage.JsonDictionary(parsedDictionary:  this.currentPromoData);
        this.<promoPackageName>k__BackingField = val_9.getString(key:  "package_name", defaultValue:  "").Trim();
        this.<promoName>k__BackingField = val_9.getString(key:  "name", defaultValue:  "");
        this.<promoIconImageUrl>k__BackingField = val_9.getString(key:  "asset", defaultValue:  "");
        if((App.Player.PromotedGames.ContainsKey(key:  this.<promoPackageName>k__BackingField)) == false)
        {
            goto label_49;
        }
        
        val_23 = App.Player.PromotedGames;
        val_23.set_Item(key:  this.<promoPackageName>k__BackingField, value:  GameOfTheDay.NON_INSTALLED);
        goto label_56;
        label_40:
        UnityEngine.Debug.Log(message:  "Cannot pick a game from networkPromos");
        return;
        label_49:
        val_23 = App.Player.PromotedGames;
        val_23.Add(key:  this.<promoPackageName>k__BackingField, value:  GameOfTheDay.NON_INSTALLED);
        label_56:
        this._isAvailable = true;
        App.Player.SaveState();
    }
    private System.Collections.Generic.Dictionary<string, object> LoadCurrentPromo()
    {
        var val_4;
        var val_5;
        var val_6;
        val_4 = null;
        val_4 = null;
        val_5 = 0;
        if((UnityEngine.PlayerPrefs.HasKey(key:  GameOfTheDay.current_promo_key)) == false)
        {
                return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_3;
        }
        
        val_6 = null;
        val_6 = null;
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  GameOfTheDay.current_promo_key));
        if(val_3 == null)
        {
                return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_3;
        }
        
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_3;
    }
    private void PersistCurrentPromo(System.Collections.Generic.Dictionary<string, object> networkPromoData)
    {
        null = null;
        UnityEngine.PlayerPrefs.SetString(key:  GameOfTheDay.current_promo_key, value:  MiniJSON.Json.Serialize(obj:  networkPromoData));
    }
    private void ClearCurrentPromo()
    {
        this.<promoName>k__BackingField = 0;
        this.currentPromoData = 0;
        this.PersistCurrentPromo(networkPromoData:  0);
        App.Player.SaveState();
    }
    private void CheckPromoAndFlag()
    {
        var val_32;
        var val_33;
        string val_35;
        var val_36;
        var val_37;
        var val_38;
        PlayerProperties val_39;
        if(this.currentPromoData == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = this.currentPromoData.LoadCurrentPromo();
            this.currentPromoData = val_1;
            if(val_1 == null)
        {
                return;
        }
        
        }
        
        object val_2 = val_1.Item["package_name"];
        if(val_2 == null)
        {
            goto label_3;
        }
        
        if(null != null)
        {
            goto label_4;
        }
        
        this.<promoPackageName>k__BackingField = val_2;
        string val_3 = val_2.Trim();
        this.<promoPackageName>k__BackingField = val_3;
        if(val_3 == null)
        {
                return;
        }
        
        val_32 = twelvegigs.plugins.InstalledAppsPlugin.IsInstalled(packageToCheck:  val_3);
        val_33 = null;
        val_33 = null;
        string val_7 = GameOfTheDay.NON_INSTALLED;
        Player val_5 = App.Player;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.Dictionary<System.String, System.String> val_6 = val_5.PromotedGames;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_9 = (val_6.TryGetValue(key:  this.<promoPackageName>k__BackingField, value: out  val_7)) ^ 1;
        if(val_9 == true)
        {
            goto label_14;
        }
        
        CompanyDevices val_10 = CompanyDevices.Instance;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_12 = val_10.CompanyDevice() ^ 1;
        if(val_12 == true)
        {
            goto label_18;
        }
        
        string val_13 = "Last promoted game " + this.<promoPackageName>k__BackingField(this.<promoPackageName>k__BackingField) + " is " + val_7;
        goto label_19;
        label_14:
        CompanyDevices val_14 = CompanyDevices.Instance;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_14.CompanyDevice() == false)
        {
            goto label_23;
        }
        
        label_19:
        UnityEngine.Debug.Log(message:  "Cannot load installation status of package " + this.<promoPackageName>k__BackingField(this.<promoPackageName>k__BackingField) + " from App.Player.PromotedGames.");
        goto label_27;
        label_18:
        val_32 = val_32 & val_12;
        goto label_27;
        label_23:
        val_32 = val_32 & val_9;
        label_27:
        val_35 = val_7;
        if((val_35 != 0) && (val_32 != false))
        {
                val_36 = null;
            val_36 = null;
            if((System.String.op_Inequality(a:  val_35, b:  GameOfTheDay.INSTALLED)) != false)
        {
                Player val_18 = App.Player;
            if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
            System.Collections.Generic.Dictionary<System.String, System.String> val_19 = val_18.PromotedGames;
            if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
            val_19.set_Item(key:  this.<promoPackageName>k__BackingField, value:  GameOfTheDay.INSTALLED);
            val_35 = GameOfTheDay.INSTALLED;
        }
        else
        {
                val_35 = val_35;
        }
        
        }
        
        val_37 = null;
        val_37 = null;
        if((System.String.op_Equality(a:  val_35, b:  GameOfTheDay.INSTALLED)) == false)
        {
            goto label_42;
        }
        
        val_38 = null;
        goto label_45;
        label_42:
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_21.properties == null)
        {
                throw new NullReferenceException();
        }
        
        int val_31 = val_21.properties.GOTDDaysSeenWoInstallation;
        val_31 = val_31 + 1;
        val_21.properties.GOTDDaysSeenWoInstallation = val_31;
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_22.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_22.properties.GOTDDaysSeenWoInstallation < 6)
        {
            goto label_52;
        }
        
        CompanyDevices val_23 = CompanyDevices.Instance;
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_23.CompanyDevice() != false)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            val_39 = val_25.properties;
            System.DateTime val_26 = DateTimeCheat.UtcNow;
        }
        else
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            val_39 = val_27.properties;
            System.DateTime val_28 = ServerHandler.ServerTime;
        }
        
        System.DateTime val_29 = val_28.dateData.AddDays(value:  21);
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        val_27.properties.GOTDDontShowUntil = val_29;
        val_38 = null;
        label_45:
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_30.properties == null)
        {
                throw new NullReferenceException();
        }
        
        val_30.properties.GOTDDaysSeenWoInstallation = 0;
        label_52:
        this.ClearCurrentPromo();
        return;
        label_3:
        this.<promoPackageName>k__BackingField = val_5;
        throw new NullReferenceException();
        label_4:
    }
    private object TryPickAPromo(System.Collections.Generic.List<object> networkPromos)
    {
        var val_7;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8;
        if(true == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((0.ContainsKey(key:  "manual")) != false)
        {
                object val_2 = 0.Item["manual"];
            var val_3 = (null != 0) ? 1 : 0;
        }
        else
        {
                val_7 = 0;
        }
        
        AppConfigs val_4 = App.Configuration;
        val_8 = 0;
        string val_5 = val_4.appConfig.Key(key:  "packageName");
        if(val_7 == 0)
        {
                return val_5.TryPickAPromo_Dynamic(networkPromos:  networkPromos, head:  val_8, currentGamePackage:  val_5);
        }
        
        val_8 = 0;
        object val_6 = val_5.TryPickAPromo_Manual(networkPromos:  networkPromos, head:  val_8, currentGamePackage:  val_5);
        if(val_6 == null)
        {
                return val_5.TryPickAPromo_Dynamic(networkPromos:  networkPromos, head:  val_8, currentGamePackage:  val_5);
        }
        
        return val_6;
    }
    private object TryPickAPromo_Manual(System.Collections.Generic.List<object> networkPromos, System.Collections.Generic.Dictionary<string, object> head, string currentGamePackage)
    {
        string val_15;
        var val_16;
        var val_17;
        val_15 = currentGamePackage;
        object val_1 = head.Item["package_name"];
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        val_16 = 0;
        if((System.String.op_Equality(a:  val_1, b:  val_15)) == true)
        {
                return (object)val_16;
        }
        
        val_16 = 0;
        if((twelvegigs.plugins.InstalledAppsPlugin.IsInstalled(packageToCheck:  val_1)) == true)
        {
                return (object)val_16;
        }
        
        val_15 = 1152921504884269056;
        if(App.Player.PromotedGames != null)
        {
                if((App.Player.PromotedGames.ContainsKey(key:  val_1)) != false)
        {
                val_15 = 1152921504975536128;
            val_17 = null;
            val_17 = null;
            bool val_12 = System.String.op_Equality(a:  App.Player.PromotedGames.Item[val_1], b:  GameOfTheDay.INSTALLED);
            val_16 = 0;
            if(val_12 == true)
        {
                return (object)val_16;
        }
        
        }
        
            if(val_12 != true)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_16 = mem[val_12 + 32];
            val_16 = val_12 + 32;
            return (object)val_16;
        }
        
        val_16 = 0;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return (object)val_16;
        }
        
        UnityEngine.Debug.LogError(message:  "App.Player.PromotedGames was null when trying to do GameOfTheDay");
        val_16 = 0;
        return (object)val_16;
        label_3:
    }
    private object TryPickAPromo_Dynamic(System.Collections.Generic.List<object> networkPromos, System.Collections.Generic.Dictionary<string, object> head, string currentGamePackage)
    {
        object val_3;
        var val_4;
        var val_20;
        string val_21;
        var val_22;
        System.Collections.Generic.List<T> val_23;
        var val_24;
        System.Collections.Generic.List<System.Object> val_1 = null;
        val_21 = public System.Void System.Collections.Generic.List<System.Object>::.ctor();
        val_1 = new System.Collections.Generic.List<System.Object>();
        if(networkPromos == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_2 = networkPromos.GetEnumerator();
        label_29:
        val_21 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_21 = null;
        object val_6 = val_3.Item["package_name"];
        if(val_6 == null)
        {
            goto label_6;
        }
        
        val_21 = null;
        if(null != val_21)
        {
            goto label_7;
        }
        
        label_6:
        if((System.String.op_Equality(a:  val_6, b:  currentGamePackage)) == true)
        {
            goto label_29;
        }
        
        val_21 = 0;
        if((twelvegigs.plugins.InstalledAppsPlugin.IsInstalled(packageToCheck:  val_6)) == true)
        {
            goto label_29;
        }
        
        Player val_9 = App.Player;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21 = 0;
        if(val_9.PromotedGames == null)
        {
            goto label_29;
        }
        
        Player val_11 = App.Player;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21 = 0;
        System.Collections.Generic.Dictionary<System.String, System.String> val_12 = val_11.PromotedGames;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21 = val_6;
        if((val_12.ContainsKey(key:  val_21)) == false)
        {
            goto label_20;
        }
        
        Player val_14 = App.Player;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21 = 0;
        System.Collections.Generic.Dictionary<System.String, System.String> val_15 = val_14.PromotedGames;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = null;
        val_22 = null;
        if((System.String.op_Equality(a:  val_15.Item[val_6], b:  GameOfTheDay.INSTALLED)) == true)
        {
            goto label_29;
        }
        
        label_20:
        val_1.Add(item:  val_3);
        goto label_29;
        label_2:
        val_21 = public System.Void List.Enumerator<System.Object>::Dispose();
        val_4.Dispose();
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(mem[1152921517565641912] != 0)
        {
                int val_18 = UnityEngine.Random.Range(min:  0, max:  mem[1152921517565641912]);
            val_23 = val_1;
            if(mem[1152921517565641912] <= val_18)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_23 = val_1;
        }
        
            var val_19 = mem[1152921517565641904];
            val_19 = val_19 + (val_18 << 3);
            val_24 = mem[(mem[1152921517565641904] + (val_18) << 3) + 32];
            val_24 = (mem[1152921517565641904] + (val_18) << 3) + 32;
            return (object)val_24;
        }
        
        val_24 = 0;
        return (object)val_24;
        label_7:
        val_20 = X22;
        throw new NullReferenceException();
    }
    public GameOfTheDay()
    {
    
    }
    private static GameOfTheDay()
    {
        GameOfTheDay.current_promo_key = "current_game_of_the_day";
        GameOfTheDay.INSTALLED = "INSTALLED";
        GameOfTheDay.NON_INSTALLED = "NON_INSTALLED";
        GameOfTheDay.currentStatus = "";
    }

}
