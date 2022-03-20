using UnityEngine;
public class TRVStarChampionshipProgressBar : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform giftIcons;
    private UnityEngine.Transform completedIcons;
    private UnityEngine.UI.Image progressFill;
    
    // Methods
    public void UpdateProgressBar(float progress, int tier)
    {
        this.progressFill.fillAmount = progress;
        var val_8 = 0;
        do
        {
            int val_1 = val_8 + 1;
            this.giftIcons.GetChild(index:  val_1).gameObject.SetActive(value:  (val_1 > tier) ? 1 : 0);
            this.completedIcons.GetChild(index:  val_1).gameObject.SetActive(value:  (val_1 <= tier) ? 1 : 0);
            val_8 = val_8 + 1;
        }
        while(val_8 < 3);
    
    }
    public TRVStarChampionshipProgressBar()
    {
    
    }

}
