using UnityEngine;
public class FOMOPackEventFeature : LocalGameEventSpawner<FOMOPackEventFeature>
{
    // Fields
    private static bool showFOMO;
    private GameEventV2 myProxyEvent;
    
    // Methods
    public override void InitSpwaner()
    {
    
    }
    protected override bool CanAddProxyEvent()
    {
        return (bool)((FOMOPackEventHandler.<Instance>k__BackingField) == 0) ? 1 : 0;
    }
    protected override void PopulateProxyEvent(ref GameEventV2 proxyEvent)
    {
        null = null;
        timeEnd = System.DateTime.MaxValue;
        timeExpire = System.DateTime.MaxValue;
        this.myProxyEvent = proxyEvent;
    }
    protected override void UpdateProxyEventHandler(ref WGEventHandler proxyEventHandler)
    {
        goto mem[proxyEventHandler] + 752;
    }
    protected override bool ShouldRemoveProxyEvent(WGEventHandler handler)
    {
        goto typeof(WGEventHandler).__il2cppRuntimeField_4F0;
    }
    protected override object AddProxyEventTrackingData(ref System.Collections.Generic.Dictionary<string, object> trackingData)
    {
        return (object)trackingData;
    }
    protected override string GetProxyEventTrackingName()
    {
        return "FOMO pack";
    }
    public FOMOPackEventFeature()
    {
    
    }
    private static FOMOPackEventFeature()
    {
        FOMOPackEventFeature.showFOMO = true;
    }

}
