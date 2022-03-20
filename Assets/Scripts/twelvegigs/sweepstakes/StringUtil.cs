using UnityEngine;

namespace twelvegigs.sweepstakes
{
    public static class StringUtil
    {
        // Methods
        public static string ReverseString(string s)
        {
            System.Char[] val_1 = s.ToCharArray();
            System.Array.Reverse(array:  val_1);
            return 0.CreateString(val:  val_1);
        }
        public static byte[] StringToByteArray(string text)
        {
            return new System.Text.UTF8Encoding().GetBytes(s:  text);
        }
        public static string ByteArrayToString(byte[] bytes)
        {
            return new System.Text.UTF8Encoding().GetString(bytes:  bytes);
        }
        public static bool IsJson(string input)
        {
            var val_5;
            string val_1 = input.Trim();
            if((val_1.StartsWith(value:  "{")) != false)
            {
                    if((val_1.EndsWith(value:  "}")) != false)
            {
                    val_5 = 1;
                return (bool)val_5;
            }
            
            }
            
            if((val_1.StartsWith(value:  "[")) != false)
            {
                    return val_1.EndsWith(value:  "]");
            }
            
            val_5 = 0;
            return (bool)val_5;
        }
        public static bool IsJson(byte[] bytes)
        {
            return twelvegigs.sweepstakes.StringUtil.IsJson(input:  twelvegigs.sweepstakes.StringUtil.ByteArrayToString(bytes:  bytes));
        }
        public static bool IsPlist(string input)
        {
            string val_1 = input.Trim();
            if((val_1.StartsWith(value:  "<?xml")) == false)
            {
                    return false;
            }
            
            return val_1.EndsWith(value:  "</plist>");
        }
        public static bool IsPlist(byte[] bytes)
        {
            return twelvegigs.sweepstakes.StringUtil.IsPlist(input:  twelvegigs.sweepstakes.StringUtil.ByteArrayToString(bytes:  bytes));
        }
        public static string UpperFirst(string input)
        {
            return (string)System.Char.ToUpper(c:  input.Chars[0]).ToString()(System.Char.ToUpper(c:  input.Chars[0]).ToString()) + input.Substring(startIndex:  1)(input.Substring(startIndex:  1));
        }
        public static string LowerFirst(string input)
        {
            return (string)System.Char.ToLower(c:  input.Chars[0]).ToString()(System.Char.ToLower(c:  input.Chars[0]).ToString()) + input.Substring(startIndex:  1)(input.Substring(startIndex:  1));
        }
        public static string ToCamelCase(string input)
        {
            return twelvegigs.sweepstakes.StringUtil.ToCamelCase(input:  input, capitalized:  false);
        }
        public static string ToCamelCase(string input, bool capitalized)
        {
            int val_6;
            var val_7;
            char val_8;
            val_6 = System.String.alignConst;
            if(input.m_stringLength < 1)
            {
                    return (string)val_6;
            }
            
            var val_6 = 0;
            do
            {
                char val_1 = input.Chars[0];
                char val_2 = val_1 & 65535;
                val_7 = 1;
                if((val_2 != ('-')) && (val_2 != '_'))
            {
                    val_8 = val_1;
                if(capitalized != false)
            {
                    val_8 = System.Char.ToUpper(c:  val_8);
            }
            
                val_6 = val_6 + val_8.ToString();
                val_7 = 0;
            }
            
                val_6 = val_6 + 1;
            }
            while(val_6 < input.m_stringLength);
            
            return (string)val_6;
        }
        public static string ToDashed(string input)
        {
            return twelvegigs.sweepstakes.StringUtil.SplitCamelCase(input:  input, separator:  "-");
        }
        public static string ToUnderscore(string input)
        {
            return twelvegigs.sweepstakes.StringUtil.SplitCamelCase(input:  input, separator:  "_");
        }
        private static string SplitCamelCase(string input, string separator)
        {
            int val_8;
            var val_9;
            char val_10;
            string val_11;
            var val_12;
            var val_13;
            val_8 = System.String.alignConst;
            if(input.m_stringLength < 1)
            {
                    return (string)val_8.ToLower();
            }
            
            var val_9 = 0;
            val_9 = 0;
            do
            {
                char val_1 = input.Chars[0];
                val_10 = val_1;
                if((System.Char.IsLetterOrDigit(c:  val_10)) != false)
            {
                    bool val_3 = System.Char.IsUpper(c:  val_1);
                val_10 = val_3;
                if(val_3 != false)
            {
                    val_9 = val_9 | 0 ^ 1;
            }
            
                if((val_9 != 0) && ((val_9 & 1) != 0))
            {
                    val_11 = val_8 + separator;
            }
            
                val_12 = val_11 + val_1.ToString();
                val_13 = 0;
            }
            else
            {
                    val_13 = 1;
            }
            
                val_9 = val_9 + 1;
            }
            while(val_9 < input.m_stringLength);
            
            return (string)val_8.ToLower();
        }
        public static bool IsDigitsOnly(string str)
        {
            var val_3;
            if(str.m_stringLength < 1)
            {
                goto label_1;
            }
            
            var val_3 = 0;
            label_3:
            char val_2 = str.Chars[0] - 48;
            val_2 = val_2 & 65535;
            if(val_2 >= '
            ')
            {
                goto label_2;
            }
            
            val_3 = val_3 + 1;
            if(val_3 < str.m_stringLength)
            {
                goto label_3;
            }
            
            label_1:
            val_3 = 1;
            return (bool)val_3;
            label_2:
            val_3 = 0;
            return (bool)val_3;
        }
    
    }

}
