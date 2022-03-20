using UnityEngine;
private class AdjustAndroid.AttributionChangeListener : AndroidJavaProxy
{
    // Fields
    private System.Action<com.adjust.sdk.AdjustAttribution> callback;
    
    // Methods
    public AdjustAndroid.AttributionChangeListener(System.Action<com.adjust.sdk.AdjustAttribution> pCallback)
    {
        this.callback = pCallback;
    }
    public void onAttributionChanged(UnityEngine.AndroidJavaObject attribution)
    {
        com.adjust.sdk.AdjustAttribution val_37;
        var val_38;
        var val_39;
        var val_40;
        var val_41;
        var val_42;
        var val_43;
        var val_44;
        var val_45;
        var val_46;
        var val_47;
        var val_48;
        var val_49;
        var val_50;
        var val_51;
        var val_52;
        var val_53;
        var val_54;
        var val_55;
        var val_56;
        var val_57;
        var val_58;
        var val_59;
        var val_60;
        var val_61;
        var val_62;
        var val_63;
        var val_64;
        var val_65;
        var val_66;
        var val_67;
        var val_68;
        var val_69;
        if(this.callback == null)
        {
                return;
        }
        
        com.adjust.sdk.AdjustAttribution val_1 = null;
        val_37 = val_1;
        val_1 = new com.adjust.sdk.AdjustAttribution();
        val_38 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTrackerName), b:  "")) != true)
        {
                val_39 = null;
            val_39 = null;
        }
        
        .<trackerName>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTrackerName);
        val_40 = null;
        val_40 = null;
        val_41 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTrackerToken), b:  "")) != true)
        {
                val_42 = null;
            val_42 = null;
        }
        
        .<trackerToken>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyTrackerToken);
        val_43 = null;
        val_43 = null;
        val_44 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyNetwork), b:  "")) != true)
        {
                val_45 = null;
            val_45 = null;
        }
        
        .<network>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyNetwork);
        val_46 = null;
        val_46 = null;
        val_47 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCampaign), b:  "")) != true)
        {
                val_48 = null;
            val_48 = null;
        }
        
        .<campaign>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCampaign);
        val_49 = null;
        val_49 = null;
        val_50 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyAdgroup), b:  "")) != true)
        {
                val_51 = null;
            val_51 = null;
        }
        
        .<adgroup>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyAdgroup);
        val_52 = null;
        val_52 = null;
        val_53 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCreative), b:  "")) != true)
        {
                val_54 = null;
            val_54 = null;
        }
        
        .<creative>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCreative);
        val_55 = null;
        val_55 = null;
        val_56 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyClickLabel), b:  "")) != true)
        {
                val_57 = null;
            val_57 = null;
        }
        
        .<clickLabel>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyClickLabel);
        val_58 = null;
        val_58 = null;
        val_59 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyAdid), b:  "")) != true)
        {
                val_60 = null;
            val_60 = null;
        }
        
        .<adid>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyAdid);
        val_61 = null;
        val_61 = null;
        val_62 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCostType), b:  "")) != true)
        {
                val_63 = null;
            val_63 = null;
        }
        
        .<costType>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCostType);
        val_64 = null;
        val_64 = null;
        if((attribution.Get<UnityEngine.AndroidJavaObject>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCostAmount)) == null)
        {
            goto label_54;
        }
        
        val_65 = null;
        val_65 = null;
        UnityEngine.AndroidJavaObject val_30 = attribution.Get<UnityEngine.AndroidJavaObject>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCostAmount);
        if(val_30 == null)
        {
            goto label_54;
        }
        
        val_66 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_66 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_66 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_66 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        System.Nullable<System.Double> val_32 = new System.Nullable<System.Double>(value:  val_30.Call<System.Double>(methodName:  "doubleValue", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184));
        .<costAmount>k__BackingField = val_32.HasValue;
        goto label_61;
        label_54:
        .<costAmount>k__BackingField = 0;
        mem[1152921520293901248] = 0;
        label_61:
        val_67 = null;
        val_67 = null;
        val_68 = 0;
        if((System.String.op_Equality(a:  attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCostCurrency), b:  "")) != true)
        {
                val_69 = null;
            val_69 = null;
        }
        
        .<costCurrency>k__BackingField = attribution.Get<System.String>(fieldName:  com.adjust.sdk.AdjustUtils.KeyCostCurrency);
        this.callback.Invoke(obj:  val_1);
    }

}
