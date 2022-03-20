using UnityEngine;
public class WGBonusRewardsRow : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text levelText;
    private UnityEngine.UI.Text goldenCurrencyText;
    private UnityEngine.UI.Text gemText;
    private UnityEngine.UI.Text coinText;
    
    // Methods
    public void Setup(BonusRewardsContainer myData)
    {
        string val_1 = myData.<level>k__BackingField.ToString();
        string val_2 = System.String.Format(format:  "+{0}%", arg0:  myData.<bonusGoldenCurrencyEarnedPercent>k__BackingField);
        string val_3 = System.String.Format(format:  "+{0}%", arg0:  myData.<bonusGemsEarnedPercent>k__BackingField);
        string val_4 = System.String.Format(format:  "+{0}%", arg0:  myData.<bonusCoinsEarnedPercent>k__BackingField);
    }
    public WGBonusRewardsRow()
    {
    
    }

}
