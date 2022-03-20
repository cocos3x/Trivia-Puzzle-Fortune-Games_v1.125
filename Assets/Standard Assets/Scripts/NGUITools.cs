using UnityEngine;
public static class NGUITools
{
    // Fields
    private static UnityEngine.AudioListener mListener;
    private static bool mLoaded;
    private static float mGlobalVolume;
    private static UnityEngine.Color mInvisible;
    private static System.Reflection.PropertyInfo mSystemCopyBuffer;
    
    // Properties
    public static float soundVolume { get; set; }
    public static bool fileAccess { get; }
    public static string clipboard { get; set; }
    
    // Methods
    public static float get_soundVolume()
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if(NGUITools.mLoaded != true)
        {
                val_3 = 1152921504858181640;
            NGUITools.mLoaded = true;
            val_2 = null;
            NGUITools.mGlobalVolume = UnityEngine.PlayerPrefs.GetFloat(key:  "Sound", defaultValue:  1f);
        }
        
        val_2 = null;
        return (float)NGUITools.mGlobalVolume;
    }
    public static void set_soundVolume(float value)
    {
        var val_1;
        var val_2;
        val_1 = null;
        val_1 = null;
        val_2 = val_1;
        if(NGUITools.mGlobalVolume == value)
        {
                return;
        }
        
        val_2 = null;
        NGUITools.mLoaded = true;
        NGUITools.mGlobalVolume = value;
        UnityEngine.PlayerPrefs.SetFloat(key:  "Sound", value:  value);
    }
    public static bool get_fileAccess()
    {
        return true;
    }
    public static UnityEngine.AudioSource PlaySound(UnityEngine.AudioClip clip)
    {
        return NGUITools.PlaySound(clip:  clip, volume:  1f, pitch:  1f);
    }
    public static UnityEngine.AudioSource PlaySound(UnityEngine.AudioClip clip, float volume)
    {
        return NGUITools.PlaySound(clip:  clip, volume:  volume, pitch:  1f);
    }
    public static UnityEngine.AudioSource PlaySound(UnityEngine.AudioClip clip, float volume, float pitch)
    {
        UnityEngine.Object val_23;
        var val_24;
        var val_25;
        UnityEngine.AudioListener val_26;
        UnityEngine.Object val_27;
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        var val_32;
        var val_33;
        float val_23 = volume;
        val_23 = NGUITools.soundVolume * val_23;
        val_23 = 0;
        if(val_23 <= 0.01f)
        {
                return (UnityEngine.AudioSource)val_23;
        }
        
        if(clip == 0)
        {
                return (UnityEngine.AudioSource)val_23;
        }
        
        val_24 = null;
        val_24 = null;
        if(NGUITools.mListener == 0)
        {
                UnityEngine.Object val_5 = UnityEngine.Object.FindObjectOfType(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
            val_25 = null;
            val_25 = null;
            if(val_5 != null)
        {
                var val_6 = (null == null) ? (val_5) : 0;
        }
        else
        {
                val_26 = 0;
        }
        
            NGUITools.mListener = val_26;
            if(NGUITools.mListener == 0)
        {
                val_27 = UnityEngine.Camera.main;
            if(val_27 == 0)
        {
                System.Type val_24 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            UnityEngine.Object val_11 = UnityEngine.Object.FindObjectOfType(type:  val_24);
            if(val_11 != null)
        {
                val_24 = (null == null) ? (val_11) : 0;
        }
        else
        {
                val_27 = 0;
        }
        
        }
        
            if(val_27 != 0)
        {
                val_28 = null;
            val_28 = null;
            NGUITools.mListener = val_27.gameObject.AddComponent<UnityEngine.AudioListener>();
        }
        
        }
        
        }
        
        val_29 = null;
        val_29 = null;
        val_23 = 0;
        if(NGUITools.mListener == 0)
        {
                return (UnityEngine.AudioSource)val_23;
        }
        
        val_30 = null;
        val_30 = null;
        val_23 = 0;
        if(NGUITools.mListener.enabled == false)
        {
                return (UnityEngine.AudioSource)val_23;
        }
        
        val_31 = null;
        val_31 = null;
        val_23 = 0;
        if((NGUITools.GetActive(go:  NGUITools.mListener.gameObject)) == false)
        {
                return (UnityEngine.AudioSource)val_23;
        }
        
        val_32 = null;
        val_32 = null;
        val_23 = NGUITools.mListener.GetComponent<UnityEngine.AudioSource>();
        if(val_23 == 0)
        {
                val_33 = null;
            val_33 = null;
            val_23 = NGUITools.mListener.gameObject.AddComponent<UnityEngine.AudioSource>();
        }
        
        val_23.pitch = pitch;
        val_23.PlayOneShot(clip:  clip, volumeScale:  val_23);
        return (UnityEngine.AudioSource)val_23;
    }
    public static UnityEngine.WWW OpenURL(string url)
    {
        return (UnityEngine.WWW)new UnityEngine.WWW(url:  url);
    }
    public static UnityEngine.WWW OpenURL(string url, UnityEngine.WWWForm form)
    {
        if(form == null)
        {
                return NGUITools.OpenURL(url:  url);
        }
        
        return (UnityEngine.WWW)new UnityEngine.WWW(url:  url, form:  form);
    }
    public static int RandomRange(int min, int max)
    {
        if(min == max)
        {
                return (int)min;
        }
        
        max = max + 1;
        return UnityEngine.Random.Range(min:  min, max:  max);
    }
    public static string GetHierarchy(UnityEngine.GameObject obj)
    {
        string val_11 = obj.name;
        do
        {
            if(obj.transform.parent == 0)
        {
                return "\"" + val_11 + "\"";
        }
        
            UnityEngine.GameObject val_7 = obj.transform.parent.gameObject;
            val_11 = val_7.name + "/"("/") + val_11;
        }
        while(val_7.transform != null);
        
        throw new NullReferenceException();
    }
    public static UnityEngine.Color ParseColor(string text, int offset)
    {
        offset = offset + 1;
        float val_23 = 0.003921569f;
        float val_21 = (float)(NGUIMath.HexToDecimal(ch:  text.Chars[offset])) | ((NGUIMath.HexToDecimal(ch:  text.Chars[offset])) << 4);
        float val_22 = (float)(NGUIMath.HexToDecimal(ch:  text.Chars[offset + 3])) | ((NGUIMath.HexToDecimal(ch:  text.Chars[offset + 2])) << 4);
        val_21 = val_21 * val_23;
        val_22 = val_22 * val_23;
        val_23 = ((float)(NGUIMath.HexToDecimal(ch:  text.Chars[offset + 5])) | ((NGUIMath.HexToDecimal(ch:  text.Chars[offset + 4])) << 4)) * val_23;
        UnityEngine.Color val_20 = new UnityEngine.Color(r:  val_21, g:  val_22, b:  val_23);
        return new UnityEngine.Color() {r = val_20.r, g = val_20.g, b = val_20.b, a = val_20.a};
    }
    public static string EncodeColor(UnityEngine.Color c)
    {
        int val_1 = NGUIMath.ColorToInt(c:  new UnityEngine.Color() {r = c.r, g = c.g, b = c.b, a = c.a});
        val_1 = val_1 >> 8;
        return NGUIMath.DecimalToHex(num:  val_1);
    }
    public static int ParseSymbol(string text, int index, System.Collections.Generic.List<UnityEngine.Color> colors, bool premultiply)
    {
        string val_18;
        var val_19;
        float val_24;
        float val_25;
        float val_26;
        float val_27;
        var val_28;
        val_18 = index;
        int val_1 = val_18 + 2;
        if(val_1 >= text.m_stringLength)
        {
            goto label_9;
        }
        
        int val_2 = val_18 + 1;
        if((text.Chars[val_2] & 65535) != ('-'))
        {
            goto label_3;
        }
        
        int val_18 = val_1;
        char val_6 = text.Chars[val_18] & 65535;
        if(val_6 != ']')
        {
            goto label_9;
        }
        
        if((colors != null) && (val_6 >= ''))
        {
                val_18 = val_6 - 1;
            colors.RemoveAt(index:  val_18);
        }
        
        val_19 = 3;
        return (int)val_19;
        label_3:
        int val_7 = val_18 + 7;
        if((val_7 >= text.m_stringLength) || ((text.Chars[val_7] & 65535) != ']'))
        {
            goto label_9;
        }
        
        if(colors == null)
        {
                return (int)val_19;
        }
        
        UnityEngine.Color val_10 = NGUITools.ParseColor(text:  text, offset:  val_2);
        val_24 = val_10.r;
        val_25 = val_10.g;
        val_26 = val_10.b;
        int val_11 = NGUIMath.ColorToInt(c:  new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a});
        val_11 = val_11 >> 8;
        val_18 = NGUIMath.DecimalToHex(num:  val_11);
        if((System.String.op_Inequality(a:  val_18, b:  text.Substring(startIndex:  val_2, length:  6).ToUpper())) == false)
        {
            goto label_14;
        }
        
        label_9:
        val_19 = 0;
        return (int)val_19;
        label_14:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_27 = mem[(NGUITools.__il2cppRuntimeField_cctor_finished + ((NGUITools.__il2cppRuntimeField_cctor_finished - 1)) << 4) + 44];
        val_27 = (NGUITools.__il2cppRuntimeField_cctor_finished + ((NGUITools.__il2cppRuntimeField_cctor_finished - 1)) << 4) + 44;
        if((val_27 != 1f) && (premultiply != false))
        {
                val_28 = null;
            val_28 = null;
            UnityEngine.Color val_17 = UnityEngine.Color.Lerp(a:  new UnityEngine.Color() {r = NGUITools.mInvisible, g = NGUITools.mListener.__il2cppRuntimeField_14, b = NGUITools.mListener.__il2cppRuntimeField_18, a = NGUITools.mListener.__il2cppRuntimeField_1C}, b:  new UnityEngine.Color() {r = val_24, g = val_25, b = val_26, a = val_27}, t:  val_27);
            val_24 = val_17.r;
            val_25 = val_17.g;
            val_26 = val_17.b;
            val_27 = val_17.a;
        }
        
        colors.Add(item:  new UnityEngine.Color() {r = val_24, g = val_25, b = val_26, a = val_27});
        return (int)val_19;
    }
    public static string StripSymbols(string text)
    {
        string val_5;
        int val_6;
        val_5 = text;
        if(val_5 == null)
        {
                return val_5;
        }
        
        val_6 = text.m_stringLength;
        if(val_6 < 1)
        {
                return val_5;
        }
        
        var val_5 = 0;
        goto label_10;
        label_9:
        val_6 = val_1.m_stringLength;
        val_5 = val_5.Remove(startIndex:  0, count:  19578);
        goto label_5;
        label_10:
        if((val_5.Chars[0] & 65535) == '[')
        {
                if((NGUITools.ParseSymbol(text:  val_5, index:  0, colors:  0, premultiply:  false)) >= 1)
        {
            goto label_9;
        }
        
        }
        
        val_5 = val_5 + 1;
        label_5:
        if(val_5 < val_6)
        {
            goto label_10;
        }
        
        return val_5;
    }
    public static T[] FindActive<T>()
    {
        UnityEngine.Object[] val_2 = UnityEngine.Object.FindObjectsOfType(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}));
    }
    public static UnityEngine.Camera FindCameraForLayer(int layer)
    {
        T val_4;
        if(val_1.Length < 1)
        {
            goto label_8;
        }
        
        var val_4 = 0;
        label_9:
        val_4 = NGUITools.FindActive<UnityEngine.Camera>()[val_4];
        if(val_4.cullingMask != (1 << layer))
        {
                return (UnityEngine.Camera)val_4;
        }
        
        val_4 = val_4 + 1;
        if(val_4 >= val_1.Length)
        {
            goto label_8;
        }
        
        if(val_4 < val_1.Length)
        {
            goto label_9;
        }
        
        throw new IndexOutOfRangeException();
        label_8:
        val_4 = 0;
        return (UnityEngine.Camera)val_4;
    }
    public static string GetName<T>()
    {
        var val_4;
        System.Type val_1 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48});
        if((val_1.StartsWith(value:  "UI")) != false)
        {
                val_4 = 2;
            return val_1.Substring(startIndex:  12);
        }
        
        if((val_1.StartsWith(value:  "UnityEngine.")) == false)
        {
                return (string)val_1;
        }
        
        val_4 = 12;
        return val_1.Substring(startIndex:  12);
    }
    public static UnityEngine.GameObject AddChild(UnityEngine.GameObject parent)
    {
        UnityEngine.GameObject val_1 = new UnityEngine.GameObject();
        if(parent == 0)
        {
                return val_1;
        }
        
        UnityEngine.Transform val_3 = val_1.transform;
        val_3.parent = parent.transform;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
        val_3.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.identity;
        val_3.localRotation = new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w};
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
        val_3.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        val_1.layer = parent.layer;
        return val_1;
    }
    public static UnityEngine.GameObject AddChild(UnityEngine.GameObject parent, UnityEngine.GameObject prefab)
    {
        return NGUITools.AddChild(parent:  parent, prefab:  prefab, pooling:  false);
    }
    public static UnityEngine.GameObject AddChild(UnityEngine.GameObject parent, UnityEngine.GameObject prefab, bool pooling)
    {
        UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  prefab);
        if(val_1 == 0)
        {
                return val_1;
        }
        
        if(parent == 0)
        {
                return val_1;
        }
        
        UnityEngine.Transform val_4 = val_1.transform;
        val_4.parent = parent.transform;
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
        val_4.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        UnityEngine.Quaternion val_7 = UnityEngine.Quaternion.identity;
        val_4.localRotation = new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w};
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.one;
        val_4.localScale = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        val_1.layer = parent.layer;
        return val_1;
    }
    public static T AddChild<T>(UnityEngine.GameObject parent)
    {
        NGUITools.AddChild(parent:  parent).name = __RuntimeMethodHiddenParam + 48;
        goto __RuntimeMethodHiddenParam + 48 + 8;
    }
    public static UnityEngine.GameObject GetRoot(UnityEngine.GameObject go)
    {
        UnityEngine.Transform val_1 = go.transform;
        do
        {
        
        }
        while(val_1.parent != 0);
        
        return val_1.gameObject;
    }
    public static T FindInParents<T>(UnityEngine.GameObject go)
    {
        var val_6;
        UnityEngine.Object val_7;
        var val_8;
        var val_9;
        val_6 = __RuntimeMethodHiddenParam;
        val_7 = go;
        val_8 = 0;
        if(val_7 == 0)
        {
                return (object)val_8;
        }
        
        val_9 = val_7;
        if(val_7 != null)
        {
            goto label_8;
        }
        
        UnityEngine.Transform val_2 = val_7.transform;
        val_9 = 0;
        goto label_7;
        label_13:
        if((val_2 & 1) == 0)
        {
            goto label_8;
        }
        
        val_9 = val_2.gameObject;
        label_7:
        val_7 = val_2.parent;
        bool val_5 = UnityEngine.Object.op_Inequality(x:  val_7, y:  0);
        if(val_9 == null)
        {
            goto label_13;
        }
        
        label_8:
        val_6 = mem[__RuntimeMethodHiddenParam + 48 + 8];
        val_6 = __RuntimeMethodHiddenParam + 48 + 8;
        if(val_9 != null)
        {
                if(X0 == true)
        {
                return (object)val_8;
        }
        
        }
        
        val_8 = 0;
        return (object)val_8;
    }
    public static void Destroy(UnityEngine.Object obj)
    {
        NGUITools.Destroy(obj:  obj, withPool:  false);
    }
    public static void Destroy(UnityEngine.Object obj, bool withPool)
    {
        if(obj == 0)
        {
                return;
        }
        
        if(UnityEngine.Application.isPlaying != false)
        {
                if((obj != null) && (null == null))
        {
                obj.transform.parent = 0;
        }
        
            UnityEngine.Object.Destroy(obj:  obj);
            return;
        }
        
        UnityEngine.Object.DestroyImmediate(obj:  obj);
    }
    public static void DestroyImmediate(UnityEngine.Object obj)
    {
        if(obj == 0)
        {
                return;
        }
        
        if(UnityEngine.Application.isEditor != false)
        {
                UnityEngine.Object.DestroyImmediate(obj:  obj);
            return;
        }
        
        UnityEngine.Object.Destroy(obj:  obj);
    }
    public static void Broadcast(string funcName)
    {
        UnityEngine.Object[] val_2 = UnityEngine.Object.FindObjectsOfType(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        if((X0 + 24) < 1)
        {
                return;
        }
        
        var val_4 = 0;
        do
        {
            bool val_3 = X0 + 0;
            (X0 + 0) + 32.SendMessage(methodName:  funcName, options:  1);
            val_4 = val_4 + 1;
            if(val_4 >= (X0 + 24))
        {
                return;
        }
        
        }
        while(val_4 < (X0 + 24));
        
        throw new IndexOutOfRangeException();
    }
    public static void Broadcast(string funcName, object param)
    {
        UnityEngine.Object[] val_2 = UnityEngine.Object.FindObjectsOfType(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        if((X0 + 24) < 1)
        {
                return;
        }
        
        var val_4 = 0;
        do
        {
            bool val_3 = X0 + 0;
            (X0 + 0) + 32.SendMessage(methodName:  funcName, value:  param, options:  1);
            val_4 = val_4 + 1;
            if(val_4 >= (X0 + 24))
        {
                return;
        }
        
        }
        while(val_4 < (X0 + 24));
        
        throw new IndexOutOfRangeException();
    }
    public static bool IsChild(UnityEngine.Transform parent, UnityEngine.Transform child)
    {
        UnityEngine.Transform val_6 = child;
        if(parent == 0)
        {
                return false;
        }
        
        if(val_6 != 0)
        {
            goto label_6;
        }
        
        return false;
        label_14:
        if(val_6 == parent)
        {
                return false;
        }
        
        val_6 = val_6.parent;
        label_6:
        if(val_6 != 0)
        {
            goto label_14;
        }
        
        return false;
    }
    private static void Activate(UnityEngine.Transform t)
    {
        var val_8;
        t.gameObject.SetActive(value:  true);
        int val_2 = t.childCount;
        if(val_2 >= 1)
        {
                val_8 = 0;
            do
        {
            if((t.GetChild(index:  0).gameObject.activeSelf) == true)
        {
                return;
        }
        
            val_8 = val_8 + 1;
        }
        while(val_8 < val_2);
        
        }
        
        int val_6 = t.childCount;
        if(val_6 < 1)
        {
                return;
        }
        
        do
        {
            UnityEngine.Transform val_7 = t.GetChild(index:  0);
            val_8 = 0 + 1;
        }
        while(val_6 != val_8);
    
    }
    private static void Deactivate(UnityEngine.Transform t)
    {
        t.gameObject.SetActive(value:  false);
    }
    public static void SetActive(UnityEngine.GameObject go, bool state)
    {
        UnityEngine.Transform val_1 = go.transform;
        if(state != false)
        {
                NGUITools.Activate(t:  val_1);
            return;
        }
        
        NGUITools.Deactivate(t:  val_1);
    }
    public static void SetActiveChildren(UnityEngine.GameObject go, bool state)
    {
        bool val_5 = state;
        UnityEngine.Transform val_1 = go.transform;
        int val_2 = val_1.childCount;
        if(val_5 != false)
        {
                if(val_2 < 1)
        {
                return;
        }
        
            do
        {
            NGUITools.Activate(t:  val_1.GetChild(index:  0));
            val_5 = 0 + 1;
        }
        while(val_2 != val_5);
        
            return;
        }
        
        if(val_2 < 1)
        {
                return;
        }
        
        do
        {
            NGUITools.Deactivate(t:  val_1.GetChild(index:  0));
            val_5 = 0 + 1;
        }
        while(val_2 != val_5);
    
    }
    public static bool GetActive(UnityEngine.GameObject go)
    {
        if((UnityEngine.Object.op_Implicit(exists:  go)) == false)
        {
                return false;
        }
        
        return go.activeInHierarchy;
    }
    public static void SetActiveSelf(UnityEngine.GameObject go, bool state)
    {
        if(go != null)
        {
                go.SetActive(value:  state);
            return;
        }
        
        throw new NullReferenceException();
    }
    public static void SetLayer(UnityEngine.GameObject go, int layer)
    {
        var val_5;
        go.layer = layer;
        UnityEngine.Transform val_1 = go.transform;
        int val_2 = val_1.childCount;
        if(val_2 < 1)
        {
                return;
        }
        
        val_5 = val_2;
        var val_5 = 0;
        do
        {
            UnityEngine.GameObject val_4 = val_1.GetChild(index:  0).gameObject;
            val_5 = val_5 + 1;
        }
        while(val_5 < val_5);
    
    }
    public static UnityEngine.Vector3 Round(UnityEngine.Vector3 v)
    {
        var val_1;
        var val_5;
        float val_6;
        var val_8;
        float val_9;
        var val_11;
        float val_12;
        if(v.x >= 0f)
        {
            goto label_3;
        }
        
        if((double)v.x != (-0.5))
        {
            goto label_4;
        }
        
        val_5 = val_1;
        val_6 = -1f;
        goto label_5;
        label_3:
        if((double)v.x != 0.5)
        {
            goto label_6;
        }
        
        val_5 = val_1;
        val_6 = 1f;
        label_5:
        val_6 = (float)val_5 + val_6;
        var val_2 = (((long)val_5 & 1) != 0) ? ((float)val_5) : (val_6);
        goto label_8;
        label_4:
        float val_5 = -0.5f;
        val_5 = v.x + val_5;
        goto label_8;
        label_6:
        float val_6 = 0.5f;
        val_6 = v.x + val_6;
        label_8:
        if(v.y >= 0f)
        {
            goto label_9;
        }
        
        if((double)v.y != (-0.5))
        {
            goto label_10;
        }
        
        val_8 = val_1;
        val_9 = -1f;
        goto label_11;
        label_9:
        if((double)v.y != 0.5)
        {
            goto label_12;
        }
        
        val_8 = val_1;
        val_9 = 1f;
        label_11:
        val_9 = (float)val_8 + val_9;
        var val_3 = (((long)val_8 & 1) != 0) ? ((float)val_8) : (val_9);
        goto label_14;
        label_10:
        float val_7 = -0.5f;
        val_7 = v.y + val_7;
        goto label_14;
        label_12:
        float val_8 = 0.5f;
        val_8 = v.y + val_8;
        label_14:
        if(v.z >= 0f)
        {
            goto label_15;
        }
        
        if((double)v.z != (-0.5))
        {
            goto label_16;
        }
        
        val_11 = val_1;
        val_12 = -1f;
        goto label_17;
        label_15:
        if((double)v.z != 0.5)
        {
            goto label_18;
        }
        
        val_11 = val_1;
        val_12 = 1f;
        label_17:
        val_12 = (float)val_11 + val_12;
        var val_4 = (((long)val_11 & 1) != 0) ? ((float)val_11) : (val_12);
        return new UnityEngine.Vector3() {x = v.x, y = v.y, z = v.z};
        label_16:
        float val_9 = -0.5f;
        val_9 = v.z + val_9;
        return new UnityEngine.Vector3() {x = v.x, y = v.y, z = v.z};
        label_18:
        float val_10 = 0.5f;
        val_10 = v.z + val_10;
        return new UnityEngine.Vector3() {x = v.x, y = v.y, z = v.z};
    }
    public static bool Save(string fileName, byte[] bytes)
    {
        string val_2 = UnityEngine.Application.persistentDataPath + "/"("/") + fileName;
        if(bytes != null)
        {
                System.IO.File.Create(path:  val_2).Close();
            return true;
        }
        
        if((System.IO.File.Exists(path:  val_2)) == false)
        {
                return true;
        }
        
        System.IO.File.Delete(path:  val_2);
        return true;
    }
    public static byte[] Load(string fileName)
    {
        string val_2 = UnityEngine.Application.persistentDataPath + "/"("/") + fileName;
        if((System.IO.File.Exists(path:  val_2)) == false)
        {
                return 0;
        }
        
        return System.IO.File.ReadAllBytes(path:  val_2);
    }
    public static UnityEngine.Color ApplyPMA(UnityEngine.Color c)
    {
        if(c.a == 1f)
        {
                return new UnityEngine.Color() {r = c.r, g = c.g, b = c.b, a = c.a};
        }
        
        c.r = c.r * c.a;
        c.g = c.g * c.a;
        c.b = c.b * c.a;
        return new UnityEngine.Color() {r = c.r, g = c.g, b = c.b, a = c.a};
    }
    private static System.Reflection.PropertyInfo GetSystemCopyBufferProperty()
    {
        System.Reflection.PropertyInfo val_4;
        var val_5;
        var val_6;
        val_5 = null;
        val_5 = null;
        if((System.Reflection.PropertyInfo.op_Equality(left:  NGUITools.mSystemCopyBuffer, right:  0)) != false)
        {
                val_6 = null;
            val_4 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()).GetProperty(name:  "systemCopyBuffer", bindingAttr:  40);
            val_6 = null;
            NGUITools.mSystemCopyBuffer = val_4;
        }
        else
        {
                val_6 = null;
        }
        
        val_6 = null;
        return (System.Reflection.PropertyInfo)NGUITools.mSystemCopyBuffer;
    }
    public static string get_clipboard()
    {
        var val_3;
        System.Reflection.PropertyInfo val_1 = NGUITools.GetSystemCopyBufferProperty();
        val_3 = 0;
        if((System.Reflection.PropertyInfo.op_Inequality(left:  val_1, right:  0)) == false)
        {
                return (string)val_3;
        }
        
        val_3 = val_1;
        if(val_3 == null)
        {
                return (string)val_3;
        }
        
        if(null == null)
        {
                return (string)val_3;
        }
    
    }
    public static void set_clipboard(string value)
    {
        if((System.Reflection.PropertyInfo.op_Inequality(left:  NGUITools.GetSystemCopyBufferProperty(), right:  0)) == false)
        {
                return;
        }
        
        value = ???;
        goto typeof(System.Reflection.PropertyInfo).__il2cppRuntimeField_300;
    }
    private static NGUITools()
    {
        UnityEngine.Color val_1;
        NGUITools.mLoaded = false;
        NGUITools.mGlobalVolume = 1f;
        val_1 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0f);
        NGUITools.mInvisible = val_1.r;
        NGUITools.mSystemCopyBuffer = 0;
    }

}
