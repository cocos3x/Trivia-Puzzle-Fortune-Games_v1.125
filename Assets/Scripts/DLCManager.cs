using UnityEngine;
public class DLCManager : MonoBehaviour
{
    // Fields
    private string currentAssetToLoad;
    private string currentAssetPath;
    private int currentAssetVersion;
    private bool executing;
    private bool dlc_loaded;
    private string baseString;
    private const string PP_SavedDLC = "PP_SavedDLC";
    private System.Collections.Generic.Dictionary<string, int> SavedAssetsMap;
    private System.Action<UnityEngine.AssetBundle> currentOnDownloadedCallback;
    private System.Collections.Generic.List<DLCManager.DLCRequest> RequestsQueue;
    private static System.Collections.Generic.Dictionary<string, UnityEngine.AssetBundle> LoadedAssets;
    public const string NOTIFICATION_ASSET_LOADED = "OnAssetLoaded";
    private bool hasCheckedVersion;
    private string fileExtension;
    
    // Properties
    private static char slash { get; }
    
    // Methods
    public void DownloadResource(string bundlePath, string bundleName, int bundleVersion, System.Action<UnityEngine.AssetBundle> onDownloadedCallback)
    {
        if(this.executing != false)
        {
                this.EnqueueRequest(assetToLoad:  bundleName, assetPath:  bundlePath, assetVersion:  bundleVersion, onDownloadedCallback:  onDownloadedCallback);
            return;
        }
        
        this.currentAssetToLoad = bundleName;
        this.currentAssetPath = bundlePath;
        this.currentAssetVersion = bundleVersion;
        this.currentOnDownloadedCallback = onDownloadedCallback;
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.Execute());
    }
    public UnityEngine.AssetBundle GetBundle(string bundleName)
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = null;
        val_3 = null;
        if((DLCManager.NOTIFICATION_ASSET_LOADED.ContainsKey(key:  bundleName)) != false)
        {
                val_4 = null;
            val_4 = null;
            UnityEngine.AssetBundle val_2 = DLCManager.NOTIFICATION_ASSET_LOADED.Item[bundleName];
            return (UnityEngine.AssetBundle)val_5;
        }
        
        val_5 = 0;
        return (UnityEngine.AssetBundle)val_5;
    }
    public bool IsAssetAvailable(string bundleName, int version = -1)
    {
        null = null;
        return DLCManager.NOTIFICATION_ASSET_LOADED.ContainsKey(key:  bundleName);
    }
    public static string DLCPath()
    {
        var val_4 = null;
        return (string)UnityEngine.Application.dataPath + System.IO.Path.DirectorySeparatorChar.ToString() + "DLC";
    }
    private void Awake()
    {
        this.Initialize();
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void DLCManager::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        this.LoadAssets();
    }
    private void Initialize()
    {
        this.fileExtension = "";
        AppConfigs val_1 = App.Configuration;
        this.currentAssetVersion = val_1.dlcConfig.version;
        this.LoadAlreadySavedAssets();
        this.LoadAssets();
    }
    private void LoadAssets()
    {
        AppConfigs val_1 = App.Configuration;
        List.Enumerator<T> val_2 = val_1.dlcConfig.packing_tags.GetEnumerator();
        label_8:
        bool val_3 = 0.MoveNext();
        if(val_3 == false)
        {
            goto label_6;
        }
        
        if((val_3.IsAssetAvailable(bundleName:  0, version:  0)) == true)
        {
            goto label_8;
        }
        
        this.DownloadResource(bundlePath:  "word_games", bundleName:  0, bundleVersion:  this.currentAssetVersion, onDownloadedCallback:  new System.Action<UnityEngine.AssetBundle>(object:  this, method:  System.Void DLCManager::CheckAllAssetsLoaded(UnityEngine.AssetBundle loaded)));
        goto label_8;
        label_6:
        0.Dispose();
    }
    private void LoadAlreadySavedAssets()
    {
        var val_7;
        string val_8;
        string val_14;
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_15;
        this.SavedAssetsMap = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "PP_SavedDLC", defaultValue:  "{}"));
        Dictionary.Enumerator<TKey, TValue> val_5 = GetEnumerator();
        label_11:
        val_14 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(val_7.MoveNext() == false)
        {
            goto label_6;
        }
        
        val_15 = this.SavedAssetsMap;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14 = val_8;
        if((val_15.ContainsKey(key:  val_14)) == true)
        {
            goto label_11;
        }
        
        if(val_8 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_15 = val_8;
        val_14 = 511;
        if(this.SavedAssetsMap == null)
        {
                throw new NullReferenceException();
        }
        
        this.SavedAssetsMap.Add(key:  val_8, value:  System.Int32.Parse(s:  val_15, style:  val_14));
        goto label_11;
        label_6:
        val_7.Dispose();
        Dictionary.Enumerator<TKey, TValue> val_12 = this.SavedAssetsMap.GetEnumerator();
        label_14:
        if(0.MoveNext() == false)
        {
            goto label_13;
        }
        
        this.DownloadResource(bundlePath:  "word_games", bundleName:  0, bundleVersion:  0, onDownloadedCallback:  0);
        goto label_14;
        label_13:
        0.Dispose();
    }
    private void SaveAlreadySavedAssets()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "PP_SavedDLC", value:  MiniJSON.Json.Serialize(obj:  this.SavedAssetsMap));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void CheckAllAssetsLoaded(UnityEngine.AssetBundle loaded)
    {
        var val_5;
        if(this.dlc_loaded == true)
        {
                return;
        }
        
        AppConfigs val_1 = App.Configuration;
        List.Enumerator<T> val_2 = val_1.dlcConfig.packing_tags.GetEnumerator();
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_7;
        }
        
        val_5 = null;
        val_5 = null;
        if(DLCManager.NOTIFICATION_ASSET_LOADED == null)
        {
                throw new NullReferenceException();
        }
        
        if((DLCManager.NOTIFICATION_ASSET_LOADED.ContainsKey(key:  0)) == true)
        {
            goto label_11;
        }
        
        0.Dispose();
        return;
        label_7:
        0.Dispose();
        this.dlc_loaded = true;
    }
    private void EnqueueRequest(string assetToLoad, string assetPath, int assetVersion, System.Action<UnityEngine.AssetBundle> onDownloadedCallback)
    {
        if((this.AlreadyQueued(assetToLoad:  assetToLoad)) != false)
        {
                return;
        }
        
        .asset = assetToLoad;
        .assetPath = assetPath;
        .assetVersion = assetVersion;
        .OnDownloadedCallback = onDownloadedCallback;
        this.RequestsQueue.Add(item:  new DLCManager.DLCRequest());
    }
    private bool AlreadyQueued(string assetToLoad)
    {
        var val_4;
        List.Enumerator<T> val_1 = this.RequestsQueue.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  11993091, b:  assetToLoad)) == false)
        {
            goto label_4;
        }
        
        val_4 = 1;
        goto label_5;
        label_2:
        val_4 = 0;
        label_5:
        0.Dispose();
        return (bool)val_4;
    }
    private static char get_slash()
    {
        null = null;
        return (char)System.IO.Path.DirectorySeparatorChar;
    }
    private System.Collections.IEnumerator Execute()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new DLCManager.<Execute>d__29();
    }
    private void Dequeue()
    {
        if(true >= 1)
        {
                this.RequestsQueue.RemoveAt(index:  0);
            this.currentAssetToLoad = mem[-2305843009213693936];
            this.currentAssetPath = mem[-2305843009213693928];
            this.currentAssetVersion = mem[-2305843009213693920];
            this.currentOnDownloadedCallback = mem[-2305843009213693912];
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.Execute());
            return;
        }
        
        this.executing = false;
    }
    public DLCManager()
    {
        this.currentAssetVersion = 1;
        this.baseString = "https://cdn.12gigs.com/{0}/v{1}/";
        this.RequestsQueue = new System.Collections.Generic.List<DLCRequest>();
        this.fileExtension = "";
    }
    private static DLCManager()
    {
        DLCManager.NOTIFICATION_ASSET_LOADED = new System.Collections.Generic.Dictionary<System.String, UnityEngine.AssetBundle>();
    }

}
