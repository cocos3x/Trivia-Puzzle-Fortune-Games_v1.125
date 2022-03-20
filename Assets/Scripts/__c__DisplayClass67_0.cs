using UnityEngine;
private sealed class TRVDataParser.<>c__DisplayClass67_0
{
    // Fields
    public string questionID;
    
    // Methods
    public TRVDataParser.<>c__DisplayClass67_0()
    {
    
    }
    internal bool <GetQuestionFromID>b__1(QuestionData p)
    {
        if(p != null)
        {
                return System.String.op_Equality(a:  p.<questionID>k__BackingField, b:  this.questionID);
        }
        
        throw new NullReferenceException();
    }

}
