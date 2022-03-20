using UnityEngine;
public class WGStoreItem_pet : WGStoreItem
{
    // Methods
    public override void UpdateUI(PurchaseModel pack, int packIndex, int totalPackItems, IStoreUI storeUI)
    {
        var val_15;
        var val_17;
        val_15 = this;
        mem[1152921517988016264] = pack;
        mem[1152921517988016272] = storeUI;
        bool val_1 = UnityEngine.Object.op_Inequality(x:  storeUI, y:  0);
        if(val_1 != false)
        {
                val_1.sprite = 0;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  storeUI)) != false)
        {
                decimal val_3 = pack.PetsFood;
            GameEcon val_4 = App.getGameEcon;
            string val_5 = val_3.flags.ToString(format:  val_4.numberFormatInt);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  storeUI)) != false)
        {
                string val_7 = pack.LocalPrice;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  pack)) == false)
        {
                return;
        }
        
        if((UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 192) != 0)
        {
                return;
        }
        
        if(totalPackItems >= 1)
        {
                int val_10 = packIndex - totalPackItems;
            val_17 = val_15 + ((UnityEngine.Mathf.Max(a:  ((packIndex - totalPackItems) + UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished)>>0&0xFFFFFFFF, b:  0)) << 3);
        }
        else
        {
                val_17 = val_15 + (packIndex << 3);
        }
        
        UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 192.sprite = 0;
    }
    public WGStoreItem_pet()
    {
        mem[1152921517988152744] = 1;
        val_1 = new MyButton();
    }

}
