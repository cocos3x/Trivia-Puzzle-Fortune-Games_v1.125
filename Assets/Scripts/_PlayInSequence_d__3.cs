using UnityEngine;
private sealed class LineDrawerParticles.<PlayInSequence>d__3 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public LineDrawerParticles <>4__this;
    public System.Collections.Generic.List<UnityEngine.Vector3> selectedPositions;
    private int <i>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LineDrawerParticles.<PlayInSequence>d__3(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_2;
        int val_3;
        val_2 = this.<>1__state;
        if(val_2 == 1)
        {
            goto label_1;
        }
        
        if(val_2 != 0)
        {
            goto label_5;
        }
        
        this.<>1__state = 0;
        this.<i>5__2 = 0;
        goto label_3;
        label_1:
        this.<>1__state = 0;
        val_2 = (this.<i>5__2) + 1;
        this.<i>5__2 = val_2;
        label_3:
        if(val_2 < this.selectedPositions)
        {
                if(val_2 <= (this.<i>5__2))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2 = val_2 + ((this.<i>5__2) * 12);
            this.<>4__this.particleSystem.transform.position = new UnityEngine.Vector3() {x = (this.<i>5__2 * 12) + (this.<i>5__2 + 1) + 32, y = (this.<i>5__2 * 12) + (this.<i>5__2 + 1) + 32 + 4, z = (this.<i>5__2 * 12) + (this.<i>5__2 + 1) + 40};
            this.<>4__this.particleSystem.Play();
            val_3 = 1;
            this.<>2__current = 0;
            this.<>1__state = val_3;
            return (bool)val_3;
        }
        
        label_5:
        val_3 = 0;
        return (bool)val_3;
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
