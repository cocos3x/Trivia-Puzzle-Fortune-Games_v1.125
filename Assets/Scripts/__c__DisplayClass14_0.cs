using UnityEngine;
private sealed class GridPlaceableShapeInfo.<>c__DisplayClass14_0
{
    // Fields
    public BlockPuzzleMagic.ShapeBlock rootShapeBlock;
    public System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> unconcealedBlocks;
    public System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> concealedBlocks;
    
    // Methods
    public GridPlaceableShapeInfo.<>c__DisplayClass14_0()
    {
    
    }
    internal bool <CanPlaceAtCurrentWorldPos>b__2(BlockPuzzleMagic.ShapeBlock n)
    {
        return (bool)(this.rootShapeBlock == n) ? 1 : 0;
    }

}
