using UnityEngine;
public class PiggyBankRaidEcon
{
    // Fields
    public const int MAX_BANK_LEVEL = 5;
    public int levelBuffer;
    public System.Collections.Generic.Dictionary<int, System.Decimal> bankMaxCoins;
    public System.Collections.Generic.Dictionary<int, System.Decimal> bankPriceTier;
    public System.Collections.Generic.List<float> raidOptionMultiplier;
    public decimal minimumRaidableCoins;
    public System.Collections.Generic.Dictionary<int, int> fakeOpponentBankLevelWeights;
    
    // Methods
    public PiggyBankRaidEcon()
    {
        this.levelBuffer = 2;
        System.Collections.Generic.Dictionary<System.Int32, System.Decimal> val_1 = new System.Collections.Generic.Dictionary<System.Int32, System.Decimal>();
        decimal val_2 = new System.Decimal(value:  88);
        val_1.Add(key:  1, value:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        decimal val_3 = new System.Decimal(value:  176);
        val_1.Add(key:  2, value:  new System.Decimal() {flags = val_3.flags, hi = val_3.flags, lo = val_3.lo, mid = val_3.lo});
        decimal val_4 = new System.Decimal(value:  96);
        val_1.Add(key:  3, value:  new System.Decimal() {flags = val_4.flags, hi = val_4.flags, lo = val_4.lo, mid = val_4.lo});
        decimal val_5 = new System.Decimal(value:  148);
        val_1.Add(key:  4, value:  new System.Decimal() {flags = val_5.flags, hi = val_5.flags, lo = val_5.lo, mid = val_5.lo});
        decimal val_6 = new System.Decimal(value:  40);
        val_1.Add(key:  5, value:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo});
        this.bankMaxCoins = val_1;
        System.Collections.Generic.Dictionary<System.Int32, System.Decimal> val_7 = new System.Collections.Generic.Dictionary<System.Int32, System.Decimal>();
        decimal val_8 = new System.Decimal(value:  199);
        val_7.Add(key:  1, value:  new System.Decimal() {flags = val_8.flags, hi = val_8.flags, lo = val_8.lo, mid = val_8.lo});
        decimal val_9 = new System.Decimal(value:  143);
        val_7.Add(key:  2, value:  new System.Decimal() {flags = val_9.flags, hi = val_9.flags, lo = val_9.lo, mid = val_9.lo});
        decimal val_10 = new System.Decimal(value:  31);
        val_7.Add(key:  3, value:  new System.Decimal() {flags = val_10.flags, hi = val_10.flags, lo = val_10.lo, mid = val_10.lo});
        decimal val_11 = new System.Decimal(value:  219);
        val_7.Add(key:  4, value:  new System.Decimal() {flags = val_11.flags, hi = val_11.flags, lo = val_11.lo, mid = val_11.lo});
        decimal val_12 = new System.Decimal(value:  183);
        val_7.Add(key:  5, value:  new System.Decimal() {flags = val_12.flags, hi = val_12.flags, lo = val_12.lo, mid = val_12.lo});
        this.bankPriceTier = val_7;
        System.Collections.Generic.List<System.Single> val_13 = new System.Collections.Generic.List<System.Single>();
        val_13.Add(item:  0.05f);
        val_13.Add(item:  0.1f);
        val_13.Add(item:  0.2f);
        decimal val_14;
        this.raidOptionMultiplier = val_13;
        val_14 = new System.Decimal(value:  20);
        this.minimumRaidableCoins = val_14.flags;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_15 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        val_15.Add(key:  1, value:  25);
        val_15.Add(key:  2, value:  25);
        val_15.Add(key:  3, value:  20);
        val_15.Add(key:  4, value:  15);
        val_15.Add(key:  5, value:  15);
        this.fakeOpponentBankLevelWeights = val_15;
    }
    public PiggyBankRaidEcon(System.Collections.Generic.Dictionary<string, object> eventDataDict)
    {
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_36;
        var val_37;
        int val_38;
        var val_39;
        this.levelBuffer = 2;
        System.Collections.Generic.Dictionary<System.Int32, System.Decimal> val_1 = new System.Collections.Generic.Dictionary<System.Int32, System.Decimal>();
        decimal val_2 = new System.Decimal(value:  88);
        val_1.Add(key:  1, value:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        decimal val_3 = new System.Decimal(value:  176);
        val_1.Add(key:  2, value:  new System.Decimal() {flags = val_3.flags, hi = val_3.flags, lo = val_3.lo, mid = val_3.lo});
        decimal val_4 = new System.Decimal(value:  96);
        val_1.Add(key:  3, value:  new System.Decimal() {flags = val_4.flags, hi = val_4.flags, lo = val_4.lo, mid = val_4.lo});
        decimal val_5 = new System.Decimal(value:  148);
        val_1.Add(key:  4, value:  new System.Decimal() {flags = val_5.flags, hi = val_5.flags, lo = val_5.lo, mid = val_5.lo});
        decimal val_6 = new System.Decimal(value:  40);
        val_1.Add(key:  5, value:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo});
        this.bankMaxCoins = val_1;
        System.Collections.Generic.Dictionary<System.Int32, System.Decimal> val_7 = new System.Collections.Generic.Dictionary<System.Int32, System.Decimal>();
        decimal val_8 = new System.Decimal(value:  199);
        val_7.Add(key:  1, value:  new System.Decimal() {flags = val_8.flags, hi = val_8.flags, lo = val_8.lo, mid = val_8.lo});
        decimal val_9 = new System.Decimal(value:  143);
        val_7.Add(key:  2, value:  new System.Decimal() {flags = val_9.flags, hi = val_9.flags, lo = val_9.lo, mid = val_9.lo});
        decimal val_10 = new System.Decimal(value:  31);
        val_7.Add(key:  3, value:  new System.Decimal() {flags = val_10.flags, hi = val_10.flags, lo = val_10.lo, mid = val_10.lo});
        decimal val_11 = new System.Decimal(value:  219);
        val_7.Add(key:  4, value:  new System.Decimal() {flags = val_11.flags, hi = val_11.flags, lo = val_11.lo, mid = val_11.lo});
        decimal val_12 = new System.Decimal(value:  183);
        val_7.Add(key:  5, value:  new System.Decimal() {flags = val_12.flags, hi = val_12.flags, lo = val_12.lo, mid = val_12.lo});
        this.bankPriceTier = val_7;
        System.Collections.Generic.List<System.Single> val_13 = new System.Collections.Generic.List<System.Single>();
        val_13.Add(item:  0.05f);
        val_13.Add(item:  0.1f);
        val_13.Add(item:  0.2f);
        decimal val_14;
        this.raidOptionMultiplier = val_13;
        val_14 = new System.Decimal(value:  20);
        this.minimumRaidableCoins = val_14.flags;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_15 = null;
        val_36 = val_15;
        val_15 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        val_15.Add(key:  1, value:  25);
        val_15.Add(key:  2, value:  25);
        val_15.Add(key:  3, value:  20);
        val_15.Add(key:  4, value:  15);
        val_37 = public System.Void System.Collections.Generic.Dictionary<System.Int32, System.Int32>::Add(System.Int32 key, System.Int32 value);
        val_15.Add(key:  5, value:  15);
        this.fakeOpponentBankLevelWeights = val_36;
        if(eventDataDict == null)
        {
                return;
        }
        
        val_36 = "economy";
        if((eventDataDict.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        if(eventDataDict.Item["economy"] == null)
        {
                return;
        }
        
        object val_18 = eventDataDict.Item["economy"];
        if((val_18.ContainsKey(key:  "levels")) != false)
        {
                object val_20 = val_18.Item["levels"];
            if(null >= 1)
        {
                do
        {
            if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((System.Decimal.TryParse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg + 16 + 32, result: out  new System.Decimal())) != false)
        {
                val_37 = 0;
            val_38 = 0 + 1;
            EnumerableExtentions.SetOrAdd<System.Int32, System.Decimal>(dic:  this.bankPriceTier, key:  val_38, newValue:  new System.Decimal());
        }
        
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((System.Decimal.TryParse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg + 16 + 40, result: out  new System.Decimal())) != false)
        {
                EnumerableExtentions.SetOrAdd<System.Int32, System.Decimal>(dic:  this.bankMaxCoins, key:  0 + 1, newValue:  new System.Decimal());
        }
        
        }
        while((0 + 1) < null);
        
        }
        
        }
        
        if((val_18.ContainsKey(key:  "m_r_c")) != false)
        {
                bool val_27 = System.Decimal.TryParse(s:  val_18.Item["m_r_c"], result: out  new System.Decimal() {flags = this.minimumRaidableCoins, hi = this.minimumRaidableCoins, lo = this.minimumRaidableCoins, mid = this.minimumRaidableCoins});
        }
        
        if((val_18.ContainsKey(key:  "r_o_m")) != false)
        {
                object val_29 = val_18.Item["r_o_m"];
            val_39 = 0;
            System.Collections.Generic.List<System.Single> val_31 = new System.Collections.Generic.List<System.Single>();
            var val_38 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((System.Single.TryParse(s:  ((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_29 : 0 + 16 + 0) + 32, result: out  float val_32 = -716291.3f)) != false)
        {
                val_31.Add(item:  0f);
        }
        
            val_38 = val_38 + 1;
            this.raidOptionMultiplier = val_31;
        }
        
        val_36 = "r_o_w";
        if((val_18.ContainsKey(key:  "r_o_w")) == false)
        {
                return;
        }
        
        object val_35 = val_18.Item["r_o_w"];
        if(null < 1)
        {
                return;
        }
        
        if(null <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_36 = 0 + 1;
        if((System.Int32.TryParse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, result: out  0)) == false)
        {
                return;
        }
        
        EnumerableExtentions.SetOrAdd<System.Int32, System.Int32>(dic:  this.fakeOpponentBankLevelWeights, key:  val_36, newValue:  0);
    }

}
