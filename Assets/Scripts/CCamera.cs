using UnityEngine;
public class CCamera : MonoBehaviour
{
    // Fields
    public bool landscape;
    public float minWidth;
    public float minHeight;
    public float maxWidth;
    public float maxHeight;
    public float virtualWidth;
    public float virtualHeight;
    private int screenWidth;
    private int screenHeight;
    private float aspect;
    private UnityEngine.Camera cam;
    private bool matchWidth;
    private float width;
    private float height;
    private float minAspect;
    private float maxAspect;
    public System.Action onScreenSizeChanged;
    
    // Methods
    protected virtual void Awake()
    {
        float val_7;
        float val_8;
        val_7 = this.minWidth;
        this.cam = this.GetComponent<UnityEngine.Camera>();
        this.matchWidth = (val_7 == this.maxWidth) ? 1 : 0;
        if(this.landscape != false)
        {
                float val_3 = UnityEngine.Mathf.Min(a:  this.minHeight, b:  this.maxHeight);
            val_3 = val_7 / val_3;
            this.minAspect = val_3;
            val_8 = this.maxWidth / (UnityEngine.Mathf.Max(a:  this.minHeight, b:  this.maxHeight));
        }
        else
        {
                float val_5 = UnityEngine.Mathf.Max(a:  val_7, b:  this.maxWidth);
            val_7 = this.maxHeight;
            val_5 = this.minHeight / val_5;
            this.minAspect = val_5;
            val_8 = val_7 / (UnityEngine.Mathf.Min(a:  this.minWidth, b:  this.maxWidth));
        }
        
        this.maxAspect = val_8;
        this.UpdateCamera();
    }
    private void Update()
    {
        if(this.screenWidth == UnityEngine.Screen.width)
        {
                if(this.screenHeight == UnityEngine.Screen.height)
        {
                return;
        }
        
        }
        
        this.UpdateCamera();
    }
    private void UpdateCamera()
    {
        float val_8;
        float val_9;
        this.screenWidth = UnityEngine.Screen.width;
        this.screenHeight = UnityEngine.Screen.height;
        if(this.landscape != false)
        {
                val_8 = (float)UnityEngine.Screen.width / (float)UnityEngine.Screen.height;
            this.aspect = val_8;
            this.SetUpForLandscape();
        }
        else
        {
                val_8 = (float)UnityEngine.Screen.height / (float)UnityEngine.Screen.width;
            this.aspect = val_8;
            this.SetUpForPortrait();
        }
        
        float val_7 = this.cam.orthographicSize;
        val_7 = val_7 * 200f;
        this.virtualHeight = val_7;
        if(this.landscape != false)
        {
                val_9 = val_7 * this.aspect;
        }
        else
        {
                val_9 = val_7 / this.aspect;
        }
        
        this.virtualWidth = val_9;
        if(this.onScreenSizeChanged == null)
        {
                return;
        }
        
        this.onScreenSizeChanged.Invoke();
    }
    private void SetUpForPortrait()
    {
        float val_2;
        float val_3;
        float val_1 = UnityEngine.Mathf.Clamp(value:  this.aspect, min:  this.minAspect, max:  this.maxAspect);
        if(this.matchWidth != false)
        {
                val_2 = this.minWidth / 200f;
            val_3 = val_1 * val_2;
        }
        else
        {
                val_3 = this.minHeight / 200f;
            val_2 = val_3 / val_1;
        }
        
        this.width = val_2;
        this.height = val_3;
        float val_2 = this.aspect;
        val_2 = val_2 * val_2;
        val_2 = (val_2 < 0) ? (val_3) : (val_2);
        this.cam.orthographicSize = val_2;
    }
    private void SetUpForLandscape()
    {
        float val_2;
        float val_3;
        float val_1 = UnityEngine.Mathf.Clamp(value:  this.aspect, min:  this.minAspect, max:  this.maxAspect);
        if(this.matchWidth != false)
        {
                val_2 = this.minWidth / 200f;
            val_3 = val_2 / val_1;
        }
        else
        {
                val_3 = this.minHeight / 200f;
            val_2 = val_1 * val_3;
        }
        
        this.width = val_2;
        this.height = val_3;
        float val_2 = this.aspect;
        val_2 = val_2 / val_2;
        val_2 = (val_2 < this.minAspect) ? (val_2) : (val_3);
        this.cam.orthographicSize = val_2;
    }
    public float GetHeight()
    {
        return (float)this.height;
    }
    public float GetWidth()
    {
        return (float)this.width;
    }
    public CCamera()
    {
    
    }

}
