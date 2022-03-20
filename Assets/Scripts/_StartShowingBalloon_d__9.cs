using UnityEngine;
private sealed class PrizeBalloonUIController.<StartShowingBalloon>d__9 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PrizeBalloonUIController <>4__this;
    private float <step>5__2;
    private float <t>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PrizeBalloonUIController.<StartShowingBalloon>d__9(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_16;
        int val_17;
        float val_18;
        val_16 = this;
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
        UnityEngine.Vector3 val_2 = this.<>4__this.start.position;
        this.<>4__this.balloon.transform.position = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        val_17 = 1;
        this.<>4__this.balloon.gameObject.SetActive(value:  true);
        this.<>2__current = 0;
        this.<>1__state = val_17;
        return (bool)val_17;
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this) != null)
        {
            goto label_11;
        }
        
        label_2:
        this.<>1__state = 0;
        GameEcon val_5 = App.getGameEcon;
        this.<t>5__3 = 0f;
        float val_16 = (float)val_5.prize_balloon_econ.BalloonOnScreenInSec;
        val_16 = val_16 + 1f;
        val_16 = UnityEngine.Time.fixedDeltaTime / val_16;
        this.<step>5__2 = val_16;
        label_11:
        UnityEngine.Vector3 val_7 = this.<>4__this.balloon.transform.position;
        val_18 = val_7.x;
        UnityEngine.Vector3 val_8 = this.<>4__this.end.position;
        if(val_18 < 0)
        {
            goto label_21;
        }
        
        val_16 = this.<>4__this.balloon.transform;
        UnityEngine.Vector3 val_10 = this.<>4__this.end.position;
        val_16.position = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
        this.<>4__this.HideBalloon();
        label_3:
        val_17 = 0;
        return (bool)val_17;
        label_21:
        float val_17 = this.<step>5__2;
        val_17 = (this.<t>5__3) + val_17;
        this.<t>5__3 = val_17;
        UnityEngine.Vector3 val_12 = this.<>4__this.start.position;
        val_18 = val_12.x;
        UnityEngine.Vector3 val_13 = this.<>4__this.end.position;
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = val_18, y = val_12.y, z = val_12.z}, b:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, t:  this.<t>5__3);
        this.<>4__this.balloon.transform.position = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
        this.<>2__current = new UnityEngine.WaitForFixedUpdate();
        this.<>1__state = 2;
        val_17 = 1;
        return (bool)val_17;
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
