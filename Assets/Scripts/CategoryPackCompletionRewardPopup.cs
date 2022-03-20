using UnityEngine;
public class CategoryPackCompletionRewardPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text descriptionLabel;
    private UnityEngine.UI.Button collectButton;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private GoldenCurrencyCollectAnimationInstantiator goldenAnimControl;
    private UnityEngine.Sprite coinIcon;
    private UnityEngine.Sprite goldenCurrencyIcon;
    private UnityEngine.Sprite bonusIconWheel;
    private UnityEngine.Sprite bonusIconSlots;
    private UnityEngine.GameObject rewardCoinObject;
    private UnityEngine.UI.Text reward;
    private UnityEngine.UI.Image rewardSingularIcon;
    private UnityEngine.GameObject rewardBonusGameObject;
    private UnityEngine.UI.Text rewardBonusGameLabel;
    private UnityEngine.UI.Image rewardBonusGameIcon;
    private UnityEngine.GameObject rewardCoinGoldenObject;
    private UnityEngine.UI.Text rewardCGCoin;
    private UnityEngine.UI.Text rewardCGGolden;
    private System.Func<float> onCollectCreditAction;
    
    // Methods
    private void Start()
    {
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void CategoryPackCompletionRewardPopup::OnCollectClick()));
    }
    public void Initialize(CategoryCompletionReward _rewardData, int categoriesCleared)
    {
        object val_52;
        int val_53;
        IntPtr val_55;
        var val_56;
        var val_58;
        string val_1 = Localization.Localize(key:  "cleared_x_categories", defaultValue:  "You\'ve cleared {0} Categories!", useSingularKey:  false);
        string val_2 = System.String.Format(format:  val_1, arg0:  categoriesCleared);
        if(((_rewardData.rewards.ContainsKey(key:  1)) == false) || ((_rewardData.rewards.ContainsKey(key:  2)) == false))
        {
            goto label_6;
        }
        
        CategoryPackCompletionRewardPopup.<>c__DisplayClass19_0 val_5 = null;
        val_52 = val_5;
        val_5 = new CategoryPackCompletionRewardPopup.<>c__DisplayClass19_0();
        .<>4__this = this;
        this.rewardCoinObject.gameObject.SetActive(value:  false);
        this.rewardBonusGameObject.gameObject.SetActive(value:  false);
        this.rewardCoinGoldenObject.gameObject.SetActive(value:  true);
        decimal val_9 = _rewardData.rewards.Item[2];
        string val_10 = val_9.flags.ToString();
        decimal val_11 = _rewardData.rewards.Item[1];
        string val_12 = val_11.flags.ToString();
        Player val_13 = App.Player;
        decimal val_14 = _rewardData.rewards.Item[1];
        decimal val_15 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_13._credits, hi = val_13._credits, lo = val_1, mid = val_1}, d2:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid});
        .preCreditedValueCoins = val_15;
        mem[1152921516117820024] = val_15.lo;
        mem[1152921516117820028] = val_15.mid;
        this.coinsAnimControl.Set(instantValue:  new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid});
        Player val_16 = App.Player;
        decimal val_17 = _rewardData.rewards.Item[2];
        val_17.lo = val_16._stars - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid}));
        .preCreditedValueGolden = val_17.lo;
        this.goldenAnimControl.SetStatViewValue(instantValue:  val_17.lo);
        val_55 = 1152921516117483008;
        goto label_48;
        label_6:
        if((_rewardData.rewards.ContainsKey(key:  1)) == false)
        {
            goto label_30;
        }
        
        CategoryPackCompletionRewardPopup.<>c__DisplayClass19_1 val_20 = null;
        val_52 = val_20;
        val_20 = new CategoryPackCompletionRewardPopup.<>c__DisplayClass19_1();
        .<>4__this = this;
        this.rewardCoinObject.gameObject.SetActive(value:  true);
        this.rewardBonusGameObject.gameObject.SetActive(value:  false);
        this.rewardCoinGoldenObject.gameObject.SetActive(value:  false);
        decimal val_24 = _rewardData.rewards.Item[1];
        string val_25 = val_24.flags.ToString();
        this.rewardSingularIcon.sprite = this.coinIcon;
        Player val_26 = App.Player;
        decimal val_27 = _rewardData.rewards.Item[1];
        val_53 = val_27.flags;
        decimal val_28 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_26._credits, hi = val_26._credits, lo = this.reward, mid = this.reward}, d2:  new System.Decimal() {flags = val_53, hi = val_27.hi, lo = val_27.lo, mid = val_27.mid});
        .preCreditedValueCoins = val_28;
        mem[1152921516117906040] = val_28.lo;
        mem[1152921516117906044] = val_28.mid;
        this.coinsAnimControl.Set(instantValue:  new System.Decimal() {flags = val_28.flags, hi = val_28.hi, lo = val_28.lo, mid = val_28.mid});
        val_55 = 1152921516117553664;
        goto label_48;
        label_30:
        if((_rewardData.rewards.ContainsKey(key:  2)) == false)
        {
            goto label_50;
        }
        
        CategoryPackCompletionRewardPopup.<>c__DisplayClass19_2 val_30 = null;
        val_52 = val_30;
        val_30 = new CategoryPackCompletionRewardPopup.<>c__DisplayClass19_2();
        .<>4__this = this;
        this.rewardCoinObject.gameObject.SetActive(value:  true);
        this.rewardBonusGameObject.gameObject.SetActive(value:  false);
        this.rewardCoinGoldenObject.gameObject.SetActive(value:  false);
        val_53 = 1152921516117436928;
        decimal val_34 = _rewardData.rewards.Item[2];
        string val_35 = val_34.flags.ToString();
        this.rewardSingularIcon.sprite = this.goldenCurrencyIcon;
        Player val_36 = App.Player;
        decimal val_37 = _rewardData.rewards.Item[2];
        int val_52 = val_37.lo;
        val_52 = val_36._stars - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_37.flags, hi = val_37.hi, lo = val_52, mid = val_37.mid}));
        .preCreditedValueGolden = val_52;
        this.goldenAnimControl.SetStatViewValue(instantValue:  val_52);
        System.Func<System.Single> val_39 = null;
        val_55 = 1152921516117624320;
        label_48:
        val_39 = new System.Func<System.Single>(object:  val_30, method:  val_55);
        label_101:
        this.onCollectCreditAction = val_39;
        return;
        label_50:
        if((_rewardData.rewards.ContainsKey(key:  3)) == false)
        {
            goto label_69;
        }
        
        this.rewardCoinObject.gameObject.SetActive(value:  false);
        this.rewardBonusGameObject.gameObject.SetActive(value:  true);
        this.rewardCoinGoldenObject.gameObject.SetActive(value:  false);
        string val_44 = Localization.Localize(key:  "bonus_wheel_upper", defaultValue:  "BONUS WHEEL", useSingularKey:  false);
        this.rewardBonusGameIcon.sprite = this.bonusIconWheel;
        val_56 = null;
        val_56 = null;
        if((CategoryPackCompletionRewardPopup.<>c.<>9__19_0) != null)
        {
            goto label_101;
        }
        
        CategoryPackCompletionRewardPopup.<>c.<>9__19_0 = new System.Func<System.Single>(object:  CategoryPackCompletionRewardPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Single CategoryPackCompletionRewardPopup.<>c::<Initialize>b__19_0());
        goto label_101;
        label_69:
        if((_rewardData.rewards.ContainsKey(key:  4)) == false)
        {
                return;
        }
        
        this.rewardCoinObject.gameObject.SetActive(value:  false);
        this.rewardBonusGameObject.gameObject.SetActive(value:  true);
        this.rewardCoinGoldenObject.gameObject.SetActive(value:  false);
        string val_50 = Localization.Localize(key:  "bonus_spin_upper", defaultValue:  "BONUS SPIN", useSingularKey:  false);
        this.rewardBonusGameIcon.sprite = this.bonusIconSlots;
        val_58 = null;
        val_58 = null;
        if((CategoryPackCompletionRewardPopup.<>c.<>9__19_1) != null)
        {
            goto label_101;
        }
        
        CategoryPackCompletionRewardPopup.<>c.<>9__19_1 = new System.Func<System.Single>(object:  CategoryPackCompletionRewardPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Single CategoryPackCompletionRewardPopup.<>c::<Initialize>b__19_1());
        goto label_101;
    }
    private void OnCollectClick()
    {
        float val_4;
        this.collectButton.interactable = false;
        if(this.onCollectCreditAction != null)
        {
                val_4 = this.onCollectCreditAction.Invoke();
        }
        else
        {
                val_4 = 0f;
        }
        
        DG.Tweening.Tween val_3 = DG.Tweening.DOVirtual.DelayedCall(delay:  val_4, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void CategoryPackCompletionRewardPopup::CloseWindow()), ignoreTimeScale:  true);
    }
    private void CloseWindow()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public CategoryPackCompletionRewardPopup()
    {
    
    }

}
