using UnityEngine;
private sealed class GridPlaceableShapeInfo.<>c__DisplayClass14_2
{
    // Fields
    public int derivedRowIdForGridCell;
    public int derivedColIdForGridCell;
    
    // Methods
    public GridPlaceableShapeInfo.<>c__DisplayClass14_2()
    {
    
    }
    internal bool <CanPlaceAtCurrentWorldPos>b__3(BlockPuzzleMagic.GridCell o)
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
