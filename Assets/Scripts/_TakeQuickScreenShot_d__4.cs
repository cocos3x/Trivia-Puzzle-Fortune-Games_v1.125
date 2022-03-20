using UnityEngine;
private sealed class WGScreenshotter.<TakeQuickScreenShot>d__4 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGScreenshotter <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGScreenshotter.<TakeQuickScreenShot>d__4(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.Texture2D val_8;
        int val_9;
        val_8 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_9 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_9;
        return (bool)val_9;
        label_1:
        this.<>1__state = 0;
        UnityEngine.Texture2D val_4 = null;
        val_8 = val_4;
        val_4 = new UnityEngine.Texture2D(width:  UnityEngine.Screen.width, height:  UnityEngine.Screen.height, textureFormat:  3, mipChain:  false);
        this.<>4__this.tex = val_8;
        UnityEngine.Rect val_7 = new UnityEngine.Rect(x:  0f, y:  0f, width:  (float)UnityEngine.Screen.width, height:  (float)UnityEngine.Screen.height);
        val_4.ReadPixels(source:  new UnityEngine.Rect() {m_XMin = val_7.m_XMin, m_YMin = val_7.m_YMin, m_Width = val_7.m_Width, m_Height = val_7.m_Height}, destX:  0, destY:  0);
        this.<>4__this.tex.Apply();
        val_9 = this.<>4__this.OnScreenshotTaken;
        if(val_9 == null)
        {
                return (bool)val_9;
        }
        
        val_9.Invoke();
        label_2:
        val_9 = 0;
        return (bool)val_9;
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
