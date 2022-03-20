using UnityEngine;
public class DefaultHandler<T> : MonoBehaviour
{
    // Fields
    private static bool isQuitting;
    protected static T _Instance;
    
    // Properties
    public static T Instance { get; }
    protected Player Player { get; }
    
    // Methods
    public static T get_Instance()
    {
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        System.Object[] val_26;
        var val_27;
        var val_28;
        int val_29;
        var val_30;
        int val_31;
        int val_32;
        var val_33;
        var val_34;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        var val_39;
        val_21 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_21 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_21 & 1) == 0)
        {
                val_21 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_21 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        val_22 = 1152921504765632512;
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184 + 8) != 0)
        {
            goto label_135;
        }
        
        val_23 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_23 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_23 & 1) == 0)
        {
                val_23 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_23 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184) != 0)
        {
            goto label_135;
        }
        
        val_24 = mem[__RuntimeMethodHiddenParam + 24 + 302];
        val_24 = __RuntimeMethodHiddenParam + 24 + 302;
        val_25 = __RuntimeMethodHiddenParam + 24;
        if((val_24 & 1) == 0)
        {
                val_25 = mem[__RuntimeMethodHiddenParam + 24];
            val_25 = __RuntimeMethodHiddenParam + 24;
            val_24 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_24 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
        val_27 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 16 + 24];
        val_27 = __RuntimeMethodHiddenParam + 24 + 192 + 16 + 24;
        if(val_27 >= 2)
        {
                val_28 = 1152921505054202560;
            object[] val_2 = new object[3];
            val_26 = val_2;
            val_29 = val_2.Length;
            val_26[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 24});
            val_29 = val_2.Length;
            val_26[1] = " found: ";
            val_26[2] = __RuntimeMethodHiddenParam + 24 + 192 + 16 + 24;
            D.LogClientError(developer:  "NA", filter:  "default", context:  0, strings:  val_2);
            val_27 = (__RuntimeMethodHiddenParam + 24 + 192 + 16 + 24) & 4294967295;
            if((__RuntimeMethodHiddenParam + 24 + 192 + 16 + 24) >= 1)
        {
                val_30 = "] is null";
            object val_21 = 0;
            UnityEngine.Object val_4 = (__RuntimeMethodHiddenParam + 24 + 192 + 16) + 32;
            do
        {
            if(val_4 == 0)
        {
                object[] val_6 = new object[3];
            val_26 = val_6;
            val_26[0] = "instances[";
            val_31 = val_6.Length;
            val_26[1] = val_21;
            val_31 = val_6.Length;
            val_26[2] = "] is null";
            D.LogClientError(developer:  "NA", filter:  "default", context:  0, strings:  val_6);
        }
        else
        {
                object[] val_8 = new object[1];
            object[] val_9 = new object[4];
            val_9[0] = "instances[";
            val_32 = val_9.Length;
            val_9[1] = val_21;
            val_32 = val_9.Length;
            val_9[2] = "] = ";
            val_9[3] = val_4.name;
            val_22 = val_22;
            val_8[0] = +val_9;
            D.LogClientError(developer:  "NA", filter:  "default", context:  val_4.gameObject, strings:  val_8);
            val_28 = val_28;
            val_30 = "] is null";
            val_33 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_33 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_33 & 1) == 0)
        {
                val_33 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_33 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            val_26 = mem[__RuntimeMethodHiddenParam + 24 + 192];
            val_26 = __RuntimeMethodHiddenParam + 24 + 192;
            mem2[0] = val_4;
        }
        
            val_27 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 16 + 24];
            val_27 = __RuntimeMethodHiddenParam + 24 + 192 + 16 + 24;
            val_21 = val_21 + 1;
            val_4 = val_4 + 8;
        }
        while(val_21 < (val_27 << ));
        
        }
        
        }
        
        if(val_27 == 1)
        {
                if((__RuntimeMethodHiddenParam + 24 + 192 + 16 + 32) == 0)
        {
                object[] val_13 = new object[1];
            val_26 = "instances[0] is null";
            val_13[0] = "instances[0] is null";
            D.LogClientError(developer:  "NA", filter:  "default", context:  0, strings:  val_13);
        }
        else
        {
                val_26 = mem[__RuntimeMethodHiddenParam + 24];
            val_26 = __RuntimeMethodHiddenParam + 24;
            val_34 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_34 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_34 & 1) == 0)
        {
                val_34 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_34 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 16 + 32;
        }
        
        }
        
        val_35 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_35 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_35 & 1) == 0)
        {
                val_35 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_35 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 184 + 8) != 0) || (UnityEngine.Application.isPlaying == false))
        {
            goto label_135;
        }
        
        val_36 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_36 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_36 & 1) == 0)
        {
                val_36 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_36 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        val_28 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 184];
        val_28 = __RuntimeMethodHiddenParam + 24 + 192 + 184;
        if((new UnityEngine.GameObject(name:  "[HANDLER] " + System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 24})(System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 24})) + " (self-generated)"(" (self-generated)")).AddComponent(componentType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 24}))) != null)
        {
                if(X0 == true)
        {
            goto label_155;
        }
        
        }
        
        val_37 = 0;
        label_155:
        mem2[0] = val_37;
        val_38 = mem[__RuntimeMethodHiddenParam + 24 + 302];
        val_38 = __RuntimeMethodHiddenParam + 24 + 302;
        val_26 = __RuntimeMethodHiddenParam + 24;
        if((val_38 & 1) == 0)
        {
                val_26 = mem[__RuntimeMethodHiddenParam + 24];
            val_26 = __RuntimeMethodHiddenParam + 24;
            val_38 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_38 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
        label_135:
        val_39 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_39 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_39 & 1) == 0)
        {
                val_39 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_39 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) != 0)
        {
                return (PurchasesHandler)__RuntimeMethodHiddenParam + 24 + 192 + 184 + 8;
        }
        
        return (PurchasesHandler)__RuntimeMethodHiddenParam + 24 + 192 + 184 + 8;
    }
    public void OnApplicationQuit()
    {
        var val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_1 & 1) == 0)
        {
                val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        mem2[0] = 1;
    }
    protected virtual void AwakeLogic()
    {
    
    }
    protected Player get_Player()
    {
        return App.Player;
    }
    protected void RewardPlayerPurchase(PurchaseModel purchase)
    {
        var val_32;
        var val_33;
        var val_34;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        var val_39;
        var val_40;
        var val_41;
        var val_42;
        var val_43;
        var val_44;
        var val_45;
        decimal val_1 = purchase.Credits;
        val_32 = null;
        val_32 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_3 = purchase.Credits;
            val_33 = val_3.lo;
        }
        
        decimal val_4 = purchase.GoldenCurrency;
        val_34 = null;
        val_34 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_6 = purchase.GoldenCurrency;
            val_35 = val_6.lo;
        }
        
        decimal val_7 = purchase.Gems;
        val_36 = null;
        val_36 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_9 = purchase.Gems;
            val_37 = val_9.lo;
        }
        
        decimal val_10 = purchase.PetsFood;
        val_38 = null;
        val_38 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_12 = purchase.PetsFood;
            val_39 = val_12.lo;
        }
        
        decimal val_13 = purchase.PetCards;
        val_40 = null;
        val_40 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_15 = purchase.PetCards;
            val_41 = val_15.lo;
        }
        
        decimal val_16 = purchase.GoldenCurrency;
        val_42 = null;
        val_42 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_16.lo, mid = val_16.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                GameBehavior val_18 = App.getBehavior;
            if(((val_18.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
                decimal val_22 = purchase.GoldenCurrency;
            MonoSingleton<WordGameEventsController>.Instance.OnAppleAwarded(appleAwarded:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_22.flags, hi = val_22.hi, lo = val_22.lo, mid = val_22.mid}));
        }
        
        }
        
        }
        
        decimal val_24 = purchase.Spins;
        val_43 = null;
        val_43 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_24.flags, hi = val_24.hi, lo = val_24.lo, mid = val_24.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_26 = purchase.Spins;
            val_44 = val_26.lo;
        }
        
        decimal val_27 = purchase.DiceRolls;
        val_45 = null;
        val_45 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_27.flags, hi = val_27.hi, lo = val_27.lo, mid = val_27.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_29 = purchase.DiceRolls;
        }
        
        if((purchase.id.Contains(value:  "remove")) == false)
        {
                return;
        }
        
        App.Player.RemovedAds = true;
    }
    protected void RewardPlayer(string theType, decimal amount, string sourceOfReward = "")
    {
        if((System.String.op_Equality(a:  theType, b:  "credits")) != false)
        {
                this.AddCredits(amount:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}, source:  sourceOfReward, subSource:  0, externalParams:  0, doTrack:  true);
            return;
        }
        
        if((System.String.op_Equality(a:  theType, b:  "golden_currency")) != false)
        {
                int val_13 = amount.lo;
            val_13 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = val_13, mid = amount.mid})) + this;
            this.stars = val_13;
            return;
        }
        
        if((System.String.op_Equality(a:  theType, b:  "gems")) != false)
        {
                this.AddGems(amount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}), source:  sourceOfReward, subsource:  0);
            return;
        }
        
        if((System.String.op_Equality(a:  theType, b:  "pets_food")) != false)
        {
                this.AddPetsFood(amount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}), source:  sourceOfReward, subSource:  0, FoodSpentParams:  0, additionalParam:  0);
            return;
        }
        
        if((System.String.op_Equality(a:  theType, b:  "pet_cards")) != false)
        {
                MonoSingleton<WADPetsManager>.Instance.RewardPetCards(amount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}), pet:  0, source:  0, subsource:  0, additionalParam:  0);
            return;
        }
        
        if((System.String.op_Equality(a:  theType, b:  "dice_rolls")) == false)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.RewardDiceRolls(amount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = amount.flags, hi = amount.hi, lo = amount.lo, mid = amount.mid}), source:  sourceOfReward);
    }
    protected decimal GetTotalAmountByPackage(twelvegigs.storage.JsonDictionary packageDictionary, string packageType)
    {
        return PackagesManager.GetTotalAmountByPackage(pack:  packageDictionary, currencyType:  packageType);
    }
    protected twelvegigs.storage.JsonDictionary GetPackage(string id)
    {
        return PackagesManager.GetPackageById(packageId:  id);
    }
    public DefaultHandler<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    private static DefaultHandler<T>()
    {
    
    }

}
