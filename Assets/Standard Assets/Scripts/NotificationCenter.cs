using UnityEngine;
public class NotificationCenter : MonoBehaviour
{
    // Fields
    private static bool isQuitting;
    private static NotificationCenter defaultCenter;
    private static UnityEngine.GameObject objectContainer;
    private System.Collections.Hashtable notifications;
    
    // Properties
    public static NotificationCenter DefaultCenter { get; }
    
    // Methods
    private void Awake()
    {
        UnityEngine.GameObject val_6;
        var val_7;
        var val_8;
        val_6 = 1152921504858230784;
        val_7 = null;
        val_7 = null;
        if(NotificationCenter.objectContainer != 0)
        {
                val_8 = null;
            val_8 = null;
            val_6 = NotificationCenter.objectContainer;
            if(this.gameObject != val_6)
        {
                UnityEngine.Object.Destroy(obj:  this.gameObject);
            return;
        }
        
        }
        
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void NotificationCenter::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        null = null;
        if(NotificationCenter.objectContainer == this.gameObject)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.remove_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void NotificationCenter::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    public static NotificationCenter get_DefaultCenter()
    {
        var val_5;
        var val_6;
        var val_7;
        var val_8;
        if(UnityEngine.Application.isPlaying != false)
        {
                val_5 = null;
            val_5 = null;
            if((UnityEngine.Object.op_Implicit(exists:  NotificationCenter.defaultCenter)) != true)
        {
                val_6 = null;
            val_6 = null;
            if(NotificationCenter.isQuitting != true)
        {
                UnityEngine.GameObject val_3 = new UnityEngine.GameObject(name:  "Default Notification Center");
            val_7 = null;
            val_7 = null;
            NotificationCenter.objectContainer = val_3;
            NotificationCenter.defaultCenter = val_3.AddComponent<NotificationCenter>();
            UnityEngine.Object.DontDestroyOnLoad(target:  val_3);
        }
        
        }
        
        }
        
        val_8 = null;
        val_8 = null;
        return (NotificationCenter)NotificationCenter.defaultCenter;
    }
    public void OnApplicationQuit()
    {
        null = null;
        NotificationCenter.isQuitting = true;
    }
    public void AddObserver(UnityEngine.Component observer, string name)
    {
        this.AddObserver(observer:  observer, name:  name, sender:  null);
    }
    public void AddObserver(UnityEngine.Component observer, string name, UnityEngine.Component sender)
    {
        if((System.String.IsNullOrEmpty(value:  name)) == true)
        {
                return;
        }
        
        if(this.notifications == null)
        {
                System.Collections.Generic.List<UnityEngine.Component> val_2 = new System.Collections.Generic.List<UnityEngine.Component>();
        }
        
        if((this.notifications.Contains(item:  observer)) != false)
        {
                return;
        }
        
        this.notifications.Add(item:  observer);
    }
    public void RemoveObserver(UnityEngine.Component observer, string name)
    {
        var val_3;
        if(this.notifications == null)
        {
                return;
        }
        
        val_3 = this.notifications;
        if((val_3.Contains(item:  observer)) != false)
        {
                bool val_2 = val_3.Remove(item:  observer);
        }
        
        if(this.notifications.count != 0)
        {
                return;
        }
        
        val_3 = ???;
        goto typeof(System.Collections.Hashtable).__il2cppRuntimeField_3A0;
    }
    public void PostNotificationDelayed(UnityEngine.Component aSender, string aName, System.Collections.Hashtable aData, float delay = 1)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.PostNotificationDelay(aSender:  aSender, aName:  aName, aData:  aData, delay:  delay));
    }
    private System.Collections.IEnumerator PostNotificationDelay(UnityEngine.Component aSender, string aName, System.Collections.Hashtable aData, float delay = 1)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .aSender = aSender;
        .aName = aName;
        .aData = aData;
        .delay = delay;
        return (System.Collections.IEnumerator)new NotificationCenter.<PostNotificationDelay>d__14();
    }
    public void PostNotification(UnityEngine.Component aSender, string aName)
    {
        this.PostNotification(aSender:  aSender, aName:  aName, aData:  0);
    }
    public void PostNotification(UnityEngine.Component aSender, string aName, System.Collections.Hashtable aData)
    {
        .sender = aSender;
        .name = aName;
        .data = aData;
        this.PostNotification(aNotification:  new Notification());
    }
    public void PostNotification(Notification aNotification)
    {
        var val_7;
        Notification val_8 = aNotification;
        if((System.String.IsNullOrEmpty(value:  aNotification.name)) == true)
        {
                return;
        }
        
        if(this.notifications == null)
        {
                return;
        }
        
        System.Collections.Generic.List<UnityEngine.Component> val_2 = new System.Collections.Generic.List<UnityEngine.Component>();
        if(this.notifications.count >= 1)
        {
                var val_8 = 0;
            do
        {
            if(val_8 >= this.notifications.count)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            bucket val_7 = this.notifications.buckets[val_8];
            if((UnityEngine.Object.op_Implicit(exists:  val_7)) != false)
        {
                val_7.SendMessage(methodName:  aNotification.name, value:  val_8 = aNotification, options:  1);
        }
        else
        {
                val_2.Add(item:  val_7);
        }
        
            val_8 = val_8 + 1;
        }
        while(val_8 < this.notifications.count);
        
        }
        
        List.Enumerator<T> val_4 = val_2.GetEnumerator();
        val_8 = 1152921510471087616;
        val_7 = 1152921510470320768;
        label_18:
        if(0.MoveNext() == false)
        {
            goto label_17;
        }
        
        bool val_6 = this.notifications.Remove(item:  0);
        goto label_18;
        label_17:
        0.Dispose();
    }
    public NotificationCenter()
    {
        this.notifications = new System.Collections.Hashtable();
    }
    private static NotificationCenter()
    {
    
    }

}
