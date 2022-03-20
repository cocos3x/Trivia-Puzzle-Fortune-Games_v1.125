using UnityEngine;
private sealed class Json.Parser : IDisposable
{
    // Fields
    private const string WHITE_SPACE = " \t\n\r";
    private const string WORD_BREAK = " \t\n\r{}[],:\"";
    private System.IO.StringReader json;
    
    // Properties
    private char PeekChar { get; }
    private char NextChar { get; }
    private string NextWord { get; }
    private MiniJSON.Json.Parser.TOKEN NextToken { get; }
    
    // Methods
    private Json.Parser(string jsonString)
    {
        this.json = new System.IO.StringReader(s:  jsonString);
    }
    public static object Parse(string jsonString)
    {
        Json.Parser val_1 = new Json.Parser(jsonString:  jsonString);
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_1.Dispose();
        if(0 != 0)
        {
                throw ???;
        }
        
        return (object)val_1.ParseByToken(token:  val_1.NextToken);
    }
    public void Dispose()
    {
        this.json.Dispose();
        this.json = 0;
    }
    private System.Collections.Generic.Dictionary<string, object> ParseObject()
    {
        var val_7;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_7 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        goto label_6;
        label_9:
        if(this.NextToken != 5)
        {
            goto label_7;
        }
        
        val_1.set_Item(key:  this.json, value:  this.ParseByToken(token:  this.NextToken));
        do
        {
            label_6:
            TOKEN val_5 = this.NextToken;
        }
        while(val_5 == 6);
        
        if(val_5 == 0)
        {
            goto label_7;
        }
        
        if(val_5 == 2)
        {
                return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_7;
        }
        
        if(this.ParseString() != null)
        {
            goto label_9;
        }
        
        label_7:
        val_7 = 0;
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_7;
    }
    private System.Collections.Generic.List<object> ParseArray()
    {
        goto label_5;
    }
    private object ParseValue()
    {
        return this.ParseByToken(token:  this.NextToken);
    }
    private object ParseByToken(MiniJSON.Json.Parser.TOKEN token)
    {
        var val_10 = 0;
        if((token - 1) > 9)
        {
                return (object);
        }
        
        var val_10 = 32498648 + ((token - 1)) << 2;
        val_10 = val_10 + 32498648;
        goto (32498648 + ((token - 1)) << 2 + 32498648);
    }
    private string ParseString()
    {
        char val_14;
        label_14:
        if(this.json == 1)
        {
            goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
        }
        
        char val_2 = this.NextChar;
        char val_3 = val_2 & 65535;
        if(val_3 == '\')
        {
            goto label_4;
        }
        
        if(val_3 == '"')
        {
            goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
        }
        
        val_14 = val_2;
        goto label_29;
        label_4:
        if(this.json == 1)
        {
            goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
        }
        
        char val_4 = this.NextChar;
        char val_5 = val_4 & 65535;
        val_14 = val_4;
        if(val_5 > '\')
        {
            goto label_10;
        }
        
        val_5 = val_5 - 34;
        if(val_5 > (':'))
        {
            goto label_21;
        }
        
        val_5 = 1 << val_5;
        if((val_5 & ' ') != 0)
        {
            goto label_21;
        }
        
        label_29:
        System.Text.StringBuilder val_6 = new System.Text.StringBuilder().Append(value:  val_14);
        label_21:
        if(this.json != null)
        {
            goto label_14;
        }
        
        label_10:
        if(val_5 > 'f')
        {
            goto label_16;
        }
        
        char val_7 = val_14 & 65535;
        if(val_7 == 'b')
        {
            goto label_29;
        }
        
        if(val_7 != 'f')
        {
            goto label_21;
        }
        
        goto label_29;
        label_16:
        char val_8 = val_14 & 65535;
        val_8 = val_8 - 110;
        if(val_8 > '')
        {
            goto label_21;
        }
        
        var val_13 = 32498616 + (((val_4 & 65535) - 110)) << 2;
        val_13 = val_13 + 32498616;
        goto (32498616 + (((val_4 & 65535) - 110)) << 2 + 32498616);
    }
    private object ParseNumber()
    {
        var val_9;
        string val_1 = this.NextWord;
        if(((val_1.IndexOf(value:  '.')) & 2147483648) != 0)
        {
            goto label_2;
        }
        
        float val_4 = System.Single.Parse(s:  val_1, provider:  System.Globalization.CultureInfo.InvariantCulture);
        val_9 = null;
        goto label_5;
        label_2:
        if((System.Int32.TryParse(s:  val_1, style:  511, provider:  0, result: out  0)) == false)
        {
            goto label_6;
        }
        
        val_9 = null;
        label_5:
        return (object)0;
        label_6:
        decimal val_8 = System.Decimal.Parse(s:  val_1, provider:  System.Globalization.CultureInfo.InvariantCulture);
        return (object)0;
    }
    private void EatWhitespace()
    {
        do
        {
            if((IndexOf(value:  this.PeekChar)) == 1)
        {
                return;
        }
        
        }
        while(this.json != 1);
    
    }
    private char get_PeekChar()
    {
        return System.Convert.ToChar(value:  this.json);
    }
    private char get_NextChar()
    {
        return System.Convert.ToChar(value:  this.json);
    }
    private string get_NextWord()
    {
        char val_6;
        label_5:
        val_6 = this.PeekChar;
        if((IndexOf(value:  val_6)) != 1)
        {
            goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
        }
        
        System.Text.StringBuilder val_5 = new System.Text.StringBuilder().Append(value:  this.NextChar);
        if(this.json != 1)
        {
            goto label_5;
        }
        
        goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
    }
    private MiniJSON.Json.Parser.TOKEN get_NextToken()
    {
        var val_9;
        this.EatWhitespace();
        if(this.json == 1)
        {
            goto label_2;
        }
        
        char val_2 = this.PeekChar & 65535;
        if(val_2 > '[')
        {
            goto label_3;
        }
        
        if((val_2 - 34) > '')
        {
            goto label_4;
        }
        
        var val_9 = 32498516;
        val_9 = (32498516 + (((val_1 & 65535) - 34)) << 2) + val_9;
        goto (32498516 + (((val_1 & 65535) - 34)) << 2 + 32498516);
        label_2:
        val_9 = 0;
        return (TOKEN)val_9;
        label_3:
        if(val_2 == ']')
        {
                return (TOKEN)val_9;
        }
        
        if(val_2 == '{')
        {
                return (TOKEN)val_9;
        }
        
        if(val_2 != '}')
        {
            goto label_14;
        }
        
        return (TOKEN)val_9;
        label_4:
        if(val_2 == '[')
        {
                return (TOKEN)val_9;
        }
        
        label_14:
        string val_4 = this.NextWord;
        if((System.String.op_Equality(a:  val_4, b:  "false")) != false)
        {
                return (TOKEN)val_9;
        }
        
        if((System.String.op_Equality(a:  val_4, b:  "true")) != false)
        {
                return (TOKEN)val_9;
        }
        
        var val_8 = ((System.String.op_Equality(a:  val_4, b:  "null")) != true) ? 11 : 0;
        return (TOKEN)val_9;
    }

}
