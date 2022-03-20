using UnityEngine;
public class KeyToRichesEventHandler.Reward
{
    // Fields
    private KeyToRichesEventHandler.RewardType <rewardType>k__BackingField;
    private int <count>k__BackingField;
    
    // Properties
    public KeyToRichesEventHandler.RewardType rewardType { get; set; }
    public int count { get; set; }
    
    // Methods
    public KeyToRichesEventHandler.RewardType get_rewardType()
    {
        return (RewardType)this.<rewardType>k__BackingField;
    }
    private void set_rewardType(KeyToRichesEventHandler.RewardType value)
    {
        this.<rewardType>k__BackingField = value;
    }
    public int get_count()
    {
        return (int)this.<count>k__BackingField;
    }
    private void set_count(int value)
    {
        this.<count>k__BackingField = value;
    }
    public KeyToRichesEventHandler.Reward(KeyToRichesEventHandler.RewardType _type, int _count)
    {
        this.<rewardType>k__BackingField = _type;
        this.<count>k__BackingField = _count;
    }
    public override string ToString()
    {
        return (string)this.<rewardType>k__BackingField.ToString()(this.<rewardType>k__BackingField.ToString()) + ":\n"(":\n") + this.<count>k__BackingField.ToString()(this.<count>k__BackingField.ToString());
    }

}
