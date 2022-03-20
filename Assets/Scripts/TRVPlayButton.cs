using UnityEngine;
public class TRVPlayButton : ButtonPlayGame
{
    // Fields
    private TweenCoinsText entryCostText;
    private CoinCurrencyCollectAnimationInstantiator coinAnim;
    private UnityEngine.Transform coinFlyTo;
    private int costStartLevel;
    private UnityEngine.GameObject playTextGO;
    private UnityEngine.GameObject playTextFtuxGO;
    
    // Properties
    private int entryCost { get; }
    
    // Methods
    private int get_entryCost()
    {
        return App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost;
    }
    protected override void Start()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnStarMultiChanged");
        this.Start();
        mem[1152921517320805976] = 1;
        this.playTextFtuxGO.SetActive(value:  false);
        this.playTextGO.SetActive(value:  false);
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) >= this.costStartLevel)
        {
            goto label_10;
        }
        
        this.coinFlyTo.gameObject.SetActive(value:  false);
        if(this.playTextFtuxGO != null)
        {
            goto label_13;
        }
        
        label_10:
        decimal val_5 = System.Decimal.op_Implicit(value:  val_2.<metaGameBehavior>k__BackingField.entryCost);
        this.entryCostText.Set(instantValue:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        label_13:
        this.playTextGO.SetActive(value:  true);
    }
    public override void OnButtonClick()
    {
        var val_17;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) < this.costStartLevel)
        {
                val_1.<metaGameBehavior>k__BackingField.interactable = false;
            this.OnButtonClick();
            return;
        }
        
        decimal val_4 = System.Decimal.op_Implicit(value:  App.Player.entryCost);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})) != false)
        {
                WGAudioController val_6 = MonoSingleton<WGAudioController>.Instance;
            val_6.sound.PlayGeneralSound(type:  2, oneshot:  true, pitch:  1f, vol:  1f);
            int val_7 = val_6.sound.entryCost;
            decimal val_8 = System.Decimal.op_Implicit(value:  val_7);
            bool val_9 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, source:  "Start Quiz", externalParams:  0, animated:  true);
            UnityEngine.Vector3 val_10 = this.coinFlyTo.position;
            int val_11 = this.coinFlyTo.entryCost;
            val_7.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, particleCount:  0, animateStatView:  false);
            val_7.interactable = false;
            UUI_EventsController.DisableInputs();
            this.GetComponentInChildren<UnityEngine.ParticleSystem>().Stop(withChildren:  true, stopBehavior:  0);
            UnityEngine.Coroutine val_14 = this.StartCoroutine(routine:  this.WaitForCoinAnimation());
            return;
        }
        
        val_17 = null;
        val_17 = null;
        PurchaseProxy.currentPurchasePoint = 0;
        GameBehavior val_15 = App.getBehavior;
        val_15.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  0);
    }
    private System.Collections.IEnumerator WaitForCoinAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVPlayButton.<WaitForCoinAnimation>d__10();
    }
    private void OnDisable()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnStarMultiChanged");
    }
    private void OnStarMultiChanged()
    {
        decimal val_2 = System.Decimal.op_Implicit(value:  this.entryCost);
        this.entryCostText.CountUp(endValue:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, seconds:  0.2f);
    }
    public TRVPlayButton()
    {
        this.costStartLevel = 3;
    }
    private void <>n__0()
    {
        this.OnButtonClick();
    }

}
