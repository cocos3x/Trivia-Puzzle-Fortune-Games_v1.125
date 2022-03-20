using UnityEngine;
public class SROptions_BonusGames : SuperLuckySROptionsParent<SROptions_BonusGames>, INotifyPropertyChanged
{
    // Properties
    public string PossibleRewardWheel { get; }
    public string PossibleRewardSlots { get; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    public string get_PossibleRewardWheel()
    {
        var val_4;
        var val_5;
        val_4 = 1152921504909348864;
        if(BonusGameWheelPopup.QAHACK_ForceAwardType != 0)
        {
                AwardType val_2 = BonusGameWheelPopup.QAHACK_ForceAwardType;
            val_4 = val_2;
            val_5 = val_2.ToString();
            return (string)val_5;
        }
        
        val_5 = "Random";
        return (string)val_5;
    }
    public void WheelForceDefault()
    {
        BonusGameWheelPopup.QAHACK_ForceAwardType = 0;
        SROptions_BonusGames.NotifyPropertyChanged(propertyName:  "PossibleRewardWheel");
    }
    public void WheelForceCoins()
    {
        BonusGameWheelPopup.QAHACK_ForceAwardType = 1;
        SROptions_BonusGames.NotifyPropertyChanged(propertyName:  "PossibleRewardWheel");
    }
    public void WheelForceGolden()
    {
        BonusGameWheelPopup.QAHACK_ForceAwardType = 2;
        SROptions_BonusGames.NotifyPropertyChanged(propertyName:  "PossibleRewardWheel");
    }
    public string get_PossibleRewardSlots()
    {
        var val_4;
        var val_5;
        val_4 = 1152921504909082624;
        if(BonusGameSlotMachinePopup.QAHACK_ForceAwardType != 0)
        {
                GameEventRewardType val_2 = BonusGameSlotMachinePopup.QAHACK_ForceAwardType;
            val_4 = val_2;
            val_5 = val_2.ToString();
            return (string)val_5;
        }
        
        val_5 = "Random";
        return (string)val_5;
    }
    public void SlotsForceDefault()
    {
        BonusGameSlotMachinePopup.QAHACK_ForceAwardType = 0;
        SROptions_BonusGames.NotifyPropertyChanged(propertyName:  "PossibleRewardSlots");
    }
    public void SlotsForceCoins()
    {
        BonusGameSlotMachinePopup.QAHACK_ForceAwardType = 1;
        SROptions_BonusGames.NotifyPropertyChanged(propertyName:  "PossibleRewardSlots");
    }
    public void SlotsForceGolden()
    {
        BonusGameSlotMachinePopup.QAHACK_ForceAwardType = 2;
        SROptions_BonusGames.NotifyPropertyChanged(propertyName:  "PossibleRewardSlots");
    }
    public SROptions_BonusGames()
    {
    
    }

}
