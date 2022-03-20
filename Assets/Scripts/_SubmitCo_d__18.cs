using UnityEngine;
private sealed class BugReportSheetController.<SubmitCo>d__18 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SRDebugger.UI.Other.BugReportSheetController <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public BugReportSheetController.<SubmitCo>d__18(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        SRDebugger.UI.Other.BugReportSheetController val_14;
        int val_15;
        var val_16;
        val_14 = this.<>4__this;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        if(SRDebugger.Internal.BugReportScreenshotUtil.ScreenshotData != null)
        {
            goto label_9;
        }
        
        if((this.<>4__this.TakingScreenshot) != null)
        {
                this.<>4__this.TakingScreenshot.Invoke();
        }
        
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_14 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_15 = 1;
        this.<>2__current = val_14;
        this.<>1__state = val_15;
        return (bool)val_15;
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this.ScreenshotComplete) != null)
        {
                this.<>4__this.ScreenshotComplete.Invoke();
        }
        
        label_9:
        .Email = this.<>4__this.EmailField.m_Text;
        .UserDescription = this.<>4__this.DescriptionField.m_Text;
        var val_16 = 0;
        val_16 = val_16 + 1;
        val_16 = 4;
        goto label_20;
        label_2:
        this.<>1__state = 0;
        this.<>2__current = val_14.StartCoroutine(routine:  SRDebugger.Internal.BugReportScreenshotUtil.ScreenshotCaptureCo());
        this.<>1__state = 2;
        val_15 = 1;
        return (bool)val_15;
        label_20:
        .ConsoleLog = System.Linq.Enumerable.ToList<SRDebugger.Services.ConsoleEntry>(source:  SRDebugger.Internal.Service.Console.AllEntries);
        var val_17 = 0;
        val_17 = val_17 + 1;
        val_16 = 3;
        .SystemInformation = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.ISystemInformationService>().CreateReport(includePrivate:  false);
        .ScreenshotData = SRDebugger.Internal.BugReportScreenshotUtil.ScreenshotData;
        SRDebugger.Internal.BugReportScreenshotUtil.ScreenshotData = 0;
        var val_18 = 0;
        val_18 = val_18 + 1;
        SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IBugReportService>().SendBugReport(report:  new SRDebugger.Services.BugReport(), completeHandler:  new SRDebugger.Services.BugReportCompleteCallback(object:  val_14, method:  System.Void SRDebugger.UI.Other.BugReportSheetController::OnBugReportComplete(bool didSucceed, string errorMessage)), progressCallback:  new SRDebugger.Services.BugReportProgressCallback(object:  val_14, method:  System.Void SRDebugger.UI.Other.BugReportSheetController::OnBugReportProgress(float progress)));
        label_3:
        val_15 = 0;
        return (bool)val_15;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
