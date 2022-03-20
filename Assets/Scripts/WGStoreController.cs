using UnityEngine;
public class WGStoreController : MonoSingletonSelfGenerating<WGStoreController>
{
    // Fields
    public System.Action<PurchaseModel> OnStorePurchaseSuccess;
    public System.Action<string, string> OnStorePurchaseFailed;
    
    // Methods
    private void Start()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStoreController::PurchasesHandler_OnPurchaseCompleted(PurchaseModel obj)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        System.Delegate val_4 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStoreController::PurchasesHandler_OnPurchaseFailure(PurchaseModel obj)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_4;
        return;
        label_6:
    }
    private void PurchasesHandler_OnPurchaseCompleted(PurchaseModel obj)
    {
        if((obj.ContainsInstruction(instruction:  2)) == false)
        {
                return;
        }
        
        string val_3 = System.String.Format(format:  "WGStoreController.PurchasesHandler_OnPurchaseCompleted :: {0}", arg0:  obj.ToShortString());
        SLCDebug.Log(logMessage:  val_3, colorHash:  "#43F799", isError:  false);
        val_3.HandlePurchaseSuccess(purchase:  obj);
    }
    private void PurchasesHandler_OnPurchaseFailure(PurchaseModel obj)
    {
        System.Action val_7;
        var val_8;
        if((obj.ContainsInstruction(instruction:  2)) == false)
        {
                return;
        }
        
        SLCDebug.Log(logMessage:  System.String.Format(format:  "WGStoreController.PurchasesHandler_OnPurchaseFailure :: {0}", arg0:  obj.ToShortString()), colorHash:  "#F220EB", isError:  false);
        val_7 = 0;
        val_8 = null;
        val_8 = null;
        if((WGStoreController.<>c.<>9__2_0) == null)
        {
                System.Action val_6 = null;
            val_7 = 0;
            val_6 = new System.Action(object:  WGStoreController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGStoreController.<>c::<PurchasesHandler_OnPurchaseFailure>b__2_0());
            WGStoreController.<>c.<>9__2_0 = val_6;
        }
        
        this.HandlePurchaseFailed(title:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), message:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false), onCloseMessageAction:  val_7);
    }
    public System.Collections.Generic.List<PurchaseModel> RetrievePurchasePacks()
    {
        System.Collections.IList val_1 = PackagesManager.GetPackages(packageType:  "credits");
        if(val_1 == null)
        {
                UnityEngine.Debug.LogError(message:  "No packages found in PackagesManager.GetPackages()... PROBABLY NOT THE RIGHT GAME OR SOMETHING.");
        }
        
        System.Collections.Generic.List<PurchaseModel> val_2 = PurchaseModelsFromPacks(packs:  val_1);
        GameBehavior val_3 = App.getBehavior;
        float val_4 = PackagesManager.GetBestValuePackPrice(unfiltered:  val_3.<metaGameBehavior>k__BackingField);
        return (System.Collections.Generic.List<PurchaseModel>)val_3.<metaGameBehavior>k__BackingField;
    }
    public System.Collections.Generic.List<PurchaseModel> RetrieveGemPurchasePacks()
    {
        System.Collections.IList val_1 = PackagesManager.GetPackages(packageType:  "gems");
        if(val_1 != null)
        {
                return PurchaseModelsFromPacks(packs:  val_1);
        }
        
        UnityEngine.Debug.LogError(message:  "No packages found in PackagesManager.GetPackages()... PROBABLY NOT THE RIGHT GAME OR SOMETHING.");
        return PurchaseModelsFromPacks(packs:  val_1);
    }
    public System.Collections.Generic.List<PurchaseModel> RetrievePetsFoodPurchasePacks()
    {
        System.Collections.IList val_1 = PackagesManager.GetPackages(packageType:  "pets_food");
        if(val_1 != null)
        {
                return PurchaseModelsFromPacks(packs:  val_1);
        }
        
        UnityEngine.Debug.LogError(message:  "No packages found in PackagesManager.GetPackages()... PROBABLY NOT THE RIGHT GAME OR SOMETHING.");
        return PurchaseModelsFromPacks(packs:  val_1);
    }
    public System.Collections.Generic.List<PurchaseModel> RetrieveSpinPurchasePacks()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return 0;
        }
        
        System.Collections.IList val_2 = PackagesManager.GetPackages(packageType:  "spins");
        if(val_2 != null)
        {
                return PurchaseModelsFromPacks(packs:  val_2);
        }
        
        UnityEngine.Debug.LogError(message:  "No packages found in PackagesManager.GetPackages()... PROBABLY NOT THE RIGHT GAME OR SOMETHING.");
        return PurchaseModelsFromPacks(packs:  val_2);
    }
    public System.Collections.Generic.List<PurchaseModel> RetrieveDiceRollsPurchasePacks()
    {
        System.Collections.IList val_1 = PackagesManager.GetPackages(packageType:  "dice_rolls");
        if(val_1 != null)
        {
                return PurchaseModelsFromPacks(packs:  val_1);
        }
        
        UnityEngine.Debug.LogError(message:  "No packages found in PackagesManager.GetPackages()... PROBABLY NOT THE RIGHT GAME OR SOMETHING.");
        return PurchaseModelsFromPacks(packs:  val_1);
    }
    private System.Collections.Generic.List<PurchaseModel> PurchaseModelsFromPacks(System.Collections.IList packs)
    {
        PurchaseModel val_10;
        var val_11;
        System.Collections.Generic.List<PurchaseModel> val_1 = new System.Collections.Generic.List<PurchaseModel>();
        if(packs == null)
        {
                throw new NullReferenceException();
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        System.Collections.IEnumerator val_3 = packs.GetEnumerator();
        label_20:
        var val_10 = 0;
        val_10 = val_10 + 1;
        if(val_3.MoveNext() == false)
        {
            goto label_11;
        }
        
        var val_11 = 0;
        val_11 = val_11 + 1;
        val_10 = new PurchaseModel();
        val_10 = new PurchaseModel(json:  val_3.Current);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  new PurchaseModel());
        goto label_20;
        label_11:
        val_10 = 0;
        if(X0 == false)
        {
            goto label_21;
        }
        
        var val_14 = X0;
        if((X0 + 294) == 0)
        {
            goto label_25;
        }
        
        var val_12 = X0 + 176;
        var val_13 = 0;
        val_12 = val_12 + 8;
        label_24:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_23;
        }
        
        val_13 = val_13 + 1;
        val_12 = val_12 + 16;
        if(val_13 < (X0 + 294))
        {
            goto label_24;
        }
        
        goto label_25;
        label_23:
        val_14 = val_14 + (((X0 + 176 + 8)) << 4);
        val_11 = val_14 + 304;
        label_25:
        X0.Dispose();
        label_21:
        if(val_10 != 0)
        {
                throw val_10;
        }
        
        return val_1;
    }
    public void Purchase(PurchaseModel purchase)
    {
        System.Action val_6;
        var val_7;
        purchase.AddInstruction(instruction:  2);
        if((PurchaseProxy.Purchase(purchase:  purchase)) != false)
        {
                NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnInAppPurchaseStarted");
            return;
        }
        
        val_6 = 0;
        val_7 = null;
        val_7 = null;
        if((WGStoreController.<>c.<>9__9_0) == null)
        {
                System.Action val_5 = null;
            val_6 = 0;
            val_5 = new System.Action(object:  WGStoreController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGStoreController.<>c::<Purchase>b__9_0());
            WGStoreController.<>c.<>9__9_0 = val_5;
        }
        
        this.HandlePurchaseFailed(title:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), message:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\\n\\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), onCloseMessageAction:  val_6);
    }
    public void HandlePurchaseSuccess(PurchaseModel purchase)
    {
        if((MonoSingleton<GameStoreUI>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<GameStoreUI>.Instance.DisplayPurchaseSuccess(purchase:  purchase);
    }
    public void HandlePurchaseFailed(string title, string message, System.Action onCloseMessageAction)
    {
        if(this.OnStorePurchaseFailed != null)
        {
                this.OnStorePurchaseFailed.Invoke(arg1:  title, arg2:  message);
            return;
        }
        
        if((MonoSingleton<GameStoreUI>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<GameStoreUI>.Instance.DisplayPurchaseFail(title:  title, message:  message);
    }
    public bool OpenStore(bool forceShowNext = False)
    {
        GameBehavior val_1 = App.getBehavior;
        bool val_3 = forceShowNext;
        return true;
    }
    public WGStoreController()
    {
    
    }

}
