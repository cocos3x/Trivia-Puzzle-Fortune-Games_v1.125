using UnityEngine;
private sealed class BlockShapeSpawner.<>c__DisplayClass47_0
{
    // Fields
    public BlockPuzzleMagic.BlockShapeSpawner <>4__this;
    public int index;
    public BlockPuzzleMagic.ShapeInfo shape;
    public UnityEngine.Vector3 newPos;
    
    // Methods
    public BlockShapeSpawner.<>c__DisplayClass47_0()
    {
    
    }
    internal void <SetPowerupShape>b__0()
    {
        this.<>4__this.spawnedShapes[this.index].Alpha = 0f;
        BlockPuzzleMagic.ShapeInfo val_2 = this.<>4__this.spawnedShapes[this.index];
        this.<>4__this.spawnedShapes[this.index][0].neutralAlpha = 0f;
        this.<>4__this.spawnedShapes[this.index].Interactable = false;
    }
    internal void <SetPowerupShape>b__1()
    {
        UnityEngine.Transform val_1 = this.<>4__this.transform;
        this.shape.Interactable = true;
    }

}
