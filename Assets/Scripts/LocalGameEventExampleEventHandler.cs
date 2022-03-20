using UnityEngine;
public class LocalGameEventExampleEventHandler : WGEventHandler
{
    // Methods
    public void SetupSomeStuffFromFeature(string whateverFeatureInfo = "")
    {
    
    }
    public override string GetEventDisplayName()
    {
        return "LOCAL GAME EVENT EXAMPLE";
    }
    public override string GetMainMenuButtonText()
    {
        return "LOCAL GAME EVENT EXAMPLE";
    }
    public override string GetGameButtonText()
    {
        return "LOCAL GAME EVENT EXAMPLE";
    }
    public LocalGameEventExampleEventHandler()
    {
    
    }

}
