using UnityEngine;
public class CUtils
{
    // Fields
    private static UnityEngine.AndroidJavaClass cls_UnityPlayer;
    private static UnityEngine.AndroidJavaObject obj_Activity;
    private static System.Collections.Generic.List<string> validContactPoints;
    private static System.Collections.Generic.List<string> invalidSceneIndeces;
    
    // Methods
    private static CUtils()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "MetaGameBehavior");
        CUtils.validContactPoints = val_1;
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        val_2.Add(item:  "Bootstrap");
        CUtils.invalidSceneIndeces = val_2;
    }
    public static string ReadFileContent(string path)
    {
        var val_3;
        UnityEngine.Object val_1 = UnityEngine.Resources.Load(path:  path);
        val_3 = 0;
        if( != 0)
        {
                return text;
        }
        
        return 0;
    }
    public static UnityEngine.Vector3 CopyVector3(UnityEngine.Vector3 ori)
    {
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  ori.x, y:  ori.y, z:  ori.z);
        return new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
    }
    public static bool EqualVector3(UnityEngine.Vector3 v1, UnityEngine.Vector3 v2)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = v1.x, y = v1.y, z = v1.z}, b:  new UnityEngine.Vector3() {x = v2.x, y = v2.y, z = v2.z});
        return (bool)((UnityEngine.Vector3.SqrMagnitude(vector:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z})) <= (1E-07f)) ? 1 : 0;
    }
    public static float GetSign(UnityEngine.Vector3 A, UnityEngine.Vector3 B, UnityEngine.Vector3 M)
    {
        float val_1;
        A.x = B.x - A.x;
        A.y = val_1 - A.y;
        A.x = A.x * A.y;
        A.x = A.x - ((B.y - A.y) * (M.x - A.x));
        return UnityEngine.Mathf.Sign(f:  A.x);
    }
    public static UnityEngine.Vector3 RotatePointAroundPivot(UnityEngine.Vector3 point, UnityEngine.Vector3 pivot, UnityEngine.Vector3 angles)
    {
        float val_1;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = point.x, y = point.y, z = point.z}, b:  new UnityEngine.Vector3() {x = pivot.x, y = pivot.y, z = pivot.z});
        UnityEngine.Quaternion val_3 = UnityEngine.Quaternion.Euler(euler:  new UnityEngine.Vector3() {x = angles.x, y = val_1, z = angles.y});
        UnityEngine.Vector3 val_4 = UnityEngine.Quaternion.op_Multiply(rotation:  new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w}, point:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        return UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, b:  new UnityEngine.Vector3() {x = pivot.x, y = pivot.y, z = pivot.z});
    }
    public static void Shuffle<T>(T[] array)
    {
        if(array.Length < 1)
        {
                return;
        }
        
        var val_5 = 0;
        do
        {
            int val_3 = array.Length;
            val_3 = val_3 & 4294967295;
            mem2[0] = array[UnityEngine.Random.Range(min:  0, max:  array.Length & 4294967295)];
            array[UnityEngine.Random.Range(min:  0, max:  array.Length & 4294967295)] = null;
            val_5 = val_5 + 1;
        }
        while(val_5 < (array.Length << ));
    
    }
    public static string[] SeparateLines(string lines)
    {
        char[] val_3 = new char[1];
        val_3[0] = Chars[0];
        return lines.Replace(oldValue:  "\r\n", newValue:  "\n").Replace(oldValue:  "\r", newValue:  "\n").Split(separator:  val_3);
    }
    public static void ChangeSortingLayerRecursively(UnityEngine.Transform root, string sortingLayerName, int offsetOrder = 0)
    {
        var val_9;
        var val_10;
        var val_13;
        val_9 = offsetOrder;
        if(root == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.SpriteRenderer val_1 = root.GetComponent<UnityEngine.SpriteRenderer>();
        if(val_1 != 0)
        {
                if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
            val_1.sortingLayerName = sortingLayerName;
            val_1.sortingOrder = val_1.sortingOrder + val_9;
        }
        
        val_10 = root.GetEnumerator();
        label_22:
        var val_10 = 0;
        val_10 = val_10 + 1;
        if(val_10.MoveNext() == false)
        {
            goto label_11;
        }
        
        var val_11 = 0;
        val_11 = val_11 + 1;
        if(val_10.Current == null)
        {
            goto label_22;
        }
        
        goto label_22;
        label_11:
        val_9 = 0;
        if(X0 == false)
        {
            goto label_23;
        }
        
        var val_14 = X0;
        val_10 = X0;
        if((X0 + 294) == 0)
        {
            goto label_27;
        }
        
        var val_12 = X0 + 176;
        var val_13 = 0;
        val_12 = val_12 + 8;
        label_26:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_25;
        }
        
        val_13 = val_13 + 1;
        val_12 = val_12 + 16;
        if(val_13 < (X0 + 294))
        {
            goto label_26;
        }
        
        goto label_27;
        label_25:
        val_14 = val_14 + (((X0 + 176 + 8)) << 4);
        val_13 = val_14 + 304;
        label_27:
        val_10.Dispose();
        label_23:
        if(val_9 != 0)
        {
                throw val_9;
        }
    
    }
    public static void ChangeRendererColorRecursively(UnityEngine.Transform root, UnityEngine.Color color)
    {
        UnityEngine.Object val_7;
        var val_8;
        var val_11;
        if(root == null)
        {
                throw new NullReferenceException();
        }
        
        val_7 = root.GetComponent<UnityEngine.SpriteRenderer>();
        if(val_7 != 0)
        {
                if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
            val_7.color = new UnityEngine.Color() {r = color.r, g = color.g, b = color.b, a = color.a};
        }
        
        val_8 = root.GetEnumerator();
        label_22:
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_8.MoveNext() == false)
        {
            goto label_11;
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_7 = val_8.Current;
        if(val_7 == null)
        {
            goto label_22;
        }
        
        goto label_22;
        label_11:
        val_7 = 0;
        if(X0 == false)
        {
            goto label_23;
        }
        
        var val_12 = X0;
        val_8 = X0;
        if((X0 + 294) == 0)
        {
            goto label_27;
        }
        
        var val_10 = X0 + 176;
        var val_11 = 0;
        val_10 = val_10 + 8;
        label_26:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_25;
        }
        
        val_11 = val_11 + 1;
        val_10 = val_10 + 16;
        if(val_11 < (X0 + 294))
        {
            goto label_26;
        }
        
        goto label_27;
        label_25:
        val_12 = val_12 + (((X0 + 176 + 8)) << 4);
        val_11 = val_12 + 304;
        label_27:
        val_8.Dispose();
        label_23:
        if(val_7 != 0)
        {
                throw val_7;
        }
    
    }
    public static void ChangeImageColorRecursively(UnityEngine.Transform root, UnityEngine.Color color)
    {
        UnityEngine.Object val_7;
        var val_8;
        var val_11;
        if(root == null)
        {
                throw new NullReferenceException();
        }
        
        val_7 = root.GetComponent<UnityEngine.UI.Image>();
        if(val_7 != 0)
        {
                if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
            val_7.color = new UnityEngine.Color() {r = color.r, g = color.g, b = color.b, a = color.a};
        }
        
        val_8 = root.GetEnumerator();
        label_22:
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_8.MoveNext() == false)
        {
            goto label_11;
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_7 = val_8.Current;
        if(val_7 == null)
        {
            goto label_22;
        }
        
        goto label_22;
        label_11:
        val_7 = 0;
        if(X0 == false)
        {
            goto label_23;
        }
        
        var val_12 = X0;
        val_8 = X0;
        if((X0 + 294) == 0)
        {
            goto label_27;
        }
        
        var val_10 = X0 + 176;
        var val_11 = 0;
        val_10 = val_10 + 8;
        label_26:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_25;
        }
        
        val_11 = val_11 + 1;
        val_10 = val_10 + 16;
        if(val_11 < (X0 + 294))
        {
            goto label_26;
        }
        
        goto label_27;
        label_25:
        val_12 = val_12 + (((X0 + 176 + 8)) << 4);
        val_11 = val_12 + 304;
        label_27:
        val_8.Dispose();
        label_23:
        if(val_7 != 0)
        {
                throw val_7;
        }
    
    }
    public static string GetFacePictureURL(string facebookID, System.Nullable<int> width, System.Nullable<int> height, string type)
    {
        var val_4;
        string val_14;
        bool val_15;
        string val_16;
        string val_17;
        string val_18;
        val_14 = System.String.Format(format:  "/{0}/picture", arg0:  facebookID);
        if((width.HasValue & true) == 0)
        {
                val_15 = val_4;
            val_16 = "&width="("&width=") + width.HasValue.ToString();
        }
        else
        {
                val_16 = "";
            val_15 = height.HasValue >> 32;
        }
        
        if((val_15 & true) == 0)
        {
                val_17 = "&height="("&height=") + height.HasValue.ToString();
        }
        else
        {
                val_17 = "";
        }
        
        if(type != null)
        {
                val_18 = "&type="("&type=") + type;
        }
        else
        {
                val_18 = "";
        }
        
        string val_10 = val_16 + val_17(val_16 + val_17) + val_18(val_16 + val_17(val_16 + val_17) + val_18) + "&redirect=false"("&redirect=false");
        if((System.String.op_Inequality(a:  val_10, b:  "")) == false)
        {
                return (string)val_14;
        }
        
        val_14 = val_14 + "?g"("?g") + val_10;
        return (string)val_14;
    }
    public static double GetCurrentTime()
    {
        System.DateTime val_1 = System.DateTime.Now;
        System.DateTime val_2 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0);
        System.TimeSpan val_3 = val_1.dateData.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
        return (double)val_3._ticks.TotalSeconds;
    }
    public static double GetCurrentTimeInDays()
    {
        System.DateTime val_1 = System.DateTime.Now;
        System.DateTime val_2 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0);
        System.TimeSpan val_3 = val_1.dateData.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
        return (double)val_3._ticks.TotalDays;
    }
    public static double GetCurrentTimeInMills()
    {
        System.DateTime val_1 = System.DateTime.Now;
        System.DateTime val_2 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0);
        System.TimeSpan val_3 = val_1.dateData.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
        return (double)val_3._ticks.TotalMilliseconds;
    }
    public static T GetRandom<T>(T[] arr)
    {
        return (object)arr[UnityEngine.Random.Range(min:  0, max:  arr.Length)];
    }
    public static bool IsActionAvailable(string action, int time, bool availableFirstTime = True)
    {
        var val_6;
        if((CPlayerPrefs.HasKey(key:  action + "_time")) != false)
        {
                double val_4 = CUtils.GetActionTime(action:  action);
            val_4 = CUtils.GetCurrentTime() - val_4;
            val_4 = (val_4 == Infinity) ? (-val_4) : (val_4);
            var val_5 = ((int)val_4 >= time) ? 1 : 0;
            return (bool)val_6;
        }
        
        if(availableFirstTime != false)
        {
                val_6 = 1;
            return (bool)val_6;
        }
        
        CUtils.SetActionTime(action:  action);
        val_6 = 0;
        return (bool)val_6;
    }
    public static double GetActionDeltaTime(string action)
    {
        if((CUtils.GetActionTime(action:  action)) == 0f)
        {
                return (double)val_3;
        }
        
        double val_3 = CUtils.GetActionTime(action:  action);
        val_3 = CUtils.GetCurrentTime() - val_3;
        return (double)val_3;
    }
    public static void SetActionTime(string action)
    {
        CPlayerPrefs.SetDouble(key:  action + "_time", value:  CUtils.GetCurrentTime());
    }
    public static void SetActionTime(string action, double time)
    {
        CPlayerPrefs.SetDouble(key:  action + "_time", value:  time);
    }
    public static double GetActionTime(string action)
    {
        return CPlayerPrefs.GetDouble(key:  action + "_time");
    }
    public static void SetLoggedInFb()
    {
        CPlayerPrefs.SetBool(key:  "logged_in_fb", value:  true);
    }
    public static bool IsLoggedInFb()
    {
        return CPlayerPrefs.GetBool(key:  "logged_in_fb", defaultValue:  false);
    }
    public static void SetBuyItem()
    {
        CPlayerPrefs.SetBool(key:  "buy_item", value:  true);
    }
    public static void SetRemoveAds(bool value)
    {
        CPlayerPrefs.SetBool(key:  "remove_ads", value:  value);
    }
    public static bool IsAdsRemoved()
    {
        return CPlayerPrefs.GetBool(key:  "remove_ads", defaultValue:  false);
    }
    public static bool IsBuyItem()
    {
        return CPlayerPrefs.GetBool(key:  "buy_item", defaultValue:  false);
    }
    public static void SetRateGame()
    {
        CPlayerPrefs.SetBool(key:  "rate_game", value:  true);
    }
    public static bool IsGameRated()
    {
        return CPlayerPrefs.GetBool(key:  "rate_game", defaultValue:  false);
    }
    public static void SetLikeFbPage(string id)
    {
        CPlayerPrefs.SetBool(key:  "like_page_" + id, value:  true);
    }
    public static bool IsLikedFbPage(string id)
    {
        return CPlayerPrefs.GetBool(key:  "like_page_" + id, defaultValue:  false);
    }
    public static void SetInitGame()
    {
        CPlayerPrefs.SetBool(key:  "init_game", value:  true);
    }
    public static bool IsGameInitialzied()
    {
        return CPlayerPrefs.GetBool(key:  "init_game", defaultValue:  false);
    }
    public static void SetAndroidVersion(string version)
    {
        CPlayerPrefs.SetString(key:  "android_version", val:  version);
    }
    public static void SetIOSVersion(string version)
    {
        CPlayerPrefs.SetString(key:  "ios_version", val:  version);
    }
    public static void SetWindowsPhoneVersion(string version)
    {
        CPlayerPrefs.SetString(key:  "wp_version", val:  version);
    }
    public static string GetAndroidVersion()
    {
        return CPlayerPrefs.GetString(key:  "android_version", defaultValue:  "1.0");
    }
    public static string GetIOSVersion()
    {
        return CPlayerPrefs.GetString(key:  "ios_version", defaultValue:  "1.0");
    }
    public static string GetWindowsPhoneVersion()
    {
        return CPlayerPrefs.GetString(key:  "wp_version", defaultValue:  "1.0");
    }
    public static void SetVersionCode(int versionCode)
    {
        CPlayerPrefs.SetInt(key:  "game_version_code", val:  versionCode);
    }
    public static int GetVersionCode()
    {
        return CPlayerPrefs.GetInt(key:  "game_version_code");
    }
    public static string BuildStringFromCollection(System.Collections.ICollection values, char split = '\x7c')
    {
        var val_10;
        object val_11;
        var val_13;
        string val_15;
        var val_18;
        val_10 = values;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = "";
        var val_13 = 0;
        val_13 = val_13 + 1;
        System.Collections.IEnumerator val_2 = val_10.GetEnumerator();
        val_13 = 0;
        goto label_7;
        label_21:
        var val_14 = 0;
        val_14 = val_14 + 1;
        val_15 = val_11 + val_2.Current;
        var val_15 = 0;
        val_15 = val_15 + 1;
        if(val_13 != (val_10.Count - 1))
        {
                val_15 = val_15 + split.ToString();
        }
        
        val_13 = 1;
        val_11 = val_15;
        label_7:
        var val_16 = 0;
        val_16 = val_16 + 1;
        if(val_2.MoveNext() == true)
        {
            goto label_21;
        }
        
        val_10 = 0;
        if(X0 == false)
        {
            goto label_22;
        }
        
        var val_19 = X0;
        if((X0 + 294) == 0)
        {
            goto label_26;
        }
        
        var val_17 = X0 + 176;
        var val_18 = 0;
        val_17 = val_17 + 8;
        label_25:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_24;
        }
        
        val_18 = val_18 + 1;
        val_17 = val_17 + 16;
        if(val_18 < (X0 + 294))
        {
            goto label_25;
        }
        
        goto label_26;
        label_24:
        val_19 = val_19 + (((X0 + 176 + 8)) << 4);
        val_18 = val_19 + 304;
        label_26:
        X0.Dispose();
        label_22:
        if(val_10 != 0)
        {
                throw val_10;
        }
        
        return (string)val_11;
    }
    public static System.Collections.Generic.List<T> BuildListFromString<T>(string values, char split = '\x7c')
    {
        string val_7 = values;
        if((System.String.IsNullOrEmpty(value:  val_7 = values)) == true)
        {
                return (System.Collections.Generic.List<T>)__RuntimeMethodHiddenParam + 48;
        }
        
        char[] val_2 = new char[1];
        val_2[0] = split;
        int val_7 = val_3.Length;
        val_7 = val_7.Split(separator:  val_2);
        if(val_7 < 1)
        {
                return (System.Collections.Generic.List<T>)__RuntimeMethodHiddenParam + 48;
        }
        
        var val_8 = 0;
        val_7 = val_7 & 4294967295;
        do
        {
            if((System.String.IsNullOrEmpty(value:  1152921505059157200)) != true)
        {
                object val_6 = System.Convert.ChangeType(value:  1152921505059157200, conversionType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48 + 16}));
        }
        
            val_8 = val_8 + 1;
        }
        while(val_8 < (val_3.Length << ));
        
        return (System.Collections.Generic.List<T>)__RuntimeMethodHiddenParam + 48;
    }
    public static bool IsOutOfScreen(UnityEngine.Vector3 pos, float padding = 0)
    {
        var val_4;
        float val_3 = WordUICamera.instance + 76;
        val_3 = val_3 + padding;
        if((pos.x >= 0) && (pos.x <= val_3))
        {
                float val_4 = WordUICamera.instance + 80;
            val_4 = val_4 + padding;
            val_4 = ((pos.y > val_4) ? 1 : 0) | ((pos.y < 0) ? 1 : 0);
            return (bool)val_4;
        }
        
        val_4 = 1;
        return (bool)val_4;
    }
    public static void SetNumofEnterScene(string sceneName, int value)
    {
        CPlayerPrefs.SetInt(key:  "numof_enter_scene_" + sceneName, val:  value);
    }
    public static int GetNumofEnterScene(string sceneName)
    {
        return CPlayerPrefs.GetInt(key:  "numof_enter_scene_" + sceneName, defaultValue:  0);
    }
    public static int IncreaseNumofEnterScene(string sceneName)
    {
        int val_2 = (CUtils.GetNumofEnterScene(sceneName:  sceneName)) + 1;
        CUtils.SetNumofEnterScene(sceneName:  sceneName, value:  val_2);
        return val_2;
    }
    public static System.Collections.Generic.List<T> GetObjectInRange<T>(UnityEngine.Vector3 position, float radius, int layerMask = -5)
    {
        UnityEngine.Vector2 val_1 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = position.x, y = position.y, z = position.z});
        if(val_2.Length < 1)
        {
                return (System.Collections.Generic.List<T>)__RuntimeMethodHiddenParam + 48;
        }
        
        var val_7 = 0;
        label_19:
        UnityEngine.Component val_5 = UnityEngine.Physics2D.OverlapCircleAll(point:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y}, radius:  radius, layerMask:  layerMask)[val_7].gameObject.GetComponent(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48 + 16}));
        if(X0 == false)
        {
            goto label_16;
        }
        
        if(X0 == true)
        {
            goto label_17;
        }
        
        goto label_18;
        label_16:
        label_17:
        val_7 = val_7 + 1;
        if(val_7 < val_2.Length)
        {
            goto label_19;
        }
        
        return (System.Collections.Generic.List<T>)__RuntimeMethodHiddenParam + 48;
        label_18:
    }
    public static UnityEngine.Sprite GetSprite(string textureName, string spriteName)
    {
        T val_4;
        if(val_1.Length >= 1)
        {
                var val_4 = 0;
            do
        {
            val_4 = UnityEngine.Resources.LoadAll<UnityEngine.Sprite>(path:  textureName)[val_4];
            if((System.String.op_Equality(a:  val_4.name, b:  spriteName)) == true)
        {
                return (UnityEngine.Sprite)val_4;
        }
        
            val_4 = val_4 + 1;
        }
        while(val_4 < val_1.Length);
        
        }
        
        val_4 = 0;
        return (UnityEngine.Sprite)val_4;
    }
    public static System.Collections.Generic.List<UnityEngine.Transform> GetActiveChildren(UnityEngine.Transform parent)
    {
        UnityEngine.Transform val_10;
        var val_11;
        System.Collections.Generic.List<UnityEngine.Transform> val_1 = new System.Collections.Generic.List<UnityEngine.Transform>();
        if(parent == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.IEnumerator val_2 = parent.GetEnumerator();
        label_18:
        var val_9 = 0;
        val_9 = val_9 + 1;
        if(val_2.MoveNext() == false)
        {
            goto label_7;
        }
        
        var val_10 = 0;
        val_10 = val_10 + 1;
        object val_6 = val_2.Current;
        val_10 = val_6;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_7 = val_10.gameObject;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_7.activeSelf == false)
        {
            goto label_18;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_10);
        goto label_18;
        label_7:
        val_10 = 0;
        if(X0 == false)
        {
            goto label_19;
        }
        
        var val_13 = X0;
        if((X0 + 294) == 0)
        {
            goto label_23;
        }
        
        var val_11 = X0 + 176;
        var val_12 = 0;
        val_11 = val_11 + 8;
        label_22:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_21;
        }
        
        val_12 = val_12 + 1;
        val_11 = val_11 + 16;
        if(val_12 < (X0 + 294))
        {
            goto label_22;
        }
        
        goto label_23;
        label_21:
        val_13 = val_13 + (((X0 + 176 + 8)) << 4);
        val_11 = val_13 + 304;
        label_23:
        X0.Dispose();
        label_19:
        if(val_10 != 0)
        {
                throw val_10;
        }
        
        return val_1;
    }
    public static System.Collections.Generic.List<UnityEngine.Transform> GetChildren(UnityEngine.Transform parent)
    {
        var val_6;
        var val_9;
        System.Collections.Generic.List<UnityEngine.Transform> val_1 = new System.Collections.Generic.List<UnityEngine.Transform>();
        if(parent == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.IEnumerator val_2 = parent.GetEnumerator();
        val_6 = 1152921504683417600;
        label_16:
        var val_7 = 0;
        val_7 = val_7 + 1;
        if(val_2.MoveNext() == false)
        {
            goto label_7;
        }
        
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_2.Current);
        goto label_16;
        label_7:
        val_6 = 0;
        if(X0 == false)
        {
            goto label_17;
        }
        
        var val_11 = X0;
        if((X0 + 294) == 0)
        {
            goto label_21;
        }
        
        var val_9 = X0 + 176;
        var val_10 = 0;
        val_9 = val_9 + 8;
        label_20:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_19;
        }
        
        val_10 = val_10 + 1;
        val_9 = val_9 + 16;
        if(val_10 < (X0 + 294))
        {
            goto label_20;
        }
        
        goto label_21;
        label_19:
        val_11 = val_11 + (((X0 + 176 + 8)) << 4);
        val_9 = val_11 + 304;
        label_21:
        X0.Dispose();
        label_17:
        if(val_6 != 0)
        {
                throw val_6;
        }
        
        return val_1;
    }
    public static bool IsLoadingScene()
    {
        var val_3;
        if(ScreenFaderV2.fadeInTime != 0)
        {
                if((ScreenFaderV2.fadeInTime + 24) == 0)
        {
                return (bool)((ScreenFaderV2.fadeInTime + 25) != 0) ? 1 : 0;
        }
        
            val_3 = 1;
            return (bool)((ScreenFaderV2.fadeInTime + 25) != 0) ? 1 : 0;
        }
        
        val_3 = 0;
        return (bool)((ScreenFaderV2.fadeInTime + 25) != 0) ? 1 : 0;
    }
    public static void FadeAndLoadScene(string sceneName)
    {
        var val_7;
        System.Collections.Generic.List<System.String> val_8;
        string val_9;
        string val_10;
        var val_8 = 0;
        label_10:
        val_7 = null;
        val_7 = null;
        val_8 = CUtils.invalidSceneIndeces;
        if(val_8 >= (CUtils.invalidSceneIndeces + 24))
        {
            goto label_4;
        }
        
        val_8 = CUtils.invalidSceneIndeces;
        if(val_8 >= (CUtils.invalidSceneIndeces + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_7 = CUtils.invalidSceneIndeces + 16;
        val_7 = val_7 + 0;
        val_8 = val_8 + 1;
        if((sceneName.Contains(value:  (CUtils.invalidSceneIndeces + 16 + 0) + 32)) == false)
        {
            goto label_10;
        }
        
        UnityEngine.Debug.LogError(message:  "CUtils.FadeAndLoadScene(int) attempting to load invalid scene index " + sceneName + ". Please use a valid scene index.");
        return;
        label_4:
        if(ScreenFaderV2.fadeInTime == 0)
        {
            goto label_15;
        }
        
        if((ScreenFaderV2.fadeInTime + 24) == 0)
        {
            goto label_17;
        }
        
        if((ScreenFaderV2.fadeInTime + 25) == 0)
        {
                return;
        }
        
        val_9 = "is fading";
        goto label_19;
        label_15:
        CUtils.LoadSceneImmediate(sceneName:  sceneName);
        return;
        label_17:
        if((ScreenFaderV2.fadeInTime + 25) == 0)
        {
            goto label_22;
        }
        
        val_9 = "";
        label_19:
        if((System.String.IsNullOrEmpty(value:  val_9)) != true)
        {
                val_10 = val_9 + " and ";
        }
        
        string val_6 = val_10 + "is loading scene";
        return;
        label_22:
        ScreenFaderV2.fadeInTime.GotoScene(sceneName:  sceneName);
    }
    public static void LoadSceneImmediate(string sceneName)
    {
        App.StartSceneLoadingTimer();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  sceneName, mode:  0);
    }
    public static void ReloadScene(bool useScreenFader = False)
    {
        UnityEngine.SceneManagement.Scene val_1 = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        char[] val_3 = new char[1];
        val_3[0] = '_';
        string val_7 = val_1.m_Handle.name.Split(separator:  val_3)[0](val_1.m_Handle.name.Split(separator:  val_3)[0]) + "_" + App.ThemesHandler.CurrentThemeName;
        if(useScreenFader != false)
        {
                CUtils.FadeAndLoadScene(sceneName:  val_7);
            return;
        }
        
        CUtils.LoadSceneImmediate(sceneName:  val_7);
    }
    public static void CheckConnection(UnityEngine.MonoBehaviour behaviour, System.Action<int> connectionListener)
    {
        UnityEngine.Coroutine val_2 = behaviour.StartCoroutine(routine:  CUtils.ConnectUrl(url:  "http://www.google.com", connectionListener:  connectionListener));
    }
    private static System.Collections.IEnumerator ConnectUrl(string url, System.Action<int> connectionListener)
    {
        .<>1__state = 0;
        .url = url;
        .connectionListener = connectionListener;
        return (System.Collections.IEnumerator)new CUtils.<ConnectUrl>d__60();
    }
    public static void CheckDisconnection(UnityEngine.MonoBehaviour behaviour, System.Action onDisconnected)
    {
        UnityEngine.Coroutine val_2 = behaviour.StartCoroutine(routine:  CUtils.ConnectUrl(url:  "http://www.google.com", onDisconnected:  onDisconnected));
    }
    private static System.Collections.IEnumerator ConnectUrl(string url, System.Action onDisconnected)
    {
        .<>1__state = 0;
        .url = url;
        .onDisconnected = onDisconnected;
        return (System.Collections.IEnumerator)new CUtils.<ConnectUrl>d__62();
    }
    public static void SetAutoSigninGPS(int value)
    {
        CPlayerPrefs.SetInt(key:  "auto_sign_in_gps", val:  value);
    }
    public static int GetAutoSigninGPS()
    {
        return CPlayerPrefs.GetInt(key:  "auto_sign_in_gps");
    }
    public static System.Collections.IEnumerator LoadPicture(string url, System.Action<UnityEngine.Texture2D> callback, int width, int height, bool useCached = True)
    {
        .<>1__state = 0;
        .url = url;
        .callback = callback;
        .width = width;
        .height = height;
        .useCached = useCached;
        return (System.Collections.IEnumerator)new CUtils.<LoadPicture>d__65();
    }
    private static string GetLocalPath(string url)
    {
        return UnityEngine.Application.persistentDataPath + "/"("/") + System.IO.Path.GetFileName(path:  new System.Uri(uriString:  url).LocalPath)(System.IO.Path.GetFileName(path:  new System.Uri(uriString:  url).LocalPath));
    }
    public static System.Collections.IEnumerator CachePicture(string url, System.Action<bool> result)
    {
        .<>1__state = 0;
        .url = url;
        .result = result;
        return (System.Collections.IEnumerator)new CUtils.<CachePicture>d__67();
    }
    public static bool IsCacheExists(string url)
    {
        return System.IO.File.Exists(path:  CUtils.GetLocalPath(url:  url));
    }
    private static bool LoadFromLocal(System.Action<UnityEngine.Texture2D> callback, string localPath, int width, int height)
    {
        var val_6;
        if((System.IO.File.Exists(path:  localPath)) != false)
        {
                UnityEngine.Texture2D val_3 = new UnityEngine.Texture2D(width:  width, height:  height, textureFormat:  3, mipChain:  false);
            bool val_4 = UnityEngine.ImageConversion.LoadImage(tex:  val_3, data:  System.IO.File.ReadAllBytes(path:  localPath));
            if(val_3 != 0)
        {
                callback.Invoke(obj:  val_3);
            val_6 = 1;
            return (bool)val_6;
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public static UnityEngine.Sprite CreateSprite(UnityEngine.Texture2D texture, int width, int height)
    {
        UnityEngine.Rect val_1 = new UnityEngine.Rect(x:  0f, y:  0f, width:  (float)width, height:  (float)height);
        UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
        return (UnityEngine.Sprite)UnityEngine.Sprite.Create(texture:  texture, rect:  new UnityEngine.Rect() {m_XMin = val_1.m_XMin, m_YMin = val_1.m_YMin, m_Width = val_1.m_Width, m_Height = val_1.m_Height}, pivot:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y}, pixelsPerUnit:  100f);
    }
    public static System.Collections.Generic.List<System.Collections.Generic.List<T>> Split<T>(System.Collections.Generic.List<T> source, System.Predicate<T> split)
    {
        if(source < 1)
        {
                return (System.Collections.Generic.List<System.Collections.Generic.List<T>>)__RuntimeMethodHiddenParam + 48;
        }
        
        var val_2 = 0;
        label_12:
        if((split & 1) == 0)
        {
            goto label_4;
        }
        
        goto label_5;
        label_4:
        if((0 & 1) != 0)
        {
                if((__RuntimeMethodHiddenParam + 48) != 0)
        {
            goto label_7;
        }
        
        }
        
        label_7:
        var val_1 = (__RuntimeMethodHiddenParam + 48) - 1;
        label_5:
        val_2 = val_2 + 1;
        if(val_2 < source)
        {
            goto label_12;
        }
        
        return (System.Collections.Generic.List<System.Collections.Generic.List<T>>)__RuntimeMethodHiddenParam + 48;
    }
    public static System.Collections.Generic.List<System.Collections.Generic.List<T>> GetArrList<T>(System.Collections.Generic.List<T> source, System.Predicate<T> take)
    {
        var val_1;
        var val_2;
        var val_7;
        var val_8;
        val_7 = take;
        label_12:
        if(val_2.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_7 & 1) == 0)
        {
            goto label_12;
        }
        
        if((0 & 1) == 0)
        {
            goto label_6;
        }
        
        if((__RuntimeMethodHiddenParam + 48) != 0)
        {
            goto label_7;
        }
        
        throw new NullReferenceException();
        label_6:
        if((__RuntimeMethodHiddenParam + 48) == 0)
        {
                throw new NullReferenceException();
        }
        
        label_7:
        var val_4 = (__RuntimeMethodHiddenParam + 48) - 1;
        if((__RuntimeMethodHiddenParam + 48) == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_12;
        label_3:
        val_7 = 0;
        val_2 = __RuntimeMethodHiddenParam + 48 + 96;
        val_1 = val_2;
        if((__RuntimeMethodHiddenParam + 48 + 96 + 294) == 0)
        {
            goto label_17;
        }
        
        var val_6 = __RuntimeMethodHiddenParam + 48 + 96 + 176;
        var val_7 = 0;
        val_6 = val_6 + 8;
        label_16:
        if(((__RuntimeMethodHiddenParam + 48 + 96 + 176 + 8) + -8) == null)
        {
            goto label_15;
        }
        
        val_7 = val_7 + 1;
        val_6 = val_6 + 16;
        if(val_7 < (__RuntimeMethodHiddenParam + 48 + 96 + 294))
        {
            goto label_16;
        }
        
        goto label_17;
        label_15:
        val_8 = ((__RuntimeMethodHiddenParam + 48 + 96) + (((__RuntimeMethodHiddenParam + 48 + 96 + 176 + 8)) << 4)) + 304;
        label_17:
        val_2.Dispose();
        if(val_7 != 0)
        {
                throw val_7;
        }
        
        return (System.Collections.Generic.List<System.Collections.Generic.List<T>>)__RuntimeMethodHiddenParam + 48;
    }
    public static System.Collections.Generic.List<T> ToList<T>(T obj)
    {
        if(((__RuntimeMethodHiddenParam + 48 + 302) & 1) != 0)
        {
                return (System.Collections.Generic.List<T>)__RuntimeMethodHiddenParam + 48;
        }
        
        return (System.Collections.Generic.List<T>)__RuntimeMethodHiddenParam + 48;
    }
    public static int ChooseRandomWithProbs(float[] probs)
    {
        float val_4;
        var val_5;
        int val_1 = probs.Length << 32;
        if(val_1 >= 1)
        {
                var val_3 = 0;
            do
        {
            val_3 = val_3 + 1;
            val_4 = 0f + null;
        }
        while(val_3 < (long)probs.Length);
        
        }
        else
        {
                val_4 = 0f;
        }
        
        float val_2 = UnityEngine.Random.value;
        int val_4 = probs.Length;
        val_5 = val_4 - 1;
        if(val_1 < 1)
        {
                return (int)val_5;
        }
        
        val_4 = val_4 & 4294967295;
        var val_5 = 0;
        val_2 = val_4 * val_2;
        label_8:
        if(val_2 < 0)
        {
            goto label_7;
        }
        
        val_5 = val_5 + 1;
        val_2 = val_2 - null;
        if(val_5 < (long)val_4)
        {
            goto label_8;
        }
        
        return (int)val_5;
        label_7:
        val_5 = val_5;
        return (int)val_5;
    }
    public static bool IsObjectSeenByCamera(UnityEngine.Camera camera, UnityEngine.GameObject gameObj, float delta = 0)
    {
        var val_8;
        UnityEngine.Vector3 val_2 = gameObj.transform.position;
        UnityEngine.Vector3 val_3 = camera.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        if((val_3.z > 0f) && (val_3.x > (-delta)))
        {
                float val_7 = 1f;
            val_7 = delta + val_7;
            var val_4 = (val_3.x < 0) ? 1 : 0;
            val_4 = val_4 & ((val_3.y > (-delta)) ? 1 : 0);
            val_8 = val_4 & ((val_3.y < 0) ? 1 : 0);
            return (bool)val_8;
        }
        
        val_8 = 0;
        return (bool)val_8;
    }
    public static UnityEngine.Vector3 GetMiddlePoint(UnityEngine.Vector3 begin, UnityEngine.Vector3 end, float delta = 0)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = begin.x, y = begin.y, z = begin.z}, b:  new UnityEngine.Vector3() {x = end.x, y = end.y, z = end.z}, t:  0.5f);
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = end.x, y = end.y, z = end.z}, b:  new UnityEngine.Vector3() {x = begin.x, y = begin.y, z = begin.z});
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  -val_2.y, y:  val_2.x, z:  0f);
        UnityEngine.Vector3 val_4 = val_3.x.normalized;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, d:  delta);
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, b:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
        return new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
    }
    public static UnityEngine.AnimationClip GetAnimationClip(UnityEngine.Animator anim, string name)
    {
        var val_8;
        UnityEngine.AnimationClip val_9;
        UnityEngine.RuntimeAnimatorController val_1 = anim.runtimeAnimatorController;
        UnityEngine.AnimationClip[] val_2 = val_1.animationClips;
        val_8 = 0;
        label_8:
        if(val_8 >= val_2.Length)
        {
            goto label_3;
        }
        
        if((System.String.op_Equality(a:  val_1.animationClips[0].name, b:  name)) == true)
        {
            goto label_7;
        }
        
        val_8 = val_8 + 1;
        if(val_1.animationClips != null)
        {
            goto label_8;
        }
        
        throw new NullReferenceException();
        label_3:
        val_9 = 0;
        return val_9;
        label_7:
        val_9 = val_1.animationClips[0];
        return val_9;
    }
    public static void Swap<T>(ref T lhs, ref T rhs)
    {
        lhs = rhs;
        rhs = lhs;
    }
    public static void Pause()
    {
    
    }
    public CUtils()
    {
    
    }

}
