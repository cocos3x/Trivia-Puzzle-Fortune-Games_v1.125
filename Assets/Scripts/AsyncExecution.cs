using UnityEngine;
public class AsyncExecution : MonoSingletonSelfGenerating<AsyncExecution>
{
    // Fields
    private System.Collections.Generic.Dictionary<string, System.Action> currents;
    
    // Methods
    private void Awake()
    {
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
    }
    public static void StopAllExecution()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingletonSelfGenerating<AsyncExecution>.Instance)) == false)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<AsyncExecution>.Instance.StopAllCoroutines();
    }
    public void Async(System.Action callback, float when = 1)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.CallAction(current:  callback, when:  when));
    }
    public System.Collections.IEnumerator MultiAsync<T>(System.Collections.Generic.IEnumerable<T> collection, System.Action<T> collectionAction, int batchSize = 1)
    {
        mem2[0] = collection;
        mem2[0] = this;
        mem2[0] = collectionAction;
        mem2[0] = batchSize;
        return (System.Collections.IEnumerator)__RuntimeMethodHiddenParam + 48;
    }
    private System.Collections.IEnumerator MultiAction<T>(int framesToWait, System.Action<T> collectionAction, T actionArgument)
    {
        mem2[0] = framesToWait;
        mem2[0] = collectionAction;
        mem2[0] = actionArgument;
        return (System.Collections.IEnumerator)__RuntimeMethodHiddenParam + 48;
    }
    private System.Collections.IEnumerator CallAction(System.Action current, float when = 1)
    {
        .<>1__state = 0;
        .current = current;
        .when = when;
        return (System.Collections.IEnumerator)new AsyncExecution.<CallAction>d__6();
    }
    public void HaltActions()
    {
        this.StopAllCoroutines();
    }
    public AsyncExecution()
    {
    
    }

}
