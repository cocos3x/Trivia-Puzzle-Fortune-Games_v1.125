using UnityEngine;
private sealed class CUtils.<LoadPicture>d__65 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public string url;
    public bool useCached;
    public System.Action<UnityEngine.Texture2D> callback;
    public int width;
    public int height;
    private string <localPath>5__2;
    private UnityEngine.WWW <www>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public CUtils.<LoadPicture>d__65(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_10;
        int val_11;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        string val_1 = CUtils.GetLocalPath(url:  this.url);
        this.<localPath>5__2 = val_1;
        if(this.useCached == false)
        {
            goto label_8;
        }
        
        val_10 = this.height;
        if((CUtils.LoadFromLocal(callback:  this.callback, localPath:  val_1, width:  this.width, height:  val_10)) == false)
        {
            goto label_8;
        }
        
        label_2:
        val_11 = 0;
        return (bool)val_11;
        label_1:
        this.<>1__state = 0;
        if(((this.<www>5__3.isDone) != false) && ((System.String.IsNullOrEmpty(value:  this.<www>5__3.error)) != false))
        {
                this.callback.Invoke(obj:  this.<www>5__3.texture);
            System.IO.File.WriteAllBytes(path:  this.<localPath>5__2, bytes:  this.<www>5__3.bytes);
        }
        else
        {
                val_10 = this.width;
            bool val_8 = CUtils.LoadFromLocal(callback:  this.callback, localPath:  this.<localPath>5__2, width:  val_10, height:  this.height);
        }
        
        val_11 = 0;
        this.<www>5__3 = 0;
        return (bool)val_11;
        label_8:
        UnityEngine.WWW val_9 = null;
        val_10 = val_9;
        val_9 = new UnityEngine.WWW(url:  this.url);
        val_11 = 1;
        this.<www>5__3 = val_10;
        this.<>2__current = val_10;
        this.<>1__state = val_11;
        return (bool)val_11;
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
