using UnityEngine;
public class ScrollIndexCallback2 : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Text text;
    public UnityEngine.UI.LayoutElement element;
    private static float[] randomWidths;
    
    // Methods
    private void ScrollCellIndex(int idx)
    {
        var val_6;
        bool val_3 = UnityEngine.Object.op_Inequality(x:  this.text, y:  0);
        val_6 = null;
        val_6 = null;
        var val_6 = 0;
        val_6 = (UnityEngine.Mathf.Abs(value:  idx)) - val_6;
        val_6 = ScrollIndexCallback2.randomWidths + (val_6 << 2);
        this.gameObject.name = "Cell " + idx.ToString();
    }
    public ScrollIndexCallback2()
    {
    
    }
    private static ScrollIndexCallback2()
    {
        ScrollIndexCallback2.randomWidths = new float[3] {7.183897E-41f, 7.986E-42f, 2.592122E-41f};
    }

}
