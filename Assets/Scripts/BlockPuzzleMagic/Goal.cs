using UnityEngine;

namespace BlockPuzzleMagic
{
    public class Goal
    {
        // Fields
        public BlockPuzzleMagic.Goal.GoalType goalType;
        public int targetValue;
        public int currentValue;
        public BlockPuzzleMagic.BlockColorType goalColorValue;
        public BlockPuzzleMagic.CellImpedimentType impedimentType;
        
        // Methods
        public Goal(BlockPuzzleMagic.Goal.GoalType _goalType, int _goalAmt, BlockPuzzleMagic.BlockColorType _colorType = 0, BlockPuzzleMagic.CellImpedimentType _cellImpedimentType = 0)
        {
            this.goalType = _goalType;
            this.targetValue = _goalAmt;
            this.currentValue = 0;
            this.goalColorValue = _colorType;
            this.impedimentType = _cellImpedimentType;
        }
        public static bool IsUnlocked(BlockPuzzleMagic.Goal.GoalType gType)
        {
            return true;
        }
        public static bool IsGoalColorBased(BlockPuzzleMagic.Goal.GoalType goalType)
        {
            return (bool)(goalType == 3) ? 1 : 0;
        }
    
    }

}
