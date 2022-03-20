using UnityEngine;
[Serializable]
public class TRVExpert
{
    // Fields
    public string expertName;
    public TRVExpertRarites rarity;
    public UnityEngine.Sprite mySprite;
    public int totalPotential;
    public int totalDefault;
    public System.Collections.Generic.List<TRVCategoryProficiencies> myProfs;
    
    // Properties
    public string GetLocalizedName { get; }
    
    // Methods
    public string get_GetLocalizedName()
    {
        return Localization.Localize(key:  System.String.Format(format:  "experts_{0}", arg0:  this.expertName.Replace(oldValue:  " ", newValue:  "_").ToLower()), defaultValue:  this.expertName.ToUpper(), useSingularKey:  false);
    }
    public TRVExpert()
    {
    
    }
    public bool SetupExpert(string data)
    {
        System.Type val_18;
        string val_19;
        var val_20;
        object val_21;
        var val_23;
        var val_24;
        var val_27;
        val_18 = data;
        char[] val_1 = new char[1];
        val_1[0] = '	';
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>(collection:  val_18.Split(separator:  val_1));
        if(1152921515438511520 >= 1)
        {
                this.expertName = public System.String SRDebugger_Instantiator::GetLPNsLog();
            val_3.RemoveAt(index:  0);
            if((public System.String SRDebugger_Instantiator::GetLPNsLog()) >= 1)
        {
                val_19 = 1152921504951734272;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_20 = 1152921504617496576;
            val_21 = mem[System.Type.__il2cppRuntimeField_cctor_finished + 32];
            val_21 = System.Type.__il2cppRuntimeField_cctor_finished + 32;
            if((System.Enum.IsDefined(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_21)) != false)
        {
                val_18 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            object val_7 = System.Enum.Parse(enumType:  val_18, value:  System.Type.__il2cppRuntimeField_cctor_finished + 32, ignoreCase:  true);
            this.rarity = null;
        }
        else
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_21 = System.Environment.NewLine;
            val_18 = System.Enum.__il2cppRuntimeField_cctor_finished + 32(System.Enum.__il2cppRuntimeField_cctor_finished + 32) + " is not defined" + val_21 + PrettyPrint.printJSON(obj:  val_18, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  val_18, types:  false, singleLineOutput:  false));
            UnityEngine.Debug.LogError(message:  val_18);
        }
        
            val_3.RemoveAt(index:  0);
            if((null >= 1) && ((System.Int32.TryParse(s:  UnityEngine.Debug.__il2cppRuntimeField_byval_arg, result: out  this.totalPotential)) != false))
        {
                val_3.RemoveAt(index:  0);
            if((System.Int32.TryParse(s:  64, result: out  this.totalDefault)) != false)
        {
                val_3.RemoveAt(index:  0);
            System.Collections.Generic.List<TRVCategoryProficiencies> val_15 = null;
            val_18 = val_15;
            val_15 = new System.Collections.Generic.List<TRVCategoryProficiencies>();
            if(1152921517151199104 >= 1)
        {
                val_20 = 1152921504957857792;
            val_23 = 0;
            do
        {
            val_24 = null;
            val_24 = null;
            if(1152921517151199104 <= val_23)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_21 = 0;
            if((TRVEcon.DefaultCategoryUnlockLevels.ContainsKey(key:  public System.Boolean System.Nullable<System.DateTimeOffset>::get_HasValue())) != false)
        {
                if(44248336 <= val_23)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(44248336 <= (val_23 + 1))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_21 = mem[(TRVEcon.__il2cppRuntimeField_static_fields + ((val_23 + 1)) << 3) + 32];
            val_21 = (TRVEcon.__il2cppRuntimeField_static_fields + ((val_23 + 1)) << 3) + 32;
            val_23 = val_23 + 2;
            if(44248336 <= val_23)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_19 = mem[(TRVEcon.__il2cppRuntimeField_static_fields + ((val_23 + 2)) << 3) + 32];
            val_19 = (TRVEcon.__il2cppRuntimeField_static_fields + ((val_23 + 2)) << 3) + 32;
            val_15.Add(item:  new TRVCategoryProficiencies(cat:  TRVEcon.overridenInitialValues.__il2cppRuntimeField_20, maxPot:  val_21, incDefault:  val_19));
        }
        
            val_23 = val_23 + 1;
        }
        while(val_23 < 1152921517151205248);
        
        }
        
            val_27 = 1;
            this.myProfs = val_18;
            return (bool)val_27;
        }
        
        }
        
        }
        
        }
        
        val_27 = 0;
        return (bool)val_27;
    }

}
