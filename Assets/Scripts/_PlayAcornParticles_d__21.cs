using UnityEngine;
private sealed class WFOManagerGameplayUI.<PlayAcornParticles>d__21 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public int wordIndex;
    public WordForest.WFOManagerGameplayUI <>4__this;
    public System.Collections.Generic.List<int> slotIndices;
    private System.Collections.Generic.List<Cell> <cells>5__2;
    private int <q>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WFOManagerGameplayUI.<PlayAcornParticles>d__21(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WordForest.WFOAcornGameBalanceParticle val_16;
        System.Collections.Generic.List<Cell> val_17;
        System.Collections.Generic.List<Cell> val_18;
        var val_19;
        var val_20;
        val_16 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_7;
        }
        
        this.<>1__state = 0;
        if((this.wordIndex < 1) || (this.wordIndex >= (X22 + 24)))
        {
            goto label_7;
        }
        
        if(this.wordIndex == 1)
        {
            goto label_8;
        }
        
        if((X22 + 24) <= this.wordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_15 = X22 + 16;
        val_15 = val_15 + ((this.wordIndex) << 3);
        val_17 = mem[(X22 + 16 + (this.wordIndex) << 3) + 32 + 40];
        val_17 = (X22 + 16 + (this.wordIndex) << 3) + 32 + 40;
        val_18 = val_16;
        val_19 = 0;
        this.<cells>5__2 = val_17;
        mem[1152921518152617040] = 0;
        if(val_17 != 0)
        {
            goto label_11;
        }
        
        label_1:
        val_18 = this.<cells>5__2;
        this.<>1__state = 0;
        goto label_13;
        label_8:
        UnityEngine.Vector3 val_3 = this.<>4__this.extraWordGameplayIcon.transform.position;
        this.<>4__this.acornParticleSystem.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        val_16 = this.<>4__this.acornParticleSystem;
        UnityEngine.Vector3 val_6 = this.<>4__this.acornStatView.AppleIcon.transform.position;
        val_16.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, particleCount:  1, animateStatView:  true);
        label_7:
        val_20 = 0;
        return (bool)val_20;
        label_26:
        if((val_16.Contains(item:  1)) == true)
        {
            goto label_24;
        }
        
        label_13:
        val_19 = X22 + 1;
        mem2[0] = val_19;
        val_17 = mem[this.wordIndex];
        val_17 = this.wordIndex;
        label_11:
        if(val_19 < (this.wordIndex + 24))
        {
            goto label_26;
        }
        
        val_20 = 0;
        mem2[0] = 0;
        return (bool)val_20;
        label_24:
        if((this.wordIndex + 24) <= X22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_16 = this.wordIndex + 16;
        val_16 = val_16 + ((X22) << 3);
        UnityEngine.Vector3 val_10 = (this.wordIndex + 16 + (X22) << 3) + 32.transform.position;
        1.transform.position = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
        UnityEngine.Vector3 val_13 = 9733424.AppleIcon.transform.position;
        val_20 = 1;
        1.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, particleCount:  1, animateStatView:  true);
        mem2[0] = new UnityEngine.WaitForSeconds(seconds:  0.1f);
        mem2[0] = val_20;
        return (bool)val_20;
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
