using UnityEngine;
public class FeaturedOfferStoreItem : WGStoreItem
{
    // Fields
    private UnityEngine.UI.Text text_percent_discount;
    
    // Methods
    public override void UpdateUI(PurchaseModel pack, int packIndex, int totalPackItems, IStoreUI storeUI)
    {
        var val_9;
        this.UpdateUI(pack:  pack, packIndex:  packIndex, totalPackItems:  totalPackItems, storeUI:  storeUI);
        val_9 = null;
        decimal val_1 = FeaturedOfferManager.BonusCoinPercentage;
        decimal val_2 = new System.Decimal(value:  100);
        decimal val_3 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        GameEcon val_4 = App.getGameEcon;
        string val_8 = System.String.Format(format:  "{0}% ", arg0:  val_3.flags.ToString(format:  val_4.numberFormatInt))(System.String.Format(format:  "{0}% ", arg0:  val_3.flags.ToString(format:  val_4.numberFormatInt))) + Localization.Localize(key:  "bonus_upper", defaultValue:  "BONUS", useSingularKey:  false)(Localization.Localize(key:  "bonus_upper", defaultValue:  "BONUS", useSingularKey:  false));
    }
    public FeaturedOfferStoreItem()
    {
    
    }

}
