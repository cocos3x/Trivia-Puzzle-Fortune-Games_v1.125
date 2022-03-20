using UnityEngine;
public class TournamentsResultsPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button_continue;
    private UnityEngine.UI.Button button_collect;
    private TournamentsTierDisplay tier_display;
    private UnityEngine.UI.Text text_rank;
    private UnityEngine.UI.Text text_rank_ordinal;
    private UnityEngine.UI.Text text_gemReward;
    private UnityEngine.UI.Text text_coinReward;
    private UnityEngine.GameObject giftReward;
    private UnityEngine.GameObject promotion;
    private UnityEngine.GameObject demotion;
    private CurrencyCollectAnimationInstantiator coinsAnimControl;
    private CurrencyCollectAnimationInstantiator gemAnimControl;
    private int coins;
    private int gemsOrPetFood;
    private System.Collections.Generic.List<GiftReward> giftRewards;
    private bool canCollect;
    
    // Properties
    private int PlayerCurrentGemsOrPetFood { get; }
    
    // Methods
    private int get_PlayerCurrentGemsOrPetFood()
    {
        var val_4;
        var val_6;
        int val_7;
        val_4 = null;
        val_6 = 0;
        if(App.game == 17)
        {
                Player val_1 = App.Player;
            val_7 = val_1._gems;
            return val_7;
        }
        
        Player val_2 = App.Player;
        val_7 = val_2._food;
        return val_7;
    }
    private void Awake()
    {
        this.button_collect.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TournamentsResultsPopup::OnCollectContinueClicked()));
        this.button_continue.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TournamentsResultsPopup::OnCollectContinueClicked()));
        System.Delegate val_4 = System.Delegate.Combine(a:  this.button_continue.m_OnClick, b:  new System.Action(object:  this, method:  System.Void TournamentsResultsPopup::<Awake>b__18_0()));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        mem2[0] = val_4;
        System.Delegate val_6 = System.Delegate.Combine(a:  this.button_continue.m_OnClick, b:  new System.Action(object:  this, method:  System.Void TournamentsResultsPopup::<Awake>b__18_1()));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        mem2[0] = val_6;
        return;
        label_10:
    }
    public void ShowResults(int coinReward, int gemsOrPetFoodReward, System.Collections.Generic.List<GiftReward> giftRewards, int rankIndex, int lastTournamentTier)
    {
        int val_19;
        int val_20;
        bool val_21 = true;
        this.coins = coinReward;
        this.gemsOrPetFood = gemsOrPetFoodReward;
        this.giftRewards = giftRewards;
        val_21 = (gemsOrPetFoodReward + coinReward) + val_21;
        this.canCollect = (val_21 > 0) ? 1 : 0;
        this.tier_display.RefreshDisplay(tierIndex:  lastTournamentTier);
        int val_3 = rankIndex + 1;
        string val_4 = val_3.ToString();
        string val_5 = Ordinal.AddOrdinal(num:  val_3);
        this.giftReward.gameObject.SetActive(value:  (null > 0) ? 1 : 0);
        string val_9 = System.String.Format(format:  "+{0}", arg0:  gemsOrPetFoodReward.ToString());
        string val_11 = System.String.Format(format:  "+{0}", arg0:  coinReward.ToString());
        if((TournamentsEconomy.TierIndexCanPromote(tierIndex:  lastTournamentTier)) == false)
        {
            goto label_11;
        }
        
        val_19 = rankIndex;
        bool val_13 = TournamentsEconomy.RankIndexIsPromotion(rankIndex:  val_19);
        if(this.promotion != null)
        {
            goto label_14;
        }
        
        label_11:
        val_19 = 0;
        label_14:
        this.promotion.SetActive(value:  val_19 & 1);
        if((TournamentsEconomy.TierIndexCanDemote(tierIndex:  lastTournamentTier)) == false)
        {
            goto label_19;
        }
        
        val_20 = rankIndex;
        bool val_16 = TournamentsEconomy.RankIndexIsDemotion(rankIndex:  val_20);
        if(this.demotion != null)
        {
            goto label_22;
        }
        
        label_19:
        val_20 = 0;
        label_22:
        this.demotion.SetActive(value:  val_20 & 1);
        this.button_collect.gameObject.SetActive(value:  this.canCollect);
        this.button_continue.gameObject.SetActive(value:  (this.canCollect == false) ? 1 : 0);
    }
    private void OnCollectContinueClicked()
    {
        var val_16;
        var val_17;
        int val_18;
        int val_19;
        CurrencyCollectAnimationInstantiator val_20;
        System.Action val_21;
        System.Action val_22;
        if(this.canCollect != true)
        {
                val_16 = this;
            this.OnCollectAnimsFinished();
        }
        
        if(this.coins >= 1)
        {
                if(this.gemsOrPetFood >= 1)
        {
                Player val_1 = App.Player;
            val_17 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X21, mid = X21});
            Player val_3 = App.Player;
            val_18 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = X21, mid = X21});
            val_19 = val_17 - this.coins;
            val_16 = this;
            val_20 = this.coinsAnimControl;
            val_21 = 0;
        }
        else
        {
                Player val_5 = App.Player;
            val_17 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = X21, mid = X21});
            Player val_7 = App.Player;
            System.Action val_9 = null;
            val_22 = val_9;
            val_9 = new System.Action(object:  this, method:  System.Void TournamentsResultsPopup::OnCollectAnimsFinished());
            val_19 = val_17 - this.coins;
            val_16 = this;
            val_20 = this.coinsAnimControl;
            val_18 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits, lo = X21, mid = X21});
            val_21 = val_22;
        }
        
            this.AnimatePurchase(animControl:  val_20, fromAmount:  val_19, toAmount:  val_18, actionOnComplete:  val_9, delay:  0f);
        }
        
        if(this.gemsOrPetFood >= 1)
        {
                int val_10 = this.PlayerCurrentGemsOrPetFood;
            val_17 = val_10;
            System.Action val_12 = null;
            val_22 = val_12;
            val_12 = new System.Action(object:  this, method:  System.Void TournamentsResultsPopup::OnCollectAnimsFinished());
            this.AnimatePurchase(animControl:  this.gemAnimControl, fromAmount:  val_17 - this.gemsOrPetFood, toAmount:  val_10.PlayerCurrentGemsOrPetFood, actionOnComplete:  val_12, delay:  0.9f);
        }
        
        this.button_collect.interactable = false;
        this.button_continue.interactable = false;
    }
    private void AnimatePurchase(CurrencyCollectAnimationInstantiator animControl, int fromAmount, int toAmount, System.Action actionOnComplete, float delay = 0)
    {
        animControl.OnCompleteCallback = actionOnComplete;
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.StartAnimating(animControl:  animControl, fromAmount:  fromAmount, toAmount:  toAmount, delay:  delay));
    }
    private System.Collections.IEnumerator StartAnimating(CurrencyCollectAnimationInstantiator animControl, int fromAmount, int toAmount, float delay)
    {
        .<>1__state = 0;
        .animControl = animControl;
        .fromAmount = fromAmount;
        .toAmount = toAmount;
        .delay = delay;
        return (System.Collections.IEnumerator)new TournamentsResultsPopup.<StartAnimating>d__22();
    }
    private void OnCollectAnimsFinished()
    {
        var val_6;
        var val_7;
        MonoSingleton<TournamentsManager>.Instance.HandleTournamentResultsCollected();
        if((this.giftRewards != null) && (this.giftRewards >= 1))
        {
                val_6 = null;
            val_6 = null;
            if(App.game == 17)
        {
                WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance;
            val_7 = 1152921515927318256;
        }
        else
        {
                val_7 = 1152921515927323376;
        }
        
            WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGGiftRewardPopup>(showNext:  true);
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TournamentsResultsPopup()
    {
    
    }
    private void <Awake>b__18_0()
    {
        Player val_1 = App.Player;
        int val_3 = X21;
        val_3 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = val_3, mid = val_3})) - this.coins;
        this.coinsAnimControl.SetStatViewValue(instantValue:  val_3);
    }
    private void <Awake>b__18_1()
    {
        this.gemAnimControl.SetStatViewValue(instantValue:  this.PlayerCurrentGemsOrPetFood - this.gemsOrPetFood);
    }

}
