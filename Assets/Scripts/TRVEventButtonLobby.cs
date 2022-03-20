using UnityEngine;
public class TRVEventButtonLobby : MonoBehaviour
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
    private UnityEngine.Sprite crazyCategoriesIcon;
    private UnityEngine.Sprite triviaMastersIcon;
    private UnityEngine.Sprite starChampionshipIcon;
    private UnityEngine.Sprite triviaPursuitIcon;
    private UnityEngine.Sprite leaderboardIcon;
    public UnityEngine.Sprite pbMenuSprite;
    private UnityEngine.Sprite youBetchaIcon;
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
        System.Delegate val_5 = System.Delegate.Combine(a:  this.event_button.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVEventButtonLobby::OnClick(bool result)));
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
        
        this.LeftButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVEventButtonLobby::PrevEvent()));
        this.RightButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVEventButtonLobby::NextEvent()));
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
        val_18 = TRVEventButtonLobby.<>c.<>9__26_0;
        if(val_18 == null)
        {
                System.Action val_10 = null;
            val_18 = val_10;
            val_10 = new System.Action(object:  TRVEventButtonLobby.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVEventButtonLobby.<>c::<OnClick>b__26_0());
            TRVEventButtonLobby.<>c.<>9__26_0 = val_18;
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
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateDisplayAfterDelay());
    }
    private System.Collections.IEnumerator UpdateDisplayAfterDelay()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVEventButtonLobby.<UpdateDisplayAfterDelay>d__30();
    }
    public void UpdateDisplay()
    {
        var val_82;
        WGEventHandler val_83;
        WGEventHandler val_84;
        var val_85;
        UnityEngine.UI.Text val_86;
        var val_87;
        UnityEngine.Sprite val_88;
        float val_90;
        var val_91;
        if(this.categorySelectPopupEventBar != false)
        {
                UnityEngine.GameObject val_1 = this.gameObject;
            if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
            val_82 = 1152921515458238320;
            if((val_1.GetComponent<UnityEngine.CanvasGroup>()) != 0)
        {
                UnityEngine.GameObject val_4 = this.gameObject;
            if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.CanvasGroup val_5 = val_4.GetComponent<UnityEngine.CanvasGroup>();
            if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
            val_5.alpha = 1f;
        }
        
        }
        
        if(WordGameEventsController.EventsEnabled == false)
        {
            goto label_10;
        }
        
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_7 = this.event_text.gameObject;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_7.SetActive(value:  true);
        val_82 = 1152921504893161472;
        WordGameEventsController val_8 = MonoSingleton<WordGameEventsController>.Instance;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_8.GetCurrentEventsCount >= 2) && (this.LeftButton != 0))
        {
                if(this.RightButton != 0)
        {
                if(this.LeftButton == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_12 = this.LeftButton.gameObject;
            if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
            val_12.SetActive(value:  true);
            if(this.RightButton == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_13 = this.RightButton.gameObject;
            if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
            val_13.SetActive(value:  true);
        }
        
        }
        
        if(this.showingAllEventsButton == false)
        {
            goto label_27;
        }
        
        val_83 = this;
        val_84 = this.currentEventHandler;
        if(val_84 != null)
        {
            goto label_28;
        }
        
        throw new NullReferenceException();
        label_27:
        WordGameEventsController val_14 = MonoSingleton<WordGameEventsController>.Instance;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        WGEventHandler val_15 = val_14.GetOrderedEventHandlersByIndex(index:  this.CurrentEventIndex);
        this.currentEventHandler = val_15;
        if(val_15 == null)
        {
            goto label_33;
        }
        
        val_83 = this.currentEventHandler;
        label_28:
        val_85 = 1152921504765632512;
        if((val_15 != 0) && (this.showingAllEventsButton != true))
        {
                if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
            this.button_prefix.sprite = val_15;
            if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
            this.button_prefix.enabled = true;
            if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_17 = this.button_prefix.gameObject;
            if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
            val_17.SetActive(value:  true);
        }
        
        if(this.event_button == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_18 = this.event_button.gameObject;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_18.SetActive(value:  true);
        if(this.eventsCointainer != 0)
        {
                if(this.eventsCointainer == null)
        {
                throw new NullReferenceException();
        }
        
            this.eventsCointainer.SetActive(value:  true);
        }
        
        if(this.eventsCounter != 0)
        {
                string val_21 = Localization.Localize(key:  "active_events_upper", defaultValue:  "ACTIVE EVENTS", useSingularKey:  false);
            if(this.eventsCounter == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.showingAllEventsButton != false)
        {
                UnityEngine.GameObject val_22 = this.button_prefix.gameObject;
            if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
            val_22.SetActive(value:  false);
            string val_23 = Localization.Localize(key:  "view_all_events_upper", defaultValue:  "VIEW ALL EVENTS", useSingularKey:  false);
            if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
            this.event_text.resizeTextMaxSize = 65;
            if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
            this.iconTextLayout.childAlignment = 5;
            if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
            val_86 = this.event_text.rectTransform;
            UnityEngine.Vector2 val_25 = new UnityEngine.Vector2(x:  602f, y:  170f);
            if(val_86 == null)
        {
                throw new NullReferenceException();
        }
        
            val_86.sizeDelta = new UnityEngine.Vector2() {x = val_25.x, y = val_25.y};
            return;
        }
        
        UnityEngine.RectTransform val_26 = this.button_prefix.rectTransform;
        UnityEngine.Vector3 val_27 = UnityEngine.Vector3.one;
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.localScale = new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z};
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        this.iconTextLayout.childAlignment = 4;
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_28 = this.event_text.rectTransform;
        UnityEngine.Vector2 val_29 = new UnityEngine.Vector2(x:  568f, y:  170f);
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28.sizeDelta = new UnityEngine.Vector2() {x = val_29.x, y = val_29.y};
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        this.iconTextLayout.spacing = 0f;
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        this.iconTextLayout.left = 10;
        if(mem[this.currentEventHandler] == 0)
        {
                throw new NullReferenceException();
        }
        
        string val_30 = mem[this.currentEventHandler].EventType;
        uint val_31 = _PrivateImplementationDetails_.ComputeStringHash(s:  val_30);
        if(val_31 > 2109769660)
        {
            goto label_72;
        }
        
        if(val_31 > 1054264077)
        {
            goto label_73;
        }
        
        if(val_31 == 813111565)
        {
            goto label_74;
        }
        
        if((val_31 != 1054264077) || ((System.String.op_Equality(a:  val_30, b:  "ProgressiveIapSale")) == false))
        {
            goto label_201;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.progressiveIAPIcon;
        UnityEngine.Color val_33 = new UnityEngine.Color(r:  0.1058824f, g:  0.9686275f, b:  0.8352941f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_33.r, g = val_33.g, b = val_33.b, a = val_33.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_34 = this.button_prefix.gameObject;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34.SetActive(value:  true);
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.fontSize = 56;
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.resizeTextMaxSize = 56;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_35 = this.button_prefix.rectTransform;
        UnityEngine.Vector3 val_36 = new UnityEngine.Vector3(x:  1.3f, y:  1.3f, z:  1.3f);
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35.localScale = new UnityEngine.Vector3() {x = val_36.x, y = val_36.y, z = val_36.z};
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        this.iconTextLayout.spacing = 0f;
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        val_87 = 30;
        goto label_135;
        label_72:
        if(val_31 > (-885012804))
        {
            goto label_90;
        }
        
        if(val_31 == (-1621386445))
        {
            goto label_91;
        }
        
        if(val_31 == (-1019895860))
        {
            goto label_92;
        }
        
        if((val_31 != (-885012804)) || ((System.String.op_Equality(a:  val_30, b:  "SpecialCategories")) == false))
        {
            goto label_201;
        }
        
        val_85 = MonoSingleton<TRVUtils>.Instance;
        if(TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_85 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = val_85.GetCategoryIcon(category:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 64);
        UnityEngine.Color val_40 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_40.r, g = val_40.g, b = val_40.b, a = val_40.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_41 = this.button_prefix.rectTransform;
        UnityEngine.Vector2 val_42 = new UnityEngine.Vector2(x:  135f, y:  135f);
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41.sizeDelta = new UnityEngine.Vector2() {x = val_42.x, y = val_42.y};
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.resizeTextMaxSize = 52;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_43 = this.button_prefix.gameObject;
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43.SetActive(value:  true);
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        this.iconTextLayout.spacing = 0f;
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.iconTextLayout != null)
        {
            goto label_110;
        }
        
        throw new NullReferenceException();
        label_33:
        if(this.CurrentEventIndex != 0)
        {
                throw new NullReferenceException();
        }
        
        label_10:
        if(this.event_button == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_44 = this.event_button.gameObject;
        if(val_44 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44.SetActive(value:  false);
        if(this.categorySelectPopupEventBar == false)
        {
            goto label_115;
        }
        
        if(this.gameObject != null)
        {
            goto label_116;
        }
        
        throw new NullReferenceException();
        label_115:
        if(this.eventsCointainer == null)
        {
                throw new NullReferenceException();
        }
        
        label_116:
        this.eventsCointainer.SetActive(value:  false);
        return;
        label_73:
        if(val_31 == 1399814793)
        {
            goto label_119;
        }
        
        if(val_31 == 2102096662)
        {
            goto label_120;
        }
        
        if((val_31 != 2109769660) || ((System.String.op_Equality(a:  val_30, b:  "Special Categories")) == false))
        {
            goto label_201;
        }
        
        if(mem[this.currentEventHandler] == 0)
        {
                throw new NullReferenceException();
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = mem[this.currentEventHandler];
        UnityEngine.Color val_47 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_47.r, g = val_47.g, b = val_47.b, a = val_47.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_48 = this.button_prefix.rectTransform;
        UnityEngine.Vector2 val_49 = new UnityEngine.Vector2(x:  135f, y:  135f);
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        val_48.sizeDelta = new UnityEngine.Vector2() {x = val_49.x, y = val_49.y};
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.resizeTextMaxSize = 52;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.gameObject.SetActive(value:  true);
        this.iconTextLayout.spacing = 0f;
        label_110:
        val_87 = 20;
        goto label_135;
        label_90:
        if(val_31 == (-746431984))
        {
            goto label_136;
        }
        
        if(val_31 == (-157622816))
        {
            goto label_137;
        }
        
        if((val_31 != (-306129312)) || ((System.String.op_Equality(a:  val_30, b:  "BigQuiz")) == false))
        {
            goto label_201;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.bigQuizIcon;
        UnityEngine.Color val_52 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_52.r, g = val_52.g, b = val_52.b, a = val_52.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.resizeTextMaxSize = 65;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_53 = this.button_prefix.gameObject;
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        val_53.SetActive(value:  true);
        goto label_210;
        label_74:
        if((System.String.op_Equality(a:  val_30, b:  "TriviaMasters")) == false)
        {
            goto label_201;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_88 = this.triviaMastersIcon;
        goto label_149;
        label_91:
        if((System.String.op_Equality(a:  val_30, b:  "YouBetcha")) == false)
        {
            goto label_201;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.youBetchaIcon;
        UnityEngine.Color val_56 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_56.r, g = val_56.g, b = val_56.b, a = val_56.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_57 = this.button_prefix.gameObject;
        if(val_57 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57.SetActive(value:  true);
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.fontSize = 48;
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.resizeTextMaxSize = 65;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_58 = this.button_prefix.rectTransform;
        UnityEngine.Vector3 val_59 = new UnityEngine.Vector3(x:  0.6f, y:  0.6f, z:  0.6f);
        if(val_58 == null)
        {
                throw new NullReferenceException();
        }
        
        val_58.localScale = new UnityEngine.Vector3() {x = val_59.x, y = val_59.y, z = val_59.z};
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        this.iconTextLayout.spacing = -60f;
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        val_87 = 29;
        label_135:
        this.iconTextLayout.left = 29;
        goto label_210;
        label_92:
        if((System.String.op_Equality(a:  val_30, b:  "Leaderboard")) == false)
        {
            goto label_201;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.leaderboardIcon;
        UnityEngine.Color val_61 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_61.r, g = val_61.g, b = val_61.b, a = val_61.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_62 = this.button_prefix.gameObject;
        if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
        val_62.SetActive(value:  true);
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.fontSize = 48;
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.resizeTextMaxSize = 65;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_63 = this.button_prefix.rectTransform;
        val_90 = 1.1f;
        goto label_173;
        label_119:
        if((System.String.op_Equality(a:  val_30, b:  "PiggyBank")) == false)
        {
            goto label_201;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.pbMenuSprite;
        UnityEngine.Color val_65 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_65.r, g = val_65.g, b = val_65.b, a = val_65.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        val_91 = 56;
        goto label_179;
        label_120:
        if((System.String.op_Equality(a:  val_30, b:  "CrazyCategories")) == false)
        {
            goto label_201;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.crazyCategoriesIcon;
        UnityEngine.Color val_67 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_67.r, g = val_67.g, b = val_67.b, a = val_67.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_68 = this.button_prefix.rectTransform;
        UnityEngine.Vector2 val_69 = new UnityEngine.Vector2(x:  160f, y:  160f);
        if(val_68 == null)
        {
                throw new NullReferenceException();
        }
        
        val_68.sizeDelta = new UnityEngine.Vector2() {x = val_69.x, y = val_69.y};
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.resizeTextMaxSize = 56;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_70 = this.button_prefix.gameObject;
        if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        val_70.SetActive(value:  true);
        goto label_189;
        label_136:
        if((System.String.op_Equality(a:  val_30, b:  "StarChampionship")) == false)
        {
            goto label_201;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.starChampionshipIcon;
        UnityEngine.Color val_72 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_72.r, g = val_72.g, b = val_72.b, a = val_72.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.resizeTextMaxSize = 56;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_73 = this.button_prefix.gameObject;
        if(val_73 == null)
        {
                throw new NullReferenceException();
        }
        
        val_73.SetActive(value:  true);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_74 = this.button_prefix.rectTransform;
        UnityEngine.Vector3 val_75 = new UnityEngine.Vector3(x:  0.8f, y:  0.8f, z:  0.8f);
        if(val_74 == null)
        {
                throw new NullReferenceException();
        }
        
        val_74.localScale = new UnityEngine.Vector3() {x = val_75.x, y = val_75.y, z = val_75.z};
        label_189:
        if(this.iconTextLayout == null)
        {
                throw new NullReferenceException();
        }
        
        this.iconTextLayout.spacing = -10f;
        goto label_210;
        label_137:
        if((System.String.op_Equality(a:  val_30, b:  "TriviaPursuit")) == false)
        {
            goto label_201;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_88 = this.triviaPursuitIcon;
        label_149:
        this.button_prefix.sprite = val_88;
        UnityEngine.Color val_77 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_77.r, g = val_77.g, b = val_77.b, a = val_77.a};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        val_91 = 65;
        label_179:
        this.event_text.resizeTextMaxSize = 65;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_78 = this.button_prefix.gameObject;
        if(val_78 == null)
        {
                throw new NullReferenceException();
        }
        
        val_78.SetActive(value:  true);
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_79 = this.button_prefix.rectTransform;
        val_90 = 0.8f;
        label_173:
        UnityEngine.Vector3 val_80 = new UnityEngine.Vector3(x:  val_90, y:  val_90, z:  val_90);
        if(val_79 == null)
        {
                throw new NullReferenceException();
        }
        
        val_79.localScale = new UnityEngine.Vector3() {x = val_80.x, y = val_80.y, z = val_80.z};
        goto label_210;
        label_201:
        UnityEngine.Debug.LogError(message:  mem[this.currentEventHandler].EventType);
        label_210:
        this.event_text.fontSize = 0;
        val_86 = this.event_text;
    }
    public TRVEventButtonLobby()
    {
    
    }

}
