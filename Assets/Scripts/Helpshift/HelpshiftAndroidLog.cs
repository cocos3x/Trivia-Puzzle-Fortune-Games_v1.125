using UnityEngine;

namespace Helpshift
{
    public class HelpshiftAndroidLog
    {
        // Fields
        private static UnityEngine.AndroidJavaClass logger;
        
        // Methods
        private HelpshiftAndroidLog()
        {
        
        }
        public static int v(string tag, string log)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = tag;
            if(log != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = log;
            return Helpshift.HelpshiftAndroidLog.logger.CallStatic<System.Int32>(methodName:  "v", args:  val_1);
        }
        public static int d(string tag, string log)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = tag;
            if(log != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = log;
            return Helpshift.HelpshiftAndroidLog.logger.CallStatic<System.Int32>(methodName:  "d", args:  val_1);
        }
        public static int i(string tag, string log)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = tag;
            if(log != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = log;
            return Helpshift.HelpshiftAndroidLog.logger.CallStatic<System.Int32>(methodName:  "i", args:  val_1);
        }
        public static int w(string tag, string log)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = tag;
            if(log != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = log;
            return Helpshift.HelpshiftAndroidLog.logger.CallStatic<System.Int32>(methodName:  "w", args:  val_1);
        }
        public static int e(string tag, string log)
        {
            var val_2;
            int val_3;
            val_2 = null;
            val_2 = null;
            object[] val_1 = new object[2];
            val_3 = val_1.Length;
            val_1[0] = tag;
            if(log != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = log;
            return Helpshift.HelpshiftAndroidLog.logger.CallStatic<System.Int32>(methodName:  "e", args:  val_1);
        }
        private static HelpshiftAndroidLog()
        {
            Helpshift.HelpshiftAndroidLog.logger = new UnityEngine.AndroidJavaClass(className:  "com.helpshift.support.Log");
        }
    
    }

}
