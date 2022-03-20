using UnityEngine;
public class FoodDisplayManager : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform itemContainer;
    private System.Collections.Generic.List<WGStoreItem_pet> packDisplays;
    
    // Methods
    public void CreatePackItems(UnityEngine.Transform packItemContainer)
    {
        UnityEngine.GameObject val_8;
        this.itemContainer = packItemContainer;
        packItemContainer.GetComponent<UnityEngine.UI.VerticalLayoutGroup>().spacing = 20f;
        System.Collections.Generic.List<PurchaseModel> val_3 = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrievePetsFoodPurchasePacks();
        if(W22 >= 1)
        {
                var val_8 = 0;
            do
        {
            val_8 = MonoSingleton<GameStoreUI>.Instance.Prefab_storePetFoodItem;
            this.packDisplays.Add(item:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_8, parent:  this.itemContainer).GetComponent<WGStoreItem_pet>());
            val_8 = val_8 + 1;
        }
        while(val_8 < W22);
        
        }
        
        this.RefreshPackItems();
    }
    public void RefreshPackItems()
    {
        var val_4;
        System.Collections.Generic.List<PurchaseModel> val_2 = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrievePetsFoodPurchasePacks();
        val_4 = 4;
        do
        {
            var val_3 = val_4 - 4;
            if(val_3 >= 1152921516404570576)
        {
                return;
        }
        
            if(1152921516404570576 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(W9 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            GameStoreUI val_4 = MonoSingleton<GameStoreUI>.Instance;
            val_4 = val_4 + 1;
        }
        while(this.packDisplays != null);
        
        throw new NullReferenceException();
    }
    public FoodDisplayManager()
    {
        this.packDisplays = new System.Collections.Generic.List<WGStoreItem_pet>();
    }

}
