using UnityEngine;
public class TRVYouBetchaBetPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button betButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button noThanksButton;
    private GemsCollectAnimationInstantiator gcAnim;
    private CoinCurrencyCollectAnimationInstantiator cAnim;
    private UnityEngine.UI.Text betCostText;
    private UnityEngine.UI.Text bestDescText;
    
    // Methods
    private void OnEnable()
    {
        this.betButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVYouBetchaBetPopup::OnBetPressed()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVYouBetchaBetPopup::OnClose()));
        this.noThanksButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVYouBetchaBetPopup::OnClose()));
        string val_4 = TRVYouBetchaEventHandler.EVENT_TRACKING_ID + 44.ToString();
        float val_7 = TRVYouBetchaEventHandler.EVENT_TRACKING_ID + 48;
        val_7 = val_7 + 1f;
        string val_6 = System.String.Format(format:  Localization.Localize(key:  "you_betcha_bet_popup", defaultValue:  "Get {0}x your bet\nif you get the\nnext question right!", useSingularKey:  false), arg0:  val_7);
    }
    private void Start()
    {
    
    }
    private void OnClose()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickCoinBalance()
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = 114;
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  0);
    }
    private void OnClickGemBalance()
    {
        var val_4;
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        val_4 = null;
        val_4 = null;
        PurchaseProxy.currentPurchasePoint = 114;
        GameBehavior val_2 = App.getBehavior;
        val_2.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  0);
    }
    private void OnBetPressed()
    {
        var val_12;
        if(TRVYouBetchaEventHandler.EVENT_TRACKING_ID.TryPlaceBet() != false)
        {
                UnityEngine.Vector3 val_3 = this.betCostText.transform.position;
            var val_12 = TRVYouBetchaEventHandler.EVENT_TRACKING_ID + 44;
            val_12 = val_12 * 1717986919;
            val_12 = val_12 >> 34;
            PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, particleCount:  val_12 + (val_12 >> 63), animateStatView:  true);
            this.betButton.interactable = false;
            this.closeButton.interactable = false;
            this.noThanksButton.interactable = false;
            UUI_EventsController.DisableInputs();
            this.GetComponentInChildren<UnityEngine.ParticleSystem>().Stop(withChildren:  true, stopBehavior:  0);
            WGAudioController val_7 = MonoSingleton<WGAudioController>.Instance;
            val_7.sound.PlayGeneralSound(type:  2, oneshot:  true, pitch:  1f, vol:  1f);
            UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this.WaitForCoinAnimation());
            return;
        }
        
        val_12 = null;
        val_12 = null;
        PurchaseProxy.currentPurchasePoint = 114;
        GameBehavior val_10 = App.getBehavior;
        val_10.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  0);
    }
    private System.Collections.IEnumerator WaitForCoinAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVYouBetchaBetPopup.<WaitForCoinAnimation>d__13();
    }
    public TRVYouBetchaBetPopup()
    {
    
    }

}
