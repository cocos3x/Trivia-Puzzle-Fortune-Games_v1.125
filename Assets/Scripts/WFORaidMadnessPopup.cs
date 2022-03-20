using UnityEngine;
public class WFORaidMadnessPopup : RaidMadnessPopup
{
    // Fields
    protected UnityEngine.UI.Text buttonText;
    protected UnityEngine.UI.Image finalPrizeIconImage;
    
    // Methods
    protected override void Initialize()
    {
        UnityEngine.Sprite val_13;
        var val_15;
        val_13 = this;
        RESEventRewardData val_2 = this.Handler.GetFinalPrize();
        if(val_2.rewardType == 4)
        {
            goto label_10;
        }
        
        if(val_2.rewardType == 3)
        {
            goto label_5;
        }
        
        if(val_2.rewardType != 1)
        {
            goto label_6;
        }
        
        goto label_10;
        label_5:
        label_10:
        this.finalPrizeIconImage.sprite = this;
        label_6:
        val_15 = 0;
        bool val_4 = this.Handler.HasCollectedAllRewards();
        if(val_4 != false)
        {
                val_4.gameObject.SetActive(value:  false);
            val_13 = ???;
            val_15 = "OK";
        }
        else
        {
                string val_7 = System.String.Format(format:  "LEVEL {0}", arg0:  App.Player);
        }
    
    }
    protected override void OnMainButtonClicked()
    {
        if(this.Handler.HasCollectedAllRewards() != true)
        {
                GameBehavior val_3 = App.getBehavior;
            if((val_3.<metaGameBehavior>k__BackingField) != 2)
        {
                GameBehavior val_4 = App.getBehavior;
        }
        
        }
        
        this.OnMainButtonClicked();
    }
    protected override string GetTimerText()
    {
        System.TimeSpan val_1 = RaidMadnessEventHandler.<Instance>k__BackingField.GetTimeLeft();
        object[] val_2 = new object[4];
        val_2[0] = val_1._ticks.Days;
        val_2[1] = val_1._ticks.Hours;
        val_2[2] = val_1._ticks.Minutes;
        val_2[3] = val_1._ticks.Seconds;
        return (string)System.String.Format(format:  "{0}:{1:00}:{2:00}:{3:00}", args:  val_2);
    }
    protected override string GetAmountString(decimal amount)
    {
        GameEcon val_1 = App.getGameEcon;
        return (string)amount.flags.ToString(format:  val_1.numberFormatInt);
    }
    public WFORaidMadnessPopup()
    {
    
    }

}
