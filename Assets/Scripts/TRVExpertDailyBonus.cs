using UnityEngine;
public class TRVExpertDailyBonus : WGDailyBonusPopup
{
    // Fields
    private UnityEngine.GameObject pickGiftParent;
    private UnityEngine.GameObject giftAnimationScreen;
    private UnityEngine.UI.Image giftImage;
    private UnityEngine.UI.Text tapToOpenText;
    
    // Methods
    protected override void Init_v2()
    {
        this.Init_v2();
    }
    protected override System.Collections.IEnumerator CheckState()
    {
        return this.CheckState();
    }
    protected override void OnEnable_v2()
    {
        this.OnEnable_v2();
    }
    protected override void OnCoinsAnimFinished_v2()
    {
        this.OnCoinsAnimFinished_v2();
    }
    protected override void OnClick_PickAnotherButton(bool result)
    {
        this.OnClick_PickAnotherButton(result:  result);
    }
    protected override void UpdateDailyBonusUI()
    {
        this.UpdateDailyBonusUI();
    }
    protected override void UpdateReward(DailyBonusRevealedRewardInfo info)
    {
        this.UpdateReward(info:  info);
    }
    protected override void OnClick_ContinueButton()
    {
        this.OnClick_ContinueButton();
    }
    protected override void OnClick_CloseButton()
    {
        this.OnClick_CloseButton();
    }
    protected override void ShowPickAnotherGroup(bool showPickAnotherButton)
    {
        this.ShowPickAnotherGroup(showPickAnotherButton:  showPickAnotherButton);
    }
    protected override void ShowFtuxPickGroup()
    {
        this.ShowFtuxPickGroup();
    }
    protected override void ShowFtuxRewardGroup()
    {
        this.ShowFtuxRewardGroup();
    }
    protected override void HidePickAnotherGroup()
    {
        this.HidePickAnotherGroup();
    }
    protected override void ShowPickRewardText()
    {
        this.ShowPickRewardText();
    }
    public override void OnRewardButtonClick(UnityEngine.GameObject reward)
    {
        System.Delegate val_24;
        var val_25;
        var val_26;
        System.Action val_28;
        val_24 = 1152921504893161472;
        WGDailyBonusManager val_1 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_1.revealedRewardInfo != null)
        {
                return;
        }
        
        mem[1152921517146725240] = reward;
        WGDailyBonusManager val_2 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_2._bonusUIState == 4)
        {
            goto label_12;
        }
        
        WGDailyBonusManager val_3 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_3._bonusUIState == 0)
        {
            goto label_12;
        }
        
        WGDailyBonusManager val_4 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_4._bonusUIState != 2)
        {
            goto label_16;
        }
        
        label_12:
        WGDailyBonusManager val_5 = MonoSingleton<WGDailyBonusManager>.Instance;
        if(val_5._bonusUIState == 4)
        {
                val_25 = 2;
        }
        else
        {
                WGDailyBonusManager val_6 = MonoSingleton<WGDailyBonusManager>.Instance;
        }
        
        bool val_11 = false;
        val_24 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVGiftRewardPopup>(showNext:  true);
        System.Collections.Generic.List<TSource> val_14 = System.Linq.Enumerable.ToList<GiftReward>(source:  System.Linq.Enumerable.Cast<GiftReward>(source:  WGGiftRewardManager<TRVGiftRewardManager>.Instance.GetRewards(rewardsSource:  (val_6._bonusUIState == 2) ? 1 : 0, expertLeveledUp: out  val_11, cardsGranted:  0)));
        if(val_11 != 0)
        {
                WGWindow val_15 = val_24.GetComponent<WGWindow>();
            val_26 = null;
            val_26 = null;
            val_28 = TRVExpertDailyBonus.<>c.<>9__18_1;
            if(val_28 == null)
        {
                System.Action val_16 = null;
            val_28 = val_16;
            val_16 = new System.Action(object:  TRVExpertDailyBonus.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVExpertDailyBonus.<>c::<OnRewardButtonClick>b__18_1());
            TRVExpertDailyBonus.<>c.<>9__18_1 = val_28;
        }
        
            System.Delegate val_17 = System.Delegate.Combine(a:  val_24, b:  val_16);
            if(val_17 != null)
        {
                if(null != null)
        {
            goto label_40;
        }
        
        }
        
            mem2[0] = val_17;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_16:
        bool val_19 = UnityEngine.Object.op_Inequality(x:  reward, y:  0);
        if(val_19 == false)
        {
                return;
        }
        
        DG.Tweening.Tweener val_23 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOShakeScale(target:  val_19.transform, duration:  1f, strength:  0.25f, vibrato:  10, randomness:  90f, fadeOut:  true), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void TRVExpertDailyBonus::<OnRewardButtonClick>b__18_0()));
        return;
        label_40:
    }
    public TRVExpertDailyBonus()
    {
    
    }
    private void <OnRewardButtonClick>b__18_0()
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.one;
        28311.transform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
    }

}
