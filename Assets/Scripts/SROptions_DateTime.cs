using UnityEngine;
public class SROptions_DateTime : SuperLuckySROptionsParent<SROptions_DateTime>, INotifyPropertyChanged
{
    // Properties
    public string SimulatedDate { get; }
    public float CurrentTimeScale { get; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((propertyName.Equals(value:  "SimulatedDate")) == false)
        {
                return;
        }
        
        SLCDateTimeDisplay.UpdateDateTimeDisplay();
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
    public string get_SimulatedDate()
    {
        System.DateTime val_1 = DateTimeCheat.GetSimulatedDateTime();
        return (string)val_1.dateData.ToString();
    }
    public void Add21()
    {
        this.AddDays(amount:  21);
    }
    public void Add14()
    {
        this.AddDays(amount:  14);
    }
    public void Add1()
    {
        this.AddDays(amount:  1);
    }
    public void Sub21()
    {
        this.AddDays(amount:  20);
    }
    public void Sub14()
    {
        this.AddDays(amount:  13);
    }
    public void Sub1()
    {
        this.AddDays(amount:  0);
    }
    public void ResetDate()
    {
        DateTimeCheat.ResetDateStatic();
    }
    public void AddSeconds1h()
    {
        this.AddSeconds(amount:  16);
    }
    public void SubSeconds1h()
    {
        this.AddSeconds(amount:  3599);
    }
    public void AddSeconds10m()
    {
        this.AddSeconds(amount:  88);
    }
    public void SubSeconds10m()
    {
        this.AddSeconds(amount:  599);
    }
    public void AddSeconds15()
    {
        this.AddSeconds(amount:  15);
    }
    public void SubSeconds15()
    {
        this.AddSeconds(amount:  -15);
    }
    private void AddDays(int amount)
    {
        DateTimeCheat.AddDaysStatic(daysCount:  amount, postNotification:  true);
        SROptions_DateTime.NotifyPropertyChanged(propertyName:  "SimulatedDate");
    }
    private void AddSeconds(int amount)
    {
        DateTimeCheat.AddSecondsStatic(secondsCount:  amount, postNotification:  true);
        SROptions_DateTime.NotifyPropertyChanged(propertyName:  "SimulatedDate");
    }
    public float get_CurrentTimeScale()
    {
        return UnityEngine.Time.timeScale;
    }
    public void TimeScale025()
    {
        UnityEngine.Time.timeScale = 0.25f;
        SROptions_DateTime.NotifyPropertyChanged(propertyName:  "CurrentTimeScale");
    }
    public void TimeScale05()
    {
        UnityEngine.Time.timeScale = 0.5f;
        SROptions_DateTime.NotifyPropertyChanged(propertyName:  "CurrentTimeScale");
    }
    public void TimeScale075()
    {
        UnityEngine.Time.timeScale = 0.75f;
        SROptions_DateTime.NotifyPropertyChanged(propertyName:  "CurrentTimeScale");
    }
    public void TimeScale1()
    {
        UnityEngine.Time.timeScale = 1f;
        SROptions_DateTime.NotifyPropertyChanged(propertyName:  "CurrentTimeScale");
    }
    public void TimeScale15()
    {
        UnityEngine.Time.timeScale = 1.5f;
        SROptions_DateTime.NotifyPropertyChanged(propertyName:  "CurrentTimeScale");
    }
    public void TimeScale2()
    {
        UnityEngine.Time.timeScale = 2f;
        SROptions_DateTime.NotifyPropertyChanged(propertyName:  "CurrentTimeScale");
    }
    public SROptions_DateTime()
    {
    
    }

}
