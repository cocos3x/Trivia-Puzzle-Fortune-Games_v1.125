using UnityEngine;
[Serializable]
public struct ExposedList.Enumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
{
    // Fields
    private Spine.ExposedList<T> l;
    private int next;
    private int ver;
    private T current;
    
    // Properties
    public T Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    internal ExposedList.Enumerator<T>(Spine.ExposedList<T> l)
    {
        mem[1152921510587525816] = 0;
        mem[1152921510587525800] = 0;
        mem[1152921510587525784] = 0;
        mem[1152921510587525768] = 0;
        this = l;
        if(l != null)
        {
                mem[1152921510587525772] = ???;
            return;
        }
        
        throw new NullReferenceException();
    }
    public void Dispose()
    {
        this = 0;
    }
    private void VerifyState()
    {
        if((new ExposedList.Enumerator<T>()) != 0)
        {
                return;
        }
        
        throw new System.ObjectDisposedException(objectName:  null.GetType());
    }
    public bool MoveNext()
    {
        var val_3;
        this.VerifyState();
        if(((__RuntimeMethodHiddenParam + 24 + 192) & 2147483648) == 0)
        {
                mem[1152921510587891672] = (__RuntimeMethodHiddenParam + 24 + 192) + 1;
            val_3 = 1;
            mem[1152921510587891680] = (ExposedList.Enumerator<T>.__il2cppRuntimeField_name + (__RuntimeMethodHiddenParam + 24 + 192) << 3) + 32;
            return (bool);
        }
        
        val_3 = 0;
        return (bool);
    }
    public T get_Current()
    {
        return (Spine.Animation)this;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        this.VerifyState();
        mem[1152921510588115672] = 0;
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        this.VerifyState();
        if((__RuntimeMethodHiddenParam + 24 + 192) <= 0)
        {
                throw new System.InvalidOperationException();
        }
        
        return (object);
    }

}
