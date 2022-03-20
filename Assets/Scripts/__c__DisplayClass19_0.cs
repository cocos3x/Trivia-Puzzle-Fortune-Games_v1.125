using UnityEngine;
private sealed class WGEventProgressFlyInAwayPopup.<>c__DisplayClass19_0
{
    // Fields
    public WGEventHandler handler;
    
    // Methods
    public WGEventProgressFlyInAwayPopup.<>c__DisplayClass19_0()
    {
    
    }
    internal bool <SetUp>b__0(WGEventProgressFlyInAwayPopup.EventProgressPopupData d)
    {
        if(d != null)
        {
                return (bool)(d.eventHandler == this.handler) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
