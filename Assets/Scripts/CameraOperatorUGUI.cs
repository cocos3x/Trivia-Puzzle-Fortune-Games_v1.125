using UnityEngine;
public class CameraOperatorUGUI : MonoBehaviour
{
    // Fields
    private UnityEngine.Canvas myCanvas;
    
    // Properties
    private UnityEngine.Canvas MyCanvas { get; }
    
    // Methods
    private UnityEngine.Canvas get_MyCanvas()
    {
        UnityEngine.Canvas val_3;
        if(this.myCanvas == 0)
        {
                this.myCanvas = this.GetComponent<UnityEngine.Canvas>();
            return val_3;
        }
        
        val_3 = this.myCanvas;
        return val_3;
    }
    private void Start()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance)) == false)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance.AddCamera(cam:  this);
    }
    private void OnDestroy()
    {
        var val_4;
        null = null;
        if(App.isQuitting == true)
        {
                return;
        }
        
        val_4 = 1152921504893267968;
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance)) == false)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance.RemoveCamera(cam:  this);
    }
    public bool IsCameraActive()
    {
        return this.MyCanvas.enabled;
    }
    public void SetCameraState(bool active)
    {
        active = active;
        this.MyCanvas.enabled = active;
    }
    public CameraOperatorUGUI()
    {
    
    }

}
