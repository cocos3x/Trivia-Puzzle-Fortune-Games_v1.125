using UnityEngine;
public class ByteReader
{
    // Fields
    private byte[] mBuffer;
    private int mOffset;
    
    // Properties
    public bool canRead { get; }
    
    // Methods
    public ByteReader(byte[] bytes)
    {
        this.mBuffer = bytes;
    }
    public ByteReader(UnityEngine.TextAsset asset)
    {
        this.mBuffer = asset.bytes;
    }
    public bool get_canRead()
    {
        if(this.mBuffer == null)
        {
                return false;
        }
        
        return (bool)(this.mOffset < this.mBuffer.Length) ? 1 : 0;
    }
    private static string ReadLine(byte[] buffer, int start, int count)
    {
        System.Text.Encoding val_1 = System.Text.Encoding.UTF8;
        goto typeof(System.Text.Encoding).__il2cppRuntimeField_360;
    }
    public string ReadLine()
    {
        int val_4;
        var val_5;
        val_4 = this.mBuffer.Length;
        int val_4 = this.mOffset;
        if(val_4 >= val_4)
        {
            goto label_4;
        }
        
        label_5:
        if(this.mBuffer[val_4] >= 32)
        {
            goto label_3;
        }
        
        val_4 = val_4 + 1;
        this.mOffset = val_4;
        if(val_4 < val_4)
        {
                if(val_4 < this.mBuffer.Length)
        {
            goto label_5;
        }
        
        }
        
        label_4:
        val_5 = 0;
        goto label_7;
        label_3:
        var val_5 = 0;
        var val_7 = val_4;
        label_11:
        if(val_7 >= (long)val_4)
        {
            goto label_10;
        }
        
        val_5 = val_4 + val_5;
        byte val_6 = this.mBuffer[val_7];
        if(val_6 == 13)
        {
            goto label_10;
        }
        
        val_7 = val_7 + 1;
        if(val_6 != 10)
        {
            goto label_11;
        }
        
        label_10:
        val_4 = (val_4 + val_5) + 1;
        label_7:
        this.mOffset = val_4;
        return (string)ByteReader.ReadLine(buffer:  this.mBuffer, start:  val_4, count:  0);
    }
    public System.Collections.Generic.Dictionary<string, string> ReadDictionary()
    {
        System.Collections.Generic.Dictionary<System.String, System.String> val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        char[] val_2 = new char[1];
        val_2[0] = '=';
        if(this.mBuffer == null)
        {
                return val_1;
        }
        
        do
        {
            if(this.mOffset >= this.mBuffer.Length)
        {
                return val_1;
        }
        
            string val_3 = this.ReadLine();
            if(val_3 == null)
        {
                return val_1;
        }
        
            if((val_3.StartsWith(value:  "//")) != true)
        {
                System.String[] val_5 = val_3.Split(separator:  val_2, count:  2, options:  1);
            if(val_5.Length == 2)
        {
                val_1.set_Item(key:  val_5[0].Trim(), value:  val_5[1].Trim().Replace(oldValue:  "\\n", newValue:  "\n"));
        }
        
        }
        
        }
        while(this.mBuffer != null);
        
        return val_1;
    }

}
