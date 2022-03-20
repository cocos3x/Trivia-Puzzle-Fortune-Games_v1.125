using UnityEngine;
public class TRVPromoCategoriesProxyEventHandler : WGEventHandler
{
    // Fields
    public const string EVENT_ID = "Special Categories";
    public TRVPromoCategory PromoCategory;
    
    // Properties
    public override bool IsEventHidden { get; }
    
    // Methods
    public override string GetEventDisplayName()
    {
        return System.String.Format(format:  "SPECIAL CATEGORY: {0}", arg0:  this.PromoCategory.subCategoryName.ToUpper());
    }
    public override string GetMainMenuButtonText()
    {
        return System.String.Format(format:  "SPECIAL CATEGORY\n{0}", arg0:  this.PromoCategory.subCategoryName.ToUpper());
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetupWithPromo(promo:  this.PromoCategory, hidePaidEntry:  false, returnToCategorySelectOnButtonClose:  false, continueToNextLevel:  true);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetupWithPromo(promo:  this.PromoCategory, hidePaidEntry:  true, returnToCategorySelectOnButtonClose:  true, continueToNextLevel:  true);
    }
    public override UnityEngine.Sprite GetEventIcon()
    {
        return MonoSingleton<TRVPromoCategoriesHandler>.Instance.GetIcon(promoCategory:  this.PromoCategory);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentPromoCategories>(allowMultiple:  false).Init(category:  this.PromoCategory);
    }
    public override bool get_IsEventHidden()
    {
        var val_10;
        if((MonoSingleton<TRVPromoCategoriesHandler>.Instance) == 0)
        {
                label_16:
            val_10 = 1;
        }
        else
        {
                if(this.PromoCategory.promoCategoryType == 1)
        {
                if(((MonoSingleton<TRVPromoCategoriesHandler>.Instance.EventShouldShow()) == false) || ((MonoSingleton<TRVPromoCategoriesHandler>.Instance.GetRemainingLevelsForPromo(currentPromo:  this.PromoCategory)) < 1))
        {
            goto label_16;
        }
        
        }
        
            bool val_8 = MonoSingleton<TRVPromoCategoriesHandler>.Instance.EventShouldShow();
            val_10 = val_8 ^ 1;
        }
        
        val_8 = val_10;
        return (bool)val_8;
    }
    public TRVPromoCategoriesProxyEventHandler()
    {
    
    }

}
