using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class BugReportApiService : SRServiceBase<SRDebugger.Services.IBugReportService>, IBugReportService
    {
        // Fields
        public const float Timeout = 12;
        private SRDebugger.Services.BugReportCompleteCallback _completeCallback;
        private string _errorMessage;
        private bool _isBusy;
        private float _previousProgress;
        private SRDebugger.Services.BugReportProgressCallback _progressCallback;
        private SRDebugger.Internal.BugReportApi _reportApi;
        
        // Methods
        public void SendBugReport(SRDebugger.Services.BugReport report, SRDebugger.Services.BugReportCompleteCallback completeHandler, SRDebugger.Services.BugReportProgressCallback progressCallback)
        {
            string val_8;
            if(report == null)
            {
                goto label_1;
            }
            
            if(completeHandler == null)
            {
                goto label_2;
            }
            
            if(this._isBusy != false)
            {
                    label_7:
                completeHandler.Invoke(didSucceed:  false, errorMessage:  "BugReportApiService is already sending a bug report");
                return;
            }
            
            if(UnityEngine.Application.internetReachability == 0)
            {
                goto label_7;
            }
            
            this._errorMessage = "";
            this.enabled = true;
            this._isBusy = true;
            this._completeCallback = completeHandler;
            this._progressCallback = progressCallback;
            SRDebugger.Settings val_2 = SRDebugger.Settings.Instance;
            SRDebugger.Internal.BugReportApi val_3 = new SRDebugger.Internal.BugReportApi();
            ._apiKey = val_2._apiKey;
            ._bugReport = report;
            this._reportApi = val_3;
            UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  val_3.Submit());
            return;
            label_1:
            val_8 = "report";
            goto label_8;
            label_2:
            System.ArgumentNullException val_6 = null;
            val_8 = "completeHandler";
            label_8:
            val_6 = new System.ArgumentNullException(paramName:  val_8);
            throw val_6;
        }
        protected override void Awake()
        {
            this.Awake();
            this.CachedTransform.SetParent(p:  SRF.Hierarchy.Get(key:  "SRDebugger"));
        }
        private void OnProgress(float progress)
        {
            if(this._progressCallback == null)
            {
                    return;
            }
            
            this._progressCallback.Invoke(progress:  progress);
        }
        private void OnComplete()
        {
            string val_3;
            this._isBusy = false;
            this.enabled = false;
            if((System.String.IsNullOrEmpty(value:  this._reportApi.<ErrorMessage>k__BackingField)) == false)
            {
                goto label_1;
            }
            
            val_3 = this._errorMessage;
            if(this._completeCallback != null)
            {
                goto label_2;
            }
            
            label_1:
            val_3 = this._reportApi.<ErrorMessage>k__BackingField;
            label_2:
            this._completeCallback.Invoke(didSucceed:  ((this._reportApi.<WasSuccessful>k__BackingField) == true) ? 1 : 0, errorMessage:  mem[this._reportApi.<ErrorMessage>k__BackingField]);
            this._completeCallback = 0;
        }
        protected override void Update()
        {
            this.Update();
            if(this._isBusy == false)
            {
                    return;
            }
            
            if(this._reportApi != null)
            {
                    if((this._reportApi.<IsComplete>k__BackingField) != false)
            {
                    this.OnComplete();
                return;
            }
            
                if(this._previousProgress == this._reportApi.Progress)
            {
                    return;
            }
            
                if(this._progressCallback != null)
            {
                    this._progressCallback.Invoke(progress:  this._reportApi.Progress);
            }
            
                this._previousProgress = this._reportApi.Progress;
                return;
            }
            
            this._isBusy = false;
            throw new NullReferenceException();
        }
        public BugReportApiService()
        {
        
        }
    
    }

}
