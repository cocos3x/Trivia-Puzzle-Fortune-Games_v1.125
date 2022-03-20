using UnityEngine;

namespace LitJson
{
    public class JsonReader
    {
        // Fields
        private static System.Collections.Generic.IDictionary<int, System.Collections.Generic.IDictionary<int, int[]>> parse_table;
        private System.Collections.Generic.Stack<int> automaton_stack;
        private int current_input;
        private int current_symbol;
        private bool end_of_json;
        private bool end_of_input;
        private LitJson.Lexer lexer;
        private bool parser_in_string;
        private bool parser_return;
        private bool read_started;
        private System.IO.TextReader reader;
        private bool reader_is_owned;
        private bool skip_non_members;
        private object token_value;
        private LitJson.JsonToken token;
        
        // Properties
        public bool AllowComments { get; set; }
        public bool AllowSingleQuotedStrings { get; set; }
        public bool SkipNonMembers { get; set; }
        public bool EndOfInput { get; }
        public bool EndOfJson { get; }
        public LitJson.JsonToken Token { get; }
        public object Value { get; }
        
        // Methods
        public bool get_AllowComments()
        {
            if(this.lexer != null)
            {
                    return (bool)this.lexer.allow_comments;
            }
            
            throw new NullReferenceException();
        }
        public void set_AllowComments(bool value)
        {
            if(this.lexer != null)
            {
                    this.lexer.allow_comments = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        public bool get_AllowSingleQuotedStrings()
        {
            if(this.lexer != null)
            {
                    return (bool)this.lexer.allow_single_quoted_strings;
            }
            
            throw new NullReferenceException();
        }
        public void set_AllowSingleQuotedStrings(bool value)
        {
            if(this.lexer != null)
            {
                    this.lexer.allow_single_quoted_strings = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        public bool get_SkipNonMembers()
        {
            return (bool)this.skip_non_members;
        }
        public void set_SkipNonMembers(bool value)
        {
            this.skip_non_members = value;
        }
        public bool get_EndOfInput()
        {
            return (bool)this.end_of_input;
        }
        public bool get_EndOfJson()
        {
            return (bool)this.end_of_json;
        }
        public LitJson.JsonToken get_Token()
        {
            return (LitJson.JsonToken)this.token;
        }
        public object get_Value()
        {
            return (object)this.token_value;
        }
        private static JsonReader()
        {
            LitJson.JsonReader.PopulateParseTable();
        }
        public JsonReader(string json_text)
        {
            System.IO.StringReader val_1 = new System.IO.StringReader(s:  json_text);
        }
        public JsonReader(System.IO.TextReader reader)
        {
        
        }
        private JsonReader(System.IO.TextReader reader, bool owned)
        {
            if(reader == null)
            {
                    throw new System.ArgumentNullException(paramName:  "reader");
            }
            
            this.parser_in_string = false;
            this.parser_return = false;
            this.read_started = false;
            System.Collections.Generic.Stack<System.Int32> val_1 = new System.Collections.Generic.Stack<System.Int32>();
            this.automaton_stack = val_1;
            val_1.Push(item:  65553);
            this.automaton_stack.Push(item:  65543);
            this.lexer = new LitJson.Lexer(reader:  reader);
            this.end_of_json = false;
            this.end_of_input = false;
            this.reader = reader;
            this.skip_non_members = true;
            this.reader_is_owned = owned;
        }
        private static void PopulateParseTable()
        {
            var val_29 = null;
            LitJson.JsonReader.parse_table = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.IDictionary<System.Int32, System.Int32[]>>();
            LitJson.JsonReader.TableAddRow(rule:  65548);
            int[] val_2 = new int[2];
            val_2[0] = 91;
            val_2[0] = 65549;
            LitJson.JsonReader.TableAddCol(row:  65548, col:  91, symbols:  val_2);
            LitJson.JsonReader.TableAddRow(rule:  13);
            LitJson.JsonReader.TableAddCol(row:  13, col:  34, symbols:  new int[3] {65550, 65551, 93});
            LitJson.JsonReader.TableAddCol(row:  13, col:  91, symbols:  new int[3] {65550, 65551, 93});
            int[] val_5 = new int[1];
            val_5[0] = 93;
            LitJson.JsonReader.TableAddCol(row:  13, col:  93, symbols:  val_5);
            LitJson.JsonReader.TableAddCol(row:  13, col:  123, symbols:  new int[3] {65550, 65551, 93});
            LitJson.JsonReader.TableAddCol(row:  13, col:  65537, symbols:  new int[3] {65550, 65551, 93});
            LitJson.JsonReader.TableAddCol(row:  13, col:  65538, symbols:  new int[3] {65550, 65551, 93});
            LitJson.JsonReader.TableAddCol(row:  13, col:  65539, symbols:  new int[3] {65550, 65551, 93});
            LitJson.JsonReader.TableAddCol(row:  13, col:  65540, symbols:  new int[3] {65550, 65551, 93});
            LitJson.JsonReader.TableAddRow(rule:  65544);
            int[] val_11 = new int[2];
            val_11[0] = 123;
            val_11[0] = 65545;
            LitJson.JsonReader.TableAddCol(row:  65544, col:  123, symbols:  val_11);
            LitJson.JsonReader.TableAddRow(rule:  65545);
            LitJson.JsonReader.TableAddCol(row:  65545, col:  34, symbols:  new int[3] {65546, 65547, 125});
            int[] val_13 = new int[1];
            val_13[0] = 125;
            LitJson.JsonReader.TableAddCol(row:  65545, col:  125, symbols:  val_13);
            LitJson.JsonReader.TableAddRow(rule:  65546);
            LitJson.JsonReader.TableAddCol(row:  65546, col:  34, symbols:  new int[3] {65552, 58, 65550});
            LitJson.JsonReader.TableAddRow(rule:  65547);
            LitJson.JsonReader.TableAddCol(row:  65547, col:  44, symbols:  new int[3] {44, 65546, 65547});
            int[] val_16 = new int[1];
            val_16[0] = 65554;
            LitJson.JsonReader.TableAddCol(row:  65547, col:  125, symbols:  val_16);
            LitJson.JsonReader.TableAddRow(rule:  65552);
            LitJson.JsonReader.TableAddCol(row:  65552, col:  34, symbols:  new int[3] {34, 65541, 34});
            LitJson.JsonReader.TableAddRow(rule:  65543);
            int[] val_18 = new int[1];
            val_18[0] = 65548;
            LitJson.JsonReader.TableAddCol(row:  65543, col:  91, symbols:  val_18);
            int[] val_19 = new int[1];
            val_19[0] = 65544;
            LitJson.JsonReader.TableAddCol(row:  65543, col:  123, symbols:  val_19);
            LitJson.JsonReader.TableAddRow(rule:  65550);
            int[] val_20 = new int[1];
            val_20[0] = 65552;
            LitJson.JsonReader.TableAddCol(row:  65550, col:  34, symbols:  val_20);
            int[] val_21 = new int[1];
            val_21[0] = 65548;
            LitJson.JsonReader.TableAddCol(row:  65550, col:  91, symbols:  val_21);
            int[] val_22 = new int[1];
            val_22[0] = 65544;
            LitJson.JsonReader.TableAddCol(row:  65550, col:  123, symbols:  val_22);
            int[] val_23 = new int[1];
            val_23[0] = 65537;
            LitJson.JsonReader.TableAddCol(row:  65550, col:  65537, symbols:  val_23);
            int[] val_24 = new int[1];
            val_24[0] = 65538;
            LitJson.JsonReader.TableAddCol(row:  65550, col:  65538, symbols:  val_24);
            int[] val_25 = new int[1];
            val_25[0] = 65539;
            LitJson.JsonReader.TableAddCol(row:  65550, col:  65539, symbols:  val_25);
            int[] val_26 = new int[1];
            val_26[0] = 65540;
            LitJson.JsonReader.TableAddCol(row:  65550, col:  65540, symbols:  val_26);
            LitJson.JsonReader.TableAddRow(rule:  65551);
            LitJson.JsonReader.TableAddCol(row:  65551, col:  44, symbols:  new int[3] {44, 65550, 65551});
            int[] val_28 = new int[1];
            val_28[0] = 65554;
            LitJson.JsonReader.TableAddCol(row:  65551, col:  93, symbols:  val_28);
        }
        private static void TableAddCol(LitJson.ParserToken row, int col, int[] symbols)
        {
            var val_3;
            var val_5;
            val_3 = null;
            val_3 = null;
            var val_3 = 0;
            val_3 = val_3 + 1;
            TValue val_2 = LitJson.JsonReader.parse_table.Item[???];
            var val_7 = val_2;
            if((val_2 + 294) == 0)
            {
                goto label_12;
            }
            
            var val_4 = val_2 + 176;
            var val_5 = 0;
            val_4 = val_4 + 8;
            label_11:
            if(((val_2 + 176 + 8) + -8) == null)
            {
                goto label_10;
            }
            
            val_5 = val_5 + 1;
            val_4 = val_4 + 16;
            if(val_5 < (val_2 + 294))
            {
                goto label_11;
            }
            
            goto label_12;
            label_10:
            var val_6 = val_4;
            val_6 = val_6 + 5;
            val_7 = val_7 + val_6;
            val_5 = val_7 + 304;
            label_12:
            val_2.Add(key:  null, value:  null);
        }
        private static void TableAddRow(LitJson.ParserToken rule)
        {
            var val_3 = null;
            System.Collections.Generic.Dictionary<System.Int32, System.Int32[]> val_1 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32[]>();
            var val_3 = 0;
            val_3 = val_3 + 1;
            LitJson.JsonReader.parse_table.Add(key:  null, value:  null);
        }
        private void ProcessNumber(string number)
        {
            var val_10;
            var val_11;
            long val_8 = 0;
            if((number.IndexOf(value:  '.')) == 1)
            {
                    if((number.IndexOf(value:  'e')) == 1)
            {
                    if((number.IndexOf(value:  'E')) == 1)
            {
                goto label_7;
            }
            
            }
            
            }
            
            if((System.Double.TryParse(s:  number, result: out  double val_4 = 1.28823225678246E-231)) == false)
            {
                goto label_7;
            }
            
            this.token = 8;
            val_10 = 0;
            val_11 = null;
            goto label_8;
            label_7:
            if((System.Int32.TryParse(s:  number, result: out  0)) == false)
            {
                goto label_9;
            }
            
            this.token = 6;
            val_11 = null;
            goto label_12;
            label_9:
            if((System.Int64.TryParse(s:  number, result: out  val_8)) == false)
            {
                goto label_11;
            }
            
            this.token = 7;
            val_10 = val_8;
            val_11 = null;
            label_8:
            label_12:
            this.token_value = 0;
            return;
            label_11:
            this.token = 6;
            goto label_12;
        }
        private void ProcessSymbol()
        {
            var val_1;
            LitJson.JsonToken val_2;
            if(this.current_symbol <= 122)
            {
                goto label_1;
            }
            
            var val_1 = -65537;
            val_1 = this.current_symbol + val_1;
            if(val_1 > 9)
            {
                goto label_2;
            }
            
            var val_2 = 32563008;
            val_2 = (32563008 + ((this.current_symbol + -65537)) << 2) + val_2;
            goto (32563008 + ((this.current_symbol + -65537)) << 2 + 32563008);
            label_1:
            if(this.current_symbol == 34)
            {
                goto label_5;
            }
            
            if(this.current_symbol == 91)
            {
                goto label_6;
            }
            
            if(this.current_symbol != 93)
            {
                    return;
            }
            
            val_1 = 5;
            goto label_14;
            label_2:
            if(this.current_symbol == 123)
            {
                goto label_9;
            }
            
            if(this.current_symbol != 125)
            {
                    return;
            }
            
            val_1 = 3;
            goto label_14;
            label_5:
            if(this.parser_in_string == false)
            {
                goto label_12;
            }
            
            this.parser_in_string = true;
            this.parser_return = true;
            return;
            label_6:
            val_1 = 4;
            label_14:
            this.token = 11;
            this.parser_return = true;
            return;
            label_9:
            val_2 = 1;
            this.token = val_2;
            this.parser_return = val_2;
            return;
            label_12:
            if(this.token == 0)
            {
                    this.token = 9;
            }
            
            this.parser_in_string = true;
        }
        private bool ReadToken()
        {
            if(this.end_of_input == true)
            {
                    return false;
            }
            
            bool val_1 = this.lexer.NextToken();
            if(this.lexer.end_of_input != false)
            {
                    this.Close();
                return false;
            }
            
            this.current_input = this.lexer.token;
            return false;
        }
        public void Close()
        {
            if(this.end_of_input == true)
            {
                    return;
            }
            
            this.end_of_json = true;
            this.end_of_input = true;
            this.reader = 0;
        }
        public bool Read()
        {
            var val_15;
            System.Collections.Generic.Stack<System.Int32> val_16;
            var val_17;
            int val_18;
            var val_19;
            var val_21;
            var val_22;
            if(this.end_of_input != false)
            {
                    return false;
            }
            
            if(this.end_of_json != false)
            {
                    val_16 = this.automaton_stack;
                this.end_of_json = false;
                if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_16.Clear();
                val_16 = this.automaton_stack;
                if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_15 = 1152921513355896176;
                val_16.Push(item:  65553);
                val_16 = this.automaton_stack;
                if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_17 = public System.Void System.Collections.Generic.Stack<System.Int32>::Push(System.Int32 item);
                val_16.Push(item:  65543);
            }
            
            this.parser_in_string = false;
            this.parser_return = false;
            this.token = 0;
            this.token_value = 0;
            if(this.read_started != true)
            {
                    this.read_started = true;
                if(this.ReadToken() == false)
            {
                    return false;
            }
            
            }
            
            val_16 = this.automaton_stack;
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_34:
            if(this.parser_return == true)
            {
                goto label_9;
            }
            
            this.current_symbol = val_16.Pop();
            this.ProcessSymbol();
            val_18 = this.current_symbol;
            if(val_18 != this.current_input)
            {
                goto label_10;
            }
            
            if(this.ReadToken() == true)
            {
                goto label_31;
            }
            
            goto label_12;
            label_10:
            val_19 = null;
            val_19 = null;
            val_18 = this.current_symbol;
            var val_17 = 0;
            val_17 = val_17 + 1;
            val_17 = 0;
            val_21 = public TValue System.Collections.Generic.IDictionary<TKey, TValue>::get_Item(TKey key);
            TValue val_5 = LitJson.JsonReader.parse_table.Item[???];
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_20 = val_5;
            if((val_5 + 294) == 0)
            {
                goto label_21;
            }
            
            var val_18 = val_5 + 176;
            var val_19 = 0;
            val_18 = val_18 + 8;
            label_23:
            if(((val_5 + 176 + 8) + -8) == null)
            {
                goto label_22;
            }
            
            val_19 = val_19 + 1;
            val_18 = val_18 + 16;
            if(val_19 < (val_5 + 294))
            {
                goto label_23;
            }
            
            label_21:
            val_21 = 0;
            goto label_24;
            label_22:
            val_20 = val_20 + (((val_5 + 176 + 8)) << 4);
            val_22 = val_20 + 304;
            label_24:
            val_16 = val_5;
            TValue val_6 = val_16.Item[???];
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(((val_6 + 32) == (65553 + 1)) || ((val_6 + 32) < 0))
            {
                goto label_31;
            }
            
            var val_9 = (val_6 + 24) & 4294967295;
            var val_21 = (long)(val_6 + 24) - 1;
            var val_10 = (val_6 + 24) - 2;
            label_32:
            val_16 = this.automaton_stack;
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            TValue val_11 = val_6 + (((long)(int)((val_6 + 24 - 1))) << 2);
            val_16.Push(item:  (val_6 + ((long)(int)((val_6 + 24 - 1))) << 2) + 32);
            if((val_10 & 2147483648) != 0)
            {
                goto label_31;
            }
            
            val_21 = val_21 - 1;
            val_10 = val_10 - 1;
            if(val_21 < (val_6 + 24))
            {
                goto label_32;
            }
            
            label_31:
            val_16 = this.automaton_stack;
            if(val_16 != null)
            {
                goto label_34;
            }
            
            throw new NullReferenceException();
            label_9:
            if(val_16.Peek() != 65553)
            {
                    return false;
            }
            
            this.end_of_json = true;
            return false;
            label_12:
            if(this.automaton_stack == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.automaton_stack.Peek() == 65553)
            {
                    var val_14 = (this.parser_return == true) ? 1 : 0;
                return false;
            }
            
            throw new LitJson.JsonException(message:  "Input doesn\'t evaluate to proper JSON text");
        }
    
    }

}
