using UnityEngine;
public class EventListItemContentPromoCategories : EventListItemContentProgressbar
{
    // Fields
    private UnityEngine.UI.Image specialCatImage;
    
    // Methods
    public void Init(TRVPromoCategory category)
    {
        this.SetupSlider(sliderText:  System.String.Format(format:  "Complete levels in\nthe {0} category\nfor unique rewards!", arg0:  category.subCategoryName), sliderValue:  0f);
        this.specialCatImage.sprite = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  category.subCategoryName);
    }
    public EventListItemContentPromoCategories()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
