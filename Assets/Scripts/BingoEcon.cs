using UnityEngine;
public class BingoEventHandler.BingoEcon
{
    // Fields
    public int maxBingoCalls;
    public int maxBallsPerLevel;
    public int ballLevelIntervall;
    public bool purchasersOnly;
    public int basePrize;
    
    // Methods
    public BingoEventHandler.BingoEcon()
    {
        this.ballLevelIntervall = 1;
        this.maxBingoCalls = 24;
        this.maxBallsPerLevel = 1;
        this.basePrize = 100;
    }

}
