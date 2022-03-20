using UnityEngine;
private sealed class GamePlay.<>c__DisplayClass31_0
{
    // Fields
    public BlockPuzzleMagic.Goal currentGoal;
    
    // Methods
    public GamePlay.<>c__DisplayClass31_0()
    {
    
    }
    internal bool <UpdateGoalProgress>b__1(BlockPuzzleMagic.GridCell obj)
    {
        var val_5;
        if(obj.isFilled != false)
        {
                if((obj.<ChildBlock>k__BackingField.fillColorType) != this.currentGoal.goalColorValue)
        {
                return (bool)((obj.<ChildBlock>k__BackingField.fillColorType) == 1) ? 1 : 0;
        }
        
            val_5 = 1;
            return (bool)((obj.<ChildBlock>k__BackingField.fillColorType) == 1) ? 1 : 0;
        }
        
        val_5 = 0;
        return (bool)((obj.<ChildBlock>k__BackingField.fillColorType) == 1) ? 1 : 0;
    }

}
