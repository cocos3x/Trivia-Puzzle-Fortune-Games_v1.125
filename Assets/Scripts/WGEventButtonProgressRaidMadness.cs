using UnityEngine;
public class WGEventButtonProgressRaidMadness : WGEventButtonProgress
{
    // Properties
    private int PointsCollectedForCurrentLevel { get; }
    
    // Methods
    private int get_PointsCollectedForCurrentLevel()
    {
        return 0;
    }
    public override void Initialize(WGEventHandler handler)
    {
        mem[1152921517499551096] = handler;
        goto typeof(WGEventButtonProgressRaidMadness).__il2cppRuntimeField_190;
    }
    public override void ShowIntroAnimation()
    {
        if(this.PointsCollectedForCurrentLevel < 1)
        {
                return;
        }
        
        this.ShowIntroAnimation();
    }
    public override void Refresh()
    {
        WordForest.WFOMysteryChestDisplay val_1 = MonoSingleton<WordForest.WFOMysteryChestDisplay>.Instance;
        bool val_2 = UnityEngine.Object.op_Inequality(x:  val_1, y:  0);
        if(val_2 != true)
        {
                if(WFOEventPointGainAnimationV2.IsActive == false)
        {
            goto label_6;
        }
        
        }
        
        label_12:
        val_2.alpha = 1f;
        val_1.interactable = (val_1.alpha >= 1f) ? 1 : 0;
        this = ???;
        goto typeof(WGEventButtonProgressRaidMadness).__il2cppRuntimeField_5E0;
        label_6:
        var val_6 = (this.PointsCollectedForCurrentLevel > 0) ? 1f : 0f;
        goto label_12;
    }
    public WGEventButtonProgressRaidMadness()
    {
        mem[1152921517499899392] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
