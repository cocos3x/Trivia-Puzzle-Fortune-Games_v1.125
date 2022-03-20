using UnityEngine;
public class SLC_MocksViewer : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.RawImage currentMock;
    
    // Methods
    public void OnOpacitySliderChanged(float value)
    {
        this.currentMock.canvasRenderer.SetAlpha(alpha:  value);
    }
    public void SetImage(UnityEngine.Texture image)
    {
        if(this.currentMock != null)
        {
                this.currentMock.texture = image;
            return;
        }
        
        throw new NullReferenceException();
    }
    public UnityEngine.Texture GetImage()
    {
        if(this.currentMock == 0)
        {
                return 0;
        }
        
        0 = this.currentMock.m_Texture;
        return 0;
    }
    public SLC_MocksViewer()
    {
    
    }

}
