using UnityEngine;
public class TRVPromoCategoriesSliderTick : TRVDynamicSliderTick
{
    // Fields
    private UnityEngine.UI.Text rewardText;
    private UnityEngine.GameObject rewardGroup;
    
    // Methods
    public override string FormatMyText(int myDisplayAmount)
    {
        return (string)myDisplayAmount.ToString();
    }
    public void ShowRewardAmount(bool showReward, int rewardAmount = 0)
    {
        this.rewardGroup.gameObject.SetActive(value:  showReward);
        string val_4 = System.String.Format(format:  "x{0}", arg0:  rewardAmount.ToString());
    }
    public TRVPromoCategoriesSliderTick()
    {
    
    }

}
