using UnityEngine;
private sealed class GameReferenceData.<>c__DisplayClass22_0
{
    // Fields
    public BlockPuzzleMagic.BlockColorType colorType;
    
    // Methods
    public GameReferenceData.<>c__DisplayClass22_0()
    {
    
    }
    internal bool <GetBlockColor>b__0(BlockPuzzleMagic.BlockColor obj)
    {
        if(obj != null)
        {
                return (bool)(obj.blockColor == this.colorType) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
