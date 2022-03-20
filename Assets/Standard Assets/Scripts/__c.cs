using UnityEngine;
[Serializable]
private sealed class JsonMapper.<>c
{
    // Fields
    public static readonly LitJson.JsonMapper.<>c <>9;
    public static LitJson.WrapperFactory <>9__23_0;
    public static LitJson.ExporterFunc <>9__24_0;
    public static LitJson.ExporterFunc <>9__24_1;
    public static LitJson.ExporterFunc <>9__24_2;
    public static LitJson.ExporterFunc <>9__24_3;
    public static LitJson.ExporterFunc <>9__24_4;
    public static LitJson.ExporterFunc <>9__24_5;
    public static LitJson.ExporterFunc <>9__24_6;
    public static LitJson.ExporterFunc <>9__24_7;
    public static LitJson.ExporterFunc <>9__24_8;
    public static LitJson.ImporterFunc <>9__25_0;
    public static LitJson.ImporterFunc <>9__25_1;
    public static LitJson.ImporterFunc <>9__25_2;
    public static LitJson.ImporterFunc <>9__25_3;
    public static LitJson.ImporterFunc <>9__25_4;
    public static LitJson.ImporterFunc <>9__25_5;
    public static LitJson.ImporterFunc <>9__25_6;
    public static LitJson.ImporterFunc <>9__25_7;
    public static LitJson.ImporterFunc <>9__25_8;
    public static LitJson.ImporterFunc <>9__25_9;
    public static LitJson.ImporterFunc <>9__25_10;
    public static LitJson.ImporterFunc <>9__25_11;
    public static LitJson.WrapperFactory <>9__30_0;
    public static LitJson.WrapperFactory <>9__31_0;
    public static LitJson.WrapperFactory <>9__32_0;
    
    // Methods
    private static JsonMapper.<>c()
    {
        JsonMapper.<>c.<>9 = new JsonMapper.<>c();
    }
    public JsonMapper.<>c()
    {
    
    }
    internal LitJson.IJsonWrapper <ReadSkip>b__23_0()
    {
        return (LitJson.IJsonWrapper)new LitJson.JsonMockWrapper();
    }
    internal void <RegisterBaseExporters>b__24_0(object obj, LitJson.JsonWriter writer)
    {
        writer.Write(number:  System.Convert.ToInt32(value:  0));
    }
    internal void <RegisterBaseExporters>b__24_1(object obj, LitJson.JsonWriter writer)
    {
        writer.Write(str:  System.Convert.ToString(value:  ''));
    }
    internal void <RegisterBaseExporters>b__24_2(object obj, LitJson.JsonWriter writer)
    {
        null = null;
        writer.Write(str:  System.Convert.ToString(value:  new System.DateTime(), provider:  LitJson.JsonMapper.datetime_format));
    }
    internal void <RegisterBaseExporters>b__24_3(object obj, LitJson.JsonWriter writer)
    {
        writer.Write(number:  new System.Decimal() {flags = 19914752, hi = 268435456, lo = writer, mid = writer});
    }
    internal void <RegisterBaseExporters>b__24_4(object obj, LitJson.JsonWriter writer)
    {
        writer.Write(number:  System.Convert.ToInt32(value:  0));
    }
    internal void <RegisterBaseExporters>b__24_5(object obj, LitJson.JsonWriter writer)
    {
        writer.Write(number:  System.Convert.ToInt32(value:  57344));
    }
    internal void <RegisterBaseExporters>b__24_6(object obj, LitJson.JsonWriter writer)
    {
        writer.Write(number:  System.Convert.ToInt32(value:  57344));
    }
    internal void <RegisterBaseExporters>b__24_7(object obj, LitJson.JsonWriter writer)
    {
        writer.Write(number:  System.Convert.ToUInt64(value:  19914752));
    }
    internal void <RegisterBaseExporters>b__24_8(object obj, LitJson.JsonWriter writer)
    {
        writer.Write(number:  null);
    }
    internal object <RegisterBaseImporters>b__25_0(object input)
    {
        return (object)System.Convert.ToByte(value:  19914752);
    }
    internal object <RegisterBaseImporters>b__25_1(object input)
    {
        return (object)System.Convert.ToUInt64(value:  19914752);
    }
    internal object <RegisterBaseImporters>b__25_2(object input)
    {
        return (object)System.Convert.ToSByte(value:  19914752);
    }
    internal object <RegisterBaseImporters>b__25_3(object input)
    {
        return (object)System.Convert.ToInt16(value:  19914752);
    }
    internal object <RegisterBaseImporters>b__25_4(object input)
    {
        return (object)System.Convert.ToUInt16(value:  19914752);
    }
    internal object <RegisterBaseImporters>b__25_5(object input)
    {
        return (object)System.Convert.ToUInt32(value:  19914752);
    }
    internal object <RegisterBaseImporters>b__25_6(object input)
    {
        return (object)System.Convert.ToSingle(value:  19914752);
    }
    internal object <RegisterBaseImporters>b__25_7(object input)
    {
        return (object)System.Convert.ToDouble(value:  19914752);
    }
    internal object <RegisterBaseImporters>b__25_8(object input)
    {
        decimal val_1 = System.Convert.ToDecimal(value:  1.28822975961593E-231);
        return (object)val_1;
    }
    internal object <RegisterBaseImporters>b__25_9(object input)
    {
        return (object)System.Convert.ToUInt32(value:  null);
    }
    internal object <RegisterBaseImporters>b__25_10(object input)
    {
        if(input == null)
        {
                return (object)System.Convert.ToChar(value:  input);
        }
        
        if(null == null)
        {
                return (object)System.Convert.ToChar(value:  input);
        }
    
    }
    internal object <RegisterBaseImporters>b__25_11(object input)
    {
        null = null;
        if(input != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        System.DateTime val_1 = System.Convert.ToDateTime(value:  input, provider:  LitJson.JsonMapper.datetime_format);
        return (object)val_1;
        label_6:
    }
    internal LitJson.IJsonWrapper <ToObject>b__30_0()
    {
        return (LitJson.IJsonWrapper)new LitJson.JsonData();
    }
    internal LitJson.IJsonWrapper <ToObject>b__31_0()
    {
        return (LitJson.IJsonWrapper)new LitJson.JsonData();
    }
    internal LitJson.IJsonWrapper <ToObject>b__32_0()
    {
        return (LitJson.IJsonWrapper)new LitJson.JsonData();
    }

}
