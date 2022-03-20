using UnityEngine;
public class EventListItemContentProgressiveIAP : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image fillBar;
    private UnityEngine.UI.Text fillText;
    private UnityEngine.UI.Slider sliderProgressBar;
    
    // Methods
    public void OnEnable()
    {
        var val_15;
        string val_16;
        object val_17;
        val_15 = this;
        val_16 = TRVProgressiveIAPHandler.BONUS_MULTIPLIER;
        if(val_16 == null)
        {
                return;
        }
        
        if((TRVProgressiveIAPHandler.BONUS_MULTIPLIER + 56) >= (System.Linq.Enumerable.Sum(source:  TRVProgressiveIAPHandler.BONUS_MULTIPLIER + 48)))
        {
            goto label_3;
        }
        
        int val_2 = val_16.GetCurrentTierProgress(calculatedProgress:  TRVProgressiveIAPHandler.BONUS_MULTIPLIER + 56);
        val_16 = val_16.GetCurrentTierRequirement(calculatedProgress:  TRVProgressiveIAPHandler.BONUS_MULTIPLIER + 56);
        val_17 = val_2;
        string val_4 = System.String.Format(format:  "{0}/{1}", arg0:  val_2, arg1:  val_16);
        if(val_2 == 0)
        {
            goto label_5;
        }
        
        float val_14 = (float)val_2;
        val_14 = val_14 / (float)val_16;
        goto label_6;
        label_3:
        this.SetBarProgress(progressAmount:  1f);
        string val_5 = Localization.Localize(key:  "max_value_upper", defaultValue:  "MAX VALUE", useSingularKey:  false);
        val_15 = ???;
        val_16 = ???;
        val_17 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_5:
        label_6:
        val_15.SetBarProgress(progressAmount:  0f);
    }
    private void SetBarProgress(float progressAmount)
    {
        if(this.fillBar != 0)
        {
                this.fillBar.fillAmount = progressAmount;
        }
        
        if(this.sliderProgressBar == 0)
        {
                return;
        }
        
        this = ???;
        goto typeof(UnityEngine.UI.Slider).__il2cppRuntimeField_420;
    }
    public EventListItemContentProgressiveIAP()
    {
    
    }

}
