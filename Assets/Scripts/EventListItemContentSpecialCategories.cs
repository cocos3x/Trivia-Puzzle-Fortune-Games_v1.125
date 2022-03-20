using UnityEngine;
public class EventListItemContentSpecialCategories : EventListItemContentProgressbar
{
    // Fields
    private UnityEngine.UI.Image specialCatImage;
    
    // Methods
    public void Init(string category)
    {
        this.SetupSlider(sliderText:  System.String.Format(format:  "Complete levels in\nthe {0} category\nto earn big rewards!", arg0:  category), sliderValue:  0f);
        this.specialCatImage.sprite = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  category);
    }
    public EventListItemContentSpecialCategories()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
