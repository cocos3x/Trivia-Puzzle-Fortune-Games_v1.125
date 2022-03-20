using UnityEngine;
public class WGEventButtonProgressAttackMadness : WGEventButtonProgress
{
    // Properties
    private int PointsCollectedForCurrentLevel { get; }
    
    // Methods
    private int get_PointsCollectedForCurrentLevel()
    {
        return EnumerableExtentions.GetOrDefault<GameplayMode, System.Int32>(dic:  mem[12292196401200], key:  PlayingLevel.CurrentGameplayMode, defaultValue:  0);
    }
    public override void ShowIntroAnimation()
    {
        if(this.PointsCollectedForCurrentLevel < 1)
        {
                return;
        }
        
        this.ShowIntroAnimation();
    }
    public override void Initialize(WGEventHandler handler)
    {
        mem[1152921517496830040] = handler;
        goto typeof(WGEventButtonProgressAttackMadness).__il2cppRuntimeField_190;
    }
    public override void Refresh()
    {
        X20.alpha = (this.PointsCollectedForCurrentLevel > 0) ? 1f : 0f;
        goto typeof(WGEventButtonProgressAttackMadness).__il2cppRuntimeField_5E0;
    }
    public WGEventButtonProgressAttackMadness()
    {
        mem[1152921517497058144] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
