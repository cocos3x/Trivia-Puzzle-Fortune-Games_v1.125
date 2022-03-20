using UnityEngine;
public class TRVExpertsCollectionPopup : MonoBehaviour
{
    // Fields
    private TRVExpertDisplay expertDisplayPrefab;
    private TRVExpertCategoryDisplay catDisplayPrefab;
    private UnityEngine.Transform catDisplayParent;
    private UnityEngine.UI.Button infoButton;
    private UnityEngine.UI.Button homeButton;
    private UnityEngine.UI.Button coinStoreButton;
    private UnityEngine.UI.Button gemStoreButton;
    private UnityEngine.GameObject infoPopup;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.UI.Text infoCooldownText;
    private UnityEngine.UI.ScrollRect expertScrollRect;
    private System.Collections.Generic.List<TRVExpertCategoryDisplay> catDisplays;
    private TRVExpertCategoryDisplay upgradeDisplay;
    public System.Action onStartAction;
    
    // Methods
    public System.Collections.IEnumerator Start()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVExpertsCollectionPopup.<Start>d__14();
    }
    private void Init()
    {
        TRVCategoryExpertEcon val_10;
        int val_11;
        UnityEngine.Transform val_26;
        System.Collections.Generic.List<TRVExpertCategoryDisplay> val_27;
        var val_28;
        var val_29;
        System.Func<TRVCategoryExpertEcon, System.Int32> val_31;
        this.infoPopup.gameObject.SetActive(value:  false);
        TRVExpertsController val_2 = MonoSingleton<TRVExpertsController>.Instance;
        this.catDisplays = new System.Collections.Generic.List<TRVExpertCategoryDisplay>();
        if(1152921517153960448 >= 1)
        {
                this.upgradeDisplay = UnityEngine.Object.Instantiate<TRVExpertCategoryDisplay>(original:  this.catDisplayPrefab, parent:  this.catDisplayParent);
            .upgradeOnlyEcon = true;
            .Category = Localization.Localize(key:  "experts_category_upgrade_ready", defaultValue:  "UPGRADE READY!", useSingularKey:  false);
            .experts = MonoSingleton<TRVExpertsController>.Instance.GetAllExpertsReadyToUpgrade();
            this.upgradeDisplay.Init(displayPrefab:  this.expertDisplayPrefab, incEcon:  new TRVCategoryExpertEcon(), myPopup:  this);
        }
        
        List.Enumerator<T> val_9 = val_2.myEcon.econs.GetEnumerator();
        label_20:
        if(val_11.MoveNext() == false)
        {
            goto label_15;
        }
        
        val_26 = this.catDisplayParent;
        TRVExpertCategoryDisplay val_13 = UnityEngine.Object.Instantiate<TRVExpertCategoryDisplay>(original:  this.catDisplayPrefab, parent:  val_26);
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26 = this.expertDisplayPrefab;
        val_13.Init(displayPrefab:  val_26, incEcon:  val_10, myPopup:  this);
        val_27 = this.catDisplays;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        val_27.Add(item:  val_13);
        goto label_20;
        label_15:
        val_11.Dispose();
        val_28 = 1152921504893161472;
        TRVExpertsController val_14 = MonoSingleton<TRVExpertsController>.Instance;
        val_11 = val_14.myExperts.Count;
        val_29 = null;
        val_29 = null;
        val_31 = TRVExpertsCollectionPopup.<>c.<>9__15_0;
        if(val_31 == null)
        {
                System.Func<TRVCategoryExpertEcon, System.Int32> val_16 = null;
            val_31 = val_16;
            val_16 = new System.Func<TRVCategoryExpertEcon, System.Int32>(object:  TRVExpertsCollectionPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVExpertsCollectionPopup.<>c::<Init>b__15_0(TRVCategoryExpertEcon x));
            TRVExpertsCollectionPopup.<>c.<>9__15_0 = val_31;
            val_28 = 1152921504893161472;
        }
        
        val_11 = System.Linq.Enumerable.Sum<TRVCategoryExpertEcon>(source:  val_2.myEcon.econs, selector:  val_16);
        string val_18 = System.String.Format(format:  "{0}/{1}", arg0:  val_11, arg1:  val_11);
        this.coinStoreButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertsCollectionPopup::OnClickCoinBalance()));
        this.gemStoreButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertsCollectionPopup::OnClickGemBalance()));
        this.homeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertsCollectionPopup::Close()));
        this.infoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertsCollectionPopup::<Init>b__15_1()));
        string val_25 = System.String.Format(format:  "Each expert can only be asked once every {0} hours.", arg0:  MonoSingleton<TRVExpertsController>.Instance.getExpertCooldown);
    }
    public void DisplayExpert(TRVExpert expert, TRVExpertProgressData data, TRVExpertDisplay display)
    {
        System.Collections.Generic.List<TRVExpertCategoryDisplay> val_10;
        UnityEngine.Object val_11;
        TRVExpertsCollectionPopup.<>c__DisplayClass16_0 val_1 = null;
        val_11 = 0;
        val_1 = new TRVExpertsCollectionPopup.<>c__DisplayClass16_0();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .<>4__this = this;
        .expert = expert;
        .data = data;
        .display = display;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_2.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = mem[(1152921504946249728 + (public TRVExpertsProfilePopup MetaGameBehavior::ShowUGUIFlyOut<TRVExpertsProfilePopup>().__il2cppRuntimeField_48) << 4) + 312];
        val_10 = val_2.<metaGameBehavior>k__BackingField;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.Init(expert:  (TRVExpertsCollectionPopup.<>c__DisplayClass16_0)[1152921517154566096].expert, data:  (TRVExpertsCollectionPopup.<>c__DisplayClass16_0)[1152921517154566096].data);
        val_11 = 0;
        if(((TRVExpertsCollectionPopup.<>c__DisplayClass16_0)[1152921517154566096].display) != val_11)
        {
            goto label_22;
        }
        
        val_10 = this.catDisplays;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_5 = val_10.GetEnumerator();
        label_14:
        val_11 = public System.Boolean List.Enumerator<TRVExpertCategoryDisplay>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_11;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_10 = 64;
        if(val_10 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_10.ContainsKey(key:  (TRVExpertsCollectionPopup.<>c__DisplayClass16_0)[1152921517154566096].expert)) == false)
        {
            goto label_14;
        }
        
        .display = 64.Item[(TRVExpertsCollectionPopup.<>c__DisplayClass16_0)[1152921517154566096].expert];
        label_11:
        0.Dispose();
        label_22:
        mem2[0] = new System.Action(object:  val_1, method:  System.Void TRVExpertsCollectionPopup.<>c__DisplayClass16_0::<DisplayExpert>b__0());
    }
    private void UpdateExpert(TRVExpert exp, TRVExpertProgressData data, TRVExpertDisplay display)
    {
        var val_3;
        var val_4;
        UnityEngine.Object val_10;
        TRVExpertCategoryDisplay val_11;
        TRVExpertCategoryDisplay val_12;
        UnityEngine.Object val_13;
        val_10 = display;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.Init(me:  exp, progress:  data, upgraded:  false, showName:  false);
        val_12 = this.upgradeDisplay;
        val_13 = 0;
        if(val_12 == val_13)
        {
                return;
        }
        
        val_11 = this.upgradeDisplay;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.RefreshDisplay();
        val_11 = this.catDisplays;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_2 = val_11.GetEnumerator();
        val_12 = 1152921517154478352;
        label_10:
        val_13 = public System.Boolean List.Enumerator<TRVExpertCategoryDisplay>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_7;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_11 = mem[val_3 + 32];
        val_11 = val_3 + 32;
        if(val_11 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_11.ContainsKey(key:  exp)) == false)
        {
            goto label_10;
        }
        
        val_10 = val_3 + 32.Item[exp];
        label_7:
        val_4.Dispose();
        val_11 = val_10;
        val_13 = 0;
        if(val_11 == val_13)
        {
                return;
        }
        
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.Init(me:  exp, progress:  data, upgraded:  false, showName:  false);
    }
    private void OnClickCoinBalance()
    {
        var val_5;
        var val_6;
        System.Action val_8;
        val_5 = null;
        val_5 = null;
        PurchaseProxy.currentPurchasePoint = 87;
        GameBehavior val_1 = App.getBehavior;
        val_6 = null;
        val_6 = null;
        val_8 = TRVExpertsCollectionPopup.<>c.<>9__18_0;
        if(val_8 == null)
        {
                System.Action val_3 = null;
            val_8 = val_3;
            val_3 = new System.Action(object:  TRVExpertsCollectionPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVExpertsCollectionPopup.<>c::<OnClickCoinBalance>b__18_0());
            TRVExpertsCollectionPopup.<>c.<>9__18_0 = val_8;
        }
        
        val_1.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  val_3);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickGemBalance()
    {
        var val_6;
        var val_7;
        System.Action val_9;
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        val_6 = null;
        val_6 = null;
        PurchaseProxy.currentPurchasePoint = 87;
        GameBehavior val_2 = App.getBehavior;
        val_7 = null;
        val_7 = null;
        val_9 = TRVExpertsCollectionPopup.<>c.<>9__19_0;
        if(val_9 == null)
        {
                System.Action val_4 = null;
            val_9 = val_4;
            val_4 = new System.Action(object:  TRVExpertsCollectionPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVExpertsCollectionPopup.<>c::<OnClickGemBalance>b__19_0());
            TRVExpertsCollectionPopup.<>c.<>9__19_0 = val_9;
        }
        
        val_2.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  val_4);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVExpertsCollectionPopup()
    {
    
    }
    private void <Init>b__15_1()
    {
        if(this.infoPopup != null)
        {
                this.infoPopup.SetActive(value:  true);
            return;
        }
        
        throw new NullReferenceException();
    }

}
