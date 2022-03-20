using UnityEngine;
private class AdjustAndroid.SessionTrackingFailedListener : AndroidJavaProxy
{
    // Fields
    private System.Action<com.adjust.sdk.AdjustSessionFailure> callback;
    
    // Methods
    public AdjustAndroid.SessionTrackingFailedListener(System.Action<com.adjust.sdk.AdjustSessionFailure> pCallback)
    {
        this.callback = pCallback;
    }
    public void onFinishedSessionTrackingFailed(UnityEngine.AndroidJavaObject sessionFailureData)
    {
        var val_15;
        var val_16;
        var val_17;
        string val_18;
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        System.Action<com.adjust.sdk.AdjustSessionFailure> val_28;
        if(sessionFailureData == null)
        {
                return;
        }
        
        if(this.callback == null)
        {
                return;
        }
        
        com.adjust.sdk.AdjustSessionFailure val_1 = new com.adjust.sdk.AdjustSessionFailure();
        val_15 = null;
        val_15 = null;
        val_16 = 0;
        if((System.String.op_Equality(a:  sessionFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyAdid), b:  "")) != true)
        {
                val_17 = null;
            val_17 = null;
            val_18 = com.adjust.sdk.AdjustUtils.KeyAdid;
            string val_4 = sessionFailureData.Get<System.String>(fieldName:  val_18);
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .<Adid>k__BackingField = val_4;
        val_20 = null;
        val_20 = null;
        val_21 = 0;
        if((System.String.op_Equality(a:  sessionFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyMessage), b:  "")) != true)
        {
                val_22 = null;
            val_22 = null;
        }
        
        .<Message>k__BackingField = sessionFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyMessage);
        val_23 = null;
        val_23 = null;
        .<WillRetry>k__BackingField = sessionFailureData.Get<System.Boolean>(fieldName:  com.adjust.sdk.AdjustUtils.KeyWillRetry);
        val_24 = 0;
        if((System.String.op_Equality(a:  sessionFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTimestamp), b:  "")) != true)
        {
                val_25 = null;
            val_25 = null;
        }
        
        .<Timestamp>k__BackingField = sessionFailureData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
        val_26 = null;
        val_26 = null;
        val_27 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_27 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_27 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_27 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_18 = sessionFailureData.Get<UnityEngine.AndroidJavaObject>(fieldName:  com.adjust.sdk.AdjustUtils.KeyJsonResponse).Call<System.String>(methodName:  "toString", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_1.BuildJsonResponseFromString(jsonResponseString:  val_18);
        val_28 = this.callback;
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28.Invoke(obj:  val_1);
    }

}
