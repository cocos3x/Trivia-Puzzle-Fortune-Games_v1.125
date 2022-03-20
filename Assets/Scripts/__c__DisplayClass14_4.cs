using UnityEngine;
private sealed class GridPlaceableShapeInfo.<>c__DisplayClass14_4
{
    // Fields
    public int derivedRowIdForGridCell;
    public int derivedColIdForGridCell;
    
    // Methods
    public GridPlaceableShapeInfo.<>c__DisplayClass14_4()
    {
    
    }
    internal bool <CanPlaceAtCurrentWorldPos>b__5(BlockPuzzleMagic.GridCell o)
    {
        if(o != null)
        {
                if(o.rowId != this.derivedRowIdForGridCell)
        {
                return false;
        }
        
            return (bool)(o.columnId == this.derivedColIdForGridCell) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
