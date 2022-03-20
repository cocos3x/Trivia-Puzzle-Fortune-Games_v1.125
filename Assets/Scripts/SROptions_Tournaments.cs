using UnityEngine;
public class SROptions_Tournaments : SuperLuckySROptionsParent<SROptions_Tournaments>, INotifyPropertyChanged
{
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
    public void ExpertsRewardResult()
    {
        MonoSingleton<TournamentsManager>.Instance.Hack_1_thru_3();
    }
    public void HighRankResult()
    {
        MonoSingleton<TournamentsManager>.Instance.Hack_4_thru_10();
    }
    public void MiddlingResult()
    {
        MonoSingleton<TournamentsManager>.Instance.Hack_11_thru_30();
    }
    public void LoserResult()
    {
        MonoSingleton<TournamentsManager>.Instance.Hack_31_thru_50();
    }
    public void MasterPromotedResult()
    {
        MonoSingleton<TournamentsManager>.Instance.Hack_Master_Promoted();
    }
    public void BronzeVIIDemotedResult()
    {
        MonoSingleton<TournamentsManager>.Instance.Hack_BronzeVII_Demoted();
    }
    public SROptions_Tournaments()
    {
    
    }

}
