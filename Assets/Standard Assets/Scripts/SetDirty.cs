using UnityEngine;
public class SetDirty : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Graphic m_graphic;
    
    // Methods
    private void Reset()
    {
        this.m_graphic = this.GetComponent<UnityEngine.UI.Graphic>();
    }
    private void Update()
    {
        if(this.m_graphic != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public SetDirty()
    {
    
    }

}
