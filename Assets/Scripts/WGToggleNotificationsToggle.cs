using UnityEngine;
public class WGToggleNotificationsToggle : WGMyToggle
{
    // Methods
    protected override void Start()
    {
        var val_3;
        this.Start();
        if(41963520 == 0)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        this.isOn = (twelvegigs.plugins.LocalNotificationsPlugin.notification_status == false) ? 1 : 0;
    }
    public override void OnToggleChange(bool state)
    {
        if(state != false)
        {
                twelvegigs.plugins.LocalNotificationsPlugin.DisableNotifications();
        }
        else
        {
                twelvegigs.plugins.LocalNotificationsPlugin.EnableNotifications();
        }
        
        state = state;
        this.OnToggleChange(state:  state);
    }
    public WGToggleNotificationsToggle()
    {
    
    }

}
