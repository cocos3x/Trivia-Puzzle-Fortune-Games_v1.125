using UnityEngine;
private sealed class SkeletonRagdoll2D.<SmoothMixCoroutine>d__39 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Spine.Unity.Modules.SkeletonRagdoll2D <>4__this;
    public float target;
    public float duration;
    private float <startTime>5__2;
    private float <startMix>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SkeletonRagdoll2D.<SmoothMixCoroutine>d__39(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_5;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<startTime>5__2 = UnityEngine.Time.time;
        this.<startMix>5__3 = this.<>4__this.mix;
        goto label_4;
        label_1:
        this.<>1__state = 0;
        label_4:
        if((this.<>4__this.mix) > 0f)
        {
            goto label_6;
        }
        
        label_2:
        val_5 = 0;
        return (bool)val_5;
        label_6:
        this.<>4__this.skeleton.SetBonesToSetupPose();
        float val_2 = UnityEngine.Time.time;
        val_2 = val_2 - (this.<startTime>5__2);
        val_5 = 1;
        this.<>4__this.mix = UnityEngine.Mathf.SmoothStep(from:  this.<startMix>5__3, to:  this.target, t:  val_2 / this.duration);
        this.<>2__current = 0;
        this.<>1__state = val_5;
        return (bool)val_5;
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
