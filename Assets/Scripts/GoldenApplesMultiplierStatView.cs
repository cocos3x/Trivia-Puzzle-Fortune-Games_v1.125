using UnityEngine;
public class GoldenApplesMultiplierStatView : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button multiplierButton;
    private UnityEngine.UI.Text multiplierText;
    
    // Properties
    public UnityEngine.RectTransform GetButtonTransform { get; }
    
    // Methods
    public UnityEngine.RectTransform get_GetButtonTransform()
    {
        return this.multiplierButton.GetComponent<UnityEngine.RectTransform>();
    }
    private void Awake()
    {
        System.Action<System.Boolean> val_8;
        this.multiplierButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void GoldenApplesMultiplierStatView::OnTouchAreaClicked()));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGoldenMultiplierUpdate");
        val_8 = 1152921504893161472;
        if((MonoSingleton<WGSubscriptionManager>.Instance) == 0)
        {
                return;
        }
        
        WGSubscriptionManager val_5 = MonoSingleton<WGSubscriptionManager>.Instance;
        val_8 = val_5.purchaseResult;
        System.Delegate val_7 = System.Delegate.Combine(a:  val_8, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void GoldenApplesMultiplierStatView::OnSubscriptionPurchaseAttempt(bool success)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_15;
        }
        
        }
        
        val_5.purchaseResult = val_7;
        return;
        label_15:
    }
    private void Start()
    {
        this.OnGoldenMultiplierUpdate();
    }
    private void OnDestroy()
    {
        if((MonoSingleton<WGSubscriptionManager>.Instance) == 0)
        {
                return;
        }
        
        WGSubscriptionManager val_3 = MonoSingleton<WGSubscriptionManager>.Instance;
        1152921504893161472 = val_3.purchaseResult;
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void GoldenApplesMultiplierStatView::OnSubscriptionPurchaseAttempt(bool success)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_3.purchaseResult = val_5;
        return;
        label_10:
    }
    private void OnGoldenMultiplierUpdate()
    {
        string val_4 = System.String.Format(format:  "{0}X", arg0:  MonoSingleton<GoldenMultiplierManager>.Instance.GetTotalMultipliers().ToString(format:  "##.#"));
    }
    private void OnTouchAreaClicked()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public WGGoldenMultiplierPopup MetaGameBehavior::ShowUGUIMonolith<WGGoldenMultiplierPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    private void OnSubscriptionPurchaseAttempt(bool success)
    {
        this.OnGoldenMultiplierUpdate();
    }
    public GoldenApplesMultiplierStatView()
    {
    
    }

}
