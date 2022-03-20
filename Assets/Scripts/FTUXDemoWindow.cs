using UnityEngine;
public class FTUXDemoWindow : MonoBehaviour
{
    // Methods
    private void OnEnable()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WGFTUXManager>.Instance)) == false)
        {
                return;
        }
        
        WGFTUXManager val_3 = MonoSingleton<WGFTUXManager>.Instance;
        val_3.currDemoWindow = this;
    }
    private void OnDisable()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WGFTUXManager>.Instance)) == false)
        {
                return;
        }
        
        WGFTUXManager val_3 = MonoSingleton<WGFTUXManager>.Instance;
        val_3.currDemoWindow = 0;
    }
    public FTUXDemoWindow()
    {
    
    }

}
