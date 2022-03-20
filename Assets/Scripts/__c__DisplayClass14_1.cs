using UnityEngine;
private sealed class GridPlaceableShapeInfo.<>c__DisplayClass14_1
{
    // Fields
    public int i;
    public BlockPuzzleMagic.GridPlaceableShapeInfo.<>c__DisplayClass14_0 CS$<>8__locals1;
    
    // Methods
    public GridPlaceableShapeInfo.<>c__DisplayClass14_1()
    {
    
    }
    internal bool <CanPlaceAtCurrentWorldPos>b__4(BlockPuzzleMagic.ShapeBlock n)
    {
        GridPlaceableShapeInfo.<>c__DisplayClass14_0 val_2 = this.CS$<>8__locals1;
        if(val_2 <= this.i)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + ((this.i) << 3);
        return (bool)(((this.CS$<>8__locals1 + (this.i) << 3).concealedBlocks) == n) ? 1 : 0;
    }

}
