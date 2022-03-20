using UnityEngine;
public class ScreenCast : MonoBehaviour
{
    // Methods
    public static UnityEngine.Vector3 GetObjectPosition(ScreenCast.ScreenCastMode mode, UnityEngine.Vector3 objectPosition)
    {
        var val_6;
        if(mode == 0)
        {
            goto label_1;
        }
        
        if(mode != 1)
        {
                return UnityEngine.Vector3.zero;
        }
        
        val_6 = SLCWindowManager<WGWindowManager>.monolithPopupCamera;
        if(UnityEngine.Camera.main != null)
        {
            goto label_5;
        }
        
        label_1:
        val_6 = UnityEngine.Camera.main;
        label_5:
        UnityEngine.Vector3 val_5 = SLCWindowManager<WGWindowManager>.monolithPopupCamera.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = objectPosition.x, y = objectPosition.y, z = objectPosition.z});
        return val_6.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
    }
    public ScreenCast()
    {
    
    }

}
