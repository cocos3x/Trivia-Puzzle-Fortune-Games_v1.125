using UnityEngine;

namespace twelvegigs.Autopilot
{
    public class AutopilotTracker : Tracker
    {
        // Fields
        private string deviceId;
        private string clientVersion;
        
        // Methods
        public void InjectRegularGlobals(string eventName, System.Collections.Generic.Dictionary<string, object> globals)
        {
            var val_38;
            string val_39;
            UnityEngine.Object val_40;
            bool val_41;
            Player val_1 = App.Player;
            if(App.getBehavior == null)
            {
                    throw new NullReferenceException();
            }
            
            if(App.getBehavior == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = 0;
            if(globals == null)
            {
                    throw new NullReferenceException();
            }
            
            globals.Add(key:  "Purchaser", value:  (val_1.total_purchased > 0f) ? 1 : 0.ToString());
            globals.Add(key:  "Network Purchaser", value:  val_1.NetworkPurchaser.ToString());
            globals.Add(key:  "Level", value:  val_1);
            val_39 = "Coins";
            globals.Add(key:  val_39, value:  val_1._credits.ToString());
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Hacker";
            globals.Add(key:  val_39, value:  val_10.isHacker);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "total_transactions";
            globals.Add(key:  val_39, value:  val_11.num_purchase);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            globals.Add(key:  "total_purchase", value:  val_12.total_purchased);
            val_40 = DefaultHandler<SubscriptionHandler>.Instance;
            val_39 = 0;
            if(val_40 == val_39)
            {
                goto label_18;
            }
            
            SubscriptionHandler val_15 = DefaultHandler<SubscriptionHandler>.Instance;
            if(val_15 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = 0;
            if((val_15.IsActive(subPackage:  val_39)) == false)
            {
                goto label_18;
            }
            
            SubscriptionHandler val_17 = DefaultHandler<SubscriptionHandler>.Instance;
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = 0;
            if((val_17.getCurrentModel(subPackage:  val_39)) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = (val_18.<trial>k__BackingField) ^ 1;
            goto label_23;
            label_18:
            val_41 = false;
            label_23:
            val_39 = "Golden Ticket Sub Active";
            globals.Add(key:  val_39, value:  val_41);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_19.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Golden Ticket Sub Purchases";
            globals.Add(key:  val_39, value:  val_19.properties.numSubscriptionsPurchased);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_20.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Silver Ticket Sub Active";
            globals.Add(key:  val_39, value:  val_20.properties.has_Active_Subscription_Silver);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_21.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Silver Ticket Sub Purchases";
            globals.Add(key:  val_39, value:  val_21.properties.numSubscriptionsPurchased_Silver);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_22.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Goal Extra Words";
            globals.Add(key:  val_39, value:  val_22.properties.GoalExtraWords);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_23.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Goal Use Hints";
            globals.Add(key:  val_39, value:  val_23.properties.GoalUseHints);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_24.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Goal Golden Currency";
            globals.Add(key:  val_39, value:  val_24.properties.GoalGoldenCurrency);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_25.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Goal Daily Challenge";
            globals.Add(key:  val_39, value:  val_25.properties.GoalDailyChallenge);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_26.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Goal Twitter Post";
            globals.Add(key:  val_39, value:  val_26.properties.GoalTwitterPosts);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_27.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39 = "Goal Friend Inviter";
            globals.Add(key:  val_39, value:  val_27.properties.GoalFriendInvites);
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_28.properties == null)
            {
                    throw new NullReferenceException();
            }
            
            globals.Add(key:  "User IQ", value:  val_28.properties.PlayerIQ);
            globals.Add(key:  "Lifetime Books Purchased", value:  TheLibraryLogic.LifetimeBooksPurchased);
            globals.Add(key:  "Lifetime Books Earned", value:  TheLibraryLogic.LifetimeBooksEarned);
            globals.Add(key:  "Library Score", value:  TheLibraryLogic.LibraryScore);
            globals.Add(key:  "Library Collections Completed", value:  TheLibraryLogic.CountCompletedCollections());
            val_39 = "Lifetime Book Packs Purchased";
            val_38 = globals;
            val_38.Add(key:  val_39, value:  TheLibraryLogic.LifetimeBookPacksPurchased);
            if((val_2.<metaGameBehavior>k__BackingField) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
            {
                    return;
            }
            
            val_40 = 1152921515417176704;
            val_39 = 0;
            if((MonoSingleton<CategoryPacksManager>.Instance) == val_39)
            {
                    return;
            }
            
            if((MonoSingleton<CategoryPacksManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            globals.Add(key:  "Total Categories Complete", value:  val_36.totalCompletedPacks);
            CategoryPacksManager val_37 = MonoSingleton<CategoryPacksManager>.Instance;
            globals.Add(key:  "Total Categories Purchased", value:  val_37.totalPurchasedPacks);
        }
        public void InjectEventData(string eventName, System.Collections.Generic.Dictionary<string, object> data)
        {
            ApplicationConfig val_8;
            string val_9;
            if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
            if(data == null)
            {
                    throw new NullReferenceException();
            }
            
            data.Add(key:  "player_id", value:  val_1.id);
            val_9 = "device_id";
            data.Add(key:  val_9, value:  this.deviceId);
            if(App.Configuration == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_2.appConfig == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = "game";
            data.Add(key:  val_9, value:  val_2.appConfig.gameName);
            if(App.Configuration == null)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = val_3.appConfig;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = "env";
            data.Add(key:  val_9, value:  val_8.Environment);
            if(App.Configuration == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_5.appConfig == null)
            {
                    throw new NullReferenceException();
            }
            
            data.Add(key:  "branch", value:  val_5.appConfig.GitBranch);
            Player val_6 = App.Player;
            data.Add(key:  "bucket", value:  val_6.playerBucket);
            data.Add(key:  "platform", value:  DeviceProperties.Platform);
            data.Add(key:  "client_version", value:  this.clientVersion);
        }
        public override void trackEvent(string eventName, System.Collections.Generic.Dictionary<string, object> data)
        {
            UnityEngine.Object val_13;
            bool val_14;
            val_13 = twelvegigs.Autopilot.AutopilotManager.Requester;
            if(val_13 == 0)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_3.InjectRegularGlobals(eventName:  public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::.ctor(), globals:  val_3);
            this.InjectEventData(eventName:  public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::.ctor(), data:  data);
            if((data.ContainsKey(key:  "timestamp")) != true)
            {
                    System.DateTime val_5 = System.DateTime.UtcNow;
                data.Add(key:  "timestamp", value:  twelvegigs.storage.JsonDictionary.TotalSeconds(dateTime:  new System.DateTime() {dateData = val_5.dateData}));
            }
            
            data.Add(key:  "globals", value:  val_3);
            data.Add(key:  "event_name", value:  eventName);
            if((System.String.op_Equality(a:  eventName, b:  "auto_errors")) != false)
            {
                    val_14 = 1;
            }
            else
            {
                    val_14 = System.String.op_Equality(a:  eventName, b:  "auto_stop_actions");
            }
            
            val_13 = twelvegigs.Autopilot.AutopilotManager.Requester;
            if(val_13 == 0)
            {
                    return;
            }
            
            twelvegigs.Autopilot.AutopilotManager.Requester.SendEvent(eventData:  data, sendImmediately:  val_14);
        }
        public override void identify(string id)
        {
            this.deviceId = id;
            this.clientVersion = DeviceIdPlugin.GetClientVersion();
        }
        public override void trackEvent(string eventName, string propertyName, string propertyValue)
        {
        
        }
        public override void increment(string eventName, string eventValue)
        {
        
        }
        public override void peopleIncrement(string eventName, string eventValue)
        {
        
        }
        public override void peopleProperty(string propertyName, string propertyValue)
        {
        
        }
        public override void superProperty(string propertyName, string propertyValue)
        {
        
        }
        public override void trackCharge(string quantity, System.Collections.Generic.Dictionary<string, object> data)
        {
        
        }
        public AutopilotTracker()
        {
            this.clientVersion = System.String.alignConst;
        }
    
    }

}
