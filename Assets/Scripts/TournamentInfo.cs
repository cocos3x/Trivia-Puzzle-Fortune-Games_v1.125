using UnityEngine;
public class TournamentInfo
{
    // Fields
    public int tierIndex;
    public System.DateTime endTime;
    public System.Collections.Generic.List<TournamentPlayer> tournamentPlayers;
    public TournamentPlayer me;
    public int myRank;
    public int myScore;
    
    // Methods
    public TournamentInfo()
    {
        this.tournamentPlayers = new System.Collections.Generic.List<TournamentPlayer>();
        this.myRank = -1;
        this.myScore = -1;
    }

}
