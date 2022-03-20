using UnityEngine;
public class ClipboardHelper
{
    // Fields
    private static System.Reflection.PropertyInfo m_systemCopyBufferProperty;
    
    // Properties
    public static string clipBoard { get; set; }
    
    // Methods
    private static System.Reflection.PropertyInfo GetSystemCopyBufferProperty()
    {
        System.Reflection.PropertyInfo val_6;
        var val_7;
        var val_8;
        var val_9;
        val_7 = null;
        val_7 = null;
        if((System.Reflection.PropertyInfo.op_Equality(left:  ClipboardHelper.m_systemCopyBufferProperty, right:  0)) != false)
        {
                val_8 = null;
            val_6 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()).GetProperty(name:  "systemCopyBuffer", bindingAttr:  40);
            val_8 = null;
            ClipboardHelper.m_systemCopyBufferProperty = val_6;
            if((System.Reflection.PropertyInfo.op_Equality(left:  ClipboardHelper.m_systemCopyBufferProperty, right:  0)) == true)
        {
                throw new System.Exception(message:  "Can\'t access internal member \'GUIUtility.systemCopyBuffer\' it may have been removed / renamed");
        }
        
        }
        
        val_9 = null;
        val_9 = null;
        return ClipboardHelper.m_systemCopyBufferProperty;
    }
    public static string get_clipBoard()
    {
        return UnityEngine.GUIUtility.systemCopyBuffer;
    }
    public static void set_clipBoard(string value)
    {
        UnityEngine.GUIUtility.systemCopyBuffer = value;
    }
    public ClipboardHelper()
    {
    
    }
    private static ClipboardHelper()
    {
    
    }

}
