using UnityEngine;
public class GameStoreUI : MonoSingleton<GameStoreUI>, IStoreUI
{
    // Fields
    private UnityEngine.UI.Button button_back;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private CurrencyCollectAnimationInstantiator gemAnimControl;
    private CurrencyCollectAnimationInstantiator goldCurrencyAnimControl;
    private CurrencyCollectAnimationInstantiator spinAnimControl;
    private WADPetFoodAnimationInstantiator foodAnimControl;
    private DiceRollAnimationInstantiator diceAnimControl;
    private UnityEngine.Transform xfm_category_content;
    private UnityEngine.UI.ScrollRect _scroll_category_content;
    private UnityEngine.CanvasGroup _canvas_category_content;
    private bool canPurchase;
    private bool didPurchase;
    private System.Collections.Generic.List<PurchaseModel> _Packages;
    private System.Collections.Generic.List<PurchaseModel> _PetsFoodPackages;
    private System.Collections.Generic.List<PurchaseModel> _GemPackages;
    private System.Collections.Generic.List<PurchaseModel> _SpinPackages;
    private System.Collections.Generic.Dictionary<string, GameStoreCategory> storeCategories;
    private System.Collections.Generic.Dictionary<string, float> normalishCategoryPositions;
    private System.Collections.Generic.List<WGStoreItem> packItems;
    private System.Collections.Generic.List<WGStoreItem_pet> foodPackItems;
    private System.Collections.Generic.List<WGStoreItem_gems> gemPackItems;
    private System.Collections.Generic.List<WGStoreItem_spins> spinPackItems;
    private WGStoreItem_NoAds noAdsItem;
    private System.Collections.Generic.Dictionary<string, WGStoreItem> standardPackItems;
    private float lastScrollPosition;
    public static TrackerPurchasePoints windowEntryPoint;
    public static System.Action OnRefreshDisplay;
    public static System.Action OnCreatePackItems;
    public static System.Action OnRewardAnimationsComplete;
    
    // Properties
    private UnityEngine.GameObject Prefab_PackItem { get; }
    private UnityEngine.GameObject Prefab_PackFoodItem { get; }
    private UnityEngine.GameObject Prefab_PackGemItem { get; }
    private UnityEngine.GameObject Prefab_goldenTicketItem { get; }
    private UnityEngine.GameObject Prefab_silverTicketItem { get; }
    private UnityEngine.GameObject Prefab_PackSpinItem { get; }
    private UnityEngine.GameObject Prefab_BonusRewardHeader { get; }
    private UnityEngine.GameObject Prefab_PackNoAdsItem { get; }
    public UnityEngine.GameObject Prefab_storePetFoodItem { get; }
    private GameStoreCategory Prefab_StoreCategory { get; }
    private UnityEngine.UI.ScrollRect scroll_category_content { get; }
    private UnityEngine.CanvasGroup canvas_category_content { get; }
    private System.Collections.Generic.List<PurchaseModel> Packages { get; }
    private System.Collections.Generic.List<PurchaseModel> PetsFoodPackages { get; }
    private System.Collections.Generic.List<PurchaseModel> GemPackages { get; }
    private System.Collections.Generic.List<PurchaseModel> SpinPackages { get; }
    public int CoinPackItemsCount { get; }
    
    // Methods
    private UnityEngine.GameObject get_Prefab_PackItem()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Store", prefabName:  "WGStoreItem");
    }
    private UnityEngine.GameObject get_Prefab_PackFoodItem()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Store", prefabName:  "WGPetFoodStoreItem");
    }
    private UnityEngine.GameObject get_Prefab_PackGemItem()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Store", prefabName:  "WGStoreItem_gems");
    }
    private UnityEngine.GameObject get_Prefab_goldenTicketItem()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Store", prefabName:  "WGStoreGoldenTicket");
    }
    private UnityEngine.GameObject get_Prefab_silverTicketItem()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Store", prefabName:  "WGStoreSilverTicket");
    }
    private UnityEngine.GameObject get_Prefab_PackSpinItem()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Store", prefabName:  "WGStoreItem_spins");
    }
    private UnityEngine.GameObject get_Prefab_BonusRewardHeader()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Store", prefabName:  "WGBonusRewardsStoreDisplay");
    }
    private UnityEngine.GameObject get_Prefab_PackNoAdsItem()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Store", prefabName:  "WGStoreItem_noAds");
    }
    public UnityEngine.GameObject get_Prefab_storePetFoodItem()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Store", prefabName:  "WGPetFoodStoreItem");
    }
    private GameStoreCategory get_Prefab_StoreCategory()
    {
        return PrefabLoader.LoadPrefab<GameStoreCategory>(featureName:  "Store");
    }
    private UnityEngine.UI.ScrollRect get_scroll_category_content()
    {
        UnityEngine.UI.ScrollRect val_3;
        if(this._scroll_category_content == 0)
        {
                this._scroll_category_content = this.xfm_category_content.GetComponent<UnityEngine.UI.ScrollRect>();
            return val_3;
        }
        
        val_3 = this._scroll_category_content;
        return val_3;
    }
    private UnityEngine.CanvasGroup get_canvas_category_content()
    {
        UnityEngine.CanvasGroup val_3;
        if(this._canvas_category_content == 0)
        {
                this._canvas_category_content = this.xfm_category_content.GetComponent<UnityEngine.CanvasGroup>();
            return val_3;
        }
        
        val_3 = this._canvas_category_content;
        return val_3;
    }
    private System.Collections.Generic.List<PurchaseModel> get_Packages()
    {
        System.Collections.Generic.List<PurchaseModel> val_5;
        if(this._Packages != null)
        {
                if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_5;
        }
        
        }
        
        this._Packages = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrievePurchasePacks();
        return val_5;
        label_5:
        val_5 = this._Packages;
        return val_5;
    }
    private System.Collections.Generic.List<PurchaseModel> get_PetsFoodPackages()
    {
        System.Collections.Generic.List<PurchaseModel> val_5;
        if(this._PetsFoodPackages != null)
        {
                if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_5;
        }
        
        }
        
        this._PetsFoodPackages = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrievePetsFoodPurchasePacks();
        return val_5;
        label_5:
        val_5 = this._PetsFoodPackages;
        return val_5;
    }
    private System.Collections.Generic.List<PurchaseModel> get_GemPackages()
    {
        System.Collections.Generic.List<PurchaseModel> val_5;
        if(this._GemPackages != null)
        {
                if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_5;
        }
        
        }
        
        this._GemPackages = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrieveGemPurchasePacks();
        return val_5;
        label_5:
        val_5 = this._GemPackages;
        return val_5;
    }
    private System.Collections.Generic.List<PurchaseModel> get_SpinPackages()
    {
        System.Collections.Generic.List<PurchaseModel> val_5;
        if(this._SpinPackages != null)
        {
                if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_5;
        }
        
        }
        
        this._SpinPackages = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrieveSpinPurchasePacks();
        return val_5;
        label_5:
        val_5 = this._SpinPackages;
        return val_5;
    }
    public int get_CoinPackItemsCount()
    {
        var val_1;
        if(this.packItems != null)
        {
                return (int)val_1;
        }
        
        val_1 = 0;
        return (int)val_1;
    }
    public override void InitMonoSingleton()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.button_back)) != false)
        {
                this.button_back.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(GameStoreUI).__il2cppRuntimeField_1E8));
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnPurchaseNoAdsPackSuccess");
    }
    private void Start()
    {
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void GameStoreUI::HandleBackButtonClose()));
        if((MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance.DisableSnapshottedCameras();
        }
        
        this.AdjustLowerRowStatViews();
        if(this.coinsAnimControl != 0)
        {
                if(this.coinsAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.gemAnimControl != 0)
        {
                if(this.gemAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.goldCurrencyAnimControl != 0)
        {
                if(this.goldCurrencyAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.foodAnimControl != 0)
        {
                if(this.foodAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.spinAnimControl != 0)
        {
                if(this.spinAnimControl != 0)
        {
                mem2[0] = 0;
        }
        
        }
        
        if(this.diceAnimControl == 0)
        {
                return;
        }
        
        if(this.diceAnimControl == 0)
        {
                return;
        }
        
        mem2[0] = 0;
    }
    private void OnEnable()
    {
        this.didPurchase = false;
        SLCDebug.Log(logMessage:  "GameStoreUI.OnEnable :: canPurchase = true", colorHash:  "#19A1DF", isError:  false);
        this.canPurchase = true;
        this.button_back.interactable = true;
        this.RefreshPackItemDisplays();
        Player val_1 = App.Player;
        this.coinsAnimControl.Set(instantValue:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits});
    }
    private void AdjustFoodStatView()
    {
        var val_6;
        var val_7;
        if(this.foodAnimControl == 0)
        {
                return;
        }
        
        UnityEngine.Vector2 val_3 = this.foodAnimControl.GetComponent<UnityEngine.RectTransform>().anchoredPosition;
        val_6 = null;
        val_6 = null;
        if(App.game != 1)
        {
            goto label_11;
        }
        
        goto label_12;
        label_11:
        val_7 = null;
        val_7 = null;
        if(App.game != 4)
        {
            goto label_18;
        }
        
        label_12:
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  -50f, y:  -75f);
        label_18:
        this.foodAnimControl.GetComponent<UnityEngine.RectTransform>().anchoredPosition = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
    }
    private void AdjustLowerRowStatViews()
    {
        var val_11;
        if(this.foodAnimControl == 0)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        UnityEngine.Vector2 val_4 = this.foodAnimControl.GetComponent<UnityEngine.RectTransform>().anchoredPosition;
        if(this.diceAnimControl != 0)
        {
                GameBehavior val_6 = App.getBehavior;
            val_11 = val_6.<metaGameBehavior>k__BackingField;
        }
        else
        {
                val_11 = 0;
        }
        
        this.foodAnimControl.GetComponent<UnityEngine.RectTransform>().anchoredPosition = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
        this.diceAnimControl.gameObject.SetActive(value:  val_11 & 1);
        if((val_11 & 1) == 0)
        {
                return;
        }
        
        UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  220f, y:  -90f);
        this.diceAnimControl.GetComponent<UnityEngine.RectTransform>().anchoredPosition = new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
    }
    public void RefreshPackItemDisplays()
    {
        var val_19;
        System.Func<PurchaseModel, System.Boolean> val_21;
        var val_22;
        var val_23;
        System.Func<PurchaseModel, System.Boolean> val_25;
        var val_26;
        var val_27;
        System.Action val_28;
        var val_29;
        if(this.packItems != null)
        {
                if(this.packItems > 0)
        {
            goto label_2;
        }
        
        }
        
        this.CreatePackItems();
        label_2:
        if(this.noAdsItem != 0)
        {
                val_19 = null;
            val_19 = null;
            val_21 = GameStoreUI.<>c.<>9__68_0;
            if(val_21 == null)
        {
                System.Func<PurchaseModel, System.Boolean> val_3 = null;
            val_21 = val_3;
            val_3 = new System.Func<PurchaseModel, System.Boolean>(object:  GameStoreUI.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean GameStoreUI.<>c::<RefreshPackItemDisplays>b__68_0(PurchaseModel x));
            GameStoreUI.<>c.<>9__68_0 = val_21;
        }
        
            PurchaseModel val_4 = System.Linq.Enumerable.FirstOrDefault<PurchaseModel>(source:  this.Packages, predicate:  val_3);
            val_22 = val_4;
            if(val_4 == null)
        {
                val_23 = null;
            val_23 = null;
            val_25 = GameStoreUI.<>c.<>9__68_1;
            if(val_25 == null)
        {
                System.Func<PurchaseModel, System.Boolean> val_6 = null;
            val_25 = val_6;
            val_6 = new System.Func<PurchaseModel, System.Boolean>(object:  GameStoreUI.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean GameStoreUI.<>c::<RefreshPackItemDisplays>b__68_1(PurchaseModel x));
            GameStoreUI.<>c.<>9__68_1 = val_25;
        }
        
            val_22 = System.Linq.Enumerable.FirstOrDefault<PurchaseModel>(source:  this.GemPackages, predicate:  val_6);
        }
        
            if(val_22 != null)
        {
            
        }
        else
        {
                this.noAdsItem.gameObject.SetActive(value:  false);
        }
        
        }
        
        var val_23 = 4;
        do
        {
            var val_9 = val_23 - 4;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.Collections.Generic.List<PurchaseModel> val_10 = this.Packages;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_23 = val_23 + 1;
        }
        while(this.packItems != null);
        
        var val_24 = 4;
        do
        {
            var val_11 = val_24 - 4;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.Collections.Generic.List<PurchaseModel> val_12 = this.PetsFoodPackages;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_24 = val_24 + 1;
        }
        while(this.foodPackItems != null);
        
        var val_25 = 4;
        do
        {
            var val_13 = val_25 - 4;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.Collections.Generic.List<PurchaseModel> val_14 = this.GemPackages;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_25 = val_25 + 1;
        }
        while(this.gemPackItems != null);
        
        var val_26 = 4;
        do
        {
            var val_15 = val_26 - 4;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.Collections.Generic.List<PurchaseModel> val_16 = this.SpinPackages;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_26 = val_26 + 1;
        }
        while(this.spinPackItems != null);
        
        val_26 = null;
        val_26 = null;
        if(App.game != 20)
        {
                Player val_17 = App.Player;
            GameEcon val_18 = App.getGameEcon;
            this.ShowOrHidePackItem(packId:  "id_credits1", show:  (val_17.total_purchased < 0) ? 1 : 0);
        }
        
        val_27 = null;
        val_27 = null;
        val_28 = GameStoreUI.OnRefreshDisplay;
        if(val_28 != null)
        {
                val_28 = GameStoreUI.OnRefreshDisplay;
            val_28.Invoke();
        }
        
        val_29 = null;
        val_29 = null;
        if(App.game == 20)
        {
                return;
        }
        
        this.canvas_category_content.alpha = 0f;
        UnityEngine.Coroutine val_22 = this.StartCoroutine(routine:  this.WaitAndScroll());
    }
    public GameStoreCategory GetOrCreateCategory(string categoryTitle, bool showTitle = True, int siblingIndex = -1)
    {
        GameStoreCategory val_12;
        bool val_1 = this.storeCategories.ContainsKey(key:  categoryTitle);
        if((val_1 != false) && (this.storeCategories.Item[categoryTitle] != 0))
        {
                if((siblingIndex & 2147483648) == 0)
        {
                this.storeCategories.Item[categoryTitle].transform.SetSiblingIndex(index:  siblingIndex);
        }
        
            val_12 = this.storeCategories.Item[categoryTitle];
            return val_12;
        }
        
        GameStoreCategory val_8 = UnityEngine.Object.Instantiate<GameStoreCategory>(original:  val_1.Prefab_StoreCategory, parent:  this.xfm_category_content);
        val_12 = val_8;
        val_8.transform.name = categoryTitle;
        val_12.Setup(categoryTitle:  categoryTitle, showTitle:  showTitle);
        this.storeCategories.Add(key:  categoryTitle, value:  val_12);
        if((siblingIndex & 2147483648) != 0)
        {
                return val_12;
        }
        
        val_12.transform.SetSiblingIndex(index:  siblingIndex);
        return val_12;
    }
    public void ShowOrHidePackItem(string packId, bool show)
    {
        if((this.standardPackItems.ContainsKey(key:  packId)) == false)
        {
                return;
        }
        
        this.standardPackItems.Item[packId].gameObject.SetActive(value:  show);
    }
    public int GetStoreItemIndex(string packId)
    {
        var val_3;
        bool val_3 = true;
        if(this.packItems == null)
        {
            goto label_2;
        }
        
        val_3 = 0;
        label_6:
        if(val_3 >= val_3)
        {
            goto label_2;
        }
        
        if(val_3 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + 0;
        if((System.String.op_Equality(a:  (true + 0) + 32.PackID, b:  packId)) == true)
        {
                return (int)val_3;
        }
        
        val_3 = val_3 + 1;
        if(this.packItems != null)
        {
            goto label_6;
        }
        
        throw new NullReferenceException();
        label_2:
        val_3 = 0;
        return (int)val_3;
    }
    private System.Collections.IEnumerator WaitAndScroll()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new GameStoreUI.<WaitAndScroll>d__72();
    }
    public void CreatePackItems()
    {
        string val_59;
        var val_60;
        var val_107;
        System.Action val_108;
        MetaGameBehavior val_109;
        string val_110;
        var val_111;
        var val_112;
        var val_113;
        val_107 = null;
        val_107 = null;
        val_108 = GameStoreUI.OnCreatePackItems;
        if(val_108 != null)
        {
                val_108 = GameStoreUI.OnCreatePackItems;
            if(val_108 == null)
        {
                throw new NullReferenceException();
        }
        
            val_108.Invoke();
        }
        
        this.packItems = new System.Collections.Generic.List<WGStoreItem>();
        this.foodPackItems = new System.Collections.Generic.List<WGStoreItem_pet>();
        this.gemPackItems = new System.Collections.Generic.List<WGStoreItem_gems>();
        System.Collections.Generic.List<WGStoreItem_spins> val_4 = null;
        val_110 = public System.Void System.Collections.Generic.List<WGStoreItem_spins>::.ctor();
        val_4 = new System.Collections.Generic.List<WGStoreItem_spins>();
        this.spinPackItems = val_4;
        val_111 = null;
        val_111 = null;
        if(App.game == 16)
        {
            goto label_12;
        }
        
        val_111 = null;
        val_111 = null;
        if(App.game != 12)
        {
            goto label_18;
        }
        
        label_12:
        val_112 = 0;
        goto label_19;
        label_18:
        val_112 = 1;
        label_19:
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_5.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) == 0)
        {
            goto label_26;
        }
        
        val_110 = "SPINS";
        if(this.SpinPackages == null)
        {
                throw new NullReferenceException();
        }
        
        var val_106 = 0;
        label_29:
        if(val_106 >= "SPINS")
        {
            goto label_26;
        }
        
        if((this.GetOrCreateCategory(categoryTitle:  val_110, showTitle:  true, siblingIndex:  0)) == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_6.layout_pack_contents;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        val_110 = val_106;
        this.MakeSpinItem(index:  0, parentXfm:  val_109.transform);
        val_106 = val_106 + 1;
        if(this.SpinPackages != null)
        {
            goto label_29;
        }
        
        throw new NullReferenceException();
        label_26:
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_10.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) != 0)
        {
                val_110 = 0;
            if((DefaultHandler<WGBonusRewardsHandler>.Instance) != val_110)
        {
                val_110 = "Bonus Rewards";
            GameStoreCategory val_13 = this.GetOrCreateCategory(categoryTitle:  val_110, showTitle:  false, siblingIndex:  0);
            if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
            val_109 = val_13.layout_pack_contents;
            if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
            val_110 = val_109.transform;
            UnityEngine.GameObject val_16 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_13.Prefab_BonusRewardHeader, parent:  val_110);
        }
        
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_17.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) == 0)
        {
            goto label_62;
        }
        
        val_110 = "NoAds";
        GameStoreCategory val_18 = this.GetOrCreateCategory(categoryTitle:  val_110, showTitle:  false, siblingIndex:  1);
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_18.layout_pack_contents;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_21 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_18.Prefab_PackNoAdsItem, parent:  val_109.transform);
        val_110 = 0;
        if(val_21 == val_110)
        {
            goto label_58;
        }
        
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_21.GetComponent<WGStoreItem_NoAds>())) == false)
        {
            goto label_58;
        }
        
        val_110 = public WGStoreItem_NoAds UnityEngine.GameObject::GetComponent<WGStoreItem_NoAds>();
        this.noAdsItem = val_21.GetComponent<WGStoreItem_NoAds>();
        goto label_62;
        label_58:
        val_109 = val_21;
        val_110 = 0;
        if(val_109 != val_110)
        {
                if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
            val_110 = 0;
            val_21.SetActive(value:  false);
        }
        
        label_62:
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_27.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        val_113 = this.GetOrCreateCategory(categoryTitle:  val_109, showTitle:  true, siblingIndex:  0);
        val_110 = 0;
        if((MonoSingleton<WGSubscriptionManager>.Instance) == val_110)
        {
            goto label_77;
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_31.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) == 0)
        {
            goto label_77;
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_32.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) == 0)
        {
            goto label_82;
        }
        
        label_77:
        var val_107 = 0;
        label_185:
        if(this.Packages == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_107 < 1152921504765632512)
        {
                if(val_113 == null)
        {
                throw new NullReferenceException();
        }
        
            do
        {
            val_109 = val_28.layout_pack_contents;
            if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
            val_110 = val_107;
            this.MakeStoreItem(index:  0, parentXfm:  val_109.transform);
            val_107 = val_107 + 1;
        }
        while(val_107 < 1152921504765632512);
        
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_35.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) == 0)
        {
            goto label_94;
        }
        
        val_110 = Localization.Localize(key:  "food_upper", defaultValue:  "FOOD", useSingularKey:  false);
        val_113 = this.GetOrCreateCategory(categoryTitle:  val_110, showTitle:  true, siblingIndex:  0);
        if(this.PetsFoodPackages == null)
        {
                throw new NullReferenceException();
        }
        
        var val_108 = 0;
        label_97:
        if(val_108 >= "food_upper")
        {
            goto label_94;
        }
        
        if(val_113 == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_37.layout_pack_contents;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        val_110 = val_108;
        this.MakePetsFoodItem(index:  0, parentXfm:  val_109.transform);
        val_108 = val_108 + 1;
        if(this.PetsFoodPackages != null)
        {
            goto label_97;
        }
        
        throw new NullReferenceException();
        label_94:
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_41.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) == 0)
        {
            goto label_132;
        }
        
        GameStoreCategory val_43 = this.GetOrCreateCategory(categoryTitle:  Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false), showTitle:  true, siblingIndex:  0);
        val_110 = 0;
        if((MonoSingleton<WGSubscriptionManager>.Instance) == val_110)
        {
            goto label_118;
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_46.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) == 0)
        {
            goto label_118;
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_47.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) == 0)
        {
            goto label_118;
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_48.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) != 0)
        {
            goto label_126;
        }
        
        val_110 = 0;
        val_109 = "gems";
        int val_49 = PackagesManager.GetAdPackageCount(packageType:  val_109);
        if(val_49 < 1)
        {
            goto label_126;
        }
        
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_109 = 0;
        do
        {
            val_109 = val_43.layout_pack_contents;
            if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
            val_110 = val_109;
            this.MakeGemItem(index:  0, parentXfm:  val_109.transform);
            val_109 = val_109 + 1;
        }
        while(val_109 < val_49);
        
        goto label_130;
        label_118:
        val_113 = 0;
        label_195:
        if(this.GemPackages == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_113 < val_107)
        {
                if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
            do
        {
            val_109 = val_43.layout_pack_contents;
            if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
            val_110 = val_113;
            this.MakeGemItem(index:  0, parentXfm:  val_109.transform);
            val_113 = val_113 + 1;
        }
        while(val_113 < val_107);
        
        }
        
        label_132:
        if(this.scroll_category_content == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_53.m_Content;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Rect val_54 = val_109.rect;
        val_110 = 0;
        float val_55 = val_54.m_XMin.height;
        val_109 = this.storeCategories;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_57 = val_109.GetEnumerator();
        label_153:
        val_110 = public System.Boolean Dictionary.Enumerator<System.String, GameStoreCategory>::MoveNext();
        if(val_60.MoveNext() == false)
        {
            goto label_139;
        }
        
        if(val_59 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_110 = 0;
        UnityEngine.Transform val_62 = val_59.transform;
        if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
        if(null != null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Rect val_64 = (null == null) ? (val_62) : 0.rect;
        val_110 = 0;
        UnityEngine.Transform val_66 = val_59.transform;
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_67 = val_66.localPosition;
        val_110 = 0;
        UnityEngine.Transform val_68 = val_59.transform;
        if(val_68 == null)
        {
                throw new NullReferenceException();
        }
        
        if(null != null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Rect val_70 = (null == null) ? (val_68) : 0.rect;
        float val_71 = val_70.m_XMin.height;
        val_110 = 0;
        UnityEngine.Transform val_72 = val_59.transform;
        if(val_72 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_73 = val_72.localPosition;
        val_110 = 0;
        UnityEngine.Transform val_74 = val_59.transform;
        if(val_74 == null)
        {
                throw new NullReferenceException();
        }
        
        if(null != null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Rect val_76 = (null == null) ? (val_74) : 0.rect;
        float val_77 = val_76.m_XMin.height;
        val_110 = 0;
        UnityEngine.Transform val_78 = val_59.transform;
        if(val_78 == null)
        {
                throw new NullReferenceException();
        }
        
        val_110 = 0;
        val_109 = this.storeCategories;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        val_110 = 0;
        UnityEngine.Transform val_83 = val_59.transform;
        if(val_83 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_84 = val_83.localPosition;
        float val_85 = val_64.m_XMin.height * 0.5f;
        val_85 = val_85 * ((val_78.GetSiblingIndex() == (val_109.Count - 1)) ? -1f : 1f);
        val_85 = val_85 + val_84.y;
        val_85 = (val_55 * 0.5f) + val_85;
        val_85 = val_85 / val_55;
        this.normalishCategoryPositions.Add(key:  val_59, value:  val_85);
        goto label_153;
        label_139:
        val_60.Dispose();
        return;
        label_82:
        val_110 = 0;
        val_109 = "credits";
        int val_86 = PackagesManager.GetAdPackageCount(packageType:  val_109);
        if(val_86 >= 1)
        {
                if(val_113 == null)
        {
                throw new NullReferenceException();
        }
        
            var val_110 = 0;
            do
        {
            val_109 = val_28.layout_pack_contents;
            if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
            val_110 = val_110;
            this.MakeStoreItem(index:  0, parentXfm:  val_109.transform);
            val_110 = val_110 + 1;
        }
        while(val_110 < val_86);
        
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_88.<metaGameBehavior>k__BackingField;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_109 & 1) != 0)
        {
                WGSubscriptionManager val_89 = MonoSingleton<WGSubscriptionManager>.Instance;
            if(val_89 == null)
        {
                throw new NullReferenceException();
        }
        
            val_110 = 1;
            if((val_89.hasSubscription(subPackage:  val_110)) != true)
        {
                WGSubscriptionManager val_91 = MonoSingleton<WGSubscriptionManager>.Instance;
            if(val_91 == null)
        {
                throw new NullReferenceException();
        }
        
            val_110 = 0;
            bool val_92 = val_91.silverTicketUnlocked;
            if(val_92 != false)
        {
                if(val_113 == null)
        {
                throw new NullReferenceException();
        }
        
            val_109 = val_28.layout_pack_contents;
            if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
            val_110 = val_109.transform;
            UnityEngine.GameObject val_95 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_92.Prefab_silverTicketItem, parent:  val_110);
        }
        
        }
        
        }
        
        WGSubscriptionManager val_96 = MonoSingleton<WGSubscriptionManager>.Instance;
        if(val_96 == null)
        {
                throw new NullReferenceException();
        }
        
        val_110 = 0;
        bool val_97 = val_96.hasSubscription(subPackage:  val_110);
        if(val_97 == true)
        {
            goto label_185;
        }
        
        if(val_113 == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_28.layout_pack_contents;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_100 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_97.Prefab_goldenTicketItem, parent:  val_109.transform);
        goto label_185;
        label_126:
        label_130:
        WGSubscriptionManager val_101 = MonoSingleton<WGSubscriptionManager>.Instance;
        if(val_101 == null)
        {
                throw new NullReferenceException();
        }
        
        val_110 = 0;
        bool val_102 = val_101.hasSubscription(subPackage:  val_110);
        if(val_102 == true)
        {
            goto label_195;
        }
        
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_109 = val_43.layout_pack_contents;
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        val_110 = val_109.transform;
        UnityEngine.GameObject val_105 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_102.Prefab_goldenTicketItem, parent:  val_110);
        if(val_105 == null)
        {
                throw new NullReferenceException();
        }
        
        val_105.SetActive(value:  true);
        goto label_195;
    }
    public void ScrollToCategory(string categoryName)
    {
        int val_8;
        if((System.String.IsNullOrEmpty(value:  categoryName)) == true)
        {
            goto label_1;
        }
        
        if((this.storeCategories.ContainsKey(key:  categoryName)) == false)
        {
            goto label_3;
        }
        
        this.lastScrollPosition = this.normalishCategoryPositions.Item[categoryName];
        label_1:
        UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  0f, y:  this.lastScrollPosition);
        this.scroll_category_content.normalizedPosition = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        return;
        label_3:
        string[] val_6 = new string[5];
        val_8 = val_6.Length;
        val_6[0] = "Store could not scroll to ";
        if(categoryName != null)
        {
                val_8 = val_6.Length;
        }
        
        val_6[1] = categoryName;
        val_8 = val_6.Length;
        val_6[2] = " : ";
        if(categoryName != null)
        {
                val_8 = val_6.Length;
        }
        
        val_6[3] = categoryName;
        val_8 = val_6.Length;
        val_6[4] = " is not a category key.";
        UnityEngine.Debug.LogError(message:  +val_6);
    }
    public void MakeStoreItem(int index, UnityEngine.Transform parentXfm)
    {
        var val_8 = 1152921513413301296;
        UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.Prefab_PackItem, parent:  parentXfm);
        System.Collections.Generic.List<PurchaseModel> val_3 = this.Packages;
        if(val_8 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = val_8 + (index << 3);
        decimal val_4 = (1152921513413301296 + (index) << 3) + 32.Credits;
        val_2.name = "PackItem_" + val_4;
        WGStoreItem val_6 = val_2.GetComponent<WGStoreItem>();
        System.Collections.Generic.List<WGStoreItem> val_9 = this.packItems;
        val_9.Add(item:  val_6);
        System.Collections.Generic.List<PurchaseModel> val_7 = this.Packages;
        if(val_9 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_9 = val_9 + (((long)(int)(index)) << 3);
        this.standardPackItems.Add(key:  val_6, value:  val_6);
    }
    private void MakePetsFoodItem(int index, UnityEngine.Transform parentXfm)
    {
        var val_8 = 1152921513413301296;
        UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.Prefab_PackFoodItem, parent:  parentXfm);
        System.Collections.Generic.List<PurchaseModel> val_3 = this.PetsFoodPackages;
        if(val_8 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = val_8 + (index << 3);
        decimal val_4 = (1152921513413301296 + (index) << 3) + 32.PetsFood;
        val_2.name = "PackItem_" + val_4;
        UnityEngine.UI.LayoutElement val_6 = val_2.GetComponent<UnityEngine.UI.LayoutElement>();
        this.foodPackItems.Add(item:  val_2.GetComponent<WGStoreItem_pet>());
    }
    private void MakeGemItem(int index, UnityEngine.Transform parentXfm)
    {
        string val_7;
        var val_7 = 1152921513413301296;
        UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.Prefab_PackGemItem, parent:  parentXfm);
        if((index & 2147483648) != 0)
        {
            goto label_3;
        }
        
        System.Collections.Generic.List<PurchaseModel> val_3 = this.GemPackages;
        if(val_7 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + (index << 3);
        decimal val_4 = (1152921513413301296 + (index) << 3) + 32.Gems;
        val_7 = "GemPackItem_" + val_4;
        if(val_2 != null)
        {
            goto label_7;
        }
        
        label_3:
        val_7 = "subscription";
        label_7:
        val_2.name = val_7;
        this.gemPackItems.Add(item:  val_2.GetComponent<WGStoreItem_gems>());
    }
    private void MakeSpinItem(int index, UnityEngine.Transform parentXfm)
    {
        var val_7 = 1152921513413301296;
        UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.Prefab_PackSpinItem, parent:  parentXfm);
        System.Collections.Generic.List<PurchaseModel> val_3 = this.SpinPackages;
        if(val_7 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + (index << 3);
        decimal val_4 = (1152921513413301296 + (index) << 3) + 32.Spins;
        val_2.name = "SpinPackItem_" + val_4;
        this.spinPackItems.Add(item:  val_2.GetComponent<WGStoreItem_spins>());
    }
    public virtual void PurchaseItemModel(PurchaseModel pack)
    {
        if(this.canPurchase == false)
        {
                return;
        }
        
        SLCDebug.Log(logMessage:  "GameStoreUI.PurchaseItemModel :: canPurchase = false", colorHash:  "#E4784B", isError:  false);
        this.canPurchase = true;
        this.didPurchase = true;
        this.button_back.interactable = false;
        UnityEngine.Vector2 val_2 = this.scroll_category_content.normalizedPosition;
        this.lastScrollPosition = val_2.y;
        MonoSingletonSelfGenerating<WGStoreController>.Instance.Purchase(purchase:  pack);
    }
    public void ShowConnectionRequired()
    {
        int val_10;
        var val_11;
        System.Func<System.Boolean> val_13;
        var val_14;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_10 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_10 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_11 = null;
        val_11 = null;
        val_13 = GameStoreUI.<>c.<>9__80_0;
        if(val_13 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_13 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  GameStoreUI.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean GameStoreUI.<>c::<ShowConnectionRequired>b__80_0());
            GameStoreUI.<>c.<>9__80_0 = val_13;
        }
        
        val_8[0] = val_13;
        val_14 = null;
        val_14 = null;
        MonoSingleton<GameStoreWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public void UpdateCoins(decimal amount)
    {
        if(this.coinsAnimControl != null)
        {
                this.coinsAnimControl.Set(instantValue:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid});
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnPurchaseNoAdsPackSuccess()
    {
        App.Player.RemovedAds = true;
        this.RefreshPackItemDisplays();
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
    }
    public void DisplayPurchaseFail(string title, string message)
    {
        System.Boolean[] val_10;
        int val_11;
        var val_12;
        System.Func<System.Boolean> val_14;
        var val_15;
        val_10 = 1152921504893161472;
        if((MonoSingleton<GameStoreWindowManager>.Instance) != 0)
        {
                bool[] val_5 = new bool[2];
            val_10 = val_5;
            val_10[0] = true;
            string[] val_6 = new string[2];
            val_11 = val_6.Length;
            val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_11 = val_6.Length;
            val_6[1] = "NO";
            System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
            val_12 = null;
            val_12 = null;
            val_14 = GameStoreUI.<>c.<>9__83_0;
            if(val_14 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_14 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  GameStoreUI.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean GameStoreUI.<>c::<DisplayPurchaseFail>b__83_0());
            GameStoreUI.<>c.<>9__83_0 = val_14;
        }
        
            val_8[0] = val_14;
            val_15 = null;
            val_15 = null;
            MonoSingleton<GameStoreWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  title, messageTxt:  message, shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        
        SLCDebug.Log(logMessage:  "GameStoreUI.DisplayPurchaseFail :: canPurchase = true", colorHash:  "#19A1DF", isError:  false);
        this.canPurchase = true;
        this.button_back.interactable = true;
        this.didPurchase = false;
    }
    public void DisplayPurchaseSuccess(PurchaseModel purchase)
    {
        int val_79;
        var val_80;
        var val_81;
        var val_82;
        var val_83;
        var val_84;
        var val_85;
        int val_86;
        var val_87;
        var val_88;
        int val_89;
        float val_90;
        int val_91;
        CurrencyCollectAnimationInstantiator val_92;
        System.Action val_93;
        var val_94;
        int val_95;
        int val_96;
        CurrencyCollectAnimationInstantiator val_97;
        System.Action val_98;
        var val_99;
        int val_100;
        int val_101;
        CurrencyCollectAnimationInstantiator val_102;
        System.Action val_103;
        var val_104;
        float val_105;
        var val_106;
        int val_107;
        int val_108;
        CurrencyCollectAnimationInstantiator val_109;
        int val_110;
        System.Action val_111;
        if(this.gameObject.activeSelf == false)
        {
                return;
        }
        
        bool val_3 = purchase.id.Contains(value:  "bundle");
        decimal val_4 = purchase.Credits;
        val_80 = null;
        val_80 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_6 = purchase.Gems;
            val_82 = null;
            val_82 = null;
            float val_70 = 1.8f;
            float val_8 = ((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != true) ? 2.7f : (val_70);
            decimal val_9 = purchase.GoldenCurrency;
            val_83 = null;
            val_83 = null;
            float val_71 = 0.9f;
            val_70 = val_8 + val_71;
            val_8 = ((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != true) ? (val_70) : (val_8);
            decimal val_11 = purchase.PetsFood;
            val_84 = null;
            val_84 = null;
            val_70 = val_8 + val_71;
            val_8 = ((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != true) ? (val_70) : (val_8);
            decimal val_13 = purchase.Spins;
            val_85 = null;
            val_85 = null;
            val_70 = val_8 + val_71;
            val_71 = ((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != true) ? (val_70) : (val_8);
            Player val_15 = App.Player;
            decimal val_16 = purchase.Credits;
            val_86 = val_16.lo;
            decimal val_17 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_15._credits, hi = val_15._credits, lo = val_13.lo, mid = val_13.mid}, d2:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_86, mid = val_16.mid});
            Player val_18 = App.Player;
            this.AnimateCoins(fromAmount:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid}, toAmount:  new System.Decimal() {flags = val_18._credits, hi = val_18._credits}, actionOnComplete:  0);
            System.Action val_19 = null;
            val_81 = 0;
            val_19 = new System.Action(object:  this, method:  System.Void GameStoreUI::<DisplayPurchaseSuccess>b__84_3());
            UnityEngine.Coroutine val_21 = this.StartCoroutine(routine:  val_19.PurchaseDelayComplete(waitTime:  val_71, onCompleteAction:  val_19));
            val_87 = 1;
        }
        else
        {
                val_87 = 0;
        }
        
        decimal val_22 = purchase.Gems;
        val_88 = null;
        val_88 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_22.flags, hi = val_22.hi, lo = val_22.lo, mid = val_22.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_25;
        }
        
        float val_24 = (val_3 != true) ? 1.8f : 0.9f;
        if(val_87 == 0)
        {
            goto label_26;
        }
        
        Player val_25 = App.Player;
        val_86 = val_25._gems;
        decimal val_26 = purchase.Gems;
        Player val_28 = App.Player;
        val_89 = val_28._gems;
        val_91 = val_86 - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_26.flags, hi = val_26.hi, lo = val_26.lo, mid = val_26.mid}));
        val_92 = this.gemAnimControl;
        val_93 = 0;
        goto label_33;
        label_25:
        val_90 = 0.9f;
        goto label_34;
        label_26:
        Player val_29 = App.Player;
        decimal val_30 = purchase.Gems;
        Player val_32 = App.Player;
        System.Action val_33 = null;
        val_86 = val_33;
        val_33 = new System.Action(object:  this, method:  System.Void GameStoreUI::<DisplayPurchaseSuccess>b__84_0());
        val_91 = val_29._gems - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_30.flags, hi = val_30.hi, lo = val_30.lo, mid = val_30.mid}));
        val_92 = this.gemAnimControl;
        val_89 = val_32._gems;
        val_93 = val_86;
        label_33:
        this.AnimatePurchase(animControl:  val_92, fromAmount:  val_91, toAmount:  val_89, actionOnComplete:  val_33, delay:  val_24);
        val_87 = 1;
        label_34:
        decimal val_34 = purchase.PetsFood;
        val_94 = null;
        val_94 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_34.flags, hi = val_34.hi, lo = val_34.lo, mid = val_34.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_90 = ((val_3 != true) ? 0.9f : 0f) + val_24;
            if(val_87 != 0)
        {
                Player val_37 = App.Player;
            val_86 = val_37._food;
            decimal val_38 = purchase.PetsFood;
            Player val_40 = App.Player;
            val_95 = val_40._food;
            val_96 = val_86 - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_38.flags, hi = val_38.hi, lo = val_38.lo, mid = val_38.mid}));
            val_97 = this.foodAnimControl;
            val_98 = 0;
        }
        else
        {
                Player val_41 = App.Player;
            decimal val_42 = purchase.PetsFood;
            Player val_44 = App.Player;
            System.Action val_45 = null;
            val_86 = val_45;
            val_45 = new System.Action(object:  this, method:  System.Void GameStoreUI::<DisplayPurchaseSuccess>b__84_1());
            val_96 = val_41._food - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_42.flags, hi = val_42.hi, lo = val_42.lo, mid = val_42.mid}));
            val_97 = this.foodAnimControl;
            val_95 = val_44._food;
            val_98 = val_86;
        }
        
            this.AnimatePurchase(animControl:  val_97, fromAmount:  val_96, toAmount:  val_95, actionOnComplete:  val_45, delay:  val_90);
            val_87 = 1;
        }
        
        decimal val_46 = purchase.GoldenCurrency;
        val_99 = null;
        val_99 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_46.flags, hi = val_46.hi, lo = val_46.lo, mid = val_46.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_90 = ((val_3 != true) ? 0.9f : 0f) + val_90;
            if(val_87 != 0)
        {
                Player val_49 = App.Player;
            val_86 = val_49._stars;
            decimal val_50 = purchase.GoldenCurrency;
            Player val_52 = App.Player;
            val_100 = val_52._stars;
            val_101 = val_86 - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_50.flags, hi = val_50.hi, lo = val_50.lo, mid = val_50.mid}));
            val_102 = this.goldCurrencyAnimControl;
            val_103 = 0;
        }
        else
        {
                Player val_53 = App.Player;
            decimal val_54 = purchase.GoldenCurrency;
            Player val_56 = App.Player;
            System.Action val_57 = null;
            val_86 = val_57;
            val_57 = new System.Action(object:  this, method:  System.Void GameStoreUI::<DisplayPurchaseSuccess>b__84_2());
            val_101 = val_53._stars - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_54.flags, hi = val_54.hi, lo = val_54.lo, mid = val_54.mid}));
            val_102 = this.goldCurrencyAnimControl;
            val_100 = val_56._stars;
            val_103 = val_86;
        }
        
            this.AnimatePurchase(animControl:  val_102, fromAmount:  val_101, toAmount:  val_100, actionOnComplete:  val_57, delay:  val_90);
            val_87 = 1;
        }
        
        decimal val_58 = purchase.Spins;
        val_104 = null;
        val_104 = null;
        bool val_59 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_58.flags, hi = val_58.hi, lo = val_58.lo, mid = val_58.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        float val_72 = 0.9f;
        float val_60 = (val_3 != true) ? (val_72) : 0f;
        val_72 = val_60 + val_90;
        val_90 = (val_59 != true) ? (val_72) : (val_90);
        decimal val_61 = purchase.DiceRolls;
        val_79 = val_61.flags;
        val_106 = null;
        val_107 = val_61.lo;
        val_106 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_79, hi = val_61.hi, lo = val_107, mid = val_61.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_86 = val_59 | val_87;
            val_105 = val_60 + val_90;
            val_79 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceBalance();
            decimal val_64 = purchase.DiceRolls;
            val_107 = val_64.flags;
            if(val_86 != false)
        {
                val_108 = val_79 - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_107, hi = val_64.hi, lo = val_64.lo, mid = val_64.mid}));
            val_109 = this.diceAnimControl;
            val_110 = val_79;
            val_111 = 0;
        }
        else
        {
                val_107 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_107, hi = val_64.hi, lo = val_64.lo, mid = val_64.mid});
            System.Action val_67 = new System.Action(object:  this, method:  System.Void GameStoreUI::<DisplayPurchaseSuccess>b__84_4());
            val_108 = val_79 - val_107;
            val_109 = this.diceAnimControl;
            val_110 = val_79;
            val_111 = val_67;
        }
        
            this.AnimatePurchase(animControl:  val_109, fromAmount:  val_108, toAmount:  val_110, actionOnComplete:  val_67, delay:  val_105);
        }
        
        if((purchase.id.Contains(value:  "remove")) != true)
        {
                if((purchase.id.Contains(value:  "starter_pack")) == false)
        {
                return;
        }
        
        }
        
        this.OnPurchaseNoAdsPackSuccess();
    }
    private System.Collections.IEnumerator PurchaseDelayComplete(float waitTime, System.Action onCompleteAction)
    {
        .<>1__state = 0;
        .waitTime = waitTime;
        .onCompleteAction = onCompleteAction;
        return (System.Collections.IEnumerator)new GameStoreUI.<PurchaseDelayComplete>d__85();
    }
    private void AnimateCoins(decimal fromAmount, decimal toAmount, System.Action actionOnComplete)
    {
        this.coinsAnimControl.OnCompleteCallback = actionOnComplete;
        this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = fromAmount.flags, hi = fromAmount.hi, lo = fromAmount.lo, mid = fromAmount.mid}, toValue:  new System.Decimal() {flags = toAmount.flags, hi = toAmount.hi, lo = toAmount.lo, mid = toAmount.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f);
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
        return (System.Collections.IEnumerator)new GameStoreUI.<StartAnimating>d__88();
    }
    public void SetVisible(bool visible)
    {
        if(visible != false)
        {
            
        }
        
        MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject).alpha = 0f;
    }
    private void OnAnimFinished()
    {
        var val_6;
        System.Action val_7;
        SLCDebug.Log(logMessage:  "GameStoreUI.OnAnimFinished :: canPurchase = true", colorHash:  "#19A1DF", isError:  false);
        this.canPurchase = true;
        this.button_back.interactable = true;
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        if(MainController.instance != 0)
        {
                if((MainController.instance.IsChapterComplete != false) && (VIPPartyEventHandler.instance != null))
        {
                VIPPartyEventHandler.instance.OnAnimFinished_StorePurchaseOnChapterComplete();
        }
        
        }
        
        val_6 = null;
        val_6 = null;
        val_7 = GameStoreUI.OnRewardAnimationsComplete;
        if(val_7 == null)
        {
                return;
        }
        
        val_7 = GameStoreUI.OnRewardAnimationsComplete;
        val_7.Invoke();
    }
    private void HandleBackButtonClose()
    {
        this.Close();
    }
    public void Close()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void GameStoreUI::HandleBackButtonClose()));
        GameStoreManager.StoreCategoryFocus = "";
        MonoSingletonSelfGenerating<GameStoreManager>.Instance.HandleStoreClose(purchased:  this.didPurchase, runCallbacks:  true, forceClose:  false);
    }
    public void ForceClose()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void GameStoreUI::HandleBackButtonClose()));
        GameStoreManager.StoreCategoryFocus = "";
        MonoSingletonSelfGenerating<GameStoreManager>.Instance.HandleStoreClose(purchased:  false, runCallbacks:  true, forceClose:  true);
    }
    public GameStoreUI()
    {
        this.canPurchase = true;
        this.storeCategories = new System.Collections.Generic.Dictionary<System.String, GameStoreCategory>();
        this.normalishCategoryPositions = new System.Collections.Generic.Dictionary<System.String, System.Single>();
        this.standardPackItems = new System.Collections.Generic.Dictionary<System.String, WGStoreItem>();
        this.lastScrollPosition = 1f;
    }
    private static GameStoreUI()
    {
    
    }
    private void <DisplayPurchaseSuccess>b__84_3()
    {
        this.OnAnimFinished();
        this.RefreshPackItemDisplays();
    }
    private void <DisplayPurchaseSuccess>b__84_0()
    {
        this.OnAnimFinished();
        this.RefreshPackItemDisplays();
    }
    private void <DisplayPurchaseSuccess>b__84_1()
    {
        this.OnAnimFinished();
        this.RefreshPackItemDisplays();
    }
    private void <DisplayPurchaseSuccess>b__84_2()
    {
        this.OnAnimFinished();
        this.RefreshPackItemDisplays();
    }
    private void <DisplayPurchaseSuccess>b__84_4()
    {
        this.OnAnimFinished();
        this.RefreshPackItemDisplays();
    }

}
