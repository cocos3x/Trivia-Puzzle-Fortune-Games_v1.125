using UnityEngine;
public class WGGoldenGalaInfoPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text timerText;
    private UnityEngine.GameObject subscriberGroup;
    private UnityEngine.GameObject nonSubscriberGroup;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button goldenTicketButton;
    private System.Action onDisableCallback;
    
    // Methods
    private void Awake()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGGoldenGalaInfoPopup::OnCloseButtonClicked()));
        this.goldenTicketButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGGoldenGalaInfoPopup::OnGoldenTicketButtonClicked()));
    }
    private void OnEnable()
    {
        bool val_1 = GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive;
        this.subscriberGroup.SetActive(value:  val_1);
        this.nonSubscriberGroup.SetActive(value:  (~val_1) & 1);
        this.StopAllCoroutines();
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.SetTimer());
    }
    private void OnDisable()
    {
        if(this.onDisableCallback == null)
        {
                return;
        }
        
        this.onDisableCallback.Invoke();
    }
    public void SetOnDisableCallback(System.Action callback)
    {
        this.onDisableCallback = callback;
    }
    private void OnCloseButtonClicked()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnGoldenTicketButtonClicked()
    {
        WGSubscriptionManager._subEntryPoint = 60;
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGSubscriptionPopup>(showNext:  true);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private System.Collections.IEnumerator SetTimer()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGGoldenGalaInfoPopup.<SetTimer>d__12();
    }
    public WGGoldenGalaInfoPopup()
    {
    
    }

}
