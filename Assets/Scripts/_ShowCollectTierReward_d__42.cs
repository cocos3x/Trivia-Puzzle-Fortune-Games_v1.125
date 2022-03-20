using UnityEngine;
private sealed class WGInviteV2.<ShowCollectTierReward>d__42 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGInviteV2 <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGInviteV2.<ShowCollectTierReward>d__42(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_25;
        object val_26;
        System.Collections.Generic.List<UnityEngine.GameObject> val_27;
        if((this.<>1__state) > 3)
        {
            goto label_1;
        }
        
        var val_25 = 32496540 + (this.<>1__state) << 2;
        val_25 = val_25 + 32496540;
        goto (32496540 + (this.<>1__state) << 2 + 32496540);
        label_14:
        var val_4 =  - 4;
        if(val_4 >= )
        {
            goto label_9;
        }
        
        if( <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((1152921517887012400 + (val_2) << 3) + 32 + 24) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        (1152921517887012400 + (val_2) << 3) + 32.texture = (1152921517887012400 + (val_2) << 3) + 32 + 16 + 32;
         =  + 1;
        if((this.<>4__this.chestImages) != null)
        {
            goto label_14;
        }
        
        this.<>1__state = 0;
        this.<>4__this.closedChest.SetActive(value:  false);
        val_25 = 1;
        this.<>4__this.openedChest.SetActive(value:  true);
        UnityEngine.WaitForSeconds val_5 = null;
        val_26 = val_5;
        val_5 = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>2__current = val_26;
        this.<>1__state = 2;
        return (bool)val_25;
        label_1:
        val_25 = 0;
        return (bool)val_25;
        label_9:
        val_27 = this.<>4__this.progressChestGO;
        if( <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_27 = this.<>4__this.progressChestGO;
        }
        
         =  + (((long)(int)(val_2)) << 3);
        if(32496540 <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
         =  + (((long)(int)(val_2)) << 3);
        (((1152921517887012400 + (val_2) << 3) + ((long)(int)(val_2)) << 3) + ((long)(int)(val_2)) << 3) + 32.SetActive(value:  false);
        this.<>4__this.chestGO.SetActive(value:  true);
        this.<>4__this.closedChest.SetActive(value:  true);
        this.<>4__this.openedChest.SetActive(value:  false);
        UnityEngine.Vector3 val_15 = ((1152921517887012400 + (val_2) << 3) + ((long)(int)(val_2)) << 3) + 32.transform.position;
        this.<>4__this.chestGO.transform.position = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
        UnityEngine.Vector3 val_17 = new UnityEngine.Vector3(x:  0.25f, y:  0.25f);
        this.<>4__this.chestGO.transform.localScale = new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z};
        val_26 = this.<>4__this.chestGO.transform;
        UnityEngine.Vector3 val_19 = UnityEngine.Vector3.one;
        DG.Tweening.Tweener val_20 = DG.Tweening.ShortcutExtensions.DOScale(target:  val_26, endValue:  new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z}, duration:  1f);
        UnityEngine.Vector3 val_22 = UnityEngine.Vector3.zero;
        DG.Tweening.Tweener val_23 = DG.Tweening.ShortcutExtensions.DOLocalMove(target:  this.<>4__this.chestGO.transform, endValue:  new UnityEngine.Vector3() {x = val_22.x, y = val_22.y, z = val_22.z}, duration:  1f, snapping:  false);
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        val_25 = 1;
        this.<>1__state = val_25;
        return (bool)val_25;
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
