using UnityEngine;
public class WGEventButtonV2_IslandParadise : WGEventButtonV2
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
        string val_1 = IslandParadiseEventHandler._Instance + 24.ToString();
        if((IslandParadiseEventHandler._Instance + 16) == 4)
        {
            goto label_4;
        }
        
        if((IslandParadiseEventHandler._Instance + 16) == 3)
        {
            goto label_5;
        }
        
        if((IslandParadiseEventHandler._Instance + 16) != 1)
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
    public WGEventButtonV2_IslandParadise()
    {
        mem[1152921517491359456] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
