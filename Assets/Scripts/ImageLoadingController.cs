using UnityEngine;
public class ImageLoadingController
{
    // Methods
    public static UnityEngine.Sprite GetSprite(string path)
    {
        var val_8;
        UnityEngine.Texture2D val_1 = ImageLoadingController.GetTexture2D(path:  path);
        val_8 = 0;
        if(val_1 == 0)
        {
                return (UnityEngine.Sprite)UnityEngine.Sprite.Create(texture:  val_1, rect:  new UnityEngine.Rect() {m_XMin = val_5.m_XMin, m_YMin = val_5.m_YMin, m_Width = val_5.m_Width, m_Height = val_5.m_Height}, pivot:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y});
        }
        
        UnityEngine.Rect val_5 = new UnityEngine.Rect(x:  0f, y:  0f, width:  (float)val_1.width, height:  (float)val_1.height);
        UnityEngine.Vector2 val_6 = UnityEngine.Vector2.zero;
        return (UnityEngine.Sprite)UnityEngine.Sprite.Create(texture:  val_1, rect:  new UnityEngine.Rect() {m_XMin = val_5.m_XMin, m_YMin = val_5.m_YMin, m_Width = val_5.m_Width, m_Height = val_5.m_Height}, pivot:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y});
    }
    public static UnityEngine.Texture2D GetTexture2D(string path)
    {
        UnityEngine.Texture2D val_5;
        if((System.IO.File.Exists(path:  path)) != false)
        {
                UnityEngine.Texture2D val_2 = null;
            val_5 = val_2;
            val_2 = new UnityEngine.Texture2D(width:  1, height:  1);
            val_2.name = path;
            if((UnityEngine.ImageConversion.LoadImage(tex:  val_2, data:  System.IO.File.ReadAllBytes(path:  path))) == true)
        {
                return (UnityEngine.Texture2D)val_5;
        }
        
        }
        
        val_5 = 0;
        return (UnityEngine.Texture2D)val_5;
    }
    public ImageLoadingController()
    {
    
    }

}
