using UnityEngine;
public class WGHintMegaDemoPopup : WGHintButtonDemoPopup
{
    // Properties
    public static bool IsShowing { get; }
    
    // Methods
    public static bool get_IsShowing()
    {
        return WGHintButtonDemoPopup.IsShowingByType(_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
    }
    protected override void SetupButton()
    {
        mem[1152921517867920792] = MonoSingleton<AdsUIController>.Instance.MegaHintButtonGroup;
    }
    protected override void OnKeyBoardPress()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_190;
    }
    protected override void OnClick_UseHint()
    {
        this.OnClick_UseHint();
    }
    public WGHintMegaDemoPopup()
    {
        this = new UnityEngine.MonoBehaviour();
    }

}
