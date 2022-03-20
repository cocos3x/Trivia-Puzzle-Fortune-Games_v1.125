using UnityEngine;
public class VIPPartyEventHandler : WGEventHandler
{
    // Fields
    public const string VIP_PARTY_EVENT_ID = "VipParty";
    private static VIPPartyEventHandler instance;
    private VIPPartyEventInfo eventInfo;
    
    // Properties
    public static VIPPartyEventHandler Instance { get; }
    
    // Methods
    public static VIPPartyEventHandler get_Instance()
    {
        return (VIPPartyEventHandler)VIPPartyEventHandler.instance;
    }
    public override void Init(GameEventV2 eventV2)
    {
        VIPPartyEventHandler.instance = this;
        mem[1152921516763375952] = eventV2;
        this.eventInfo.timestamp = eventV2.serverTimestamp;
        this.ParseEventData(eventData:  eventV2.eventData);
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        Player val_3 = App.Player;
        UnityEngine.Debug.LogWarning(message:  "Player ID: "("Player ID: ") + val_3.id);
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if(true == 0)
        {
                return;
        }
        
        if((System.String.op_Inequality(a:  0, b:  "VipParty")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + eventV2.ToString());
            return;
        }
        
        this.eventInfo.timestamp = eventV2.serverTimestamp;
        this.ParseEventData(eventData:  eventV2.eventData);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        this.UpdateProgressionToServer();
    }
    public override void OnEventEnded()
    {
        VIPPartyEventHandler.instance = 0;
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "vip_party_upper", defaultValue:  "VIP PARTY", useSingularKey:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentVipParty>(allowMultiple:  false).SetupVipStatus(isVIP:  this.eventInfo.isVIP);
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "vip_party_upper", defaultValue:  "VIP PARTY", useSingularKey:  false);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        this.ShowVipPartyEventInfoPopup();
        this.TrackPurchase(point:  54);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        this.ShowVipPartyEventInfoPopup();
        this.TrackPurchase(point:  55);
    }
    public override void OnPurchaseCompleted(PurchaseModel obj)
    {
        Player val_1 = App.Player;
        int val_3 = val_1.properties.LifetimeVipPartyPurchases;
        val_3 = val_3 + 1;
        val_1.properties.LifetimeVipPartyPurchases = val_3;
        this.eventInfo.isVIP = true;
        this.UpdateProgressionToServer();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnChapterCompletePurchase");
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        string val_21;
        var val_33;
        string val_34;
        string val_35;
        string val_36;
        var val_37;
        val_34 = this;
        if(eventData == null)
        {
                return;
        }
        
        val_33 = "economy";
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        val_35 = "economy";
        object val_2 = eventData.Item[val_35];
        if(val_2 == null)
        {
                return;
        }
        
        var val_3 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_2) : 0;
        if((val_3.ContainsKey(key:  "reward")) == false)
        {
                return;
        }
        
        val_35 = "reward";
        object val_5 = val_3.Item[val_35];
        if(val_5 == null)
        {
                return;
        }
        
        val_3 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_5) : 0;
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_6.playerBucket;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = 0;
        string val_7 = val_36.ToUpper();
        val_35 = "android";
        object val_8 = val_3.Item[val_35];
        val_37 = val_8;
        if(val_8 == null)
        {
            goto label_67;
        }
        
        val_36 = val_37;
        val_35 = val_7;
        if((val_36.ContainsKey(key:  val_35)) == false)
        {
            goto label_19;
        }
        
        val_35 = val_7;
        if(val_37.Item[val_35] == null)
        {
                throw new NullReferenceException();
        }
        
        goto label_24;
        label_19:
        val_37 = 0;
        label_67:
        label_55:
        if(this.eventInfo == null)
        {
                throw new NullReferenceException();
        }
        
        if(0 != 0)
        {
                this.eventInfo.rewardType = 0;
            val_36 = val_37;
            val_35 = 0;
            decimal val_11 = System.Decimal.op_Implicit(value:  0);
            if(this.eventInfo == null)
        {
                throw new NullReferenceException();
        }
        
            this.eventInfo.reward = val_11;
            mem2[0] = val_11.lo;
            mem[4] = val_11.mid;
        }
        else
        {
                this.eventInfo.rewardType = 1;
            val_36;
            val_35 = 25;
            val_36 = new System.Decimal(value:  25);
            if(this.eventInfo == null)
        {
                throw new NullReferenceException();
        }
        
            this.eventInfo.reward = val_36.flags;
        }
        
        val_33 = "status";
        if((eventData.ContainsKey(key:  "status")) == false)
        {
                return;
        }
        
        val_35 = "status";
        object val_13 = eventData.Item[val_35];
        if(val_13 != null)
        {
                val_33 = "isVIP";
            val_36 = val_13;
            val_35 = "isVIP";
            if((val_36.ContainsKey(key:  val_35)) != false)
        {
                val_35 = "isVIP";
            object val_15 = val_13.Item[val_35];
            if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.eventInfo == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = val_15;
            bool val_17 = System.Boolean.TryParse(value:  val_34, result: out  this.eventInfo.isVIP);
            return;
        }
        
        }
        
        if(this.eventInfo == null)
        {
                throw new NullReferenceException();
        }
        
        this.eventInfo.isVIP = false;
        return;
        label_24:
        Dictionary.Enumerator<TKey, TValue> val_19 = GetEnumerator();
        do
        {
            label_51:
            val_35 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
            if(val_36.flags.MoveNext() == false)
        {
            goto label_53;
        }
        
            val_36 = val_21;
            int val_23 = 0;
            if(val_36 == 0)
        {
                throw new NullReferenceException();
        }
        
        }
        while(val_23 < 1);
        
        if(((System.Int32.TryParse(s:  val_36, result: out  val_23)) ^ 1) == true)
        {
            goto label_51;
        }
        
        if(val_21 == 0)
        {
                throw new NullReferenceException();
        }
        
        string val_27 = val_21.Trim().ToLower();
        if((System.String.Compare(strA:  val_27, strB:  "coins")) == 0)
        {
            goto label_54;
        }
        
        if((System.String.Compare(strA:  val_27, strB:  "bonus_wheel")) == 0)
        {
            goto label_50;
        }
        
        if((System.String.Compare(strA:  val_27, strB:  "bonus_spin")) != 0)
        {
            goto label_51;
        }
        
        goto label_54;
        label_50:
        label_54:
        label_53:
        val_36.flags.Dispose();
        goto label_55;
    }
    private void UpdateProgressionToServer()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "timestamp", value:  this.eventInfo.timestamp);
        val_1.Add(key:  "isVIP", value:  this.eventInfo.isVIP);
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_1);
    }
    private bool IsEventEnded()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public VIPPartyEventInfo GetEventInfo()
    {
        return (VIPPartyEventInfo)this.eventInfo;
    }
    public bool IsEventExpired()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public string GetEventRemainingTime()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = val_1.dateData});
        object[] val_3 = new object[4];
        val_3[0] = UnityEngine.Mathf.Max(a:  val_2._ticks.Days, b:  0);
        val_3[1] = UnityEngine.Mathf.Max(a:  val_2._ticks.Hours, b:  0);
        val_3[2] = UnityEngine.Mathf.Max(a:  val_2._ticks.Minutes, b:  0);
        val_3[3] = UnityEngine.Mathf.Max(a:  val_2._ticks.Seconds, b:  0);
        return (string)System.String.Format(format:  "{0:0}:{1:00}:{2:00}:{3:00}", args:  val_3);
    }
    public void ShowVipPartyEventInfoPopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGVipPartyEventInfoPopup>(showNext:  false);
    }
    public void ShowChapterClearPopup()
    {
    
    }
    public void OnAnimFinished_StorePurchaseOnChapterComplete()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "VIP Party Bonus", value:  VIPPartyEventInfo.__il2cppRuntimeField_namespaze);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = this.eventInfo.reward, hi = this.eventInfo.reward, lo = -725904496, mid = 268435458}, source:  "Chapter Complete", subSource:  0, externalParams:  val_1, doTrack:  true);
    }
    public void TrackPurchase(TrackerPurchasePoints point)
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = point;
    }
    public VIPPartyEventHandler()
    {
        this.eventInfo = new VIPPartyEventInfo();
    }

}
