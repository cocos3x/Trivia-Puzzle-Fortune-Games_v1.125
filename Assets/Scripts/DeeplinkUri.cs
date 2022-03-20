using UnityEngine;
public class DeeplinkUri
{
    // Fields
    private System.Uri normalUri;
    private string scheme;
    private string host;
    private string query;
    private string absolutePath;
    
    // Properties
    public string Scheme { get; }
    public string Host { get; }
    public string Query { get; }
    public string AbsolutePath { get; }
    
    // Methods
    public string get_Scheme()
    {
        if((System.Uri.op_Inequality(uri1:  this.normalUri, uri2:  0)) == false)
        {
                return (string)this.scheme;
        }
        
        return this.normalUri.Scheme;
    }
    public string get_Host()
    {
        if((System.Uri.op_Inequality(uri1:  this.normalUri, uri2:  0)) == false)
        {
                return (string)this.host;
        }
        
        return this.normalUri.Host;
    }
    public string get_Query()
    {
        if((System.Uri.op_Inequality(uri1:  this.normalUri, uri2:  0)) == false)
        {
                return (string)this.query;
        }
        
        return this.normalUri.Query;
    }
    public string get_AbsolutePath()
    {
        if((System.Uri.op_Inequality(uri1:  this.normalUri, uri2:  0)) == false)
        {
                return (string)this.absolutePath;
        }
        
        return this.normalUri.AbsolutePath;
    }
    public DeeplinkUri(string uri, bool useParser = False)
    {
        bool val_2 = useParser;
        this.scheme = "";
        this.host = "";
        this.query = "";
        this.absolutePath = "";
        if(val_2 != false)
        {
                this.ParseDeeplink(uri:  uri);
            return;
        }
        
        System.Uri val_1 = null;
        val_2 = val_1;
        val_1 = new System.Uri(uriString:  uri);
        this.normalUri = val_2;
    }
    private void ParseDeeplink(string uri)
    {
        object val_13;
        System.String[] val_14;
        System.Char[] val_16;
        int val_17;
        val_14 = uri;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = "://";
        string val_2 = val_14.Substring(startIndex:  0, length:  val_14.IndexOf(value:  "://"));
        this.scheme = val_2;
        if((val_2 + "://"("://")) == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = val_14.Remove(startIndex:  0, count:  val_3.m_stringLength);
        char[] val_5 = new char[1];
        val_16 = val_5;
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_5.Length != 0)
        {
                val_16[0] = '/';
            if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
            System.String[] val_6 = val_13.Split(separator:  val_5);
            val_14 = val_6;
            if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
            val_17 = val_6.Length;
            if(val_17 == 0)
        {
                return;
        }
        
            if(val_17 == 1)
        {
                this.host = this.SaveAndExtractQuery(uriComponent:  val_14[0]);
            return;
        }
        
            if(val_17 >= 1)
        {
                var val_15 = 0;
            do
        {
            if(val_15 == 0)
        {
                if(val_17 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
            this.host = val_14[0];
            val_17 = val_6.Length;
        }
        
            if(val_15 == (val_17 - 1))
        {
                if(val_15 >= val_17)
        {
                throw new IndexOutOfRangeException();
        }
        
            string val_9 = this.SaveAndExtractQuery(uriComponent:  null);
            if(val_9 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
            val_17 = val_6.Length;
            if(val_15 >= val_17)
        {
                throw new IndexOutOfRangeException();
        }
        
            mem2[0] = val_9;
        }
        
            val_15 = val_15 + 1;
        }
        while(val_15 < (val_17 << ));
        
        }
        
            this.absolutePath = System.String.Format(format:  "/{0}/", arg0:  System.String.Join(separator:  "/", value:  val_14));
            return;
        }
        
        val_16 = 0;
        throw new IndexOutOfRangeException();
    }
    private string SaveAndExtractQuery(string uriComponent)
    {
        var val_5;
        int val_1 = uriComponent.IndexOf(value:  '?');
        if(val_1 == 1)
        {
            goto label_2;
        }
        
        string val_2 = uriComponent.Substring(startIndex:  0, length:  val_1);
        val_5 = val_2;
        if((System.String.IsNullOrEmpty(value:  val_2)) == false)
        {
            goto label_3;
        }
        
        this.query = uriComponent;
        val_5 = "";
        return (string)val_5;
        label_2:
        val_5 = uriComponent;
        return (string)val_5;
        label_3:
        this.query = uriComponent.Remove(startIndex:  0, count:  val_2.m_stringLength);
        return (string)val_5;
    }

}
