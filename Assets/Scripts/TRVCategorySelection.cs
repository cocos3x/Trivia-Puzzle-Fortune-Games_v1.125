using UnityEngine;
public class TRVCategorySelection : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button rerollButton;
    private UnityEngine.UI.Button storeButton;
    private UnityEngine.UI.Button gemStoreButton;
    private UnityEngine.UI.Button lastCategoryButton;
    private UnityEngine.UI.Button earlyUnlockCategoryButton;
    private UnityEngine.UI.Text levelText;
    private UnityEngine.UI.Text quizLengthText;
    private UnityEngine.UI.Text rerollCostText;
    private UnityEngine.UI.Text headerText;
    private System.Collections.Generic.List<TRVCategoryButton> catButtons;
    private UnityEngine.GameObject rerollCostParent;
    private UnityEngine.GameObject revealParent;
    private UnityEngine.GameObject lastCategoryLockedGroup;
    private UnityEngine.GameObject lastCategoryUnlockedGroup;
    private UnityEngine.GameObject newCategoryGroup;
    private UnityEngine.GameObject nextCategoryGroup;
    private UnityEngine.UI.Text newCategoryText;
    private UnityEngine.UI.Text nextCategoryText;
    private UnityEngine.UI.Text lastCategoryText;
    private UnityEngine.UI.Text lastCategoryCostText;
    private UnityEngine.UI.Button newCategoryButton;
    private UnityEngine.UI.Image crazyCategoryImage;
    private UnityEngine.UI.Image lastCategoryImage;
    private UnityEngine.UI.Image recentCategoryImage;
    private TRVEventButtonLobby eventButton;
    private UnityEngine.RectTransform nextCatTransform;
    private System.Action onStartAction;
    private bool rerollActive;
    private string forcedPlayNowCategory;
    private System.Collections.Generic.List<TRVCategorySelectionInfo> prevInitCategories;
    private System.Collections.Generic.List<TRVCategorySelectionInfo> currentCategories;
    
    // Methods
    public static string ToUpperCategory(string category)
    {
        string val_7 = category;
        string val_2 = System.Text.RegularExpressions.Regex.Match(input:  val_7 = category, pattern:  "[0-9][0-9]s").Value;
        if((System.String.IsNullOrEmpty(value:  val_2)) != true)
        {
                val_7 = val_7.Replace(oldValue:  val_2, newValue:  "---");
        }
        
        string val_5 = val_7.ToUpper();
        if((System.String.IsNullOrEmpty(value:  val_2)) == false)
        {
                return val_5.Replace(oldValue:  "---", newValue:  val_2);
        }
        
        return val_5;
    }
    public void Init(System.Collections.Generic.List<TRVCategorySelectionInfo> selectedCategorys, bool animate, bool canReroll)
    {
        int val_76;
        System.Action val_78;
        var val_79;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_81;
        string val_82;
        var val_83;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_85;
        var val_86;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_88;
        var val_89;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32> val_91;
        TRVCategorySelection.<>c__DisplayClass33_0 val_1 = new TRVCategorySelection.<>c__DisplayClass33_0();
        .<>4__this = this;
        .animate = animate;
        this.eventButton.UpdateDisplay();
        this.closeButton.m_OnClick.RemoveAllListeners();
        this.rerollButton.m_OnClick.RemoveAllListeners();
        this.storeButton.m_OnClick.RemoveAllListeners();
        this.storeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVCategorySelection::OpenStore()));
        this.gemStoreButton.m_OnClick.RemoveAllListeners();
        this.gemStoreButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  val_1, method:  System.Void TRVCategorySelection.<>c__DisplayClass33_0::<Init>b__0()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void TRVCategorySelection::OnCloseButtonPressed()));
        this.prevInitCategories = selectedCategorys;
        this.currentCategories = new System.Collections.Generic.List<TRVCategorySelectionInfo>(collection:  selectedCategorys);
        string val_9 = System.String.Format(format:  "{0} Questions", arg0:  MonoSingleton<TRVDataParser>.Instance.GetQuizLength());
        string val_12 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        TRVEcon val_13 = App.GetGameSpecificEcon<TRVEcon>();
        string val_14 = val_13.playLastCategoryCost.ToString();
        GameBehavior val_15 = App.getBehavior;
        val_76 = val_15.<metaGameBehavior>k__BackingField;
        if(val_76 < TRVMainController.getRerollFTUXLEVEL)
        {
                string val_17 = Localization.Localize(key:  "free_upper", defaultValue:  "FREE", useSingularKey:  false);
        }
        else
        {
                TRVEcon val_18 = App.GetGameSpecificEcon<TRVEcon>();
            string val_19 = val_18.categoryRerollCost.ToString();
        }
        
        this.crazyCategoryImage.gameObject.SetActive(value:  false);
        this.rerollCostParent.gameObject.SetActive(value:  true);
        this.revealParent.gameObject.SetActive(value:  false);
        this.rerollButton.interactable = true;
        this.rerollActive = canReroll;
        System.Action val_24 = null;
        val_78 = val_24;
        val_24 = new System.Action(object:  val_1, method:  System.Void TRVCategorySelection.<>c__DisplayClass33_0::<Init>b__1());
        this.onStartAction = val_78;
        Player val_25 = App.Player;
        if(val_25 != 1)
        {
            goto label_47;
        }
        
        this.newCategoryGroup.gameObject.SetActive(value:  false);
        label_138:
        this.nextCategoryGroup.gameObject.SetActive(value:  false);
        this.nextCatTransform.gameObject.SetActive(value:  false);
        goto label_116;
        label_47:
        if(val_25.canDisplayPlayCategoryNowButton() == false)
        {
            goto label_55;
        }
        
        .CS$<>8__locals2 = val_1;
        this.newCategoryGroup.gameObject.SetActive(value:  true);
        this.nextCategoryGroup.gameObject.SetActive(value:  false);
        if((System.String.IsNullOrEmpty(value:  this.forcedPlayNowCategory)) == false)
        {
            goto label_61;
        }
        
        val_79 = null;
        val_79 = null;
        val_81 = TRVCategorySelection.<>c.<>9__33_4;
        if(val_81 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_36 = null;
            val_81 = val_36;
            val_36 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean>(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVCategorySelection.<>c::<Init>b__33_4(System.Collections.Generic.KeyValuePair<string, int> x));
            TRVCategorySelection.<>c.<>9__33_4 = val_81;
        }
        
        System.Collections.Generic.KeyValuePair<System.String, System.Int32> val_37 = System.Linq.Enumerable.First<System.Collections.Generic.KeyValuePair<System.String, System.Int32>>(source:  MonoSingleton<TRVDataParser>.Instance.CategoryUnlockLevels, predicate:  val_36);
        val_82 = val_37.Value;
        goto label_70;
        label_55:
        this.newCategoryGroup.gameObject.SetActive(value:  false);
        this.nextCategoryGroup.gameObject.SetActive(value:  true);
        val_83 = null;
        val_83 = null;
        val_85 = TRVCategorySelection.<>c.<>9__33_2;
        if(val_85 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_42 = null;
            val_85 = val_42;
            val_42 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean>(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVCategorySelection.<>c::<Init>b__33_2(System.Collections.Generic.KeyValuePair<string, int> x));
            TRVCategorySelection.<>c.<>9__33_2 = val_85;
        }
        
        if((System.Linq.Enumerable.Any<System.Collections.Generic.KeyValuePair<System.String, System.Int32>>(source:  MonoSingleton<TRVDataParser>.Instance.CategoryUnlockLevels, predicate:  val_42)) == false)
        {
            goto label_83;
        }
        
        val_86 = null;
        val_86 = null;
        val_88 = TRVCategorySelection.<>c.<>9__33_6;
        if(val_88 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_47 = null;
            val_88 = val_47;
            val_47 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean>(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVCategorySelection.<>c::<Init>b__33_6(System.Collections.Generic.KeyValuePair<string, int> x));
            TRVCategorySelection.<>c.<>9__33_6 = val_88;
        }
        
        val_89 = null;
        val_89 = null;
        val_91 = TRVCategorySelection.<>c.<>9__33_7;
        if(val_91 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32> val_49 = null;
            val_91 = val_49;
            val_49 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32>(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVCategorySelection.<>c::<Init>b__33_7(System.Collections.Generic.KeyValuePair<string, int> x));
            TRVCategorySelection.<>c.<>9__33_7 = val_91;
        }
        
        System.Collections.Generic.KeyValuePair<System.String, System.Int32> val_50 = MoreLinq.MinBy<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32>(source:  System.Linq.Enumerable.Where<System.Collections.Generic.KeyValuePair<System.String, System.Int32>>(source:  MonoSingleton<TRVDataParser>.Instance.CategoryUnlockLevels, predicate:  val_47), selector:  val_49);
        .cat = val_50.Value;
        string val_56 = System.String.Format(format:  Localization.Localize(key:  "trv_category_unlock", defaultValue:  "Category {0} unlocks at Level {1}!", useSingularKey:  false), arg0:  TRVCategorySelection.ToUpperCategory(category:  (TRVCategorySelection.<>c__DisplayClass33_3)[1152921517223294224].cat), arg1:  MonoSingleton<TRVDataParser>.Instance.CategoryUnlockLevels.Item[(TRVCategorySelection.<>c__DisplayClass33_3)[1152921517223294224].cat]);
        TRVEcon val_61 = App.GetGameSpecificEcon<TRVEcon>();
        val_76 = val_61.earlyCategoryUnlockLevel;
        int val_76 = val_76;
        val_76 = GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_76);
        this.earlyUnlockCategoryButton.transform.parent.gameObject.SetActive(value:  val_76);
        val_78 = this.earlyUnlockCategoryButton.m_OnClick;
        val_78.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new TRVCategorySelection.<>c__DisplayClass33_3(), method:  System.Void TRVCategorySelection.<>c__DisplayClass33_3::<Init>b__8()));
        goto label_116;
        label_61:
        val_82 = this.forcedPlayNowCategory;
        label_70:
        string val_64 = TRVCategorySelection.ToUpperCategory(category:  val_82);
        this.newCategoryButton.m_OnClick.RemoveAllListeners();
        .unlockedCatInfo = new TRVCategorySelectionInfo();
        .categoryName = val_82;
        (TRVCategorySelection.<>c__DisplayClass33_2)[1152921517223228688].unlockedCatInfo.associatedEvents = new System.Collections.Generic.List<WGEventHandler>();
        this.newCategoryButton.m_OnClick.RemoveAllListeners();
        UnityEngine.Events.UnityAction val_67 = null;
        val_76 = val_67;
        val_67 = new UnityEngine.Events.UnityAction(object:  new TRVCategorySelection.<>c__DisplayClass33_2(), method:  System.Void TRVCategorySelection.<>c__DisplayClass33_2::<Init>b__5());
        this.newCategoryButton.m_OnClick.AddListener(call:  val_67);
        val_78 = this.recentCategoryImage;
        val_78.sprite = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  val_82);
        label_116:
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if(this.onStartAction != null)
        {
                this.onStartAction.Invoke();
        }
        
        this.onStartAction = 0;
        return;
        label_83:
        this.nextCategoryGroup.gameObject.SetActive(value:  false);
        if(this.nextCategoryGroup.transform.parent.gameObject != null)
        {
            goto label_138;
        }
        
        throw new NullReferenceException();
    }
    private bool canDisplayPlayCategoryNowButton()
    {
        string val_14;
        var val_15;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_17;
        var val_18;
        val_14 = MonoSingleton<TRVDataParser>.Instance.CategoryUnlockLevels;
        if((val_14.ContainsValue(value:  App.Player)) != false)
        {
                val_15 = null;
            val_15 = null;
            val_17 = TRVCategorySelection.<>c.<>9__34_0;
            if(val_17 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_7 = null;
            val_17 = val_7;
            val_7 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean>(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVCategorySelection.<>c::<canDisplayPlayCategoryNowButton>b__34_0(System.Collections.Generic.KeyValuePair<string, int> x));
            TRVCategorySelection.<>c.<>9__34_0 = val_17;
        }
        
            System.Collections.Generic.KeyValuePair<System.String, System.Int32> val_8 = System.Linq.Enumerable.FirstOrDefault<System.Collections.Generic.KeyValuePair<System.String, System.Int32>>(source:  MonoSingleton<TRVDataParser>.Instance.CategoryUnlockLevels, predicate:  val_7);
            val_14 = val_8.Value;
            if((MonoSingleton<TRVDataParser>.Instance.IsValidSubCategory(cat:  val_14)) != false)
        {
                TRVDataParser val_11 = MonoSingleton<TRVDataParser>.Instance;
            val_18 = (val_11.<playerPersistance>k__BackingField._earlyUnlockedCategories.Contains(item:  val_14)) ^ 1;
            return (bool)val_18 & 1;
        }
        
        }
        
        val_18 = 0;
        return (bool)val_18 & 1;
    }
    private void OnEnable()
    {
        if(this.onStartAction != null)
        {
                this.onStartAction.Invoke();
        }
        
        this.onStartAction = 0;
    }
    private void Start()
    {
        DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  public System.Void TRVCategorySelection::OnCloseButtonPressed()));
    }
    private void OnDisable()
    {
        DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  public System.Void TRVCategorySelection::OnCloseButtonPressed()));
    }
    private System.Collections.IEnumerator animateCategorySelection(TRVCategorySelectionInfo selectedCat, System.Collections.Generic.List<string> incCats, TRVCategoryButton thisCatButton)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .selectedCat = selectedCat;
        .thisCatButton = thisCatButton;
        .incCats = incCats;
        return (System.Collections.IEnumerator)new TRVCategorySelection.<animateCategorySelection>d__38();
    }
    private void PlayLastCategoryPlayed(TRVCategorySelectionInfo cat)
    {
        this.PlayCategory(cat:  cat);
    }
    private void PlayEarlyUnlockCategory(TRVCategorySelectionInfo cat)
    {
        this.PlayCategory(cat:  cat);
    }
    private void PlayCategoryFromAnimation(TRVCategorySelectionInfo cat)
    {
        this.PlayCategory(cat:  cat);
    }
    private void PlayCategoryFromInit(TRVCategorySelectionInfo cat)
    {
        this.PlayCategory(cat:  cat);
    }
    private void PlayCategory(TRVCategorySelectionInfo cat)
    {
        var val_7;
        if((TRVSpecialCategoriesManager.IsSpecialCategory(subcategory:  cat.categoryName)) != false)
        {
                MonoSingleton<TRVSpecialCategoriesManager>.Instance.OnCategorySelected(selectionInfo:  cat);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
        }
        
        CPlayerPrefs.SetString(key:  "lstCatPlayed", val:  cat.categoryName);
        WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
        val_4.sound.PlayGameSpecificSound(id:  "TRVCategorySelected", clipIndex:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        val_7 = null;
        val_7 = null;
        TRVMainController.noAnswerSelectedCharacter = 0;
        MonoSingleton<TRVMainController>.Instance.OnCategorySelected(selectedSubCat:  cat, selectedPrimaryCat:  "");
        CPlayerPrefs.Save();
    }
    private void SetupLastCategoryButton(bool rolling)
    {
        var val_17;
        object val_18;
        var val_19;
        UnityEngine.UI.Text val_20;
        bool val_21;
        var val_22;
        val_18 = this;
        if(App.Player == 1)
        {
            goto label_13;
        }
        
        val_19 = "lstCatPlayed";
        if((System.String.IsNullOrEmpty(value:  CPlayerPrefs.GetString(key:  "lstCatPlayed", defaultValue:  ""))) == true)
        {
            goto label_13;
        }
        
        val_17 = MonoSingleton<TRVDataParser>.Instance;
        if((val_17.IsValidSubCategory(cat:  CPlayerPrefs.GetString(key:  "lstCatPlayed", defaultValue:  ""))) == false)
        {
            goto label_13;
        }
        
        this.lastCategoryLockedGroup.SetActive(value:  false);
        this.lastCategoryUnlockedGroup.SetActive(value:  true);
        this.lastCategoryButton.m_OnClick.RemoveAllListeners();
        this.lastCategoryButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVCategorySelection::PressLastCategoryButton()));
        this.lastCategoryImage.sprite = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  CPlayerPrefs.GetString(key:  "lstCatPlayed"));
        val_20 = this.lastCategoryText;
        string val_12 = TRVCategorySelection.ToUpperCategory(category:  CPlayerPrefs.GetString(key:  "lstCatPlayed"));
        if(rolling == false)
        {
            goto label_28;
        }
        
        val_21 = 0;
        goto label_29;
        label_13:
        this.lastCategoryLockedGroup.SetActive(value:  true);
        this.lastCategoryUnlockedGroup.SetActive(value:  false);
        this.lastCategoryButton.interactable = false;
        this.lastCategoryButton.gameObject.SetActive(value:  false);
        return;
        label_28:
        this.lastCategoryButton.interactable = true;
        val_19 = 1152921504956633088;
        val_18 = this.currentCategories;
        val_22 = null;
        val_22 = null;
        val_20 = TRVCategorySelection.<>c.<>9__44_0;
        if(val_20 == null)
        {
                System.Func<TRVCategorySelectionInfo, System.Boolean> val_14 = null;
            val_20 = val_14;
            val_14 = new System.Func<TRVCategorySelectionInfo, System.Boolean>(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVCategorySelection.<>c::<SetupLastCategoryButton>b__44_0(TRVCategorySelectionInfo x));
            TRVCategorySelection.<>c.<>9__44_0 = val_20;
        }
        
        val_21 = (~(System.Linq.Enumerable.Any<TRVCategorySelectionInfo>(source:  val_18, predicate:  val_14))) & 1;
        label_29:
        this.lastCategoryButton.interactable = val_21;
    }
    private void PressLastCategoryButton()
    {
        var val_17;
        System.Func<TRVCategorySelectionInfo, System.Boolean> val_19;
        if(App.Player == 1)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  CPlayerPrefs.GetString(key:  "lstCatPlayed", defaultValue:  ""))) == true)
        {
                return;
        }
        
        val_17 = null;
        val_17 = null;
        val_19 = TRVCategorySelection.<>c.<>9__45_0;
        if(val_19 == null)
        {
                System.Func<TRVCategorySelectionInfo, System.Boolean> val_4 = null;
            val_19 = val_4;
            val_4 = new System.Func<TRVCategorySelectionInfo, System.Boolean>(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVCategorySelection.<>c::<PressLastCategoryButton>b__45_0(TRVCategorySelectionInfo x));
            TRVCategorySelection.<>c.<>9__45_0 = val_19;
        }
        
        if((System.Linq.Enumerable.Any<TRVCategorySelectionInfo>(source:  this.currentCategories, predicate:  val_4)) == true)
        {
                return;
        }
        
        if((MonoSingleton<TRVDataParser>.Instance.IsValidSubCategory(cat:  CPlayerPrefs.GetString(key:  "lstCatPlayed", defaultValue:  ""))) == false)
        {
                return;
        }
        
        Player val_9 = App.Player;
        TRVEcon val_10 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_9._gems < val_10.playLastCategoryCost)
        {
                this.OpenGemStore(tpp:  99);
            return;
        }
        
        TRVEcon val_12 = App.GetGameSpecificEcon<TRVEcon>();
        App.Player.AddGems(amount:  -val_12.playLastCategoryCost, source:  "LastCategory", subsource:  0);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "GemStatViewUpdate");
        .categoryName = CPlayerPrefs.GetString(key:  "lstCatPlayed");
        .associatedEvents = new System.Collections.Generic.List<WGEventHandler>();
        this.PlayCategory(cat:  new TRVCategorySelectionInfo());
    }
    public void OnReroll()
    {
        MonoSingleton<TRVMainController>.Instance.RerollCategory(onRerollSuccess:  new System.Action(object:  this, method:  System.Void TRVCategorySelection::<OnReroll>b__46_0()), onRerollFailed:  new System.Action(object:  this, method:  System.Void TRVCategorySelection::<OnReroll>b__46_1()));
    }
    private System.Collections.IEnumerator CheckCrazyCategories()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVCategorySelection.<CheckCrazyCategories>d__47();
    }
    private void OnRevealComplete()
    {
        var val_2;
        var val_3;
        var val_9;
        UnityEngine.GameObject val_10;
        List.Enumerator<T> val_1 = this.catButtons.GetEnumerator();
        label_9:
        val_9 = public System.Boolean List.Enumerator<TRVCategoryButton>::MoveNext();
        if(val_3.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_10 = val_2;
        if(val_10 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_9 = public UnityEngine.UI.Button UnityEngine.Component::GetComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Button val_5 = val_10.GetComponent<UnityEngine.UI.Button>();
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9 = 1;
        val_5.interactable = true;
        val_10 = this.rerollCostParent;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9 = 0;
        UnityEngine.GameObject val_6 = val_10.gameObject;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9 = 1;
        val_6.SetActive(value:  true);
        val_10 = this.revealParent;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9 = 0;
        UnityEngine.GameObject val_7 = val_10.gameObject;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_7.SetActive(value:  false);
        goto label_9;
        label_2:
        val_3.Dispose();
        string val_8 = Localization.Localize(key:  "trv_category_choose", defaultValue:  "Tap to choose a Category!", useSingularKey:  false);
        this.rerollButton.interactable = this.rerollActive;
        this.SetupLastCategoryButton(rolling:  false);
    }
    public void UpdateCategoryUnlockButton(string category)
    {
        .<>4__this = this;
        this.forcedPlayNowCategory = category;
        UnityEngine.Vector2 val_2 = this.nextCatTransform.sizeDelta;
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  val_2.x, y:  262f);
        this.nextCatTransform.sizeDelta = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
        this.newCategoryGroup.gameObject.SetActive(value:  true);
        this.nextCategoryGroup.gameObject.SetActive(value:  false);
        string val_6 = TRVCategorySelection.ToUpperCategory(category:  category);
        this.recentCategoryImage.sprite = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  category);
        this.newCategoryButton.m_OnClick.RemoveAllListeners();
        .unlockedCatInfo = new TRVCategorySelectionInfo();
        .categoryName = category;
        (TRVCategorySelection.<>c__DisplayClass49_0)[1152921517226079024].unlockedCatInfo.associatedEvents = new System.Collections.Generic.List<WGEventHandler>();
        this.newCategoryButton.m_OnClick.RemoveAllListeners();
        this.newCategoryButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new TRVCategorySelection.<>c__DisplayClass49_0(), method:  System.Void TRVCategorySelection.<>c__DisplayClass49_0::<UpdateCategoryUnlockButton>b__0()));
    }
    private bool CanReroll()
    {
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        return true;
    }
    private void OpenStore()
    {
        var val_5;
        var val_6;
        System.Action val_8;
        val_5 = null;
        val_5 = null;
        PurchaseProxy.currentPurchasePoint = 86;
        GameBehavior val_1 = App.getBehavior;
        val_6 = null;
        val_6 = null;
        val_8 = TRVCategorySelection.<>c.<>9__51_0;
        if(val_8 == null)
        {
                System.Action val_3 = null;
            val_8 = val_3;
            val_3 = new System.Action(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVCategorySelection.<>c::<OpenStore>b__51_0());
            TRVCategorySelection.<>c.<>9__51_0 = val_8;
        }
        
        val_1.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  val_3);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OpenGemStore(TrackerPurchasePoints tpp = 86)
    {
        var val_6;
        var val_7;
        System.Action val_9;
        val_6 = null;
        val_6 = null;
        PurchaseProxy.currentPurchasePoint = tpp;
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        GameBehavior val_2 = App.getBehavior;
        val_7 = null;
        val_7 = null;
        val_9 = TRVCategorySelection.<>c.<>9__52_0;
        if(val_9 == null)
        {
                System.Action val_4 = null;
            val_9 = val_4;
            val_4 = new System.Action(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVCategorySelection.<>c::<OpenGemStore>b__52_0());
            TRVCategorySelection.<>c.<>9__52_0 = val_9;
        }
        
        val_2.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  val_4);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void OnHomeButtonPressed()
    {
        var val_5;
        System.Action val_7;
        GameBehavior val_1 = App.getBehavior;
        val_5 = null;
        val_5 = null;
        val_7 = TRVCategorySelection.<>c.<>9__53_0;
        if(val_7 == null)
        {
                System.Action val_3 = null;
            val_7 = val_3;
            val_3 = new System.Action(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVCategorySelection.<>c::<OnHomeButtonPressed>b__53_0());
            TRVCategorySelection.<>c.<>9__53_0 = val_7;
        }
        
        mem2[0] = val_7;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void OnCloseButtonPressed()
    {
        GameBehavior val_1 = App.getBehavior;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVCategorySelection()
    {
    
    }
    private void <OnReroll>b__46_0()
    {
        var val_5;
        System.Func<TRVCategorySelectionInfo, System.String> val_7;
        val_5 = null;
        val_5 = null;
        val_7 = TRVCategorySelection.<>c.<>9__46_2;
        if(val_7 == null)
        {
                System.Func<TRVCategorySelectionInfo, System.String> val_2 = null;
            val_7 = val_2;
            val_2 = new System.Func<TRVCategorySelectionInfo, System.String>(object:  TRVCategorySelection.<>c.__il2cppRuntimeField_static_fields, method:  System.String TRVCategorySelection.<>c::<OnReroll>b__46_2(TRVCategorySelectionInfo x));
            TRVCategorySelection.<>c.<>9__46_2 = val_7;
        }
        
        MonoSingleton<TRVMainController>.Instance.Init(currentlySelectedCategores:  System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Select<TRVCategorySelectionInfo, System.String>(source:  this.prevInitCategories, selector:  val_2)), fromReroll:  true);
    }
    private void <OnReroll>b__46_1()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
