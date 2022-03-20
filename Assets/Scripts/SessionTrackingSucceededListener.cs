using UnityEngine;
private class AdjustAndroid.SessionTrackingSucceededListener : AndroidJavaProxy
{
    // Fields
    private System.Action<com.adjust.sdk.AdjustSessionSuccess> callback;
    
    // Methods
    public AdjustAndroid.SessionTrackingSucceededListener(System.Action<com.adjust.sdk.AdjustSessionSuccess> pCallback)
    {
        this.callback = pCallback;
    }
    public void onFinishedSessionTrackingSucceeded(UnityEngine.AndroidJavaObject sessionSuccessData)
    {
        var val_13;
        var val_14;
        var val_15;
        string val_16;
        var val_18;
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        System.Action<com.adjust.sdk.AdjustSessionSuccess> val_26;
        if(sessionSuccessData == null)
        {
                return;
        }
        
        if(this.callback == null)
        {
                return;
        }
        
        com.adjust.sdk.AdjustSessionSuccess val_1 = new com.adjust.sdk.AdjustSessionSuccess();
        val_13 = null;
        val_13 = null;
        val_14 = 0;
        if((System.String.op_Equality(a:  sessionSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyAdid), b:  "")) != true)
        {
                val_15 = null;
            val_15 = null;
            val_16 = com.adjust.sdk.AdjustUtils.KeyAdid;
            string val_4 = sessionSuccessData.Get<System.String>(fieldName:  val_16);
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .<Adid>k__BackingField = val_4;
        val_18 = null;
        val_18 = null;
        val_19 = 0;
        if((System.String.op_Equality(a:  sessionSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyMessage), b:  "")) != true)
        {
                val_20 = null;
            val_20 = null;
        }
        
        .<Message>k__BackingField = sessionSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyMessage);
        val_21 = null;
        val_21 = null;
        val_22 = 0;
        if((System.String.op_Equality(a:  sessionSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTimestamp), b:  "")) != true)
        {
                val_23 = null;
            val_23 = null;
        }
        
        .<Timestamp>k__BackingField = sessionSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
        val_24 = null;
        val_24 = null;
        val_25 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_25 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_25 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_25 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_16 = sessionSuccessData.Get<UnityEngine.AndroidJavaObject>(fieldName:  com.adjust.sdk.AdjustUtils.KeyJsonResponse).Call<System.String>(methodName:  "toString", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_1.BuildJsonResponseFromString(jsonResponseString:  val_16);
        val_26 = this.callback;
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.Invoke(obj:  val_1);
    }

}
