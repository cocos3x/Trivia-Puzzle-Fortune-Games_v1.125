using UnityEngine;
public class WGMessageFlyout : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
    // Fields
    private UnityEngine.RectTransform flyoutParent;
    private UnityEngine.UI.Text flyoutText;
    private float displayDuration;
    private bool playingAnimation;
    private bool showing;
    private System.Action onStartAction;
    
    // Methods
    private void Awake()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) == false)
        {
                return;
        }
        
        MainController val_3 = MainController.instance;
        val_3.onBeforeLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMessageFlyout::OnBeforeLevelComplete()));
    }
    private void Start()
    {
        if(this.onStartAction != null)
        {
                this.onStartAction.Invoke();
        }
        
        this.ProgressAnim();
    }
    public void SetupMessage(string message, float displaySeconds = 3, System.Action startAction)
    {
        this.onStartAction = startAction;
        this.displayDuration = displaySeconds;
    }
    private void ProgressAnim()
    {
        if(this.playingAnimation != false)
        {
                return;
        }
        
        this.playingAnimation = true;
        this.flyoutParent.gameObject.SetActive(value:  true);
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.ProgressFlyout());
    }
    private System.Collections.IEnumerator ProgressFlyout()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGMessageFlyout.<ProgressFlyout>d__10();
    }
    private void OnBeforeLevelComplete()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) != false)
        {
                MainController val_3 = MainController.instance;
            val_3.onBeforeLevelComplete.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMessageFlyout::OnBeforeLevelComplete()));
        }
        
        this.OnDisplayComplete();
    }
    private void Update()
    {
        if((MonoSingleton<WGWindowManager>.Instance.GetActiveAndQueuedWindowCount()) <= 1)
        {
                if(this.showing == false)
        {
                return;
        }
        
            if(UnityEngine.Input.touchCount < 1)
        {
                return;
        }
        
        }
        
        this.OnDisplayComplete();
    }
    private void OnDisplayComplete()
    {
        this.StopAllCoroutines();
        this.gameObject.SetActive(value:  false);
    }
    private void OnDestroy()
    {
        this.StopAllCoroutines();
    }
    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        this.StopAllCoroutines();
        this.gameObject.SetActive(value:  false);
    }
    public WGMessageFlyout()
    {
        this.displayDuration = 3f;
    }

}
