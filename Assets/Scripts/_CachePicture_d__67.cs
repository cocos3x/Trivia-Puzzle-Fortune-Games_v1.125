using UnityEngine;
private sealed class CUtils.<CachePicture>d__67 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public string url;
    public System.Action<bool> result;
    private string <localPath>5__2;
    private UnityEngine.WWW <www>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public CUtils.<CachePicture>d__67(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_7;
        var val_8;
        var val_9;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<localPath>5__2 = CUtils.GetLocalPath(url:  this.url);
        UnityEngine.WWW val_2 = new UnityEngine.WWW(url:  this.url);
        val_7 = 1;
        this.<www>5__3 = val_2;
        this.<>2__current = val_2;
        this.<>1__state = val_7;
        return (bool)val_7;
        label_1:
        this.<>1__state = 0;
        if(((this.<www>5__3.isDone) != false) && ((System.String.IsNullOrEmpty(value:  this.<www>5__3.error)) != false))
        {
                System.IO.File.WriteAllBytes(path:  this.<localPath>5__2, bytes:  this.<www>5__3.bytes);
            val_7 = this.result;
            if(val_7 == null)
        {
                return (bool)val_7;
        }
        
            val_8 = 1152921510229859200;
            val_9 = 1;
        }
        else
        {
                val_7 = this.result;
            if(val_7 == null)
        {
                return (bool)val_7;
        }
        
            val_8 = 1152921510229859200;
            val_9 = 0;
        }
        
        val_7.Invoke(obj:  false);
        label_2:
        val_7 = 0;
        return (bool)val_7;
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
