using UnityEngine;
public class CategoryPackPurchasePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text unlockBlurbLabel;
    private UnityEngine.UI.Text unlockCostLabel;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button unlockButton;
    private UnityEngine.UI.Text unlockButtonLabel;
    private UnityEngine.UI.Image unlockWaitingIcon;
    private int currentActionedPackId;
    
    // Methods
    private void Start()
    {
        this.unlockButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void CategoryPackPurchasePopup::OnPackUnlockConfirm()));
        CategoryPacksManager val_2 = MonoSingleton<CategoryPacksManager>.Instance;
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.OnPackPurchaseComplete, b:  new System.Action<System.Boolean, System.Int32>(object:  this, method:  System.Void CategoryPackPurchasePopup::OnPurchaseComplete(bool isSuccessful, int packId)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_7;
        }
        
        }
        
        val_2.OnPackPurchaseComplete = val_4;
        return;
        label_7:
    }
    private void OnDestroy()
    {
        CategoryPacksManager val_1 = MonoSingleton<CategoryPacksManager>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnPackPurchaseComplete, value:  new System.Action<System.Boolean, System.Int32>(object:  this, method:  System.Void CategoryPackPurchasePopup::OnPurchaseComplete(bool isSuccessful, int packId)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnPackPurchaseComplete = val_3;
        return;
        label_5:
    }
    public void Show(int packId)
    {
        this.currentActionedPackId = packId;
        decimal val_2 = MonoSingleton<CategoryPacksManager>.Instance.GetPackUnlockCost(packId:  packId);
        CategoryColor val_6 = MonoSingleton<CategoryPacksManager>.Instance.GetColor(colorCode:  val_4.color);
        string val_10 = System.String.Format(format:  "{0}\n<color=#{1}>{2}?</color>", arg0:  Localization.Localize(key:  "unlock_pack", defaultValue:  "Unlock", useSingularKey:  false), arg1:  UnityEngine.ColorUtility.ToHtmlStringRGBA(color:  new UnityEngine.Color() {r = val_6.colorValue}), arg2:  MonoSingleton<CategoryPacksManager>.Instance.GetPackInfo(packId:  packId).FullTitle);
        string val_11 = val_2.flags.ToString();
        string val_12 = Localization.Localize(key:  "unlock_upper", defaultValue:  "UNLOCK", useSingularKey:  false);
        this.gameObject.SetActive(value:  true);
    }
    private void SetLoadingUI(bool isVisible)
    {
        bool val_6 = isVisible;
        this.unlockWaitingIcon.gameObject.SetActive(value:  val_6);
        bool val_4 = val_6 ^ 1;
        val_6 = val_4;
        this.unlockButtonLabel.gameObject.SetActive(value:  val_6);
        this.unlockButton.interactable = val_6;
        this.closeButton.interactable = val_4;
    }
    private void OnPackUnlockConfirm()
    {
        MonoSingleton<CategoryPacksManager>.Instance.PurchasePack(packToPurchase:  this.currentActionedPackId);
    }
    private void CloseWindow()
    {
        this.gameObject.SetActive(value:  false);
    }
    private void OnPurchaseComplete(bool isSuccessful, int packId)
    {
        var val_3;
        if(isSuccessful != true)
        {
                val_3 = null;
            val_3 = null;
            PurchaseProxy.currentPurchasePoint = 69;
            MonoSingleton<CategoriesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  0);
        }
        
        this.CloseWindow();
    }
    public CategoryPackPurchasePopup()
    {
        this.currentActionedPackId = 0;
    }

}
