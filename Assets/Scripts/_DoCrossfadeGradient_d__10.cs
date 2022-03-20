using UnityEngine;
private sealed class GradientButton.<DoCrossfadeGradient>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public GradientButton <>4__this;
    public UIGradient gradient;
    public GradientInfo newGradientInfo;
    private float <startTime>5__2;
    private float <endTime>5__3;
    private UnityEngine.Color <m_color1_start>5__4;
    private UnityEngine.Color <m_color2_start>5__5;
    private float <m_angle_start>5__6;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public GradientButton.<DoCrossfadeGradient>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        float val_9;
        int val_10;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        float val_1 = UnityEngine.Time.time;
        this.<startTime>5__2 = val_1;
        val_9 = this;
        val_1 = val_1 + (this.<>4__this.duration);
        this.<endTime>5__3 = val_1;
        this.<m_color1_start>5__4 = this.gradient.m_color1;
        this.<m_color2_start>5__5 = this.gradient.m_color2;
        this.<m_angle_start>5__6 = this.gradient.m_angle;
        goto label_5;
        label_1:
        val_9 = this.<endTime>5__3;
        this.<>1__state = 0;
        label_5:
        if(UnityEngine.Time.time <= val_9)
        {
            goto label_6;
        }
        
        this.gradient.m_color1 = this.newGradientInfo.m_color1;
        this.gradient.m_color2 = this.newGradientInfo.m_color2;
        this.gradient.m_angle = this.newGradientInfo.m_angle;
        this.gradient.Refresh();
        label_2:
        val_10 = 0;
        return (bool)val_10;
        label_6:
        float val_3 = UnityEngine.Time.time;
        val_3 = val_3 - (this.<startTime>5__2);
        float val_4 = val_3 / (this.<>4__this.duration);
        UnityEngine.Color val_5 = UnityEngine.Color.Lerp(a:  new UnityEngine.Color() {r = this.<m_color1_start>5__4, g = val_9}, b:  new UnityEngine.Color() {r = this.newGradientInfo.m_color1}, t:  val_4);
        this.gradient.m_color1 = val_5;
        mem2[0] = val_5.g;
        mem2[0] = val_5.b;
        mem2[0] = val_5.a;
        UnityEngine.Color val_6 = UnityEngine.Color.Lerp(a:  new UnityEngine.Color() {r = this.<m_color2_start>5__5, g = val_5.g, b = val_5.b, a = val_5.a}, b:  new UnityEngine.Color() {r = this.newGradientInfo.m_color2}, t:  val_4);
        this.gradient.m_color2 = val_6;
        mem2[0] = val_6.g;
        mem2[0] = val_6.b;
        mem2[0] = val_6.a;
        this.gradient.m_angle = UnityEngine.Mathf.Lerp(a:  this.<m_angle_start>5__6, b:  this.newGradientInfo.m_angle, t:  val_4);
        this.gradient.Refresh();
        val_10 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_10;
        return (bool)val_10;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
