using UnityEngine;

namespace LitJson
{
    internal class Lexer
    {
        // Fields
        private static int[] fsm_return_table;
        private static LitJson.Lexer.StateHandler[] fsm_handler_table;
        private bool allow_comments;
        private bool allow_single_quoted_strings;
        private bool end_of_input;
        private LitJson.FsmContext fsm_context;
        private int input_buffer;
        private int input_char;
        private System.IO.TextReader reader;
        private int state;
        private System.Text.StringBuilder string_buffer;
        private string string_value;
        private int token;
        private int unichar;
        
        // Properties
        public bool AllowComments { get; set; }
        public bool AllowSingleQuotedStrings { get; set; }
        public bool EndOfInput { get; }
        public int Token { get; }
        public string StringValue { get; }
        
        // Methods
        public bool get_AllowComments()
        {
            return (bool)this.allow_comments;
        }
        public void set_AllowComments(bool value)
        {
            this.allow_comments = value;
        }
        public bool get_AllowSingleQuotedStrings()
        {
            return (bool)this.allow_single_quoted_strings;
        }
        public void set_AllowSingleQuotedStrings(bool value)
        {
            this.allow_single_quoted_strings = value;
        }
        public bool get_EndOfInput()
        {
            return (bool)this.end_of_input;
        }
        public int get_Token()
        {
            return (int)this.token;
        }
        public string get_StringValue()
        {
            return (string)this.string_value;
        }
        private static Lexer()
        {
            LitJson.Lexer.PopulateFsmTables();
        }
        public Lexer(System.IO.TextReader reader)
        {
            this.input_buffer = 0;
            this.allow_comments = true;
            this.allow_single_quoted_strings = true;
            this.string_buffer = new System.Text.StringBuilder(capacity:  128);
            this.end_of_input = false;
            this.reader = reader;
            this.state = 1;
            this.fsm_context = new LitJson.FsmContext();
            .L = this;
        }
        private static int HexValue(int digit)
        {
            if((digit - 65) > 5)
            {
                    if((digit - 97) > 5)
            {
                    return (int)digit - 48;
            }
            
                var val_4 = 32563116;
                val_4 = (32563116 + ((digit - 97)) << 2) + val_4;
            }
            else
            {
                    var val_5 = 32563092;
                val_5 = (32563092 + ((digit - 65)) << 2) + val_5;
            }
        
        }
        private static void PopulateFsmTables()
        {
            var val_31;
            StateHandler[] val_1 = new StateHandler[28];
            val_1[0] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State1(LitJson.FsmContext ctx));
            val_1[1] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State2(LitJson.FsmContext ctx));
            val_1[2] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State3(LitJson.FsmContext ctx));
            val_1[3] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State4(LitJson.FsmContext ctx));
            val_1[4] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State5(LitJson.FsmContext ctx));
            val_1[5] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State6(LitJson.FsmContext ctx));
            val_1[6] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State7(LitJson.FsmContext ctx));
            val_1[7] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State8(LitJson.FsmContext ctx));
            val_1[8] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State9(LitJson.FsmContext ctx));
            val_1[9] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State10(LitJson.FsmContext ctx));
            val_1[10] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State11(LitJson.FsmContext ctx));
            val_1[11] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State12(LitJson.FsmContext ctx));
            val_1[12] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State13(LitJson.FsmContext ctx));
            val_1[13] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State14(LitJson.FsmContext ctx));
            val_1[14] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State15(LitJson.FsmContext ctx));
            val_1[15] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State16(LitJson.FsmContext ctx));
            val_1[16] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State17(LitJson.FsmContext ctx));
            val_1[17] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State18(LitJson.FsmContext ctx));
            val_1[18] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State19(LitJson.FsmContext ctx));
            val_1[19] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State20(LitJson.FsmContext ctx));
            val_1[20] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State21(LitJson.FsmContext ctx));
            val_1[21] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State22(LitJson.FsmContext ctx));
            val_1[22] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State23(LitJson.FsmContext ctx));
            val_1[23] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State24(LitJson.FsmContext ctx));
            val_1[24] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State25(LitJson.FsmContext ctx));
            val_1[25] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State26(LitJson.FsmContext ctx));
            val_1[26] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State27(LitJson.FsmContext ctx));
            val_1[27] = new Lexer.StateHandler(object:  0, method:  static System.Boolean LitJson.Lexer::State28(LitJson.FsmContext ctx));
            val_31 = null;
            val_31 = null;
            LitJson.Lexer.fsm_handler_table = val_1;
            LitJson.Lexer.fsm_return_table = new int[28] {65542, 0, 65537, 65537, 0, 65537, 0, 65537, 0, 0, 65538, 0, 0, 0, 65539, 0, 0, 65540, 65541, 65542, 0, 0, 65541, 65542, 0, 0, 0, 0};
        }
        private static char ProcessEscChar(int esc_char)
        {
            var val_3;
            if(esc_char > 92)
            {
                goto label_1;
            }
            
            if(esc_char > 39)
            {
                goto label_2;
            }
            
            if((esc_char == 34) || (esc_char == 39))
            {
                    return System.Convert.ToChar(value:  esc_char);
            }
            
            goto label_14;
            label_1:
            if(esc_char > 102)
            {
                goto label_6;
            }
            
            var val_2 = (esc_char == 98) ? 8 : ((esc_char == 102) ? 12 : 63);
            return 13;
            label_2:
            if(esc_char == 47)
            {
                    return System.Convert.ToChar(value:  esc_char);
            }
            
            if(esc_char != 92)
            {
                goto label_14;
            }
            
            return System.Convert.ToChar(value:  esc_char);
            label_6:
            if(esc_char == 110)
            {
                goto label_12;
            }
            
            if(esc_char == 114)
            {
                goto label_13;
            }
            
            if(esc_char == 116)
            {
                    val_3 = 9;
                return 13;
            }
            
            label_14:
            val_3 = 63;
            return 13;
            label_12:
            val_3 = 10;
            return 13;
            label_13:
            val_3 = 13;
            return 13;
        }
        private static bool State1(LitJson.FsmContext ctx)
        {
            bool val_6;
            int val_7;
            label_6:
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                goto label_2;
            }
            
            if(ctx.L.input_char == 32)
            {
                goto label_6;
            }
            
            if(ctx.L.input_char < 9)
            {
                goto label_35;
            }
            
            if(ctx.L.input_char < 14)
            {
                goto label_6;
            }
            
            if(ctx.L.input_char >= 49)
            {
                goto label_7;
            }
            
            if(ctx.L.input_char > 39)
            {
                goto label_15;
            }
            
            if(ctx.L.input_char == 34)
            {
                goto label_9;
            }
            
            if((ctx.L.input_char != 39) || (ctx.L.allow_single_quoted_strings == false))
            {
                goto label_35;
            }
            
            val_6 = 1;
            ctx.L.input_char = 34;
            ctx.NextState = 23;
            goto label_29;
            label_2:
            val_6 = true;
            ctx.L.end_of_input = val_6;
            return (bool)val_6;
            label_7:
            if(ctx.L.input_char <= 57)
            {
                goto label_14;
            }
            
            if(ctx.L.input_char <= 91)
            {
                goto label_15;
            }
            
            if(ctx.L.input_char <= 110)
            {
                goto label_16;
            }
            
            if(ctx.L.input_char == 116)
            {
                goto label_40;
            }
            
            if(ctx.L.input_char == 123)
            {
                goto label_30;
            }
            
            if(ctx.L.input_char != 125)
            {
                goto label_35;
            }
            
            goto label_30;
            label_15:
            val_6 = 0;
            if((ctx.L.input_char - 44) > 4)
            {
                goto label_21;
            }
            
            var val_6 = 32563140 + ((ctx.L.input_char - 44)) << 2;
            val_6 = val_6 + 32563140;
            goto (32563140 + ((ctx.L.input_char - 44)) << 2 + 32563140);
            label_14:
            System.Text.StringBuilder val_4 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            val_7 = 3;
            label_40:
            ctx.NextState = val_7;
            val_6 = 1;
            return (bool)val_6;
            label_21:
            if((ctx.L.input_char == 58) || (ctx.L.input_char == 91))
            {
                goto label_30;
            }
            
            return (bool)val_6;
            label_9:
            val_6 = 1;
            ctx.NextState = 19;
            goto label_29;
            label_16:
            if(ctx.L.input_char == 93)
            {
                goto label_30;
            }
            
            if(ctx.L.input_char == 102)
            {
                goto label_40;
            }
            
            if(ctx.L.input_char != 110)
            {
                goto label_35;
            }
            
            goto label_40;
            label_30:
            val_6 = 1;
            ctx.NextState = val_6;
            label_29:
            ctx.Return = val_6;
            return (bool)val_6;
            label_35:
            val_6 = 0;
            return (bool)val_6;
        }
        private static bool State2(LitJson.FsmContext ctx)
        {
            int val_4;
            var val_5;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char >= 49)
            {
                goto label_4;
            }
            
            if(ctx.L.input_char != 48)
            {
                goto label_5;
            }
            
            System.Text.StringBuilder val_2 = ctx.L.string_buffer.Append(value:  '0');
            val_4 = 4;
            goto label_7;
            label_4:
            if(ctx.L.input_char <= 57)
            {
                goto label_8;
            }
            
            label_5:
            val_5 = 0;
            return (bool)val_5;
            label_8:
            System.Text.StringBuilder val_3 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            val_4 = 3;
            label_7:
            val_5 = 1;
            ctx.NextState = val_4;
            return (bool)val_5;
        }
        private static bool State3(LitJson.FsmContext ctx)
        {
            bool val_6;
            var val_7;
            goto label_1;
            label_7:
            if(ctx.L.input_char < 48)
            {
                goto label_3;
            }
            
            if(ctx.L.input_char > 57)
            {
                goto label_4;
            }
            
            System.Text.StringBuilder val_1 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            label_1:
            int val_2 = ctx.L.NextChar();
            ctx.L.input_char = val_2;
            if(val_2 != 1)
            {
                goto label_7;
            }
            
            val_6 = true;
            ctx.L.end_of_input = val_6;
            return (bool)val_6;
            label_3:
            val_6 = 0;
            if(ctx.L.input_char > 31)
            {
                goto label_9;
            }
            
            if((ctx.L.input_char - 9) < 5)
            {
                goto label_22;
            }
            
            return (bool)val_6;
            label_4:
            if(ctx.L.input_char <= 69)
            {
                goto label_12;
            }
            
            if(ctx.L.input_char == 125)
            {
                goto label_21;
            }
            
            if(ctx.L.input_char == 101)
            {
                goto label_14;
            }
            
            if(ctx.L.input_char != 93)
            {
                goto label_17;
            }
            
            goto label_21;
            label_12:
            if(ctx.L.input_char != 69)
            {
                goto label_17;
            }
            
            label_14:
            System.Text.StringBuilder val_4 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            val_7 = 7;
            goto label_19;
            label_9:
            if(ctx.L.input_char == 46)
            {
                goto label_20;
            }
            
            if(ctx.L.input_char == 44)
            {
                goto label_21;
            }
            
            if(ctx.L.input_char == 32)
            {
                goto label_22;
            }
            
            return (bool)val_6;
            label_17:
            val_6 = 0;
            return (bool)val_6;
            label_21:
            ctx.L.input_buffer = ctx.L.input_char;
            label_22:
            val_6 = true;
            ctx.Return = val_6;
            ctx.NextState = val_6;
            return (bool)val_6;
            label_20:
            System.Text.StringBuilder val_5 = ctx.L.string_buffer.Append(value:  '.');
            val_7 = 5;
            label_19:
            ctx.NextState = 5;
            val_6 = 1;
            return (bool)val_6;
        }
        private static bool State4(LitJson.FsmContext ctx)
        {
            var val_4;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char != 32)
            {
                goto label_4;
            }
            
            label_17:
            ctx.Return = true;
            ctx.NextState = true;
            return true;
            label_4:
            if(ctx.L.input_char < 9)
            {
                goto label_7;
            }
            
            if(ctx.L.input_char <= 13)
            {
                goto label_17;
            }
            
            if(ctx.L.input_char <= 69)
            {
                goto label_7;
            }
            
            if(ctx.L.input_char == 125)
            {
                goto label_12;
            }
            
            if(ctx.L.input_char == 101)
            {
                goto label_9;
            }
            
            if(ctx.L.input_char == 93)
            {
                goto label_12;
            }
            
            return true;
            label_7:
            if(ctx.L.input_char == 44)
            {
                goto label_12;
            }
            
            if(ctx.L.input_char == 46)
            {
                goto label_13;
            }
            
            if(ctx.L.input_char != 69)
            {
                    return true;
            }
            
            label_9:
            System.Text.StringBuilder val_2 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            val_4 = 7;
            goto label_16;
            label_12:
            ctx.L.input_buffer = ctx.L.input_char;
            goto label_17;
            label_13:
            System.Text.StringBuilder val_3 = ctx.L.string_buffer.Append(value:  '.');
            val_4 = 5;
            label_16:
            ctx.NextState = 5;
            return true;
        }
        private static bool State5(LitJson.FsmContext ctx)
        {
            var val_4;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if((ctx.L.input_char - 48) <= 9)
            {
                    System.Text.StringBuilder val_3 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
                val_4 = 1;
                ctx.NextState = 6;
                return (bool)val_4;
            }
            
            val_4 = 0;
            return (bool)val_4;
        }
        private static bool State6(LitJson.FsmContext ctx)
        {
            bool val_4;
            goto label_1;
            label_7:
            if(ctx.L.input_char < 48)
            {
                goto label_3;
            }
            
            if(ctx.L.input_char > 57)
            {
                goto label_4;
            }
            
            System.Text.StringBuilder val_1 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            label_1:
            int val_2 = ctx.L.NextChar();
            ctx.L.input_char = val_2;
            if(val_2 != 1)
            {
                goto label_7;
            }
            
            val_4 = true;
            ctx.L.end_of_input = val_4;
            return (bool)val_4;
            label_3:
            if(ctx.L.input_char == 32)
            {
                goto label_11;
            }
            
            if(ctx.L.input_char < 9)
            {
                goto label_19;
            }
            
            if(ctx.L.input_char <= 13)
            {
                goto label_11;
            }
            
            if(ctx.L.input_char == 44)
            {
                goto label_15;
            }
            
            goto label_19;
            label_4:
            if(ctx.L.input_char <= 69)
            {
                goto label_14;
            }
            
            if(ctx.L.input_char == 125)
            {
                goto label_15;
            }
            
            if(ctx.L.input_char == 101)
            {
                goto label_16;
            }
            
            if(ctx.L.input_char != 93)
            {
                goto label_19;
            }
            
            label_15:
            ctx.L.input_buffer = ctx.L.input_char;
            label_11:
            val_4 = true;
            ctx.Return = val_4;
            ctx.NextState = val_4;
            return (bool)val_4;
            label_14:
            if(ctx.L.input_char != 69)
            {
                goto label_19;
            }
            
            label_16:
            System.Text.StringBuilder val_3 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            ctx.NextState = 7;
            val_4 = 1;
            return (bool)val_4;
            label_19:
            val_4 = 0;
            return (bool)val_4;
        }
        private static bool State7(LitJson.FsmContext ctx)
        {
            var val_3;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char >= 48)
            {
                goto label_4;
            }
            
            if(ctx.L.input_char != 45)
            {
                    if(ctx.L.input_char != 43)
            {
                goto label_6;
            }
            
            }
            
            label_9:
            System.Text.StringBuilder val_2 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            val_3 = 1;
            ctx.NextState = 8;
            return (bool)val_3;
            label_4:
            if(ctx.L.input_char <= 57)
            {
                goto label_9;
            }
            
            label_6:
            val_3 = 0;
            return (bool)val_3;
        }
        private static bool State8(LitJson.FsmContext ctx)
        {
            bool val_5;
            goto label_1;
            label_7:
            if(ctx.L.input_char < 48)
            {
                goto label_3;
            }
            
            if(ctx.L.input_char > 57)
            {
                goto label_4;
            }
            
            System.Text.StringBuilder val_1 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            label_1:
            int val_2 = ctx.L.NextChar();
            ctx.L.input_char = val_2;
            if(val_2 != 1)
            {
                goto label_7;
            }
            
            val_5 = true;
            ctx.L.end_of_input = val_5;
            return (bool)val_5;
            label_3:
            if((ctx.L.input_char - 9) < 5)
            {
                goto label_11;
            }
            
            if(ctx.L.input_char == 44)
            {
                goto label_10;
            }
            
            if(ctx.L.input_char == 32)
            {
                goto label_11;
            }
            
            goto label_13;
            label_4:
            if((ctx.L.input_char | 32) != 125)
            {
                goto label_13;
            }
            
            label_10:
            ctx.L.input_buffer = ctx.L.input_char;
            label_11:
            val_5 = true;
            ctx.Return = val_5;
            ctx.NextState = val_5;
            return (bool)val_5;
            label_13:
            val_5 = 0;
            return (bool)val_5;
        }
        private static bool State9(LitJson.FsmContext ctx)
        {
            var val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 114)
            {
                    val_2 = 1;
                ctx.NextState = 10;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State10(LitJson.FsmContext ctx)
        {
            var val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 117)
            {
                    val_2 = 1;
                ctx.NextState = 11;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State11(LitJson.FsmContext ctx)
        {
            bool val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 101)
            {
                    val_2 = true;
                ctx.Return = val_2;
                ctx.NextState = val_2;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State12(LitJson.FsmContext ctx)
        {
            var val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 97)
            {
                    val_2 = 1;
                ctx.NextState = 13;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State13(LitJson.FsmContext ctx)
        {
            var val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 108)
            {
                    val_2 = 1;
                ctx.NextState = 14;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State14(LitJson.FsmContext ctx)
        {
            var val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 115)
            {
                    val_2 = 1;
                ctx.NextState = 15;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State15(LitJson.FsmContext ctx)
        {
            bool val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 101)
            {
                    val_2 = true;
                ctx.Return = val_2;
                ctx.NextState = val_2;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State16(LitJson.FsmContext ctx)
        {
            var val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 117)
            {
                    val_2 = 1;
                ctx.NextState = 17;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State17(LitJson.FsmContext ctx)
        {
            var val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 108)
            {
                    val_2 = 1;
                ctx.NextState = 18;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State18(LitJson.FsmContext ctx)
        {
            bool val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 108)
            {
                    val_2 = true;
                ctx.Return = val_2;
                ctx.NextState = val_2;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State19(LitJson.FsmContext ctx)
        {
            goto label_1;
            label_7:
            if(ctx.L.input_char == 92)
            {
                goto label_3;
            }
            
            if(ctx.L.input_char == 34)
            {
                goto label_4;
            }
            
            System.Text.StringBuilder val_1 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            label_1:
            int val_2 = ctx.L.NextChar();
            ctx.L.input_char = val_2;
            if(val_2 != 1)
            {
                goto label_7;
            }
            
            ctx.L.end_of_input = true;
            return true;
            label_3:
            ctx.StateStack = 19;
            ctx.NextState = 21;
            return true;
            label_4:
            ctx.L.input_buffer = 34;
            ctx.Return = true;
            ctx.NextState = 20;
            return true;
        }
        private static bool State20(LitJson.FsmContext ctx)
        {
            bool val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 34)
            {
                    val_2 = true;
                ctx.Return = val_2;
                ctx.NextState = val_2;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State21(LitJson.FsmContext ctx)
        {
            var val_6;
            int val_7;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char <= 92)
            {
                goto label_5;
            }
            
            if(ctx.L.input_char <= 102)
            {
                goto label_6;
            }
            
            val_6 = 0;
            if((ctx.L.input_char - 110) > 7)
            {
                    return (bool)val_6;
            }
            
            var val_6 = 32563160 + ((ctx.L.input_char - 110)) << 2;
            val_6 = val_6 + 32563160;
            goto (32563160 + ((ctx.L.input_char - 110)) << 2 + 32563160);
            label_5:
            if(ctx.L.input_char <= 39)
            {
                goto label_9;
            }
            
            if((ctx.L.input_char == 47) || (ctx.L.input_char == 92))
            {
                goto label_15;
            }
            
            goto label_16;
            label_6:
            if((ctx.L.input_char | 4) == 102)
            {
                goto label_15;
            }
            
            goto label_16;
            label_9:
            if(ctx.L.input_char != 34)
            {
                    if(ctx.L.input_char != 39)
            {
                goto label_16;
            }
            
            }
            
            label_15:
            System.Text.StringBuilder val_5 = ctx.L.string_buffer.Append(value:  LitJson.Lexer.ProcessEscChar(esc_char:  ctx.L.input_char));
            val_7 = ctx.StateStack;
            val_6 = 1;
            ctx.NextState = val_7;
            return (bool)val_6;
            label_16:
            val_6 = 0;
            return (bool)val_6;
        }
        private static bool State22(LitJson.FsmContext ctx)
        {
            int val_8;
            bool val_9;
            ctx.L.unichar = 0;
            var val_9 = 4096;
            val_8 = 4;
            label_13:
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                goto label_4;
            }
            
            if(ctx.L.input_char < 48)
            {
                goto label_10;
            }
            
            if(ctx.L.input_char < 58)
            {
                goto label_9;
            }
            
            if(ctx.L.input_char < 65)
            {
                goto label_10;
            }
            
            if(ctx.L.input_char >= 71)
            {
                    if((ctx.L.input_char - 97) > 5)
            {
                goto label_10;
            }
            
            }
            
            label_9:
            ctx.L.unichar = ctx.L.unichar + ((LitJson.Lexer.HexValue(digit:  ctx.L.input_char)) * val_9);
            val_8 = val_8 - 1;
            val_9 = ((val_9 < 0) ? (val_9 + 15) : (val_9)) >> 4;
            if(val_9 != 0)
            {
                goto label_13;
            }
            
            val_8 = ctx.L.unichar;
            System.Text.StringBuilder val_8 = ctx.L.string_buffer.Append(value:  System.Convert.ToChar(value:  val_8));
            val_9 = 1;
            ctx.NextState = ctx.StateStack;
            return val_9;
            label_10:
            val_9 = 0;
            return val_9;
            label_4:
            val_9 = true;
            ctx.L.end_of_input = val_9;
            return val_9;
        }
        private static bool State23(LitJson.FsmContext ctx)
        {
            goto label_1;
            label_7:
            if(ctx.L.input_char == 92)
            {
                goto label_3;
            }
            
            if(ctx.L.input_char == 39)
            {
                goto label_4;
            }
            
            System.Text.StringBuilder val_1 = ctx.L.string_buffer.Append(value:  ctx.L.input_char);
            label_1:
            int val_2 = ctx.L.NextChar();
            ctx.L.input_char = val_2;
            if(val_2 != 1)
            {
                goto label_7;
            }
            
            ctx.L.end_of_input = true;
            return true;
            label_3:
            ctx.StateStack = 23;
            ctx.NextState = 21;
            return true;
            label_4:
            ctx.L.input_buffer = 39;
            ctx.Return = true;
            ctx.NextState = 24;
            return true;
        }
        private static bool State24(LitJson.FsmContext ctx)
        {
            bool val_2;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 39)
            {
                    val_2 = true;
                ctx.L.input_char = 34;
                ctx.Return = val_2;
                ctx.NextState = val_2;
                return (bool)val_2;
            }
            
            val_2 = 0;
            return (bool)val_2;
        }
        private static bool State25(LitJson.FsmContext ctx)
        {
            var val_2;
            var val_3;
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                    ctx.L.end_of_input = true;
            }
            
            if(ctx.L.input_char == 42)
            {
                goto label_4;
            }
            
            if(ctx.L.input_char != 47)
            {
                goto label_5;
            }
            
            val_2 = 26;
            goto label_6;
            label_4:
            val_2 = 27;
            label_6:
            val_3 = 1;
            ctx.NextState = 27;
            return (bool)val_3;
            label_5:
            val_3 = 0;
            return (bool)val_3;
        }
        private static bool State26(LitJson.FsmContext ctx)
        {
            label_4:
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                goto label_2;
            }
            
            if(ctx.L.input_char != 10)
            {
                goto label_4;
            }
            
            ctx.NextState = 1;
            return true;
            label_2:
            ctx.L.end_of_input = true;
            return true;
        }
        private static bool State27(LitJson.FsmContext ctx)
        {
            label_4:
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                goto label_2;
            }
            
            if(ctx.L.input_char != 42)
            {
                goto label_4;
            }
            
            ctx.NextState = 28;
            return true;
            label_2:
            ctx.L.end_of_input = true;
            return true;
        }
        private static bool State28(LitJson.FsmContext ctx)
        {
            var val_2;
            label_4:
            int val_1 = ctx.L.NextChar();
            ctx.L.input_char = val_1;
            if(val_1 == 1)
            {
                goto label_2;
            }
            
            if(ctx.L.input_char == 42)
            {
                goto label_4;
            }
            
            if(ctx.L.input_char != 47)
            {
                goto label_5;
            }
            
            val_2 = 1;
            goto label_6;
            label_2:
            ctx.L.end_of_input = true;
            return true;
            label_5:
            val_2 = 27;
            label_6:
            ctx.NextState = 27;
            return true;
        }
        private bool GetChar()
        {
            bool val_2;
            int val_1 = this.NextChar();
            this.input_char = val_1;
            val_2 = true;
            if(val_1 != 1)
            {
                    return (bool)val_2;
            }
            
            this.end_of_input = val_2;
            val_2 = 0;
            return (bool)val_2;
        }
        private int NextChar()
        {
            if(this.input_buffer != 0)
            {
                    this.input_buffer = 0;
                return (int)this.input_buffer;
            }
            
            if(this.reader != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public bool NextToken()
        {
            var val_5;
            var val_6;
            var val_7;
            this.fsm_context.Return = false;
            goto label_2;
            label_11:
            if(this.fsm_context.Return == true)
            {
                goto label_4;
            }
            
            this.state = this.fsm_context.NextState;
            label_2:
            val_5 = null;
            val_5 = null;
            StateHandler[] val_6 = LitJson.Lexer.fsm_handler_table;
            int val_5 = this.state;
            val_5 = val_5 - 1;
            val_6 = val_6 + (val_5 << 3);
            if(((LitJson.Lexer.fsm_handler_table + ((this.state - 1)) << 3) + 32.Invoke(ctx:  this.fsm_context)) == false)
            {
                    throw new LitJson.JsonException(c:  ??? + 36);
            }
            
            if(this.end_of_input == false)
            {
                goto label_11;
            }
            
            val_6 = 0;
            return (bool)val_6;
            label_4:
            this.string_value = this.string_buffer;
            System.Text.StringBuilder val_3 = this.string_buffer.Remove(startIndex:  0, length:  this.string_buffer.Length);
            val_7 = null;
            val_7 = null;
            System.Int32[] val_8 = LitJson.Lexer.fsm_return_table;
            int val_7 = this.state;
            val_7 = val_7 - 1;
            val_8 = val_8 + (val_7 << 2);
            this.token = (LitJson.Lexer.fsm_return_table + ((this.state - 1)) << 2) + 32;
            if(((LitJson.Lexer.fsm_return_table + ((this.state - 1)) << 2) + 32) == 65542)
            {
                    this.token = this.input_char;
            }
            
            val_6 = 1;
            this.state = this.fsm_context.NextState;
            return (bool)val_6;
        }
        private void UngetChar()
        {
            this.input_buffer = this.input_char;
        }
    
    }

}
