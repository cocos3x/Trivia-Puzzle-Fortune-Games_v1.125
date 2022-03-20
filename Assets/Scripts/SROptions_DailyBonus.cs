using UnityEngine;
public class SROptions_DailyBonus : SuperLuckySROptionsParent<SROptions_DailyBonus>, INotifyPropertyChanged
{
    // Fields
    private System.DateTime daily_bonus_last_collect_time;
    
    // Properties
    public string LastCollect_LocalTime { get; }
    
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
    public string get_LastCollect_LocalTime()
    {
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this.daily_bonus_last_collect_time}, d2:  new System.DateTime())) == false)
        {
                return this.daily_bonus_last_collect_time.ToString();
        }
        
        System.DateTime val_3 = MonoSingleton<WGDailyBonusManager>.Instance.GetLastCollectTime();
        this.daily_bonus_last_collect_time = val_3;
        return this.daily_bonus_last_collect_time.ToString();
    }
    public void ForceUpdateLastCollectTime()
    {
        if((MonoSingleton<WGDailyBonusManager>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<WGDailyBonusManager>.Instance.ForceUpdateLastCollectTime(time:  new System.DateTime() {dateData = this.daily_bonus_last_collect_time});
    }
    public void Add1Day()
    {
        this.AddDays(amount:  1);
    }
    public void Sub1Day()
    {
        this.AddDays(amount:  0);
    }
    public void Add1h()
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
    private void AddDays(int amount)
    {
        System.DateTime val_1 = this.daily_bonus_last_collect_time.AddDays(value:  (double)amount);
        this.daily_bonus_last_collect_time = val_1;
        SROptions_DailyBonus.NotifyPropertyChanged(propertyName:  "LastCollect_LocalTime");
    }
    private void AddSeconds(int amount)
    {
        System.DateTime val_1 = this.daily_bonus_last_collect_time.AddSeconds(value:  (double)amount);
        this.daily_bonus_last_collect_time = val_1;
        SROptions_DailyBonus.NotifyPropertyChanged(propertyName:  "LastCollect_LocalTime");
    }
    public SROptions_DailyBonus()
    {
    
    }

}
