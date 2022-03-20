using UnityEngine;
public class WGHintButtonDemoPopup : MonoBehaviour
{
    // Fields
    protected UnityEngine.Transform Transform_UseHint;
    protected UnityEngine.UI.Button Button_UseHint;
    protected UnityEngine.UI.Text hintCostText;
    private UnityEngine.Coroutine waitSetPosition;
    protected UnityEngine.GameObject targetButtonObject;
    private bool acceptKeyInput;
    protected static System.Collections.Generic.Dictionary<System.Type, bool> shownTypeDict;
    
    // Properties
    public static bool IsShowing { get; }
    public UnityEngine.Camera mainCamera { get; }
    
    // Methods
    public static bool get_IsShowing()
    {
        return WGHintButtonDemoPopup.IsShowingByType(_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
    }
    public UnityEngine.Camera get_mainCamera()
    {
        return SLCWindowManager<WGWindowManager>.gameplayCamera;
    }
    public static bool CheckAvailable()
    {
        var val_6;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                GameBehavior val_2 = App.getBehavior;
            GameBehavior val_3 = App.getBehavior;
            if((val_2.<metaGameBehavior>k__BackingField) == (val_3.<metaGameBehavior>k__BackingField))
        {
                val_6 = Prefs.HasUsedHint() ^ 1;
            return (bool)val_6 & 1;
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6 & 1;
    }
    protected static bool IsShowingByType(System.Type _type)
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if((WGHintButtonDemoPopup.shownTypeDict.ContainsKey(key:  _type)) == false)
        {
                return false;
        }
        
        val_3 = null;
        val_3 = null;
        return WGHintButtonDemoPopup.shownTypeDict.Item[_type];
    }
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnCanvasResized");
    }
    protected virtual void OnDestroy()
    {
        System.Action<System.String, System.Int32, System.Boolean, System.Boolean> val_12;
        var val_13;
        if((MonoSingleton<AdsUIController>.Instance) != 0)
        {
                AdsUIController val_3 = MonoSingleton<AdsUIController>.Instance;
            val_3.onAdToggled.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGHintButtonDemoPopup::OnAdToggled()));
        }
        
        val_12 = 1152921504879157248;
        if(WordRegion.instance != 0)
        {
                WordRegion val_7 = WordRegion.instance;
            val_12 = val_7.OnHintedUsed;
            System.Delegate val_9 = System.Delegate.Remove(source:  val_12, value:  new System.Action<System.String, System.Int32, System.Boolean, System.Boolean>(object:  this, method:  System.Void WGHintButtonDemoPopup::OnHintUsed(string word, int index, bool isFree, bool isPickerHint)));
            if(val_9 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
            val_7.OnHintedUsed = val_9;
        }
        
        val_13 = null;
        val_13 = null;
        EnumerableExtentions.SetOrAdd<System.Type, System.Boolean>(dic:  WGHintButtonDemoPopup.shownTypeDict, key:  this.GetType(), newValue:  false);
        HintFeatureManager val_11 = MonoSingleton<HintFeatureManager>.Instance;
        val_11.<wgHbutton>k__BackingField.UpdateDisplay();
        return;
        label_19:
    }
    protected virtual void Start()
    {
        var val_14;
        int val_15;
        AdsUIController val_1 = MonoSingleton<AdsUIController>.Instance;
        val_1.onAdToggled.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGHintButtonDemoPopup::OnAdToggled()));
        val_14 = null;
        val_14 = null;
        EnumerableExtentions.SetOrAdd<System.Type, System.Boolean>(dic:  WGHintButtonDemoPopup.shownTypeDict, key:  this.GetType(), newValue:  true);
        WordRegion.instance.addOnHintedUsedAction(callback:  new System.Action<System.String, System.Int32, System.Boolean, System.Boolean>(object:  this, method:  System.Void WGHintButtonDemoPopup::OnHintUsed(string word, int index, bool isFree, bool isPickerHint)));
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        UnityEngine.Color val_9 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.75f);
        System.Nullable<UnityEngine.Color> val_10 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_9.r, g = val_9.g, b = val_9.b, a = val_9.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = false}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
        UnityEngine.Transform[] val_12 = new UnityEngine.Transform[2];
        val_15 = val_12.Length;
        val_12[0] = this.targetButtonObject.transform;
        if(this.Transform_UseHint != null)
        {
                val_15 = val_12.Length;
        }
        
        val_12[1] = this.Transform_UseHint;
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_12);
    }
    protected virtual void SetupButton()
    {
        this.targetButtonObject = MonoSingleton<AdsUIController>.Instance.HintButtonGroup;
        HintFeatureManager val_3 = MonoSingleton<HintFeatureManager>.Instance;
        val_3.<wgHbutton>k__BackingField.CheckFreeHinting();
    }
    protected void OnAdToggled()
    {
        this.RefreshPosition();
    }
    private void OnCanvasResized(Notification notif)
    {
        this.RefreshPosition();
    }
    private void OnRectTransformDimensionsChange()
    {
        this.RefreshPosition();
    }
    private void OnEnable()
    {
        this.Transform_UseHint.gameObject.SetActive(value:  false);
        this.RefreshPosition();
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                WordRegion.instance.OnHintDemoEnable();
        }
        
        this.acceptKeyInput = true;
    }
    private void Update()
    {
    
    }
    protected virtual void OnKeyBoardPress()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_180;
    }
    private void RefreshPosition()
    {
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if(this.waitSetPosition != null)
        {
                this.StopCoroutine(routine:  this.waitSetPosition);
        }
        
        this.waitSetPosition = this.StartCoroutine(routine:  this.WaitSetPosition());
    }
    private System.Collections.IEnumerator WaitSetPosition()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGHintButtonDemoPopup.<WaitSetPosition>d__24();
    }
    protected virtual void SetPosition()
    {
        UnityEngine.Transform val_3 = MonoSingleton<GameMaskOverlay>.Instance.GetStandInTransformForObject(original:  this.targetButtonObject.transform);
        if(val_3 == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_7 = MonoSingleton<GameMaskOverlay>.Instance.TransformPositionToOverlaySpace(objectTransform:  val_3.transform);
        this.targetButtonObject.transform.position = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        this.Transform_UseHint.position = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
    }
    private System.Collections.IEnumerator HoldPosition()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGHintButtonDemoPopup.<HoldPosition>d__26();
    }
    private void OnHintUsed(string word, int index, bool isFree, bool isPickerHint)
    {
        goto typeof(WGHintButtonDemoPopup).__il2cppRuntimeField_1C0;
    }
    protected virtual void OnClick_UseHint()
    {
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        this.acceptKeyInput = false;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public UnityEngine.Camera GetCameraByTransform(UnityEngine.Transform obTranform)
    {
        var val_6;
        UnityEngine.Object val_7;
        val_6 = obTranform;
        goto label_0;
        label_8:
        if(val_6.parent == 0)
        {
            goto label_3;
        }
        
        val_6 = val_6.parent;
        label_0:
        val_7 = val_6.GetComponent<UnityEngine.Camera>();
        if(val_7 == 0)
        {
            goto label_8;
        }
        
        return (UnityEngine.Camera)val_7;
        label_3:
        val_7 = 0;
        return (UnityEngine.Camera)val_7;
    }
    public WGHintButtonDemoPopup()
    {
    
    }
    private static WGHintButtonDemoPopup()
    {
        WGHintButtonDemoPopup.shownTypeDict = new System.Collections.Generic.Dictionary<System.Type, System.Boolean>();
    }

}
