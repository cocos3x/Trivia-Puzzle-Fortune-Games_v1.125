using UnityEngine;
private sealed class BingoEventPopup.<>c__DisplayClass40_3
{
    // Fields
    public UnityEngine.GameObject ballGO;
    
    // Methods
    public BingoEventPopup.<>c__DisplayClass40_3()
    {
    
    }
    internal void <CollectBallsAnimation>b__2()
    {
        if(this.ballGO != null)
        {
                this.ballGO.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }

}
