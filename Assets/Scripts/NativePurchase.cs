using UnityEngine;
public class NativePurchase
{
    // Fields
    private NativePurchaseErrorCode errorCode;
    private string purchaseId;
    private string sku;
    private string packageName;
    private string token;
    private string signature;
    private string stuff;
    private string errorString;
    private string kindleUserId;
    private string originalJson;
    private bool isSubscription;
    private bool isConsumable;
    private bool isPending;
    
    // Properties
    public string Sku { get; set; }
    public string PackageName { get; set; }
    public static string Platform { get; }
    public string PurchaseId { get; set; }
    public string Token { get; set; }
    public string Signature { get; set; }
    public string ErrorString { get; set; }
    public string KindleUserId { get; set; }
    public string OriginalJson { get; set; }
    public NativePurchaseErrorCode ErrorCode { get; set; }
    public string RawError { get; set; }
    public bool IsSubscription { get; }
    public bool IsConsumable { get; }
    public bool IsPending { get; set; }
    
    // Methods
    public string get_Sku()
    {
        return (string)this.sku;
    }
    public void set_Sku(string value)
    {
        this.sku = value;
    }
    public string get_PackageName()
    {
        return (string)this.packageName;
    }
    public void set_PackageName(string value)
    {
        this.packageName = value;
    }
    public static string get_Platform()
    {
        return "android";
    }
    public string get_PurchaseId()
    {
        return (string)this.purchaseId;
    }
    public void set_PurchaseId(string value)
    {
        this.purchaseId = value;
    }
    public string get_Token()
    {
        return (string)this.token;
    }
    public void set_Token(string value)
    {
        this.token = value;
    }
    public string get_Signature()
    {
        return (string)this.signature;
    }
    public void set_Signature(string value)
    {
        this.signature = value;
    }
    public string get_ErrorString()
    {
        return (string)this.token;
    }
    public void set_ErrorString(string value)
    {
        this.token = value;
    }
    public string get_KindleUserId()
    {
        return (string)this.kindleUserId;
    }
    public void set_KindleUserId(string value)
    {
        if(value != null)
        {
                this.kindleUserId = value;
            return;
        }
        
        this.kindleUserId = "no_id";
    }
    public string get_OriginalJson()
    {
        return (string)this.originalJson;
    }
    public void set_OriginalJson(string value)
    {
        this.originalJson = value;
    }
    public NativePurchaseErrorCode get_ErrorCode()
    {
        return (NativePurchaseErrorCode)this.errorCode;
    }
    public void set_ErrorCode(NativePurchaseErrorCode value)
    {
        this.errorCode = value;
    }
    public string get_RawError()
    {
        return (string)this.errorString;
    }
    public void set_RawError(string value)
    {
        this.errorString = value;
    }
    public bool get_IsSubscription()
    {
        return (bool)this.isSubscription;
    }
    public bool get_IsConsumable()
    {
        return (bool)this.isConsumable;
    }
    public bool get_IsPending()
    {
        return (bool)this.isPending;
    }
    public void set_IsPending(bool value)
    {
        this.isPending = value;
    }
    public NativePurchase()
    {
    
    }
    public NativePurchase(string sku)
    {
        this.sku = sku;
        AppConfigs val_1 = App.Configuration;
        ProductDetails val_2 = val_1.storeConfig.GetProductBySku(sku:  sku);
        this.isSubscription = (val_2.productType == 2) ? 1 : 0;
        this.isConsumable = (val_2.productType == 0) ? 1 : 0;
    }
    public NativePurchase(NativePurchaseErrorCode errorCode, string errorString)
    {
        val_1 = new System.Object();
        this.errorCode = errorCode;
        this.errorString = val_1;
    }
    private static NativePurchaseErrorCode setNativePurchaseErrorCodeKindle(string error)
    {
        var val_12;
        if((error.ToUpper().Contains(value:  "UNKNOWN")) != false)
        {
                val_12 = 3;
            return (NativePurchaseErrorCode)((error.ToUpper().Contains(value:  "SUCCESSFUL")) != true) ? 0 : 6;
        }
        
        if((error.ToUpper().Contains(value:  "ALREADY_PURCHASED")) == false)
        {
            goto label_6;
        }
        
        label_12:
        val_12 = 5;
        return (NativePurchaseErrorCode)((error.ToUpper().Contains(value:  "SUCCESSFUL")) != true) ? 0 : 6;
        label_6:
        if((error.ToUpper().Contains(value:  "FAILED")) != false)
        {
                val_12 = 1;
            return (NativePurchaseErrorCode)((error.ToUpper().Contains(value:  "SUCCESSFUL")) != true) ? 0 : 6;
        }
        
        if((error.ToUpper().Contains(value:  "INVALID_SKU")) == true)
        {
            goto label_12;
        }
        
        return (NativePurchaseErrorCode)((error.ToUpper().Contains(value:  "SUCCESSFUL")) != true) ? 0 : 6;
    }
    private static NativePurchaseErrorCode setNativePurchaseErrorCodeAndroid(string error)
    {
        var val_14;
        if((error.Contains(value:  "100")) != false)
        {
                val_14 = 5;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "-1")) != false)
        {
                val_14 = 16;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "-2")) != false)
        {
                val_14 = 12;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "-3")) != false)
        {
                val_14 = 17;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "1")) != false)
        {
                val_14 = 3;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "2")) != false)
        {
                val_14 = 18;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "3")) != false)
        {
                val_14 = 9;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "4")) != false)
        {
                val_14 = 15;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "5")) != false)
        {
                val_14 = 10;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "6")) != false)
        {
                val_14 = 11;
            return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        if((error.Contains(value:  "7")) == false)
        {
                return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
        }
        
        val_14 = 13;
        return (NativePurchaseErrorCode)((error.Contains(value:  "8")) != true) ? 14 : 6;
    }
    public static NativePurchaseErrorCode setNavitePurchaseErrorCode(string error)
    {
        if((System.String.op_Equality(a:  "android", b:  "android")) != false)
        {
                return NativePurchase.setNativePurchaseErrorCodeAndroid(error:  error);
        }
        
        if((System.String.op_Equality(a:  "android", b:  "kindle")) == false)
        {
                return 6;
        }
        
        return NativePurchase.setNativePurchaseErrorCodeKindle(error:  error);
    }
    public void AddStoreSpecificDataForValidation(ref System.Collections.Generic.Dictionary<string, object> postParams)
    {
        string val_5;
        string val_6;
        postParams.Add(key:  "store", value:  "android");
        if((System.String.op_Equality(a:  "android", b:  "android")) == false)
        {
            goto label_4;
        }
        
        postParams.Add(key:  "package_name", value:  this.packageName);
        postParams.Add(key:  "product_id", value:  this.sku);
        label_22:
        postParams.Add(key:  "token", value:  this.token);
        postParams.Add(key:  "signature", value:  this.signature);
        val_5 = this.originalJson;
        val_6 = "originalJson";
        goto label_14;
        label_4:
        if((System.String.op_Equality(a:  "android", b:  "ios")) == false)
        {
            goto label_11;
        }
        
        postParams.Add(key:  "receipt_data", value:  this.token);
        val_5 = this.purchaseId;
        val_6 = "purchase_id";
        goto label_14;
        label_11:
        if((System.String.op_Equality(a:  "android", b:  "kindle")) == false)
        {
            goto label_15;
        }
        
        postParams.Add(key:  "product_id", value:  this.sku);
        postParams.Add(key:  "k_user_id", value:  this.kindleUserId);
        val_5 = this.token;
        val_6 = "purchase_token";
        label_14:
        label_26:
        postParams.Add(key:  val_6, value:  val_5);
        return;
        label_15:
        if((System.String.op_Equality(a:  "android", b:  "webgl")) == false)
        {
            goto label_19;
        }
        
        postParams.Add(key:  "product_id", value:  this.sku);
        goto label_22;
        label_19:
        postParams.Add(key:  "package_name", value:  this.packageName);
        postParams.Add(key:  "product_id", value:  this.sku);
        goto label_26;
    }

}
