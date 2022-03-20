using UnityEngine;
public class SLCHUDWindow : MonoSingleton<SLCHUDWindow>
{
    // Fields
    private UnityEngine.GameObject uiobject;
    private UnityEngine.UI.Text nfo;
    private UnityEngine.UI.Text title;
    private UnityEngine.UI.Button copyButton;
    private System.Func<string> callback;
    
    // Methods
    private void Start()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.copyButton)) != false)
        {
                this.copyButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLCHUDWindow::OnCopyButtonClicked()));
        }
        
        if(this.callback != null)
        {
                return;
        }
        
        this.uiobject.SetActive(value:  false);
    }
    private void Update()
    {
        if(this.callback == null)
        {
                return;
        }
        
        if(this.nfo == 0)
        {
                return;
        }
        
        string val_2 = this.callback.Invoke();
        this = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void CloseWindow()
    {
        this.callback = 0;
        this.uiobject.SetActive(value:  false);
    }
    public static void SetupHUD(string name, System.Func<string> callbackfunc)
    {
        UnityEngine.Object val_8 = MonoSingleton<SLCHUDWindow>.Instance;
        if(callbackfunc == null)
        {
                return;
        }
        
        if(val_8 == 0)
        {
                return;
        }
        
        SLCHUDWindow val_3 = MonoSingleton<SLCHUDWindow>.Instance;
        val_3.uiobject.SetActive(value:  true);
        SLCHUDWindow val_4 = MonoSingleton<SLCHUDWindow>.Instance;
        val_8 = val_4.title;
        if(val_8 != 0)
        {
                SLCHUDWindow val_6 = MonoSingleton<SLCHUDWindow>.Instance;
        }
        
        SLCHUDWindow val_7 = MonoSingleton<SLCHUDWindow>.Instance;
        val_7.callback = callbackfunc;
    }
    private void OnCopyButtonClicked()
    {
        ClipboardHelper.clipBoard = this.nfo;
    }
    public SLCHUDWindow()
    {
    
    }

}
