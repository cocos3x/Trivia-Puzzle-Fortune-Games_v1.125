using UnityEngine;
public class WGHintPickerDemoPopup : WGHintButtonDemoPopup
{
    // Fields
    private WGHintPickerButton pickerButton;
    
    // Properties
    public static bool IsShowing { get; }
    
    // Methods
    public static bool get_IsShowing()
    {
        return WGHintButtonDemoPopup.IsShowingByType(_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
    }
    protected override void Start()
    {
        this.Start();
        HintPickerController val_1 = MonoSingleton<HintPickerController>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnPickOverlayStateChanged, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGHintPickerDemoPopup::OnPickOverlayStateChanged(bool isOverlayVisible)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnPickOverlayStateChanged = val_3;
        return;
        label_5:
    }
    protected override void OnDestroy()
    {
        this.OnDestroy();
        HintPickerController val_1 = MonoSingleton<HintPickerController>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnPickOverlayStateChanged, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGHintPickerDemoPopup::OnPickOverlayStateChanged(bool isOverlayVisible)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnPickOverlayStateChanged = val_3;
        if(this.pickerButton == 0)
        {
                return;
        }
        
        this.pickerButton.UpdateDisplay();
        return;
        label_5:
    }
    protected override void SetupButton()
    {
        mem[1152921517868845080] = MonoSingleton<AdsUIController>.Instance.PickerHintButtonGroup;
        HintPickerController val_3 = MonoSingleton<HintPickerController>.Instance;
        WGHintPickerButton val_4 = val_3.gameHintPickerButton.GetComponent<WGHintPickerButton>();
        this.pickerButton = val_4;
        if(val_4 == 0)
        {
                return;
        }
        
        this.pickerButton.UpdateDisplay();
    }
    protected override void OnKeyBoardPress()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_1A0;
    }
    private void OnPickOverlayStateChanged(bool isOverlayVisible)
    {
        MonoSingleton<GameMaskOverlay>.Instance.Alpha = (isOverlayVisible != true) ? 0f : 1f;
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = (~isOverlayVisible) & 1;
    }
    public WGHintPickerDemoPopup()
    {
        this = new UnityEngine.MonoBehaviour();
    }

}
