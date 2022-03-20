using UnityEngine;
public class WADPetsManager : MonoSingleton<WADPetsManager>
{
    // Fields
    public bool QHACK_UseMinutes;
    private WADPets.WADPetsUtils petsUtils;
    private static WADPets.WADPetsUtils notreally_staticPetsUtils;
    private WADPets.WADPetsStatus petsStatus;
    private WADPets.LevelTracking levelTrackingInfo;
    private WADPets.LevelTracking savedLevelTrackingInfo;
    private WADPets.LifetimeTracking <LifetimeTrackingInfo>k__BackingField;
    private bool <IsDataInitialized>k__BackingField;
    private GameStoreCategory foodStoreCategory;
    private bool packagesAdded;
    
    // Properties
    public WADPets.LifetimeTracking LifetimeTrackingInfo { get; set; }
    public bool IsDataInitialized { get; set; }
    private static System.Collections.Generic.List<WADPets.WADPet> AllPetsCollection { get; }
    
    // Methods
    public WADPets.LifetimeTracking get_LifetimeTrackingInfo()
    {
        return (WADPets.LifetimeTracking)this.<LifetimeTrackingInfo>k__BackingField;
    }
    private void set_LifetimeTrackingInfo(WADPets.LifetimeTracking value)
    {
        this.<LifetimeTrackingInfo>k__BackingField = value;
    }
    public bool get_IsDataInitialized()
    {
        return (bool)this.<IsDataInitialized>k__BackingField;
    }
    private void set_IsDataInitialized(bool value)
    {
        this.<IsDataInitialized>k__BackingField = value;
    }
    private static System.Collections.Generic.List<WADPets.WADPet> get_AllPetsCollection()
    {
        return WADPetsManager.notreally_staticPetsUtils.AllPetsInfo;
    }
    private void TrustingServerData(Notification notif)
    {
        string val_10;
        var val_11;
        var val_20;
        System.Collections.Hashtable val_21;
        string val_22;
        val_20 = notif;
        if(val_20 == null)
        {
                return;
        }
        
        val_21 = notif.data;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = "response";
        if(val_21 == null)
        {
                return;
        }
        
        var val_1 = (((System.Collections.Hashtable.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_21) : 0;
        if((val_1.ContainsKey(key:  "pets")) == false)
        {
                return;
        }
        
        val_22 = "pets";
        object val_3 = val_1.Item[val_22];
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.IsNullOrEmpty(value:  val_3)) == true)
        {
                return;
        }
        
        val_22 = "pets";
        object val_5 = val_1.Item[val_22];
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = 0;
        if((MiniJSON.Json.Deserialize(json:  val_5)) == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_8 = GetEnumerator();
        label_21:
        if(val_11.MoveNext() == false)
        {
            goto label_16;
        }
        
        WADPetsManager.<>c__DisplayClass16_0 val_13 = null;
        val_22 = 0;
        val_13 = new WADPetsManager.<>c__DisplayClass16_0();
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        .petname = val_10;
        if(val_10 == 0)
        {
                throw new NullReferenceException();
        }
        
        WADPets.WADPet val_17 = WADPetsManager.AllPetsCollection.Find(match:  new System.Predicate<WADPets.WADPet>(object:  val_13, method:  System.Boolean WADPetsManager.<>c__DisplayClass16_0::<TrustingServerData>b__0(WADPets.WADPet x)));
        if(val_17 == null)
        {
            goto label_21;
        }
        
        val_17.Upgrade(hackLevel:  (System.Int32.Parse(s:  val_10, style:  511)) + 1);
        goto label_21;
        label_16:
        val_11.Dispose();
    }
    public override void InitMonoSingleton()
    {
        this.Initialize();
    }
    public System.Collections.Generic.Dictionary<string, int> SerializeUnlockedPets()
    {
        var val_4;
        var val_5;
        var val_10;
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
        List.Enumerator<T> val_3 = WADPetsManager.GetUnlockedPets().GetEnumerator();
        label_7:
        val_10 = public System.Boolean List.Enumerator<WADPets.WADPet>::MoveNext();
        if(val_5.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_4 + 16) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_10 = (val_4 + 16) + 16;
        if(val_10 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_10 = public System.String System.Enum::ToString();
        mem2[0] = val_10;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_10.ToString(), value:  (val_4 + 24) - 1);
        goto label_7;
        label_2:
        val_5.Dispose();
        return val_1;
    }
    public bool IsPetMaxLevel(WADPets.WADPet pet)
    {
        return (bool)(pet.LevelIndex == this.GetMaxLevel()) ? 1 : 0;
    }
    public void ShowPetUnlockedPopup(WADPets.WADPet pet)
    {
        if((MonoSingleton<WGWindowManager>.Instance.GetWindow<WADPetUnlockedPopup>().isActiveAndEnabled) != false)
        {
                if((MonoSingleton<WGWindowManager>.Instance.GetWindow<WADPetUnlockedPopup>()) != null)
        {
            goto label_9;
        }
        
        }
        
        label_9:
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WADPetUnlockedPopup>(showNext:  true).Setup(pet:  pet);
    }
    public void ShowFeedYourPetsPopup()
    {
        if(WADPetsManager.IsAnyPetHungry() == false)
        {
                return;
        }
        
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WADPetsFeedFoodPopup>(showNext:  true);
    }
    public void ResetPetStats()
    {
        List.Enumerator<T> val_2 = new System.Collections.Generic.List<WADPets.WADPet>().GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if((0 == 0) || (0 == 0))
        {
            goto label_5;
        }
        
        goto label_5;
        label_2:
        0.Dispose();
    }
    public bool FeedAllPets()
    {
        var val_13;
        var val_14;
        var val_15;
        Player val_1 = App.Player;
        val_13 = 1152921505018187776;
        val_14 = null;
        val_14 = null;
        if(val_1._food < WADPets.WADPetsEcon.FeedCost)
        {
                val_15 = 0;
            return (bool)val_15;
        }
        
        .AmountSpent = WADPets.WADPetsEcon.FeedCost;
        Player val_3 = App.Player;
        .PreviousFood = val_3._food;
        Player val_4 = App.Player;
        int val_13 = WADPets.WADPetsEcon.FeedCost;
        val_13 = val_4._food - val_13;
        .CurrentFood = val_13;
        App.Player.AddPetsFood(amount:  -WADPets.WADPetsEcon.FeedCost, source:  "Feed Pet", subSource:  0, FoodSpentParams:  new WADPets.Tracking_FoodSpent(), additionalParam:  0);
        App.Player.SaveState();
        val_13 = 1152921504858230784;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnPetsFoodUpdated");
        System.DateTime val_8 = DateTimeCheat.UtcNow;
        this.petsStatus.LastFedUtcTime = val_8;
        this.SchedulePetHungryLPN();
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<AdsUIController>.Instance)) != false)
        {
                MonoSingleton<AdsUIController>.Instance.ToggleIncentivizedButton();
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnPetsStatusUpdated");
        val_15 = 1;
        return (bool)val_15;
    }
    public System.TimeSpan GetTimeCountdownToNextFeed()
    {
        var val_6;
        var val_7;
        var val_9;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = this.petsStatus.LastFedUtcTime})) != false)
        {
                return 0;
        }
        
        val_6 = null;
        if(this.QHACK_UseMinutes != false)
        {
                val_7 = null;
            System.DateTime val_3 = this.petsStatus.LastFedUtcTime.AddMinutes(value:  (double)WADPets.WADPetsEcon.FedDurationHours);
        }
        else
        {
                val_9 = null;
            System.DateTime val_4 = this.petsStatus.LastFedUtcTime.AddHours(value:  (double)WADPets.WADPetsEcon.FedDurationHours);
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_4.dateData}, d2:  new System.DateTime() {dateData = val_5.dateData});
    }
    public void UpgradePet(WADPets.WADPet pet)
    {
        WADPets.WADPetUpgradeRequirement val_1 = WADPetsManager.GetUpgradeRequirement(levelIndex:  pet.LevelIndex);
        if(pet.Cards < val_1.Cards)
        {
                return;
        }
        
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_1.Coins);
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid})) != false)
        {
                GameBehavior val_5 = App.getBehavior;
            val_5.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  0);
            return;
        }
        
        pet.Upgrade(hackLevel:  0);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnPetsStatusUpdated");
    }
    public bool IsAnyUpgradeAvailable()
    {
        var val_5;
        System.Predicate<WADPets.WADPet> val_7;
        val_5 = null;
        val_5 = null;
        val_7 = WADPetsManager.<>c.<>9__26_0;
        if(val_7 != null)
        {
                return (bool)((WADPetsManager.AllPetsCollection.Find(match:  System.Predicate<WADPets.WADPet> val_2 = null)) != 0) ? 1 : 0;
        }
        
        val_7 = val_2;
        val_2 = new System.Predicate<WADPets.WADPet>(object:  WADPetsManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADPetsManager.<>c::<IsAnyUpgradeAvailable>b__26_0(WADPets.WADPet x));
        WADPetsManager.<>c.<>9__26_0 = val_7;
        return (bool)((WADPetsManager.AllPetsCollection.Find(match:  val_2)) != 0) ? 1 : 0;
    }
    public WADPets.WADPet GetAnyUpgradeablePet(bool onlyUnlockable = False)
    {
        WADPets.WADPet val_4;
        var val_5;
        int val_10;
        var val_11;
        System.Collections.Generic.List<WADPets.WADPet> val_1 = new System.Collections.Generic.List<WADPets.WADPet>();
        List.Enumerator<T> val_3 = WADPetsManager.AllPetsCollection.GetEnumerator();
        label_11:
        if(val_5.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(onlyUnlockable == false)
        {
            goto label_3;
        }
        
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_4 + 28) != 0)
        {
            goto label_11;
        }
        
        val_10 = 0;
        goto label_6;
        label_3:
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_10 = mem[val_4 + 24];
        val_10 = val_4 + 24;
        label_6:
        if((WADPetsManager.GetUpgradeRequirement(levelIndex:  val_10)) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_4 + 32) < val_7.Cards)
        {
            goto label_11;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_4);
        goto label_11;
        label_2:
        var val_9 = 1152921515677507840;
        val_5.Dispose();
        if(as. 
           
           
          
        
        
        
         != 0)
        {
                int val_8 = UnityEngine.Random.Range(min:  0, max:  -1814241024);
            if(val_9 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_9 = val_9 + (val_8 << 3);
            val_11 = mem[(1152921515677507840 + (val_8) << 3) + 32];
            val_11 = (1152921515677507840 + (val_8) << 3) + 32;
            return (WADPets.WADPet)val_11;
        }
        
        val_11 = 0;
        return (WADPets.WADPet)val_11;
    }
    public WADPets.WADPet GetRandomPet()
    {
        var val_7;
        System.Predicate<WADPets.WADPet> val_9;
        System.Collections.Generic.List<WADPets.WADPet> val_2 = new System.Collections.Generic.List<WADPets.WADPet>(collection:  WADPetsManager.AllPetsCollection);
        if(Alphabet2Manager.IsAvailable != false)
        {
                if(val_2 != null)
        {
            goto label_4;
        }
        
        }
        
        val_7 = null;
        val_7 = null;
        val_9 = WADPetsManager.<>c.<>9__28_0;
        if(val_9 == null)
        {
                System.Predicate<WADPets.WADPet> val_4 = null;
            val_9 = val_4;
            val_4 = new System.Predicate<WADPets.WADPet>(object:  WADPetsManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADPetsManager.<>c::<GetRandomPet>b__28_0(WADPets.WADPet x));
            WADPetsManager.<>c.<>9__28_0 = val_9;
        }
        
        var val_7 = 1152921516782054736;
        int val_5 = val_2.RemoveAll(match:  val_4);
        label_4:
        int val_6 = UnityEngine.Random.Range(min:  0, max:  -709628912);
        if(val_7 <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + (val_6 << 3);
        return (WADPets.WADPet)(1152921516782054736 + (val_6) << 3) + 32;
    }
    public void RewardPetCards(int amount, WADPets.WADPet pet, string source, string subsource, System.Collections.Generic.Dictionary<string, object> additionalParam)
    {
        WADPets.WADPet val_10 = pet;
        if(val_10 == null)
        {
                val_10 = this.GetRandomPet();
        }
        
        int val_10 = val_1.Cards;
        val_10 = val_10 + amount;
        val_1.Cards = val_10;
        if(source == null)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
        val_10 = val_2;
        val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "Current Cards", value:  WADPetsManager.GetCardsBalance());
        if(additionalParam == null)
        {
            goto label_14;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_5 = additionalParam.Keys.GetEnumerator();
        label_8:
        if(0.MoveNext() == false)
        {
            goto label_7;
        }
        
        val_2.Add(key:  0, value:  additionalParam.Item[0]);
        goto label_8;
        label_7:
        0.Dispose();
        label_14:
        App.Player.TrackNonCoinReward(source:  source, subSource:  subsource, rewardType:  "Cards", rewardAmount:  amount.ToString(), additionalParams:  val_2);
    }
    public bool CheckFTUX()
    {
        WADPets.WADPet val_5;
        var val_6;
        System.Collections.Generic.List<WADPets.WADPet> val_17;
        var val_18;
        var val_19;
        var val_20;
        if(SceneDictator.IsInGameScene() == false)
        {
            goto label_26;
        }
        
        System.Collections.Generic.List<WADPets.WADPet> val_2 = null;
        val_17 = val_2;
        val_18 = public System.Void System.Collections.Generic.List<WADPets.WADPet>::.ctor();
        val_2 = new System.Collections.Generic.List<WADPets.WADPet>();
        System.Collections.Generic.List<WADPets.WADPet> val_3 = WADPetsManager.AllPetsCollection;
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_4 = val_3.GetEnumerator();
        goto label_18;
        label_24:
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_5 + 36) != 0)
        {
            goto label_18;
        }
        
        if((val_5 + 16) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(((val_5 + 16 + 20) - 2) < 2)
        {
            goto label_18;
        }
        
        if((val_5 + 16 + 20) == 4)
        {
            goto label_10;
        }
        
        if((val_5 + 16 + 20) == 5)
        {
            goto label_18;
        }
        
        label_23:
        if(val_5.IsActive() == false)
        {
            goto label_18;
        }
        
        mem2[0] = 1;
        val_18 = mem[val_5 + 384 + 8];
        val_18 = val_5 + 384 + 8;
        val_19 = val_5;
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(item:  val_5);
        goto label_18;
        label_10:
        AdsUIController val_9 = MonoSingleton<AdsUIController>.Instance;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_18 = 0;
        if(val_9.VideoAdsAllowed == false)
        {
            goto label_18;
        }
        
        AdsUIController val_11 = MonoSingleton<AdsUIController>.Instance;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_11.FreeHintButtonGroup.activeSelf == true)
        {
            goto label_23;
        }
        
        label_18:
        if(val_6.MoveNext() == true)
        {
            goto label_24;
        }
        
        val_18 = public System.Void List.Enumerator<WADPets.WADPet>::Dispose();
        val_6.Dispose();
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if((public System.Void List.Enumerator<WADPets.WADPet>::Dispose()) != 0)
        {
                WADPetsUIController val_15 = MonoSingleton<WADPetsUIController>.Instance;
            if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
            val_15.ShowFTUX(pets:  val_2);
            val_20 = 1;
            return (bool)val_20;
        }
        
        label_26:
        val_20 = 0;
        return (bool)val_20;
    }
    public static System.Collections.Generic.List<WADPets.WADPet> GetHungryPets()
    {
        var val_4;
        System.Predicate<WADPets.WADPet> val_6;
        val_4 = null;
        val_4 = null;
        val_6 = WADPetsManager.<>c.<>9__31_0;
        if(val_6 != null)
        {
                return System.Linq.Enumerable.ToList<WADPets.WADPet>(source:  WADPetsManager.AllPetsCollection.FindAll(match:  System.Predicate<WADPets.WADPet> val_2 = null));
        }
        
        val_6 = val_2;
        val_2 = new System.Predicate<WADPets.WADPet>(object:  WADPetsManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADPetsManager.<>c::<GetHungryPets>b__31_0(WADPets.WADPet x));
        WADPetsManager.<>c.<>9__31_0 = val_6;
        return System.Linq.Enumerable.ToList<WADPets.WADPet>(source:  WADPetsManager.AllPetsCollection.FindAll(match:  val_2));
    }
    public static System.Collections.Generic.List<WADPets.WADPet> GetUnlockedPets()
    {
        var val_4;
        System.Predicate<WADPets.WADPet> val_6;
        val_4 = null;
        val_4 = null;
        val_6 = WADPetsManager.<>c.<>9__32_0;
        if(val_6 != null)
        {
                return System.Linq.Enumerable.ToList<WADPets.WADPet>(source:  WADPetsManager.AllPetsCollection.FindAll(match:  System.Predicate<WADPets.WADPet> val_2 = null));
        }
        
        val_6 = val_2;
        val_2 = new System.Predicate<WADPets.WADPet>(object:  WADPetsManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADPetsManager.<>c::<GetUnlockedPets>b__32_0(WADPets.WADPet x));
        WADPetsManager.<>c.<>9__32_0 = val_6;
        return System.Linq.Enumerable.ToList<WADPets.WADPet>(source:  WADPetsManager.AllPetsCollection.FindAll(match:  val_2));
    }
    public static System.Collections.Generic.List<WADPets.WADPet> GetAllPetsCollection()
    {
        return WADPetsManager.AllPetsCollection;
    }
    public static int GetCardsBalance()
    {
        var val_3;
        System.Func<WADPets.WADPet, System.Int32> val_5;
        val_3 = null;
        val_3 = null;
        val_5 = WADPetsManager.<>c.<>9__34_0;
        if(val_5 != null)
        {
                return System.Linq.Enumerable.Sum<WADPets.WADPet>(source:  WADPetsManager.AllPetsCollection, selector:  System.Func<WADPets.WADPet, System.Int32> val_2 = null);
        }
        
        val_5 = val_2;
        val_2 = new System.Func<WADPets.WADPet, System.Int32>(object:  WADPetsManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WADPetsManager.<>c::<GetCardsBalance>b__34_0(WADPets.WADPet x));
        WADPetsManager.<>c.<>9__34_0 = val_5;
        return System.Linq.Enumerable.Sum<WADPets.WADPet>(source:  WADPetsManager.AllPetsCollection, selector:  val_2);
    }
    public static bool IsFeatureUnlocked()
    {
        var val_3;
        if(WADPetsManager.notreally_staticPetsUtils == 0)
        {
                val_3 = 0;
            return (bool)val_3;
        }
        
        if(WADPetsManager.GetCardsBalance() <= 0)
        {
                return WADPetsManager.IsAnyPetUnlocked();
        }
        
        val_3 = 1;
        return (bool)val_3;
    }
    public static bool IsAnyPetUnlocked()
    {
        var val_5;
        System.Predicate<WADPets.WADPet> val_7;
        val_5 = null;
        val_5 = null;
        val_7 = WADPetsManager.<>c.<>9__36_0;
        if(val_7 != null)
        {
                return (bool)((WADPetsManager.AllPetsCollection.Find(match:  System.Predicate<WADPets.WADPet> val_2 = null)) != 0) ? 1 : 0;
        }
        
        val_7 = val_2;
        val_2 = new System.Predicate<WADPets.WADPet>(object:  WADPetsManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADPetsManager.<>c::<IsAnyPetUnlocked>b__36_0(WADPets.WADPet x));
        WADPetsManager.<>c.<>9__36_0 = val_7;
        return (bool)((WADPetsManager.AllPetsCollection.Find(match:  val_2)) != 0) ? 1 : 0;
    }
    public static bool IsAnyPetHungry()
    {
        var val_5;
        System.Predicate<WADPets.WADPet> val_7;
        val_5 = null;
        val_5 = null;
        val_7 = WADPetsManager.<>c.<>9__37_0;
        if(val_7 != null)
        {
                return (bool)((WADPetsManager.AllPetsCollection.Find(match:  System.Predicate<WADPets.WADPet> val_2 = null)) != 0) ? 1 : 0;
        }
        
        val_7 = val_2;
        val_2 = new System.Predicate<WADPets.WADPet>(object:  WADPetsManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADPetsManager.<>c::<IsAnyPetHungry>b__37_0(WADPets.WADPet x));
        WADPetsManager.<>c.<>9__37_0 = val_7;
        return (bool)((WADPetsManager.AllPetsCollection.Find(match:  val_2)) != 0) ? 1 : 0;
    }
    public static WADPets.WADPet GetPetByAbility(WADPets.WADPetAbility ability)
    {
        .ability = ability;
        return WADPetsManager.AllPetsCollection.Find(match:  new System.Predicate<WADPets.WADPet>(object:  new WADPetsManager.<>c__DisplayClass38_0(), method:  System.Boolean WADPetsManager.<>c__DisplayClass38_0::<GetPetByAbility>b__0(WADPets.WADPet x)));
    }
    public static bool GetUnlockedPetByAbility(WADPets.WADPetAbility ability)
    {
        var val_4;
        if(WADPetsManager.notreally_staticPetsUtils == 0)
        {
                val_4 = 0;
            return (bool)(val_2.IsUnlocked == true) ? 1 : 0;
        }
        
        WADPets.WADPet val_2 = WADPetsManager.GetPetByAbility(ability:  ability);
        return (bool)(val_2.IsUnlocked == true) ? 1 : 0;
    }
    public static WADPets.WADPetUpgradeRequirement GetUpgradeRequirement(int levelIndex)
    {
        var val_4;
        if((MonoSingleton<WADPetsManager>.Instance.GetMaxLevel()) == levelIndex)
        {
                WADPets.WADPetUpgradeRequirement val_3 = null;
            val_4 = val_3;
            val_3 = new WADPets.WADPetUpgradeRequirement();
            .Cards = ;
            return (WADPets.WADPetUpgradeRequirement)val_4;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_4 = mem[(System.Collections.Generic.List<T>.__il2cppRuntimeField_name + (levelIndex) << 3) + 32];
        val_4 = (System.Collections.Generic.List<T>.__il2cppRuntimeField_name + (levelIndex) << 3) + 32;
        return (WADPets.WADPetUpgradeRequirement)val_4;
    }
    public static float GetLevelCurveModifier(WADPets.WADPetAbility ability)
    {
        WADPets.WADPetAbility val_9;
        var val_10;
        System.Collections.Generic.List<System.Single> val_11;
        val_9 = ability;
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  val_9);
        val_10 = 0f;
        if(val_1 == null)
        {
                return (float)val_10;
        }
        
        val_9 = val_1;
        if(val_1.IsActive() == false)
        {
                return (float)val_10;
        }
        
        if(val_1.Info.LevelCurveModifierRanges >= 1)
        {
                int val_7 = val_1.LevelIndex;
            val_11 = val_7 - 1;
            if(val_1.Info.LevelCurveModifierRanges <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_7 = val_7 + (val_11 << 2);
            if(((val_1.LevelIndex + ((val_1.LevelIndex - 1)) << 2) + 32) == 0f)
        {
                WADPets.WADPetInfo val_8 = val_1.Info;
            val_11 = val_1.Info.LevelCurveModifiers;
            int val_3 = val_1.LevelIndex - 1;
            if(W10 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = val_8 + (val_3 << 3);
            System.Collections.Generic.List<WADPets.WADPetLevelAbilityRange> val_9 = (val_1.Info + ((val_1.LevelIndex - 1)) << 3).LevelCurveModifierRanges;
            int val_4 = val_1.LevelIndex - 1;
            if(W10 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_9 = val_9 + (val_4 << 3);
            val_11.set_Item(index:  val_3, value:  (float)UnityEngine.Random.Range(min:  val_1.Info.LevelCurveModifierRanges, max:  val_9 + 1));
        }
        
        }
        
        int val_10 = val_1.LevelIndex;
        val_9 = val_10 - 1;
        if(val_1.LevelIndex <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + (val_9 << 2);
        val_10 = mem[(val_1.LevelIndex + ((val_1.LevelIndex - 1)) << 2) + 32];
        val_10 = (val_1.LevelIndex + ((val_1.LevelIndex - 1)) << 2) + 32;
        return (float)val_10;
    }
    public string GetFoodBalanceText()
    {
        Player val_1 = App.Player;
        decimal val_2 = System.Decimal.op_Implicit(value:  val_1._food);
        return NumberAbbreviation.GetNumber(num:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
    }
    public static string GetFormattedTimeText(System.TimeSpan time)
    {
        return (string)System.String.Format(format:  "{0}:{1}:{2}", arg0:  UnityEngine.Mathf.Max(a:  time._ticks.Hours, b:  0), arg1:  UnityEngine.Mathf.Max(a:  time._ticks.Minutes, b:  0).ToString(format:  "00"), arg2:  UnityEngine.Mathf.Max(a:  time._ticks.Seconds, b:  0).ToString(format:  "00"));
    }
    public static string GetAbilityDescription(WADPets.WADPet pet)
    {
        var val_8;
        string val_9;
        var val_10;
        WADPets.WADPetInfo val_11;
        object val_12;
        val_8 = null;
        val_8 = null;
        System.Collections.Generic.KeyValuePair<System.String, System.String> val_1 = WADPets.LocTexts.AbilityDescription.Item[pet.Info.Ability];
        val_9 = pet.Info.Ability;
        if(pet.IsUnlocked != false)
        {
                val_10 = pet.LevelIndex - 1;
        }
        else
        {
                val_10 = 0;
        }
        
        val_11 = pet.Info;
        if(pet.Info.LevelCurveModifierRanges >= 1)
        {
                if(pet.Info <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_9 = 1152921504619999232;
            val_12 = WADPets.WADPetInfo.__il2cppRuntimeField_byval_arg + 16;
            if(pet.Info <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            string val_3 = System.String.Format(format:  Localization.Localize(key:  val_1.Value, defaultValue:  val_9, useSingularKey:  false), arg0:  WADPets.WADPetInfo.__il2cppRuntimeField_byval_arg + 16, arg1:  WADPets.WADPetInfo.__il2cppRuntimeField_byval_arg + 20);
            return (string)System.String.Format(format:  val_12 = Localization.Localize(key:  val_1.Value, defaultValue:  val_9, useSingularKey:  false), arg0:  (val_7 == 2) ? (val_8) : System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg);
        }
        
        if(pet.Info.LevelCurveModifierRanges <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_11 = pet.Info;
        }
        
        WADPets.WADPetAbility val_7 = pet.Info.Ability;
        float val_8 = 100f;
        val_7 = val_7 & 4294967294;
        val_8 = (System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg) * val_8;
        return (string)System.String.Format(format:  val_12, arg0:  (val_7 == 2) ? (val_8) : System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg);
    }
    private void Initialize()
    {
        var val_9;
        WADPetsManager.notreally_staticPetsUtils = this.petsUtils;
        this.InitializePets();
        this.petsStatus = new WADPets.WADPetsStatus();
        this.levelTrackingInfo = new WADPets.LevelTracking();
        .Food = 10;
        this.<LifetimeTrackingInfo>k__BackingField = new WADPets.LifetimeTracking();
        this.<IsDataInitialized>k__BackingField = true;
        val_9 = null;
        val_9 = null;
        System.Delegate val_5 = System.Delegate.Combine(a:  GameStoreUI.OnCreatePackItems, b:  new System.Action(object:  this, method:  System.Void WADPetsManager::OnStoreCreatePackItems()));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        GameStoreUI.OnCreatePackItems = val_5;
        System.Delegate val_7 = System.Delegate.Combine(a:  GameStoreUI.OnRefreshDisplay, b:  new System.Action(object:  this, method:  System.Void WADPetsManager::OnStoreRefreshDisplay()));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        GameStoreUI.OnRefreshDisplay = val_7;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "TrustingServerData");
        return;
        label_10:
    }
    private void OnStoreCreatePackItems()
    {
    
    }
    private void OnStoreRefreshDisplay()
    {
    
    }
    private int GetMaxLevel()
    {
        return (int)System.Collections.Generic.List<T>.__il2cppRuntimeField_namespaze;
    }
    private void InitializePetsCollection()
    {
        WADPetsManager.notreally_staticPetsUtils = this.petsUtils;
    }
    private void InitializePets()
    {
        List.Enumerator<T> val_2 = WADPetsManager.AllPetsCollection.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_4;
        label_2:
        0.Dispose();
    }
    private void SchedulePetHungryLPN()
    {
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  24);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "notification_type", value:  "feed_pet");
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this.petsStatus.LastFedUtcTime}, d2:  new System.DateTime())) != false)
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
        }
        else
        {
                System.DateTime val_4 = DateTimeCheat.UtcNow;
            System.TimeSpan val_5 = this.GetTimeCountdownToNextFeed();
            System.DateTime val_7 = val_4.dateData.AddSeconds(value:  val_5._ticks.TotalSeconds);
        }
        
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  24, when:  new System.DateTime() {dateData = val_7.dateData}, optMessage:  "Feed your Pets to activate benefits!", extraData:  val_1);
    }
    private static int GetPetIndexInCollection(WADPets.WADPet pet)
    {
        .pet = pet;
        return WADPetsManager.AllPetsCollection.FindIndex(match:  new System.Predicate<WADPets.WADPet>(object:  new WADPetsManager.<>c__DisplayClass54_0(), method:  System.Boolean WADPetsManager.<>c__DisplayClass54_0::<GetPetIndexInCollection>b__0(WADPets.WADPet x)));
    }
    public void Tracking_HasBonusAlphabetTile()
    {
        this.levelTrackingInfo.HasBonusAlphabetTile = true;
        goto typeof(WADPets.LevelTracking).__il2cppRuntimeField_180;
    }
    public void Tracking_GainedBonusAlphabetTile()
    {
        if(this.levelTrackingInfo.HasBonusAlphabetTile == false)
        {
                return;
        }
        
        this.levelTrackingInfo.GainedBonusAlphabetTile = true;
        goto typeof(WADPets.LevelTracking).__il2cppRuntimeField_180;
    }
    public void Tracking_HasAlphabetTile()
    {
        this.levelTrackingInfo.HasAlphabetTileInLevel = true;
        goto typeof(WADPets.LevelTracking).__il2cppRuntimeField_180;
    }
    public System.Collections.Generic.Dictionary<string, object> GetBonusGoldenApplesRewardTrackingParameters(GameLevel level)
    {
        var val_6;
        var val_7;
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  2);
        if(val_1 != null)
        {
                val_6 = val_1;
            if(val_1.IsActive() != false)
        {
                float val_6 = (float)level.goldenApplesStreaks;
            val_6 = (WADPetsManager.GetLevelCurveModifier(ability:  2)) * val_6;
            int val_4 = UnityEngine.Mathf.RoundToInt(f:  val_6);
            val_1.CachedValueModifier = (float)val_4;
            if(val_4 >= 1)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = null;
            val_7 = val_5;
            val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_5.Add(key:  "Pet Ability: Coco Bonus", value:  val_1.CachedValueModifier);
            return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_7;
        }
        
        }
        
        }
        
        val_7 = 0;
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_7;
    }
    public void SaveLevelTrackingInfo()
    {
        WADPets.LevelTracking val_1 = new WADPets.LevelTracking();
        this.savedLevelTrackingInfo = this.levelTrackingInfo;
    }
    public void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> curData)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(this.savedLevelTrackingInfo.HasBonusAlphabetTile != false)
        {
                curData.Add(key:  "Bonus Alphabet Tile", value:  this.savedLevelTrackingInfo.GainedBonusAlphabetTile);
        }
        
        this.ResetLevelCompleteEventTracking();
    }
    public void ResetLevelCompleteEventTracking()
    {
        if(this.levelTrackingInfo != null)
        {
                this.levelTrackingInfo.HasBonusAlphabetTile = false;
            this.levelTrackingInfo.GainedBonusAlphabetTile = false;
            this.levelTrackingInfo.HasAlphabetTileInLevel = false;
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public void Tracking_LifetimeFoodIncreased(int amount)
    {
        int val_1 = this.<LifetimeTrackingInfo>k__BackingField.Food;
        val_1 = val_1 + amount;
        this.<LifetimeTrackingInfo>k__BackingField.Food = val_1;
        goto typeof(WADPets.LifetimeTracking).__il2cppRuntimeField_180;
    }
    public WADPetsManager()
    {
    
    }

}
