using UnityEngine;
public class Logger
{
    // Fields
    public static bool Leagues;
    public static bool GameEvents;
    public static bool Machines;
    public static bool Profile;
    public static bool Store;
    public static bool EncodableModel;
    private static bool Enabled;
    
    // Methods
    public static void Init()
    {
    
    }
    public static void Setup(bool val)
    {
        null = null;
        Logger.Enabled = val;
    }
    public static void Exception(System.Exception ex)
    {
        null = null;
        if(Logger.Enabled == false)
        {
                return;
        }
        
        UnityEngine.Debug.LogException(exception:  ex);
    }
    public static void Warn(object message)
    {
        object val_5;
        var val_6;
        val_5 = message;
        val_6 = null;
        val_6 = null;
        if(Logger.Enabled == false)
        {
                return;
        }
        
        val_5 = val_5;
        UnityEngine.Debug.LogWarning(message:  val_5);
    }
    public static void Log(object message)
    {
        object val_5;
        var val_6;
        val_5 = message;
        val_6 = null;
        val_6 = null;
        if(Logger.Enabled == false)
        {
                return;
        }
        
        val_5 = val_5;
        UnityEngine.Debug.Log(message:  val_5);
    }
    public Logger()
    {
    
    }
    private static Logger()
    {
        Logger.Enabled = true;
    }

}
