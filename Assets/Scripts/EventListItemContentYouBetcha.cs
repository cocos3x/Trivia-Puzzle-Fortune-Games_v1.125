using UnityEngine;
public class EventListItemContentYouBetcha : EventListItemContentProgressbar
{
    // Methods
    public override void Setup(WGEventHandler handler)
    {
        float val_3 = TRVYouBetchaEventHandler.EVENT_TRACKING_ID + 48;
        val_3 = val_3 + 1f;
        string val_2 = System.String.Format(format:  Localization.Localize(key:  "you_betcha_description", defaultValue:  "Make a bet and earn\n{0}x MORE COINS\nif you\'re right!", useSingularKey:  false), arg0:  val_3);
    }
    public EventListItemContentYouBetcha()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
