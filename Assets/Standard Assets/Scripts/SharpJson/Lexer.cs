using UnityEngine;

namespace SharpJson
{
    internal class Lexer
    {
        // Fields
        private int <lineNumber>k__BackingField;
        private bool <parseNumbersAsFloat>k__BackingField;
        private char[] json;
        private int index;
        private bool success;
        private char[] stringBuffer;
        
        // Properties
        public bool hasError { get; }
        public int lineNumber { get; set; }
        public bool parseNumbersAsFloat { get; set; }
        
        // Methods
        public bool get_hasError()
        {
            return (bool)(this.success == false) ? 1 : 0;
        }
        public int get_lineNumber()
        {
            return (int)this.<lineNumber>k__BackingField;
        }
        private void set_lineNumber(int value)
        {
            this.<lineNumber>k__BackingField = value;
        }
        public bool get_parseNumbersAsFloat()
        {
            return (bool)this.<parseNumbersAsFloat>k__BackingField;
        }
        public void set_parseNumbersAsFloat(bool value)
        {
            this.<parseNumbersAsFloat>k__BackingField = value;
        }
        public Lexer(string text)
        {
            this.success = true;
            this.stringBuffer = new char[4096];
            this.index = 0;
            this.<lineNumber>k__BackingField = true;
            this.success = true;
            this.json = text.ToCharArray();
            this.<parseNumbersAsFloat>k__BackingField = false;
        }
        public void Reset()
        {
            this.index = 0;
            this.<lineNumber>k__BackingField = 1;
            this.success = 1;
        }
        public string ParseString()
        {
            var val_20;
            this.SkipWhiteSpaces();
            this.index = this.index + 1;
            goto label_3;
            label_58:
            System.Text.StringBuilder val_2 = 0.Append(value:  this.stringBuffer, startIndex:  0, charCount:  W21);
            label_3:
            val_20 = 0;
            goto label_56;
            label_51:
            if(this.json.Length == W11)
            {
                goto label_49;
            }
            
            this.index = this.index + 2;
            char val_20 = this.stringBuffer[this.json.Length << 1];
            if(val_20 > '\')
            {
                goto label_7;
            }
            
            if(val_20 == '"')
            {
                goto label_8;
            }
            
            if(val_20 == ('/'))
            {
                goto label_9;
            }
            
            if(val_20 != '\')
            {
                goto label_46;
            }
            
            val_20 = 1;
            this.stringBuffer[0] = '\';
            goto label_46;
            label_7:
            if(val_20 > 'f')
            {
                goto label_14;
            }
            
            if(val_20 == 'b')
            {
                goto label_15;
            }
            
            if(val_20 != 'f')
            {
                goto label_46;
            }
            
            val_20 = 1;
            this.stringBuffer[0] = 12;
            goto label_46;
            label_14:
            val_20 = val_20 - 110;
            if(val_20 > '')
            {
                goto label_46;
            }
            
            var val_21 = 32576312 + ((this.stringBuffer[(this.json.Length) << 1][0] - 110)) << 2;
            val_21 = val_21 + 32576312;
            goto (32576312 + ((this.stringBuffer[(this.json.Length) << 1][0] - 110)) << 2 + 32576312);
            label_9:
            val_20 = 1;
            this.stringBuffer[0] = '/';
            goto label_46;
            label_8:
            val_20 = 1;
            this.stringBuffer[0] = '"';
            goto label_46;
            label_15:
            val_20 = 1;
            this.stringBuffer[0] = 8;
            goto label_46;
            label_56:
            if(((0 & 1) != 0) || (this.index == this.json.Length))
            {
                goto label_49;
            }
            
            this.index = this.index + 1;
            char val_23 = this.json[(this.index) << 1];
            if(val_23 == '\')
            {
                goto label_51;
            }
            
            if(val_23 == '"')
            {
                goto label_52;
            }
            
            val_20 = val_20 + 1;
            this.stringBuffer[0] = val_23;
            label_46:
            if(val_20 < this.stringBuffer.Length)
            {
                goto label_56;
            }
            
            if((0 != 0) || (new System.Text.StringBuilder() != null))
            {
                goto label_58;
            }
            
            throw new NullReferenceException();
            label_49:
            this.success = false;
            return 0;
            label_52:
            if(0 == 0)
            {
                    return 0.CreateString(val:  ??? + 40, startIndex:  0, length:  ???);
            }
            
            goto mem[282584257677023];
        }
        private string GetNumberString()
        {
            this.SkipWhiteSpaces();
            int val_2 = (this.GetLastIndexOfNumber(index:  this.index)) + 1;
            this.index = val_2;
            return (string)0.CreateString(val:  this.json, startIndex:  this.index, length:  val_2 - this.index);
        }
        public float ParseFloatNumber()
        {
            return (float)((System.Single.TryParse(s:  this.GetNumberString(), style:  167, provider:  System.Globalization.CultureInfo.InvariantCulture, result: out  float val_3 = 1.430733E+19f)) != true) ? 0 : 0f;
        }
        public double ParseDoubleNumber()
        {
            return (double)((System.Double.TryParse(s:  this.GetNumberString(), style:  511, provider:  System.Globalization.CultureInfo.InvariantCulture, result: out  double val_3 = 1.28823143973823E-231)) != true) ? 0 : 0;
        }
        private int GetLastIndexOfNumber(int index)
        {
            var val_3;
            val_3 = (long)index;
            if((long)this.json.Length <= (index << ))
            {
                    return (int)val_3 - 1;
            }
            
            do
            {
                char val_3 = this.json[((long)(int)(index)) << 1];
                if((val_3 - 48) >= '
            ')
            {
                    val_3 = val_3 - 43;
                if(val_3 > (':'))
            {
                    return (int)val_3 - 1;
            }
            
                val_3 = 1 << val_3;
                if((val_3 & '') != 0)
            {
                    return (int)val_3 - 1;
            }
            
            }
            
                val_3 = val_3 + 1;
            }
            while(val_3 < (long)this.json.Length);
            
            return (int)val_3 - 1;
        }
        private void SkipWhiteSpaces()
        {
            int val_2;
            do
            {
                val_2 = this.json.Length;
                if(this.index >= val_2)
            {
                    return;
            }
            
                if((this.json[this.index << 1]) == '
            ')
            {
                    int val_3 = this.<lineNumber>k__BackingField;
                val_3 = val_3 + 1;
                this.<lineNumber>k__BackingField = val_3;
                val_2 = this.json.Length;
            }
            
                if((System.Char.IsWhiteSpace(c:  this.json[(this.index) << 1] + 32)) == false)
            {
                    return;
            }
            
                int val_4 = this.index;
                val_4 = val_4 + 1;
                this.index = val_4;
            }
            while(this.json != null);
            
            throw new NullReferenceException();
        }
        public SharpJson.Lexer.Token LookAhead()
        {
            this.SkipWhiteSpaces();
            return (Token)SharpJson.Lexer.NextToken(json:  this.json, index: ref  this.index);
        }
        public SharpJson.Lexer.Token NextToken()
        {
            this.SkipWhiteSpaces();
            return SharpJson.Lexer.NextToken(json:  this.json, index: ref  this.index);
        }
        private static SharpJson.Lexer.Token NextToken(char[] json, ref int index)
        {
            var val_14;
            if(index != json.Length)
            {
                goto label_1;
            }
            
            label_44:
            val_14 = 0;
            return (Token);
            label_1:
            int val_1 = index + 1;
            index = val_1;
            char val_14 = json[((long)(int)(index)) << 1];
            if(val_14 > '[')
            {
                goto label_4;
            }
            
            if((val_14 - 34) > '')
            {
                goto label_5;
            }
            
            var val_15 = 32576344 + ((json[((long)(int)(index)) << 1][0] - 34)) << 2;
            val_15 = val_15 + 32576344;
            goto (32576344 + ((json[((long)(int)(index)) << 1][0] - 34)) << 2 + 32576344);
            label_4:
            if(val_14 == ']')
            {
                goto label_7;
            }
            
            if(val_14 == '{')
            {
                goto label_8;
            }
            
            if(val_14 != '}')
            {
                goto label_13;
            }
            
            val_14 = 9;
            return (Token);
            label_8:
            val_14 = 8;
            return (Token);
            label_7:
            val_14 = 11;
            return (Token);
            label_5:
            if(val_14 == '[')
            {
                    val_14 = 10;
                return (Token);
            }
            
            label_13:
            index = index;
            int val_3 = json.Length - index;
            if(val_3 >= 5)
            {
                goto label_15;
            }
            
            if(val_3 != 4)
            {
                goto label_44;
            }
            
            goto label_27;
            label_15:
            if((json[((long)(int)(index)) << 1] + 32) == 102)
            {
                    if((json[val_1 << 1]) == 'a')
            {
                    if((json[(index + 2) << 1]) == 'l')
            {
                    if((json[(index + 3) << 1]) == 's')
            {
                    if((json[(index + 4) << 1]) == 'e')
            {
                    index = index + 5;
                val_14 = 3;
                return (Token);
            }
            
            }
            
            }
            
            }
            
            }
            
            label_27:
            if((json[((long)(int)(index)) << 1] + 32) == 110)
            {
                goto label_30;
            }
            
            if((json[((long)(int)(index)) << 1] + 32) != 116)
            {
                goto label_44;
            }
            
            if((json[val_1 << 1]) != 'r')
            {
                goto label_44;
            }
            
            if((json[(index + 2) << 1]) != 'u')
            {
                goto label_44;
            }
            
            if((json[(index + 3) << 1]) != 'e')
            {
                goto label_44;
            }
            
            index = index + 4;
            val_14 = 2;
            return (Token);
            label_30:
            if((json[val_1 << 1]) != 'u')
            {
                goto label_44;
            }
            
            if((json[(index + 2) << 1]) != 'l')
            {
                goto label_44;
            }
            
            if((json[(index + 3) << 1]) != 'l')
            {
                goto label_44;
            }
            
            index = index + 4;
            val_14 = 1;
            return (Token);
        }
    
    }

}
