using UnityEngine;
private sealed class TwistyArrowLogic.<>c__DisplayClass20_0
{
    // Fields
    public float angle;
    
    // Methods
    public TwistyArrowLogic.<>c__DisplayClass20_0()
    {
    
    }
    internal bool <CheckCollision>b__0(float a)
    {
        var val_4;
        if((UnityEngine.Mathf.DeltaAngle(current:  -a, target:  this.angle)) >= (-36f))
        {
                return (bool)((UnityEngine.Mathf.DeltaAngle(current:  -a, target:  this.angle)) < 0) ? 1 : 0;
        }
        
        val_4 = 0;
        return (bool)((UnityEngine.Mathf.DeltaAngle(current:  -a, target:  this.angle)) < 0) ? 1 : 0;
    }

}
