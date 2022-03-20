using UnityEngine;
private class AdjustAndroid.EventTrackingSucceededListener : AndroidJavaProxy
{
    // Fields
    private System.Action<com.adjust.sdk.AdjustEventSuccess> callback;
    
    // Methods
    public AdjustAndroid.EventTrackingSucceededListener(System.Action<com.adjust.sdk.AdjustEventSuccess> pCallback)
    {
        this.callback = pCallback;
    }
    public void onFinishedEventTrackingSucceeded(UnityEngine.AndroidJavaObject eventSuccessData)
    {
        var val_19;
        var val_20;
        var val_21;
        string val_22;
        var val_24;
        var val_25;
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
        System.Action<com.adjust.sdk.AdjustEventSuccess> val_38;
        if(eventSuccessData == null)
        {
                return;
        }
        
        if(this.callback == null)
        {
                return;
        }
        
        com.adjust.sdk.AdjustEventSuccess val_1 = new com.adjust.sdk.AdjustEventSuccess();
        val_19 = null;
        val_19 = null;
        val_20 = 0;
        if((System.String.op_Equality(a:  eventSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyAdid), b:  "")) != true)
        {
                val_21 = null;
            val_21 = null;
            val_22 = com.adjust.sdk.AdjustUtils.KeyAdid;
            string val_4 = eventSuccessData.Get<System.String>(fieldName:  val_22);
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .<Adid>k__BackingField = val_4;
        val_24 = null;
        val_24 = null;
        val_25 = 0;
        if((System.String.op_Equality(a:  eventSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyMessage), b:  "")) != true)
        {
                val_26 = null;
            val_26 = null;
        }
        
        .<Message>k__BackingField = eventSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyMessage);
        val_27 = null;
        val_27 = null;
        val_28 = 0;
        if((System.String.op_Equality(a:  eventSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTimestamp), b:  "")) != true)
        {
                val_29 = null;
            val_29 = null;
        }
        
        .<Timestamp>k__BackingField = eventSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
        val_30 = null;
        val_30 = null;
        val_31 = 0;
        if((System.String.op_Equality(a:  eventSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyEventToken), b:  "")) != true)
        {
                val_32 = null;
            val_32 = null;
        }
        
        .<EventToken>k__BackingField = eventSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyEventToken);
        val_33 = null;
        val_33 = null;
        val_34 = 0;
        if((System.String.op_Equality(a:  eventSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCallbackId), b:  "")) != true)
        {
                val_35 = null;
            val_35 = null;
        }
        
        .<CallbackId>k__BackingField = eventSuccessData.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCallbackId);
        val_36 = null;
        val_36 = null;
        val_37 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_37 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_37 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_37 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_22 = eventSuccessData.Get<UnityEngine.AndroidJavaObject>(fieldName:  com.adjust.sdk.AdjustUtils.KeyJsonResponse).Call<System.String>(methodName:  "toString", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_1.BuildJsonResponseFromString(jsonResponseString:  val_22);
        val_38 = this.callback;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        val_38.Invoke(obj:  val_1);
    }

}
