using UnityEngine;
private sealed class PuzzleCollectionHandler.<>c__DisplayClass114_0
{
    // Fields
    public int i;
    public PuzzleCollectionHandler <>4__this;
    
    // Methods
    public PuzzleCollectionHandler.<>c__DisplayClass114_0()
    {
    
    }
    internal bool <GetNewPuzzleName>b__0(string n)
    {
        return System.String.op_Inequality(a:  n, b:  this.<>4__this.CompletedPuzzles[this.i]);
    }

}
