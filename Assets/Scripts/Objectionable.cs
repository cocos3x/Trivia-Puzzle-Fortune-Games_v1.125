using UnityEngine;
public class Objectionable
{
    // Fields
    private static bool initialized;
    private static string[] objectionables;
    
    // Methods
    public static bool Valid(string words)
    {
        var val_3;
        var val_4;
        System.String[] val_5;
        var val_6;
        val_3 = null;
        val_3 = null;
        if(Objectionable.initialized != true)
        {
                Objectionable.initialize();
        }
        
        var val_3 = 0;
        label_16:
        val_4 = null;
        val_4 = null;
        val_5 = Objectionable.objectionables;
        if(val_3 >= Objectionable.objectionables.Length)
        {
            goto label_9;
        }
        
        val_5 = Objectionable.objectionables;
        val_3 = val_3 + 1;
        if((words.Contains(value:  Objectionable.objectionables + 32.ToLower())) == false)
        {
            goto label_16;
        }
        
        val_6 = 0;
        return (bool)val_6;
        label_9:
        val_6 = 1;
        return (bool)val_6;
    }
    public static string FoundObjectionable(string words)
    {
        var val_3;
        var val_4;
        System.String[] val_5;
        string val_6;
        val_3 = null;
        val_3 = null;
        if(Objectionable.initialized != true)
        {
                Objectionable.initialize();
        }
        
        var val_3 = 0;
        label_16:
        val_4 = null;
        val_4 = null;
        val_5 = Objectionable.objectionables;
        if(val_3 >= Objectionable.objectionables.Length)
        {
            goto label_9;
        }
        
        val_5 = Objectionable.objectionables;
        val_6 = Objectionable.objectionables + 32.ToLower();
        val_3 = val_3 + 1;
        if((words.Contains(value:  val_6)) == false)
        {
            goto label_16;
        }
        
        return (string)val_6;
        label_9:
        val_6 = System.String.alignConst;
        return (string)val_6;
    }
    private static void initialize()
    {
        System.String[] val_7;
        var val_8;
        var val_9;
        char[] val_4 = new char[1];
        val_4[0] = '
        ';
        val_7 = UnityEngine.Resources.Load(path:  "data/objectionables", systemTypeInstance:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle())).text.Split(separator:  val_4);
        val_8 = null;
        val_8 = null;
        Objectionable.objectionables = val_7;
        val_9 = 0;
        goto label_11;
        label_24:
        val_7 = System.Text.RegularExpressions.Regex.Replace(input:  X26 + 32, pattern:  "[^a-zA-Z0-9]", replacement:  "");
        mem2[0] = val_7;
        val_8 = null;
        val_9 = 1;
        label_11:
        val_8 = null;
        if(val_9 < val_5.Length)
        {
            goto label_24;
        }
        
        Objectionable.initialized = true;
    }
    public Objectionable()
    {
    
    }
    private static Objectionable()
    {
    
    }

}
