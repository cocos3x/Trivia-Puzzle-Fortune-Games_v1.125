using UnityEngine;
public class WFOAttackMadnessPopup : AttackMadnessPopup
{
    // Fields
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.UI.Image finalPrizeIconImage;
    
    // Methods
    protected override void Initialize()
    {
        RESEventRewardData val_2 = this.Handler.GetFinalPrize();
        if(val_2.rewardType == 4)
        {
            goto label_4;
        }
        
        if(val_2.rewardType == 3)
        {
            goto label_10;
        }
        
        if(val_2.rewardType != 1)
        {
            goto label_6;
        }
        
        goto label_10;
        label_4:
        label_10:
        this.finalPrizeIconImage.sprite = this;
        label_6:
        AttackMadnessEventHandler val_3 = this.Handler;
        if(this.Handler.HasCollectedAllRewards() != false)
        {
                this.buttonText.CrossFadeColor(targetColor:  new UnityEngine.Color() {r = 1f}, duration:  null, ignoreTimeScale:  false, useAlpha:  typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E8>>0&0xFF);
            this.buttonText.gameObject.SetActive(value:  false);
            return;
        }
        
        AttackMadnessEventHandler val_13 = this.Handler;
        string val_11 = System.String.Format(format:  "LEVEL {0}", arg0:  App.Player);
        val_13 = val_13 - this.Handler.PointsCollectedInLevel;
        float val_14 = (float)val_13;
        val_14 = val_14 / (float)W23;
        this.buttonText.CrossFadeColor(targetColor:  new UnityEngine.Color() {r = val_14, g = (float)W23}, duration:  null, ignoreTimeScale:  false, useAlpha:  typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E8>>0&0xFF);
        string val_12 = System.String.Format(format:  "{0}/{1}", arg0:  val_13, arg1:  ???);
    }
    protected override void OnMainButtonClicked()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                if(this.Handler.HasCollectedAllRewards() != true)
        {
                GameBehavior val_4 = App.getBehavior;
        }
        
        }
        
        this.OnMainButtonClicked();
    }
    protected override string GetTimerText()
    {
        object[] val_1 = new object[4];
        val_1[0] = AttackMadnessEventHandler.<Instance>k__BackingField.Days;
        val_1[1] = AttackMadnessEventHandler.<Instance>k__BackingField.Hours;
        val_1[2] = AttackMadnessEventHandler.<Instance>k__BackingField.Minutes;
        val_1[3] = AttackMadnessEventHandler.<Instance>k__BackingField.Seconds;
        return (string)System.String.Format(format:  "{0}:{1:00}:{2:00}:{3:00}", args:  val_1);
    }
    protected override string GetAmountString(decimal amount)
    {
        GameEcon val_1 = App.getGameEcon;
        return (string)amount.flags.ToString(format:  val_1.numberFormatInt);
    }
    public WFOAttackMadnessPopup()
    {
    
    }

}
