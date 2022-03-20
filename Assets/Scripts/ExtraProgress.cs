using UnityEngine;
public class ExtraProgress : MonoBehaviour
{
    // Fields
    public float target;
    public float _current;
    public float maxWidth;
    private UnityEngine.RectTransform sourceTransform;
    private UnityEngine.RectTransform rt;
    private bool hasInitialized;
    
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
        if(this.sourceTransform == 0)
        {
            goto label_3;
        }
        
        label_5:
        UnityEngine.Rect val_3 = this.sourceTransform.rect;
        this.maxWidth = val_3.m_XMin.width;
        this.hasInitialized = true;
        return;
        label_3:
        if(this.rt != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
    }
    private void UpdateUI()
    {
        float val_6;
        if(this.hasInitialized != true)
        {
                this.Init();
        }
        
        val_6 = this.target;
        if(val_6 == 0f)
        {
                return;
        }
        
        val_6 = UnityEngine.Mathf.Clamp(value:  this._current / val_6, min:  0f, max:  1f);
        UnityEngine.Vector2 val_3 = this.rt.sizeDelta;
        UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  val_6 * this.maxWidth, y:  val_3.y);
        this.rt.sizeDelta = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
    }
    public ExtraProgress()
    {
    
    }

}
