using UnityEngine;
private sealed class WordRegion.<>c__DisplayClass109_0
{
    // Fields
    public string targetWord;
    
    // Methods
    public WordRegion.<>c__DisplayClass109_0()
    {
    
    }
    internal bool <IsCellFoundInWord>b__0(LineWord x)
    {
        if(x != null)
        {
                return System.String.op_Equality(a:  x.answer, b:  this.targetWord);
        }
        
        throw new NullReferenceException();
    }

}
