using UnityEngine;
private sealed class BBLOutOfLivesPopup.<>c__DisplayClass25_1
{
    // Fields
    public int curr;
    public BBLOutOfLivesPopup.<>c__DisplayClass25_0 CS$<>8__locals1;
    
    // Methods
    public BBLOutOfLivesPopup.<>c__DisplayClass25_1()
    {
    
    }
    internal void <CreditLife>b__0()
    {
        BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
        int val_3 = this.CS$<>8__locals1.amt;
        val_3 = val_1.livesBalance - val_3;
        val_3 = val_3 + this.curr;
        val_3 = val_3 + 1;
        string val_2 = val_3.ToString();
    }

}
