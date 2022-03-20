using UnityEngine;

namespace BlockPuzzleMagic
{
    [Serializable]
    public class GoalIconSprite
    {
        // Fields
        public BlockPuzzleMagic.Goal.GoalType goalType;
        public BlockPuzzleMagic.CellImpedimentType cellImpedimentType;
        public UnityEngine.Sprite goalSprite;
        
        // Methods
        public GoalIconSprite()
        {
        
        }
    
    }

}
