using UnityEngine;
public class OnTheTrailEventEcon
{
    // Fields
    public System.Collections.Generic.List<int> Goals;
    public System.Collections.Generic.List<int> Rewards;
    public int FixPrice;
    public int SecondsPerDay;
    
    // Methods
    public OnTheTrailEventEcon()
    {
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_1.Add(item:  10);
        val_1.Add(item:  15);
        val_1.Add(item:  20);
        val_1.Add(item:  25);
        val_1.Add(item:  30);
        this.Goals = val_1;
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        val_2.Add(item:  50);
        val_2.Add(item:  100);
        val_2.Add(item:  250);
        val_2.Add(item:  244);
        val_2.Add(item:  232);
        this.Rewards = val_2;
        this.FixPrice = 80;
        this.SecondsPerDay = 86400;
    }

}
