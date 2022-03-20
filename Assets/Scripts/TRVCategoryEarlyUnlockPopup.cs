using UnityEngine;
public class TRVCategoryEarlyUnlockPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image catImage;
    private UnityEngine.UI.Text catText;
    private UnityEngine.UI.Text unlockCost;
    private UnityEngine.UI.Button unlockButton;
    private UnityEngine.UI.Button closeButton;
    private GemsCollectAnimationInstantiator gca;
    
    // Methods
    public void Init(string cat)
    {
        .<>4__this = this;
        .cat = cat;
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVCategoryEarlyUnlockPopup::Close()));
        this.unlockButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new TRVCategoryEarlyUnlockPopup.<>c__DisplayClass6_0(), method:  System.Void TRVCategoryEarlyUnlockPopup.<>c__DisplayClass6_0::<Init>b__0()));
        this.catImage.sprite = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  (TRVCategoryEarlyUnlockPopup.<>c__DisplayClass6_0)[1152921517217326176].cat);
        TRVEcon val_6 = App.GetGameSpecificEcon<TRVEcon>();
        string val_7 = val_6.earlyCategoryUnlockCost.ToString();
        string val_8 = TRVCategorySelection.ToUpperCategory(category:  (TRVCategoryEarlyUnlockPopup.<>c__DisplayClass6_0)[1152921517217326176].cat);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void UnlockCat(string cat)
    {
        var val_23;
        var val_24;
        UnityEngine.Object val_25;
        .cat = cat;
        Player val_2 = App.Player;
        val_23 = 1152921517052171200;
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_2._gems >= val_3.earlyCategoryUnlockCost)
        {
            goto label_6;
        }
        
        val_24 = null;
        val_24 = null;
        PurchaseProxy.currentPurchasePoint = 104;
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        GameBehavior val_5 = App.getBehavior;
        val_25 = val_5.<metaGameBehavior>k__BackingField;
        val_25.Init(outOfCredits:  true, onCloseAction:  new System.Action(object:  new TRVCategoryEarlyUnlockPopup.<>c__DisplayClass7_0(), method:  System.Void TRVCategoryEarlyUnlockPopup.<>c__DisplayClass7_0::<UnlockCat>b__0()));
        goto label_17;
        label_6:
        MonoSingleton<TRVDataParser>.Instance.UnlockCategoryEarly(euCat:  (TRVCategoryEarlyUnlockPopup.<>c__DisplayClass7_0)[1152921517217623728].cat);
        TRVEcon val_10 = App.GetGameSpecificEcon<TRVEcon>();
        App.Player.AddGems(amount:  -val_10.earlyCategoryUnlockCost, source:  "Early Category Unlock", subsource:  0);
        val_25 = MonoSingleton<WGWindowManager>.Instance.GetWindow<TRVCategorySelection>();
        if(val_25 != 0)
        {
            goto label_30;
        }
        
        UnityEngine.Debug.LogError(message:  "MEGA FAIL");
        label_17:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_30:
        val_25.UpdateCategoryUnlockButton(category:  (TRVCategoryEarlyUnlockPopup.<>c__DisplayClass7_0)[1152921517217623728].cat);
        this.unlockButton.interactable = false;
        mem2[0] = new System.Action(object:  this, method:  System.Void TRVCategoryEarlyUnlockPopup::Close());
        Player val_16 = App.Player;
        TRVEcon val_17 = App.GetGameSpecificEcon<TRVEcon>();
        Player val_18 = App.Player;
        decimal val_19 = System.Decimal.op_Implicit(value:  val_18._gems);
        UnityEngine.GameObject val_20 = this.unlockButton.gameObject;
        this.gca.Play(fromValue:  val_17.earlyCategoryUnlockCost + val_16._gems, toValue:  new System.Decimal() {flags = val_19.flags, hi = val_19.hi, lo = val_19.lo, mid = val_19.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  val_20, originObject:  val_20.gameObject);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVCategoryEarlyUnlockPopup()
    {
    
    }

}
