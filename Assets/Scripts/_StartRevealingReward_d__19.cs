using UnityEngine;
private sealed class GiftRewardUI.<StartRevealingReward>d__19 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public GiftRewardUI <>4__this;
    public GiftRewardRevealInfo reward;
    public System.Action onAllRewardsRevealed;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public GiftRewardUI.<StartRevealingReward>d__19(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_4;
        var val_5;
        var val_16;
        object val_17;
        int val_18;
        UnityEngine.GameObject val_19;
        UnityEngine.UI.Button val_20;
        float val_21;
        var val_22;
        val_16 = 0;
        if((this.<>1__state) > 4)
        {
                return (bool)val_22;
        }
        
        var val_15 = 32562116;
        val_15 = (32562116 + (this.<>1__state) << 2) + val_15;
        goto (32562116 + (this.<>1__state) << 2 + 32562116);
        label_16:
        if(val_5.MoveNext() == false)
        {
            goto label_14;
        }
        
        val_4.SetActive(value:  false);
        goto label_16;
        label_14:
        val_19 = public System.Void List.Enumerator<UnityEngine.GameObject>::Dispose();
        val_5.Dispose();
        val_20 = this.<>4__this.revealedRewardObjects;
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = public System.Void System.Collections.Generic.List<UnityEngine.GameObject>::Clear();
        val_20.Clear();
        val_20 = this.<>4__this.revealedRewardObjects;
        if(this.reward == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = this.reward.rewardObject;
        val_20.Add(item:  val_19);
        if((this.<>4__this.rewardsToReveal) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.revealedRewardObjects) == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = this.<>4__this.upperLayout;
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_9 = val_20.transform;
        if(((this.<>4__this.rewardsToReveal) + (this.<>4__this.revealedRewardObjects)) < (this.<>4__this.maxRevealedRewards))
        {
                val_21 = 1.1f;
        }
        else
        {
                val_21 = 0.9f;
        }
        
        val_5 = 0;
        val_19 = 0;
        UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  val_21, y:  val_21, z:  1f);
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = val_9;
        val_19 = 0;
        val_20.localScale = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
        if(this.reward == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = this.reward.rewardObject;
        val_19 = 0;
        if(val_20 != val_19)
        {
                if(this.reward == null)
        {
                throw new NullReferenceException();
        }
        
            val_19 = 0;
            DG.Tweening.Tweener val_13 = DG.Tweening.ShortcutExtensions46.DOFade(target:  MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.reward.rewardObject), endValue:  1f, duration:  0.3f);
        }
        
        if(this.reward == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.reward.rewardAction != null)
        {
                this.reward.rewardAction.Invoke();
        }
        
        UnityEngine.WaitForSeconds val_14 = null;
        val_17 = val_14;
        val_14 = new UnityEngine.WaitForSeconds(seconds:  1f);
        val_18 = 1;
        val_22 = 1;
        this.<>2__current = val_17;
        this.<>1__state = val_18;
        return (bool)val_22;
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
