using UnityEngine;
public class SROptions_GameOfTheDay : SuperLuckySROptionsParent<SROptions_GameOfTheDay>, INotifyPropertyChanged
{
    // Properties
    public string LastAdClicked { get; }
    public string GOTDLastShown { get; }
    public string GOTDDaysSeenWoInstallation { get; }
    public string DontShowUntil { get; }
    public string LastResponse { get; }
    public string PromotedGames { get; }
    
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
    public void Refresh()
    {
        SROptions_GameOfTheDay.NotifyPropertyChanged(propertyName:  "LastResponse");
    }
    public void SimulateAdClick()
    {
        Player val_1 = App.Player;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        val_1.properties.AdsLastClickedTime = val_2;
        Player val_3 = App.Player;
        val_3.properties.Save(writePrefs:  true);
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        System.DateTime val_5 = val_4.dateData.ToLocalTime();
        DebugMessageDisplay.DisplayMessage(msgTxt:  System.String.Format(format:  "Simulated ad click at {0}", arg0:  val_5), displayTime:  3f);
        SROptions_GameOfTheDay.NotifyPropertyChanged(propertyName:  "LastAdClicked");
        Refresh();
    }
    public string get_LastAdClicked()
    {
        Player val_1 = App.Player;
        System.DateTime val_2 = val_1.properties.AdsLastClickedTime.ToLocalTime();
        return (string)val_2.dateData.ToString();
    }
    public string get_GOTDLastShown()
    {
        Player val_1 = App.Player;
        System.DateTime val_2 = val_1.properties.GOTDLastShownTime.ToLocalTime();
        return (string)val_2.dateData.ToString();
    }
    public string get_GOTDDaysSeenWoInstallation()
    {
        Player val_1 = App.Player;
        return val_1.properties.GOTDDaysSeenWoInstallation.ToString();
    }
    public string get_DontShowUntil()
    {
        Player val_1 = App.Player;
        System.DateTime val_2 = val_1.properties.GOTDDontShowUntil.ToLocalTime();
        return (string)val_2.dateData.ToString();
    }
    public string get_LastResponse()
    {
        null = null;
        return (string)twelvegigs.plugins.InstalledAppsPlugin.lastResponse;
    }
    public string get_PromotedGames()
    {
        return PrettyPrint.printJSON(obj:  App.Player.PromotedGames, types:  false, singleLineOutput:  false);
    }
    public SROptions_GameOfTheDay()
    {
    
    }

}
