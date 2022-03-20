using UnityEngine;
public class EventListItemContentVipParty : EventListItemContent
{
    // Fields
    private UnityEngine.UI.Text vipStatus;
    
    // Methods
    public void SetupVipStatus(bool isVIP)
    {
        string val_3 = Localization.Localize(key:  (isVIP != true) ? "vip_privileges_upper" : "become_vip_now_upper", defaultValue:  (isVIP != true) ? "VIP PRIVILEGES" : "BECOME VIP NOW", useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public EventListItemContentVipParty()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
