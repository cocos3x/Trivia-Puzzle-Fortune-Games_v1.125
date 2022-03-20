using UnityEngine;
public class GameEventV2
{
    // Fields
    public int serverTimestamp;
    public System.DateTime lastTimestamp;
    public System.DateTime timeStart;
    public System.DateTime timeEnd;
    public System.DateTime timeExpire;
    public int id;
    public string name;
    public string type;
    public bool masterEnable;
    public bool isDownloaded;
    private bool <inExpireInterval>k__BackingField;
    private string dlcJson;
    public string eventDataJson;
    public System.Collections.Generic.Dictionary<string, object> eventData;
    public int minPlayerLevel;
    public UnityEngine.AssetBundle downloadedBundle;
    
    // Properties
    public bool inExpireInterval { get; set; }
    
    // Methods
    public bool get_inExpireInterval()
    {
        return (bool)this.<inExpireInterval>k__BackingField;
    }
    private void set_inExpireInterval(bool value)
    {
        this.<inExpireInterval>k__BackingField = value;
    }
    public void init(System.Collections.IDictionary desc)
    {
        var val_15;
        var val_17;
        var val_19;
        var val_21;
        var val_23;
        object val_24;
        var val_26;
        var val_28;
        var val_21 = 0;
        val_21 = val_21 + 1;
        val_15 = public System.Object System.Collections.IDictionary::get_Item(object key);
        this.id = System.Int32.Parse(s:  desc.Item["id"]);
        this.update(data:  desc);
        var val_22 = 0;
        val_22 = val_22 + 1;
        val_15 = 4;
        val_17 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((desc.Contains(key:  "start")) != true)
        {
                System.DateTime val_6 = DateTimeCheat.UtcNow;
            this.timeStart = val_6;
        }
        
        var val_23 = 0;
        val_23 = val_23 + 1;
        val_17 = 4;
        val_19 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((desc.Contains(key:  "end")) != true)
        {
                System.DateTime val_9 = DateTimeCheat.UtcNow;
            System.DateTime val_10 = val_9.dateData.AddDays(value:  7);
            this.timeEnd = val_10;
        }
        
        var val_24 = 0;
        val_24 = val_24 + 1;
        val_19 = 4;
        val_21 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((desc.Contains(key:  "expire")) != true)
        {
                this.timeExpire = this.timeEnd;
        }
        
        var val_25 = 0;
        val_25 = val_25 + 1;
        val_21 = 4;
        val_23 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((desc.Contains(key:  "enable")) != true)
        {
                this.masterEnable = true;
        }
        
        val_24 = "data";
        var val_26 = 0;
        val_26 = val_26 + 1;
        val_23 = 4;
        val_26 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((desc.Contains(key:  val_24)) != false)
        {
                val_24 = "data";
            var val_27 = 0;
            val_27 = val_27 + 1;
            val_26 = 0;
            if(desc.Item[val_24] != null)
        {
                object val_19 = MiniJSON.Json.Deserialize(json:  this.eventDataJson);
            val_28 = 0;
            this.eventData = ;
        }
        
        }
        
        this.CheckDownloadDLC();
    }
    public void update(System.Collections.IDictionary data)
    {
        var val_42;
        var val_43;
        var val_45;
        var val_47;
        var val_48;
        var val_50;
        var val_52;
        var val_53;
        var val_55;
        var val_57;
        var val_58;
        var val_60;
        var val_62;
        var val_63;
        var val_65;
        var val_67;
        var val_68;
        var val_70;
        var val_72;
        var val_73;
        var val_75;
        var val_77;
        var val_78;
        var val_80;
        var val_81;
        var val_83;
        var val_85;
        var val_86;
        var val_88;
        var val_90;
        var val_91;
        var val_93;
        var val_94;
        var val_96;
        var val_97;
        object val_98;
        var val_100;
        System.DateTime val_2 = MonoSingleton<GameEventsManager>.Instance.ServerTime;
        this.lastTimestamp = val_2;
        var val_65 = 0;
        val_65 = val_65 + 1;
        val_42 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "timestamp")) != false)
        {
                var val_66 = 0;
            val_66 = val_66 + 1;
            val_43 = 0;
            val_45 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.serverTimestamp = System.Int32.Parse(s:  data.Item["timestamp"]);
        }
        
        var val_67 = 0;
        val_67 = val_67 + 1;
        val_45 = 4;
        val_47 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "start")) != false)
        {
                var val_68 = 0;
            val_68 = val_68 + 1;
            val_48 = 0;
            val_50 = public System.Object System.Collections.IDictionary::get_Item(object key);
            System.DateTime val_13 = this.lastTimestamp.AddSeconds(value:  (double)System.Int32.Parse(s:  data.Item["start"]));
            this.timeStart = val_13;
        }
        
        var val_69 = 0;
        val_69 = val_69 + 1;
        val_50 = 4;
        val_52 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "end")) != false)
        {
                var val_70 = 0;
            val_70 = val_70 + 1;
            val_53 = 0;
            val_55 = public System.Object System.Collections.IDictionary::get_Item(object key);
            System.DateTime val_19 = this.lastTimestamp.AddSeconds(value:  (double)System.Int32.Parse(s:  data.Item["end"]));
            this.timeEnd = val_19;
        }
        
        var val_71 = 0;
        val_71 = val_71 + 1;
        val_55 = 4;
        val_57 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "expire")) != false)
        {
                var val_72 = 0;
            val_72 = val_72 + 1;
            val_58 = 0;
            val_60 = public System.Object System.Collections.IDictionary::get_Item(object key);
            System.DateTime val_25 = this.lastTimestamp.AddSeconds(value:  (double)System.Int32.Parse(s:  data.Item["expire"]));
            this.timeExpire = val_25;
        }
        
        var val_73 = 0;
        val_73 = val_73 + 1;
        val_60 = 4;
        val_62 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "type")) != false)
        {
                var val_74 = 0;
            val_74 = val_74 + 1;
            val_63 = 0;
            val_65 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.type = data.Item["type"];
        }
        
        var val_75 = 0;
        val_75 = val_75 + 1;
        val_65 = 4;
        val_67 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "name")) != false)
        {
                var val_76 = 0;
            val_76 = val_76 + 1;
            val_68 = 0;
            val_70 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.name = data.Item["name"];
        }
        
        var val_77 = 0;
        val_77 = val_77 + 1;
        val_70 = 4;
        val_72 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "enable")) != false)
        {
                var val_78 = 0;
            val_78 = val_78 + 1;
            val_73 = 0;
            val_75 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.masterEnable = System.Boolean.Parse(value:  data.Item["enable"]);
        }
        
        var val_79 = 0;
        val_79 = val_79 + 1;
        val_75 = 4;
        val_77 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "dlc")) != false)
        {
                var val_80 = 0;
            val_80 = val_80 + 1;
            val_78 = 0;
            val_80 = public System.Object System.Collections.IDictionary::get_Item(object key);
            if(data.Item["dlc"] != null)
        {
                var val_81 = 0;
            val_81 = val_81 + 1;
            val_81 = 0;
            val_83 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.dlcJson = data.Item["dlc"];
        }
        
        }
        
        var val_82 = 0;
        val_82 = val_82 + 1;
        val_83 = 4;
        val_85 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "in_expire_interval")) != false)
        {
                var val_83 = 0;
            val_83 = val_83 + 1;
            val_86 = 0;
            val_88 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.<inExpireInterval>k__BackingField = System.Boolean.Parse(value:  data.Item["in_expire_interval"]);
        }
        
        var val_84 = 0;
        val_84 = val_84 + 1;
        val_88 = 4;
        val_90 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "data")) != false)
        {
                var val_85 = 0;
            val_85 = val_85 + 1;
            val_91 = 0;
            val_93 = public System.Object System.Collections.IDictionary::get_Item(object key);
            if(data.Item["data"] != null)
        {
                var val_86 = 0;
            val_86 = val_86 + 1;
            val_94 = 0;
            val_96 = public System.Object System.Collections.IDictionary::get_Item(object key);
            object val_57 = data.Item["data"];
            this.eventDataJson = val_57;
            object val_58 = MiniJSON.Json.Deserialize(json:  val_57);
            val_97 = 0;
            this.eventData = ;
        }
        
        }
        
        val_98 = "unlock_level";
        var val_87 = 0;
        val_87 = val_87 + 1;
        val_96 = 4;
        val_100 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  val_98)) == false)
        {
                return;
        }
        
        val_98 = "unlock_level";
        var val_88 = 0;
        val_88 = val_88 + 1;
        val_100 = 0;
        this.minPlayerLevel = System.Int32.Parse(s:  data.Item[val_98]);
    }
    public System.Collections.Generic.Dictionary<string, object> Serialize()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "sts", value:  this.serverTimestamp);
        val_1.Add(key:  "lt", value:  this.lastTimestamp.ToString());
        val_1.Add(key:  "ts", value:  this.timeStart.ToString());
        val_1.Add(key:  "te", value:  this.timeEnd.ToString());
        val_1.Add(key:  "tx", value:  this.timeExpire.ToString());
        val_1.Add(key:  "id", value:  this.id);
        val_1.Add(key:  "n", value:  this.name);
        val_1.Add(key:  "t", value:  this.type);
        val_1.Add(key:  "me", value:  this.masterEnable.ToString());
        val_1.Add(key:  "dlc", value:  this.dlcJson);
        val_1.Add(key:  "dat", value:  this.eventDataJson);
        val_1.Add(key:  "mpl", value:  this.minPlayerLevel);
        return val_1;
    }
    public void Deserialize(System.Collections.IDictionary data)
    {
        var val_35;
        var val_36;
        var val_38;
        var val_40;
        var val_41;
        var val_43;
        var val_45;
        var val_46;
        var val_48;
        var val_50;
        var val_51;
        var val_53;
        var val_55;
        var val_56;
        var val_58;
        var val_60;
        var val_61;
        var val_63;
        var val_65;
        var val_66;
        var val_68;
        var val_70;
        var val_71;
        var val_73;
        var val_75;
        var val_76;
        var val_78;
        var val_80;
        var val_81;
        var val_83;
        var val_85;
        var val_86;
        var val_88;
        object val_89;
        var val_91;
        var val_58 = 0;
        val_58 = val_58 + 1;
        val_35 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "sts")) != false)
        {
                var val_59 = 0;
            val_59 = val_59 + 1;
            val_36 = 0;
            val_38 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.serverTimestamp = System.Int32.Parse(s:  data.Item["sts"]);
        }
        
        var val_60 = 0;
        val_60 = val_60 + 1;
        val_38 = 4;
        val_40 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "lt")) != false)
        {
                var val_61 = 0;
            val_61 = val_61 + 1;
            val_41 = 0;
            val_43 = public System.Object System.Collections.IDictionary::get_Item(object key);
            System.DateTime val_10 = System.DateTime.Parse(s:  data.Item["lt"]);
            this.lastTimestamp = val_10;
        }
        
        var val_62 = 0;
        val_62 = val_62 + 1;
        val_43 = 4;
        val_45 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "ts")) != false)
        {
                var val_63 = 0;
            val_63 = val_63 + 1;
            val_46 = 0;
            val_48 = public System.Object System.Collections.IDictionary::get_Item(object key);
            System.DateTime val_15 = System.DateTime.Parse(s:  data.Item["ts"]);
            this.timeStart = val_15;
        }
        
        var val_64 = 0;
        val_64 = val_64 + 1;
        val_48 = 4;
        val_50 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "te")) != false)
        {
                var val_65 = 0;
            val_65 = val_65 + 1;
            val_51 = 0;
            val_53 = public System.Object System.Collections.IDictionary::get_Item(object key);
            System.DateTime val_20 = System.DateTime.Parse(s:  data.Item["te"]);
            this.timeEnd = val_20;
        }
        
        var val_66 = 0;
        val_66 = val_66 + 1;
        val_53 = 4;
        val_55 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "tx")) != false)
        {
                var val_67 = 0;
            val_67 = val_67 + 1;
            val_56 = 0;
            val_58 = public System.Object System.Collections.IDictionary::get_Item(object key);
            System.DateTime val_25 = System.DateTime.Parse(s:  data.Item["tx"]);
            this.timeExpire = val_25;
        }
        
        var val_68 = 0;
        val_68 = val_68 + 1;
        val_58 = 4;
        val_60 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "id")) != false)
        {
                var val_69 = 0;
            val_69 = val_69 + 1;
            val_61 = 0;
            val_63 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.id = System.Int32.Parse(s:  data.Item["id"]);
        }
        
        var val_70 = 0;
        val_70 = val_70 + 1;
        val_63 = 4;
        val_65 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "n")) != false)
        {
                var val_71 = 0;
            val_71 = val_71 + 1;
            val_66 = 0;
            val_68 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.name = data.Item["n"];
        }
        
        var val_72 = 0;
        val_72 = val_72 + 1;
        val_68 = 4;
        val_70 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "t")) != false)
        {
                var val_73 = 0;
            val_73 = val_73 + 1;
            val_71 = 0;
            val_73 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.type = data.Item["t"];
        }
        
        var val_74 = 0;
        val_74 = val_74 + 1;
        val_73 = 4;
        val_75 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "me")) != false)
        {
                var val_75 = 0;
            val_75 = val_75 + 1;
            val_76 = 0;
            val_78 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.masterEnable = System.Boolean.Parse(value:  data.Item["me"]);
        }
        
        var val_76 = 0;
        val_76 = val_76 + 1;
        val_78 = 4;
        val_80 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "dlc")) != false)
        {
                var val_77 = 0;
            val_77 = val_77 + 1;
            val_81 = 0;
            val_83 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.dlcJson = data.Item["dlc"];
        }
        
        var val_78 = 0;
        val_78 = val_78 + 1;
        val_83 = 4;
        val_85 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  "dat")) != false)
        {
                var val_79 = 0;
            val_79 = val_79 + 1;
            val_86 = 0;
            val_88 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.eventDataJson = data.Item["dat"];
        }
        
        val_89 = "mpl";
        var val_80 = 0;
        val_80 = val_80 + 1;
        val_88 = 4;
        val_91 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((data.Contains(key:  val_89)) != false)
        {
                val_89 = "mpl";
            var val_81 = 0;
            val_81 = val_81 + 1;
            val_91 = 0;
            this.minPlayerLevel = System.Int32.Parse(s:  data.Item[val_89]);
        }
        
        this.CheckDownloadDLC();
    }
    public GameEventV2.Phase GetPhase()
    {
        System.DateTime val_12;
        var val_13;
        val_12 = this;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((this.timeStart.CompareTo(value:  new System.DateTime() {dateData = val_1.dateData})) > 0)
        {
                val_13 = 1;
            return (Phase)val_13;
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        if((this.timeEnd.CompareTo(value:  new System.DateTime() {dateData = val_3.dateData})) > 0)
        {
                val_13 = 2;
            return (Phase)val_13;
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        val_12 = this.timeExpire;
        if(((this.timeEnd.CompareTo(value:  new System.DateTime() {dateData = val_5.dateData})) & 2147483648) != 0)
        {
            goto label_11;
        }
        
        label_17:
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        val_13 = ((val_12.CompareTo(value:  new System.DateTime() {dateData = val_7.dateData})) >> 29) & 4;
        return (Phase)val_13;
        label_11:
        System.DateTime val_10 = DateTimeCheat.UtcNow;
        if((val_12.CompareTo(value:  new System.DateTime() {dateData = val_10.dateData})) <= 0)
        {
            goto label_17;
        }
        
        val_13 = 3;
        return (Phase)val_13;
    }
    private void CheckDownloadDLC()
    {
        if((System.String.IsNullOrEmpty(value:  this.dlcJson)) != false)
        {
                this.isDownloaded = true;
            return;
        }
        
        if(this.isDownloaded != false)
        {
                return;
        }
        
        this.isDownloaded = false;
        UnityEngine.Debug.LogError(message:  "TODO - Not Implemented: Download GameEvent dlc for UGUI?");
    }
    public void OnDownloaded(UnityEngine.AssetBundle downloadedAssetBundle)
    {
        this.downloadedBundle = downloadedAssetBundle;
        this.isDownloaded = true;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnGameEventDataDownloaded");
    }
    public GameEventV2()
    {
        this.name = "";
        this.type = "";
        this.dlcJson = "";
        this.eventDataJson = "";
    }

}
