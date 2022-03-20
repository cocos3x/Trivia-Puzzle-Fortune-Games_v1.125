using UnityEngine;
[Serializable]
public class GradientInfo
{
    // Fields
    public UnityEngine.Color m_color1;
    public UnityEngine.Color m_color2;
    public float m_angle;
    public bool m_ignoreRatio;
    
    // Methods
    public GradientInfo()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.m_color1 = val_1;
        mem[1152921517679467284] = val_1.g;
        mem[1152921517679467288] = val_1.b;
        mem[1152921517679467292] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.m_color2 = val_2;
        mem[1152921517679467300] = val_2.g;
        mem[1152921517679467304] = val_2.b;
        mem[1152921517679467308] = val_2.a;
        this.m_ignoreRatio = true;
    }

}
