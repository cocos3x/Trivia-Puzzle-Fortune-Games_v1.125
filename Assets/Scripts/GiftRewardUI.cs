using UnityEngine;
public class GiftRewardUI : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text tapToOpen;
    protected UnityEngine.UI.Button tapArea;
    protected UnityEngine.UI.GridLayoutGroup upperLayout;
    private int maxRevealedRewards;
    private UnityEngine.GameObject coinRewardPrefab;
    private UnityEngine.GameObject foodRewardPrefab;
    private UnityEngine.GameObject petCardRewardPrefab;
    private UnityEngine.GameObject petCoinsRewardPrefab;
    private UnityEngine.GameObject diceRollPrefab;
    protected GridCoinCollectAnimationInstantiator coinAnim;
    private WADPetFoodAnimationInstantiator foodAnim;
    private DiceRollAnimationInstantiator diceAnim;
    public System.Collections.Generic.List<GiftRewardRevealInfo> rewardsToReveal;
    private System.Collections.Generic.List<UnityEngine.GameObject> revealedRewardObjects;
    protected bool waitingForCollectAnim;
    
    // Methods
    public virtual void Setup(System.Collections.Generic.List<GiftRewardUIParams> rewardsParams, System.Action onAllRewardsRevealed)
    {
        mem2[0] = 0;
        this.rewardsToReveal = this;
        this.FinishSetup(onAllRewardsRevealed:  onAllRewardsRevealed);
    }
    protected virtual System.Collections.Generic.List<GiftRewardRevealInfo> CreateRewardReveals(System.Collections.Generic.List<GiftRewardUIParams> rewardsParams, System.Action onAllRewardsRevealed)
    {
        System.Collections.Generic.List<GiftRewardUIParams> val_32;
        var val_33;
        System.Delegate val_34;
        UnityEngine.Transform val_35;
        val_32 = rewardsParams;
        System.Collections.Generic.List<GiftRewardRevealInfo> val_1 = null;
        val_33 = val_1;
        val_1 = new System.Collections.Generic.List<GiftRewardRevealInfo>();
        if(1152921516546076912 < 1)
        {
                return (System.Collections.Generic.List<GiftRewardRevealInfo>);
        }
        
        var val_34 = 0;
        label_66:
        GiftRewardUI.<>c__DisplayClass16_0 val_2 = null;
        val_34 = val_2;
        val_2 = new GiftRewardUI.<>c__DisplayClass16_0();
        .<>4__this = this;
        if(val_34 >= 1152921504975855616)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        .rewardParam = "path";
        val_35 = this.upperLayout.transform;
        GiftRewardUI.<>c__DisplayClass16_1 val_4 = new GiftRewardUI.<>c__DisplayClass16_1();
        if(((GiftRewardUI.<>c__DisplayClass16_0)[1152921517570236288].rewardParam.Reward.Type) > 4)
        {
            goto label_55;
        }
        
        var val_32 = 32562096 + ((GiftRewardUI.<>c__DisplayClass16_0)[1152921517570236288].rewardParam.Reward.Type) << 2;
        val_32 = val_32 + 32562096;
        goto (32562096 + ((GiftRewardUI.<>c__DisplayClass16_0)[1152921517570236288].rewardParam.Reward.Type) << 2 + 32562096);
        label_55:
        val_34 = val_34 + 1;
        if(val_34 < (rewardsParams + 24))
        {
            goto label_66;
        }
        
        return (System.Collections.Generic.List<GiftRewardRevealInfo>);
    }
    protected void FinishSetup(System.Action onAllRewardsRevealed)
    {
        .<>4__this = this;
        .onAllRewardsRevealed = onAllRewardsRevealed;
        string val_3 = System.String.Format(format:  Localization.Localize(key:  "tap_to_open_num_upper", defaultValue:  "TAP TO OPEN ({0})", useSingularKey:  false), arg0:  this.rewardsToReveal);
        this.OnClick_RevealReward(onAllRewardsRevealed:  (GiftRewardUI.<>c__DisplayClass17_0)[1152921517570603488].onAllRewardsRevealed);
        this.tapArea.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new GiftRewardUI.<>c__DisplayClass17_0(), method:  System.Void GiftRewardUI.<>c__DisplayClass17_0::<FinishSetup>b__0()));
    }
    public void OnClick_RevealReward(System.Action onAllRewardsRevealed)
    {
        if(this.rewardsToReveal == null)
        {
                return;
        }
        
        this.tapArea.interactable = false;
        if(this.rewardsToReveal == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        bool val_1 = this.rewardsToReveal.Remove(item:  this.rewardsToReveal);
        if(this.rewardsToReveal != null)
        {
                string val_3 = System.String.Format(format:  Localization.Localize(key:  "tap_to_open_num_upper", defaultValue:  "TAP TO OPEN ({0})", useSingularKey:  false), arg0:  this.rewardsToReveal);
        }
        else
        {
                this.tapToOpen.transform.parent.gameObject.SetActive(value:  false);
        }
        
        WGAudioController val_7 = MonoSingleton<WGAudioController>.Instance;
        val_7.sound.PlayGameSpecificSound(id:  "OpenGift", clipIndex:  0);
        UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this.StartRevealingReward(reward:  this.rewardsToReveal, onAllRewardsRevealed:  onAllRewardsRevealed));
    }
    private System.Collections.IEnumerator StartRevealingReward(GiftRewardRevealInfo reward, System.Action onAllRewardsRevealed)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .reward = reward;
        .onAllRewardsRevealed = onAllRewardsRevealed;
        return (System.Collections.IEnumerator)new GiftRewardUI.<StartRevealingReward>d__19();
    }
    public GiftRewardUI()
    {
        this.maxRevealedRewards = 4;
        this.revealedRewardObjects = new System.Collections.Generic.List<UnityEngine.GameObject>();
    }
    private void <CreateRewardReveals>b__16_6()
    {
        this.waitingForCollectAnim = false;
    }
    private void <CreateRewardReveals>b__16_7()
    {
        this.waitingForCollectAnim = false;
    }
    private void <CreateRewardReveals>b__16_8()
    {
        this.waitingForCollectAnim = false;
    }
    private void <CreateRewardReveals>b__16_9()
    {
        this.waitingForCollectAnim = false;
    }

}
