using UnityEngine;
private sealed class WGGoldenMultiplierFlyout.<SetCompleteFlyoutPlacement>d__16 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGGoldenMultiplierFlyout <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGGoldenMultiplierFlyout.<SetCompleteFlyoutPlacement>d__16(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.RectTransform val_19;
        int val_20;
        if(((this.<>1__state) - 1) >= 2)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        val_19 = this.<>4__this.completeFlyout;
        if(val_19 == 0)
        {
            goto label_31;
        }
        
        val_19 = SLCWindowManager<WGWindowManager>.gameplayCamera;
        if(val_19 == 0)
        {
            goto label_31;
        }
        
        val_19 = this.<>4__this.uiButton;
        if(val_19 == 0)
        {
            goto label_31;
        }
        
        val_19 = this.<>4__this.canvasCamera;
        if(val_19 == 0)
        {
            goto label_31;
        }
        
        val_19 = this.<>4__this.gameObject;
        if((val_19 == 0) || ((this.<>4__this.gameObject.activeInHierarchy) == false))
        {
            goto label_31;
        }
        
        val_19 = SLCWindowManager<WGWindowManager>.gameplayCamera;
        UnityEngine.Rect val_12 = this.<>4__this.uiButton.rect;
        UnityEngine.Vector2 val_13 = val_12.m_XMin.center;
        UnityEngine.Vector3 val_14 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_13.x, y = val_13.y});
        UnityEngine.Vector3 val_15 = this.<>4__this.uiButton.TransformPoint(position:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
        UnityEngine.Vector3 val_16 = val_19.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z});
        UnityEngine.Vector3 val_17 = this.<>4__this.canvasCamera.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
        this.<>4__this.completeFlyout.position = new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z};
        this.<>2__current = 0;
        this.<>1__state = 2;
        val_20 = 1;
        return (bool)val_20;
        label_1:
        if((this.<>1__state) == 0)
        {
                this.<>1__state = 0;
            val_20 = 1;
            this.<>2__current = new UnityEngine.WaitForFixedUpdate();
            this.<>1__state = val_20;
            return (bool)val_20;
        }
        
        label_31:
        val_20 = 0;
        return (bool)val_20;
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
