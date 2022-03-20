using UnityEngine;
public class TRVDynamicSliderTick : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text myText;
    private UnityEngine.GameObject completeImage;
    private bool completeImageReplacesText;
    
    // Methods
    public void Init(int myValue, int maxValue, int myDisplayAmount, int lastTickOffset, bool isComplete = False)
    {
        this.gameObject.SetActive(value:  true);
        UnityEngine.Rect val_5 = this.transform.parent.GetComponent<UnityEngine.RectTransform>().rect;
        float val_6 = val_5.m_XMin.width;
        float val_16 = (float)myValue;
        val_16 = val_16 / (float)maxValue;
        val_6 = val_16 * val_6;
        val_16 = val_6 + (float)lastTickOffset;
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  (myValue == maxValue) ? (val_16) : (val_6), y:  0f);
        this.GetComponent<UnityEngine.RectTransform>().anchoredPosition = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        bool val_10 = UnityEngine.Object.op_Inequality(x:  this.myText, y:  0);
        if(this.completeImage == 0)
        {
                return;
        }
        
        this.completeImage.gameObject.SetActive(value:  isComplete);
        if(this.completeImageReplacesText == false)
        {
                return;
        }
        
        if(isComplete == false)
        {
                return;
        }
        
        if(this.myText == 0)
        {
                return;
        }
        
        this.myText.gameObject.SetActive(value:  false);
    }
    public virtual string FormatMyText(int myDisplayAmount)
    {
        return (string)System.String.Format(format:  "x{0}", arg0:  myDisplayAmount.ToString());
    }
    public TRVDynamicSliderTick()
    {
    
    }

}
