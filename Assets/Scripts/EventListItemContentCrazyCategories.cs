using UnityEngine;
public class EventListItemContentCrazyCategories : EventListItemContentProgressbar
{
    // Methods
    public override void Setup(WGEventHandler handler)
    {
        string val_2 = System.String.Format(format:  Localization.Localize(key:  "crazy_categories_description", defaultValue:  "Complete Crazy Category levels to earn {0}x more Stars", useSingularKey:  false), arg0:  TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 40);
    }
    public EventListItemContentCrazyCategories()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
