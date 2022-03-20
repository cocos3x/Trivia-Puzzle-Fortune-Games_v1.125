using UnityEngine;
public static class SLCDebug
{
    // Fields
    private static int maxLength;
    private static string logs;
    private static bool errorOccurred;
    
    // Methods
    public static string GetLogs()
    {
        null = null;
        return (string)SLCDebug.logs;
    }
    public static void Log(string logMessage, string colorHash = "#FFFFFF", bool isError = False)
    {
        string val_7;
        var val_8;
        var val_9;
        string val_11;
        val_7 = isError;
        val_8 = null;
        val_8 = null;
        if(SLCDebug.errorOccurred == true)
        {
                return;
        }
        
        if(val_7 != false)
        {
                val_8 = null;
            val_9 = 1152921504893485072;
            SLCDebug.errorOccurred = true;
        }
        
        val_8 = null;
        val_7 = SLCDebug.logs;
        SLCDebug.logs = val_7 + System.String.Format(format:  "{0}s: <color={1}>{2}</color>\n", arg0:  UnityEngine.Time.time.ToString(format:  "0000.00"), arg1:  colorHash, arg2:  logMessage)(System.String.Format(format:  "{0}s: <color={1}>{2}</color>\n", arg0:  UnityEngine.Time.time.ToString(format:  "0000.00"), arg1:  colorHash, arg2:  logMessage));
        val_11 = SLCDebug.logs;
        if(val_4.m_stringLength <= SLCDebug.maxLength)
        {
                return;
        }
        
        val_11 = SLCDebug.logs;
        SLCDebug.logs = val_11.Substring(startIndex:  (val_4.m_stringLength - SLCDebug.maxLength)>>0&0xFFFFFFFF);
    }
    private static SLCDebug()
    {
        SLCDebug.maxLength = 10000;
        SLCDebug.logs = "";
        SLCDebug.errorOccurred = false;
    }

}
