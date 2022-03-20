using UnityEngine;
public class WFOEventRewardPopup : MonoBehaviour
{
    // Fields
    public System.Action OnCollectCallback;
    public System.Action OnCloseCallback;
    private UnityEngine.UI.Text eventNameText;
    private UnityEngine.UI.Image rewardIconBig;
    private UnityEngine.UI.Image rewardIconSmall;
    private UnityEngine.UI.Text rewardAmountText;
    private UnityEngine.UI.Button collectButton;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private GoldenCurrencyCollectAnimationInstantiator goldAnim;
    private WADPetFoodAnimationInstantiator foodAnim;
    private UnityEngine.Sprite rewIconCoins;
    private UnityEngine.Sprite rewIconGoldenCurrency;
    private UnityEngine.Sprite rewIconFood;
    private UnityEngine.Sprite rewIconCoinsBig;
    private UnityEngine.Sprite rewIconGoldenCurrencyBig;
    private UnityEngine.Sprite rewIconFoodBig;
    private RESEventRewardData rewardData;
    private string rewardSource;
    
    // Properties
    public UnityEngine.Transform rewardIconBigTransform { get; }
    
    // Methods
    public UnityEngine.Transform get_rewardIconBigTransform()
    {
        if(this.rewardIconBig != null)
        {
                return this.rewardIconBig.transform;
        }
        
        throw new NullReferenceException();
    }
    private void Start()
    {
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WFOEventRewardPopup::OnCollectButtonClicked()));
    }
    private void OnEnable()
    {
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.sound.PlayGameSpecificSound(id:  "Collect Reward", clipIndex:  0);
    }
    public void InitReward(string title, RESEventRewardData reward, string source = "", System.Action onCollectClicked, System.Action onClose)
    {
        UnityEngine.Sprite val_5;
        this.rewardData = reward;
        this.rewardSource = source;
        System.Delegate val_1 = System.Delegate.Combine(a:  this.OnCollectCallback, b:  onCollectClicked);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        this.OnCollectCallback = val_1;
        System.Delegate val_2 = System.Delegate.Combine(a:  this.OnCloseCallback, b:  onClose);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        this.OnCloseCallback = val_2;
        if(this.rewardData.rewardType == 4)
        {
            goto label_7;
        }
        
        if(this.rewardData.rewardType == 3)
        {
            goto label_8;
        }
        
        if(this.rewardData.rewardType != 1)
        {
            goto label_9;
        }
        
        this.rewardIconBig.sprite = this.rewIconCoinsBig;
        val_5 = this.rewIconCoins;
        goto label_15;
        label_8:
        this.rewardIconBig.sprite = this.rewIconGoldenCurrencyBig;
        val_5 = this.rewIconGoldenCurrency;
        goto label_15;
        label_7:
        this.rewardIconBig.sprite = this.rewIconFoodBig;
        val_5 = this.rewIconFood;
        label_15:
        this.rewardIconSmall.sprite = val_5;
        label_9:
        GameEcon val_3 = App.getGameEcon;
        string val_4 = reward.rewardQty.ToString(format:  val_3.numberFormatInt);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_5:
    }
    private void OnCollectButtonClicked()
    {
        var val_23;
        System.Delegate val_24;
        GoldenCurrencyCollectAnimationInstantiator val_25;
        this.collectButton.interactable = false;
        if(this.rewardData.rewardType == 4)
        {
            goto label_3;
        }
        
        if(this.rewardData.rewardType != 3)
        {
                if(this.rewardData.rewardType != 1)
        {
                return;
        }
        
            App.Player.AddCredits(amount:  new System.Decimal() {flags = this.rewardData.rewardQty, hi = this.rewardData.rewardQty}, source:  this.rewardSource, subSource:  0, externalParams:  0, doTrack:  true);
            Player val_2 = App.Player;
            decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = this.rewardData.rewardQty, hi = this.rewardData.rewardQty, lo = X21, mid = X21});
            Player val_4 = App.Player;
            this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, toValue:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            val_23 = 1152921504614301696;
            System.Action val_5 = null;
            val_24 = val_5;
            val_5 = new System.Action(object:  this, method:  System.Void WFOEventRewardPopup::CollectAndClose());
            System.Delegate val_6 = System.Delegate.Combine(a:  this.coinsAnim.OnCompleteCallback, b:  val_5);
            if(val_6 != null)
        {
                if(null != null)
        {
            goto label_46;
        }
        
        }
        
            this.coinsAnim.OnCompleteCallback = val_6;
            return;
        }
        
        GoldenApplesManager val_7 = MonoSingleton<GoldenApplesManager>.Instance;
        Player val_9 = App.Player;
        Player val_11 = App.Player;
        decimal val_12 = System.Decimal.op_Implicit(value:  val_11._stars);
        this.goldAnim.Play(fromValue:  val_9._stars - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.rewardData.rewardQty, hi = this.rewardData.rewardQty, lo = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.rewardData.rewardQty, hi = this.rewardData.rewardQty, lo = X21, mid = X21}), mid = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.rewardData.rewardQty, hi = this.rewardData.rewardQty, lo = X21, mid = X21})})), toValue:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        val_25 = this.goldAnim;
        if(val_25 != null)
        {
            goto label_32;
        }
        
        label_3:
        int val_15 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.rewardData.rewardQty, hi = this.rewardData.rewardQty, lo = X21, mid = X21});
        App.Player.AddPetsFood(amount:  val_15, source:  this.rewardSource, subSource:  0, FoodSpentParams:  0, additionalParam:  0);
        Player val_16 = App.Player;
        Player val_18 = App.Player;
        decimal val_19 = System.Decimal.op_Implicit(value:  val_18._food);
        this.foodAnim.Play(fromValue:  val_16._food - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.rewardData.rewardQty, hi = this.rewardData.rewardQty, lo = val_15, mid = val_15})), toValue:  new System.Decimal() {flags = val_19.flags, hi = val_19.hi, lo = val_19.lo, mid = val_19.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        val_25 = this.foodAnim;
        label_32:
        val_23 = 1152921504614301696;
        System.Action val_21 = null;
        val_24 = val_21;
        val_21 = new System.Action(object:  this, method:  System.Void WFOEventRewardPopup::CollectAndClose());
        System.Delegate val_22 = System.Delegate.Combine(a:  this.foodAnim, b:  val_21);
        if(val_22 != null)
        {
                if(null != null)
        {
            goto label_46;
        }
        
        }
        
        mem2[0] = val_22;
        return;
        label_46:
    }
    private void CollectAndClose()
    {
        if(this.OnCollectCallback != null)
        {
                this.OnCollectCallback.Invoke();
        }
        
        this.Close();
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(this.OnCloseCallback == null)
        {
                return;
        }
        
        this.OnCloseCallback.Invoke();
    }
    public WFOEventRewardPopup()
    {
    
    }

}
