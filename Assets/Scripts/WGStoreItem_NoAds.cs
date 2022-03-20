using UnityEngine;
public class WGStoreItem_NoAds : WGStoreItem
{
    // Fields
    private UnityEngine.UI.Text gemAmount;
    private UnityEngine.GameObject gemGroupParent;
    private UnityEngine.GameObject coinGroupParent;
    
    // Methods
    public override void UpdateUI(PurchaseModel pack, int packIndex, int totalPackItems, IStoreUI storeUI)
    {
        var val_25;
        var val_26;
        mem[1152921517987179144] = pack;
        mem[1152921517987179152] = storeUI;
        bool val_1 = UnityEngine.Object.op_Inequality(x:  storeUI, y:  0);
        if(val_1 != false)
        {
                val_1.sprite = 0;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  storeUI)) == false)
        {
            goto label_11;
        }
        
        decimal val_3 = pack.Credits;
        val_25 = null;
        val_25 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_11;
        }
        
        decimal val_5 = pack.Credits;
        GameEcon val_6 = App.getGameEcon;
        string val_7 = val_5.flags.ToString(format:  val_6.numberFormatInt);
        goto label_16;
        label_11:
        this.coinGroupParent.SetActive(value:  false);
        label_16:
        if((UnityEngine.Object.op_Implicit(exists:  this.gemAmount)) == false)
        {
            goto label_24;
        }
        
        decimal val_9 = pack.Gems;
        val_26 = null;
        val_26 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_24;
        }
        
        decimal val_11 = pack.Gems;
        GameEcon val_12 = App.getGameEcon;
        string val_13 = val_11.flags.ToString(format:  val_12.numberFormatInt);
        goto label_32;
        label_24:
        if(this.gemGroupParent != 0)
        {
                this.gemGroupParent.SetActive(value:  false);
        }
        
        label_32:
        if((UnityEngine.Object.op_Implicit(exists:  this.gemGroupParent)) != false)
        {
                string val_16 = pack.LocalPrice;
        }
        
        bool val_17 = UnityEngine.Object.op_Implicit(exists:  this.gemGroupParent);
        if(val_17 != false)
        {
                val_17.gameObject.SetActive(value:  false);
        }
        
        if((pack.id.Contains(value:  "removeAds")) == false)
        {
                return;
        }
        
        GameEcon val_20 = App.getGameEcon;
        if((pack.sale_price.Equals(obj:  val_20.NoAdsPackagePriceToUse)) != false)
        {
                if(App.Player.RemovedAds == false)
        {
                return;
        }
        
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public WGStoreItem_NoAds()
    {
        mem[1152921517987368872] = 1;
        val_1 = new MyButton();
    }

}
