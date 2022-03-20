using UnityEngine;
public class AdjustConfig : ScriptableObject
{
    // Fields
    public AdjustProductConfig Free_Android;
    public AdjustProductConfig Free_Ios;
    
    // Methods
    public void LinkTokens(AdjustTracking tracker)
    {
        if(val_2.Length < 1)
        {
                return;
        }
        
        var val_5 = 0;
        do
        {
            System.Reflection.FieldInfo val_4 = this.Free_Android.GetType().GetFields()[val_5];
            tracker.AddEventToken(eventName:  val_4, eventToken:  val_4.ToString());
            val_5 = val_5 + 1;
        }
        while(val_5 < val_2.Length);
    
    }
    private AdjustProductConfig ChooseConfig()
    {
        return (AdjustProductConfig)this.Free_Android;
    }
    public AdjustConfig()
    {
    
    }

}
