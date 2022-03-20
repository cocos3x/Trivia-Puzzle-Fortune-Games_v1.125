using UnityEngine;
public abstract class BasedOnResolution : MonoBehaviour
{
    // Fields
    protected float currentWidth;
    protected float currentHeight;
    protected float currentResolution;
    
    // Methods
    protected virtual void Start()
    {
        this.currentWidth = (float)UnityEngine.Screen.width;
        int val_2 = UnityEngine.Screen.height;
        float val_4 = this.currentWidth;
        this.currentHeight = (float)val_2;
        val_4 = val_4 / (float)val_2;
        this.currentResolution = val_2.ShortenToSigFigs(number:  val_4);
        goto typeof(BasedOnResolution).__il2cppRuntimeField_180;
    }
    protected virtual void Modify()
    {
        if(this.currentResolution > 1.7f)
        {
            
        }
        else
        {
                if((this.currentResolution > 1.6f) && ((double)this.currentResolution <= 1.7))
        {
            
        }
        else
        {
                if((this.currentResolution <= 1.6f) && (this.currentResolution > 1.5f))
        {
            
        }
        else
        {
                if((this.currentResolution <= 1.5f) && (this.currentResolution > 1.333f))
        {
            
        }
        else
        {
                if(this.currentResolution <= 1.333f)
        {
            goto typeof(BasedOnResolution).__il2cppRuntimeField_1D0;
        }
        
        }
        
        }
        
        }
        
        }
    
    }
    protected abstract void Apply17x10(); // 0
    protected abstract void Apply16x9(); // 0
    protected abstract void Apply16x10(); // 0
    protected abstract void Apply3x2(); // 0
    protected abstract void Apply4x3(); // 0
    protected float ShortenToSigFigs(float number)
    {
        decimal val_1 = System.Convert.ToDecimal(value:  number);
        decimal val_2 = new System.Decimal(value:  100);
        decimal val_3 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        decimal val_4 = System.Math.Truncate(d:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        decimal val_5 = new System.Decimal(value:  100);
        decimal val_6 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.flags, lo = val_5.lo, mid = val_5.lo});
        return (float)System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
    }
    protected BasedOnResolution()
    {
    
    }

}
