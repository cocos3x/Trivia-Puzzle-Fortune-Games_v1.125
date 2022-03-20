using UnityEngine;
private sealed class WGDailyChallengeWordRegion.<>c__DisplayClass54_0
{
    // Fields
    public string checkWord;
    
    // Methods
    public WGDailyChallengeWordRegion.<>c__DisplayClass54_0()
    {
    
    }
    internal bool <CheckAnswerBetter>b__0(LineWord x)
    {
        if(x != null)
        {
                return System.String.op_Equality(a:  x.answer, b:  this.checkWord);
        }
        
        throw new NullReferenceException();
    }

}
