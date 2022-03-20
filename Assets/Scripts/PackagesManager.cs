using UnityEngine;
public class PackagesManager
{
    // Fields
    public const string CREDITS = "credits";
    public const string GOLDEN_CURRENCY = "golden_currency";
    public const string SPECIAL = "special";
    public const string PRICE = "sale_price";
    public const string LOC_PRICE = "regular_price";
    public const string ID = "id";
    public const string GEMS = "gems";
    public const string PETS_FOOD = "pets_food";
    public const string PET_CARDS = "pet_cards";
    public const string DICE_ROLLS = "dice_rolls";
    public const string KEYS = "keys";
    public const string SPINS = "spins";
    public const string REMOVEADS = "removeAds";
    public const string GOLDEN_TICKET = "golden_ticket";
    public const string SILVER_TICKET = "silver_ticket";
    private static PackageDefinitions myDef;
    private static string[] NonConsumables;
    private static bool transformedCreditPacks;
    private static float _knownBestValuePrice;
    
    // Properties
    public static PackageDefinitions getDef { get; }
    
    // Methods
    public static PackageDefinitions get_getDef()
    {
        object val_4;
        var val_5;
        var val_6;
        val_5 = null;
        val_5 = null;
        if(PackagesManager.myDef == null)
        {
                GameBehavior val_1 = App.getBehavior;
            val_6 = null;
            val_4 = System.Activator.CreateInstance(type:  val_1.<metaGameBehavior>k__BackingField);
            val_6 = null;
            PackagesManager.myDef = val_4;
            val_5 = null;
        }
        
        val_5 = null;
        return (PackageDefinitions)PackagesManager.myDef;
    }
    private static System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> GetListToUseForGame(string packageType)
    {
        string val_16 = packageType;
        if((System.String.op_Equality(a:  val_16 = packageType, b:  "pets_food")) == false)
        {
            goto label_1;
        }
        
        PackageDefinitions val_2 = PackagesManager.getDef;
        goto label_20;
        label_1:
        if((System.String.op_Equality(a:  val_16, b:  "dice_rolls")) == false)
        {
            goto label_6;
        }
        
        PackageDefinitions val_4 = PackagesManager.getDef;
        goto label_20;
        label_6:
        if((System.String.op_Equality(a:  val_16, b:  "gems")) == false)
        {
            goto label_11;
        }
        
        PackageDefinitions val_6 = PackagesManager.getDef;
        goto label_20;
        label_11:
        if((System.String.op_Equality(a:  val_16, b:  "spins")) == false)
        {
            goto label_16;
        }
        
        PackageDefinitions val_8 = PackagesManager.getDef;
        goto label_20;
        label_16:
        if((System.String.op_Equality(a:  val_16, b:  "special")) == false)
        {
            goto label_21;
        }
        
        PackageDefinitions val_10 = PackagesManager.getDef;
        label_20:
        val_16 = ???;
        goto typeof(PackageDefinitions).__il2cppRuntimeField_1D0;
        label_21:
        bool val_11 = System.String.op_Equality(a:  val_16, b:  "credits");
        return PackagesManager.GetCreditsForGame();
    }
    private static System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> GetCreditsForGame()
    {
        var val_8;
        System.Collections.Generic.IEnumerable<TSource> val_9;
        var val_10;
        System.Func<System.Collections.Generic.Dictionary<System.String, System.Object>, System.Boolean> val_12;
        System.Func<TSource, System.Boolean> val_13;
        val_8 = null;
        val_8 = null;
        if(PackagesManager.transformedCreditPacks != true)
        {
                decimal val_2 = PackagesManager.GetCreditPackMultiplierForGame();
            PackagesManager.TransformCreditPacks(creditPacks:  PackagesManager.getDef, multiplier:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
            val_8 = null;
        }
        
        val_9 = PackagesManager.getDef;
        val_10 = null;
        val_10 = null;
        val_12 = PackagesManager.<>c.<>9__19_0;
        if(val_12 == null)
        {
                System.Func<System.Collections.Generic.Dictionary<System.String, System.Object>, System.Boolean> val_4 = null;
            val_12 = val_4;
            val_4 = new System.Func<System.Collections.Generic.Dictionary<System.String, System.Object>, System.Boolean>(object:  PackagesManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PackagesManager.<>c::<GetCreditsForGame>b__19_0(System.Collections.Generic.Dictionary<string, object> x));
            PackagesManager.<>c.<>9__19_0 = val_12;
        }
        
        val_13 = val_12;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = System.Linq.Enumerable.FirstOrDefault<System.Collections.Generic.Dictionary<System.String, System.Object>>(source:  val_9, predicate:  val_4);
        if(val_5 == null)
        {
                return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)PackagesManager.getDef;
        }
        
        val_9 = val_5;
        GameEcon val_6 = App.getGameEcon;
        val_13 = "credits";
        val_9.set_Item(key:  val_13, value:  val_6.NoAdsStarterPackCoinAmount);
        return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>)PackagesManager.getDef;
    }
    private static decimal GetCreditPackMultiplierForGame()
    {
        var val_2;
        var val_3;
        var val_4;
        val_2 = 1152921504884269056;
        val_3 = null;
        val_3 = null;
        GameNames val_2 = App.game;
        val_2 = val_2 - 16;
        if(val_2 <= 5)
        {
                var val_3 = 32558320 + ((App.game - 16)) << 2;
            val_3 = val_3 + 32558320;
        }
        else
        {
                decimal val_1;
            val_4 = 10;
            val_1 = new System.Decimal(value:  10);
            return new System.Decimal() {flags = val_1.flags, hi = val_1.flags, lo = val_1.lo, mid = val_1.lo};
        }
    
    }
    public static decimal GetCreditsAmountByIndex(string packageType, int packageIndex)
    {
        var val_5;
        var val_6;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = PackagesManager.GetListToUseForGame(packageType:  packageType);
        label_17:
        var val_6 = 0;
        do
        {
            val_5 = null;
            val_5 = null;
            System.String[] val_5 = PackagesManager.NonConsumables;
            if(W9 <= (long)packageIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_5 = val_5 + (((long)(int)(packageIndex)) << 3);
            if(val_6 >= PackagesManager.NonConsumables.Length)
        {
                return PackagesManager.GetTotalAmountByPackage(thePack:  (PackagesManager.NonConsumables + ((long)(int)(packageIndex)) << 3) + 32, currencyType:  packageType);
        }
        
            val_6 = null;
            val_6 = null;
            val_6 = val_6 + 1;
        }
        while(((PackagesManager.NonConsumables + ((long)(int)(packageIndex)) << 3) + 32.Item["id"].Contains(value:  PackagesManager.NonConsumables + 32)) == false);
        
        var val_4 = (long)packageIndex + 1;
        goto label_17;
    }
    public static float GetPriceByIndex(string packageType, int index)
    {
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = PackagesManager.GetListToUseForGame(packageType:  packageType);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        return new twelvegigs.storage.JsonDictionary(parsedDictionary:  (PackagesManager.__il2cppRuntimeField_cctor_finished + (index) << 3) + 32).getFloat(key:  "sale_price", defaultValue:  1f);
    }
    public static twelvegigs.storage.JsonDictionary GetPackageByIndex(string packageType, int index)
    {
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = PackagesManager.GetListToUseForGame(packageType:  packageType);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary(parsedDictionary:  (PackagesManager.__il2cppRuntimeField_cctor_finished + (index) << 3) + 32);
    }
    public static twelvegigs.storage.JsonDictionary GetPackageBySubscriptionID(string packageType, SubscriptionHandler.SubScriptionType instruction)
    {
        .subID = (instruction == 0) ? "golden_ticket" : "silver_ticket";
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = System.Linq.Enumerable.FirstOrDefault<System.Collections.Generic.Dictionary<System.String, System.Object>>(source:  PackagesManager.GetListToUseForGame(packageType:  packageType), predicate:  new System.Func<System.Collections.Generic.Dictionary<System.String, System.Object>, System.Boolean>(object:  new PackagesManager.<>c__DisplayClass24_0(), method:  System.Boolean PackagesManager.<>c__DisplayClass24_0::<GetPackageBySubscriptionID>b__0(System.Collections.Generic.Dictionary<string, object> x)));
        GameBehavior val_6 = App.getBehavior;
        return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary(parsedDictionary:  val_6.<metaGameBehavior>k__BackingField);
    }
    public static decimal GetTotalAmountByPackage(System.Collections.IDictionary thePack, string currencyType)
    {
        var val_2 = null;
        return new twelvegigs.storage.JsonDictionary(parsedDictionary:  thePack).getDecimal(key:  currencyType, defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
    }
    public static decimal GetTotalAmountByPackage(twelvegigs.storage.JsonDictionary pack, string currencyType)
    {
        null = null;
        return pack.getDecimal(key:  currencyType, defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
    }
    public static System.Collections.IList GetPackages(string packageType)
    {
        return PackagesManager.GetPackagesByType(packageType:  packageType);
    }
    private static System.Collections.Generic.List<twelvegigs.storage.JsonDictionary> GetPackagesByType(string packageType)
    {
        var val_4;
        System.Collections.Generic.List<twelvegigs.storage.JsonDictionary> val_2 = null;
        val_4 = val_2;
        val_2 = new System.Collections.Generic.List<twelvegigs.storage.JsonDictionary>();
        if((PackagesManager.GetListToUseForGame(packageType:  packageType)) != null)
        {
                if(1152921515762115440 < 1)
        {
                return (System.Collections.Generic.List<twelvegigs.storage.JsonDictionary>)val_4;
        }
        
            var val_4 = 0;
            do
        {
            if(val_4 >= 1152921515762115440)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2.Add(item:  new twelvegigs.storage.JsonDictionary(parsedDictionary:  public System.Void System.Action<System.Int32, System.Int32>::.ctor(object object, IntPtr method)));
            val_4 = val_4 + 1;
        }
        while(val_4 < 44350344);
        
            return (System.Collections.Generic.List<twelvegigs.storage.JsonDictionary>)val_4;
        }
        
        val_4 = 0;
        return (System.Collections.Generic.List<twelvegigs.storage.JsonDictionary>)val_4;
    }
    public static twelvegigs.storage.JsonDictionary GetPackageById(string packageId)
    {
        var val_8;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_2 = PackagesManager.GetListToUseForGame(packageType:  PackagesManager.InferPackageKind(packageId:  packageId));
        if(val_2 == null)
        {
            goto label_3;
        }
        
        List.Enumerator<T> val_3 = val_2.GetEnumerator();
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  0.Item["id"], b:  packageId)) == false)
        {
            goto label_7;
        }
        
        twelvegigs.storage.JsonDictionary val_7 = null;
        val_8 = val_7;
        val_7 = new twelvegigs.storage.JsonDictionary(parsedDictionary:  0);
        goto label_8;
        label_3:
        val_8 = 0;
        return (twelvegigs.storage.JsonDictionary)val_8;
        label_4:
        val_8 = 0;
        label_8:
        0.Dispose();
        return (twelvegigs.storage.JsonDictionary)val_8;
    }
    public static bool IsNonConsumable(PurchaseModel purchase)
    {
        var val_2;
        if((purchase == null) || (purchase.id == null))
        {
                return false;
        }
        
        val_2 = null;
        val_2 = null;
        int val_2 = PackagesManager.NonConsumables.Length;
        if(val_2 >= 1)
        {
                var val_3 = 0;
            val_2 = val_2 & 4294967295;
            do
        {
            if((purchase.id.Contains(value:  X22 + 0)) == true)
        {
                return false;
        }
        
            val_3 = val_3 + 1;
        }
        while(val_3 < (PackagesManager.NonConsumables.Length << ));
        
        }
        
        return false;
    }
    private static string InferPackageKind(string packageId)
    {
        string val_4 = "credits";
        if(((packageId.LastIndexOf(value:  "credits")) & 2147483648) == 0)
        {
                return (string)((packageId.LastIndexOf(value:  "gems")) >= 0) ? "gems" : "special";
        }
        
        return (string)((packageId.LastIndexOf(value:  "gems")) >= 0) ? "gems" : "special";
    }
    private static void TransformCreditPacks(System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> creditPacks, decimal multiplier)
    {
        var val_2;
        int val_3;
        string val_8;
        var val_10;
        List.Enumerator<T> val_1 = creditPacks.GetEnumerator();
        label_7:
        val_8 = public System.Boolean List.Enumerator<System.Collections.Generic.Dictionary<System.String, System.Object>>::MoveNext();
        if(val_3.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_8 = "credits";
        object val_5 = val_2.Item[val_8];
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        decimal val_6 = System.Decimal.Parse(s:  val_5, style:  511);
        decimal val_7 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, d2:  new System.Decimal() {flags = multiplier.flags, hi = multiplier.hi, lo = multiplier.lo, mid = multiplier.mid});
        val_3 = val_7.flags;
        val_2.set_Item(key:  "credits", value:  val_7);
        goto label_7;
        label_2:
        val_3.Dispose();
        val_10 = null;
        val_10 = null;
        PackagesManager.transformedCreditPacks = true;
    }
    public static void UpdateCreditsFromStore(System.Collections.Generic.Dictionary<string, string> items)
    {
        string val_5;
        var val_6;
        var val_78;
        var val_79;
        var val_80;
        SLCDebug.Log(logMessage:  "UpdateCreditsFromStore ::\n"("UpdateCreditsFromStore ::\n") + PrettyPrint.printJSON(obj:  items, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  items, types:  false, singleLineOutput:  false)), colorHash:  "#FFFFFF", isError:  false);
        List.Enumerator<T> val_4 = PackagesManager.getDef.GetEnumerator();
        val_78 = 0;
        label_22:
        if(val_6.MoveNext() == false)
        {
            goto label_9;
        }
        
        if(items == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_5;
        Dictionary.Enumerator<TKey, TValue> val_8 = items.GetEnumerator();
        label_18:
        if(val_6.MoveNext() == false)
        {
            goto label_11;
        }
        
        if(val_78 == 0)
        {
                throw new NullReferenceException();
        }
        
        object val_11 = val_78.Item["id"];
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_11.Equals(value:  val_5)) == false)
        {
            goto label_18;
        }
        
        if((val_78.ContainsKey(key:  "regular_price")) == false)
        {
            goto label_16;
        }
        
        val_78.set_Item(key:  "regular_price", value:  val_5);
        goto label_18;
        label_16:
        val_78.Add(key:  "regular_price", value:  val_5);
        goto label_18;
        label_11:
        val_78 = 0;
        var val_14 = val_78 + 1;
        mem2[0] = 181;
        val_6.Dispose();
        if(val_78 != 0)
        {
                throw val_78;
        }
        
        if((val_14 == 1) || ((-1728864992 + ((val_78 + 1)) << 2) != 181))
        {
            goto label_22;
        }
        
        var val_89 = 0;
        val_89 = val_89 ^ (val_14 >> 31);
        var val_15 = val_14 + val_89;
        goto label_22;
        label_9:
        val_78 = val_78 + 1;
        mem2[0] = 209;
        val_6.Dispose();
        if(val_78 != 1)
        {
                var val_16 = ((-1728864992 + ((val_78 + 1)) << 2) == 209) ? 1 : 0;
            val_16 = ((val_78 >= 0) ? 1 : 0) & val_16;
            val_79 = val_78 - val_16;
        }
        else
        {
                val_79 = 0;
        }
        
        List.Enumerator<T> val_19 = PackagesManager.getDef.GetEnumerator();
        label_56:
        if(val_6.MoveNext() == false)
        {
            goto label_43;
        }
        
        if(items == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_5;
        Dictionary.Enumerator<TKey, TValue> val_21 = items.GetEnumerator();
        label_52:
        if(val_6.MoveNext() == false)
        {
            goto label_45;
        }
        
        if(val_78 == 0)
        {
                throw new NullReferenceException();
        }
        
        object val_23 = val_78.Item["id"];
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_23.Equals(value:  val_5)) == false)
        {
            goto label_52;
        }
        
        if((val_78.ContainsKey(key:  "regular_price")) == false)
        {
            goto label_50;
        }
        
        val_78.set_Item(key:  "regular_price", value:  val_5);
        goto label_52;
        label_50:
        val_78.Add(key:  "regular_price", value:  val_5);
        goto label_52;
        label_45:
        var val_26 = val_79 + 1;
        val_78 = 0;
        mem2[0] = 367;
        val_6.Dispose();
        if(val_78 != 0)
        {
                throw val_78;
        }
        
        if((val_26 == 1) || ((-1728864992 + ((val_79 + 1)) << 2) != 367))
        {
            goto label_56;
        }
        
        var val_90 = 0;
        val_90 = val_90 ^ (val_26 >> 31);
        var val_27 = val_26 + val_90;
        goto label_56;
        label_43:
        val_79 = val_79 + 1;
        mem2[0] = 395;
        val_6.Dispose();
        if(val_79 != 1)
        {
                var val_28 = ((-1728864992 + ((val_79 + 1)) << 2) == 395) ? 1 : 0;
            val_28 = ((val_79 >= 0) ? 1 : 0) & val_28;
            val_80 = val_79 - val_28;
        }
        else
        {
                val_80 = 0;
        }
        
        List.Enumerator<T> val_31 = PackagesManager.getDef.GetEnumerator();
        label_90:
        if(val_6.MoveNext() == false)
        {
            goto label_77;
        }
        
        if(items == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_5;
        Dictionary.Enumerator<TKey, TValue> val_33 = items.GetEnumerator();
        label_86:
        if(val_6.MoveNext() == false)
        {
            goto label_79;
        }
        
        if(val_78 == 0)
        {
                throw new NullReferenceException();
        }
        
        object val_35 = val_78.Item["id"];
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_35.Equals(value:  val_5)) == false)
        {
            goto label_86;
        }
        
        if((val_78.ContainsKey(key:  "regular_price")) == false)
        {
            goto label_84;
        }
        
        val_78.set_Item(key:  "regular_price", value:  val_5);
        goto label_86;
        label_84:
        val_78.Add(key:  "regular_price", value:  val_5);
        goto label_86;
        label_79:
        var val_38 = val_80 + 1;
        val_78 = 0;
        mem2[0] = 553;
        val_6.Dispose();
        if(val_78 != 0)
        {
                throw val_78;
        }
        
        if((val_38 == 1) || ((-1728864992 + ((val_80 + 1)) << 2) != 553))
        {
            goto label_90;
        }
        
        var val_91 = 0;
        val_91 = val_91 ^ (val_38 >> 31);
        var val_39 = val_38 + val_91;
        goto label_90;
        label_77:
        val_80 = val_80 + 1;
        mem2[0] = 581;
        val_6.Dispose();
        if(val_80 != 1)
        {
                var val_40 = ((-1728864992 + ((val_80 + 1)) << 2) == 581) ? 1 : 0;
            val_40 = ((val_80 >= 0) ? 1 : 0) & val_40;
            val_78 = val_80 - val_40;
        }
        else
        {
                val_78 = 0;
        }
        
        List.Enumerator<T> val_43 = PackagesManager.getDef.GetEnumerator();
        label_124:
        if(val_6.MoveNext() == false)
        {
            goto label_111;
        }
        
        if(items == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_5;
        Dictionary.Enumerator<TKey, TValue> val_45 = items.GetEnumerator();
        label_120:
        if(val_6.MoveNext() == false)
        {
            goto label_113;
        }
        
        if(val_78 == 0)
        {
                throw new NullReferenceException();
        }
        
        object val_47 = val_78.Item["id"];
        if(val_47 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_47 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_47.Equals(value:  val_5)) == false)
        {
            goto label_120;
        }
        
        if((val_78.ContainsKey(key:  "regular_price")) == false)
        {
            goto label_118;
        }
        
        val_78.set_Item(key:  "regular_price", value:  val_5);
        goto label_120;
        label_118:
        val_78.Add(key:  "regular_price", value:  val_5);
        goto label_120;
        label_113:
        val_78 = 0;
        var val_50 = val_78 + 1;
        mem2[0] = 739;
        val_6.Dispose();
        if(val_78 != 0)
        {
                throw val_78;
        }
        
        if((val_50 == 1) || ((-1728864992 + ((val_78 + 1)) << 2) != 739))
        {
            goto label_124;
        }
        
        var val_92 = 0;
        val_92 = val_92 ^ (val_50 >> 31);
        var val_51 = val_50 + val_92;
        goto label_124;
        label_111:
        val_78 = val_78 + 1;
        mem2[0] = 767;
        val_6.Dispose();
        if(val_78 != 1)
        {
                var val_52 = ((-1728864992 + ((val_78 + 1)) << 2) == 767) ? 1 : 0;
            val_52 = ((val_78 >= 0) ? 1 : 0) & val_52;
            val_78 = val_78 - val_52;
        }
        else
        {
                val_78 = 0;
        }
        
        List.Enumerator<T> val_55 = PackagesManager.getDef.GetEnumerator();
        label_158:
        if(val_6.MoveNext() == false)
        {
            goto label_145;
        }
        
        if(items == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_5;
        Dictionary.Enumerator<TKey, TValue> val_57 = items.GetEnumerator();
        label_154:
        if(val_6.MoveNext() == false)
        {
            goto label_147;
        }
        
        if(val_78 == 0)
        {
                throw new NullReferenceException();
        }
        
        object val_59 = val_78.Item["id"];
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_59.Equals(value:  val_5)) == false)
        {
            goto label_154;
        }
        
        if((val_78.ContainsKey(key:  "regular_price")) == false)
        {
            goto label_152;
        }
        
        val_78.set_Item(key:  "regular_price", value:  val_5);
        goto label_154;
        label_152:
        val_78.Add(key:  "regular_price", value:  val_5);
        goto label_154;
        label_147:
        val_78 = 0;
        var val_62 = val_78 + 1;
        mem2[0] = 925;
        val_6.Dispose();
        if(val_78 != 0)
        {
                throw val_78;
        }
        
        if((val_62 == 1) || ((-1728864992 + ((val_78 + 1)) << 2) != 925))
        {
            goto label_158;
        }
        
        var val_93 = 0;
        val_93 = val_93 ^ (val_62 >> 31);
        var val_63 = val_62 + val_93;
        goto label_158;
        label_145:
        val_78 = val_78 + 1;
        mem2[0] = 953;
        val_6.Dispose();
        if(val_78 != 1)
        {
                var val_64 = ((-1728864992 + ((val_78 + 1)) << 2) == 953) ? 1 : 0;
            val_64 = ((val_78 >= 0) ? 1 : 0) & val_64;
            val_78 = val_78 - val_64;
        }
        else
        {
                val_78 = 0;
        }
        
        List.Enumerator<T> val_67 = PackagesManager.getDef.GetEnumerator();
        label_192:
        if(val_6.MoveNext() == false)
        {
            goto label_179;
        }
        
        if(items == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_5;
        Dictionary.Enumerator<TKey, TValue> val_69 = items.GetEnumerator();
        label_188:
        if(val_6.MoveNext() == false)
        {
            goto label_181;
        }
        
        if(val_78 == 0)
        {
                throw new NullReferenceException();
        }
        
        object val_71 = val_78.Item["id"];
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_71.Equals(value:  val_5)) == false)
        {
            goto label_188;
        }
        
        if((val_78.ContainsKey(key:  "regular_price")) == false)
        {
            goto label_186;
        }
        
        val_78.set_Item(key:  "regular_price", value:  val_5);
        goto label_188;
        label_186:
        val_78.Add(key:  "regular_price", value:  val_5);
        goto label_188;
        label_181:
        val_78 = 0;
        var val_74 = val_78 + 1;
        mem2[0] = 1111;
        val_6.Dispose();
        if(val_78 != 0)
        {
                throw val_78;
        }
        
        if((val_74 == 1) || ((-1728864992 + ((val_78 + 1)) << 2) != 1111))
        {
            goto label_192;
        }
        
        var val_94 = 0;
        val_94 = val_94 ^ (val_74 >> 31);
        var val_75 = val_74 + val_94;
        goto label_192;
        label_179:
        val_78 = val_78 + 1;
        mem2[0] = 1139;
        val_6.Dispose();
        if(val_78 != 1)
        {
                var val_76 = ((-1728864992 + ((val_78 + 1)) << 2) == 1139) ? 1 : 0;
            val_76 = ((val_78 >= 0) ? 1 : 0) & val_76;
            val_78 = val_78 - val_76;
        }
        else
        {
                val_78 = 0;
        }
        
        List.Enumerator<T> val_79 = PackagesManager.getDef.GetEnumerator();
        label_226:
        if(val_6.MoveNext() == false)
        {
            goto label_213;
        }
        
        if(items == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_5;
        Dictionary.Enumerator<TKey, TValue> val_81 = items.GetEnumerator();
        label_222:
        if(val_6.MoveNext() == false)
        {
            goto label_215;
        }
        
        if(val_78 == 0)
        {
                throw new NullReferenceException();
        }
        
        object val_83 = val_78.Item["id"];
        if(val_83 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_83 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_83.Equals(value:  val_5)) == false)
        {
            goto label_222;
        }
        
        if((val_78.ContainsKey(key:  "regular_price")) == false)
        {
            goto label_220;
        }
        
        val_78.set_Item(key:  "regular_price", value:  val_5);
        goto label_222;
        label_220:
        val_78.Add(key:  "regular_price", value:  val_5);
        goto label_222;
        label_215:
        val_78 = 0;
        var val_86 = val_78 + 1;
        mem2[0] = 1297;
        val_6.Dispose();
        if(val_78 != 0)
        {
                throw val_78;
        }
        
        if((val_86 == 1) || ((-1728864992 + ((val_78 + 1)) << 2) != 1297))
        {
            goto label_226;
        }
        
        var val_95 = 0;
        val_95 = val_95 ^ (val_86 >> 31);
        var val_87 = val_86 + val_95;
        goto label_226;
        label_213:
        var val_88 = val_78 + 1;
        mem2[0] = 1325;
        val_6.Dispose();
    }
    public static float GetBestValuePackPrice(System.Collections.Generic.List<PurchaseModel> unfiltered)
    {
        var val_1 = null;
        if(PackagesManager._knownBestValuePrice > 0f)
        {
                return 0f;
        }
        
        if(unfiltered != null)
        {
                var val_2 = 4;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_1 = null;
            val_1 = null;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_1 = null;
            val_1 = null;
            PackagesManager._knownBestValuePrice = PackagesManager.myDef.__il2cppRuntimeField_20 + 112;
            val_2 = val_2 + 1;
            var val_1 = val_2 - 4;
            val_1 = null;
            return 0f;
        }
        
        UnityEngine.Debug.LogError(message:  "PackagesManager:GetBestValuePackPrice: unknown best value price");
        return 0f;
    }
    public static string GetPackagePrice(twelvegigs.storage.JsonDictionary package)
    {
        string val_5 = "";
        if(package == null)
        {
                return (string)val_5;
        }
        
        var val_6 = 0;
        val_6 = val_6 + 1;
        if(package.dataSource.Count == 0)
        {
                return (string)val_5;
        }
        
        string val_3 = package.getString(key:  "regular_price", defaultValue:  "");
        val_5 = val_3;
        if((System.String.op_Equality(a:  val_3, b:  "")) == false)
        {
                return (string)val_5;
        }
        
        return "$" + package.getString(key:  "sale_price", defaultValue:  "")(package.getString(key:  "sale_price", defaultValue:  ""));
    }
    public static int GetAdPackageCount(string packageType)
    {
        var val_3;
        System.Func<twelvegigs.storage.JsonDictionary, System.Boolean> val_5;
        val_3 = null;
        val_3 = null;
        val_5 = PackagesManager.<>c.<>9__39_0;
        if(val_5 != null)
        {
                return System.Linq.Enumerable.Count<twelvegigs.storage.JsonDictionary>(source:  PackagesManager.GetPackagesByType(packageType:  packageType), predicate:  System.Func<twelvegigs.storage.JsonDictionary, System.Boolean> val_2 = null);
        }
        
        val_5 = val_2;
        val_2 = new System.Func<twelvegigs.storage.JsonDictionary, System.Boolean>(object:  PackagesManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PackagesManager.<>c::<GetAdPackageCount>b__39_0(twelvegigs.storage.JsonDictionary x));
        PackagesManager.<>c.<>9__39_0 = val_5;
        return System.Linq.Enumerable.Count<twelvegigs.storage.JsonDictionary>(source:  PackagesManager.GetPackagesByType(packageType:  packageType), predicate:  val_2);
    }
    public PackagesManager()
    {
    
    }
    private static PackagesManager()
    {
        PackagesManager.myDef = 0;
        string[] val_1 = new string[1];
        val_1[0] = "remove";
        PackagesManager.NonConsumables = val_1;
        PackagesManager.transformedCreditPacks = false;
        PackagesManager._knownBestValuePrice = -1f;
    }

}
