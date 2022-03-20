using UnityEngine;
public class FrameSkipper : MonoBehaviour
{
    // Fields
    protected bool disableSkip;
    private int frameSkipper;
    protected int _framesToSkip;
    public System.Action updateLogic;
    
    // Properties
    public int framesToSkip { get; set; }
    
    // Methods
    public int get_framesToSkip()
    {
        return (int)this._framesToSkip;
    }
    public void set_framesToSkip(int value)
    {
        this._framesToSkip = value;
    }
    private void Update()
    {
        int val_2;
        if(this.disableSkip != false)
        {
                return;
        }
        
        val_2 = this.frameSkipper;
        int val_2 = this._framesToSkip;
        val_2 = val_2 - ((val_2 / val_2) * val_2);
        if(val_2 == 0)
        {
                if(this.updateLogic != null)
        {
                this.updateLogic.Invoke();
        }
        
            val_2 = 0;
            this.frameSkipper = 0;
        }
        
        val_2 = val_2 + 1;
        this.frameSkipper = val_2;
    }
    protected virtual void UpdateLogic()
    {
    
    }
    public FrameSkipper()
    {
        var val_2;
        System.Action val_4;
        this._framesToSkip = 30;
        val_2 = null;
        val_2 = null;
        val_4 = FrameSkipper.<>c.<>9__9_0;
        if(val_4 == null)
        {
                System.Action val_1 = null;
            val_4 = val_1;
            val_1 = new System.Action(object:  FrameSkipper.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FrameSkipper.<>c::<.ctor>b__9_0());
            FrameSkipper.<>c.<>9__9_0 = val_4;
        }
        
        this.updateLogic = val_4;
    }

}
