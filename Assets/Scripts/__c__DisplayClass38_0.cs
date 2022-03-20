using UnityEngine;
private sealed class BlockShapeSpawner.<>c__DisplayClass38_0
{
    // Fields
    public int shapeID;
    
    // Methods
    public BlockShapeSpawner.<>c__DisplayClass38_0()
    {
    
    }
    internal bool <CreateShapeWithID>b__0(BlockPuzzleMagic.ShapeBlockSpawn o)
    {
        if(o != null)
        {
                return (bool)(o.BlockID == this.shapeID) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
