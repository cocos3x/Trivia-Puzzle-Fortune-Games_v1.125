using UnityEngine;
private sealed class WordRegion.<>c__DisplayClass75_0
{
    // Fields
    public string checkWord;
    
    // Methods
    public WordRegion.<>c__DisplayClass75_0()
    {
    
    }
    internal bool <CheckAnswer>b__0(LineWord x)
    {
        if(x != null)
        {
                return System.String.op_Equality(a:  x.answer, b:  this.checkWord);
        }
        
        throw new NullReferenceException();
    }

}
