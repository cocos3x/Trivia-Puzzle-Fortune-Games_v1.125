using UnityEngine;
public class SpinKingSlotMachine
{
    // Fields
    public const int NumberOfReel = 3;
    public const int NumberOfRow = 5;
    public static SpinKingSlotMachine.SpinType hackSpinType;
    private static System.Collections.Generic.List<SpinKingOutCome> outComesConfig;
    private static SpinKingSlotMachine.SpinKingSymbol[,] <ReelData>k__BackingField;
    private static SpinKingOutCome <SpinResult>k__BackingField;
    private static int middleRow;
    private static RandomSet spinRandomSet;
    private static System.Collections.Generic.List<SpinKingSlotMachine.SpinKingSymbol> allSymbolTypes;
    private static System.Collections.Generic.List<SpinKingSlotMachine.SpinKingSymbol> allNonCoinSymbolTypes;
    
    // Properties
    public static SpinKingSlotMachine.SpinKingSymbol[,] ReelData { get; set; }
    public static SpinKingOutCome SpinResult { get; set; }
    
    // Methods
    public static SpinKingSlotMachine.SpinKingSymbol[,] get_ReelData()
    {
        null = null;
        return (SpinKingSymbol[,])SpinKingSlotMachine.<ReelData>k__BackingField;
    }
    private static void set_ReelData(SpinKingSlotMachine.SpinKingSymbol[,] value)
    {
        null = null;
        SpinKingSlotMachine.<ReelData>k__BackingField = value;
    }
    public static SpinKingOutCome get_SpinResult()
    {
        null = null;
        return (SpinKingOutCome)SpinKingSlotMachine.<SpinResult>k__BackingField;
    }
    private static void set_SpinResult(SpinKingOutCome value)
    {
        null = null;
        SpinKingSlotMachine.<SpinResult>k__BackingField = value;
    }
    public static SpinKingSlotMachine.SpinKingSymbol GetRandomSymbol(SpinKingSlotMachine.SpinKingSymbol except = 0)
    {
        var val_2;
        do
        {
            val_2 = null;
            val_2 = null;
            int val_1 = UnityEngine.Random.Range(min:  0, max:  SpinKingSlotMachine.allSymbolTypes + 24);
            if((SpinKingSlotMachine.allSymbolTypes + 24) <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_2 = SpinKingSlotMachine.allSymbolTypes + 16;
            val_2 = val_2 + (val_1 << 2);
        }
        while(((SpinKingSlotMachine.allSymbolTypes + 16 + (val_1) << 2) + 32) == except);
        
        return (SpinKingSymbol)(SpinKingSlotMachine.allSymbolTypes + 16 + (val_1) << 2) + 32;
    }
    private static SpinKingSlotMachine.SpinKingSymbol GetNonCoinRandomSymbol(SpinKingSlotMachine.SpinKingSymbol except = 0)
    {
        var val_2;
        do
        {
            val_2 = null;
            val_2 = null;
            int val_1 = UnityEngine.Random.Range(min:  0, max:  SpinKingSlotMachine.allNonCoinSymbolTypes + 24);
            if((SpinKingSlotMachine.allNonCoinSymbolTypes + 24) <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_2 = SpinKingSlotMachine.allNonCoinSymbolTypes + 16;
            val_2 = val_2 + (val_1 << 2);
        }
        while(((SpinKingSlotMachine.allNonCoinSymbolTypes + 16 + (val_1) << 2) + 32) == except);
        
        return (SpinKingSymbol)(SpinKingSlotMachine.allNonCoinSymbolTypes + 16 + (val_1) << 2) + 32;
    }
    public static SpinKingOutCome CreateSpinOutCome()
    {
        SpinKingOutCome val_4;
        var val_23;
        var val_24;
        SpinKingSymbol[,] val_25;
        var val_26;
        var val_27;
        var val_28;
        var val_29;
        var val_31;
        var val_34;
        var val_35;
        var val_37;
        var val_38;
        var val_39;
        var val_50;
        var val_51;
        var val_52;
        var val_53;
        SpinKingSymbol val_54;
        bool val_56;
        var val_57;
        val_23 = null;
        val_23 = null;
        if((SpinKingSlotMachine.<ReelData>k__BackingField) == null)
        {
            goto label_13;
        }
        
        val_24 = null;
        val_24 = null;
        val_25 = SpinKingSlotMachine.<ReelData>k__BackingField;
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26 = 0;
        if(val_25.Length == 0)
        {
            goto label_13;
        }
        
        val_27 = null;
        goto label_14;
        label_13:
        val_26;
        val_27 = null;
        val_27 = null;
        SpinKingSlotMachine.<ReelData>k__BackingField = null;
        label_14:
        val_27 = null;
        val_25 = SpinKingSlotMachine.spinRandomSet;
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26 = 0;
        val_28 = null;
        if(val_25.remainingCount() != 0)
        {
            goto label_23;
        }
        
        val_28 = null;
        if(SpinKingSlotMachine.spinRandomSet == null)
        {
                throw new NullReferenceException();
        }
        
        val_29 = 0;
        SpinKingSlotMachine.spinRandomSet.replacement = true;
        goto label_27;
        label_37:
        if(SpinKingSlotMachine.outComesConfig == null)
        {
                throw new NullReferenceException();
        }
        
        if((SpinKingSlotMachine.outComesConfig + 24) <= val_29)
        {
                val_25 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_25 = SpinKingSlotMachine.outComesConfig + 16;
        val_25 = val_25 + 0;
        if(((SpinKingSlotMachine.outComesConfig + 16 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(SpinKingSlotMachine.spinRandomSet == null)
        {
                throw new NullReferenceException();
        }
        
        val_25 = SpinKingSlotMachine.spinRandomSet;
        val_26 = val_29;
        val_25.add(item:  0, weight:  (SpinKingSlotMachine.outComesConfig + 16 + 0) + 32 + 24);
        val_28 = null;
        val_29 = 1;
        label_27:
        val_28 = null;
        if(SpinKingSlotMachine.outComesConfig == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_29 < (SpinKingSlotMachine.outComesConfig + 24))
        {
            goto label_37;
        }
        
        label_23:
        val_31 = 0;
        if(SpinKingSlotMachine.hackSpinType == 0)
        {
            goto label_41;
        }
        
        val_25 = SpinKingSlotMachine.outComesConfig;
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_3 = val_25.GetEnumerator();
        goto label_49;
        label_55:
        val_34 = null;
        val_34 = null;
        if((val_4 + 16) == SpinKingSlotMachine.hackSpinType)
        {
                val_35 = null;
            val_35 = null;
            SpinKingSlotMachine.<SpinResult>k__BackingField = val_4;
        }
        
        label_49:
        if(MoveNext() == true)
        {
            goto label_55;
        }
        
        val_26 = public System.Void List.Enumerator<SpinKingOutCome>::Dispose();
        Dispose();
        goto label_282;
        label_41:
        val_25 = SpinKingSlotMachine.spinRandomSet;
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26 = 0;
        int val_6 = val_25.roll(unweighted:  false);
        if(SpinKingSlotMachine.outComesConfig == null)
        {
                throw new NullReferenceException();
        }
        
        if((SpinKingSlotMachine.outComesConfig + 24) <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_26 = SpinKingSlotMachine.outComesConfig + 16;
        val_26 = val_26 + (val_6 << 3);
        val_37 = null;
        val_37 = null;
        SpinKingSlotMachine.<SpinResult>k__BackingField = (SpinKingSlotMachine.outComesConfig + 16 + (val_6) << 3) + 32;
        label_282:
        var val_28 = 0;
        do
        {
            var val_27 = 0;
            do
        {
            val_38 = null;
            val_38 = null;
            if(null == null)
        {
                throw new NullReferenceException();
        }
        
            val_27 = val_27 + 1;
            mem2[0] = SpinKingSlotMachine.GetRandomSymbol(except:  0);
        }
        while(val_27 < 4);
        
            val_28 = val_28 + 1;
        }
        while(val_28 <= 1);
        
        val_39 = null;
        val_39 = null;
        if((SpinKingSlotMachine.<SpinResult>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        SpinKingSlotMachine.SpinType val_29 = (SpinKingSlotMachine.outComesConfig + 16 + (val_6) << 3) + 32.SType;
        val_29 = val_29 - 1;
        if(val_29 > 9)
        {
            goto label_81;
        }
        
        var val_30 = 32556032 + (((SpinKingSlotMachine.outComesConfig + 16 + (val_6) << 3) + 32.SType - 1)) << 2;
        val_30 = val_30 + 32556032;
        goto (32556032 + (((SpinKingSlotMachine.outComesConfig + 16 + (val_6) << 3) + 32.SType - 1)) << 2 + 32556032);
        label_81:
        val_50 = 0;
        goto label_211;
        label_232:
        val_51 = null;
        val_50 = 1;
        label_211:
        val_52 = null;
        val_52 = null;
        if(val_50 != 1)
        {
                val_53 = null;
            val_53 = null;
            if(null == null)
        {
                throw new NullReferenceException();
        }
        
            val_54 = mem[(SpinKingSlotMachine.<ReelData>k__BackingField + ((SpinKingSymbol[,].__il2cppRuntimeField_name + 16 * val_50) + SpinKingSlotMachine.middleRow) << 2) + 32];
        }
        else
        {
                val_54 = 0;
        }
        
        if(null == null)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = SpinKingSlotMachine.GetNonCoinRandomSymbol(except:  val_54);
        if((val_50 + 1) <= 1)
        {
            goto label_232;
        }
        
        var val_37 = 0;
        do
        {
            val_25 = null;
            val_25 = null;
            if(null == null)
        {
                throw new NullReferenceException();
        }
        
            var val_21 = val_37 + 1;
            val_26 = 3;
            int val_22 = UnityEngine.Random.Range(min:  0, max:  3);
            val_25 = null;
            val_56 = 1;
            if(val_56 == 0)
        {
                val_25 = null;
        }
        
            val_25 = null;
            if(null == null)
        {
                throw new NullReferenceException();
        }
        
            if(null == null)
        {
                throw new NullReferenceException();
        }
        
            mem2[0] = mem[(SpinKingSlotMachine.<ReelData>k__BackingField + ((SpinKingSymbol[,].__il2cppRuntimeField_name + 16 * (long)(int)(val_22)) + SpinKingSlotMachine.middleRow) << 2) + 32];
            val_25 = null;
            val_25 = null;
            if(null == null)
        {
                throw new NullReferenceException();
        }
        
            mem2[0] = mem[(SpinKingSlotMachine.<ReelData>k__BackingField + ((SpinKingSymbol[,].__il2cppRuntimeField_name + 16 * (0 + 1)) + SpinKingSlotMachine.middleRow) << 2) + 32];
            val_37 = val_37 + 1;
        }
        while(val_37 < 2);
        
        val_57 = null;
        val_57 = null;
        return (SpinKingOutCome)SpinKingSlotMachine.<SpinResult>k__BackingField;
    }
    public SpinKingSlotMachine()
    {
    
    }
    private static SpinKingSlotMachine()
    {
        SpinKingSlotMachine.hackSpinType = 0;
        System.Collections.Generic.List<SpinKingOutCome> val_1 = new System.Collections.Generic.List<SpinKingOutCome>();
        .SType = 0;
        .Weight = 10f;
        val_1.Add(item:  new SpinKingOutCome());
        .Weight = 20f;
        .SType = 1.06099789553204E-313;
        val_1.Add(item:  new SpinKingOutCome());
        .Weight = 8f;
        .SType = 2.12199579106409E-313;
        val_1.Add(item:  new SpinKingOutCome());
        .Weight = 3f;
        .SType = 4.24399158207876E-313;
        val_1.Add(item:  new SpinKingOutCome());
        .Weight = 20f;
        .SType = 4.24399158390681E-314;
        val_1.Add(item:  new SpinKingOutCome());
        .Weight = 10f;
        .SType = 6.36598737536615E-314;
        val_1.Add(item:  new SpinKingOutCome());
        .Weight = 4f;
        .SType = 8.48798316682548E-314;
        val_1.Add(item:  new SpinKingOutCome());
        .Weight = 10f;
        .SType = 3.18299368679375E-313;
        val_1.Add(item:  new SpinKingOutCome());
        .Weight = 3f;
        .SType = 2.1219957949178E-314;
        val_1.Add(item:  new SpinKingOutCome());
        .Weight = 1f;
        .SType = 2.12199579541186E-314;
        val_1.Add(item:  new SpinKingOutCome());
        SpinKingSlotMachine.outComesConfig = val_1;
        SpinKingSlotMachine.middleRow = 2;
        SpinKingSlotMachine.spinRandomSet = new RandomSet();
        System.Collections.Generic.List<SpinKingSymbol> val_13 = new System.Collections.Generic.List<SpinKingSymbol>();
        val_13.Add(item:  1);
        val_13.Add(item:  2);
        val_13.Add(item:  3);
        val_13.Add(item:  4);
        val_13.Add(item:  5);
        SpinKingSlotMachine.allSymbolTypes = val_13;
        System.Collections.Generic.List<SpinKingSymbol> val_14 = new System.Collections.Generic.List<SpinKingSymbol>();
        val_14.Add(item:  3);
        val_14.Add(item:  4);
        val_14.Add(item:  5);
        SpinKingSlotMachine.allNonCoinSymbolTypes = val_14;
    }

}
