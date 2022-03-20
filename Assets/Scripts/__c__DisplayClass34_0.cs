using UnityEngine;
private sealed class WFOEventPointGainAnimationV2.<>c__DisplayClass34_0
{
    // Fields
    public bool destroy;
    public UnityEngine.Transform trans;
    public WFOEventPointGainAnimationV2 <>4__this;
    
    // Methods
    public WFOEventPointGainAnimationV2.<>c__DisplayClass34_0()
    {
    
    }
    internal void <MoveSymbol>b__0()
    {
        if(this.destroy != false)
        {
                UnityEngine.Object.Destroy(obj:  this.trans.gameObject);
        }
        
        this.<>4__this.OnPointCollision();
    }

}
