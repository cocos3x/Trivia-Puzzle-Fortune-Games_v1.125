using UnityEngine;
public class InstallRecapture : MonoSingleton<InstallRecapture>
{
    // Fields
    private bool isFeatureEnabled;
    private int levelThreshold;
    private string urlImage;
    private string message;
    private string urlStore;
    private bool notifBlasted;
    
    // Methods
    public override void InitMonoSingleton()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
    }
    private void OnServerSync()
    {
        string val_5;
        var val_6;
        var val_19;
        var val_20;
        var val_21;
        bool val_22;
        val_19 = null;
        val_19 = null;
        System.Collections.IDictionary val_1 = getInstallRecapture();
        if(val_1 == null)
        {
                return;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_3 = (((System.Collections.IDictionary.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_1) : 0.GetEnumerator();
        label_13:
        if(val_6.MoveNext() == false)
        {
            goto label_12;
        }
        
        val_20 = val_5;
        if((System.String.op_Inequality(a:  val_5, b:  "notification")) == true)
        {
            goto label_13;
        }
        
        new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
        val_6.Dispose();
        if(new twelvegigs.storage.JsonDictionary() == null)
        {
                return;
        }
        
        if((new twelvegigs.storage.JsonDictionary().getBool(key:  "enable")) == false)
        {
            goto label_21;
        }
        
        val_21 = null;
        val_21 = null;
        if(App.game != 17)
        {
            goto label_21;
        }
        
        Player val_11 = App.Player;
        var val_12 = (val_11.lifetimePlays < 2) ? 1 : 0;
        if(this != null)
        {
            goto label_25;
        }
        
        label_12:
        val_6.Dispose();
        return;
        label_21:
        val_22 = false;
        label_25:
        this.isFeatureEnabled = val_22;
        this.levelThreshold = new twelvegigs.storage.JsonDictionary().getInt(key:  "level", defaultValue:  0);
        this.urlImage = new twelvegigs.storage.JsonDictionary().getString(key:  "image", defaultValue:  0);
        val_20 = "";
        this.urlStore = new twelvegigs.storage.JsonDictionary().getString(key:  "url", defaultValue:  "");
        this.message = new twelvegigs.storage.JsonDictionary().getString(key:  "message", defaultValue:  "");
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnServerSync");
    }
    private void OnApplicationPause(bool pause)
    {
        if((InAppPurchasesManager.<inPurchaseIntent>k__BackingField) == true)
        {
                return;
        }
        
        if(pause == false)
        {
                return;
        }
        
        this.BlastRecaptureNotification();
    }
    public void OnApplicationQuit()
    {
        this.BlastRecaptureNotification();
    }
    private void BlastRecaptureNotification()
    {
        ulong val_5;
        var val_6;
        if(this.isFeatureEnabled == false)
        {
                return;
        }
        
        if(this.notifBlasted == true)
        {
                return;
        }
        
        if(App.Player > this.levelThreshold)
        {
                return;
        }
        
        val_6 = null;
        val_6 = null;
        if(TrackingComponent.currentIntent != 0)
        {
                return;
        }
        
        System.DateTime val_2 = System.DateTime.UtcNow;
        System.DateTime val_3 = val_2.dateData.AddSeconds(value:  5);
        val_5 = val_3.dateData;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "url", value:  this.urlStore);
        val_4.Add(key:  "notification_type", value:  "install_recapture");
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotifWithImage(type:  14, when:  new System.DateTime() {dateData = val_5}, interval:  0, title:  0, message:  this.message, extraData:  val_4, imageUrl:  this.urlImage, priority:  0, useTimeModifier:  true);
        this.notifBlasted = true;
    }
    public InstallRecapture()
    {
    
    }

}
