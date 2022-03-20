using UnityEngine;
public class TheLibraryAcquireBooksPopup : FrameSkipper
{
    // Fields
    private LibraryBookDisplay_AcquireBookPack prefab_bookpack_display;
    private UnityEngine.UI.ScrollRect scrollRect;
    private UnityEngine.Transform xfm_content_group;
    private UnityEngine.Transform xfm_content_packs_group;
    private UnityEngine.UI.Button button_close;
    private GoldenCurrencyCollectAnimationInstantiator gold_currency_instantiator;
    private UnityEngine.UI.Text text_time;
    private UnityEngine.CanvasGroup canvas_not_enough_apples;
    private UnityEngine.UI.Button button_info;
    private UnityEngine.GameObject gems_stat_view;
    private UnityEngine.UI.Button button_gems_store;
    private System.Collections.Generic.List<LibraryBookDisplay_AcquireBooks> bookInstances;
    private LibraryBookDisplay_AcquireBookPack newPackDisplay;
    private bool showingNotEnoughApples;
    private LibraryBookDisplay_AcquireBooks _prefab_book_display;
    
    // Properties
    private LibraryBookDisplay_AcquireBooks prefab_book_display { get; }
    
    // Methods
    private LibraryBookDisplay_AcquireBooks get_prefab_book_display()
    {
        LibraryBookDisplay_AcquireBooks val_3;
        if(this._prefab_book_display == 0)
        {
                this._prefab_book_display = PrefabLoader.LoadPrefab<LibraryBookDisplay_AcquireBooks>(featureName:  "TheLibrary");
            return val_3;
        }
        
        val_3 = this._prefab_book_display;
        return val_3;
    }
    private void Awake()
    {
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryAcquireBooksPopup::<Awake>b__17_0()));
        this.button_info.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryAcquireBooksPopup::<Awake>b__17_1()));
        this.button_gems_store.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryAcquireBooksPopup::OnClick_GemsStore()));
    }
    private void OnEnable()
    {
        this.Setup(bookInfos:  TheLibraryLogic.PurchasableBooks);
    }
    public void Setup(System.Collections.Generic.List<BookInfo> bookInfos)
    {
        this.xfm_content_group.gameObject.SetActive(value:  false);
        this.RefreshItems(bookInfos:  bookInfos);
        this.Invoke(methodName:  "ShowScroll", time:  0.1f);
        GameBehavior val_2 = App.getBehavior;
        this.gems_stat_view.SetActive(value:  (val_2.<metaGameBehavior>k__BackingField) & 1);
    }
    private void ShowScroll()
    {
        this.xfm_content_group.gameObject.SetActive(value:  true);
        MonoExtensions.ScrollToTop(scrollRect:  this.scrollRect);
    }
    private void RefreshItems(System.Collections.Generic.List<BookInfo> bookInfos)
    {
        LibraryBookDisplay_AcquireBookPack val_19;
        var val_20;
        int val_21;
        System.Collections.Generic.List<LibraryBookDisplay_AcquireBooks> val_22;
        var val_23;
        var val_24;
        if(this.newPackDisplay == 0)
        {
                LibraryBookDisplay_AcquireBookPack val_2 = UnityEngine.Object.Instantiate<LibraryBookDisplay_AcquireBookPack>(original:  this.prefab_bookpack_display, parent:  this.xfm_content_packs_group);
            val_19 = val_2;
            this.newPackDisplay = val_2;
        }
        else
        {
                val_19 = this.newPackDisplay;
        }
        
        string val_4 = Localization.Localize(key:  "book_pack_info", defaultValue:  "At least 1 Rare in every pack!", useSingularKey:  false);
        val_20 = null;
        val_20 = null;
        val_21 = TheLibraryLogic.BookPackGemCost;
        val_19.Setup(bookpack:  Localization.Localize(key:  "book_pack_upper", defaultValue:  "BOOK PACK", useSingularKey:  false), packdescription:  val_4, packcost:  val_21, packSize:  TheLibraryLogic.BookPackBookCount, onBookClicked:  new System.Action<LibraryBookDisplay_AcquireBookPack>(object:  this, method:  System.Void TheLibraryAcquireBooksPopup::OnBookPackDisplayClicked(LibraryBookDisplay_AcquireBookPack display)));
        val_22 = this.bookInstances;
        if(val_4 < 1152921515893245504)
        {
                val_21 = 1152921515893252672;
            do
        {
            this.bookInstances.Add(item:  UnityEngine.Object.Instantiate<LibraryBookDisplay_AcquireBooks>(original:  this.prefab_book_display, parent:  this.xfm_content_group));
            val_23 = val_4 + 1;
        }
        while(val_23 < this.bookInstances);
        
            val_22 = this.bookInstances;
        }
        
        var val_20 = 4;
        do
        {
            var val_8 = val_20 - 4;
            if(val_8 >= this.bookInstances)
        {
                return;
        }
        
            if(this.bookInstances <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            0.gameObject.SetActive(value:  (val_8 < this.bookInstances) ? 1 : 0);
            if(val_8 < this.bookInstances)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((TheLibraryLogic.PlayerBooksByCollection.ContainsKey(key:  TheLibraryLogic.__il2cppRuntimeField_cctor_finished + 32 + 48)) != false)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(1152921515875437808 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_24 = (~(TheLibraryLogic.ListContainsBook(bookInfos:  TheLibraryLogic.PlayerBooksByCollection.Item[TheLibraryLogic.__il2cppRuntimeField_cctor_finished + 32 + 48], bookToCheck:  null))) & 1;
        }
        else
        {
                val_24 = 1;
        }
        
            if(1152921515876351424 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_23 = mem[TheLibraryLogic.__il2cppRuntimeField_cctor_finished + 32];
            val_23 = TheLibraryLogic.__il2cppRuntimeField_cctor_finished + 32;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.Action<BookInfo, LibraryBookDisplay_AcquireBooks> val_17 = null;
            val_21 = val_17;
            val_17 = new System.Action<BookInfo, LibraryBookDisplay_AcquireBooks>(object:  this, method:  System.Void TheLibraryAcquireBooksPopup::OnBookDisplayClicked(BookInfo info, LibraryBookDisplay_AcquireBooks display));
            val_23.Setup(info:  TheLibraryLogic.__il2cppRuntimeField_cctor_finished + 32, isNew:  true, isPurchased:  TheLibraryLogic.BookAlreadyPurchased(bookInfo:  System.Void Dictionary.KeyCollection<AnimationPair, System.Single>::System.Collections.Generic.ICollection<TKey>.Clear()), onBookClicked:  val_17, onBookAlreadyPurchasedClicked:  new System.Action<BookInfo, LibraryBookDisplay_AcquireBooks>(object:  this, method:  System.Void TheLibraryAcquireBooksPopup::OnPurchasedBookDisplayClicked(BookInfo info, LibraryBookDisplay_AcquireBooks display)));
        }
        
            val_22 = this.bookInstances;
            val_20 = val_20 + 1;
        }
        while(val_22 != null);
        
        throw new NullReferenceException();
    }
    private void OnBookDisplayClicked(BookInfo info, LibraryBookDisplay_AcquireBooks display)
    {
        if((TheLibraryLogic.BuyBook(bookToBuy:  info)) != false)
        {
                this.RefreshItems(bookInfos:  TheLibraryLogic.PurchasableBooks);
            return;
        }
        
        if(this.showingNotEnoughApples == true)
        {
                return;
        }
        
        this.showingNotEnoughApples = true;
        this.canvas_not_enough_apples.gameObject.SetActive(value:  true);
        DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvas_not_enough_apples, endValue:  1f, duration:  0.5f);
        DG.Tweening.Tweener val_6 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvas_not_enough_apples, endValue:  0f, duration:  0.5f), delay:  3f);
        mem2[0] = new DG.Tweening.TweenCallback(object:  this, method:  System.Void TheLibraryAcquireBooksPopup::<OnBookDisplayClicked>b__22_0());
    }
    private void OnBookPackDisplayClicked(LibraryBookDisplay_AcquireBookPack display)
    {
        LibraryBookDisplay_AcquireBookPack val_11 = display;
        System.Collections.Generic.List<BookInfo> val_1 = TheLibraryLogic.BuyBookPack(packSize:  display._packSize);
        if(val_1 != null)
        {
                MonoSingleton<LibraryWindowManager>.Instance.ShowUGUIMonolith<TheLibraryAcquireBookPackPopup>(showNext:  true).Setup(packPurchased:  val_1);
        }
        else
        {
                UnityEngine.Debug.LogError(message:  "TheLibraryAquireBooksPopup.OnBookPackDisplayClicked: something went wrong", context:  this);
            return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnPurchasedBookDisplayClicked(BookInfo info, LibraryBookDisplay_AcquireBooks display)
    {
        if((TheLibraryLogic.PlayerBooksByCollection.ContainsKey(key:  info.Collection)) == false)
        {
                return;
        }
        
        TheLibraryUI.ShowTheLibraryCollection(collectionName:  info.Collection, trackLibraryAccessed:  false);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_GemsStore()
    {
        MonoSingletonSelfGenerating<GameStoreManager>.Instance.ShowStore(categoryFocus:  Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false), storeCloseCallback:  0);
    }
    protected override void UpdateLogic()
    {
        var val_16;
        object val_17;
        object val_18;
        string val_19;
        this.UpdateLogic();
        System.DateTime val_1 = TheLibraryLogic.LastPurchasableRefreshDate;
        System.DateTime val_2 = val_1.dateData.AddHours(value:  (double)TheLibraryLogic.PurchasableBookRefreshTimeHours);
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        System.TimeSpan val_4 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = val_3.dateData});
        val_16 = null;
        val_16 = null;
        if((System.TimeSpan.op_GreaterThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_4._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                val_17 = System.Math.Truncate(d:  val_4._ticks.TotalHours).ToString(format:  "00");
            val_18 = val_4._ticks.Minutes.ToString(format:  "00");
            int val_11 = val_4._ticks.Seconds;
            val_19 = "00";
        }
        else
        {
                val_17 = 0.ToString(format:  "00");
            val_19 = "00";
            val_18 = 0.ToString(format:  "00");
        }
        
        string val_15 = System.String.Format(format:  "{0}:{1}:{2}", arg0:  val_17, arg1:  val_18, arg2:  0.ToString(format:  val_19));
    }
    public TheLibraryAcquireBooksPopup()
    {
        this.bookInstances = new System.Collections.Generic.List<LibraryBookDisplay_AcquireBooks>();
    }
    private void <Awake>b__17_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void <Awake>b__17_1()
    {
        var val_6;
        System.Action val_8;
        GameBehavior val_1 = App.getBehavior;
        SLCWindow val_3 = val_1.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_6 = null;
        val_6 = null;
        val_8 = TheLibraryAcquireBooksPopup.<>c.<>9__17_2;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  TheLibraryAcquireBooksPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TheLibraryAcquireBooksPopup.<>c::<Awake>b__17_2());
            TheLibraryAcquireBooksPopup.<>c.<>9__17_2 = val_8;
        }
        
        val_3.Action_OnClose = val_8;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void <OnBookDisplayClicked>b__22_0()
    {
        this.canvas_not_enough_apples.gameObject.SetActive(value:  false);
        this.showingNotEnoughApples = false;
    }

}
