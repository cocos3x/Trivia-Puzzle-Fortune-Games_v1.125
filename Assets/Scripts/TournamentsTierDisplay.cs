using UnityEngine;
public class TournamentsTierDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text normalTierText;
    private TMPro.TextMeshProUGUI fancyTierText;
    
    // Methods
    public void RefreshDisplay(int tierIndex)
    {
        var val_8;
        this.normalTierText.gameObject.SetActive(value:  (tierIndex != 0) ? 1 : 0);
        this.fancyTierText.gameObject.SetActive(value:  (tierIndex == 0) ? 1 : 0);
        val_8 = null;
        val_8 = null;
        System.String[] val_8 = TournamentsEconomy.TierNames;
        val_8 = val_8 + (tierIndex << 3);
        this.fancyTierText.text = TournamentsEconomy.GetLocalizedTierNameForTierName(tierName:  (TournamentsEconomy.TierNames + (tierIndex) << 3) + 32).ToUpper();
        string val_7 = TournamentsEconomy.GetFormattedColorizedTierName(tierIndex:  tierIndex);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public TournamentsTierDisplay()
    {
    
    }

}
