using UnityEngine;
public class WGMegaHintButton : MyButton
{
    // Fields
    private UnityEngine.UI.Text hintCostText;
    private UnityEngine.GameObject crossedOutCost;
    private UnityEngine.UI.Text crossedOutText;
    private bool alwaysShowDiscount;
    
    // Methods
    private void Awake()
    {
    
    }
    protected override void Start()
    {
        this.Start();
        this.UpdateDisplay();
    }
    public override void OnButtonClick()
    {
        MonoSingleton<WGMegaHintController>.Instance.OnMegaHintPressed(freeHint:  false);
    }
    private void OnHintDiscountAvailable()
    {
        this.UpdateDisplay();
    }
    private void OnHintDiscountExpire()
    {
        this.UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        if(this.hintCostText != 0)
        {
                if(this.alwaysShowDiscount != false)
        {
                decimal val_3 = App.getGameEcon.HintMEGACostDiscounted;
        }
        else
        {
                GameEcon val_4 = App.getGameEcon;
        }
        
            GameEcon val_5 = App.getGameEcon;
            string val_6 = val_4._HintMEGACost.ToString(format:  val_5.numberFormatInt);
        }
        
        if(this.crossedOutText != 0)
        {
                GameEcon val_8 = App.getGameEcon;
            GameEcon val_9 = App.getGameEcon;
            string val_10 = val_8._HintMEGACost.ToString(format:  val_9.numberFormatInt);
        }
        
        if(this.crossedOutCost == 0)
        {
                return;
        }
        
        this.crossedOutCost.SetActive(value:  false);
    }
    private void OnEnable()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        this.transform.parent.gameObject.SetActive(value:  false);
    }
    public WGMegaHintButton()
    {
    
    }

}
