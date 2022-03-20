using UnityEngine;
public class DeeplinkAction
{
    // Fields
    private DeeplinkActionState state;
    private string identifier;
    private string encodedAction;
    private string decodedAction;
    private System.Collections.Generic.Dictionary<string, object> parameters;
    private string source;
    private bool forcedJson;
    
    // Properties
    public DeeplinkActionState State { get; set; }
    public string Identifier { get; }
    public string EncodedAction { get; }
    public string DecodedAction { get; }
    public System.Collections.Generic.Dictionary<string, object> Parameters { get; }
    public string Source { get; set; }
    public bool IsForcedJson { get; }
    public bool IsValidAction { get; }
    
    // Methods
    public DeeplinkActionState get_State()
    {
        return (DeeplinkActionState)this.state;
    }
    public void set_State(DeeplinkActionState value)
    {
        this.state = value;
    }
    public string get_Identifier()
    {
        return (string)this.identifier;
    }
    public string get_EncodedAction()
    {
        return (string)this.encodedAction;
    }
    public string get_DecodedAction()
    {
        return (string)this.decodedAction;
    }
    public System.Collections.Generic.Dictionary<string, object> get_Parameters()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.parameters;
    }
    public string get_Source()
    {
        return (string)this.source;
    }
    public void set_Source(string value)
    {
        this.source = value;
    }
    public bool get_IsForcedJson()
    {
        return (bool)this.forcedJson;
    }
    public bool get_IsValidAction()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.decodedAction);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public DeeplinkAction(string maybeJson)
    {
        var val_18;
        string val_19;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_20;
        var val_21;
        val_18 = 1152921504622235648;
        this.identifier = System.String.alignConst;
        this.encodedAction = System.String.alignConst;
        this.decodedAction = System.String.alignConst;
        this.parameters = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.source = System.String.alignConst;
        val_19 = 0;
        val_21 = MiniJSON.Json.Deserialize(json:  maybeJson);
        this.encodedAction = maybeJson;
        if(this.parameters == null)
        {
                throw new NullReferenceException();
        }
        
        val_21 = "g";
        val_19 = "g";
        val_20 = this.parameters;
        if((this.parameters.ContainsKey(key:  val_19)) != false)
        {
                if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            val_19 = "g";
            object val_4 = val_20.Item[val_19];
            if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
            string val_5 = DeeplinkAction.TryBase64ForUrlDecode(str:  val_4);
        }
        else
        {
                if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            val_21 = "c";
            val_19 = "c";
            if((val_20.ContainsKey(key:  val_19)) != false)
        {
                val_20 = this.parameters;
            if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            val_19 = "c";
            object val_7 = val_20.Item[val_19];
            if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
            string val_8 = DeeplinkAction.TryBase64ForUrlDecode(str:  val_7);
        }
        
        }
        
        this.decodedAction = DeeplinkAction.TryBase64ForUrlDecode(str:  this.encodedAction);
    }
    public void ForceJson(string forcedJson)
    {
        object[] val_1 = new object[1];
        val_1[0] = forcedJson;
        UnityEngine.Debug.LogWarningFormat(format:  "DeeplinkAction. Forcing Json: {0}", args:  val_1);
        this.decodedAction = forcedJson;
        this.forcedJson = true;
    }
    public override string ToString()
    {
        int val_5;
        object[] val_1 = new object[6];
        val_1[0] = this.identifier;
        val_1[1] = this.state;
        object val_5 = ~(System.String.IsNullOrEmpty(value:  this.decodedAction));
        val_5 = val_5 & 1;
        val_5 = val_1.Length;
        val_1[2] = val_5;
        if(this.encodedAction != null)
        {
                val_5 = val_1.Length;
        }
        
        val_1[3] = this.encodedAction;
        if(this.decodedAction != null)
        {
                val_5 = val_1.Length;
        }
        
        val_1[4] = this.decodedAction;
        val_1[5] = MiniJSON.Json.Serialize(obj:  this.parameters);
        return (string)System.String.Format(format:  "DeeplinkAction: identifier={0} state={1} valid={2} encodedAction={3} decodedAction={4} parameters={5}", args:  val_1);
    }
    public static string Base64ForUrlEncode(string str)
    {
        return UnityEngine.WWW.EscapeURL(s:  System.Convert.ToBase64String(inArray:  System.Text.Encoding.UTF8));
    }
    public static string Base64ForUrlDecode(string str)
    {
        System.Text.Encoding val_1 = System.Text.Encoding.Default;
        System.Byte[] val_2 = DeeplinkAction.UnscapeURLAndDecode(parameter:  str);
        goto typeof(System.Text.Encoding).__il2cppRuntimeField_350;
    }
    private static byte[] UnscapeURLAndDecode(string parameter)
    {
        return System.Convert.FromBase64String(s:  UnityEngine.WWW.UnEscapeURL(s:  parameter));
    }
    public static string TryBase64ForUrlDecode(string str)
    {
        return (string)DeeplinkAction.Base64ForUrlDecode(str:  str);
    }

}
