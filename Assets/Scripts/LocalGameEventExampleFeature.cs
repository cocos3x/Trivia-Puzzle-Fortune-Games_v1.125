using UnityEngine;
public class LocalGameEventExampleFeature : LocalGameEventSpawner<LocalGameEventExampleFeature>
{
    // Fields
    private static bool showExample;
    private GameEventV2 myProxyEvent;
    
    // Methods
    public override void InitSpwaner()
    {
    
    }
    protected override bool CanAddProxyEvent()
    {
        return false;
    }
    protected override void PopulateProxyEvent(ref GameEventV2 proxyEvent)
    {
        this.myProxyEvent = proxyEvent;
    }
    protected override void UpdateProxyEventHandler(ref WGEventHandler proxyEventHandler)
    {
        goto mem[proxyEventHandler] + 752;
    }
    protected override bool ShouldRemoveProxyEvent(WGEventHandler handler)
    {
        return false;
    }
    protected override string GetProxyEventTrackingName()
    {
        return "LocalGameEventExampleFeature";
    }
    public LocalGameEventExampleFeature()
    {
    
    }
    private static LocalGameEventExampleFeature()
    {
    
    }

}
