using UnityEngine;
public class LetterBankProgressBar : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject gift_1_group;
    private UnityEngine.UI.Text text_gift_1_requirement;
    private UnityEngine.GameObject gift_1_rewarded_group;
    private UnityEngine.GameObject gift_2_group;
    private UnityEngine.UI.Text text_gift_2_requirement;
    private UnityEngine.GameObject gift_2_rewarded_group;
    private UnityEngine.GameObject gift_3_group;
    private UnityEngine.UI.Text text_gift_3_requirement;
    private UnityEngine.GameObject gift_3_rewarded_group;
    private UnityEngine.UI.Slider slider;
    private UnityEngine.UI.Text text_current_bank_value;
    private float gift_1_percent;
    private float gift_2_percent;
    private float gift_3_percent;
    
    // Methods
    public void UpdateSlider()
    {
        this.UpdateSlider(sliderValue:  null);
    }
    public void UpdateSlider(float sliderValue)
    {
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        var val_32;
        var val_33;
        var val_34;
        var val_35;
        val_28 = null;
        val_28 = null;
        string val_1 = LetterBankEventHandler._CurrentBankValue.ToString();
        val_29 = null;
        val_29 = null;
        string val_2 = LetterBankEventHandler._Tier1RequiredPoints.ToString();
        val_30 = null;
        val_30 = null;
        string val_3 = LetterBankEventHandler._Tier2RequiredPoints.ToString();
        val_31 = null;
        val_31 = null;
        string val_4 = LetterBankEventHandler._Tier3RequiredPoints.ToString();
        if((UnityEngine.Object.op_Implicit(exists:  this.gift_1_rewarded_group)) != false)
        {
                val_32 = null;
            val_32 = null;
            this.gift_1_rewarded_group.SetActive(value:  LetterBankEventHandler._RewardedTier1);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.gift_2_rewarded_group)) != false)
        {
                val_33 = null;
            val_33 = null;
            this.gift_2_rewarded_group.SetActive(value:  LetterBankEventHandler._RewardedTier2);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.gift_3_rewarded_group)) != false)
        {
                val_34 = null;
            val_34 = null;
            this.gift_3_rewarded_group.SetActive(value:  LetterBankEventHandler._RewardedTier3);
        }
        
        UnityEngine.Vector2 val_10 = (null == null) ? this.slider.transform : 0.sizeDelta;
        UnityEngine.Vector3 val_12 = this.gift_1_group.transform.localPosition;
        val_12.x = val_12.x / val_10.x;
        this.gift_1_percent = val_12.x;
        UnityEngine.Vector3 val_14 = this.gift_2_group.transform.localPosition;
        val_14.x = val_14.x / val_10.x;
        this.gift_2_percent = val_14.x;
        UnityEngine.Vector3 val_16 = this.gift_3_group.transform.localPosition;
        val_16.x = val_16.x / val_10.x;
        this.gift_3_percent = val_16.x;
        val_35 = null;
        val_35 = null;
        val_35 = null;
        val_35 = null;
        val_35 = null;
        val_35 = null;
        val_35 = null;
        val_35 = null;
        float val_21 = (float)LetterBankEventHandler._Tier2RequiredPoints - (float)LetterBankEventHandler._Tier1RequiredPoints;
        val_21 = (UnityEngine.Mathf.Max(a:  0f, b:  (float)LetterBankEventHandler._CurrentBankValue - (float)LetterBankEventHandler._Tier1RequiredPoints)) / val_21;
        float val_25 = (float)LetterBankEventHandler._Tier3RequiredPoints - (float)LetterBankEventHandler._Tier2RequiredPoints;
        val_25 = (UnityEngine.Mathf.Max(a:  0f, b:  (float)LetterBankEventHandler._CurrentBankValue - (float)LetterBankEventHandler._Tier2RequiredPoints)) / val_25;
        float val_26 = UnityEngine.Mathf.Min(a:  1f, b:  val_25);
        float val_28 = this.gift_1_percent;
        float val_29 = this.gift_2_percent;
        val_28 = val_29 - val_28;
        val_29 = this.gift_3_percent - val_29;
        val_28 = (UnityEngine.Mathf.Min(a:  1f, b:  val_21)) * val_28;
        val_28 = ((UnityEngine.Mathf.Min(a:  1f, b:  (float)LetterBankEventHandler._CurrentBankValue / (float)LetterBankEventHandler._Tier1RequiredPoints)) * val_28) + val_28;
        val_26 = val_26 * val_29;
        val_26 = val_28 + val_26;
    }
    public LetterBankProgressBar()
    {
    
    }

}
