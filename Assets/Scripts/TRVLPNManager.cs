using UnityEngine;
public class TRVLPNManager : FrameSkipper
{
    // Fields
    private const string PP_Sent_TRV_KEEPP = "PP_Sent_TRV_KEEPP";
    private const int frequency = 30;
    
    // Methods
    private void Start()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "PP_Sent_TRV_KEEPP")) != false)
        {
                UnityEngine.Object.Destroy(obj:  this.gameObject);
            return;
        }
        
        mem[1152921517271410112] = 300;
    }
    protected override void UpdateLogic()
    {
        this.SendNotification();
    }
    private void SendNotification()
    {
        UnityEngine.Object val_12;
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  29);
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.DateTime val_2 = val_1.dateData.Date;
        Player val_3 = App.Player;
        System.DateTime val_4 = val_3.created_at.Date;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = val_4.dateData})) != false)
        {
                val_12 = this.gameObject;
            UnityEngine.Object.Destroy(obj:  val_12);
            return;
        }
        
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        System.DateTime val_8 = val_7.dateData.AddMinutes(value:  30);
        val_12 = val_8.dateData;
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  29, when:  new System.DateTime() {dateData = val_12}, optMessage:  System.String.Format(format:  "Keep playing!{0}Your next question is ready!", arg0:  System.Environment.NewLine), extraData:  0);
        UnityEngine.PlayerPrefs.SetInt(key:  "PP_Sent_TRV_KEEPP", value:  10);
        bool val_11 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public TRVLPNManager()
    {
    
    }

}
