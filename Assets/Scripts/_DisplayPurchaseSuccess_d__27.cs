using UnityEngine;
private sealed class WGStore_DicePacksPopup.<DisplayPurchaseSuccess>d__27 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PurchaseModel purchase;
    public WGStore_DicePacksPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGStore_DicePacksPopup.<DisplayPurchaseSuccess>d__27(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_28;
        int val_29;
        int val_30;
        var val_31;
        decimal val_32;
        var val_33;
        var val_34;
        int val_35;
        float val_36;
        var val_37;
        int val_38;
        int val_39;
        CurrencyCollectAnimationInstantiator val_40;
        int val_41;
        System.Action val_42;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_37;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_28 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_29 = 1;
        this.<>2__current = val_28;
        this.<>1__state = val_29;
        return (bool)val_29;
        label_2:
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_2 = null;
        val_28 = val_2;
        val_2 = new UnityEngine.WaitForEndOfFrame();
        this.<>2__current = val_28;
        this.<>1__state = 2;
        val_29 = 1;
        return (bool)val_29;
        label_1:
        val_28 = this.<>4__this;
        this.<>1__state = 0;
        val_30 = this.purchase.id.Contains(value:  "bundle");
        decimal val_4 = this.purchase.Credits;
        val_31 = null;
        val_31 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                Player val_6 = App.Player;
            decimal val_7 = this.purchase.Credits;
            decimal val_8 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
            Player val_9 = App.Player;
            val_32 = val_9._credits;
            val_28.AnimateCoins(fromAmount:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, toAmount:  new System.Decimal() {flags = val_32, hi = val_32}, actionOnComplete:  0);
            val_33 = 1;
        }
        else
        {
                val_33 = 0;
        }
        
        decimal val_10 = this.purchase.PetsFood;
        val_34 = null;
        val_34 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                Player val_13 = App.Player;
            decimal val_14 = this.purchase.PetsFood;
            Player val_16 = App.Player;
            val_35 = val_16._food;
            val_28.AnimatePurchase(animControl:  this.<>4__this.foodAnim, fromAmount:  val_13._food - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid})), toAmount:  val_35, actionOnComplete:  0, delay:  (val_30 != true) ? 1.8f : 0.9f);
            val_33 = 1;
        }
        else
        {
                val_36 = 0.9f;
        }
        
        decimal val_18 = this.purchase.DiceRolls;
        val_37 = null;
        val_38 = val_18.lo;
        val_37 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_18.flags, hi = val_18.hi, lo = val_38, mid = val_18.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_30 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceBalance();
            val_36 = ((val_30 != true) ? 0.9f : 0f) + val_36;
            decimal val_22 = this.purchase.DiceRolls;
            val_38 = val_22.lo;
            if(val_33 != 0)
        {
                val_39 = val_30 - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_22.flags, hi = val_22.hi, lo = val_38, mid = val_22.mid}));
            val_40 = this.<>4__this.diceAnim;
            val_41 = val_30;
            val_42 = 0;
        }
        else
        {
                System.Action val_25 = null;
            val_38 = val_25;
            val_25 = new System.Action(object:  val_28, method:  typeof(WGStore_DicePacksPopup).__il2cppRuntimeField_1C8);
            val_39 = val_30 - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_22.flags, hi = val_22.hi, lo = val_38, mid = val_22.mid}));
            val_40 = this.<>4__this.diceAnim;
            val_41 = val_30;
            val_42 = val_38;
        }
        
            val_28.AnimatePurchase(animControl:  val_40, fromAmount:  val_39, toAmount:  val_41, actionOnComplete:  val_25, delay:  val_36);
        }
        
        label_37:
        val_29 = 0;
        return (bool)val_29;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
