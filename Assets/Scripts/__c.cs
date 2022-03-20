using UnityEngine;
[Serializable]
private sealed class PowerupEarthquakeButton.<>c
{
    // Fields
    public static readonly BlockPuzzleMagic.PowerupEarthquakeButton.<>c <>9;
    public static System.Func<bool> <>9__3_0;
    
    // Methods
    private static PowerupEarthquakeButton.<>c()
    {
        PowerupEarthquakeButton.<>c.<>9 = new PowerupEarthquakeButton.<>c();
    }
    public PowerupEarthquakeButton.<>c()
    {
    
    }
    internal bool <ShowFTUX>b__3_0()
    {
        bool val_2 = MonoSingleton<WGWindowManager>.Instance.HasQueuedWindows();
        val_2 = (~val_2) & 1;
        return (bool)val_2;
    }

}
