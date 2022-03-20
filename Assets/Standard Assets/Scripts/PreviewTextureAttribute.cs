using UnityEngine;
public class PreviewTextureAttribute : PropertyAttribute
{
    // Fields
    public UnityEngine.Rect lastPosition;
    public long expire;
    public UnityEngine.WWW www;
    public UnityEngine.Texture2D cached;
    
    // Methods
    public PreviewTextureAttribute()
    {
        UnityEngine.Rect val_1 = new UnityEngine.Rect(x:  0f, y:  0f, width:  0f, height:  0f);
        this.lastPosition = val_1.m_XMin;
        this.expire = 6000000000;
    }
    public PreviewTextureAttribute(int expire)
    {
        UnityEngine.Rect val_1 = new UnityEngine.Rect(x:  0f, y:  0f, width:  0f, height:  0f);
        this.lastPosition = val_1.m_XMin;
        this.expire = 6000000000;
        this.expire = (long)expire * 10000000;
    }

}
