using UnityEngine;
public class WGGoldenMultiplierFlyout : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
    // Fields
    private UnityEngine.RectTransform completeFlyout;
    private UnityEngine.UI.Text completeText;
    private bool playingAnimation;
    private System.Action onStartAction;
    private UnityEngine.Camera canvasCamera;
    private UnityEngine.RectTransform uiButton;
    
    // Methods
    private void Awake()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) == false)
        {
                return;
        }
        
        MainController val_3 = MainController.instance;
        val_3.onBeforeLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGGoldenMultiplierFlyout::OnBeforeLevelComplete()));
    }
    private void Start()
    {
        if(this.onStartAction == null)
        {
                return;
        }
        
        this.onStartAction.Invoke();
    }
    private void Update()
    {
        if((MonoSingleton<WGWindowManager>.Instance.GetActiveAndQueuedWindowCount()) < 2)
        {
                return;
        }
        
        this.OnDisplayComplete();
    }
    private void OnDestroy()
    {
        this.StopAllCoroutines();
    }
    public void PlayCompleteFlyout()
    {
        this.onStartAction = new System.Action(object:  this, method:  System.Void WGGoldenMultiplierFlyout::DoCompleteFlyout());
    }
    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        this.StopAllCoroutines();
        this.gameObject.SetActive(value:  false);
        GameBehavior val_2 = App.getBehavior;
        goto mem[(1152921504946249728 + (public WGGoldenMultiplierPopup MetaGameBehavior::ShowUGUIMonolith<WGGoldenMultiplierPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    private void DoCompleteFlyout()
    {
        if(this.playingAnimation == true)
        {
                return;
        }
        
        this.playingAnimation = true;
        UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  1f);
        this.completeFlyout.transform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        this.completeFlyout.gameObject.SetActive(value:  true);
        string val_4 = Localization.Localize(key:  "increase_golden_mult_ex", defaultValue:  "Increase your Golden Multiplier!", useSingularKey:  false);
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.CompleteFlyout());
        UnityEngine.Coroutine val_8 = this.StartCoroutine(routine:  this.SetCompleteFlyoutPlacement());
    }
    private void OnBeforeLevelComplete()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) != false)
        {
                MainController val_3 = MainController.instance;
            val_3.onBeforeLevelComplete.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGGoldenMultiplierFlyout::OnBeforeLevelComplete()));
        }
        
        this.OnDisplayComplete();
    }
    private void OnDisplayComplete()
    {
        this.StopAllCoroutines();
        this.gameObject.SetActive(value:  false);
    }
    private System.Collections.IEnumerator CompleteFlyout()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGGoldenMultiplierFlyout.<CompleteFlyout>d__15();
    }
    private System.Collections.IEnumerator SetCompleteFlyoutPlacement()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGGoldenMultiplierFlyout.<SetCompleteFlyoutPlacement>d__16();
    }
    public WGGoldenMultiplierFlyout()
    {
    
    }

}
