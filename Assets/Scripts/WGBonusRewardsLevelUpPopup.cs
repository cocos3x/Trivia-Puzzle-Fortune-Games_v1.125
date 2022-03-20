using UnityEngine;
public class WGBonusRewardsLevelUpPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text bonusLevelText;
    private UnityEngine.UI.Text newLevelDescText;
    
    // Methods
    private void OnEnable()
    {
        this.DisplayLevelUpAnim();
    }
    private void DisplayLevelUpAnim()
    {
        BonusRewardsContainer val_2 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetCurrentRewards();
        string val_4 = (val_2.<level>k__BackingField) - 1.ToString();
        string val_6 = System.String.Format(format:  Localization.Localize(key:  "bonus_rewards_levelup_body", defaultValue:  "YOU\'VE UNLOCKED/n BONUS LEVEL {0}!", useSingularKey:  false), arg0:  val_2.<level>k__BackingField);
        UnityEngine.Coroutine val_8 = this.StartCoroutine(routine:  this.AnimateThenClose(newLevel:  val_2.<level>k__BackingField));
    }
    private System.Collections.IEnumerator AnimateThenClose(int newLevel)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .newLevel = newLevel;
        return (System.Collections.IEnumerator)new WGBonusRewardsLevelUpPopup.<AnimateThenClose>d__4();
    }
    public WGBonusRewardsLevelUpPopup()
    {
    
    }

}
