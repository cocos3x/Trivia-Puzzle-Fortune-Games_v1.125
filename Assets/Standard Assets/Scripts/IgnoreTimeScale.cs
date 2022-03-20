using UnityEngine;
public class IgnoreTimeScale : MonoBehaviour
{
    // Fields
    private float mRt;
    private float mTimeStart;
    private float mTimeDelta;
    private float mActual;
    private bool mTimeStarted;
    
    // Properties
    public float realTime { get; }
    public float realTimeDelta { get; }
    
    // Methods
    public float get_realTime()
    {
        return (float)this.mRt;
    }
    public float get_realTimeDelta()
    {
        return (float)this.mTimeDelta;
    }
    protected virtual void OnEnable()
    {
        this.mTimeStarted = true;
        this.mTimeDelta = 0f;
        this.mTimeStart = UnityEngine.Time.realtimeSinceStartup;
    }
    protected float UpdateRealTimeDelta()
    {
        var val_4;
        var val_6;
        float val_7;
        float val_1 = UnityEngine.Time.realtimeSinceStartup;
        this.mRt = val_1;
        if(this.mTimeStarted == false)
        {
            goto label_1;
        }
        
        float val_2 = val_1 - this.mTimeStart;
        float val_3 = UnityEngine.Mathf.Max(a:  0f, b:  val_2);
        val_3 = this.mActual + val_3;
        this.mActual = val_3;
        val_2 = val_3 * 1000f;
        if(val_2 >= 0f)
        {
            goto label_4;
        }
        
        if((double)val_2 != (-0.5))
        {
            goto label_5;
        }
        
        val_6 = val_4;
        val_7 = -1f;
        goto label_6;
        label_1:
        this.mTimeStart = val_1;
        this.mTimeDelta = 0f;
        this.mTimeStarted = true;
        return 1f;
        label_4:
        if((double)val_2 != 0.5)
        {
            goto label_8;
        }
        
        val_6 = val_4;
        val_7 = 1f;
        label_6:
        float val_5 = (float)val_6;
        val_7 = val_5 + val_7;
        val_5 = (((long)val_6 & 1) != 0) ? (val_5) : (val_7);
        goto label_10;
        label_5:
        float val_6 = -0.5f;
        val_6 = val_2 + val_6;
        goto label_10;
        label_8:
        float val_7 = 0.5f;
        val_7 = val_2 + val_7;
        label_10:
        float val_8 = 0.001f;
        val_7 = val_7 * val_8;
        val_8 = this.mActual - val_7;
        this.mTimeDelta = val_7;
        this.mActual = val_8;
        if(val_7 > 1f)
        {
                this.mTimeDelta = 1f;
        }
        
        this.mTimeStart = this.mRt;
        return 1f;
    }
    public IgnoreTimeScale()
    {
    
    }

}
