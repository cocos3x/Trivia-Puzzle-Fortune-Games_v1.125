using UnityEngine;
private sealed class WordLadderUIController.<MoveArrow>d__24 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.Ladder.WordLadderUIController <>4__this;
    public float x;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordLadderUIController.<MoveArrow>d__24(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_10;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>4__this.Arrow.gameObject.SetActive(value:  true);
        goto label_6;
        label_1:
        this.<>1__state = 0;
        UnityEngine.Vector3 val_2 = this.<>4__this.Arrow.position;
        UnityEngine.Vector3 val_4 = this.<>4__this.Arrow.position;
        UnityEngine.Vector3 val_5 = this.<>4__this.Arrow.position;
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  UnityEngine.Mathf.Lerp(a:  val_2.x, b:  this.x, t:  0.3f), y:  val_4.y, z:  val_5.z);
        this.<>4__this.Arrow.position = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        label_6:
        UnityEngine.Vector3 val_7 = this.<>4__this.Arrow.position;
        if((val_7.x ?? this.x) > 0.01f)
        {
            goto label_16;
        }
        
        label_2:
        val_10 = 0;
        return (bool)val_10;
        label_16:
        val_10 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_10;
        return (bool)val_10;
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
