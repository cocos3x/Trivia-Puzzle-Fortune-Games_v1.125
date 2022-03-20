using UnityEngine;
public class LoadTimer : MonoSingletonSelfGenerating<LoadTimer>
{
    // Fields
    private System.Collections.Generic.List<string> loadTimes;
    private System.Collections.Generic.Dictionary<string, LoadTimer.LoadTimerData> timers;
    private bool stopOnLevelLoaded;
    private bool levelWasLoaded;
    
    // Methods
    public void StartTimer(string title, bool stopOnLevelWasLoaded = True)
    {
        if((this.timers.ContainsKey(key:  title)) != false)
        {
                return;
        }
        
        this.timers.Add(key:  title, value:  new LoadTimerData() {startTime = UnityEngine.Time.realtimeSinceStartup, stopOnLevelLoaded = stopOnLevelWasLoaded});
    }
    private void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  public System.Void LoadTimer::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
    }
    private void Update()
    {
        if(this.levelWasLoaded == false)
        {
                return;
        }
        
        this.StopTimersOnLevelWasLoaded();
        this.levelWasLoaded = false;
    }
    public void StopTimer(string stopSpecifiedTimer)
    {
        string val_8;
        float val_9;
        val_8 = "error";
        val_9 = -1000f;
        if((System.String.IsNullOrEmpty(value:  stopSpecifiedTimer)) != true)
        {
                if((this.timers.ContainsKey(key:  stopSpecifiedTimer)) != false)
        {
                float val_8 = UnityEngine.Time.realtimeSinceStartup;
            LoadTimerData val_4 = this.timers.Item[stopSpecifiedTimer];
            val_8 = val_8 - val_4.startTime;
            bool val_5 = this.timers.Remove(key:  stopSpecifiedTimer);
            val_8 = stopSpecifiedTimer;
            val_9 = val_8 * 1000f;
        }
        
        }
        
        this.loadTimes.Add(item:  val_8 + ", " + val_9.ToString(format:  "0.0000")(val_9.ToString(format:  "0.0000")) + "ms");
    }
    public void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        this.levelWasLoaded = true;
    }
    private void StopTimersOnLevelWasLoaded()
    {
        List.Enumerator<T> val_2 = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<System.String, LoadTimerData>>(collection:  this.timers).GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
            goto label_4;
        }
        
        this.StopTimer(stopSpecifiedTimer:  0);
        goto label_4;
        label_2:
        0.Dispose();
    }
    public string GetLoadTimeInfo()
    {
        var val_2;
        string val_3;
        val_2 = 0;
        val_3 = "";
        do
        {
            if(val_2 >= "")
        {
                return (string)val_3;
        }
        
            if(val_2 >= 44273376)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3 = val_3 + public CreatorPropertyContext List.Enumerator<CreatorPropertyContext>::get_Current()(public CreatorPropertyContext List.Enumerator<CreatorPropertyContext>::get_Current()) + "\n";
            val_2 = val_2 + 1;
        }
        while(this.loadTimes != null);
        
        throw new NullReferenceException();
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.remove_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  public System.Void LoadTimer::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    public LoadTimer()
    {
        this.loadTimes = new System.Collections.Generic.List<System.String>();
        this.timers = new System.Collections.Generic.Dictionary<System.String, LoadTimerData>();
    }

}
