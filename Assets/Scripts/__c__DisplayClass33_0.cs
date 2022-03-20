using UnityEngine;
private sealed class GamePlay.<>c__DisplayClass33_0
{
    // Fields
    public int adjustedRowIdForBlock;
    public int adjustedColIdForBlock;
    
    // Methods
    public GamePlay.<>c__DisplayClass33_0()
    {
    
    }
    internal bool <CheckShapeCanPlace>b__0(BlockPuzzleMagic.GridCell o)
    {
        if(o != null)
        {
                if(o.rowId != this.adjustedRowIdForBlock)
        {
                return false;
        }
        
            return (bool)(o.columnId == this.adjustedColIdForBlock) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
