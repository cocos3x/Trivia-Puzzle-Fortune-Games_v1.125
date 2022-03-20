using UnityEngine;
private sealed class MinigameManager.<>c__DisplayClass64_0
{
    // Fields
    public SLC.Minigames.MinigameManager <>4__this;
    public SLC.Minigames.MinigameLevelRank currentRank;
    
    // Methods
    public MinigameManager.<>c__DisplayClass64_0()
    {
    
    }
    internal bool <HandleLevelComplete>b__0(int x)
    {
        int val_2 = this.currentRank.rankLevel;
        val_2 = val_2 + x;
        return (bool)((this.<>4__this.currentPlayerLevel) >= val_2) ? 1 : 0;
    }
    internal bool <HandleLevelComplete>b__1(SLC.Minigames.MinigameLevelRank x)
    {
        return (bool)((this.<>4__this.currentPlayerLevel) >= x.rankLevel) ? 1 : 0;
    }

}
