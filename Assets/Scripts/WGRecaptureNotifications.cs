using UnityEngine;
public class WGRecaptureNotifications : MonoBehaviour
{
    // Fields
    private const string SENT_NOTIF = "wg_recapture_installed_sent_notif";
    public static System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> recaptureNotifications;
    private System.Collections.Generic.List<int> sentNotif;
    private System.DateTime lastPause;
    
    // Methods
    private void Awake()
    {
        object val_10;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                object[] val_3 = new object[1];
            val_10 = WGRecaptureNotifications.IsFirstDay().ToString();
            val_3[0] = val_10;
            UnityEngine.Debug.LogFormat(format:  "WGRecaptureNotifications Enabled IsFirstDay: {0}", args:  val_3);
        }
        
        object val_8 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "wg_recapture_installed_sent_notif", defaultValue:  "[]"));
        if(null < 1)
        {
                return;
        }
        
        var val_9 = 0;
        do
        {
            val_10 = this.sentNotif;
            if(null <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_10.Add(item:  0);
            val_9 = val_9 + 1;
        }
        while(val_9 < 1);
    
    }
    private void OnApplicationPause(bool pause)
    {
    
    }
    public static bool IsFirstDay()
    {
        Player val_1 = App.Player;
        System.DateTime val_2 = val_1.created_at.AddDays(value:  1);
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        return (bool)System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = val_3.dateData});
    }
    public void OnApplicationQuit()
    {
    
    }
    public void BlastRecaptureNotification()
    {
    
    }
    public int GetRandonNotif()
    {
        RecaptureType val_9;
        var val_10;
        var val_11;
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_9 = 0;
        goto label_1;
        label_7:
        if((val_1.CanShowNotif(type:  val_9)) != false)
        {
                val_1.Add(item:  0);
        }
        
        val_9 = 1;
        label_1:
        val_10 = null;
        val_10 = null;
        if(val_9 < (WGRecaptureNotifications.recaptureNotifications + 24))
        {
            goto label_7;
        }
        
        var val_9 = 1152921516081016528;
        System.Collections.Generic.List<TSource> val_4 = System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Except<System.Int32>(first:  val_1, second:  this.sentNotif));
        if((public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<System.Int32>(System.Collections.Generic.IEnumerable<TSource> source)) >= 1)
        {
                int val_5 = UnityEngine.Random.Range(min:  0, max:  -2041131504);
            if(val_9 <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_9 = val_9 + (val_5 << 2);
            val_11 = mem[(1152921516081016528 + (val_5) << 2) + 32];
            val_11 = (1152921516081016528 + (val_5) << 2) + 32;
            return (int)val_11;
        }
        
        System.Collections.Generic.List<TSource> val_7 = System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Intersect<System.Int32>(first:  this.sentNotif, second:  val_1));
        if((public static System.Collections.Generic.IEnumerable<TSource> System.Linq.Enumerable::Intersect<System.Int32>(System.Collections.Generic.IEnumerable<TSource> first, System.Collections.Generic.IEnumerable<TSource> second)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_11 = public System.Void ExposedList.Enumerator<Spine.ExposedList<System.Single>>::Dispose();
        bool val_8 = this.sentNotif.Remove(item:  1715526576);
        return (int)val_11;
    }
    private bool CanShowNotif(WGRecaptureNotifications.RecaptureType type)
    {
        UnityEngine.Object val_17;
        var val_18;
        val_17 = type;
        if(val_17 <= 4)
        {
                var val_17 = 32496716 + (type) << 2;
            val_17 = val_17 + 32496716;
        }
        else
        {
                val_18 = 0;
            return (bool)val_18 & 1;
        }
    
    }
    public WGRecaptureNotifications()
    {
        this.sentNotif = new System.Collections.Generic.List<System.Int32>();
        System.DateTime val_2 = System.DateTime.UtcNow;
        this.lastPause = val_2;
    }
    private static WGRecaptureNotifications()
    {
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "title", value:  "DAILY BONUS HERE!");
        val_2.Add(key:  "text", value:  "Get your free bonus now!");
        val_2.Add(key:  "amp", value:  "recapture_daily_bonus");
        val_2.Add(key:  "scene", value:  "default");
        val_1.Add(item:  val_2);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "title", value:  "DAILY CHALLENGE");
        val_3.Add(key:  "text", value:  "The Daily Challenge is waiting for you!");
        val_3.Add(key:  "amp", value:  "recapture_daily_challenge");
        val_3.Add(key:  "scene", value:  "challenge");
        val_1.Add(item:  val_3);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "title", value:  "TRAIN YOUR BRAIN");
        val_4.Add(key:  "text", value:  "Return and raise your IQ!");
        val_4.Add(key:  "amp", value:  "recapture_iq");
        val_4.Add(key:  "scene", value:  "game");
        val_1.Add(item:  val_4);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "title", value:  "NEW PUZZLES");
        val_5.Add(key:  "text", value:  "New puzzles are available!");
        val_5.Add(key:  "amp", value:  "recapture_new_puzzles");
        val_5.Add(key:  "scene", value:  "game");
        val_1.Add(item:  val_5);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_6.Add(key:  "title", value:  "IT GETS HARDER");
        val_6.Add(key:  "text", value:  "More challenging levels await!");
        val_6.Add(key:  "amp", value:  "recapture_it_gets_harder");
        val_6.Add(key:  "scene", value:  "game");
        val_1.Add(item:  val_6);
        WGRecaptureNotifications.recaptureNotifications = val_1;
    }

}
