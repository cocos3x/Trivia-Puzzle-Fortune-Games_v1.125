using UnityEngine;
public class UGUIRawImageScrollUV : MonoBehaviour
{
    // Fields
    private UnityEngine.Vector2 scrollSpeed;
    private UnityEngine.Vector2 currentUV;
    private UnityEngine.UI.RawImage _myImage;
    
    // Properties
    private UnityEngine.UI.RawImage myImage { get; }
    
    // Methods
    private UnityEngine.UI.RawImage get_myImage()
    {
        UnityEngine.UI.RawImage val_3;
        if(this._myImage == 0)
        {
                this._myImage = this.GetComponent<UnityEngine.UI.RawImage>();
            return val_3;
        }
        
        val_3 = this._myImage;
        return val_3;
    }
    private void Update()
    {
        float val_7;
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = val_1 * this.scrollSpeed;
        val_1 = this.currentUV + val_1;
        this.currentUV = val_1;
        float val_2 = UnityEngine.Time.deltaTime;
        val_7 = -1f;
        val_2 = val_2 * S3;
        val_2 = S9 + val_2;
        mem[1152921515541332564] = val_2;
        if(this.currentUV > val_7)
        {
                if(this.currentUV < 1f)
        {
            goto label_1;
        }
        
        }
        
        this.currentUV = 0;
        label_1:
        if(val_2 <= val_7)
        {
            goto label_2;
        }
        
        val_7 = 1f;
        if(val_2 < val_7)
        {
            goto label_3;
        }
        
        label_2:
        mem[1152921515541332564] = 0;
        label_3:
        UnityEngine.UI.RawImage val_4 = this.myImage;
        UnityEngine.Vector2 val_5 = val_4.m_UVRect.size;
        UnityEngine.Rect val_6 = new UnityEngine.Rect(position:  new UnityEngine.Vector2() {x = this.currentUV, y = V9.16B}, size:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y});
        this.myImage.uvRect = new UnityEngine.Rect() {m_XMin = val_6.m_XMin, m_YMin = val_6.m_YMin, m_Width = val_6.m_Width, m_Height = val_6.m_Height};
    }
    public UGUIRawImageScrollUV()
    {
    
    }

}
