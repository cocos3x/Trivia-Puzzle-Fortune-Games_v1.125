using UnityEngine;
public class EventButtonPanel : MonoBehaviour
{
    // Fields
    private const int MAX_EVENT_DISPLAY = 2;
    private const string BUTTON_ORDER_PREFKEY = "evtpnl_btn_order";
    protected EventButtonPanel.LayoutType layout;
    protected EventButtonPanel.DisplayContext displayContext;
    protected UnityEngine.CanvasGroup rootCanvasGroup;
    protected UnityEngine.GameObject rootContainer;
    protected System.Collections.Generic.List<UnityEngine.Transform> slot;
    protected bool dontAnimateIntro;
    protected float onEnableDelay;
    protected System.Collections.Generic.List<string> btnPlacementOrder;
    protected System.Collections.Generic.List<WGEventButtonV2> btnList;
    private bool isInitialized;
    private DG.Tweening.Tween panelOuttroTween;
    
    // Properties
    public System.Collections.Generic.List<WGEventButtonV2> ButtonList { get; }
    public UnityEngine.CanvasGroup RootCanvasGroup { get; }
    
    // Methods
    public System.Collections.Generic.List<WGEventButtonV2> get_ButtonList()
    {
        return (System.Collections.Generic.List<WGEventButtonV2>)this.btnList;
    }
    public UnityEngine.CanvasGroup get_RootCanvasGroup()
    {
        return (UnityEngine.CanvasGroup)this.rootCanvasGroup;
    }
    protected void Awake()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "evtpnl_btn_order", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_1)) != false)
        {
                if(this.btnPlacementOrder != null)
        {
                return;
        }
        
        }
        else
        {
                System.Collections.Generic.List<System.String> val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  val_1);
            this.btnPlacementOrder = val_3;
            if(val_3 != null)
        {
                return;
        }
        
        }
        
        this.btnPlacementOrder = new System.Collections.Generic.List<System.String>();
    }
    protected void Start()
    {
        System.Action val_10;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventControllerUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventHandlerProgress");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventDataReceived");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  1.ToString());
        val_10 = 1152921504879157248;
        if(WordRegion.instance != 0)
        {
                System.Action val_9 = null;
            val_10 = val_9;
            val_9 = new System.Action(object:  this, method:  System.Void EventButtonPanel::UpdateDisplay());
            WordRegion.instance.addOnLevelLoadCompleteAction(callback:  val_9);
        }
        
        this.UpdateDisplay();
    }
    protected void OnDestroy()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnGameEventControllerUpdate");
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnGameEventHandlerProgress");
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnGameEventDataReceived");
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  1.ToString());
        if(this.panelOuttroTween == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.panelOuttroTween, complete:  false);
    }
    protected void OnEnable()
    {
        this.UpdateDisplay();
    }
    protected void OnGameEventDataReceived()
    {
        this.UpdateDisplay();
    }
    protected void OnGameEventControllerUpdate()
    {
        this.UpdateDisplay();
    }
    protected void OnGameEventHandlerProgress()
    {
        this.UpdateDisplay();
    }
    protected void OnMyProfileUpdate()
    {
        this.UpdateDisplay();
    }
    public WGEventButtonV2 GetEventButton(string eventId)
    {
        .eventId = eventId;
        return this.btnList.Find(match:  new System.Predicate<WGEventButtonV2>(object:  new EventButtonPanel.<>c__DisplayClass27_0(), method:  System.Boolean EventButtonPanel.<>c__DisplayClass27_0::<GetEventButton>b__0(WGEventButtonV2 n)));
    }
    public WGEventButtonV2 GetEventButton(int slotIndex)
    {
        var val_1;
        bool val_1 = true;
        if(((slotIndex & 2147483648) == 0) && (val_1 > slotIndex))
        {
                if(val_1 <= slotIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_1 = val_1 + (slotIndex << 3);
            val_1 = mem[(true + (slotIndex) << 3) + 32];
            val_1 = (true + (slotIndex) << 3) + 32;
            return (WGEventButtonV2)val_1;
        }
        
        val_1 = 0;
        return (WGEventButtonV2)val_1;
    }
    protected string GetEventIdForSlotIndex(int slotIndex)
    {
        var val_1;
        bool val_1 = true;
        if((slotIndex & 2147483648) == 0)
        {
                if(0 >= slotIndex)
        {
            goto label_3;
        }
        
        }
        
        val_1 = 0;
        return (string)val_1;
        label_3:
        if(val_1 <= slotIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + (slotIndex << 3);
        val_1 = mem[(true + (slotIndex) << 3) + 32];
        val_1 = (true + (slotIndex) << 3) + 32;
        return (string)val_1;
    }
    protected void SetEventIdForSlotIndex(int slotIndex, string eventId)
    {
        string val_1;
        if(41967616 > slotIndex)
        {
                this.btnPlacementOrder.set_Item(index:  slotIndex, value:  eventId);
            return;
        }
        
        do
        {
            if(slotIndex == 41967616)
        {
                val_1 = eventId;
        }
        else
        {
                val_1 = 0;
        }
        
            this.btnPlacementOrder.Add(item:  val_1);
            if(41967617 > slotIndex)
        {
                return;
        }
        
        }
        while(this.btnPlacementOrder != null);
        
        throw new NullReferenceException();
    }
    protected int GetEmptySlotIndex()
    {
        System.Collections.Generic.List<System.String> val_2;
        var val_3;
        var val_4;
        val_2 = this.btnPlacementOrder;
        if(true <= 1)
        {
                var val_3 = 1;
            if(val_3 >= 1)
        {
                var val_2 = 0;
            do
        {
            val_2.Add(item:  0);
            val_2 = this.btnPlacementOrder;
            val_2 = val_2 + 1;
            val_3 = 2 - val_3;
        }
        while(val_2 < val_3);
        
        }
        
        }
        
        val_3 = 0;
        label_10:
        val_4 = 0;
        if(val_3 > 1)
        {
                return (int)val_4;
        }
        
        if(val_3 >= val_3)
        {
                return (int)val_4;
        }
        
        val_3 = val_3 & 4294967295;
        if(val_3 >= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + 0;
        if((System.String.IsNullOrEmpty(value:  (((2 - 1) & 4294967295) + 0) + 32)) == true)
        {
            goto label_9;
        }
        
        val_3 = val_3 + 1;
        if(this.btnPlacementOrder != null)
        {
            goto label_10;
        }
        
        throw new NullReferenceException();
        label_9:
        val_4 = val_3;
        return (int)val_4;
    }
    protected bool IsSlotAvailable(int slotIndex)
    {
        if(slotIndex > 1)
        {
                return false;
        }
        
        return System.String.IsNullOrEmpty(value:  this.GetEventIdForSlotIndex(slotIndex:  slotIndex));
    }
    protected int GetSlotIndexForEvent(string eventId)
    {
        .eventId = eventId;
        return this.btnPlacementOrder.FindIndex(match:  new System.Predicate<System.String>(object:  new EventButtonPanel.<>c__DisplayClass33_0(), method:  System.Boolean EventButtonPanel.<>c__DisplayClass33_0::<GetSlotIndexForEvent>b__0(string n)));
    }
    protected WGEventButtonV2 GetPrefab(string eventId)
    {
        if(this.layout != 1)
        {
                return MonoSingleton<WordGameEventsController>.Instance.EventPrefabsConfig.GetEventButtonPrefab(eventId:  eventId);
        }
        
        return MonoSingleton<WordGameEventsController>.Instance.EventPrefabsConfig.GetEventProgressPrefab(eventId:  eventId);
    }
    protected void ResyncEventSlotStatus()
    {
        object val_14;
        var val_15;
        EventButtonPanel.<>c__DisplayClass35_0 val_3 = null;
        val_14 = val_3;
        val_3 = new EventButtonPanel.<>c__DisplayClass35_0();
        .<>4__this = this;
        .i = 0;
        val_15 = 1152921504614887424;
        label_11:
        if(0 >= null)
        {
            goto label_6;
        }
        
        if(null <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((System.String.IsNullOrEmpty(value:  EventButtonPanel.<>c__DisplayClass35_0.__il2cppRuntimeField_byval_arg)) != true)
        {
                if((MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlers().Find(match:  new System.Predicate<WGEventHandler>(object:  val_3, method:  System.Boolean EventButtonPanel.<>c__DisplayClass35_0::<ResyncEventSlotStatus>b__0(WGEventHandler n)))) == null)
        {
                this.SetEventIdForSlotIndex(slotIndex:  (EventButtonPanel.<>c__DisplayClass35_0)[1152921517494426240].i, eventId:  0);
        }
        
        }
        
        .i = ((EventButtonPanel.<>c__DisplayClass35_0)[1152921517494426240].i) + 1;
        if(this.btnPlacementOrder != null)
        {
            goto label_11;
        }
        
        label_6:
        if(null >= 1)
        {
                var val_14 = 0;
            do
        {
            if(null <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((this.GetSlotIndexForEvent(eventId:  EventButtonPanel.<>c__DisplayClass35_0.__il2cppRuntimeField_byval_arg.EventType)) == 1)
        {
                int val_10 = this.GetEmptySlotIndex();
            if((val_10 & 2147483648) == 0)
        {
                val_14 = val_10;
            val_15 = 0;
            if(1152921504972341248 <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.SetEventIdForSlotIndex(slotIndex:  val_14, eventId:  EventButtonPanel.<>c__DisplayClass35_0.__il2cppRuntimeField_byval_arg.EventType);
        }
        
        }
        
            val_14 = val_14 + 1;
        }
        while(val_14 < 1152921504972341248);
        
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "evtpnl_btn_order", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.btnPlacementOrder));
        bool val_13 = PrefsSerializationManager.SavePlayerPrefs();
    }
    protected void UpdateDisplay()
    {
        WGEventButtonV2 val_40;
        var val_41;
        object val_42;
        System.Predicate<T> val_43;
        var val_44;
        var val_45;
        UnityEngine.Object val_46;
        if((MonoSingleton<GameEventsManager>.Instance.isAvailable) == false)
        {
                return;
        }
        
        if(this.isInitialized != true)
        {
                this.isInitialized = true;
            if(this.onEnableDelay > 0f)
        {
                DG.Tweening.Tween val_4 = DG.Tweening.DOVirtual.DelayedCall(delay:  this.onEnableDelay, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void EventButtonPanel::UpdateDisplay()), ignoreTimeScale:  true);
            return;
        }
        
        }
        
        if(WordGameEventsController.EventsEnabled != true)
        {
                if(this.rootContainer.activeSelf == false)
        {
                return;
        }
        
        }
        
        val_40 = 0;
        this.rootContainer.gameObject.SetActive(value:  true);
        this.ResyncEventSlotStatus();
        System.Collections.Generic.List<WGEventHandler> val_9 = MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlers();
        System.Collections.Generic.List<WGEventButtonV2> val_40 = this.btnList;
        val_40 = val_40 - 1;
        if(>=0)
        {
                val_41 = 1152921504765632512;
            var val_10 = (long)val_40 + 4;
            do
        {
            EventButtonPanel.<>c__DisplayClass36_0 val_11 = null;
            val_42 = val_11;
            val_11 = new EventButtonPanel.<>c__DisplayClass36_0();
            var val_12 = val_10 - 4;
            if(val_12 >= (long)val_40)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_40 = 0;
            if(((long)(int)((this.btnList - 1)) + (((long)(int)((this.btnList - 1)) + 4)) << 3) != 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            .eventId = EventType;
            System.Predicate<System.String> val_15 = null;
            val_43 = val_15;
            val_15 = new System.Predicate<System.String>(object:  val_11, method:  System.Boolean EventButtonPanel.<>c__DisplayClass36_0::<UpdateDisplay>b__1(string n));
            val_40 = public System.String System.Collections.Generic.List<System.String>::Find(System.Predicate<T> match);
            if((System.String.IsNullOrEmpty(value:  this.btnPlacementOrder.Find(match:  val_15))) != false)
        {
                val_42 = this.btnList;
            if(val_12 >= 1152921516021162784)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_40 = 0;
            this.btnList.set_Item(index:  val_10 - 4, value:  val_40);
        }
        
        }
        
            val_44 = val_10 - 1;
        }
        while(val_44 >= 0);
        
        }
        
        if(1152921517494593856 < 1)
        {
            goto label_91;
        }
        
        val_44 = 1152921515401808240;
        val_43 = 1152921504765632512;
        val_41 = 0;
        val_45 = 0;
        label_92:
        if(1152921517494593856 <= val_41)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        int val_20 = this.GetSlotIndexForEvent(eventId:  EventType);
        if((val_20 & 2147483648) != 0)
        {
            goto label_88;
        }
        
        val_42 = val_20;
        if(val_20 >= this.slot)
        {
            goto label_88;
        }
        
        if(this.slot <= val_41)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(this.layout == 1)
        {
                if(this.layout <= val_41)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
            goto label_88;
        }
        
        }
        
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_46 = this.GetEventButton(eventId:  (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32.EventType);
        if(val_46 != 0)
        {
            goto label_81;
        }
        
        if(null <= val_41)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        WGEventButtonV2 val_29 = this.GetPrefab(eventId:  UnityEngine.Object.__il2cppRuntimeField_byval_arg.EventType);
        var val_41 = null;
        if(val_29 == 0)
        {
            goto label_88;
        }
        
        if(val_41 <= val_42)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_41 = val_41 + (val_42 << 3);
        val_31.slotIndex = val_42;
        val_46 = UnityEngine.Object.Instantiate<WGEventButtonV2>(original:  val_29, parent:  (null + (val_20) << 3) + 32);
        if(1152921517494644032 <= val_41)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        int val_32 = val_42 + 1;
        var val_42 = 0;
        this.btnList.Add(item:  0);
        val_42 = val_42 + 1;
        val_44 = 1152921515401808240;
        val_43 = val_43;
        if(this.btnList == null)
        {
                val_43 = val_43;
        }
        
        this.btnList.set_Item(index:  val_42, value:  val_46);
        val_45 = val_45;
        label_81:
        if(val_46 != 0)
        {
            goto label_84;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_42 = "Event Button for \'" + (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32((UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32) + "\' not instantiated for unexpected reasons";
        UnityEngine.Debug.Log(message:  val_42, context:  this);
        goto label_88;
        label_84:
        val_45 = val_45 + 1;
        if(val_45 > 1)
        {
            goto label_91;
        }
        
        label_88:
        val_41 = val_41 + 1;
        if(val_41 < null)
        {
            goto label_92;
        }
        
        label_91:
        if(WordGameEventsController.EventsEnabled == true)
        {
                return;
        }
        
        if(this.btnList >= 1)
        {
                this.panelOuttroTween = DG.Tweening.DOVirtual.DelayedCall(delay:  3f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void EventButtonPanel::<UpdateDisplay>b__36_0()), ignoreTimeScale:  true);
            return;
        }
        
        this.rootContainer.gameObject.SetActive(value:  false);
    }
    public EventButtonPanel()
    {
        this.btnPlacementOrder = new System.Collections.Generic.List<System.String>();
        this.btnList = new System.Collections.Generic.List<WGEventButtonV2>(capacity:  2);
    }
    private void <UpdateDisplay>b__36_0()
    {
        if(this.rootContainer == 0)
        {
                return;
        }
        
        this.rootContainer.gameObject.SetActive(value:  false);
    }

}
