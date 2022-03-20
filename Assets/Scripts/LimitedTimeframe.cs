using UnityEngine;
public class LimitedTimeframe
{
    // Fields
    private System.DateTime startDate;
    private int durationDays;
    
    // Methods
    public LimitedTimeframe(string date, string duration)
    {
        string val_8;
        var val_9;
        int val_10;
        var val_11;
        val_8 = date;
        val_9 = null;
        val_9 = null;
        this.startDate = System.DateTime.MinValue;
        val_1 = new System.Object();
        if((System.DateTime.TryParse(s:  val_8, provider:  System.Globalization.CultureInfo.InvariantCulture, styles:  0, result: out  new System.DateTime() {dateData = this.startDate})) != false)
        {
                if((System.Int32.TryParse(s:  string val_1 = duration, result: out  this.durationDays)) == true)
        {
                return;
        }
        
        }
        
        string[] val_6 = new string[5];
        val_10 = val_6.Length;
        val_6[0] = "LimitedTimeframe failed to parse ";
        if(val_8 != null)
        {
                val_10 = val_6.Length;
        }
        
        val_6[1] = val_8;
        val_8 = " to valid date, or ";
        val_10 = val_6.Length;
        val_6[2] = " to valid date, or ";
        if(val_1 != null)
        {
                val_10 = val_6.Length;
        }
        
        val_6[3] = val_1;
        val_10 = val_6.Length;
        val_6[4] = " to valid int. Defaulting to minimum time and minimal duration.";
        UnityEngine.Debug.LogError(message:  +val_6);
        val_11 = null;
        val_11 = null;
        this.durationDays = 0;
        this.startDate = System.DateTime.MinValue;
    }
    public System.DateTime GetEndDate()
    {
        return this.startDate.AddDays(value:  (double)this.durationDays);
    }
    public bool IsWithinTimeFrame(System.DateTime time)
    {
        var val_7;
        System.TimeSpan val_1 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = time.dateData}, d2:  new System.DateTime() {dateData = this.startDate});
        if(val_1._ticks.TotalSeconds > 0f)
        {
                System.DateTime val_3 = this.startDate.AddDays(value:  (double)this.durationDays);
            System.TimeSpan val_4 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_3.dateData}, d2:  new System.DateTime() {dateData = time.dateData});
            var val_6 = (val_4._ticks.TotalSeconds >= 0f) ? 1 : 0;
            return (bool)val_7;
        }
        
        val_7 = 0;
        return (bool)val_7;
    }
    public override string ToString()
    {
        object[] val_1 = new object[4];
        val_1[0] = this.startDate.Month.ToString();
        val_1[1] = this.startDate.Day.ToString();
        val_1[2] = this.startDate.Year.ToString();
        val_1[3] = this.durationDays.ToString();
        return (string)System.String.Format(format:  "{0}/{1}/{2}-{3}d", args:  val_1);
    }

}
