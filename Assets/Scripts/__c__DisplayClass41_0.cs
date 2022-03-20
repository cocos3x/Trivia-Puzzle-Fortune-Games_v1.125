using UnityEngine;
private sealed class AutopilotManager.<>c__DisplayClass41_0
{
    // Fields
    public int cameraInstanceID;
    
    // Methods
    public AutopilotManager.<>c__DisplayClass41_0()
    {
    
    }
    internal bool <ExecuteSelectableAction>b__1(twelvegigs.Autopilot.AutopilotButton aButton)
    {
        var val_3;
        if(aButton != 0)
        {
                var val_2 = ((aButton.<CameraId>k__BackingField) == this.cameraInstanceID) ? 1 : 0;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }

}
