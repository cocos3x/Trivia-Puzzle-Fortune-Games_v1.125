using UnityEngine;
public class SLCWindow : MonoBehaviour
{
    // Fields
    public bool postOnCloseNotification;
    private bool dontDestroyOnDisable;
    private bool tapToCloseOnAwake;
    private bool backButtonCanClose;
    private bool closeWindowCalledBeforeDisable;
    public System.Action Action_OnClose;
    
    // Properties
    public bool DontDestroyOnDisable { get; set; }
    
    // Methods
    public static void CloseWindow(UnityEngine.GameObject window, bool setDestroyOnDisableState = False, bool dontDestroyOnDisable = False)
    {
        bool val_8 = setDestroyOnDisableState;
        if((window.GetComponent<SLCWindow>()) == 0)
        {
            goto label_4;
        }
        
        if(val_8 == false)
        {
            goto label_5;
        }
        
        val_1.dontDestroyOnDisable = dontDestroyOnDisable;
        goto label_7;
        label_4:
        object[] val_4 = new object[1];
        val_8 = window.name;
        val_4[0] = val_8;
        UnityEngine.Debug.LogWarningFormat(format:  "{0} does not have an SCLWindow (or derived) component!", args:  val_4);
        goto label_14;
        label_5:
        label_7:
        val_1.closeWindowCalledBeforeDisable = true;
        label_14:
        WindowTransitionTween val_6 = window.GetComponent<WindowTransitionTween>();
        if(val_6 != 0)
        {
                val_6.TweenOffScreenAndDisable();
            return;
        }
        
        window.SetActive(value:  false);
    }
    public bool get_DontDestroyOnDisable()
    {
        return (bool)this.dontDestroyOnDisable;
    }
    public void set_DontDestroyOnDisable(bool value)
    {
        this.dontDestroyOnDisable = value;
    }
    private void Awake()
    {
        if(this.tapToCloseOnAwake == false)
        {
                return;
        }
        
        this.SetupTapToClose();
    }
    private void OnEnable()
    {
        this.closeWindowCalledBeforeDisable = false;
    }
    public void Setup(SLCWindowSetting settings)
    {
        object val_9;
        var val_10;
        val_9 = this;
        if(settings == 0)
        {
            goto label_3;
        }
        
        this.backButtonCanClose = settings.backButtonCanClose;
        if(settings.backButtonCanClose == true)
        {
            goto label_5;
        }
        
        label_8:
        if(((settings.ShiftDownForBanner == true) ? 1 : 0) != 0)
        {
            goto label_6;
        }
        
        return;
        label_3:
        val_10 = 0;
        if(this.backButtonCanClose == false)
        {
            goto label_8;
        }
        
        label_5:
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void SLCWindow::HandleBackButtonClose()));
        if(val_10 == 0)
        {
                return;
        }
        
        label_6:
        val_9 = this.GetComponent<UnityEngine.RectTransform>();
        if((UnityEngine.Object.op_Implicit(exists:  val_9)) == false)
        {
                return;
        }
        
        UnityEngine.Vector2 val_6 = val_9.offsetMax;
        float val_9 = (float)-UnityEngine.Screen.height;
        val_9 = val_9 * 0.17f;
        UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  val_6.x, y:  val_9);
        val_9.offsetMax = new UnityEngine.Vector2() {x = val_8.x, y = val_8.y};
    }
    protected virtual void OnDisable()
    {
        if(this.closeWindowCalledBeforeDisable != true)
        {
                object[] val_1 = new object[2];
            val_1[0] = this.gameObject.name;
            val_1[1] = this.gameObject;
            UnityEngine.Debug.LogWarningFormat(format:  "SLCWindow::CloseWindow(GameObject) Not Called! on {0}", args:  val_1);
        }
        
        if(this.backButtonCanClose != false)
        {
                DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void SLCWindow::HandleBackButtonClose()));
        }
        
        if(this.Action_OnClose != null)
        {
                this.Action_OnClose.Invoke();
        }
        
        this.Action_OnClose = 0;
        if(this.postOnCloseNotification != false)
        {
                NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  SLCWindowManager<T>.color_show_available_popups);
        }
        
        if(this.dontDestroyOnDisable != false)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void DoOnCloseAction()
    {
        if(this.Action_OnClose != null)
        {
                this.Action_OnClose.Invoke();
        }
        
        this.Action_OnClose = 0;
    }
    private void SetupTapToClose()
    {
        UnityEngine.UI.Image val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.Image>(gameObject:  this.gameObject);
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
        val_2.color = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
        val_2.raycastTarget = true;
        UnityEngine.UI.Button val_5 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.Button>(gameObject:  this.gameObject);
        val_5.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLCWindow::CloseWindow()));
    }
    private void CloseWindow()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void HandleBackButtonClose()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public SLCWindow()
    {
        this.postOnCloseNotification = true;
        this.backButtonCanClose = true;
    }

}
