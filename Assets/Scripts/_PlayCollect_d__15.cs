using UnityEngine;
private sealed class PetCardAnimationInstantiator.<PlayCollect>d__15 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PetCardAnimationInstantiator <>4__this;
    private int <i>5__2;
    private PetCardAnimationInstantiator.PetCardReward <rwd>5__3;
    private WADPets.WADPetUpgradeRequirement <upgradeRequirement>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PetCardAnimationInstantiator.<PlayCollect>d__15(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_11;
        if((this.<>1__state) <= 3)
        {
                var val_9 = 32558344 + (this.<>1__state) << 2;
            val_9 = val_9 + 32558344;
        }
        else
        {
                val_11 = 0;
            return (bool);
        }
    
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
