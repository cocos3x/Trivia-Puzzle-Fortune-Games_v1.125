using UnityEngine;
private sealed class TRVLevelComplete.<SetupReward>d__97 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVLevelComplete <>4__this;
    public TRVLevelReward reward;
    public UnityEngine.Transform parent;
    public bool anim;
    private TRVLevelCompleteReward <lcr>5__2;
    private UnityEngine.Vector3 <targetStatView>5__3;
    private CurrencyParticles <newCps>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVLevelComplete.<SetupReward>d__97(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        System.Collections.Generic.Dictionary<System.String, TRVLevelCompleteReward> val_13;
        UnityEngine.Transform val_14;
        CoinCurrencyParticles val_15;
        int val_16;
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
            goto label_8;
        }
        
        this.<>1__state = 0;
        val_13 = this.<>4__this.spawnedRewards;
        if(val_13 == null)
        {
                System.Collections.Generic.Dictionary<System.String, TRVLevelCompleteReward> val_1 = null;
            val_13 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, TRVLevelCompleteReward>();
            this.<>4__this.spawnedRewards = val_13;
        }
        
        if((val_1.ContainsKey(key:  this.reward.<desc>k__BackingField)) == true)
        {
            goto label_8;
        }
        
        val_14 = this.parent;
        TRVLevelCompleteReward val_3 = UnityEngine.Object.Instantiate<TRVLevelCompleteReward>(original:  this.<>4__this.levelCompleteRewardPrefab, parent:  val_14);
        this.<lcr>5__2 = val_3;
        val_3.Init(myRew:  this.reward);
        if(this.anim == false)
        {
            goto label_12;
        }
        
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.zero;
        this.<targetStatView>5__3 = val_4;
        mem[1152921517289706844] = val_4.y;
        mem[1152921517289706848] = val_4.z;
        if((this.reward.<rewardType>k__BackingField) == 2)
        {
            goto label_16;
        }
        
        if((this.reward.<rewardType>k__BackingField) == 1)
        {
            goto label_17;
        }
        
        if((this.reward.<rewardType>k__BackingField) != 0)
        {
            goto label_18;
        }
        
        val_15 = this.<>4__this.ccp;
        goto label_35;
        label_1:
        this.<>1__state = 0;
        int val_13 = this.reward.<value>k__BackingField;
        val_13 = val_13 * 1717986919;
        val_13 = val_13 >> 34;
        this.<newCps>5__4.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = this.<targetStatView>5__3}, particleCount:  val_13 + (val_13 >> 63), animateStatView:  true);
        mem[1152921517289706848] = 0;
        this.<targetStatView>5__3 = 0;
        this.<newCps>5__4 = 0;
        label_12:
        this.<>4__this.spawnedRewards.Add(key:  this.reward.<desc>k__BackingField, value:  this.<lcr>5__2);
        label_8:
        val_16 = 0;
        return (bool)val_16;
        label_2:
        this.<>1__state = 0;
        this.<newCps>5__4.SetOrigin(originObject:  this.<lcr>5__2.rewardCurrencyImage.transform.gameObject);
        this.<>2__current = 0;
        this.<>1__state = 2;
        val_16 = 1;
        return (bool)val_16;
        label_16:
        val_15 = this.<>4__this.gp;
        goto label_35;
        label_17:
        val_15 = this.<>4__this.sp;
        label_35:
        UnityEngine.Vector3 val_10 = this.<>4__this.starStatView.text.transform.position;
        this.<targetStatView>5__3 = val_10;
        mem[1152921517289706844] = val_10.y;
        mem[1152921517289706848] = val_10.z;
        goto label_39;
        label_18:
        val_15 = 0;
        label_39:
        val_14 = this.<lcr>5__2.rewardCurrencyImage.transform;
        this.<newCps>5__4 = UnityEngine.Object.Instantiate<CurrencyParticles>(original:  val_15, parent:  val_14);
        val_16 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_16;
        return (bool)val_16;
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
