using UnityEngine;
public class FPHPlayButton : ButtonPlayGame
{
    // Fields
    private UnityEngine.UI.Text entryCostText;
    private CoinCurrencyCollectAnimationInstantiator coinAnim;
    private UnityEngine.Transform coinFlyTo;
    private bool showInterstitialAd;
    private bool cancelButtonActionOnContinue;
    public System.Action<bool> onPlayResult;
    public System.Action OnAnimationStarted;
    public System.Action overridePlayButtonClick;
    
    // Properties
    private int entryCost { get; }
    public bool SetCancelButtonActionOnContinue { set; }
    private bool showContinueState { get; }
    
    // Methods
    private int get_entryCost()
    {
        FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
        return (int)val_1.levelEntryFee;
    }
    public void set_SetCancelButtonActionOnContinue(bool value)
    {
        this.cancelButtonActionOnContinue = value;
    }
    private bool get_showContinueState()
    {
        UnityEngine.Object val_10;
        var val_11;
        val_10 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                if((MonoSingleton<FPHDataParser>.Instance.CanResumeGame()) != false)
        {
                val_11 = 1;
            return (bool)val_11;
        }
        
        }
        
        GameBehavior val_4 = App.getBehavior;
        if((val_4.<metaGameBehavior>k__BackingField) == 2)
        {
                val_10 = FPHGameplayController.Instance;
            if(val_10 != 0)
        {
                FPHGameplayController val_7 = FPHGameplayController.Instance;
            if(val_7.currentGame != null)
        {
                FPHGameplayController val_8 = FPHGameplayController.Instance;
            var val_9 = (val_8.currentGame.hasCollectedChest == false) ? 1 : 0;
            return (bool)val_11;
        }
        
        }
        
        }
        
        val_11 = 0;
        return (bool)val_11;
    }
    protected override void Start()
    {
        this.Start();
        mem[1152921515977193752] = 1;
        this.UpdateUI();
    }
    public override void OnButtonClick()
    {
        var val_21;
        var val_22;
        var val_23;
        if(this.overridePlayButtonClick != null)
        {
                this.overridePlayButtonClick.Invoke();
            return;
        }
        
        if(this.overridePlayButtonClick.showContinueState != false)
        {
                val_21 = null;
            val_21 = null;
            FPHGameplayController.currentGameplayMode = 0;
            if(this.onPlayResult != null)
        {
                this.onPlayResult.Invoke(obj:  true);
        }
        
            this.onPlayResult = 0;
            if(this.cancelButtonActionOnContinue != false)
        {
                GameBehavior val_2 = App.getBehavior;
            if((val_2.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        }
        
            this.OnButtonClick();
            return;
        }
        
        decimal val_5 = System.Decimal.op_Implicit(value:  App.Player.entryCost);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid})) != false)
        {
                if(this.showInterstitialAd != false)
        {
                bool val_8 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
        }
        
            if(this.OnAnimationStarted != null)
        {
                this.OnAnimationStarted.Invoke();
        }
        
            WGAudioController val_9 = MonoSingleton<WGAudioController>.Instance;
            val_9.sound.PlayGeneralSound(type:  2, oneshot:  true, pitch:  1f, vol:  1f);
            decimal val_11 = System.Decimal.op_Implicit(value:  val_9.sound.entryCost);
            bool val_12 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, source:  "Level Start", externalParams:  0, animated:  true);
            val_22 = null;
            val_22 = null;
            FPHGameplayController.currentGameplayMode = 0;
            UnityEngine.Vector3 val_13 = this.coinFlyTo.position;
            int val_14 = this.coinFlyTo.entryCost;
            PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, particleCount:  0, animateStatView:  false);
            interactable = false;
            UUI_EventsController.DisableInputs();
            UnityEngine.ParticleSystem val_15 = this.GetComponentInChildren<UnityEngine.ParticleSystem>();
            if(val_15 != 0)
        {
                val_15.Stop(withChildren:  true, stopBehavior:  0);
        }
        
            UnityEngine.Coroutine val_18 = this.StartCoroutine(routine:  this.WaitForCoinAnimation());
            return;
        }
        
        val_23 = null;
        val_23 = null;
        PurchaseProxy.currentPurchasePoint = 123;
        GameBehavior val_19 = App.getBehavior;
        val_19.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  0);
        if(this.onPlayResult != null)
        {
                this.onPlayResult.Invoke(obj:  false);
        }
        
        this.onPlayResult = 0;
    }
    private void UpdateUI()
    {
        UnityEngine.GameObject val_2 = this.coinFlyTo.gameObject;
        if(this.showContinueState != false)
        {
                val_2.SetActive(value:  false);
            return;
        }
        
        val_2.SetActive(value:  true);
        string val_4 = val_2.entryCost.ToString();
        this.SetupPlayText();
    }
    private System.Collections.IEnumerator WaitForCoinAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new FPHPlayButton.<WaitForCoinAnimation>d__17();
    }
    public FPHPlayButton()
    {
    
    }
    private void <>n__0()
    {
        this.OnButtonClick();
    }

}
