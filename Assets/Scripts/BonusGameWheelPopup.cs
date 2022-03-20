using UnityEngine;
public class BonusGameWheelPopup : MonoBehaviour
{
    // Fields
    public string trackEventSource;
    public System.Action OnRewarded;
    private UnityEngine.UI.Text descriptionLabel;
    private UnityEngine.UI.Button buttonSpin;
    private UnityEngine.UI.Button buttonCollect;
    private UnityEngine.UI.Button buttonClose;
    private UnityEngine.RectTransform spinContainer;
    private BonusGameWheelWedge[] wedges;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private GoldenCurrencyCollectAnimationInstantiator goldenCurrencyAnimControl;
    private UnityEngine.Sprite spriteIconGoldenCurrency;
    private UnityEngine.Sprite spriteIconCoin;
    private int minSpinCount;
    private int maxSpinCount;
    private float spinDuration;
    private float pullbackDegree;
    private System.Collections.Generic.List<BonusGameWheelPopup.WheelPrizeData> prizeList;
    private int wheelOffset;
    private int prizeIndex;
    private static BonusGameWheelPopup.AwardType qaHackFlagAwardType;
    
    // Properties
    public static BonusGameWheelPopup.AwardType QAHACK_ForceAwardType { get; set; }
    
    // Methods
    private void Start()
    {
        this.Init();
    }
    private void Init()
    {
        BonusGameWheelWedge[] val_18;
        GameEcon val_1 = App.getGameEcon;
        GameEcon val_2 = App.getGameEcon;
        System.Collections.Generic.List<WheelPrizeData> val_5 = new System.Collections.Generic.List<WheelPrizeData>();
        val_18 = this.wedges;
        this.prizeList = val_5;
        if(this.wedges.Length < 2)
        {
            goto label_20;
        }
        
        var val_19 = 0;
        label_21:
        if((val_19 < (val_3.Length << )) && (W10 < this.wedges.Length))
        {
                val_5.Add(item:  new WheelPrizeData() {prizeType = 1, prizeAmount = -1391022224});
        }
        
        if((val_19 < (val_4.Length << )) && (W10 < this.wedges.Length))
        {
                this.prizeList.Add(item:  new WheelPrizeData() {prizeType = 2, prizeAmount = -1391022224});
        }
        
        val_18 = this.wedges;
        if(W10 >= this.wedges.Length)
        {
            goto label_20;
        }
        
        var val_6 = (this.wedges.Length < 0) ? (this.wedges.Length + 1) : this.wedges.Length;
        val_19 = val_19 + 1;
        val_6 = val_6 >> 1;
        if(val_19 < (val_6 << ))
        {
            goto label_21;
        }
        
        label_20:
        var val_25 = 0;
        var val_24 = 4;
        label_33:
        var val_7 = val_24 - 4;
        if(val_7 >= this.wedges.Length)
        {
            goto label_22;
        }
        
        if(this.wedges.Length <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        BonusGameWheelWedge val_21 = val_18[0];
        if(val_21 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_9 = (this.wedges[0].icon == 1) ? 112 : 104;
        val_18[0].Init(rewardText:  val_21.ToString(), rewardIcon:  null);
        UnityEngine.Color val_10 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0.3f);
        int val_23 = this.wedges.Length;
        val_23 = val_25 + val_23;
        this.wedges[0].Flash(flashColor:  new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a}, flashDuration:  0.45f, startDelay:  (float)val_7 * 0.4f, endDelay:  (float)val_23 * 0.4f);
        val_24 = val_24 + 1;
        val_25 = val_25 - 1;
        if(this.wedges != null)
        {
            goto label_33;
        }
        
        label_22:
        this.buttonSpin.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BonusGameWheelPopup::Spin()));
        this.buttonCollect.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BonusGameWheelPopup::Collect()));
        this.buttonCollect.interactable = false;
        this.buttonSpin.interactable = true;
        this.buttonSpin.gameObject.SetActive(value:  true);
        this.buttonCollect.gameObject.SetActive(value:  false);
        this.buttonClose.gameObject.SetActive(value:  false);
        this.buttonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BonusGameWheelPopup::CloseProperly()));
    }
    public void SetOnClose(System.Action onClose)
    {
        System.Delegate val_3 = System.Delegate.Combine(a:  this.gameObject.GetComponent<WGWindow>(), b:  onClose);
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        mem2[0] = val_3;
        return;
        label_4:
    }
    private void Spin()
    {
        int val_42;
        this.buttonCollect.interactable = false;
        this.buttonSpin.interactable = false;
        var val_43 = 0;
        label_7:
        val_42 = this.wedges.Length;
        if(val_43 >= val_42)
        {
            goto label_4;
        }
        
        this.wedges[val_43].StopFlash();
        val_43 = val_43 + 1;
        if(this.wedges != null)
        {
            goto label_7;
        }
        
        throw new NullReferenceException();
        label_4:
        this.prizeIndex = UnityEngine.Random.Range(min:  0, max:  0);
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                if(BonusGameWheelPopup.QAHACK_ForceAwardType != 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            AwardType val_5 = BonusGameWheelPopup.QAHACK_ForceAwardType;
            float val_7 = UnityEngine.Mathf.Repeat(t:  (float)this.prizeIndex + 1, length:  (float)(BonusGameWheelPopup.__il2cppRuntimeField_cctor_finished + (this.prizeIndex) << 3) + 32);
            val_7 = (val_7 == Infinityf) ? (-(double)val_7) : ((double)val_7);
            int val_44 = (int)val_7;
            this.prizeIndex = val_44;
        }
        
        }
        
        if(val_44 <= this.prizeIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_44 = val_44 + ((this.prizeIndex) << 3);
        if(((val_7 == Infinityf ? val_7 : val_7 + (this.prizeIndex) << 3) + 32) == 2)
        {
            goto label_26;
        }
        
        if(((val_7 == Infinityf ? val_7 : val_7 + (this.prizeIndex) << 3) + 32) != 1)
        {
            goto label_43;
        }
        
        decimal val_10 = System.Decimal.op_Implicit(value:  ((val_7 == Infinityf ? val_7 : val_7 + (this.prizeIndex) << 3) + 32) >> 32);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, source:  this.trackEventSource, subSource:  "Bonus Game Wheel", externalParams:  0, doTrack:  true);
        goto label_33;
        label_26:
        GoldenApplesManager val_11 = MonoSingleton<GoldenApplesManager>.Instance;
        var val_12 = ((val_7 == Infinityf ? val_7 : val_7 + (this.prizeIndex) << 3) + 32) >> 32;
        WGWindow val_14 = this.gameObject.GetComponent<WGWindow>();
        System.Delegate val_17 = System.Delegate.Combine(a:  this.prizeIndex, b:  new System.Action(object:  MonoSingleton<WordGameEventsController>.Instance, method:  public System.Void WordGameEventsController::OnBonusGameGoldCurrencyRewardGranted()));
        if(val_17 != null)
        {
                if(null != null)
        {
            goto label_42;
        }
        
        }
        
        mem2[0] = val_17;
        label_33:
        if(this.OnRewarded != null)
        {
                this.OnRewarded.Invoke();
        }
        
        label_43:
        DG.Tweening.Sequence val_20 = DG.Tweening.DOTween.Sequence();
        UnityEngine.Vector3 val_21 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  this.pullbackDegree);
        DG.Tweening.Sequence val_24 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_20, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this.spinContainer, endValue:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z}, duration:  0.85f, mode:  3), ease:  6));
        float val_48 = 360f;
        float val_47 = -360f;
        float val_45 = (float)S8;
        float val_46 = (float)this.prizeIndex;
        val_45 = val_48 / val_45;
        val_46 = val_45 * val_46;
        val_47 = ((float)UnityEngine.Random.Range(min:  this.minSpinCount, max:  this.maxSpinCount + 1)) * val_47;
        val_46 = val_48 - val_46;
        val_46 = val_47 - val_46;
        val_45 = val_45 * (float)this.wheelOffset;
        DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_20, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.spinContainer.transform.parent, endValue:  0.96f, duration:  0.35f), ease:  6));
        UnityEngine.Vector3 val_31;
        val_48 = (val_46 - val_45) - this.pullbackDegree;
        val_31 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  val_48);
        DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_20, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this.spinContainer, endValue:  new UnityEngine.Vector3() {x = val_31.x, y = val_31.y, z = val_31.z}, duration:  this.spinDuration, mode:  3), ease:  21));
        DG.Tweening.Sequence val_39 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_20, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.spinContainer.transform.parent, endValue:  1f, duration:  0.2f), ease:  21));
        DG.Tweening.Sequence val_41 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_20, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BonusGameWheelPopup::OnSpinComplete()));
        this.wheelOffset = this.prizeIndex;
        return;
        label_42:
    }
    private void Collect()
    {
        this.buttonCollect.interactable = false;
        this.buttonSpin.interactable = false;
        this.wedges[this.prizeIndex].StopFlash();
        if(this.wedges[this.prizeIndex] <= this.prizeIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        BonusGameWheelWedge val_14 = this.wedges[this.prizeIndex][this.prizeIndex];
        if(val_14 == 2)
        {
            goto label_8;
        }
        
        if(val_14 != 1)
        {
            goto label_9;
        }
        
        this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void BonusGameWheelPopup::CloseProperly());
        Player val_2 = App.Player;
        val_14 = val_14 >> 32;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_14);
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = -1389142240, mid = 268435458}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        Player val_5 = App.Player;
        this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        return;
        label_8:
        mem2[0] = new System.Action(object:  this, method:  System.Void BonusGameWheelPopup::CloseProperly());
        Player val_7 = App.Player;
        Player val_8 = App.Player;
        decimal val_9 = System.Decimal.op_Implicit(value:  val_8._stars);
        this.goldenCurrencyAnimControl.Play(fromValue:  val_7._stars - (val_14 >> 32), toValue:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        return;
        label_9:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnSpinComplete()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.wedges[this.prizeIndex].Flash(flashColor:  new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a}, flashDuration:  0.5f, startDelay:  0f, endDelay:  0f);
        this.buttonCollect.interactable = true;
        this.buttonSpin.interactable = false;
        this.buttonSpin.gameObject.SetActive(value:  false);
        this.buttonCollect.gameObject.SetActive(value:  true);
    }
    private UnityEngine.Sprite GetAwardIcon(BonusGameWheelPopup.AwardType _type)
    {
        var val_1 = (_type == 1) ? 112 : 104;
        return (UnityEngine.Sprite)null;
    }
    private T[] ShuffleAwardArray<T>(T[] originalArray)
    {
        RandomSet val_1 = new RandomSet();
        val_1.addIntRange(lowest:  0, highest:  originalArray.Length - 1);
        if((__RuntimeMethodHiddenParam + 48 + 24) < 1)
        {
                return (T[])__RuntimeMethodHiddenParam + 48;
        }
        
        var val_6 = 0;
        var val_3 = (__RuntimeMethodHiddenParam + 48) + 32;
        do
        {
            mem2[0] = originalArray[(val_1.roll(unweighted:  false)) << 2];
            val_6 = val_6 + 1;
        }
        while(val_6 < ((__RuntimeMethodHiddenParam + 48 + 24) << ));
        
        return (T[])__RuntimeMethodHiddenParam + 48;
    }
    private void CloseProperly()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public static BonusGameWheelPopup.AwardType get_QAHACK_ForceAwardType()
    {
        var val_3;
        AwardType val_4;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_3 = null;
            val_3 = null;
            val_4 = BonusGameWheelPopup.qaHackFlagAwardType;
            return (AwardType)val_4;
        }
        
        val_4 = 0;
        return (AwardType)val_4;
    }
    public static void set_QAHACK_ForceAwardType(BonusGameWheelPopup.AwardType value)
    {
        var val_3;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        BonusGameWheelPopup.qaHackFlagAwardType = value;
    }
    public BonusGameWheelPopup()
    {
        this.pullbackDegree = 15f;
        this.trackEventSource = "Bonus Game Wheel";
    }
    private static BonusGameWheelPopup()
    {
    
    }

}
