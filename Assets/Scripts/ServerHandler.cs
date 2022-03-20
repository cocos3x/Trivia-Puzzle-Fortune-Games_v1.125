using UnityEngine;
public class ServerHandler : DefaultHandler<ServerHandler>
{
    // Fields
    public const string ONSERVERRESPONDED = "OnServerResponded";
    public const string ONSERVERFAILED = "OnServerFailed";
    private bool inRequest;
    private bool _allowServerConnect;
    private static System.DateTime epocStart;
    private float _lastServerTimeUpate;
    private System.DateTime _serverTime;
    private System.Collections.Generic.List<Award> currentAwards;
    public const string awardKey = "awards_available";
    private System.Collections.Generic.List<MessageParams> _ParsedMessages;
    public const string ONSERVERIMPORTRESPONDED = "OnServerImportResponded";
    public const string ONSERVERIMPORTFAILED = "OnServerImportFailed";
    private static bool initialized;
    private const string missed_msgs_key = "missed_messages";
    
    // Properties
    public bool InRequesting { get; }
    public bool AllowServerConnection { get; }
    public static System.DateTime ServerTime { get; }
    public static int UnixServerTime { get; }
    public static System.Collections.Generic.List<Award> Awards { get; }
    public System.Collections.Generic.List<MessageParams> ParsedMessages { get; }
    
    // Methods
    public bool get_InRequesting()
    {
        return (bool)this.inRequest;
    }
    public bool get_AllowServerConnection()
    {
        return (bool)this._allowServerConnect;
    }
    public static System.DateTime get_ServerTime()
    {
        ServerHandler val_1 = DefaultHandler<ServerHandler>.Instance;
        ServerHandler val_3 = DefaultHandler<ServerHandler>.Instance;
        float val_4 = val_3._lastServerTimeUpate;
        val_4 = UnityEngine.Time.unscaledTime - val_4;
        return val_1._serverTime.AddSeconds(value:  (double)val_4);
    }
    public static int get_UnixServerTime()
    {
        System.DateTime val_1 = ServerHandler.ServerTime;
        System.TimeSpan val_2 = val_1.dateData.Subtract(value:  new System.DateTime() {dateData = ServerHandler.missed_msgs_key});
        double val_3 = val_2._ticks.TotalSeconds;
        val_3 = (val_3 == Infinity) ? (-val_3) : (val_3);
        return (int)(int)val_3;
    }
    public void RequestDataFlush(bool immediate = False, bool reset = False)
    {
        string val_23;
        string val_24;
        string val_25;
        var val_26;
        var val_27;
        var val_28;
        System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_29;
        var val_30;
        var val_31;
        var val_32;
        var val_33;
        val_24 = reset;
        val_25 = immediate;
        val_26 = null;
        val_26 = null;
        if(App.networkManager == null)
        {
                return;
        }
        
        if(this.inRequest != false)
        {
                if(val_25 == false)
        {
                return;
        }
        
        }
        
        val_27 = null;
        val_27 = null;
        if(App.networkManager.Reachable() == false)
        {
                return;
        }
        
        Player val_2 = this.Player;
        val_23 = val_2.uuid;
        val_28 = null;
        val_28 = null;
        if((System.String.op_Inequality(a:  val_23, b:  DeviceIdPlugin.UNIDENTIFIABLE_ANDROID_DEVICE)) == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = null;
        val_23 = val_4;
        val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_5 = null;
        val_29 = val_5;
        val_5 = new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void ServerHandler::OnRequestResponse(string method, System.Collections.Generic.Dictionary<string, object> response));
        if(val_25 == false)
        {
            goto label_20;
        }
        
        val_4.Add(key:  "no_update", value:  true);
        val_29 = 0;
        if(val_24 == true)
        {
            goto label_22;
        }
        
        goto label_24;
        label_20:
        this.inRequest = true;
        if(val_24 == false)
        {
            goto label_24;
        }
        
        label_22:
        val_4.Add(key:  "hard_reset", value:  true);
        label_24:
        Player val_6 = this.Player;
        if((val_6.id.Equals(value:  " ")) != false)
        {
                val_25 = "/api/users";
            val_30 = null;
            val_30 = null;
            val_24 = 1152921515419383392;
            val_4.Add(key:  "versions", value:  App.storageManager.EncodeInitialVersions());
            Player val_9 = this.Player;
            val_4.Add(key:  "device", value:  val_9.uuid);
            Player val_10 = this.Player;
            val_4.Add(key:  "bucket", value:  val_10.playerBucket);
            val_4.Add(key:  "device_properties", value:  this.Player.GetDeviceProperties());
            val_4.Add(key:  "ps_knobs", value:  true);
            val_4.AddFacebookParameters(parameters: ref  val_4);
            val_31 = null;
            val_31 = null;
            App.networkManager.DoPost(path:  val_25, postBody:  val_4, onCompleteFunction:  val_5, timeout:  20, destroy:  false, immediate:  false, serverType:  0);
            return;
        }
        
        Player val_13 = this.Player;
        val_24 = "/api/users/"("/api/users/") + val_13.id;
        val_32 = null;
        val_32 = null;
        val_4.Add(key:  "versions", value:  App.storageManager.EncodeInitialVersions());
        Player val_18 = this.Player;
        val_4.Add(key:  "device", value:  val_18.uuid);
        val_4.Add(key:  "user", value:  this.Player.Encode());
        Player val_19 = this.Player;
        val_4.Add(key:  "bucket", value:  val_19.playerBucket);
        val_4.Add(key:  "device_properties", value:  this.Player.GetDeviceProperties());
        val_4.Add(key:  "ps_knobs", value:  true);
        val_4.Add(key:  "_method", value:  "PUT");
        val_4.AddFacebookParameters(parameters: ref  val_4);
        val_33 = null;
        val_33 = null;
        App.networkManager.DoPut(path:  val_24, postBody:  val_4, onCompleteFunction:  val_5, timeout:  20, destroy:  false, immediate:  val_25);
    }
    public virtual void InjectAdditionalPlayerData(ref System.Collections.Generic.Dictionary<string, object> encodedPlayerData)
    {
        Player val_1 = this.Player;
        encodedPlayerData.Add(key:  "deviceId", value:  val_1.uuid);
        if((MonoSingleton<WADPetsManager>.Instance) == 0)
        {
                return;
        }
        
        encodedPlayerData.Add(key:  "pets", value:  MiniJSON.Json.Serialize(obj:  MonoSingleton<WADPetsManager>.Instance.SerializeUnlockedPets()));
    }
    private void OnRequestResponse(string method, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        this.inRequest = false;
        if(response == null)
        {
            goto label_13;
        }
        
        if((response.ContainsKey(key:  "no_server_data")) != false)
        {
                this._allowServerConnect = false;
            UnityEngine.Debug.LogWarning(message:  "NO SERVER DATA ALLOWED RESPONSE RECEIVED");
        }
        
        val_11 = "meta";
        if((response.ContainsKey(key:  "meta")) == false)
        {
            goto label_13;
        }
        
        val_12 = public System.Object System.Collections.Generic.Dictionary<System.String, System.Object>::get_Item(System.String key);
        object val_3 = response.Item["meta"];
        val_13 = 1152921504683257856;
        if(X0 == false)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_14 = null;
        if(X0 == false)
        {
                throw new IndexOutOfRangeException();
        }
        
        var val_14 = X0;
        if((X0 + 294) == 0)
        {
            goto label_9;
        }
        
        var val_11 = X0 + 176;
        var val_12 = 0;
        val_11 = val_11 + 8;
        label_11:
        if(((X0 + 176 + 8) + -8) == val_14)
        {
            goto label_10;
        }
        
        val_12 = val_12 + 1;
        val_11 = val_11 + 16;
        if(val_12 < (X0 + 294))
        {
            goto label_11;
        }
        
        label_9:
        val_12 = 4;
        goto label_12;
        label_10:
        var val_13 = val_11;
        val_13 = val_13 + 4;
        val_14 = val_14 + val_13;
        val_15 = val_14 + 304;
        label_12:
        if((X0.Contains(key:  "versions")) != false)
        {
                char[] val_5 = new char[1];
            val_5[0] = '/';
            if((System.String.op_Equality(a:  method.Split(separator:  val_5)[4], b:  "users")) == false)
        {
                return;
        }
        
            this.UpdatedFromServer(serverResponse:  response, forceUpdate:  false);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnServerResponded", aData:  new System.Collections.Hashtable());
            return;
        }
        
        label_13:
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnServerFailed");
    }
    public void UpdatedFromServer(System.Collections.Generic.Dictionary<string, object> serverResponse, bool forceUpdate = False)
    {
        var val_18;
        var val_19;
        Player val_1 = App.Player;
        val_1.<forceUpdateFromServer>k__BackingField = forceUpdate;
        if((serverResponse.ContainsKey(key:  "user")) != false)
        {
                object val_4 = serverResponse.Item["user"];
            val_18 = 0;
            this.UpdateUserData(userData:  null);
        }
        
        this.UpdateFeatures(response:  serverResponse);
        val_19 = null;
        val_19 = null;
        App.storageManager.OnDataUpdate(response:  serverResponse);
        if((serverResponse.ContainsKey(key:  "srv_time")) != false)
        {
                decimal val_7 = System.Decimal.Parse(s:  serverResponse.Item["srv_time"]);
            System.DateTime val_8 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
            this._serverTime = val_8;
            this._lastServerTimeUpate = UnityEngine.Time.unscaledTime;
            System.DateTime val_10 = System.DateTime.UtcNow;
            System.DateTime val_11 = ServerHandler.ServerTime;
            System.TimeSpan val_12 = val_10.dateData.Subtract(value:  new System.DateTime() {dateData = val_11.dateData});
            System.TimeSpan val_13 = val_12._ticks.Duration();
            if(val_13._ticks.TotalHours > 12)
        {
                bool val_16 = CompanyDevices.Instance.CompanyDevice();
        }
        
        }
        
        App.Player.SaveState();
    }
    private void UpdateUserData(System.Collections.IDictionary userData)
    {
        this.Player.UpdateData(diff:  userData);
    }
    public static System.Collections.Generic.List<Award> get_Awards()
    {
        ServerHandler val_1 = DefaultHandler<ServerHandler>.Instance;
        return (System.Collections.Generic.List<Award>)val_1.currentAwards;
    }
    public void AddAward(Award award)
    {
        this.currentAwards.Add(item:  new Award() {id = award.id, kind = award.id, amount = new System.Decimal() {flags = award.amount.flags}, text = award.text});
        this.SaveCurrent();
    }
    public void RefreshAwards()
    {
        bool val_2 = true;
        System.Collections.Generic.List<Award> val_1 = this.ParseCurrent();
        if(val_2 < 1)
        {
                return;
        }
        
        var val_3 = 0;
        var val_4 = 32;
        do
        {
            if(val_3 >= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2 = val_2 + val_4;
            this.currentAwards.Add(item:  new Award() {id = val_2, kind = val_2, amount = new System.Decimal() {flags = (true + 32) + 16, hi = (true + 32) + 16, lo = (true + 32) + 16, mid = (true + 32) + 16}, text = (true + 32) + 32});
            val_3 = val_3 + 1;
            val_4 = val_4 + 40;
        }
        while(val_3 < ((true + 32) + 32));
    
    }
    public void CashOutAward(string id)
    {
        System.Collections.Generic.List<Award> val_4;
        var val_5;
        string val_6;
        bool val_3 = true;
        val_4 = this.currentAwards;
        if(val_3 < 1)
        {
                return;
        }
        
        val_5 = 0;
        val_6 = 0;
        var val_4 = 0;
        label_6:
        if(val_4 >= val_3)
        {
            goto label_7;
        }
        
        val_3 = val_3 & 4294967295;
        if(val_4 >= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + val_5;
        val_6 = mem[((true & 4294967295) + val_5) + 32];
        val_6 = ((true & 4294967295) + val_5) + 32;
        if((System.String.op_Equality(a:  id, b:  val_6)) == true)
        {
            goto label_5;
        }
        
        val_4 = this.currentAwards;
        val_4 = val_4 + 1;
        val_5 = val_5 + 40;
        if(val_4 != null)
        {
            goto label_6;
        }
        
        throw new NullReferenceException();
        label_5:
        val_4 = this.currentAwards;
        label_7:
        if((val_4.Contains(item:  new Award() {id = val_6, kind = ((true & 4294967295) + val_5) + 40, amount = new System.Decimal() {flags = ((true & 4294967295) + val_5) + 40, hi = ((true & 4294967295) + val_5) + 40, lo = ((true & 4294967295) + val_5) + 56, mid = ((true & 4294967295) + val_5) + 56}, text = ((true & 4294967295) + val_5) + 56})) == false)
        {
                return;
        }
        
        this.CashAward(current:  new Award() {id = val_6, kind = ((true & 4294967295) + val_5) + 40, amount = new System.Decimal() {flags = ((true & 4294967295) + val_5) + 40, hi = ((true & 4294967295) + val_5) + 40, lo = ((true & 4294967295) + val_5) + 56, mid = ((true & 4294967295) + val_5) + 56}, text = ((true & 4294967295) + val_5) + 56});
    }
    private void CashAward(Award current)
    {
        this.RewardPlayer(theType:  current.kind, amount:  new System.Decimal() {flags = current.amount.flags, hi = current.amount.flags, lo = current.amount.lo, mid = current.amount.lo}, sourceOfReward:  "Award");
        bool val_1 = this.currentAwards.Remove(item:  new Award() {id = current.id, kind = current.id, amount = new System.Decimal() {flags = current.amount.flags}, text = current.text});
        this.SaveCurrent();
    }
    private void AddFacebookParameters(ref System.Collections.Generic.Dictionary<string, object> parameters)
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "facebook_app_user_id", defaultValue:  "default");
        if((System.String.op_Equality(a:  val_1, b:  "default")) == true)
        {
                return;
        }
        
        if((System.String.op_Equality(a:  val_1, b:  "sent")) == true)
        {
                return;
        }
        
        if((System.String.op_Inequality(a:  UnityEngine.PlayerPrefs.GetString(key:  "sent_facebook_app_user_id", defaultValue:  "default"), b:  "default")) != false)
        {
                return;
        }
        
        parameters.Add(key:  "fb_auid", value:  val_1);
        UnityEngine.PlayerPrefs.SetString(key:  "sent_facebook_app_user_id", value:  "sent");
    }
    private void UpdateFeatures(System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_3;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = response;
        if(val_3 == null)
        {
                return;
        }
        
        if((val_3.ContainsKey(key:  "user")) == false)
        {
                return;
        }
        
        object val_2 = val_3.Item["user"];
        val_3 = 0;
        this.ProcessAwards(userFromServer:  null);
        this.ProcessMessages(userFromServer:  null);
    }
    public System.Collections.Generic.List<MessageParams> get_ParsedMessages()
    {
        return (System.Collections.Generic.List<MessageParams>)this._ParsedMessages;
    }
    private void ProcessMessages(System.Collections.Generic.Dictionary<string, object> userFromServer)
    {
        var val_5;
        var val_6;
        string val_17;
        System.Collections.Generic.List<MessageParams> val_18;
        string val_19;
        val_17 = userFromServer;
        val_18 = "notices";
        if((val_17.ContainsKey(key:  "notices")) == false)
        {
                return;
        }
        
        object val_2 = val_17.Item["notices"];
        List.Enumerator<T> val_4 = GetEnumerator();
        label_25:
        val_19 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19 = null;
        object val_8 = val_5.Item["msg"];
        val_17 = val_8;
        if(val_8 != null)
        {
                val_19 = null;
            if(null != val_19)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_19 = "ack";
        object val_10 = val_5.Item[val_19];
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = val_10;
        if((System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_19)) == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = null;
        val_19 = "loc";
        object val_12 = val_5.Item[val_19];
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        MessageParams val_15 = null;
        val_19 = val_17;
        val_15 = new MessageParams(message:  val_19, prompt:  1152921504626761728, localize:  System.Boolean.Parse(value:  val_12));
        if(mem[1152921515736086272] == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921515736086272].Add(item:  val_15);
        goto label_25;
        label_8:
        val_6.Dispose();
        val_18 = mem[1152921515736086272];
        ServerHandler.SaveQueuedToPlayerPrefs(queuedMessages:  val_18);
    }
    public void HackAGoddamnAward(Award awerd)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "kind", value:  awerd.kind);
        val_2.Add(key:  "amount", value:  awerd.amount.flags);
        System.Collections.Generic.List<System.Object> val_3 = new System.Collections.Generic.List<System.Object>();
        val_3.Add(item:  val_2);
        val_1.Add(key:  "awards", value:  val_3);
        this.ProcessAwards(userFromServer:  val_1);
    }
    public void HackMultipleGoddamnAwards(System.Collections.Generic.List<Award> awerds)
    {
        object val_5;
        object val_6;
        object val_7;
        var val_10;
        string val_11;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.Collections.Generic.List<System.Object> val_2 = new System.Collections.Generic.List<System.Object>();
        List.Enumerator<T> val_3 = awerds.GetEnumerator();
        label_5:
        if(val_7.MoveNext() == false)
        {
            goto label_2;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_9 = null;
        val_11 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::.ctor();
        val_9 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9.Add(key:  "kind", value:  val_6);
        val_7 = val_5;
        val_11 = "amount";
        val_10 = val_9;
        val_9.Add(key:  val_11, value:  val_7);
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(item:  val_9);
        goto label_5;
        label_2:
        val_7.Dispose();
        val_1.Add(key:  "awards", value:  val_2);
        this.ProcessAwards(userFromServer:  val_1);
    }
    private void ProcessAwards(System.Collections.Generic.Dictionary<string, object> userFromServer)
    {
        UnityEngine.Object val_114;
        var val_115;
        var val_116;
        int val_117;
        var val_118;
        var val_121;
        var val_122;
        var val_123;
        var val_124;
        var val_125;
        var val_126;
        var val_127;
        var val_128;
        var val_129;
        var val_130;
        var val_131;
        int val_132;
        int val_133;
        int val_134;
        int val_135;
        var val_136;
        var val_137;
        var val_138;
        var val_139;
        var val_140;
        int val_141;
        int val_142;
        int val_143;
        int val_144;
        var val_145;
        var val_146;
        string val_147;
        var val_148;
        var val_149;
        var val_150;
        int val_151;
        int val_152;
        int val_153;
        int val_154;
        var val_155;
        var val_156;
        var val_157;
        var val_158;
        int val_159;
        int val_160;
        int val_161;
        int val_162;
        var val_163;
        var val_164;
        int val_165;
        int val_166;
        int val_167;
        int val_168;
        var val_169;
        if(userFromServer == null)
        {
                throw new NullReferenceException();
        }
        
        val_114 = "awards";
        if((userFromServer.ContainsKey(key:  "awards")) == false)
        {
                return;
        }
        
        val_115 = public System.Object System.Collections.Generic.Dictionary<System.String, System.Object>::get_Item(System.String key);
        mem[1152921515736758184] = userFromServer.Item["awards"].ParseCurrent();
        if(X0 == false)
        {
                throw new NullReferenceException();
        }
        
        val_116 = null;
        val_117 = null;
        var val_118 = X0;
        if((X0 + 294) == 0)
        {
            goto label_4;
        }
        
        var val_116 = X0 + 176;
        var val_117 = 0;
        val_116 = val_116 + 8;
        label_6:
        if(((X0 + 176 + 8) + -8) == val_117)
        {
            goto label_5;
        }
        
        val_117 = val_117 + 1;
        val_116 = val_116 + 16;
        if(val_117 < (X0 + 294))
        {
            goto label_6;
        }
        
        label_4:
        val_116 = val_117;
        val_115 = 0;
        goto label_7;
        label_5:
        val_118 = val_118 + (((X0 + 176 + 8)) << 4);
        val_118 = val_118 + 304;
        label_7:
        System.Collections.IEnumerator val_4 = X0.GetEnumerator();
        label_280:
        var val_119 = 0;
        val_119 = val_119 + 1;
        val_115 = 0;
        if(val_4.MoveNext() == false)
        {
            goto label_13;
        }
        
        var val_120 = 0;
        val_120 = val_120 + 1;
        val_115 = 1;
        if(val_4.Current == null)
        {
                throw new NullReferenceException();
        }
        
        val_117 = X0;
        if(X0 == false)
        {
                throw new NullReferenceException();
        }
        
        var val_123 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_20;
        }
        
        var val_121 = X0 + 176;
        var val_122 = 0;
        val_121 = val_121 + 8;
        label_22:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_21;
        }
        
        val_122 = val_122 + 1;
        val_121 = val_121 + 16;
        if(val_122 < (X0 + 294))
        {
            goto label_22;
        }
        
        label_20:
        val_115 = 0;
        goto label_23;
        label_21:
        val_123 = val_123 + (((X0 + 176 + 8)) << 4);
        val_121 = val_123 + 304;
        label_23:
        object val_9 = val_117.Item["kind"];
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_122 = 0;
        if((System.String.op_Equality(a:  val_9, b:  "level")) == false)
        {
            goto label_25;
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        var val_130 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_29;
        }
        
        var val_124 = X0 + 176;
        var val_125 = 0;
        val_124 = val_124 + 8;
        label_31:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_30;
        }
        
        val_125 = val_125 + 1;
        val_124 = val_124 + 16;
        if(val_125 < (X0 + 294))
        {
            goto label_31;
        }
        
        label_29:
        val_122 = 0;
        goto label_32;
        label_25:
        val_124 = 0;
        if((System.String.op_Equality(a:  val_9, b:  "no_ads")) == false)
        {
            goto label_33;
        }
        
        AdsManager.HandlePurchase();
        var val_139 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_36;
        }
        
        var val_126 = X0 + 176;
        var val_127 = 0;
        val_126 = val_126 + 8;
        label_38:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_37;
        }
        
        val_127 = val_127 + 1;
        val_126 = val_126 + 16;
        if(val_127 < (X0 + 294))
        {
            goto label_38;
        }
        
        label_36:
        val_124 = 0;
        goto label_39;
        label_33:
        val_126 = 0;
        if((System.String.op_Equality(a:  val_9, b:  "total_purchase")) == false)
        {
            goto label_40;
        }
        
        var val_145 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_41;
        }
        
        var val_128 = X0 + 176;
        var val_129 = 0;
        val_128 = val_128 + 8;
        label_43:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_42;
        }
        
        val_129 = val_129 + 1;
        val_128 = val_128 + 16;
        if(val_129 < (X0 + 294))
        {
            goto label_43;
        }
        
        label_41:
        val_126 = 0;
        goto label_44;
        label_30:
        val_130 = val_130 + (((X0 + 176 + 8)) << 4);
        val_123 = val_130 + 304;
        label_32:
        object val_14 = val_117.Item["amount"];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_15 = System.Int32.Parse(s:  val_14);
        if((val_11.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        var val_133 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_47;
        }
        
        var val_131 = X0 + 176;
        var val_132 = 0;
        val_131 = val_131 + 8;
        label_49:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_48;
        }
        
        val_132 = val_132 + 1;
        val_131 = val_131 + 16;
        if(val_132 < (X0 + 294))
        {
            goto label_49;
        }
        
        label_47:
        val_128 = 0;
        goto label_50;
        label_48:
        val_133 = val_133 + (((X0 + 176 + 8)) << 4);
        val_129 = val_133 + 304;
        label_50:
        val_130 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_16 = val_117.Item["kind"];
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_136 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_52;
        }
        
        var val_134 = X0 + 176;
        var val_135 = 0;
        val_134 = val_134 + 8;
        label_54:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_53;
        }
        
        val_135 = val_135 + 1;
        val_134 = val_134 + 16;
        if(val_135 < (X0 + 294))
        {
            goto label_54;
        }
        
        label_52:
        val_130 = 0;
        goto label_55;
        label_53:
        val_136 = val_136 + (((X0 + 176 + 8)) << 4);
        val_131 = val_136 + 304;
        label_55:
        object val_17 = val_117.Item["amount"];
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        decimal val_18 = System.Decimal.Parse(s:  val_17, style:  511);
        val_117 = val_18.flags;
        object[] val_19 = new object[9];
        System.DateTime val_20 = System.DateTime.Now;
        string val_22 = val_20.dateData.Year.ToString();
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_22 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_132 = val_19.Length;
        if(val_132 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_19[0] = val_22;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_132 = val_19.Length;
        if(val_132 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_19[1] = "-";
        System.DateTime val_23 = System.DateTime.Now;
        string val_25 = val_23.dateData.Month.ToString(format:  "00");
        if(val_25 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_133 = val_19.Length;
        if(val_133 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_19[2] = val_25;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_133 = val_19.Length;
        if(val_133 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_19[3] = "-";
        System.DateTime val_26 = System.DateTime.Now;
        string val_28 = val_26.dateData.Day.ToString(format:  "00");
        if(val_28 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_134 = val_19.Length;
        if(val_134 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_19[4] = val_28;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_134 = val_19.Length;
        if(val_134 <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_19[5] = "_";
        System.DateTime val_29 = System.DateTime.Now;
        int val_30 = val_29.dateData.Millisecond;
        if(val_30 != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_135 = val_19.Length;
        if(val_135 <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_19[6] = val_30;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_135 = val_19.Length;
        if(val_135 <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_19[7] = "-";
        string val_32 = UnityEngine.Random.Range(min:  0, max:  999999999).ToString();
        if(val_32 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_19.Length <= 8)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_19[8] = val_32;
        if(mem[1152921515736758184] == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921515736758184].Add(item:  new Award() {id = +val_19, kind = val_16, amount = new System.Decimal() {flags = val_117, hi = val_18.hi, lo = val_18.lo, mid = val_18.mid}});
        goto label_280;
        label_40:
        val_136 = 0;
        if((System.String.op_Equality(a:  val_9, b:  "name_change")) == false)
        {
            goto label_91;
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        var val_156 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_95;
        }
        
        var val_137 = X0 + 176;
        var val_138 = 0;
        val_137 = val_137 + 8;
        label_97:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_96;
        }
        
        val_138 = val_138 + 1;
        val_137 = val_137 + 16;
        if(val_138 < (X0 + 294))
        {
            goto label_97;
        }
        
        label_95:
        val_137 = 0;
        goto label_98;
        label_37:
        val_139 = val_139 + (((X0 + 176 + 8)) << 4);
        val_125 = val_139 + 304;
        label_39:
        val_139 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_36 = val_117.Item["kind"];
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_142 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_100;
        }
        
        var val_140 = X0 + 176;
        var val_141 = 0;
        val_140 = val_140 + 8;
        label_102:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_101;
        }
        
        val_141 = val_141 + 1;
        val_140 = val_140 + 16;
        if(val_141 < (X0 + 294))
        {
            goto label_102;
        }
        
        label_100:
        val_139 = 0;
        goto label_103;
        label_101:
        val_142 = val_142 + (((X0 + 176 + 8)) << 4);
        val_140 = val_142 + 304;
        label_103:
        object val_37 = val_117.Item["amount"];
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        decimal val_38 = System.Decimal.Parse(s:  val_37, style:  511);
        val_117 = val_38.flags;
        object[] val_39 = new object[9];
        System.DateTime val_40 = System.DateTime.Now;
        string val_42 = val_40.dateData.Year.ToString();
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_42 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_141 = val_39.Length;
        if(val_141 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_39[0] = val_42;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_141 = val_39.Length;
        if(val_141 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_39[1] = "-";
        System.DateTime val_43 = System.DateTime.Now;
        string val_45 = val_43.dateData.Month.ToString(format:  "00");
        if(val_45 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_142 = val_39.Length;
        if(val_142 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_39[2] = val_45;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_142 = val_39.Length;
        if(val_142 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_39[3] = "-";
        System.DateTime val_46 = System.DateTime.Now;
        string val_48 = val_46.dateData.Day.ToString(format:  "00");
        if(val_48 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_143 = val_39.Length;
        if(val_143 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_39[4] = val_48;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_143 = val_39.Length;
        if(val_143 <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_39[5] = "_";
        System.DateTime val_49 = System.DateTime.Now;
        int val_50 = val_49.dateData.Millisecond;
        if(val_50 != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_144 = val_39.Length;
        if(val_144 <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_39[6] = val_50;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_144 = val_39.Length;
        if(val_144 <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_39[7] = "-";
        string val_52 = UnityEngine.Random.Range(min:  0, max:  999999999).ToString();
        if(val_52 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_39.Length <= 8)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_39[8] = val_52;
        if(mem[1152921515736758184] == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921515736758184].Add(item:  new Award() {id = +val_39, kind = val_36, amount = new System.Decimal() {flags = val_117, hi = val_38.hi, lo = val_38.lo, mid = val_38.mid}});
        goto label_280;
        label_91:
        var val_153 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_139;
        }
        
        var val_143 = X0 + 176;
        var val_144 = 0;
        val_143 = val_143 + 8;
        label_141:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_140;
        }
        
        val_144 = val_144 + 1;
        val_143 = val_143 + 16;
        if(val_144 < (X0 + 294))
        {
            goto label_141;
        }
        
        label_139:
        val_145 = 0;
        goto label_142;
        label_42:
        val_145 = val_145 + (((X0 + 176 + 8)) << 4);
        val_127 = val_145 + 304;
        label_44:
        object val_54 = val_117.Item["amount"];
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        float val_146 = (float)System.Int32.Parse(s:  val_54);
        val_146 = val_146 / 100f;
        val_56.total_purchased = val_146;
        AdsUIController val_57 = MonoSingleton<AdsUIController>.Instance;
        if(val_57 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57.HandlePurchase();
        NotificationCenter val_58 = NotificationCenter.DefaultCenter;
        if(val_58 == null)
        {
                throw new NullReferenceException();
        }
        
        val_147 = "UpdatePlayerVIPBar";
        val_58.PostNotification(aSender:  this, aName:  val_147);
        var val_149 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_153;
        }
        
        var val_147 = X0 + 176;
        var val_148 = 0;
        val_147 = val_147 + 8;
        label_155:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_154;
        }
        
        val_148 = val_148 + 1;
        val_147 = val_147 + 16;
        if(val_148 < (X0 + 294))
        {
            goto label_155;
        }
        
        label_153:
        val_147 = 0;
        goto label_156;
        label_154:
        val_149 = val_149 + (((X0 + 176 + 8)) << 4);
        val_148 = val_149 + 304;
        label_156:
        val_149 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_59 = val_117.Item["kind"];
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_152 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_158;
        }
        
        var val_150 = X0 + 176;
        var val_151 = 0;
        val_150 = val_150 + 8;
        label_160:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_159;
        }
        
        val_151 = val_151 + 1;
        val_150 = val_150 + 16;
        if(val_151 < (X0 + 294))
        {
            goto label_160;
        }
        
        label_158:
        val_149 = 0;
        goto label_161;
        label_159:
        val_152 = val_152 + (((X0 + 176 + 8)) << 4);
        val_150 = val_152 + 304;
        label_161:
        object val_60 = val_117.Item["amount"];
        if(val_60 == null)
        {
                throw new NullReferenceException();
        }
        
        decimal val_61 = System.Decimal.Parse(s:  val_60, style:  511);
        val_117 = val_61.flags;
        object[] val_62 = new object[9];
        System.DateTime val_63 = System.DateTime.Now;
        string val_65 = val_63.dateData.Year.ToString();
        if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_65 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_151 = val_62.Length;
        if(val_151 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[0] = val_65;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_151 = val_62.Length;
        if(val_151 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[1] = "-";
        System.DateTime val_66 = System.DateTime.Now;
        string val_68 = val_66.dateData.Month.ToString(format:  "00");
        if(val_68 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_152 = val_62.Length;
        if(val_152 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[2] = val_68;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_152 = val_62.Length;
        if(val_152 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[3] = "-";
        System.DateTime val_69 = System.DateTime.Now;
        string val_71 = val_69.dateData.Day.ToString(format:  "00");
        if(val_71 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_153 = val_62.Length;
        if(val_153 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[4] = val_71;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_153 = val_62.Length;
        if(val_153 <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[5] = "_";
        System.DateTime val_72 = System.DateTime.Now;
        int val_73 = val_72.dateData.Millisecond;
        if(val_73 != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_154 = val_62.Length;
        if(val_154 <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[6] = val_73;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_154 = val_62.Length;
        if(val_154 <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[7] = "-";
        string val_75 = UnityEngine.Random.Range(min:  0, max:  999999999).ToString();
        if(val_75 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_62.Length <= 8)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[8] = val_75;
        if(mem[1152921515736758184] == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921515736758184].Add(item:  new Award() {id = +val_62, kind = val_59, amount = new System.Decimal() {flags = val_117, hi = val_61.hi, lo = val_61.lo, mid = val_61.mid}});
        goto label_280;
        label_140:
        val_153 = val_153 + (((X0 + 176 + 8)) << 4);
        val_146 = val_153 + 304;
        label_142:
        val_155 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_77 = val_117.Item["kind"];
        if(val_77 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_159 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_198;
        }
        
        var val_154 = X0 + 176;
        var val_155 = 0;
        val_154 = val_154 + 8;
        label_200:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_199;
        }
        
        val_155 = val_155 + 1;
        val_154 = val_154 + 16;
        if(val_155 < (X0 + 294))
        {
            goto label_200;
        }
        
        label_198:
        val_155 = 0;
        goto label_201;
        label_96:
        val_156 = val_156 + (((X0 + 176 + 8)) << 4);
        val_138 = val_156 + 304;
        label_98:
        val_157 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_78 = val_117.Item["contents"];
        if(val_78 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_35.properties == null)
        {
                throw new NullReferenceException();
        }
        
        val_35.properties._profile_name = val_78;
        var val_160 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_204;
        }
        
        var val_157 = X0 + 176;
        var val_158 = 0;
        val_157 = val_157 + 8;
        label_206:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_205;
        }
        
        val_158 = val_158 + 1;
        val_157 = val_157 + 16;
        if(val_158 < (X0 + 294))
        {
            goto label_206;
        }
        
        label_204:
        val_157 = 0;
        goto label_207;
        label_199:
        val_159 = val_159 + (((X0 + 176 + 8)) << 4);
        val_156 = val_159 + 304;
        label_201:
        object val_79 = val_117.Item["amount"];
        if(val_79 == null)
        {
                throw new NullReferenceException();
        }
        
        decimal val_80 = System.Decimal.Parse(s:  val_79, style:  511);
        val_117 = val_80.flags;
        object[] val_81 = new object[9];
        System.DateTime val_82 = System.DateTime.Now;
        string val_84 = val_82.dateData.Year.ToString();
        if(val_81 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_84 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_159 = val_81.Length;
        if(val_159 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_81[0] = val_84;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_159 = val_81.Length;
        if(val_159 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_81[1] = "-";
        System.DateTime val_85 = System.DateTime.Now;
        string val_87 = val_85.dateData.Month.ToString(format:  "00");
        if(val_87 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_160 = val_81.Length;
        if(val_160 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_81[2] = val_87;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_160 = val_81.Length;
        if(val_160 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_81[3] = "-";
        System.DateTime val_88 = System.DateTime.Now;
        string val_90 = val_88.dateData.Day.ToString(format:  "00");
        if(val_90 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_161 = val_81.Length;
        if(val_161 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_81[4] = val_90;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_161 = val_81.Length;
        if(val_161 <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_81[5] = "_";
        System.DateTime val_91 = System.DateTime.Now;
        int val_92 = val_91.dateData.Millisecond;
        if(val_92 != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_162 = val_81.Length;
        val_81[6] = val_92;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_162 = val_81.Length;
        if(val_162 <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_81[7] = "-";
        string val_94 = UnityEngine.Random.Range(min:  0, max:  999999999).ToString();
        if(val_94 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_81.Length <= 8)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_81[8] = val_94;
        if(mem[1152921515736758184] == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921515736758184].Add(item:  new Award() {id = +val_81, kind = val_77, amount = new System.Decimal() {flags = val_117, hi = val_80.hi, lo = val_80.lo, mid = val_80.mid}});
        goto label_280;
        label_205:
        val_160 = val_160 + (((X0 + 176 + 8)) << 4);
        val_158 = val_160 + 304;
        label_207:
        val_163 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_96 = val_117.Item["kind"];
        if(val_96 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_163 = val_117;
        if((X0 + 294) == 0)
        {
            goto label_244;
        }
        
        var val_161 = X0 + 176;
        var val_162 = 0;
        val_161 = val_161 + 8;
        label_246:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_245;
        }
        
        val_162 = val_162 + 1;
        val_161 = val_161 + 16;
        if(val_162 < (X0 + 294))
        {
            goto label_246;
        }
        
        label_244:
        val_163 = 0;
        goto label_247;
        label_245:
        val_163 = val_163 + (((X0 + 176 + 8)) << 4);
        val_164 = val_163 + 304;
        label_247:
        object val_97 = val_117.Item["contents"];
        if(val_97 == null)
        {
                throw new NullReferenceException();
        }
        
        val_117 = val_97;
        object[] val_98 = new object[9];
        System.DateTime val_99 = System.DateTime.Now;
        string val_101 = val_99.dateData.Year.ToString();
        if(val_98 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_101 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_165 = val_98.Length;
        if(val_165 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_98[0] = val_101;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_165 = val_98.Length;
        if(val_165 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_98[1] = "-";
        System.DateTime val_102 = System.DateTime.Now;
        string val_104 = val_102.dateData.Month.ToString(format:  "00");
        if(val_104 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_166 = val_98.Length;
        if(val_166 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_98[2] = val_104;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_166 = val_98.Length;
        if(val_166 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_98[3] = "-";
        System.DateTime val_105 = System.DateTime.Now;
        string val_107 = val_105.dateData.Day.ToString(format:  "00");
        if(val_107 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_167 = val_98.Length;
        if(val_167 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_98[4] = val_107;
        val_167 = val_98.Length;
        if(val_167 <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_98[5] = "_";
        System.DateTime val_108 = System.DateTime.Now;
        int val_109 = val_108.dateData.Millisecond;
        if(val_109 != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_168 = val_98.Length;
        if(val_168 <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_98[6] = val_109;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_168 = val_98.Length;
        if(val_168 <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_98[7] = "-";
        string val_111 = UnityEngine.Random.Range(min:  0, max:  999999999).ToString();
        if(val_111 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_98.Length <= 8)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_98[8] = val_111;
        if(mem[1152921515736758184] == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921515736758184].Add(item:  new Award() {id = +val_98, kind = val_96, amount = new System.Decimal(), text = val_117});
        goto label_280;
        label_13:
        val_117 = 0;
        if(X0 == false)
        {
            goto label_281;
        }
        
        var val_166 = X0;
        if((X0 + 294) == 0)
        {
            goto label_285;
        }
        
        var val_164 = X0 + 176;
        var val_165 = 0;
        val_164 = val_164 + 8;
        label_284:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_283;
        }
        
        val_165 = val_165 + 1;
        val_164 = val_164 + 16;
        if(val_165 < (X0 + 294))
        {
            goto label_284;
        }
        
        goto label_285;
        label_283:
        val_166 = val_166 + (((X0 + 176 + 8)) << 4);
        val_169 = val_166 + 304;
        label_285:
        X0.Dispose();
        label_281:
        if(val_117 != 0)
        {
                throw val_117;
        }
        
        this.SaveCurrent();
        val_117 = 1152921515628071632;
        val_114 = MonoSingleton<AwardController>.Instance;
        if(val_114 == 0)
        {
                return;
        }
        
        AwardController val_115 = MonoSingleton<AwardController>.Instance;
        if(val_115 == null)
        {
                throw new NullReferenceException();
        }
        
        val_115.HandleUpdateFromServer();
    }
    public void ProcessCommand(string cmd)
    {
        System.Reflection.MethodInfo val_27;
        string val_28;
        string val_29;
        System.Reflection.MethodInfo val_30;
        System.Reflection.MethodInfo val_31;
        System.Object[] val_32;
        var val_33;
        System.Type val_34;
        object val_1 = MiniJSON.Json.Deserialize(json:  cmd);
        val_27 = 1152921510222861648;
        if((val_1.ContainsKey(key:  "cmd")) == false)
        {
            goto label_4;
        }
        
        object val_3 = val_1.Item["cmd"];
        val_28 = val_3;
        if((val_3 == null) || (null == null))
        {
            goto label_6;
        }
        
        label_4:
        val_28 = 0;
        label_6:
        if((val_1.ContainsKey(key:  "mtd")) == false)
        {
            goto label_7;
        }
        
        object val_5 = val_1.Item["mtd"];
        val_29 = val_5;
        if((val_5 == null) || (null == null))
        {
            goto label_9;
        }
        
        label_7:
        val_29 = 0;
        label_9:
        if((val_1.ContainsKey(key:  "prms")) != false)
        {
                object val_7 = val_1.Item["prms"];
            val_31 = null;
            val_32 = val_7.ToArray();
        }
        else
        {
                val_32 = 0;
        }
        
        if((System.Type.GetType(typeName:  val_28)) == null)
        {
                val_31 = 0;
            System.Type val_10 = System.Type.GetType(typeName:  val_28);
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_27 = val_10.GetMethod(name:  val_29, bindingAttr:  124);
        if((System.Type.GetType(typeName:  val_28)) == null)
        {
                val_31 = 0;
            System.Type val_13 = System.Type.GetType(typeName:  val_28);
            if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        System.Reflection.PropertyInfo val_14 = val_13.GetProperty(name:  "Instance", bindingAttr:  124);
        val_30 = val_27;
        val_31 = 0;
        if((System.Reflection.MethodInfo.op_Inequality(left:  val_30, right:  val_31)) != false)
        {
                if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_27.IsStatic != false)
        {
                object val_17 = val_27.Invoke(obj:  0, parameters:  val_32);
            return;
        }
        
        }
        
        val_30 = val_14;
        val_31 = 0;
        if((System.Reflection.PropertyInfo.op_Inequality(left:  val_30, right:  val_31)) != false)
        {
                if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            val_30 = val_14;
            val_31 = val_30;
            if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
            object val_19 = val_27.Invoke(obj:  val_31, parameters:  val_32);
            return;
        }
        
        System.Type val_20 = System.Type.GetType(typeName:  val_28);
        val_33 = val_20;
        if(val_20 == null)
        {
                val_33 = System.Type.GetType(typeName:  val_28);
        }
        
        val_31 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_33 & 1) == 0)
        {
                return;
        }
        
        System.Type val_23 = System.Type.GetType(typeName:  val_28);
        val_34 = val_23;
        if(val_23 == null)
        {
                val_34 = System.Type.GetType(typeName:  val_28);
        }
        
        val_31 = 0;
        UnityEngine.Object val_25 = UnityEngine.Object.FindObjectOfType(type:  val_34);
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        val_31 = null;
        val_25.SendMessage(methodName:  val_29);
    }
    private System.Collections.Generic.List<Award> ParseCurrent()
    {
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_26;
        var val_27;
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        var val_32;
        var val_33;
        var val_34;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        var val_39;
        var val_40;
        var val_41;
        var val_42;
        var val_43;
        var val_44;
        var val_45;
        System.Collections.Generic.List<Award> val_1 = new System.Collections.Generic.List<Award>();
        val_20 = 0;
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "awards_available", defaultValue:  "[]"));
        if(X0 == false)
        {
                throw new NullReferenceException();
        }
        
        val_21 = null;
        val_22 = null;
        var val_24 = X0;
        if((X0 + 294) == 0)
        {
            goto label_2;
        }
        
        var val_22 = X0 + 176;
        var val_23 = 0;
        val_22 = val_22 + 8;
        label_4:
        if(((X0 + 176 + 8) + -8) == val_22)
        {
            goto label_3;
        }
        
        val_23 = val_23 + 1;
        val_22 = val_22 + 16;
        if(val_23 < (X0 + 294))
        {
            goto label_4;
        }
        
        label_2:
        val_21 = val_22;
        val_20 = 0;
        goto label_5;
        label_3:
        val_24 = val_24 + (((X0 + 176 + 8)) << 4);
        val_23 = val_24 + 304;
        label_5:
        System.Collections.IEnumerator val_4 = X0.GetEnumerator();
        label_74:
        var val_25 = 0;
        val_25 = val_25 + 1;
        val_20 = 0;
        if(val_4.MoveNext() == false)
        {
            goto label_11;
        }
        
        var val_26 = 0;
        val_26 = val_26 + 1;
        val_20 = 1;
        if(val_4.Current == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = X0;
        if(X0 == false)
        {
                throw new NullReferenceException();
        }
        
        var val_29 = val_22;
        if((X0 + 294) == 0)
        {
            goto label_18;
        }
        
        var val_27 = X0 + 176;
        var val_28 = 0;
        val_27 = val_27 + 8;
        label_20:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_19;
        }
        
        val_28 = val_28 + 1;
        val_27 = val_27 + 16;
        if(val_28 < (X0 + 294))
        {
            goto label_20;
        }
        
        label_18:
        val_20 = 0;
        goto label_21;
        label_19:
        val_29 = val_29 + (((X0 + 176 + 8)) << 4);
        val_26 = val_29 + 304;
        label_21:
        object val_9 = val_22.Item["kind"];
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_27 = 0;
        if((val_9.Contains(value:  "chances")) == false)
        {
            goto label_31;
        }
        
        var val_32 = val_22;
        if((X0 + 294) == 0)
        {
            goto label_25;
        }
        
        var val_30 = X0 + 176;
        var val_31 = 0;
        val_30 = val_30 + 8;
        label_27:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_26;
        }
        
        val_31 = val_31 + 1;
        val_30 = val_30 + 16;
        if(val_31 < (X0 + 294))
        {
            goto label_27;
        }
        
        label_25:
        val_28 = 0;
        goto label_28;
        label_26:
        val_32 = val_32 + (((X0 + 176 + 8)) << 4);
        val_29 = val_32 + 304;
        label_28:
        object val_11 = val_22.Item["kind"];
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_30 = 0;
        if((val_11.Contains(value:  "name_change")) == false)
        {
            goto label_31;
        }
        
        var val_44 = val_22;
        if((X0 + 294) == 0)
        {
            goto label_32;
        }
        
        var val_33 = X0 + 176;
        var val_34 = 0;
        val_33 = val_33 + 8;
        label_34:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_33;
        }
        
        val_34 = val_34 + 1;
        val_33 = val_33 + 16;
        if(val_34 < (X0 + 294))
        {
            goto label_34;
        }
        
        label_32:
        val_31 = 0;
        goto label_35;
        label_31:
        var val_37 = val_22;
        if((X0 + 294) == 0)
        {
            goto label_36;
        }
        
        var val_35 = X0 + 176;
        var val_36 = 0;
        val_35 = val_35 + 8;
        label_38:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_37;
        }
        
        val_36 = val_36 + 1;
        val_35 = val_35 + 16;
        if(val_36 < (X0 + 294))
        {
            goto label_38;
        }
        
        label_36:
        val_33 = 0;
        goto label_39;
        label_37:
        val_37 = val_37 + (((X0 + 176 + 8)) << 4);
        val_34 = val_37 + 304;
        label_39:
        val_35 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_13 = val_22.Item["kind"];
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_40 = val_22;
        if((X0 + 294) == 0)
        {
            goto label_41;
        }
        
        var val_38 = X0 + 176;
        var val_39 = 0;
        val_38 = val_38 + 8;
        label_43:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_42;
        }
        
        val_39 = val_39 + 1;
        val_38 = val_38 + 16;
        if(val_39 < (X0 + 294))
        {
            goto label_43;
        }
        
        label_41:
        val_35 = 0;
        goto label_44;
        label_42:
        val_40 = val_40 + (((X0 + 176 + 8)) << 4);
        val_36 = val_40 + 304;
        label_44:
        val_37 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_14 = val_22.Item["amount"];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        decimal val_15 = System.Decimal.Parse(s:  val_14);
        var val_43 = val_22;
        if((X0 + 294) == 0)
        {
            goto label_48;
        }
        
        var val_41 = X0 + 176;
        var val_42 = 0;
        val_41 = val_41 + 8;
        label_50:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_49;
        }
        
        val_42 = val_42 + 1;
        val_41 = val_41 + 16;
        if(val_42 < (X0 + 294))
        {
            goto label_50;
        }
        
        label_48:
        val_37 = 0;
        goto label_51;
        label_49:
        val_43 = val_43 + (((X0 + 176 + 8)) << 4);
        val_38 = val_43 + 304;
        label_51:
        object val_16 = val_22.Item["id"];
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  new Award() {id = val_16, kind = val_13, amount = new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid}});
        goto label_74;
        label_33:
        val_44 = val_44 + (((X0 + 176 + 8)) << 4);
        val_32 = val_44 + 304;
        label_35:
        object val_17 = val_22.Item["kind"];
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        val_39 = 0;
        if((val_17.Contains(value:  "name_change")) == false)
        {
            goto label_74;
        }
        
        var val_47 = val_22;
        if((X0 + 294) == 0)
        {
            goto label_58;
        }
        
        var val_45 = X0 + 176;
        var val_46 = 0;
        val_45 = val_45 + 8;
        label_60:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_59;
        }
        
        val_46 = val_46 + 1;
        val_45 = val_45 + 16;
        if(val_46 < (X0 + 294))
        {
            goto label_60;
        }
        
        label_58:
        val_39 = 0;
        goto label_61;
        label_59:
        val_47 = val_47 + (((X0 + 176 + 8)) << 4);
        val_40 = val_47 + 304;
        label_61:
        val_41 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_19 = val_22.Item["kind"];
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_50 = val_22;
        if((X0 + 294) == 0)
        {
            goto label_63;
        }
        
        var val_48 = X0 + 176;
        var val_49 = 0;
        val_48 = val_48 + 8;
        label_65:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_64;
        }
        
        val_49 = val_49 + 1;
        val_48 = val_48 + 16;
        if(val_49 < (X0 + 294))
        {
            goto label_65;
        }
        
        label_63:
        val_41 = 0;
        goto label_66;
        label_64:
        val_50 = val_50 + (((X0 + 176 + 8)) << 4);
        val_42 = val_50 + 304;
        label_66:
        val_43 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_20 = val_22.Item["amount"];
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_53 = val_22;
        if((X0 + 294) == 0)
        {
            goto label_68;
        }
        
        var val_51 = X0 + 176;
        var val_52 = 0;
        val_51 = val_51 + 8;
        label_70:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_69;
        }
        
        val_52 = val_52 + 1;
        val_51 = val_51 + 16;
        if(val_52 < (X0 + 294))
        {
            goto label_70;
        }
        
        label_68:
        val_43 = 0;
        goto label_71;
        label_69:
        val_53 = val_53 + (((X0 + 176 + 8)) << 4);
        val_44 = val_53 + 304;
        label_71:
        object val_21 = val_22.Item["id"];
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  new Award() {id = val_21, kind = val_19, amount = new System.Decimal(), text = val_20});
        goto label_74;
        label_11:
        val_22 = 0;
        if(X0 == false)
        {
            goto label_75;
        }
        
        var val_56 = X0;
        if((X0 + 294) == 0)
        {
            goto label_79;
        }
        
        var val_54 = X0 + 176;
        var val_55 = 0;
        val_54 = val_54 + 8;
        label_78:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_77;
        }
        
        val_55 = val_55 + 1;
        val_54 = val_54 + 16;
        if(val_55 < (X0 + 294))
        {
            goto label_78;
        }
        
        goto label_79;
        label_77:
        val_56 = val_56 + (((X0 + 176 + 8)) << 4);
        val_45 = val_56 + 304;
        label_79:
        X0.Dispose();
        label_75:
        if(val_22 != 0)
        {
                throw val_22;
        }
        
        return val_1;
    }
    private void SaveCurrent()
    {
        var val_3;
        object val_4;
        var val_6;
        var val_13;
        string val_14;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        List.Enumerator<T> val_2 = this.currentAwards.GetEnumerator();
        label_5:
        if(val_6.MoveNext() == false)
        {
            goto label_2;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8 = null;
        val_14 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::.ctor();
        val_8 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.Add(key:  "id", value:  val_4);
        val_8.Add(key:  "amount", value:  val_3.ToString());
        val_14 = "kind";
        val_13 = val_8;
        val_8.Add(key:  val_14, value:  val_4);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_8);
        goto label_5;
        label_2:
        val_6.Dispose();
        UnityEngine.PlayerPrefs.SetString(key:  "awards_available", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_11 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public void importProgress(string supportId, string linkCode)
    {
        var val_6;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "link_code", value:  linkCode);
        val_1.Add(key:  "support_id", value:  supportId);
        Player val_2 = this.Player;
        val_1.Add(key:  "user_id", value:  val_2.id);
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_1.Add(key:  "force_valid", value:  "12g");
        }
        
        val_6 = null;
        val_6 = null;
        App.networkManager.DoPost(path:  "/api/imports", postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void ServerHandler::OnImportProgressResponse(string method, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private void OnImportProgressResponse(string method, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_6;
        if(response != null)
        {
                val_6 = "success";
            if((response.ContainsKey(key:  "success")) != false)
        {
                object val_2 = response.Item["success"];
            if(null != null)
        {
                this.UpdatedFromServer(serverResponse:  response, forceUpdate:  true);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnServerImportResponded", aData:  new System.Collections.Hashtable());
            return;
        }
        
        }
        
        }
        
        UnityEngine.Debug.Log(message:  "OnImportProgressResponse ONSERVERIMPORTFAILED");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnServerImportFailed");
    }
    protected override void AwakeLogic()
    {
        this.AwakeLogic();
        this.Initialize();
    }
    private void Initialize()
    {
        null = null;
        if(ServerHandler.initialized == true)
        {
                return;
        }
        
        this.RefreshAwards();
        this._ParsedMessages = ServerHandler.ExtractMissedMessagesFromPlayerPrefs();
        ServerHandler.initialized = true;
    }
    public void PopFirstMessage()
    {
        if(true < 1)
        {
                return;
        }
        
        this._ParsedMessages.RemoveAt(index:  0);
        ServerHandler.SaveQueuedToPlayerPrefs(queuedMessages:  this._ParsedMessages);
    }
    public static void SaveQueuedToPlayerPrefs(System.Collections.Generic.List<MessageParams> queuedMessages)
    {
        var val_3;
        object val_4;
        var val_11;
        string val_12;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        List.Enumerator<T> val_2 = queuedMessages.GetEnumerator();
        label_7:
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = null;
        val_12 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::.ctor();
        val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_6.Add(key:  "msg", value:  val_3 + 16);
        val_12 = val_3 + 24;
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = val_12;
        val_6.Add(key:  "ack", value:  val_12.ToString());
        val_4 = val_3 + 28;
        val_12 = "loc";
        val_11 = val_6;
        val_6.Add(key:  val_12, value:  val_4);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_6);
        goto label_7;
        label_2:
        val_4.Dispose();
        UnityEngine.PlayerPrefs.SetString(key:  "missed_messages", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_10 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static System.Collections.Generic.List<MessageParams> ExtractMissedMessagesFromPlayerPrefs()
    {
        var val_15;
        var val_16;
        var val_17;
        MessageParams val_20;
        object val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        System.Collections.Generic.List<MessageParams> val_1 = new System.Collections.Generic.List<MessageParams>();
        val_15 = 0;
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "missed_messages", defaultValue:  "[]"));
        if(X0 == false)
        {
                throw new NullReferenceException();
        }
        
        val_16 = null;
        var val_19 = X0;
        if((X0 + 294) == 0)
        {
            goto label_2;
        }
        
        var val_17 = X0 + 176;
        var val_18 = 0;
        val_17 = val_17 + 8;
        label_4:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_3;
        }
        
        val_18 = val_18 + 1;
        val_17 = val_17 + 16;
        if(val_18 < (X0 + 294))
        {
            goto label_4;
        }
        
        label_2:
        val_16 = null;
        val_15 = 0;
        goto label_5;
        label_3:
        val_19 = val_19 + (((X0 + 176 + 8)) << 4);
        val_17 = val_19 + 304;
        label_5:
        System.Collections.IEnumerator val_4 = X0.GetEnumerator();
        label_45:
        var val_20 = 0;
        val_20 = val_20 + 1;
        val_15 = 0;
        if(val_4.MoveNext() == false)
        {
            goto label_11;
        }
        
        var val_21 = 0;
        val_21 = val_21 + 1;
        val_15 = 1;
        object val_8 = val_4.Current;
        val_20 = val_8;
        if(val_8 == null)
        {
            goto label_16;
        }
        
        val_21 = null;
        val_22 = X0;
        if(X0 == true)
        {
            goto label_17;
        }
        
        throw new NullReferenceException();
        label_16:
        val_22 = 0;
        label_17:
        MessageParams val_9 = null;
        val_20 = val_9;
        val_9 = new MessageParams();
        if(val_22 == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_24 = 1179403647;
        val_21 = "msg";
        if(mem[282584257676965] == 0)
        {
            goto label_20;
        }
        
        var val_22 = mem[282584257676847];
        var val_23 = 0;
        val_22 = val_22 + 8;
        label_22:
        if(((mem[282584257676847] + 8) + -8) == null)
        {
            goto label_21;
        }
        
        val_23 = val_23 + 1;
        val_22 = val_22 + 16;
        if(val_23 < mem[282584257676965])
        {
            goto label_22;
        }
        
        label_20:
        val_15 = 0;
        goto label_23;
        label_21:
        val_24 = val_24 + (((mem[282584257676847] + 8)) << 4);
        val_23 = val_24 + 304;
        label_23:
        val_24 = public System.Object System.Collections.IDictionary::get_Item(object key);
        object val_10 = val_22.Item[val_21];
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        .Message = val_10;
        var val_27 = 1179403647;
        val_21 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if(mem[282584257676965] == 0)
        {
            goto label_28;
        }
        
        var val_25 = mem[282584257676847];
        var val_26 = 0;
        val_25 = val_25 + 8;
        label_30:
        if(((mem[282584257676847] + 8) + -8) == null)
        {
            goto label_29;
        }
        
        val_26 = val_26 + 1;
        val_25 = val_25 + 16;
        if(val_26 < mem[282584257676965])
        {
            goto label_30;
        }
        
        label_28:
        val_24 = 0;
        goto label_31;
        label_29:
        val_27 = val_27 + (((mem[282584257676847] + 8)) << 4);
        val_25 = val_27 + 304;
        label_31:
        object val_12 = val_22.Item["ack"];
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26 = 0;
        if((System.Enum.Parse(enumType:  val_21, value:  val_12)) == null)
        {
                throw new NullReferenceException();
        }
        
        .Prompt = null;
        var val_30 = 1179403647;
        val_21 = "loc";
        if(mem[282584257676965] == 0)
        {
            goto label_37;
        }
        
        var val_28 = mem[282584257676847];
        var val_29 = 0;
        val_28 = val_28 + 8;
        label_39:
        if(((mem[282584257676847] + 8) + -8) == null)
        {
            goto label_38;
        }
        
        val_29 = val_29 + 1;
        val_28 = val_28 + 16;
        if(val_29 < mem[282584257676965])
        {
            goto label_39;
        }
        
        label_37:
        val_26 = 0;
        goto label_40;
        label_38:
        val_30 = val_30 + (((mem[282584257676847] + 8)) << 4);
        val_27 = val_30 + 304;
        label_40:
        object val_14 = val_22.Item[val_21];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        .Localize = System.Boolean.Parse(value:  val_14);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_9);
        goto label_45;
        label_11:
        val_20 = 0;
        if(X0 == false)
        {
            goto label_46;
        }
        
        var val_33 = X0;
        if((X0 + 294) == 0)
        {
            goto label_50;
        }
        
        var val_31 = X0 + 176;
        var val_32 = 0;
        val_31 = val_31 + 8;
        label_49:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_48;
        }
        
        val_32 = val_32 + 1;
        val_31 = val_31 + 16;
        if(val_32 < (X0 + 294))
        {
            goto label_49;
        }
        
        goto label_50;
        label_48:
        val_33 = val_33 + (((X0 + 176 + 8)) << 4);
        val_28 = val_33 + 304;
        label_50:
        X0.Dispose();
        label_46:
        if(val_20 != 0)
        {
                throw val_20;
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "missed_messages", value:  "[]");
        return val_1;
    }
    public ServerHandler()
    {
        this._allowServerConnect = true;
        System.DateTime val_1 = System.DateTime.UtcNow;
        this._serverTime = val_1;
        this.currentAwards = new System.Collections.Generic.List<Award>();
        this._ParsedMessages = new System.Collections.Generic.List<MessageParams>();
    }
    private static ServerHandler()
    {
        System.DateTime val_1 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0, kind:  1);
        ServerHandler.missed_msgs_key = val_1.dateData;
        ServerHandler.initialized = false;
    }

}
