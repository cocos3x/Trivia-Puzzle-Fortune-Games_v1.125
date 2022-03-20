using UnityEngine;

namespace Helpshift
{
    public class HelpshiftInternalLogger
    {
        // Fields
        private static string TAG;
        private static UnityEngine.AndroidJavaClass hsInternalLogger;
        
        // Methods
        public static void d(string message)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = Helpshift.HelpshiftInternalLogger.TAG;
            if(message != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = message;
            Helpshift.HelpshiftInternalLogger.hsInternalLogger.CallStatic(methodName:  "d", args:  val_1);
        }
        public static void e(string message)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = Helpshift.HelpshiftInternalLogger.TAG;
            if(message != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = message;
            Helpshift.HelpshiftInternalLogger.hsInternalLogger.CallStatic(methodName:  "e", args:  val_1);
        }
        public static void w(string message)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = Helpshift.HelpshiftInternalLogger.TAG;
            if(message != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = message;
            Helpshift.HelpshiftInternalLogger.hsInternalLogger.CallStatic(methodName:  "w", args:  val_1);
        }
        public static void f(string message)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = Helpshift.HelpshiftInternalLogger.TAG;
            if(message != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = message;
            Helpshift.HelpshiftInternalLogger.hsInternalLogger.CallStatic(methodName:  "f", args:  val_1);
        }
        public HelpshiftInternalLogger()
        {
        
        }
        private static HelpshiftInternalLogger()
        {
            Helpshift.HelpshiftInternalLogger.TAG = "HelpshiftUnityPlugin";
            Helpshift.HelpshiftInternalLogger.hsInternalLogger = new UnityEngine.AndroidJavaClass(className:  "com.helpshift.util.HSLogger");
        }
    
    }

}
