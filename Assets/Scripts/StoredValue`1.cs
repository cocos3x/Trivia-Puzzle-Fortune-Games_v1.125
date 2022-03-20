using UnityEngine;
public class StoredValue<T>
{
    // Fields
    public System.Action onValueChanged;
    public string key;
    public T defaultValue;
    
    // Methods
    public StoredValue<T>(string key, T defaultValue)
    {
        val_1 = new System.Object();
        mem[1152921515399479256] = key;
        mem[1152921515399479264] = val_1;
    }
    public void ChangeValue(T delta)
    {
        System.Type val_20;
        System.Type val_1 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192});
        if((System.Type.op_Equality(left:  val_1, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
        {
                CPlayerPrefs.SetInt(key:  __RuntimeMethodHiddenParam, val:  (System.Convert.ToInt32(value:  delta)) + (CPlayerPrefs.GetInt(key:  __RuntimeMethodHiddenParam, defaultValue:  System.Convert.ToInt32(value:  val_1))));
        }
        else
        {
                System.Type val_8 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192});
            if((System.Type.op_Equality(left:  val_8, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
        {
                float val_13 = System.Convert.ToSingle(value:  delta);
            val_13 = (CPlayerPrefs.GetFloat(key:  __RuntimeMethodHiddenParam, defaultValue:  System.Convert.ToSingle(value:  val_8))) + val_13;
            CPlayerPrefs.SetFloat(key:  __RuntimeMethodHiddenParam, val:  val_13);
        }
        else
        {
                val_20 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192});
            if((System.Type.op_Equality(left:  val_20, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
        {
                double val_19 = System.Convert.ToDouble(value:  delta);
            val_19 = (CPlayerPrefs.GetDouble(key:  val_20, defaultValue:  System.Convert.ToDouble(value:  val_8))) + val_19;
            CPlayerPrefs.SetDouble(key:  val_20, value:  val_19);
        }
        
        }
        
        }
        
        if(val_20 == null)
        {
                return;
        }
        
        val_20.Invoke();
    }
    public void SetValue(T value)
    {
        if((System.Type.op_Equality(left:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192}), right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
        {
                CPlayerPrefs.SetInt(key:  this, val:  System.Convert.ToInt32(value:  value));
            return;
        }
        
        if((System.Type.op_Equality(left:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192}), right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
        {
                CPlayerPrefs.SetFloat(key:  this, val:  System.Convert.ToSingle(value:  value));
            return;
        }
        
        if((System.Type.op_Equality(left:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192}), right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
        {
                return;
        }
        
        CPlayerPrefs.SetDouble(key:  this, value:  System.Convert.ToDouble(value:  value));
    }
    public T GetValue()
    {
        var val_16;
        var val_17;
        var val_18;
        System.Type val_1 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192});
        if((System.Type.op_Equality(left:  val_1, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
        {
                int val_5 = CPlayerPrefs.GetInt(key:  val_1, defaultValue:  System.Convert.ToInt32(value:  this));
            val_16 = null;
        }
        else
        {
                System.Type val_6 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192});
            if((System.Type.op_Equality(left:  val_6, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
        {
                float val_10 = CPlayerPrefs.GetFloat(key:  val_6, defaultValue:  System.Convert.ToSingle(value:  this));
            val_17 = 1152921504622129152;
        }
        else
        {
                val_17 = 1152921504617336832;
        }
        
        }
        
        if((System.Convert.ChangeType(value:  CPlayerPrefs.GetDouble(key:  val_6, defaultValue:  System.Convert.ToDouble(value:  this)), conversionType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192}))) != null)
        {
                if(X0 == true)
        {
                return (object)val_18;
        }
        
        }
        
        val_18 = 0;
        return (object)val_18;
    }

}
