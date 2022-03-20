using UnityEngine;

namespace BlockPuzzleMagic
{
    public class LevelRef
    {
        // Fields
        public int levelId;
        public System.Collections.Generic.List<BlockPuzzleMagic.GoalRef> goals;
        public int layoutId;
        public int stoneLayoutId;
        
        // Properties
        public bool HasStone { get; }
        
        // Methods
        public bool get_HasStone()
        {
            return (bool)(this.stoneLayoutId > 0) ? 1 : 0;
        }
        public LevelRef()
        {
        
        }
    
    }

}
