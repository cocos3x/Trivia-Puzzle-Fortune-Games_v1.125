using UnityEngine;
private sealed class GoalDisplayIcon.<>c__DisplayClass23_0
{
    // Fields
    public BlockPuzzleMagic.Goal _goal;
    public BlockPuzzleMagic.GoalDisplayIcon <>4__this;
    
    // Methods
    public GoalDisplayIcon.<>c__DisplayClass23_0()
    {
    
    }
    internal bool <Initialize>b__0(BlockPuzzleMagic.GoalIconSprite obj)
    {
        return (bool)(obj.cellImpedimentType == this._goal.impedimentType) ? 1 : 0;
    }
    internal bool <Initialize>b__1(BlockPuzzleMagic.GoalIconSprite obj)
    {
        return (bool)(obj.goalType == (this.<>4__this.<goalType>k__BackingField)) ? 1 : 0;
    }

}
