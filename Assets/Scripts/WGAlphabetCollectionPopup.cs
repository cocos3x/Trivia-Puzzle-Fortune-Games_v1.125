using UnityEngine;
public class WGAlphabetCollectionPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject progressWindow;
    private UnityEngine.GameObject completeWindow;
    private UnityEngine.GameObject infoWindow;
    private AlphabetWordRegion wordRegion;
    private UnityEngine.UI.Slider progressSlider;
    private UnityEngine.UI.Text sliderLabel;
    private UnityEngine.GameObject progressCoinRewardGroup;
    private UnityEngine.UI.Text rewardAmount;
    private UnityEngine.UI.Button infoButton;
    private UnityEngine.UI.Button closeInfoButton;
    private UnityEngine.UI.Button closeButton;
    private AlphabetWordRegion wordRegionComplete;
    private UnityEngine.GameObject completeCoinRewardGroup;
    private UnityEngine.UI.Text rewardAmountComplete;
    private UnityEngine.UI.Button collectButton;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private bool startInfo;
    
    // Properties
    private UnityEngine.GameObject collectParticle { get; }
    
    // Methods
    private UnityEngine.GameObject get_collectParticle()
    {
        return PrefabLoader.LoadPrefab(featureName:  "CoinParticles", prefabName:  "coin_explosion_rain");
    }
    public void SetupWithInfo()
    {
        this.startInfo = true;
    }
    private void Start()
    {
        this.Setup();
        this.infoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionPopup::ShowInfoWindow()));
        this.closeInfoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionPopup::onClick_CloseInfo()));
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionPopup::onClick_Collect()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionPopup::onClick_Close()));
    }
    private void Setup()
    {
        UnityEngine.UI.Text val_24;
        System.Collections.Generic.List<System.String> val_25;
        val_24 = this;
        if(this.startInfo != false)
        {
                this.ShowInfoWindow();
            return;
        }
        
        if((MonoSingleton<Alphabet2Manager>.Instance.IsCurrentCollectionComplete()) != false)
        {
                this.progressWindow.SetActive(value:  false);
            this.infoWindow.SetActive(value:  false);
            this.completeWindow.SetActive(value:  true);
            val_25 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollection;
            this.wordRegionComplete.Setup(requiredWords:  val_25, progressWords:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionProgress);
            this.completeCoinRewardGroup.SetActive(value:  true);
            val_24 = this.rewardAmountComplete;
        }
        else
        {
                this.progressWindow.SetActive(value:  true);
            this.infoWindow.SetActive(value:  false);
            this.completeWindow.SetActive(value:  false);
            System.Collections.Generic.List<System.String> val_8 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollection;
            this.wordRegion.Setup(requiredWords:  val_8, progressWords:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionProgress);
            System.Collections.Generic.List<System.String> val_12 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionBox;
            Alphabet2Manager val_13 = MonoSingleton<Alphabet2Manager>.Instance;
            float val_24 = (float)val_13.tilesPerCollectionBox;
            val_24 = (float)val_8 / val_24;
            System.Collections.Generic.List<System.String> val_15 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionBox;
            val_25 = null.ToString();
            Alphabet2Manager val_17 = MonoSingleton<Alphabet2Manager>.Instance;
            string val_19 = System.String.Format(format:  "{0}/{1}", arg0:  val_25, arg1:  val_17.tilesPerCollectionBox.ToString());
            this.progressCoinRewardGroup.SetActive(value:  true);
            val_24 = this.rewardAmount;
        }
        
        decimal val_21 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentRewardAmount;
        GameEcon val_22 = App.getGameEcon;
        string val_23 = val_21.flags.ToString(format:  val_22.numberFormatInt);
    }
    private void onClick_Info()
    {
        this.ShowInfoWindow();
    }
    private void onClick_CloseInfo()
    {
        if(this.startInfo != false)
        {
                this.startInfo = false;
            this.Setup();
            return;
        }
        
        this.progressWindow.SetActive(value:  true);
        this.infoWindow.SetActive(value:  false);
    }
    private void onClick_Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void ShowInfoWindow()
    {
        this.progressWindow.SetActive(value:  false);
        this.infoWindow.SetActive(value:  true);
    }
    private void onClick_Collect()
    {
        this.collectButton.interactable = false;
        decimal val_2 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentRewardAmount;
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "Alphabet Collection", externalParams:  0, animated:  false);
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.PlayCelebrationAnimation());
        MonoSingleton<Alphabet2Manager>.Instance.CompleteCurrentCollection();
    }
    private System.Collections.IEnumerator PlayCelebrationAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGAlphabetCollectionPopup.<PlayCelebrationAnimation>d__28();
    }
    private void OnCoinsAnimFinished()
    {
        this.Setup();
    }
    public WGAlphabetCollectionPopup()
    {
    
    }

}
