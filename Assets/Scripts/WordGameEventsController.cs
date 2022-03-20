using UnityEngine;
public class WordGameEventsController : MonoSingleton<WordGameEventsController>
{
    // Fields
    public const string NOTIFICATION_GAME_EVENT_CONTROLLER_UPDATE = "OnGameEventControllerUpdate";
    public const string NOTIFICATION_GAME_EVENT_HANDLER_PROGRESS = "OnGameEventHandlerProgress";
    private const string NOTIFICATION_PROFILE_UPDATE = "OnMyProfileUpdate";
    public bool isWordRegionLoaded;
    protected EventPrefabsConfig eventPrefabsConfig;
    private static readonly System.Collections.Generic.Dictionary<string, System.Type> DefaultTypeLookup;
    private static System.Collections.Generic.Dictionary<string, System.Type> compiledTypeLookup;
    private System.Collections.Generic.List<WGEventHandler> _currentEventHandlers;
    public WordGameEventsController.ProxyEventHandlerDelegate AddProxyEventHandlers;
    public WordGameEventsController.ProxyEventHandlerDelegate RemoveExpiredProxyEventHandlers;
    public static WordGameEventsController.ProxyEventTrackingDelegate AddTrackingEventData;
    private int QAHACK_SingleEventKeyIndex;
    
    // Properties
    public static bool EventsEnabled { get; }
    public EventPrefabsConfig EventPrefabsConfig { get; }
    private int unlockLevel { get; }
    private bool eventsDisplayable { get; }
    private static System.Collections.Generic.Dictionary<string, System.Type> TypeLookup { get; }
    public int GetCurrentEventsCount { get; }
    private System.Collections.Generic.List<WGEventHandler> currentEventHandlers { get; }
    public string QAHACK_CurrentSingleEventTypeKey { get; }
    
    // Methods
    public static bool get_EventsEnabled()
    {
        var val_9;
        if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
                GameBehavior val_3 = App.getBehavior;
            if(((val_3.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((MonoSingleton<WordGameEventsController>.Instance.eventsDisplayable) != false)
        {
                var val_8 = ((MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) != 0) ? 1 : 0;
            return (bool)val_9;
        }
        
        }
        
        }
        
        val_9 = 0;
        return (bool)val_9;
    }
    public EventPrefabsConfig get_EventPrefabsConfig()
    {
        EventPrefabsConfig val_5;
        if(this.eventPrefabsConfig == 0)
        {
                this.eventPrefabsConfig = UnityEngine.Object.Instantiate<EventPrefabsConfig>(original:  PrefabLoader.LoadPrefab<EventPrefabsConfig>(featureName:  "Events"), parent:  this.transform);
            return val_5;
        }
        
        val_5 = this.eventPrefabsConfig;
        return val_5;
    }
    private int get_unlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.events_unlockLevel;
    }
    private bool get_eventsDisplayable()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_4A0;
    }
    private static System.Collections.Generic.Dictionary<string, System.Type> get_TypeLookup()
    {
        System.Collections.Generic.Dictionary<TKey, TValue> val_8;
        var val_9;
        System.Collections.Generic.IDictionary<TKey, TValue> val_10;
        System.Collections.Generic.IDictionary<TKey, TValue> val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        val_9 = null;
        val_9 = null;
        if(WordGameEventsController.compiledTypeLookup != null)
        {
            goto label_32;
        }
        
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != null)
        {
                GameBehavior val_2 = App.getBehavior;
            val_10 = val_2.<metaGameBehavior>k__BackingField;
            System.Collections.Generic.Dictionary<System.String, System.Type> val_3 = null;
            val_11 = val_10;
            val_8 = val_3;
            val_3 = new System.Collections.Generic.Dictionary<System.String, System.Type>(dictionary:  val_11);
            val_12 = null;
        }
        else
        {
                val_13 = null;
            val_13 = null;
            val_10 = WordGameEventsController.DefaultTypeLookup;
            System.Collections.Generic.Dictionary<System.String, System.Type> val_4 = null;
            val_11 = val_10;
            val_8 = val_4;
            val_4 = new System.Collections.Generic.Dictionary<System.String, System.Type>(dictionary:  val_11);
        }
        
        val_12 = null;
        WordGameEventsController.compiledTypeLookup = val_8;
        GameBehavior val_5 = App.getBehavior;
        if((val_5.<metaGameBehavior>k__BackingField) == null)
        {
            goto label_32;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_6 = val_5.<metaGameBehavior>k__BackingField.GetEnumerator();
        label_26:
        if(0.MoveNext() == false)
        {
            goto label_23;
        }
        
        val_14 = null;
        val_14 = null;
        EnumerableExtentions.SetOrAdd<System.String, System.Type>(dic:  val_4, key:  0, newValue:  0);
        goto label_26;
        label_23:
        0.Dispose();
        label_32:
        val_15 = null;
        val_15 = null;
        return (System.Collections.Generic.Dictionary<System.String, System.Type>)WordGameEventsController.compiledTypeLookup;
    }
    public override void InitMonoSingleton()
    {
        var val_25;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        this.InitMonoSingleton();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventDataReceived");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventDataPutResponse");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFacebookPluginUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnMyProfileUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnMysteryChestCollected");
        System.Delegate val_9 = System.Delegate.Combine(a:  GoldenApplesManager.OnAppleAwarded, b:  new System.Action<System.Int32>(object:  this, method:  public System.Void WordGameEventsController::OnAppleAwarded(int appleAwarded)));
        if(val_9 != null)
        {
                if(null != null)
        {
            goto label_38;
        }
        
        }
        
        GoldenApplesManager.OnAppleAwarded = val_9;
        System.Delegate val_11 = System.Delegate.Combine(a:  TRVStarsManager.OnStarAwarded, b:  new System.Action<System.Int32>(object:  this, method:  public System.Void WordGameEventsController::OnAppleAwarded(int appleAwarded)));
        if(val_11 != null)
        {
                if(null != null)
        {
            goto label_38;
        }
        
        }
        
        TRVStarsManager.OnStarAwarded = val_11;
        GameBehavior val_12 = App.getBehavior;
        if(((val_12.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnSpinStarted");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnSpinEnded");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnReelStopped");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnAllReelsStopped");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnSpinAmountUpdate");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnSpinBetUpdate");
        }
        
        val_25 = null;
        val_25 = null;
        System.Delegate val_20 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WordGameEventsController::OnPurchaseCompleted(PurchaseModel obj)));
        if(val_20 != null)
        {
                if(null != null)
        {
            goto label_38;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_20;
        System.Delegate val_22 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WordGameEventsController::OnPurchaseFailure(PurchaseModel obj)));
        if(val_22 != null)
        {
                if(null != null)
        {
            goto label_38;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_22;
        System.Delegate val_24 = System.Delegate.Combine(a:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, b:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WordGameEventsController::OnProcessPurchase(ref PurchaseModel purchase)));
        if(val_24 != null)
        {
                if(null != null)
        {
            goto label_38;
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_24;
        return;
        label_38:
    }
    private void OnProcessPurchase(ref PurchaseModel purchase)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    private void OnPurchaseFailure(PurchaseModel obj)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    private void OnPurchaseCompleted(PurchaseModel obj)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public WGEventHandler GetGameSceneOrderedEventHandler(bool dailyChallengeState)
    {
        System.Collections.Generic.IEnumerable<TSource> val_16;
        var val_18;
        System.Func<WGEventHandler, System.Int32> val_20;
        System.Func<TSource, System.Boolean> val_21;
        var val_22;
        System.Func<WGEventHandler, System.DateTime> val_24;
        WordGameEventsController.<>c__DisplayClass21_0 val_1 = new WordGameEventsController.<>c__DisplayClass21_0();
        .dailyChallengeState = dailyChallengeState;
        val_16 = this.currentEventHandlers;
        if((System.Linq.Enumerable.FirstOrDefault<WGEventHandler>(source:  val_16, predicate:  new System.Func<WGEventHandler, System.Boolean>(object:  val_1, method:  System.Boolean WordGameEventsController.<>c__DisplayClass21_0::<GetGameSceneOrderedEventHandler>b__0(WGEventHandler x)))) != null)
        {
                return val_10;
        }
        
        val_18 = null;
        val_18 = null;
        val_20 = WordGameEventsController.<>c.<>9__21_1;
        if(val_20 == null)
        {
                System.Func<WGEventHandler, System.Int32> val_7 = null;
            val_20 = val_7;
            val_7 = new System.Func<WGEventHandler, System.Int32>(object:  WordGameEventsController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordGameEventsController.<>c::<GetGameSceneOrderedEventHandler>b__21_1(WGEventHandler x));
            WordGameEventsController.<>c.<>9__21_1 = val_20;
        }
        
        val_16 = System.Linq.Enumerable.OrderByDescending<WGEventHandler, System.Int32>(source:  this.currentEventHandlers, keySelector:  val_7);
        WGEventHandler val_10 = System.Linq.Enumerable.FirstOrDefault<WGEventHandler>(source:  val_16, predicate:  new System.Func<WGEventHandler, System.Boolean>(object:  val_1, method:  System.Boolean WordGameEventsController.<>c__DisplayClass21_0::<GetGameSceneOrderedEventHandler>b__2(WGEventHandler x)));
        if(val_10 != null)
        {
                return val_10;
        }
        
        System.Func<WGEventHandler, System.Boolean> val_12 = null;
        val_21 = val_12;
        val_12 = new System.Func<WGEventHandler, System.Boolean>(object:  val_1, method:  System.Boolean WordGameEventsController.<>c__DisplayClass21_0::<GetGameSceneOrderedEventHandler>b__3(WGEventHandler x));
        val_22 = null;
        val_22 = null;
        val_24 = WordGameEventsController.<>c.<>9__21_4;
        if(val_24 != null)
        {
                return System.Linq.Enumerable.FirstOrDefault<WGEventHandler>(source:  System.Linq.Enumerable.OrderBy<WGEventHandler, System.DateTime>(source:  System.Linq.Enumerable.Where<WGEventHandler>(source:  this.currentEventHandlers, predicate:  val_12), keySelector:  System.Func<WGEventHandler, System.DateTime> val_14 = null));
        }
        
        val_24 = val_14;
        val_14 = new System.Func<WGEventHandler, System.DateTime>(object:  WordGameEventsController.<>c.__il2cppRuntimeField_static_fields, method:  System.DateTime WordGameEventsController.<>c::<GetGameSceneOrderedEventHandler>b__21_4(WGEventHandler x));
        WordGameEventsController.<>c.<>9__21_4 = val_24;
        return System.Linq.Enumerable.FirstOrDefault<WGEventHandler>(source:  System.Linq.Enumerable.OrderBy<WGEventHandler, System.DateTime>(source:  System.Linq.Enumerable.Where<WGEventHandler>(source:  this.currentEventHandlers, predicate:  val_12), keySelector:  val_14));
    }
    public WGEventHandler GetOrderedEventHandlersByIndex(int index)
    {
        var val_3;
        bool val_3 = true;
        if(this.GetOrderedEventHandlers() == null)
        {
                return (WGEventHandler)val_3;
        }
        
        System.Collections.Generic.List<WGEventHandler> val_2 = this.GetOrderedEventHandlers();
        if(val_3 > index)
        {
                if(val_3 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3 = val_3 + (index << 3);
            val_3 = mem[(true + (index) << 3) + 32];
            val_3 = (true + (index) << 3) + 32;
            return (WGEventHandler)val_3;
        }
        
        val_3 = 0;
        return (WGEventHandler)val_3;
    }
    public System.Collections.Generic.List<WGEventHandler> GetOrderedEventHandlers()
    {
        var val_8;
        System.Func<WGEventHandler, System.Boolean> val_10;
        var val_12;
        System.Func<WGEventHandler, System.Int32> val_14;
        var val_15;
        System.Func<WGEventHandler, System.DateTime> val_17;
        val_8 = null;
        val_8 = null;
        val_10 = WordGameEventsController.<>c.<>9__23_0;
        if(val_10 == null)
        {
                System.Func<WGEventHandler, System.Boolean> val_2 = null;
            val_10 = val_2;
            val_2 = new System.Func<WGEventHandler, System.Boolean>(object:  WordGameEventsController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordGameEventsController.<>c::<GetOrderedEventHandlers>b__23_0(WGEventHandler x));
            WordGameEventsController.<>c.<>9__23_0 = val_10;
        }
        
        val_12 = null;
        val_12 = null;
        val_14 = WordGameEventsController.<>c.<>9__23_1;
        if(val_14 == null)
        {
                System.Func<WGEventHandler, System.Int32> val_4 = null;
            val_14 = val_4;
            val_4 = new System.Func<WGEventHandler, System.Int32>(object:  WordGameEventsController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordGameEventsController.<>c::<GetOrderedEventHandlers>b__23_1(WGEventHandler x));
            WordGameEventsController.<>c.<>9__23_1 = val_14;
        }
        
        val_15 = null;
        val_15 = null;
        val_17 = WordGameEventsController.<>c.<>9__23_2;
        if(val_17 != null)
        {
                return System.Linq.Enumerable.ToList<WGEventHandler>(source:  System.Linq.Enumerable.ThenBy<WGEventHandler, System.DateTime>(source:  System.Linq.Enumerable.OrderByDescending<WGEventHandler, System.Int32>(source:  System.Linq.Enumerable.Where<WGEventHandler>(source:  this.currentEventHandlers, predicate:  val_2), keySelector:  val_4), keySelector:  System.Func<WGEventHandler, System.DateTime> val_6 = null));
        }
        
        val_17 = val_6;
        val_6 = new System.Func<WGEventHandler, System.DateTime>(object:  WordGameEventsController.<>c.__il2cppRuntimeField_static_fields, method:  System.DateTime WordGameEventsController.<>c::<GetOrderedEventHandlers>b__23_2(WGEventHandler x));
        WordGameEventsController.<>c.<>9__23_2 = val_17;
        return System.Linq.Enumerable.ToList<WGEventHandler>(source:  System.Linq.Enumerable.ThenBy<WGEventHandler, System.DateTime>(source:  System.Linq.Enumerable.OrderByDescending<WGEventHandler, System.Int32>(source:  System.Linq.Enumerable.Where<WGEventHandler>(source:  this.currentEventHandlers, predicate:  val_2), keySelector:  val_4), keySelector:  val_6));
    }
    public bool IsEventButtonPositionOccupied()
    {
        var val_5;
        var val_6;
        if(LightningWordsHandler.DEFAULT_REWARD_VALUE != 0)
        {
                val_5 = LightningWordsHandler.DEFAULT_REWARD_VALUE.IsLightningWordPeriod();
        }
        else
        {
                val_5 = 0;
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField) != null)
        {
                val_6 = LightningLevelsEventHandler.<Instance>k__BackingField.IsLightningPeriod();
            return (bool)val_6 & val_5;
        }
        
        val_6 = 0;
        return (bool)val_6 & val_5;
    }
    public static void InjectEventsTrackingData(System.Collections.Generic.Dictionary<string, object> data, bool onlyTrackEnabledEvents = False)
    {
        string val_4;
        bool val_5;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_21;
        var val_22;
        var val_23;
        ProxyEventTrackingDelegate val_24;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_18 = data;
        System.Collections.Generic.Dictionary<System.String, System.Type> val_1 = WordGameEventsController.TypeLookup;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<System.String, System.Type>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_2 = val_1.Keys;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = val_2.GetEnumerator();
        label_30:
        if(val_5.MoveNext() == false)
        {
            goto label_5;
        }
        
        WordGameEventsController.<>c__DisplayClass25_0 val_7 = new WordGameEventsController.<>c__DisplayClass25_0();
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        .eventTypeName = val_4;
        string val_8 = WGEventHandler.UnFuckTrackingName(eventName:  val_4);
        string val_9 = System.String.Format(format:  "EA {0}", arg0:  val_8);
        val_21 = val_18;
        if(val_21 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_21.ContainsKey(key:  val_9)) == false)
        {
            goto label_8;
        }
        
        object[] val_11 = new object[1];
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11[0] = val_8;
        UnityEngine.Debug.LogErrorFormat(format:  "WordGameEventsController:InjectEventsTrackingData, property with name {0} alrady exist", args:  val_11);
        goto label_30;
        label_8:
        if((MonoSingleton<GameEventsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_12.eventList == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_12.eventList.Find(match:  new System.Predicate<GameEventV2>(object:  val_7, method:  System.Boolean WordGameEventsController.<>c__DisplayClass25_0::<InjectEventsTrackingData>b__0(GameEventV2 x)))) == null)
        {
            goto label_20;
        }
        
        if((MonoSingleton<GameEventsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_15.eventList == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_15.eventList.Find(match:  new System.Predicate<GameEventV2>(object:  val_7, method:  System.Boolean WordGameEventsController.<>c__DisplayClass25_0::<InjectEventsTrackingData>b__1(GameEventV2 x)))) == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_20 = val_17.<inExpireInterval>k__BackingField;
        val_20 = val_20 ^ 1;
        val_5 = val_20;
        if(val_18 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_18.Add(key:  val_9, value:  val_5);
        goto label_30;
        label_20:
        if(onlyTrackEnabledEvents == true)
        {
            goto label_30;
        }
        
        val_5 = false;
        val_18.Add(key:  val_9, value:  null);
        goto label_30;
        label_5:
        val_22 = public System.Void Dictionary.KeyCollection.Enumerator<System.String, System.Type>::Dispose();
        val_5.Dispose();
        val_23 = null;
        val_23 = null;
        val_24 = WordGameEventsController.AddTrackingEventData;
        if(val_24 == null)
        {
                return;
        }
        
        val_24 = WordGameEventsController.AddTrackingEventData;
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        object val_19 = val_24.Invoke(trackingData: ref  val_18);
    }
    public static string GameEventActiveForTracking()
    {
        var val_8;
        string val_9;
        val_8 = null;
        val_8 = null;
        if((MonoSingleton<T>.searchedFailed) == 0)
        {
                val_9 = "None";
            return val_9;
        }
        
        List.Enumerator<T> val_4 = MonoSingleton<WordGameEventsController>.Instance.currentEventHandlers.GetEnumerator();
        label_14:
        val_9 = "";
        label_13:
        if(0.MoveNext() == false)
        {
            goto label_11;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((0 & 1) != 0)
        {
            goto label_13;
        }
        
        string val_7 = val_9 + 0.EventType;
        goto label_14;
        label_11:
        0.Dispose();
        return val_9;
    }
    public int get_GetCurrentEventsCount()
    {
        var val_4;
        System.Func<WGEventHandler, System.Boolean> val_6;
        val_4 = null;
        val_4 = null;
        val_6 = WordGameEventsController.<>c.<>9__28_0;
        if(val_6 != null)
        {
                return System.Linq.Enumerable.Count<WGEventHandler>(source:  System.Linq.Enumerable.Where<WGEventHandler>(source:  this.currentEventHandlers, predicate:  System.Func<WGEventHandler, System.Boolean> val_2 = null));
        }
        
        val_6 = val_2;
        val_2 = new System.Func<WGEventHandler, System.Boolean>(object:  WordGameEventsController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordGameEventsController.<>c::<get_GetCurrentEventsCount>b__28_0(WGEventHandler x));
        WordGameEventsController.<>c.<>9__28_0 = val_6;
        return System.Linq.Enumerable.Count<WGEventHandler>(source:  System.Linq.Enumerable.Where<WGEventHandler>(source:  this.currentEventHandlers, predicate:  val_2));
    }
    private System.Collections.Generic.List<WGEventHandler> get_currentEventHandlers()
    {
        System.Collections.Generic.List<WGEventHandler> val_2;
        if(this.QAHACK_SingleEventKeyIndex != 1)
        {
                System.Collections.Generic.List<WGEventHandler> val_1 = null;
            var val_2 = 1152921516343750880;
            val_2 = val_1;
            val_1 = new System.Collections.Generic.List<WGEventHandler>();
            if(val_2 <= this.QAHACK_SingleEventKeyIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2 = val_2 + ((this.QAHACK_SingleEventKeyIndex) << 3);
            val_1.Add(item:  (1152921516343750880 + (this.QAHACK_SingleEventKeyIndex) << 3) + 32);
            return val_2;
        }
        
        val_2 = this._currentEventHandlers;
        return val_2;
    }
    private WGEventHandler getHandlerForEvent(string eventName)
    {
        .eventName = eventName;
        return this.currentEventHandlers.Find(match:  new System.Predicate<WGEventHandler>(object:  new WordGameEventsController.<>c__DisplayClass32_0(), method:  System.Boolean WordGameEventsController.<>c__DisplayClass32_0::<getHandlerForEvent>b__0(WGEventHandler x)));
    }
    public WGEventHandler ForceInitNewHandlerForEvent(GameEventV2 eventV2)
    {
        var val_8;
        if((WordGameEventsController.TypeLookup.ContainsKey(key:  eventV2.type)) != false)
        {
                System.Type val_4 = WordGameEventsController.TypeLookup.Item[eventV2.type];
            val_8 = System.Activator.CreateInstance(type:  val_4);
            System.Type val_6 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            if((val_4 & 1) != 0)
        {
                return (WGEventHandler)val_8;
        }
        
        }
        
        val_8 = 0;
        return (WGEventHandler)val_8;
    }
    private void OnGameEventDataReceived()
    {
        GameEventV2 val_6;
        var val_7;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        WordGameEventsController.InjectEventsTrackingData(data:  new System.Collections.Generic.Dictionary<System.String, System.Object>(), onlyTrackEnabledEvents:  false);
        GameEventsManager val_4 = MonoSingleton<GameEventsManager>.Instance;
        List.Enumerator<T> val_5 = val_4.eventList.GetEnumerator();
        label_17:
        if(val_7.MoveNext() == false)
        {
            goto label_13;
        }
        
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((this.getHandlerForEvent(eventName:  val_6 + 72)) == null)
        {
            goto label_15;
        }
        
        goto label_17;
        label_15:
        this.CreateAndInitHandlerForEvent(eventV2:  val_6);
        goto label_17;
        label_13:
        val_7.Dispose();
        this.RemoveExpiredHandlers();
        if(this.AddProxyEventHandlers != null)
        {
                object val_11 = this.AddProxyEventHandlers.Invoke(existingEventHandlers: ref  this._currentEventHandlers);
        }
        
        if(this.RemoveExpiredProxyEventHandlers != null)
        {
                object val_13 = this.RemoveExpiredProxyEventHandlers.Invoke(existingEventHandlers: ref  this._currentEventHandlers);
        }
        
        System.Collections.Generic.List<WGEventHandler> val_14 = this.currentEventHandlers;
        if(1152921516262972032 < 1)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnGameEventControllerUpdate");
    }
    private void OnGameEventDataPutResponse()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        GameEventsManager val_3 = MonoSingleton<GameEventsManager>.Instance;
        List.Enumerator<T> val_4 = val_3.eventList.GetEnumerator();
        label_14:
        if(0.MoveNext() == false)
        {
            goto label_11;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((this.getHandlerForEvent(eventName:  0)) == null)
        {
            goto label_14;
        }
        
        goto label_14;
        label_11:
        0.Dispose();
    }
    private void OnMyProfileUpdate()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        GameEventsManager val_3 = MonoSingleton<GameEventsManager>.Instance;
        List.Enumerator<T> val_4 = val_3.eventList.GetEnumerator();
        label_14:
        if(0.MoveNext() == false)
        {
            goto label_11;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((this.getHandlerForEvent(eventName:  0)) == null)
        {
            goto label_14;
        }
        
        goto label_14;
        label_11:
        0.Dispose();
    }
    private void CreateAndInitHandlerForEvent(GameEventV2 eventV2)
    {
        int val_13;
        var val_14;
        string val_15;
        string val_16;
        if((WordGameEventsController.TypeLookup.ContainsKey(key:  eventV2.type)) == false)
        {
            goto label_5;
        }
        
        GameBehavior val_3 = App.getBehavior;
        val_13 = eventV2.minPlayerLevel;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_3.<metaGameBehavior>k__BackingField, knobValue:  val_13)) == false)
        {
            goto label_12;
        }
        
        System.Type val_6 = WordGameEventsController.TypeLookup.Item[eventV2.type];
        object val_7 = System.Activator.CreateInstance(type:  val_6);
        System.Type val_8 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if((val_6 & 1) == 0)
        {
            goto label_19;
        }
        
        if((val_7 & 1) == 0)
        {
            goto label_37;
        }
        
        this._currentEventHandlers.Add(item:  val_7);
        val_14 = null;
        val_14 = null;
        if(val_7 == LeaderboardEventHandler.instance)
        {
            goto label_31;
        }
        
        return;
        label_5:
        val_15 = eventV2.type;
        val_16 = "no type declared for event of ";
        goto label_37;
        label_12:
        val_15 = eventV2.type;
        val_16 = "player level not met for event: ";
        label_37:
        UnityEngine.Debug.LogWarning(message:  val_16 + val_15);
        return;
        label_19:
        UnityEngine.Debug.LogError(message:  "We don\'t a type for event of " + eventV2.type);
        return;
        label_31:
        UnityEngine.Coroutine val_12 = this.StartCoroutine(routine:  this.UpdateLeaderboardData(seconds:  30));
    }
    private void RemoveExpiredHandlers()
    {
        int val_6;
        System.Collections.Generic.List<WGEventHandler> val_7;
        System.Collections.Generic.List<WGEventHandler> val_1 = new System.Collections.Generic.List<WGEventHandler>();
        .<>4__this = this;
        .i = 0;
        label_23:
        if(0 >= this._currentEventHandlers)
        {
            goto label_3;
        }
        
        var val_6 = 1152921516063721856;
        GameEventsManager val_3 = MonoSingleton<GameEventsManager>.Instance;
        val_6 = (WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i;
        if(val_6 <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (((WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i) << 3);
        var val_7 = (1152921516063721856 + ((WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i) << 3) + 32;
        if((val_3.eventList.Exists(match:  new System.Predicate<GameEventV2>(object:  new WordGameEventsController.<>c__DisplayClass43_0(), method:  System.Boolean WordGameEventsController.<>c__DisplayClass43_0::<RemoveExpiredHandlers>b__0(GameEventV2 x)))) == false)
        {
            goto label_11;
        }
        
        val_7 = this._currentEventHandlers;
        val_6 = (WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i;
        if(val_7 <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + (((WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i) << 3);
        if((((1152921516063721856 + ((WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i) << 3) + 32) & 1) == 0)
        {
            goto label_14;
        }
        
        val_1.Add(item:  ((1152921516063721856 + ((WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i) << 3) + 32 + ((WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i) << 3) + 32);
        goto label_16;
        label_11:
        val_7 = (WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i;
        if(val_7 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + (((WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i) << 3);
        goto label_20;
        label_14:
        label_20:
        this._currentEventHandlers.set_Item(index:  (WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i, value:  0);
        label_16:
        int val_8 = (WordGameEventsController.<>c__DisplayClass43_0)[1152921516390493552].i;
        val_8 = val_8 + 1;
        .i = val_8;
        if(this._currentEventHandlers != null)
        {
            goto label_23;
        }
        
        throw new NullReferenceException();
        label_3:
        this._currentEventHandlers = val_1;
    }
    private System.Collections.IEnumerator UpdateLeaderboardData(int seconds = 30)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .seconds = seconds;
        return (System.Collections.IEnumerator)new WordGameEventsController.<UpdateLeaderboardData>d__44();
    }
    public string get_QAHACK_CurrentSingleEventTypeKey()
    {
        bool val_1 = true;
        if(this.QAHACK_SingleEventKeyIndex == 1)
        {
                return "ALL EVENTS";
        }
        
        if(val_1 <= this.QAHACK_SingleEventKeyIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + ((this.QAHACK_SingleEventKeyIndex) << 3);
        return (true + (this.QAHACK_SingleEventKeyIndex) << 3) + 32.EventType;
    }
    public void QAHACK_ToggleSingleEvent()
    {
        float val_2 = UnityEngine.Mathf.Repeat(t:  (float)this.QAHACK_SingleEventKeyIndex + 1, length:  4.196762E+07f);
        val_2 = (val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
        this.QAHACK_SingleEventKeyIndex = (int)val_2;
        if(this._currentEventHandlers == (int)val_2)
        {
                this.QAHACK_SingleEventKeyIndex = 0;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnGameEventControllerUpdate");
    }
    public System.Collections.Generic.List<WGEventHandler> QAHACK_GetAllEventHandlers()
    {
        return this.currentEventHandlers;
    }
    public void HackAddLevels(int levelsHacked)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public string DebugGetLevel()
    {
        var val_6;
        var val_7;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_5;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
            goto label_6;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_9:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_9;
        }
        
        val_6 = 0;
        0.Dispose();
        return (string)val_7;
        label_5:
        val_7 = "not supported for this game";
        return (string)val_7;
        label_6:
        val_7 = "too much of a wee baby to do events";
        return (string)val_7;
        label_8:
        0.Dispose();
        val_7 = "no current event!";
        return (string)val_7;
    }
    public void OnGameSceneBegan()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        List.Enumerator<T> val_5 = this.currentEventHandlers.GetEnumerator();
        label_16:
        if(0.MoveNext() == false)
        {
            goto label_13;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_16;
        }
        
        goto label_16;
        label_13:
        0.Dispose();
    }
    public void OnBeforeLevelComplete(int levelsProgressed = 1)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnLevelComplete(int levelsProgressed = 1)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnForestComplete(int levelsProgressed = 1)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnNewForestShown()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnForestUpdated()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnMysteryChestCollected()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnCategoryComplete()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnEventCategorySelected(TRVCategorySelectionInfo category)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((0 & 1) != 0)
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public System.Collections.Generic.List<TRVCategorySelectionInfo> GetEventsRegisteredCategories(System.Collections.Generic.List<TRVCategorySelectionInfo> categories)
    {
        var val_6;
        GameBehavior val_1 = App.getBehavior;
        if((((val_1.<metaGameBehavior>k__BackingField) & 1) == 0) || ((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false))
        {
            goto label_6;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        val_6 = categories;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_10;
        }
        
        goto label_11;
        label_6:
        val_6 = categories;
        return (System.Collections.Generic.List<TRVCategorySelectionInfo>)val_6;
        label_8:
        0.Dispose();
        return (System.Collections.Generic.List<TRVCategorySelectionInfo>)val_6;
    }
    public void OnLevelCompletedRewarded()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnLevelCompleteRewardAnimFinished()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnDailyChallengeLevelComplete()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        List.Enumerator<T> val_3 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_7;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_10;
        }
        
        goto label_10;
        label_7:
        0.Dispose();
    }
    public void OnDailyChallengeRewardGranted()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        List.Enumerator<T> val_3 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_7;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_10;
        }
        
        goto label_10;
        label_7:
        0.Dispose();
    }
    public void OnBonusGameGoldCurrencyRewardGranted()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        List.Enumerator<T> val_3 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_7;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_10;
        }
        
        goto label_10;
        label_7:
        0.Dispose();
    }
    public void OnAppleAwarded(int appleAwarded)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) == 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnMenuLoaded()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        this.isWordRegionLoaded = false;
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnWordRegionLoaded()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        this.isWordRegionLoaded = true;
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) != 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void OnGameSceneInit()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnDailyChallengeInit()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnWindowStateChanged(bool anyActiveWindows)
    {
        bool val_7 = anyActiveWindows;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        val_7 = val_7;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public bool ActivelyPlayingEventGameMode()
    {
        var val_6;
        var val_7;
        var val_8;
        val_6 = this;
        GameBehavior val_1 = App.getBehavior;
        if((((val_1.<metaGameBehavior>k__BackingField) & 1) == 0) || ((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false))
        {
            goto label_6;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_9;
        }
        
        val_6 = 0;
        goto label_10;
        label_8:
        val_7 = 0;
        val_6 = 0;
        goto label_11;
        label_9:
        val_6 = 0;
        label_10:
        val_7 = 1;
        label_11:
        0.Dispose();
        val_8 = val_7 & val_6;
        return (bool)val_8;
        label_6:
        val_8 = 0;
        return (bool)val_8;
    }
    public void OnVideoResponse(Notification notif)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_6 = this.currentEventHandlers.GetEnumerator();
        this = System.Boolean.Parse(value:  notif.data.ToString());
        label_15:
        if(0.MoveNext() == false)
        {
            goto label_13;
        }
        
        if(0 == 0)
        {
            goto label_15;
        }
        
        goto label_15;
        label_13:
        0.Dispose();
    }
    public void OnEventHandlerProgress()
    {
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnGameEventHandlerProgress");
    }
    public void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> curData)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void AppendDailyChallengeCompleteData(ref System.Collections.Generic.Dictionary<string, object> curData)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) == 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public void AppendLeaguesRolloverData(ref System.Collections.Generic.Dictionary<string, object> curData)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void ResetDCProgress()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) == 0))
        {
            goto label_11;
        }
        
        goto label_11;
        label_8:
        0.Dispose();
    }
    public bool TryShowFtux()
    {
        var val_6;
        GameBehavior val_1 = App.getBehavior;
        if((((val_1.<metaGameBehavior>k__BackingField) & 1) == 0) || ((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false))
        {
            goto label_6;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 1) == 0))
        {
            goto label_10;
        }
        
        val_6 = 1;
        goto label_11;
        label_6:
        val_6 = 0;
        return (bool)val_6;
        label_8:
        val_6 = 0;
        label_11:
        0.Dispose();
        return (bool)val_6;
    }
    public void OnSubmitWordWithHints(string word)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnHintIncompleteWord(string word, Cell hintedCell)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnHintForceEventLineWord(System.Collections.Generic.List<LineWord> lines, ref LineWord word, bool isPickerHint)
    {
        bool val_7 = isPickerHint;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        val_7 = val_7;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public GameLevel checkEventForGameLevel(GameLevel refLevel)
    {
        var val_6;
        var val_7;
        val_6 = refLevel;
        GameBehavior val_1 = App.getBehavior;
        if((((val_1.<metaGameBehavior>k__BackingField) & 1) == 0) || ((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false))
        {
            goto label_6;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        val_7 = 0;
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_11;
        label_8:
        val_7 = 0;
        label_11:
        0.Dispose();
        return (GameLevel)val_7;
        label_6:
        val_7 = 0;
        return (GameLevel)val_7;
    }
    public void OnPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        bool val_5 = hintUsage;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnValidWordSubmitted(string word, bool extra)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        if(extra == true)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_9;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_11;
        label_9:
        0.Dispose();
    }
    public void OnInvalidWordSubmitted()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void BreakWordStreak()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnFacebookPluginUpdate()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnAnyHintUsed(bool wasFree)
    {
        bool val_7 = wasFree;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        val_7 = val_7;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public WGWindow OnTRVQuestionStart(TRVQuizProgress progress)
    {
        var val_7;
        var val_8;
        UnityEngine.Object val_9;
        val_8 = progress;
        GameBehavior val_1 = App.getBehavior;
        if((((val_1.<metaGameBehavior>k__BackingField) & 1) == 0) || ((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false))
        {
            goto label_6;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        val_7 = 1152921516343765216;
        label_12:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_9 = 0;
        if(val_9 == 0)
        {
            goto label_12;
        }
        
        goto label_13;
        label_8:
        val_9 = 0;
        label_13:
        0.Dispose();
        return (WGWindow)val_9;
        label_6:
        val_9 = 0;
        return (WGWindow)val_9;
    }
    public System.Collections.Generic.List<int> GetMovingItemsIndices()
    {
        var val_7;
        MetaGameBehavior val_8;
        System.Collections.Generic.List<System.Int32> val_1 = null;
        val_7 = public System.Void System.Collections.Generic.List<System.Int32>::.ctor();
        val_1 = new System.Collections.Generic.List<System.Int32>();
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_8 = val_2.<metaGameBehavior>k__BackingField;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_8 & 1) == 0)
        {
                return val_1;
        }
        
        if(val_8.eventsDisplayable == false)
        {
                return val_1;
        }
        
        System.Collections.Generic.List<WGEventHandler> val_4 = this.currentEventHandlers;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_5 = val_4.GetEnumerator();
        label_12:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if((0 == 0) || ((0 & 2147483648) != 0))
        {
            goto label_12;
        }
        
        val_1.Add(item:  0);
        goto label_12;
        label_8:
        0.Dispose();
        return val_1;
    }
    public TRVQuizProgress GetEventQuiz(TRVSubCategoryData data)
    {
        var val_6;
        var val_7;
        val_6 = data;
        GameBehavior val_1 = App.getBehavior;
        if((((val_1.<metaGameBehavior>k__BackingField) & 1) == 0) || ((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false))
        {
            goto label_6;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        val_7 = 0;
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_11;
        label_8:
        val_7 = 0;
        label_11:
        0.Dispose();
        return (TRVQuizProgress)val_7;
        label_6:
        val_7 = 0;
        return (TRVQuizProgress)val_7;
    }
    public void InjectGemSpentTrackingInfo(ref System.Collections.Generic.Dictionary<string, object> trackingData)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void AppendAmplitudeUserProperties(ref System.Collections.Generic.Dictionary<string, object> globals)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnSpinStarted()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnSpinEnded()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnReelStopped(Notification notif)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnAllReelsStopped()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnSpinAmountUpdate()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public void OnSpinBetUpdate()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.eventsDisplayable) == false)
        {
                return;
        }
        
        List.Enumerator<T> val_4 = this.currentEventHandlers.GetEnumerator();
        this = 1152921516343765216;
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(0 == 0)
        {
            goto label_10;
        }
        
        goto label_10;
        label_8:
        0.Dispose();
    }
    public WordGameEventsController()
    {
        this._currentEventHandlers = new System.Collections.Generic.List<WGEventHandler>();
        this.QAHACK_SingleEventKeyIndex = 0;
    }
    private static WordGameEventsController()
    {
        System.Collections.Generic.Dictionary<System.String, System.Type> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Type>();
        val_1.Add(key:  "WildWordWeekend", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "LevelChallenge", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "ExtraChapterRewards", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "PuzzleCollection", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "CrownClashCvC", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "Leaderboard", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "CrownClashPvP", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "VipParty", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "PiggyBank", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "PiggyBankV2", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "GoldenGala", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "LightningWords", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "WordHunt", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "SuperStreak", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "HotStreak", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "LightningLevels", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "HintMania", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "OnTheTrail", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "TriviaMasters", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "BigQuiz", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "StarChampionship", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "CrazyCategories", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_1}));
        val_1.Add(key:  "TriviaPursuit", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "KeyToRiches", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "WordBingo", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "BuyAVowel", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "SnakesAndLadders", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "SuperBundle", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "PiggyBankRaid", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "SeasonPass", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "SpecialCategories", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "YouBetcha", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "AttackMadness", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "RaidMadness", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "HotNSpicy", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "RestaurantMaster", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "SpinKing", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "IslandParadiseSymbol", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "ForestMaster", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "LetterBank", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "ForestFrenzy", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "ProgressiveIapSale", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "FOMO pack", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        WordGameEventsController.DefaultTypeLookup = val_1;
        WordGameEventsController.compiledTypeLookup = 0;
    }

}
