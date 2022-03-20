using UnityEngine;
public class BlurCanvas : MonoBehaviour
{
    // Fields
    private LeTai.Asset.TranslucentImage.TranslucentImageSource translucentImageSource;
    private UnityEngine.Camera camera;
    private float blurStrength;
    
    // Methods
    private void Awake()
    {
        LeTai.Asset.TranslucentImage.TranslucentImageSource val_1 = this.GetComponent<LeTai.Asset.TranslucentImage.TranslucentImageSource>();
        this.translucentImageSource = val_1;
        val_1.Strength = this.blurStrength;
        this.translucentImageSource.enabled = false;
        this.camera = this.GetComponent<UnityEngine.Camera>();
    }
    public void DoBlur()
    {
        this.translucentImageSource.Strength = this.blurStrength;
        this.translucentImageSource.enabled = true;
    }
    public void StopBlur()
    {
        if(this.translucentImageSource != null)
        {
                this.translucentImageSource.enabled = false;
            return;
        }
        
        throw new NullReferenceException();
    }
    public BlurCanvas()
    {
    
    }

}
