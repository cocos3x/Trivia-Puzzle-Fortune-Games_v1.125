using UnityEngine;
public static class UnityBridge
{
    // Fields
    private const string SEND = "window.UnityBridge.Send";
    private const string PURCHASE = "window.UnityBridge.Purchase";
    private const string OPENURL = "window.UnityBridge.OpenNewTab";
    private const string HIDE_LOADING = "window.UnityBridge.HideLoadingScreen";
    private const string FB_REQUEST = "window.Facebook.request";
    private const string FB_FEED = "window.Facebook.fbFeed";
    private const string FB_SHARE = "window.Facebook.fbShare";
    private const string FB_PERMISSIONS_REQUEST = "window.Facebook.requestForPermission";
    private const string EASY_BUY_MODULE_INIT = "window.EasyBuyModule.OnGameLoad";
    private const string COPY_TO_CLIPBOARD = "window.UnityBridge.CopyToClipboard";
    
    // Methods
    public static void Send(string url, string requestType, object data, NetworkThreadingHandler threadHandler)
    {
        int val_6;
        string val_1 = MiniJSON.Json.Serialize(obj:  data);
        string val_2 = UnityBridge.generateThreadName(length:  16);
        threadHandler.gameObject.name = val_2;
        if(threadHandler.Request.logging != false)
        {
                UnityEngine.Debug.Log(message:  "SEND(" + requestType + "). Json sent is: "("). Json sent is: ") + val_1);
        }
        
        object[] val_5 = new object[4];
        val_6 = val_5.Length;
        val_5[0] = url;
        if(requestType != null)
        {
                val_6 = val_5.Length;
        }
        
        val_5[1] = requestType;
        if(val_1 != null)
        {
                val_6 = val_5.Length;
        }
        
        val_5[2] = val_1;
        if(val_2 != null)
        {
                val_6 = val_5.Length;
        }
        
        val_5[3] = val_2;
        UnityEngine.Application.ExternalCall(functionName:  "window.UnityBridge.Send", args:  val_5);
    }
    public static void Receive(string data, NetworkThreadingHandler threadHandler)
    {
        if(threadHandler.Request.logging != false)
        {
                UnityEngine.Debug.Log(message:  "RECEIVE. Json received is: "("RECEIVE. Json received is: ") + data);
            threadHandler.Request = threadHandler.Request;
        }
        
        threadHandler.Request.responseString = data;
        threadHandler.Request.finalize();
    }
    public static void FbRequest(object data)
    {
        object[] val_1 = new object[2];
        val_1[0] = MiniJSON.Json.Serialize(obj:  data);
        val_1[1] = UnityBridge.CreateThreadingHandler();
        UnityEngine.Application.ExternalCall(functionName:  "window.Facebook.request", args:  val_1);
    }
    public static void FbFeed(string url, string to = "")
    {
        int val_3;
        object[] val_1 = new object[3];
        val_3 = val_1.Length;
        val_1[0] = url;
        if(to != null)
        {
                val_3 = val_1.Length;
        }
        
        val_1[1] = to;
        val_1[2] = UnityBridge.CreateThreadingHandler();
        UnityEngine.Application.ExternalCall(functionName:  "window.Facebook.fbFeed", args:  val_1);
    }
    public static void FBShare(string url)
    {
        int val_3;
        object[] val_1 = new object[3];
        val_3 = val_1.Length;
        val_1[0] = url;
        if(url != null)
        {
                val_3 = val_1.Length;
        }
        
        val_1[1] = url;
        val_1[2] = UnityBridge.CreateThreadingHandler();
        UnityEngine.Application.ExternalCall(functionName:  "window.Facebook.fbShare", args:  val_1);
    }
    public static void InitEasyBuyBar(string packageData, string gameObjectName)
    {
        int val_2;
        object[] val_1 = new object[2];
        val_2 = val_1.Length;
        val_1[0] = packageData;
        if(gameObjectName != null)
        {
                val_2 = val_1.Length;
        }
        
        val_1[1] = gameObjectName;
        UnityEngine.Application.ExternalCall(functionName:  "window.EasyBuyModule.OnGameLoad", args:  val_1);
    }
    public static string generateThreadName(int length = 16)
    {
        string val_5 = "";
        if(length < 1)
        {
                return "nthread_" + val_5;
        }
        
        var val_5 = 0;
        do
        {
            val_5 = val_5 + 1;
            val_5 = val_5 + ToCharArray()[(UnityEngine.Random.Range(min:  0, max:  val_1.Length)) << 1][32].ToString()(ToCharArray()[(UnityEngine.Random.Range(min:  0, max:  val_1.Length)) << 1][32].ToString());
        }
        while(val_5 < length);
        
        return "nthread_" + val_5;
    }
    private static string CreateThreadingHandler()
    {
        UnityEngine.GameObject val_1 = new UnityEngine.GameObject();
        string val_2 = UnityBridge.generateThreadName(length:  16);
        val_1.name = val_2;
        NetworkThreadingHandler val_3 = val_1.AddComponent<NetworkThreadingHandler>();
        return val_2;
    }
    public static void OpenUrl(string url, string text, string title)
    {
        int val_2;
        object[] val_1 = new object[3];
        val_2 = val_1.Length;
        val_1[0] = url;
        if(text != null)
        {
                val_2 = val_1.Length;
        }
        
        val_1[1] = text;
        if(title != null)
        {
                val_2 = val_1.Length;
        }
        
        val_1[2] = title;
        UnityEngine.Application.ExternalCall(functionName:  "window.UnityBridge.OpenNewTab", args:  val_1);
    }
    public static void HideLoadingScreen()
    {
        var val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        UnityEngine.Application.ExternalCall(functionName:  "window.UnityBridge.HideLoadingScreen", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
    }
    public static void CopyToClipboard(string text)
    {
        object[] val_1 = new object[1];
        val_1[0] = text;
        UnityEngine.Application.ExternalCall(functionName:  "window.UnityBridge.CopyToClipboard", args:  val_1);
    }

}
