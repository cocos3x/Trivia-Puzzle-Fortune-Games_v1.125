using UnityEngine;
public class WebGLDeeplinkComponent : DeeplinkComponent
{
    // Fields
    private bool deeplinkParsed;
    
    // Methods
    public WebGLDeeplinkComponent(string gameName, string gameObjectName)
    {
        mem[1152921515597093904] = "WebGLDeeplinkComponent";
    }
    protected override void PerformAction()
    {
        this.deeplinkParsed = true;
        this.ParseDeeplink(action:  DeeplinkPlugin.GetAction(), source:  4);
    }
    public override void onApplicationPause(bool pauseStatus)
    {
        if(this.deeplinkParsed == true)
        {
                return;
        }
        
        if(pauseStatus == true)
        {
                return;
        }
        
        goto typeof(WebGLDeeplinkComponent).__il2cppRuntimeField_1E0;
    }
    private void CheckForDeeplinkInURL()
    {
        this.deeplinkParsed = true;
        this.ParseDeeplink(action:  DeeplinkPlugin.GetAction(), source:  4);
    }

}
