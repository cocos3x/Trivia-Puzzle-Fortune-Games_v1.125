using UnityEngine;
public class D
{
    // Fields
    public const string vLog = "log";
    public const string vWarn = "warn";
    public const string vError = "error";
    public static string[] typeList;
    
    // Methods
    public static void LogClientError(string developer, string filter = "default", UnityEngine.Object context, object[] strings)
    {
        object val_3;
        int val_3 = strings.Length;
        val_3 = filter + " : "(" : ") + developer + " : "(" : ");
        if(val_3 >= 1)
        {
                var val_4 = 0;
            val_3 = val_3 & 4294967295;
            do
        {
            val_4 = val_4 + 1;
            val_3 = val_3 + null;
        }
        while(val_4 < (strings.Length << ));
        
        }
        
        UnityEngine.Debug.LogError(message:  val_3, context:  context);
    }
    public static void LogS(object[] strings)
    {
        object val_3;
        if((D.allow(filter:  "default")) == false)
        {
                return;
        }
        
        int val_3 = strings.Length;
        val_3 = "default : NA : ";
        if(val_3 >= 1)
        {
                var val_4 = 0;
            val_3 = val_3 & 4294967295;
            do
        {
            val_4 = val_4 + 1;
            val_3 = val_3 + null;
        }
        while(val_4 < (strings.Length << ));
        
        }
        
        D.LogOut(text:  val_3, visualType:  "log", context:  0);
    }
    public static void Log(string developer = "NA", string filter = "default", string visualType = "log", UnityEngine.Object context, object[] strings)
    {
        string val_4;
        object val_5;
        val_4 = developer;
        if((D.allow(filter:  filter)) == false)
        {
                return;
        }
        
        int val_4 = strings.Length;
        val_5 = filter + " : "(" : ") + val_4 + " : "(" : ");
        if(val_4 >= 1)
        {
                val_4 = val_4 & 4294967295;
            do
        {
            val_4 = 0 + 1;
            val_5 = val_5 + null;
        }
        while(val_4 < (strings.Length << ));
        
        }
        
        D.LogOut(text:  val_5, visualType:  visualType, context:  context);
    }
    public static void LogB(string developer = "NA", string filter = "default", string visualType = "log", bool show = False, UnityEngine.Object context, object[] strings)
    {
        string val_4;
        object val_5;
        val_4 = developer;
        if(show == false)
        {
                return;
        }
        
        if((D.allow(filter:  filter)) == false)
        {
                return;
        }
        
        int val_4 = strings.Length;
        val_5 = filter + " : "(" : ") + val_4 + " : "(" : ");
        if(val_4 >= 1)
        {
                val_4 = val_4 & 4294967295;
            do
        {
            val_4 = 0 + 1;
            val_5 = val_5 + null;
        }
        while(val_4 < (strings.Length << ));
        
        }
        
        D.LogOut(text:  val_5, visualType:  visualType, context:  context);
    }
    public static void LogF(string developer = "NA", string filter = "default", string visualType = "log", string formatString = "{0}", UnityEngine.Object context, object[] strings)
    {
        if((D.allow(filter:  filter)) == false)
        {
                return;
        }
        
        string val_2 = filter + " : "(" : ") + developer + " : "(" : ");
        string val_4 = System.String.Format(format:  val_2 + formatString, args:  strings);
        D.LogOut(text:  val_2, visualType:  visualType, context:  context);
    }
    public static void LogC(System.Func<string> callback, string developer = "NA", string filter = "default", string visualType = "log", UnityEngine.Object context)
    {
        int val_5;
        if((D.allow(filter:  filter)) == false)
        {
                return;
        }
        
        string[] val_2 = new string[5];
        val_5 = val_2.Length;
        val_2[0] = filter;
        val_5 = val_2.Length;
        val_2[1] = " : ";
        if(developer != null)
        {
                val_5 = val_2.Length;
        }
        
        val_2[2] = developer;
        val_5 = val_2.Length;
        val_2[3] = " : ";
        val_2[4] = callback.Invoke();
        D.LogOut(text:  +val_2, visualType:  visualType, context:  context);
    }
    public static void LogC(string formatString, System.Func<string> callback, string developer = "NA", string filter = "default", string visualType = "log", UnityEngine.Object context)
    {
        if((D.allow(filter:  filter)) == false)
        {
                return;
        }
        
        string val_2 = filter + " : "(" : ") + developer + " : "(" : ");
        string val_5 = System.String.Format(format:  val_2 + formatString, arg0:  callback.Invoke());
        D.LogOut(text:  val_2, visualType:  visualType, context:  context);
    }
    private static void LogOut(string text, string visualType, UnityEngine.Object context)
    {
        if((System.String.op_Equality(a:  visualType, b:  "warn")) != false)
        {
                UnityEngine.Debug.LogWarning(message:  text, context:  context);
            return;
        }
        
        if((System.String.op_Equality(a:  visualType, b:  "error")) != false)
        {
                UnityEngine.Debug.LogError(message:  text, context:  context);
            return;
        }
        
        UnityEngine.Debug.Log(message:  text, context:  context);
    }
    private static bool allow(string filter)
    {
        var val_4;
        var val_5;
        var val_6;
        val_4 = null;
        val_4 = null;
        if(((System.Array.IndexOf<System.String>(array:  D.typeList, value:  "all")) & 2147483648) == 0)
        {
                val_5 = 1;
            return (bool)val_5;
        }
        
        val_6 = null;
        val_6 = null;
        val_5 = ((System.Array.IndexOf<System.String>(array:  D.typeList, value:  filter)) >> 31) ^ 1;
        return (bool)val_5;
    }
    public D()
    {
    
    }
    private static D()
    {
        D.typeList = new string[0];
    }

}
