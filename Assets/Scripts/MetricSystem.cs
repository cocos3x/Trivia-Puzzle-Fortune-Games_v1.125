using UnityEngine;
public static class MetricSystem
{
    // Fields
    private static string[] affix;
    private static string[] richTextAffix;
    private static string[] uncoloredAffix;
    private static string[] affixColor;
    
    // Methods
    public static string Abbreviate(decimal number, int maxSigFigs = 3, bool round = True, bool useColor = True, decimal maxValueWithoutAbbr, bool useRichText = False, bool withSpaces = False)
    {
        bool val_40;
        int val_41;
        var val_42;
        int val_43;
        int val_44;
        int val_45;
        var val_46;
        var val_47;
        int val_48;
        var val_49;
        var val_50;
        var val_51;
        string val_52;
        int val_53;
        var val_54;
        int val_55;
        var val_56;
        var val_57;
        var val_58;
        var val_59;
        bool val_60;
        int val_61;
        int val_62;
        var val_63;
        int val_64;
        var val_65;
        var val_66;
        System.String[] val_67;
        var val_68;
        var val_69;
        val_41 = maxValueWithoutAbbr.lo;
        val_42 = round;
        val_43 = maxSigFigs;
        val_44 = number.lo;
        val_45 = number.flags;
        val_46 = null;
        val_46 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_45, hi = number.hi, lo = val_44, mid = number.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_47 = "0";
            return (string)val_41 + (val_67 + (val_18) << 3) + 32((val_67 + (val_18) << 3) + 32).Replace(oldValue:  " ", newValue:  System.String.alignConst);
        }
        
        val_48 = val_41;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_45, hi = number.hi, lo = val_44, mid = number.mid}, d2:  new System.Decimal() {flags = maxValueWithoutAbbr.flags, hi = maxValueWithoutAbbr.hi, lo = val_48, mid = maxValueWithoutAbbr.mid})) != false)
        {
                string val_3 = number.flags.ToString(format:  "###");
            return (string)val_41 + (val_67 + (val_18) << 3) + 32((val_67 + (val_18) << 3) + 32).Replace(oldValue:  " ", newValue:  System.String.alignConst);
        }
        
        val_49 = 0;
        val_50 = 0;
        val_51 = 0;
        val_52 = "###.";
        goto label_9;
        label_16:
        decimal val_4 = new System.Decimal(value:  10);
        decimal val_5 = System.Decimal.op_Modulus(d1:  new System.Decimal() {flags = number.flags, hi = number.hi, lo = number.lo, mid = number.mid}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.flags, lo = val_4.lo, mid = val_4.lo});
        var val_7 = (val_49 == val_50) ? 1 : 0;
        val_7 = val_7 & (System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0}));
        val_49 = 1;
        val_50 = val_50 + val_7;
        decimal val_8 = new System.Decimal(value:  10);
        val_48 = val_8.lo;
        decimal val_9 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = number.flags, hi = number.hi, lo = number.lo, mid = number.mid}, d2:  new System.Decimal() {flags = val_8.flags, hi = val_8.flags, lo = val_48, mid = val_48});
        val_53 = val_9.flags;
        val_44 = val_9.lo;
        val_51 = -1;
        label_9:
        val_54 = null;
        val_54 = null;
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_53, hi = val_9.hi, lo = val_44, mid = val_9.mid}, d2:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0})) == true)
        {
            goto label_16;
        }
        
        bool val_11 = val_49 - val_50;
        val_57 = null;
        val_57 = null;
        val_58 = 1152921504620371968;
        var val_13 = val_49 - 1;
        val_13 = val_13 >> 32;
        int val_18 = System.Math.Max(val1:  System.Math.Min(val1:  val_13 + (val_13 >> 63), val2:  MetricSystem.affix.Length - 1), val2:  0);
        val_13 = val_18 - (val_18 << 2);
        val_59 = val_13 + val_49;
        if(val_42 == false)
        {
            goto label_22;
        }
        
        if(val_59 >= 1)
        {
                val_13 = val_13 + val_49;
            int val_20 = val_13 + 1;
            do
        {
            decimal val_21 = new System.Decimal(value:  10);
            decimal val_22 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, d2:  new System.Decimal() {flags = val_21.flags, hi = val_21.flags, lo = val_21.lo, mid = val_21.lo});
            val_20 = val_20 - 1;
            val_42 = val_22.flags;
        }
        while(val_20 > 1);
        
            bool val_23 = val_50 + val_51;
            var val_24 = (val_23 > (~val_43)) ? (val_23) : (!val_43);
            val_58 = 1152921504620371968;
            val_24 = (val_18 + (val_18 << 1)) - val_24;
            val_24 = val_24 - 1;
            val_56 = val_24 - val_49;
        }
        
        val_60 = useColor;
        if(val_56 >= 1)
        {
                var val_40 = val_56;
            do
        {
            val_40 = val_40 - 1;
            val_52 = val_52 + "#";
        }
        while(val_56 != 1);
        
        }
        
        val_61 = val_22.flags;
        val_43 = val_56 & (~(val_56 >> 31));
        decimal val_26 = System.Math.Round(d:  new System.Decimal() {flags = val_61, hi = val_22.hi, lo = val_22.lo, mid = val_22.mid}, decimals:  val_43);
        goto label_41;
        label_22:
        val_62 = val_26.flags;
        val_61 = val_26.lo;
        if((((val_11 > val_43) ? (val_43) : (val_11)) <= 0) && (val_59 < 1))
        {
                val_60 = useColor;
        }
        else
        {
                bool val_27 = val_50 - 1;
            val_27 = val_27 - val_49;
            val_60 = useColor;
            var val_29 = (-2) - ((val_27 > (~val_43)) ? (val_27) : (!val_43));
            do
        {
            decimal val_30 = new System.Decimal(value:  10);
            val_55 = val_30.lo;
            decimal val_31 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_62, hi = val_26.hi, lo = val_61, mid = val_26.mid}, d2:  new System.Decimal() {flags = val_30.flags, hi = val_30.flags, lo = val_55, mid = val_55});
            var val_32 = val_29 - 1;
            val_62 = val_31.flags;
            val_61 = val_31.lo;
            val_59 = val_59 - 1;
        }
        while((val_29 > 0) || (val_59 > 0));
        
        }
        
        decimal val_33 = System.Math.Truncate(d:  new System.Decimal() {flags = val_62, hi = val_31.hi, lo = val_61, mid = val_31.mid});
        if((val_59 & 2147483648) == 0)
        {
            goto label_41;
        }
        
        val_63 = val_59;
        val_63 = ~val_59;
        val_43 = val_33.flags;
        val_64 = val_33.lo;
        goto label_42;
        label_45:
        val_43 = val_33.flags;
        val_64 = val_33.lo;
        val_63 = val_63 - 1;
        label_42:
        decimal val_34 = new System.Decimal(value:  10);
        decimal val_35 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_43, hi = val_33.hi, lo = val_64, mid = val_33.mid}, d2:  new System.Decimal() {flags = val_34.flags, hi = val_34.flags, lo = val_34.lo, mid = val_34.lo});
        val_52 = val_52 + "#";
        if(val_63 != 0)
        {
            goto label_45;
        }
        
        label_41:
        val_40 = useRichText;
        val_41 = val_35.flags.ToString(format:  val_52);
        val_65 = null;
        if(val_60 == false)
        {
            goto label_46;
        }
        
        if(val_40 == false)
        {
            goto label_47;
        }
        
        val_66 = null;
        val_67 = MetricSystem.richTextAffix;
        if(val_67 != null)
        {
            goto label_54;
        }
        
        label_46:
        val_68 = null;
        val_67 = MetricSystem.uncoloredAffix;
        if(val_67 != null)
        {
            goto label_54;
        }
        
        label_47:
        val_69 = 1152921504893054976;
        val_67 = public static System.Int32 System.Array::IndexOf<Award>(T[] array, Award value, int startIndex, int count);
        label_54:
        val_67 = val_67 + (val_18 << 3);
        if(withSpaces == true)
        {
                return (string)val_41 + (val_67 + (val_18) << 3) + 32((val_67 + (val_18) << 3) + 32).Replace(oldValue:  " ", newValue:  System.String.alignConst);
        }
        
        return (string)val_41 + (val_67 + (val_18) << 3) + 32((val_67 + (val_18) << 3) + 32).Replace(oldValue:  " ", newValue:  System.String.alignConst);
    }
    public static UnityEngine.Color GetMetricColor(decimal number, int maxSigFigs = 3, bool round = True)
    {
        int val_12;
        int val_13;
        var val_14;
        int val_15;
        var val_16;
        var val_17;
        var val_18;
        val_12 = number.lo;
        val_13 = number.flags;
        val_14 = null;
        val_14 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_13, hi = number.hi, lo = val_12, mid = number.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return UnityEngine.Color.white;
        }
        
        val_16 = 0;
        goto label_4;
        label_11:
        decimal val_2 = new System.Decimal(value:  10);
        decimal val_3 = System.Decimal.op_Modulus(d1:  new System.Decimal() {flags = val_13, hi = number.hi, lo = val_12, mid = number.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        bool val_4 = System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        decimal val_5 = new System.Decimal(value:  10);
        val_15 = val_5.lo;
        decimal val_6 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_13, hi = number.hi, lo = val_12, mid = number.mid}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.flags, lo = val_15, mid = val_15});
        val_13 = val_6.flags;
        val_12 = val_6.lo;
        val_16 = 1;
        label_4:
        val_17 = null;
        val_17 = null;
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_13, hi = val_6.hi, lo = val_12, mid = val_6.mid}, d2:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0})) == true)
        {
            goto label_11;
        }
        
        val_18 = null;
        val_18 = null;
        System.String[] val_12 = MetricSystem.affixColor;
        val_12 = val_12 + ((System.Math.Max(val1:  System.Math.Min(val1:  0, val2:  MetricSystem.affix.Length - 1), val2:  0)) << 3);
        UnityEngine.Color val_11 = MetricSystem.HexToColor(hex:  (MetricSystem.affixColor + (val_10) << 3) + 32);
        return new UnityEngine.Color() {r = val_11.r, g = val_11.g, b = val_11.b, a = val_11.a};
    }
    public static UnityEngine.Color HexToColor(string hex)
    {
        UnityEngine.Color32 val_7 = new UnityEngine.Color32(r:  System.Byte.Parse(s:  hex.Substring(startIndex:  0, length:  2), style:  3), g:  System.Byte.Parse(s:  hex.Substring(startIndex:  2, length:  2), style:  3), b:  System.Byte.Parse(s:  hex.Substring(startIndex:  4, length:  2), style:  3), a:  255);
        UnityEngine.Color val_8 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_7.r, g = val_7.r, b = val_7.r, a = val_7.r});
        return new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a};
    }
    public static string ColorToHex(UnityEngine.Color32 color)
    {
        return (string)color.r.ToString(format:  "X2")(color.r.ToString(format:  "X2")) + color.g.ToString(format:  "X2")(color.g.ToString(format:  "X2")) + color.b.ToString(format:  "X2")(color.b.ToString(format:  "X2"));
    }
    private static MetricSystem()
    {
        int val_5;
        int val_6;
        int val_7;
        int val_8;
        string[] val_1 = new string[9];
        val_5 = val_1.Length;
        val_1[0] = "";
        val_5 = val_1.Length;
        val_1[1] = "[aca4f4] K[-]";
        val_5 = val_1.Length;
        val_1[2] = "[7bdaff] M[-]";
        val_5 = val_1.Length;
        val_1[3] = "[b6ffac] B[-]";
        val_5 = val_1.Length;
        val_1[4] = "[ebff43] T[-]";
        val_5 = val_1.Length;
        val_1[5] = "[ff9854] q[-]";
        val_5 = val_1.Length;
        val_1[6] = "[fe615e] Q[-]";
        val_5 = val_1.Length;
        val_1[7] = "[ff9cc7] s[-]";
        val_5 = val_1.Length;
        val_1[8] = "[c6c6c6] S[-]";
        MetricSystem.affix = val_1;
        string[] val_2 = new string[9];
        val_6 = val_2.Length;
        val_2[0] = "";
        val_6 = val_2.Length;
        val_2[1] = "<color=#aca4f4> K</color>";
        val_6 = val_2.Length;
        val_2[2] = "<color=#7bdaff> M</color>";
        val_6 = val_2.Length;
        val_2[3] = "<color=#b6ffac> B</color>";
        val_6 = val_2.Length;
        val_2[4] = "<color=#ebff43> T</color>";
        val_6 = val_2.Length;
        val_2[5] = "<color=#ff9854> q</color>";
        val_6 = val_2.Length;
        val_2[6] = "<color=#fe615e> Q</color>";
        val_6 = val_2.Length;
        val_2[7] = "<color=#ff9cc7> s</color>";
        val_6 = val_2.Length;
        val_2[8] = "<color=#c6c6c6> S</color>";
        MetricSystem.richTextAffix = val_2;
        string[] val_3 = new string[9];
        val_7 = val_3.Length;
        val_3[0] = "";
        val_7 = val_3.Length;
        val_3[1] = " K";
        val_7 = val_3.Length;
        val_3[2] = " M";
        val_7 = val_3.Length;
        val_3[3] = " B";
        val_7 = val_3.Length;
        val_3[4] = " T";
        val_7 = val_3.Length;
        val_3[5] = " q";
        val_7 = val_3.Length;
        val_3[6] = " Q";
        val_7 = val_3.Length;
        val_3[7] = " s";
        val_7 = val_3.Length;
        val_3[8] = " S";
        MetricSystem.uncoloredAffix = val_3;
        string[] val_4 = new string[9];
        val_8 = val_4.Length;
        val_4[0] = "000000";
        val_8 = val_4.Length;
        val_4[1] = "aca4f4";
        val_8 = val_4.Length;
        val_4[2] = "7bdaff";
        val_8 = val_4.Length;
        val_4[3] = "b6ffac";
        val_8 = val_4.Length;
        val_4[4] = "ebff43";
        val_8 = val_4.Length;
        val_4[5] = "ff9854";
        val_8 = val_4.Length;
        val_4[6] = "fe615e";
        val_8 = val_4.Length;
        val_4[7] = "ff9cc7";
        val_8 = val_4.Length;
        val_4[8] = "c6c6c6";
        MetricSystem.affixColor = val_4;
    }

}
