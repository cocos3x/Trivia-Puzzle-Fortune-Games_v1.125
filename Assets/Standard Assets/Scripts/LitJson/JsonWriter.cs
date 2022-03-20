using UnityEngine;

namespace LitJson
{
    public class JsonWriter
    {
        // Fields
        private static System.Globalization.NumberFormatInfo number_format;
        private LitJson.WriterContext context;
        private System.Collections.Generic.Stack<LitJson.WriterContext> ctx_stack;
        private bool has_reached_end;
        private char[] hex_seq;
        private int indentation;
        private int indent_value;
        private System.Text.StringBuilder inst_string_builder;
        private bool pretty_print;
        private bool validate;
        private System.IO.TextWriter writer;
        
        // Properties
        public int IndentValue { get; set; }
        public bool PrettyPrint { get; set; }
        public System.IO.TextWriter TextWriter { get; }
        public bool Validate { get; set; }
        
        // Methods
        public int get_IndentValue()
        {
            return (int)this.indent_value;
        }
        public void set_IndentValue(int value)
        {
            int val_1 = this.indentation;
            val_1 = val_1 / this.indent_value;
            val_1 = val_1 * value;
            this.indentation = val_1;
            this.indent_value = value;
        }
        public bool get_PrettyPrint()
        {
            return (bool)this.pretty_print;
        }
        public void set_PrettyPrint(bool value)
        {
            this.pretty_print = value;
        }
        public System.IO.TextWriter get_TextWriter()
        {
            return (System.IO.TextWriter)this.writer;
        }
        public bool get_Validate()
        {
            return (bool)this.validate;
        }
        public void set_Validate(bool value)
        {
            this.validate = value;
        }
        private static JsonWriter()
        {
            LitJson.JsonWriter.number_format = System.Globalization.NumberFormatInfo.InvariantInfo;
        }
        public JsonWriter()
        {
            System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
            this.inst_string_builder = val_1;
            this.writer = new System.IO.StringWriter(sb:  val_1);
            this.Init();
        }
        public JsonWriter(System.Text.StringBuilder sb)
        {
            System.IO.StringWriter val_1 = new System.IO.StringWriter(sb:  sb);
        }
        public JsonWriter(System.IO.TextWriter writer)
        {
            if(writer == null)
            {
                    throw new System.ArgumentNullException(paramName:  "writer");
            }
            
            this.writer = writer;
            this.Init();
        }
        private void DoValidation(LitJson.Condition cond)
        {
            string val_3;
            if(this.context.ExpectingValue != true)
            {
                    int val_2 = this.context.Count;
                val_2 = val_2 + 1;
                this.context.Count = val_2;
            }
            
            if(this.validate == false)
            {
                    return;
            }
            
            if(this.has_reached_end != true)
            {
                    if(cond > 4)
            {
                    return;
            }
            
                var val_3 = 32563048 + (cond) << 2;
                val_3 = val_3 + 32563048;
            }
            else
            {
                    val_3 = "A complete JSON symbol has already been written";
                 = new LitJson.JsonException(message:  null);
                throw null;
            }
        
        }
        private void Init()
        {
            this.has_reached_end = false;
            this.hex_seq = new char[4];
            this.pretty_print = true;
            this.validate = true;
            this.indentation = 0;
            this.indent_value = 4;
            this.ctx_stack = new System.Collections.Generic.Stack<LitJson.WriterContext>();
            LitJson.WriterContext val_3 = new LitJson.WriterContext();
            this.context = val_3;
            this.ctx_stack.Push(item:  val_3);
        }
        private static void IntToHex(int n, char[] hex)
        {
            var val_3;
            var val_5 = 0;
            do
            {
                char val_2 = (n < 0) ? (n + 15) : n;
                val_2 = val_2 & 4294967280;
                val_2 = n - val_2;
                var val_3 = 19 - 16;
                if(val_2 > 9)
            {
                    val_3 = 55;
            }
            else
            {
                    val_3 = 48;
            }
            
                val_2 = val_3 + val_2;
                val_5 = val_5 + 1;
                n = n >> 4;
                hex[0] = val_2;
                var val_4 = 19 - 1;
            }
            while(val_5 < 3);
        
        }
        private void Indent()
        {
            if(this.pretty_print == false)
            {
                    return;
            }
            
            int val_1 = this.indentation;
            val_1 = this.indent_value + val_1;
            this.indentation = val_1;
        }
        private void Put(string str)
        {
            if(((this.pretty_print != false) && (this.context.ExpectingValue != true)) && (this.indentation >= 1))
            {
                    var val_1 = 0;
                do
            {
                val_1 = val_1 + 1;
            }
            while(val_1 < this.indentation);
            
            }
        
        }
        private void PutNewline()
        {
            this.PutNewline(add_comma:  true);
        }
        private void PutNewline(bool add_comma)
        {
            if(this.pretty_print == false)
            {
                    return;
            }
            
            if(this.context.ExpectingValue == false)
            {
                goto typeof(System.IO.TextWriter).__il2cppRuntimeField_1E0;
            }
        
        }
        private void PutString(string str)
        {
            var val_11;
            this.Put(str:  System.String.alignConst);
            if(str.m_stringLength < 1)
            {
                goto typeof(System.IO.TextWriter).__il2cppRuntimeField_1E0;
            }
            
            label_26:
            char val_2 = str.Chars[0] & 65535;
            if((val_2 - 8) > '')
            {
                goto label_4;
            }
            
            var val_11 = 32563068 + (((val_1 & 65535) - 8)) << 2;
            val_11 = val_11 + 32563068;
            goto (32563068 + (((val_1 & 65535) - 8)) << 2 + 32563068);
            label_4:
            if(val_2 != '"')
            {
                    if(val_2 != '\')
            {
                goto label_8;
            }
            
            }
            
            label_13:
            char val_4 = str.Chars[0];
            goto label_11;
            label_8:
            if((str.Chars[0] & 65535) >= ' ')
            {
                    if((str.Chars[0] & 65535) <= ('~'))
            {
                goto label_13;
            }
            
            }
            
            LitJson.JsonWriter.IntToHex(n:  str.Chars[0] & 65535, hex:  this.hex_seq);
            label_11:
            val_11 = 0 + 1;
            if(val_11 < str.m_stringLength)
            {
                goto label_26;
            }
            
            goto typeof(System.IO.TextWriter).__il2cppRuntimeField_1E0;
        }
        private void Unindent()
        {
            if(this.pretty_print == false)
            {
                    return;
            }
            
            int val_1 = this.indentation;
            val_1 = val_1 - this.indent_value;
            this.indentation = val_1;
        }
        public override string ToString()
        {
            if(this.inst_string_builder == null)
            {
                    return (string)System.String.alignConst;
            }
            
            this = ???;
            goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
        }
        public void Reset()
        {
            this.has_reached_end = false;
            this.ctx_stack.Clear();
            LitJson.WriterContext val_1 = new LitJson.WriterContext();
            this.context = val_1;
            this.ctx_stack.Push(item:  val_1);
            if(this.inst_string_builder == null)
            {
                    return;
            }
            
            System.Text.StringBuilder val_3 = this.inst_string_builder.Remove(startIndex:  0, length:  this.inst_string_builder.Length);
        }
        public void Write(bool boolean)
        {
            this.DoValidation(cond:  4);
            this.PutNewline(add_comma:  true);
            this.Put(str:  (boolean != true) ? "true" : "false");
            this.context.ExpectingValue = false;
        }
        public void Write(decimal number)
        {
            var val_2;
            this.DoValidation(cond:  4);
            this.PutNewline(add_comma:  true);
            val_2 = null;
            val_2 = null;
            this.Put(str:  System.Convert.ToString(value:  new System.Decimal() {flags = number.flags, hi = number.hi, lo = number.lo, mid = number.mid}, provider:  LitJson.JsonWriter.number_format));
            this.context.ExpectingValue = false;
        }
        public void Write(double number)
        {
            var val_4;
            this.DoValidation(cond:  4);
            this.PutNewline(add_comma:  true);
            val_4 = null;
            val_4 = null;
            string val_1 = System.Convert.ToString(value:  number, provider:  LitJson.JsonWriter.number_format);
            this.Put(str:  val_1);
            if((val_1.IndexOf(value:  '.')) == 1)
            {
                    int val_3 = val_1.IndexOf(value:  'E');
            }
            
            this.context.ExpectingValue = false;
        }
        public void Write(int number)
        {
            var val_2;
            this.DoValidation(cond:  4);
            this.PutNewline(add_comma:  true);
            val_2 = null;
            val_2 = null;
            this.Put(str:  System.Convert.ToString(value:  number, provider:  LitJson.JsonWriter.number_format));
            this.context.ExpectingValue = false;
        }
        public void Write(long number)
        {
            var val_2;
            this.DoValidation(cond:  4);
            this.PutNewline(add_comma:  true);
            val_2 = null;
            val_2 = null;
            this.Put(str:  System.Convert.ToString(value:  number, provider:  LitJson.JsonWriter.number_format));
            this.context.ExpectingValue = false;
        }
        public void Write(string str)
        {
            this.DoValidation(cond:  4);
            this.PutNewline(add_comma:  true);
            if(str != null)
            {
                    this.PutString(str:  str);
            }
            else
            {
                    this.Put(str:  "null");
            }
            
            this.context.ExpectingValue = false;
        }
        public void Write(ulong number)
        {
            var val_2;
            this.DoValidation(cond:  4);
            this.PutNewline(add_comma:  true);
            val_2 = null;
            val_2 = null;
            this.Put(str:  System.Convert.ToString(value:  number, provider:  LitJson.JsonWriter.number_format));
            this.context.ExpectingValue = false;
        }
        public void WriteArrayEnd()
        {
            this.DoValidation(cond:  0);
            this.PutNewline(add_comma:  false);
            LitJson.WriterContext val_1 = this.ctx_stack.Pop();
            if(1152921513361590736 == 1)
            {
                    this.has_reached_end = 1152921513361590736;
            }
            else
            {
                    this.context = this.ctx_stack.Peek();
                val_2.ExpectingValue = false;
            }
            
            if(this.pretty_print != false)
            {
                    int val_3 = this.indentation;
                val_3 = val_3 - this.indent_value;
                this.indentation = val_3;
            }
            
            this.Put(str:  "]");
        }
        public void WriteArrayStart()
        {
            this.DoValidation(cond:  2);
            this.PutNewline(add_comma:  true);
            this.Put(str:  "[");
            this.context = new LitJson.WriterContext();
            .InArray = true;
            this.ctx_stack.Push(item:  this.context);
            if(this.pretty_print == false)
            {
                    return;
            }
            
            int val_2 = this.indentation;
            val_2 = this.indent_value + val_2;
            this.indentation = val_2;
        }
        public void WriteObjectEnd()
        {
            this.DoValidation(cond:  1);
            this.PutNewline(add_comma:  false);
            LitJson.WriterContext val_1 = this.ctx_stack.Pop();
            if(1152921513361590736 == 1)
            {
                    this.has_reached_end = 1152921513361590736;
            }
            else
            {
                    this.context = this.ctx_stack.Peek();
                val_2.ExpectingValue = false;
            }
            
            if(this.pretty_print != false)
            {
                    int val_3 = this.indentation;
                val_3 = val_3 - this.indent_value;
                this.indentation = val_3;
            }
            
            this.Put(str:  "}");
        }
        public void WriteObjectStart()
        {
            this.DoValidation(cond:  2);
            this.PutNewline(add_comma:  true);
            this.Put(str:  "{");
            this.context = new LitJson.WriterContext();
            .InObject = true;
            this.ctx_stack.Push(item:  this.context);
            if(this.pretty_print == false)
            {
                    return;
            }
            
            int val_2 = this.indentation;
            val_2 = this.indent_value + val_2;
            this.indentation = val_2;
        }
        public void WritePropertyName(string property_name)
        {
            LitJson.WriterContext val_2;
            LitJson.WriterContext val_3;
            System.IO.TextWriter val_4;
            this.DoValidation(cond:  3);
            this.PutNewline(add_comma:  true);
            this.PutString(str:  property_name);
            if(this.pretty_print != false)
            {
                    val_2 = this;
                val_3 = this.context;
                if(property_name.m_stringLength > this.context.Padding)
            {
                    this.context.Padding = property_name.m_stringLength;
                val_3 = val_3;
            }
            
                val_4 = this.writer;
                int val_2 = this.context.Padding;
                val_2 = val_2 + 1;
                int val_1 = val_2 - property_name.m_stringLength;
                do
            {
                val_1 = val_1 - 1;
                if(property_name.m_stringLength < 0)
            {
                goto label_9;
            }
            
                val_4 = this.writer;
            }
            while(val_4 != null);
            
                throw new NullReferenceException();
            }
            
            val_2 = this.context;
            label_9:
            mem2[0] = 1;
        }
    
    }

}
