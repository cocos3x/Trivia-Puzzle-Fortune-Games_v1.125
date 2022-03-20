using UnityEngine;
public class WGSpriteSlicer
{
    // Fields
    private static WGSpriteSlicer _Instance;
    
    // Properties
    public static WGSpriteSlicer Instance { get; }
    
    // Methods
    private WGSpriteSlicer()
    {
    
    }
    public static WGSpriteSlicer get_Instance()
    {
        WGSpriteSlicer val_2;
        WGSpriteSlicer val_3 = WGSpriteSlicer._Instance;
        if(val_3 != null)
        {
                return val_3;
        }
        
        WGSpriteSlicer val_1 = null;
        val_2 = val_1;
        val_1 = new WGSpriteSlicer();
        WGSpriteSlicer._Instance = val_2;
        val_3 = WGSpriteSlicer._Instance;
        return val_3;
    }
    public UnityEngine.Sprite GetSlicedSprite(UnityEngine.Sprite sprite, UnityEngine.Vector4 border)
    {
        UnityEngine.Rect val_5 = new UnityEngine.Rect(x:  0f, y:  0f, width:  (float)sprite.texture.width, height:  (float)sprite.texture.height);
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
        return (UnityEngine.Sprite)UnityEngine.Sprite.Create(texture:  sprite.texture, rect:  new UnityEngine.Rect() {m_XMin = val_5.m_XMin, m_YMin = val_5.m_YMin, m_Width = val_5.m_Width, m_Height = val_5.m_Height}, pivot:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y}, pixelsPerUnit:  100f, extrude:  1, meshType:  0, border:  new UnityEngine.Vector4() {x = border.x, y = border.z, w = val_7.x});
    }

}
