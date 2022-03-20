using UnityEngine;
private sealed class BlockShapeSpawner.<>c__DisplayClass35_0
{
    // Fields
    public int randomShapeId;
    public System.Predicate<BlockPuzzleMagic.ShapeBlockSpawn> <>9__0;
    
    // Methods
    public BlockShapeSpawner.<>c__DisplayClass35_0()
    {
    
    }
    internal bool <GetRandomShapeIds>b__0(BlockPuzzleMagic.ShapeBlockSpawn o)
    {
        if(o != null)
        {
                return (bool)(o.BlockID == this.randomShapeId) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
