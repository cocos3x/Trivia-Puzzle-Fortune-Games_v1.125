using UnityEngine;
public class EventListItemContentIslandParadise : EventListItemContentProgressbar
{
    // Fields
    private UnityEngine.UI.Text rewardAmountText;
    private UnityEngine.UI.Image rewardIcon;
    private UnityEngine.Sprite rewIconCoins;
    private UnityEngine.Sprite rewIconGoldenCurrency;
    private UnityEngine.Sprite rewIconFood;
    
    // Methods
    public void SetupSlider(bool hasCollectedAllRewards, string sliderText, float sliderValue, RESEventRewardData currentReward)
    {
        UnityEngine.Sprite val_4;
        if((currentReward == null) || (hasCollectedAllRewards == true))
        {
            goto label_2;
        }
        
        this.SetupSlider(sliderText:  sliderText, sliderValue:  sliderValue);
        if(currentReward.rewardType == 4)
        {
            goto label_3;
        }
        
        if(currentReward.rewardType == 3)
        {
            goto label_4;
        }
        
        if(currentReward.rewardType != 1)
        {
            goto label_5;
        }
        
        val_4 = this.rewIconCoins;
        goto label_11;
        label_2:
        this.SetupSlider(sliderText:  "COMPLETED!", sliderValue:  1f);
        this.rewardIcon.gameObject.SetActive(value:  false);
        return;
        label_3:
        val_4 = this.rewIconFood;
        goto label_11;
        label_4:
        val_4 = this.rewIconGoldenCurrency;
        label_11:
        this.rewardIcon.sprite = val_4;
        label_5:
        GameEcon val_2 = App.getGameEcon;
        string val_3 = currentReward.rewardQty.ToString(format:  val_2.numberFormatInt);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public EventListItemContentIslandParadise()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
