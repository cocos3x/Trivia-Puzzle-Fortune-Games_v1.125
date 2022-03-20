using UnityEngine;
private sealed class GridCell.<>c__DisplayClass56_0
{
    // Fields
    public BlockPuzzleMagic.Block blockToDestroy;
    public BlockPuzzleMagic.GridCell <>4__this;
    
    // Methods
    public GridCell.<>c__DisplayClass56_0()
    {
    
    }
    internal void <ClearCell>b__1()
    {
        if(this.blockToDestroy != 0)
        {
                UnityEngine.Object.Destroy(obj:  this.blockToDestroy.gameObject);
        }
        
        this.<>4__this.RefreshVisualState();
    }

}
