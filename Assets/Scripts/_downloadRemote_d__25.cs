using UnityEngine;
private sealed class ImageRequest.<downloadRemote>d__25 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public string url;
    public twelvegigs.net.ImageRequest <>4__this;
    private UnityEngine.WWW <getter>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ImageRequest.<downloadRemote>d__25(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.WWW val_9;
        int val_10;
        UnityEngine.WWW val_11;
        UnityEngine.Object val_12;
        var val_13;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WWW val_1 = null;
        val_9 = val_1;
        val_1 = new UnityEngine.WWW(url:  this.url);
        val_10 = 1;
        this.<getter>5__2 = val_9;
        this.<>2__current = val_9;
        this.<>1__state = val_10;
        return (bool)val_10;
        label_1:
        val_11 = this.<getter>5__2;
        this.<>1__state = 0;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = 0;
        if(val_11.error != null)
        {
            goto label_5;
        }
        
        val_11 = this.<getter>5__2;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9 = val_11.texture;
        val_11 = val_9;
        val_12 = 0;
        if(val_11 != val_12)
        {
            goto label_9;
        }
        
        label_5:
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        val_10 = 0;
        this.<>4__this.error = true;
        mem2[0] = true;
        return (bool)val_10;
        label_9:
        val_11 = this.<getter>5__2;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = 0;
        UnityEngine.Texture2D val_5 = val_11.texture;
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = 0;
        this.<>4__this.imageTexture = val_5;
        this.<>4__this.lnFile = UnityEngine.ImageConversion.EncodeToPNG(tex:  val_5);
        if((this.<>4__this._save) != false)
        {
                System.IO.DirectoryInfo val_7 = null;
            val_9 = val_7;
            val_7 = new System.IO.DirectoryInfo(path:  this.<>4__this._path);
            if((val_9 & 1) == 0)
        {
                val_13 = 0;
            val_7.Create();
        }
        
            val_12 = this.<>4__this.lnFile;
            System.IO.File.WriteAllBytes(path:  this.<>4__this._path(this.<>4__this._path) + this.<>4__this._filename(this.<>4__this._filename), bytes:  val_12);
        }
        
        this.<>4__this.fireOnComplete();
        mem2[0] = 1;
        val_11 = this.<getter>5__2;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.Dispose();
        label_2:
        val_10 = 0;
        return (bool)val_10;
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
