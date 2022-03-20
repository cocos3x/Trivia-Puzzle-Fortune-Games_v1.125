using UnityEngine;
public class TRVLevelCompleteReward : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text rewardDescText;
    private UnityEngine.UI.Text rewardValueText;
    private UnityEngine.UI.Image rewardCurrencyImage;
    private UnityEngine.UI.Image cardMultiImage;
    private UnityEngine.Sprite coinSprite;
    private UnityEngine.Sprite starSprite;
    private UnityEngine.Sprite gemSprite;
    private System.Collections.Generic.List<UnityEngine.Sprite> cardSpecificSprites;
    
    // Properties
    public UnityEngine.Transform rewardCurrencyLocation { get; }
    
    // Methods
    public UnityEngine.Transform get_rewardCurrencyLocation()
    {
        if(this.rewardCurrencyImage != null)
        {
                return this.rewardCurrencyImage.transform;
        }
        
        throw new NullReferenceException();
    }
    public void Init(TRVLevelReward myRew)
    {
        string val_1 = myRew.<value>k__BackingField.ToString();
        this.SetCurrencyImage(rw:  myRew);
        UnityEngine.GameObject val_2 = this.cardMultiImage.gameObject;
        if((myRew.<cardMulti>k__BackingField) >= 1)
        {
                val_2.SetActive(value:  true);
            if(null < 1)
        {
                return;
        }
        
            int val_3 = (myRew.<cardMulti>k__BackingField) - 1;
            if(val_3 >= null)
        {
                return;
        }
        
            this = this.cardMultiImage;
            if(null <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.UI.Text val_4 = 1152921504814993408 + (val_3 << 3);
            this.sprite = mem[(1152921504814993408 + ((myRew.<cardMulti>k__BackingField - 1)) << 3) + 32];
            return;
        }
        
        val_2.SetActive(value:  false);
    }
    private void SetCurrencyImage(TRVLevelReward rw)
    {
        UnityEngine.UI.Image val_1;
        UnityEngine.Sprite val_2;
        if((rw.<rewardType>k__BackingField) == 2)
        {
            goto label_1;
        }
        
        if((rw.<rewardType>k__BackingField) == 1)
        {
            goto label_2;
        }
        
        if((rw.<rewardType>k__BackingField) != 0)
        {
                return;
        }
        
        val_1 = this.rewardCurrencyImage;
        val_2 = this.coinSprite;
        goto label_7;
        label_2:
        val_1 = this.rewardCurrencyImage;
        val_2 = this.starSprite;
        goto label_7;
        label_1:
        val_1 = this.rewardCurrencyImage;
        val_2 = this.gemSprite;
        label_7:
        val_1.sprite = val_2;
    }
    public TRVLevelCompleteReward()
    {
        this.cardSpecificSprites = new System.Collections.Generic.List<UnityEngine.Sprite>();
    }

}
