using UnityEngine;

namespace SRDebugger.Internal
{
    public class BugReportApi
    {
        // Fields
        private readonly string _apiKey;
        private readonly SRDebugger.Services.BugReport _bugReport;
        private bool _isBusy;
        private UnityEngine.WWW _www;
        private bool <IsComplete>k__BackingField;
        private bool <WasSuccessful>k__BackingField;
        private string <ErrorMessage>k__BackingField;
        
        // Properties
        public bool IsComplete { get; set; }
        public bool WasSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public float Progress { get; }
        
        // Methods
        public BugReportApi(SRDebugger.Services.BugReport report, string apiKey)
        {
            val_1 = new System.Object();
            this._apiKey = val_1;
            this._bugReport = report;
        }
        public bool get_IsComplete()
        {
            return (bool)this.<IsComplete>k__BackingField;
        }
        private void set_IsComplete(bool value)
        {
            this.<IsComplete>k__BackingField = value;
        }
        public bool get_WasSuccessful()
        {
            return (bool)this.<WasSuccessful>k__BackingField;
        }
        private void set_WasSuccessful(bool value)
        {
            this.<WasSuccessful>k__BackingField = value;
        }
        public string get_ErrorMessage()
        {
            return (string)this.<ErrorMessage>k__BackingField;
        }
        private void set_ErrorMessage(string value)
        {
            this.<ErrorMessage>k__BackingField = value;
        }
        public float get_Progress()
        {
            if(this._www == null)
            {
                    return 0f;
            }
            
            float val_2 = this._www.uploadProgress;
            val_2 = this._www.progress + val_2;
            return UnityEngine.Mathf.Clamp01(value:  val_2);
        }
        public System.Collections.IEnumerator Submit()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new BugReportApi.<Submit>d__19();
        }
        private void SetCompletionState(bool wasSuccessful)
        {
            this._bugReport.ScreenshotData = 0;
            this.<WasSuccessful>k__BackingField = wasSuccessful;
            this.<IsComplete>k__BackingField = true;
            this._isBusy = false;
            if(wasSuccessful != false)
            {
                    return;
            }
            
            UnityEngine.Debug.LogError(message:  "Bug Reporter Error: "("Bug Reporter Error: ") + this.<ErrorMessage>k__BackingField(this.<ErrorMessage>k__BackingField));
        }
        private static string BuildJsonRequest(SRDebugger.Services.BugReport report)
        {
            System.Collections.Generic.IList<System.Collections.Generic.IList<System.String>> val_2 = SRDebugger.Internal.BugReportApi.CreateConsoleDump();
            if(report.ScreenshotData == null)
            {
                    return SRF.Json.Serialize(obj:  new System.Collections.Hashtable());
            }
            
            string val_3 = System.Convert.ToBase64String(inArray:  report.ScreenshotData);
            return SRF.Json.Serialize(obj:  new System.Collections.Hashtable());
        }
        private static System.Collections.Generic.IList<System.Collections.Generic.IList<string>> CreateConsoleDump()
        {
            var val_12;
            System.Collections.Generic.IList<System.String> val_17;
            System.Collections.Generic.List<System.Collections.Generic.IList<System.String>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.IList<System.String>>();
            SRDebugger.Services.IConsoleService val_2 = SRDebugger.Internal.Service.Console;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_12 = val_2;
            var val_16 = 0;
            val_16 = val_16 + 1;
            SRDebugger.IReadOnlyList<SRDebugger.Services.ConsoleEntry> val_4 = val_12.Entries;
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_17 = 0;
            val_17 = val_17 + 1;
            val_12 = val_4.GetEnumerator();
            label_26:
            var val_18 = 0;
            val_18 = val_18 + 1;
            if(val_12.MoveNext() == false)
            {
                goto label_16;
            }
            
            var val_19 = 0;
            val_19 = val_19 + 1;
            T val_10 = val_12.Current;
            System.Collections.Generic.List<System.String> val_11 = null;
            val_17 = val_11;
            val_11 = new System.Collections.Generic.List<System.String>();
            if(val_10 == 0)
            {
                    throw new NullReferenceException();
            }
            
            T val_12 = val_10 + 36;
            if(val_12 == 0)
            {
                    throw new NullReferenceException();
            }
            
            mem2[0] = val_12;
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_11.Add(item:  val_12.ToString());
            val_11.Add(item:  val_10 + 40);
            val_11.Add(item:  val_10 + 48);
            if((val_10 + 32) >= 2)
            {
                    val_11.Add(item:  val_10 + 32.ToString());
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_11);
            goto label_26;
            label_16:
            val_17 = 0;
            if(val_12 != null)
            {
                    var val_20 = 0;
                val_20 = val_20 + 1;
                val_12.Dispose();
            }
            
            if(val_17 != 0)
            {
                    throw val_17;
            }
            
            return (System.Collections.Generic.IList<System.Collections.Generic.IList<System.String>>)val_1;
        }
    
    }

}
