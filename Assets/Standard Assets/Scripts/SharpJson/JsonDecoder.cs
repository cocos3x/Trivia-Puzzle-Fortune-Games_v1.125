using UnityEngine;

namespace SharpJson
{
    public class JsonDecoder
    {
        // Fields
        private string <errorMessage>k__BackingField;
        private bool <parseNumbersAsFloat>k__BackingField;
        private SharpJson.Lexer lexer;
        
        // Properties
        public string errorMessage { get; set; }
        public bool parseNumbersAsFloat { get; set; }
        
        // Methods
        public string get_errorMessage()
        {
            return (string)this.<errorMessage>k__BackingField;
        }
        private void set_errorMessage(string value)
        {
            this.<errorMessage>k__BackingField = value;
        }
        public bool get_parseNumbersAsFloat()
        {
            return (bool)this.<parseNumbersAsFloat>k__BackingField;
        }
        public void set_parseNumbersAsFloat(bool value)
        {
            this.<parseNumbersAsFloat>k__BackingField = value;
        }
        public JsonDecoder()
        {
            this.<errorMessage>k__BackingField = 0;
            this.<parseNumbersAsFloat>k__BackingField = false;
        }
        public object Decode(string text)
        {
            this.<errorMessage>k__BackingField = 0;
            this.lexer = new SharpJson.Lexer(text:  text);
            .<parseNumbersAsFloat>k__BackingField = this.<parseNumbersAsFloat>k__BackingField;
            return this.ParseValue();
        }
        public static object DecodeText(string text)
        {
            .<errorMessage>k__BackingField = 0;
            .<parseNumbersAsFloat>k__BackingField = false;
            return new SharpJson.JsonDecoder().Decode(text:  text);
        }
        private System.Collections.Generic.IDictionary<string, object> ParseObject()
        {
            SharpJson.Lexer val_15;
            var val_16;
            SharpJson.Lexer val_17;
            string val_18;
            val_15 = this;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_16 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            this.lexer.SkipWhiteSpaces();
            Token val_3 = SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  this.lexer.index);
            val_17 = this.lexer;
            label_14:
            val_17.SkipWhiteSpaces();
            Token val_5 = SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  this.lexer.index);
            if(val_5 == 5)
            {
                goto label_3;
            }
            
            if(val_5 == 9)
            {
                goto label_4;
            }
            
            if(val_5 == 0)
            {
                goto label_5;
            }
            
            if((this.<errorMessage>k__BackingField) != null)
            {
                goto label_10;
            }
            
            val_17 = this.EvalLexer<System.String>(value:  this.lexer.ParseString());
            this.lexer.SkipWhiteSpaces();
            if((SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  this.lexer.index)) != 4)
            {
                goto label_9;
            }
            
            if((this.<errorMessage>k__BackingField) != null)
            {
                goto label_10;
            }
            
            val_1.set_Item(key:  val_17, value:  this.ParseValue());
            goto label_12;
            label_3:
            this.lexer.SkipWhiteSpaces();
            Token val_12 = SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  this.lexer.index);
            label_12:
            if(this.lexer != null)
            {
                goto label_14;
            }
            
            label_4:
            val_15 = this.lexer;
            val_15.SkipWhiteSpaces();
            Token val_14 = SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  this.lexer.index);
            return (System.Collections.Generic.IDictionary<System.String, System.Object>)val_16;
            label_5:
            val_18 = "Invalid token";
            goto label_18;
            label_9:
            val_18 = "Invalid token; expected \':\'";
            label_18:
            this.TriggerError(message:  val_18);
            label_10:
            val_16 = 0;
            return (System.Collections.Generic.IDictionary<System.String, System.Object>)val_16;
        }
        private System.Collections.Generic.IList<object> ParseArray()
        {
            SharpJson.Lexer val_11;
            var val_12;
            val_11 = this;
            System.Collections.Generic.List<System.Object> val_1 = null;
            val_12 = val_1;
            val_1 = new System.Collections.Generic.List<System.Object>();
            this.lexer.SkipWhiteSpaces();
            Token val_3 = SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  this.lexer.index);
            label_10:
            this.lexer.SkipWhiteSpaces();
            Token val_5 = SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  this.lexer.index);
            if(val_5 == 5)
            {
                goto label_3;
            }
            
            if(val_5 == 11)
            {
                goto label_4;
            }
            
            if(val_5 == 0)
            {
                goto label_5;
            }
            
            if((this.<errorMessage>k__BackingField) != null)
            {
                goto label_6;
            }
            
            val_1.Add(item:  this.ParseValue());
            goto label_8;
            label_3:
            this.lexer.SkipWhiteSpaces();
            Token val_8 = SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  this.lexer.index);
            label_8:
            if(this.lexer != null)
            {
                goto label_10;
            }
            
            label_4:
            val_11 = this.lexer;
            val_11.SkipWhiteSpaces();
            Token val_10 = SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  this.lexer.index);
            return (System.Collections.Generic.IList<System.Object>)val_12;
            label_5:
            this.TriggerError(message:  "Invalid token");
            label_6:
            val_12 = 0;
            return (System.Collections.Generic.IList<System.Object>)val_12;
        }
        private object ParseValue()
        {
            SharpJson.Lexer val_17;
            var val_18;
            val_17 = this;
            this.lexer.SkipWhiteSpaces();
            int val_17 = this.lexer.index;
            val_17 = (SharpJson.Lexer.NextToken(json:  this.lexer.json, index: ref  val_17)) - 1;
            if(val_17 <= 9)
            {
                    var val_18 = 32576272 + ((val_2 - 1)) << 2;
                val_18 = val_18 + 32576272;
            }
            else
            {
                    this.TriggerError(message:  "Unable to parse value");
                val_18 = 0;
                return (object)EvalLexer<System.Double>(value:  this.lexer.index + 32.ParseDoubleNumber());
            }
        
        }
        private void TriggerError(string message)
        {
            this.<errorMessage>k__BackingField = System.String.Format(format:  "Error: \'{0}\' at line {1}", arg0:  message, arg1:  this.lexer.<lineNumber>k__BackingField);
        }
        private T EvalLexer<T>(T value)
        {
            if(this.lexer.hasError == false)
            {
                    return (double)value;
            }
            
            this.TriggerError(message:  "Lexical error ocurred");
            return (double)value;
        }
    
    }

}
