using UnityEngine;
public class TrackingHandler : DefaultHandler<TrackingHandler>
{
    // Fields
    private const int RETRY_VALIDATION_SECS = 5;
    private PurchaseModel currentPurchase;
    private NativePurchase currentNativePurchase;
    private bool serverValidCurrentPurchase;
    
    // Methods
    public void ProcessPurchase(PurchaseModel currentPurchase, NativePurchase purchaseInfo)
    {
        var val_1;
        this.serverValidCurrentPurchase = false;
        if(purchaseInfo.isPending != false)
        {
                return;
        }
        
        this.ServerValidatePurchase(currentPurchase:  currentPurchase, currentNativePurchase:  purchaseInfo);
        val_1 = null;
        val_1 = null;
        App.inAppPurchasesManager.AddTracked(token:  purchaseInfo.token);
    }
    private void ServerValidatePurchase(PurchaseModel currentPurchase, NativePurchase currentNativePurchase)
    {
        PurchaseModel val_17;
        TrackingHandler val_18;
        var val_20;
        var val_21;
        val_17 = currentPurchase;
        val_18 = this;
        .<>4__this = val_18;
        SLCDebug.Log(logMessage:  "TrackingHandler.ServerValidatePurchase :: "("TrackingHandler.ServerValidatePurchase :: ") + val_17.ToShortString() + "\n" + Newtonsoft.Json.JsonConvert.SerializeObject(value:  currentNativePurchase, formatting:  1)(Newtonsoft.Json.JsonConvert.SerializeObject(value:  currentNativePurchase, formatting:  1)), colorHash:  "#83E8F7", isError:  false);
        this.currentPurchase = val_17;
        this.currentNativePurchase = currentNativePurchase;
        val_20 = null;
        val_20 = null;
        if(App.networkManager.Reachable() == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        .eventData = val_6;
        decimal val_7 = this.ChooseQuantity();
        Player val_8 = App.Player;
        val_6.Add(key:  "balance", value:  val_8._credits);
        GameBehavior val_9 = App.getBehavior;
        val_6.Add(key:  "level", value:  val_9.<metaGameBehavior>k__BackingField);
        val_6.Add(key:  "package", value:  currentPurchase.<Sku>k__BackingField);
        Player val_10 = App.Player;
        val_6.Add(key:  "plays", value:  val_10.lifetimePlays);
        float val_17 = currentPurchase.sale_price;
        val_17 = val_17 * 100f;
        val_6.Add(key:  "price", value:  (int)(val_17 == Infinityf) ? (-(double)val_17) : ((double)val_17));
        val_6.Add(key:  "quantity", value:  val_7);
        Player val_12 = App.Player;
        val_6.Add(key:  "user_public_id", value:  val_12.id);
        val_6.Add(key:  "1st_purchase", value:  (currentPurchase.PrePurchaseUserInfo.total_purchase == 0f) ? 1 : 0);
        bool val_15 = CompanyDevices.Instance.CompanyDevice();
        if(val_15 == true)
        {
                return;
        }
        
        val_15.InjectAdditionalTrackingParams(postParams: ref  .eventData, purchase:  val_17);
        if(currentNativePurchase != null)
        {
                currentNativePurchase.AddStoreSpecificDataForValidation(postParams: ref  .eventData);
        }
        
        val_21 = null;
        val_21 = null;
        val_17 = App.networkManager;
        val_17.DoPost(path:  "/api/purchases", postBody:  (TrackingHandler.<>c__DisplayClass5_0)[1152921515739388192].eventData, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new TrackingHandler.<>c__DisplayClass5_0(), method:  System.Void TrackingHandler.<>c__DisplayClass5_0::<ServerValidatePurchase>b__0(string apicall, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private System.Collections.IEnumerator RetryValidation(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .eventData = eventData;
        return (System.Collections.IEnumerator)new TrackingHandler.<RetryValidation>d__6();
    }
    private void InjectAdditionalTrackingParams(ref System.Collections.Generic.Dictionary<string, object> postParams, PurchaseModel purchase)
    {
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        val_16 = purchase;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        decimal val_2 = val_16.Credits;
        val_17 = null;
        val_17 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_4 = val_16.Credits;
            val_18 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_1.Add(key:  "coins", value:  val_4.flags.ToString(format:  "##,##0"));
        }
        
        if((System.String.IsNullOrEmpty(value:  purchase.ltoModifier)) != true)
        {
                val_18 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_1.Add(key:  "lto", value:  purchase.ltoModifier);
        }
        
        if(purchase.vipApplied == false)
        {
            goto label_24;
        }
        
        val_19 = null;
        val_19 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = purchase.vipAddedCredits, hi = purchase.vipAddedCredits, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_1.Add(key:  "Coin Amount from Bonus Level", value:  purchase.vipAddedCredits.ToString(format:  "##,##0"));
            val_20 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_1.Add(key:  "Bonus Level", value:  purchase.vipLevel);
        }
        
        if(purchase.vipApplied == false)
        {
            goto label_24;
        }
        
        val_21 = null;
        val_21 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = purchase.vipAddedGems, hi = purchase.vipAddedGems, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_1.Add(key:  "Gem Amount from Bonus Level", value:  purchase.vipAddedGems.ToString(format:  "##,##0"));
            val_22 = public static System.Void EnumerableExtentions::SetOrAdd<System.String, System.Object>(System.Collections.Generic.Dictionary<T, U> dic, System.String key, System.Object newValue);
            EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  val_1, key:  "Bonus Level", newValue:  purchase.vipLevel);
        }
        
        if(purchase.vipApplied == false)
        {
            goto label_24;
        }
        
        val_23 = null;
        val_23 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = purchase.vipAddedGoldenCurrency, hi = purchase.vipAddedGoldenCurrency, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_1.Add(key:  "vip contrib golden currency", value:  purchase.vipAddedGoldenCurrency.ToString(format:  "##,##0"));
            EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  val_1, key:  "vip level", newValue:  purchase.vipLevel);
        }
        
        if((purchase.vipApplied == false) || (purchase.vipContribution < 1))
        {
            goto label_24;
        }
        
        val_1.Add(key:  "Reward Points", value:  purchase.vipContribution);
        goto label_26;
        label_24:
        label_26:
        if((val_1.ContainsKey(key:  "entry point")) != true)
        {
                val_24 = null;
            val_24 = null;
            val_16 = PurchaseProxy.currentPurchasePoint;
            val_1.Add(key:  "entry point", value:  PurchaseProxy.currentPurchasePoint.ToString());
        }
        
        postParams.Add(key:  "mods", value:  MiniJSON.Json.Serialize(obj:  val_1));
    }
    private decimal ChooseQuantity()
    {
        int val_10;
        var val_11;
        PurchaseModel val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        decimal val_1 = this.currentPurchase.Credits;
        val_10 = val_1.lo;
        val_11 = null;
        val_11 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_10, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_12 = this.currentPurchase;
            val_13 = 0;
            decimal val_3 = val_12.Credits;
            return new System.Decimal() {flags = val_12, hi = val_12, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        decimal val_4 = this.currentPurchase.Gems;
        val_14 = null;
        val_10 = val_4.lo;
        val_14 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_10, mid = val_4.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_12 = this.currentPurchase;
            val_13 = 0;
            decimal val_6 = val_12.Gems;
            return new System.Decimal() {flags = val_12, hi = val_12, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        decimal val_7 = this.currentPurchase.PetsFood;
        val_15 = null;
        val_10 = val_7.lo;
        val_15 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_10, mid = val_7.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_12 = this.currentPurchase;
            val_13 = 0;
            decimal val_9 = val_12.PetsFood;
            return new System.Decimal() {flags = val_12, hi = val_12, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        }
        
        val_16 = null;
        val_16 = null;
        val_12 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_12, hi = val_12, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
    }
    private void ServerCallback(System.Collections.Generic.Dictionary<string, object> eventData, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_10;
        var val_11;
        var val_12;
        SLCDebug.Log(logMessage:  "TrackingHandler.ServerCallback ::\n"("TrackingHandler.ServerCallback ::\n") + Newtonsoft.Json.JsonConvert.SerializeObject(value:  response, formatting:  1)(Newtonsoft.Json.JsonConvert.SerializeObject(value:  response, formatting:  1)), colorHash:  "#136EEA", isError:  false);
        if((response == null) || ((response.ContainsKey(key:  "validated")) == false))
        {
            goto label_6;
        }
        
        if((new twelvegigs.storage.JsonDictionary(parsedDictionary:  response).getBool(key:  "validated")) == false)
        {
            goto label_8;
        }
        
        this.CheckPurchaseForAnomalies();
        this.serverValidCurrentPurchase = true;
        val_10 = null;
        val_10 = null;
        PluginObserverManager.isPurchaseValidationWorking = true;
        this.DoTrackPurchase();
        return;
        label_6:
        UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.RetryValidation(eventData:  eventData));
        return;
        label_8:
        val_11 = null;
        val_11 = null;
        GooglePurchasesBridge.trustUser = false;
        UnityEngine.Debug.LogError(message:  "Hack intent! Purchase validation failed.");
        val_12 = null;
        val_12 = null;
        PluginObserverManager.isPurchaseValidationWorking = false;
        Player val_8 = App.Player;
        val_8.properties.<PurchaseHackUser>k__BackingField = true;
        App.Player.SaveState();
    }
    private void CheckPurchaseForAnomalies()
    {
        var val_12;
        int val_13;
        var val_14;
        PurchaseUserInfo val_15;
        var val_16;
        val_12 = this;
        if(this.currentPurchase == null)
        {
                return;
        }
        
        decimal val_1 = this.currentPurchase.Credits;
        val_13 = val_1.lo;
        val_14 = null;
        val_14 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_13, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == true)
        {
                return;
        }
        
        Player val_3 = App.Player;
        val_15 = this.currentPurchase.PrePurchaseUserInfo;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = this.currentPurchase.PrePurchaseUserInfo.total_credits, hi = this.currentPurchase.PrePurchaseUserInfo.total_credits, lo = val_13, mid = val_1.mid})) == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_6 = App.Player;
        val_5.Add(key:  "Current Credits", value:  val_6._credits);
        val_5.Add(key:  "Credits Before Purchase", value:  this.currentPurchase.PrePurchaseUserInfo.total_credits);
        decimal val_7 = this.currentPurchase.Credits;
        val_5.Add(key:  "Current Purchase Total", value:  val_7);
        val_16 = null;
        val_16 = null;
        App.Player.SetCredits(amount:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        val_13 = this.currentPurchase.PrePurchaseUserInfo.total_credits;
        val_12 = App.Player;
        decimal val_10 = this.currentPurchase.Credits;
        decimal val_11 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_13, hi = val_13, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid});
        val_12.AddCredits(amount:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, source:  "Purchase Anomaly Correction", subSource:  "", externalParams:  val_5, doTrack:  true);
    }
    public void TrackSubscriptionPurchase(PurchaseModel model, NativePurchase native)
    {
        this.currentPurchase = model;
        this.currentNativePurchase = native;
        this.DoTrackPurchase();
    }
    public void TrackPurchaseFailed(PurchaseModel model, string errorCode, string errorRaw, string errorString)
    {
        object val_4;
        object val_5;
        var val_6;
        var val_7;
        var val_8;
        val_4 = errorString;
        val_5 = errorRaw;
        val_6 = model;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_7 = null;
            val_7 = null;
            if(CompanyDevices.TrackingAllowed == false)
        {
                return;
        }
        
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(val_6 != null)
        {
                val_3.Add(key:  "Package", value:  model.<Sku>k__BackingField);
            val_3.Add(key:  "Price", value:  model.sale_price);
        }
        
        val_6 = 1152921515419383392;
        val_3.Add(key:  "Error Code", value:  errorCode);
        val_3.Add(key:  "Error String", value:  val_4);
        val_3.Add(key:  "Error", value:  val_5);
        val_8 = null;
        val_8 = null;
        val_4 = 1152921504883736576;
        val_5 = App.trackerManager;
        val_5.track(eventName:  Events.TRANSACTION_FAILED, data:  val_3);
    }
    private void DoTrackPurchase()
    {
        string val_50;
        var val_72;
        var val_73;
        var val_74;
        var val_75;
        var val_76;
        var val_77;
        var val_78;
        int val_79;
        var val_80;
        var val_81;
        var val_82;
        var val_83;
        string val_84;
        System.Collections.Generic.Dictionary<TKey, TValue> val_85;
        var val_87;
        int val_88;
        var val_89;
        val_72 = 1152921504884535296;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_73 = null;
            val_73 = null;
            if(CompanyDevices.TrackingAllowed == false)
        {
                return;
        }
        
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "Item Purchased", value:  this.currentPurchase.<Sku>k__BackingField);
        val_3.Add(key:  "Dollars Spent", value:  this.currentPurchase.sale_price);
        decimal val_4 = this.currentPurchase.Credits;
        val_72 = 1152921504617017344;
        val_3.Add(key:  "Quantity", value:  val_4);
        val_74 = null;
        val_74 = null;
        val_75 = null;
        val_75 = null;
        System.DateTime val_5 = System.DateTime.UtcNow;
        App.trackerManager.superProperty(propertyName:  Events.MOST_RECENT_PURCHASE, propertyValue:  val_5.dateData.ToString(format:  "MM/dd/yyyy"));
        val_76 = null;
        val_76 = null;
        App.trackerManager.increment(eventName:  Events.LIFETIME_REVENUE, eventValue:  this.currentPurchase.sale_price.ToString());
        val_77 = null;
        val_77 = null;
        App.trackerManager.peopleIncrement(eventName:  Events.LIFETIME_REVENUE, eventValue:  this.currentPurchase.sale_price.ToString());
        System.Collections.Generic.Dictionary<System.String, System.Object> val_9 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_9.Add(key:  "Item Purchased", value:  this.currentPurchase.<Sku>k__BackingField);
        decimal val_10 = this.currentPurchase.Credits;
        val_9.Add(key:  "Quantity", value:  val_10);
        val_9.Add(key:  "Purchase_Info", value:  mem[1152921515741099200]);
        val_78 = null;
        val_78 = null;
        App.trackerManager.trackCharge(quantity:  this.currentPurchase.sale_price.ToString(), data:  val_9);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_12 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_12.Add(key:  "1st_purchase", value:  (this.currentPurchase.PrePurchaseUserInfo.total_purchase == 0f) ? 1 : 0);
        decimal val_14 = this.currentPurchase.Credits;
        val_12.Add(key:  "Amount", value:  val_14);
        val_12.Add(key:  "Entry Point", value:  this.currentPurchase.trackerPurchasePoint);
        val_12.Add(key:  "Current Lvl", value:  Player.GetLevelForTracking());
        val_12.Add(key:  "Current Lvl Name", value:  Player.GetLevelNameForTracking());
        val_12.Add(key:  "Current Difficulty", value:  Player.GetDifficultyForTracking());
        string val_18 = Player.GetProgressTypeForTracking();
        val_12.Add(key:  val_18, value:  Player.GetProgressForTracking());
        val_12.Add(key:  "Package", value:  this.currentPurchase.<Sku>k__BackingField);
        val_12.Add(key:  "Price", value:  this.currentPurchase.sale_price);
        Player val_20 = App.Player;
        decimal val_21 = this.currentPurchase.Credits;
        decimal val_22 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_20._credits, hi = val_20._credits, lo = val_18, mid = val_18}, d2:  new System.Decimal() {flags = val_21.flags, hi = val_21.hi, lo = val_21.lo, mid = val_21.mid});
        val_12.Add(key:  "Previous Balance", value:  val_22);
        val_12.Add(key:  "Cached Previous Balance", value:  this.currentPurchase.PrePurchaseUserInfo.total_credits);
        Player val_23 = App.Player;
        val_12.Add(key:  "Current Coins", value:  val_23._credits);
        decimal val_24 = this.currentPurchase.GoldenCurrency;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_24.flags, hi = val_24.hi, lo = val_24.lo, mid = val_24.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_26 = this.currentPurchase.GoldenCurrency;
            val_80 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_12.Add(key:  "Golden Currency", value:  val_26);
        }
        
        decimal val_27 = this.currentPurchase.Gems;
        val_81 = null;
        val_81 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_27.flags, hi = val_27.hi, lo = val_27.lo, mid = val_27.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_29 = this.currentPurchase.Gems;
            val_12.Add(key:  "Gem Amount", value:  val_29);
            Player val_30 = App.Player;
            decimal val_31 = System.Decimal.op_Implicit(value:  val_30._gems);
            val_79 = val_31.lo;
            decimal val_32 = this.currentPurchase.Gems;
            decimal val_33 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_31.flags, hi = val_31.hi, lo = val_79, mid = val_31.mid}, d2:  new System.Decimal() {flags = val_32.flags, hi = val_32.hi, lo = val_32.lo, mid = val_32.mid});
            val_82 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_12.Add(key:  "Previous Gems", value:  val_33);
        }
        
        decimal val_34 = this.currentPurchase.Spins;
        val_83 = null;
        val_83 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_34.flags, hi = val_34.hi, lo = val_34.lo, mid = val_34.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_36 = this.currentPurchase.Spins;
            val_12.Add(key:  "Spins Amount", value:  val_36);
        }
        
        GameBehavior val_37 = App.getBehavior;
        if(((val_37.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_12.Add(key:  "Sale Type", value:  this.currentPurchase.ltoModifier);
            int val_71 = this.currentPurchase.trackerPurchasePoint;
            val_71 = val_71 & 4294967294;
            if(val_71 == 4)
        {
                val_12.Add(key:  "Sale Target Price", value:  this.currentPurchase.targetSalePrice);
        }
        
        }
        
        GameBehavior val_38 = App.getBehavior;
        if(((val_38.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                bool val_41 = MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge;
            val_12.Add(key:  "Daily Challenge", value:  val_41);
        }
        
        Player val_42 = App.Player;
        decimal val_43 = this.currentPurchase.Credits;
        decimal val_44 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_43.flags, hi = val_43.hi, lo = val_43.lo, mid = val_43.mid}, d2:  new System.Decimal() {flags = this.currentPurchase.vipAddedCredits, hi = this.currentPurchase.vipAddedCredits, lo = 1152921504622129152});
        decimal val_45 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_42.properties.credits_purchased, hi = val_42.properties.credits_purchased, lo = val_79, mid = val_31.mid}, d2:  new System.Decimal() {flags = val_44.flags, hi = val_44.hi, lo = val_44.lo, mid = val_44.mid});
        val_42.properties.CreditsPurchased = new System.Decimal() {flags = val_45.flags, hi = val_45.hi, lo = val_45.lo, mid = val_45.mid};
        val_12.Add(key:  "Feature Offer", value:  this.currentPurchase.ContainsInstruction(instruction:  1));
        Dictionary.Enumerator<TKey, TValue> val_48 = this.currentPurchase._PurchaseTrackingInfo.GetEnumerator();
        label_126:
        val_84 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(val_41.MoveNext() == false)
        {
            goto label_119;
        }
        
        val_85 = val_12;
        if(val_85 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_84 = val_50;
        if((val_12.ContainsKey(key:  val_84)) == false)
        {
            goto label_121;
        }
        
        UnityEngine.Debug.LogError(message:  "Not adding current purchase tracking info for " + val_50 + " : key already exists in transaction info!"(" : key already exists in transaction info!"));
        goto label_126;
        label_121:
        val_85 = val_12;
        if(val_85 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_12.Add(key:  val_50, value:  val_50);
        goto label_126;
        label_119:
        val_41.Dispose();
        Player val_54 = App.Player;
        val_12.Add(key:  "Current Food", value:  val_54._food);
        decimal val_55 = this.currentPurchase.PetsFood;
        val_87 = null;
        val_88 = val_55.lo;
        val_87 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_55.flags, hi = val_55.hi, lo = val_88, mid = val_55.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                Player val_57 = App.Player;
            decimal val_58 = System.Decimal.op_Implicit(value:  val_57._food);
            val_88 = val_58.flags;
            decimal val_59 = this.currentPurchase.PetsFood;
            decimal val_60 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_88, hi = val_58.hi, lo = val_58.lo, mid = val_58.mid}, d2:  new System.Decimal() {flags = val_59.flags, hi = val_59.hi, lo = val_59.lo, mid = val_59.mid});
            val_12.Add(key:  "Previous Food", value:  val_60);
            decimal val_61 = this.currentPurchase.PetsFood;
            val_12.Add(key:  "Food", value:  val_61);
        }
        
        GameBehavior val_62 = App.getBehavior;
        GameBehavior val_63 = App.getBehavior;
        if(((val_63.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_12.Add(key:  "Current Cards", value:  WADPetsManager.GetCardsBalance());
            decimal val_66 = System.Decimal.op_Implicit(value:  WADPetsManager.GetCardsBalance());
            val_88 = val_66.flags;
            decimal val_67 = this.currentPurchase.PetCards;
            decimal val_68 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_88, hi = val_66.hi, lo = val_66.lo, mid = val_66.mid}, d2:  new System.Decimal() {flags = val_67.flags, hi = val_67.hi, lo = val_67.lo, mid = val_67.mid});
            val_12.Add(key:  "Previous Cards", value:  val_68);
        }
        
        GameBehavior val_69 = App.getBehavior;
        if((((val_69.<metaGameBehavior>k__BackingField) & 1) != 0) && (this.currentPurchase.vipApplied != false))
        {
                val_12.Add(key:  "Bonus Level", value:  this.currentPurchase.vipLevel);
            val_12.Add(key:  "Coin Amount from Bonus Level", value:  this.currentPurchase.vipAddedCredits);
            val_12.Add(key:  "Gem Amount from Bonus Level", value:  this.currentPurchase.vipAddedGems);
            val_12.Add(key:  "Reward Points", value:  this.currentPurchase.vipContribution);
        }
        
        val_89 = null;
        val_89 = null;
        App.trackerManager.track(eventName:  Events.TRANSACTION, data:  val_12);
        this.TrackAdjustPurchaseEvents(currentPurchase:  this.currentPurchase);
    }
    protected virtual void TrackSpecificGameLogic(PurchaseModel currentPurchase)
    {
    
    }
    private void TrackAdjustPurchaseEvents(PurchaseModel currentPurchase)
    {
        var val_14;
        var val_15;
        string val_16;
        var val_17;
        var val_18;
        float val_19;
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        Player val_1 = App.Player;
        if(currentPurchase.PrePurchaseUserInfo.total_purchase == 0f)
        {
                val_14 = null;
            val_14 = null;
            App.trackerManager.track(eventName:  Events.FIRST_PURCHASE);
        }
        
        if(val_1.num_purchase == 2)
        {
                val_15 = null;
            val_15 = null;
            App.trackerManager.track(eventName:  Events.REPEAT_PURCHASER);
        }
        
        string val_3 = currentPurchase.sale_price.ToString().Replace(oldValue:  ".", newValue:  "");
        val_16 = "";
        if(val_5.Length < 1)
        {
            goto label_35;
        }
        
        val_17 = 0;
        label_34:
        if((System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()).GetFields()[val_17].Contains(value:  val_3)) == true)
        {
            goto label_33;
        }
        
        val_17 = val_17 + 1;
        if(val_17 < val_5.Length)
        {
            goto label_34;
        }
        
        goto label_35;
        label_33:
        val_16 = val_5[0x0] + 32;
        label_35:
        if((System.String.IsNullOrEmpty(value:  val_16)) != false)
        {
                val_16 = "No adjust purchase event found containing purchase price of " + val_3;
            UnityEngine.Debug.LogError(message:  val_16);
        }
        else
        {
                val_18 = null;
            val_18 = null;
            App.trackerManager.track(eventName:  val_16);
        }
        
        val_19 = val_1.total_purchased;
        if(val_19 > 50f)
        {
                float val_15 = currentPurchase.sale_price;
            val_15 = val_19 - val_15;
            if(val_15 < 0)
        {
                val_20 = null;
            val_20 = null;
            val_16 = App.trackerManager;
            val_16.track(eventName:  Events.TOTAL_PURCHASE_THRESHOLD_50);
            val_19 = val_1.total_purchased;
        }
        
        }
        
        if(val_19 > 100f)
        {
                float val_16 = currentPurchase.sale_price;
            val_16 = val_19 - val_16;
            if(val_16 < 0)
        {
                val_21 = null;
            val_21 = null;
            val_16 = App.trackerManager;
            val_16.track(eventName:  Events.TOTAL_PURCHASE_THRESHOLD_100);
            val_19 = val_1.total_purchased;
        }
        
        }
        
        if(val_19 > 500f)
        {
                float val_17 = currentPurchase.sale_price;
            val_17 = val_19 - val_17;
            if(val_17 < 0)
        {
                val_22 = null;
            val_22 = null;
            val_16 = App.trackerManager;
            val_16.track(eventName:  Events.TOTAL_PURCHASE_THRESHOLD_500);
            val_19 = val_1.total_purchased;
        }
        
        }
        
        if(val_19 > 1000f)
        {
                val_19 = val_19 - currentPurchase.sale_price;
            if(val_19 < 0)
        {
                val_23 = null;
            val_23 = null;
            val_16 = 1152921504883736576;
            App.trackerManager.track(eventName:  Events.TOTAL_PURCHASE_THRESHOLD_1000);
        }
        
        }
        
        if((currentPurchase.id.Contains(value:  "gems")) != false)
        {
                val_24 = null;
            val_24 = null;
            val_16 = 1152921504883736576;
            App.trackerManager.track(eventName:  Events.PURCHASE_GEMS);
        }
        
        if((currentPurchase.id.Contains(value:  "bundle")) != false)
        {
                val_25 = null;
            val_25 = null;
            val_16 = 1152921504883736576;
            App.trackerManager.track(eventName:  Events.BUNDLE_PURCHASE);
        }
        
        if((currentPurchase.id.Contains(value:  "food")) != false)
        {
                val_26 = null;
            val_26 = null;
            App.trackerManager.track(eventName:  Events.PURCHASE_FOOD);
        }
        
        MonoSingleton<WGSerialTracker>.Instance.PurchaseTrackHour();
        MonoSingleton<WGSerialTracker>.Instance.PurchaseAndRetention();
    }
    public TrackingHandler()
    {
    
    }

}
