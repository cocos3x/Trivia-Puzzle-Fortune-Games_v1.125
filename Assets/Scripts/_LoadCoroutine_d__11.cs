using UnityEngine;
private sealed class SRSceneServiceBase.<LoadCoroutine>d__11<T, TImpl> : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SRF.Service.SRSceneServiceBase<T, TImpl> <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SRSceneServiceBase.<LoadCoroutine>d__11<T, TImpl>(int <>1__state)
    {
        mem[1152921519483005632] = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_15;
        string val_16;
        var val_17;
        var val_18;
        var val_19;
        var val_21;
        val_15 = this;
        if(true == 1)
        {
            goto label_1;
        }
        
        val_17 = 0;
        if(true != 0)
        {
                return (bool)val_17;
        }
        
        mem[1152921519483266832] = 0;
        if(static_value_0280A048 != 0)
        {
            goto label_31;
        }
        
        val_18 = null;
        val_18 = null;
        int val_15 = SRF.Service.SRServiceManager.LoadingCount;
        val_15 = val_15 + 1;
        SRF.Service.SRServiceManager.LoadingCount = val_15;
        UnityEngine.SceneManagement.Scene val_2 = UnityEngine.SceneManagement.SceneManager.GetSceneByName(name:  41984000);
        if(val_2.m_Handle.isLoaded == true)
        {
            goto label_11;
        }
        
        val_16 = 41984000;
        val_17 = 1;
        mem[1152921519483266840] = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName:  val_16, mode:  1);
        mem[1152921519483266832] = val_17;
        return (bool)val_17;
        label_1:
        mem[1152921519483266832] = 0;
        label_11:
        UnityEngine.GameObject val_5 = UnityEngine.GameObject.Find(name:  41984000);
        if(val_5 != 0)
        {
                if(val_5 != 0)
        {
            goto label_22;
        }
        
        }
        
        val_19 = null;
        val_19 = null;
        int val_16 = SRF.Service.SRServiceManager.LoadingCount;
        val_16 = val_16 - 1;
        SRF.Service.SRServiceManager.LoadingCount = val_16;
        object[] val_8 = new object[1];
        val_15 = 41984000;
        val_8[0] = val_15;
        UnityEngine.Debug.LogError(message:  SRF.SRFStringExtensions.Fmt(formatString:  "[Service] Root object ({0}) not found", args:  val_8), context:  41984000);
        enabled = false;
        goto label_31;
        label_22:
        val_5.transform.parent = CachedTransform;
        UnityEngine.Object.DontDestroyOnLoad(target:  val_5);
        object[] val_12 = new object[2];
        val_12[0] = GetType();
        val_15 = 41984000;
        val_12[1] = val_15;
        UnityEngine.Debug.Log(message:  SRF.SRFStringExtensions.Fmt(formatString:  "[Service] Loading {0} complete. (Scene: {1})", args:  val_12), context:  41984000);
        val_21 = null;
        val_21 = null;
        int val_17 = SRF.Service.SRServiceManager.LoadingCount;
        val_17 = val_17 - 1;
        SRF.Service.SRServiceManager.LoadingCount = val_17;
        label_31:
        val_17 = 0;
        return (bool)val_17;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this;
    }

}
