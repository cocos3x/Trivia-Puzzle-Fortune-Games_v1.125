using UnityEngine;
public class ResourceLoader : MonoSingletonSelfGenerating<ResourceLoader>
{
    // Fields
    private bool initialized;
    private System.Collections.Generic.Dictionary<string, object> cachedAssets;
    
    // Methods
    public UnityEngine.GameObject GetPrefabFromBundle(string bundleName, string prefabName)
    {
        object val_10;
        var val_11;
        var val_12;
        if((this.CacheHasAsset(bundleName:  bundleName, assetName:  prefabName)) == false)
        {
            goto label_1;
        }
        
        object val_2 = this.GetObjectFromCache(bundleName:  bundleName, assetName:  prefabName);
        if(val_2 == null)
        {
            goto label_2;
        }
        
        var val_3 = (null == null) ? (val_2) : 0;
        return (UnityEngine.GameObject)val_10;
        label_1:
        val_11 = null;
        val_11 = null;
        if((App.dlcManager.IsAssetAvailable(bundleName:  bundleName, version:  0)) == false)
        {
                throw new UnityEngine.UnityException(message:  +new string[5]);
        }
        
        val_12 = null;
        val_12 = null;
        val_10 = App.dlcManager.GetBundle(bundleName:  bundleName).LoadAsset<UnityEngine.GameObject>(name:  prefabName);
        this.PutAssetInCache(bundleName:  bundleName, assetName:  prefabName, toPutInCache:  val_10);
        return (UnityEngine.GameObject)val_10;
        label_2:
        val_10 = 0;
        return (UnityEngine.GameObject)val_10;
    }
    public UnityEngine.Font GetFontFromBundle(string bundleName, string fontName)
    {
        object val_10;
        var val_11;
        var val_12;
        if((this.CacheHasAsset(bundleName:  bundleName, assetName:  fontName)) == false)
        {
            goto label_1;
        }
        
        object val_2 = this.GetObjectFromCache(bundleName:  bundleName, assetName:  fontName);
        if(val_2 == null)
        {
            goto label_2;
        }
        
        var val_3 = (null == null) ? (val_2) : 0;
        return (UnityEngine.Font)val_10;
        label_1:
        val_11 = null;
        val_11 = null;
        if((App.dlcManager.IsAssetAvailable(bundleName:  bundleName, version:  0)) == false)
        {
                throw new UnityEngine.UnityException(message:  +new string[5]);
        }
        
        val_12 = null;
        val_12 = null;
        val_10 = App.dlcManager.GetBundle(bundleName:  bundleName).LoadAsset<UnityEngine.Font>(name:  fontName);
        this.PutAssetInCache(bundleName:  bundleName, assetName:  fontName, toPutInCache:  val_10);
        return (UnityEngine.Font)val_10;
        label_2:
        val_10 = 0;
        return (UnityEngine.Font)val_10;
    }
    public UnityEngine.Sprite GetSpriteFromBundle(string bundleName, string spriteName)
    {
        object val_10;
        var val_11;
        var val_12;
        if((this.CacheHasAsset(bundleName:  bundleName, assetName:  spriteName)) == false)
        {
            goto label_1;
        }
        
        object val_2 = this.GetObjectFromCache(bundleName:  bundleName, assetName:  spriteName);
        if(val_2 == null)
        {
            goto label_2;
        }
        
        var val_3 = (null == null) ? (val_2) : 0;
        return (UnityEngine.Sprite)val_10;
        label_1:
        val_11 = null;
        val_11 = null;
        if((App.dlcManager.IsAssetAvailable(bundleName:  bundleName, version:  0)) == false)
        {
                throw new UnityEngine.UnityException(message:  +new string[5]);
        }
        
        val_12 = null;
        val_12 = null;
        val_10 = App.dlcManager.GetBundle(bundleName:  bundleName).LoadAsset<UnityEngine.Sprite>(name:  spriteName);
        this.PutAssetInCache(bundleName:  bundleName, assetName:  spriteName, toPutInCache:  val_10);
        return (UnityEngine.Sprite)val_10;
        label_2:
        val_10 = 0;
        return (UnityEngine.Sprite)val_10;
    }
    public UnityEngine.Texture GetTextureFromBundle(string bundleName, string textureName)
    {
        object val_10;
        var val_11;
        var val_12;
        if((this.CacheHasAsset(bundleName:  bundleName, assetName:  textureName)) != false)
        {
                object val_2 = this.GetObjectFromCache(bundleName:  bundleName, assetName:  textureName);
            val_10 = 0;
            return (UnityEngine.Texture);
        }
        
        val_11 = null;
        val_11 = null;
        if((App.dlcManager.IsAssetAvailable(bundleName:  bundleName, version:  0)) == false)
        {
                throw new UnityEngine.UnityException(message:  +new string[5]);
        }
        
        val_12 = null;
        val_12 = null;
        val_10 = App.dlcManager.GetBundle(bundleName:  bundleName).LoadAsset<UnityEngine.Texture>(name:  textureName);
        this.PutAssetInCache(bundleName:  bundleName, assetName:  textureName, toPutInCache:  val_10);
        return (UnityEngine.Texture);
    }
    public UnityEngine.AudioClip GetSoundFromBundle(string bundleName, string audioClipName)
    {
        object val_10;
        var val_11;
        var val_12;
        if((this.CacheHasAsset(bundleName:  bundleName, assetName:  audioClipName)) == false)
        {
            goto label_1;
        }
        
        object val_2 = this.GetObjectFromCache(bundleName:  bundleName, assetName:  audioClipName);
        if(val_2 == null)
        {
            goto label_2;
        }
        
        var val_3 = (null == null) ? (val_2) : 0;
        return (UnityEngine.AudioClip)val_10;
        label_1:
        val_11 = null;
        val_11 = null;
        if((App.dlcManager.IsAssetAvailable(bundleName:  bundleName, version:  0)) == false)
        {
                throw new UnityEngine.UnityException(message:  +new string[5]);
        }
        
        val_12 = null;
        val_12 = null;
        val_10 = App.dlcManager.GetBundle(bundleName:  bundleName).LoadAsset<UnityEngine.AudioClip>(name:  audioClipName);
        this.PutAssetInCache(bundleName:  bundleName, assetName:  audioClipName, toPutInCache:  val_10);
        return (UnityEngine.AudioClip)val_10;
        label_2:
        val_10 = 0;
        return (UnityEngine.AudioClip)val_10;
    }
    private bool CacheHasAsset(string bundleName, string assetName)
    {
        return this.cachedAssets.ContainsKey(key:  bundleName + "_" + assetName);
    }
    private object GetObjectFromCache(string bundleName, string assetName)
    {
        return this.cachedAssets.Item[bundleName + "_" + assetName];
    }
    private void PutAssetInCache(string bundleName, string assetName, object toPutInCache)
    {
        this.cachedAssets.Add(key:  bundleName + "_" + assetName, value:  toPutInCache);
    }
    private void Init()
    {
        this.initialized = true;
    }
    public ResourceLoader()
    {
        this.cachedAssets = new System.Collections.Generic.Dictionary<System.String, System.Object>();
    }

}
