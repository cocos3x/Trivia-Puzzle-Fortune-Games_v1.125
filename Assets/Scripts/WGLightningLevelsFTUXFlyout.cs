using UnityEngine;
public class WGLightningLevelsFTUXFlyout : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Button lightningButton;
    protected UnityEngine.UI.Button continueButton;
    protected UnityEngine.UI.Button screenButton;
    private UnityEngine.Transform window;
    private System.Action onClose;
    
    // Methods
    protected void Awake()
    {
        this.lightningButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGLightningLevelsFTUXFlyout).__il2cppRuntimeField_178));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningLevelsFTUXFlyout::Close()));
        this.screenButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLightningLevelsFTUXFlyout::Close()));
    }
    protected void Start()
    {
        var val_16;
        var val_17;
        var val_18;
        var val_20;
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        val_16 = null;
        val_17 = null;
        val_17 = null;
        if(App.game == 18)
        {
                val_18 = MonoSingleton<GameMaskOverlay>.Instance;
            UnityEngine.Color val_4 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.3f);
            System.Nullable<UnityEngine.Color> val_5 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a});
        }
        else
        {
                val_18 = MonoSingleton<GameMaskOverlay>.Instance;
            UnityEngine.Color val_7 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0f);
            System.Nullable<UnityEngine.Color> val_8 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = val_7.a});
            val_20;
        }
        
        val_18.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
        System.Collections.Generic.List<UnityEngine.Transform> val_9 = new System.Collections.Generic.List<UnityEngine.Transform>();
        val_9.Add(item:  this.gameObject.transform);
        LightningLevelsUIController val_12 = MonoSingleton<LightningLevelsUIController>.Instance;
        val_9.Add(item:  val_12.<lightningEventButton>k__BackingField.transform);
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_9.ToArray());
    }
    public void ShowFTUX(UnityEngine.Transform eventButton, UnityEngine.Transform mainLayout, System.Action onClose)
    {
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  0f, y:  200f, z:  0f);
        UnityEngine.Vector3 val_2 = eventButton.position;
        UnityEngine.Vector3 val_3 = mainLayout.InverseTransformPoint(position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, b:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
        UnityEngine.Vector3 val_6 = this.window.parent.TransformPoint(position:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
        PluginExtension.SetY(transform:  this.window, y:  val_6.y);
        this.onClose = onClose;
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
    public WGLightningLevelsFTUXFlyout()
    {
    
    }

}
