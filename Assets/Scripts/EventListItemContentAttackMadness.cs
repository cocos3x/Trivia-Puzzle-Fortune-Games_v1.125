using UnityEngine;
public class EventListItemContentAttackMadness : EventListItemContentProgressbar
{
    // Fields
    private UnityEngine.UI.Image rewardIcon;
    private UnityEngine.UI.Text rewardAmountText;
    private UnityEngine.Sprite rewIconCoins;
    private UnityEngine.Sprite rewIconGoldenCurrency;
    private UnityEngine.Sprite rewIconFood;
    
    // Methods
    public void SetupSlider(string sliderText, float sliderValue, bool eventCompleted, RESEventRewardData rewardData)
    {
        UnityEngine.Sprite val_4;
        if(eventCompleted != false)
        {
                this.rewardIcon.gameObject.SetActive(value:  false);
            return;
        }
        
        if(rewardData.rewardType == 4)
        {
            goto label_5;
        }
        
        if(rewardData.rewardType == 3)
        {
            goto label_6;
        }
        
        if(rewardData.rewardType != 1)
        {
            goto label_7;
        }
        
        val_4 = this.rewIconCoins;
        goto label_11;
        label_5:
        val_4 = this.rewIconFood;
        goto label_11;
        label_6:
        val_4 = this.rewIconGoldenCurrency;
        label_11:
        this.rewardIcon.sprite = val_4;
        label_7:
        GameEcon val_2 = App.getGameEcon;
        string val_3 = rewardData.rewardQty.ToString(format:  val_2.numberFormatInt);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public EventListItemContentAttackMadness()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
