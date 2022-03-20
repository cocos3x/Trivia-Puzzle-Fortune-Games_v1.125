using UnityEngine;
public class WGEventsListPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text titleText;
    private UnityEngine.Transform buttonsParent;
    private UnityEngine.UI.Button closeButton;
    private bool displayEventQuantity;
    private EventListItem _EventListItemPrefab;
    
    // Properties
    private EventListItem EventListItemPrefab { get; }
    
    // Methods
    private EventListItem get_EventListItemPrefab()
    {
        EventListItem val_3;
        if(this._EventListItemPrefab == 0)
        {
                this._EventListItemPrefab = PrefabLoader.LoadPrefab<EventListItem>(featureName:  "Events");
            return val_3;
        }
        
        val_3 = this._EventListItemPrefab;
        return val_3;
    }
    private void OnEnable()
    {
        WGEventHandler val_14;
        var val_15;
        UnityEngine.Events.UnityAction val_25;
        var val_26;
        UnityEngine.Transform val_28;
        UnityEngine.Events.UnityAction val_1 = null;
        val_25 = val_1;
        val_1 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGEventsListPopup::<OnEnable>b__7_0());
        this.closeButton.m_OnClick.AddListener(call:  val_1);
        val_26 = 1152921515418697360;
        if((MonoSingleton<WordGameEventsController>.Instance) == 0)
        {
                SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
        }
        
        if(this.displayEventQuantity != false)
        {
                val_25 = Localization.Localize(key:  "events_x_upper", defaultValue:  "EVENTS ({0})", useSingularKey:  false);
            string val_9 = System.String.Format(format:  val_25, arg0:  MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount.ToString());
        }
        else
        {
                string val_10 = Localization.Localize(key:  "active_events_upper", defaultValue:  "ACTIVE EVENTS", useSingularKey:  false);
        }
        
        List.Enumerator<T> val_13 = MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlers().GetEnumerator();
        val_26 = 1152921516373923776;
        goto label_19;
        label_28:
        val_28 = this.buttonsParent;
        EventListItem val_17 = UnityEngine.Object.Instantiate<EventListItem>(original:  this.EventListItemPrefab, parent:  val_28);
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28 = public EventListItem UnityEngine.Component::GetComponent<EventListItem>();
        EventListItem val_18 = val_17.GetComponent<EventListItem>();
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_18.InitWithEventHandler(handler:  val_14);
        val_28 = 0;
        UnityEngine.GameObject val_19 = val_18.gameObject;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28 = public UGUINetworkedButton UnityEngine.GameObject::GetComponent<UGUINetworkedButton>();
        if((val_19.GetComponent<UGUINetworkedButton>()) == null)
        {
                throw new NullReferenceException();
        }
        
        val_25 = val_20.OnConnectionClick;
        System.Delegate val_22 = System.Delegate.Combine(a:  val_25, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGEventsListPopup::<OnEnable>b__7_1(bool obj)));
        if(val_22 != null)
        {
                val_28 = null;
            if(null != val_28)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_20.OnConnectionClick = val_22;
        label_19:
        if(val_15.MoveNext() == true)
        {
            goto label_28;
        }
        
        val_15.Dispose();
    }
    private System.Collections.IEnumerator UpdateTitleCounter()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGEventsListPopup.<UpdateTitleCounter>d__8();
    }
    private void OnClose(bool eventClicked = False)
    {
        null = null;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(App.game != 17)
        {
                return;
        }
        
        if(eventClicked == true)
        {
                return;
        }
        
        if(SceneDictator.IsInGameScene() == false)
        {
                return;
        }
        
        MonoSingleton<TRVMainController>.Instance.Init(currentlySelectedCategores:  0, fromReroll:  false);
    }
    private void OnDestroy()
    {
        this.StopAllCoroutines();
    }
    public WGEventsListPopup()
    {
        this.displayEventQuantity = true;
    }
    private void <OnEnable>b__7_0()
    {
        this.OnClose(eventClicked:  false);
    }
    private void <OnEnable>b__7_1(bool obj)
    {
        this.OnClose(eventClicked:  true);
    }

}
