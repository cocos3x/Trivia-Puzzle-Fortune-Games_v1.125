using UnityEngine;
public class WGOnTheTrailDayItem : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject rewardAmountGroup;
    private UnityEngine.UI.Text reward;
    private UnityEngine.UI.Text day;
    private UnityEngine.GameObject[] goldenAppleIcons;
    private UnityEngine.UI.Image progressImg;
    private UnityEngine.Sprite successSp;
    private UnityEngine.Sprite failSp;
    
    // Methods
    public void Setup(OnTheTrailEvent.OnTheTrailDayItemStatus status, int day, int reward = 0)
    {
        string val_2 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "day_upper", defaultValue:  "DAY", useSingularKey:  false), arg1:  day);
        if(status == 2)
        {
                this.SetPendingIcons(active:  true);
            this = this.reward;
            string val_3 = reward.ToString();
            return;
        }
        
        var val_4 = (status == 0) ? 64 : 72;
        this.progressImg.sprite = null;
        this.SetPendingIcons(active:  false);
    }
    private void SetPendingIcons(bool active)
    {
        this.rewardAmountGroup.SetActive(value:  active);
        if(this.goldenAppleIcons.Length >= 1)
        {
                var val_6 = 0;
            do
        {
            this.goldenAppleIcons[val_6].SetActive(value:  active);
            val_6 = val_6 + 1;
        }
        while(val_6 < this.goldenAppleIcons.Length);
        
        }
        
        this.progressImg.gameObject.SetActive(value:  (~active) & 1);
    }
    public WGOnTheTrailDayItem()
    {
    
    }

}
