using UnityEngine;
private sealed class BugReportPopoverService.<OpenCo>d__7 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public bool takeScreenshot;
    public SRDebugger.Services.Implementation.BugReportPopoverService <>4__this;
    public string descriptionText;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public BugReportPopoverService.<OpenCo>d__7(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_6;
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
            goto label_11;
        }
        
        this.<>1__state = 0;
        if(this.takeScreenshot == false)
        {
            goto label_4;
        }
        
        val_6 = 1;
        this.<>2__current = this.<>4__this.StartCoroutine(routine:  SRDebugger.Internal.BugReportScreenshotUtil.ScreenshotCaptureCo());
        this.<>1__state = val_6;
        return (bool)val_6;
        label_2:
        this.<>1__state = 0;
        label_4:
        val_6 = 1;
        this.<>4__this._popover.CachedGameObject.SetActive(value:  true);
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = 2;
        return (bool)val_6;
        label_1:
        this.<>1__state = 0;
        if((System.String.IsNullOrEmpty(value:  this.descriptionText)) != true)
        {
                this.<>4__this._sheet.DescriptionField.text = this.descriptionText;
        }
        
        label_11:
        val_6 = 0;
        return (bool)val_6;
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
