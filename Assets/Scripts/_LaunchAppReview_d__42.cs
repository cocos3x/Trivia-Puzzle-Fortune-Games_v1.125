using UnityEngine;
private sealed class WGReviewManager.<LaunchAppReview>d__42 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGReviewManager <>4__this;
    private Google.Play.Common.PlayAsyncOperation<Google.Play.Common.VoidResult, Google.Play.Review.ReviewErrorCode> <launchFlowOperation>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGReviewManager.<LaunchAppReview>d__42(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_6;
        int val_7;
        val_6 = this;
        if((this.<>1__state) != 1)
        {
                val_7 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_7;
        }
        
            this.<>1__state = 0;
            Google.Play.Common.PlayAsyncOperation<Google.Play.Common.VoidResult, Google.Play.Review.ReviewErrorCode> val_1 = this.<>4__this.reviewManager.LaunchReviewFlow(reviewInfo:  this.<>4__this._playReviewInfo);
            this.<launchFlowOperation>5__2 = val_1;
            this.<>2__current = val_1;
            val_7 = 1;
            this.<>1__state = val_7;
            return (bool)val_7;
        }
        
        this.<>1__state = 0;
        this.<>4__this._playReviewInfo = 0;
        if((this.<launchFlowOperation>5__2) != null)
        {
                AppConfigs val_2 = App.Configuration;
            twelvegigs.plugins.SharePlugin.OpenURL(url:  val_2.appConfig.Key(key:  "marketUrl"));
            val_6 = "WGReviewManager LaunchAppReview " + this.<launchFlowOperation>5__2.ToString()(this.<launchFlowOperation>5__2.ToString());
            UnityEngine.Debug.LogError(message:  val_6);
        }
        else
        {
                UnityEngine.PlayerPrefs.SetInt(key:  "google_api_review_pref", value:  1);
        }
        
        val_7 = 0;
        return (bool)val_7;
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
