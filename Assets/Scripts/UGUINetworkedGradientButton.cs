using UnityEngine;
public class UGUINetworkedGradientButton : UGUINetworkedButton
{
    // Fields
    public GradientInfo gradient_default;
    public GradientInfo gradient_pressed;
    public GradientInfo gradient_hover;
    public GradientInfo gradient_disabled;
    public float duration;
    private GradientInfo nextGradient;
    private System.Collections.IEnumerator routine;
    public UIGradient targetGradient;
    
    // Methods
    protected override void DoStateTransition(UnityEngine.UI.Selectable.SelectionState state, bool instant)
    {
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if(state <= 4)
        {
                var val_9 = 32554688 + (state) << 2;
            val_9 = val_9 + 32554688;
        }
        else
        {
                ???.CrossfadeGradient(gradient:  ??? + 528, newGradientInfo:  null);
            ???.DoStateTransition(state:  ???, instant:  (???) & 1);
        }
    
    }
    private void CrossfadeGradient(UIGradient gradient, GradientInfo newGradientInfo)
    {
        if(gradient == 0)
        {
                return;
        }
        
        if(UnityEngine.Application.isPlaying != false)
        {
                if(this.routine != null)
        {
                this.StopCoroutine(routine:  this.routine);
        }
        
            UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.DoCrossfadeGradient(gradient:  gradient, newGradientInfo:  newGradientInfo = newGradientInfo));
            return;
        }
        
        gradient.m_color1 = newGradientInfo.m_color1;
        gradient.m_color2 = newGradientInfo.m_color2;
        gradient.m_angle = newGradientInfo.m_angle;
    }
    private System.Collections.IEnumerator DoCrossfadeGradient(UIGradient gradient, GradientInfo newGradientInfo)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .gradient = gradient;
        .newGradientInfo = newGradientInfo;
        return (System.Collections.IEnumerator)new UGUINetworkedGradientButton.<DoCrossfadeGradient>d__10();
    }
    public UGUINetworkedGradientButton()
    {
        this.duration = 0.1f;
    }

}
