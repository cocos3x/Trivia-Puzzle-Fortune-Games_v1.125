using UnityEngine;
public class WGUnlockableUIElementByLevel : WGUnlockableUIElement
{
    // Fields
    private int unlockLevel;
    private int unhideLevel;
    
    // Properties
    protected override bool FeatureHidden { get; }
    protected override bool FeatureLocked { get; }
    protected override int UnlockLevel { get; }
    
    // Methods
    protected override bool get_FeatureHidden()
    {
        GameBehavior val_1 = App.getBehavior;
        return (bool)((val_1.<metaGameBehavior>k__BackingField) < this.unhideLevel) ? 1 : 0;
    }
    protected override bool get_FeatureLocked()
    {
        GameBehavior val_1 = App.getBehavior;
        return (bool)((val_1.<metaGameBehavior>k__BackingField) < this.unlockLevel) ? 1 : 0;
    }
    protected override int get_UnlockLevel()
    {
        return (int)this.unlockLevel;
    }
    public WGUnlockableUIElementByLevel()
    {
        mem[1152921517998940552] = 1;
        mem[1152921517998940588] = 0;
        val_1 = new FrameSkipper();
    }

}
