using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GoalRef
    {
        // Fields
        public BlockPuzzleMagic.Goal.GoalType goalType;
        public BlockPuzzleMagic.CellImpedimentType impedimentType;
        public int targetValue;
        
        // Methods
        public GoalRef(BlockPuzzleMagic.Goal.GoalType _goalType, int _goalAmt, BlockPuzzleMagic.CellImpedimentType _impedimentType = 0)
        {
            this.goalType = _goalType;
            this.impedimentType = _impedimentType;
            this.targetValue = _goalAmt;
        }
    
    }

}
