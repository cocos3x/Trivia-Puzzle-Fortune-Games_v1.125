using UnityEngine;
private sealed class WGScreenshotter.<TakeScreenshot>d__5 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGScreenshotter <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGScreenshotter.<TakeScreenshot>d__5(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_20;
        int val_21;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_20 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_21 = 1;
        this.<>2__current = val_20;
        this.<>1__state = val_21;
        return (bool)val_21;
        label_1:
        val_20 = this.<>4__this;
        this.<>1__state = 0;
        if(UnityEngine.Application.isEditor != false)
        {
                UnityEngine.Debug.LogError(message:  val_20.CurrentLevelLink());
        }
        else
        {
                int val_4 = UnityEngine.Screen.width;
            int val_5 = UnityEngine.Screen.height;
            UnityEngine.Texture2D val_6 = new UnityEngine.Texture2D(width:  val_4, height:  val_5, textureFormat:  3, mipChain:  false);
            this.<>4__this.tex = val_6;
            UnityEngine.Rect val_7 = new UnityEngine.Rect(x:  0f, y:  0f, width:  (float)val_4, height:  (float)val_5);
            val_6.ReadPixels(source:  new UnityEngine.Rect() {m_XMin = val_7.m_XMin, m_YMin = val_7.m_YMin, m_Width = val_7.m_Width, m_Height = val_7.m_Height}, destX:  0, destY:  0);
            this.<>4__this.tex.Apply();
            System.DateTime val_9 = System.DateTime.Now;
            string val_12 = System.IO.Path.Combine(path1:  UnityEngine.Application.persistentDataPath, path2:  val_9.dateData.ToString(format:  "yyyy-MM-dd-HHmmss")(val_9.dateData.ToString(format:  "yyyy-MM-dd-HHmmss")) + ".png");
            System.IO.File.WriteAllBytes(path:  val_12, bytes:  UnityEngine.ImageConversion.EncodeToPNG(tex:  this.<>4__this.tex));
            TrackingComponent.CurrentIntent = 7;
            AppConfigs val_14 = App.Configuration;
            GameBehavior val_17 = App.getBehavior;
            string val_18 = System.String.Format(format:  val_17.<metaGameBehavior>k__BackingField, arg0:  System.String.Format(format:  "#{0}", arg0:  val_14.appConfig.gameName.Replace(oldValue:  " ", newValue:  System.String.alignConst)));
            TrackingComponent.CurrentIntent = 7;
            twelvegigs.plugins.SharePlugin.Share(text:  val_18, url:  val_20.CurrentLevelLink(), subject:  val_18, emailBody:  "", imgPath:  val_12);
        }
        
        val_21 = this.<>4__this.OnScreenshotTaken;
        if(val_21 == null)
        {
                return (bool)val_21;
        }
        
        val_21.Invoke();
        label_2:
        val_21 = 0;
        return (bool)val_21;
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
