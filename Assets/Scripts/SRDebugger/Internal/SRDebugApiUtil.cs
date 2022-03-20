using UnityEngine;

namespace SRDebugger.Internal
{
    public static class SRDebugApiUtil
    {
        // Methods
        public static string ParseErrorException(System.Net.WebException ex)
        {
            var val_5;
            var val_8;
            if(ex.m_Response != null)
            {
                    return (string)SRDebugger.Internal.SRDebugApiUtil.ParseErrorResponse(response:  SRDebugger.Internal.SRDebugApiUtil.ReadResponseStream(stream:  ex.m_Response), fallback:  "Unexpected Response");
            }
            
            val_8 = val_5;
            goto ??? + 384;
        }
        public static string ParseErrorResponse(string response, string fallback = "Unexpected Response")
        {
            var val_13;
            string val_14;
            var val_15;
            var val_16;
            string val_17;
            object val_1 = SRF.Json.Deserialize(json:  response);
            val_13 = val_1;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14 = "" + val_13.Item["errorMessage"];
            if(((val_13.TryGetValue(key:  "errors", value: out  0)) == false) || (X0 == false))
            {
                goto label_5;
            }
            
            if(X0 == false)
            {
                    throw new NullReferenceException();
            }
            
            val_15 = null;
            var val_18 = X0;
            if((X0 + 294) == 0)
            {
                goto label_7;
            }
            
            var val_16 = X0 + 176;
            var val_17 = 0;
            val_16 = val_16 + 8;
            label_9:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_8;
            }
            
            val_17 = val_17 + 1;
            val_16 = val_16 + 16;
            if(val_17 < (X0 + 294))
            {
                goto label_9;
            }
            
            label_7:
            val_15 = null;
            goto label_10;
            label_5:
            val_17 = val_14;
            return val_17;
            label_8:
            val_18 = val_18 + (((X0 + 176 + 8)) << 4);
            val_16 = val_18 + 304;
            label_10:
            val_13 = X0.GetEnumerator();
            val_17 = val_14;
            label_22:
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_19 = 0;
            val_19 = val_19 + 1;
            if(val_13.MoveNext() == false)
            {
                goto label_17;
            }
            
            var val_20 = 0;
            val_20 = val_20 + 1;
            string val_12 = val_17 + "\n"(val_17 + "\n") + val_13.Current;
            goto label_22;
            label_17:
            val_14 = 0;
            if(val_13 != null)
            {
                    var val_21 = 0;
                val_21 = val_21 + 1;
                val_13.Dispose();
            }
            
            if(val_14 != 0)
            {
                    throw val_14;
            }
            
            return val_17;
        }
        public static bool ReadResponse(System.Net.HttpWebRequest request, out string result)
        {
            result = SRDebugger.Internal.SRDebugApiUtil.ReadResponseStream(stream:  request);
            return true;
        }
        public static string ReadResponseStream(System.Net.WebResponse stream)
        {
            System.Net.WebResponse val_4 = stream;
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_4 = val_4;
            System.IO.StreamReader val_1 = new System.IO.StreamReader(stream:  val_4);
            var val_4 = 0;
            val_4 = val_4 + 1;
            val_1.Dispose();
            if(0 != 0)
            {
                    throw X22;
            }
            
            if(val_4 != null)
            {
                    var val_5 = 0;
                val_5 = val_5 + 1;
                val_4.Dispose();
            }
            
            if(0 != 0)
            {
                    throw X21;
            }
            
            return (string)val_1;
        }
    
    }

}
