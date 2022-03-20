using UnityEngine;
public class ScreenOverlay : MonoSingleton<ScreenOverlay>
{
    // Fields
    private UnityEngine.UI.Image screenBlocker;
    
    // Methods
    private void Start()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.clear;
        this.screenBlocker.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        this.screenBlocker.raycastTarget = false;
        this.screenBlocker.gameObject.SetActive(value:  true);
    }
    public void ToggleDarkener(bool state, bool animated = False, float duration = 0.4)
    {
        this.screenBlocker.raycastTarget = state;
        if(state != false)
        {
                UnityEngine.Color val_2 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.78f);
        }
        else
        {
                UnityEngine.Color val_3 = UnityEngine.Color.clear;
        }
        
        this.ChangeColor(endColor:  new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a}, animated:  animated, duration:  duration);
    }
    public void ToggleWhiteout(bool state, bool animated = True, float duration = 0.4)
    {
        this.screenBlocker.raycastTarget = state;
        if(state != false)
        {
                UnityEngine.Color val_2 = UnityEngine.Color.white;
        }
        else
        {
                UnityEngine.Color val_3 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
        }
        
        this.ChangeColor(endColor:  new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a}, animated:  animated, duration:  duration);
    }
    public void SetColor(UnityEngine.Color endColor)
    {
        if(this.screenBlocker != null)
        {
                this.screenBlocker.color = new UnityEngine.Color() {r = endColor.r, g = endColor.g, b = endColor.b, a = endColor.a};
            return;
        }
        
        throw new NullReferenceException();
    }
    private void ChangeColor(UnityEngine.Color endColor, bool animated, float duration)
    {
        if(animated != false)
        {
                DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOColor(target:  this.screenBlocker, endValue:  new UnityEngine.Color() {r = endColor.r, g = endColor.g, b = endColor.b, a = endColor.a}, duration:  duration);
            return;
        }
        
        if(this.screenBlocker != null)
        {
                this.screenBlocker.color = new UnityEngine.Color() {r = endColor.r, g = endColor.g, b = endColor.b, a = endColor.a};
            return;
        }
        
        throw new NullReferenceException();
    }
    public ScreenOverlay()
    {
    
    }

}
