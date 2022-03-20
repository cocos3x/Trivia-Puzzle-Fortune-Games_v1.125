using UnityEngine;
public class EventListItemContentOnTheTrail : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Slider slider;
    private UnityEngine.Transform wagon;
    private UnityEngine.UI.Image completionStatus;
    private UnityEngine.Sprite checkMark;
    private UnityEngine.Sprite crossMark;
    private UnityEngine.UI.Text levels;
    
    // Methods
    public void Setup(float progress, string progressText, bool isWagonBroken)
    {
        UnityEngine.Rect val_2 = this.slider.GetComponent<UnityEngine.RectTransform>().rect;
        float val_3 = val_2.m_XMin.width;
        UnityEngine.Rect val_5 = this.wagon.GetComponent<UnityEngine.RectTransform>().rect;
        float val_6 = val_5.m_XMin.width;
        val_6 = val_6 * (-0.5f);
        float val_8 = val_3 * progress;
        val_8 = val_8 + (val_3 * (-0.5f));
        val_8 = val_8 + (val_6 + 12f);
        UnityEngine.Vector3 val_11 = this.wagon.localPosition;
        UnityEngine.Vector3 val_12 = new UnityEngine.Vector3(x:  UnityEngine.Mathf.Max(a:  val_8, b:  -360f), y:  val_11.y, z:  0f);
        this.wagon.localPosition = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.forward;
        this.wagon.Rotate(axis:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, angle:  (isWagonBroken != true) ? -10f : 0f);
        var val_15 = (isWagonBroken != true) ? 56 : 48;
        this.completionStatus.sprite = null;
    }
    public EventListItemContentOnTheTrail()
    {
    
    }

}
