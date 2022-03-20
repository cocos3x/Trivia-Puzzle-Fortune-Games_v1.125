using UnityEngine;
public class WGBonusRewardsStoreDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text playerBonusPointsText;
    private UnityEngine.UI.Text playerBonusLevelText;
    private UnityEngine.UI.Button bonusRewardInfoButton;
    private BonusRewardCurrencyParticles brcParticles;
    private int currentBonusRewardPoints;
    private int currentBonusRewardLevel;
    private int currentDisplayPoints;
    
    // Methods
    private void OnEnable()
    {
        var val_25;
        PurchaseModel val_27;
        this.bonusRewardInfoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBonusRewardsStoreDisplay::OnInfoPressed()));
        UnityEngine.UI.Button val_3 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.Button>(gameObject:  this.gameObject);
        val_3.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBonusRewardsStoreDisplay::OnInfoPressed()));
        val_25 = null;
        val_25 = null;
        System.Delegate val_6 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGBonusRewardsStoreDisplay::SetText(PurchaseModel model)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_6;
        Player val_7 = App.Player;
        this.currentBonusRewardPoints = val_7._bonusRewardPoints;
        BonusRewardsContainer val_9 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetCurrentRewards();
        this.currentBonusRewardLevel = val_9.<level>k__BackingField;
        if((DefaultHandler<WGBonusRewardsHandler>.Instance.GetNextRewards()) == null)
        {
                BonusRewardsContainer val_13 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetCurrentRewards();
        }
        
        GameEcon val_16 = App.getGameEcon;
        GameEcon val_18 = App.getGameEcon;
        val_27 = System.String.Format(format:  "{0} / {1}", arg0:  DefaultHandler<WGBonusRewardsHandler>.Instance.GetProgressThroughCurrentTier().ToString(format:  val_16.numberFormatInt), arg1:  val_13.<pointReq>k__BackingField.ToString(format:  val_18.numberFormatInt));
        this.currentDisplayPoints = DefaultHandler<WGBonusRewardsHandler>.Instance.GetProgressThroughCurrentTier();
        if((DefaultHandler<WGBonusRewardsHandler>.Instance.MaxPointsGained()) != false)
        {
                val_27 = "MAX";
        }
        
        this.SetText(model:  val_27);
        return;
        label_8:
    }
    private void SetText(PurchaseModel model)
    {
        BonusRewardsContainer val_32;
        BonusRewardsContainer val_2 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetNextRewards();
        val_32 = val_2;
        if(val_2 == null)
        {
                val_32 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetCurrentRewards();
        }
        
        BonusRewardsContainer val_6 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetCurrentRewards();
        string val_7 = val_6.<level>k__BackingField.ToString();
        int val_9 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetProgressThroughCurrentTier();
        BonusRewardsContainer val_11 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetCurrentRewards();
        if(this.currentBonusRewardLevel != (val_11.<level>k__BackingField))
        {
            goto label_16;
        }
        
        Player val_12 = App.Player;
        if((this.currentBonusRewardPoints == val_12._bonusRewardPoints) || ((DefaultHandler<WGBonusRewardsHandler>.Instance.MaxPointsGained()) == true))
        {
            goto label_37;
        }
        
        this.TweenText(startValue:  this.currentDisplayPoints, endValue:  val_9, myContainer:  val_32);
        goto label_37;
        label_16:
        GameBehavior val_15 = App.getBehavior;
        GameEcon val_17 = App.getGameEcon;
        GameEcon val_19 = App.getGameEcon;
        string val_21 = System.String.Format(format:  "{0} / {1}", arg0:  val_9.ToString(format:  val_17.numberFormatInt), arg1:  val_4.<pointReq>k__BackingField.ToString(format:  val_19.numberFormatInt));
        bool val_23 = DefaultHandler<WGBonusRewardsHandler>.Instance.MaxPointsGained();
        label_37:
        this.currentDisplayPoints = val_9;
        Player val_24 = App.Player;
        if(this.currentBonusRewardPoints != val_24._bonusRewardPoints)
        {
                Player val_25 = App.Player;
            UnityEngine.Coroutine val_28 = this.StartCoroutine(routine:  this.PlayBonusRewardsAnim(particleCount:  val_25._bonusRewardPoints - this.currentBonusRewardPoints));
        }
        
        BonusRewardsContainer val_30 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetCurrentRewards();
        this.currentBonusRewardLevel = val_30.<level>k__BackingField;
        Player val_31 = App.Player;
        this.currentBonusRewardPoints = val_31._bonusRewardPoints;
    }
    private System.Collections.IEnumerator PlayBonusRewardsAnim(int particleCount)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .particleCount = particleCount;
        return (System.Collections.IEnumerator)new WGBonusRewardsStoreDisplay.<PlayBonusRewardsAnim>d__9();
    }
    private void TweenText(int startValue, int endValue, BonusRewardsContainer myContainer)
    {
        WGBonusRewardsStoreDisplay val_20;
        DG.Tweening.Tweener val_21;
        val_20 = this;
        WGBonusRewardsStoreDisplay.<>c__DisplayClass10_0 val_1 = new WGBonusRewardsStoreDisplay.<>c__DisplayClass10_0();
        .<>4__this = val_20;
        .myContainer = myContainer;
        .progress = (float)startValue;
        DG.Tweening.TweenCallback val_5 = 1152921509727915456;
        val_5 = new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WGBonusRewardsStoreDisplay.<>c__DisplayClass10_0::<TweenText>b__1());
        val_21 = DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void WGBonusRewardsStoreDisplay.<>c__DisplayClass10_0::<TweenText>b__0(float x)), startValue:  (float)startValue, endValue:  (float)endValue, duration:  0.5f), ease:  1), action:  val_5);
        DG.Tweening.Tweener val_9 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  val_21, action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WGBonusRewardsStoreDisplay.<>c__DisplayClass10_0::<TweenText>b__2())), autoKillOnCompletion:  true);
        if((DefaultHandler<WGBonusRewardsHandler>.Instance.MaxPointsGained()) == false)
        {
                return;
        }
        
        val_20 = ???;
        val_21 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnDestroy()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseCompleted, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGBonusRewardsStoreDisplay::SetText(PurchaseModel model)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        return;
        label_4:
    }
    private void OnInfoPressed()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public WGBonusRewardsPopup MetaGameBehavior::ShowUGUIMonolith<WGBonusRewardsPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public WGBonusRewardsStoreDisplay()
    {
    
    }

}
