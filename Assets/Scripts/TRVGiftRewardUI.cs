using UnityEngine;
public class TRVGiftRewardUI : GiftRewardUI
{
    // Fields
    private TRVExpertDisplay expertCardPrefab;
    private UnityEngine.GameObject coinBagPrefab;
    
    // Methods
    private void Awake()
    {
        if(41963520 != 0)
        {
                return;
        }
        
        mem[1152921517171782160] = this.gameObject.GetComponent<UnityEngine.UI.Button>();
    }
    protected override System.Collections.Generic.List<GiftRewardRevealInfo> CreateRewardReveals(System.Collections.Generic.List<GiftRewardUIParams> rewardsParams, System.Action onAllRewardsRevealed)
    {
        GiftRewardUIParams val_3;
        var val_4;
        GiftRewardRevealInfo val_8;
        System.Collections.Generic.List<GiftRewardRevealInfo> val_1 = new System.Collections.Generic.List<GiftRewardRevealInfo>();
        List.Enumerator<T> val_2 = rewardsParams.GetEnumerator();
        label_10:
        val_8 = public System.Boolean List.Enumerator<GiftRewardUIParams>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_3 + 16) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_3 + 16 + 16) == 0)
        {
            goto label_5;
        }
        
        if((val_3 + 16 + 16) != 3)
        {
            goto label_10;
        }
        
        val_8 = this.AddExpertReward(param:  val_3);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_8);
        goto label_10;
        label_5:
        val_8 = this.AddCoinReward(param:  val_3);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_8);
        goto label_10;
        label_2:
        val_4.Dispose();
        return val_1;
    }
    public GiftRewardRevealInfo AddCoinReward(GiftRewardUIParams param)
    {
        TRVGiftRewardUI.<>c__DisplayClass4_0 val_1 = new TRVGiftRewardUI.<>c__DisplayClass4_0();
        .<>4__this = this;
        .param = param;
        UnityEngine.GameObject val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.coinBagPrefab, parent:  val_1.transform);
        UnityEngine.UI.Text val_4 = val_3.GetComponentInChildren<UnityEngine.UI.Text>();
        string val_5 = (TRVGiftRewardUI.<>c__DisplayClass4_0)[1152921517172144624].param.Reward.Amount.ToString();
        MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  val_3).alpha = 0f;
        val_3.SetActive(value:  true);
        .rewardObject = val_3;
        .rewardAction = new System.Action(object:  val_1, method:  System.Void TRVGiftRewardUI.<>c__DisplayClass4_0::<AddCoinReward>b__0());
        return (GiftRewardRevealInfo)new GiftRewardRevealInfo();
    }
    public GiftRewardRevealInfo AddExpertReward(GiftRewardUIParams param)
    {
        TRVGiftRewardUI.<>c__DisplayClass5_0 val_1 = new TRVGiftRewardUI.<>c__DisplayClass5_0();
        .newCardDisplay = UnityEngine.Object.Instantiate<TRVExpertDisplay>(original:  this.expertCardPrefab, parent:  val_1.transform);
        .myExpert = (GiftReward.__il2cppRuntimeField_typeHierarchy + (TRVDailyBonusRewardContainer.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8;
        TRVExpertsController val_4 = MonoSingleton<TRVExpertsController>.Instance;
        TRVExpertProgressData val_5 = val_4.myExperts.Item[(TRVGiftRewardUI.<>c__DisplayClass5_0)[1152921517172388720].myExpert.expertName];
        .data = val_5;
        (TRVGiftRewardUI.<>c__DisplayClass5_0)[1152921517172388720].newCardDisplay.Init(me:  (TRVGiftRewardUI.<>c__DisplayClass5_0)[1152921517172388720].myExpert, progress:  val_5, upgraded:  false, showName:  true);
        .rewardObject = (TRVGiftRewardUI.<>c__DisplayClass5_0)[1152921517172388720].newCardDisplay.gameObject;
        .rewardAction = new System.Action(object:  val_1, method:  System.Void TRVGiftRewardUI.<>c__DisplayClass5_0::<AddExpertReward>b__0());
        MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  (TRVGiftRewardUI.<>c__DisplayClass5_0)[1152921517172388720].newCardDisplay.gameObject).alpha = 0f;
        return (GiftRewardRevealInfo)new GiftRewardRevealInfo();
    }
    public TRVGiftRewardUI()
    {
    
    }

}
