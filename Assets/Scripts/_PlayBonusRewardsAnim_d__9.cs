using UnityEngine;
private sealed class WGBonusRewardsStoreDisplay.<PlayBonusRewardsAnim>d__9 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGBonusRewardsStoreDisplay <>4__this;
    public int particleCount;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGBonusRewardsStoreDisplay.<PlayBonusRewardsAnim>d__9(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_6;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_6 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.8f);
        this.<>1__state = val_6;
        return (bool)val_6;
        label_1:
        this.<>1__state = 0;
        UnityEngine.Vector3 val_3 = this.<>4__this.transform.position;
        int val_6 = this.particleCount;
        val_6 = val_6 * 1717986919;
        val_6 = val_6 >> 34;
        this.<>4__this.brcParticles.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, particleCount:  val_6 + (val_6 >> 63), animateStatView:  true);
        label_2:
        val_6 = 0;
        return (bool)val_6;
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
