using UnityEngine;
public class SRDebuggerShortcuts : MonoBehaviour
{
    // Fields
    private static SRDebuggerShortcuts.PinnedCheats pinnedCheats;
    
    // Methods
    public static void AddDebug()
    {
        if((MonoSingleton<SRDebugger_Instantiator>.Instance) != 0)
        {
                return;
        }
        
        SRDebugger_Instantiator val_4 = new UnityEngine.GameObject(name:  "SRDebugger Instantiator (Added Manually)").AddComponent<SRDebugger_Instantiator>();
    }
    public static void ShowDebugPanel()
    {
        var val_11;
        var val_12;
        var val_15;
        var val_6 = 0;
        val_11 = 1152921505014976520;
        val_6 = val_6 + 1;
        val_11 = 1152921505014976536;
        val_12 = 1;
        val_15 = SRDebug.Instance;
        if(SRDebug.Instance.IsDebugPanelVisible == false)
        {
            goto label_7;
        }
        
        var val_7 = 0;
        val_11 = 1152921505014976520;
        val_7 = val_7 + 1;
        val_11 = 1152921505014976536;
        goto label_11;
        label_7:
        var val_8 = 0;
        val_11 = 1152921505014976520;
        val_8 = val_8 + 1;
        val_12 = 8;
        goto label_15;
        label_11:
        val_12 = public System.Void SRDebugger.Services.IDebugService::HideDebugPanel();
        val_15 = ???;
        val_15.HideDebugPanel();
        return;
        label_15:
        val_15.ShowDebugPanel(requireEntryCode:  true);
    }
    public static void ToggleAllReelCheats()
    {
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_28;
        var val_30;
        object val_31;
        var val_32;
        var val_34;
        var val_36;
        var val_38;
        var val_40;
        var val_42;
        val_23 = 1152921504944386048;
        val_24 = null;
        val_24 = null;
        if(SRDebuggerShortcuts.pinnedCheats == 0)
        {
            goto label_3;
        }
        
        var val_16 = 0;
        val_25 = 1152921505014976520;
        val_16 = val_16 + 1;
        val_25 = 1152921505014976536;
        val_26 = 18;
        goto label_8;
        label_3:
        UnityEngine.Debug.Log(message:  "Pinning All Reel Cheats");
        val_28 = SRDebug.Instance;
        val_30 = 1152921505014939648;
        val_31 = SuperLuckySROptionsParent<SuperLuckySROptionsMain>.Instance;
        var val_17 = 0;
        val_25 = 1152921505014976520;
        val_17 = val_17 + 1;
        val_32 = 13;
        goto label_15;
        label_8:
        SRDebug.Instance.ClearPinnedOptions();
        val_34 = null;
        val_34 = null;
        SRDebuggerShortcuts.pinnedCheats = 0;
        var val_18 = 0;
        val_25 = 1152921505014976520;
        val_18 = val_18 + 1;
        val_25 = 1152921505014976536;
        val_26 = 13;
        val_36 = public System.Void SRDebugger.Services.IDebugService::RemoveOptionContainer(object container);
        SRDebug.Instance.RemoveOptionContainer(container:  SuperLuckySROptionsParent<SROptions_ReelCheats>.Instance);
        var val_19 = 0;
        val_25 = 1152921505014976520;
        val_19 = val_19 + 1;
        val_25 = 1152921505014976536;
        val_36 = 12;
        val_32 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        val_31 = ???;
        val_28 = ???;
        val_30 = ???;
        val_23 = ???;
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SuperLuckySROptionsMain>.Instance);
        return;
        label_15:
        val_38 = public System.Void SRDebugger.Services.IDebugService::RemoveOptionContainer(object container);
        val_28.RemoveOptionContainer(container:  val_31);
        var val_20 = 0;
        val_20 = val_20 + 1;
        val_38 = 12;
        val_40 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_ReelCheats>.Instance);
        var val_21 = 0;
        val_21 = val_21 + 1;
        val_40 = 14;
        SRDebug.Instance.PinAllOptions(category:  "Reel Results");
        val_42 = null;
        SRDebuggerShortcuts.pinnedCheats = 2;
    }
    public SRDebuggerShortcuts()
    {
    
    }
    private static SRDebuggerShortcuts()
    {
    
    }

}
