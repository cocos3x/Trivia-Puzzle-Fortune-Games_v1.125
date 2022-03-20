using UnityEngine;
private sealed class WGReviewManager.<InitReviewManager>d__41 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGReviewManager <>4__this;
    private Google.Play.Common.PlayAsyncOperation<Google.Play.Review.PlayReviewInfo, Google.Play.Review.ReviewErrorCode> <requestFlowOperation>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGReviewManager.<InitReviewManager>d__41(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_5;
        bool val_6;
        val_5 = this;
        if((this.<>1__state) != 1)
        {
                val_6 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_6;
        }
        
            this.<>1__state = 0;
            val_6 = true;
            this.<>4__this.initializingRManager = val_6;
            Google.Play.Common.PlayAsyncOperation<Google.Play.Review.PlayReviewInfo, Google.Play.Review.ReviewErrorCode> val_1 = this.<>4__this.reviewManager.RequestReviewFlow();
            this.<requestFlowOperation>5__2 = val_1;
            this.<>2__current = val_1;
            this.<>1__state = val_6;
            return (bool)val_6;
        }
        
        this.<>1__state = 0;
        if(0 != 0)
        {
                val_5 = "WGReviewManager InitReviewManager " + 0.ToString();
            UnityEngine.Debug.LogError(message:  val_5);
            val_6 = 0;
        }
        else
        {
                val_6 = 0;
            this.<>4__this._playReviewInfo = this.<requestFlowOperation>5__2.GetResult();
        }
        
        this.<>4__this.initializingRManager = false;
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
