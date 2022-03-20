using UnityEngine;
[Serializable]
public class CategoryPackInfo
{
    // Fields
    public int packId;
    public string title;
    public string suffix;
    public bool timeLimited;
    public System.DateTime availableDate;
    public float availableDuration;
    public decimal cost;
    public CategoryColorCode color;
    
    // Properties
    public string FullTitle { get; }
    public bool IsTimeLimited { get; }
    public System.DateTime ExpiryDate { get; }
    public bool IsAvailable { get; }
    
    // Methods
    public string get_FullTitle()
    {
        return System.String.Format(format:  "{0} {1}", arg0:  this.title, arg1:  this.suffix);
    }
    public bool get_IsTimeLimited()
    {
        return (bool)this.timeLimited;
    }
    public System.DateTime get_ExpiryDate()
    {
        return this.availableDate.AddDays(value:  (double)this.availableDuration);
    }
    public bool get_IsAvailable()
    {
        var val_7;
        if(this.timeLimited == false)
        {
            goto label_1;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        long val_2 = val_1.dateData.Ticks;
        if(val_2 >= this.availableDate.Ticks)
        {
            goto label_4;
        }
        
        val_7 = 0;
        return (bool)(val_2 <= val_4.dateData.Ticks) ? 1 : 0;
        label_1:
        val_7 = 1;
        return (bool)(val_2 <= val_4.dateData.Ticks) ? 1 : 0;
        label_4:
        System.DateTime val_4 = this.availableDate.AddDays(value:  (double)this.availableDuration);
        return (bool)(val_2 <= val_4.dateData.Ticks) ? 1 : 0;
    }
    public CategoryPackInfo(int id, string namePrefix, string nameSuffix, decimal price, CategoryColorCode colorType, bool limitedTime = False)
    {
        val_1 = new System.Object();
        this.packId = id;
        this.title = val_1;
        this.suffix = nameSuffix;
        this.cost = price;
        mem[1152921516134680452] = price.lo;
        mem[1152921516134680456] = price.mid;
        this.color = colorType;
        this.timeLimited = limitedTime;
    }
    public void SetTimeLimited(System.DateTime startDate, float availDuration)
    {
        this.availableDate = startDate;
        this.timeLimited = true;
        this.availableDuration = availDuration;
    }

}
