using UnityEngine;
public class DynamicToolTipButton : MyButton
{
    // Fields
    private bool topToolTip;
    private UnityEngine.GameObject toolTipOwner;
    private string tooltipLocKey;
    private string toolTipText;
    private UnityEngine.GameObject currentToolTip;
    
    // Methods
    public override void OnButtonClick()
    {
        this.OnButtonClick();
        this.PlaceToolTip();
    }
    private void PlaceToolTip()
    {
        UnityEngine.GameObject val_9;
        UnityEngine.Object val_10;
        val_9 = 1152921504765632512;
        if(this.currentToolTip != 0)
        {
                return;
        }
        
        DynamicToolTip val_3 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        this.currentToolTip = val_3.gameObject;
        val_9 = this.gameObject;
        val_10 = 0;
        if(this.toolTipOwner != val_10)
        {
                val_10 = 0;
            val_9 = this.toolTipOwner.gameObject;
        }
        
        val_3.ShowToolTip(objToToolTip:  val_9, text:  Localization.Localize(key:  this.tooltipLocKey, defaultValue:  this.toolTipText, useSingularKey:  false), topToolTip:  this.topToolTip, displayDuration:  3.5f, width:  0f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
    }
    public DynamicToolTipButton()
    {
        this.topToolTip = true;
        this.tooltipLocKey = "";
        this.toolTipText = "";
    }

}
