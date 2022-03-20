using UnityEngine;
private sealed class GamePlay.<>c__DisplayClass36_0
{
    // Fields
    public BlockPuzzleMagic.PowerUpType originatingPowerup;
    
    // Methods
    public GamePlay.<>c__DisplayClass36_0()
    {
    
    }
    internal void <CanUsePowerup>b__0()
    {
        var val_3 = this;
        if(this.originatingPowerup <= 3)
        {
                var val_3 = 32563416 + (this.originatingPowerup) << 2;
            val_3 = val_3 + 32563416;
        }
        else
        {
                WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false);
        }
    
    }

}
