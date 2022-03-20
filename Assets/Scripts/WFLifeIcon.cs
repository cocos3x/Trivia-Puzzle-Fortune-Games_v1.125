using UnityEngine;
public class WFLifeIcon : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image border;
    private UnityEngine.UI.Image heart;
    
    // Methods
    private void Start()
    {
        this.SetAlive(alive:  true);
    }
    public void SetAlive(bool alive)
    {
        UnityEngine.UI.Image val_5;
        if(alive == false)
        {
            goto label_0;
        }
        
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.border.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        val_5 = this.heart;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        if(val_5 != null)
        {
            goto label_2;
        }
        
        label_0:
        UnityEngine.Color val_3 = UnityEngine.Color.black;
        this.border.color = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
        val_5 = this.heart;
        UnityEngine.Color val_4 = UnityEngine.Color.gray;
        label_2:
        val_5.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
    }
    public WFLifeIcon()
    {
    
    }

}
