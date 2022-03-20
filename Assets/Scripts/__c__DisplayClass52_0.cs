using UnityEngine;
private sealed class BBLGameplayUIController.<>c__DisplayClass52_0
{
    // Fields
    public BlockPuzzleMagic.FtuxId stageToShow;
    public UnityEngine.GameObject target;
    
    // Methods
    public BBLGameplayUIController.<>c__DisplayClass52_0()
    {
    
    }
    internal void <CheckShowFTUXOnInputResolved>b__0()
    {
        BlockPuzzleMagic.BBLGameplayUIHelper.CloseGameplayOverlay(immediate:  false, onOverlayClosed:  0);
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<FTUXDemoWindow>(showNext:  false).ShowFTUXStep(stage:  this.stageToShow, targetGO:  this.target);
    }

}
