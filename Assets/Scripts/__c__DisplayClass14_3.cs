using UnityEngine;
private sealed class GridPlaceableShapeInfo.<>c__DisplayClass14_3
{
    // Fields
    public int i;
    public BlockPuzzleMagic.GridPlaceableShapeInfo.<>c__DisplayClass14_0 CS$<>8__locals2;
    
    // Methods
    public GridPlaceableShapeInfo.<>c__DisplayClass14_3()
    {
    
    }
    internal bool <CanPlaceAtCurrentWorldPos>b__6(BlockPuzzleMagic.ShapeBlock n)
    {
        GridPlaceableShapeInfo.<>c__DisplayClass14_0 val_2 = this.CS$<>8__locals2;
        if(val_2 <= this.i)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + ((this.i) << 3);
        return (bool)(((this.CS$<>8__locals2 + (this.i) << 3).concealedBlocks) == n) ? 1 : 0;
    }

}
