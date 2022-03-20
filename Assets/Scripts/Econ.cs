using UnityEngine;
public class KeyToRichesEventHandler.Econ
{
    // Fields
    public int levelsPerKey;
    public System.Collections.Generic.Dictionary<KeyToRichesEventHandler.Tier, int> tierQuantity;
    public System.Collections.Generic.Dictionary<KeyToRichesEventHandler.Tier, System.Collections.Generic.List<KeyToRichesEventHandler.Reward>> tierRewards;
    
    // Methods
    public KeyToRichesEventHandler.Econ()
    {
        this.levelsPerKey = 25;
        System.Collections.Generic.Dictionary<Tier, System.Int32> val_1 = new System.Collections.Generic.Dictionary<Tier, System.Int32>();
        val_1.Add(key:  0, value:  5);
        val_1.Add(key:  1, value:  3);
        val_1.Add(key:  2, value:  1);
        this.tierQuantity = val_1;
        System.Collections.Generic.Dictionary<Tier, System.Collections.Generic.List<Reward>> val_2 = new System.Collections.Generic.Dictionary<Tier, System.Collections.Generic.List<Reward>>();
        System.Collections.Generic.List<Reward> val_3 = new System.Collections.Generic.List<Reward>();
        .<rewardType>k__BackingField = 1.06099789548264E-312;
        val_3.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 1.59149684322395E-312;
        val_3.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 2.12199579096527E-312;
        val_3.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 2.12199579097021E-312;
        val_3.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 5.30498947741812E-312;
        val_3.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 1.06099789548313E-311;
        val_3.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 2.12199579244747E-314;
        val_3.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 4.24399158341274E-314;
        val_3.Add(item:  new KeyToRichesEventHandler.Reward());
        val_2.Add(key:  0, value:  val_3);
        System.Collections.Generic.List<Reward> val_12 = new System.Collections.Generic.List<Reward>();
        .<rewardType>k__BackingField = 5.30498947741318E-312;
        val_12.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 7.95748421611977E-312;
        val_12.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 1.06099789548264E-311;
        val_12.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 2.12199579096577E-311;
        val_12.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 2.65249473870708E-311;
        val_12.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 3.1829936864484E-311;
        val_12.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 2.12199579294153E-314;
        val_12.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 4.24399158390681E-314;
        val_12.Add(item:  new KeyToRichesEventHandler.Reward());
        val_2.Add(key:  1, value:  val_12);
        System.Collections.Generic.List<Reward> val_21 = new System.Collections.Generic.List<Reward>();
        .<rewardType>k__BackingField = 2.12199579096527E-311;
        val_21.Add(item:  new KeyToRichesEventHandler.Reward());
        .<rewardType>k__BackingField = 2.1219957934356E-314;
        val_21.Add(item:  new KeyToRichesEventHandler.Reward());
        val_2.Add(key:  2, value:  val_21);
        this.tierRewards = val_2;
        val_21 = new System.Object();
    }

}
