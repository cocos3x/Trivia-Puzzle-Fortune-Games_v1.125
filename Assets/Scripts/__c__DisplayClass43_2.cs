using UnityEngine;
private sealed class LightningLevelsEventHandler.<>c__DisplayClass43_2
{
    // Fields
    public WGLightningLevelsPopup rewardPopup;
    
    // Methods
    public LightningLevelsEventHandler.<>c__DisplayClass43_2()
    {
    
    }
    internal bool <DoLevelCompleteEventProgressAnimation>b__3()
    {
        var val_5;
        if(this.rewardPopup == 0)
        {
                val_5 = 1;
        }
        else
        {
                bool val_3 = this.rewardPopup.gameObject.activeSelf;
            val_5 = val_3 ^ 1;
        }
        
        val_3 = val_5;
        return (bool)val_3;
    }

}
