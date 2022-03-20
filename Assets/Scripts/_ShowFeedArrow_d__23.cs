using UnityEngine;
private sealed class WADPetProfile.<ShowFeedArrow>d__23 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WADPetProfile <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WADPetProfile.<ShowFeedArrow>d__23(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_12;
        int val_13;
        var val_14;
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
        UnityEngine.Vector3 val_3 = this.<>4__this.feedButton.transform.position;
        this.<>4__this.feedArrow.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  0f, y:  110f, z:  0f);
        this.<>4__this.feedArrow.transform.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        this.<>4__this.feedArrow.gameObject.SetActive(value:  true);
        goto label_13;
        label_1:
        this.<>1__state = 0;
        label_13:
        UnityEngine.WaitForEndOfFrame val_7 = null;
        val_12 = val_7;
        val_7 = new UnityEngine.WaitForEndOfFrame();
        val_13 = 1;
        goto label_14;
        label_2:
        this.<>1__state = 0;
        UnityEngine.Vector3 val_9 = this.<>4__this.feedButton.transform.position;
        this.<>4__this.feedArrowSequence = DG.Tweening.ShortcutExtensions.DOJump(target:  this.<>4__this.feedArrow, endValue:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, jumpPower:  0.2f, numJumps:  32, duration:  30000f, snapping:  false);
        UnityEngine.WaitForSeconds val_11 = null;
        val_12 = val_11;
        val_11 = new UnityEngine.WaitForSeconds(seconds:  30000f);
        val_13 = 2;
        label_14:
        val_14 = 1;
        this.<>2__current = val_12;
        this.<>1__state = val_13;
        return (bool)val_14;
        label_3:
        val_14 = 0;
        return (bool)val_14;
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
