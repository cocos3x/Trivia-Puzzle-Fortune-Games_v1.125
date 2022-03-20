using UnityEngine;
public class PrefabsFromFolder : MonoBehaviour
{
    // Fields
    private bool disableByDefault;
    public bool themed;
    private bool instantiateAllOnAwake;
    private bool instantiateAsChild;
    public Themes themeType;
    private PrefabsFromFolder.SetParentMethod parentingMethod;
    public string folder;
    public string[] allowedSubFolders;
    private bool initalized;
    public PrefabsFromFolder.FilterMode tagFilterMode;
    public System.Collections.Generic.List<string> tagFilter;
    private string gc_type_to_string;
    
    // Methods
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "Notification_OnThemeChanged");
    }
    private void Start()
    {
        this.CheckThemeType();
        if((this.initalized != true) && (this.instantiateAllOnAwake != false))
        {
                this.LoadAll();
        }
        
        this.initalized = true;
    }
    private void Notification_OnThemeChanged()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        this.themeType = val_1.theme.themeType;
        if(val_1.theme.themeType != 0)
        {
                return;
        }
        
        this.themed = false;
    }
    private void CheckThemeType()
    {
        if(App.ThemesHandler != 0)
        {
                AppConfigs val_3 = App.Configuration;
            if(val_3.gameConfig.themesEnabled != false)
        {
                ThemesHandler val_4 = App.ThemesHandler;
            this.themeType = val_4.theme.themeType;
            if(val_4.theme.themeType != 0)
        {
                this.themed = true;
            return;
        }
        
        }
        
        }
        
        this.themed = false;
    }
    public void Init()
    {
        if(this.initalized != false)
        {
                return;
        }
        
        this.LoadAll();
        this.initalized = true;
    }
    public bool IsComplete()
    {
        return (bool)this.initalized;
    }
    public void LoadAll()
    {
        Themes val_14;
        string val_15;
        this.CheckThemeType();
        if(this.themed != false)
        {
                val_14 = this.themeType;
            val_15 = val_14.ToString();
            mem2[0] = val_14;
            string val_2 = this.folder + "/"("/") + val_15 + "/"("/");
        }
        
        int val_14 = val_4.Length;
        if(val_14 < 1)
        {
                return;
        }
        
        var val_15 = 0;
        val_14 = val_14 & 4294967295;
        label_25:
        if((this.ShouldLoadAsset(go:  null)) == false)
        {
            goto label_21;
        }
        
        string val_6 = 1152921507650020624.name;
        if(this.instantiateAsChild == false)
        {
            goto label_12;
        }
        
        val_14 = this.transform.Find(n:  1152921507650020624.name);
        if((UnityEngine.Object.op_Implicit(exists:  val_14)) == true)
        {
            goto label_21;
        }
        
        this.OnLoadedAsset(go:  this.InstantiateToParent(parent:  this.gameObject, prefab:  null), prefab:  null, setLayer:  true);
        goto label_21;
        label_12:
        UnityEngine.GameObject val_13 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  1152921507650020624);
        label_21:
        val_15 = val_15 + 1;
        if(val_15 < (val_4.Length << ))
        {
            goto label_25;
        }
    
    }
    public T LoadStrictlyTypeNamedPrefab<T>(bool allowMultiple = False)
    {
        object val_53;
        var val_54;
        var val_55;
        System.Func<T, TResult> val_56;
        var val_57;
        object val_58;
        string val_59;
        string val_61;
        UnityEngine.Object val_62;
        var val_63;
        var val_65;
        val_53 = __RuntimeMethodHiddenParam;
        val_54 = this;
        this.CheckThemeType();
        if(allowMultiple == false)
        {
            goto label_2;
        }
        
        val_53 = val_53 + 48;
        goto label_20;
        label_2:
        val_55 = mem[__RuntimeMethodHiddenParam + 48 + 302];
        val_55 = __RuntimeMethodHiddenParam + 48 + 302;
        if((val_55 & 1) == 0)
        {
                val_55 = mem[__RuntimeMethodHiddenParam + 48 + 302];
            val_55 = __RuntimeMethodHiddenParam + 48 + 302;
        }
        
        val_56 = mem[__RuntimeMethodHiddenParam + 48 + 184 + 8];
        val_56 = __RuntimeMethodHiddenParam + 48 + 184 + 8;
        if(val_56 == 0)
        {
                val_57 = mem[__RuntimeMethodHiddenParam + 48 + 302];
            val_57 = __RuntimeMethodHiddenParam + 48 + 302;
            if((val_57 & 1) == 0)
        {
                val_57 = mem[__RuntimeMethodHiddenParam + 48 + 302];
            val_57 = __RuntimeMethodHiddenParam + 48 + 302;
        }
        
            System.Func<UnityEngine.Transform, System.Boolean> val_3 = null;
            val_56 = val_3;
            val_3 = new System.Func<UnityEngine.Transform, System.Boolean>(object:  __RuntimeMethodHiddenParam + 48 + 184, method:  __RuntimeMethodHiddenParam + 48 + 8);
            val_58 = mem[__RuntimeMethodHiddenParam + 48];
            val_58 = __RuntimeMethodHiddenParam + 48;
            mem2[0] = val_56;
        }
        
        if((System.Linq.Enumerable.FirstOrDefault<UnityEngine.Transform>(source:  System.Linq.Enumerable.Cast<UnityEngine.Transform>(source:  this.transform), predicate:  val_3)) == 0)
        {
            goto label_20;
        }
        
        val_54 = ???;
        val_53 = ???;
        val_58 = ???;
        goto __RuntimeMethodHiddenParam + 48 + 16;
        label_20:
        System.Type val_6 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_53 + 24});
        mem2[0] = val_6;
        val_59 = ".";
        if((val_6.Contains(value:  val_59)) != false)
        {
                val_59 = 0;
            mem2[0] = val_54 + 72.Remove(startIndex:  0, count:  (val_54 + 72.LastIndexOf(value:  ".")) + 1);
        }
        
        string val_11 = ((val_54 + 40) == 0) ? "" : (val_54 + 40);
        if((val_54 + 25) != 0)
        {
                string val_13 = val_11 + "/"("/") + null.ToString() + "/"("/");
        }
        else
        {
                string val_14 = val_11 + "/"("/");
        }
        
        val_61 = val_14;
        val_62 = WGResources.Load<UnityEngine.GameObject>(fileName:  val_14 + val_54 + 72(val_54 + 72), extension:  ".prefab", errorLog:  true);
        if(val_62 != 0)
        {
            goto label_68;
        }
        
        val_58 = "PrefabFromSlots.LoadStrictlyTypeNamedPrefab() No prefab found for type " + val_61 + val_54 + 72(val_54 + 72);
        if(UnityEngine.Application.isEditor != false)
        {
                val_63 = 0;
            UnityEngine.Debug.LogError(message:  val_58);
        }
        else
        {
                val_63 = 0;
            UnityEngine.Debug.LogWarning(message:  val_58);
        }
        
        if(((val_54 + 25) != 0) && ((val_54 + 28) != 1))
        {
                val_61 = val_54 + 40(val_54 + 40) + "/"("/") + null.ToString() + "/"("/");
            if(UnityEngine.Application.isEditor != false)
        {
                UnityEngine.Debug.LogError(message:  "PrefabFromSlots.LoadStrictlyTypeNamedPrefab() Attempting to load backup prefab from " + val_61 + val_54 + 72(val_54 + 72));
        }
        else
        {
                UnityEngine.Debug.LogWarning(message:  "PrefabFromSlots.LoadStrictlyTypeNamedPrefab() Attempting to load backup prfab from " + val_61 + val_54 + 72(val_54 + 72));
        }
        
            val_62 = WGResources.Load<UnityEngine.GameObject>(fileName:  val_61 + val_54 + 72(val_54 + 72), extension:  ".prefab", errorLog:  true);
        }
        
        if(val_62 != 0)
        {
            goto label_63;
        }
        
        var val_53 = val_54 + 48;
        if(val_53 == 0)
        {
            goto label_63;
        }
        
        var val_52 = val_54 + 48 + 24;
        if(val_52 < 1)
        {
            goto label_63;
        }
        
        val_58 = 0;
        val_52 = val_52 & 4294967295;
        label_65:
        val_53 = val_53 + 0;
        string val_28 = (((val_54 + 48 + 0) + 32) == 0) ? "" : ((val_54 + 48 + 0) + 32);
        if((val_54 + 25) != 0)
        {
                string val_30 = val_28 + "/"("/") + null.ToString() + "/"("/");
        }
        
        val_62 = WGResources.Load<UnityEngine.GameObject>(fileName:  val_28 + "/"("/")(val_28 + "/"("/")) + val_54 + 72(val_54 + 72), extension:  ".prefab", errorLog:  true);
        if(val_62 != 0)
        {
            goto label_63;
        }
        
        val_58 = val_58 + 1;
        if(val_58 < ((val_54 + 48 + 24) << ))
        {
            goto label_65;
        }
        
        label_63:
        if(val_62 == 0)
        {
                val_53 = "PrefabFromSlots.LoadStrictlyTypeNamedPrefab() No prefab found for type " + val_61 + val_54 + 72(val_54 + 72);
            UnityEngine.Debug.LogError(message:  val_53);
            val_65 = 0;
            return (ChallengeWordsTile)val_65;
        }
        
        label_68:
        val_62.SetActive(value:  ((val_54 + 24) == 0) ? 1 : 0);
        val_61 = val_54.InstantiateToParent(parent:  val_54.gameObject, prefab:  val_62);
        val_54.OnLoadedAsset(go:  val_61, prefab:  val_62, setLayer:  true);
        val_65 = val_61;
        return (ChallengeWordsTile)val_65;
    }
    public UnityEngine.Component FindStricklyTypeNamedPrefab(string prefabName)
    {
        System.Type val_5;
        UnityEngine.Component val_6;
        System.Type val_2 = System.Type.GetType(typeName:  prefabName);
        val_5 = val_2;
        if(val_2 == null)
        {
                val_5 = System.Type.GetType(typeName:  prefabName);
        }
        
        UnityEngine.Component[] val_4 = this.gameObject.GetComponentsInChildren(type:  val_5, includeInactive:  true);
        if(val_4 == null)
        {
                return (UnityEngine.Component)val_6;
        }
        
        if(val_4.Length != 0)
        {
                val_6 = val_4[0];
            return (UnityEngine.Component)val_6;
        }
        
        val_6 = 0;
        return (UnityEngine.Component)val_6;
    }
    public UnityEngine.Component LoadStrictlyTypeNamedPrefab(string prefabName)
    {
        string val_11;
        UnityEngine.Object val_12;
        var val_13;
        val_11 = prefabName;
        val_12 = this.FindStricklyTypeNamedPrefab(prefabName:  val_11);
        if(val_12 != 0)
        {
                return (UnityEngine.Component)val_12;
        }
        
        UnityEngine.GameObject val_6 = WGResources.Load<UnityEngine.GameObject>(fileName:  this.folder + ((System.String.IsNullOrEmpty(value:  this.folder)) != true) ? "" : "/"(((System.String.IsNullOrEmpty(value:  this.folder)) != true) ? "" : "/") + val_11, extension:  ".prefab", errorLog:  true);
        if(val_6 == 0)
        {
                val_11 = "PrefabFromSlots :: No prefab found for type "("PrefabFromSlots :: No prefab found for type ") + val_11 + ". Skipping LoadPrefab and hoping it exists within some other window root. Check for other errors relating to type " + val_11;
            val_13 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_13 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_13 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_13 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            D.LogClientError(developer:  val_11, filter:  "default", context:  0, strings:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            val_12 = 0;
            return (UnityEngine.Component)val_12;
        }
        
        UnityEngine.GameObject val_10 = this.InstantiateToParent(parent:  this.gameObject, prefab:  val_6);
        this.OnLoadedAsset(go:  val_10, prefab:  val_6, setLayer:  true);
        return val_10.GetComponent(type:  val_11);
    }
    public T LoadLooselyNamedPrefab<T>(string prefabName)
    {
        var val_10;
        string val_3 = this.folder + ((System.String.IsNullOrEmpty(value:  this.folder)) != true) ? "" : "/"(((System.String.IsNullOrEmpty(value:  this.folder)) != true) ? "" : "/") + prefabName;
        if(val_3 == 0)
        {
                val_10 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_10 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_10 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_10 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            D.LogClientError(developer:  "PrefabFromFolder :: No prefab found for type "("PrefabFromFolder :: No prefab found for type ") + prefabName + ". Skipping LoadPrefab and hoping it exists within some other window root. Check for other errors relating to type " + prefabName, filter:  "default", context:  0, strings:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return 0;
        }
        
        this.OnLoadedAsset(go:  this.InstantiateToParent(parent:  this.gameObject, prefab:  val_3.gameObject), prefab:  val_3.gameObject, setLayer:  false);
        goto __RuntimeMethodHiddenParam + 48 + 16;
    }
    public void OnLoadedAsset(UnityEngine.GameObject go, UnityEngine.GameObject prefab, bool setLayer = True)
    {
        UnityEngine.Transform val_1 = go.transform;
        UnityEngine.Vector3 val_3 = prefab.transform.localPosition;
        val_1.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        UnityEngine.Quaternion val_5 = prefab.transform.localRotation;
        val_1.localRotation = new UnityEngine.Quaternion() {x = val_5.x, y = val_5.y, z = val_5.z, w = val_5.w};
        UnityEngine.Vector3 val_7 = prefab.transform.localScale;
        val_1.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        if(setLayer != false)
        {
                go.layer = this.transform.parent.gameObject.layer;
        }
        
        go.name = prefab.name;
    }
    public void OnSceneSave()
    {
        UnityEngine.Object val_10;
        int val_11;
        int val_12;
        val_10 = this;
        if(this.transform.childCount < 1)
        {
                return;
        }
        
        object[] val_3 = new object[4];
        val_11 = val_3.Length;
        val_3[0] = this.gameObject.name;
        val_11 = val_3.Length;
        val_3[1] = " appears to have ";
        val_12 = val_3.Length;
        val_3[2] = this.transform.childCount;
        val_12 = val_3.Length;
        val_3[3] = " unfinished prefab edits. Please apply any changes and finish editing. (Note this is okay if you want to save and come back to finish editing later.)";
        val_10 = this.gameObject;
        UnityEngine.Debug.LogError(message:  +val_3, context:  val_10);
    }
    public bool ShouldLoadAsset(UnityEngine.GameObject go)
    {
        var val_6;
        if(go == 0)
        {
                val_6 = 0;
            return (bool)val_6 & 1;
        }
        
        if(this.tagFilterMode == 20)
        {
            goto label_5;
        }
        
        if(this.tagFilterMode != 10)
        {
            goto label_6;
        }
        
        return this.tagFilter.Contains(item:  go.tag);
        label_5:
        val_6 = (this.tagFilter.Contains(item:  go.tag)) ^ 1;
        return (bool)val_6 & 1;
        label_6:
        val_6 = 1;
        return (bool)val_6 & 1;
    }
    public UnityEngine.GameObject InstantiateToParent(UnityEngine.GameObject parent, UnityEngine.GameObject prefab)
    {
        UnityEngine.Object val_12;
        var val_13;
        var val_14;
        val_12 = parent;
        val_13 = this;
        if(this.parentingMethod == 1)
        {
            goto label_1;
        }
        
        if(this.parentingMethod != 0)
        {
            goto label_2;
        }
        
        val_13 = 1152921504765632512;
        UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  prefab);
        val_14 = val_1;
        if(val_1 == 0)
        {
                return (UnityEngine.GameObject)val_14;
        }
        
        if(val_12 == 0)
        {
                return (UnityEngine.GameObject)val_14;
        }
        
        val_13 = val_14.transform;
        val_13.SetParent(parent:  val_12.transform, worldPositionStays:  false);
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
        val_13.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        UnityEngine.Quaternion val_7 = UnityEngine.Quaternion.identity;
        val_13.localRotation = new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w};
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.one;
        val_13.localScale = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        val_14.layer = val_12.layer;
        return (UnityEngine.GameObject)val_14;
        label_1:
        val_12 = this.gameObject;
        UnityEngine.GameObject val_11 = NGUITools.AddChild(parent:  val_12, prefab:  prefab);
        label_2:
        val_14 = 0;
        return (UnityEngine.GameObject)val_14;
    }
    public PrefabsFromFolder()
    {
        this.disableByDefault = true;
        this.instantiateAllOnAwake = true;
        this.instantiateAsChild = true;
    }

}
