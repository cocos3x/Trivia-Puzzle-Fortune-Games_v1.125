using UnityEngine;
public class WGEventButtonV2_AttackMadness : WGEventButtonV2
{
    // Fields
    private UnityEngine.UI.Image rewardImage;
    private UnityEngine.UI.Text rewardAmount;
    private UnityEngine.Sprite rewIconCoins;
    private UnityEngine.Sprite rewIconGoldenCurrency;
    private UnityEngine.Sprite rewIconFood;
    
    // Properties
    public UnityEngine.UI.Image RewardImage { get; }
    public UnityEngine.UI.Text RewardAmount { get; }
    
    // Methods
    public UnityEngine.UI.Image get_RewardImage()
    {
        return (UnityEngine.UI.Image)this.rewardImage;
    }
    public UnityEngine.UI.Text get_RewardAmount()
    {
        return (UnityEngine.UI.Text)this;
    }
    public void UpdateReward()
    {
        UnityEngine.Sprite val_2;
        string val_1 = AttackMadnessEventHandler.<Instance>k__BackingField + 24.ToString();
        if((AttackMadnessEventHandler.<Instance>k__BackingField + 16) == 4)
        {
            goto label_4;
        }
        
        if((AttackMadnessEventHandler.<Instance>k__BackingField + 16) == 3)
        {
            goto label_5;
        }
        
        if((AttackMadnessEventHandler.<Instance>k__BackingField + 16) != 1)
        {
                return;
        }
        
        val_2 = this.rewIconCoins;
        goto label_10;
        label_4:
        val_2 = this.rewIconFood;
        goto label_10;
        label_5:
        val_2 = this.rewIconGoldenCurrency;
        label_10:
        this.rewardImage.sprite = val_2;
    }
    public WGEventButtonV2_AttackMadness()
    {
        mem[1152921517490837728] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
