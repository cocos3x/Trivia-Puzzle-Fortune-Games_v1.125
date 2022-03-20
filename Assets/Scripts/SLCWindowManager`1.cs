using UnityEngine;
public class SLCWindowManager<T> : MonoSingleton<T>
{
    // Fields
    public static string UGUI_Monolith_Window_Close;
    private static UnityEngine.Camera m_gameplayCamera;
    protected static UnityEngine.Camera m_monolithPopupCamera;
    private PrefabsFromFolder prefabsFromFolder;
    public WGWindowBackgroundHandler backgroundHandler;
    private System.Collections.Generic.Queue<UnityEngine.GameObject> uguiWindowQueue;
    private System.Collections.Generic.Dictionary<string, UnityEngine.GameObject> windows;
    private UnityEngine.GameObject currentWindow;
    private SLCWindowSetting currentWindowSetting;
    private UnityEngine.Coroutine waitingForGeneration;
    public UnityEngine.Events.UnityEvent onWindowClosed;
    public OnWindowOpenedEvent onWindowOpened;
    private UnityEngine.GameObject gc_window;
    private string debugQueue;
    private UnityEngine.GameObject[] debugQueueArray;
    public const string color_screen = "#F37CBE";
    protected const string color_show_window = "#E973EE";
    protected const string color_activating = "#E9991D";
    protected const string color_enqueue = "#23D5F5";
    protected const string color_on_window_closed = "#D7F377";
    protected const string color_show_available_popups = "#99BBCC";
    private string debugOps;
    
    // Properties
    protected virtual System.Type myWindowType { get; }
    public static UnityEngine.Camera gameplayCamera { get; }
    public static UnityEngine.Camera monolithPopupCamera { get; }
    public UnityEngine.GameObject CurrentWindow { get; }
    
    // Methods
    protected virtual System.Type get_myWindowType()
    {
        return System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
    }
    public static UnityEngine.Camera get_gameplayCamera()
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_3 & 1) == 0)
        {
                val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184 + 8) == 0)
        {
                val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_4 & 1) == 0)
        {
                val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            mem2[0] = UnityEngine.Camera.main;
        }
        
        val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_5 & 1) == 0)
        {
                val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) != 0)
        {
                return (UnityEngine.Camera)__RuntimeMethodHiddenParam + 24 + 192 + 184 + 8;
        }
        
        return (UnityEngine.Camera)__RuntimeMethodHiddenParam + 24 + 192 + 184 + 8;
    }
    public static UnityEngine.Camera get_monolithPopupCamera()
    {
        var val_5;
        var val_6;
        var val_7;
        val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_5 & 1) == 0)
        {
                val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184 + 16) == 0)
        {
                val_6 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_6 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_6 & 1) == 0)
        {
                val_6 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_6 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            mem2[0] = MonoSingleton<WGWindowManager>.Instance.transform.GetComponentInChildren<UnityEngine.Camera>();
        }
        
        val_7 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_7 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_7 & 1) == 0)
        {
                val_7 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_7 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) != 0)
        {
                return (UnityEngine.Camera)__RuntimeMethodHiddenParam + 24 + 192 + 184 + 16;
        }
        
        return (UnityEngine.Camera)__RuntimeMethodHiddenParam + 24 + 192 + 184 + 16;
    }
    public override void InitMonoSingleton()
    {
        var val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_3 & 1) == 0)
        {
                val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  __RuntimeMethodHiddenParam + 24 + 192 + 184);
        mem2[0] = UnityEngine.Camera.main;
    }
    public UnityEngine.GameObject get_CurrentWindow()
    {
        return (UnityEngine.GameObject)this;
    }
    public bool HasQueuedWindows()
    {
        return (bool)(0 > 0) ? 1 : 0;
    }
    public int GetActiveAndQueuedWindowCount()
    {
        return 0;
    }
    public void ShowWindow()
    {
        UnityEngine.Object val_11;
        var val_12;
        if(0 < 1)
        {
                return;
        }
        
        UnityEngine.GameObject val_1 = this.Peek();
        mem[1152921517640338232] = val_1;
        val_11 = val_1;
        if(val_11 == 0)
        {
                return;
        }
        
        SLCWindowSetting val_5 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.15f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  __RuntimeMethodHiddenParam + 24 + 192 + 24), ignoreTimeScale:  true).GetComponent<SLCWindowSetting>();
        mem[1152921517640338240] = val_5;
        SLCWindow val_6 = GetComponent<SLCWindow>();
        val_6.Setup(settings:  val_5);
        string val_8 = "activating " + val_6.name;
        bool val_9 = UnityEngine.Object.op_Inequality(x:  __RuntimeMethodHiddenParam, y:  0);
        if(val_9 != false)
        {
                var val_10 = (((UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 24 & 4294967294)) == 6) ? 1 : 0;
        }
        else
        {
                val_12 = 0;
        }
        
        val_9.Invoke(arg0:  false);
        val_9.HandleWindowShowing(setting:  val_5);
    }
    private void OnWGWindowClosed(Notification n)
    {
        var val_13;
        System.Type val_14;
        val_13 = n;
        val_14 = this;
        if((System.Type.op_Inequality(left:  n.sender.GetType(), right:  this)) == true)
        {
                return;
        }
        
        string val_4 = "window closed " + n.sender.name;
        if("#D7F377" < 1)
        {
                return;
        }
        
        mem[1152921517640508792] = 0;
        this.Dequeue().Invoke();
        if((val_14 & 1) != 0)
        {
                val_14 = ???;
            val_13 = ???;
        }
        else
        {
                this.CloseBackgrounds();
        }
    
    }
    public void CloseCurrentWindow()
    {
        bool val_1 = UnityEngine.Object.op_Inequality(x:  41984000, y:  0);
        if(val_1 == false)
        {
                return;
        }
        
        SLCWindow.CloseWindow(window:  val_1, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public T ShowUGUIMonolith<T>(bool showNext = False)
    {
        System.Object[] val_15;
        UnityEngine.Object val_16;
        var val_17;
        var val_18;
        val_15 = __RuntimeMethodHiddenParam;
        val_16 = this;
        if(this == 0)
        {
                object[] val_2 = new object[1];
            val_15 = val_2;
            val_15[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48 + 16});
            UnityEngine.Debug.LogErrorFormat(format:  "SLCWindowManager: Could Not ShowUGUIMonolith for type {0}!!", args:  val_2);
            val_16 = 0;
            return (CategoriesWindowManager)val_16;
        }
        
        bool val_5 = X23.Contains(item:  this.gameObject);
        if(val_5 == true)
        {
            goto label_29;
        }
        
        if(showNext == false)
        {
            goto label_18;
        }
        
        T[] val_6 = val_5.ToArray();
        System.Collections.Generic.List<UnityEngine.GameObject> val_7 = new System.Collections.Generic.List<UnityEngine.GameObject>(collection:  val_6);
        val_17 = UnityEngine.Object.op_Equality(x:  val_6, y:  0);
        if(val_17 == false)
        {
            goto label_23;
        }
        
        val_18 = 0;
        goto label_24;
        label_18:
        string val_12 = "enqueueing " + this.gameObject.name;
        showNext.Enqueue(item:  this.gameObject);
        goto label_29;
        label_23:
        val_18 = 1;
        label_24:
        val_7.Insert(index:  1, item:  this.gameObject);
        val_7.Clear();
        if(1152921517640815632 >= 1)
        {
                var val_15 = 0;
            do
        {
            if(val_15 >= 1152921517640815632)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_17.Enqueue(item:  "Player: Client Update Found");
            val_15 = val_15 + 1;
        }
        while(val_15 < 44210784);
        
        }
        
        label_29:
        if(0 != val_7)
        {
                return (CategoriesWindowManager)val_16;
        }
        
        return (CategoriesWindowManager)val_16;
    }
    public T GetWindow<T>()
    {
        var val_43;
        System.Type val_44;
        var val_45;
        System.Type val_46;
        UnityEngine.Object val_47;
        System.Object[] val_48;
        var val_49;
        val_43 = __RuntimeMethodHiddenParam;
        val_44 = this;
        val_45 = 1152921504623353856;
        if((ContainsKey(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}))) == false)
        {
            goto label_5;
        }
        
        UnityEngine.GameObject val_4 = Item[System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48})];
        mem[1152921517641130272] = val_4;
        if(val_4 == 0)
        {
            goto label_12;
        }
        
        val_44 = ???;
        val_43 = ???;
        val_45 = ???;
        val_46 = ???;
        goto __RuntimeMethodHiddenParam + 48 + 8;
        label_12:
        bool val_7 = val_44 + 48.Remove(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_43 + 48}));
        label_5:
        val_47 = val_44 + 24;
        if(val_47 == 0)
        {
                object[] val_9 = new object[1];
            val_48 = val_9;
            val_48[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_43 + 48});
            UnityEngine.Debug.LogErrorFormat(format:  "SLCWindowManager: Could Not GetWindow for type {0}!!", args:  val_9);
            val_47 = 0;
            return (WGWindowManager)val_47;
        }
        
        if((val_47.gameObject.GetComponent<SLCWindow>()) != 0)
        {
                val_46 = val_44;
            if((System.Type.op_Inequality(left:  val_47.gameObject.GetComponent<SLCWindow>().GetType(), right:  val_46)) != false)
        {
                object[] val_18 = new object[3];
            val_18[0] = val_47.gameObject.name;
            val_49 = 0;
            val_18[1] = val_47.gameObject.GetComponent<SLCWindow>().GetType();
            val_46 = val_44;
            val_18[2] = val_46;
            UnityEngine.Debug.LogWarningFormat(format:  "{0} had a {1} instead of a {2}", args:  val_18);
            UnityEngine.Object.Destroy(obj:  val_47.gameObject.GetComponent<SLCWindow>());
        }
        
        }
        
        if((val_47.gameObject.GetComponent(type:  val_44)) == 0)
        {
                UnityEngine.Component val_30 = val_47.gameObject.AddComponent(componentType:  val_44);
        }
        
        val_48 = mem[val_44 + 48];
        val_48 = val_44 + 48;
        val_48.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_43 + 48}), value:  val_47.gameObject);
        return (WGWindowManager)val_47;
    }
    public bool ShowingWindow<T>()
    {
        if(41984000 != 0)
        {
                return System.String.op_Equality(a:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}), b:  1152921504623353856.name);
        }
        
        return false;
    }
    public SLCWindowSetting GetCurrentWindowSetting()
    {
        return (SLCWindowSetting)this;
    }
    protected virtual void WindowStateChanged(bool anyActiveOrQueuedWindows)
    {
    
    }
    public void CloseAllWindows()
    {
        if(655394 >= 1)
        {
                23852.Clear();
        }
        
        bool val_1 = UnityEngine.Object.op_Inequality(x:  41984000, y:  0);
        this.CloseBackgrounds();
    }
    public string DebugQueuedWindows()
    {
        int val_8;
        mem[1152921517641875272] = "SLCWindowManager Queued Windows:<color=#B5DB11>\n";
        T[] val_1 = 23854.ToArray();
        mem[1152921517641875280] = val_1;
        var val_9 = 0;
        label_6:
        if(val_9 >= val_1.Length)
        {
            goto label_3;
        }
        
        string val_3 = 41984000 + val_1[val_9].name + "\n";
        val_9 = val_9 + 1;
        mem[1152921517641875272] = val_3;
        if(val_3 != null)
        {
            goto label_6;
        }
        
        throw new NullReferenceException();
        label_3:
        string[] val_4 = new string[6];
        val_8 = val_4.Length;
        val_4[0] = System.String.Format(format:  "<color={0}>Current Screen Id: {1}</color>\n", arg0:  "#F37CBE", arg1:  SceneDictator.GetActiveSceneType());
        val_8 = val_4.Length;
        val_4[1] = " ";
        val_8 = val_4.Length;
        val_4[2] = " ";
        val_8 = val_4.Length;
        val_4[3] = "</color>";
        if(this != null)
        {
                val_8 = val_4.Length;
        }
        
        val_4[4] = this;
        val_8 = val_4.Length;
        val_4[5] = "\n\n\n</size>{end of log}\n\n\n";
        return (string)+val_4;
    }
    public string DebugOperations()
    {
        return (string)this;
    }
    public void AddOp(string info, string hexColor)
    {
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        mem[1152921517642189576] = 41984000 + System.String.Format(format:  "\n<color={0}>{1}: {2}</color>", arg0:  hexColor, arg1:  UnityEngine.Time.time, arg2:  info)(System.String.Format(format:  "\n<color={0}>{1}: {2}</color>", arg0:  hexColor, arg1:  UnityEngine.Time.time, arg2:  info));
    }
    public void ClearOps()
    {
        mem[1152921517642326296] = "\n-= operations history =-<size=9>";
    }
    public T IsWindowInQueue<T>()
    {
        var val_2;
        var val_3;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_17;
        val_13 = __RuntimeMethodHiddenParam;
        if((this & 1) == 0)
        {
            goto label_16;
        }
        
        Queue.Enumerator<T> val_1 = this.GetEnumerator();
        label_9:
        if(val_3.MoveNext() == false)
        {
            goto label_4;
        }
        
        UnityEngine.GameObject val_5 = val_3.Current;
        val_14 = val_5;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Type val_7 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48});
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  val_14.name, b:  val_7)) == false)
        {
            goto label_9;
        }
        
        val_15 = 112;
        val_13 = val_14;
        val_12 = 0;
        goto label_10;
        label_4:
        val_15 = 102;
        val_12 = 0;
        val_13 = 0;
        label_10:
        val_14 = 0;
        val_2 = val_3;
        val_3 = null;
        var val_10 = 0;
        val_10 = val_10 + 1;
        val_3.Dispose();
        if(val_14 != 0)
        {
                throw val_14;
        }
        
        if(val_12 != 1)
        {
                var val_9 = (102 == 112) ? (val_13) : 0;
            return (WGWindowManager)val_17;
        }
        
        label_16:
        val_17 = 0;
        return (WGWindowManager)val_17;
    }
    public SLCWindowManager<T>()
    {
        var val_5;
        mem[1152921517642595304] = new System.Collections.Generic.Queue<UnityEngine.GameObject>();
        mem[1152921517642595312] = new System.Collections.Generic.Dictionary<System.String, UnityEngine.GameObject>();
        mem[1152921517642595344] = new UnityEngine.Events.UnityEvent();
        mem[1152921517642595352] = new OnWindowOpenedEvent();
        mem[1152921517642595368] = "";
        mem[1152921517642595384] = "\n-= operations history =-<size=9>";
        val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
        val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
        if((val_5 & 1) == 0)
        {
                val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
            val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
        }
        
        if(((val_5 & 512) != 0) && ((__RuntimeMethodHiddenParam + 24 + 192 + 8 + 224) == 0))
        {
            
        }
    
    }
    private static SLCWindowManager<T>()
    {
        mem2[0] = "OnWGWindowClosed";
    }
    private void <ShowWindow>b__23_0()
    {
        if(this != null)
        {
                this.SetActive(value:  true);
            return;
        }
        
        throw new NullReferenceException();
    }

}
