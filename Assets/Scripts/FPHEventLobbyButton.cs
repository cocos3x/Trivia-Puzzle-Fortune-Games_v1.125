using UnityEngine;
public class FPHEventLobbyButton : MonoBehaviour
{
    // Fields
    public UGUINetworkedButton event_button;
    public UnityEngine.UI.Image button_prefix;
    public UnityEngine.UI.Text event_text;
    public UnityEngine.UI.Image event_icon;
    public UnityEngine.UI.Button LeftButton;
    public UnityEngine.UI.Button RightButton;
    public UnityEngine.GameObject eventsCointainer;
    public UnityEngine.UI.Text eventsCounter;
    public UnityEngine.UI.HorizontalLayoutGroup iconTextLayout;
    private bool categorySelectPopupEventBar;
    private UnityEngine.Sprite bigQuizIcon;
    public UnityEngine.Sprite pbMenuSprite;
    private UnityEngine.Sprite progressiveIAPIcon;
    private int CurrentEventIndex;
    private WGEventHandler currentEventHandler;
    private bool showingAllEventsButton;
    
    // Methods
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventControllerUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventHandlerProgress");
        NotificationCenter val_3 = NotificationCenter.DefaultCenter;
        val_3.AddObserver(observer:  this, name:  "OnLocalize");
        val_3.RemoveAllListeners();
        System.Delegate val_5 = System.Delegate.Combine(a:  this.event_button.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void FPHEventLobbyButton::OnClick(bool result)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        this.event_button.OnConnectionClick = val_5;
        if(this.LeftButton == 0)
        {
                return;
        }
        
        if(this.RightButton == 0)
        {
                return;
        }
        
        this.LeftButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHEventLobbyButton::PrevEvent()));
        this.RightButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHEventLobbyButton::NextEvent()));
        return;
        label_10:
    }
    private void PrevEvent()
    {
        float val_5 = UnityEngine.Mathf.Repeat(t:  (float)this.CurrentEventIndex - 1, length:  (float)(MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) + 1);
        val_5 = (val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5);
        this.CurrentEventIndex = (int)val_5;
        this.showingAllEventsButton = ((MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) == (int)val_5) ? 1 : 0;
        this.UpdateDisplay();
    }
    private void NextEvent()
    {
        float val_5 = UnityEngine.Mathf.Repeat(t:  (float)this.CurrentEventIndex + 1, length:  (float)(MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) + 1);
        val_5 = (val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5);
        this.CurrentEventIndex = (int)val_5;
        this.showingAllEventsButton = ((MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) == (int)val_5) ? 1 : 0;
        this.UpdateDisplay();
    }
    private void OnEnable()
    {
        this.UpdateDisplay();
    }
    private void OnClick(bool result)
    {
        UnityEngine.Object val_13;
        var val_14;
        var val_15;
        var val_16;
        System.Action val_18;
        val_13 = this;
        if(this.showingAllEventsButton == false)
        {
            goto label_1;
        }
        
        GameBehavior val_1 = App.getBehavior;
        val_15 = null;
        val_15 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 47;
        if(this.categorySelectPopupEventBar == false)
        {
                return;
        }
        
        label_36:
        val_14 = 1152921513412338272;
        val_13 = MonoSingleton<WGWindowManager>.Instance.GetWindow<TRVCategorySelection>();
        if(val_13 == 0)
        {
                return;
        }
        
        SLCWindow.CloseWindow(window:  MonoSingleton<WGWindowManager>.Instance.GetWindow<TRVCategorySelection>().gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_1:
        if(this.categorySelectPopupEventBar == false)
        {
            goto label_22;
        }
        
        if(((this.currentEventHandler == null) || ((this.currentEventHandler & 1) != 0)) || ((this.currentEventHandler & 1) != 0))
        {
            goto label_38;
        }
        
        bool val_9 = result;
        val_16 = null;
        val_16 = null;
        val_18 = FPHEventLobbyButton.<>c.<>9__20_0;
        if(val_18 == null)
        {
                System.Action val_10 = null;
            val_18 = val_10;
            val_10 = new System.Action(object:  FPHEventLobbyButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FPHEventLobbyButton.<>c::<OnClick>b__20_0());
            FPHEventLobbyButton.<>c.<>9__20_0 = val_18;
        }
        
        System.Delegate val_11 = System.Delegate.Combine(a:  this.currentEventHandler.OnMyPopupWasClosed_action, b:  val_10);
        if(val_11 != null)
        {
                if(null != null)
        {
            goto label_35;
        }
        
        }
        
        this.currentEventHandler.OnMyPopupWasClosed_action = val_11;
        goto label_36;
        label_22:
        if((this.currentEventHandler != null) && ((this.currentEventHandler & 1) == 0))
        {
                if((this.currentEventHandler & 1) == 0)
        {
            goto label_40;
        }
        
        }
        
        label_38:
        this.UpdateDisplay();
        return;
        label_40:
        bool val_12 = result;
        goto typeof(WGEventHandler).__il2cppRuntimeField_250;
        label_35:
    }
    private void OnGameEventControllerUpdate()
    {
        this.UpdateDisplay();
    }
    private void OnGameEventHandlerProgress()
    {
        this.UpdateDisplay();
    }
    private void OnLocalize()
    {
        this.UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        var val_44;
        WGEventHandler val_45;
        WGEventHandler val_46;
        UnityEngine.UI.Text val_47;
        if(this.categorySelectPopupEventBar != false)
        {
                val_44 = 1152921515458238320;
            if((this.gameObject.GetComponent<UnityEngine.CanvasGroup>()) != 0)
        {
                this.gameObject.GetComponent<UnityEngine.CanvasGroup>().alpha = 1f;
        }
        
        }
        
        if(WordGameEventsController.EventsEnabled == false)
        {
            goto label_10;
        }
        
        this.event_text.gameObject.SetActive(value:  true);
        val_44 = 1152921504893161472;
        if(((MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) >= 2) && (this.LeftButton != 0))
        {
                if(this.RightButton != 0)
        {
                this.LeftButton.gameObject.SetActive(value:  true);
            this.RightButton.gameObject.SetActive(value:  true);
        }
        
        }
        
        if(this.showingAllEventsButton == false)
        {
            goto label_27;
        }
        
        val_45 = this;
        val_46 = this.currentEventHandler;
        if(val_46 != null)
        {
            goto label_28;
        }
        
        label_27:
        WGEventHandler val_15 = MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlersByIndex(index:  this.CurrentEventIndex);
        this.currentEventHandler = val_15;
        if(val_15 == null)
        {
            goto label_33;
        }
        
        val_45 = this.currentEventHandler;
        label_28:
        if((val_15 != 0) && (this.showingAllEventsButton != true))
        {
                this.button_prefix.sprite = val_15;
            this.button_prefix.enabled = true;
            this.button_prefix.gameObject.SetActive(value:  true);
        }
        
        this.event_button.gameObject.SetActive(value:  true);
        if(this.eventsCointainer != 0)
        {
                this.eventsCointainer.SetActive(value:  true);
        }
        
        bool val_20 = UnityEngine.Object.op_Inequality(x:  this.eventsCounter, y:  0);
        if(this.showingAllEventsButton != false)
        {
                this.button_prefix.gameObject.SetActive(value:  false);
            string val_22 = Localization.Localize(key:  "view_all_events_upper", defaultValue:  "VIEW ALL EVENTS", useSingularKey:  false);
            this.event_text.resizeTextMaxSize = 65;
            this.iconTextLayout.childAlignment = 5;
            val_47 = this.event_text.rectTransform;
            UnityEngine.Vector2 val_24 = new UnityEngine.Vector2(x:  602f, y:  170f);
            val_47.sizeDelta = new UnityEngine.Vector2() {x = val_24.x, y = val_24.y};
            return;
        }
        
        UnityEngine.Vector3 val_26 = UnityEngine.Vector3.one;
        this.button_prefix.rectTransform.localScale = new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z};
        this.iconTextLayout.childAlignment = 4;
        UnityEngine.Vector2 val_28 = new UnityEngine.Vector2(x:  568f, y:  170f);
        this.event_text.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_28.x, y = val_28.y};
        this.iconTextLayout.spacing = 0f;
        UnityEngine.Color val_29 = UnityEngine.Color.white;
        this.button_prefix.color = new UnityEngine.Color() {r = val_29.r, g = val_29.g, b = val_29.b, a = val_29.a};
        string val_30 = mem[this.currentEventHandler].EventType;
        if((System.String.op_Equality(a:  val_30, b:  "BigQuiz")) == false)
        {
            goto label_71;
        }
        
        this.button_prefix.sprite = this.bigQuizIcon;
        this.event_text.resizeTextMaxSize = 65;
        this.button_prefix.gameObject.SetActive(value:  true);
        goto label_94;
        label_71:
        if((System.String.op_Equality(a:  val_30, b:  "PiggyBank")) == false)
        {
            goto label_78;
        }
        
        this.button_prefix.sprite = this.pbMenuSprite;
        this.event_text.resizeTextMaxSize = 56;
        this.button_prefix.gameObject.SetActive(value:  true);
        UnityEngine.Vector3 val_36 = new UnityEngine.Vector3(x:  0.8f, y:  0.8f, z:  0.8f);
        this.button_prefix.rectTransform.localScale = new UnityEngine.Vector3() {x = val_36.x, y = val_36.y, z = val_36.z};
        goto label_94;
        label_33:
        label_10:
        this.event_button.gameObject.SetActive(value:  false);
        if(this.categorySelectPopupEventBar != false)
        {
                if(this.gameObject != null)
        {
            goto label_91;
        }
        
        }
        
        label_91:
        this.eventsCointainer.SetActive(value:  false);
        return;
        label_78:
        if((System.String.op_Equality(a:  val_30, b:  "ProgressiveIapSale")) != false)
        {
                this.button_prefix.sprite = this.progressiveIAPIcon;
            UnityEngine.Color val_40 = new UnityEngine.Color(r:  0.1058824f, g:  0.9686275f, b:  0.8352941f);
            this.button_prefix.color = new UnityEngine.Color() {r = val_40.r, g = val_40.g, b = val_40.b, a = val_40.a};
            this.button_prefix.gameObject.SetActive(value:  true);
            this.event_text.fontSize = 56;
            this.event_text.resizeTextMaxSize = 56;
            this.button_prefix.preserveAspect = true;
            UnityEngine.Vector3 val_43 = new UnityEngine.Vector3(x:  1.3f, y:  1.3f, z:  1.3f);
            this.button_prefix.rectTransform.localScale = new UnityEngine.Vector3() {x = val_43.x, y = val_43.y, z = val_43.z};
            this.iconTextLayout.spacing = 0f;
            this.iconTextLayout.left = 30;
        }
        
        label_94:
        this.event_text.fontSize = 0;
        val_47 = this.event_text;
    }
    public FPHEventLobbyButton()
    {
    
    }

}
