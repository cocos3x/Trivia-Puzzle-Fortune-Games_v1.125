using UnityEngine;
public class WGAlphabetCollectionBoxPopup : MonoBehaviour
{
    // Fields
    private AlphabetBoxItem alphabetBoxItemPrefab;
    private UnityEngine.GameObject greenTileGlowObject;
    private UnityEngine.RectTransform[] boxItemsParentRows;
    private int boxItemsPerRow;
    private AlphabetWordRegion wordRegion;
    private UnityEngine.GameObject coinRewardGroup;
    private UnityEngine.UI.Text rewardAmount;
    private UnityEngine.UI.Text redrawCost;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button redrawButton;
    private UnityEngine.GameObject ftuxTooltip;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private UnityEngine.UI.Button skipButton;
    private System.Collections.Generic.List<AlphabetBoxItem> alphabetBoxItems;
    private System.Collections.Generic.List<WGAlphabetCollectionBoxPopup.Word_Index> currentCollectedLetters;
    private decimal currentCollectionRewardAmount;
    private System.Collections.Generic.List<string> CurrentCollectionBoxLetters;
    private bool hasDrawn;
    private bool skip;
    private readonly UnityEngine.Color[] rarityColors;
    private readonly UnityEngine.Color duplicateColor;
    private bool setupForPurchase;
    private bool setupForKeyToRiches;
    
    // Properties
    private AlphabetBoxItem alphabetBoxItemPrefabLoaded { get; }
    private UnityEngine.GameObject alphabetCoinParticle { get; }
    
    // Methods
    private AlphabetBoxItem get_alphabetBoxItemPrefabLoaded()
    {
        AlphabetBoxItem val_3;
        if(this.alphabetBoxItemPrefab == 0)
        {
                this.alphabetBoxItemPrefab = PrefabLoader.LoadPrefab<AlphabetBoxItem>(featureName:  "AlphabetBoxItem");
            return val_3;
        }
        
        val_3 = this.alphabetBoxItemPrefab;
        return val_3;
    }
    private UnityEngine.GameObject get_alphabetCoinParticle()
    {
        return PrefabLoader.LoadPrefab(featureName:  "CoinParticles", prefabName:  "coin_explosion");
    }
    private void Start()
    {
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionBoxPopup::onClick_ContinueButton()));
        this.redrawButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionBoxPopup::onClick_RedrawButton()));
        this.skipButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionBoxPopup::onClick_SkipButton()));
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.SetupUI());
    }
    private void onClick_SkipButton()
    {
        this.skip = true;
    }
    public void SetupUIForPurchase(System.Collections.Generic.List<string> purchasedTiles)
    {
        this.setupForPurchase = true;
        this.redrawButton.gameObject.SetActive(value:  false);
        this.CurrentCollectionBoxLetters = purchasedTiles;
    }
    public void SetupUIForKeyToRiches(System.Collections.Generic.List<string> rewardedTiles)
    {
        this.setupForKeyToRiches = true;
        this.redrawButton.gameObject.SetActive(value:  false);
        this.CurrentCollectionBoxLetters = rewardedTiles;
    }
    private System.Collections.IEnumerator SetupUI()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGAlphabetCollectionBoxPopup.<SetupUI>d__32();
    }
    private System.Collections.IEnumerator ShowTooltipBeforeAnimating()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGAlphabetCollectionBoxPopup.<ShowTooltipBeforeAnimating>d__33();
    }
    private System.Collections.IEnumerator AnimateCollecting()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGAlphabetCollectionBoxPopup.<AnimateCollecting>d__34();
    }
    private void onClick_RedrawButton()
    {
        var val_20;
        var val_21;
        System.Action val_23;
        decimal val_2 = MonoSingleton<Alphabet2Manager>.Instance.GetRedrawCost;
        Player val_3 = App.Player;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid})) != false)
        {
                val_20 = null;
            val_20 = null;
            PurchaseProxy.currentPurchasePoint = 50;
            val_21 = null;
            val_21 = null;
            val_23 = WGAlphabetCollectionBoxPopup.<>c.<>9__35_0;
            if(val_23 == null)
        {
                System.Action val_7 = null;
            val_23 = val_7;
            val_7 = new System.Action(object:  WGAlphabetCollectionBoxPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGAlphabetCollectionBoxPopup.<>c::<onClick_RedrawButton>b__35_0());
            WGAlphabetCollectionBoxPopup.<>c.<>9__35_0 = val_23;
        }
        
            MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  val_7);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  true, dontDestroyOnDisable:  true);
            return;
        }
        
        bool val_9 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "Alphabet Tile Redraw", externalParams:  0, animated:  false);
        Player val_10 = App.Player;
        this.coinsAnimControl.Set(instantValue:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits, lo = -1449588912, mid = 268435458});
        if(this.setupForKeyToRiches == false)
        {
            goto label_28;
        }
        
        System.Collections.Generic.List<System.String> val_11 = KeyToRichesEventHandler._Instance.RerollLetters();
        goto label_31;
        label_28:
        if(this.setupForPurchase == false)
        {
            goto label_32;
        }
        
        label_31:
        this.CurrentCollectionBoxLetters = MonoSingleton<LimitedTimeBundlesManager>.Instance.RerollLettersForLastBundlePurchase();
        label_43:
        Alphabet2Manager val_14 = MonoSingleton<Alphabet2Manager>.Instance;
        val_14.LifetimeRedrawsUsed = val_14.LifetimeRedrawsUsed + 1;
        UnityEngine.Coroutine val_18 = this.StartCoroutine(routine:  this.SetupUI());
        return;
        label_32:
        MonoSingleton<Alphabet2Manager>.Instance.ClearAndFillCollectionBox(tileCount:  val_10._credits);
        goto label_43;
    }
    private void SaveCollection()
    {
        var val_5;
        string val_6;
        if((this.setupForPurchase != true) && (this.setupForKeyToRiches != true))
        {
                MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionBox.Clear();
        }
        
        MonoSingleton<Alphabet2Manager>.Instance.CollectFTUXBox();
        List.Enumerator<T> val_4 = this.currentCollectedLetters.GetEnumerator();
        label_15:
        if(val_5.MoveNext() == false)
        {
            goto label_11;
        }
        
        Alphabet2Manager val_8 = MonoSingleton<Alphabet2Manager>.Instance;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.CollectTileFromBox(word:  val_6, letterIndex:  val_6);
        goto label_15;
        label_11:
        val_5.Dispose();
        App.Player.SaveState();
    }
    private void onClick_ContinueButton()
    {
        this.SaveCollection();
        if(this.setupForKeyToRiches != true)
        {
                if(this.setupForPurchase == false)
        {
            goto label_6;
        }
        
        }
        
        if((MonoSingleton<Alphabet2Manager>.Instance.IsCurrentCollectionComplete()) != false)
        {
                GameBehavior val_3 = App.getBehavior;
        }
        else
        {
                label_6:
            WGWindowManager val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAlphabetCollectionPopup>(showNext:  true);
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  true, dontDestroyOnDisable:  false);
    }
    public WGAlphabetCollectionBoxPopup()
    {
        this.boxItemsPerRow = 5;
        this.alphabetBoxItems = new System.Collections.Generic.List<AlphabetBoxItem>();
        this.currentCollectedLetters = new System.Collections.Generic.List<Word_Index>();
        UnityEngine.Color[] val_3 = new UnityEngine.Color[4];
        UnityEngine.Color val_4 = new UnityEngine.Color(r:  0.1254902f, g:  0.9843137f, b:  0.1254902f);
        val_3[0] = val_4.r;
        UnityEngine.Color val_5 = new UnityEngine.Color(r:  0.02352941f, g:  0.454902f, b:  0.9882353f);
        val_3[2] = val_5.r;
        UnityEngine.Color val_6 = new UnityEngine.Color(r:  0.6588235f, g:  0f, b:  1f);
        val_3[4] = val_6.r;
        UnityEngine.Color val_7 = new UnityEngine.Color(r:  1f, g:  0.6117647f, b:  0f);
        UnityEngine.Color val_8;
        val_3[6] = val_7.r;
        this.rarityColors = val_3;
        val_8 = new UnityEngine.Color(r:  0.9176471f, g:  1f, b:  0f);
        this.duplicateColor = val_8.r;
    }

}
