using UnityEngine;
private sealed class GamePlay.<>c__DisplayClass28_1
{
    // Fields
    public int rowIndex;
    public BlockPuzzleMagic.GamePlay.<>c__DisplayClass28_0 CS$<>8__locals1;
    
    // Methods
    public GamePlay.<>c__DisplayClass28_1()
    {
    
    }
    internal bool <IsColumnCompletelyFilled>b__0(BlockPuzzleMagic.GridCell o)
    {
        var val_2;
        if(o.rowId == this.rowIndex)
        {
                var val_1 = (o.columnId == (this.CS$<>8__locals1.columnID)) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }

}
