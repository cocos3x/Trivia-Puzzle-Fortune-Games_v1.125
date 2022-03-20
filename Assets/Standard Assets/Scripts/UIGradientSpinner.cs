using UnityEngine;
public class UIGradientSpinner : MonoBehaviour
{
    // Fields
    private float angleIncrement;
    private UIGradient _gradient;
    private UnityEngine.UI.Image _image;
    
    // Properties
    private UIGradient gradient { get; }
    private UnityEngine.UI.Image image { get; }
    
    // Methods
    private UIGradient get_gradient()
    {
        UIGradient val_3;
        if(0 == this._gradient)
        {
                this._gradient = this.GetComponent<UIGradient>();
            return val_3;
        }
        
        val_3 = this._gradient;
        return val_3;
    }
    private UnityEngine.UI.Image get_image()
    {
        UnityEngine.UI.Image val_3;
        if((UnityEngine.Object.op_Implicit(exists:  this._image)) != false)
        {
                val_3 = this._image;
            return val_2;
        }
        
        UnityEngine.UI.Image val_2 = this.GetComponent<UnityEngine.UI.Image>();
        this._image = val_2;
        return val_2;
    }
    private void OnEnable()
    {
        UnityEngine.Coroutine val_1 = this.StartCoroutine(methodName:  "fakeUpdate");
    }
    private void FixedUpdate()
    {
    
    }
    private void doTHing()
    {
        UIGradient val_1 = this.gradient;
        float val_6 = val_1.m_angle;
        val_6 = val_6 + this.angleIncrement;
        val_1.m_angle = val_6;
        UIGradient val_2 = this.gradient;
        if(val_2.m_angle >= 180f)
        {
                UIGradient val_3 = this.gradient;
            UIGradient val_4 = this.gradient;
            float val_7 = val_4.m_angle;
            val_7 = val_7 + (-180f);
            val_7 = val_7 + (-180f);
            val_3.m_angle = val_7;
        }
        
        this.image.SetVerticesDirty();
    }
    private System.Collections.IEnumerator fakeUpdate()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new UIGradientSpinner.<fakeUpdate>d__10();
    }
    public UIGradientSpinner()
    {
        this.angleIncrement = 10f;
    }

}
