using UnityEngine;
public class ScrollIndexCallback1 : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Text text;
    
    // Methods
    private void ScrollCellIndex(int idx)
    {
        UnityEngine.UI.Image val_7;
        bool val_3 = UnityEngine.Object.op_Inequality(x:  this.text, y:  0);
        val_7 = this.image;
        if(val_7 != 0)
        {
                val_7 = this.image;
            float val_7 = (float)idx;
            val_7 = val_7 / 50f;
            UnityEngine.Color val_5 = ScrollIndexCallback1.Rainbow(progress:  val_7);
            val_7.color = new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a};
        }
        
        this.gameObject.name = "Cell " + idx.ToString();
    }
    public static UnityEngine.Color Rainbow(float progress)
    {
        float val_4;
        float val_5;
        float val_1 = UnityEngine.Mathf.Clamp01(value:  progress);
        val_1 = val_1 * 6f;
        double val_4 = (double)val_1;
        val_4 = -val_4;
        val_4 = (val_1 == Infinityf) ? (val_4) : (val_4);
        if(0 <= 5)
        {
                float val_2 = val_1 - (float)(int)val_4;
            val_4 = 1f - val_2;
            val_5 = val_2;
        }
        else
        {
                val_5 = 0f;
        }
        
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  V4.16B, g:  null, b:  val_4);
        return new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
    }
    public ScrollIndexCallback1()
    {
    
    }

}
