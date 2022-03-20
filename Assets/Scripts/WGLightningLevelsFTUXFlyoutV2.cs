using UnityEngine;
public class WGLightningLevelsFTUXFlyoutV2 : FtuxTooltip
{
    // Fields
    protected UnityEngine.UI.Button lightningButton;
    protected UnityEngine.UI.Button continueButton;
    protected UnityEngine.UI.Button screenButton;
    private UnityEngine.Transform window;
    private UnityEngine.Transform targetTransform;
    private System.Action onClose;
    
    // Methods
    protected void Awake()
    {
        this.lightningButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGLightningLevelsFTUXFlyoutV2).__il2cppRuntimeField_178));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningLevelsFTUXFlyoutV2::Close()));
        this.screenButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningLevelsFTUXFlyoutV2::Close()));
    }
    protected void Start()
    {
        var val_14;
        var val_15;
        var val_17;
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        val_14 = null;
        val_14 = null;
        if(App.game == 18)
        {
                val_15 = MonoSingleton<GameMaskOverlay>.Instance;
            UnityEngine.Color val_4 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.3f);
            System.Nullable<UnityEngine.Color> val_5 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a});
        }
        else
        {
                val_15 = MonoSingleton<GameMaskOverlay>.Instance;
            UnityEngine.Color val_7 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0f);
            System.Nullable<UnityEngine.Color> val_8 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = val_7.a});
            val_17;
        }
        
        val_15.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
        System.Collections.Generic.List<UnityEngine.Transform> val_9 = new System.Collections.Generic.List<UnityEngine.Transform>();
        val_9.Add(item:  this.gameObject.transform);
        val_9.Add(item:  this.targetTransform);
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_9.ToArray());
    }
    protected void OnEnable()
    {
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void WGLightningLevelsFTUXFlyoutV2::Reposition()), count:  1);
    }
    public void ShowFTUX(UnityEngine.Transform eventButton, System.Action onClose)
    {
        this.targetTransform = eventButton;
        this.onClose = onClose;
    }
    protected void Reposition()
    {
        UnityEngine.Vector3 val_1 = this.targetTransform.position;
        UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  0f, y:  -40f);
        this.Reposition(worldPos:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, anchoredOffset:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y});
    }
    protected void Close()
    {
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = false;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = false;
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(this.onClose == null)
        {
                return;
        }
        
        this.onClose.Invoke();
    }
    protected virtual void OnClick_LightningButton()
    {
        this.Close();
    }
    public WGLightningLevelsFTUXFlyoutV2()
    {
    
    }

}
