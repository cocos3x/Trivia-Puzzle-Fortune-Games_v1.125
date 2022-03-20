using UnityEngine;
public class DebugBannerLog : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text log;
    
    // Methods
    public void Setup(string text)
    {
        if(this.log != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public DebugBannerLog()
    {
    
    }

}
