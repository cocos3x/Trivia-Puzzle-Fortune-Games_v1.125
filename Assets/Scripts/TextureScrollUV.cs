using UnityEngine;
public class TextureScrollUV : MonoBehaviour
{
    // Fields
    public UnityEngine.Vector2 scrollSpeed;
    private UnityEngine.Vector2 currentUV;
    public bool resetOnEnable;
    private bool firstEnable;
    private UnityEngine.Vector2 originalUV;
    public bool useSharedMaterial;
    private UnityEngine.Material mMat;
    
    // Methods
    private void OnEnable()
    {
        if(this.firstEnable != false)
        {
                UnityEngine.Renderer val_1 = this.GetComponent<UnityEngine.Renderer>();
            if(this.useSharedMaterial != false)
        {
                UnityEngine.Material val_2 = val_1.sharedMaterial;
        }
        else
        {
                UnityEngine.Material val_3 = val_1.material;
        }
        
            this.mMat = val_3;
            UnityEngine.Vector2 val_4 = val_3.mainTextureOffset;
            this.currentUV = val_4;
            mem[1152921515527024612] = val_4.y;
            this.originalUV = val_4;
            mem[1152921515527024624] = val_4.y;
            this.firstEnable = false;
        }
        
        if(this.resetOnEnable == false)
        {
                return;
        }
        
        this.currentUV = this.originalUV;
    }
    public void SynchronizeUVs()
    {
        this.currentUV = this.originalUV;
    }
    public void Update()
    {
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = val_1 * this.scrollSpeed;
        val_1 = this.currentUV + val_1;
        this.currentUV = val_1;
        float val_3 = UnityEngine.Time.deltaTime;
        val_3 = val_3 * S3;
        val_3 = S9 + val_3;
        mem[1152921515527264996] = val_3;
        if(this.currentUV > (-1f))
        {
                if(this.currentUV < 1f)
        {
            goto label_1;
        }
        
        }
        
        this.currentUV = 0;
        label_1:
        if(val_3 > (-1f))
        {
                if(val_3 < 1f)
        {
            goto label_3;
        }
        
        }
        
        mem[1152921515527264996] = 0;
        label_3:
        this.mMat.mainTextureOffset = new UnityEngine.Vector2() {x = 0f, y = 0f};
    }
    public TextureScrollUV()
    {
        this.firstEnable = true;
    }

}
