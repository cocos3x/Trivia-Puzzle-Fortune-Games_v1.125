using UnityEngine;

namespace Base36Library
{
    public static class Base36
    {
        // Fields
        private const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Min = "-1Y2P0IJ32E8E8";
        private const string Max = "1Y2P0IJ32E8E7";
        
        // Methods
        public static bool WouldOverflow(string value)
        {
            var val_3;
            if(((Base36Library.Base36._Compare(valueA:  "-1Y2P0IJ32E8E8", valueB:  value)) & 2147483648) == 0)
            {
                    val_3 = (Base36Library.Base36._Compare(valueA:  value, valueB:  "1Y2P0IJ32E8E7")) >> 31;
                return (bool)val_3;
            }
            
            val_3 = 1;
            return (bool)val_3;
        }
        public static int Compare(string valueA, string valueB)
        {
            return Base36Library.Base36._Compare(valueA:  Base36Library.Base36.Sanitize(value:  valueA), valueB:  Base36Library.Base36.Sanitize(value:  valueB));
        }
        public static long Decode(string value)
        {
            var val_10;
            string val_1 = Base36Library.Base36.Sanitize(value:  value);
            Base36Library.Base36.CheckOverflow(value:  val_1);
            if(val_3.m_stringLength >= 1)
            {
                    var val_10 = 0;
                var val_11 = 0;
                do
            {
                double val_7 = System.Math.Pow(x:  (double)"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".__il2cppRuntimeField_10, y:  (double)val_11 + val_3.m_stringLength);
                val_7 = (val_7 == Infinity) ? (-val_7) : (val_7);
                val_10 = val_10 + 1;
                val_10 = 0 + ((long)val_7 * ((long)IndexOf(value:  Base36Library.Base36.Abs(value:  val_1).Chars[0])));
                val_11 = val_11 - 1;
            }
            while(val_10 < val_3.m_stringLength);
            
                return (long)((val_1.Chars[0] & 65535) == ('-')) ? (-val_10) : (val_10);
            }
            
            val_10 = 0;
            return (long)((val_1.Chars[0] & 65535) == ('-')) ? (-val_10) : (val_10);
        }
        public static string Encode(long value)
        {
            string val_8;
            if(value == (-9223372036854775808))
            {
                    val_8 = "-1Y2P0IJ32E8E8";
                return (string)val_8;
            }
            
            var val_1 = (value < 0) ? (-value) : value;
            val_8 = Chars[value < 0 ?  (-value) : value - ((value < 0 ?  (-value) : value / "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".__il2cppRuntimeField_10) * "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".__il2cppRuntimeField_10)>>0&0xFFFFFFFF].ToString()(Chars[value < 0 ?  (-value) : value - ((value < 0 ?  (-value) : value / "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".__il2cppRuntimeField_10) * "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".__il2cppRuntimeField_10)>>0&0xFFFFFFFF].ToString()) + System.String.alignConst;
            if((value & 9223372036854775808) == 0)
            {
                    return (string)val_8;
            }
            
            val_8 = "-"("-") + val_8;
            return (string)val_8;
        }
        private static string Abs(string value)
        {
            if((value.Chars[0] & 65535) != ('-'))
            {
                    return (string)value;
            }
            
            return value.Substring(startIndex:  1, length:  value.m_stringLength - 1);
        }
        private static void CheckOverflow(string value)
        {
            string val_8;
            if(((Base36Library.Base36._Compare(valueA:  "-1Y2P0IJ32E8E8", valueB:  value)) & 2147483648) != 0)
            {
                goto label_1;
            }
            
            if(((Base36Library.Base36._Compare(valueA:  value, valueB:  "1Y2P0IJ32E8E7")) & 2147483648) != 0)
            {
                goto label_2;
            }
            
            return;
            label_1:
            System.Globalization.CultureInfo val_3 = System.Globalization.CultureInfo.InvariantCulture;
            val_8 = "Value \"{0}\" would overflow since it\'s less than long.MinValue.";
            throw new System.ArgumentException(message:  System.String.Format(provider:  System.Globalization.CultureInfo.InvariantCulture, format:  val_8 = "Value \"{0}\" would overflow since it\'s greater than long.MaxValue.", arg0:  value));
            label_2:
            throw new System.ArgumentException(message:  System.String.Format(provider:  System.Globalization.CultureInfo.InvariantCulture, format:  val_8, arg0:  value));
        }
        private static string Sanitize(string value)
        {
            object val_12;
            var val_13;
            System.Func<System.Char, System.Boolean> val_15;
            if(value == null)
            {
                goto label_1;
            }
            
            if((System.String.IsNullOrEmpty(value:  value)) == true)
            {
                goto label_2;
            }
            
            string val_3 = value.Trim().ToUpperInvariant();
            val_12 = val_3;
            val_13 = null;
            val_13 = null;
            val_15 = Base36.<>c.<>9__9_0;
            if(val_15 == null)
            {
                    System.Func<System.Char, System.Boolean> val_5 = null;
                val_15 = val_5;
                val_5 = new System.Func<System.Char, System.Boolean>(object:  Base36.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean Base36.<>c::<Sanitize>b__9_0(char c));
                Base36.<>c.<>9__9_0 = val_15;
            }
            
            if((System.Linq.Enumerable.Any<System.Char>(source:  Base36Library.Base36.Abs(value:  val_3), predicate:  val_5)) == true)
            {
                    throw new System.ArgumentException(message:  System.String.Format(provider:  System.Globalization.CultureInfo.InvariantCulture, format:  "Invalid value: \"{0}\".", arg0:  System.ArgumentException val_8 = null));
            }
            
            return (string)val_12;
            label_1:
            System.ArgumentNullException val_7 = null;
            val_12 = val_7;
            val_7 = new System.ArgumentNullException(message:  "An null string was passed.", innerException:  0);
            throw val_12 = val_8;
            label_2:
            val_8 = new System.ArgumentException(message:  "An empty string was passed.");
            throw val_12;
        }
        private static int _Compare(string valueA, string valueB)
        {
            var val_21;
            string val_22;
            var val_23;
            var val_24;
            val_22 = valueA;
            if((System.String.op_Equality(a:  val_22, b:  valueB)) != false)
            {
                    val_23 = 0;
                return (int)val_23;
            }
            
            var val_4 = ((val_22.Chars[0] & 65535) == ('-')) ? 1 : 0;
            char val_6 = valueB.Chars[0] & 65535;
            var val_7 = (val_6 == ('-')) ? 1 : 0;
            var val_8 = val_4 & val_7;
            val_7 = val_4 ^ val_8;
            if((val_7 & 1) != 0)
            {
                    val_23 = 1;
                return (int)val_23;
            }
            
            var val_9 = (val_6 == ('-')) ? 1 : 0;
            val_9 = val_9 ^ val_8;
            if((val_9 & 1) != 0)
            {
                    val_23 = 0;
                return (int)val_23;
            }
            
            val_22 = Base36Library.Base36.Abs(value:  val_22);
            if(val_10.m_stringLength >= val_11.m_stringLength)
            {
                goto label_11;
            }
            
            val_24 = 0;
            goto label_12;
            label_11:
            if(val_10.m_stringLength <= val_11.m_stringLength)
            {
                goto label_13;
            }
            
            val_24 = 1;
            label_12:
            var val_12 = (val_8 == 0) ? (-val_24) : (val_24);
            return (int)val_23;
            label_13:
            if(val_10.m_stringLength < 1)
            {
                goto label_15;
            }
            
            val_21 = 0;
            label_19:
            if((IndexOf(value:  val_22.Chars[0])) != (IndexOf(value:  Base36Library.Base36.Abs(value:  valueB).Chars[0])))
            {
                goto label_18;
            }
            
            val_21 = val_21 + 1;
            if(val_21 < val_10.m_stringLength)
            {
                goto label_19;
            }
            
            label_15:
            System.Exception val_17 = null;
            val_22 = val_17;
            val_17 = new System.Exception(message:  "Logic error in the library, please contact the library author.");
            throw val_22;
            label_18:
            val_23 = ((val_21 >= val_10.m_stringLength) ? (-1) : 1) * ((val_8 == 0) ? (-0) : 0);
            return (int)val_23;
        }
    
    }

}
