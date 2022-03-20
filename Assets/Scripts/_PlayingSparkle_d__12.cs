using UnityEngine;
private sealed class AnimatedCoin.<PlayingSparkle>d__12 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public float delay;
    public AnimatedCoin <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public AnimatedCoin.<PlayingSparkle>d__12(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        CollectAnimation val_3;
        int val_4;
        val_3 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_4 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.delay);
        this.<>1__state = val_4;
        return (bool)val_4;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.particlesMainModule.startLifetimeMultiplier = this.<>4__this.originalLifetimeMultipler;
        this.<>4__this.particlesStartColor.color = new UnityEngine.Color() {r = this.<>4__this.originalParticleColor};
        this.<>4__this.particlesMainModule.startColor = new MinMaxGradient() {m_Mode = this.<>4__this.particlesStartColor, m_GradientMin = this.<>4__this.particlesStartColor, m_GradientMax = ???, m_ColorMin = new UnityEngine.Color() {r = ???, g = ???, b = this.<>4__this.originalParticleColor, a = this.<>4__this.originalParticleColor}, m_ColorMax = new UnityEngine.Color() {r = this.<>4__this.originalParticleColor, g = this.<>4__this.originalParticleColor, b = 0f, a = 0f}};
        this.<>4__this.particleSystem.Play();
        val_3 = this.<>4__this.gridCoinCollectAnimation;
        var val_3 = 0;
        val_3 = val_3 + 1;
        val_3.OnSparkle();
        label_2:
        val_4 = 0;
        return (bool)val_4;
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
