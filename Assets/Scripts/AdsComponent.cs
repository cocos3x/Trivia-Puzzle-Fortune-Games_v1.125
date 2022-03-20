using UnityEngine;
public class AdsComponent : AppComponent
{
    // Properties
    public override bool RunInMainThread { get; }
    
    // Methods
    public override bool get_RunInMainThread()
    {
        return true;
    }
    public AdsComponent(string gameName, string gameObjectName)
    {
        mem[1152921515559813872] = "AdsComponent";
    }
    public static bool isComponentRequired()
    {
        return true;
    }
    public override void initializeOnMainThread()
    {
        if((MonoSingletonSelfGenerating<AdsManager>.Instance) != 0)
        {
                return;
        }
        
        UnityEngine.Debug.LogError(message:  "Con una chin...");
    }

}
