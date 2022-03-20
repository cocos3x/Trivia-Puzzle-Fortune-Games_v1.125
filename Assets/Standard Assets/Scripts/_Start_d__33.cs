using UnityEngine;
private sealed class SkeletonRagdoll.<Start>d__33 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Spine.Unity.Modules.SkeletonRagdoll <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SkeletonRagdoll.<Start>d__33(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        Spine.Unity.ISkeletonAnimation val_6;
        int val_8;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_19;
        }
        
        this.<>1__state = 0;
        if(Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper == 0)
        {
                Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper = new UnityEngine.GameObject(name:  "Parent Space Helper").transform;
            Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper.hideFlags = 1;
        }
        
        Spine.Unity.SkeletonRenderer val_4 = this.<>4__this.GetComponent<Spine.Unity.SkeletonRenderer>();
        val_6 = X0;
        this.<>4__this.targetSkeletonComponent = null;
        if(X0 != true)
        {
                UnityEngine.Debug.LogError(message:  "Attached Spine component does not implement ISkeletonAnimation. This script is not compatible.");
            val_6 = this.<>4__this.targetSkeletonComponent;
        }
        
        var val_7 = 0;
        val_7 = val_7 + 1;
        goto label_16;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.Apply();
        goto label_19;
        label_16:
        this.<>4__this.skeleton = val_6.Skeleton;
        if((this.<>4__this.applyOnStart) != false)
        {
                val_8 = 1;
            this.<>2__current = 0;
            this.<>1__state = val_8;
            return (bool)val_8;
        }
        
        label_19:
        val_8 = 0;
        return (bool)val_8;
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
