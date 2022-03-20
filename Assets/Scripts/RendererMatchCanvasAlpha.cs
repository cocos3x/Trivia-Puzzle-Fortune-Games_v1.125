using UnityEngine;
public class RendererMatchCanvasAlpha : MonoBehaviour
{
    // Fields
    private bool mapToOriginalAlpha;
    private string colorProperty;
    private UnityEngine.CanvasGroup canvasGroup;
    private UnityEngine.Color originalColor;
    private UnityEngine.Renderer _renderer;
    
    // Properties
    private UnityEngine.Renderer _Renderer { get; }
    
    // Methods
    private UnityEngine.Renderer get__Renderer()
    {
        UnityEngine.Renderer val_3;
        if(0 == this._renderer)
        {
                this._renderer = this.GetComponent<UnityEngine.Renderer>();
            return val_3;
        }
        
        val_3 = this._renderer;
        return val_3;
    }
    private void Awake()
    {
        this.canvasGroup = this.GetComponentInParent<UnityEngine.CanvasGroup>();
        UnityEngine.Color val_4 = this._Renderer.material.GetColor(name:  this.colorProperty);
        this.originalColor = val_4;
        mem[1152921517620567492] = val_4.g;
        mem[1152921517620567496] = val_4.b;
        mem[1152921517620567500] = val_4.a;
        this.ChangeAlpha();
    }
    private void ChangeAlpha()
    {
        if(this.mapToOriginalAlpha != false)
        {
                float val_4 = UnityEngine.Mathf.Lerp(a:  0f, b:  V11.16B, t:  this.canvasGroup.alpha);
        }
        
        UnityEngine.Color val_6 = new UnityEngine.Color(r:  this.originalColor, g:  V9.16B, b:  V8.16B, a:  this.canvasGroup.alpha);
        this._Renderer.material.SetColor(name:  this.colorProperty, value:  new UnityEngine.Color() {r = val_6.r, g = val_6.g, b = val_6.b, a = val_6.a});
    }
    private void Update()
    {
        this.ChangeAlpha();
    }
    public RendererMatchCanvasAlpha()
    {
        this.mapToOriginalAlpha = true;
        this.colorProperty = "_TintColor";
        UnityEngine.Color val_1 = UnityEngine.Color.magenta;
        this.originalColor = val_1;
        mem[1152921517620960932] = val_1.g;
        mem[1152921517620960936] = val_1.b;
        mem[1152921517620960940] = val_1.a;
    }

}
