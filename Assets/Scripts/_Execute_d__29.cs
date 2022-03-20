using UnityEngine;
private sealed class DLCManager.<Execute>d__29 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public DLCManager <>4__this;
    private int <desiredVersion>5__2;
    private UnityEngine.WWW <loadingClass>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public DLCManager.<Execute>d__29(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_16;
        var val_17;
        int val_18;
        int val_19;
        bool val_20;
        var val_21;
        var val_22;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<desiredVersion>5__2 = this.<>4__this.currentAssetVersion;
        val_16 = null;
        val_16 = null;
        if((DLCManager.NOTIFICATION_ASSET_LOADED.ContainsKey(key:  this.<>4__this.currentAssetToLoad)) == false)
        {
            goto label_7;
        }
        
        val_17 = null;
        val_17 = null;
        this.<>4__this.currentOnDownloadedCallback.Invoke(obj:  DLCManager.NOTIFICATION_ASSET_LOADED.Item[this.<>4__this.currentAssetToLoad]);
        goto label_12;
        label_1:
        this.<>1__state = 0;
        if((this.<loadingClass>5__3.error) == null)
        {
            goto label_14;
        }
        
        string[] val_4 = new string[8];
        val_4[0] = "DLCManager :: Error loading: ";
        val_18 = val_4.Length;
        val_4[1] = this.<loadingClass>5__3.url;
        val_18 = val_4.Length;
        val_4[2] = "  (";
        if((this.<>4__this.currentAssetToLoad) != null)
        {
                val_18 = val_4.Length;
        }
        
        val_4[3] = this.<>4__this.currentAssetToLoad;
        val_18 = val_4.Length;
        val_4[4] = "): ";
        val_19 = val_4.Length;
        val_4[5] = this.<loadingClass>5__3.error;
        val_19 = val_4.Length;
        val_4[6] = " desiredVersion: ";
        val_4[7] = this.<desiredVersion>5__2.ToString();
        UnityEngine.Debug.Log(message:  +val_4);
        goto label_59;
        label_7:
        val_20 = true;
        this.<>4__this.executing = val_20;
        UnityEngine.WWW val_11 = UnityEngine.WWW.LoadFromCacheOrDownload(url:  System.String.Format(format:  this.<>4__this.baseString, arg0:  this.<>4__this.currentAssetPath, arg1:  this.<desiredVersion>5__2)(System.String.Format(format:  this.<>4__this.baseString, arg0:  this.<>4__this.currentAssetPath, arg1:  this.<desiredVersion>5__2)) + this.<>4__this.currentAssetToLoad(this.<>4__this.currentAssetToLoad) + this.<>4__this.fileExtension(this.<>4__this.fileExtension), version:  this.<desiredVersion>5__2);
        this.<loadingClass>5__3 = val_11;
        this.<>2__current = val_11;
        this.<>1__state = val_20;
        return (bool)val_20;
        label_14:
        val_21 = null;
        val_21 = null;
        if((DLCManager.NOTIFICATION_ASSET_LOADED.ContainsKey(key:  this.<>4__this.currentAssetToLoad)) != true)
        {
                val_22 = null;
            val_22 = null;
            DLCManager.NOTIFICATION_ASSET_LOADED.Add(key:  this.<>4__this.currentAssetToLoad, value:  this.<loadingClass>5__3.assetBundle);
        }
        
        if((this.<>4__this.SavedAssetsMap.ContainsKey(key:  this.<>4__this.currentAssetToLoad)) != true)
        {
                this.<>4__this.SavedAssetsMap.Add(key:  this.<>4__this.currentAssetToLoad, value:  this.<>4__this.currentAssetVersion);
        }
        
        this.<>4__this.SaveAlreadySavedAssets();
        if((this.<>4__this.currentOnDownloadedCallback) != null)
        {
                this.<>4__this.currentOnDownloadedCallback.Invoke(obj:  this.<loadingClass>5__3.assetBundle);
        }
        
        label_59:
        this.<loadingClass>5__3.Dispose();
        this.<loadingClass>5__3 = 0;
        label_12:
        this.<>4__this.Dequeue();
        label_2:
        val_20 = 0;
        return (bool)val_20;
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
