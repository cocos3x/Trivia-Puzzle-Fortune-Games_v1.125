using UnityEngine;
public struct LoadTimer.LoadTimerData
{
    // Fields
    public float startTime;
    public bool stopOnLevelLoaded;
    
    // Methods
    public LoadTimer.LoadTimerData(bool stopOnLevelWasLoaded)
    {
        this = UnityEngine.Time.realtimeSinceStartup;
        this.stopOnLevelLoaded = stopOnLevelWasLoaded;
    }

}
