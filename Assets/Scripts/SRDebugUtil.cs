using UnityEngine;
public static class SRDebugUtil
{
    // Fields
    public const int LineBufferCount = 512;
    private static bool <IsFixedUpdate>k__BackingField;
    
    // Properties
    public static bool IsFixedUpdate { get; set; }
    
    // Methods
    public static bool get_IsFixedUpdate()
    {
        return (bool)SRDebugUtil.<IsFixedUpdate>k__BackingField;
    }
    public static void set_IsFixedUpdate(bool value)
    {
        SRDebugUtil.<IsFixedUpdate>k__BackingField = value;
    }
    public static void AssertNotNull(object value, string message, UnityEngine.MonoBehaviour instance)
    {
        if(((System.Collections.Generic.EqualityComparer<System.Object>.Default) & 1) == 0)
        {
                return;
        }
        
        if(message != null)
        {
            goto label_3;
        }
        
        label_13:
        UnityEngine.Debug.LogError(message:  "Assert Failed", context:  instance);
        if(instance == 0)
        {
                throw new System.NullReferenceException(message:  "Assert Failed");
        }
        
        instance.enabled = false;
        throw new System.NullReferenceException(message:  "Assert Failed");
        label_3:
        object[] val_4 = new object[1];
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        if(X0 != true)
        {
                throw new ArrayTypeMismatchException();
        }
        
        if(val_4.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_4[0] = "Assert Failed";
        string val_5 = SRF.SRFStringExtensions.Fmt(formatString:  "NotNullAssert Failed: {0}", args:  val_4);
        goto label_13;
    }
    public static void Assert(bool condition, string message, UnityEngine.MonoBehaviour instance)
    {
        if(condition != false)
        {
                return;
        }
        
        if(message != null)
        {
            goto label_2;
        }
        
        label_8:
        UnityEngine.Debug.LogError(message:  "Assert Failed", context:  instance);
        throw new System.Exception(message:  "Assert Failed");
        label_2:
        object[] val_2 = new object[1];
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        if(X0 != true)
        {
                throw new ArrayTypeMismatchException();
        }
        
        if(val_2.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_2[0] = "Assert Failed";
        string val_3 = SRF.SRFStringExtensions.Fmt(formatString:  "Assert Failed: {0}", args:  val_2);
        goto label_8;
    }
    public static void EditorAssertNotNull(object value, string message, UnityEngine.MonoBehaviour instance)
    {
        SRDebugUtil.AssertNotNull(value:  value, message:  message, instance:  instance);
    }
    public static void EditorAssert(bool condition, string message, UnityEngine.MonoBehaviour instance)
    {
        SRDebugUtil.Assert(condition:  condition, message:  message, instance:  instance);
    }

}
