using UnityEngine;
public class ScaleBasedOnAspectRatio : MonoBehaviour
{
    // Fields
    public bool debugLog;
    public float aspectRatioMin;
    public float aspectRatioMax;
    public float scaleToAtMin;
    public float scaleToAtMax;
    public float scale;
    private float currentAspectRatio;
    public bool alsoScaleZAxis;
    public bool onlyUpdateOnce;
    
    // Methods
    private void Update()
    {
        object val_14;
        System.Object[] val_15;
        int val_16;
        int val_17;
        var val_19;
        var val_20;
        int val_21;
        float val_22;
        int val_23;
        int val_24;
        float val_14 = (float)UnityEngine.Screen.width;
        val_14 = val_14 / (float)UnityEngine.Screen.height;
        val_14 = this;
        this.currentAspectRatio = val_14;
        float val_15 = this.aspectRatioMin;
        if(val_14 <= val_15)
        {
            goto label_1;
        }
        
        if(val_14 >= this.aspectRatioMax)
        {
            goto label_2;
        }
        
        val_14 = val_14 - val_15;
        val_15 = this.aspectRatioMax - val_15;
        float val_3 = val_14 / val_15;
        this.scale = UnityEngine.Mathf.Lerp(a:  this.scaleToAtMin, b:  this.scaleToAtMax, t:  val_3);
        if(this.debugLog == false)
        {
            goto label_35;
        }
        
        val_15 = new object[6];
        val_15[0] = "currentAspectRatio = ";
        val_16 = val_5.Length;
        val_15[1] = this.currentAspectRatio.ToString(format:  "0.000000");
        val_16 = val_5.Length;
        val_15[2] = "  (t = ";
        val_17 = val_5.Length;
        val_15[3] = val_3;
        val_17 = val_5.Length;
        val_15[4] = ")  scale: ";
        val_19 = null;
        goto label_22;
        label_1:
        this.scale = this.scaleToAtMin;
        if(this.debugLog == false)
        {
            goto label_35;
        }
        
        val_15 = new object[6];
        val_15[0] = "currentAspectRatio ";
        val_20 = 1152921504622129152;
        val_21 = val_7.Length;
        val_15[1] = this.currentAspectRatio;
        val_21 = val_7.Length;
        val_15[2] = ", under min ";
        val_22 = this.aspectRatioMin;
        goto label_34;
        label_2:
        this.scale = this.scaleToAtMax;
        if(this.debugLog == false)
        {
            goto label_35;
        }
        
        object[] val_8 = new object[6];
        val_15 = val_8;
        val_15[0] = "currentAspectRatio ";
        val_20 = 1152921504622129152;
        val_23 = val_8.Length;
        val_15[1] = this.currentAspectRatio;
        val_23 = val_8.Length;
        val_15[2] = ",  past max ";
        val_22 = this.aspectRatioMax;
        label_34:
        val_24 = val_8.Length;
        val_15[3] = val_22;
        val_24 = val_8.Length;
        val_15[4] = " scale set to ";
        val_19 = null;
        label_22:
        val_14 = this.scale;
        val_15[5] = val_14;
        UnityEngine.Debug.LogError(message:  +val_8);
        label_35:
        UnityEngine.Vector3 val_12 = new UnityEngine.Vector3(x:  this.scale, y:  this.scale, z:  (this.alsoScaleZAxis == false) ? 1f : this.scale);
        this.transform.localScale = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
        if(this.onlyUpdateOnce == false)
        {
                return;
        }
        
        if(UnityEngine.Application.isPlaying == false)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this);
    }
    public ScaleBasedOnAspectRatio()
    {
        this.aspectRatioMin = ;
        this.aspectRatioMax = ;
        this.scaleToAtMin = 1f;
        this.scaleToAtMax = 1.2f;
        this.scale = 1f;
        this.currentAspectRatio = 2.204102E-41f;
    }

}
