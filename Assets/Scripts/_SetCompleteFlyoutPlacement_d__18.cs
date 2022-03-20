using UnityEngine;
private sealed class WGChallengeFlyout.<SetCompleteFlyoutPlacement>d__18 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGChallengeFlyout <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGChallengeFlyout.<SetCompleteFlyoutPlacement>d__18(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.RectTransform val_17;
        int val_18;
        if(((this.<>1__state) - 1) >= 2)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        val_17 = this.<>4__this.completeFlyout;
        if(val_17 == 0)
        {
            goto label_30;
        }
        
        val_17 = SLCWindowManager<WGWindowManager>.gameplayCamera;
        if(val_17 == 0)
        {
            goto label_30;
        }
        
        val_17 = this.<>4__this.uiButton;
        if(val_17 == 0)
        {
            goto label_30;
        }
        
        val_17 = this.<>4__this.canvasCamera;
        if(val_17 == 0)
        {
            goto label_30;
        }
        
        val_17 = this.<>4__this.gameObject;
        if((val_17 == 0) || ((this.<>4__this.gameObject.activeInHierarchy) == false))
        {
            goto label_30;
        }
        
        val_17 = SLCWindowManager<WGWindowManager>.gameplayCamera;
        UnityEngine.Vector3 val_13 = this.<>4__this.uiButton.transform.position;
        UnityEngine.Vector3 val_14 = val_17.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
        UnityEngine.Vector3 val_15 = this.<>4__this.canvasCamera.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
        this.<>4__this.completeFlyout.position = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
        this.<>2__current = 0;
        this.<>1__state = 2;
        val_18 = 1;
        return (bool)val_18;
        label_1:
        if((this.<>1__state) == 0)
        {
                this.<>1__state = 0;
            val_18 = 1;
            this.<>2__current = new UnityEngine.WaitForFixedUpdate();
            this.<>1__state = val_18;
            return (bool)val_18;
        }
        
        label_30:
        val_18 = 0;
        return (bool)val_18;
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
