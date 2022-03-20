using UnityEngine;
private sealed class GamePlay.<>c__DisplayClass27_1
{
    // Fields
    public int columnIndex;
    public BlockPuzzleMagic.GamePlay.<>c__DisplayClass27_0 CS$<>8__locals1;
    
    // Methods
    public GamePlay.<>c__DisplayClass27_1()
    {
    
    }
    internal bool <IsRowCompletelyFilled>b__0(BlockPuzzleMagic.GridCell o)
    {
        var val_2;
        if(o.rowId == (this.CS$<>8__locals1.rowID))
        {
                var val_1 = (o.columnId == this.columnIndex) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }

}
