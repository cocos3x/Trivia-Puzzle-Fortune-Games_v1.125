using UnityEngine;
public class TRVLossAversionPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text descText;
    private UnityEngine.UI.Text costText;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button exitQuizButton;
    private UnityEngine.UI.Image chestImage;
    private UnityEngine.Sprite bronzeChest;
    private UnityEngine.Sprite silverChest;
    private UnityEngine.Sprite goldenChest;
    private GemsCollectAnimationInstantiator gcAnim;
    private UnityEngine.GameObject mainGroup;
    private UnityEngine.GameObject streakBrokenGroup;
    private CurrencyStatViewInstantiator streakStatViewInstantiator;
    private UnityEngine.UI.Image streakImage;
    private UnityEngine.Sprite streakSprite;
    private UnityEngine.Sprite brokenStreakSprite;
    private UnityEngine.UI.Text streakText;
    private TweenCoinsText streakAmountText;
    
    // Methods
    private System.Collections.IEnumerator Start()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVLossAversionPopup.<Start>d__17();
    }
    private void OnClickContinue()
    {
        var val_14;
        var val_15;
        System.Action val_17;
        Player val_1 = App.Player;
        if((MonoSingleton<TRVMainController>.Instance.PurchaseExtraLife(updateGems:  false, addExtraLife:  true)) != false)
        {
                this.continueButton.interactable = false;
            this.exitQuizButton.interactable = false;
            UnityEngine.Vector3 val_5 = this.continueButton.transform.position;
            Player val_6 = App.Player;
            PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, particleCount:  val_1._gems - val_6._gems, animateStatView:  true);
            mem2[0] = new System.Action(object:  this, method:  System.Void TRVLossAversionPopup::<OnClickContinue>b__18_0());
            return;
        }
        
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        val_14 = null;
        val_14 = null;
        PurchaseProxy.currentPurchasePoint = 98;
        GameBehavior val_10 = App.getBehavior;
        val_15 = null;
        val_15 = null;
        val_17 = TRVLossAversionPopup.<>c.<>9__18_1;
        if(val_17 == null)
        {
                System.Action val_12 = null;
            val_17 = val_12;
            val_12 = new System.Action(object:  TRVLossAversionPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLossAversionPopup.<>c::<OnClickContinue>b__18_1());
            TRVLossAversionPopup.<>c.<>9__18_1 = val_17;
        }
        
        val_10.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_12);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnGemStoreButtonClicked()
    {
        var val_6;
        var val_7;
        System.Action val_9;
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        val_6 = null;
        val_6 = null;
        PurchaseProxy.currentPurchasePoint = 98;
        GameBehavior val_2 = App.getBehavior;
        val_7 = null;
        val_7 = null;
        val_9 = TRVLossAversionPopup.<>c.<>9__19_0;
        if(val_9 == null)
        {
                System.Action val_4 = null;
            val_9 = val_4;
            val_4 = new System.Action(object:  TRVLossAversionPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVLossAversionPopup.<>c::<OnGemStoreButtonClicked>b__19_0());
            TRVLossAversionPopup.<>c.<>9__19_0 = val_9;
        }
        
        val_2.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  val_4);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickNoThanks()
    {
        MonoSingleton<TRVStreakManager>.Instance.BreakStreak();
        MonoSingleton<TRVMainController>.Instance.ConcludeQuestionComplete();
        this.continueButton.interactable = false;
        this.exitQuizButton.interactable = false;
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.animateStreakBreaking(preStreak:  MonoSingleton<TRVStreakManager>.Instance.getCurrentStreak));
    }
    private System.Collections.IEnumerator animateStreakBreaking(int preStreak)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .preStreak = preStreak;
        return (System.Collections.IEnumerator)new TRVLossAversionPopup.<animateStreakBreaking>d__21();
    }
    private void SetChestSprite()
    {
        UnityEngine.Sprite val_2;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        if(val_1.currentGame.myChest == 2)
        {
            goto label_5;
        }
        
        if(val_1.currentGame.myChest == 1)
        {
            goto label_6;
        }
        
        if(val_1.currentGame.myChest != 0)
        {
                return;
        }
        
        val_2 = this.bronzeChest;
        goto label_11;
        label_6:
        val_2 = this.silverChest;
        goto label_11;
        label_5:
        val_2 = this.goldenChest;
        label_11:
        this.chestImage.sprite = val_2;
    }
    public TRVLossAversionPopup()
    {
    
    }
    private void <Start>b__17_0()
    {
        if((GetComponent<WGConnectionlessPopupButton>()) != 0)
        {
                UnityEngine.Object.Destroy(obj:  GetComponent<WGConnectionlessPopupButton>());
        }
        
        mem[41963768].RemoveAllListeners();
        mem[41963768].AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVLossAversionPopup::OnGemStoreButtonClicked()));
        gameObject.SetActive(value:  true);
    }
    private void <OnClickContinue>b__18_0()
    {
        MonoSingleton<TRVMainController>.Instance.OnExtraLifeClicked();
        GameBehavior val_2 = App.getBehavior;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "GemStatViewUpdate");
    }

}
