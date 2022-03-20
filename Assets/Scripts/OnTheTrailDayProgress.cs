using UnityEngine;
public class OnTheTrailDayProgress
{
    // Fields
    private const string KEY_DAY_INDEX = "day";
    private const string KEY_COMPLETED_LEVELS = "completed_levels";
    public int DayIndex;
    public int CompletedLevels;
    
    // Methods
    public void FromJSON(System.Collections.Generic.Dictionary<string, object> json)
    {
        if((json.ContainsKey(key:  "day")) != false)
        {
                this.DayIndex = System.Int32.Parse(s:  json.Item["day"]);
        }
        
        if((json.ContainsKey(key:  "completed_levels")) == false)
        {
                return;
        }
        
        this.CompletedLevels = System.Int32.Parse(s:  json.Item["completed_levels"]);
    }
    public System.Collections.Generic.Dictionary<string, object> ToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "day", value:  this.DayIndex);
        val_1.Add(key:  "completed_levels", value:  this.CompletedLevels);
        return val_1;
    }
    public void UpdateDayProgress(int dayIndex, int completedLevels)
    {
        this.DayIndex = dayIndex;
        this.CompletedLevels = completedLevels;
    }
    public OnTheTrailDayProgress()
    {
    
    }

}
