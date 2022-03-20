using UnityEngine;
public class ExtraProgressFlexible : MonoBehaviour
{
    // Fields
    public float target;
    public float _current;
    public float maxWidth;
    private UnityEngine.RectTransform sourceTransform;
    private UnityEngine.RectTransform rt;
    private bool hasInitialized;
    private FrameSkipper skipper;
    
    // Properties
    public float current { get; set; }
    
    // Methods
    public float get_current()
    {
        return (float)this._current;
    }
    public void set_current(float value)
    {
        this._current = value;
        this.UpdateUI();
    }
    private void Init()
    {
        this.rt = this.GetComponent<UnityEngine.RectTransform>();
        if(this.sourceTransform != 0)
        {
            goto label_3;
        }
        
        this.sourceTransform = this.rt;
        if(this.rt != null)
        {
            goto label_4;
        }
        
        label_3:
        label_4:
        UnityEngine.Rect val_3 = this.sourceTransform.rect;
        this.maxWidth = val_3.m_XMin.width;
        this.skipper = this.GetComponent<FrameSkipper>();
        val_5.updateLogic = new System.Action(object:  this, method:  System.Void ExtraProgressFlexible::CheckDimensions());
        this.hasInitialized = true;
    }
    private void UpdateUI()
    {
        float val_9;
        if(this.hasInitialized != true)
        {
                this.Init();
        }
        
        val_9 = this.target;
        if((UnityEngine.Mathf.Approximately(a:  val_9, b:  0f)) == true)
        {
                return;
        }
        
        UnityEngine.Rect val_2 = this.sourceTransform.rect;
        this.maxWidth = val_2.m_XMin.width;
        val_9 = UnityEngine.Mathf.Clamp(value:  this._current / this.target, min:  0f, max:  1f);
        UnityEngine.Vector2 val_6 = this.rt.sizeDelta;
        UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  val_9 * this.maxWidth, y:  val_6.y);
        this.rt.sizeDelta = new UnityEngine.Vector2() {x = val_8.x, y = val_8.y};
    }
    private void CheckDimensions()
    {
        float val_5;
        if(this.hasInitialized == false)
        {
                return;
        }
        
        val_5 = this.target;
        if((UnityEngine.Mathf.Approximately(a:  val_5, b:  0f)) == true)
        {
                return;
        }
        
        UnityEngine.Rect val_2 = this.sourceTransform.rect;
        val_5 = this.maxWidth;
        if((UnityEngine.Mathf.Approximately(a:  val_2.m_XMin.width, b:  val_5)) == true)
        {
                return;
        }
        
        this.UpdateUI();
    }
    public ExtraProgressFlexible()
    {
    
    }

}
