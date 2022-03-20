using UnityEngine;
public class UIButtonEventSpeedUpTIme : MonoBehaviour
{
    // Fields
    public static float fastTimeScale;
    public static float slowTimeScale;
    private static float pauseTimeScale;
    public UIButtonEventSpeedUpTIme.TimeEffect timeEffect;
    
    // Methods
    public void OnPointerExit()
    {
        this.CancelInvoke();
        this.Invoke(methodName:  "ResetTimeScale", time:  0.01f);
    }
    public void OnPointerDown()
    {
        var val_2;
        var val_3;
        var val_4;
        if(UnityEngine.Time.timeScale != 0f)
        {
            goto label_1;
        }
        
        label_13:
        UnityEngine.Time.timeScale = 1f;
        return;
        label_1:
        if(this.timeEffect == 2)
        {
            goto label_2;
        }
        
        if(this.timeEffect == 1)
        {
            goto label_3;
        }
        
        if(this.timeEffect != 0)
        {
                return;
        }
        
        val_2 = null;
        val_2 = null;
        goto label_13;
        label_2:
        val_3 = null;
        val_3 = null;
        goto label_13;
        label_3:
        val_4 = null;
        val_4 = null;
        goto label_13;
    }
    public void OnPointerUp()
    {
        this.CancelInvoke();
        this.Invoke(methodName:  "ResetTimeScale", time:  0.01f);
    }
    private void ResetTimeScale()
    {
        UnityEngine.Time.timeScale = 1f;
    }
    public UIButtonEventSpeedUpTIme()
    {
    
    }
    private static UIButtonEventSpeedUpTIme()
    {
        UIButtonEventSpeedUpTIme.fastTimeScale = 8f;
        UIButtonEventSpeedUpTIme.slowTimeScale = 0.2f;
        UIButtonEventSpeedUpTIme.pauseTimeScale = 0f;
    }

}
