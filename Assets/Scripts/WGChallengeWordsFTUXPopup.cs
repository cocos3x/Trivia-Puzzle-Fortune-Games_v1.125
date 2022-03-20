using UnityEngine;
public class WGChallengeWordsFTUXPopup : WGHintButtonDemoPopup
{
    // Fields
    private UnityEngine.GameObject window;
    private UnityEngine.UI.Button collectButton;
    
    // Methods
    protected override void Start()
    {
        var val_26;
        int val_27;
        AdsUIController val_1 = MonoSingleton<AdsUIController>.Instance;
        val_1.onAdToggled.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGHintButtonDemoPopup::OnAdToggled()));
        val_26 = null;
        val_26 = null;
        EnumerableExtentions.SetOrAdd<System.Type, System.Boolean>(dic:  WGHintButtonDemoPopup.shownTypeDict, key:  this.GetType(), newValue:  true);
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGChallengeWordsFTUXPopup::<Start>b__2_0()));
        WordRegion val_5 = WordRegion.instance;
        WGChallengeWordsManager val_6 = MonoSingleton<WGChallengeWordsManager>.Instance;
        bool val_26 = val_6.progress.inited;
        if(val_26 != true)
        {
                val_6.progress.InitProgress();
        }
        
        if(val_26 <= val_6.progress._wordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_26 = val_26 + ((val_6.progress._wordIndex) << 3);
        mem[1152921517747141896] = (val_6.progress.inited + (val_6.progress._wordIndex) << 3) + 32.gameObject;
        UnityEngine.Vector3 val_10 = WGChallengeWordsFTUXPopup.GetWorldPosInSelCamera(selfTransform:  this.transform, targetTransform:  val_26.transform);
        UnityEngine.Vector3 val_13 = this.window.transform.position;
        UnityEngine.Vector3 val_15 = this.window.transform.position;
        UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  val_13.x, y:  val_10.y, z:  val_15.z);
        this.window.transform.position = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        UnityEngine.Color val_20 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.42f);
        System.Nullable<UnityEngine.Color> val_21 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_20.r, g = val_20.g, b = val_20.b, a = val_20.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
        UnityEngine.Transform[] val_23 = new UnityEngine.Transform[3];
        UnityEngine.Transform val_24 = transform;
        val_27 = val_23.Length;
        val_23[0] = val_24;
        if(val_24 != null)
        {
                val_27 = val_23.Length;
        }
        
        val_23[1] = val_24;
        val_23[2] = this.window.transform;
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_23);
    }
    private static UnityEngine.Camera GetCameraByTransform(UnityEngine.Transform obTranform)
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
    private static UnityEngine.Vector3 GetWorldPosInSelCamera(UnityEngine.Transform selfTransform, UnityEngine.Transform targetTransform)
    {
        UnityEngine.Vector3 val_3 = targetTransform.position;
        UnityEngine.Vector3 val_4 = WGChallengeWordsFTUXPopup.GetCameraByTransform(obTranform:  targetTransform).WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        return WGChallengeWordsFTUXPopup.GetCameraByTransform(obTranform:  selfTransform).ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
    }
    public WGChallengeWordsFTUXPopup()
    {
    
    }
    private void <Start>b__2_0()
    {
        MonoSingleton<WGChallengeWordsManager>.Instance.FinishFTUX();
        goto typeof(WGChallengeWordsFTUXPopup).__il2cppRuntimeField_1C0;
    }

}
