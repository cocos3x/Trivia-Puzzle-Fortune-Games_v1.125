using UnityEngine;
private sealed class FlyKeyBoardLetter.<FlyTo>d__3 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.Ladder.FlyKeyBoardLetter <>4__this;
    public UnityEngine.Vector3 posStop;
    public System.Action callback;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public FlyKeyBoardLetter.<FlyTo>d__3(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.Vector3 val_10;
        float val_12;
        int val_13;
        if((this.<>1__state) >= 2)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        UnityEngine.Vector3 val_2 = this.<>4__this.transform.position;
        val_10 = this.posStop;
        val_12 = UnityEngine.Vector3.Distance(a:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, b:  new UnityEngine.Vector3() {x = val_10, y = V11.16B, z = V10.16B});
        UnityEngine.GameObject val_4 = this.<>4__this.gameObject;
        if((double)val_12 > 0.01)
        {
            goto label_7;
        }
        
        val_4.SetActive(value:  false);
        this.callback.Invoke();
        label_1:
        val_13 = 0;
        return (bool)val_13;
        label_7:
        UnityEngine.Vector3 val_7 = this.<>4__this.transform.position;
        val_10 = this.posStop;
        val_12 = val_7.x;
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = val_12, y = val_7.y, z = val_7.z}, b:  new UnityEngine.Vector3() {x = val_10, y = V11.16B, z = V10.16B}, t:  0.4f);
        val_4.transform.position = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        val_13 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_13;
        return (bool)val_13;
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
