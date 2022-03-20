using UnityEngine;
public static class UnityLoggerListener
{
    // Fields
    private const int MAX_LOGS = 10;
    private static readonly object _threadLock;
    public static SRDebugger.CircularBuffer<string> _allConsoleEntries;
    
    // Methods
    private static void RegisterForLogs()
    {
        var val_5;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        val_5 = null;
        val_5 = null;
        UnityLoggerListener._allConsoleEntries = new SRDebugger.CircularBuffer<System.String>(capacity:  10);
        UnityEngine.Application.add_logMessageReceivedThreaded(value:  new Application.LogCallback(object:  0, method:  static System.Void UnityLoggerListener::UnityLogCallback(string condition, string stackTrace, UnityEngine.LogType type)));
    }
    private static void UnityLogCallback(string condition, string stackTrace, UnityEngine.LogType type)
    {
        object val_8;
        var val_9;
        object val_10;
        SRDebugger.CircularBuffer<System.String> val_11;
        var val_12;
        string val_13;
        SRDebugger.CircularBuffer<System.String> val_14;
        var val_15;
        var val_16;
        var val_17;
        val_8 = type;
        if((val_8 & 4294967294) == 2)
        {
                return;
        }
        
        val_9 = null;
        val_9 = null;
        val_8 = UnityLoggerListener._threadLock;
        bool val_2 = false;
        System.Threading.Monitor.Enter(obj:  val_8, lockTaken: ref  val_2);
        val_10 = condition;
        val_12 = null;
        val_13 = System.String.Format(format:  "{0}\n{1}\n\n", arg0:  val_10, arg1:  stackTrace);
        val_12 = null;
        val_14 = UnityLoggerListener._allConsoleEntries;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        if((UnityLoggerListener._allConsoleEntries + 28) <= 0)
        {
            goto label_7;
        }
        
        val_14 = UnityLoggerListener._allConsoleEntries;
        string val_5 = val_14.Item[(UnityLoggerListener._allConsoleEntries + 28) - 1];
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        label_25:
        val_10 = val_13;
        if((val_5.Equals(value:  val_10)) != true)
        {
                val_15 = null;
            val_15 = null;
            val_11 = UnityLoggerListener._allConsoleEntries;
            if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
            val_10 = public System.Boolean SRDebugger.CircularBuffer<System.String>::get_IsFull();
            if(val_11.IsFull != false)
        {
                val_16 = null;
            val_16 = null;
            val_11 = UnityLoggerListener._allConsoleEntries;
            if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
            val_10 = public System.Void SRDebugger.CircularBuffer<System.String>::PopFront();
            val_11.PopFront();
        }
        
            val_17 = null;
            val_17 = null;
            val_11 = UnityLoggerListener._allConsoleEntries;
            if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
            val_11.PushBack(item:  val_13);
        }
        
        val_13 = 0;
        if(val_2 != 0)
        {
                System.Threading.Monitor.Exit(obj:  val_8);
        }
        
        if(val_13 != 0)
        {
            goto label_24;
        }
        
        return;
        label_7:
        if("" != null)
        {
            goto label_25;
        }
        
        throw new NullReferenceException();
        label_24:
        val_11 = val_13;
        val_10 = 0;
        throw val_11;
    }
    private static UnityLoggerListener()
    {
        UnityLoggerListener._threadLock = new System.Object();
    }

}
