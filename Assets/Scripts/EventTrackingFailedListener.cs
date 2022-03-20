using UnityEngine;
private class AdjustAndroid.EventTrackingFailedListener : AndroidJavaProxy
{
    // Fields
    private System.Action<com.adjust.sdk.AdjustEventFailure> callback;
    
    // Methods
    public AdjustAndroid.EventTrackingFailedListener(System.Action<com.adjust.sdk.AdjustEventFailure> pCallback)
    {
        this.callback = pCallback;
    }
    public void onFinishedEventTrackingFailed(UnityEngine.AndroidJavaObject eventFailureData)
    {
        var val_21;
        var val_22;
        var val_23;
        string val_24;
        var val_26;
        var val_27;
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        var val_32;
        var val_33;
        var val_34;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        var val_39;
        System.Action<com.adjust.sdk.AdjustEventFailure> val_40;
        if(eventFailureData == null)
        {
                return;
        }
        
        if(this.callback == null)
        {
                return;
        }
        
        com.adjust.sdk.AdjustEventFailure val_1 = new com.adjust.sdk.AdjustEventFailure();
        val_21 = null;
        val_21 = null;
        val_22 = 0;
        if((System.String.op_Equality(a:  eventFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyAdid), b:  "")) != true)
        {
                val_23 = null;
            val_23 = null;
            val_24 = com.adjust.sdk.AdjustUtils.KeyAdid;
            string val_4 = eventFailureData.Get<System.String>(fieldName:  val_24);
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .<Adid>k__BackingField = val_4;
        val_26 = null;
        val_26 = null;
        val_27 = 0;
        if((System.String.op_Equality(a:  eventFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyMessage), b:  "")) != true)
        {
                val_28 = null;
            val_28 = null;
        }
        
        .<Message>k__BackingField = eventFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyMessage);
        val_29 = null;
        val_29 = null;
        .<WillRetry>k__BackingField = eventFailureData.Get<System.Boolean>(fieldName:  com.adjust.sdk.AdjustUtils.KeyWillRetry);
        val_30 = 0;
        if((System.String.op_Equality(a:  eventFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTimestamp), b:  "")) != true)
        {
                val_31 = null;
            val_31 = null;
        }
        
        .<Timestamp>k__BackingField = eventFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
        val_32 = null;
        val_32 = null;
        val_33 = 0;
        if((System.String.op_Equality(a:  eventFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyEventToken), b:  "")) != true)
        {
                val_34 = null;
            val_34 = null;
        }
        
        .<EventToken>k__BackingField = eventFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyEventToken);
        val_35 = null;
        val_35 = null;
        val_36 = 0;
        if((System.String.op_Equality(a:  eventFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCallbackId), b:  "")) != true)
        {
                val_37 = null;
            val_37 = null;
        }
        
        .<CallbackId>k__BackingField = eventFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCallbackId);
        val_38 = null;
        val_38 = null;
        val_39 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_39 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_39 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_39 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_24 = eventFailureData.Get<UnityEngine.AndroidJavaObject>(fieldName:  com.adjust.sdk.AdjustUtils.KeyJsonResponse).Call<System.String>(methodName:  "toString", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_1.BuildJsonResponseFromString(jsonResponseString:  val_24);
        val_40 = this.callback;
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        val_40.Invoke(obj:  val_1);
    }

}
